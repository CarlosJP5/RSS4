using Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP.Buscar
{
    public partial class FrmBuscarCajas : Form
    {
        public FrmBuscarCajas()
        {
            InitializeComponent();
        }

        private readonly NFacturacion cajaN = new NFacturacion();

        private void FrmBuscarCajas_Load(object sender, EventArgs e)
        {
            cboEstado.SelectedIndex = 0;
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today.AddHours(23.99999);
            btnBuscar.PerformClick();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listarDgv.Rows.Clear();
            string query = string.Format(@"select id_caja, apertura_caja, apertura_nombre,
                                           total_caja, estado_caja from Caja 
                                           where apertura_caja between '{0}' and '{1}'",
                                           dtpDesde.Value, dtpHasta.Value);
            if (cboEstado.SelectedIndex == 1)
            {
                query += " and estado_caja = 'abierta'";
            }
            else if (cboEstado.SelectedIndex == 2)
            {
                query += " and estado_caja = 'cerrada'";
            }
            query += " order by id_caja desc";
            DataTable cajaData = cajaN.Buscar(query);
            foreach (DataRow row in cajaData.Rows)
            {
                DateTime fecha = DateTime.Parse(row[1].ToString());
                listarDgv.Rows.Add(row[0], fecha.ToString("dd /MM / yyy hh:mm tt"), row[2], row[3], row[4]);
            }
        }

        private void listarDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (listarDgv.RowCount > 0)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void listarDgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (listarDgv.RowCount > 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    listarDgv.CurrentRow.Selected = true;
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (listarDgv.RowCount > 0)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
