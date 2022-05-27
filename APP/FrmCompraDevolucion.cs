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
                            compra.Rows[i][15], compra.Rows[i][16], compra.Rows[i][17]);
                    }
                }
            }
        }
    }
}
