using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class NServicio
    {
        private readonly DServicio dservicio = new DServicio();

        public int Insertar(EServicio Factura, DataTable Detalle)
        {
            return dservicio.Insertar(Factura, Detalle);
        }
    }
}
