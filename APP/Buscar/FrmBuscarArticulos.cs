using Entidades.EClases;
using Negocios;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace APP.Buscar
{
    public partial class FrmBuscarArticulos : Form
    {

        public FrmBuscarArticulos()
        {
            InitializeComponent();
            txtBuscar.Text = EParametro.BuscaArticulo;
        }

        private readonly NArticulos _articulo = new NArticulos();

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
            if (!txtBuscar.Focused)
            {
                if (keyData == Keys.NumPad0 || keyData == Keys.NumPad1 || keyData == Keys.NumPad2 || keyData == Keys.NumPad3 ||
                    keyData == Keys.NumPad4 || keyData == Keys.NumPad5 || keyData == Keys.NumPad6 || keyData == Keys.NumPad7 ||
                    keyData == Keys.NumPad8 || keyData == Keys.NumPad9 || keyData == Keys.Q || keyData == Keys.W ||
                    keyData == Keys.E || keyData == Keys.R || keyData == Keys.T || keyData == Keys.Y ||
                    keyData == Keys.U || keyData == Keys.I || keyData == Keys.O || keyData == Keys.P ||
                    keyData == Keys.A || keyData == Keys.S || keyData == Keys.D || keyData == Keys.F ||
                    keyData == Keys.K || keyData == Keys.J || keyData == Keys.H || keyData == Keys.G ||
                    keyData == Keys.L || keyData == Keys.Z || keyData == Keys.X || keyData == Keys.C ||
                    keyData == Keys.M || keyData == Keys.N || keyData == Keys.B || keyData == Keys.V)
                {
                    txtBuscar.Focus();
                    string key = keyData.ToString();
                    if (key.StartsWith("NumPad"))
                    {
                        key = key.Substring(6);
                    }
                    txtBuscar.Text = key;
                }
                if (keyData >= Keys.D0 && keyData <= Keys.D9)
                {
                    txtBuscar.Focus();
                    txtBuscar.Text = keyData.ToString();
                }
                if (keyData == Keys.Back || keyData == Keys.Space)
                {
                    txtBuscar.Focus();
                }
                txtBuscar.SelectionStart = txtBuscar.Text.Length;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void FrmBuscarArticulos_Load(object sender, EventArgs e)
        {
            rbtnTodo.Checked = true;
            DataTable articulo = _articulo.Listar();
            foreach (DataRow rowArt in articulo.Rows)
            {
                _ = dgvListar.Rows.Add(rowArt[0], rowArt[1], rowArt[2], rowArt[3],
                                       rowArt[4], rowArt[5], rowArt[6], rowArt[7],
                                       rowArt[8], rowArt[9], rowArt[11]);
            }
            PintarRow();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvListar.Rows.Clear();
            string query = @"SELECT A.id_articulo, codigo_articulo, referencia_articulo, nombre_articulo,
	                         nombre_marca, cantidad_articulo, precio_articulo, estado_articulo, I.porciento_itbis,
                             A.costo_articulo, A.beneficio_minimo, A.puntoReorden_articulo
	                         FROM Articulo A LEFT JOIN ArticuloMarca M ON A.id_marca = M.id_marca
                             LEFT JOIN ArticuloItbis I ON A.id_itbis = I.id_itbis";
            
            if (rbtnTodo.Checked)
            {
                query += string.Format(@" WHERE codigo_articulo LIKE '%'+'{0}'+'%' OR nombre_articulo
                                          LIKE '%'+'{0}'+'%' OR referencia_articulo LIKE '%'+'{0}'+'%'
                                          OR nombre_marca LIKE '%'+'{0}'+'%'", txtBuscar.Text);
            }
            else if (rbtnCodigo.Checked)
            {
                query += string.Format(" WHERE codigo_articulo LIKE '%'+'{0}'+'%'", txtBuscar.Text);
            }
            else if (rbtnNombre.Checked)
            {
                query += string.Format(" WHERE nombre_articulo LIKE '%'+'{0}'+'%'", txtBuscar.Text);
            }
            else if (rbtnReferencia.Checked)
            {
                query += string.Format(" WHERE referencia_articulo LIKE '%'+'{0}'+'%'", txtBuscar.Text);
            }
            else if (rbtnMarca.Checked)
            {
                query += string.Format(" WHERE nombre_marca LIKE '%'+'{0}'+'%'", txtBuscar.Text);
            }
            query += " ORDER BY nombre_articulo";
            DataTable articulo = _articulo.Buscar(query);
            foreach (DataRow rowArt in articulo.Rows)
            {
                _ = dgvListar.Rows.Add(rowArt[0], rowArt[1], rowArt[2], rowArt[3],
                                       rowArt[4], rowArt[5], rowArt[6], rowArt[7],
                                       rowArt[8], rowArt[9], rowArt[11]);
            }
            if (dgvListar.RowCount > 0)
            {
                dgvListar.Focus();
            }
            PintarRow();
        }

        private void dgvListar_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvListar.RowCount > 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dgvListar.CurrentRow.Selected = true;
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    EParametro.BuscaArticulo = txtBuscar.Text;
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void PintarRow()
        {
            foreach (DataGridViewRow row in dgvListar.Rows)
            {
                if (Convert.ToDouble(row.Cells[5].Value) <= Convert.ToDouble(row.Cells[10].Value))
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(240, 65, 65);
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvListar.RowCount > 0)
            {
                EParametro.BuscaArticulo = txtBuscar.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            EParametro.BuscaArticulo = txtBuscar.Text;
            DialogResult = DialogResult.Cancel;
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnBuscar.PerformClick();
            }
        }

        private void rbtnTodo_CheckedChanged(object sender, EventArgs e)
        {
            _ = txtBuscar.Focus();
        }

        private void dgvListar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListar.RowCount > 0)
            {
                EParametro.BuscaArticulo = txtBuscar.Text;
                DialogResult = DialogResult.OK;
            }
        }
    }
}
