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
        public void BorrarCantidad(int IdRegistro)
        {
            _comprobantes.BorrarCantidad(IdRegistro);
        }
        public void InsertarCantidad(string IdComprobante, string Desde, string Hasta, DateTime FechaVecimiento)
        {
            int _desde = Convert.ToInt32(Desde);
            int _hasta = Convert.ToInt32(Hasta);
            _comprobantes.InsertarCantidad(IdComprobante, _desde, _hasta, FechaVecimiento);
        }
    }
}
