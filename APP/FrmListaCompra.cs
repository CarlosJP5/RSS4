using APP.Buscar;
using APP.Reportes;
using Negocios;
using System;
using System.Data;
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
            dgvListar.Rows.Clear();
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                GenerarLista();
            }
            else
            {
                NArticulos _articulo = new NArticulos();
                DataTable Articulo = _articulo.ListaDeCompras(txtIdSuplidor.Text);
                foreach (DataRow row in Articulo.Rows)
                {

                    _ = dgvListar.Rows.Add(row[0], row[1],
                        string.IsNullOrEmpty(row[2].ToString()) ? "" : row[2],
                        string.IsNullOrEmpty(row[3].ToString()) ? "" : row[3],
                        string.IsNullOrEmpty(row[4].ToString()) ? "" : row[4],
                        row[5], row[6], 0m, 0);
                }
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
                    
                    _ = dgvListar.Rows.Add(row[0], row[1],
                        string.IsNullOrEmpty(row[2].ToString()) ? "" : row[2],
                        string.IsNullOrEmpty(row[3].ToString()) ? "" : row[3],
                        string.IsNullOrEmpty(row[4].ToString()) ? "" : row[4],
                        row[5], row[6], 0m, 0);
                }
            }
        }

        private void dgvListar_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListar.CurrentRow.Cells[7].Value == null)
            {
                dgvListar.CurrentRow.Cells[7].Value = 0m;
                dgvListar.CurrentRow.Cells[8].Value = 0;
            }
            else
            {
                if (decimal.TryParse(dgvListar.CurrentRow.Cells[7].Value.ToString(), out _))
                {
                    decimal pedido = Convert.ToDecimal(dgvListar.CurrentRow.Cells[7].Value);
                    if (pedido > 0)
                    {
                        dgvListar.CurrentRow.Cells[8].Value = 1;
                    }
                    else
                    {
                        dgvListar.CurrentRow.Cells[8].Value = 0;
                    }
                    dgvListar.CurrentRow.Cells[7].Value = pedido;
                }
                else
                {
                    dgvListar.CurrentRow.Cells[7].Value = 0m;
                    dgvListar.CurrentRow.Cells[8].Value = 0;
                }
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DataTable Detalle = new DataTable();
            Detalle.Columns.Add("Codigo", typeof(string));
            Detalle.Columns.Add("Referencia", typeof(string));
            Detalle.Columns.Add("Nombre", typeof(string));
            Detalle.Columns.Add("Marca", typeof(string));
            Detalle.Columns.Add("Cantidad", typeof(decimal));
            Detalle.Columns.Add("Costo", typeof(decimal));
            Detalle.Columns.Add("Importe", typeof(decimal));
            for (int i = 0; i < dgvListar.RowCount; i++)
            {
                if (Convert.ToBoolean(dgvListar.Rows[i].Cells[8].Value))
                {
                    DataRow row = Detalle.NewRow();
                    row[0] = Convert.ToString(dgvListar.Rows[i].Cells[1].Value);
                    row[1] = Convert.ToString(dgvListar.Rows[i].Cells[2].Value);
                    row[2] = Convert.ToString(dgvListar.Rows[i].Cells[3].Value);
                    row[3] = Convert.ToString(dgvListar.Rows[i].Cells[4].Value);
                    row[4] = Convert.ToDecimal(dgvListar.Rows[i].Cells[7].Value);
                    row[5] = Convert.ToDecimal(dgvListar.Rows[i].Cells[6].Value);
                    row[6] = Convert.ToDecimal(dgvListar.Rows[i].Cells[7].Value) * Convert.ToDecimal(dgvListar.Rows[i].Cells[6].Value);
                    Detalle.Rows.Add(row);
                }
            }
            rptListaCompra frm = new rptListaCompra(Detalle);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtIdSuplidor.Text = null;
                txtNombre.Text = null;
                btnGenerarLista.PerformClick();
            }
        }

        private void dgvListar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
