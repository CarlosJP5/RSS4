using APP.Buscar;
using Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP
{
    public partial class FrmBancosMovimientos : Form
    {
        public FrmBancosMovimientos()
        {
            InitializeComponent();
        }

        private readonly NBancos nbancos = new NBancos();

        private void FrmBancosMovimientos_Load(object sender, EventArgs e)
        {
            btnNuevo.PerformClick();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            bancoLbl.Text = "Banco";
            numeroCuentaLbl.Text = "Nº Cuenta";
            nombreLbl.Text = "Nombre";
            balanceLbl.Text = "$ 0.00";
            tipoTransaccionCbo.SelectedIndex = 0;
            montoTxt.Text = "";
            detalleTxt.Text = "";
            idBancoLbl.Text = "x";
            idCtnBancoLbl.Text = "x";

            btnModificar.Enabled = false;
            btnSalvar.Enabled = true;
            btnBuscar.Enabled = true;
        }

        private void cuentaLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBuscarBancosCuentas frm = new FrmBuscarBancosCuentas();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                idCtnBancoLbl.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                idBancoLbl.Text = frm.dgvListar.SelectedCells[1].Value.ToString();
                bancoLbl.Text = frm.dgvListar.SelectedCells[2].Value.ToString();
                nombreLbl.Text = frm.dgvListar.SelectedCells[3].Value.ToString();
                numeroCuentaLbl.Text = frm.dgvListar.SelectedCells[4].Value.ToString();
                total = Convert.ToDouble(frm.dgvListar.SelectedCells[5].Value);
                balanceLbl.Text = total.ToString("C");
            }
        }

        private double total = 0;

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Credito Aumenta cuenta
            // Debito Disminuye
            double credito = 0;
            double debito = 0;
            double monto = 0;

            if (!double.TryParse(idCtnBancoLbl.Text, out _))
            {
                MessageBox.Show("Debe elegir una cuenta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(montoTxt.Text, out monto))
            {
                MessageBox.Show("Monto invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // retito
            if (tipoTransaccionCbo.SelectedIndex == 1)
            {
                debito = monto;
            }
            // deposito
            else if(tipoTransaccionCbo.SelectedIndex == 2)
            {
                credito = monto;
            }
            else
            {
                MessageBox.Show("Debe elegir el tipo de transaccion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            total = total + credito - debito;

            nbancos.InsertarMovimiento(idBancoLbl.Text, idCtnBancoLbl.Text, DateTime.Now, detalleTxt.Text, debito, credito, total);
            DataTable cuentaData = nbancos.BuscarCuentaId(idCtnBancoLbl.Text);
            if (cuentaData.Rows.Count > 0)
            {
                total = Convert.ToDouble(cuentaData.Rows[0][4]);
                balanceLbl.Text = total.ToString("C");
            }
            montoTxt.Text = "";
            detalleTxt.Text = "";
            _ = montoTxt.Focus();
        }

        private void montoTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void montoTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                _ = detalleTxt.Focus();
            }
        }

        private void detalleTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                _ = detalleTxt.Focus();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarBancosMovimientos frm = new FrmBuscarBancosMovimientos();
            if (frm.ShowDialog() == DialogResult.OK)
            {

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
