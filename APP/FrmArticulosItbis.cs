using APP.Buscar;
using Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP
{
    public partial class FrmArticulosItbis : Form
    {
        public FrmArticulosItbis()
        {
            InitializeComponent();
        }

        private readonly NItbis _itbis = new NItbis();

        private void FrmArticulosItbis_Load(object sender, EventArgs e)
        {
            btnNuevo.PerformClick();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = _itbis.MaxId().ToString();
            txtNombre.Text = null;
            txtItbis.Text = null;
            _ = txtNombre.Focus();
            btnModificar.Enabled = false;
            btnSalvar.Enabled = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            DataTable itbis = _itbis.BuscarId(txtCodigo.Text);
            _ = ValidateChildren();
            if (txtNombre.AllowDrop == false && txtItbis.AllowDrop == false)
            {
                if (itbis.Rows.Count > 0)
                {
                    // Editar Itbis
                    _itbis.Editar(txtCodigo.Text, txtNombre.Text, txtItbis.Text);
                }
                else
                {
                    // Crear Itbis
                    _itbis.Insertar(txtNombre.Text, txtItbis.Text);
                }
                btnNuevo.PerformClick();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarItbis frm = new FrmBuscarItbis();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtCodigo.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                txtNombre.Text = frm.dgvListar.SelectedCells[1].Value.ToString();
                txtItbis.Text = frm.dgvListar.SelectedCells[2].Value.ToString();

                btnModificar.Enabled = true;
                btnSalvar.Enabled = false;
                txtNombre.Enabled = false;
                txtItbis.Enabled = false;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            btnSalvar.Enabled = true;
            txtNombre.Enabled = true;
            txtItbis.Enabled = true;
        }

        private void txtNombre_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                errorProviderNombre.SetError(txtNombre, "Campo Obligatorio");
                txtNombre.AllowDrop = true;
            }
            else
            {
                errorProviderNombre.Clear();
                txtNombre.AllowDrop = false;
            }
        }

        private void txtItbis_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtItbis.Text))
            {
                errorProviderPorciento.SetError(txtItbis, "Campo Obligatorio");
                txtItbis.AllowDrop = true;
            }
            else
            {
                errorProviderPorciento.Clear();
                txtItbis.AllowDrop = false;
            }
        }

        private void txtItbis_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
