using System;

namespace Entidades
{
    public class EUsuario
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Clave { get; set; }
        public bool Estado { get; set; } = false;

        // Permisos
        public bool datos_ { get; set; } = false;
        public bool datos_articulos_ { get; set; } = false;
        public bool datos_articulos_detalle { get; set; } = false;
        public bool datos_articulos_marcas { get; set; } = false;
        public bool datos_articulos_ajusteInventario { get; set; } = false;
        public bool datos_articulos_cambiar_codigo { get; set; } = false;
        public bool datos_articulos_itbis { get; set; } = false;
        public bool datos_articulos_reporteInventario { get; set; } = false;
        public bool datos_clientes_ { get; set; } = false;
        public bool datos_clientes_detalle { get; set; } = false;
        public bool datos_suplidores { get; set; } = false;
        public bool datos_usuario_ { get; set; } = false;
        public bool datos_usuario_detalle { get; set; } = false;
        public bool datos_usuario_permisos { get; set; } = false;
        public bool datos_ncf { get; set; } = false;
        public bool datos_registro_comprobante { get; set; } = false;
        public bool datos_reporte_607 { get; set; } = false;
        public bool facturacion_ { get; set; } = false;
        public bool facturacion_normal { get; set; } = false;
        public bool facturacion_devolucion { get; set; } = false;
        public bool facturacion_cotizacion { get; set; } = false;
        public bool facturacion_cuadre_caja { get; set; } = false;
        public bool cxc_ { get; set; } = false;
        public bool cxc_reciboIngreso { get; set; } = false;
        public bool cxp_ { get; set; } = false;
        public bool cxp_compra { get; set; } = false;
        public bool cxp_devolucion { get; set; } = false;
        public bool cxp_pago { get; set; } = false;
    }
}
