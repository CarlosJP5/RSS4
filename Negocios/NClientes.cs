using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class NClientes
    {
        private readonly DClientes _cliente = new DClientes();

        public int MaxId()
        {
            return _cliente.MaxId();
        }
        public void Insertar(ECliente cliente)
        {
            _cliente.Insertar(cliente);
        }
    }
}
