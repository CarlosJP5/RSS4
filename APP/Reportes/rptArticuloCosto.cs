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
    public partial class rptArticuloCosto : Form
    {
        public rptArticuloCosto()
        {
            InitializeComponent();
        }

        private void rptArticuloCosto_Load(object sender, EventArgs e)
        {
            NrptEmpresa nEmpresa = new NrptEmpresa();
            NrptArticulos nArticulos = new NrptArticulos();
            nEmpresa.LlenaEmpresa();
            nArticulos.CapitalInventario();
            erptEmpresaBindingSource.DataSource = nEmpresa.Empresa;
            eArticuloBindingSource.DataSource = nArticulos.Articulos;
            this.reportViewer1.RefreshReport();
        }
    }
}
