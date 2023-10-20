using Negocios.NReportes;
using System;
using System.Windows.Forms;

namespace APP
{
    public partial class FrmCuadreCaja2 : Form
    {
        public FrmCuadreCaja2()
        {
            InitializeComponent();
        }

        private void FrmCuadreCaja2_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today.AddHours(23.999999);
            createSalesOrderReport(dtpDesde.Value, dtpHasta.Value);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            createSalesOrderReport(dtpDesde.Value, dtpHasta.Value);
        }

        private void createSalesOrderReport(DateTime fromDate, DateTime toDate)
        {
            NrptEmpresa nEmpresa = new NrptEmpresa();
            nEmpresa.LlenaEmpresa();

            NrptCuadreCaja2 cuadreCaja2 = new NrptCuadreCaja2();
            cuadreCaja2.createSalesOrderReport(fromDate, toDate);

            erptEmpresaBindingSource.DataSource = nEmpresa.Empresa;
            nrptCuadreCaja2BindingSource.DataSource = cuadreCaja2;
            eFacturaBindingSource.DataSource = cuadreCaja2.salesListing;
            eVentasNetasBindingSource.DataSource = cuadreCaja2.netSalesByPeriod;
            this.reportViewer1.RefreshReport();
        }
    }
}
