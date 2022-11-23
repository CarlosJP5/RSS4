using Negocios.NReportes;
using System;
using System.Windows.Forms;

namespace APP.Reportes
{
    public partial class rptFacturaA4 : Form
    {
        private readonly string IdFactura;

        public rptFacturaA4(string idFactura)
        {
            InitializeComponent();
            IdFactura = idFactura;
        }

        private void rptFacturaA4_Load(object sender, EventArgs e)
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
    }
}
