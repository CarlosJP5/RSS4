using APP.Reportes;
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
    public partial class FrmArticulosReporteCosto : Form
    {
        public FrmArticulosReporteCosto()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtCantidad_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                txtCantidad.Text = "0";
            }
            else
            {
                if (!double.TryParse(txtCantidad.Text, out _))
                {
                    _ = MessageBox.Show("Cantidad no es validad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCantidad.Text = "0";
                }
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                _ = btnImprimir.Focus();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string query = @"SELECT codigo_articulo, nombre_articulo, 
                            cantidad_articulo, costo_articulo, (cantidad_articulo * costo_articulo) as importe
                            FROM Articulo ";
            if (rbtnMayor.Checked)
            {
                query += $"where cantidad_articulo > '{txtCantidad.Text}'";
            }
            else if (rbtnMenor.Checked)
            {
                query += $"where cantidad_articulo < '{txtCantidad.Text}'";
            }
            else if (rbtnIgual.Checked)
            {
                query += $"where cantidad_articulo = '{txtCantidad.Text}'";
            }

            query += " order by nombre_articulo";
            rptArticulosReporteCosto frm = new rptArticulosReporteCosto(query);
            frm.Show();

        }
    }
}
