﻿namespace Entidades.EReportes
{
    public class ErptFacturaDetalle
    {
        public string CodigoArticulo { get; set; }
        public string NombreArticulo { get; set; }
        public string ReferenciaArticulo { get; set; }
        public string MarcaArticulo { get; set; }
        public decimal CantidadFacturado { get; set; }
        public decimal DescuentoFacturado { get; set; }
        public decimal PrecioFacturado { get; set; }
        public decimal CostoArticulo { get; set; }
        public decimal ImporteFacturado { get; set; }
        public decimal TotalImporte { get; set; }
        public decimal TotalDescuento { get; set; }
        public decimal TotalItbis { get; set; }
    }
}
