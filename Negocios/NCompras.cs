using Datos;
using Entidades;
using System.Data;

namespace Negocios
{
    public class NCompras
    {
        private readonly DCompras _compra = new DCompras();

        public void Insertar(ECompra Compra, DataTable Detalle)
        {
            _compra.Insertar(Compra, Detalle);
        }
    }
}
