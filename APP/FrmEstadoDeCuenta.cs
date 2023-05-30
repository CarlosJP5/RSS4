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
    public partial class FrmEstadoDeCuenta : Form
    {
        public FrmEstadoDeCuenta()
        {
            InitializeComponent();
        }

        private readonly NClientes _cliente = new NClientes();
        private readonly NReciboIngreso _recibo = new NReciboIngreso();

        //private void CalculaTotal()
        //{
        //    double monto = 0;
        //    double pago = 0;
        //    decimal balance = 0m;
        //    for (int i = 0; i < dgvListar.RowCount; i++)
        //    {
        //        balance += Convert.ToDecimal(dgvListar.Rows[i].Cells[5].Value);
        //        if (dgvListar.CurrentRow.Cells[6].Value != null)
        //        {
        //            if (double.TryParse(dgvListar.Rows[i].Cells[6].Value.ToString(), out _))
        //            {
        //                monto += Convert.ToDouble(dgvListar.Rows[i].Cells[6].Value);
        //            }
        //            else
        //            {
        //                dgvListar.Rows[i].Cells[6].Value = " ";
        //                dgvListar.Rows[i].Cells[7].Value = " ";
        //                dgvListar.Rows[i].Cells[8].Value = " ";
        //            }
        //        }
        //    }
        //    txtPago.Text = monto.ToString("N2");
        //    if (!string.IsNullOrEmpty(txtMonto.Text))
        //    {
        //        pago = Convert.ToDouble(txtMonto.Text);
        //    }
        //    txtDiferencia.Text = (monto - pago).ToString("N2");
        //    txtBalance.Text = balance.ToString("N2");
        //}

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
            //CalculaTotal();
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
    }
}
