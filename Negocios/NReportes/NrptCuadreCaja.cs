using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.NReportes
{
    public class NrptCuadreCaja
    {
        private DateTime Desde;
        private DateTime Hasta;

        public decimal TotalReciboIngreso { get; private set; } = 0m;
        public decimal TotalVentasContado { get; private set; } = 0m;
        public decimal TotalDevoluciones { get; private set; } = 0m;
        public decimal TotalTotal { get; private set; } = 0m;
        public List<KeyValuePair<string,decimal>> TopProducList { get; private set; }
        public List<KeyValuePair<string, decimal>> ReporteGanancias { get; private set; }
        public int CantidadRecibos { get; private set; } = 0;
        public int CantidadFacturas { get; private set; } = 0;
        public int CantidadDevoluciones { get; private set; } = 0;

        //Constructor
        public NrptCuadreCaja()
        {

        }

        //Metodos Privados
        private void GetCantidades()
        {
            DFacturacion _factura = new DFacturacion();

            string query = string.Format(@"SELECT id_ri, fecha_ri, SUM(pago_ri) as Pago  FROM ReciboIngreso
                                            WHERE fecha_ri BETWEEN '{0}' AND '{1}'
                                            GROUP BY id_ri, fecha_ri", Desde, Hasta);
            DataTable data = _factura.Buscar(query);
            CantidadRecibos = data.Rows.Count;
            foreach (DataRow row in data.Rows)
            {
                TotalReciboIngreso += (decimal)row[2];
            }

            query = string.Format(@"SELECT total_factura FROM Factura
                                    WHERE fecha_factura BETWEEN '{0}' AND '{1}'
                                    AND tipoCompra_factura = 'CONTADO'", Desde, Hasta);
            data = _factura.Buscar(query);
            CantidadFacturas = data.Rows.Count;
            foreach (DataRow row in data.Rows)
            {
                TotalVentasContado += (decimal)row[0];
            }

            query = string.Format(@"SELECT total_devolucion FROM FacturaDevolucion
                                    WHERE fecha_devolucion BETWEEN '{0}' AND '{1}'", Desde, Hasta);
            data = _factura.Buscar(query);
            CantidadDevoluciones = data.Rows.Count;
            foreach (DataRow row in data.Rows)
            {
                TotalDevoluciones += (decimal)row[0];
            }

            TotalTotal = TotalReciboIngreso + TotalVentasContado - TotalDevoluciones;
        }

        private void GetTopProducts()
        {
            DFacturacion _factura = new DFacturacion();
            TopProducList = new List<KeyValuePair<string, decimal>>();

            string query = string.Format(@"SELECT TOP 5 A.nombre_articulo, SUM(FD.cantidad_factura) AS Cantidad
                                           FROM Factura F LEFT JOIN FacturaDetalle FD ON F.id_factura = FD.id_factura
                                           LEFT JOIN Articulo A ON FD.id_articulo = A.id_articulo
                                           WHERE F.fecha_factura BETWEEN '{0}' AND '{1}'
                                           GROUP BY A.nombre_articulo ORDER BY Cantidad DESC", Desde, Hasta);
            DataTable data = _factura.Buscar(query);
            foreach (DataRow row in data.Rows)
            {
                TopProducList.Add(new KeyValuePair<string, decimal>((string)row[0], (decimal)row[1]));
            }
        }

        private void GetGananciasReporte()
        {
            DFacturacion _factura = new DFacturacion();
            ReporteGanancias = new List<KeyValuePair<string, decimal>>();

            string query = string.Format(@"SELECT SUM(FD.importe_factura - FD.totalDescuento_factura) AS PRECIO,
                                           SUM(FD.costo_factura * FD.cantidad_factura) AS COSTO FROM Factura F 
                                           LEFT JOIN FacturaDetalle FD ON F.id_factura = FD.id_factura
                                           WHERE F.fecha_factura BETWEEN '{0}' AND '{1}'", Desde, Hasta);
            DataTable data = _factura.Buscar(query);
            double venta = Convert.ToDouble(data.Rows[0][0]);
            double costo = Convert.ToDouble(data.Rows[0][1]);
            double ganancia = venta - costo;
            TopProducList.Add(new KeyValuePair<string, decimal>("Venta", (decimal)venta));
            TopProducList.Add(new KeyValuePair<string, decimal>("Costo", (decimal)costo));
            TopProducList.Add(new KeyValuePair<string, decimal>("Ganancia", (decimal)ganancia));
        }

        public void LlenarDatos(DateTime Desde, DateTime Hasta)
        {
            this.Desde = Desde;
            this.Hasta = Hasta;
            GetCantidades();
            GetTopProducts();
            GetGananciasReporte();
        }
    }
}
