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
    public partial class FrmBancosCuentas : Form
    {
        private readonly NBancos nbancos = new NBancos();

        public FrmBancosCuentas()
        {
            InitializeComponent();
        }

        private void FrmBancosCuentas_Load(object sender, EventArgs e)
        {
            btnNuevo.PerformClick();
        }

        private void linkBanco_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBuscarBancos frm = new FrmBuscarBancos();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                idBancoTxt.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                bancoNombreTxt.Text = frm.dgvListar.SelectedCells[1].Value.ToString();
                _ = cuentaNombreTxt.Focus();
            }
            else
            {
                idBancoTxt.Text = "";
                bancoNombreTxt.Text = "";
            }
        }

        private void idBancoTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void idBancoTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                _ = cuentaNombreTxt.Focus();
            }
        }

        private void cuentaNombreTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                _ = numeroCuentaTxt.Focus();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            errorBanco.Clear();
            errorNombre.Clear();
            errorNumero.Clear();
            idCuentaLbl.Text = "x";
            idBancoTxt.Text = "";
            bancoNombreTxt.Text = "";
            cuentaNombreTxt.Text = "";
            numeroCuentaTxt.Text = "";

            linkBanco.Enabled = true;
            idBancoTxt.Enabled = true;
            bancoNombreTxt.Enabled = true;
            cuentaNombreTxt.Enabled = true;
            numeroCuentaTxt.Enabled = true;

            btnModificar.Enabled = false;
            btnSalvar.Enabled = true;
            btnBuscar.Enabled = true;
        }

        private void numeroCuentaTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                _ = numeroCuentaTxt.Focus();
            }
        }

        private void idBancoTxt_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(idBancoTxt.Text))
            {
                DataTable data = nbancos.BuscarId(idBancoTxt.Text);
                if (data.Rows.Count > 0)
                {
                    bancoNombreTxt.Text = data.Rows[0][1].ToString();
                }
                else
                {
                    bancoNombreTxt.Text = "";
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            bool validar = true;
            if (string.IsNullOrEmpty(bancoNombreTxt.Text))
            {
                errorBanco.SetError(bancoNombreTxt, "Debes elegir un banco");
                validar = false;
            }
            if (string.IsNullOrWhiteSpace(cuentaNombreTxt.Text))
            {
                errorNombre.SetError(cuentaNombreTxt, "Campo obligatorio");
                validar = false;
            }
            if (string.IsNullOrWhiteSpace(numeroCuentaTxt.Text))
            {
                errorNumero.SetError(numeroCuentaTxt, "Campo obligatorio");
                validar = false;
            }
            if (!validar)
            {
                return;
            }

            if (idCuentaLbl.Text == "x")
            {
                // Insertar
                nbancos.InsertarCuenta(idBancoTxt.Text, cuentaNombreTxt.Text, numeroCuentaTxt.Text);
            }
            else
            {
                // Editar
                nbancos.EditarCuenta(idCuentaLbl.Text, idBancoTxt.Text, cuentaNombreTxt.Text, numeroCuentaTxt.Text);
            }

            btnNuevo.PerformClick();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarBancosCuentas frm = new FrmBuscarBancosCuentas();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                idCuentaLbl.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                idBancoTxt.Text = frm.dgvListar.SelectedCells[1].Value.ToString();
                bancoNombreTxt.Text = frm.dgvListar.SelectedCells[2].Value.ToString();
                cuentaNombreTxt.Text = frm.dgvListar.SelectedCells[3].Value.ToString();
                numeroCuentaTxt.Text = frm.dgvListar.SelectedCells[4].Value.ToString();

                linkBanco.Enabled = false;
                idBancoTxt.Enabled = false;
                bancoNombreTxt.Enabled = false;
                cuentaNombreTxt.Enabled = false;
                numeroCuentaTxt.Enabled = false;

                btnModificar.Enabled = true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            linkBanco.Enabled = true;
            idBancoTxt.Enabled = true;
            bancoNombreTxt.Enabled = true;
            cuentaNombreTxt.Enabled = true;
            numeroCuentaTxt.Enabled = true;

            btnModificar.Enabled = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
