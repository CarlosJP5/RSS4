using Negocios.NReportes;
using System;
using System.Windows.Forms;

namespace APP.Reportes
{
    public partial class rptCuadreCaja2 : Form
    {
        private DateTime Desde;
        private DateTime Hasta;
        private int idCaja = 0;

        public rptCuadreCaja2(DateTime desde, DateTime hasta)
        {
            InitializeComponent();
            Desde = desde;
            Hasta = hasta;
        }

        public rptCuadreCaja2(int idcaja)
        {
            InitializeComponent();
            idCaja = idcaja;
        }

        private void rptCuadreCaja2_Load(object sender, EventArgs e)
        {
            if (idCaja == 0)
            {
                createSalesOrderReport();
            }
            else
            {
                NrptEmpresa nEmpresa = new NrptEmpresa();
                nEmpresa.LlenaEmpresa();
                NrptCuadreCaja2 cuadre = new NrptCuadreCaja2();
                cuadre.createSalesOrderReport(idCaja);
                erptEmpresaBindingSource.DataSource = nEmpresa.Empresa;
                nrptCuadreCaja2BindingSource.DataSource = cuadre;
                erptFacturaDetalleBindingSource.DataSource = cuadre.listaFacturas;
                this.reportViewer1.RefreshReport();
            }
        }

        private void createSalesOrderReport()
        {
            NrptEmpresa nEmpresa = new NrptEmpresa();
            nEmpresa.LlenaEmpresa();
            NrptCuadreCaja2 cuadre = new NrptCuadreCaja2();
            cuadre.createSalesOrderReport(Desde, Hasta);
            erptEmpresaBindingSource.DataSource = nEmpresa.Empresa;
            nrptCuadreCaja2BindingSource.DataSource = cuadre;
            erptFacturaDetalleBindingSource.DataSource = cuadre.listaFacturas;
            this.reportViewer1.RefreshReport();
        }
    }
}
