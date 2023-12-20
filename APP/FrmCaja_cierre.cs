using APP.Buscar;
using Entidades;
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
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarCajas frm = new FrmBuscarCajas();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                caja.id_caja = (int)frm.listarDgv.SelectedCells[0].Value;
                caja.apertura_nombre = frm.listarDgv.SelectedCells[2].Value.ToString();
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

            }
        }
    }
}
