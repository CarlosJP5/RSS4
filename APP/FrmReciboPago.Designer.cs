
namespace APP
{
    partial class FrmReciboPago
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelmid = new System.Windows.Forms.Panel();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.lblIdRecibo = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAnular = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dgvListar = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDiferencia = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.txtDiferencia = new System.Windows.Forms.TextBox();
            this.txtPago = new System.Windows.Forms.TextBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.errorCliente = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorMonto = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorDiferencia = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelTop.SuspendLayout();
            this.panelmid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListar)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorMonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorDiferencia)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(235)))), ((int)(((byte)(182)))));
            this.panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1314, 45);
            this.panelTop.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Century Schoolbook", 18F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1312, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "Recibo Pago";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelmid
            // 
            this.panelmid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelmid.Controls.Add(this.btnAplicar);
            this.panelmid.Controls.Add(this.lblIdRecibo);
            this.panelmid.Controls.Add(this.btnImprimir);
            this.panelmid.Controls.Add(this.btnSalvar);
            this.panelmid.Controls.Add(this.btnBuscar);
            this.panelmid.Controls.Add(this.btnAnular);
            this.panelmid.Controls.Add(this.btnNuevo);
            this.panelmid.Controls.Add(this.btnSalir);
            this.panelmid.Controls.Add(this.dgvListar);
            this.panelmid.Controls.Add(this.groupBox1);
            this.panelmid.Controls.Add(this.txtMonto);
            this.panelmid.Controls.Add(this.label5);
            this.panelmid.Controls.Add(this.dtpFecha);
            this.panelmid.Controls.Add(this.label4);
            this.panelmid.Controls.Add(this.txtNombre);
            this.panelmid.Controls.Add(this.label3);
            this.panelmid.Controls.Add(this.btnBuscarCliente);
            this.panelmid.Controls.Add(this.txtIdCliente);
            this.panelmid.Controls.Add(this.label2);
            this.panelmid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelmid.Location = new System.Drawing.Point(0, 45);
            this.panelmid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelmid.Name = "panelmid";
            this.panelmid.Size = new System.Drawing.Size(1314, 476);
            this.panelmid.TabIndex = 1;
            // 
            // btnAplicar
            // 
            this.btnAplicar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAplicar.FlatAppearance.BorderSize = 0;
            this.btnAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicar.Image = global::APP.Properties.Resources.Pay_24;
            this.btnAplicar.Location = new System.Drawing.Point(728, 63);
            this.btnAplicar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(38, 38);
            this.btnAplicar.TabIndex = 41;
            this.btnAplicar.UseVisualStyleBackColor = true;
            // 
            // lblIdRecibo
            // 
            this.lblIdRecibo.AutoSize = true;
            this.lblIdRecibo.Location = new System.Drawing.Point(27, 418);
            this.lblIdRecibo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdRecibo.Name = "lblIdRecibo";
            this.lblIdRecibo.Size = new System.Drawing.Size(73, 20);
            this.lblIdRecibo.TabIndex = 40;
            this.lblIdRecibo.Text = "IdRecibo";
            this.lblIdRecibo.Visible = false;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = global::APP.Properties.Resources.Print_16;
            this.btnImprimir.Location = new System.Drawing.Point(574, 426);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(128, 38);
            this.btnImprimir.TabIndex = 34;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = global::APP.Properties.Resources.Salvar_16;
            this.btnSalvar.Location = new System.Drawing.Point(723, 426);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(128, 38);
            this.btnSalvar.TabIndex = 35;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::APP.Properties.Resources.Buscar_16;
            this.btnBuscar.Location = new System.Drawing.Point(872, 426);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(128, 38);
            this.btnBuscar.TabIndex = 36;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAnular
            // 
            this.btnAnular.Image = global::APP.Properties.Resources.Borrar_16;
            this.btnAnular.Location = new System.Drawing.Point(426, 426);
            this.btnAnular.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(128, 38);
            this.btnAnular.TabIndex = 38;
            this.btnAnular.Text = "Anular";
            this.btnAnular.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAnular.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::APP.Properties.Resources.Nuevo_16;
            this.btnNuevo.Location = new System.Drawing.Point(278, 426);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(128, 38);
            this.btnNuevo.TabIndex = 37;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::APP.Properties.Resources.Salir_16;
            this.btnSalir.Location = new System.Drawing.Point(1020, 426);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(128, 38);
            this.btnSalir.TabIndex = 39;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dgvListar
            // 
            this.dgvListar.AllowUserToAddRows = false;
            this.dgvListar.AllowUserToDeleteRows = false;
            this.dgvListar.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvListar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            this.dgvListar.Location = new System.Drawing.Point(15, 122);
            this.dgvListar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvListar.Name = "dgvListar";
            this.dgvListar.RowHeadersVisible = false;
            this.dgvListar.Size = new System.Drawing.Size(1276, 285);
            this.dgvListar.TabIndex = 33;
            this.dgvListar.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListar_CellEndEdit);
            this.dgvListar.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvListar_EditingControlShowing);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Fact. Nº";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "NCF";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Fecha";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column4.HeaderText = "Días";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 75;
            // 
            // Column5
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.Column5.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column5.HeaderText = "Total";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 150;
            // 
            // Column6
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.Column6.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column6.HeaderText = "Balance";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 150;
            // 
            // Column7
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.Column7.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column7.HeaderText = "Pago";
            this.Column7.Name = "Column7";
            this.Column7.Width = 150;
            // 
            // Column8
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.Column8.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column8.HeaderText = "Restante";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 150;
            // 
            // Column9
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Red;
            this.Column9.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column9.HeaderText = "Estado";
            this.Column9.Name = "Column9";
            this.Column9.Width = 105;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "IdCompra";
            this.Column10.Name = "Column10";
            this.Column10.Visible = false;
            this.Column10.Width = 150;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.groupBox1.Controls.Add(this.lblDiferencia);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtBalance);
            this.groupBox1.Controls.Add(this.txtDiferencia);
            this.groupBox1.Controls.Add(this.txtPago);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(800, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(442, 106);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Totales";
            // 
            // lblDiferencia
            // 
            this.lblDiferencia.AutoSize = true;
            this.lblDiferencia.Location = new System.Drawing.Point(286, 65);
            this.lblDiferencia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiferencia.Name = "lblDiferencia";
            this.lblDiferencia.Size = new System.Drawing.Size(81, 20);
            this.lblDiferencia.TabIndex = 5;
            this.lblDiferencia.Text = "Diferencia";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(150, 65);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Pago";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 65);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Balance";
            // 
            // txtBalance
            // 
            this.txtBalance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtBalance.Location = new System.Drawing.Point(15, 29);
            this.txtBalance.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(133, 26);
            this.txtBalance.TabIndex = 0;
            this.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDiferencia
            // 
            this.txtDiferencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtDiferencia.Location = new System.Drawing.Point(288, 29);
            this.txtDiferencia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDiferencia.Name = "txtDiferencia";
            this.txtDiferencia.ReadOnly = true;
            this.txtDiferencia.Size = new System.Drawing.Size(133, 26);
            this.txtDiferencia.TabIndex = 2;
            this.txtDiferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPago
            // 
            this.txtPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtPago.Location = new System.Drawing.Point(152, 29);
            this.txtPago.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPago.Name = "txtPago";
            this.txtPago.ReadOnly = true;
            this.txtPago.Size = new System.Drawing.Size(133, 26);
            this.txtPago.TabIndex = 1;
            this.txtPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMonto
            // 
            this.txtMonto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtMonto.Location = new System.Drawing.Point(540, 63);
            this.txtMonto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(172, 26);
            this.txtMonto.TabIndex = 30;
            this.txtMonto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMonto_KeyDown);
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            this.txtMonto.Leave += new System.EventHandler(this.txtMonto_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(471, 68);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 29;
            this.label5.Text = "Monto:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd / MM / yyyy";
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(540, 15);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(172, 26);
            this.dtpFecha.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(471, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "Fecha:";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtNombre.Location = new System.Drawing.Point(88, 63);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(350, 26);
            this.txtNombre.TabIndex = 26;
            this.txtNombre.Validating += new System.ComponentModel.CancelEventHandler(this.txtNombre_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 68);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "Nombre:";
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Image = global::APP.Properties.Resources.Buscar_16;
            this.btnBuscarCliente.Location = new System.Drawing.Point(248, 11);
            this.btnBuscarCliente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(45, 38);
            this.btnBuscarCliente.TabIndex = 24;
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtIdCliente.Location = new System.Drawing.Point(88, 15);
            this.txtIdCliente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(148, 26);
            this.txtIdCliente.TabIndex = 22;
            this.txtIdCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdCliente_KeyDown);
            this.txtIdCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdCliente_KeyPress);
            this.txtIdCliente.Leave += new System.EventHandler(this.txtIdCliente_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Codigo:";
            // 
            // errorCliente
            // 
            this.errorCliente.ContainerControl = this;
            // 
            // errorMonto
            // 
            this.errorMonto.ContainerControl = this;
            // 
            // errorDiferencia
            // 
            this.errorDiferencia.ContainerControl = this;
            // 
            // FrmReciboPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1314, 521);
            this.Controls.Add(this.panelmid);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FrmReciboPago";
            this.ShowIcon = false;
            this.Text = "Recibo Pago";
            this.Load += new System.EventHandler(this.FrmReciboPago_Load);
            this.panelTop.ResumeLayout(false);
            this.panelmid.ResumeLayout(false);
            this.panelmid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorMonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorDiferencia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelmid;
        private System.Windows.Forms.Label lblIdRecibo;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgvListar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDiferencia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.TextBox txtDiferencia;
        private System.Windows.Forms.TextBox txtPago;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorCliente;
        private System.Windows.Forms.ErrorProvider errorMonto;
        private System.Windows.Forms.ErrorProvider errorDiferencia;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
    }
}