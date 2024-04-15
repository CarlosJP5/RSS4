using Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP.Buscar
{
    public partial class FrmBuscarGastoTipo : Form
    {
        public FrmBuscarGastoTipo()
        {
            InitializeComponent();
        }

        private readonly NGasto nGasto = new NGasto();

        private void Buscar(string nombre = "")
        {
            listarDgv.Rows.Clear();
            DataTable data = nGasto.Buscar(nombre);
            foreach (DataRow row in data.Rows)
            {
                _ = listarDgv.Rows.Add(row[0], row[1]);
            }
        }

        private void FrmBuscarGastoTipo_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        private void nombreTxt_TextChanged(object sender, EventArgs e)
        {
            Buscar(nombreTxt.Text.Trim());
        }

        private void buscarBtn_Click(object sender, EventArgs e)
        {
            Buscar(nombreTxt.Text.Trim());
        }

        private void listarDgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listarDgv.CurrentRow.Selected = true;
                e.SuppressKeyPress = true;
                e.Handled = true;
                DialogResult = DialogResult.OK;
            }
        }

        private void aceptarBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void listarDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void salirBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
