using APP.Buscar;
using Entidades;
using Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP
{
    public partial class FrmUsuarioPermiso : Form
    {
        private readonly NUsuario nUsuario = new NUsuario();
        private EUsuario Usuario = new EUsuario();
        private bool afterCheck = false;

        public FrmUsuarioPermiso()
        {
            InitializeComponent();
        }

        private void FrmUsuarioPermiso_Load(object sender, EventArgs e)
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Usuario = new EUsuario();
            txtNombre.Text = "";
            afterCheck = false;
            LlenarTree();
        }

        private void treeViewDatos_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (afterCheck)
            {
                Usuario.datos_ = treeViewDatos.Nodes["datos"].Checked;

                Usuario.datos_articulos_ = treeViewDatos.Nodes["datos"].Nodes["articulos"].Checked;
                Usuario.datos_articulos_detalle = treeViewDatos.Nodes["datos"].Nodes["articulos"].Nodes["detalleArticulo"].Checked;
                Usuario.datos_articulos_marcas = treeViewDatos.Nodes["datos"].Nodes["articulos"].Nodes["marcas"].Checked;
                Usuario.datos_articulos_ajusteInventario = treeViewDatos.Nodes["datos"].Nodes["articulos"].Nodes["ajusteInventario"].Checked;
                Usuario.datos_articulos_cambiar_codigo = treeViewDatos.Nodes["datos"].Nodes["articulos"].Nodes["cambiarCodigo"].Checked;
                Usuario.datos_articulos_itbis = treeViewDatos.Nodes["datos"].Nodes["articulos"].Nodes["itbis"].Checked;
                Usuario.datos_articulos_reporteInventario = treeViewDatos.Nodes["datos"].Nodes["articulos"].Nodes["reporteInventario"].Checked;


                Usuario.datos_clientes_ = treeViewDatos.Nodes["datos"].Nodes["clientes"].Checked;
                Usuario.datos_clientes_detalle = treeViewDatos.Nodes["datos"].Nodes["clientes"].Nodes["detalleClientes"].Checked;

                Usuario.datos_suplidores = treeViewDatos.Nodes["datos"].Nodes["suplidores"].Checked;

                Usuario.datos_usuario_ = treeViewDatos.Nodes["datos"].Nodes["usuario"].Checked;
                Usuario.datos_usuario_detalle = treeViewDatos.Nodes["datos"].Nodes["usuario"].Nodes["detalleUsuario"].Checked;
                Usuario.datos_usuario_permisos = treeViewDatos.Nodes["datos"].Nodes["usuario"].Nodes["permisoUsuarios"].Checked;

                Usuario.datos_ncf = treeViewDatos.Nodes["datos"].Nodes["ncf"].Checked;
                Usuario.datos_registro_comprobante = treeViewDatos.Nodes["datos"].Nodes["ncf"].Nodes["registroComprobantes"].Checked;
                Usuario.datos_reporte_607 = treeViewDatos.Nodes["datos"].Nodes["ncf"].Nodes["reporte607"].Checked; 
            }
        }

        private void treeViewFacturacion_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (afterCheck)
            {
                Usuario.facturacion_ = treeViewFacturacion.Nodes["facturacion"].Checked;
                Usuario.facturacion_normal = treeViewFacturacion.Nodes["facturacion"].Nodes["facturacionNormal"].Checked;
                Usuario.facturacion_devolucion = treeViewFacturacion.Nodes["facturacion"].Nodes["devolucionVenta"].Checked;
                Usuario.facturacion_cotizacion = treeViewFacturacion.Nodes["facturacion"].Nodes["cotizaciones"].Checked;
                Usuario.facturacion_cuadre_caja = treeViewFacturacion.Nodes["facturacion"].Nodes["cuadreCaja"].Checked; 
            }
        }

        private void treeViewCxc_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (afterCheck)
            {
                Usuario.cxc_ = treeViewCxc.Nodes["cxc"].Checked;
                Usuario.cxc_reciboIngreso = treeViewCxc.Nodes["cxc"].Nodes["reciboIngreso"].Checked; 
            }
        }

        private void treeViewCxp_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (afterCheck)
            {
                Usuario.cxp_ = treeViewCxp.Nodes["cxp"].Checked;
                Usuario.cxp_compra = treeViewCxp.Nodes["cxp"].Nodes["compra"].Checked;
                Usuario.cxp_devolucion = treeViewCxp.Nodes["cxp"].Nodes["devolucionCompra"].Checked;
                Usuario.cxp_pago = treeViewCxp.Nodes["cxp"].Nodes["reciboPago"].Checked; 
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarUsuarios frm = new FrmBuscarUsuarios();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Usuario.Id = Convert.ToInt16(frm.dgvListar.SelectedCells[0].Value);
                Usuario.Usuario = frm.dgvListar.SelectedCells[1].Value.ToString();
                Usuario.Nombre = frm.dgvListar.SelectedCells[2].Value.ToString();
                txtNombre.Text = frm.dgvListar.SelectedCells[2].Value.ToString();

                DataTable usuarioPermiso = nUsuario.ListaPermisos(Usuario.Id);
                Usuario.datos_ = (bool)usuarioPermiso.Rows[0][1];
                Usuario.datos_articulos_ = (bool)usuarioPermiso.Rows[0][2];
                Usuario.datos_articulos_detalle = (bool)usuarioPermiso.Rows[0][3];
                Usuario.datos_articulos_marcas = (bool)usuarioPermiso.Rows[0][4];
                Usuario.datos_articulos_ajusteInventario = (bool)usuarioPermiso.Rows[0][5];
                Usuario.datos_articulos_cambiar_codigo = (bool)usuarioPermiso.Rows[0][6];
                Usuario.datos_articulos_itbis = (bool)usuarioPermiso.Rows[0][7];
                Usuario.datos_articulos_reporteInventario = (bool)usuarioPermiso.Rows[0][8];
                Usuario.datos_clientes_ = (bool)usuarioPermiso.Rows[0][9];
                Usuario.datos_clientes_detalle = (bool)usuarioPermiso.Rows[0][10];
                Usuario.datos_suplidores = (bool)usuarioPermiso.Rows[0][11];
                Usuario.datos_usuario_ = (bool)usuarioPermiso.Rows[0][12];
                Usuario.datos_usuario_detalle = (bool)usuarioPermiso.Rows[0][13];
                Usuario.datos_usuario_permisos = (bool)usuarioPermiso.Rows[0][14];
                Usuario.datos_ncf = (bool)usuarioPermiso.Rows[0][15];
                Usuario.datos_registro_comprobante = (bool)usuarioPermiso.Rows[0][16];
                Usuario.datos_reporte_607 = (bool)usuarioPermiso.Rows[0][17];
                Usuario.facturacion_ = (bool)usuarioPermiso.Rows[0][18];
                Usuario.facturacion_normal = (bool)usuarioPermiso.Rows[0][19];
                Usuario.facturacion_devolucion = (bool)usuarioPermiso.Rows[0][20];
                Usuario.facturacion_cotizacion = (bool)usuarioPermiso.Rows[0][21];
                Usuario.facturacion_cuadre_caja = (bool)usuarioPermiso.Rows[0][22];
                Usuario.cxc_ = (bool)usuarioPermiso.Rows[0][23];
                Usuario.cxc_reciboIngreso = (bool)usuarioPermiso.Rows[0][24];
                Usuario.cxp_ = (bool)usuarioPermiso.Rows[0][25];
                Usuario.cxp_compra = (bool)usuarioPermiso.Rows[0][26];
                Usuario.cxp_devolucion = (bool)usuarioPermiso.Rows[0][27];
                Usuario.cxp_pago = (bool)usuarioPermiso.Rows[0][28];
                afterCheck = false;
                LlenarTree();
            }
        }

        private void LlenarTree()
        {           
            treeViewDatos.Nodes["datos"].Checked = Usuario.datos_;
            
            treeViewDatos.Nodes["datos"].Nodes["articulos"].Checked = Usuario.datos_articulos_;
            treeViewDatos.Nodes["datos"].Nodes["articulos"].Nodes["detalleArticulo"].Checked = Usuario.datos_articulos_detalle;
            treeViewDatos.Nodes["datos"].Nodes["articulos"].Nodes["marcas"].Checked = Usuario.datos_articulos_marcas;
            treeViewDatos.Nodes["datos"].Nodes["articulos"].Nodes["ajusteInventario"].Checked = Usuario.datos_articulos_ajusteInventario;
            treeViewDatos.Nodes["datos"].Nodes["articulos"].Nodes["cambiarCodigo"].Checked = Usuario.datos_articulos_cambiar_codigo;
            treeViewDatos.Nodes["datos"].Nodes["articulos"].Nodes["itbis"].Checked = Usuario.datos_articulos_itbis;
            treeViewDatos.Nodes["datos"].Nodes["articulos"].Nodes["reporteInventario"].Checked = Usuario.datos_articulos_reporteInventario;
            

            treeViewDatos.Nodes["datos"].Nodes["clientes"].Checked = Usuario.datos_clientes_;
            treeViewDatos.Nodes["datos"].Nodes["clientes"].Nodes["detalleClientes"].Checked = Usuario.datos_clientes_detalle;
            
            treeViewDatos.Nodes["datos"].Nodes["suplidores"].Checked = Usuario.datos_suplidores;

            treeViewDatos.Nodes["datos"].Nodes["usuario"].Checked = Usuario.datos_usuario_;
            treeViewDatos.Nodes["datos"].Nodes["usuario"].Nodes["detalleUsuario"].Checked = Usuario.datos_usuario_detalle;
            treeViewDatos.Nodes["datos"].Nodes["usuario"].Nodes["permisoUsuarios"].Checked = Usuario.datos_usuario_permisos;
            
            treeViewDatos.Nodes["datos"].Nodes["ncf"].Checked = Usuario.datos_ncf;
            treeViewDatos.Nodes["datos"].Nodes["ncf"].Nodes["registroComprobantes"].Checked = Usuario.datos_registro_comprobante;
            treeViewDatos.Nodes["datos"].Nodes["ncf"].Nodes["reporte607"].Checked = Usuario.datos_reporte_607;

            treeViewFacturacion.Nodes["facturacion"].Checked = Usuario.facturacion_;
            treeViewFacturacion.Nodes["facturacion"].Nodes["facturacionNormal"].Checked = Usuario.facturacion_normal;
            treeViewFacturacion.Nodes["facturacion"].Nodes["devolucionVenta"].Checked = Usuario.facturacion_devolucion;
            treeViewFacturacion.Nodes["facturacion"].Nodes["cotizaciones"].Checked = Usuario.facturacion_cotizacion;
            treeViewFacturacion.Nodes["facturacion"].Nodes["cuadreCaja"].Checked = Usuario.facturacion_cuadre_caja;

            treeViewCxc.Nodes["cxc"].Checked = Usuario.cxc_;
            treeViewCxc.Nodes["cxc"].Nodes["reciboIngreso"].Checked = Usuario.cxc_reciboIngreso;

            treeViewCxp.Nodes["cxp"].Checked = Usuario.cxp_;
            treeViewCxp.Nodes["cxp"].Nodes["compra"].Checked = Usuario.cxp_compra;
            treeViewCxp.Nodes["cxp"].Nodes["devolucionCompra"].Checked = Usuario.cxp_devolucion;
            treeViewCxp.Nodes["cxp"].Nodes["reciboPago"].Checked = Usuario.cxp_pago;
            afterCheck = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Usuario.Id > 0)
            {
                nUsuario.EditarPermisos(Usuario);
                btnNuevo.PerformClick();
            }
            else
            {
                _ = MessageBox.Show("Debe elegir un Usuario Valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
