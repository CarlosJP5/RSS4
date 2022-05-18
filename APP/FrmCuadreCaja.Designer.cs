namespace APP
{
    partial class FrmCuadreCaja
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.panelTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHoy = new System.Windows.Forms.Button();
            this.btn7Dias = new System.Windows.Forms.Button();
            this.btnMes = new System.Windows.Forms.Button();
            this.btnPersonalizada = new System.Windows.Forms.Button();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblReciboIngreso = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblVentasContado = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblDevoluciones = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblTotalIngresos = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.reporteGanancias = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblCantidadRecibos = new System.Windows.Forms.Label();
            this.lblCantidadFacturas = new System.Windows.Forms.Label();
            this.lblCantidadDevoluciones = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reporteGanancias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(235)))), ((int)(((byte)(182)))));
            this.panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(803, 25);
            this.panelTop.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(801, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cuadre Caja";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnImprimir);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpDesde);
            this.panel1.Controls.Add(this.dtpHasta);
            this.panel1.Controls.Add(this.btnPersonalizada);
            this.panel1.Controls.Add(this.btnMes);
            this.panel1.Controls.Add(this.btn7Dias);
            this.panel1.Controls.Add(this.btnHoy);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(803, 40);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnHoy
            // 
            this.btnHoy.Location = new System.Drawing.Point(389, 5);
            this.btnHoy.Name = "btnHoy";
            this.btnHoy.Size = new System.Drawing.Size(95, 26);
            this.btnHoy.TabIndex = 0;
            this.btnHoy.Text = "Hoy";
            this.btnHoy.UseVisualStyleBackColor = true;
            // 
            // btn7Dias
            // 
            this.btn7Dias.Location = new System.Drawing.Point(490, 5);
            this.btn7Dias.Name = "btn7Dias";
            this.btn7Dias.Size = new System.Drawing.Size(95, 26);
            this.btn7Dias.TabIndex = 1;
            this.btn7Dias.Text = "Ultimos 7 Dias";
            this.btn7Dias.UseVisualStyleBackColor = true;
            // 
            // btnMes
            // 
            this.btnMes.Location = new System.Drawing.Point(591, 5);
            this.btnMes.Name = "btnMes";
            this.btnMes.Size = new System.Drawing.Size(95, 26);
            this.btnMes.TabIndex = 2;
            this.btnMes.Text = "Este Mes";
            this.btnMes.UseVisualStyleBackColor = true;
            // 
            // btnPersonalizada
            // 
            this.btnPersonalizada.Location = new System.Drawing.Point(288, 5);
            this.btnPersonalizada.Name = "btnPersonalizada";
            this.btnPersonalizada.Size = new System.Drawing.Size(95, 26);
            this.btnPersonalizada.TabIndex = 3;
            this.btnPersonalizada.Text = "Personalizada";
            this.btnPersonalizada.UseVisualStyleBackColor = true;
            // 
            // dtpHasta
            // 
            this.dtpHasta.CustomFormat = "dd / MM / yyyy";
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHasta.Location = new System.Drawing.Point(179, 9);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(100, 20);
            this.dtpHasta.TabIndex = 4;
            // 
            // dtpDesde
            // 
            this.dtpDesde.CustomFormat = "dd / MM / yyyy";
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDesde.Location = new System.Drawing.Point(70, 9);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(100, 20);
            this.dtpDesde.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Fecha:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblReciboIngreso);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(12, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(170, 58);
            this.panel2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Recibos de Ingreso";
            // 
            // lblReciboIngreso
            // 
            this.lblReciboIngreso.AutoSize = true;
            this.lblReciboIngreso.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold);
            this.lblReciboIngreso.Location = new System.Drawing.Point(5, 23);
            this.lblReciboIngreso.Name = "lblReciboIngreso";
            this.lblReciboIngreso.Size = new System.Drawing.Size(149, 19);
            this.lblReciboIngreso.TabIndex = 1;
            this.lblReciboIngreso.Text = "Ventas a Credito";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblVentasContado);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(208, 71);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(170, 58);
            this.panel3.TabIndex = 3;
            // 
            // lblVentasContado
            // 
            this.lblVentasContado.AutoSize = true;
            this.lblVentasContado.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold);
            this.lblVentasContado.Location = new System.Drawing.Point(5, 23);
            this.lblVentasContado.Name = "lblVentasContado";
            this.lblVentasContado.Size = new System.Drawing.Size(149, 19);
            this.lblVentasContado.TabIndex = 1;
            this.lblVentasContado.Text = "Ventas a Credito";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Ventas a Contado";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblDevoluciones);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Location = new System.Drawing.Point(404, 71);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(170, 58);
            this.panel4.TabIndex = 4;
            // 
            // lblDevoluciones
            // 
            this.lblDevoluciones.AutoSize = true;
            this.lblDevoluciones.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold);
            this.lblDevoluciones.Location = new System.Drawing.Point(5, 23);
            this.lblDevoluciones.Name = "lblDevoluciones";
            this.lblDevoluciones.Size = new System.Drawing.Size(149, 19);
            this.lblDevoluciones.TabIndex = 1;
            this.lblDevoluciones.Text = "Ventas a Credito";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Total Devoluciones";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.lblTotalIngresos);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Location = new System.Drawing.Point(600, 71);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(170, 58);
            this.panel5.TabIndex = 3;
            // 
            // lblTotalIngresos
            // 
            this.lblTotalIngresos.AutoSize = true;
            this.lblTotalIngresos.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalIngresos.Location = new System.Drawing.Point(5, 23);
            this.lblTotalIngresos.Name = "lblTotalIngresos";
            this.lblTotalIngresos.Size = new System.Drawing.Size(149, 19);
            this.lblTotalIngresos.TabIndex = 1;
            this.lblTotalIngresos.Text = "Ventas a Credito";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "Total Ingresos";
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.lblCantidadDevoluciones);
            this.panel8.Controls.Add(this.lblCantidadFacturas);
            this.panel8.Controls.Add(this.lblCantidadRecibos);
            this.panel8.Controls.Add(this.label14);
            this.panel8.Controls.Add(this.label12);
            this.panel8.Controls.Add(this.label11);
            this.panel8.Controls.Add(this.label13);
            this.panel8.Location = new System.Drawing.Point(12, 423);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(372, 118);
            this.panel8.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(5, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 19);
            this.label13.TabIndex = 3;
            this.label13.Text = "Cantidades";
            // 
            // reporteGanancias
            // 
            this.reporteGanancias.BorderlineColor = System.Drawing.Color.Black;
            this.reporteGanancias.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.reporteGanancias.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.reporteGanancias.Legends.Add(legend1);
            this.reporteGanancias.Location = new System.Drawing.Point(12, 135);
            this.reporteGanancias.Name = "reporteGanancias";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.reporteGanancias.Series.Add(series1);
            this.reporteGanancias.Size = new System.Drawing.Size(372, 282);
            this.reporteGanancias.TabIndex = 8;
            this.reporteGanancias.Text = "reporteGanancias";
            title1.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            title1.Name = "Reporte de Ganancias";
            title1.Text = "Reporte de Ganancias";
            this.reporteGanancias.Titles.Add(title1);
            // 
            // chart1
            // 
            this.chart1.BorderlineColor = System.Drawing.Color.Black;
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(390, 135);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            series2.IsValueShownAsLabel = true;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(395, 406);
            this.chart1.TabIndex = 9;
            this.chart1.Text = "chart1";
            title2.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            title2.Name = "Reporte de Ganancias";
            title2.Text = "Top 15 producotos vendidos";
            this.chart1.Titles.Add(title2);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Schoolbook", 12F);
            this.label11.Location = new System.Drawing.Point(5, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(165, 20);
            this.label11.TabIndex = 4;
            this.label11.Text = "Total Recibo Ingreso:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Schoolbook", 12F);
            this.label12.Location = new System.Drawing.Point(5, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(122, 20);
            this.label12.TabIndex = 5;
            this.label12.Text = "Total Facturas:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Schoolbook", 12F);
            this.label14.Location = new System.Drawing.Point(5, 85);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(153, 20);
            this.label14.TabIndex = 6;
            this.label14.Text = "Total Devoluciones:";
            // 
            // lblCantidadRecibos
            // 
            this.lblCantidadRecibos.AutoSize = true;
            this.lblCantidadRecibos.Font = new System.Drawing.Font("Century Schoolbook", 12F);
            this.lblCantidadRecibos.Location = new System.Drawing.Point(165, 35);
            this.lblCantidadRecibos.Name = "lblCantidadRecibos";
            this.lblCantidadRecibos.Size = new System.Drawing.Size(165, 20);
            this.lblCantidadRecibos.TabIndex = 7;
            this.lblCantidadRecibos.Text = "Total Recibo Ingreso:";
            // 
            // lblCantidadFacturas
            // 
            this.lblCantidadFacturas.AutoSize = true;
            this.lblCantidadFacturas.Font = new System.Drawing.Font("Century Schoolbook", 12F);
            this.lblCantidadFacturas.Location = new System.Drawing.Point(165, 60);
            this.lblCantidadFacturas.Name = "lblCantidadFacturas";
            this.lblCantidadFacturas.Size = new System.Drawing.Size(165, 20);
            this.lblCantidadFacturas.TabIndex = 8;
            this.lblCantidadFacturas.Text = "Total Recibo Ingreso:";
            // 
            // lblCantidadDevoluciones
            // 
            this.lblCantidadDevoluciones.AutoSize = true;
            this.lblCantidadDevoluciones.Font = new System.Drawing.Font("Century Schoolbook", 12F);
            this.lblCantidadDevoluciones.Location = new System.Drawing.Point(165, 85);
            this.lblCantidadDevoluciones.Name = "lblCantidadDevoluciones";
            this.lblCantidadDevoluciones.Size = new System.Drawing.Size(165, 20);
            this.lblCantidadDevoluciones.TabIndex = 9;
            this.lblCantidadDevoluciones.Text = "Total Recibo Ingreso:";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(692, 5);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(95, 26);
            this.btnImprimir.TabIndex = 7;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // FrmCuadreCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(803, 559);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.reporteGanancias);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTop);
            this.MaximizeBox = false;
            this.Name = "FrmCuadreCaja";
            this.ShowIcon = false;
            this.Text = "Cuadre Caja";
            this.Load += new System.EventHandler(this.FrmCuadreCaja_Load);
            this.panelTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reporteGanancias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHoy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnPersonalizada;
        private System.Windows.Forms.Button btnMes;
        private System.Windows.Forms.Button btn7Dias;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblReciboIngreso;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblVentasContado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblDevoluciones;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblTotalIngresos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataVisualization.Charting.Chart reporteGanancias;
        private System.Windows.Forms.Label lblCantidadDevoluciones;
        private System.Windows.Forms.Label lblCantidadFacturas;
        private System.Windows.Forms.Label lblCantidadRecibos;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnImprimir;
    }
}