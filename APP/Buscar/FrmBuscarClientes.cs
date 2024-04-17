using Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP.Buscar
{
    public partial class FrmBuscarClientes : Form
    {
        public FrmBuscarClientes()
        {
            InitializeComponent();
        }

        private readonly NClientes _clientes = new NClientes();

        private void FrmBuscarClientes_Load(object sender, EventArgs e)
        {
            rbtnTodo.Checked = true;
            DataTable dt = _clientes.Listar();
            foreach (DataRow clienteRow in dt.Rows)
            {
                _ = dgvListar.Rows.Add(clienteRow[0], clienteRow[4], clienteRow[2], clienteRow[5],
                    clienteRow[6], clienteRow[11], clienteRow[1], clienteRow[3], clienteRow[7],
                    clienteRow[8], clienteRow[9], clienteRow[10]);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvListar.Rows.Clear();
            string query = @"SELECT id_cliente, id_comprobante, nombre_cliente, cedula_cliente, rnc_cliente,
                             direccion_cliente, telefono_cliente, correo_cliente, tipoCompra_cliente,
                             limiteCredito_cliente, descuento_cliente, estado_cliente FROM Clientes ";
            if (rbtnTodo.Checked)
            {
                query += string.Format("WHERE id_cliente LIKE '%'+'{0}'+'%' OR nombre_cliente LIKE '%'+'{0}'+'%' OR " +
                                       "rnc_cliente LIKE '%'+'{0}'+'%' OR cedula_cliente LIKE '%'+'{0}'+'%' OR " +
                                       "telefono_cliente LIKE '%' + '{0}' + '%'", txtBuscar.Text);
            }
            else if (rbtnCodigo.Checked)
            {
                query += string.Format("WHERE id_cliente LIKE '%'+'{0}'+'%'", txtBuscar.Text);
            }
            else if (rbtnNombre.Checked)
            {
                query += string.Format("WHERE nombre_cliente LIKE '%'+'{0}'+'%'", txtBuscar.Text);
            }
            else if (rbtnRnc.Checked)
            {
                query += string.Format("WHERE rnc_cliente LIKE '%'+'{0}'+'%' OR cedula_cliente LIKE '%'+'{0}'+'%'", txtBuscar.Text);
            }
            else if (rbtnTelefono.Checked)
            {
                query += string.Format("WHERE telefono_cliente LIKE '%' + '{0}' + '%'", txtBuscar.Text);
            }
            query += " ORDER BY nombre_cliente";
            DataTable dt = _clientes.Buscar(query);
            foreach (DataRow clienteRow in dt.Rows)
            {
                _ = dgvListar.Rows.Add(clienteRow[0], clienteRow[4], clienteRow[2], clienteRow[5],
                    clienteRow[6], clienteRow[11], clienteRow[1], clienteRow[3], clienteRow[7],
                    clienteRow[8], clienteRow[9], clienteRow[10]);
            }
            if (dgvListar.RowCount > 0)
            {
                dgvListar.Focus();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvListar.RowCount > 0)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void dgvListar_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListar.RowCount > 0)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void dgvListar_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvListar.RowCount > 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dgvListar.CurrentRow.Selected = true;
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnBuscar.PerformClick();
            }
        }

        private void rbtnTodo_CheckedChanged(object sender, EventArgs e)
        {
            _ = txtBuscar.Focus();
        }

        private void dgvListar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListar.RowCount > 0)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
