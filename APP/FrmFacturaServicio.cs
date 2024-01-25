using APP.Buscar;
using APP.Reportes;
using Entidades;
using Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP
{
    public partial class FrmFacturaServicio : Form
    {
        public FrmFacturaServicio()
        {
            InitializeComponent();
            cboTipoComprobante.DataSource = _comprobante.ComprovantesVentas();
            cboTipoComprobante.ValueMember = "id_comprobante";
            cboTipoComprobante.DisplayMember = "nombre_comprobante";
        }

        private ECaja caja = new ECaja();
        private readonly NComprobantes _comprobante = new NComprobantes();
        private readonly NServicio nservicio = new NServicio();

        private void CalculaTotal()
        {
            if (cboTipoComprobante.SelectedValue.ToString() != "B02")
            {
                decimal importe = 0m;
                for (int i = 0; i < dgvListar.Rows.Count - 1; i++)
                {
                    importe += Convert.ToDecimal(dgvListar.Rows[i].Cells[1].Value);
                }
                decimal itbis = importe * 0.18m;
                txtImporte.Text = importe.ToString("N2");
                txtItbis.Text = itbis.ToString("N2");
                txtTotal.Text = (importe + itbis).ToString("N2");
            }
            else
            {
                decimal importe = 0m;
                for (int i = 0; i < dgvListar.Rows.Count - 1; i++)
                {
                    importe += Convert.ToDecimal(dgvListar.Rows[i].Cells[1].Value);
                }
                decimal itbis = 0m;
                txtImporte.Text = importe.ToString("N2");
                txtItbis.Text = itbis.ToString("N2");
                txtTotal.Text = (importe + itbis).ToString("N2");
            }
        }

        private void desabilita_controles()
        {
            txtIdCliente.Enabled = false;
            btnBuscarClientes.Enabled = false;
            txtNombre.Enabled = false;
            cboTipoComprobante.Enabled = false;
            txtCedula.Enabled = false;
            txtRnc.Enabled = false;
            linkLabel1.Enabled = false;
            cboTipoCompra.Enabled = false;
            dgvListar.ReadOnly = true;
        }

        private void habilita_controles()
        {
            txtIdCliente.Enabled = true;
            btnBuscarClientes.Enabled = true;
            txtNombre.Enabled = true;
            cboTipoComprobante.Enabled = true;
            txtCedula.Enabled = true;
            txtRnc.Enabled = true;
            dgvListar.ReadOnly = false;
        }

        private void FrmFacturaServicio_Load(object sender, EventArgs e)
        {
            btnNuevo.PerformClick();
            cboImprecion.SelectedIndex = 0;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtIdCliente.Text = string.Empty;
            txtNombre.Text = string.Empty;
            cboTipoComprobante.SelectedValue = "B02";
            dtpFecha.Value = DateTime.Now;
            txtCedula.Text = string.Empty;
            txtRnc.Text = string.Empty;
            dgvListar.Rows.Clear();
            txtImporte.Text = string.Empty;
            txtItbis.Text = string.Empty;
            txtTotal.Text = string.Empty;
            lblidFactura_int.Text = string.Empty;
            txtCotizacion.Text = string.Empty;
            lblIdFactura.Text = "~~~";
            lblNcf.Text = "~~~";

            btnImprimir.Enabled = false;
            btnModificar.Enabled = false;
            btnFacturar.Enabled = true;
            btnBuscar.Enabled = true;
            cboTipoCompra.Enabled = true;
            linkLabel1.Enabled = true;
            habilita_controles();
            _ = txtIdCliente.Focus();
        }

        private void btnBuscarClientes_Click(object sender, EventArgs e)
        {
            FrmBuscarClientes frm = new FrmBuscarClientes();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtIdCliente.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                txtRnc.Text = frm.dgvListar.SelectedCells[1].Value.ToString();
                txtNombre.Text = frm.dgvListar.SelectedCells[2].Value.ToString();
                txtCedula.Text = frm.dgvListar.SelectedCells[7].Value.ToString();
                cboTipoComprobante.SelectedValue = frm.dgvListar.SelectedCells[6].Value.ToString();
                cboTipoCompra.Text = frm.dgvListar.SelectedCells[9].Value.ToString();
                _ = dgvListar.Focus();
            }
        }

        private void txtIdCliente_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtIdCliente.Text))
            {
                NClientes ncliente = new NClientes();
                DataTable cliente = ncliente.BuscarId(txtIdCliente.Text);
                if (cliente.Rows.Count > 0)
                {
                    txtNombre.Text = cliente.Rows[0][2].ToString();
                    txtCedula.Text = cliente.Rows[0][3].ToString();
                    txtRnc.Text = cliente.Rows[0][4].ToString();
                    cboTipoComprobante.SelectedValue = cliente.Rows[0][1].ToString();
                    cboTipoCompra.Text = cliente.Rows[0][8].ToString();
                }
            }
        }

        private void dgvListar_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListar.CurrentRow.Cells[1].Value != null)
            {
                if (decimal.TryParse(dgvListar.CurrentRow.Cells[1].Value.ToString(), out _))
                {
                    decimal precio = decimal.Parse(dgvListar.CurrentRow.Cells[1].Value.ToString());
                    dgvListar.CurrentRow.Cells[1].Value = precio;
                }
                else
                {
                    dgvListar.CurrentRow.Cells[1].Value = 0;
                }
            }
            else
            {
                dgvListar.CurrentRow.Cells[1].Value = 0;
            }
            CalculaTotal();
        }

        private void dgvListar_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dgvListar.CurrentCell.ColumnIndex == 1) //Desired Column
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

        private void dgvListar_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculaTotal();
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
            if (!string.IsNullOrEmpty(txtTotal.Text))
            {
                string idFacuraServicio = "";
                decimal total = decimal.Parse(txtTotal.Text);
                if (total > 0)
                {
                    EServicio Factura = new EServicio()
                    {
                        Fecha = DateTime.Now,
                        IdCliente = int.Parse(txtIdCliente.Text),
                        NombreCliente = txtNombre.Text,
                        Cedula = txtCedula.Text,
                        Rnc = txtRnc.Text,
                        IdComprobante = cboTipoComprobante.SelectedValue.ToString(),
                        TipoCompra = cboTipoCompra.Text,
                        NombreComprobante = cboTipoComprobante.Text,
                        Importe = decimal.Parse(txtImporte.Text),
                        Itbis = decimal.Parse(txtItbis.Text),
                        Total = decimal.Parse(txtTotal.Text),
                        IdCaja = caja.id_caja
                    };
                    if (caja.id_caja == 0)
                    {
                        _ = MessageBox.Show("Debe seleccionar un cajero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (!string.IsNullOrWhiteSpace(txtCotizacion.Text))
                    {
                        Factura.IdCotizacion = txtCotizacion.Text;
                    }
                    DataTable Detalle = new DataTable();
                    Detalle.Columns.Add("[descripcion]", typeof(string));
                    Detalle.Columns.Add("[precio]", typeof(decimal));
                    for (int i = 0; i < dgvListar.RowCount - 1; i++)
                    {
                        DataRow row = Detalle.NewRow();
                        row[0] = Convert.ToString(dgvListar.Rows[i].Cells[0].Value);
                        row[1] = Convert.ToDecimal(dgvListar.Rows[i].Cells[1].Value);
                        Detalle.Rows.Add(row);
                    }
                    if (string.IsNullOrEmpty(lblidFactura_int.Text))
                    {
                        // Insertar
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
                        idFacuraServicio = nservicio.Insertar(Factura, Detalle);
                    }
                    else
                    {
                        // Editar
                        Factura.IdFactura = int.Parse(lblidFactura_int.Text);
                        nservicio.Editar(Factura, Detalle);
                        idFacuraServicio = lblIdFactura.Text;
                    }
                    DialogResult msj = MessageBox.Show("Desea Imprimir", "inf", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (msj == DialogResult.Yes)
                    {
                        if (cboImprecion.SelectedIndex == 0)
                        {
                            rptFacturaServicio frm = new rptFacturaServicio(idFacuraServicio);
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                frm.Close();
                            }
                        }
                        else
                        {
                            rptFacturaServicioA4 frm = new rptFacturaServicioA4(idFacuraServicio);
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                frm.Close();
                            }
                        }
                    }
                    btnNuevo.PerformClick();
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarFacturaServicio frm = new FrmBuscarFacturaServicio();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataTable factura = nservicio.Listar(frm.dgvListar.SelectedCells[0].Value.ToString());
                txtIdCliente.Text = factura.Rows[0][2].ToString();
                txtNombre.Text = factura.Rows[0][3].ToString();
                cboTipoComprobante.SelectedValue = factura.Rows[0][6].ToString();
                dtpFecha.Value = DateTime.Parse(factura.Rows[0][1].ToString());
                txtCedula.Text = factura.Rows[0][4].ToString();
                txtRnc.Text = factura.Rows[0][5].ToString();
                txtImporte.Text = factura.Rows[0][8].ToString();
                txtItbis.Text = factura.Rows[0][9].ToString();
                txtTotal.Text = factura.Rows[0][10].ToString();
                lblIdFactura.Text = factura.Rows[0][11].ToString();
                lblNcf.Text = factura.Rows[0][15].ToString();
                lblidFactura_int.Text = factura.Rows[0][0].ToString();
                cboTipoCompra.Text = factura.Rows[0][12].ToString();
                foreach (DataRow row in factura.Rows)
                {
                    _ = dgvListar.Rows.Add(row[19], row[20]);
                }

                desabilita_controles();
                btnFacturar.Enabled = false;
                btnImprimir.Enabled = true;
                btnModificar.Enabled = true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            habilita_controles();
            btnImprimir.Enabled = false;
            btnBuscar.Enabled = false;
            btnFacturar.Enabled = true;
            btnModificar.Enabled = false;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblIdFactura.Text))
            {
                DialogResult msj = MessageBox.Show("Desea Imprimir", "inf", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msj == DialogResult.Yes)
                {
                    if (cboImprecion.SelectedIndex == 0)
                    {
                        rptFacturaServicio frm = new rptFacturaServicio(lblIdFactura.Text);
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            frm.Close();
                        }
                    }
                    else
                    {
                        rptFacturaServicioA4 frm = new rptFacturaServicioA4(lblIdFactura.Text);
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            frm.Close();
                        }
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

        private void txtIdCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                _ = dgvListar.Focus();
            }
        }

        private void cboTipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculaTotal();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBuscarCotizacionServicio frm = new FrmBuscarCotizacionServicio();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                NCotizacionServicio ncotizacionServicio = new NCotizacionServicio();
                DataTable factura = ncotizacionServicio.Listar(frm.dgvListar.SelectedCells[0].Value.ToString());
                if (factura.Rows[0][12].ToString() != "Facturado")
                {
                    txtIdCliente.Text = factura.Rows[0][2].ToString();
                    txtNombre.Text = factura.Rows[0][3].ToString();
                    cboTipoComprobante.SelectedValue = factura.Rows[0][6].ToString();
                    cboTipoCompra.Text = factura.Rows[0][13].ToString();
                    dtpFecha.Value = DateTime.Now;
                    txtCedula.Text = factura.Rows[0][4].ToString();
                    txtRnc.Text = factura.Rows[0][5].ToString();
                    txtImporte.Text = factura.Rows[0][8].ToString();
                    txtItbis.Text = factura.Rows[0][9].ToString();
                    txtTotal.Text = factura.Rows[0][10].ToString();
                    txtCotizacion.Text = factura.Rows[0][11].ToString();
                    foreach (DataRow row in factura.Rows)
                    {
                        _ = dgvListar.Rows.Add(row[15], row[16]);
                    }
                }
                else
                {
                    _ = MessageBox.Show("Esta cotizacion ha sido Facturada", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LlenarCaja();
        }

        private void LlenarCaja()
        {
            FrmBuscarCajas frm = new FrmBuscarCajas();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.listarDgv.SelectedCells[4].Value.ToString() != "CERRADA")
                {
                    caja.id_caja = (int)frm.listarDgv.SelectedCells[0].Value;
                    caja.apertura_nombre = frm.listarDgv.SelectedCells[2].Value.ToString();
                    caja.total_caja = (double)frm.listarDgv.SelectedCells[3].Value;
                    cajeroTxt.Text = caja.apertura_nombre;
                }
                else
                {
                    caja = new ECaja();
                    cajeroTxt.Text = caja.apertura_nombre;
                    _ = MessageBox.Show("Esta caja esta cerrada", "Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }
    }
}
