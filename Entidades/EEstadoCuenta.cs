using System;

namespace Entidades
{
    public class EEstadoCuenta
    {
        public string fact { get; set; }
        public string ncf { get; set; }
        public DateTime fecha { get; set; }
        public int dias { get; set; }
        public decimal Balance { get; set; }
    }
}
