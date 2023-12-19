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
    public partial class FrmCaja_cierre : Form
    {
        public FrmCaja_cierre()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarCajas frm = new FrmBuscarCajas();
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
