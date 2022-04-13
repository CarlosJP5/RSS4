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
                _clientes.Insertar(cliente);
                btnNuevo.PerformClick();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
