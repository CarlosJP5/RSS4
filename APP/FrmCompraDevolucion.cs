using APP.Buscar;
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
                            "",0m,0m);
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

        }
    }
}
