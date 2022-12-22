using System;

namespace Entidades.EReportes
{
    public class ErptReciboIngresoServicio
    {
        public int IdRecibo { get; set; }
        public string IdFactura { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Pago { get; set; }
        public string Estado { get; set; }
        public string NombreCliente { get; set; }
        public decimal Balance { get; set; }
    }
}
