using APP.Buscar;
using Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP
{
    public partial class FrmArticulosCambiarCodigo : Form
    {
        public FrmArticulosCambiarCodigo()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                btnSalvar.PerformClick();
            }
            if (keyData == Keys.F1)
            {
                FrmBuscarArticulos frm = new FrmBuscarArticulos();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    DataTable dataArt = _articulo.BuscarId(frm.dgvListar.SelectedCells[0].Value.ToString());
                    lblIdArticulo.Text = dataArt.Rows[0][0].ToString();
                    txtCodigo.Text = dataArt.Rows[0][4].ToString();
                    txtNombre.Text = dataArt.Rows[0][5].ToString();
                    _ = txtNuevoCodigo.Focus();
                }
                else
                {
                    lblIdArticulo.Text = null;
                    txtNombre.Text = null;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private readonly NArticulos _articulo = new NArticulos();

        private void FrmArticulosCambiarCodigo_Load(object sender, EventArgs e)
        {
            btnNuevo.PerformClick();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = null;
            txtNombre.Text = null;
            txtNuevoCodigo.Text = null;
            errorCodigo.Clear();
            errorNombre.Clear();
            _ = txtCodigo.Focus();
        }

        private void linkCodigo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBuscarArticulos frm = new FrmBuscarArticulos();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataTable dataArt = _articulo.BuscarId(frm.dgvListar.SelectedCells[0].Value.ToString());
                lblIdArticulo.Text = dataArt.Rows[0][0].ToString();
                txtCodigo.Text = dataArt.Rows[0][4].ToString();
                txtNombre.Text = dataArt.Rows[0][5].ToString();
                _ = txtNuevoCodigo.Focus();
            }
            else
            {
                lblIdArticulo.Text = null;
                txtNombre.Text = null;
            }
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                DataTable articulo = _articulo.BuscarCodigo(txtCodigo.Text);
                if (articulo.Rows.Count > 0)
                {
                    lblIdArticulo.Text = articulo.Rows[0][0].ToString();
                    txtCodigo.Text = articulo.Rows[0][4].ToString();
                    txtNombre.Text = articulo.Rows[0][5].ToString();
                    _ = txtNuevoCodigo.Focus();
                }
                else
                {
                    lblIdArticulo.Text = null;
                    txtNombre.Text = null;
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                errorNombre.SetError(txtNombre, "No hay Articulo Seleccionado");
                return;
            }
            else
            {
                errorNombre.Clear();
            }
            if (string.IsNullOrEmpty(txtNuevoCodigo.Text))
            {
                errorCodigo.SetError(txtNuevoCodigo, "No hay Codigo nuevo");
                _ = txtNuevoCodigo.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(txtNuevoCodigo.Text))
            {
                DataTable articulo = _articulo.BuscarCodigo(txtNuevoCodigo.Text);
                if (articulo.Rows.Count > 0)
                {
                    errorCodigo.SetError(txtNuevoCodigo, "Codigo Ya Existe");
                    _ = txtNuevoCodigo.Focus();
                    return;
                }
                else
                {
                    errorCodigo.Clear();
                    _articulo.CambiarCodigo(lblIdArticulo.Text, txtNuevoCodigo.Text);
                    btnNuevo.PerformClick();
                }
            }
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = txtNuevoCodigo.Focus();
            }
        }

        private void txtNuevoCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSalvar.PerformClick(); 
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
