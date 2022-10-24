using System;

namespace Entidades.EReportes
{
    public class ErptFacturaServicio
    {
        public int Id { get; set; }
        public string IdFactura { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string CedulaCliente { get; set; }
        public string RncCliente { get; set; }
        public string IdComprobante { get; set; }
        public string NombreComprobante { get; set; }
        public string NumeroComprobante { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Importe { get; set; }
        public decimal Itbis { get; set; }
        public decimal Total { get; set; }
    }
}
