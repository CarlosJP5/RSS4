using Datos;
using Datos.DReportes;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Security.Policy;

namespace Negocios.NReportes
{
    public class NrptVentas
    {
        private readonly DrptVentas drptVentas = new DrptVentas();

        public string Hasta { get; private set; }
        public string Desde { get; private set; }
        public decimal Ganancia { get; private set; }
        public List<EFactura> ContadoVentas { get; private set; }
        public List<EFactura> CreditoVentas { get; private set; }
        public List<EFactura> DevolucionVentas { get; private set; }
        public List<EFactura> ReciboIngresos { get; private set; }

        public void GetVentas(DateTime desde, DateTime hasta)
        {
            Desde = desde.ToString("dd / MM / yyyy");
            Hasta = hasta.ToString("dd / MM / yyyy");
            Ganancia = 0;
            DataTable ventasDT = drptVentas.Ventas(desde, hasta);
            ContadoVentas = new List<EFactura>();
            CreditoVentas = new List<EFactura>();
            foreach (DataRow dr in ventasDT.Rows)
            {
                EFactura facturaModel = new EFactura
                {
                    IdFactura = (int)dr[0],
                    Nombre = dr[1].ToString(),
                    Fecha = DateTime.Parse(dr[2].ToString()),
                    Importe = (decimal)dr[3],
                    Descuento = (decimal)dr[4],
                    Itbis = (decimal)dr[5],
                    Total = (decimal)dr[6],
                    TipoCompra = dr[7].ToString()
                };
                if (facturaModel.TipoCompra == "CONTADO")
                {
                    ContadoVentas.Add(facturaModel);
                }
                else
                {
                    CreditoVentas.Add(facturaModel);
                }
            }

            DataTable devolucionesDT = drptVentas.Devoluciones(desde, hasta);
            DevolucionVentas = new List<EFactura>();
            foreach (DataRow dr in devolucionesDT.Rows)
            {
                EFactura facturaModel = new EFactura
                {
                    IdFactura = (int)dr[0],
                    Nombre = dr[1].ToString(),
                    Fecha = DateTime.Parse(dr[2].ToString()),
                    Importe = (decimal)dr[3],
                    Descuento = (decimal)dr[4],
                    Itbis = (decimal)dr[5],
                    Total = (decimal)dr[6],
                    TipoCompra = dr[7].ToString()
                };
                DevolucionVentas.Add(facturaModel);
            }

            DataTable beneficioData = drptVentas.Beneficio(desde, hasta);
            foreach (DataRow dr in beneficioData.Rows)
            {
                decimal importe = (decimal)dr[0];
                decimal descuento = importe * (decimal)dr[1] / 100;
                decimal costo = (decimal)dr[2];
                Ganancia += importe - descuento - costo;
            }

            DataTable beneficioDevolucionData = drptVentas.BeneficioDevolucion(desde, hasta);
            foreach (DataRow dr in beneficioDevolucionData.Rows)
            {
                decimal importe = (decimal)dr[0];
                decimal descuento = importe * (decimal)dr[1] / 100;
                decimal costo = (decimal)dr[2];
                Ganancia -= importe - descuento - costo;
            }

            DataTable reciboIngresoDt = drptVentas.ReciboIngreso(desde, hasta);
            foreach (DataRow dr in reciboIngresoDt.Rows)
            {
                EFactura facturaModel = new EFactura
                {
                    IdFactura = (int)dr[0],
                    Fecha = DateTime.Parse(dr[1].ToString()),
                    Nombre = dr[2].ToString(),
                    Total = (decimal)dr[3]
                };
                DevolucionVentas.Add(facturaModel);
                CalcularGananciaReciboIngreso(facturaModel.IdFactura);
            }

        }

        private void CalcularGananciaReciboIngreso(int idRecibo)
        {
            DReciboIngreso dReciboIngreso = new DReciboIngreso();
            DataTable reciboDetalle = dReciboIngreso.BuscarId(idRecibo);
            foreach (DataRow dr in reciboDetalle.Rows)
            {
                decimal pago = (decimal)dr[6]; // 630
                decimal gananciaTotalFactura = 0m;
                decimal importeTotalfact = 0m;
                DataTable facturaData = drptVentas.Beneficio((int)dr[4]); //fact 294
                foreach (DataRow drf in facturaData.Rows)
                {
                    decimal importe = (decimal)drf[0];
                    decimal descuento = importe * (decimal)drf[1] / 100;
                    decimal costo = (decimal)drf[2];
                    gananciaTotalFactura += importe - descuento - costo;
                    importeTotalfact += importe;
                }
                decimal porcientopagado = pago * 100 / importeTotalfact;
                Ganancia += gananciaTotalFactura * porcientopagado / 100;
            }
        }
    }
}
