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
    public partial class rptEstadoDeCuenta : Form
    {
        private DataTable Detalle = new DataTable();
        private string IdCliente;

        public rptEstadoDeCuenta(DataTable detalle, string idCliente)
        {
            InitializeComponent();
            Detalle = detalle;
            IdCliente = idCliente;
        }

        private void rptEstadoDeCuenta_Load(object sender, EventArgs e)
        {
            NrptEmpresa nEmpresa = new NrptEmpresa();
            nEmpresa.LlenaEmpresa();
            nEmpresa.EstadoCuenta(Detalle);
            nEmpresa.Cliente(IdCliente);
            erptEmpresaBindingSource.DataSource = nEmpresa.Empresa;
            eClienteBindingSource.DataSource = nEmpresa.Clientes;
            erptEstadoCuentaBindingSource.DataSource = nEmpresa.EstadoCuentas;
            this.reportViewer1.RefreshReport();
        }
    }
}
