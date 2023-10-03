using Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP.Buscar
{
    public partial class FrmBuscarBancosCuentas : Form
    {
        private readonly NBancos nbancos = new NBancos();

        public FrmBuscarBancosCuentas()
        {
            InitializeComponent();
        }

        private void FrmBuscarBancosCuentas_Load(object sender, EventArgs e)
        {
            DataTable datos = nbancos.BuscarCuentaNombre("");
            foreach (DataRow row in datos.Rows)
            {
                _ = dgvListar.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5]);
            }
        }

        private void buscarBtn_Click(object sender, EventArgs e)
        {
            dgvListar.Rows.Clear();
            DataTable datos = nbancos.BuscarCuentaNombre(nombreTxt.Text);
            foreach (DataRow row in datos.Rows)
            {
                _ = dgvListar.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5]);
            }
        }

        private void nombreTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                buscarBtn.PerformClick();
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

        private void aceptarBtn_Click(object sender, EventArgs e)
        {
            if (dgvListar.RowCount > 0)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void cancelarBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
