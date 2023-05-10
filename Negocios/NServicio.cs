using Datos;
using Entidades;
using System;
using System.Data;

namespace Negocios
{
    public class NServicio
    {
        private readonly DServicio dservicio = new DServicio();

        public DataTable Buscar(DateTime desde, DateTime hasta)
        {
            return dservicio.Buscar(desde, hasta);
        }

        public DataTable Buscar_cliente(DateTime desde, DateTime hasta, string idCliente)
        {
            int id = int.Parse(idCliente);
            return dservicio.Buscar_cliente(desde, hasta, id);
        }

        public DataTable Buscar_idFactura(string idfactura)
        {
            return dservicio.Buscar_idFactura(idfactura);
        }

        public DataTable Listar(string idfactura)
        {
            return dservicio.Listar(idfactura);
        }
        public DataTable ListarAutomatica()
        {
            return dservicio.ListarAutomatica();
        }

        public void CancelarFacturaAutomatica(string idFactura)
        {
            dservicio.CancelarFacturaAutomatica(idFactura);
        }

        public void Editar(EServicio Factura, DataTable Detalle)
        {
            dservicio.Editar(Factura, Detalle);
        }

        public void EditarFacturaAutomatica(string idFactura, string idCliente, DateTime fecha, string descripcion, decimal precio)
        {
            dservicio.EditarFacturaAutomatica(idFactura, idCliente, fecha, descripcion, precio);
        }

        public string Insertar(EServicio Factura, DataTable Detalle)
        {
            return dservicio.Insertar(Factura, Detalle);
        }

        public string InsertarFacturaAutomatica(string idCliente, DateTime fecha, string descripcion, decimal precio)
        {
            return dservicio.InsertarFacturaAutomatica(idCliente, fecha, descripcion, precio);
        }
    }
}
