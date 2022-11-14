using Negocios.NReportes;
using System;
using System.Windows.Forms;

namespace APP.Reportes
{
    public partial class rtpCotizacionServicio : Form
    {
        private readonly string IdFactura;

        public rtpCotizacionServicio(string idFactura)
        {
            InitializeComponent();
            IdFactura = idFactura;
        }

        private void rtpCotizacionServicio_Load(object sender, EventArgs e)
        {
            NrptEmpresa nEmpresa = new NrptEmpresa();
            NrptCotizacionServicio nfactura = new NrptCotizacionServicio();
            nEmpresa.LlenaEmpresa();
            nfactura.Facturas(IdFactura);
            erptEmpresaBindingSource.DataSource = nEmpresa.Empresa;
            erptFacturaServicioBindingSource.DataSource = nfactura.Factura;
            erptFacturaServicioDetalleBindingSource.DataSource = nfactura.Detalle;
            this.reportViewer1.RefreshReport();
        }
    }
}
