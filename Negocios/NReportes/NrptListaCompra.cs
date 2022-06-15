using Entidades.EReportes;
using System.Collections.Generic;
using System.Data;

namespace Negocios.NReportes
{
    public class NrptListaCompra
    {
        public List<ErptFacturaDetalle> FacturaDetalles { get; private set; }

        public void Lista(DataTable detalle)
        {
            FacturaDetalles = new List<ErptFacturaDetalle>();
            foreach (DataRow row in detalle.Rows)
            {
                ErptFacturaDetalle detalleModel = new ErptFacturaDetalle()
                {
                    CodigoArticulo = row[0].ToString(),
                    ReferenciaArticulo = row[1].ToString(),
                    NombreArticulo = row[2].ToString(),
                    MarcaArticulo = row[3].ToString(),
                    CantidadFacturado = (decimal)row[4],
                    CostoArticulo = (decimal)row[5],
                    ImporteFacturado = (decimal)row[6],
                };
                FacturaDetalles.Add(detalleModel);
            }
        }
    }
}
