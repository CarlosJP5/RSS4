using APP.Buscar;
using Entidades;
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

namespace APP
{
    public partial class FrmSuplidores : Form
    {
        public FrmSuplidores()
        {
            InitializeComponent();
        }

        private readonly ESuplidor suplidor = new ESuplidor();
        private readonly NSuplidores _suplidores = new NSuplidores();

        private void FrmSuplidores_Load(object sender, EventArgs e)
        {
            btnNuevo.PerformClick();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombre.Text = null;
            txtDireccion.Text = null;
            txtCorreo.Text = null;
            txtRnc.Text = null;
            txtTelefono.Text = null;
            txtVendedor.Text = null;
            txtCelular.Text = null;
            cboEstado.SelectedIndex = 0;
            cboCompraA.SelectedIndex = 1;

            btnModificar.Enabled = false;
            btnSalvar.Enabled = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ValidateChildren();
            if (!txtNombre.AllowDrop)
            {
                suplidor.Nombre = txtNombre.Text;
                suplidor.Direccion = txtDireccion.Text;
                suplidor.Correo = txtCorreo.Text;
                suplidor.Estado = cboEstado.SelectedIndex == 0;
                suplidor.RNC = txtRnc.Text;
                suplidor.Telefono = txtTelefono.Text;
                suplidor.Vendedor = txtVendedor.Text;
                suplidor.Cell = txtCelular.Text;
                suplidor.TipoCompra = cboCompraA.Text;
                _suplidores.Insertar(suplidor);
                btnNuevo.PerformClick();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarSuplidores frm = new FrmBuscarSuplidores();
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
