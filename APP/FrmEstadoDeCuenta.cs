using APP.Buscar;
using APP.Reportes;
using Negocios;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace APP
{
    public partial class FrmEstadoDeCuenta : Form
    {
        public FrmEstadoDeCuenta()
        {
            InitializeComponent();
        }

        private readonly NClientes _cliente = new NClientes();

        private void LlenarDGV(string IdCliente)
        {
            dgvListar.Rows.Clear();
            DataTable balance = _cliente.BalancePendiente(IdCliente);
            if (balance.Rows.Count > 0)
            {
                DateTime d2 = DateTime.Now.Date;
                for (int i = 0; i < balance.Rows.Count; i++)
                {
                    DateTime d1 = DateTime.Parse(balance.Rows[i][8].ToString());

                    _ = dgvListar.Rows.Add(balance.Rows[i][1], balance.Rows[i][18], d1.ToString("dd/MM/yyyy"),
                        (d2 - d1.Date).Days.ToString("N0"), balance.Rows[i][3]);
                }
            }
            DataTable balance2 = _cliente.BalancePendienteServicio(IdCliente);
            if (balance2.Rows.Count > 0)
            {
                DateTime d2 = DateTime.Now.Date;
                for (int i = 0; i < balance2.Rows.Count; i++)
                {
                    DateTime d1 = DateTime.Parse(balance2.Rows[i][2].ToString());
                    _ = dgvListar.Rows.Add(balance2.Rows[i][0], balance2.Rows[i][1], d1.ToString("dd/MM/yyyy"),
                        (d2 - d1.Date).Days.ToString("N0"), balance2.Rows[i][4]);
                }
            }
            double total = 0;
            for (int i = 0; i < dgvListar.RowCount; i++)
            {
                total += Convert.ToDouble(dgvListar.Rows[i].Cells[4].Value);
            }
            txtTotal.Text = total.ToString("N2");
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

        private void FrmEstadoDeCuenta_Load(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtIdCliente.Text = "";
            txtNombre.Text = "";
            txtTotal.Text = "";
            dgvListar.Rows.Clear();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DataTable detalle = new DataTable();
            detalle.Columns.Add("ID", typeof(string));
            detalle.Columns.Add("Ncf", typeof(string));
            detalle.Columns.Add("fecha", typeof(DateTime));
            detalle.Columns.Add("dias", typeof(int));
            detalle.Columns.Add("balance", typeof(double));
            detalle.Columns.Add("total", typeof(double));
            for (int i = 0; i < dgvListar.RowCount; i++)
            {
                DataRow row = detalle.NewRow();
                row[0] = dgvListar.Rows[i].Cells[0].Value.ToString();
                row[1] = dgvListar.Rows[i].Cells[1].Value.ToString();
                row[2] = DateTime.ParseExact(dgvListar.Rows[i].Cells[2].Value.ToString().Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                row[3] = Convert.ToInt16(dgvListar.Rows[i].Cells[3].Value);
                row[4] = Convert.ToDouble(dgvListar.Rows[i].Cells[4].Value);
                row[5] = Convert.ToDouble(txtTotal.Text);
                detalle.Rows.Add(row);
            }
            rptEstadoDeCuenta frm = new rptEstadoDeCuenta(detalle, txtIdCliente.Text);
            _ = frm.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult msj = MessageBox.Show("Desea Salir", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msj == DialogResult.Yes)
            {
                Close();
            }
        }

        private void txtIdCliente_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void txtIdCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                _ = dgvListar.Focus();
            }
        }

        private void txtIdCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
