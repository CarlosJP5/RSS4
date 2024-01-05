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
    public partial class rptCuadreCaja2 : Form
    {
        private DateTime desde;
        private DateTime hasta;
        public rptCuadreCaja2(DateTime desde, DateTime hasta)
        {
            InitializeComponent();
            this.desde = desde;
            this.hasta = hasta;
        }

        private void rptCuadreCaja2_Load(object sender, EventArgs e)
        {
            createSalesOrderReport();
        }

        private void createSalesOrderReport()
        {
            NrptEmpresa nEmpresa = new NrptEmpresa();
            nEmpresa.LlenaEmpresa();
            NrptCuadreCaja2 cuadre = new NrptCuadreCaja2();
            cuadre.createSalesOrderReport(desde, hasta);
            erptEmpresaBindingSource.DataSource = nEmpresa.Empresa;
            nrptCuadreCaja2BindingSource.DataSource = cuadre;
            erptFacturaDetalleBindingSource.DataSource = cuadre.listaFacturas;
            this.reportViewer1.RefreshReport();
        }
    }
}
