using Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP.Buscar
{
    public partial class FrmBuscarCompras : Form
    {
        public FrmBuscarCompras()
        {
            InitializeComponent();
        }

        private readonly NCompras _compra = new NCompras();

        private void FrmBuscarCompras_Load(object sender, EventArgs e)
        {
            cboTipoCompra.SelectedIndex = 2;
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today.AddHours(23.99999);
            DataTable dt = _compra.Listar(dtpDesde.Value, dtpHasta.Value);
            foreach (DataRow row in dt.Rows)
            {
                DateTime fecha = DateTime.Parse(row[2].ToString());
                _ = dgvListar.Rows.Add(row[0], row[1], fecha.ToString("dd / MM / yyy"), row[3], row[4], row[5], row[6]);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvListar.Rows.Clear();
            string query = @"SELECT id_compra, facturaNumero_compra, fecha_compra, ncf_compra,
	                         S.nombre_suplidor, total_compra, tipoCompra_compra FROM Compra C
	                         LEFT JOIN Suplidores S ON C.id_suplidor = S.id_suplidor ";
            if (!string.IsNullOrEmpty(txtIdFactura.Text))
            {
                // Buscar Por IdFactura;
                query += string.Format(" WHERE facturaNumero_compra LIKE '%'+'{0}'+'%'", txtIdFactura.Text);
            }
            else
            {
                // Si no es por IdFactura, todas las demas busquedas toman en cuenta la fecha
                query += string.Format(" WHERE fecha_compra BETWEEN '{0}' AND '{1}'", dtpDesde.Value, dtpHasta.Value);
                if (!string.IsNullOrEmpty(txtNombre.Text))
                {
                    query += string.Format(" AND C.id_suplidor = {0}", txtIdCliente.Text);
                }
                if (cboTipoCompra.SelectedIndex != 2)
                {
                    query += string.Format(" AND C.tipoCompra_compra = '{0}'", cboTipoCompra.Text);
                }
            }
            query += " ORDER BY nombre_suplidor";
            DataTable dt = _compra.Buscar(query);
            foreach (DataRow row in dt.Rows)
            {
                DateTime fecha = DateTime.Parse(row[2].ToString());
                _ = dgvListar.Rows.Add(row[0], row[1], fecha.ToString("dd / MM / yyy"), row[3], row[4], row[5], row[6]);
            }
        }

        private void linkCliente_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBuscarSuplidores frm = new FrmBuscarSuplidores();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtIdCliente.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                txtNombre.Text = frm.dgvListar.SelectedCells[2].Value.ToString();
            }
            else
            {
                txtIdCliente.Text = null;
                txtNombre.Text = null;
            }
        }

        private void txtIdCliente_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdCliente.Text))
            {
                NSuplidores suplidor = new NSuplidores();
                DataTable table = suplidor.BuscarId(txtIdCliente.Text);
                if (table.Rows.Count > 0)
                {
                    txtNombre.Text = table.Rows[0][1].ToString();
                }
                else
                {
                    txtIdCliente.Text = null;
                    txtNombre.Text = null;
                }
            }
            else
            {
                txtIdCliente.Text = null;
                txtNombre.Text = null;
            }
        }

        private void dgvListar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvListar.CurrentRow.Selected = true;
                e.SuppressKeyPress = true;
                e.Handled = true;
                DialogResult = DialogResult.OK;
            }
        }

        private void dgvListar_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void txtIdCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = btnBuscar.Focus();
            }
        }

        private void txtIdFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
