using Datos;
using Entidades;
using System;
using System.Data;

namespace Negocios
{
    public class NFacturacion
    {
        private readonly DFacturacion _facturar = new DFacturacion();
        
        public bool TieneMovimientos(string IdFactura)
        {
            int Id = Convert.ToInt32(IdFactura);
            return _facturar.TieneMovimientos(Id);
        }
        public DataTable Buscar(string Query)
        {
            return _facturar.Buscar(Query);
        }
        public DataTable BuscarId(string IdFactura)
        {
            int Id = Convert.ToInt32(IdFactura);
            return _facturar.BuscarId(Id);
        }
        public DataTable BuscarDevoluionId(string IdDevolucion)
        {
            int Id = Convert.ToInt32(IdDevolucion);
            return _facturar.BuscarDevoluionId(Id);
        }
        public DataTable DevolucionCargar(string IdFactura)
        {
            int id = Convert.ToInt32(IdFactura);
            return _facturar.DevolucionCargar(id);
        }
        public DataTable Listar(DateTime Desde, DateTime Hasta)
        {
            return _facturar.Listar(Desde, Hasta);
        }
        public DataTable ListarDevolucion(DateTime Desde, DateTime Hasta)
        {
            return _facturar.ListarDevolucion(Desde, Hasta);
        }
        public int Insertar(EFactura Factura, DataTable Detalle)
        {
            return _facturar.Insertar(Factura, Detalle);
        }
        public int InsertarDevolucion(EFactura Factura, DataTable Detalle)
        {
            return _facturar.InsertarDevolucion(Factura, Detalle);
        }
        public void Editar(EFactura Factura, DataTable Detalle, DataTable imeiDt)
        {
            _facturar.Editar(Factura, Detalle, imeiDt);
        }
    }
}
