using Datos;
using System;
using System.Data;

namespace Negocios
{
    public class NItbis
    {
        private readonly DItbis _itibis = new DItbis();

        public DataTable Buscar(string Query)
        {
            return _itibis.Buscar(Query);
        }
        public DataTable BuscarId(string IdItbis)
        {
            int Id = Convert.ToInt32(IdItbis);
            return _itibis.BuscarId(Id);
        }
        public DataTable Listar()
        {
            return _itibis.Listar();
        }
        public int MaxId()
        {
            return _itibis.MaxId();
        }
        public void Editar(string IdItbis, string Nombre, string Porciento)
        {
            int Id = Convert.ToInt32(IdItbis);
            decimal porciento = Convert.ToDecimal(Porciento);
            _itibis.Editar(Id, Nombre, porciento);
        }
        public void Insertar(string Nombre, string Porciento)
        {
            decimal porciento = Convert.ToDecimal(Porciento);
            _itibis.Insertar(Nombre, porciento);
        }
    }
}
