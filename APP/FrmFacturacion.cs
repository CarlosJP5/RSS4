using APP.Buscar;
using APP.Reportes;
using Entidades;
using Microsoft.Reporting.WinForms;
using Negocios;
using Negocios.NReportes;
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
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
            if (keyData == Keys.F5)
            {
                btnFacturar.PerformClick();
                return true;    // indicate that you handled this keystroke
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private readonly NArticulos _articulo = new NArticulos();
        private readonly NComprobantes _comprobante = new NComprobantes();
        private readonly NClientes _cliente = new NClientes();
        private readonly NFacturacion _facturar = new NFacturacion();

        private void CalculaTotal()
        {
            decimal importeTotal = 0m;
            decimal descuentoTotal = 0m;
            decimal itbisTotal = 0m;
            for (int i = 0; i < dgvListar.RowCount; i++)
            {
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
            txtImporteFactura.Text = importeTotal.ToString("N2");
            txtDescuentoFactura.Text = descuentoTotal.ToString("N2");
            txtItbisFactura.Text = itbisTotal.ToString("N2");
            txtTotalFactura.Text = (importeTotal - descuentoTotal + itbisTotal).ToString("N2");
        }

        private void FrmFacturacion_Load(object sender, EventArgs e)
        {
            btnNuevo.PerformClick();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnBuscar.Enabled = true;
            btnFacturar.Enabled = true;
            btnImprimir.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = false;
            txtIdCliente.Text = "0";
            txtIdCliente_Leave(sender, e);
            dgvListar.Rows.Clear();
            CalculaTotal();
            HabilitarControles();
            cboTipoCompra.Enabled = true;
            cboTipoComprobante.Enabled = true;
            linkCotizacion.Enabled = true;
            lblIdFactura.Text = "#";
            lblNCF.Text = "#";
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
                    if (!btnGuardar.Enabled)
                    {
                        cboTipoCompra.Text = cliente.Rows[0][8].ToString();
                        cboTipoComprobante.SelectedValue = cliente.Rows[0][1].ToString();
                    }
                    txtDescuento.Text = cliente.Rows[0][10].ToString();
                }
                else
                {
                    txtNombre.Text = null;
                    txtDireccion.Text = null;
                    txtCedula.Text = null;
                    txtRnc.Text = null;
                    if (!btnGuardar.Enabled)
                    {
                        cboTipoCompra.SelectedIndex = 0;
                        cboTipoComprobante.SelectedIndex = 0;
                    }
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
                txtCedula.Text = frm.dgvListar.SelectedCells[7].Value.ToString();
                if (!btnGuardar.Enabled)
                {
                    cboTipoComprobante.SelectedValue = frm.dgvListar.SelectedCells[6].Value.ToString();
                    cboTipoCompra.Text = frm.dgvListar.SelectedCells[9].Value.ToString();
                }
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
            if (dgvListar.CurrentRow.Cells[4].Value == null || Convert.ToDouble(dgvListar.CurrentRow.Cells[4].Value) <= 0)
            {
                dgvListar.CurrentRow.Cells[4].Value = 1m;
            }
            if (Convert.ToDouble(dgvListar.CurrentRow.Cells[4].Value) <= 0.01)
            {
                dgvListar.CurrentRow.Cells[4].Value = 0.01m;
            }
            if (Convert.ToDouble(dgvListar.CurrentRow.Cells[6].Value) <= 0.01)
            {
                dgvListar.CurrentRow.Cells[6].Value = 0.01m;
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
                EFactura Factura = new EFactura()
                {
                    IdCliente = Convert.ToInt32(txtIdCliente.Text),
                    IdComprobante = cboTipoComprobante.SelectedValue.ToString(),
                    Fecha = DateTime.Now,
                    TipoCompra = cboTipoCompra.Text,
                    Nota = txtNota.Text,
                    Importe = Convert.ToDecimal(txtImporteFactura.Text),
                    Descuento = Convert.ToDecimal(txtDescuentoFactura.Text),
                    Itbis = Convert.ToDecimal(txtItbisFactura.Text),
                    Total = Convert.ToDecimal(txtTotalFactura.Text),
                };
                DataTable ListaComprobante = _comprobante.SumarCantidad(Factura.IdComprobante);
                if (ListaComprobante.Rows.Count > 0)
                {
                    DateTime date = DateTime.Parse(ListaComprobante.Rows[0][5].ToString());
                    if (date > Factura.Fecha)
                    {
                        int numeroComprobante = Convert.ToInt32(ListaComprobante.Rows[0][4].ToString());
                        Factura.Ncf = Factura.IdComprobante + numeroComprobante.ToString("D8");
                        Factura.FechaVencimiento = date;
                    }
                    else
                    {
                        _comprobante.Deshabilitar(ListaComprobante.Rows[0][0].ToString());
                        _ = MessageBox.Show("La Fecha del Comprobante se ha Vendido\nDebe Solicitar mas comprobantes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    _ = MessageBox.Show("No hay Comprobantes Disponibles\nDebe Solicitar mas comprobantes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DataTable Detalle = new DataTable();
                Detalle.Columns.Add("[idArticulo]", typeof(int));
                Detalle.Columns.Add("[cantidad]", typeof(decimal));
                Detalle.Columns.Add("[descuento]", typeof(decimal));
                Detalle.Columns.Add("[precio]", typeof(decimal));
                Detalle.Columns.Add("[importe]", typeof(decimal));
                Detalle.Columns.Add("[costo]", typeof(decimal));
                Detalle.Columns.Add("[totalimporte]", typeof(decimal));
                Detalle.Columns.Add("[totaldescuento]", typeof(decimal));
                Detalle.Columns.Add("[totalitbis]", typeof(decimal));
                for (int i = 0; i < dgvListar.RowCount; i++)
                {
                    DataRow row = Detalle.NewRow();
                    row[0] = Convert.ToInt32(dgvListar.Rows[i].Cells[0].Value);
                    row[1] = Convert.ToDecimal(dgvListar.Rows[i].Cells[4].Value);
                    row[2] = Convert.ToDecimal(dgvListar.Rows[i].Cells[5].Value);
                    row[3] = Convert.ToDecimal(dgvListar.Rows[i].Cells[6].Value);
                    row[4] = Convert.ToDecimal(dgvListar.Rows[i].Cells[7].Value);
                    row[5] = Convert.ToDecimal(dgvListar.Rows[i].Cells[8].Value);
                    row[6] = Convert.ToDecimal(dgvListar.Rows[i].Cells[10].Value);
                    row[7] = Convert.ToDecimal(dgvListar.Rows[i].Cells[11].Value);
                    row[8] = Convert.ToDecimal(dgvListar.Rows[i].Cells[12].Value);
                    Detalle.Rows.Add(row);
                }
                int IdFactura = _facturar.Insertar(Factura, Detalle);
                DialogResult msj = MessageBox.Show("Desea Imprimir", "inf", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msj == DialogResult.Yes)
                {
                    rptFactura frm = new rptFactura(lblIdFactura.Text);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        frm.Close();
                    }
                    //using (LocalReport localReport = new LocalReport())
                    //{
                    //    NrptEmpresa nEmpresa = new NrptEmpresa();
                    //    NrptFactura nFactura = new NrptFactura();
                    //    nEmpresa.LlenaEmpresa();
                    //    nFactura.Facturas(IdFactura.ToString());
                    //    //localReport.ReportPath = Application.StartupPath + @"\Reportes\rptFactura.rdlc";
                    //    localReport.ReportPath = @"C:\Users\Carlos J Pacheco\source\repos\CarlosJP5\RSS4\APP\Reportes\rptFactura.rdlc";
                    //    localReport.DataSources.Clear();
                    //    localReport.DataSources.Add(new ReportDataSource("dsEmpresa", nEmpresa.Empresa));
                    //    localReport.DataSources.Add(new ReportDataSource("dsFactura", nFactura.Factura));
                    //    localReport.DataSources.Add(new ReportDataSource("dsFacturaDetalle", nFactura.FacturaDetalles));
                    //    localReport.PrintToPrinter();
                    //}
                }
                btnNuevo.PerformClick();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarFactura frm = new FrmBuscarFactura();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dgvListar.Rows.Clear();
                DataTable facturaTable = _facturar.BuscarId(frm.dgvListar.SelectedCells[0].Value.ToString());
                lblIdFactura.Text = facturaTable.Rows[0][0].ToString();
                lblNCF.Text = facturaTable.Rows[0][1].ToString();
                dtpFecha.Value = (DateTime)facturaTable.Rows[0][2];
                txtIdCliente.Text = facturaTable.Rows[0][3].ToString();
                txtNombre.Text = facturaTable.Rows[0][4].ToString();
                txtDireccion.Text = facturaTable.Rows[0][5].ToString();
                txtCedula.Text = facturaTable.Rows[0][6].ToString();
                txtRnc.Text = facturaTable.Rows[0][7].ToString();
                cboTipoCompra.Text = facturaTable.Rows[0][8].ToString();
                cboTipoComprobante.SelectedValue = facturaTable.Rows[0][9].ToString();
                txtDescuento.Text = facturaTable.Rows[0][10].ToString();
                txtImporteFactura.Text = facturaTable.Rows[0][11].ToString();
                txtDescuentoFactura.Text = facturaTable.Rows[0][12].ToString();
                txtItbisFactura.Text = facturaTable.Rows[0][13].ToString();
                txtTotalFactura.Text = facturaTable.Rows[0][14].ToString();
                txtNota.Text = facturaTable.Rows[0][15].ToString();
                for (int i = 0; i < facturaTable.Rows.Count; i++)
                {
                    dgvListar.Rows.Add(facturaTable.Rows[i][16], facturaTable.Rows[i][17],
                        facturaTable.Rows[i][18], facturaTable.Rows[i][19], facturaTable.Rows[i][20],
                        facturaTable.Rows[i][21], facturaTable.Rows[i][22], facturaTable.Rows[i][23],
                        facturaTable.Rows[i][24], facturaTable.Rows[i][25], facturaTable.Rows[i][26],
                        facturaTable.Rows[i][27], facturaTable.Rows[i][28]);
                }
                CalculaTotal();

                txtIdCliente.Enabled = false;
                btnBuscarClientes.Enabled = false;
                txtNombre.Enabled = false;
                txtDireccion.Enabled = false;
                txtCedula.Enabled = false;
                txtRnc.Enabled = false;
                txtDescuento.Enabled = false;
                cboTipoCompra.Enabled = false;
                cboTipoComprobante.Enabled = false;
                linkCotizacion.Enabled = false;
                linkCodigo.Enabled = false;
                txtCodigo.Enabled = false;
                btnAgregar.Enabled = false;
                btnBorrar.Enabled = false;
                dgvListar.ReadOnly = true;
                txtNota.Enabled = false;
                btnFacturar.Enabled = false;
                btnModificar.Enabled = true;
                btnImprimir.Enabled = true;
            }
        }

        private void HabilitarControles()
        {
            txtIdCliente.Enabled = true;
            btnBuscarClientes.Enabled = true;
            txtNombre.Enabled = true;
            txtDireccion.Enabled = true;
            txtCedula.Enabled = true;
            txtRnc.Enabled = true;
            txtDescuento.Enabled = true;
            txtCodigo.Enabled = true;
            linkCodigo.Enabled = true;
            txtNota.Enabled = true;
            btnAgregar.Enabled = true;
            btnBorrar.Enabled = true;
            dgvListar.ReadOnly = false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (_facturar.TieneMovimientos(lblIdFactura.Text))
            {
                MessageBox.Show("Esta Factura tiene movimientos\nNo puede ser modificada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                HabilitarControles();
                btnGuardar.Enabled = true;
                btnImprimir.Enabled = false;
                btnBuscar.Enabled = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
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
                EFactura Factura = new EFactura()
                {
                    IdFactura = Convert.ToInt32(lblIdFactura.Text),
                    IdCliente = Convert.ToInt32(txtIdCliente.Text),
                    IdComprobante = cboTipoComprobante.SelectedValue.ToString(),
                    Fecha = DateTime.Now,
                    TipoCompra = cboTipoCompra.Text,
                    Nota = txtNota.Text,
                    Importe = Convert.ToDecimal(txtImporteFactura.Text),
                    Descuento = Convert.ToDecimal(txtDescuentoFactura.Text),
                    Itbis = Convert.ToDecimal(txtItbisFactura.Text),
                    Total = Convert.ToDecimal(txtTotalFactura.Text),
                };
                DataTable Detalle = new DataTable();
                Detalle.Columns.Add("[idArticulo]", typeof(int));
                Detalle.Columns.Add("[cantidad]", typeof(decimal));
                Detalle.Columns.Add("[descuento]", typeof(decimal));
                Detalle.Columns.Add("[precio]", typeof(decimal));
                Detalle.Columns.Add("[importe]", typeof(decimal));
                Detalle.Columns.Add("[costo]", typeof(decimal));
                Detalle.Columns.Add("[totalimporte]", typeof(decimal));
                Detalle.Columns.Add("[totaldescuento]", typeof(decimal));
                Detalle.Columns.Add("[totalitbis]", typeof(decimal));
                for (int i = 0; i < dgvListar.RowCount; i++)
                {
                    DataRow row = Detalle.NewRow();
                    row[0] = Convert.ToInt32(dgvListar.Rows[i].Cells[0].Value);
                    row[1] = Convert.ToDecimal(dgvListar.Rows[i].Cells[4].Value);
                    row[2] = Convert.ToDecimal(dgvListar.Rows[i].Cells[5].Value);
                    row[3] = Convert.ToDecimal(dgvListar.Rows[i].Cells[6].Value);
                    row[4] = Convert.ToDecimal(dgvListar.Rows[i].Cells[7].Value);
                    row[5] = Convert.ToDecimal(dgvListar.Rows[i].Cells[8].Value);
                    row[6] = Convert.ToDecimal(dgvListar.Rows[i].Cells[10].Value);
                    row[7] = Convert.ToDecimal(dgvListar.Rows[i].Cells[11].Value);
                    row[8] = Convert.ToDecimal(dgvListar.Rows[i].Cells[12].Value);
                    Detalle.Rows.Add(row);
                }
                _facturar.Editar(Factura, Detalle);
                DialogResult msj = MessageBox.Show("Desea Imprimir", "inf", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msj == DialogResult.Yes)
                {
                    using (LocalReport localReport = new LocalReport())
                    {
                        NrptEmpresa nEmpresa = new NrptEmpresa();
                        NrptFactura nFactura = new NrptFactura();
                        nEmpresa.LlenaEmpresa();
                        nFactura.Facturas(lblIdFactura.Text);
                        localReport.ReportPath = Application.StartupPath + @"\Reportes\rptFactura.rdlc";
                        localReport.DataSources.Clear();
                        localReport.DataSources.Add(new ReportDataSource("dsEmpresa", nEmpresa.Empresa));
                        localReport.DataSources.Add(new ReportDataSource("dsFactura", nFactura.Factura));
                        localReport.DataSources.Add(new ReportDataSource("dsFacturaDetalle", nFactura.FacturaDetalles));
                        localReport.PrintToPrinter();
                    }
                }
                btnNuevo.PerformClick();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult msj = MessageBox.Show("Desea Salir", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msj == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            using (LocalReport localReport = new LocalReport())
            {
                rptFactura frm = new rptFactura(lblIdFactura.Text);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    frm.Close();
                }
                //NrptEmpresa nEmpresa = new NrptEmpresa();
                //NrptFactura nFactura = new NrptFactura();
                //nEmpresa.LlenaEmpresa();
                //nFactura.Facturas(lblIdFactura.Text);
                ////localReport.ReportPath = @"C:\Users\Carlo\source\repos\RSS4\APP\Reportes\rptFactura.rdlc";
                //localReport.ReportPath = Application.StartupPath + @"\Reportes\rptFactura.rdlc";
                //localReport.DataSources.Clear();
                //localReport.DataSources.Add(new ReportDataSource("dsEmpresa", nEmpresa.Empresa));
                //localReport.DataSources.Add(new ReportDataSource("dsFactura", nFactura.Factura));
                //localReport.DataSources.Add(new ReportDataSource("dsFacturaDetalle", nFactura.FacturaDetalles));
                //localReport.PrintToPrinter();
                btnNuevo.PerformClick();
            }
        }
    }
}
