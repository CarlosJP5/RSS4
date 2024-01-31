using Datos;
using Entidades.EReportes;
using System;
using System.Collections.Generic;
using System.Data;

namespace Negocios.NReportes
{
    public class NrptFacturaServicio
    {
        private readonly DServicio dservicio = new DServicio();
        public List<ErptFacturaServicio> Factura { get; private set; }
        public List<ErptFacturaServicioDetalle> Detalle { get; private set; }

        public void Facturas(string IdFactura)
        {
            DataTable tbFactura = dservicio.Listar(IdFactura);
            Factura = new List<ErptFacturaServicio>();
            ErptFacturaServicio facturaModel = new ErptFacturaServicio()
            {
                Id = (int)tbFactura.Rows[0][0],
                IdFactura = tbFactura.Rows[0][11].ToString(),
                Fecha = DateTime.Parse(tbFactura.Rows[0][1].ToString()),
                IdCliente = (int)tbFactura.Rows[0][2],
                NombreCliente = tbFactura.Rows[0][3].ToString(),
                CedulaCliente = tbFactura.Rows[0][4].ToString(),
                RncCliente = tbFactura.Rows[0][5].ToString(),
                IdComprobante = tbFactura.Rows[0][6].ToString(),
                TipoCompra = tbFactura.Rows[0][12].ToString(),
                NombreComprobante = tbFactura.Rows[0][7].ToString(),
                NumeroComprobante = tbFactura.Rows[0][16].ToString(),
                FechaVencimiento = DateTime.Parse(tbFactura.Rows[0][17].ToString()),
                Importe = (decimal)tbFactura.Rows[0][8],
                Itbis = (decimal)tbFactura.Rows[0][9],
                Total = (decimal)tbFactura.Rows[0][10]
            };
            Factura.Add(facturaModel);

            Detalle = new List<ErptFacturaServicioDetalle>();
            foreach (DataRow row in tbFactura.Rows)
            {
                ErptFacturaServicioDetalle detalleModel = new ErptFacturaServicioDetalle()
                {
                    Descripcion = row[19].ToString(),
                    Precio = (decimal)row[20],
                };
                Detalle.Add(detalleModel);
            }
        }
    }
}
