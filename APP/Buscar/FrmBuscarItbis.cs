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

namespace APP.Buscar
{
    public partial class FrmBuscarItbis : Form
    {
        public FrmBuscarItbis()
        {
            InitializeComponent();
        }

        private readonly NItbis _itbis = new NItbis();

        private void FrmBuscarItbis_Load(object sender, EventArgs e)
        {
            rbtnPorciento.Checked = true;
            DataTable itbis = _itbis.Listar();
            foreach (DataRow dr in itbis.Rows)
            {
                _ = dgvListar.Rows.Add(dr[0], dr[1], dr[2]);
            }
        }
    }
}
