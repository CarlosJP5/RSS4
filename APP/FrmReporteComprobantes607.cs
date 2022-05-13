using Negocios;
using Negocios.NReportes;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP
{
    public partial class FrmReporteComprobantes607 : Form
    {
        public FrmReporteComprobantes607()
        {
            InitializeComponent();
        }

        private void FrmReporteComprobantes607_Load(object sender, EventArgs e)
        {
            cboTipoComprobante.SelectedIndex = 0;
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today.AddHours(23.99999);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            dgvListar.Rows.Clear();
            NComprobantes _comprobante = new NComprobantes();
            NrptEmpresa _empresa = new NrptEmpresa();
            string NombreEmpresa = _empresa.LlenaEmpresa();
            string query = @"SELECT C.rnc_cliente, C.cedula_cliente, CD.ncf_comprobante, F.fecha_factura,
                             F.itbis_factura, (F.total_factura - F.itbis_factura) AS Monto, F.id_factura,
                             C.nombre_cliente, F.total_factura, F.id_comprobante FROM Factura F
                             LEFT JOIN ComprobantesDetalle CD ON F.id_factura = CD.id_documento AND
                             F.id_comprobante = CD.id_comprobante LEFT JOIN Clientes C ON F.id_cliente = C.id_cliente";
            query += string.Format(@" WHERE F.fecha_factura BETWEEN '{0}' AND '{1}'", dtpDesde.Value, dtpHasta.Value); ;
            switch (cboTipoComprobante.SelectedIndex)
            {
                case 1:
                    query += " AND F.id_comprobante = 'B01'";
                    break;
                case 2:
                    query += " AND F.id_comprobante = 'B02'";
                    break;
            }
            query += " ORDER BY CD.ncf_comprobante";
            DataTable detalle = _comprobante.Reporte607(query);
            double itbis = 0;
            double monto = 0;
            for (int i = 0; i < detalle.Rows.Count; i++)
            {
                string Tp = "";
                string RNC = detalle.Rows[i][0].ToString();
                if (string.IsNullOrEmpty(RNC))
                {
                    RNC = detalle.Rows[i][1].ToString();
                }
                switch (RNC.Length)
                {
                    case 9:
                        Tp = "1";
                        break;
                    case 11:
                        Tp = "2";
                        break;
                    default:
                        Tp = "";
                        break;
                }
                string fecha = DateTime.Parse(detalle.Rows[i][3].ToString()).ToString("dd / MMM / yy");
                itbis += Convert.ToDouble(detalle.Rows[i][4]);
                monto += Convert.ToDouble(detalle.Rows[i][5]);
                _ = dgvListar.Rows.Add(RNC, Tp, detalle.Rows[i][2], fecha, detalle.Rows[i][4], detalle.Rows[i][5],
                    detalle.Rows[i][6], i + 1, detalle.Rows[i][7], detalle.Rows[i][4], detalle.Rows[i][5], NombreEmpresa);
            }
        }
    }
}
