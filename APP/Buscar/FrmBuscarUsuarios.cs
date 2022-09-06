using Negocios;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace APP.Buscar
{
    public partial class FrmBuscarUsuarios : Form
    {
        public FrmBuscarUsuarios()
        {
            InitializeComponent();
        }

        private readonly NUsuario nUsuario = new NUsuario();

        private void Ordenar()
        {
            if (dgvListar.RowCount > 0)
            {
                for (int i = 0; i < dgvListar.RowCount; i++)
                {
                    if (i % 2 == 0)
                    {
                        dgvListar.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(220, 255, 255);
                    }
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
            if (!txtBuscar.Focused)
            {
                if (keyData == Keys.NumPad0 || keyData == Keys.NumPad1 || keyData == Keys.NumPad2 || keyData == Keys.NumPad3 ||
                    keyData == Keys.NumPad4 || keyData == Keys.NumPad5 || keyData == Keys.NumPad6 || keyData == Keys.NumPad7 ||
                    keyData == Keys.NumPad8 || keyData == Keys.NumPad9 || keyData == Keys.Q || keyData == Keys.W ||
                    keyData == Keys.E || keyData == Keys.R || keyData == Keys.T || keyData == Keys.Y ||
                    keyData == Keys.U || keyData == Keys.I || keyData == Keys.O || keyData == Keys.P ||
                    keyData == Keys.A || keyData == Keys.S || keyData == Keys.D || keyData == Keys.F ||
                    keyData == Keys.K || keyData == Keys.J || keyData == Keys.H || keyData == Keys.G ||
                    keyData == Keys.L || keyData == Keys.Z || keyData == Keys.X || keyData == Keys.C ||
                    keyData == Keys.M || keyData == Keys.N || keyData == Keys.B || keyData == Keys.V)
                {
                    txtBuscar.Focus();
                    txtBuscar.Text = keyData.ToString();
                }
                if (keyData >= Keys.D0 && keyData <= Keys.D9)
                {
                    txtBuscar.Focus();
                    txtBuscar.Text = keyData.ToString();
                }
                if (keyData == Keys.Back || keyData == Keys.Space)
                {
                    txtBuscar.Focus();
                }
                txtBuscar.SelectionStart = txtBuscar.Text.Length;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void FrmBuscarUsuarios_Load(object sender, EventArgs e)
        {
            rbtnTodo.Checked = true;
            DataTable table = nUsuario.Buscar("usuario_buscar", txtBuscar.Text);
            foreach (DataRow row in table.Rows)
            {
                dgvListar.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5],
                    row[6], row[7], row[8], row[9]);
            }
            Ordenar();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnBuscar.PerformClick();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvListar.Rows.Clear();
            DataTable table = new DataTable();
            if (rbtnTodo.Checked)
            {
                table = nUsuario.Buscar("usuario_buscar", txtBuscar.Text);
            }
            if (rbtnUsuario.Checked)
            {
                table = nUsuario.Buscar("usuario_buscarUsuario", txtBuscar.Text);
            }
            if (rbtnNombre.Checked)
            {
                table = nUsuario.Buscar("usuario_buscarNombre", txtBuscar.Text);
            }
            if (rbtnCedula.Checked)
            {
                table = nUsuario.Buscar("usuario_buscarCedula", txtBuscar.Text);
            }
            if (rbtnCorreo.Checked)
            {
                table = nUsuario.Buscar("usuario_buscarCorreo", txtBuscar.Text);
            }
            foreach (DataRow row in table.Rows)
            {
                dgvListar.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5],
                    row[6], row[7], row[8], row[9]);
            }
            Ordenar();
            if (dgvListar.RowCount > 0)
            {
                dgvListar.Focus();
            }
        }

        private void rbtnTodo_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscar.Focus();
            txtBuscar.SelectAll();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvListar.RowCount > 0)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void dgvListar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListar.RowCount > 0)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void dgvListar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvListar.RowCount > 0)
                {
                    dgvListar.CurrentRow.Selected = true;
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
