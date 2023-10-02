namespace APP
{
    partial class FrmBancosMovimientos
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.detalleTxt = new System.Windows.Forms.TextBox();
            this.montoTxt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tipoTransaccionCbo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.balanceLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bancoLbl = new System.Windows.Forms.Label();
            this.nombreLbl = new System.Windows.Forms.Label();
            this.numeroCuentaLbl = new System.Windows.Forms.Label();
            this.cuentaLink = new System.Windows.Forms.LinkLabel();
            this.panelTop.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.panelTop.Size = new System.Drawing.Size(574, 30);
            this.panelTop.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(572, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registrar Transacciones Bancos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.btnSalvar);
            this.panel1.Controls.Add(this.btnModificar);
            this.panel1.Controls.Add(this.btnNuevo);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.detalleTxt);
            this.panel1.Controls.Add(this.montoTxt);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.tipoTransaccionCbo);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.balanceLbl);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.bancoLbl);
            this.panel1.Controls.Add(this.nombreLbl);
            this.panel1.Controls.Add(this.numeroCuentaLbl);
            this.panel1.Controls.Add(this.cuentaLink);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(574, 194);
            this.panel1.TabIndex = 4;
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Image = global::APP.Properties.Resources.Salir_16;
            this.btnSalir.Location = new System.Drawing.Point(424, 148);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 25);
            this.btnSalir.TabIndex = 22;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::APP.Properties.Resources.Buscar_16;
            this.btnBuscar.Location = new System.Drawing.Point(333, 148);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 25);
            this.btnBuscar.TabIndex = 21;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = global::APP.Properties.Resources.Salvar_16;
            this.btnSalvar.Location = new System.Drawing.Point(242, 148);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 25);
            this.btnSalvar.TabIndex = 20;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            this.btnModificar.Image = global::APP.Properties.Resources.Edit_16;
            this.btnModificar.Location = new System.Drawing.Point(151, 148);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 25);
            this.btnModificar.TabIndex = 19;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::APP.Properties.Resources.Nuevo_16;
            this.btnNuevo.Location = new System.Drawing.Point(60, 148);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 25);
            this.btnNuevo.TabIndex = 18;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(75, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Detalle";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // detalleTxt
            // 
            this.detalleTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.detalleTxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.detalleTxt.Location = new System.Drawing.Point(121, 108);
            this.detalleTxt.Name = "detalleTxt";
            this.detalleTxt.Size = new System.Drawing.Size(429, 20);
            this.detalleTxt.TabIndex = 11;
            // 
            // montoTxt
            // 
            this.montoTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.montoTxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.montoTxt.Location = new System.Drawing.Point(334, 81);
            this.montoTxt.Name = "montoTxt";
            this.montoTxt.Size = new System.Drawing.Size(100, 20);
            this.montoTxt.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(288, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Monto:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(-1, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 1);
            this.panel2.TabIndex = 8;
            // 
            // tipoTransaccionCbo
            // 
            this.tipoTransaccionCbo.FormattingEnabled = true;
            this.tipoTransaccionCbo.Items.AddRange(new object[] {
            "------------",
            "RETIRO",
            "DEPOSITO"});
            this.tipoTransaccionCbo.Location = new System.Drawing.Point(121, 81);
            this.tipoTransaccionCbo.Name = "tipoTransaccionCbo";
            this.tipoTransaccionCbo.Size = new System.Drawing.Size(147, 21);
            this.tipoTransaccionCbo.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Tipo de Transaccion";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // balanceLbl
            // 
            this.balanceLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.balanceLbl.Location = new System.Drawing.Point(402, 38);
            this.balanceLbl.Name = "balanceLbl";
            this.balanceLbl.Size = new System.Drawing.Size(148, 22);
            this.balanceLbl.TabIndex = 5;
            this.balanceLbl.Text = "$ 0.00";
            this.balanceLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(350, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Balance";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bancoLbl
            // 
            this.bancoLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bancoLbl.Location = new System.Drawing.Point(60, 10);
            this.bancoLbl.Name = "bancoLbl";
            this.bancoLbl.Size = new System.Drawing.Size(284, 22);
            this.bancoLbl.TabIndex = 3;
            this.bancoLbl.Text = "Banco";
            this.bancoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nombreLbl
            // 
            this.nombreLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nombreLbl.Location = new System.Drawing.Point(166, 38);
            this.nombreLbl.Name = "nombreLbl";
            this.nombreLbl.Size = new System.Drawing.Size(178, 22);
            this.nombreLbl.TabIndex = 2;
            this.nombreLbl.Text = "Nombre";
            this.nombreLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numeroCuentaLbl
            // 
            this.numeroCuentaLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numeroCuentaLbl.Location = new System.Drawing.Point(60, 38);
            this.numeroCuentaLbl.Name = "numeroCuentaLbl";
            this.numeroCuentaLbl.Size = new System.Drawing.Size(100, 22);
            this.numeroCuentaLbl.TabIndex = 1;
            this.numeroCuentaLbl.Text = "Nº Cuenta";
            this.numeroCuentaLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cuentaLink
            // 
            this.cuentaLink.AutoSize = true;
            this.cuentaLink.Location = new System.Drawing.Point(10, 43);
            this.cuentaLink.Name = "cuentaLink";
            this.cuentaLink.Size = new System.Drawing.Size(44, 13);
            this.cuentaLink.TabIndex = 0;
            this.cuentaLink.TabStop = true;
            this.cuentaLink.Text = "Cuenta:";
            this.cuentaLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.cuentaLink_LinkClicked);
            // 
            // FrmBancosMovimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(574, 224);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTop);
            this.Name = "FrmBancosMovimientos";
            this.Text = "Bancos Movimientos";
            this.Load += new System.EventHandler(this.FrmBancosMovimientos_Load);
            this.panelTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label numeroCuentaLbl;
        private System.Windows.Forms.LinkLabel cuentaLink;
        private System.Windows.Forms.Label bancoLbl;
        private System.Windows.Forms.Label nombreLbl;
        private System.Windows.Forms.Label balanceLbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox tipoTransaccionCbo;
        private System.Windows.Forms.TextBox montoTxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox detalleTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNuevo;
    }
}