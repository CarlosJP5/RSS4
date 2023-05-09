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
    public partial class FrmBuscarFacturaAutomatica : Form
    {
        public FrmBuscarFacturaAutomatica()
        {
            InitializeComponent();
        }

        private readonly NServicio nservicio = new NServicio();

        private void FrmBuscarFacturaAutomatica_Load(object sender, EventArgs e)
        {
            DataTable ListadeFacturar = nservicio.ListarAutomatica();
            foreach (DataRow dataRow in ListadeFacturar.Rows)
            {
                DateTime fecha = DateTime.Parse(dataRow[2].ToString());
                _ = dgvListar.Rows.Add(dataRow[0], dataRow[1], dataRow[5], dataRow[3], dataRow[4], fecha.ToString("dd/MM/yyyy"));
            }
        }
    }
}
