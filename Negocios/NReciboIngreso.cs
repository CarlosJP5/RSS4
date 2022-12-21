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
        public int InsertarServicio(string IdCliente, DateTime Fecha, DataTable Detalle)
        {
            int id = Convert.ToInt32(IdCliente);
            return _recibo.InsertarServicio(id, Fecha, Detalle);
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
            string query = string.Format(@"SELECT SUM(balance_cxc) balance FROM CuentaCobrar
                                           WHERE id_cliente = {0} AND balance_cxc > 0", tbRecibo.Rows[0][0].ToString());
            DataTable tbalance = _recibo.Buscar(query);
            decimal balance = 0m;
            if (!string.IsNullOrEmpty(tbalance.Rows[0][0].ToString()))
            {
                balance = Convert.ToDecimal(tbalance.Rows[0][0].ToString());
            }
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
                    Estado = row[7].ToString(),
                    Balance = balance   
                };
                ReciboIngresos.Add(reciboModel);
            }
        }
    }
}
