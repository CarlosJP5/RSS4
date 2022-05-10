namespace APP.Buscar
{
    partial class FrmBuscarDevolucion
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMid = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtIdDevolucion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.linkCliente = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvListar = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelMid.SuspendLayout();
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
            this.panelTop.Size = new System.Drawing.Size(614, 30);
            this.panelTop.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(612, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar Devolucion";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMid
            // 
            this.panelMid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMid.Controls.Add(this.btnBuscar);
            this.panelMid.Controls.Add(this.txtIdDevolucion);
            this.panelMid.Controls.Add(this.label4);
            this.panelMid.Controls.Add(this.txtNombre);
            this.panelMid.Controls.Add(this.txtIdCliente);
            this.panelMid.Controls.Add(this.dtpHasta);
            this.panelMid.Controls.Add(this.dtpDesde);
            this.panelMid.Controls.Add(this.linkCliente);
            this.panelMid.Controls.Add(this.label3);
            this.panelMid.Controls.Add(this.label2);
            this.panelMid.Location = new System.Drawing.Point(12, 36);
            this.panelMid.Name = "panelMid";
            this.panelMid.Size = new System.Drawing.Size(585, 71);
            this.panelMid.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::APP.Properties.Resources.Buscar_16;
            this.btnBuscar.Location = new System.Drawing.Point(483, 32);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 25);
            this.btnBuscar.TabIndex = 11;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtIdDevolucion
            // 
            this.txtIdDevolucion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtIdDevolucion.Location = new System.Drawing.Point(284, 35);
            this.txtIdDevolucion.Name = "txtIdDevolucion";
            this.txtIdDevolucion.Size = new System.Drawing.Size(100, 20);
            this.txtIdDevolucion.TabIndex = 8;
            this.txtIdDevolucion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdCliente_KeyDown);
            this.txtIdDevolucion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdCliente_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(199, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Devolucion Nº:";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(312, 8);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(246, 20);
            this.txtNombre.TabIndex = 6;
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtIdCliente.Location = new System.Drawing.Point(266, 8);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(40, 20);
            this.txtIdCliente.TabIndex = 5;
            this.txtIdCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdCliente_KeyDown);
            this.txtIdCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdCliente_KeyPress);
            this.txtIdCliente.Leave += new System.EventHandler(this.txtIdCliente_Leave);
            // 
            // dtpHasta
            // 
            this.dtpHasta.CustomFormat = "dd / MM / yyyy";
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHasta.Location = new System.Drawing.Point(57, 35);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(129, 20);
            this.dtpHasta.TabIndex = 4;
            // 
            // dtpDesde
            // 
            this.dtpDesde.CustomFormat = "dd / MM / yyyy";
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDesde.Location = new System.Drawing.Point(57, 8);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(129, 20);
            this.dtpDesde.TabIndex = 3;
            // 
            // linkCliente
            // 
            this.linkCliente.AutoSize = true;
            this.linkCliente.Location = new System.Drawing.Point(215, 11);
            this.linkCliente.Name = "linkCliente";
            this.linkCliente.Size = new System.Drawing.Size(42, 13);
            this.linkCliente.TabIndex = 2;
            this.linkCliente.TabStop = true;
            this.linkCliente.Text = "Cliente:";
            this.linkCliente.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCliente_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Hasta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Desde:";
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
            this.Column5});
            this.dgvListar.Location = new System.Drawing.Point(12, 113);
            this.dgvListar.Name = "dgvListar";
            this.dgvListar.ReadOnly = true;
            this.dgvListar.RowHeadersVisible = false;
            this.dgvListar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListar.Size = new System.Drawing.Size(585, 185);
            this.dgvListar.TabIndex = 3;
            this.dgvListar.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListar_CellContentDoubleClick);
            this.dgvListar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListar_KeyDown);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Dev. Nº";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 90;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "NCF";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Fecha";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 80;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Cliente";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 200;
            // 
            // Column5
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.Column5.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column5.HeaderText = "Total";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 90;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::APP.Properties.Resources.Borrar_16;
            this.btnCancelar.Location = new System.Drawing.Point(512, 306);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 25);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = global::APP.Properties.Resources.Aceptar_16;
            this.btnAceptar.Location = new System.Drawing.Point(418, 306);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(85, 25);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // FrmBuscarDevolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(614, 343);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dgvListar);
            this.Controls.Add(this.panelMid);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmBuscarDevolucion";
            this.ShowIcon = false;
            this.Text = "Buscar Devolucion";
            this.Load += new System.EventHandler(this.FrmBuscarDevolucion_Load);
            this.panelTop.ResumeLayout(false);
            this.panelMid.ResumeLayout(false);
            this.panelMid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelMid;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtIdDevolucion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.LinkLabel linkCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        public System.Windows.Forms.DataGridView dgvListar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}