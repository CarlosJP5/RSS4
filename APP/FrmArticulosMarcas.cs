using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace APP
{
    public partial class FrmArticulosMarcas : Form
    {
        public FrmArticulosMarcas()
        {
            InitializeComponent();
            MarcasCollection();
        }

        private readonly NMarcas _marcas = new NMarcas();

        private void MarcasCollection()
        {
            List<string> strList = null;
            strList = new List<string>();
            DataTable data = _marcas.Listar();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                strList.Add(data.Rows[i][1].ToString());
            }
            var autoCollection = new AutoCompleteStringCollection();
            autoCollection.AddRange(strList.ToArray());
            txtNombre.AutoCompleteCustomSource = autoCollection;
            txtNombre.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtNombre.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void FrmArticulosMarcas_Load(object sender, EventArgs e)
        {
            btnNuevo.PerformClick();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MarcasCollection();
            txtCodigo.Text = _marcas.MaxId().ToString();
            txtNombre.Text = null;
            _ = txtNombre.Focus();
            btnModificar.Enabled = false;
            btnSalvar.Enabled = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                _marcas.Insertar(txtNombre.Text);
                btnNuevo.PerformClick();
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {

            }
        }
    }
}
