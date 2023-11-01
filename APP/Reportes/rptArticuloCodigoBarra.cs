using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP.Reportes
{
    public partial class rptArticuloCodigoBarra : Form
    {
        rptArticuloCodigoBarraDS.BarCodeTDataTable barCodeTRows;

        public rptArticuloCodigoBarra(rptArticuloCodigoBarraDS.BarCodeTDataTable barCodeTRows)
        {
            InitializeComponent();
            this.barCodeTRows = barCodeTRows;
        }

        private void rptArticuloCodigoBarra_Load(object sender, EventArgs e)
        {
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "Barcodes";
            reportDataSource.Value = barCodeTRows;
            reportViewer1.LocalReport.EnableExternalImages = true;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }
    }
}
