using Datos;
using Entidades.EReportes;
using System;
using System.Collections.Generic;
using System.Data;

namespace Negocios
{
    public class NReciboIngreso
    {
        private readonly DReciboIngreso _recibo = new DReciboIngreso();
        public List<ErptReciboIngreso> ReciboIngresos { get; set; }

        public DataTable Buscar(string Query)
        {
            return _recibo.Buscar(Query);
        }
        public DataTable BuscarId(string IdRecibo)
        {
            int id = Convert.ToInt32(IdRecibo);
            return _recibo.BuscarId(id);
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
        public void Anular(string IdRecibo)
        {
            int id = Convert.ToInt32(IdRecibo);
            _recibo.Anular(id);
        }

        public void ImprimirRecibo(string IdRecibo)
        {
            int id = Convert.ToInt32(IdRecibo);
            DataTable tbRecibo = _recibo.BuscarId(id);
            ReciboIngresos = new List<ErptReciboIngreso>();
            foreach (DataRow row in tbRecibo.Rows)
            {
                ErptReciboIngreso reciboModel = new ErptReciboIngreso()
                {
                    IdCliente = (int)row[0],
                    NombreCliente = row[1].ToString(),
                    Fecha = DateTime.Parse(row[2].ToString()),
                    IdRecibo = (int)row[3],
                    IdFactura = (int)row[4],
                    Pago = (decimal)row[6],
                    Estado = row[7].ToString()
                };
                ReciboIngresos.Add(reciboModel);
            }
        }
    }
}
