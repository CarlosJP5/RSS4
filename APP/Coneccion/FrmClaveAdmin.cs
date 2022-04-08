using System;
using System.Windows.Forms;

namespace APP.Coneccion
{
    public partial class FrmClaveAdmin : Form
    {
        public FrmClaveAdmin()
        {
            InitializeComponent();
        }

        private readonly string pwds = "20200816@pv";

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (pwds == txtClave.Text)
            {
                FrmConexion frm = new FrmConexion();
                frm.Show();
                Close();
            }
        }

        private void FrmClaveAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
