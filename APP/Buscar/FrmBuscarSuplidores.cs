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
    public partial class FrmBuscarSuplidores : Form
    {
        public FrmBuscarSuplidores()
        {
            InitializeComponent();
        }

        private readonly NSuplidores _suplidores = new NSuplidores();

        private void FrmBuscarSuplidores_Load(object sender, EventArgs e)
        {
            rbtnTodo.Checked = true;
            DataTable suplidor = _suplidores.Listar();
            foreach (DataRow suplidorRow in suplidor.Rows)
            {
                dgvListar.Rows.Add(suplidorRow[0], suplidorRow[2], suplidorRow[1],
                    suplidorRow[6], suplidorRow[4], suplidorRow[7]);
            }
        }
    }
}
