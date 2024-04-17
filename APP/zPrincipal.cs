using APP.Reportes;
using Entidades;
using Negocios;
using Negocios.NClasses;
using Negocios.NReportes;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP
{
    public partial class zPrincipal : Form
    {
        public zPrincipal()
        {
            InitializeComponent();
            ControlBox = false;
            NAppSetting setting = new NAppSetting();
            zConexion.CadenaConexion = setting.GetConnectionString("cn");
        }

        private void zPrincipal_Load(object sender, EventArgs e)
        {
            DateTime licenciaLock = DateTime.Parse("12/31/2024");
            NrptEmpresa lic = new NrptEmpresa();
            DateTime lisencia = lic.lisencia();
            if (licenciaLock != lisencia)
            {
                MessageBox.Show("Error de validacion.\nLa licencia del programa ha sido alterada.", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            if (lisencia < DateTime.Now)
            {
                MessageBox.Show("Licencia del programa vencida");
                return;
            }
            FrmLogin frm = new FrmLogin();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                NUsuario nUsuario = new NUsuario();
                DataTable usuarioPermiso = nUsuario.ListaPermisos((int)frm.usuario.Rows[0][0]);
                datosToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][1];
                articulosToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][2];
                detalleArticulosToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][3];
                marcasToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][4];
                ajusteInventarioToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][5];
                cambiarCodigoToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][6];
                itbisDelArticuloToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][7];
                reporteInventarioCostoToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][8];
                clientesToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][9];
                detalleClientesToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][10];
                suplidoresToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][11];
                usuariosToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][12];
                detalleUsuarioToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][13];
                permisoUsuarioToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][14];
                nCFToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][15];
                registroComprobantesToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][16];
                reporteVentas607ToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][17];
                facturacionToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][18];
                facturacionNormalToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][19];
                devolucionSVentaToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][20];
                cotizacionesToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][21];
                cuadreCajaToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][22];
                cxCToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][23];
                reciboIngresoToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][24];
                cxPToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][25];
                compraToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][26];
                devolucionSCompraToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][27];
                reciboDePagoToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][28];
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult msj = MessageBox.Show("Desea Salir del sistema", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msj == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void detalleArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmArticulos frm = new FrmArticulos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmArticulosMarcas frm = new FrmArticulosMarcas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void itbisDelArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmArticulosItbis frm = new FrmArticulosItbis();
            frm.MdiParent = this;
            frm.Show();
        }

        private void detalleClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientes frm = new FrmClientes();
            frm.MdiParent = this;
            frm.Show();
        }

        private void suplidoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSuplidores frm = new FrmSuplidores();
            frm.MdiParent = this;
            frm.Show();
        }

        private void registroComprobantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistroComprobante frm = new FrmRegistroComprobante();
            frm.MdiParent = this;
            frm.Show();
        }

        private void facturacionNormalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFacturacion frm = new FrmFacturacion();
            frm.MdiParent = this;
            frm.Show();
        }

        private void compraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCompra frm = new FrmCompra();
            frm.MdiParent = this;
            frm.Show();
        }

        private void devolucionSVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFacturaDevolucion frm = new FrmFacturaDevolucion();
            frm.MdiParent = this;
            frm.Show();
        }

        private void reciboIngresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReciboIngreso frm = new FrmReciboIngreso();
            frm.MdiParent = this;
            frm.Show();
        }

        private void reciboDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReciboPago frm = new FrmReciboPago();
            frm.MdiParent = this;
            frm.Show();
        }

        private void reporteVentas607ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReporteComprobantes607 frm = new FrmReporteComprobantes607();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cuadreCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCuadreCaja frm = new FrmCuadreCaja();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ajusteInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmArticulosAjusteInventario frm = new FrmArticulosAjusteInventario();
            frm.MdiParent = this;
            frm.Show();
        }

        private void devolucionSCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCompraDevolucion frm = new FrmCompraDevolucion();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cambiarCodigoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmArticulosCambiarCodigo frm = new FrmArticulosCambiarCodigo();
            frm.MdiParent = this;
            frm.Show();
        }

        private void listaDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListaCompra frm = new FrmListaCompra();
            frm.MdiParent = this;
            frm.Show();
        }

        private void detalleUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuarios frm = new FrmUsuarios();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cotizacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCotizacion frm = new FrmCotizacion();
            frm.MdiParent = this;
            frm.Show();
        }

        private void facturarServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFacturaServicio frm = new FrmFacturaServicio();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cotizacionServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCotizacionServicio frm = new FrmCotizacionServicio();
            frm.MdiParent = this;
            frm.Show();
        }

        private void reciboIngresoServToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReciboIngresoServicio frm = new FrmReciboIngresoServicio
            {
                MdiParent = this
            };
            frm.Show();
        }

        private void reporteInventarioCostoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptArticuloCosto frm = new rptArticuloCosto
            {
                MdiParent = this
            };
            frm.Show();
        }

        private void permisoUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuarioPermiso frm = new FrmUsuarioPermiso
            {
                MdiParent = this
            };
            frm.Show();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            datosToolStripMenuItem.Enabled = false;
            facturacionToolStripMenuItem.Enabled = false;
            cxCToolStripMenuItem.Enabled = false;
            cxPToolStripMenuItem.Enabled = false;

            FrmLogin frm = new FrmLogin();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                NUsuario nUsuario = new NUsuario();
                DataTable usuarioPermiso = nUsuario.ListaPermisos((int)frm.usuario.Rows[0][0]);
                datosToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][1];
                articulosToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][2];
                detalleArticulosToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][3];
                marcasToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][4];
                ajusteInventarioToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][5];
                cambiarCodigoToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][6];
                itbisDelArticuloToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][7];
                reporteInventarioCostoToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][8];
                clientesToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][9];
                detalleClientesToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][10];
                suplidoresToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][11];
                usuariosToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][12];
                detalleUsuarioToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][13];
                permisoUsuarioToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][14];
                nCFToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][15];
                registroComprobantesToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][16];
                reporteVentas607ToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][17];
                facturacionToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][18];
                facturacionNormalToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][19];
                devolucionSVentaToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][20];
                cotizacionesToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][21];
                cuadreCajaToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][22];
                cxCToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][23];
                reciboIngresoToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][24];
                cxPToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][25];
                compraToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][26];
                devolucionSCompraToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][27];
                reciboDePagoToolStripMenuItem.Enabled = (bool)usuarioPermiso.Rows[0][28];
            }
        }
    }
}
