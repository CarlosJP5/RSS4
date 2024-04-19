using Datos;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Negocios
{
    public class NGasto
    {
        private readonly DGasto dGasto = new DGasto();

        public DataTable Buscar(int id)
        {
            return dGasto.Buscar(id);
        }
        public DataTable Buscar(string nombre)
        {
            return dGasto.Buscar(nombre);
        }
        public DataTable BuscarDetalle(int idRegistro)
        {
            return dGasto.BuscarDetalle(idRegistro);
        }
        public DataTable BuscarDetalle(DateTime desde, DateTime hasta)
        {
            return dGasto.BuscarDetalle(desde, hasta);
        }
        public DataTable BuscarDetalle(DateTime desde, DateTime hasta, int idTipo)
        {
            return dGasto.BuscarDetalle(desde, hasta, idTipo);
        }
        public void Editar(int id, string nombre)
        {
            dGasto.Editar(id, nombre);
        }
        public void EditarDetalle(int idRegistro, int idGasto, DateTime fecha, string nota, decimal monto)
        {
            dGasto.EditarDetalle(idRegistro, idGasto, fecha, nota, monto);
        }
        public void Insertar(string nombre)
        {
            dGasto.Insertar(nombre);
        }
        public void InsertarDetalle(int idGasto, DateTime fecha, string nota, decimal monto)
        {
            dGasto.InsertarDetalle(idGasto, fecha, nota, monto);
        }
    }
}
