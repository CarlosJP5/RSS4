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
    public partial class rptCotizacion : Form
    {
        private readonly string IdCotizacion;

        public rptCotizacion(string IdCotizacion)
        {
            InitializeComponent();
            this.IdCotizacion = IdCotizacion;
        }

        private void rptCotizacion_Load(object sender, EventArgs e)
        {
            NrptEmpresa nEmpresa = new NrptEmpresa();
            NrptCotizacion nCotizacion = new NrptCotizacion();
            nEmpresa.LlenaEmpresa();
            nCotizacion.Cotizacion_rpt(IdCotizacion);
            erptEmpresaBindingSource.DataSource = nEmpresa.Empresa;
            erptCotizacionBindingSource.DataSource = nCotizacion.Cotizacion;
            erptCotizacionDetalleBindingSource.DataSource = nCotizacion.CotizacionDetalles;
            this.reportViewer1.RefreshReport();
        }
    }
}
