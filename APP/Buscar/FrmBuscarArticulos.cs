using Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP.Buscar
{
    public partial class FrmBuscarArticulos : Form
    {
        public FrmBuscarArticulos()
        {
            InitializeComponent();
        }

        private readonly NArticulos _articulo = new NArticulos();

        private void FrmBuscarArticulos_Load(object sender, EventArgs e)
        {
            rbtnTodo.Checked = true;
            DataTable articulo = _articulo.Listar();
            foreach (DataRow rowArt in articulo.Rows)
            {
                _ = dgvListar.Rows.Add(rowArt[0], rowArt[1], rowArt[2], rowArt[3],
                                       rowArt[4], rowArt[5], rowArt[6], rowArt[7],
                                       rowArt[8], rowArt[9]);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvListar.Rows.Clear();
            string query = @"SELECT A.id_articulo, codigo_articulo, referencia_articulo, nombre_articulo,
	                         nombre_marca, cantidad_articulo, precio_articulo, estado_articulo, I.porciento_itbis, A.costo_articulo 
	                         FROM Articulo A LEFT JOIN ArticuloMarca M ON A.id_marca = M.id_marca
                             LEFT JOIN ArticuloItbis I ON A.id_itbis = I.id_itbis";
            
            if (rbtnTodo.Checked)
            {
                query += string.Format(@" WHERE codigo_articulo LIKE '%'+'{0}'+'%' OR nombre_articulo
                                          LIKE '%'+'{0}'+'%' OR referencia_articulo LIKE '%'+'{0}'+'%'
                                          OR nombre_marca LIKE '%'+'{0}'+'%'", txtBuscar.Text);
            }
            else if (rbtnCodigo.Checked)
            {
                query += string.Format(" WHERE codigo_articulo LIKE '%'+'{0}'+'%'", txtBuscar.Text);
            }
            else if (rbtnNombre.Checked)
            {
                query += string.Format(" WHERE nombre_articulo LIKE '%'+'{0}'+'%'", txtBuscar.Text);
            }
            else if (rbtnReferencia.Checked)
            {
                query += string.Format(" WHERE referencia_articulo LIKE '%'+'{0}'+'%'", txtBuscar.Text);
            }
            else if (rbtnMarca.Checked)
            {
                query += string.Format(" WHERE nombre_marca LIKE '%'+'{0}'+'%'", txtBuscar.Text);
            }
            query += " ORDER BY nombre_articulo";
            DataTable articulo = _articulo.Buscar(query);
            foreach (DataRow rowArt in articulo.Rows)
            {
                _ = dgvListar.Rows.Add(rowArt[0], rowArt[1], rowArt[2], rowArt[3],
                                       rowArt[4], rowArt[5], rowArt[6], rowArt[7],
                                       rowArt[8], rowArt[9]);
            }
            if (dgvListar.RowCount > 0)
            {
                dgvListar.Focus();
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
