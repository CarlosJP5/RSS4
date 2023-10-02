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
            numeroCuentaLbl.Text = "";
            nombreLbl.Text = "";
            balanceLbl.Text = "";
            tipoTransaccionCbo.SelectedIndex = 0;
            montoTxt.Text = "";
            detalleTxt.Text = "";

            btnModificar.Enabled = false;
            btnSalvar.Enabled = true;
            btnBuscar.Enabled = true;
        }
    }
}
