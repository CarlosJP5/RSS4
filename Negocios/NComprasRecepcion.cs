using Datos;
using System.Data;

namespace Negocios
{
    public class NComprasRecepcion
    {
        private readonly DComprasRecepcion dcomprasrecepcion = new DComprasRecepcion();

        public DataTable Insertada(string idCompra)
        {
            return dcomprasrecepcion.Insertada(idCompra);
        }
        public void Insertar(string idCompra, DataTable detalle)
        {
            dcomprasrecepcion.Insertar(idCompra, detalle);
        }
    }
}
