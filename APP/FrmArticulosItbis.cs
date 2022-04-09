using APP.Buscar;
using Negocios;
using System;
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
            if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtItbis.Text))
            {
                _itbis.Insertar(txtNombre.Text, txtItbis.Text);
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
    }
}
