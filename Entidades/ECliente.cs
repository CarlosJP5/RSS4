using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ECliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string IdComprobante { get; set; }
        public string RNC { get; set; }
        public string Telefono { get; set; }
        public decimal LimiteCredito { get; set; } = 0;
        public decimal Descuento { get; set; }  = 0;
        public string TipoCompra { get; set; }
        public bool Estado { get; set; }
    }
}
