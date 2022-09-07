using APP.Buscar;
using Entidades;
using Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP
{
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private readonly NUsuario nUsuario = new NUsuario();
        private bool editar = false;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                btnBuscar.PerformClick();
            }
            if (keyData == Keys.F4)
            {
                btnEditar.PerformClick();
            }
            if (keyData == Keys.F5)
            {
                btnGuardar.PerformClick();
            }
            if (keyData == Keys.F9)
            {
                btnNuevo.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            btnNuevo.PerformClick();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = nUsuario.MaxId();
            Habilitar();
            editar = false;
            txtNombre.Text = string.Empty;
            errorNombre.Clear();
            txtUsuario.Enabled = true;
            txtUsuario.Text = string.Empty;
            errorUsuario.Clear();
            txtCedula.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtClave.Text = string.Empty;
            errorClave.Clear();
            txtClaveConfirma.Text = string.Empty;
            errorConfirmaClave.Clear();
            cboEstado.SelectedIndex = 0;
            txtFechaIngreso.Text = DateTime.Now.ToString("dd / MM / yyyy");
            btnGuardar.Enabled = true;
            btnBuscar.Enabled = true;
            btnEditar.Enabled = false;
            txtUsuario.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                errorUsuario.SetError(txtUsuario, "Campo Obligatorio");
                return;
            }
            else
            {
                if (!editar)
                {
                    DataTable table = nUsuario.Login(txtUsuario.Text);
                    if (table.Rows.Count > 0)
                    {
                        errorUsuario.SetError(txtUsuario, "Usuario ya Existe");
                        return;
                    }
                }
            }
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorNombre.SetError(txtNombre, "Campo Obligatorio");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtClave.Text))
            {
                errorClave.SetError(txtClave, "Campo Obligatorio");
                return;
            }
            if (txtClave.Text != txtClaveConfirma.Text)
            {
                errorConfirmaClave.SetError(txtClaveConfirma, "Clave Diferente");
                return;
            }
            EUsuario usuario = new EUsuario
            {
                Usuario = txtUsuario.Text,
                Nombre = txtNombre.Text,
                Cedula = txtCedula.Text,
                Direccion = txtDireccion.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text,
                FechaIngreso = DateTime.Now,
                Clave = txtClave.Text,
                Estado = cboEstado.SelectedIndex == 0,
            };
            if (!editar)
            {
                nUsuario.Insertar(usuario);
            }
            else
            {
                usuario.Id = Convert.ToInt32(txtCodigo.Text);
                nUsuario.Editar(usuario);
            }
            btnNuevo.PerformClick();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarUsuarios frm = new FrmBuscarUsuarios();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtCodigo.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                txtUsuario.Text = frm.dgvListar.SelectedCells[1].Value.ToString();
                txtNombre.Text = frm.dgvListar.SelectedCells[2].Value.ToString();
                txtCedula.Text = frm.dgvListar.SelectedCells[3].Value.ToString();
                txtDireccion.Text = frm.dgvListar.SelectedCells[4].Value.ToString();
                txtTelefono.Text = frm.dgvListar.SelectedCells[5].Value.ToString();
                txtCorreo.Text = frm.dgvListar.SelectedCells[6].Value.ToString();
                txtFechaIngreso.Text = DateTime.Parse(frm.dgvListar.SelectedCells[7].Value.ToString()).ToString("dd / MM / yyyy");
                txtClave.Text = frm.dgvListar.SelectedCells[8].Value.ToString();
                txtClaveConfirma.Text = txtClave.Text;
                cboEstado.SelectedIndex = (bool)frm.dgvListar.SelectedCells[9].Visible ? 0 : 1;

                txtUsuario.Enabled = false;
                txtNombre.Enabled = false;
                txtCedula.Enabled = false;
                txtDireccion.Enabled = false;
                txtTelefono.Enabled = false;
                txtCorreo.Enabled = false;
                txtClave.Enabled = false;
                txtClaveConfirma.Enabled = false;
                cboEstado.Enabled = false;
                btnEditar.Enabled = true;
                btnGuardar.Enabled = false;
            }
        }

        private void Habilitar()
        {
            txtNombre.Enabled = true;
            txtCedula.Enabled = true;
            txtDireccion.Enabled = true;
            txtTelefono.Enabled = true;
            txtCorreo.Enabled = true;
            txtClave.Enabled = true;
            txtClaveConfirma.Enabled = true;
            cboEstado.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text) && txtCodigo.Text == "0")
            {
                MessageBox.Show("Este usuario no puede ser modificado");
                return;
            }
            editar = true;
            Habilitar();
            btnBuscar.Enabled = false;
            btnGuardar.Enabled = true;
            btnBuscar.Enabled = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult msj = MessageBox.Show("Desea Salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msj == DialogResult.Yes)
            {
                Close();
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtNombre.Focus();
            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtCedula.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                txtUsuario.Focus();
            }
        }

        private void txtCedula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtDireccion.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                txtNombre.Focus();
            }
        }

        private void txtDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtCorreo.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                txtCedula.Focus();
            }
        }

        private void txtCorreo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtTelefono.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                txtDireccion.Focus();
            }
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtClave.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                txtCorreo.Focus();
            }
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtClaveConfirma.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                txtTelefono.Focus();
            }
        }

        private void txtClaveConfirma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                cboEstado.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                txtClave.Focus();
            }
        }

        private void cboEstado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnGuardar.Focus();
            }
        }
    }
}
