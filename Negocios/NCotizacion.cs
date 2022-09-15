using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class NCotizacion
    {
        private readonly DCotizacion dCotizacion = new DCotizacion();

        public bool TieneMovimientos(string IdFactura)
        {
            int id = Convert.ToInt16(IdFactura);
            return dCotizacion.TieneMovimientos(id);
        }
        public DataTable Buscar(string Query)
        {
            return dCotizacion.Buscar(Query);
        }
        public DataTable BuscarId(string IdFactura)
        {
            int id = Convert.ToInt16(IdFactura);
            return dCotizacion.BuscarId(id);
        }
        public DataTable Listar(DateTime Desde, DateTime Hasta)
        {
            return dCotizacion.Listar(Desde, Hasta);
        }
        public int Insertar(EFactura Factura, DataTable Detalle)
        {
            return dCotizacion.Insertar(Factura, Detalle);
        }
        public void Editar(EFactura Factura, DataTable Detalle)
        {
            dCotizacion.Editar(Factura, Detalle);
        }
    }
}
