using Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP.Buscar
{
    public partial class FrmBuscarReciboIngreso : Form
    {
        public FrmBuscarReciboIngreso()
        {
            InitializeComponent();
        }

        private readonly NReciboIngreso _recibo = new NReciboIngreso();

        private void FrmBuscarReciboIngreso_Load(object sender, EventArgs e)
        {
            DataTable recibos = _recibo.Listar(dtpDesde.Value.Date, dtpHasta.Value.Date);
            foreach (DataRow dr in recibos.Rows)
            {
                DateTime fecha = DateTime.Parse(dr[1].ToString());
                dgvListar.Rows.Add(dr[0], fecha.ToString("dd/MM/yyyy"), dr[2], dr[3]);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvListar.Rows.Clear();
            string query = @"SELECT RI.id_ri, RI.fecha_ri, CL.nombre_cliente, 
                             SUM(RI.pago_ri) Monto FROM ReciboIngreso RI 
                             LEFT JOIN Clientes CL ON RI.id_cliente = CL.id_cliente";
            
            if (!string.IsNullOrEmpty(txtIdRecibo.Text))
            {
                query += string.Format(" WHERE RI.id_ri = '{0}'", txtIdRecibo.Text);
            }
            else
            {
                query += string.Format(" WHERE RI.fecha_ri BETWEEN '{0}' AND '{1}'",
                    dtpDesde.Value.Date, dtpHasta.Value.Date);

                if (!string.IsNullOrEmpty(txtNombre.Text))
                {
                    query += string.Format(" AND RI.id_cliente = '{0}'", txtIdCliente.Text);
                }
            }            
            query += @" GROUP BY RI.id_ri, RI.fecha_ri, CL.nombre_cliente
	                  ORDER BY RI.id_ri DESC";

            DataTable recibos = _recibo.Buscar(query);
            foreach (DataRow dr in recibos.Rows)
            {
                DateTime fecha = DateTime.Parse(dr[1].ToString());
                dgvListar.Rows.Add(dr[0], fecha.ToString("dd/MM/yyyy"), dr[2], dr[3]);
            }
            if (dgvListar.RowCount > 0)
            {
                dgvListar.Focus();
            }
        }

        private void linkCliente_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBuscarClientes frm = new FrmBuscarClientes();
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
                NClientes _cliente = new NClientes();
                DataTable cliente = _cliente.BuscarId(txtIdCliente.Text);
                if (cliente.Rows.Count > 0)
                {
                    txtNombre.Text = cliente.Rows[0][2].ToString();
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

        private void txtIdRecibo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtIdRecibo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = btnBuscar.Focus();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
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
