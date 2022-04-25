using APP.Buscar;
using Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP
{
    public partial class FrmCompra : Form
    {
        public FrmCompra()
        {
            InitializeComponent();
        }

        private void FrmCompra_Load(object sender, EventArgs e)
        {
            btnNuevo.PerformClick();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            _ = txtIdSuplidor.Focus();
            txtIdSuplidor.Text = null;
            txtSuplidorNombre.Text = null;
            cboTipoCompra.SelectedIndex = 1;
            dtpFecha.Value = DateTime.Now;
            txtFacturaNumero.Text = null;
            txtNCF.Text = null;
            ckbComprobante.Checked = false;
            limpiarArticulo();
            dgvListar.Rows.Clear();
            txtImporteCompra.Text = null;
            txtDescuentoCompra.Text = null;
            txtItbisCompra.Text = null;
            txtTotalCompra.Text = null;
            lblItems.Text = "0";
            lblItbisPorciento.Text = "0";
            lblIdArticulo.Text = "0";

            btnImprimir.Enabled = false;
            btnModificar.Enabled = false;
            btnSalvar.Enabled = false;

        }

        private void limpiarArticulo()
        {
            txtCodigo.Text = null;
            txtNombre.Text = null;
            txtCantidad.Text = null;
            txtDescuento.Text = null;
            txtImporte.Text = null;
            txtCosto.Text = null;
            txtCostoFinal.Text = null;
            txtPrecio.Text = null;
            txtBeneficio.Text = null;
            txtPrecioActual.Text = null;
            txtBeneficioActual.Text = null;
            lblItbisPorciento.Text = "0";
            lblIdArticulo.Text = "0";
        }

        private void linkSuplidor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBuscarSuplidores frm = new FrmBuscarSuplidores();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtIdSuplidor.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                txtSuplidorNombre.Text = frm.dgvListar.SelectedCells[2].Value.ToString();
                cboTipoCompra.Text = frm.dgvListar.SelectedCells[8].Value.ToString();
                _ = dtpFecha.Focus();
            }
        }

        private void txtIdSuplidor_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdSuplidor.Text))
            {
                NSuplidores _suplidores = new NSuplidores();
                DataTable suplidor = _suplidores.BuscarId(txtIdSuplidor.Text);
                if (suplidor.Rows.Count > 0)
                {
                    txtSuplidorNombre.Text = suplidor.Rows[0][1].ToString();
                    cboTipoCompra.Text = suplidor.Rows[0][8].ToString();
                }
                else
                {
                    txtSuplidorNombre.Text = null;
                }
            }
        }

        private void txtIdSuplidor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = dtpFecha.Focus();
            }
        }

        private void txtIdSuplidor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cboTipoCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = dtpFecha.Focus();
            }
        }

        private void dtpFecha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = txtFacturaNumero.Focus();
            }
        }

        private void txtFacturaNumero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = txtNCF.Focus();
            }
        }

        private void txtNCF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = txtCodigo.Focus();
            }
        }

        private void linkCodigo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBuscarArticulos frm = new FrmBuscarArticulos();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                lblIdArticulo.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                txtCodigo.Text = frm.dgvListar.SelectedCells[1].Value.ToString();
                txtNombre.Text = frm.dgvListar.SelectedCells[2].Value.ToString();
                lblItbisPorciento.Text = frm.dgvListar.SelectedCells[3].Value.ToString();
            }
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            NArticulos _articulo = new NArticulos();
            DataTable articulo = _articulo.BuscarCodigo(txtCodigo.Text);
            if (articulo.Rows.Count > 0)
            {
                lblIdArticulo.Text = articulo.Rows[0][0].ToString();
                txtCodigo.Text = articulo.Rows[0][4].ToString();
                txtNombre.Text = articulo.Rows[0][5].ToString();
                lblItbisPorciento.Text = articulo.Rows[0][15].ToString();
            }
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = cboItbis.Focus();
            }
        }

        private void cboItbis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = txtCantidad.Focus();
            }
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = txtDescuento.Focus();
            }
        }

        private void txtDescuento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = txtImporte.Focus();
            }
        }

        private void txtImporte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = txtCosto.Focus();
            }
        }

        private void txtCosto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = txtPrecio.Focus();
            }
        }

        private void txtPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = txtBeneficio.Focus();
            }
        }

        private void txtBeneficio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = btnAgregar.Focus();
            }
        }

        private void txtBeneficio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allowed numeric and one dot  ex. 10.23
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtImporte_Leave(object sender, EventArgs e)
        {

        }

        private void txtCosto_Leave(object sender, EventArgs e)
        {

        }
    }
}
