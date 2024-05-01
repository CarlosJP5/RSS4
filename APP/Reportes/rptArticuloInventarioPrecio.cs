using Negocios.NReportes;
using Negocios;
using System;
using System.Windows.Forms;

namespace APP.Reportes
{
    public partial class rptArticuloInventarioPrecio : Form
    {
        public rptArticuloInventarioPrecio()
        {
            InitializeComponent();
        }

        private void rptArticuloInventarioPrecio_Load(object sender, EventArgs e)
        {
            NrptEmpresa nEmpresa = new NrptEmpresa();
            NArticulos nArticulos = new NArticulos();
            _ = nEmpresa.LlenaEmpresa();
            nArticulos.Inventario();
            erptEmpresaBindingSource.DataSource = nEmpresa.Empresa;
            eArticuloBindingSource.DataSource = nArticulos.Articulos;
            reportViewer1.RefreshReport();
        }
    }
}
