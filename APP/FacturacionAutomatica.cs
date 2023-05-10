using APP.Buscar;
using Negocios;
using System;
using System.ComponentModel;
using System.Data;
using System.Globalization;
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

            if (string.IsNullOrEmpty(txtIdFacturaAutomatica.Text))
            {
                nservicio.InsertarFacturaAutomatica(txtIdCliente.Text, dtpFecha.Value, txtDescripcion.Text, precio);
            }
            else
            {
                nservicio.EditarFacturaAutomatica(txtIdFacturaAutomatica.Text, txtIdCliente.Text, dtpFecha.Value, txtDescripcion.Text, precio);
            }

            btnNuevo.PerformClick();
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
            txtIdFacturaAutomatica.Text = null;
            txtIdCliente.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            dtpFecha.Value = DateTime.Now;

            btnBuscarClientes.Enabled = true;
            txtIdCliente.Enabled = true;
            txtNombre.Enabled = true;
            dtpFecha.Enabled = true;
            txtDescripcion.Enabled = true;
            txtPrecio.Enabled = true;

            btnSalvar.Enabled = true;
            btnBuscar.Enabled = true;
            btnModificar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarFacturaAutomatica frm = new FrmBuscarFacturaAutomatica();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtIdFacturaAutomatica.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                txtIdCliente.Text = frm.dgvListar.SelectedCells[1].Value.ToString();
                txtNombre.Text = frm.dgvListar.SelectedCells[2].Value.ToString();
                dtpFecha.Value = DateTime.ParseExact(frm.dgvListar.SelectedCells[5].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                txtDescripcion.Text = frm.dgvListar.SelectedCells[3].Value.ToString();
                txtPrecio.Text = frm.dgvListar.SelectedCells[4].Value.ToString();

                btnBuscarClientes.Enabled = false;
                txtIdCliente.Enabled = false;
                txtNombre.Enabled = false;
                dtpFecha.Enabled = false;
                txtDescripcion.Enabled = false;
                txtPrecio.Enabled = false;
                btnSalvar.Enabled = false;
                btnModificar.Enabled = true;
                btnCancelar.Enabled = true;
            }
        }

        private void FacturacionAutomatica_Load(object sender, EventArgs e)
        {
            txtIdFacturaAutomatica.Text = null;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            btnBuscarClientes.Enabled = true;
            txtIdCliente.Enabled = true;
            txtNombre.Enabled = true;
            dtpFecha.Enabled = true;
            txtDescripcion.Enabled = true;
            txtPrecio.Enabled = true;
            btnSalvar.Enabled = true;
            btnBuscar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void txtIdCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                _ = txtNombre.Focus();
            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                _ = dtpFecha.Focus();
            }
        }

        private void dtpFecha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                _ = txtDescripcion.Focus();
            }
        }

        private void txtPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                _ = btnSalvar.Focus();
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdFacturaAutomatica.Text))
            {
                DialogResult msj = MessageBox.Show($"Seguro desea cancelar la suscripción de:\n {txtNombre.Text} \n {txtDescripcion.Text} - {txtPrecio.Text}", "Canselar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msj == DialogResult.Yes)
                {
                    nservicio.CancelarFacturaAutomatica(txtIdFacturaAutomatica.Text);
                    btnNuevo.PerformClick();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult msj = MessageBox.Show("Desea Salir", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msj == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
