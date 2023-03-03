using Datos.DReportes;
using Entidades.EReportes;
using System;
using System.Collections.Generic;
using System.Data;

namespace Negocios.NReportes
{
    public class NrptFactura
    {
        private readonly DrptFactura _factura = new DrptFactura();
        public List<ErptFactura> Factura { get; private set; }
        public List<ErptFacturaDetalle> FacturaDetalles { get; private set; }

        public void Facturas(string IdFactura)
        {
            int id = Convert.ToInt32(IdFactura);
            DataTable tbFactura = _factura.Factura(id);
            Factura = new List<ErptFactura>();
            ErptFactura facturaModel = new ErptFactura()
            {
                IdFactura = (int)tbFactura.Rows[0][0],
                IdCliente = (int)tbFactura.Rows[0][1],
                IdComprobante = tbFactura.Rows[0][2].ToString(),
                FechaFactura = DateTime.Parse(tbFactura.Rows[0][3].ToString()),
                TipoCompra = tbFactura.Rows[0][4].ToString(),
                NotaFactura = tbFactura.Rows[0][5].ToString(),
                ImporteFactura = (decimal)tbFactura.Rows[0][6],
                DescuentoFactura = (decimal)tbFactura.Rows[0][7],
                ItbisFactura = (decimal)tbFactura.Rows[0][8],
                Total = (decimal)tbFactura.Rows[0][9],
                NombreCliente = tbFactura.Rows[0][10].ToString(),
                CedulaCliente = tbFactura.Rows[0][11].ToString(),
                RncCliente = tbFactura.Rows[0][12].ToString(),
                DireccionCliente = tbFactura.Rows[0][13].ToString(),
                TelefonoCliente = tbFactura.Rows[0][14].ToString(),
                CorreoCliente = tbFactura.Rows[0][15].ToString(),
                NcfComprobante = tbFactura.Rows[0][16].ToString(),
                FechaVencimiento = DateTime.Parse(tbFactura.Rows[0][17].ToString()),
                NombreComprobante = tbFactura.Rows[0][18].ToString(),
                Pago = tbFactura.Rows[0][19].ToString(),
                Devuelta = tbFactura.Rows[0][20].ToString(),
            };
            facturaModel.FechaVenceCredito = facturaModel.FechaFactura.AddDays(30);
            Factura.Add(facturaModel);

            DataTable detalle = _factura.FacturaDetalle(id);
            FacturaDetalles = new List<ErptFacturaDetalle>();
            foreach (DataRow row in detalle.Rows)
            {
                ErptFacturaDetalle detalleModel = new ErptFacturaDetalle()
                {
                    CodigoArticulo = row[0].ToString(),
                    NombreArticulo = row[1].ToString(),
                    ReferenciaArticulo = row[2].ToString(),
                    CantidadFacturado = (decimal)row[3],
                    DescuentoFacturado = (decimal)row[4],
                    PrecioFacturado = (decimal)row[5],
                    ImporteFacturado = (decimal)row[6],
                    TotalImporte = (decimal)row[7],
                    TotalDescuento = (decimal)row[8],
                    TotalItbis = (decimal)row[9]
                };
                FacturaDetalles.Add(detalleModel);
            }
        }
    }
}
