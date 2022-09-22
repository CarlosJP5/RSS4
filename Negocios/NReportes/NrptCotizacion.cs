using Datos.DReportes;
using Entidades.EReportes;
using System;
using System.Collections.Generic;
using System.Data;

namespace Negocios.NReportes
{
    public class NrptCotizacion
    {
        private readonly DrptFactura drptFactura = new DrptFactura();
        public List<ErptCotizacion> Cotizacion { get; set; }
        public List<ErptCotizacionDetalle> CotizacionDetalles { get; set; }

        public void Cotizacion_rpt(string IdCotizacion)
        {
            int id = Convert.ToInt32(IdCotizacion);
            DataTable cotizacion_table = drptFactura.Cotizacion(id);
            Cotizacion = new List<ErptCotizacion>();
            ErptCotizacion cotizacion_model = new ErptCotizacion()
            {
                IdCotizacion = Convert.ToInt16(cotizacion_table.Rows[0][0].ToString()),
                IdCliente = Convert.ToInt16(cotizacion_table.Rows[0][1].ToString()),
                FechaCotizacion = DateTime.Parse(cotizacion_table.Rows[0][3].ToString()),
                TipoCompra = cotizacion_table.Rows[0][4].ToString(),
                NotaFactura = cotizacion_table.Rows[0][5].ToString(),
                ImporteFactura = Convert.ToDecimal(cotizacion_table.Rows[0][6].ToString()),
                ItbisFactura = Convert.ToDecimal(cotizacion_table.Rows[0][7].ToString()),
                Total = Convert.ToDecimal(cotizacion_table.Rows[0][8].ToString()),
                DescuentoFactura = Convert.ToDecimal(cotizacion_table.Rows[0][9].ToString()),
                NombreCliente = cotizacion_table.Rows[0][2].ToString(),
                RncCliente = cotizacion_table.Rows[0][10].ToString(),
            };
            Cotizacion.Add(cotizacion_model);

            DataTable Detalle = drptFactura.CotizacionDetalle(id);
            CotizacionDetalles = new List<ErptCotizacionDetalle>();
            foreach (DataRow row in Detalle.Rows)
            {
                ErptCotizacionDetalle cotizacion_detalle = new ErptCotizacionDetalle()
                {
                    CodigoArticulo = row[0].ToString(),
                    NombreArticulo = row[1].ToString(),
                    CantidadFacturado = Convert.ToDecimal(row[2].ToString()),
                    DescuentoFacturado = Convert.ToDecimal(row[3].ToString()),
                    PrecioFacturado = Convert.ToDecimal(row[4].ToString()),
                    ImporteFacturado = Convert.ToDecimal(row[5].ToString()),
                    TotalImporte = Convert.ToDecimal(row[6].ToString()),
                    TotalDescuento = Convert.ToDecimal(row[7].ToString()),
                    TotalItbis = Convert.ToDecimal(row[8].ToString()),
                };
                CotizacionDetalles.Add(cotizacion_detalle);
            }
        }
    }
}
