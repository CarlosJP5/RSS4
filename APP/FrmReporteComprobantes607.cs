using ClosedXML.Excel;
using Negocios;
using Negocios.NReportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            // Sets time to 23:59:59 of the current day
            dtpHasta.Value = DateTime.Today.AddDays(1).AddTicks(-1);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            dgvListar.Rows.Clear();
            NComprobantes _comprobante = new NComprobantes();

            // --- Query 1: Facturas ---
            string query = @"SELECT C.rnc_cliente, C.cedula_cliente, CD.ncf_comprobante, F.fecha_factura,
                             F.itbis_factura, (F.total_factura - F.itbis_factura) AS Monto, F.id_factura,
                             C.nombre_cliente, F.total_factura, F.id_comprobante FROM Factura F
                             LEFT JOIN ComprobantesDetalle CD ON CAST(F.id_factura as varchar) = CD.id_documento AND
                             F.id_comprobante = CD.id_comprobante LEFT JOIN Clientes C ON F.id_cliente = C.id_cliente";
            query += string.Format(@" WHERE F.fecha_factura BETWEEN '{0}' AND '{1}'", dtpDesde.Value, dtpHasta.Value);

            if (cboTipoComprobante.SelectedIndex == 1) query += " AND F.id_comprobante = 'B01'";
            else if (cboTipoComprobante.SelectedIndex == 2) query += " AND F.id_comprobante = 'B02'";

            query += " ORDER BY CD.ncf_comprobante";
            LlenarDataGrid(_comprobante.Reporte607(query));

            // --- Query 2: Servicios ---
            string querys = @"SELECT C.rnc_cliente, C.cedula_cliente, CD.ncf_comprobante, F.fecha_fservicio,
                              F.itbis_fservicio, (F.total_fservicio - F.itbis_fservicio) AS Monto, F.id_fservicio_st,
                              C.nombre_cliente, F.total_fservicio, F.id_comprobante FROM FacturaServicio F
                              LEFT JOIN ComprobantesDetalle CD ON F.id_fservicio_st = CD.id_documento AND
                              F.id_comprobante = CD.id_comprobante LEFT JOIN Clientes C ON F.id_cliente = C.id_cliente";
            querys += string.Format(@" WHERE F.fecha_fservicio BETWEEN '{0}' AND '{1}'", dtpDesde.Value, dtpHasta.Value);

            if (cboTipoComprobante.SelectedIndex == 1) querys += " AND F.id_comprobante = 'B01'";
            else if (cboTipoComprobante.SelectedIndex == 2) querys += " AND F.id_comprobante = 'B02'";

            querys += " ORDER BY CD.ncf_comprobante";
            LlenarDataGrid(_comprobante.Reporte607(querys));

            // --- Query 3: Devoluciones ---
            string queryDev = @"SELECT C.rnc_cliente, C.cedula_cliente, CD.ncf_comprobante, F.fecha_devolucion,
                    F.itbis_devolucion, (F.total_devolucion - F.itbis_devolucion) AS Monto, F.id_devolucion,
                    C.nombre_cliente, F.total_devolucion, CDD.ncf_comprobante, F.id_comprobante FROM FacturaDevolucion F
                    LEFT JOIN ComprobantesDetalle CD ON cast(F.id_devolucion as varchar(30)) = CD.id_documento AND
                    F.id_comprobante = CD.id_comprobante LEFT JOIN Clientes C ON F.id_cliente = C.id_cliente
                    LEFT JOIN ComprobantesDetalle CDD ON CAST(F.id_factura as varchar) = CDD.id_documento";
            queryDev += string.Format(@" WHERE F.fecha_devolucion BETWEEN '{0}' AND '{1}'", dtpDesde.Value, dtpHasta.Value);
            queryDev += " ORDER BY CD.ncf_comprobante";
            LlenarDataGrid(_comprobante.Reporte607(queryDev));
        }

        private void LlenarDataGrid(DataTable detalle)
        {
            if (detalle == null) return;
            NrptEmpresa _empresa = new NrptEmpresa();
            string nombreEmpresa = _empresa.LlenaEmpresa();

            foreach (DataRow row in detalle.Rows)
            {
                // Logic for RNC/Cedula
                string rnc = row[0]?.ToString();
                if (string.IsNullOrEmpty(rnc)) rnc = row[1]?.ToString() ?? "";

                // Logic for NCF Modifica
                string ncfModifica = row.Table.Columns.Count > 9 ? row[9]?.ToString() : "";
                if (ncfModifica == "B01" || ncfModifica == "B02") ncfModifica = "000000000";

                // Type calculation
                string tp = rnc.Length == 9 ? "1" : (rnc.Length == 11 ? "2" : "");

                // Date formatting
                string fechaRaw = row[3]?.ToString();
                string fechaFormateada = DateTime.TryParse(fechaRaw, out DateTime dt)
                    ? dt.ToString("dd / MM / yyyy") : fechaRaw;

                dgvListar.Rows.Add(
                    rnc, tp, row[2], fechaFormateada, row[4], row[5], row[6],
                    dgvListar.Rows.Count + 1, row[7], row[4], row[5],
                    nombreEmpresa, ncfModifica
                );
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvListar.Rows.Count == 0) return;

            using (SaveFileDialog sfd = new SaveFileDialog { Filter = "Excel Workbook|*.xlsx", FileName = "Reporte607.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    progressBar.Visible = true;
                    lblStatus.Visible = true;
                    progressBar.Value = 0;

                    // IMPORTANT: Extract data to a list first. 
                    // BackgroundWorker cannot safely touch dgvListar.Rows.
                    var rowsData = new List<object[]>();
                    foreach (DataGridViewRow row in dgvListar.Rows)
                    {
                        if (row.IsNewRow) continue;
                        var cellValues = row.Cells.Cast<DataGridViewCell>().Select(c => c.Value).ToArray();
                        rowsData.Add(cellValues);
                    }

                    // If there is no real data (for example only the NewRow existed), abort and inform the user.
                    if (rowsData.Count == 0)
                    {
                        progressBar.Visible = false;
                        lblStatus.Visible = false;
                        MessageBox.Show("No hay datos para exportar.");
                        return;
                    }

                    var exportData = new ExportContainer { Path = sfd.FileName, Data = rowsData };
                    backgroundWorker.RunWorkerAsync(exportData);
                }
            }
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var container = (ExportContainer)e.Argument;

            using (var workbook = new XLWorkbook())
            {
                var ws = workbook.Worksheets.Add("Reporte 607");
                string[] headers = { "Rnc", "Tipo", "NCF", "NCF2", "Fecha", "itbisp", "monto", "sec", "factura", "Cliente", "compañía" };

                for (int h = 0; h < headers.Length; h++) ws.Cell(1, h + 1).Value = headers[h];

                for (int i = 0; i < container.Data.Count; i++)
                {
                    int rowNum = i + 2;
                    var data = container.Data[i];

                    ws.Cell(rowNum, 1).Value = data[0]?.ToString();
                    ws.Cell(rowNum, 2).Value = data[1]?.ToString();
                    ws.Cell(rowNum, 3).Value = data[2]?.ToString();
                    ws.Cell(rowNum, 4).Value = data[12]?.ToString(); // NCF2
                    ws.Cell(rowNum, 5).Value = data[3]?.ToString();
                    ws.Cell(rowNum, 6).Value = data[4]?.ToString();
                    ws.Cell(rowNum, 7).Value = data[5]?.ToString();
                    ws.Cell(rowNum, 8).Value = data[7]?.ToString();
                    ws.Cell(rowNum, 9).Value = data[6]?.ToString();
                    ws.Cell(rowNum, 10).Value = data[8]?.ToString();
                    ws.Cell(rowNum, 11).Value = data[11]?.ToString();

                    backgroundWorker.ReportProgress((i + 1) * 100 / container.Data.Count);
                }

                ws.Columns().AdjustToContents();
                workbook.SaveAs(container.Path);
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            lblStatus.Text = $"Progreso... {e.ProgressPercentage}%";
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            progressBar.Visible = false;
            lblStatus.Visible = false;

            if (e.Error != null) MessageBox.Show($"Error: {e.Error.Message}");
            else MessageBox.Show("Archivo de Excel exportado exitosamente.");
        }

        private class ExportContainer
        {
            public string Path { get; set; }
            public List<object[]> Data { get; set; }
        }
    }
}