using Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP.Buscar
{
    public partial class FrmBuscarFacturaServicio : Form
    {
        public FrmBuscarFacturaServicio()
        {
            InitializeComponent();
        }

        private readonly NServicio nservicio = new NServicio();

        private void FrmBuscarFacturaServicio_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today.AddHours(23.99999);
            DataTable dt = nservicio.Buscar(dtpDesde.Value, dtpHasta.Value);
            foreach (DataRow row in dt.Rows)
            {
                DateTime fecha = DateTime.Parse(row[1].ToString());
                _ = dgvListar.Rows.Add(row[0], fecha.ToString("dd/MM/yyy  hh:mm tt"), row[2], row[3], row[4]);
            }
        }

        private void linkCliente_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBuscarClientes frm = new FrmBuscarClientes();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtIdCliente.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                txtNombre.Text = frm.dgvListar.SelectedCells[2].Value.ToString();
            }
            else
            {
                txtIdCliente.Text = null;
                txtNombre.Text = null;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvListar.Rows.Clear();
            DataTable dt = new DataTable();
            if (!string.IsNullOrWhiteSpace(txtIdFactura.Text))
            {
                dt = nservicio.Buscar_idFactura(txtIdFactura.Text);
            }
            else if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                dt = nservicio.Buscar_cliente(dtpDesde.Value, dtpHasta.Value, txtIdCliente.Text);
            }
            else
            {
                dt = nservicio.Buscar(dtpDesde.Value, dtpHasta.Value);
            }
            foreach (DataRow row in dt.Rows)
            {
                DateTime fecha = DateTime.Parse(row[1].ToString());
                _ = dgvListar.Rows.Add(row[0], fecha.ToString("dd/MM/yyy  hh:mm tt"), row[2], row[3], row[4]);
            }
        }

        private void txtIdCliente_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdCliente.Text))
            {
                NClientes cliente = new NClientes();
                DataTable table = cliente.BuscarId(txtIdCliente.Text);
                if (table.Rows.Count > 0)
                {
                    txtNombre.Text = table.Rows[0][2].ToString();
                }
                else
                {
                    txtIdCliente.Text = null;
                    txtNombre.Text = null;
                }
            }
            else
            {
                txtIdCliente.Text = null;
                txtNombre.Text = null;
            }
        }

        private void dgvListar_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvListar.Rows.Count > 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dgvListar.CurrentRow.Selected = true;
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void dgvListar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListar.Rows.Count > 0)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvListar.Rows.Count > 0)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void txtIdFactura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                btnBuscar.PerformClick();
            }
        }
    }
}
