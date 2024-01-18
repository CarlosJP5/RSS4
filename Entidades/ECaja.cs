using System;

namespace Entidades
{
    public class ECaja
    {
        public int id_caja { get; set; } = 0;
        public DateTime apertura_caja { get; set; } = DateTime.Now;
        public string apertura_nombre { get; set; } = "";
        public DateTime cierre_caja { get; set; } = DateTime.Now;
        public string cierre_nombre { get; set; } = "Cierre Automatico";
        public double total_caja { get; set; } = 0;
        public double fondo_caja { get; set; } = 0;
        public string estado_caja { get; set; } = "";
    }
}
