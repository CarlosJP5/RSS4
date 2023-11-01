using IronBarCode;
using Negocios;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace APP
{
    public partial class FrmArticulosCodigoBarra : Form
    {
        public FrmArticulosCodigoBarra()
        {
            InitializeComponent();
        }

        private readonly NArticulos nArticulos = new NArticulos();

        private int count = 0;

        private void CrearCodigoBarra(string codigo = "")
        {
            DataTable articuloData = nArticulos.BuscarCodigo(codigo);
            if (articuloData.Rows.Count > 0)
            {
                count++;
                txtIdArticulo.Text = articuloData.Rows[0][0].ToString();
                txtCodigo.Text = articuloData.Rows[0][4].ToString();
                txtNombre.Text = articuloData.Rows[0][5].ToString();
                var myBarcode = BarcodeWriter.CreateBarcode(txtCodigo.Text, BarcodeWriterEncoding.Code93);
                _ = myBarcode.AddBarcodeValueTextBelowBarcode();
                _ = myBarcode.SaveAsImage($@"C:\Temp\bcode{count}.jpeg");
                picBarCode.Image = Image.FromFile($@"C:\Temp\bcode{count}.jpeg");

            }
        }

        private void FrmArticulosCodigoBarra_Load(object sender, EventArgs e)
        {

        }

        private void txtCodigo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                CrearCodigoBarra(txtCodigo.Text.Trim());
            }
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                _ = btnImprimir.Focus();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
