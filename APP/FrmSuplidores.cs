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
            txtIdSuplidor.Text = _suplidores.MaxId().ToString();
            ActivaControles();
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
                DataTable Sup = _suplidores.BuscarId(txtIdSuplidor.Text);
                if (Sup.Rows.Count <= 0)
                {
                    // Nuevo
                    _suplidores.Insertar(suplidor);
                }
                else
                {
                    // Editar
                    suplidor.IdSuplidor = Convert.ToInt32(txtIdSuplidor.Text);
                    _suplidores.Editar(suplidor);
                }
                btnNuevo.PerformClick();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarSuplidores frm = new FrmBuscarSuplidores();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtIdSuplidor.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                txtRnc.Text = frm.dgvListar.SelectedCells[1].Value.ToString();
                txtNombre.Text = frm.dgvListar.SelectedCells[2].Value.ToString();
                txtVendedor.Text = frm.dgvListar.SelectedCells[3].Value.ToString();
                txtTelefono.Text = frm.dgvListar.SelectedCells[4].Value.ToString();
                txtCelular.Text = frm.dgvListar.SelectedCells[5].Value.ToString();
                txtDireccion.Text = frm.dgvListar.SelectedCells[6].Value.ToString();
                txtCorreo.Text = frm.dgvListar.SelectedCells[7].Value.ToString();
                cboCompraA.Text = frm.dgvListar.SelectedCells[8].Value.ToString();
                cboEstado.SelectedIndex = (bool)frm.dgvListar.SelectedCells[9].Value ? 0 : 1;

                DesactivaControles();
                btnModificar.Enabled = true;
                btnSalvar.Enabled = false;
            }
        }

        public void DesactivaControles()
        {
            txtNombre.Enabled = false;
            txtDireccion.Enabled = false;
            txtCorreo.Enabled = false;
            cboEstado.Enabled = false;
            txtRnc.Enabled = false;
            txtTelefono.Enabled = false;
            txtVendedor.Enabled = false;
            txtCelular.Enabled = false;
            cboCompraA.Enabled = false;
        }

        public void ActivaControles()
        {
            txtNombre.Enabled = true;
            txtDireccion.Enabled = true;
            txtCorreo.Enabled = true;
            cboEstado.Enabled = true;
            txtRnc.Enabled = true;
            txtTelefono.Enabled = true;
            txtVendedor.Enabled = true;
            txtCelular.Enabled = true;
            cboCompraA.Enabled = true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ActivaControles();
            btnSalvar.Enabled = true;
            _ = txtNombre.Focus();
        }

        private void txtRnc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
