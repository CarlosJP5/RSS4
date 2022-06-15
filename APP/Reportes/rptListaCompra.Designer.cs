namespace APP.Reportes
{
    partial class rptListaCompra
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.erptEmpresaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.erptFacturaDetalleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.erptEmpresaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erptFacturaDetalleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // erptEmpresaBindingSource
            // 
            this.erptEmpresaBindingSource.DataSource = typeof(Entidades.EReportes.ErptEmpresa);
            // 
            // erptFacturaDetalleBindingSource
            // 
            this.erptFacturaDetalleBindingSource.DataSource = typeof(Entidades.EReportes.ErptFacturaDetalle);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsEmpresa";
            reportDataSource1.Value = this.erptEmpresaBindingSource;
            reportDataSource2.Name = "dsLista";
            reportDataSource2.Value = this.erptFacturaDetalleBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "APP.Reportes.rptListaCompra.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ReportExport += new Microsoft.Reporting.WinForms.ExportEventHandler(this.reportViewer1_ReportExport);
            this.reportViewer1.Print += new Microsoft.Reporting.WinForms.ReportPrintEventHandler(this.reportViewer1_Print);
            // 
            // rptListaCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "rptListaCompra";
            this.ShowIcon = false;
            this.Text = "Lista Compra";
            this.Load += new System.EventHandler(this.rptListaCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.erptEmpresaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erptFacturaDetalleBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource erptEmpresaBindingSource;
        private System.Windows.Forms.BindingSource erptFacturaDetalleBindingSource;
    }
}