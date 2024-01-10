using Datos;
using Entidades.EReportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Negocios.NReportes
{
    public class NrptCuadreCaja2
    {
        public DateTime reportDate { get; private set; }
        public DateTime startDate { get; private set; }
        public DateTime endDate { get; private set; }
        public List<ErptFacturaCuadreCaja> listaFacturas { get; private set; }
        public double totalVentaContado { get; set; } = 0;
        public double totalVentaCredito { get; set; } = 0;
        public double totalReciboIngreso { get; set; } = 0;
        public double totalDevoluciones { get; set; } = 0;
        public double totalTotal { get; set; } = 0;
        public double venta { get; set; } = 0;
        public double servicio { get; set; } = 0;


        public void createSalesOrderReport(DateTime fromDate, DateTime toDate)
        {
            reportDate = DateTime.Now;
            startDate = fromDate;
            endDate = toDate;

            DFacturacion dFacturacion = new DFacturacion();
            DServicio dServicio = new DServicio();
            DReciboIngreso dRecibo = new DReciboIngreso();

            DataTable facturaData = dFacturacion.Listar(startDate, endDate);
            DataTable servicioData = dServicio.Listar(startDate, endDate);

            listaFacturas = new List<ErptFacturaCuadreCaja>();

            foreach (DataRow row in facturaData.Rows)
            {
                ErptFacturaCuadreCaja facturasModel = new ErptFacturaCuadreCaja()
                {
                    IdFactura = row[0].ToString(),
                    Fecha = DateTime.Parse(row[1].ToString()),
                    NCF = row[2].ToString(),
                    NombreCliente = row[3].ToString(),
                    TotalFactura = Convert.ToDouble(row[4].ToString()),
                    TipoCompra = row[5].ToString()
                };
                listaFacturas.Add(facturasModel);

                if (row[5].ToString() == "CONTADO")
                {
                    venta += Convert.ToDouble(row[4].ToString());
                    totalVentaContado += Convert.ToDouble(row[4].ToString());
                }
                else
                {
                    totalVentaCredito += Convert.ToDouble(row[4].ToString());
                }
            }

            foreach (DataRow row in servicioData.Rows)
            {
                ErptFacturaCuadreCaja facturasModel = new ErptFacturaCuadreCaja()
                {
                    IdFactura = row[0].ToString(),
                    Fecha = DateTime.Parse(row[1].ToString()),
                    NCF = row[2].ToString(),
                    NombreCliente = row[3].ToString(),
                    TotalFactura = Convert.ToDouble(row[4].ToString()),
                    TipoCompra = row[5].ToString()
                };
                listaFacturas.Add(facturasModel);

                if (row[5].ToString() == "CONTADO")
                {
                    servicio += Convert.ToDouble(row[4].ToString());
                    totalVentaContado += Convert.ToDouble(row[4].ToString());
                }
                else
                {
                    totalVentaCredito += Convert.ToDouble(row[4].ToString());
                }
            }

            _ = listaFacturas.OrderBy(k => k.NCF).ToList();

            DataTable reciboIngresoData = dRecibo.Listar(startDate, endDate);
            foreach (DataRow row in reciboIngresoData.Rows)
            {
                totalReciboIngreso += Convert.ToDouble(row[3]);
            }

            DataTable reciboServicioData = dRecibo.ListarServicio(startDate, endDate);
            foreach (DataRow row in reciboServicioData.Rows)
            {
                totalReciboIngreso += Convert.ToDouble(row[3]);
            }

            DataTable devolucionesData = dFacturacion.ListarDevolucion(startDate, endDate);
            foreach (DataRow row in devolucionesData.Rows)
            {
                totalDevoluciones += Convert.ToDouble(row[4]);
            }

            totalTotal = totalVentaContado + totalReciboIngreso - totalDevoluciones;
        }
    }
}
