using APP.Buscar;
using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Windows.Forms;

namespace APP
{
    public partial class FrmFacturaServicio : Form
    {
        public FrmFacturaServicio()
        {
            InitializeComponent();
            cboTipoComprobante.DataSource = _comprobante.ComprovantesVentas();
            cboTipoComprobante.ValueMember = "id_comprobante";
            cboTipoComprobante.DisplayMember = "nombre_comprobante";
        }

        private readonly NComprobantes _comprobante = new NComprobantes();

        private void FrmFacturaServicio_Load(object sender, EventArgs e)
        {
            btnNuevo.PerformClick();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtIdCliente.Text = string.Empty;
            txtNombre.Text = string.Empty;
            cboTipoComprobante.SelectedValue = "B02";
            dtpFecha.Value = DateTime.Now;
            txtCedula.Text = string.Empty;
            txtRnc.Text = string.Empty;
            dgvListar.Rows.Clear();
            txtImporte.Text = string.Empty;
            txtItbis.Text = string.Empty;
            txtTotal.Text = string.Empty;

            btnImprimir.Enabled = false;
            btnModificar.Enabled = false;
            _ = txtIdCliente.Focus();
        }

        private void btnBuscarClientes_Click(object sender, EventArgs e)
        {
            FrmBuscarClientes frm = new FrmBuscarClientes();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtIdCliente.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                txtRnc.Text = frm.dgvListar.SelectedCells[1].Value.ToString();
                txtNombre.Text = frm.dgvListar.SelectedCells[2].Value.ToString();
                txtCedula.Text = frm.dgvListar.SelectedCells[7].Value.ToString();
                cboTipoComprobante.SelectedValue = frm.dgvListar.SelectedCells[6].Value.ToString();
                _ = dgvListar.Focus();
            }
        }

        private void txtIdCliente_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtIdCliente.Text))
            {
                NClientes ncliente = new NClientes();
                DataTable cliente = ncliente.BuscarId(txtIdCliente.Text);
                if (cliente.Rows.Count > 0)
                {
                    txtNombre.Text = cliente.Rows[0][2].ToString();
                    txtCedula.Text = cliente.Rows[0][3].ToString();
                    txtRnc.Text = cliente.Rows[0][4].ToString();
                    cboTipoComprobante.SelectedValue = cliente.Rows[0][1].ToString();
                }
            }
        }

        private void dgvListar_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!string.IsNullOrEmpty((string)dgvListar.CurrentRow.Cells[1].Value))
            {
                if (decimal.TryParse(dgvListar.CurrentRow.Cells[1].Value.ToString(), out _))
                {
                    decimal precio = decimal.Parse(dgvListar.CurrentRow.Cells[1].Value.ToString());
                    dgvListar.CurrentRow.Cells[1].Value = precio;
                }
                else
                {
                    dgvListar.CurrentRow.Cells[1].Value = 0;
                }
            }
            else
            {
                dgvListar.CurrentRow.Cells[1].Value = 0;
            }
        }
    }
}
