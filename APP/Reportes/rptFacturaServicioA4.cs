using Negocios.NReportes;
using System;
using System.Windows.Forms;

namespace APP.Reportes
{
    public partial class rptFacturaServicioA4 : Form
    {
        private readonly string IdFactura;

        public rptFacturaServicioA4(string idFactura)
        {
            InitializeComponent();
            IdFactura = idFactura;
        }

        private void rptFacturaServicioA4_Load(object sender, EventArgs e)
        {
            NrptEmpresa nEmpresa = new NrptEmpresa();
            NrptFacturaServicio nfactura = new NrptFacturaServicio();
            nEmpresa.LlenaEmpresa();
            nfactura.Facturas(IdFactura);
            erptEmpresaBindingSource.DataSource = nEmpresa.Empresa;
            erptFacturaServicioBindingSource.DataSource = nfactura.Factura;
            erptFacturaServicioDetalleBindingSource.DataSource = nfactura.Detalle;
            reportViewer1.PrinterSettings.DefaultPageSettings.Landscape = false;
            reportViewer1.RefreshReport();
        }

        private void reportViewer1_Print(object sender, Microsoft.Reporting.WinForms.ReportPrintEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
