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
    public class NArticulos
    {
        private readonly DArticulos _articulos = new DArticulos();

        public DataTable Buscar(string Query)
        {
            return _articulos.Buscar(Query);
        }
        public DataTable BuscarCodigo(string Codigo)
        {
            return _articulos.BuscarCodigo(Codigo);
        }
        public DataTable BuscarId(string IdArticulo)
        {
            int Id = Convert.ToInt32(IdArticulo);
            return _articulos.BuscarId(Id);
        }
        public DataTable Listar()
        {
            return _articulos.Listar();
        }
        public void Editar(EArticulo articulo)
        {
            _articulos.Editar(articulo);
        }
        public void Insertar(EArticulo articulo)
        {
            _articulos.Insertar(articulo);
        }
    }
}
