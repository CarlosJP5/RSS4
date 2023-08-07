using Entidades;
using Negocios;
using System;
using System.Windows.Forms;

namespace APP
{
    public partial class FrmUsuarioPermiso : Form
    {
        private readonly NUsuario nUsuario = new NUsuario();
        private EUsuario Usuario = new EUsuario();

        public FrmUsuarioPermiso()
        {
            InitializeComponent();
        }

        private void FrmUsuarioPermiso_Load(object sender, EventArgs e)
        {
            Usuario = new EUsuario();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Usuario = new EUsuario();
            foreach (TreeNode item in treeViewDatos.Nodes)
            {
                item.Checked = false;
            }
            foreach (TreeNode item in treeViewFacturacion.Nodes)
            {
                item.Checked = false;
            }
            foreach (TreeNode item in treeViewCxc.Nodes)
            {
                item.Checked = false;
            }
            foreach (TreeNode item in treeViewCxp.Nodes)
            {
                item.Checked = false;
            }
        }

        private void treeViewDatos_AfterCheck(object sender, TreeViewEventArgs e)
        {
            Usuario.datos_ = treeViewDatos.Nodes["datos"].Checked;
            Usuario.datos_articulos_ = treeViewDatos.Nodes["articulos"].Checked;
            Usuario.datos_articulos_detalle = treeViewDatos.Nodes["detalleArticulo"].Checked;
            Usuario.datos_articulos_marcas = treeViewDatos.Nodes["marcas"].Checked;
            Usuario.datos_articulos_ajusteInventario = treeViewDatos.Nodes["ajusteInventario"].Checked;
            Usuario.datos_articulos_cambiar_codigo = treeViewDatos.Nodes["cambiarCodigo"].Checked;
            Usuario.datos_articulos_itbis = treeViewDatos.Nodes["itbis"].Checked;
            Usuario.datos_articulos_reporteInventario = treeViewDatos.Nodes["reporteInventario"].Checked;
            Usuario.datos_clientes_ = treeViewDatos.Nodes["clientes"].Checked;
            Usuario.datos_clientes_detalle = treeViewDatos.Nodes["detalleClientes"].Checked;
            Usuario.datos_suplidores = treeViewDatos.Nodes["suplidores"].Checked;
            Usuario.datos_usuario_ = treeViewDatos.Nodes["usuario"].Checked;
            Usuario.datos_usuario_detalle = treeViewDatos.Nodes["detalleUsuario"].Checked;
            Usuario.datos_usuario_permisos = treeViewDatos.Nodes["permisoUsuarios"].Checked;
            Usuario.datos_registro_comprobante = treeViewDatos.Nodes["registroComprobantes"].Checked;
            Usuario.datos_reporte_607 = treeViewDatos.Nodes["reporte607"].Checked;
            Usuario.datos_ncf = treeViewDatos.Nodes["ncf"].Checked;
        }

        private void treeViewFacturacion_AfterCheck(object sender, TreeViewEventArgs e)
        {
            Usuario.facturacion_normal = treeViewFacturacion.Nodes["facturacionNormal"].Checked;
            Usuario.facturacion_devolucion = treeViewFacturacion.Nodes["devolucionVenta"].Checked;
            Usuario.facturacion_cotizacion = treeViewFacturacion.Nodes["cotizaciones"].Checked;
            Usuario.facturacion_cuadre_caja = treeViewFacturacion.Nodes["cuadreCaja"].Checked;
            Usuario.facturacion_ = treeViewFacturacion.Nodes["facturacion"].Checked;
        }

        private void treeViewCxc_AfterCheck(object sender, TreeViewEventArgs e)
        {
            Usuario.cxc_reciboIngreso = treeViewCxc.Nodes["reciboIngreso"].Checked;
            Usuario.cxc_ = treeViewCxc.Nodes["cxc"].Checked;
        }

        private void treeViewCxp_AfterCheck(object sender, TreeViewEventArgs e)
        {
            Usuario.cxp_compra = treeViewCxp.Nodes["compra"].Checked;
            Usuario.cxp_devolucion = treeViewCxp.Nodes["devolucionCompra"].Checked;
            Usuario.cxp_pago = treeViewCxp.Nodes["reciboPago"].Checked;
            Usuario.cxp_ = treeViewCxp.Nodes["cxp"].Checked;
        }
    }
}
