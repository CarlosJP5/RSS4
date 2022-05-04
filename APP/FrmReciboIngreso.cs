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
                _ = txtMonto.Focus();
            }
        }

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
                    _ = dgvListar.Rows.Add(balance.Rows[i][1], balance.Rows[i][17], d1.ToString("dd/MM/yyyy"),
                        (d2 - d1.Date).Days.ToString("N0"), balance.Rows[i][14], balance.Rows[i][3], "", "", "");
                }
            }
            CalculaTotal();
        }

        private void txtIdCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = txtMonto.Focus();
            }
        }

        private void txtIdCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMonto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = btnAplicar.Focus();
            }
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            CalculaTotal();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMonto.Text) && dgvListar.RowCount > 0)
            {
                decimal pago = Convert.ToDecimal(txtMonto.Text);
                for (int i = 0; i < dgvListar.RowCount; i++)
                {
                    decimal balance = Convert.ToDecimal(dgvListar.Rows[i].Cells[5].Value);
                    if (pago >= balance)
                    {
                        dgvListar.Rows[i].Cells[6].Value = balance;
                        dgvListar.Rows[i].Cells[7].Value = 0;
                        dgvListar.Rows[i].Cells[8].Value = "SALDO";
                        pago -= balance;
                    }
                    else
                    {
                        dgvListar.Rows[i].Cells[6].Value = pago;
                        dgvListar.Rows[i].Cells[7].Value = balance - pago;
                        dgvListar.Rows[i].Cells[8].Value = "ABONO";
                        pago = 0;
                    }
                    if (pago == 0)
                    {
                        break;
                    }
                }
                CalculaTotal();
            }
        }

        private void dgvListar_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListar.CurrentRow.Cells[6].Value != null)
            {
                if (double.TryParse(dgvListar.CurrentRow.Cells[6].Value.ToString(), out _))
                {
                    double pago = Convert.ToDouble(dgvListar.CurrentRow.Cells[6].Value);
                    if (pago > Convert.ToDouble(dgvListar.CurrentRow.Cells[5].Value))
                    {
                        pago = Convert.ToDouble(dgvListar.CurrentRow.Cells[5].Value);
                    }
                    dgvListar.CurrentRow.Cells[6].Value = pago.ToString("N2");
                    dgvListar.CurrentRow.Cells[7].Value = (Convert.ToDouble(dgvListar.CurrentRow.Cells[5].Value) - pago).ToString("N2");
                    dgvListar.CurrentRow.Cells[8].Value = Convert.ToDouble(dgvListar.CurrentRow.Cells[7].Value) == 0 ? "SALDO" : "ABONO";
                    if (pago == 0)
                    {
                        dgvListar.CurrentRow.Cells[6].Value = " ";
                        dgvListar.CurrentRow.Cells[7].Value = " ";
                        dgvListar.CurrentRow.Cells[8].Value = " ";
                    }
                }
            }
            else
            {
                dgvListar.CurrentRow.Cells[6].Value = " ";
                dgvListar.CurrentRow.Cells[7].Value = " ";
                dgvListar.CurrentRow.Cells[8].Value = " ";
            }
            CalculaTotal();
        }

        private void CalculaTotal()
        {
            double monto = 0;
            double pago = 0;
            decimal balance = 0m;
            for (int i = 0; i < dgvListar.RowCount; i++)
            {
                balance += Convert.ToDecimal(dgvListar.Rows[i].Cells[5].Value);
                if (dgvListar.CurrentRow.Cells[6].Value != null)
                {
                    if (double.TryParse(dgvListar.Rows[i].Cells[6].Value.ToString(), out _))
                    {
                        monto += Convert.ToDouble(dgvListar.Rows[i].Cells[6].Value);
                    }
                    else
                    {
                        dgvListar.Rows[i].Cells[6].Value = " ";
                        dgvListar.Rows[i].Cells[7].Value = " ";
                        dgvListar.Rows[i].Cells[8].Value = " ";
                    }
                }
            }
            txtPago.Text = monto.ToString("N2");
            if (!string.IsNullOrEmpty(txtMonto.Text))
            {
                pago = Convert.ToDouble(txtMonto.Text);
            }
            txtDiferencia.Text = (monto - pago).ToString("N2");
            txtBalance.Text = balance.ToString("N2");
        }

        private void dgvListar_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(txtMonto_KeyPress);
            if (dgvListar.CurrentCell.ColumnIndex == 6) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(txtMonto_KeyPress);
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (dgvListar.RowCount <= 0)
            {
                _ = MessageBox.Show("Este Cliente no Posee Factura Pendiente", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!string.IsNullOrEmpty(txtIdCliente.Text) && !string.IsNullOrEmpty(txtNombre.Text)
                && !string.IsNullOrEmpty(txtMonto.Text) && dgvListar.RowCount > 0 && txtDiferencia.Text == "0.00")
            {
                DataTable detalleRecibo = new DataTable();
                detalleRecibo.Columns.Add("idFactura", typeof(int));
                detalleRecibo.Columns.Add("pago", typeof(decimal));
                detalleRecibo.Columns.Add("estado", typeof(string));
                for (int i = 0; i < dgvListar.RowCount; i++)
                {
                    bool tryy = double.TryParse(dgvListar.Rows[i].Cells[6].Value.ToString(), out _);
                    if (tryy)
                    {
                        DataRow row = detalleRecibo.NewRow();
                        row[0] = (int)dgvListar.Rows[i].Cells[0].Value;
                        row[1] = Convert.ToDouble(dgvListar.Rows[i].Cells[6].Value);
                        row[2] = dgvListar.Rows[i].Cells[8].Value.ToString();
                        detalleRecibo.Rows.Add(row);
                    }
                }
                NReciboIngreso _recibo = new NReciboIngreso();
                _ = _recibo.Insertar(txtIdCliente.Text, dtpFecha.Value, detalleRecibo);
                btnNuevo.PerformClick();
            }
        }
    }
}
