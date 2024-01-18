using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class NCaja
    {
        private readonly DCaja dCaja = new DCaja();

        public void Cierre(ECaja caja)
        {
            dCaja.Cierre(caja);
        }
        public void Apertura(string nombre, double fondo)
        {
            dCaja.Apertura(nombre, fondo);
        }
    }
}
