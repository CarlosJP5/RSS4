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
            DataTable devolucionData = dFacturacion.ReporteDevolucion(startDate, endDate);
            DataTable reciboIngresoData = dRecibo.Listar(startDate, endDate);
            DataTable reciboServicioData = dRecibo.ListarServicio(startDate, endDate);
            DataTable devolucionesData = dFacturacion.ListarDevolucion(startDate, endDate);

            listaFacturas = new List<ErptFacturaCuadreCaja>();

            foreach (DataRow row in facturaData.Rows)
            {
                ErptFacturaCuadreCaja facturasModel = new ErptFacturaCuadreCaja()
                {
                    IdFactura = "FT-" + row[0].ToString(),
                    Fecha = DateTime.Parse(row[1].ToString()),
                    NCF = row[2].ToString(),
                    NombreCliente = row[3].ToString(),
                    TotalFactura = Convert.ToDouble(row[4].ToString()),
                    TipoCompra = row[5].ToString()
                };
                listaFacturas.Add(facturasModel);

                if (row[5].ToString() == "CONTADO")
                {
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
                    totalVentaContado += Convert.ToDouble(row[4].ToString());
                }
                else
                {
                    totalVentaCredito += Convert.ToDouble(row[4].ToString());
                }
            }

            foreach(DataRow row in devolucionData.Rows)
            {
                ErptFacturaCuadreCaja facturasModel = new ErptFacturaCuadreCaja()
                {
                    IdFactura = "DEV-" + row[0].ToString(),
                    Fecha = DateTime.Parse(row[3].ToString()),
                    NCF = row[14].ToString(),
                    NombreCliente = row[9].ToString(),
                    TotalFactura = Convert.ToDouble(row[8].ToString()),
                    TipoCompra = row[4].ToString()
                };
                listaFacturas.Add(facturasModel);
            }

            foreach (DataRow row in reciboIngresoData.Rows)
            {
                ErptFacturaCuadreCaja facturasModel = new ErptFacturaCuadreCaja()
                {
                    IdFactura = "RI-" + row[0].ToString(),
                    Fecha = DateTime.Parse(row[1].ToString()),
                    NCF = "",
                    NombreCliente = row[2].ToString(),
                    TotalFactura = Convert.ToDouble(row[3].ToString()),
                    TipoCompra = "RECIBO"
                };
                listaFacturas.Add(facturasModel);
                totalReciboIngreso += Convert.ToDouble(row[3]);
            }

            foreach (DataRow row in reciboServicioData.Rows)
            {
                ErptFacturaCuadreCaja facturasModel = new ErptFacturaCuadreCaja()
                {
                    IdFactura = "RIS-" + row[0].ToString(),
                    Fecha = DateTime.Parse(row[1].ToString()),
                    NCF = "",
                    NombreCliente = row[2].ToString(),
                    TotalFactura = Convert.ToDouble(row[3].ToString()),
                    TipoCompra = "RECIBO"
                };
                listaFacturas.Add(facturasModel);
                totalReciboIngreso += Convert.ToDouble(row[3]);
            }

            foreach (DataRow row in devolucionesData.Rows)
            {
                totalDevoluciones += Convert.ToDouble(row[4]);
            }

            _ = listaFacturas.OrderBy(k => k.NCF).ToList();
            totalTotal = totalVentaContado + totalReciboIngreso - totalDevoluciones;
        }

        public void createSalesOrderReport(int idCaja)
        {
            reportDate = DateTime.Now;
            startDate = DateTime.Now;
            endDate = DateTime.Now;

            DFacturacion dFacturacion = new DFacturacion();
            DServicio dServicio = new DServicio();
            DReciboIngreso dRecibo = new DReciboIngreso();

            DataTable facturaData = dFacturacion.Listar(idCaja);
            DataTable servicioData = dServicio.Listar(idCaja);
            DataTable devolucionData = dFacturacion.ReporteDevolucion(idCaja.ToString());
            DataTable reciboIngresoData = dRecibo.Listar(idCaja);
            DataTable reciboServicioData = dRecibo.ListarServicio(idCaja);
            DataTable devolucionesData = dFacturacion.ListarDevolucion(idCaja);

            listaFacturas = new List<ErptFacturaCuadreCaja>();

            foreach (DataRow row in facturaData.Rows)
            {
                ErptFacturaCuadreCaja facturasModel = new ErptFacturaCuadreCaja()
                {
                    IdFactura = "FT-" + row[0].ToString(),
                    Fecha = DateTime.Parse(row[1].ToString()),
                    NCF = row[2].ToString(),
                    NombreCliente = row[3].ToString(),
                    TotalFactura = Convert.ToDouble(row[4].ToString()),
                    TipoCompra = row[5].ToString()
                };
                listaFacturas.Add(facturasModel);

                if (row[5].ToString() == "CONTADO")
                {
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
                    totalVentaContado += Convert.ToDouble(row[4].ToString());
                }
                else
                {
                    totalVentaCredito += Convert.ToDouble(row[4].ToString());
                }
            }

            foreach (DataRow row in devolucionData.Rows)
            {
                ErptFacturaCuadreCaja facturasModel = new ErptFacturaCuadreCaja()
                {
                    IdFactura = "DEV-" + row[0].ToString(),
                    Fecha = DateTime.Parse(row[3].ToString()),
                    NCF = row[14].ToString(),
                    NombreCliente = row[9].ToString(),
                    TotalFactura = Convert.ToDouble(row[8].ToString()),
                    TipoCompra = row[4].ToString()
                };
                listaFacturas.Add(facturasModel);
            }

            foreach (DataRow row in reciboIngresoData.Rows)
            {
                ErptFacturaCuadreCaja facturasModel = new ErptFacturaCuadreCaja()
                {
                    IdFactura = "RI-" + row[0].ToString(),
                    Fecha = DateTime.Parse(row[1].ToString()),
                    NCF = "",
                    NombreCliente = row[2].ToString(),
                    TotalFactura = Convert.ToDouble(row[3].ToString()),
                    TipoCompra = "RECIBO"
                };
                listaFacturas.Add(facturasModel);
                totalReciboIngreso += Convert.ToDouble(row[3]);
            }

            foreach (DataRow row in reciboServicioData.Rows)
            {
                ErptFacturaCuadreCaja facturasModel = new ErptFacturaCuadreCaja()
                {
                    IdFactura = "RIS-" + row[0].ToString(),
                    Fecha = DateTime.Parse(row[1].ToString()),
                    NCF = "",
                    NombreCliente = row[2].ToString(),
                    TotalFactura = Convert.ToDouble(row[3].ToString()),
                    TipoCompra = "RECIBO"
                };
                listaFacturas.Add(facturasModel);
                totalReciboIngreso += Convert.ToDouble(row[3]);
            }

            foreach (DataRow row in devolucionesData.Rows)
            {
                totalDevoluciones += Convert.ToDouble(row[4]);
            }

            _ = listaFacturas.OrderBy(k => k.NCF).ToList();
            totalTotal = totalVentaContado + totalReciboIngreso - totalDevoluciones;
        }
    }
}
