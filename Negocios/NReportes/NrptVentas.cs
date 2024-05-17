using Datos.DReportes;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace Negocios.NReportes
{
    public class NrptVentas
    {
        private readonly DrptVentas drptVentas = new DrptVentas();

        public decimal Ganancia { get; private set; }
        public List<EFactura> ContadoVentas { get; private set; }
        public List<EFactura> CreditoVentas { get; private set; }
        public List<EFactura> DevolucionVentas { get; private set; }

        public void GetVentas(DateTime desde, DateTime Hasta)
        {
            Ganancia = 0;
            DataTable ventasDT = drptVentas.Ventas(desde, Hasta);
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

            DataTable devolucionesDT = drptVentas.Devoluciones(desde, Hasta);
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

            DataTable beneficioData = drptVentas.Beneficio(desde, Hasta);
            foreach (DataRow dr in beneficioData.Rows)
            {
                decimal importe = (decimal)dr[0];
                decimal descuento = importe * (decimal)dr[1] / 100;
                decimal costo = (decimal)dr[2];
                Ganancia += importe - descuento - costo;
            }

            DataTable beneficioDevolucionData = drptVentas.BeneficioDevolucion(desde, Hasta);
            foreach (DataRow dr in beneficioDevolucionData.Rows)
            {
                decimal importe = (decimal)dr[0];
                decimal descuento = importe * (decimal)dr[1] / 100;
                decimal costo = (decimal)dr[2];
                Ganancia -= importe - descuento - costo;
            }

        }
    }
}
