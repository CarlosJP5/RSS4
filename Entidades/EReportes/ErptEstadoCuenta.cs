using System;

namespace Entidades.EReportes
{
    public class ErptEstadoCuenta
    {
        public string IdFactura { get; set; }
        public string NCF { get; set; }
        public DateTime Fecha { get; set; }
        public string Dias { get; set; }
        public decimal Balance { get; set; }
        public decimal Total { get; set; }
    }
}
