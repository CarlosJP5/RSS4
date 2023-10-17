using Datos.DReportes;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public double totalVenta { get; private set; }
        public double totalCosto { get; private set; }
        public double totalGanancia { get; private set; }

        public void createSalesOrderReport(DateTime fromDate, DateTime toDate)
        {
            reportDate = DateTime.Now;
            startDate = fromDate;
            endDate = toDate;

            DataTable ventasDatos = dReportes.ReporteVentas(startDate, endDate);

            salesListing = new List<EFactura>();
            foreach (DataRow row in ventasDatos.Rows)
            {
                EFactura facturaModel = new EFactura()
                {
                    IdFactura = Convert.ToInt32(row[0]),
                    Fecha = Convert.ToDateTime(row[1]),
                    Nota = row[2].ToString(),
                    Total = Convert.ToDecimal(row[3]),
                };
                salesListing.Add(facturaModel);
                totalVenta += Convert.ToDouble(row[3]);
                totalCosto += Convert.ToDouble(row[4]);
            }
            totalGanancia = totalVenta - totalCosto;
        }
    }
}
