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
        public List<ErptReciboIngresoServicio> ReciboIngresosServicio { get; set; }
        public List<ErptCxc> EstadoCuenta { get; private set; }

        public DataTable Buscar(string Query)
        {
            return _recibo.Buscar(Query);
        }
        public DataTable BuscarId(string IdRecibo)
        {
            int id = Convert.ToInt32(IdRecibo);
            return _recibo.BuscarId(id);
        }
        public DataTable BuscarIdServicio(string IdRecibo)
        {
            int id = Convert.ToInt32(IdRecibo);
            return _recibo.BuscarIdServicio(id);
        }
        public DataTable Listar(DateTime Desde, DateTime Hasta)
        {
            return _recibo.Listar(Desde, Hasta);
        }
        public DataTable ListarServicio(DateTime Desde, DateTime Hasta)
        {
            return _recibo.ListarServicio(Desde, Hasta);
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
        public void AnularServicio(string IdRecibo)
        {
            int id = Convert.ToInt32(IdRecibo);
            _recibo.AnularServicio(id);
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

        public void ImprimirReciboServicio(string IdRecibo)
        {
            int id = Convert.ToInt32(IdRecibo);
            DataTable tbRecibo = _recibo.BuscarIdServicio(id);
            ReciboIngresosServicio = new List<ErptReciboIngresoServicio>();
            string query = string.Format(@"SELECT SUM(balance_cxc) balance FROM CuentaCobrarServicio
                                           WHERE id_cliente = {0} AND balance_cxc > 0", tbRecibo.Rows[0][0].ToString());
            DataTable tbalance = _recibo.Buscar(query);
            decimal balance = 0m;
            if (!string.IsNullOrEmpty(tbalance.Rows[0][0].ToString()))
            {
                balance = Convert.ToDecimal(tbalance.Rows[0][0].ToString());
            }
            foreach (DataRow row in tbRecibo.Rows)
            {
                ErptReciboIngresoServicio reciboModel = new ErptReciboIngresoServicio()
                {
                    IdCliente = (int)row[0],
                    NombreCliente = row[1].ToString(),
                    Fecha = DateTime.Parse(row[2].ToString()),
                    IdRecibo = (int)row[3],
                    IdFactura = (string)row[4],
                    Pago = (decimal)row[6],
                    Estado = row[7].ToString(),
                    Balance = balance
                };
                ReciboIngresosServicio.Add(reciboModel);
            }
        }

        public void ReporteEstadoCuenta()
        {
            DataTable dt = _recibo.EstadoCuentaTodo();
            EstadoCuenta = new List<ErptCxc>();
            foreach (DataRow dr in dt.Rows)
            {
                ErptCxc modeloEstado = new ErptCxc
                {
                    idCliente = (int)dr[0],
                    NombreCliente = dr[1].ToString(),
                    idFactura = dr[2].ToString(),
                    FechaFactura = DateTime.Parse(dr[3].ToString()),
                    TotalFactura = (decimal)dr[4],
                    BalancePendiente = (decimal)dr[5],
                };
                modeloEstado.DiasFactura = (DateTime.Now - modeloEstado.FechaFactura).Days;
                EstadoCuenta.Add(modeloEstado);
            }
        }
    }
}
