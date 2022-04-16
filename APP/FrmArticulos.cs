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
    public partial class FrmArticulos : Form
    {
        public FrmArticulos()
        {
            InitializeComponent();
        }

        private readonly NArticulos _articulos = new NArticulos();

        private void FrmArticulos_Load(object sender, EventArgs e)
        {
            btnNuevo.PerformClick();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = null;
            txtCantidad.Text = null;
            if (!ckbPlanilla.Checked)
            {
                txtNombre.Text = null;
                txtReferencia.Text = null;
                txtMarca.Text = null;
                txtIdMarca.Text = null;
                txtIdSuplidor.Text = null;
                txtSuplidor.Text = null;
                txtCosto.Text = null;
                txtPrecio.Text = null;
                txtBeneficio.Text = null;
                cboEstado.SelectedIndex = 0;
            }

            btnModificar.Enabled = false;
            btnSalvar.Enabled = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!txtCodigo.AllowDrop && !txtNombre.AllowDrop)
            {
                EArticulo articulo = new EArticulo
                {
                    Codigo = txtCodigo.Text,
                    Nombre = txtNombre.Text,
                    Referencia = txtReferencia.Text
                };
                if (!string.IsNullOrEmpty(txtMarca.Text))
                {
                    articulo.IdMarca = Convert.ToInt16(txtIdMarca.Text);
                }
                if (!string.IsNullOrEmpty(txtItbis.Text))
                {
                    articulo.IdItbis = Convert.ToInt16(txtIdItbis.Text);
                }
                if (!string.IsNullOrEmpty(txtSuplidor.Text))
                {
                    articulo.IdSuplidor = Convert.ToInt16(txtIdSuplidor.Text);
                }
                if (!string.IsNullOrEmpty(txtPuntoReorden.Text))
                {
                    articulo.PuntoReorden = Convert.ToInt16(txtPuntoReorden.Text);
                }
                if (!string.IsNullOrEmpty(txtCantidad.Text))
                {
                    articulo.Cantidad = Convert.ToDecimal(txtCantidad.Text);
                }
                if (!string.IsNullOrEmpty(txtCosto.Text))
                {
                    articulo.Costo = Convert.ToDecimal(txtCosto.Text);
                }
                if (!string.IsNullOrEmpty(txtPrecio.Text))
                {
                    articulo.Precio = Convert.ToDecimal(txtPrecio.Text);
                }
                if (!string.IsNullOrEmpty(txtBeneficio.Text))
                {
                    articulo.Beneficio = Convert.ToDecimal(txtBeneficio.Text);
                }
                articulo.Estado = cboEstado.SelectedIndex == 0;
                _articulos.Insertar(articulo);
                btnNuevo.PerformClick();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarArticulos frm = new FrmBuscarArticulos();
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
