using APP.Buscar;
using Entidades;
using Negocios;
using System;
using System.Windows.Forms;

namespace APP
{
    public partial class FrmBancos : Form
    {
        private EBancos Banco = new EBancos();
        private readonly NBancos nbancos = new NBancos();
        public FrmBancos()
        {
            InitializeComponent();
        }

        private void FrmBancos_Load(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            errorNombre.Clear();
            txtNombre.Enabled = true;
            txtCodigo.Text = "";
            txtNombre.Text = "";

            btnModificar.Enabled = false;
            btnSalvar.Enabled = true;
            btnBuscar.Enabled = true;
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                _ = btnSalvar.Focus();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorNombre.SetError(txtNombre, "Nombre no puede tar vacio");
                return;
            }

            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                // Insertar
                nbancos.Insertar(txtNombre.Text);
            }
            else
            {
                // Editar
                nbancos.Editar(Convert.ToInt16(txtCodigo.Text), txtNombre.Text);
            }

            btnNuevo.PerformClick();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarBancos frm = new FrmBuscarBancos();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtCodigo.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                txtNombre.Text = frm.dgvListar.SelectedCells[1].Value.ToString();

                txtNombre.Enabled = false;
                btnSalvar.Enabled = false;
                btnModificar.Enabled = true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            txtNombre.Enabled = true;
            btnSalvar.Enabled = true;
            btnBuscar.Enabled = false;
            _ = txtNombre.Focus();
        }

        private void txtNombre_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            errorNombre.Clear();
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
