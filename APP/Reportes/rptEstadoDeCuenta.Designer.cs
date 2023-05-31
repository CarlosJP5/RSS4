namespace APP.Reportes
{
    partial class rptEstadoDeCuenta
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.erptEmpresaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eClienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.erptEstadoCuentaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.erptEmpresaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eClienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erptEstadoCuentaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // erptEmpresaBindingSource
            // 
            this.erptEmpresaBindingSource.DataSource = typeof(Entidades.EReportes.ErptEmpresa);
            // 
            // eClienteBindingSource
            // 
            this.eClienteBindingSource.DataSource = typeof(Entidades.ECliente);
            // 
            // erptEstadoCuentaBindingSource
            // 
            this.erptEstadoCuentaBindingSource.DataSource = typeof(Entidades.EReportes.ErptEstadoCuenta);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Empresa";
            reportDataSource1.Value = this.erptEmpresaBindingSource;
            reportDataSource2.Name = "Cliente";
            reportDataSource2.Value = this.eClienteBindingSource;
            reportDataSource3.Name = "EstadoCuenta";
            reportDataSource3.Value = this.erptEstadoCuentaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "APP.Reportes.rptEstadoDeCuenta.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(905, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // rptEstadoDeCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(905, 450);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "rptEstadoDeCuenta";
            this.ShowIcon = false;
            this.Text = "rpt Estado De Cuenta";
            this.Load += new System.EventHandler(this.rptEstadoDeCuenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.erptEmpresaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eClienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erptEstadoCuentaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource erptEmpresaBindingSource;
        private System.Windows.Forms.BindingSource eClienteBindingSource;
        private System.Windows.Forms.BindingSource erptEstadoCuentaBindingSource;
    }
}