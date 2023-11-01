namespace APP.Reportes
{
    partial class rptArticuloCodigoBarra
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptArticuloCodigoBarraDS = new APP.Reportes.rptArticuloCodigoBarraDS();
            this.rptArticuloCodigoBarraDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.rptArticuloCodigoBarraDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptArticuloCodigoBarraDSBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Barcodes";
            reportDataSource1.Value = this.rptArticuloCodigoBarraDSBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "APP.Reportes.rptArticuloCodigoBarra.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // rptArticuloCodigoBarraDS
            // 
            this.rptArticuloCodigoBarraDS.DataSetName = "rptArticuloCodigoBarraDS";
            this.rptArticuloCodigoBarraDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rptArticuloCodigoBarraDSBindingSource
            // 
            this.rptArticuloCodigoBarraDSBindingSource.DataSource = this.rptArticuloCodigoBarraDS;
            this.rptArticuloCodigoBarraDSBindingSource.Position = 0;
            // 
            // rptArticuloCodigoBarra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rptArticuloCodigoBarra";
            this.Text = "rptArticuloCodigoBarra";
            this.Load += new System.EventHandler(this.rptArticuloCodigoBarra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rptArticuloCodigoBarraDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptArticuloCodigoBarraDSBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource rptArticuloCodigoBarraDSBindingSource;
        private rptArticuloCodigoBarraDS rptArticuloCodigoBarraDS;
    }
}