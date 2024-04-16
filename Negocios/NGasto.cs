using Datos;
using System;
using System.Data;

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
        public void Editar(int id, string nombre)
        {
            dGasto.Editar(id, nombre);
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
