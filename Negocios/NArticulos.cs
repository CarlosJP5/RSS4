using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace Negocios
{
    public class NArticulos
    {
        private readonly DArticulos _articulos = new DArticulos();

        public List<EArticulo> Articulos { get; private set; }

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

        public void Inventario()
        {
            DataTable dt = _articulos.Inventario();
            Articulos = new List<EArticulo>();
            foreach (DataRow dr in dt.Rows)
            {
                EArticulo modeloArti = new EArticulo
                {
                    Codigo = dr[0].ToString(),
                    Nombre = dr[1].ToString(),
                    Cantidad = (decimal)dr[2],
                    Costo = (decimal)dr[3],
                    Precio = (decimal)dr[4],
                    BeneficioMinimo = (decimal)dr[5],
                    Beneficio = (decimal)dr[6],
                };
                Articulos.Add(modeloArti);
            }
        }
    }
}
