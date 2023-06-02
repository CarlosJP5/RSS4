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
    public partial class rptArticulosReporteCosto : Form
    {
        private string Query;

        public rptArticulosReporteCosto(string query)
        {
            InitializeComponent();
            Query = query;
        }

        private void rptArticulosReporteCosto_Load(object sender, EventArgs e)
        {
            NrptEmpresa nEmpresa = new NrptEmpresa();
            nEmpresa.LlenaEmpresa();
            nEmpresa.ArticulosReporte(Query);
            erptEmpresaBindingSource.DataSource = nEmpresa.Empresa;
            erptFacturaDetalleBindingSource.DataSource = nEmpresa.ArticuloLista;
            this.reportViewer1.RefreshReport();
        }
    }
}
