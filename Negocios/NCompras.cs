using Datos;
using Entidades;
using System;
using System.Data;

namespace Negocios
{
    public class NCompras
    {
        private readonly DCompras _compra = new DCompras();
        public DataTable Buscar(string Query)
        {
            return _compra.Buscar(Query);
        }
        public DataTable BuscarId(string IdCompra)
        {
            int Id = Convert.ToInt32(IdCompra);
            return _compra.BuscarId(Id);
        }
        public DataTable Listar(DateTime Desde, DateTime Hasta)
        {
            return _compra.Listar(Desde, Hasta);
        }
        public void Editar(ECompra Compra, DataTable Detalle)
        {
            _compra.Editar(Compra, Detalle);
        }
        public void Insertar(ECompra Compra, DataTable Detalle)
        {
            _compra.Insertar(Compra, Detalle);
        }
    }
}
