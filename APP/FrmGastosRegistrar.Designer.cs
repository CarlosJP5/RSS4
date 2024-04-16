namespace APP
{
    partial class FrmGastosRegistrar
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.fechaDtp = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.totalTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.detalleTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tipoGastoCbo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.errorTotal = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelTop.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorTotal)).BeginInit();
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
            this.panelTop.Size = new System.Drawing.Size(489, 30);
            this.panelTop.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(487, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registrar Gasto";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.btnSalvar);
            this.panel1.Controls.Add(this.btnModificar);
            this.panel1.Controls.Add(this.btnNuevo);
            this.panel1.Controls.Add(this.fechaDtp);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.totalTxt);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.detalleTxt);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tipoGastoCbo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(489, 137);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(-1, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(500, 1);
            this.panel2.TabIndex = 19;
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Image = global::APP.Properties.Resources.Salir_16;
            this.btnSalir.Location = new System.Drawing.Point(387, 93);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 25);
            this.btnSalir.TabIndex = 18;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::APP.Properties.Resources.Buscar_16;
            this.btnBuscar.Location = new System.Drawing.Point(296, 93);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 25);
            this.btnBuscar.TabIndex = 17;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = global::APP.Properties.Resources.Salvar_16;
            this.btnSalvar.Location = new System.Drawing.Point(205, 93);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 25);
            this.btnSalvar.TabIndex = 16;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Image = global::APP.Properties.Resources.Edit_16;
            this.btnModificar.Location = new System.Drawing.Point(114, 93);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 25);
            this.btnModificar.TabIndex = 15;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::APP.Properties.Resources.Nuevo_16;
            this.btnNuevo.Location = new System.Drawing.Point(23, 93);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 25);
            this.btnNuevo.TabIndex = 14;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // fechaDtp
            // 
            this.fechaDtp.CustomFormat = " dd / MM / yyyy";
            this.fechaDtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fechaDtp.Location = new System.Drawing.Point(337, 14);
            this.fechaDtp.Name = "fechaDtp";
            this.fechaDtp.Size = new System.Drawing.Size(135, 20);
            this.fechaDtp.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(294, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Fecha";
            // 
            // totalTxt
            // 
            this.totalTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.totalTxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.totalTxt.Location = new System.Drawing.Point(337, 49);
            this.totalTxt.Name = "totalTxt";
            this.totalTxt.Size = new System.Drawing.Size(90, 20);
            this.totalTxt.TabIndex = 5;
            this.totalTxt.Validating += new System.ComponentModel.CancelEventHandler(this.totalTxt_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(300, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Total";
            // 
            // detalleTxt
            // 
            this.detalleTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.detalleTxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.detalleTxt.Location = new System.Drawing.Point(93, 49);
            this.detalleTxt.Name = "detalleTxt";
            this.detalleTxt.Size = new System.Drawing.Size(184, 20);
            this.detalleTxt.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Detalle";
            // 
            // tipoGastoCbo
            // 
            this.tipoGastoCbo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tipoGastoCbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoGastoCbo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.tipoGastoCbo.FormattingEnabled = true;
            this.tipoGastoCbo.Items.AddRange(new object[] {
            "0"});
            this.tipoGastoCbo.Location = new System.Drawing.Point(93, 14);
            this.tipoGastoCbo.Name = "tipoGastoCbo";
            this.tipoGastoCbo.Size = new System.Drawing.Size(184, 21);
            this.tipoGastoCbo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tipo de Gasto";
            // 
            // errorTotal
            // 
            this.errorTotal.ContainerControl = this;
            // 
            // FrmGastosRegistrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(489, 167);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmGastosRegistrar";
            this.ShowIcon = false;
            this.Text = "Registrar Gasto";
            this.Load += new System.EventHandler(this.FrmGastosRegistrar_Load);
            this.panelTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorTotal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox tipoGastoCbo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox totalTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox detalleTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker fechaDtp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.ErrorProvider errorTotal;
    }
}