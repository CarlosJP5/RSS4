using Datos;
using Entidades;
using System;
using System.Data;

namespace Negocios
{
    public class NFacturacion
    {
        private readonly DFacturacion _facturar = new DFacturacion();

        public DataTable Buscar(string Query)
        {
            return _facturar.Buscar(Query);
        }
        public DataTable BuscarId(string IdFactura)
        {
            int Id = Convert.ToInt32(IdFactura);
            return _facturar.BuscarId(Id);
        }
        public DataTable Listar(DateTime Desde, DateTime Hasta)
        {
            return _facturar.Listar(Desde, Hasta);
        }
        public int Insertar(EFactura Factura, DataTable Detalle)
        {
            return _facturar.Insertar(Factura, Detalle);
        }
        public void Editar(EFactura Factura, DataTable Detalle)
        {
            _facturar.Editar(Factura, Detalle);
        }
    }
}
