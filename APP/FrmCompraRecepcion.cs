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
                        _ = dgvListar.Rows.Add(row[11], row[12], row[13], "", row[20], "", row[20], row[21], row[22]);
                    }
                }
            }
        }
    }
}
