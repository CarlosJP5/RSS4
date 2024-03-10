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
    public partial class FrmMecanico : Form
    {
        public FrmMecanico()
        {
            InitializeComponent();
        }

        private readonly NMecanico nMecanico = new NMecanico();

        private void FrmMecanico_Load(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            idTxt.Text = "";
            nombreTxt.Text = "";
            comisionTxt.Text = "";
            nombreTxt.Enabled = true;
            comisionTxt.Enabled = true;
            btnModificar.Enabled = false;
            btnSalvar.Enabled = true;
            btnBuscar.Enabled = true;
            _ = nombreTxt.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nombreTxt.Text))
            {
                _ = MessageBox.Show("Nombre obligatorio", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(idTxt.Text))
            {
                // Insertar
                double.TryParse(comisionTxt.Text, out double comision);
                nMecanico.Insertar(nombreTxt.Text, comision);
            }
            else
            {
                // Editar
                double.TryParse(comisionTxt.Text, out double comision);
                nMecanico.Editar(Convert.ToInt16(idTxt.Text), nombreTxt.Text, comision);
            }
            btnNuevo.PerformClick();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarMecanico frm = new FrmBuscarMecanico();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                idTxt.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                nombreTxt.Text = frm.dgvListar.SelectedCells[1].Value.ToString();
                comisionTxt.Text = frm.dgvListar.SelectedCells[2].Value.ToString();
                nombreTxt.Enabled = false;
                comisionTxt.Enabled = false;
                btnModificar.Enabled = true;
                btnSalvar.Enabled = false;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            nombreTxt.Enabled = true;
            comisionTxt.Enabled = true;
            btnBuscar.Enabled = false;
            btnSalvar.Enabled = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult msj = MessageBox.Show("Desea Salir", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msj == DialogResult.Yes)
            {
                Close();
            }
        }

        private void nombreTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                _ = comisionTxt.Focus();
            }
        }

        private void comisionTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                _ = btnSalvar.Focus();
            }
        }

        private void comisionTxt_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
