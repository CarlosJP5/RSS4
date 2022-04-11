using APP.Coneccion;
using Entidades;
using Negocios.NClasses;
using System;
using System.Windows.Forms;

namespace APP
{
    public partial class zPrincipal : Form
    {
        public zPrincipal()
        {
            InitializeComponent();
            NAppSetting setting = new NAppSetting();
            zConexion.CadenaConexion = setting.GetConnectionString("cn");
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConexion frm = new FrmConexion();
            frm.MdiParent = this;
            frm.Show();
        }

        private void zPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmArticulosMarcas frm = new FrmArticulosMarcas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void itbisDelArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmArticulosItbis frm = new FrmArticulosItbis();
            frm.MdiParent = this;
            frm.Show();
        }

        private void suplidoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSuplidores frm = new FrmSuplidores();
            frm.MdiParent= this;
            frm.Show();
        }
    }
}
