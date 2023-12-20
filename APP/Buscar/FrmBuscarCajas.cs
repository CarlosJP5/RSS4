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
    public partial class FrmBuscarCajas : Form
    {
        public FrmBuscarCajas()
        {
            InitializeComponent();
        }

        private readonly NFacturacion cajaN = new NFacturacion();

        private void FrmBuscarCajas_Load(object sender, EventArgs e)
        {
            cboEstado.SelectedIndex = 0;
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today.AddHours(23.99999);
            btnBuscar.PerformClick();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listarDgv.Rows.Clear();
            string query = string.Format(@"select id_caja, apertura_caja, apertura_nombre,
                                           total_caja, estado_caja from Caja 
                                           where apertura_caja between '{0}' and '{1}'",
                                           dtpDesde.Value, dtpHasta.Value);
            if (cboEstado.SelectedIndex == 1)
            {
                query += " and estado_caja = 'abierta'";
            }
            else if (cboEstado.SelectedIndex == 2)
            {
                query += " and estado_caja = 'cerrada'";
            }
            query += " order by id_caja desc";
            DataTable cajaData = cajaN.Buscar(query);
            foreach (DataRow row in cajaData.Rows)
            {
                DateTime fecha = DateTime.Parse(row[1].ToString());
                listarDgv.Rows.Add(row[0], fecha.ToString("dd/MM/yyy hh:mm tt"), row[2], row[3], row[4]);
            }
        }
    }
}
