using System;

namespace Entidades.EReportes
{
    public class ErptReciboIngreso
    {
        public int IdRecibo { get; set; }
        public int IdFactura { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Pago { get; set; }
        public string Estado { get; set; }
        public string NombreCliente { get; set; }
    }
}
