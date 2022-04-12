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
    public partial class FrmBuscarSuplidores : Form
    {
        public FrmBuscarSuplidores()
        {
            InitializeComponent();
        }

        private readonly NSuplidores _suplidores = new NSuplidores();

        private void FrmBuscarSuplidores_Load(object sender, EventArgs e)
        {
            rbtnTodo.Checked = true;
            DataTable suplidor = _suplidores.Listar();
            foreach (DataRow suplidorRow in suplidor.Rows)
            {
                dgvListar.Rows.Add(suplidorRow[0], suplidorRow[2], suplidorRow[1],
                    suplidorRow[6], suplidorRow[4], suplidorRow[7]);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvListar.Rows.Clear();
            string query = @"SELECT id_suplidor, nombre_suplidor, rnc_suplidor, direccion_suplidor, telefono_suplidor,
	                         correo_suplidor, vendedor_suplidor, cell_suplidor, tipoCompra_suplidor, estado_suplidor
	                         FROM Suplidores ";
            if (rbtnTodo.Checked)
            {
                query += string.Format("WHERE id_suplidor LIKE '%'+'{0}'+'%' OR nombre_suplidor LIKE '%'+'{0}'+'%' " +
                    "OR rnc_suplidor LIKE '%'+'{0}'+'%' OR vendedor_suplidor LIKE '%'+'{0}'+'%'", txtBuscar.Text);
            }
            else if (rbtnCodigo.Checked)
            {
                query += string.Format("WHERE id_suplidor LIKE '%'+'{0}'+'%'", txtBuscar.Text);
            }
            else if (rbtnNombre.Checked)
            {
                query += string.Format("WHERE nombre_suplidor LIKE '%'+'{0}'+'%'", txtBuscar.Text);
            }
            else if (rbtnRNC.Checked)
            {
                query += string.Format("WHERE rnc_suplidor LIKE '%'+'{0}'+'%'", txtBuscar.Text);
            }
            else if (rbtnVendedor.Checked)
            {
                query += string.Format("WHERE vendedor_suplidor LIKE '%'+'{0}'+'%'", txtBuscar.Text);
            }
            query += "  ORDER BY nombre_suplidor";
            DataTable suplidor = _suplidores.Buscar(query);
            foreach (DataRow suplidorRow in suplidor.Rows)
            {
                dgvListar.Rows.Add(suplidorRow[0], suplidorRow[2], suplidorRow[1],
                    suplidorRow[6], suplidorRow[4], suplidorRow[7]);
            }
        }
    }
}
