namespace APP.Reportes
{
    partial class rptArticuloInventarioPrecio
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.erptEmpresaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eArticuloBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.erptEmpresaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eArticuloBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Empresa";
            reportDataSource1.Value = this.erptEmpresaBindingSource;
            reportDataSource2.Name = "Articulos";
            reportDataSource2.Value = this.eArticuloBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "APP.Reportes.rptArticuloInventarioPrecio.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(844, 461);
            this.reportViewer1.TabIndex = 0;
            // 
            // erptEmpresaBindingSource
            // 
            this.erptEmpresaBindingSource.DataSource = typeof(Entidades.EReportes.ErptEmpresa);
            // 
            // eArticuloBindingSource
            // 
            this.eArticuloBindingSource.DataSource = typeof(Entidades.EArticulo);
            // 
            // rptArticuloInventarioPrecio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(844, 461);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rptArticuloInventarioPrecio";
            this.ShowIcon = false;
            this.Text = "Articulo Inventario Precio";
            this.Load += new System.EventHandler(this.rptArticuloInventarioPrecio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.erptEmpresaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eArticuloBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource erptEmpresaBindingSource;
        private System.Windows.Forms.BindingSource eArticuloBindingSource;
    }
}