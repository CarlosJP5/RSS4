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

namespace APP.Buscar
{
    public partial class FrmBuscarDevolucion : Form
    {
        public FrmBuscarDevolucion()
        {
            InitializeComponent();
        }

        private readonly NFacturacion _facturar = new NFacturacion();

        private void FrmBuscarDevolucion_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today.AddHours(23.99999);
            DataTable dt = _facturar.ListarDevolucion(dtpDesde.Value, dtpHasta.Value);
            foreach (DataRow row in dt.Rows)
            {
                DateTime fecha = DateTime.Parse(row[2].ToString());
                _ = dgvListar.Rows.Add(row[0], row[1], fecha.ToString("dd/ MM /yyy"), row[3], row[4]);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvListar.Rows.Clear();
            string query = @"SELECT DV.id_devolucion, CD.ncf_comprobante,
	                            DV.fecha_devolucion, CL.nombre_cliente, DV.total_devolucion
	                            FROM FacturaDevolucion DV
	                            LEFT JOIN ComprobantesDetalle CD ON CD.id_documento = DV.id_devolucion AND CD.id_comprobante = DV.id_comprobante
	                            LEFT JOIN Clientes CL ON DV.id_cliente = CL.id_cliente";
            if (!string.IsNullOrEmpty(txtIdDevolucion.Text))
            {
                query += string.Format(" WHERE DV.id_devolucion = {0}", txtIdDevolucion.Text);
            }
            else
            {
                query += string.Format(" WHERE DV.fecha_devolucion BETWEEN '{0}' AND '{1}'",
                    dtpDesde.Value.Date, dtpHasta.Value.Date);

                if (!string.IsNullOrEmpty(txtNombre.Text))
                {
                    query += string.Format(" AND DV.id_cliente = {0}", txtIdCliente.Text);
                }
            }
            query += " ORDER BY DV.id_devolucion DESC";
            DataTable dt = _facturar.Buscar(query);
            foreach (DataRow row in dt.Rows)
            {
                DateTime fecha = DateTime.Parse(row[2].ToString());
                _ = dgvListar.Rows.Add(row[0], row[1], fecha.ToString("dd/ MM /yyy"), row[3], row[4]);
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
                NClientes cliente = new NClientes();
                DataTable table = cliente.BuscarId(txtIdCliente.Text);
                if (table.Rows.Count > 0)
                {
                    txtNombre.Text = table.Rows[0][2].ToString();
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

        private void txtIdCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
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

        private void dgvListar_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
