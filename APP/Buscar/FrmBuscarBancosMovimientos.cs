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
    public partial class FrmBuscarBancosMovimientos : Form
    {
        public FrmBuscarBancosMovimientos()
        {
            InitializeComponent();
        }

        private readonly NFacturacion nfacturacion = new NFacturacion();

        private void FrmBuscarBancosMovimientos_Load(object sender, EventArgs e)
        {
            idBancoLbl.Text = "";
            idCtnBancoLbl.Text = "";
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today.AddHours(23.99999);
            string query = string.Format(@"select bm.id_movimiento, bm.fecha_movimiento, b.nombre_banco, bc.nombre_cnt_banco,
                                           bm.descripcion_movimiento, bm.debito_movimiento as retiro, bm.credito_movimiento as deposito
                                           from BancosMovimiento bm left join BancosCuentas bc on bm.id_ctn_banco = bc.id_cnt_banco
                                           left join Bancos b on bm.id_banco = b.id_banco
                                           where bm.fecha_movimiento between '{0}' and '{1}' order by bm.fecha_movimiento desc",
                                           dtpDesde.Value, dtpHasta.Value);
            DataTable data = nfacturacion.Buscar(query);
            foreach (DataRow row in data.Rows)
            {
                DateTime fecha = DateTime.Parse(row[1].ToString());
                _ = dgvListar.Rows.Add(row[0], fecha.ToString(" dd/MM/yyyy"), row[2], row[3], row[4], row[5], row[6]);
            }
        }

        private void bancoLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBuscarBancos frm = new FrmBuscarBancos();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                idBancoLbl.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                bancoLbl.Text = frm.dgvListar.SelectedCells[1].Value.ToString();
                nombreLbl.Text = "";
                numeroCuentaLbl.Text = "";
                idCtnBancoLbl.Text = "";
            }
        }

        private void cuentaLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBuscarBancosCuentas frm = new FrmBuscarBancosCuentas();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                idCtnBancoLbl.Text = frm.dgvListar.SelectedCells[0].Value.ToString();
                idBancoLbl.Text = frm.dgvListar.SelectedCells[1].Value.ToString();
                bancoLbl.Text = frm.dgvListar.SelectedCells[2].Value.ToString();
                nombreLbl.Text = frm.dgvListar.SelectedCells[3].Value.ToString();
                numeroCuentaLbl.Text = frm.dgvListar.SelectedCells[4].Value.ToString();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvListar.Rows.Clear();
            string query = string.Format(@"select bm.id_movimiento, bm.fecha_movimiento, b.nombre_banco, bc.nombre_cnt_banco,
                                           bm.descripcion_movimiento, bm.debito_movimiento as retiro, bm.credito_movimiento as deposito
                                           from BancosMovimiento bm left join BancosCuentas bc on bm.id_ctn_banco = bc.id_cnt_banco
                                           left join Bancos b on bm.id_banco = b.id_banco
                                           where bm.fecha_movimiento between '{0}' and '{1}'",
                                           dtpDesde.Value, dtpHasta.Value);
            if (!string.IsNullOrEmpty(idCtnBancoLbl.Text))
            {
                query += $" and bm.id_ctn_banco = '{idCtnBancoLbl.Text}'";
            }
            else if (!string.IsNullOrEmpty(idBancoLbl.Text))
            {
                query += $"and bm.id_banco = '{idBancoLbl.Text}'";
            }
            query += " order by bm.fecha_movimiento desc";
            DataTable data = nfacturacion.Buscar(query);
            foreach (DataRow row in data.Rows)
            {
                DateTime fecha = DateTime.Parse(row[1].ToString());
                _ = dgvListar.Rows.Add(row[0], fecha.ToString(" dd/MM/yyyy"), row[2], row[3], row[4], row[5], row[6]);
            }
        }
    }
}
