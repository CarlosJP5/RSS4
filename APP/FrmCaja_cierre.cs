using APP.Buscar;
using Entidades;
using Negocios;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace APP
{
    public partial class FrmCaja_cierre : Form
    {
        public FrmCaja_cierre()
        {
            InitializeComponent();
        }

        private ECaja caja = new ECaja();

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            caja = new ECaja();
            errorNombre.Clear();
            cajeroTxt.Text = "";
            montoTxt.Text = "";
            cerradoPorTxt.Text = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarCajas frm = new FrmBuscarCajas();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                caja.id_caja = (int)frm.listarDgv.SelectedCells[0].Value;
                caja.apertura_nombre = frm.listarDgv.SelectedCells[2].Value.ToString();
                caja.total_caja = (double)frm.listarDgv.SelectedCells[3].Value;
                cajeroTxt.Text = caja.apertura_nombre;
                montoTxt.Text = caja.total_caja.ToString("n2");
                _ = cerradoPorTxt.Focus();
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            caja.cierre_nombre = cerradoPorTxt.Text.Trim();
            errorNombre.Clear();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(caja.cierre_nombre))
            {
                errorNombre.SetError(cerradoPorTxt, "Campo Obligatorio");
                return;
            }

            if (caja.id_caja != 0)
            {
                NCaja nCaja = new NCaja();
                nCaja.Cierre(caja);
                btnNuevo.PerformClick();
            }
            else
            {
                _ = MessageBox.Show("No hay caja seleccionada para cerrar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
