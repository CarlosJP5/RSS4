using Entidades;
using System;
using System.Windows.Forms;

namespace APP
{
    public partial class FrmBancos : Form
    {
        private EBancos Banco = new EBancos();

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
            txtCodigo.Text = "";
            txtNombre.Text = "";
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                _ = btnNuevo.Focus();
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
            }
            else
            {
                // Editar
            }
        }
    }
}
