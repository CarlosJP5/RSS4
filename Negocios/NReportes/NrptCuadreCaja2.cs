using Datos.DReportes;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Negocios.NReportes
{
    public class NrptCuadreCaja2
    {
        DrptFactura dReportes = new DrptFactura();

        public DateTime reportDate { get; private set; }
        public DateTime startDate { get; private set; }
        public DateTime endDate { get; private set; }
        public List<EFactura> salesListing { get; private set; }
        public List<EVentasNetas> netSalesByPeriod { get; private set; }
        public double totalVenta { get; private set; } = 0;
        public double totalCosto { get; private set; } = 0;
        public double totalGanancia { get; private set; } = 0;
        public double devolucionTotalVenta { get; private set; } = 0;
        public double devolucionTotalCosto { get; private set; } = 0;
        public double devolucionTotalGanancia { get; private set; } = 0;
        public double reciboPago { get; private set; } = 0;
        public double reciboCosto { get; private set; } = 0;
        public double reciboGanancia { get; private set; } = 0;

        public void createSalesOrderReport(DateTime fromDate, DateTime toDate)
        {
            reportDate = DateTime.Now;
            startDate = fromDate;
            endDate = toDate;

            DataTable ventasDatos = dReportes.ReporteVentas(startDate, endDate);
            DataTable reciboIngresoDatos = dReportes.ReporteVentasReciboIngreso(startDate, endDate);
            DataTable devolucionDatos = dReportes.ReporteVentasDevoluciones(startDate, endDate);

            salesListing = new List<EFactura>();
            foreach (DataRow row in ventasDatos.Rows)
            {
                EFactura facturaModel = new EFactura()
                {
                    IdFactura = Convert.ToInt32(row[0]),
                    Fecha = Convert.ToDateTime(row[1]),
                    Nota = row[2].ToString(),
                    Total = Convert.ToDecimal(row[3]),
                    IdComprobante = row[5].ToString(),
                };
                salesListing.Add(facturaModel);
                totalVenta += Convert.ToDouble(row[3]);
                totalCosto += Convert.ToDouble(row[4]);
            }
            totalGanancia = totalVenta - totalCosto;

            foreach (DataRow rowRecibo in reciboIngresoDatos.Rows)
            {
                reciboPago += Convert.ToDouble(rowRecibo[0]);
                reciboCosto += Convert.ToDouble(rowRecibo[1]);
                reciboGanancia += Convert.ToDouble(rowRecibo[2]);
            }

            if (devolucionDatos.Rows.Count > 0)
            {
                if (double.TryParse(devolucionDatos.Rows[0][0].ToString(), out _))
                {
                    devolucionTotalVenta = Convert.ToDouble(devolucionDatos.Rows[0][0]);
                }

                if (double.TryParse(devolucionDatos.Rows[0][1].ToString(), out _))
                {
                    devolucionTotalCosto = Convert.ToDouble(devolucionDatos.Rows[0][1]);
                }
            }
            devolucionTotalGanancia = devolucionTotalVenta - devolucionTotalCosto;

            //create net sales by period
            var listSalesByDate = (from sales in salesListing
                                   group sales by sales.Fecha
                                   into listSales
                                   select new
                                   {
                                       date = listSales.Key,
                                       amount = listSales.Sum(item => item.Total)
                                   }).AsEnumerable();
            //Get Number of days
            int totalDays = Convert.ToInt32((toDate - fromDate).Days);
            //Group by Days
            if (totalDays <= 7)
            {
                netSalesByPeriod = (from sales in listSalesByDate
                                    group sales by sales.date.ToString("dd/MM/yyyy")
                                    into listSales
                                    select new EVentasNetas
                                    {
                                        Periodo = listSales.Key,
                                        VentaNeta = listSales.Sum(item => item.amount)
                                    }).ToList();
            }
            //Group by Weeks
            else if (totalDays <= 31)
            {
                netSalesByPeriod = (from sales in listSalesByDate
                                    group sales by
                                    System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                                        sales.date, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                                    into listSales
                                    select new EVentasNetas
                                    {
                                        Periodo = "Semana " + listSales.Key.ToString(),
                                        VentaNeta = listSales.Sum(item => item.amount)
                                    }).ToList();
            }
            //Group by Months
            else if (totalDays <= 365)
            {
                netSalesByPeriod = (from sales in listSalesByDate
                                    group sales by sales.date.ToString("MM/yyyy")
                                    into listSales
                                    select new EVentasNetas
                                    {
                                        Periodo = listSales.Key,
                                        VentaNeta = listSales.Sum(item => item.amount)
                                    }).ToList();
            }
            else
            {
                netSalesByPeriod = (from sales in listSalesByDate
                                    group sales by sales.date.ToString("yyyy")
                                    into listSales
                                    select new EVentasNetas
                                    {
                                        Periodo = listSales.Key,
                                        VentaNeta = listSales.Sum(item => item.amount)
                                    }).ToList();
            }
        }
    }
}
