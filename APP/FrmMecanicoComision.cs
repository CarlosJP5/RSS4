using APP.Buscar;
using Negocios;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace APP
{
    public partial class FrmMecanicoComision : Form
    {
        public FrmMecanicoComision()
        {
            InitializeComponent();
        }

        private readonly NMecanico nMecanico = new NMecanico();

        private void FrmMecanicoComision_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today.AddHours(23.99999);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBuscarMecanico frm = new FrmBuscarMecanico();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                idMecanicoTxt.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                nombreMecanicoTxt.Text = frm.dgvListar.SelectedCells[1].Value.ToString();
            }
        }

        private void idMecanicoTxt_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(idMecanicoTxt.Text, out int idMecanico))
            {
                DataTable dt = nMecanico.Buscar(idMecanico);
                if (dt.Rows.Count > 0)
                {
                    idMecanicoTxt.Text = dt.Rows[0][0].ToString();
                    nombreMecanicoTxt.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    idMecanicoTxt.Text = "";
                    nombreMecanicoTxt.Text = "";
                }
            }
        }

        private void idMecanicoTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                _ = btnBuscar.Focus();
            }
        }

        private void idMecanicoTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (int.TryParse(idMecanicoTxt.Text, out int idMecanico))
            {
                double total = 0;
                DataTable comisionData = nMecanico.Comision(idMecanico, dtpDesde.Value, dtpHasta.Value);
                foreach (DataRow row in comisionData.Rows)
                {
                    DateTime fecha = DateTime.Parse(row[1].ToString());
                    double venta = double.Parse(row[3].ToString());
                    double comision = double.Parse(row[4].ToString()) / 100;
                    double pago = venta * comision;
                    total += pago;
                    dataGridView1.Rows.Add(row[0], fecha.ToString("dd/MM/yyyy"), row[2], row[3], pago);
                }
                totalComisionTxt.Text = total.ToString("n2");
            }
            else
            {
                _ = MessageBox.Show("Debe elegir un Mecanico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
