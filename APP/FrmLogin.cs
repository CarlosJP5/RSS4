using Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP
{
    public partial class FrmLogin : Form
    {
        public DataTable usuario = new DataTable();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private readonly NUsuario nUsuario = new NUsuario();

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            usuario = nUsuario.Login(txtUsuario.Text);
            if (usuario.Rows.Count > 0)
            {
                if (txtClave.Text == usuario.Rows[0][8].ToString())
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Clave Incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Usuario Incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtClave.Focus();
            }
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnIniciar.PerformClick();
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //DateTime hoy = DateTime.Now;
            //DateTime vence = DateTime.Parse("06/09/2022");
            //int dias = Convert.ToInt16((hoy - vence).Days.ToString());
            //lblPrueba.Text = string.Format("Dias de Prueba {0}", dias);
            //if (dias > 31)
            //{
            //    MessageBox.Show("Periodo de Prueba Terminado\nContactar al Ingeniero", "Prueba", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    Application.Exit();
            //}
        }
    }
}
