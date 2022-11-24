using Negocios.NReportes;
using System;
using System.Windows.Forms;

namespace APP.Reportes
{
    public partial class rtpCotizacionServicioA4 : Form
    {
        private readonly string IdFactura;

        public rtpCotizacionServicioA4(string idFactura)
        {
            InitializeComponent();
            IdFactura = idFactura;
        }

        private void rtpCotizacionServicioA4_Load(object sender, EventArgs e)
        {
            NrptEmpresa nEmpresa = new NrptEmpresa();
            NrptCotizacionServicio nfactura = new NrptCotizacionServicio();
            nEmpresa.LlenaEmpresa();
            nfactura.Facturas(IdFactura);
            erptEmpresaBindingSource.DataSource = nEmpresa.Empresa;
            erptFacturaServicioBindingSource.DataSource = nfactura.Factura;
            erptFacturaServicioDetalleBindingSource.DataSource = nfactura.Detalle;
            reportViewer1.RefreshReport();
        }
    }
}
