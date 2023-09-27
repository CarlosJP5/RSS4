using APP.Buscar;
using Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP
{
    public partial class FrmCompraRecepcion : Form
    {
        public FrmCompraRecepcion()
        {
            InitializeComponent();
        }

        private readonly NComprasRecepcion recepcion = new NComprasRecepcion();

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NCompras _compra = new NCompras();
            FrmBuscarCompras frm = new FrmBuscarCompras();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dgvListar.Rows.Clear();
                idCompraTxt.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                DataTable compra = _compra.BuscarId(idCompraTxt.Text);
                //if (compra.Rows.Count > 0)
                //{
                //txtIdSuplidor.Text = compra.Rows[0][1].ToString();
                suplidorNombreLbl.Text = compra.Rows[0][2].ToString();
                //cboTipoCompra.Text = compra.Rows[0][3].ToString();
                //dtpFecha.Value = DateTime.Parse(compra.Rows[0][4].ToString());
                //txtFacturaNumero.Text = compra.Rows[0][5].ToString();
                //txtNCF.Text = compra.Rows[0][6].ToString();
                //txtImporteCompra.Text = compra.Rows[0][7].ToString();
                //txtDescuentoCompra.Text = compra.Rows[0][8].ToString();
                //txtItbisCompra.Text = compra.Rows[0][9].ToString();
                //txtTotalCompra.Text = compra.Rows[0][10].ToString();
                //for (int i = 0; i < compra.Rows.Count; i++)
                //{
                //    _ = dgvListar.Rows.Add(compra.Rows[i][11], compra.Rows[i][12], compra.Rows[i][13],
                //        compra.Rows[i][14], compra.Rows[i][15], compra.Rows[i][16], compra.Rows[i][17],
                //        compra.Rows[i][18], compra.Rows[i][19], compra.Rows[i][20], compra.Rows[i][21],
                //        compra.Rows[i][22], compra.Rows[i][23], compra.Rows[i][24], compra.Rows[i][25]);
                //}
                //CalculaTotal();
                //}
                foreach (DataRow row in compra.Rows)
                {
                    for (int i = 0; i < Convert.ToDouble(row[15]); i++)
                    {
                        _ = dgvListar.Rows.Add(row[11], row[12], row[13], "", row[20], "0.00", row[20], row[21], row[22]);
                    }
                }

                DataTable insertado = recepcion.Insertada(idCompraTxt.Text);
                foreach (DataRow dtrow in insertado.Rows)
                {
                    for (int i = 0; i < dgvListar.RowCount; i++)
                    {
                        if (dtrow[4].ToString() == dgvListar.Rows[i].Cells[0].Value.ToString())
                        {
                            dgvListar.Rows.RemoveAt(i);
                            break;
                        }
                    }
                }
                if (dgvListar.RowCount == 0)
                {
                    MessageBox.Show("Compra recivida completa.", "Inf.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    foreach (DataRow row in insertado.Rows)
                    {
                        _ = dgvListar.Rows.Add(row[4], row[5], row[6], row[7], row[8], row[9], row[10], row[11], row[12]);
                    }
                    dgvListar.ReadOnly = true;
                    linkLabel1.Enabled = false;
                }
                cantidadLbl.Text = dgvListar.RowCount.ToString();
            }
        }

        private void dgvListar_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (double.TryParse(dgvListar.CurrentRow.Cells[4].Value.ToString(), out double costo))
            {
                dgvListar.CurrentRow.Cells[4].Value = costo;
            }
            else
            {
                dgvListar.CurrentRow.Cells[4].Value = costo;
            }
            if (double.TryParse(dgvListar.CurrentRow.Cells[5].Value.ToString(), out double courier))
            {
                dgvListar.CurrentRow.Cells[5].Value = courier;
            }
            else
            {
                dgvListar.CurrentRow.Cells[5].Value = courier;
            }
            double costoFinal = costo + courier;
            dgvListar.CurrentRow.Cells[6].Value = costoFinal;

            if (double.TryParse(dgvListar.CurrentRow.Cells[7].Value.ToString(), out double precio))
            {
                dgvListar.CurrentRow.Cells[7].Value = precio;
            }
            else
            {
                dgvListar.CurrentRow.Cells[7].Value = precio;
            }

            double beneficio = 100;
            if (costoFinal > 0)
            {
                beneficio = ((precio - costoFinal) / costoFinal * 100);
            }
            dgvListar.CurrentRow.Cells[8].Value = beneficio;

            //decimal precio = Convert.ToDecimal(txtPrecio.Text);
            //decimal costo = Convert.ToDecimal(txtCostoFinal.Text);
            //if (costo != 0)
            //{
            //    txtBeneficio.Text = ((precio - costo) / costo * 100).ToString("N2");
            //}
            //else
            //{
            //    txtBeneficio.Text = "100.00";
            //}
            //txtPrecio.Text = precio.ToString("N2");
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            DataTable Detalle = new DataTable();
            Detalle.Columns.Add("[id_articulo]", typeof(int));
            Detalle.Columns.Add("[codigo]", typeof(string));
            Detalle.Columns.Add("[nombre]", typeof(string));
            Detalle.Columns.Add("[Imei]", typeof(string));
            Detalle.Columns.Add("[costo]", typeof(double));
            Detalle.Columns.Add("[courier]", typeof(double));
            Detalle.Columns.Add("[costo_final]", typeof(double));
            Detalle.Columns.Add("[precio]", typeof(double));
            Detalle.Columns.Add("[beneficio]", typeof(double));

            foreach (DataGridViewRow row in dgvListar.Rows)
            {
                if (Convert.ToBoolean(row.Cells[9].Value))
                {
                    DataRow drow = Detalle.NewRow();
                    drow[0] = Convert.ToInt32(row.Cells[0].Value);
                    drow[1] = Convert.ToString(row.Cells[1].Value);
                    drow[2] = Convert.ToString(row.Cells[2].Value);
                    drow[3] = Convert.ToString(row.Cells[3].Value);
                    drow[4] = Convert.ToDouble(row.Cells[4].Value);
                    drow[5] = Convert.ToDouble(row.Cells[5].Value);
                    drow[6] = Convert.ToDouble(row.Cells[6].Value);
                    drow[7] = Convert.ToDouble(row.Cells[7].Value);
                    drow[8] = Convert.ToDouble(row.Cells[8].Value);
                    Detalle.Rows.Add(drow);
                }
            }

            recepcion.Insertar(idCompraTxt.Text, Detalle);
            btnNuevo.PerformClick();
        }

        private void dgvListar_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dgvListar.CurrentCell.ColumnIndex == 5 || dgvListar.CurrentCell.ColumnIndex == 7 || dgvListar.CurrentCell.ColumnIndex == 6) //Desired Column
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            linkLabel1.Enabled = true;
            idCompraTxt.Text = "";
            suplidorNombreLbl.Text = "Suplidor";
            dgvListar.Rows.Clear();
            dgvListar.ReadOnly = false;
            cantidadLbl.Text = "0";
        }
    }
}
