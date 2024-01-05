using Negocios.NReportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP.Reportes
{
    public partial class rptDevolucionesFact : Form
    {
        int IdDevolucion;

        public rptDevolucionesFact(int idDevolucion)
        {
            InitializeComponent();
            IdDevolucion = idDevolucion;
        }

        private void rptDevolucionesFact_Load(object sender, EventArgs e)
        {
            NrptEmpresa nEmpresa = new NrptEmpresa();
            NrptFactura nrptFactura = new NrptFactura();
            nEmpresa.LlenaEmpresa();
            nrptFactura.FactuasDevolucion(IdDevolucion);
            erptEmpresaBindingSource.DataSource = nEmpresa.Empresa;
            erptFacturaBindingSource.DataSource = nrptFactura.Factura;
            erptFacturaDetalleBindingSource.DataSource = nrptFactura.FacturaDetalles;
            this.reportViewer1.RefreshReport();
        }
    }
}
