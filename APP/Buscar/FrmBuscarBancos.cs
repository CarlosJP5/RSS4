using Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP.Buscar
{
    public partial class FrmBuscarBancos : Form
    {
        private readonly NBancos nbancos = new NBancos();

        public FrmBuscarBancos()
        {
            InitializeComponent();
        }

        private void FrmBuscarBancos_Load(object sender, EventArgs e)
        {
            DataTable datos = nbancos.BuscarNombre("");
            foreach (DataRow row in datos.Rows)
            {
                _ = dgvListar.Rows.Add(row[0], row[1]);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvListar.Rows.Clear();
            DataTable datos = nbancos.BuscarNombre(txtBuscar.Text);
            foreach (DataRow row in datos.Rows)
            {
                _ = dgvListar.Rows.Add(row[0], row[1]);
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

        private void dgvListar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListar.RowCount > 0)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvListar.RowCount > 0)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
