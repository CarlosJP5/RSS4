using Negocios.NReportes;
using System;
using System.Windows.Forms;

namespace APP.Reportes
{
    public partial class rptFactura : Form
    {
        private readonly string IdFactura;
        
        public rptFactura(string IdFactura)
        {
            InitializeComponent();
            this.IdFactura = IdFactura;
        }

        private void rptFactura_Load(object sender, EventArgs e)
        {
            NrptEmpresa nEmpresa = new NrptEmpresa();
            NrptFactura nFactura = new NrptFactura();
            _ = nEmpresa.LlenaEmpresa();
            nFactura.Facturas(IdFactura);
            erptEmpresaBindingSource.DataSource = nEmpresa.Empresa;
            erptFacturaBindingSource.DataSource = nFactura.Factura;
            erptFacturaDetalleBindingSource.DataSource = nFactura.FacturaDetalles;
            reportViewer1.RefreshReport();
        }

        private void reportViewer1_Print(object sender, Microsoft.Reporting.WinForms.ReportPrintEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
