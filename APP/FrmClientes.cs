using APP.Buscar;
using Entidades;
using Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
            NComprobantes _comprobante = new NComprobantes();
            cboTipoComprobante.DataSource = _comprobante.ComprovantesVentas();
            cboTipoComprobante.ValueMember = "id_comprobante";
            cboTipoComprobante.DisplayMember = "nombre_comprobante";
        }

        private readonly ECliente cliente = new ECliente();
        private readonly NClientes _clientes = new NClientes();

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            btnNuevo.PerformClick();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtIdCliente.Text = _clientes.MaxId().ToString();
            ActivarControles();
            txtNombre.Text = null;
            txtCedula.Text = null;
            txtDireccion.Text = null;
            txtCorreo.Text = null;
            cboTipoComprobante.SelectedIndex = 0;
            txtRnc.Text = null;
            txtTelefono.Text = null;
            txtLimiteCredito.Text = null;
            txtDescuento.Text = null;
            cboTipoCompra.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;

            btnModificar.Enabled = false;
            btnSalvar.Enabled = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ValidateChildren();
            if (!txtNombre.AllowDrop)
            {
                cliente.Nombre = txtNombre.Text;
                cliente.Cedula = txtCedula.Text;
                cliente.Direccion = txtDireccion.Text;
                cliente.Correo = txtCorreo.Text;
                cliente.IdComprobante = cboTipoComprobante.SelectedValue.ToString();
                cliente.RNC = txtRnc.Text;
                cliente.Telefono = txtTelefono.Text;
                if (!string.IsNullOrEmpty(txtLimiteCredito.Text))
                {
                    cliente.LimiteCredito = Convert.ToDecimal(txtLimiteCredito.Text);
                }
                if (!string.IsNullOrEmpty(txtDescuento.Text))
                {
                    cliente.Descuento = Convert.ToDecimal(txtDescuento.Text);
                }
                cliente.TipoCompra = cboTipoCompra.Text;
                cliente.Estado = cboEstado.SelectedIndex == 0;
                DataTable clientes = _clientes.BuscarId(txtIdCliente.Text);
                if(clientes.Rows.Count > 0)
                {
                    // Editar
                    cliente.Id = Convert.ToInt32(txtIdCliente.Text);
                    _clientes.Editar(cliente);
                }
                else
                {
                    // Crear
                    _clientes.Insertar(cliente);
                }
                btnNuevo.PerformClick();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarClientes frm = new FrmBuscarClientes();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtIdCliente.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                txtRnc.Text = frm.dgvListar.SelectedCells[1].Value.ToString();
                txtNombre.Text = frm.dgvListar.SelectedCells[2].Value.ToString();
                txtDireccion.Text = frm.dgvListar.SelectedCells[3].Value.ToString();
                txtTelefono.Text = frm.dgvListar.SelectedCells[4].Value.ToString();
                cboEstado.SelectedIndex = (bool)frm.dgvListar.SelectedCells[5].Value ? 0 : 1;
                cboTipoComprobante.SelectedValue = frm.dgvListar.SelectedCells[6].Value.ToString();
                txtCedula.Text = frm.dgvListar.SelectedCells[7].Value.ToString();
                txtCorreo.Text = frm.dgvListar.SelectedCells[8].Value.ToString();
                cboTipoCompra.Text = frm.dgvListar.SelectedCells[9].Value.ToString();
                txtLimiteCredito.Text = ((decimal)frm.dgvListar.SelectedCells[10].Value).ToString("N2");
                txtDescuento.Text = ((decimal)frm.dgvListar.SelectedCells[11].Value).ToString("N2");

                txtNombre.Enabled = false;
                txtCedula.Enabled = false;
                txtDireccion.Enabled = false;
                txtCorreo.Enabled = false;
                cboTipoComprobante.Enabled = false;
                txtRnc.Enabled = false;
                txtTelefono.Enabled = false;
                txtLimiteCredito.Enabled = false;
                txtDescuento.Enabled = false;
                cboTipoCompra.Enabled = false;
                cboEstado.Enabled = false;

                btnModificar.Enabled = true;
                btnSalvar.Enabled = false;
            }
        }

        private void ActivarControles()
        {
            txtNombre.Enabled = true;
            txtCedula.Enabled = true;
            txtDireccion.Enabled = true;
            txtCorreo.Enabled = true;
            cboTipoComprobante.Enabled = true;
            txtRnc.Enabled = true;
            txtTelefono.Enabled = true;
            txtLimiteCredito.Enabled = true;
            txtDescuento.Enabled = true;
            cboTipoCompra.Enabled = true;
            cboEstado.Enabled = true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ActivarControles();
            _ = txtNombre.Focus();
            btnSalvar.Enabled = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult msj = MessageBox.Show("Desea Salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msj == DialogResult.Yes)
            {
                Close();
            }
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
