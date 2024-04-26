using Datos;
using Entidades.EReportes;
using System;
using System.Collections.Generic;
using System.Data;

namespace Negocios
{
    public class NReciboPago
    {
        private readonly DReciboPago _recibo = new DReciboPago();

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
