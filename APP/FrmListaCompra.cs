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
    public partial class FrmListaCompra : Form
    {
        public FrmListaCompra()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                FrmBuscarSuplidores frm = new FrmBuscarSuplidores();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    txtIdSuplidor.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                    txtNombre.Text = frm.dgvListar.SelectedCells[2].Value.ToString();
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void FrmListaCompra_Load(object sender, EventArgs e)
        {
            GenerarLista();
        }

        private void linkSuplidor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBuscarSuplidores frm = new FrmBuscarSuplidores();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtIdSuplidor.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                txtNombre.Text = frm.dgvListar.SelectedCells[2].Value.ToString();
            }
        }

        private void txtIdSuplidor_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdSuplidor.Text))
            {
                NSuplidores _suplidor = new NSuplidores();
                DataTable suplidor = _suplidor.BuscarId(txtIdSuplidor.Text);
                if (suplidor.Rows.Count > 0)
                {
                    txtNombre.Text = suplidor.Rows[0][1].ToString();
                }
                else
                {
                    txtNombre.Text = null;
                }
            }
            else
            {
                txtNombre.Text = null;
            }
        }

        private void txtIdSuplidor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = btnGenerarLista.Focus();
            }
        }

        private void txtIdSuplidor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnGenerarLista_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                GenerarLista();
            }
            else
            {

            }
        }

        private void GenerarLista()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                NArticulos _articulo = new NArticulos();
                DataTable Articulo = _articulo.ListaDeCompras();
                foreach (DataRow row in Articulo.Rows)
                {
                    _ = dgvListar.Rows.Add(row[0], row[1], row[2], row[3],
                        row[4], row[5], row[6]);
                }
            }
        }
    }
}
