using Negocios.NReportes;
using System;
using System.Windows.Forms;

namespace APP.Reportes
{
    public partial class rptFacturaServicio : Form
    {
        private readonly string IdFactura;

        public rptFacturaServicio(string idFactura)
        {
            InitializeComponent();
            IdFactura = idFactura;
        }

        private void rptFacturaServicio_Load(object sender, EventArgs e)
        {
            NrptEmpresa nEmpresa = new NrptEmpresa();
            NrptFacturaServicio nfactura = new NrptFacturaServicio();
            nEmpresa.LlenaEmpresa();
            nfactura.Facturas(IdFactura);
            erptEmpresaBindingSource.DataSource = nEmpresa.Empresa;
            erptFacturaServicioBindingSource.DataSource = nfactura.Factura;
            erptFacturaServicioDetalleBindingSource.DataSource = nfactura.Detalle;
            reportViewer1.RefreshReport();
        }
    }
}
