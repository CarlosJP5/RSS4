using APP.Buscar;
using Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP
{
    public partial class FrmReciboIngreso : Form
    {
        public FrmReciboIngreso()
        {
            InitializeComponent();
        }

        private readonly NClientes _cliente = new NClientes();

        private void FrmReciboIngreso_Load(object sender, EventArgs e)
        {
            btnNuevo.PerformClick();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtIdCliente.Text = null;
            txtNombre.Text = null;
            dtpFecha.Value = DateTime.Now;
            txtMonto.Text = null;
            txtBalance.Text = null;
            txtPago.Text = null;
            txtDiferencia.Text = null;
            dgvListar.Rows.Clear();

            btnImprimir.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = false;
        }

        private void txtIdCliente_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdCliente.Text))
            {                
                DataTable cliente = _cliente.BuscarId(txtIdCliente.Text);
                if (cliente.Rows.Count > 0)
                {
                    txtNombre.Text = cliente.Rows[0][2].ToString();
                    LlenarDGV(txtIdCliente.Text);
                }
                else
                {
                    txtNombre.Text = null;
                }
                
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmBuscarClientes frm = new FrmBuscarClientes();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtIdCliente.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                txtNombre.Text = frm.dgvListar.SelectedCells[2].Value.ToString();
                LlenarDGV(txtIdCliente.Text);
            }
        }

        private void LlenarDGV(string IdCliente)
        {
            dgvListar.Rows.Clear();
            DataTable balance = _cliente.BalancePendiente(IdCliente);
            if (balance.Rows.Count > 0)
            {
                DateTime d2 = DateTime.Now;
                for (int i = 0; i < balance.Rows.Count; i++)
                {
                    DateTime d1 = DateTime.Parse(balance.Rows[i][8].ToString());
                    _ = dgvListar.Rows.Add(balance.Rows[i][1], balance.Rows[i][17], d1.ToString("dd/MM/yyyy"),
                        (d2 - d1).Days.ToString("N0"), balance.Rows[i][14], balance.Rows[i][3]);
                }
            }
        }
    }
}
