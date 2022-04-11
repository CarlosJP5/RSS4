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
    public class NSuplidores
    {
        private readonly DSuplidores _suplidor = new DSuplidores();

        public DataTable Listar()
        {
            return _suplidor.Listar();
        }
        public void Insertar(ESuplidor suplidor)
        {
            _suplidor.Insertar(suplidor);
        }
    }
}
