using APP.Buscar;
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
    public partial class FrmBancosMovimientos : Form
    {
        public FrmBancosMovimientos()
        {
            InitializeComponent();
        }

        private void FrmBancosMovimientos_Load(object sender, EventArgs e)
        {
            btnNuevo.PerformClick();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            bancoLbl.Text = "Banco";
            numeroCuentaLbl.Text = "Nº Cuenta";
            nombreLbl.Text = "Nombre";
            balanceLbl.Text = "$ 0.00";
            tipoTransaccionCbo.SelectedIndex = 0;
            montoTxt.Text = "";
            detalleTxt.Text = "";

            btnModificar.Enabled = false;
            btnSalvar.Enabled = true;
            btnBuscar.Enabled = true;
        }

        private void cuentaLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBuscarBancosCuentas frm = new FrmBuscarBancosCuentas();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //idCuentaLbl.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                //idBancoTxt.Text = frm.dgvListar.SelectedCells[1].Value.ToString();
                bancoLbl.Text = frm.dgvListar.SelectedCells[2].Value.ToString();
                nombreLbl.Text = frm.dgvListar.SelectedCells[3].Value.ToString();
                numeroCuentaLbl.Text = frm.dgvListar.SelectedCells[4].Value.ToString();
            }
        }
    }
}
