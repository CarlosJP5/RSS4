using APP.Buscar;
using Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP
{
    public partial class FrmGastosRegistrar : Form
    {
        public FrmGastosRegistrar()
        {
            InitializeComponent();
            DataTable data = nGasto.Buscar("");

            DataRow dr = data.NewRow();
            dr["id_gasto"] = 0;
            dr["nombre_gasto"] = "- - -";
            data.Rows.InsertAt(dr, 0);

            tipoGastoCbo.DataSource = data;
            tipoGastoCbo.ValueMember = "id_gasto";
            tipoGastoCbo.DisplayMember = "nombre_gasto";
        }

        private readonly NGasto nGasto = new NGasto();

        private void Nuevo()
        {
            idRegistroTxt.Text = "0";
            errorTotal.Clear();
            tipoGastoCbo.Enabled = true;
            detalleTxt.Enabled = true;
            fechaDtp.Enabled = true;
            totalTxt.Enabled = true;
            tipoGastoCbo.SelectedIndex = 0;
            detalleTxt.Text = "";
            fechaDtp.Value = DateTime.Now;
            totalTxt.Text = "";
            _ = tipoGastoCbo.Focus();
            btnModificar.Enabled = false;
            btnSalvar.Enabled = true;
            btnBuscar.Enabled = true;
        }

        private void FrmGastosRegistrar_Load(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void totalTxt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!decimal.TryParse(totalTxt.Text, out decimal total))
            {
                errorTotal.SetError(totalTxt, "Número Invalido");
            }
            else
            {
                totalTxt.Text = total.ToString("n2");
                errorTotal.Clear();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (tipoGastoCbo.SelectedIndex == 0)
            {
                MessageBox.Show("Debe seleccionar un tipo de gasto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!decimal.TryParse(totalTxt.Text, out decimal monto))
            {
                errorTotal.SetError(totalTxt, "Número Invalido");
                return;
            }
            else
            {
                if (monto == 0)
                {
                    MessageBox.Show("El gato no puede ser Cero (0)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (idRegistroTxt.Text == "0")
            {
                // insertar
                nGasto.InsertarDetalle((int)tipoGastoCbo.SelectedValue, fechaDtp.Value, detalleTxt.Text, monto);
            }
            else
            {
                // editar
            }
            Nuevo();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarGastoRegistro frm = new FrmBuscarGastoRegistro();
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
