using Negocios;
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
    public partial class rptCxp_estadoCuenta : Form
    {
        public rptCxp_estadoCuenta()
        {
            InitializeComponent();
        }

        private void rptCxp_estadoCuenta_Load(object sender, EventArgs e)
        {
            NReciboPago nRecibo = new NReciboPago();
            NrptEmpresa nEmpresa = new NrptEmpresa();
            nEmpresa.LlenaEmpresa();
            nRecibo.ReporteEstadoCuenta();
            erptEmpresaBindingSource.DataSource = nEmpresa.Empresa;
            erptCxcBindingSource.DataSource = nRecibo.EstadoCuenta;
            reportViewer1.RefreshReport();
        }
    }
}
