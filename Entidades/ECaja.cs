using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ECaja
    {
        public static int id_caja { get; set; }
        public static DateTime apertura_caja { get; set; }
        public static string apertura_nombre { get; set; }
        public static DateTime cierre_caja { get; set; }
        public static string cierre_nombre { get; set; }
        public static double total_caja { get; set; }
        public static string estado_caja { get; set; }
    }
}
