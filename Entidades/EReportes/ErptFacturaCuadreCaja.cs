using System;

namespace Entidades.EReportes
{
    public class ErptFacturaCuadreCaja
    {
        public string IdFactura { get; set; }
        public DateTime Fecha { get; set; }
        public string NCF { get; set; }
        public string NombreCliente { get; set; }
        public double TotalFactura { get; set; }
        public string TipoCompra { get; set; }
    }
}
