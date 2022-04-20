using APP.Buscar;
using Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP
{
    public partial class FrmFacturacion : Form
    {
        public FrmFacturacion()
        {
            InitializeComponent();
            cboTipoComprobante.DataSource = _comprobante.ComprovantesVentas();
            cboTipoComprobante.ValueMember = "id_comprobante";
            cboTipoComprobante.DisplayMember = "nombre_comprobante";
        }

        private readonly NComprobantes _comprobante = new NComprobantes();
        private readonly NClientes _cliente = new NClientes();

        private void FrmFacturacion_Load(object sender, EventArgs e)
        {
            btnNuevo.PerformClick();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtIdCliente.Text = "0";
            txtIdCliente_Leave(sender, e);
        }

        private void txtIdCliente_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdCliente.Text))
            {
                DataTable cliente = _cliente.BuscarId(txtIdCliente.Text);
                if (cliente.Rows.Count > 0)
                {
                    txtNombre.Text = cliente.Rows[0][2].ToString();
                    txtDireccion.Text = cliente.Rows[0][5].ToString();
                    txtCedula.Text = cliente.Rows[0][3].ToString();
                    txtRnc.Text = cliente.Rows[0][4].ToString();
                    cboTipoCompra.Text = cliente.Rows[0][8].ToString();
                    cboTipoComprobante.SelectedValue = cliente.Rows[0][1].ToString();
                    txtDescuento.Text = cliente.Rows[0][10].ToString();
                }
                else
                {
                    txtNombre.Text = null;
                    txtDireccion.Text = null;
                    txtCedula.Text = null;
                    txtRnc.Text = null;
                    cboTipoCompra.SelectedIndex = 0;
                    cboTipoComprobante.SelectedIndex = 0;
                    txtDescuento.Text = "0.00";
                }
            }
        }

        private void btnBuscarClientes_Click(object sender, EventArgs e)
        {
            FrmBuscarClientes frm = new FrmBuscarClientes();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtIdCliente.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                txtRnc.Text = frm.dgvListar.SelectedCells[1].Value.ToString();
                txtNombre.Text = frm.dgvListar.SelectedCells[2].Value.ToString();
                txtDireccion.Text = frm.dgvListar.SelectedCells[3].Value.ToString();
                cboTipoComprobante.SelectedValue = frm.dgvListar.SelectedCells[6].Value.ToString();
                txtCedula.Text = frm.dgvListar.SelectedCells[7].Value.ToString();
                cboTipoCompra.Text = frm.dgvListar.SelectedCells[9].Value.ToString();
                txtDescuento.Text = frm.dgvListar.SelectedCells[11].Value.ToString();
                _ = txtCodigo.Focus();
            }
        }

        private void txtIdCliente_KeyPress(object sender, KeyPressEventArgs e)
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
                _ = txtCodigo.Focus();
            }
        }
    }
}
