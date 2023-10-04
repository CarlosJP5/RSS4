namespace APP.Buscar
{
    partial class FrmBuscarBancosMovimientos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvListar = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.idCtnBancoLbl = new System.Windows.Forms.Label();
            this.idBancoLbl = new System.Windows.Forms.Label();
            this.bancoLink = new System.Windows.Forms.LinkLabel();
            this.bancoLbl = new System.Windows.Forms.Label();
            this.nombreLbl = new System.Windows.Forms.Label();
            this.numeroCuentaLbl = new System.Windows.Forms.Label();
            this.cuentaLink = new System.Windows.Forms.LinkLabel();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Column0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTop.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListar)).BeginInit();
            this.panel2.SuspendLayout();
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
            this.panelTop.Size = new System.Drawing.Size(822, 30);
            this.panelTop.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(820, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar Transacciones Bancos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dgvListar);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(822, 358);
            this.panel1.TabIndex = 2;
            // 
            // dgvListar
            // 
            this.dgvListar.AllowUserToAddRows = false;
            this.dgvListar.AllowUserToDeleteRows = false;
            this.dgvListar.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvListar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column0,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvListar.Location = new System.Drawing.Point(10, 86);
            this.dgvListar.Name = "dgvListar";
            this.dgvListar.ReadOnly = true;
            this.dgvListar.RowHeadersVisible = false;
            this.dgvListar.Size = new System.Drawing.Size(794, 240);
            this.dgvListar.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnBuscar);
            this.panel2.Controls.Add(this.idCtnBancoLbl);
            this.panel2.Controls.Add(this.idBancoLbl);
            this.panel2.Controls.Add(this.bancoLink);
            this.panel2.Controls.Add(this.bancoLbl);
            this.panel2.Controls.Add(this.nombreLbl);
            this.panel2.Controls.Add(this.numeroCuentaLbl);
            this.panel2.Controls.Add(this.cuentaLink);
            this.panel2.Controls.Add(this.dtpHasta);
            this.panel2.Controls.Add(this.dtpDesde);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(10, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 76);
            this.panel2.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::APP.Properties.Resources.Buscar_16;
            this.btnBuscar.Location = new System.Drawing.Point(564, 36);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(91, 25);
            this.btnBuscar.TabIndex = 29;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // idCtnBancoLbl
            // 
            this.idCtnBancoLbl.AutoSize = true;
            this.idCtnBancoLbl.Location = new System.Drawing.Point(561, 19);
            this.idCtnBancoLbl.Name = "idCtnBancoLbl";
            this.idCtnBancoLbl.Size = new System.Drawing.Size(62, 13);
            this.idCtnBancoLbl.TabIndex = 28;
            this.idCtnBancoLbl.Text = "idCntBanco";
            this.idCtnBancoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.idCtnBancoLbl.Visible = false;
            // 
            // idBancoLbl
            // 
            this.idBancoLbl.AutoSize = true;
            this.idBancoLbl.Location = new System.Drawing.Point(561, 2);
            this.idBancoLbl.Name = "idBancoLbl";
            this.idBancoLbl.Size = new System.Drawing.Size(46, 13);
            this.idBancoLbl.TabIndex = 27;
            this.idBancoLbl.Text = "idBanco";
            this.idBancoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.idBancoLbl.Visible = false;
            // 
            // bancoLink
            // 
            this.bancoLink.AutoSize = true;
            this.bancoLink.Location = new System.Drawing.Point(210, 15);
            this.bancoLink.Name = "bancoLink";
            this.bancoLink.Size = new System.Drawing.Size(41, 13);
            this.bancoLink.TabIndex = 13;
            this.bancoLink.TabStop = true;
            this.bancoLink.Text = "Banco:";
            this.bancoLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.bancoLink_LinkClicked);
            // 
            // bancoLbl
            // 
            this.bancoLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bancoLbl.Location = new System.Drawing.Point(260, 10);
            this.bancoLbl.Name = "bancoLbl";
            this.bancoLbl.Size = new System.Drawing.Size(284, 22);
            this.bancoLbl.TabIndex = 12;
            this.bancoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nombreLbl
            // 
            this.nombreLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nombreLbl.Location = new System.Drawing.Point(366, 38);
            this.nombreLbl.Name = "nombreLbl";
            this.nombreLbl.Size = new System.Drawing.Size(178, 22);
            this.nombreLbl.TabIndex = 11;
            this.nombreLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numeroCuentaLbl
            // 
            this.numeroCuentaLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numeroCuentaLbl.Location = new System.Drawing.Point(260, 38);
            this.numeroCuentaLbl.Name = "numeroCuentaLbl";
            this.numeroCuentaLbl.Size = new System.Drawing.Size(100, 22);
            this.numeroCuentaLbl.TabIndex = 10;
            this.numeroCuentaLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cuentaLink
            // 
            this.cuentaLink.AutoSize = true;
            this.cuentaLink.Location = new System.Drawing.Point(210, 42);
            this.cuentaLink.Name = "cuentaLink";
            this.cuentaLink.Size = new System.Drawing.Size(44, 13);
            this.cuentaLink.TabIndex = 9;
            this.cuentaLink.TabStop = true;
            this.cuentaLink.Text = "Cuenta:";
            this.cuentaLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.cuentaLink_LinkClicked);
            // 
            // dtpHasta
            // 
            this.dtpHasta.CustomFormat = "dd / MM / yyyy";
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHasta.Location = new System.Drawing.Point(61, 39);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(129, 20);
            this.dtpHasta.TabIndex = 8;
            // 
            // dtpDesde
            // 
            this.dtpDesde.CustomFormat = "dd / MM / yyyy";
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDesde.Location = new System.Drawing.Point(61, 12);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(129, 20);
            this.dtpDesde.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hasta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Desde:";
            // 
            // Column0
            // 
            this.Column0.HeaderText = "Transaccion";
            this.Column0.Name = "Column0";
            this.Column0.ReadOnly = true;
            this.Column0.Width = 90;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Fecha";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Banco";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Cuenta";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 120;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Descripcion";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 170;
            // 
            // Column5
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "C2";
            dataGridViewCellStyle9.NullValue = "-";
            this.Column5.DefaultCellStyle = dataGridViewCellStyle9;
            this.Column5.HeaderText = "Retiro";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 90;
            // 
            // Column6
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "C2";
            dataGridViewCellStyle10.NullValue = "-";
            this.Column6.DefaultCellStyle = dataGridViewCellStyle10;
            this.Column6.HeaderText = "Deposito";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 90;
            // 
            // FrmBuscarBancosMovimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(822, 388);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTop);
            this.Name = "FrmBuscarBancosMovimientos";
            this.Text = "Buscar Transacciones Bancos";
            this.Load += new System.EventHandler(this.FrmBuscarBancosMovimientos_Load);
            this.panelTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListar)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel bancoLink;
        private System.Windows.Forms.Label bancoLbl;
        private System.Windows.Forms.Label nombreLbl;
        private System.Windows.Forms.Label numeroCuentaLbl;
        private System.Windows.Forms.LinkLabel cuentaLink;
        private System.Windows.Forms.Label idCtnBancoLbl;
        private System.Windows.Forms.Label idBancoLbl;
        private System.Windows.Forms.Button btnBuscar;
        public System.Windows.Forms.DataGridView dgvListar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column0;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}