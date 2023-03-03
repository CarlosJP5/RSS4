using System;

namespace Entidades.EReportes
{
    public class ErptFactura
    {
        public int IdFactura { get; set; }
        public int IdCliente { get; set; }
        public string IdComprobante { get; set; }
        public DateTime FechaFactura { get; set; }
        public string TipoCompra { get; set; }
        public string NotaFactura { get; set; }
        public decimal ImporteFactura { get; set; }
        public decimal DescuentoFactura { get; set; }
        public decimal ItbisFactura { get; set; }
        public decimal Total { get; set; }
        public string NombreCliente { get; set; }
        public string CedulaCliente { get; set; }
        public string RncCliente { get; set; }
        public string DireccionCliente { get; set; }
        public string TelefonoCliente { get; set; }
        public string CorreoCliente { get; set; }
        public string NcfComprobante { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string NombreComprobante { get; set; }
        public DateTime FechaVenceCredito { get; set; }
        public string Pago { get; set; }
        public string Devuelta { get; set; }
    }
}
