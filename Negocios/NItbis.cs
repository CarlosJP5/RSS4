using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class NItbis
    {
        private readonly DItbis _itibis = new DItbis();

        public DataTable Listar()
        {
            return _itibis.Listar();
        }
        public int MaxId()
        {
            return _itibis.MaxId();
        }
        public void Insertar(string Nombre, string Porciento)
        {
            decimal porciento = Convert.ToDecimal(Porciento);
            _itibis.Insertar(Nombre, porciento);
        }
    }
}
