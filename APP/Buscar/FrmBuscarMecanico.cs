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
    public partial class FrmBuscarMecanico : Form
    {
        public FrmBuscarMecanico()
        {
            InitializeComponent();
        }

        private readonly NMecanico nMecanico = new NMecanico();

        private void Buscar(string nombre = "")
        {
            dgvListar.Rows.Clear();
            DataTable data = nMecanico.Buscar(nombre);
            foreach (DataRow row in data.Rows)
            {
                dgvListar.Rows.Add(row[0], row[1], row[2]);
            }
        }

        private void FrmBuscarMecanico_Load(object sender, EventArgs e)
        {
            Buscar();   
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Buscar(txtBuscar.Text);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar(txtBuscar.Text);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                btnBuscar.PerformClick();
            }
        }

        private void dgvListar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListar.RowCount > 0)
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
