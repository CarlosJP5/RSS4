using Entidades;
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
    public partial class FrmCaja_apertura : Form
    {
        public FrmCaja_apertura()
        {
            InitializeComponent();
        }

        private ECaja caja = new ECaja();

        private void FrmCaja_apertura_Load(object sender, EventArgs e)
        {
            caja = new ECaja();
            txtNombreCajero.Text = "";
            txtFondoCaja.Text = "0.00";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            caja = new ECaja();
            txtNombreCajero.Text = "";
            txtFondoCaja.Text = "0.00";
        }

        private void txtNombreCajero_Validating(object sender, CancelEventArgs e)
        {
            caja.apertura_nombre = txtNombreCajero.Text.Trim();
            errorNombre.Clear();
        }

        private void txtFondoCaja_Validating(object sender, CancelEventArgs e)
        {
            if (double.TryParse(txtFondoCaja.Text, out double fondo))
            {
                caja.fondo_caja = fondo;
            }
            else
            {
                caja.fondo_caja = 0;
            }
            txtFondoCaja.Text = fondo.ToString("n2");
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(caja.apertura_nombre))
            {
                errorNombre.SetError(txtNombreCajero, "Campo Obligatorio");
                return;
            }


        }
    }
}
