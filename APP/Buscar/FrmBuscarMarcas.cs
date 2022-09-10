using Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP.Buscar
{
    public partial class FrmBuscarMarcas : Form
    {
        public FrmBuscarMarcas()
        {
            InitializeComponent();
        }

        private readonly NMarcas _marca = new NMarcas();

        private void FrmBuscarMarcas_Load(object sender, EventArgs e)
        {
            rbtnTodo.Checked = true;
            DataTable marca = _marca.Listar();
            foreach (DataRow row in marca.Rows)
            {
                _ = dgvListar.Rows.Add(row[0], row[1]);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvListar.Rows.Clear();
            string query = @"SELECT id_marca, nombre_marca FROM ArticuloMarca";
            if (rbtnTodo.Checked)
            {
                query += string.Format(" WHERE id_marca LIKE '%'+'{0}'+'%' OR nombre_marca LIKE '%'+'{0}'+'%'",
                    txtBuscar.Text);
            }
            else if (rbtnCodigo.Checked)
            {
                query += string.Format(" WHERE id_marca LIKE '%'+'{0}'+'%'", txtBuscar.Text);
            }
            else if (rbtnNombre.Checked)
            {
                query += string.Format(" WHERE nombre_marca LIKE '%'+'{0}'+'%'", txtBuscar.Text);
            }
            query += " ORDER BY nombre_marca";
            DataTable marca = _marca.Buscar(query);
            if (marca.Rows.Count > 0)
            {
                _ = dgvListar.Focus();
            }
            foreach (DataRow row in marca.Rows)
            {
                _ = dgvListar.Rows.Add(row[0], row[1]);
            }
            if (dgvListar.RowCount > 0)
            {
                dgvListar.Focus();
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnBuscar.PerformClick();
            }
        }

        private void dgvListar_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
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

        private void rbtnTodo_CheckedChanged(object sender, EventArgs e)
        {
            _ = txtBuscar.Focus();
        }

        private void dgvListar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
