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
    public partial class FrmBuscarGastoRegistro : Form
    {
        public FrmBuscarGastoRegistro()
        {
            InitializeComponent();
        }

        private readonly NGasto nGasto = new NGasto();

        private void FrmBuscarGastoRegistro_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today.AddHours(23.99999);
            DataTable dt = nGasto.BuscarDetalle(dtpDesde.Value, dtpHasta.Value);
            foreach (DataRow dr in dt.Rows)
            {
                _ = listarDgv.Rows.Add(dr[0], dr[3], dr[2], dr[5], dr[4], dr[1]);
            }
        }
    }
}
