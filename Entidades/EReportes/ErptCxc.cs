using System;

namespace Entidades.EReportes
{
    public class ErptCxc
    {
        public int idCliente { get; set; }
        public string NombreCliente { get; set; }
        public string idFactura { get; set; }
        public DateTime FechaFactura { get; set; }
        public int DiasFactura { get; set; }
        public decimal TotalFactura { get; set; }
        public decimal BalancePendiente { get; set; }
    }
}
