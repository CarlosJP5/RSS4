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
    public partial class rptListaCompra : Form
    {
        private readonly DataTable Detalle;
        public rptListaCompra(DataTable detalle)
        {
            InitializeComponent();
            Detalle = detalle;
        }

        private void rptListaCompra_Load(object sender, EventArgs e)
        {
            NrptEmpresa nEmpresa = new NrptEmpresa();
            NrptListaCompra nListaCompra = new NrptListaCompra();
            nEmpresa.LlenaEmpresa();
            nListaCompra.Lista(Detalle);
            erptEmpresaBindingSource.DataSource = nEmpresa.Empresa;
            erptFacturaDetalleBindingSource.DataSource = nListaCompra.FacturaDetalles;
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Print(object sender, Microsoft.Reporting.WinForms.ReportPrintEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void reportViewer1_ReportExport(object sender, Microsoft.Reporting.WinForms.ReportExportEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
