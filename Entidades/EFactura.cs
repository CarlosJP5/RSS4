using System;

namespace Entidades
{
    public class EFactura
    {
        public int IdFactura { get; set; }
        public int IdCliente { get; set; }
        public int IdCaja { get; set; }
        public int IdDevolucion { get; set; }
        public string IdComprobante { get; set; }
        public string Ncf { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string TipoCompra { get; set; }
        public string Nota { get; set; }
        public decimal Importe { get; set; }
        public decimal Descuento { get; set; }
        public decimal Itbis { get; set; }
        public decimal Total { get; set; }
        public string Nombre { get; set; }
    }
}
