using APP.Buscar;
using Entidades;
using Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP
{
    public partial class FrmFacturaDevolucion : Form
    {
        public FrmFacturaDevolucion()
        {
            InitializeComponent();
            cboTipoComprobante.DataSource = _comprobante.ComprovantesVentas();
            cboTipoComprobante.ValueMember = "id_comprobante";
            cboTipoComprobante.DisplayMember = "nombre_comprobante";
        }

        private readonly NComprobantes _comprobante = new NComprobantes();
        private readonly NFacturacion _facturar = new NFacturacion();

        private void FrmFacturaDevolucion_Load(object sender, EventArgs e)
        {
            btnNuevo.PerformClick();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            dtpFecha.Value = DateTime.Now;
            txtIdFactura.Text = null;
            txtNCF.Text = null;
            txtFechaFactura.Text = null;
            lblDias.Text = "0";
            txtNombre.Text = null;
            txtDireccion.Text = null;
            txtCedula.Text = null;
            txtRNC.Text = null;
            txtTipoFactura.Text = null;
            cboTipoComprobante.SelectedIndex = 0;
            dgvListar.Rows.Clear();
            txtImporteFactura.Text = null;
            txtDescuentoFactura.Text = null;
            txtItbisFactura.Text = null;
            txtTotalFactura.Text = null;
            lblIdDevolucion.Visible = false;
            lblNCF.Visible = false;

            txtIdFactura.Enabled = true;
            btnBuscarFactura.Enabled = true;
            dgvListar.ReadOnly = false;

            btnImprimir.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = false;
        }

        private void btnBuscarFactura_Click(object sender, EventArgs e)
        {
            FrmBuscarFactura frm = new FrmBuscarFactura();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtIdFactura.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                LlenarForm(txtIdFactura.Text);
            }
        }

        private void txtIdFactura_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdFactura.Text))
            {
                LlenarForm(txtIdFactura.Text);
            }
        }

        private void LlenarForm(string IdFactura)
        {
            dgvListar.Rows.Clear();
            DataTable facturaTable = _facturar.BuscarId(IdFactura);
            if (facturaTable.Rows.Count > 0)
            {
                txtIdFactura.Text = facturaTable.Rows[0][0].ToString();
                txtNCF.Text = facturaTable.Rows[0][1].ToString();
                DateTime D2 = (DateTime)facturaTable.Rows[0][2];
                txtFechaFactura.Text = D2.ToString("dd / MM / yyyy - hh:mm tt");
                lblDias.Text = (DateTime.Now - D2).Days.ToString();
                txtIdCliente.Text = facturaTable.Rows[0][3].ToString();
                txtNombre.Text = facturaTable.Rows[0][4].ToString();
                txtDireccion.Text = facturaTable.Rows[0][5].ToString();
                txtCedula.Text = facturaTable.Rows[0][6].ToString();
                txtRNC.Text = facturaTable.Rows[0][7].ToString();
                txtTipoFactura.Text = facturaTable.Rows[0][8].ToString();
                cboTipoComprobante.SelectedValue = facturaTable.Rows[0][9].ToString();
                DataTable CargarDev = _facturar.DevolucionCargar(IdFactura);
                for (int i = 0; i < facturaTable.Rows.Count; i++)
                {
                    dgvListar.Rows.Add(facturaTable.Rows[i][16], facturaTable.Rows[i][17],
                        facturaTable.Rows[i][18], facturaTable.Rows[i][20], facturaTable.Rows[i][21],
                        facturaTable.Rows[i][22], "", "", "", facturaTable.Rows[i][25], facturaTable.Rows[i][24],
                        facturaTable.Rows[i][27], facturaTable.Rows[i][28], facturaTable.Rows[i][24], facturaTable.Rows[i][33]);
                }
                for (int y = 0; y < CargarDev.Rows.Count; y++)
                {
                    for (int i = 0; i < dgvListar.RowCount; i++)
                    {
                        if (dgvListar.Rows[i].Cells[0].Value.ToString() == CargarDev.Rows[y][0].ToString())
                        {
                            dgvListar.Rows[i].Cells[3].Value = Convert.ToDecimal(dgvListar.Rows[i].Cells[3].Value) - Convert.ToDecimal(CargarDev.Rows[y][1]);
                        }
                    }
                }
            }
            else
            {
                txtNCF.Text = null;
                txtFechaFactura.Text = null;
                txtNombre.Text = null;
                txtDireccion.Text = null;
                txtCedula.Text = null;
                txtRNC.Text = null;
            }
        }

        private void dgvListar_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListar.CurrentRow.Cells[7].Value == null)
            {
                dgvListar.CurrentRow.Cells[7].Value = "";
            }
            if (decimal.TryParse(dgvListar.CurrentRow.Cells[7].Value.ToString(), out _))
            {
                decimal dev = Convert.ToDecimal(dgvListar.CurrentRow.Cells[7].Value);
                decimal cant = Convert.ToDecimal(dgvListar.CurrentRow.Cells[3].Value);
                if (dev > cant)
                {
                    dev = cant;
                }
                dgvListar.CurrentRow.Cells[7].Value = dev.ToString("N2");
                CalculaTotal();
            }
        }

        private void dgvListar_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dgvListar.CurrentCell.ColumnIndex == 7) //Desired Column
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

        private void CalculaTotal()
        {
            decimal importeTotal = 0m;
            decimal descuentoTotal = 0m;
            decimal itbisTotal = 0m;
            for (int i = 0; i < dgvListar.RowCount; i++)
            {
                if (dgvListar.Rows[i].Cells[7].Value == null)
                {
                    dgvListar.Rows[i].Cells[7].Value = "";
                }
                bool tryy = decimal.TryParse(dgvListar.Rows[i].Cells[7].Value.ToString(), out _);
                if (tryy)
                {
                    decimal precioNeto = Convert.ToDecimal(dgvListar.Rows[i].Cells[5].Value);
                    decimal cantidad = Convert.ToDecimal(dgvListar.Rows[i].Cells[7].Value);
                    decimal descuento = Convert.ToDecimal(dgvListar.Rows[i].Cells[4].Value) / 100;
                    decimal itbis = 1 + (Convert.ToDecimal(dgvListar.Rows[i].Cells[9].Value) / 100);
                    decimal precio = precioNeto / itbis;
                    descuento = precio * descuento;
                    itbis = (precio - descuento) * (itbis - 1);
                    dgvListar.Rows[i].Cells[5].Value = Convert.ToDecimal(dgvListar.Rows[i].Cells[5].Value);
                    dgvListar.Rows[i].Cells[8].Value = decimal.Round(cantidad * precioNeto, 2);
                    dgvListar.Rows[i].Cells[10].Value = decimal.Round(cantidad * precio, 2);
                    dgvListar.Rows[i].Cells[11].Value = decimal.Round(cantidad * descuento, 2);
                    dgvListar.Rows[i].Cells[12].Value = decimal.Round(cantidad * itbis, 2);

                    importeTotal += Convert.ToDecimal(dgvListar.Rows[i].Cells[10].Value);
                    descuentoTotal += Convert.ToDecimal(dgvListar.Rows[i].Cells[11].Value);
                    itbisTotal += Convert.ToDecimal(dgvListar.Rows[i].Cells[12].Value);
                }
            }
            txtImporteFactura.Text = importeTotal.ToString("N2");
            txtDescuentoFactura.Text = descuentoTotal.ToString("N2");
            txtItbisFactura.Text = itbisTotal.ToString("N2");
            txtTotalFactura.Text = (importeTotal - descuentoTotal + itbisTotal).ToString("N2");
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTotalFactura.Text) && !string.IsNullOrEmpty(txtNombre.Text))
            {
                bool tryy = decimal.TryParse(txtTotalFactura.Text, out _);
                if (tryy)
                {
                    EFactura Factura = new EFactura()
                    {
                        IdFactura = Convert.ToInt32(txtIdFactura.Text),
                        IdCliente = Convert.ToInt32(txtIdCliente.Text),
                        IdComprobante = "B04",
                        Fecha = DateTime.Now,
                        TipoCompra = txtTipoFactura.Text,
                        Importe = Convert.ToDecimal(txtImporteFactura.Text),
                        Descuento = Convert.ToDecimal(txtDescuentoFactura.Text),
                        Itbis = Convert.ToDecimal(txtItbisFactura.Text),
                        Total = Convert.ToDecimal(txtTotalFactura.Text),
                    };
                    if (Factura.Total > 0)
                    {
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
                        Detalle.Columns.Add("[precio]", typeof(decimal));
                        Detalle.Columns.Add("[totalimporte]", typeof(decimal));
                        Detalle.Columns.Add("[totaldescuento]", typeof(decimal));
                        Detalle.Columns.Add("[totalitbis]", typeof(decimal));
                        Detalle.Columns.Add("[costo]", typeof(decimal));
                        Detalle.Columns.Add("[id_iemi]", typeof(string));
                        for (int i = 0; i < dgvListar.RowCount; i++)
                        {
                            if (double.TryParse(dgvListar.Rows[i].Cells[7].Value.ToString(), out _))
                            {
                                DataRow row = Detalle.NewRow();
                                row[0] = Convert.ToInt32(dgvListar.Rows[i].Cells[0].Value);
                                row[1] = Convert.ToDecimal(dgvListar.Rows[i].Cells[7].Value);
                                row[2] = Convert.ToDecimal(dgvListar.Rows[i].Cells[5].Value);
                                row[3] = Convert.ToDecimal(dgvListar.Rows[i].Cells[10].Value);
                                row[4] = Convert.ToDecimal(dgvListar.Rows[i].Cells[11].Value);
                                row[5] = Convert.ToDecimal(dgvListar.Rows[i].Cells[12].Value);
                                row[6] = Convert.ToDecimal(dgvListar.Rows[i].Cells[13].Value);
                                row[7] = Convert.ToString(dgvListar.Rows[i].Cells[14].Value);
                                Detalle.Rows.Add(row);
                            }
                        }
                        _facturar.InsertarDevolucion(Factura, Detalle);
                        btnNuevo.PerformClick();
                    }
                    else
                    {
                        _ = MessageBox.Show("No hay Monto para devolver", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarDevolucion frm = new FrmBuscarDevolucion();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                lblIdDevolucion.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                lblNCF.Text = frm.dgvListar.SelectedCells[1].Value.ToString();
                lblIdDevolucion.Visible = true;
                lblNCF.Visible = true;
                DataTable dev = _facturar.BuscarDevoluionId(lblIdDevolucion.Text);
                LlenarForm(dev.Rows[0][0].ToString());
                for (int i = 0; i < dgvListar.Rows.Count; i++)
                {
                    foreach (DataRow row in dev.Rows)
                    {
                        if (dgvListar.Rows[i].Cells[0].Value.ToString() == row[1].ToString())
                        {
                            dgvListar.Rows[i].Cells[7].Value = row[2];
                        }
                    }
                }
                CalculaTotal();

                txtIdFactura.Enabled = false;
                btnBuscarFactura.Enabled = false;
                dgvListar.ReadOnly = true;

                btnSalvar.Enabled = false;
                btnImprimir.Enabled = true;
                //btnModificar.Enabled = true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            btnImprimir.Enabled = false;
            btnGuardar.Enabled = true;
            dgvListar.ReadOnly = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTotalFactura.Text) && !string.IsNullOrEmpty(txtNombre.Text))
            {
                bool tryy = decimal.TryParse(txtTotalFactura.Text, out _);
                if (tryy)
                {
                    EFactura Factura = new EFactura()
                    {
                        IdDevolucion = Convert.ToInt32(lblIdDevolucion.Text),
                        Importe = Convert.ToDecimal(txtImporteFactura.Text),
                        Descuento = Convert.ToDecimal(txtDescuentoFactura.Text),
                        Itbis = Convert.ToDecimal(txtItbisFactura.Text),
                        Total = Convert.ToDecimal(txtTotalFactura.Text),
                    };
                    if (Factura.Total > 0)
                    {
                        DataTable Detalle = new DataTable();
                        Detalle.Columns.Add("[idArticulo]", typeof(int));
                        Detalle.Columns.Add("[cantidad]", typeof(decimal));
                        Detalle.Columns.Add("[precio]", typeof(decimal));
                        Detalle.Columns.Add("[totalimporte]", typeof(decimal));
                        Detalle.Columns.Add("[totaldescuento]", typeof(decimal));
                        Detalle.Columns.Add("[totalitbis]", typeof(decimal));
                        Detalle.Columns.Add("[costo]", typeof(decimal));
                        Detalle.Columns.Add("[id_iemi]", typeof(string));
                        for (int i = 0; i < dgvListar.RowCount; i++)
                        {
                            if (double.TryParse(dgvListar.Rows[i].Cells[7].Value.ToString(), out _))
                            {
                                DataRow row = Detalle.NewRow();
                                row[0] = Convert.ToInt32(dgvListar.Rows[i].Cells[0].Value);
                                row[1] = Convert.ToDecimal(dgvListar.Rows[i].Cells[7].Value);
                                row[2] = Convert.ToDecimal(dgvListar.Rows[i].Cells[5].Value);
                                row[3] = Convert.ToDecimal(dgvListar.Rows[i].Cells[10].Value);
                                row[4] = Convert.ToDecimal(dgvListar.Rows[i].Cells[11].Value);
                                row[5] = Convert.ToDecimal(dgvListar.Rows[i].Cells[12].Value);
                                row[6] = Convert.ToDecimal(dgvListar.Rows[i].Cells[13].Value);
                                row[7] = Convert.ToString(dgvListar.Rows[i].Cells[14].Value);
                                Detalle.Rows.Add(row);
                            }
                        }
                        //_facturar.InsertarDevolucion(Factura, Detalle);
                        btnNuevo.PerformClick();
                    }
                    else
                    {
                        _ = MessageBox.Show("No hay Monto para devolver", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }
    }
}
