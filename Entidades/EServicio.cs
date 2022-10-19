using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EServicio
    {
        public int IdFactura { get; set; }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string Cedula { get; set; }
        public string Rnc { get; set; }
        public string IdComprobante { get; set; }
        public string NombreComprobante { get; set; }
        public string Ncf { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Importe { get; set; }
        public decimal Itbis { get; set; }
        public decimal Total { get; set; }
    }
}
