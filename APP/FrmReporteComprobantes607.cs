using Microsoft.Office.Interop.Excel;
using Negocios;
using Negocios.NReportes;
using System;
using System.Data;
using System.Threading;
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
            
            string query = @"SELECT C.rnc_cliente, C.cedula_cliente, CD.ncf_comprobante, F.fecha_factura,
                             F.itbis_factura, (F.total_factura - F.itbis_factura) AS Monto, F.id_factura,
                             C.nombre_cliente, F.total_factura, F.id_comprobante FROM Factura F
                             LEFT JOIN ComprobantesDetalle CD ON CAST(F.id_factura as varchar) = CD.id_documento AND
                             F.id_comprobante = CD.id_comprobante LEFT JOIN Clientes C ON F.id_cliente = C.id_cliente";
            query += string.Format(@" WHERE F.fecha_factura BETWEEN '{0}' AND '{1}'", dtpDesde.Value, dtpHasta.Value);
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
            System.Data.DataTable detalle = _comprobante.Reporte607(query);
            LlenarDataGrid(detalle);

            string querys = @"SELECT C.rnc_cliente, C.cedula_cliente, CD.ncf_comprobante, F.fecha_fservicio,
                              F.itbis_fservicio, (F.total_fservicio - F.itbis_fservicio) AS Monto, F.id_fservicio_st,
                              C.nombre_cliente, F.total_fservicio, F.id_comprobante FROM FacturaServicio F
                              LEFT JOIN ComprobantesDetalle CD ON F.id_fservicio_st = CD.id_documento AND
                              F.id_comprobante = CD.id_comprobante LEFT JOIN Clientes C ON F.id_cliente = C.id_cliente";
            querys += string.Format(@" WHERE F.fecha_fservicio BETWEEN '{0}' AND '{1}'", dtpDesde.Value, dtpHasta.Value);
            switch (cboTipoComprobante.SelectedIndex)
            {
                case 1:
                    querys += " AND F.id_comprobante = 'B01'";
                    break;
                case 2:
                    querys += " AND F.id_comprobante = 'B02'";
                    break;
            }
            querys += " ORDER BY CD.ncf_comprobante";
            System.Data.DataTable detalles = _comprobante.Reporte607(querys);
            LlenarDataGrid(detalles);


            query = @"SELECT C.rnc_cliente, C.cedula_cliente, CD.ncf_comprobante, F.fecha_devolucion,
                    F.itbis_devolucion, (F.total_devolucion - F.itbis_devolucion) AS Monto, F.id_devolucion,
                    C.nombre_cliente, F.total_devolucion, CDD.ncf_comprobante, F.id_comprobante FROM FacturaDevolucion F
                    LEFT JOIN ComprobantesDetalle CD ON cast(F.id_devolucion as varchar(30)) = CD.id_documento AND
                    F.id_comprobante = CD.id_comprobante LEFT JOIN Clientes C ON F.id_cliente = C.id_cliente
                    LEFT JOIN ComprobantesDetalle CDD ON CAST(F.id_factura as varchar) = CDD.id_documento";
            query += string.Format(@" WHERE F.fecha_devolucion BETWEEN '{0}' AND '{1}'", dtpDesde.Value, dtpHasta.Value);
            query += " ORDER BY CD.ncf_comprobante";
            detalle = _comprobante.Reporte607(query);
            LlenarDataGrid(detalle);
        }

        private void LlenarDataGrid(System.Data.DataTable detalle)
        {
            NrptEmpresa _empresa = new NrptEmpresa();
            string NombreEmpresa = _empresa.LlenaEmpresa();
            //double itbis = 0;
            //double monto = 0;
            for (int i = 0; i < detalle.Rows.Count; i++)
            {
                string Tp = "";
                string RNC = detalle.Rows[i][0].ToString();
                string ncfModifica = detalle.Rows[i][9].ToString();
                if (ncfModifica == "B01" || ncfModifica == "B02")
                {
                    ncfModifica = "000000000";
                }
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
                string fecha = DateTime.Parse(detalle.Rows[i][3].ToString()).ToString("dd / MM / yyyy");
                //itbis += Convert.ToDouble(detalle.Rows[i][4]);
                //monto += Convert.ToDouble(detalle.Rows[i][5]);
                _ = dgvListar.Rows.Add(RNC, Tp, detalle.Rows[i][2], fecha, detalle.Rows[i][4], detalle.Rows[i][5],
                    detalle.Rows[i][6], i + 1, detalle.Rows[i][7], detalle.Rows[i][4], detalle.Rows[i][5], NombreEmpresa, ncfModifica);
            }
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {            
                string filename = ((DatoArchivo)e.Argument).FileName;
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                Workbook wb = excel.Workbooks.Add(XlSheetType.xlWorksheet);
                Worksheet ws = (Worksheet)excel.ActiveSheet;
                int Fila = 1;
                int proceso = dgvListar.RowCount;
                ws.Cells[1, 1] = "Rnc";
                ws.Cells[1, 2] = "Tipo";
                ws.Cells[1, 3] = "NCF";
                ws.Cells[1, 4] = "NCF2";
                ws.Cells[1, 5] = "Fecha";
                ws.Cells[1, 6] = "itbisp";
                ws.Cells[1, 7] = "monto";
                ws.Cells[1, 8] = "sec";
                ws.Cells[1, 9] = "factura";
                ws.Cells[1, 10] = "Cliente";
                ws.Cells[1, 11] = "compañia";
                for (int i = 0; i < dgvListar.RowCount; i++)
                {
                    backgroundWorker.ReportProgress(Fila++ * 100 / proceso);
                    ws.Cells[Fila, 1] = dgvListar.Rows[i].Cells[0].Value.ToString();
                    ws.Cells[Fila, 2] = dgvListar.Rows[i].Cells[1].Value.ToString();
                    ws.Cells[Fila, 3] = dgvListar.Rows[i].Cells[2].Value.ToString();
                    ws.Cells[Fila, 4] = dgvListar.Rows[i].Cells[12].Value.ToString();
                    ws.Cells[Fila, 5] = dgvListar.Rows[i].Cells[3].Value.ToString();
                    ws.Cells[Fila, 6] = dgvListar.Rows[i].Cells[4].Value.ToString();
                    ws.Cells[Fila, 7] = dgvListar.Rows[i].Cells[5].Value.ToString();
                    ws.Cells[Fila, 8] = 
                    ws.Cells[Fila, 9] = dgvListar.Rows[i].Cells[6].Value.ToString();
                    ws.Cells[Fila, 10] = dgvListar.Rows[i].Cells[8].Value.ToString();
                    ws.Cells[Fila, 11] = dgvListar.Rows[i].Cells[11].Value.ToString();
                }
                ws.Columns.AutoFit();
                ws.SaveAs(filename);
                excel.Quit();
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show($"Microsoft Office no Instalado\n\n{ex}");
                throw;
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            lblStatus.Text = string.Format("Progreso... {0}%", e.ProgressPercentage);
            progressBar.Update();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                Thread.Sleep(100);
                progressBar.Value = 100;
                MessageBox.Show("Archivo de Excel exportado Exitozamente");
                progressBar.Visible = false;
                lblStatus.Visible = false;
            }
        }

        struct DatoArchivo
        {
            public string FileName { get; set; }
        }
        DatoArchivo _Parametro;

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook | *.xls" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        progressBar.Visible = true;
                        lblStatus.Visible = true;
                        _Parametro.FileName = sfd.FileName;
                        progressBar.Minimum = 0;
                        progressBar.Value = 0;
                        backgroundWorker.RunWorkerAsync(_Parametro);
                    }
                }
            }
        }
    }
}
