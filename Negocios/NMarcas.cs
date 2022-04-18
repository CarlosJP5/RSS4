using Datos;
using System;
using System.Data;

namespace Negocios
{
    public class NMarcas
    {
        private readonly DMarcas _marcas = new DMarcas();
        public DataTable Buscar(string Query)
        {
            return _marcas.Buscar(Query);
        }
        public DataTable BuscarId(string Id)
        {
            int Idmarca = Convert.ToInt32(Id);
            return _marcas.BuscarId(Idmarca);
        }
        public DataTable BuscarNombre(string Nombre)
        {
            return _marcas.BuscarNombre(Nombre);
        }
        public DataTable Listar()
        {
            return _marcas.Listar();
        }
        public int MaxId()
        {
            return _marcas.MaxId();
        }
        public void Editar(string Id, string Nombre)
        {
            int IdMarca = Convert.ToInt32(Id);
            _marcas.Editar(IdMarca, Nombre);
        }
        public int Insertar(string Nombre)
        {
            return _marcas.Insertar(Nombre);
        }
    }
}
