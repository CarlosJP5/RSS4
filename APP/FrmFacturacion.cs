using APP.Buscar;
using Entidades;
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
        
        private readonly NArticulos _articulo = new NArticulos();
        private readonly NComprobantes _comprobante = new NComprobantes();
        private readonly NClientes _cliente = new NClientes();

        private void CalculaTotal()
        {
            decimal importeTotal = 0m;
            decimal descuentoTotal = 0m;
            decimal itbisTotal = 0m;
            for (int i = 0; i < dgvListar.RowCount; i++)
            {
                if (!decimal.TryParse(dgvListar.Rows[i].Cells[4].Value.ToString(), out _))
                {
                    dgvListar.Rows[i].Cells[4].Value = 1m;
                }
                if (!decimal.TryParse(dgvListar.Rows[i].Cells[5].Value.ToString(), out _))
                {
                    dgvListar.Rows[i].Cells[5].Value = Convert.ToDecimal(txtDescuento.Text);
                }
                if (!decimal.TryParse(dgvListar.Rows[i].Cells[6].Value.ToString(), out _))
                {
                    dgvListar.Rows[i].Cells[6].Value = Convert.ToDecimal(dgvListar.Rows[i].Cells[13].Value);
                }
                decimal precioNeto = Convert.ToDecimal(dgvListar.Rows[i].Cells[6].Value);
                decimal cantidad = Convert.ToDecimal(dgvListar.Rows[i].Cells[4].Value);
                decimal descuento = Convert.ToDecimal(dgvListar.Rows[i].Cells[5].Value) / 100;
                decimal itbis = 1 + (Convert.ToDecimal(dgvListar.Rows[i].Cells[9].Value) / 100);
                decimal precio = precioNeto / itbis;
                descuento = precio * descuento;
                itbis = (precio - descuento) * (itbis - 1);
                dgvListar.Rows[i].Cells[4].Value = cantidad;
                dgvListar.Rows[i].Cells[5].Value = Convert.ToDecimal(dgvListar.Rows[i].Cells[5].Value);
                dgvListar.Rows[i].Cells[6].Value = precioNeto;
                dgvListar.Rows[i].Cells[7].Value = decimal.Round(cantidad * precioNeto, 2);
                dgvListar.Rows[i].Cells[10].Value = decimal.Round(cantidad * precio, 2);
                dgvListar.Rows[i].Cells[11].Value = decimal.Round(cantidad * descuento, 2);
                dgvListar.Rows[i].Cells[12].Value = decimal.Round(cantidad * itbis, 2);

                importeTotal += Convert.ToDecimal(dgvListar.Rows[i].Cells[10].Value);
                descuentoTotal += Convert.ToDecimal(dgvListar.Rows[i].Cells[11].Value);
                itbisTotal += Convert.ToDecimal(dgvListar.Rows[i].Cells[12].Value);
            }
            txtImporte_fact.Text = importeTotal.ToString("N2");
            txtDescuento_fact.Text = descuentoTotal.ToString("N2");
            txtItbis_fact.Text = itbisTotal.ToString("N2");
            txtTotal_fact.Text = (importeTotal - descuentoTotal + itbisTotal).ToString("N2");
        }

        private void FrmFacturacion_Load(object sender, EventArgs e)
        {
            btnNuevo.PerformClick();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtIdCliente.Text = "0";
            txtIdCliente_Leave(sender, e);
            dgvListar.Rows.Clear();
            CalculaTotal();
            _ = txtCodigo.Focus();
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
                for (int i = 0; i < dgvListar.RowCount; i++)
                {
                    dgvListar.Rows[i].Cells[5].Value = Convert.ToDecimal(txtDescuento.Text);
                }
                CalculaTotal();
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
                for (int i = 0; i < dgvListar.RowCount; i++)
                {
                    dgvListar.Rows[i].Cells[5].Value = Convert.ToDecimal(txtDescuento.Text);
                }
                CalculaTotal();
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

        private void linkCodigo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBuscarArticulos frm = new FrmBuscarArticulos();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataTable dataArt = _articulo.BuscarId(frm.dgvListar.SelectedCells[0].Value.ToString());
                if ((bool)dataArt.Rows[0][12])
                {
                    _ = dgvListar.Rows.Add(dataArt.Rows[0][0], dataArt.Rows[0][4], dataArt.Rows[0][5],
                        dataArt.Rows[0][13], 1m, Convert.ToDecimal(txtDescuento.Text), dataArt.Rows[0][10],
                        dataArt.Rows[0][10], dataArt.Rows[0][9], dataArt.Rows[0][15], 0m, 0m, 0m,
                        dataArt.Rows[0][10]);
                    CalculaTotal();
                    txtCodigo.Text = null;
                    _ = txtCodigo.Focus();
                }
                else
                {
                    _ = MessageBox.Show("Articulo desactivado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCodigo.Text = null;
                    _ = txtCodigo.Focus();
                }
            }
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (!string.IsNullOrEmpty(txtCodigo.Text))
                {
                    btnAgregar.PerformClick();
                }
                else
                {
                    LinkLabelLinkClickedEventArgs ex = new LinkLabelLinkClickedEventArgs(linkCodigo.Links[0]);
                    linkCodigo_LinkClicked(sender, ex);
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DataTable dataArt = _articulo.BuscarCodigo(txtCodigo.Text);
            if (dataArt.Rows.Count > 0)
            {
                if ((bool)dataArt.Rows[0][12])
                {
                    _ = dgvListar.Rows.Add(dataArt.Rows[0][0], dataArt.Rows[0][4], dataArt.Rows[0][5],
                        dataArt.Rows[0][13], 1m, Convert.ToDecimal(txtDescuento.Text), dataArt.Rows[0][10],
                        dataArt.Rows[0][10], dataArt.Rows[0][9], dataArt.Rows[0][15], 0m, 0m, 0m,
                        dataArt.Rows[0][10]);
                    CalculaTotal();
                    txtCodigo.Text = null;
                    _ = txtCodigo.Focus();
                }
                else
                {
                    _ = MessageBox.Show("Articulo desactivado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCodigo.Text = null;
                    _ = txtCodigo.Focus();
                }
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

        private void dgvListar_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!decimal.TryParse(dgvListar.CurrentRow.Cells[6].Value.ToString(), out _))
            {
                dgvListar.CurrentRow.Cells[6].Value = Convert.ToDecimal(dgvListar.CurrentRow.Cells[13].Value);
            }
            decimal precio = Convert.ToDecimal(dgvListar.CurrentRow.Cells[6].Value);
            decimal costo = Convert.ToDecimal(dgvListar.CurrentRow.Cells[8].Value);
            if (precio < costo)
            {
                _ = MessageBox.Show("Precio Menor al Costo", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvListar.CurrentRow.Cells[6].Value = (decimal)dgvListar.CurrentRow.Cells[13].Value;
            }
            CalculaTotal();
        }

        private void dgvListar_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dgvListar.CurrentCell.ColumnIndex == 4 || dgvListar.CurrentCell.ColumnIndex == 5 || dgvListar.CurrentCell.ColumnIndex == 6) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }
        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allowed numeric and one dot  ex. 10.23
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                _ = MessageBox.Show("Debe Seleccionar un Cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboTipoComprobante.SelectedValue.ToString() == "B01")
            {
                if (string.IsNullOrEmpty(txtRnc.Text) || (txtRnc.Text.Length != 11 && txtRnc.Text.Length != 9))
                {
                    _ = MessageBox.Show("El RNC no es Valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (dgvListar.RowCount > 0)
            {

            }
        }
    }
}
