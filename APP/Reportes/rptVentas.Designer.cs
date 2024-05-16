namespace APP.Reportes
{
    partial class rptVentas
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.erptEmpresaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nrptVentasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contadoVentasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.creditoVentasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.buscarBtn = new System.Windows.Forms.Button();
            this.hastaDtp = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.desdeDtp = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.nrptVentasBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.erptEmpresaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrptVentasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contadoVentasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.creditoVentasBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrptVentasBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // erptEmpresaBindingSource
            // 
            this.erptEmpresaBindingSource.DataSource = typeof(Entidades.EReportes.ErptEmpresa);
            // 
            // nrptVentasBindingSource
            // 
            this.nrptVentasBindingSource.DataSource = typeof(Negocios.NReportes.NrptVentas);
            // 
            // contadoVentasBindingSource
            // 
            this.contadoVentasBindingSource.DataMember = "ContadoVentas";
            this.contadoVentasBindingSource.DataSource = this.nrptVentasBindingSource;
            // 
            // creditoVentasBindingSource
            // 
            this.creditoVentasBindingSource.DataMember = "CreditoVentas";
            this.creditoVentasBindingSource.DataSource = this.nrptVentasBindingSource;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buscarBtn);
            this.panel1.Controls.Add(this.hastaDtp);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.desdeDtp);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 41);
            this.panel1.TabIndex = 0;
            // 
            // buscarBtn
            // 
            this.buscarBtn.Image = global::APP.Properties.Resources.Buscar_16;
            this.buscarBtn.Location = new System.Drawing.Point(412, 5);
            this.buscarBtn.Name = "buscarBtn";
            this.buscarBtn.Size = new System.Drawing.Size(75, 25);
            this.buscarBtn.TabIndex = 5;
            this.buscarBtn.Text = "Buscar";
            this.buscarBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buscarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buscarBtn.UseVisualStyleBackColor = true;
            this.buscarBtn.Click += new System.EventHandler(this.buscarBtn_Click);
            // 
            // hastaDtp
            // 
            this.hastaDtp.CustomFormat = " dd / MM / yyyy";
            this.hastaDtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.hastaDtp.Location = new System.Drawing.Point(276, 8);
            this.hastaDtp.Name = "hastaDtp";
            this.hastaDtp.Size = new System.Drawing.Size(120, 20);
            this.hastaDtp.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(237, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "hasta";
            // 
            // desdeDtp
            // 
            this.desdeDtp.CustomFormat = " dd / MM / yyyy";
            this.desdeDtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.desdeDtp.Location = new System.Drawing.Point(108, 8);
            this.desdeDtp.Name = "desdeDtp";
            this.desdeDtp.Size = new System.Drawing.Size(120, 20);
            this.desdeDtp.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "desde";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "FECHA";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Empresa";
            reportDataSource1.Value = this.erptEmpresaBindingSource;
            reportDataSource2.Name = "Ganancias";
            reportDataSource2.Value = this.nrptVentasBindingSource;
            reportDataSource3.Name = "ContadoVentas";
            reportDataSource3.Value = this.contadoVentasBindingSource;
            reportDataSource4.Name = "CreditoVentas";
            reportDataSource4.Value = this.creditoVentasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "APP.Reportes.rptVentas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 41);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 409);
            this.reportViewer1.TabIndex = 1;
            // 
            // nrptVentasBindingSource1
            // 
            this.nrptVentasBindingSource1.DataSource = typeof(Negocios.NReportes.NrptVentas);
            // 
            // rptVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.Name = "rptVentas";
            this.Text = "Reporte de Ventas";
            this.Load += new System.EventHandler(this.rptVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.erptEmpresaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrptVentasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contadoVentasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.creditoVentasBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrptVentasBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button buscarBtn;
        private System.Windows.Forms.DateTimePicker hastaDtp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker desdeDtp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource erptEmpresaBindingSource;
        private System.Windows.Forms.BindingSource nrptVentasBindingSource;
        private System.Windows.Forms.BindingSource contadoVentasBindingSource;
        private System.Windows.Forms.BindingSource creditoVentasBindingSource;
        private System.Windows.Forms.BindingSource nrptVentasBindingSource1;
    }
}