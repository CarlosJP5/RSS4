using APP.Reportes;
using Microsoft.Reporting.WinForms;
using Negocios.NReportes;
using System;
using System.Windows.Forms;

namespace APP
{
    public partial class FrmCuadreCaja : Form
    {
        private NrptCuadreCaja _reporte;

        public FrmCuadreCaja()
        {
            InitializeComponent();
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today.AddHours(23.99999);
            btnHoy.Select();
            _reporte = new NrptCuadreCaja();
            CargarDatos(dtpDesde.Value, dtpHasta.Value);
        }

        private void CargarDatos(DateTime Desde, DateTime Hasta)
        {
            _reporte.LlenarDatos(Desde, Hasta);
            lblReciboIngreso.Text = "$" + _reporte.TotalReciboIngreso.ToString("N2");
            lblVentasContado.Text = "$" + _reporte.TotalVentasContado.ToString("N2");
            lblDevoluciones.Text = "$" + _reporte.TotalDevoluciones.ToString("N2");
            lblTotalIngresos.Text = "$" + _reporte.TotalTotal.ToString("N2");
            lblCantidadRecibos.Text = _reporte.CantidadRecibos.ToString("N0");
            lblCantidadFacturas.Text = _reporte.CantidadFacturas.ToString("N0");
            lblCantidadDevoluciones.Text = _reporte.CantidadDevoluciones.ToString("N0");

            chartGanancias.DataSource = _reporte.ReporteGanancias;
            chartGanancias.Series[0].XValueMember = "Key";
            chartGanancias.Series[0].YValueMembers = "Value";
            chartGanancias.DataBind();

            chartTop15.DataSource = _reporte.TopProducList;
            chartTop15.Series[0].XValueMember = "Key";
            chartTop15.Series[0].YValueMembers = "Value";
            chartTop15.DataBind();
        }

        private void FrmCuadreCaja_Load(object sender, EventArgs e)
        {
            
        }

        private void btnPersonalizada_Click(object sender, EventArgs e)
        {
            CargarDatos(dtpDesde.Value, dtpHasta.Value);
        }

        private void btnHoy_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today.AddHours(23.99999);
            CargarDatos(dtpDesde.Value, dtpHasta.Value);
        }

        private void btn7Dias_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today.AddDays(-7);
            dtpHasta.Value = DateTime.Today.AddHours(23.99999);
            CargarDatos(dtpDesde.Value, dtpHasta.Value);
        }

        private void btnMes_Click(object sender, EventArgs e)
        {
            double dias = Convert.ToDouble(DateTime.Today.Day.ToString("d")) - 1;
            dtpDesde.Value = DateTime.Today.AddDays(-dias);
            dtpHasta.Value = DateTime.Today.AddHours(23.99999);
            CargarDatos(dtpDesde.Value, dtpHasta.Value);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //using (LocalReport localReport = new LocalReport())
            //{
            //    NrptEmpresa nEmpresa = new NrptEmpresa();
            //    NrptFactura nFactura = new NrptFactura();
            //    nEmpresa.LlenaEmpresa();
            //    localReport.ReportPath = Application.StartupPath + @"\Reportes\rptCuadreCaja.rdlc";
            //    localReport.DataSources.Clear();
            //    localReport.DataSources.Add(new ReportDataSource("dsEmpresa", nEmpresa.Empresa));
            //    localReport.DataSources.Add(new ReportDataSource("dsCaja", _reporte.Cuadre));
            //    localReport.PrintToPrinter();
            //}
            rptCuadreCaja2 reporteCuadre = new rptCuadreCaja2(dtpDesde.Value, dtpHasta.Value);
            reporteCuadre.ShowDialog();
        }
    }
}
