using Entidades;
using Negocios;
using Negocios.NReportes;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
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
            // Configurar licencia de QuestPDF (Requerido)
            QuestPDF.Settings.License = LicenseType.Community;
        }

        private List<E607> listaReporte = new List<E607>();

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
            listaReporte.Clear(); // IMPORTANTE: Limpiar la lista antes de cada consulta
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
                // 1. Lógica de RNC y NCF (la misma que ya tenías)
                string rnc = row[0]?.ToString() ?? row[1]?.ToString() ?? "";
                string ncfMod = row.Table.Columns.Count > 9 ? row[9]?.ToString() : "";
                if (ncfMod == "B01" || ncfMod == "B02") ncfMod = "000000000";

                // 2. Crear el objeto
                E607 entidad = new E607
                {
                    Rnc = rnc,
                    Tipo = rnc.Length == 9 ? "1" : (rnc.Length == 11 ? "2" : ""),
                    Ncf = row[2]?.ToString(),
                    NcfModificado = ncfMod,
                    Fecha = DateTime.TryParse(row[3]?.ToString(), out DateTime dt) ? dt.ToString("dd/MM/yyyy") : "",
                    Itbis = Convert.ToDecimal(row[4] ?? 0),
                    Monto = Convert.ToDecimal(row[5] ?? 0),
                    Secuencia = dgvListar.Rows.Count + 1,
                    IdFactura = row[6]?.ToString(),
                    Cliente = row[7]?.ToString(),
                    Empresa = nombreEmpresa
                };

                // 3. Agregar a la lista y al Grid
                listaReporte.Add(entidad);

                dgvListar.Rows.Add(entidad.Rnc, entidad.Tipo, entidad.Ncf, entidad.Fecha, entidad.Itbis,
                                   entidad.Monto, entidad.IdFactura, entidad.Secuencia, entidad.Cliente,
                                   entidad.Itbis, entidad.Monto, entidad.Empresa, entidad.NcfModificado);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            // Validación simple: Si la lista está vacía, no hay nada que hacer
            if (listaReporte == null || listaReporte.Count == 0)
            {
                MessageBox.Show("No hay datos cargados para exportar. Primero haga clic en Aceptar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog { Filter = "Archivo PDF|*.pdf", FileName = $"Reporte607 {dtpHasta.Value.Month}.pdf" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    progressBar.Visible = true;
                    lblStatus.Visible = true;
                    progressBar.Value = 0;

                    // PREPARAR CONTENEDOR: Pasamos directamente la listaReporte que ya es List<E607>
                    var exportData = new ExportContainer
                    {
                        Path = sfd.FileName,
                        Data = listaReporte.ToList() // ToList() crea una copia para evitar problemas de hilos
                    };

                    backgroundWorker.RunWorkerAsync(exportData);
                }
            }
        }

        // 1. Modifica el contenedor para que acepte la lista de entidades
        private class ExportContainer
        {
            public string Path { get; set; }
            public List<E607> Data { get; set; } // Cambiado de object[] a E607
        }

        // Métodos de ayuda para el estilo del PDF
        private IContainer CellStyle(IContainer container)
        {
            return container.DefaultTextStyle(x => x.SemiBold().FontColor(Colors.White))
                            .PaddingVertical(5)
                            .Background(Colors.Blue.Medium)
                            .AlignCenter();
        }

        private IContainer ContentStyle(IContainer container)
        {
            return container.BorderBottom(0.5f)
                            .BorderColor(Colors.Grey.Lighten2)
                            .PaddingVertical(2)
                            .PaddingHorizontal(2);
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var container = (ExportContainer)e.Argument;
            var datos = container.Data;

            try
            {
                Document.Create(doc =>
                {
                    doc.Page(page =>
                    {
                        page.Size(PageSizes.A4.Landscape());
                        page.Margin(1, Unit.Centimetre);
                        page.DefaultTextStyle(x => x.FontSize(8).FontFamily(Fonts.Verdana));

                        page.Header().PaddingBottom(10).Row(row =>
                        {
                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Text("REPORTE DE VENTAS DE BIENES Y SERVICIOS (607)").FontSize(14).SemiBold().FontColor(Colors.Blue.Medium);
                                col.Item().Text($"Fecha de Generación: {DateTime.Now:dd/MM/yyyy HH:mm}");
                            });
                        });

                        page.Content().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(2);    // RNC
                                columns.ConstantColumn(30);   // Tipo
                                columns.RelativeColumn(2.5f); // NCF
                                columns.RelativeColumn(2.5f); // NCF Modif
                                columns.RelativeColumn(2);    // Fecha
                                columns.RelativeColumn(1.5f); // ITBIS
                                columns.RelativeColumn(1.5f); // Monto
                                columns.ConstantColumn(30);   // Sec
                                columns.RelativeColumn(1.5f); // Factura
                                columns.RelativeColumn(3);    // Cliente
                                columns.RelativeColumn(2.5f); // Empresa
                            });

                            table.Header(header =>
                            {
                                header.Cell().Element(CellStyle).Text("RNC/Cédula");
                                header.Cell().Element(CellStyle).Text("Tipo");
                                header.Cell().Element(CellStyle).Text("NCF");
                                header.Cell().Element(CellStyle).Text("NCF Modif.");
                                header.Cell().Element(CellStyle).Text("Fecha");
                                header.Cell().Element(CellStyle).Text("ITBIS");
                                header.Cell().Element(CellStyle).Text("Monto");
                                header.Cell().Element(CellStyle).Text("Sec");
                                header.Cell().Element(CellStyle).Text("Fact.");
                                header.Cell().Element(CellStyle).Text("Cliente");
                                header.Cell().Element(CellStyle).Text("Empresa");
                            });

                            int i = 0;
                            foreach (var item in datos)
                            {
                                table.Cell().Element(ContentStyle).Text(item.Rnc);
                                table.Cell().Element(ContentStyle).AlignCenter().Text(item.Tipo);
                                table.Cell().Element(ContentStyle).Text(item.Ncf);
                                table.Cell().Element(ContentStyle).Text(item.NcfModificado);
                                table.Cell().Element(ContentStyle).AlignCenter().Text(item.Fecha);
                                table.Cell().Element(ContentStyle).AlignRight().Text($"{item.Itbis:N2}");
                                table.Cell().Element(ContentStyle).AlignRight().Text($"{item.Monto:N2}");
                                table.Cell().Element(ContentStyle).AlignCenter().Text(item.Secuencia.ToString());
                                table.Cell().Element(ContentStyle).Text(item.IdFactura);
                                table.Cell().Element(ContentStyle).Text(item.Cliente);
                                table.Cell().Element(ContentStyle).Text(item.Empresa);

                                i++;
                                if (i % 10 == 0) backgroundWorker.ReportProgress((i * 100) / datos.Count);
                            }
                        });

                        page.Footer().AlignCenter().Text(x => {
                            x.Span("Página "); x.CurrentPageNumber(); x.Span(" de "); x.TotalPages();
                        });
                    });
                }).GeneratePdf(container.Path);
            }
            catch (Exception ex)
            {
                throw new Exception("Error generando PDF: " + ex.Message);
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
            else MessageBox.Show("Archivo de PDF exportado exitosamente.");
        }
    }
}