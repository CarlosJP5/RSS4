using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class NComprobantes
    {
        private readonly DComprobantes _comprobantes = new DComprobantes();
        public DataTable ComprovantesVentas()
        {
            return _comprobantes.ComprovantesVentas();
        }
    }
}
