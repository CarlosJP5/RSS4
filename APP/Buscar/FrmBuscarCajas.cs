using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP.Buscar
{
    public partial class FrmBuscarCajas : Form
    {
        public FrmBuscarCajas()
        {
            InitializeComponent();
        }

        private void FrmBuscarCajas_Load(object sender, EventArgs e)
        {
            cboEstado.SelectedIndex = 0;
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today.AddHours(23.99999);
        }
    }
}
