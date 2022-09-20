using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.EReportes
{
    public class ErptCotizacion
    {
        public int IdCotizacion { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaCotizacion { get; set; }
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
    }
}
