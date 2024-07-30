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
    public partial class FrmReciboPagoReporte : Form
    {
        public FrmReciboPagoReporte()
        {
            InitializeComponent();
        }

        private void FrmReciboPagoReporte_Load(object sender, EventArgs e)
        {

        }

        private void linkCliente_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBuscarSuplidores frm = new FrmBuscarSuplidores();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtIdCliente.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                txtNombre.Text = frm.dgvListar.SelectedCells[2].Value.ToString();
            }
            else
            {
                txtIdCliente.Text = null;
                txtNombre.Text = null;
            }
        }

        private void txtIdCliente_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdCliente.Text))
            {
                NSuplidores _cliente = new NSuplidores();
                if (int.TryParse(txtIdCliente.Text, out _))
                {
                    DataTable cliente = _cliente.BuscarId(txtIdCliente.Text);
                    if (cliente.Rows.Count > 0)
                    {
                        txtNombre.Text = cliente.Rows[0][1].ToString();
                    }
                    else
                    {
                        txtIdCliente.Text = null;
                        txtNombre.Text = null;
                    }
                }
                else
                {
                    txtIdCliente.Text = null;
                    txtNombre.Text = null;
                }
            }
        }

        private void txtIdCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = btnBuscar.Focus();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtIdCliente.Text))
            {
                MessageBox.Show("Debe seleccionar un Suplidor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            listarDgv.Rows.Clear();

            NReciboPago _recibo = new NReciboPago();
            int.TryParse(txtIdCliente.Text, out int idSuplidor);
            DataTable data = _recibo.Historial(idSuplidor, dtpDesde.Value, dtpHasta.Value);
            foreach (DataRow row in data.Rows)
            {
                DateTime fecha = DateTime.Parse(row[1].ToString());
                listarDgv.Rows.Add(row[0], fecha.ToString("dd / MM / yyyy"), row[2], row[3], row[4], row[5]);
            }
        }
    }
}
