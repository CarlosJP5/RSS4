using APP.Buscar;
using Negocios;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace APP
{
    public partial class FrmGastosTipos : Form
    {
        public FrmGastosTipos()
        {
            InitializeComponent();
        }

        private readonly NGasto nGasto = new NGasto();

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nombreTxt.Enabled = true;
            idTxt.Text = "";
            nombreTxt.Text = "";
            btnModificar.Enabled = false;
            btnSalvar.Enabled = true;
            btnBuscar.Enabled = true;
            errorNombre.Clear();
            _ = nombreTxt.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(nombreTxt.Text))
            {
                errorNombre.SetError(nombreTxt, "Campo obligatorio");
                return;
            }
            else
            {
                if (string.IsNullOrEmpty(idTxt.Text))
                {
                    // Insertar
                    nGasto.Insertar(nombreTxt.Text);
                }
                else
                {
                    // Editar
                    nGasto.Editar(Convert.ToInt16(idTxt.Text), nombreTxt.Text);
                }
            }
            btnNuevo.PerformClick();
        }

        private void nombreTxt_Validating(object sender, CancelEventArgs e)
        {
            errorNombre.Clear();
        }

        private void nombreTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                _ = btnSalvar.Focus();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarGastoTipo frm = new FrmBuscarGastoTipo();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                idTxt.Text = frm.listarDgv.SelectedCells[0].Value.ToString();
                nombreTxt.Text = frm.listarDgv.SelectedCells[1].Value.ToString();
                nombreTxt.Enabled = false;
                btnSalvar.Enabled = false;
                btnModificar.Enabled = true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            nombreTxt.Enabled = true;
            btnSalvar.Enabled = true;
            btnBuscar.Enabled = false;
            _ = nombreTxt.Focus();
        }
    }
}
