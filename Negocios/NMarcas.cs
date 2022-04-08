using Datos;
using System.Data;

namespace Negocios
{
    public class NMarcas
    {
        private readonly DMarcas _marcas = new DMarcas();
        public DataTable Listar()
        {
            return _marcas.Listar();
        }
        public int MaxId()
        {
            return _marcas.MaxId();
        }
        public void Insertar(string Nombre)
        {
            _marcas.Insertar(Nombre);
        }
    }
}
