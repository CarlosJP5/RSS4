using APP.Buscar;
using Negocios;
using System;
using System.Data;
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
            for (int i = 0; i < dgvListar.RowCount; i++)
            {
                DataRow row = detalle.NewRow();
                row[0] = dgvListar.Rows[i].Cells[0].Value.ToString();
                row[1] = dgvListar.Rows[i].Cells[1].Value.ToString();
                row[2]  = dgvListar.Rows[i].Cells[2].Value.ToString();
                row[3] = dgvListar.Rows[i].Cells[3].Value.ToString();
                row[4] = dgvListar.Rows[i].Cells[4].Value.ToString();
            }
        }
    }
}
