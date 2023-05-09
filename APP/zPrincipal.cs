using APP.Coneccion;
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

        private void HacerFactura(string idCliente, DateTime fechaFactura, string precio, string descripcion)
        {
            NComprobantes _comprobante = new NComprobantes();
            NClientes cliente = new NClientes();
            DataTable clienteDatos = cliente.BuscarId(idCliente);
            EServicio Factura = new EServicio()
            {
                Fecha = fechaFactura,
                IdCliente = int.Parse(idCliente),
                NombreCliente = clienteDatos.Rows[0][2].ToString(),
                Cedula = clienteDatos.Rows[0][3].ToString(),
                Rnc = clienteDatos.Rows[0][4].ToString(),
                IdComprobante = clienteDatos.Rows[0][1].ToString(),
                TipoCompra = "CREDITO",
                NombreComprobante = "Factura de Consumo",
                Importe = decimal.Parse(precio),
                Itbis = 0M,
                Total = decimal.Parse(precio)
            };
            DataTable Detalle = new DataTable();
            Detalle.Columns.Add("[descripcion]", typeof(string));
            Detalle.Columns.Add("[precio]", typeof(decimal));

            DataRow row = Detalle.NewRow();
            row[0] = descripcion;
            row[1] = Convert.ToDecimal(precio);
            Detalle.Rows.Add(row);

            // Insertar
            DataTable ListaComprobante = _comprobante.SumarCantidad(Factura.IdComprobante);
            if (ListaComprobante.Rows.Count > 0)
            {
                DateTime date = DateTime.Parse(ListaComprobante.Rows[0][5].ToString());
                if (date > Factura.Fecha)
                {
                    int numeroComprobante = Convert.ToInt32(ListaComprobante.Rows[0][4].ToString());
                    Factura.Ncf = Factura.IdComprobante + numeroComprobante.ToString("D8");
                    Factura.FechaVencimiento = date;
                }
                else
                {
                    _comprobante.Deshabilitar(ListaComprobante.Rows[0][0].ToString());
                    _ = MessageBox.Show("La Fecha del Comprobante se ha Vendido\nDebe Solicitar mas comprobantes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                _ = MessageBox.Show("No hay Comprobantes Disponibles\nDebe Solicitar mas comprobantes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _ = nservicio.Insertar(Factura, Detalle);
        }

        private readonly NServicio nservicio = new NServicio();

        private void zPrincipal_Load(object sender, EventArgs e)
        {
            //FrmLogin frm = new FrmLogin();
            //frm.ShowDialog();
            NServicio nservicio = new NServicio();
            NrptEmpresa _empresa = new NrptEmpresa();
            DataTable dt = _empresa.EmpresaDatos();
            DataTable ListadeFacturar = nservicio.ListarAutomatica();
            DateTime Fecha = DateTime.Parse(dt.Rows[0][7].ToString());
            if (Fecha < DateTime.Today)
            {
                while (Fecha <= DateTime.Today)
                {
                    foreach (DataRow dr in ListadeFacturar.Rows)
                    {
                        DateTime fechafactura = DateTime.Parse(dr[2].ToString());
                        if (fechafactura.Day == Fecha.Day)
                        {
                            HacerFactura(dr[1].ToString(), fechafactura, dr[4].ToString(), dr[3].ToString());
                        }
                    }
                    Fecha = Fecha.AddDays(1);
                }
                _empresa.FachaActualiza();
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

        private void facturaAutomaticaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FacturacionAutomatica frm = new FacturacionAutomatica
            {
                MdiParent = this
            };
            frm.Show();
        }
    }
}
