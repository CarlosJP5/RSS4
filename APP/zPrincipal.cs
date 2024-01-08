﻿using APP.Coneccion;
using Entidades;
using Negocios.NClasses;
using Negocios.NReportes;
using System;
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
            DateTime licenciaLock = DateTime.Parse("12/31/2040");
            NrptEmpresa lic = new NrptEmpresa();
            DateTime lisencia = lic.Licensia();
            if (licenciaLock != lisencia)
            {
                MessageBox.Show("Error de validacion.\nLa licencia del programa ha sido alterada.", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            if (lisencia < DateTime.Now)
            {
                MessageBox.Show("Licencia del programa vencida");
                Application.Exit();
            }
            FrmLogin frm = new FrmLogin();
            frm.ShowDialog();
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

        private void reporteDeCxCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEstadoDeCuenta frm = new FrmEstadoDeCuenta
            {
                MdiParent = this
            };
            frm.Show();
        }

        private void aperturaDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCaja_apertura frm = new FrmCaja_apertura
            {
                MdiParent = this
            };
            frm.Show();
        }

        private void cierreDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCaja_cierre frm = new FrmCaja_cierre
            {
                MdiParent = this
            };
            frm.Show();
        }
    }
}
