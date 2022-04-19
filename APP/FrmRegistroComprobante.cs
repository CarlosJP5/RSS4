using Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP
{
    public partial class FrmRegistroComprobante : Form
    {
        public FrmRegistroComprobante()
        {
            InitializeComponent();

            cboTipoComprobante.DataSource = _comprobante.Listar();
            cboTipoComprobante.ValueMember = "id_comprobante";
            cboTipoComprobante.DisplayMember = "nombre_comprobante";
        }

        private readonly NComprobantes _comprobante = new NComprobantes();

        private void LlenarDataGrid()
        {
            dgvListar.Rows.Clear();
            DataTable comprobantes = _comprobante.ListarCantidad();
            foreach (DataRow row in comprobantes.Rows)
            {
                DateTime fecha = DateTime.Parse(row[6].ToString());
                _ = dgvListar.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], fecha.ToString("dd / MM / yyyy"), row[7]);
            }
        }

        private void FrmRegistroComprobante_Load(object sender, EventArgs e)
        {
            LlenarDataGrid();            
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            _ = ValidateChildren();
            if (!txtDesde.AllowDrop && !txtHasta.AllowDrop)
            {
                int desde = Convert.ToInt32(txtDesde.Text);
                int hasta = Convert.ToInt32(txtHasta.Text);
                for (int i = 0; i < dgvListar.RowCount; i++)
                {
                    if (cboTipoComprobante.SelectedValue.ToString() == dgvListar.Rows[i].Cells[1].Value.ToString())
                    {
                        if (desde <= (int)dgvListar.Rows[i].Cells[4].Value)
                        {
                            _ = MessageBox.Show("Error en la Secuencia! " + cboTipoComprobante.SelectedValue.ToString() 
                                + "\n\nEsta secuancia ya existe, favor revisar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (desde > hasta)
                {
                    _ = MessageBox.Show("Error en el Orden de la Secuencia!\n\nDesde: "
                        + desde.ToString() + " no puede ser Mayor que Hasta: " + hasta.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                _comprobante.InsertarCantidad(cboTipoComprobante.SelectedValue.ToString(),
                    txtDesde.Text, txtHasta.Text, dtpFechaVencimiento.Value.Date);

                txtDesde.Text = null;
                txtHasta.Text = null;
                LlenarDataGrid();
                _ = cboTipoComprobante.Focus();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvListar.Rows.Count > 0)
            {
                _comprobante.BorrarCantidad((int)dgvListar.SelectedCells[0].Value);
                LlenarDataGrid();
            }
        }

        private void txtDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDesde_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDesde.Text))
            {
                txtDesde.AllowDrop = true;
                errorDesde.SetError(txtDesde, "Campo Requerido");
            }
            else
            {
                txtDesde.AllowDrop = false;
                errorDesde.Clear();
            }
        }

        private void txtHasta_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtHasta.Text))
            {
                txtHasta.AllowDrop = true;
                errorHasta.SetError(txtHasta, "Campo Requerido");
            }
            else
            {
                txtHasta.AllowDrop = false;
                errorHasta.Clear();
            }
        }

        private void cboTipoComprobante_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = txtDesde.Focus();
            }
        }

        private void txtDesde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = txtHasta.Focus();
            }
        }

        private void txtHasta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSalvar.PerformClick();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
