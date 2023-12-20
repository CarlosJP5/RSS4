using Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP.Buscar
{
    public partial class FrmBuscarFactura : Form
    {

        public FrmBuscarFactura()
        {
            InitializeComponent();
        }

        private readonly NFacturacion _facturar = new NFacturacion();

        private void FrmBuscarFactura_Load(object sender, EventArgs e)
        {
            cboTipoCompra.SelectedIndex = 2;
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today.AddHours(23.99999);
            DataTable dt = _facturar.Listar(dtpDesde.Value, dtpHasta.Value);
            foreach (DataRow row in dt.Rows)
            {
                DateTime fecha = DateTime.Parse(row[1].ToString());
                _ = dgvListar.Rows.Add(row[0], fecha.ToString("dd/MM/yyy  hh:mm tt"), row[2], row[3], row[4], row[5]);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvListar.Rows.Clear();
            string query = @"SELECT F.id_factura, F.fecha_factura, CD.ncf_comprobante,
	                         C.nombre_cliente, F.total_factura, F.tipoCompra_factura
	                         FROM Factura F LEFT JOIN Clientes C ON F.id_cliente = C.id_cliente
	                         LEFT JOIN ComprobantesDetalle CD ON F.id_comprobante = 
                             F.id_comprobante AND cast(F.id_factura as varchar) = CD.id_documento ";
            if (!string.IsNullOrEmpty(txtIdFactura.Text))
            {
                // Buscar Por IdFactura;
                query += string.Format(" WHERE F.id_factura = {0}", txtIdFactura.Text);
            }
            else
            {
                // Si no es por IdFactura, todas las demas busquedas toman en cuenta la fecha
                query += string.Format(" WHERE F.fecha_factura BETWEEN '{0}' AND '{1}'", dtpDesde.Value, dtpHasta.Value);
                if (!string.IsNullOrEmpty(txtNombre.Text))
                {
                    query += string.Format(" AND F.id_cliente = {0}", txtIdCliente.Text);
                }
                if (cboTipoCompra.SelectedIndex != 2)
                {
                    query += string.Format(" AND F.tipoCompra_factura = '{0}'", cboTipoCompra.Text);
                }
            }
            query += " ORDER BY F.id_factura DESC";
            DataTable dt = _facturar.Buscar(query);
            foreach (DataRow row in dt.Rows)
            {
                DateTime fecha = DateTime.Parse(row[1].ToString());
                _ = dgvListar.Rows.Add(row[0], fecha.ToString("dd/MM/yyy hh:mm tt"), row[2], row[3], row[4], row[5]);
            }
            if (dgvListar.RowCount > 0)
            {
                dgvListar.Focus();
            }
        }

        private void linkCliente_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBuscarClientes frm = new FrmBuscarClientes();
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
                NClientes cliente = new NClientes();
                DataTable table = cliente.BuscarId(txtIdCliente.Text);
                if (table.Rows.Count > 0)
                {
                    txtNombre.Text = table.Rows[0][2].ToString();
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
            if (dgvListar.RowCount > 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dgvListar.CurrentRow.Selected = true;
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvListar.RowCount > 0)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void txtIdFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtIdCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = btnBuscar.Focus();
            }
        }

        private void dgvListar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListar.RowCount > 0)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
