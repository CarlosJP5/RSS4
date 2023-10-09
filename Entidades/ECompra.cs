using System;

namespace Entidades
{
    public class ECompra
    {
        public int IdCompra { get; set; }
        public int IdSuplidor { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoCompra { get; set; }
        public string FacturaNumero { get; set; }
        public string NCF { get; set; }
        public decimal Importe { get; set; }
        public decimal Descuento { get; set; }
        public decimal Itbis { get; set; }
        public decimal Total { get; set; }
        public double Taza { get; set; } = 1;
    }
}
