using System.Data;
using System.Windows.Forms;

namespace APP
{
    public partial class FrmArticuloDialogIMEI : Form
    {
        public FrmArticuloDialogIMEI(DataTable data)
        {
            InitializeComponent();
            foreach (DataRow row in data.Rows)
            {
                _ = dgvListar.Rows.Add(row[0], row[1], row[2]);
            }
        }

        private void dgvListar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListar.Rows.Count > 0)
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
    }
}
