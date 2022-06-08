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
    public partial class FrmCompraDevolucion : Form
    {
        public FrmCompraDevolucion()
        {
            InitializeComponent();
        }

        private readonly NCompras _compra = new NCompras();

        private void FrmCompraDevolucion_Load(object sender, EventArgs e)
        {
            btnNuevo.PerformClick();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            dtpFecha.Value = DateTime.Now;
            btnBuscarCompra.Enabled = true;
            txtFacturaNumero.Text = null;
            txtNCF.Text = null;
            txtIdSuplidor.Text = null;
            txtSuplidorNombre.Text = null;
            lblIdCompra.Text = null;
            dgvListar.Rows.Clear();
            txtImporteCompra.Text = null;
            txtDescuentoCompra.Text = null;
            txtItbisCompra.Text = null;
            txtTotalCompra.Text = null;
            errorSuplidor.Clear();

            btnImprimir.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = false;
        }

        private void btnBuscarCompra_Click(object sender, EventArgs e)
        {
            FrmBuscarCompras frm = new FrmBuscarCompras();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                lblIdCompra.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                DataTable compra = _compra.BuscarId(lblIdCompra.Text);
                if (compra.Rows.Count > 0)
                {
                    txtIdSuplidor.Text = compra.Rows[0][1].ToString();
                    txtSuplidorNombre.Text = compra.Rows[0][2].ToString();
                    dtpFecha.Value = DateTime.Parse(compra.Rows[0][4].ToString());
                    txtFacturaNumero.Text = compra.Rows[0][5].ToString();
                    txtNCF.Text = compra.Rows[0][6].ToString();
                    for (int i = 0; i < compra.Rows.Count; i++)
                    {
                        _ = dgvListar.Rows.Add(compra.Rows[i][11], compra.Rows[i][12], compra.Rows[i][13],
                            compra.Rows[i][14], compra.Rows[i][15], compra.Rows[i][16], compra.Rows[i][17],
                            compra.Rows[i][18], compra.Rows[i][19], compra.Rows[i][20], compra.Rows[i][21],
                            compra.Rows[i][22], compra.Rows[i][23], compra.Rows[i][24], compra.Rows[i][25],
                            "",0m,0m, compra.Rows[i][15]);
                    }

                    DataTable Select = _compra.SelectDevluciones(lblIdCompra.Text);
                    if (Select.Rows.Count > 0)
                    {
                        for (int i = 0; i < dgvListar.RowCount; i++)
                        {
                            for (int x = 0; x < Select.Rows.Count; x++)
                            {
                                if (dgvListar.Rows[i].Cells[0].Value.ToString() == Select.Rows[x][0].ToString())
                                {
                                    dgvListar.Rows[i].Cells[4].Value = Convert.ToDecimal(dgvListar.Rows[i].Cells[4].Value) - Convert.ToDecimal(Select.Rows[x][1].ToString());
                                }
                            }
                        }
                    }
                }
            }
        }

        private void dgvListar_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dgvListar.CurrentCell.ColumnIndex == 16) //Desired Column
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

        private void dgvListar_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListar.CurrentRow.Cells[16].Value == null)
            {
                dgvListar.CurrentRow.Cells[16].Value = 0m;
            }
            if (decimal.TryParse(dgvListar.CurrentRow.Cells[16].Value.ToString(), out _))
            {
                decimal cantidad = Convert.ToDecimal(dgvListar.CurrentRow.Cells[16].Value);
                decimal cantidadComprada = Convert.ToDecimal(dgvListar.CurrentRow.Cells[4].Value);
                if (cantidad > cantidadComprada)
                {
                    cantidad = cantidadComprada;
                }
                decimal costo = Convert.ToDecimal(dgvListar.CurrentRow.Cells[6].Value);
                dgvListar.CurrentRow.Cells[16].Value = cantidad;
                dgvListar.CurrentRow.Cells[17].Value = cantidad * costo;
                CalcularTotal();
            }
        }

        private void CalcularTotal()
        {
            decimal importe = 0m;
            decimal descuento = 0m;
            decimal itbis = 0;
            for (int i = 0; i < dgvListar.RowCount; i++)
            {
                if (Convert.ToDecimal(dgvListar.Rows[i].Cells[4].Value) != 0)
                {
                    importe += (Convert.ToDecimal(dgvListar.Rows[i].Cells[12].Value) / Convert.ToDecimal(dgvListar.Rows[i].Cells[18].Value)) * Convert.ToDecimal(dgvListar.Rows[i].Cells[16].Value);
                    descuento += (Convert.ToDecimal(dgvListar.Rows[i].Cells[13].Value) / Convert.ToDecimal(dgvListar.Rows[i].Cells[18].Value)) * Convert.ToDecimal(dgvListar.Rows[i].Cells[16].Value);
                    itbis += (Convert.ToDecimal(dgvListar.Rows[i].Cells[14].Value) / Convert.ToDecimal(dgvListar.Rows[i].Cells[18].Value)) * Convert.ToDecimal(dgvListar.Rows[i].Cells[16].Value);

                }
            }
            txtImporteCompra.Text = importe.ToString("N2");
            txtDescuentoCompra.Text = descuento.ToString("N2");
            txtItbisCompra.Text = itbis.ToString("N2");
            txtTotalCompra.Text = (importe - descuento + itbis).ToString("N2");
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSuplidorNombre.Text))
            {
                errorSuplidor.SetError(txtSuplidorNombre, "NO hay compra seleccionada");
                return;
            }
            else
            {
                errorSuplidor.Clear();
            }
            if (string.IsNullOrEmpty(txtTotalCompra.Text) || txtTotalCompra.Text == "0.00")
            {
                _ = MessageBox.Show("No hay Articulos Para Devolver", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ECompra compra = new ECompra()
            {
                IdCompra = Convert.ToInt32(lblIdCompra.Text),
                IdSuplidor = Convert.ToInt32(txtIdSuplidor.Text),
                Fecha = dtpFecha.Value,
                Importe = Convert.ToDecimal(txtImporteCompra.Text),
                Descuento = Convert.ToDecimal(txtDescuentoCompra.Text),
                Itbis = Convert.ToDecimal(txtItbisCompra.Text),
                Total = Convert.ToDecimal(txtTotalCompra.Text)
            };
            DataTable Detalle = new DataTable();
            Detalle.Columns.Add("id_articulo", typeof(int));
            Detalle.Columns.Add("cantidad", typeof(decimal));
            Detalle.Columns.Add("importe", typeof(decimal));
            for (int i = 0; i < dgvListar.RowCount; i++)
            {
                if (Convert.ToDecimal(dgvListar.Rows[i].Cells[16].Value) > 0)
                {
                    DataRow row = Detalle.NewRow();
                    row[0] = Convert.ToInt16(dgvListar.Rows[i].Cells[0].Value);
                    row[1] = Convert.ToDecimal(dgvListar.Rows[i].Cells[16].Value);
                    row[2] = Convert.ToDecimal(dgvListar.Rows[i].Cells[17].Value);
                    Detalle.Rows.Add(row);
                }
            }
            _compra.InsertarDevolucion(compra, Detalle);
            btnNuevo.PerformClick();
        }
    }
}
