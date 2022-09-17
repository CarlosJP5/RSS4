using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP.Buscar
{
    public partial class FrmBuscarCotizacion : Form
    {
        public FrmBuscarCotizacion()
        {
            InitializeComponent();
        }

        private readonly NCotizacion _facturar = new NCotizacion();

        private void FrmBuscarCotizacion_Load(object sender, EventArgs e)
        {
            cboTipoCompra.SelectedIndex = 2;
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today.AddHours(23.99999);
            DataTable dt = _facturar.Listar(dtpDesde.Value, dtpHasta.Value);
            foreach (DataRow row in dt.Rows)
            {
                DateTime fecha = DateTime.Parse(row[1].ToString());
                _ = dgvListar.Rows.Add(row[0], fecha.ToString("dd/MM/yyy  hh:mm tt"), row[2], row[3], row[4]);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvListar.Rows.Clear();
            string query = @"SELECT F.id_cotizacion, F.fecha_cotizacion, 
                             C.nombre_cliente, F.total_cotizacion, F.estado_cotizacion
                             FROM Cotizacion F LEFT JOIN Clientes C ON F.id_cliente = C.id_cliente";
            if (!string.IsNullOrEmpty(txtIdFactura.Text))
            {
                // Buscar Por IdFactura;
                query += string.Format(" WHERE F.id_cotizacion = {0}", txtIdFactura.Text);
            }
            else
            {
                // Si no es por IdFactura, todas las demas busquedas toman en cuenta la fecha
                query += string.Format(" WHERE F.fecha_cotizacion BETWEEN '{0}' AND '{1}'", dtpDesde.Value, dtpHasta.Value);
                if (!string.IsNullOrEmpty(txtNombre.Text))
                {
                    query += string.Format(" AND F.id_cliente = {0}", txtIdCliente.Text);
                }
                if (cboTipoCompra.SelectedIndex != 2)
                {
                    query += string.Format(" AND F.tipoCompra_cotizacion = '{0}'", cboTipoCompra.Text);
                }
            }
            query += " ORDER BY F.id_cotizacion DESC";
            DataTable dt = _facturar.Buscar(query);
            foreach (DataRow row in dt.Rows)
            {
                DateTime fecha = DateTime.Parse(row[1].ToString());
                _ = dgvListar.Rows.Add(row[0], fecha.ToString("dd/MM/yyy  hh:mm tt"), row[2], row[3], row[4]);
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
            if (e.KeyCode == Keys.Enter)
            {
                dgvListar.CurrentRow.Selected = true;
                e.SuppressKeyPress = true;
                e.Handled = true;
                DialogResult = DialogResult.OK;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
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
            DialogResult = DialogResult.OK;
        }
    }
}
