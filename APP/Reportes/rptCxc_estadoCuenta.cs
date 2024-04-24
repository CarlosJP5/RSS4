using Negocios;
using Negocios.NReportes;
using System;
using System.Windows.Forms;

namespace APP.Reportes
{
    public partial class rptCxc_estadoCuenta : Form
    {
        public rptCxc_estadoCuenta()
        {
            InitializeComponent();
        }

        private void rptCxc_estadoCuenta_Load(object sender, EventArgs e)
        {
            NrptEmpresa nEmpresa = new NrptEmpresa();
            NReciboIngreso nReciboIngreso = new NReciboIngreso();
            nEmpresa.LlenaEmpresa();
            nReciboIngreso.ReporteEstadoCuenta();
            erptEmpresaBindingSource.DataSource = nEmpresa.Empresa;
            erptCxcBindingSource.DataSource = nReciboIngreso.EstadoCuenta;
            this.reportViewer1.RefreshReport();
        }
    }
}
