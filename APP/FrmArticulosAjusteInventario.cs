using APP.Buscar;
using Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP
{
    public partial class FrmArticulosAjusteInventario : Form
    {
        public FrmArticulosAjusteInventario()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Delete)
            {
                btnBorrar.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private readonly NArticulos _articulos = new NArticulos();

        private void FrmArticulosAjusteInventario_Load(object sender, EventArgs e)
        {
            btnNuevo.PerformClick();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = null;
            txtNombre.Text = null;
            cboAj.SelectedIndex = 0;
            txtCantidad.Text = null;
            txtCosto.Text = null;
            txtNota.Text = null;
            errorCodigo.Clear();
            dgvListar.Rows.Clear();
        }

        private void linkCodigo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBuscarArticulos frm = new FrmBuscarArticulos();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                errorCodigo.Clear();
                txtIdArticulo.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                txtCodigo.Text = frm.dgvListar.SelectedCells[1].Value.ToString();
                txtNombre.Text = frm.dgvListar.SelectedCells[3].Value.ToString();
                txtCosto.Text = frm.dgvListar.SelectedCells[9].Value.ToString();
                _ = cboAj.Focus();
            }
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                DataTable articulo = _articulos.BuscarCodigo(txtCodigo.Text);
                if (articulo.Rows.Count > 0)
                {
                    errorCodigo.Clear();
                    txtIdArticulo.Text = articulo.Rows[0][0].ToString();
                    txtCodigo.Text = articulo.Rows[0][4].ToString();
                    txtNombre.Text = articulo.Rows[0][5].ToString();
                    txtCosto.Text = articulo.Rows[0][9].ToString();
                }
                else
                {
                    txtIdArticulo.Text = "";
                    txtNombre.Text = null;
                    txtCosto.Text = null;
                }
            }
            else
            {
                txtIdArticulo.Text = "";
                txtNombre.Text = null;
                txtCosto.Text = null;
            }
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Right)
            {
                e.SuppressKeyPress = true;
                _ = cboAj.Focus();
            }
        }

        private void cboAj_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = txtCantidad.Focus();
            }
            else if (e.KeyCode == Keys.Right)
            {
                _ = txtCantidad.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                _ = txtCodigo.Focus();
            }
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    errorCodigo.SetError(linkCodigo, "No Existe el articulo");
                    _ = txtCodigo.Focus();
                    return;
                }
                else
                {
                    errorCodigo.Clear();
                    dgvListar.Rows.Add(txtIdArticulo.Text, txtCodigo.Text, txtNombre.Text, cboAj.Text,
                        txtCantidad.Text, txtCosto.Text);
                    txtCodigo.Text = null;
                    txtIdArticulo.Text = "";
                    txtNombre.Text = null;
                    txtCosto.Text = null;
                    txtCantidad.Text = null;
                    _ = txtCodigo.Focus();
                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                _ = cboAj.Focus();
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvListar.RowCount > 0)
            {
                dgvListar.Rows.Remove(dgvListar.CurrentRow);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dgvListar.RowCount > 0)
            {
                DataTable Detalle = new DataTable();
                Detalle.Columns.Add("[idArticulo]", typeof(int));
                Detalle.Columns.Add("[cantidad]", typeof(decimal));
                Detalle.Columns.Add("[tipoAjuste]", typeof(char));
                Detalle.Columns.Add("[costo]", typeof(decimal));
                for (int i = 0; i < dgvListar.RowCount; i++)
                {
                    DataRow row = Detalle.NewRow();
                    row[0] = Convert.ToInt32(dgvListar.Rows[i].Cells[0].Value);
                    row[1] = Convert.ToDecimal(dgvListar.Rows[i].Cells[4].Value);
                    row[2] = dgvListar.Rows[i].Cells[3].Value.ToString();
                    row[3] = Convert.ToDecimal(dgvListar.Rows[i].Cells[5].Value);
                    Detalle.Rows.Add(row);
                    string query = string.Format(@"UPDATE Articulo SET cantidad_articulo = 
                                               cantidad_articulo {0} '{1}' WHERE id_articulo = {2}",
                                               dgvListar.Rows[i].Cells[3].Value.ToString(),
                                               dgvListar.Rows[i].Cells[4].Value.ToString(),
                                               dgvListar.Rows[i].Cells[0].Value.ToString());
                    if (dgvListar.Rows[i].Cells[3].Value.ToString() == "=")
                    {
                        query = string.Format(@"UPDATE Articulo SET cantidad_articulo = {0}
                                                WHERE id_articulo = {1}",
                                               dgvListar.Rows[i].Cells[4].Value.ToString(),
                                               dgvListar.Rows[i].Cells[0].Value.ToString());
                    }
                    _articulos.Buscar(query);
                }
                _articulos.InsertarAjuste(DateTime.Now, txtNota.Text, Detalle);
                btnNuevo.PerformClick();
            }
            else
            {
                MessageBox.Show("No hay articulos para Ajustar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult msj = MessageBox.Show("Desea Salir", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msj == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
