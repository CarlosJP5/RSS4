using APP.Buscar;
using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace APP
{
    public partial class FrmArticulos : Form
    {
        public FrmArticulos()
        {
            InitializeComponent();
            LlenarMarcas();
            LlenarSuplidor();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                btnSalvar.PerformClick();
            }
            if (keyData == Keys.F1)
            {
                btnBuscar.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private readonly NArticulos _articulos = new NArticulos();
        private readonly NMarcas _marca = new NMarcas();

        private void FrmArticulos_Load(object sender, EventArgs e)
        {
            btnNuevo.PerformClick();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ActivaControles();
            txtCodigo.Enabled = true;
            txtIdArticulo.Text = null;
            txtCodigo.Text = null;
            txtCantidad.Text = null;
            if (!ckbPlanilla.Checked)
            {
                txtNombre.Text = null;
                txtReferencia.Text = null;
                txtMarca.Text = null;
                txtIdMarca.Text = null;
                txtIdSuplidor.Text = null;
                txtSuplidor.Text = null;
                txtPuntoReorden.Text = null;
                txtCosto.Text = null;
                txtPrecio.Text = null;
                txtBeneficio.Text = null;
                cboEstado.SelectedIndex = 0;
                txtBeneficioMinimo.Text = "20.00";
            }
            txtIdItbis.Text = "1";
            txtIdItbis_Leave(sender, e);
            errorCodigo.Clear();
            errorItbis.Clear();
            errorNombre.Clear();
            _ = txtCodigo.Focus();
            btnModificar.Enabled = false;
            btnSalvar.Enabled = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtItbis.Text))
            {
                errorItbis.SetError(txtItbis, "Campo Obligatorio");
                txtItbis.AllowDrop = true;
            }
            else
            {
                errorItbis.Clear();
                txtItbis.AllowDrop = false;
            }
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                errorCodigo.SetError(txtCodigo, "Campo Obligatorio");
                txtCodigo.AllowDrop = true;
            }
            else
            {
                errorCodigo.Clear();
                txtCodigo.AllowDrop = false;
            }
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                errorNombre.SetError(txtNombre, "Campo Obligatorio");
                txtNombre.AllowDrop = true;
            }
            else
            {
                errorNombre.Clear();
                txtNombre.AllowDrop = false;
            }
            if (!txtCodigo.AllowDrop && !txtNombre.AllowDrop && !txtItbis.AllowDrop)
            {
                EArticulo articulo = new EArticulo
                {
                    Codigo = txtCodigo.Text,
                    Nombre = txtNombre.Text,
                    Referencia = txtReferencia.Text
                };

                if (!string.IsNullOrEmpty(txtIdMarca.Text) && !string.IsNullOrEmpty(txtMarca.Text))
                {
                    articulo.IdMarca = Convert.ToInt16(txtIdMarca.Text);
                }
                else if (string.IsNullOrEmpty(txtIdMarca.Text) && !string.IsNullOrEmpty(txtMarca.Text))
                {
                    // Marca nueva
                    articulo.IdMarca = _marca.Insertar(txtMarca.Text);
                    LlenarMarcas();
                }

                if (!string.IsNullOrEmpty(txtSuplidor.Text))
                {
                    articulo.IdSuplidor = Convert.ToInt16(txtIdSuplidor.Text);
                }
                if (!string.IsNullOrEmpty(txtItbis.Text))
                {
                    articulo.IdItbis = Convert.ToInt16(txtIdItbis.Text);
                }
                if (!string.IsNullOrEmpty(txtPuntoReorden.Text))
                {
                    articulo.PuntoReorden = Convert.ToInt16(txtPuntoReorden.Text);
                }
                if (!string.IsNullOrEmpty(txtCantidad.Text))
                {
                    articulo.Cantidad = Convert.ToDecimal(txtCantidad.Text);
                }
                if (!string.IsNullOrEmpty(txtCosto.Text))
                {
                    articulo.Costo = Convert.ToDecimal(txtCosto.Text);
                }
                if (!string.IsNullOrEmpty(txtPrecio.Text))
                {
                    articulo.Precio = Convert.ToDecimal(txtPrecio.Text);
                }
                if (!string.IsNullOrEmpty(txtBeneficio.Text))
                {
                    articulo.Beneficio = Convert.ToDecimal(txtBeneficio.Text);
                }
                if (!string.IsNullOrEmpty(txtBeneficioMinimo.Text))
                {
                    articulo.BeneficioMinimo = Convert.ToDecimal(txtBeneficioMinimo.Text);
                }
                articulo.Estado = cboEstado.SelectedIndex == 0;
                if (string.IsNullOrEmpty(txtIdArticulo.Text))
                {
                    // Crear
                    _articulos.Insertar(articulo);
                }
                else
                {
                    // Editar
                    articulo.Id = Convert.ToInt32(txtIdArticulo.Text);
                    _articulos.Editar(articulo);

                }
                btnNuevo.PerformClick();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarArticulos frm = new FrmBuscarArticulos();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataTable articulo = _articulos.BuscarId(frm.dgvListar.SelectedCells[0].Value.ToString());
                txtIdArticulo.Text = articulo.Rows[0][0].ToString();
                txtIdMarca.Text = articulo.Rows[0][1].ToString();
                txtIdItbis.Text = articulo.Rows[0][2].ToString();
                txtIdSuplidor.Text = articulo.Rows[0][3].ToString();
                txtCodigo.Text = articulo.Rows[0][4].ToString();
                txtNombre.Text = articulo.Rows[0][5].ToString();
                txtReferencia.Text = articulo.Rows[0][6].ToString();
                txtPuntoReorden.Text = articulo.Rows[0][7].ToString();
                txtCantidad.Text = articulo.Rows[0][8].ToString();
                txtCosto.Text = articulo.Rows[0][9].ToString();
                txtPrecio.Text = articulo.Rows[0][10].ToString();
                txtBeneficio.Text = articulo.Rows[0][11].ToString();
                cboEstado.SelectedIndex = (bool)articulo.Rows[0][12] ? 0 : 1;
                txtMarca.Text = articulo.Rows[0][13].ToString();
                txtItbis.Text = articulo.Rows[0][14].ToString();
                txtPorcientoItbis.Text = articulo.Rows[0][15].ToString();
                txtSuplidor.Text = articulo.Rows[0][16].ToString();
                txtBeneficioMinimo.Text = articulo.Rows[0][17].ToString();

                DesactivaControles();
                btnModificar.Enabled = true;
                btnSalvar.Enabled = false;
            }
        }

        private void DesactivaControles()
        {
            txtIdArticulo.Enabled = false;
            txtIdMarca.Enabled = false;
            txtIdItbis.Enabled = false;
            txtIdSuplidor.Enabled = false;
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
            txtReferencia.Enabled = false;
            txtPuntoReorden.Enabled = false;
            txtCantidad.Enabled = false;
            txtCosto.Enabled = false;
            txtPrecio.Enabled = false;
            txtBeneficio.Enabled = false;
            cboEstado.Enabled = false;
            txtMarca.Enabled = false;
            txtItbis.Enabled = false;
            txtPorcientoItbis.Enabled = false;
            txtSuplidor.Enabled = false;
            txtBeneficioMinimo.Enabled = false;
        }

        private void ActivaControles()
        {
            txtIdArticulo.Enabled = true;
            txtIdMarca.Enabled = true;
            txtIdItbis.Enabled = true;
            txtIdSuplidor.Enabled = true;
            //txtCodigo.Enabled = true;
            txtNombre.Enabled = true;
            txtReferencia.Enabled = true;
            txtPuntoReorden.Enabled = true;
            //txtCantidad.Enabled = true;
            txtCosto.Enabled = true;
            txtPrecio.Enabled = true;
            txtBeneficio.Enabled = true;
            cboEstado.Enabled = true;
            txtMarca.Enabled = true;
            txtItbis.Enabled = true;
            txtPorcientoItbis.Enabled = true;
            txtSuplidor.Enabled = true;
            txtBeneficioMinimo.Enabled = true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ActivaControles();
            btnSalvar.Enabled = true;
            _ = txtNombre.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult msj = MessageBox.Show("Desea Salir", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msj == DialogResult.Yes)
            {
                Close();
            }
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                DataTable articulo = _articulos.BuscarCodigo(txtCodigo.Text);
                if (articulo.Rows.Count > 0)
                {
                    txtIdArticulo.Text = articulo.Rows[0][0].ToString();
                    txtIdMarca.Text = articulo.Rows[0][1].ToString();
                    txtIdItbis.Text = articulo.Rows[0][2].ToString();
                    txtIdSuplidor.Text = articulo.Rows[0][3].ToString();
                    txtCodigo.Text = articulo.Rows[0][4].ToString();
                    txtNombre.Text = articulo.Rows[0][5].ToString();
                    txtReferencia.Text = articulo.Rows[0][6].ToString();
                    txtPuntoReorden.Text = articulo.Rows[0][7].ToString();
                    txtCantidad.Text = articulo.Rows[0][8].ToString();
                    txtCosto.Text = articulo.Rows[0][9].ToString();
                    txtPrecio.Text = articulo.Rows[0][10].ToString();
                    txtBeneficio.Text = articulo.Rows[0][11].ToString();
                    cboEstado.SelectedIndex = (bool)articulo.Rows[0][12] ? 0 : 1;
                    txtMarca.Text = articulo.Rows[0][13].ToString();
                    txtItbis.Text = articulo.Rows[0][14].ToString();
                    txtPorcientoItbis.Text = articulo.Rows[0][15].ToString();
                    txtSuplidor.Text = articulo.Rows[0][16].ToString();
                    txtBeneficioMinimo.Text = articulo.Rows[0][17].ToString();

                    DesactivaControles();
                    btnModificar.Enabled = true;
                    btnSalvar.Enabled = false;
                }
            }
        }

        private void txtIdMarca_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdMarca.Text))
            {
                
                DataTable marca = _marca.BuscarId(txtIdMarca.Text);
                if (marca.Rows.Count > 0)
                {
                    txtMarca.Text = marca.Rows[0][1].ToString();
                }
                else
                {
                    txtIdMarca.Text = null;
                    txtMarca.Text = null;
                }
            }
        }

        private void txtMarca_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMarca.Text))
            {
                NMarcas _marca = new NMarcas();
                DataTable marca = _marca.BuscarNombre(txtMarca.Text);
                if (marca.Rows.Count > 0)
                {
                    txtIdMarca.Text = marca.Rows[0][0].ToString();
                }
                else
                {
                    txtIdMarca.Text = null;
                }
            }
        }

        private void LlenarMarcas()
        {
            NMarcas _marca = new NMarcas();
            List<string> strList = null;
            strList = new List<string>();
            DataTable data = _marca.Listar();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                strList.Add(data.Rows[i][1].ToString());
            }
            var autoCollection = new AutoCompleteStringCollection();
            autoCollection.AddRange(strList.ToArray());
            txtMarca.AutoCompleteCustomSource = autoCollection;
            txtMarca.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtMarca.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void txtIdSuplidor_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdSuplidor.Text))
            {
                NSuplidores _suplidor = new NSuplidores();
                DataTable suplidor = _suplidor.BuscarId(txtIdSuplidor.Text);
                if (suplidor.Rows.Count > 0)
                {
                    txtSuplidor.Text = suplidor.Rows[0][1].ToString();
                }
                else
                {
                    txtIdSuplidor.Text = null;
                    txtSuplidor.Text = null;
                }
            }
        }

        private void txtSuplidor_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSuplidor.Text))
            {
                NSuplidores _suplidor = new NSuplidores();
                DataTable suplidor = _suplidor.BuscarNombre(txtSuplidor.Text);
                if (suplidor.Rows.Count > 0)
                {
                    txtIdSuplidor.Text = suplidor.Rows[0][0].ToString();
                }
                else
                {
                    txtIdSuplidor.Text = null;
                    txtSuplidor.Text = null;
                }
            }
        }

        private void LlenarSuplidor()
        {
            NSuplidores _suplidor = new NSuplidores();
            List<string> strList = null;
            strList = new List<string>();
            DataTable data = _suplidor.Listar();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                strList.Add(data.Rows[i][1].ToString());
            }
            var autoCollection = new AutoCompleteStringCollection();
            autoCollection.AddRange(strList.ToArray());
            txtSuplidor.AutoCompleteCustomSource = autoCollection;
            txtSuplidor.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtSuplidor.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void txtIdItbis_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdItbis.Text))
            {
                NItbis _itbis = new NItbis();
                DataTable itb = _itbis.BuscarId(txtIdItbis.Text);
                if (itb.Rows.Count > 0)
                {
                    txtItbis.Text = itb.Rows[0][1].ToString();
                    txtPorcientoItbis.Text = itb.Rows[0][2].ToString();
                }
                else
                {
                    txtIdItbis.Text = null;
                    txtItbis.Text = null;
                    txtPorcientoItbis.Text = null;
                }
            }
        }

        private void linkMarca_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBuscarMarcas frm = new FrmBuscarMarcas();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtIdMarca.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                txtMarca.Text = frm.dgvListar.SelectedCells[1].Value.ToString();
            }
        }

        private void linkSuplidor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBuscarSuplidores frm = new FrmBuscarSuplidores();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtIdSuplidor.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                txtSuplidor.Text = frm.dgvListar.SelectedCells[2].Value.ToString();
            }
        }

        private void linkItbis_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBuscarItbis frm = new FrmBuscarItbis();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtIdItbis.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                txtItbis.Text = frm.dgvListar.SelectedCells[1].Value.ToString();
            }
        }

        private void txtIdMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPrecio_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPrecio.Text))
            {
                double precio = Convert.ToDouble(txtPrecio.Text);
                txtPrecio.Text = precio.ToString("N2");
                if (!string.IsNullOrEmpty(txtCosto.Text))
                {
                    double costo = Convert.ToDouble(txtCosto.Text);
                    txtCosto.Text = costo.ToString("N2");
                    double beneficio = (precio - costo) / costo * 100;
                    if (costo == 0)
                    {
                        beneficio = 100;
                    }
                    txtBeneficio.Text = beneficio.ToString("N2");
                }
            }
        }

        private void txtBeneficio_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBeneficio.Text))
            {
                double beneficio = Convert.ToDouble(txtBeneficio.Text);
                txtBeneficio.Text = beneficio.ToString("N2");
                if (!string.IsNullOrEmpty(txtCosto.Text))
                {
                    double costo = Convert.ToDouble(txtCosto.Text);
                    txtCosto.Text = costo.ToString("N2");
                    if (costo != 0)
                    {
                        double precio = ((beneficio / 100) + 1) * costo;
                        txtPrecio.Text = precio.ToString("N2");
                    }
                }
            }
        }

        private void txtCodigo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                errorCodigo.Clear();
                txtCodigo.AllowDrop = false;
            }
        }

        private void txtNombre_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                errorNombre.Clear();
                txtNombre.AllowDrop = false;
            }
        }

        private void txtItbis_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtItbis.Text))
            {
                errorItbis.Clear();
                txtItbis.AllowDrop = false;
            }
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = txtNombre.Focus();
            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = txtReferencia.Focus();
            }
        }

        private void txtReferencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = txtIdMarca.Focus();
            }
        }

        private void txtIdMarca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = txtIdSuplidor.Focus();
            }
        }

        private void txtIdSuplidor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = txtIdItbis.Focus();
            }
        }

        private void txtIdItbis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = txtPuntoReorden.Focus();
            }
        }

        private void txtPuntoReorden_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = txtCosto.Focus();
            }
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = txtCosto.Focus();
            }
        }

        private void txtCosto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = txtPrecio.Focus();
            }
        }

        private void txtPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = txtBeneficio.Focus();
            }
        }

        private void txtBeneficio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = txtBeneficioMinimo.Focus();
            }
        }

        private void txtBeneficioMinimo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = cboEstado.Focus();
            }
        }

        private void cboEstado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _ = btnSalvar.Focus();
            }
        }

    }
}
