using APP.Buscar;
using Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP
{
    public partial class FrmArticulosMarcas : Form
    {
        public FrmArticulosMarcas()
        {
            InitializeComponent();
        }

        private readonly NMarcas _marcas = new NMarcas();

        //private void MarcasCollection()
        //{
        //    List<string> strList = null;
        //    strList = new List<string>();
        //    DataTable data = _marcas.Listar();
        //    for (int i = 0; i < data.Rows.Count; i++)
        //    {
        //        strList.Add(data.Rows[i][1].ToString());
        //    }
        //    var autoCollection = new AutoCompleteStringCollection();
        //    autoCollection.AddRange(strList.ToArray());
        //    txtNombre.AutoCompleteCustomSource = autoCollection;
        //    txtNombre.AutoCompleteMode = AutoCompleteMode.Suggest;
        //    txtNombre.AutoCompleteSource = AutoCompleteSource.CustomSource;
        //}

        private void FrmArticulosMarcas_Load(object sender, EventArgs e)
        {
            btnNuevo.PerformClick();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = _marcas.MaxId().ToString();
            txtNombre.Text = null;
            errorProvider1.Clear();
            _ = txtNombre.Focus();
            txtNombre.Enabled = true;
            btnModificar.Enabled = false;
            btnSalvar.Enabled = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "Campo Obligatorio");
                txtNombre.AllowDrop = true;
            }
            else
            {
                errorProvider1.Clear();
                txtNombre.AllowDrop = false;
            }
            if (!txtNombre.AllowDrop)
            {
                DataTable marca = _marcas.BuscarId(txtCodigo.Text);
                if (marca.Rows.Count > 0)
                {
                    // Modificar Marca
                    _marcas.Editar(txtCodigo.Text, txtNombre.Text);
                }
                else
                {
                    // Crear Marca
                    _marcas.Insertar(txtNombre.Text);
                }
                btnNuevo.PerformClick();
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                DataTable marca = _marcas.BuscarNombre(txtNombre.Text);
                if (marca.Rows.Count > 0)
                {
                    txtCodigo.Text = marca.Rows[0][0].ToString();
                    txtNombre.Enabled = false;
                    btnSalvar.Enabled = false;
                    btnModificar.Enabled = true;
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            txtNombre.Enabled = true;
            btnSalvar.Enabled = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarMarcas frm = new FrmBuscarMarcas();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtCodigo.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                txtNombre.Text = frm.dgvListar.SelectedCells[1].Value.ToString();
                txtNombre.Enabled = false;
                btnSalvar.Enabled = false;
                btnModificar.Enabled = true;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                _ = btnSalvar.Focus();
            }
        }
    }
}
