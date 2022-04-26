using APP.Buscar;
using Entidades;
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

        EArticulo Articulo = new EArticulo();

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
            cboItbis.SelectedIndex = 0;
            LimpiarArticulo();
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

        private void LimpiarArticulo()
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
                txtNombre.Text = frm.dgvListar.SelectedCells[3].Value.ToString();
                lblItbisPorciento.Text = frm.dgvListar.SelectedCells[8].Value.ToString();
            }
            else
            {
                txtCodigo.Text = null;
                txtNombre.Text = null;
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
            else
            {
                txtNombre.Text = null;
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
            if (!string.IsNullOrEmpty(txtImporte.Text))
            {
                decimal Importe = Convert.ToDecimal(txtImporte.Text);
                txtImporte.Text = Importe.ToString("N2");
                if (!string.IsNullOrEmpty(txtCantidad.Text))
                {
                    decimal costo = Importe / Convert.ToDecimal(txtCantidad.Text);
                    txtCosto.Text = costo.ToString("N2");
                }
                CalculaCostoFinal();
            }
        }

        private void txtCosto_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCosto.Text))
            {
                decimal costo = Convert.ToDecimal(txtCosto.Text);
                txtCosto.Text = costo.ToString("N2");
                if (!string.IsNullOrEmpty(txtCantidad.Text))
                {
                    decimal importe = costo * Convert.ToDecimal(txtCantidad.Text);
                    txtImporte.Text = importe.ToString("N2");
                }
                CalculaCostoFinal();
            }
        }

        private decimal ImporteTotal { get; set; }
        private decimal DescuentoTotal { get; set; }
        private decimal ItbisTotal { get; set; }
        
        private void CalculaCostoFinal()
        {
            decimal costoFinal = 0m;
            decimal costo = 0m;
            decimal descuento = 0m;
            decimal itbis = Convert.ToDecimal(lblItbisPorciento.Text) / 100;
            decimal cantidad = 0m;
            if (string.IsNullOrEmpty(txtCosto.Text) && string.IsNullOrEmpty(txtImporte.Text))
            {
                return;
            }
            if (!string.IsNullOrEmpty(txtCantidad.Text))
            {
                cantidad = Convert.ToDecimal(txtCantidad.Text);
            }
            if (!string.IsNullOrEmpty(txtCosto.Text))
            {
                costo = Convert.ToDecimal(txtCosto.Text);
            }
            if (!string.IsNullOrEmpty(txtDescuento.Text))
            {
                descuento = Convert.ToDecimal(txtDescuento.Text) / 100;
            }
            switch (cboItbis.SelectedIndex)
            {
                case 1:
                    //Incluido
                    costo = costo / (1 + itbis);
                    descuento = costo * descuento;
                    itbis = (costo - descuento) * itbis;
                    costoFinal = costo - descuento + itbis;
                    break;
                case 2:
                    //Exento
                    descuento = costo * descuento;
                    itbis = 0;
                    costoFinal = costo - descuento;
                    break;
                default:
                    //Sumado
                    descuento = costo * descuento;
                    itbis = (costo - descuento) * itbis;
                    costoFinal = costo - descuento + itbis;
                    break;
            }
            
            txtCostoFinal.Text = costoFinal.ToString("N2");
            ImporteTotal = cantidad * costo;
            DescuentoTotal = cantidad * descuento;
            ItbisTotal = cantidad * itbis;

            if (string.IsNullOrEmpty(txtPrecio.Text) && string.IsNullOrEmpty(txtBeneficio.Text))
            {
                decimal beneficio = 40m;
                txtBeneficio.Text = beneficio.ToString("N2");
                txtPrecio.Text = (costoFinal * (1 + (beneficio / 100))).ToString("N2");
            }
            else if (!string.IsNullOrEmpty(txtBeneficio.Text))
            {
                decimal beneficio = Convert.ToDecimal(txtBeneficio.Text);
                txtBeneficio.Text = beneficio.ToString("N2");
                txtPrecio.Text = (costoFinal * (1 + (beneficio / 100))).ToString("N2");
            }
        }

        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPrecio.Text) && !string.IsNullOrEmpty(txtCostoFinal.Text))
            {
                decimal precio = Convert.ToDecimal(txtPrecio.Text);
                decimal costo = Convert.ToDecimal(txtCostoFinal.Text);
                txtBeneficio.Text = ((precio - costo) / costo * 100).ToString("N2");
                txtPrecio.Text = precio.ToString("N2");
            }
        }

        private void txtBeneficio_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBeneficio.Text) && !string.IsNullOrEmpty(txtCostoFinal.Text))
            {
                double benefecio = Convert.ToDouble(txtBeneficio.Text);
                txtBeneficio.Text = benefecio.ToString("N2");
                double costo = Convert.ToDouble(txtCostoFinal.Text);
                txtPrecio.Text = (costo * (1 + (benefecio / 100))).ToString("N2");
            }
        }

        private void CalculaTotal()
        {
            decimal Importe = 0;
            decimal Descuento = 0;
            decimal Itbis = 0;
            for (int i = 0; i < dgvListar.RowCount; i++)
            {
                Importe += Convert.ToDecimal(dgvListar.Rows[i].Cells[12].Value);
                Descuento += Convert.ToDecimal(dgvListar.Rows[i].Cells[13].Value);
                Itbis += Convert.ToDecimal(dgvListar.Rows[i].Cells[14].Value);
            }
            txtImporteCompra.Text = Importe.ToString("N2");
            txtDescuentoCompra.Text = Descuento.ToString("N2");
            txtItbisCompra.Text = Itbis.ToString("N2");
            txtTotalCompra.Text = (Importe - Descuento + Itbis).ToString("N2");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                string itb = "+";
                switch (cboItbis.SelectedIndex)
                {
                    case 1:
                        //Incluido
                        itb = "=";
                        break;
                    case 2:
                        //Exento
                        itb = "-";
                        break;
                    default:
                        //Sumado
                        itb = "+";
                        break;
                }
                bool existe = false;
                for (int i = 0; i < dgvListar.RowCount; i++)
                {
                    //NO Repetir
                    if (dgvListar.Rows[i].Cells[1].Value.ToString() == txtCodigo.Text)
                    {
                        existe = true;
                        DialogResult msg = MessageBox.Show("Desea Modificarlo?", "Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (msg == DialogResult.Yes)
                        {
                            dgvListar.Rows.RemoveAt(i);
                            _ = dgvListar.Rows.Add(lblIdArticulo.Text, txtCodigo.Text, txtNombre.Text, itb, txtCantidad.Text,
                                txtDescuento.Text, txtCosto.Text, txtImporte.Text, lblItbisPorciento.Text, txtCostoFinal.Text,
                                txtPrecio.Text, txtBeneficio.Text, ImporteTotal, DescuentoTotal, ItbisTotal);
                        }
                        return;
                    }
                }
                if (!existe)
                {
                    _ = dgvListar.Rows.Add(lblIdArticulo.Text, txtCodigo.Text, txtNombre.Text, itb, txtCantidad.Text,
                                txtDescuento.Text, txtCosto.Text, txtImporte.Text, lblItbisPorciento.Text, txtCostoFinal.Text,
                                txtPrecio.Text, txtBeneficio.Text, ImporteTotal, DescuentoTotal, ItbisTotal);
                }
                CalculaTotal();
                LimpiarArticulo();
                _ = txtCodigo.Focus();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvListar.RowCount > 0)
            {
                dgvListar.Rows.Remove(dgvListar.CurrentRow);
                CalculaTotal();
            }
        }
    }
}
