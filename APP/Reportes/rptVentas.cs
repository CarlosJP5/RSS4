using Negocios.NReportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP.Reportes
{
    public partial class rptVentas : Form
    {
        public rptVentas()
        {
            InitializeComponent();
        }

        private readonly NrptEmpresa nEmpresa = new NrptEmpresa();
        private readonly NrptVentas nrptVentas = new NrptVentas();

        private void rptVentas_Load(object sender, EventArgs e)
        {
            desdeDtp.Value = DateTime.Today;
            hastaDtp.Value = DateTime.Today.AddHours(23.99999);
            //this.reportViewer1.RefreshReport();
        }

        private void buscarBtn_Click(object sender, EventArgs e)
        {
            _ = nEmpresa.LlenaEmpresa();
            nrptVentas.GetVentas(desdeDtp.Value, hastaDtp.Value);
            erptEmpresaBindingSource.DataSource = nEmpresa.Empresa;
            nrptVentasBindingSource.DataSource = nrptVentas;
            contadoVentasBindingSource.DataSource = nrptVentas.ContadoVentas;
            creditoVentasBindingSource.DataSource = nrptVentas.CreditoVentas;
            devolucionVentasBindingSource.DataSource = nrptVentas.DevolucionVentas;
            reportViewer1.RefreshReport();
        }
    }
}
