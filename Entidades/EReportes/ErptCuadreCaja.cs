using System;

namespace Entidades.EReportes
{
    public class ErptCuadreCaja
    {
        public decimal TotalRecibo { get; set; }
        public decimal TotalVentaContado { get; set; }
        public decimal TotalDevolicion { get; set; }
        public decimal TotalTotal { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
    }
}
