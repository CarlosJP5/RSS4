using Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP.Buscar
{
    public partial class FrmBuscarGastoRegistro : Form
    {
        public FrmBuscarGastoRegistro()
        {
            InitializeComponent();
            DataTable data = nGasto.Buscar("");

            DataRow dr = data.NewRow();
            dr["id_gasto"] = 0;
            dr["nombre_gasto"] = "- - -";
            data.Rows.InsertAt(dr, 0);

            tipoGastoCbo.DataSource = data;
            tipoGastoCbo.ValueMember = "id_gasto";
            tipoGastoCbo.DisplayMember = "nombre_gasto";
        }

        private readonly NGasto nGasto = new NGasto();

        private void FrmBuscarGastoRegistro_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today.AddHours(23.99999);
            DataTable dt = nGasto.BuscarDetalle(dtpDesde.Value, dtpHasta.Value);
            foreach (DataRow dr in dt.Rows)
            {
                _ = listarDgv.Rows.Add(dr[0], dr[3], dr[2], dr[5], dr[4], dr[1]);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listarDgv.Rows.Clear();
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(idRegistroTxt.Text))
            {
                if(int.TryParse(idRegistroTxt.Text, out int idRegistro))
                {
                    dt = nGasto.BuscarDetalle(idRegistro);
                }
                else
                {
                    idRegistroTxt.Text = "";
                }
            }
            else if (tipoGastoCbo.SelectedIndex != 0)
            {
                dt = nGasto.BuscarDetalle(dtpDesde.Value, dtpHasta.Value, (int)tipoGastoCbo.SelectedValue);   
            }
            else
            {
                dt = nGasto.BuscarDetalle(dtpDesde.Value, dtpHasta.Value);
            }
            foreach (DataRow dr in dt.Rows)
            {
                _ = listarDgv.Rows.Add(dr[0], dr[3], dr[2], dr[5], dr[4], dr[1]);
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

        private void listarDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (listarDgv.RowCount > 0)
            {
                DialogResult = DialogResult.OK;
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
