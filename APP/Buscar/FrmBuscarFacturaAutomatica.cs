using Negocios;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace APP.Buscar
{
    public partial class FrmBuscarFacturaAutomatica : Form
    {
        public FrmBuscarFacturaAutomatica()
        {
            InitializeComponent();
        }

        private readonly NServicio nservicio = new NServicio();
        private readonly NClientes nclientes = new NClientes();
        private readonly NArticulos buscar = new NArticulos();

        private void FrmBuscarFacturaAutomatica_Load(object sender, EventArgs e)
        {
            DataTable ListadeFacturar = nservicio.ListarAutomatica();
            foreach (DataRow dataRow in ListadeFacturar.Rows)
            {
                DateTime fecha = DateTime.Parse(dataRow[2].ToString());
                _ = dgvListar.Rows.Add(dataRow[0], dataRow[1], dataRow[5], dataRow[3], dataRow[4], fecha.ToString("dd/MM/yyyy"));
            }
        }

        private void linkCliente_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBuscarClientes frm = new FrmBuscarClientes();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtCodigo.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                txtNombre.Text = frm.dgvListar.SelectedCells[2].Value.ToString();
            }
        }

        private void txtCodigo_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                DataTable cliente = nclientes.BuscarId(txtCodigo.Text);
                if (cliente.Rows.Count > 0)
                {
                    txtNombre.Text = cliente.Rows[0][2].ToString();
                }
                else
                {
                    txtNombre.Text = null;
                    txtCodigo.Text = null;
                }
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvListar.Rows.Clear();
            if (string.IsNullOrEmpty(txtCodigo.Text) && string.IsNullOrEmpty(txtNombre.Text))
            {
                DataTable ListadeFacturar = nservicio.ListarAutomatica();
                foreach (DataRow dataRow in ListadeFacturar.Rows)
                {
                    DateTime fecha = DateTime.Parse(dataRow[2].ToString());
                    _ = dgvListar.Rows.Add(dataRow[0], dataRow[1], dataRow[5], dataRow[3], dataRow[4], fecha.ToString("dd/MM/yyyy"));
                }
            }
            else if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                string query = $@"select FA.id_factura_automatica, FA.id_cliente, FA.fecha_factura_automatica, 
                                FA.descripcion_factura_automatica, FA.precio_factura_automatica, c.nombre_cliente
                                from FacturaAutomatica FA
                                left join Clientes C ON FA.id_cliente = C.id_cliente
                                where C.id_cliente = '{txtCodigo.Text}'
                                order by C.nombre_cliente";
                DataTable ListadeFacturar = buscar.Buscar(query);
                foreach (DataRow dataRow in ListadeFacturar.Rows)
                {
                    DateTime fecha = DateTime.Parse(dataRow[2].ToString());
                    _ = dgvListar.Rows.Add(dataRow[0], dataRow[1], dataRow[5], dataRow[3], dataRow[4], fecha.ToString("dd/MM/yyyy"));
                }
            }
            else
            {
                string query = $@"select FA.id_factura_automatica, FA.id_cliente, FA.fecha_factura_automatica, 
                                FA.descripcion_factura_automatica, FA.precio_factura_automatica, c.nombre_cliente
                                from FacturaAutomatica FA
                                left join Clientes C ON FA.id_cliente = C.id_cliente
                                where C.nombre_cliente like '%'+'{txtNombre.Text}'+'%'
                                order by C.nombre_cliente";
                DataTable ListadeFacturar = buscar.Buscar(query);
                foreach (DataRow dataRow in ListadeFacturar.Rows)
                {
                    DateTime fecha = DateTime.Parse(dataRow[2].ToString());
                    _ = dgvListar.Rows.Add(dataRow[0], dataRow[1], dataRow[5], dataRow[3], dataRow[4], fecha.ToString("dd/MM/yyyy"));
                }
            }
        }
    }
}
