using APP.Buscar;
using APP.Reportes;
using Entidades;
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
    public partial class FrmCaja_cuadre : Form
    {
        public FrmCaja_cuadre()
        {
            InitializeComponent();
        }

        private ECaja caja = new ECaja();

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            caja = new ECaja();
            cajeroTxt.Text = "";
            montoTxt.Text = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarCajas frm = new FrmBuscarCajas();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                caja.id_caja = (int)frm.listarDgv.SelectedCells[0].Value;
                caja.apertura_nombre = frm.listarDgv.SelectedCells[2].Value.ToString();
                caja.total_caja = (double)frm.listarDgv.SelectedCells[3].Value;
                cajeroTxt.Text = caja.apertura_nombre;
                montoTxt.Text = caja.total_caja.ToString("n2");
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (caja.id_caja != 0)
            {
                rptCuadreCaja2 frm = new rptCuadreCaja2(caja.id_caja);
                _ = frm.ShowDialog();
                btnNuevo.PerformClick();
            }
        }
    }
}
