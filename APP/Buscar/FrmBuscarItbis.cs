using Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP.Buscar
{
    public partial class FrmBuscarItbis : Form
    {
        public FrmBuscarItbis()
        {
            InitializeComponent();
        }

        private readonly NItbis _itbis = new NItbis();

        private void FrmBuscarItbis_Load(object sender, EventArgs e)
        {
            rbtnTodo.Checked = true;
            DataTable itbis = _itbis.Listar();
            foreach (DataRow dr in itbis.Rows)
            {
                _ = dgvListar.Rows.Add(dr[0], dr[1], dr[2]);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvListar.Rows.Clear();
            string query = @"SELECT id_itbis, nombre_itbis, porciento_itbis FROM ArticuloItbis";
            if (rbtnTodo.Checked)
            {
                query += string.Format(" WHERE id_itbis LIKE '%'+'{0}'+'%' OR nombre_itbis LIKE '%'+'{0}'+'%' " +
                    "OR porciento_itbis LIKE '%'+'{0}'+'%'", txtBuscar.Text);
            }
            else if (rbtnCodigo.Checked)
            {
                query += string.Format(" WHERE id_itbis LIKE '%'+'{0}'+'%'", txtBuscar.Text);
            }
            else if (rbtnNombre.Checked)
            {
                query += string.Format(" WHERE nombre_itbis LIKE '%'+'{0}'+'%'", txtBuscar.Text);
            }
            else if (rbtnPorciento.Checked)
            {
                query += string.Format(" WHERE porciento_itbis LIKE '%'+'{0}'+'%'", txtBuscar.Text);
            }
            query += " ORDER BY nombre_itbis";
            DataTable itbis = _itbis.Buscar(query);
            foreach (DataRow dr in itbis.Rows)
            {
                _ = dgvListar.Rows.Add(dr[0], dr[1], dr[2]);
            }
            if (dgvListar.RowCount > 0)
            {
                dgvListar.Focus();
            }
        }

        private void dgvListar_KeyDown(object sender, KeyEventArgs e)
        {
            dgvListar.CurrentRow.Selected = true;
            e.SuppressKeyPress = true;
            e.Handled= true;
            DialogResult = DialogResult.OK;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }


        private void dgvListar_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult= DialogResult.OK;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
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
    }
}
