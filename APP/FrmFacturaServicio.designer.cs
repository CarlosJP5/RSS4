namespace APP
{
    partial class FrmFacturaServicio
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCotizacion = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lblidFactura_int = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.lblIdFactura = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblNcf = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtItbis = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.dgvListar = new System.Windows.Forms.DataGridView();
            this.Column0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.btnBuscarClientes = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cboTipoComprobante = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRnc = new System.Windows.Forms.TextBox();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cboImprecion = new System.Windows.Forms.ComboBox();
            this.panelTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListar)).BeginInit();
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
            this.panelTop.Size = new System.Drawing.Size(474, 30);
            this.panelTop.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Century Schoolbook", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(472, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Facturar Servicio";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cboImprecion);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtCotizacion);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.lblidFactura_int);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.btnImprimir);
            this.panel1.Controls.Add(this.btnFacturar);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.btnModificar);
            this.panel1.Controls.Add(this.btnNuevo);
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtTotal);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtItbis);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtImporte);
            this.panel1.Controls.Add(this.dgvListar);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dtpFecha);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.btnBuscarClientes);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cboTipoComprobante);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtRnc);
            this.panel1.Controls.Add(this.txtCedula);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.txtIdCliente);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(474, 472);
            this.panel1.TabIndex = 1;
            // 
            // txtCotizacion
            // 
            this.txtCotizacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCotizacion.Location = new System.Drawing.Point(347, 90);
            this.txtCotizacion.Name = "txtCotizacion";
            this.txtCotizacion.ReadOnly = true;
            this.txtCotizacion.Size = new System.Drawing.Size(100, 20);
            this.txtCotizacion.TabIndex = 30;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(269, 91);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(72, 16);
            this.linkLabel1.TabIndex = 29;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Cotizacion:";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lblidFactura_int
            // 
            this.lblidFactura_int.AutoSize = true;
            this.lblidFactura_int.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblidFactura_int.Location = new System.Drawing.Point(18, 346);
            this.lblidFactura_int.Name = "lblidFactura_int";
            this.lblidFactura_int.Size = new System.Drawing.Size(101, 16);
            this.lblidFactura_int.TabIndex = 28;
            this.lblidFactura_int.Text = "IdFactura_int";
            this.lblidFactura_int.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label10);
            this.flowLayoutPanel1.Controls.Add(this.lblIdFactura);
            this.flowLayoutPanel1.Controls.Add(this.label12);
            this.flowLayoutPanel1.Controls.Add(this.lblNcf);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(13, 125);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(447, 22);
            this.flowLayoutPanel1.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "Factura Nº:";
            // 
            // lblIdFactura
            // 
            this.lblIdFactura.AutoSize = true;
            this.lblIdFactura.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdFactura.Location = new System.Drawing.Point(88, 0);
            this.lblIdFactura.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblIdFactura.Name = "lblIdFactura";
            this.lblIdFactura.Size = new System.Drawing.Size(39, 16);
            this.lblIdFactura.TabIndex = 1;
            this.lblIdFactura.Text = "~ ~ ~";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Blue;
            this.label12.Location = new System.Drawing.Point(133, 0);
            this.label12.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.label12.Size = new System.Drawing.Size(56, 16);
            this.label12.TabIndex = 2;
            this.label12.Text = "NCF:";
            // 
            // lblNcf
            // 
            this.lblNcf.AutoSize = true;
            this.lblNcf.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNcf.ForeColor = System.Drawing.Color.Blue;
            this.lblNcf.Location = new System.Drawing.Point(189, 0);
            this.lblNcf.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblNcf.Name = "lblNcf";
            this.lblNcf.Size = new System.Drawing.Size(31, 16);
            this.lblNcf.TabIndex = 3;
            this.lblNcf.Text = "~~~";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = global::APP.Properties.Resources.Print_16;
            this.btnImprimir.Location = new System.Drawing.Point(18, 396);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(85, 25);
            this.btnImprimir.TabIndex = 24;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnFacturar
            // 
            this.btnFacturar.Image = global::APP.Properties.Resources.Facturar_16;
            this.btnFacturar.Location = new System.Drawing.Point(109, 365);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(92, 25);
            this.btnFacturar.TabIndex = 22;
            this.btnFacturar.Text = "Facturar [F5]";
            this.btnFacturar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFacturar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::APP.Properties.Resources.Buscar_16;
            this.btnBuscar.Location = new System.Drawing.Point(207, 365);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(85, 25);
            this.btnBuscar.TabIndex = 23;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Image = global::APP.Properties.Resources.Edit_16;
            this.btnModificar.Location = new System.Drawing.Point(110, 396);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(85, 25);
            this.btnModificar.TabIndex = 25;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::APP.Properties.Resources.Nuevo_16;
            this.btnNuevo.Location = new System.Drawing.Point(18, 365);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(85, 25);
            this.btnNuevo.TabIndex = 21;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::APP.Properties.Resources.Salir_16;
            this.btnSalir.Location = new System.Drawing.Point(207, 396);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(85, 25);
            this.btnSalir.TabIndex = 26;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(323, 407);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Total";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtTotal.Location = new System.Drawing.Point(360, 404);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 20;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(328, 381);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Itbis";
            // 
            // txtItbis
            // 
            this.txtItbis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtItbis.Location = new System.Drawing.Point(360, 378);
            this.txtItbis.Name = "txtItbis";
            this.txtItbis.ReadOnly = true;
            this.txtItbis.Size = new System.Drawing.Size(100, 20);
            this.txtItbis.TabIndex = 18;
            this.txtItbis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(312, 355);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Importe";
            // 
            // txtImporte
            // 
            this.txtImporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtImporte.Location = new System.Drawing.Point(360, 352);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.ReadOnly = true;
            this.txtImporte.Size = new System.Drawing.Size(100, 20);
            this.txtImporte.TabIndex = 16;
            this.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dgvListar
            // 
            this.dgvListar.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvListar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column0,
            this.Column1});
            this.dgvListar.Location = new System.Drawing.Point(13, 151);
            this.dgvListar.Name = "dgvListar";
            this.dgvListar.Size = new System.Drawing.Size(447, 193);
            this.dgvListar.TabIndex = 14;
            this.dgvListar.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListar_CellEndEdit);
            this.dgvListar.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvListar_EditingControlShowing);
            this.dgvListar.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvListar_RowsRemoved);
            // 
            // Column0
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column0.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column0.HeaderText = "Descripcion";
            this.Column0.MaxInputLength = 150;
            this.Column0.Name = "Column0";
            this.Column0.Width = 275;
            // 
            // Column1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "Precio";
            this.Column1.Name = "Column1";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(0, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(490, 1);
            this.panel2.TabIndex = 13;
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd / MM / yyyy";
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(346, 10);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(113, 20);
            this.dtpFecha.TabIndex = 8;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(299, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 7;
            this.label14.Text = "Fecha:";
            // 
            // btnBuscarClientes
            // 
            this.btnBuscarClientes.Image = global::APP.Properties.Resources.Buscar_16;
            this.btnBuscarClientes.Location = new System.Drawing.Point(179, 8);
            this.btnBuscarClientes.Name = "btnBuscarClientes";
            this.btnBuscarClientes.Size = new System.Drawing.Size(30, 25);
            this.btnBuscarClientes.TabIndex = 2;
            this.btnBuscarClientes.UseVisualStyleBackColor = true;
            this.btnBuscarClientes.Click += new System.EventHandler(this.btnBuscarClientes_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Tipo NCF:";
            // 
            // cboTipoComprobante
            // 
            this.cboTipoComprobante.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cboTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoComprobante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipoComprobante.FormattingEnabled = true;
            this.cboTipoComprobante.Location = new System.Drawing.Point(71, 63);
            this.cboTipoComprobante.Name = "cboTipoComprobante";
            this.cboTipoComprobante.Size = new System.Drawing.Size(202, 21);
            this.cboTipoComprobante.TabIndex = 6;
            this.cboTipoComprobante.SelectedIndexChanged += new System.EventHandler(this.cboTipoComprobante_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(308, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "RNC:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(298, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Cedula:";
            // 
            // txtRnc
            // 
            this.txtRnc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtRnc.Location = new System.Drawing.Point(347, 64);
            this.txtRnc.Name = "txtRnc";
            this.txtRnc.ReadOnly = true;
            this.txtRnc.Size = new System.Drawing.Size(100, 20);
            this.txtRnc.TabIndex = 12;
            // 
            // txtCedula
            // 
            this.txtCedula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtCedula.Location = new System.Drawing.Point(347, 38);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.ReadOnly = true;
            this.txtCedula.Size = new System.Drawing.Size(100, 20);
            this.txtCedula.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtNombre.Location = new System.Drawing.Point(71, 37);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(202, 20);
            this.txtNombre.TabIndex = 4;
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtIdCliente.Location = new System.Drawing.Point(71, 12);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(100, 20);
            this.txtIdCliente.TabIndex = 1;
            this.txtIdCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdCliente_KeyDown);
            this.txtIdCliente.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdCliente_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cliente:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 440);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Formato Imprecion";
            // 
            // cboImprecion
            // 
            this.cboImprecion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cboImprecion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboImprecion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboImprecion.FormattingEnabled = true;
            this.cboImprecion.Items.AddRange(new object[] {
            "80MM - pequeño",
            "A4 - grande"});
            this.cboImprecion.Location = new System.Drawing.Point(118, 437);
            this.cboImprecion.Name = "cboImprecion";
            this.cboImprecion.Size = new System.Drawing.Size(121, 21);
            this.cboImprecion.TabIndex = 32;
            // 
            // FrmFacturaServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(474, 502);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmFacturaServicio";
            this.ShowIcon = false;
            this.Text = "Facturar Servicio";
            this.Load += new System.EventHandler(this.FrmFacturaServicio_Load);
            this.panelTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBuscarClientes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboTipoComprobante;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRnc;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgvListar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column0;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtItbis;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblIdFactura;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblNcf;
        private System.Windows.Forms.Label lblidFactura_int;
        private System.Windows.Forms.TextBox txtCotizacion;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ComboBox cboImprecion;
        private System.Windows.Forms.Label label11;
    }
}