using Datos;
using Entidades;
using System;
using System.Data;

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
        public DataTable BuscarImei(string imei)
        {
            return _articulos.BuscarImei(imei);
        }
        public DataTable Listar()
        {
            return _articulos.Listar();
        }
        public DataTable ListarImei(string idArticulo)
        {
            return _articulos.ListarImei(idArticulo);
        }
        public DataTable ListaDeCompras()
        {
            return _articulos.ListaDeCompras();
        }
        public DataTable ListaDeCompras(string IdSup)
        {
            int id = Convert.ToInt32(IdSup);
            return _articulos.ListaDeCompras(id);
        }
        public void CambiarCodigo(string IdArticulo, string Codigo)
        {
            int id = Convert.ToInt32(IdArticulo);
            _articulos.CambiarCodigo(id, Codigo);
        }
        public void Editar(EArticulo articulo)
        {
            _articulos.Editar(articulo);
        }
        public void Insertar(EArticulo articulo)
        {
            _articulos.Insertar(articulo);
        }
        public void InsertarAjuste(DateTime Fecha, string Nota, DataTable Detalle)
        {
            _articulos.InsertarAjuste(Fecha, Nota, Detalle);
        }
    }
}
