using Datos;
using Entidades.EReportes;
using System;
using System.Collections.Generic;
using System.Data;

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
        public List<ErptCuadreCaja> Cuadre { get; private set; }

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
            decimal count = 0m;
            foreach (DataRow row in data.Rows)
            {
                count += (decimal)row[2];
            }
            TotalReciboIngreso = count;

            query = string.Format(@"SELECT total_factura FROM Factura
                                    WHERE fecha_factura BETWEEN '{0}' AND '{1}'
                                    AND tipoCompra_factura = 'CONTADO'", Desde, Hasta);
            data = _factura.Buscar(query);
            CantidadFacturas = data.Rows.Count;
            count = 0m;
            foreach (DataRow row in data.Rows)
            {
                count += (decimal)row[0];
            }
            TotalVentasContado = count;

            query = string.Format(@"SELECT total_devolucion FROM FacturaDevolucion
                                    WHERE fecha_devolucion BETWEEN '{0}' AND '{1}' AND tipo_devolucion = 'CONTADO'", Desde, Hasta);
            data = _factura.Buscar(query);
            CantidadDevoluciones = data.Rows.Count;
            count = 0m;
            foreach (DataRow row in data.Rows)
            {
                count += (decimal)row[0];
            }
            TotalDevoluciones = count * -1;

            TotalTotal = TotalReciboIngreso + TotalVentasContado + TotalDevoluciones;

            Cuadre = new List<ErptCuadreCaja>();
            ErptCuadreCaja cuadreModel = new ErptCuadreCaja()
            {
                TotalRecibo = TotalReciboIngreso,
                TotalVentaContado = TotalVentasContado,
                TotalDevolicion = TotalDevoluciones,
                TotalTotal = TotalTotal,
                Desde = Desde,
                Hasta = Hasta
            };
            Cuadre.Add(cuadreModel);
        }

        private void GetTopProducts()
        {
            DFacturacion _factura = new DFacturacion();
            TopProducList = new List<KeyValuePair<string, decimal>>();

            string query = string.Format(@"SELECT TOP 15 A.nombre_articulo, SUM(FD.cantidad_factura) AS Cantidad
                                           FROM Factura F LEFT JOIN FacturaDetalle FD ON F.id_factura = FD.id_factura
                                           LEFT JOIN Articulo A ON FD.id_articulo = A.id_articulo
                                           WHERE F.fecha_factura BETWEEN '{0}' AND '{1}'
                                           GROUP BY A.nombre_articulo ORDER BY Cantidad DESC", Desde, Hasta);
            Console.WriteLine(query);
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

            string query = string.Format(@"SELECT SUM(FD.importe_factura - (FD.importe_factura * FD.descuento_factura / 100)) AS Precio, SUM(FD.costo_factura * FD.cantidad_factura) AS Costo FROM Factura F LEFT JOIN FacturaDetalle FD ON F.id_factura = FD.id_factura
                                           WHERE F.fecha_factura BETWEEN '{0}' AND '{1}'", Desde, Hasta);
            DataTable data = _factura.Buscar(query);
            decimal venta = 0m;
            if (decimal.TryParse(data.Rows[0][0].ToString(), out _))
            {
                 venta = Convert.ToDecimal(data.Rows[0][0]);
            }
            decimal costo = 0m;
            if (decimal.TryParse(data.Rows[0][1].ToString(), out _))
            {
                costo = Convert.ToDecimal(data.Rows[0][1]);
            }
            string query_dev = string.Format(@"SELECT SUM(DD.totalImporte_devolucion) AS IMPORTE, SUM(DD.costo_devolucion * DD.cantidad_devolucion) AS COSTO FROM FacturaDevolucion D
                                               LEFT JOIN FacturaDevolucionDetalle DD ON D.id_devolucion = DD.id_devolucion
                                               WHERE D.fecha_devolucion BETWEEN '{0}' AND '{1}'", Desde.Date, Hasta.Date);
            DataTable data_dev = _factura.Buscar(query_dev);
            if (decimal.TryParse(data_dev.Rows[0][0].ToString(), out _))
            {
                venta -= Convert.ToDecimal(data_dev.Rows[0][0]);
            }
            if (decimal.TryParse(data_dev.Rows[0][1].ToString(), out _))
            {
                costo -= Convert.ToDecimal(data_dev.Rows[0][1]);
            }
            decimal ganancia = venta - costo;
            ReporteGanancias.Add(new KeyValuePair<string, decimal>("Venta", (decimal)venta));
            ReporteGanancias.Add(new KeyValuePair<string, decimal>("Costo", (decimal)costo));
            ReporteGanancias.Add(new KeyValuePair<string, decimal>("Ganancia", (decimal)ganancia));
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
