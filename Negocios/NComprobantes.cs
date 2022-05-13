using Datos;
using System;
using System.Data;

namespace Negocios
{
    public class NComprobantes
    {
        private readonly DComprobantes _comprobantes = new DComprobantes();
        public DataTable Listar()
        {
            return _comprobantes.Listar();
        }
        public DataTable ListarCantidad()
        {
            return _comprobantes.ListarCantidad();
        }
        public DataTable ComprovantesVentas()
        {
            return _comprobantes.ComprovantesVentas();
        }
        public DataTable SumarCantidad(string IdComprobante)
        {
            return _comprobantes.SumarCantidad(IdComprobante);
        }
        public DataTable Reporte607(string Query)
        {
            return _comprobantes.Reporte607(Query);
        }
        public void BorrarCantidad(int IdRegistro)
        {
            _comprobantes.BorrarCantidad(IdRegistro);
        }
        public void Deshabilitar(string IdRegistro)
        {
            int id = Convert.ToInt32(IdRegistro);
            _comprobantes.Deshabilitar(id);
        }
        public void InsertarCantidad(string IdComprobante, string Desde, string Hasta, DateTime FechaVecimiento)
        {
            int _desde = Convert.ToInt32(Desde);
            int _hasta = Convert.ToInt32(Hasta);
            _comprobantes.InsertarCantidad(IdComprobante, _desde, _hasta, FechaVecimiento);
        }
    }
}
