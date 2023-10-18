using Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP.Buscar
{
    public partial class FrmBuscarReciboPago : Form
    {
        public FrmBuscarReciboPago()
        {
            InitializeComponent();
        }

        private readonly NReciboPago _recibo = new NReciboPago();

        private void FrmBuscarReciboPago_Load(object sender, EventArgs e)
        {
            DataTable recibos = _recibo.Listar(dtpDesde.Value.Date, dtpHasta.Value.Date);
            foreach (DataRow dr in recibos.Rows)
            {
                dgvListar.Rows.Add(dr[0], dr[1], dr[2], dr[3]);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvListar.Rows.Clear();
            string query = @"SELECT RI.id_rp, RI.fecha_rp, CL.nombre_suplidor, 
                             SUM(RI.pago_rp) Monto FROM ReciboPago RI 
                             LEFT JOIN Suplidores CL ON RI.id_suplidor = CL.id_suplidor";

            if (!string.IsNullOrEmpty(txtIdRecibo.Text))
            {
                query += string.Format(" WHERE RI.id_rp = '{0}'", txtIdRecibo.Text);
            }
            else
            {
                query += string.Format(" WHERE RI.fecha_rp BETWEEN '{0}' AND '{1}'",
                    dtpDesde.Value.Date, dtpHasta.Value.Date);

                if (!string.IsNullOrEmpty(txtNombre.Text))
                {
                    query += string.Format(" AND RI.id_suplidor = '{0}'", txtIdCliente.Text);
                }
            }
            query += @" GROUP BY RI.id_rp, RI.fecha_rp, CL.nombre_suplidor
	                  ORDER BY RI.id_rp DESC";
            DataTable recibos = _recibo.Buscar(query);
            foreach (DataRow dr in recibos.Rows)
            {
                dgvListar.Rows.Add(dr[0], dr[1], dr[2], dr[3]);
            }
            if (dgvListar.RowCount > 0)
            {
                dgvListar.Focus();
            }
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

        private void txtIdCliente_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdCliente.Text))
            {
                NSuplidores _cliente = new NSuplidores();
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
        }

        private void txtIdCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = btnBuscar.Focus();
            }
        }

        private void txtIdCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvListar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvListar.CurrentRow.Selected = true;
                e.SuppressKeyPress = true;
                e.Handled = true;
                DialogResult = DialogResult.OK;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void dgvListar_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
