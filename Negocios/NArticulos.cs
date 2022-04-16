using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class NArticulos
    {
        private readonly DArticulos _articulos = new DArticulos();
        public void Insertar(EArticulo articulo)
        {
            _articulos.Insertar(articulo);
        }
    }
}
