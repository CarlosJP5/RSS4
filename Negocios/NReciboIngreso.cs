using Datos;
using System;
using System.Data;

namespace Negocios
{
    public class NReciboIngreso
    {
        private readonly DReciboIngreso _recibo = new DReciboIngreso();

        public DataTable Buscar(string Query)
        {
            return _recibo.Buscar(Query);
        }
        public DataTable Listar(DateTime Desde, DateTime Hasta)
        {
            return _recibo.Listar(Desde, Hasta);
        }
        public int Insertar(string IdCliente, DateTime Fecha, DataTable Detalle)
        {
            int id = Convert.ToInt32(IdCliente);
            return _recibo.Insertar(id, Fecha, Detalle);
        }
    }
}
