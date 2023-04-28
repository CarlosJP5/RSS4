using APP.Buscar;
using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP
{
    public partial class FacturacionAutomatica : Form
    {
        public FacturacionAutomatica()
        {
            InitializeComponent();
        }

        private readonly NServicio nservicio = new NServicio();
        private readonly NClientes _cliente = new NClientes();

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            decimal precio = 0m;
            if (decimal.TryParse(txtPrecio.Text, out _))
            {
                precio = Convert.ToDecimal(txtPrecio.Text);
            }
            else
            {
                return;
            }
            nservicio.InsertarFacturaAutomatica(txtIdCliente.Text, dtpFecha.Value, txtDescripcion.Text, precio);
        }

        private void txtIdCliente_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdCliente.Text))
            {
                DataTable cliente = _cliente.BuscarId(txtIdCliente.Text);
                if (cliente.Rows.Count > 0)
                {
                    txtNombre.Text = cliente.Rows[0][2].ToString();
                }
                else
                {
                    txtNombre.Text = "";
                }
            }
        }

        private void btnBuscarClientes_Click(object sender, EventArgs e)
        {
            FrmBuscarClientes frm = new FrmBuscarClientes();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtIdCliente.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                txtNombre.Text = frm.dgvListar.SelectedCells[2].Value.ToString();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtIdCliente.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            dtpFecha.Value = DateTime.Now;
        }
    }
}
