namespace APP
{
    partial class FrmBancosCuentas
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
            this.idCuentaLbl = new System.Windows.Forms.Label();
            this.linkBanco = new System.Windows.Forms.LinkLabel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numeroCuentaTxt = new System.Windows.Forms.TextBox();
            this.cuentaNombreTxt = new System.Windows.Forms.TextBox();
            this.bancoNombreTxt = new System.Windows.Forms.TextBox();
            this.idBancoTxt = new System.Windows.Forms.TextBox();
            this.errorBanco = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorNombre = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorNumero = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelTop.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorBanco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorNumero)).BeginInit();
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
            this.panelTop.Size = new System.Drawing.Size(435, 30);
            this.panelTop.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(433, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cuentas de Bancos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.idCuentaLbl);
            this.panel1.Controls.Add(this.linkBanco);
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.btnSalvar);
            this.panel1.Controls.Add(this.btnModificar);
            this.panel1.Controls.Add(this.btnNuevo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.numeroCuentaTxt);
            this.panel1.Controls.Add(this.cuentaNombreTxt);
            this.panel1.Controls.Add(this.bancoNombreTxt);
            this.panel1.Controls.Add(this.idBancoTxt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 141);
            this.panel1.TabIndex = 3;
            // 
            // idCuentaLbl
            // 
            this.idCuentaLbl.AutoSize = true;
            this.idCuentaLbl.Location = new System.Drawing.Point(283, 40);
            this.idCuentaLbl.Name = "idCuentaLbl";
            this.idCuentaLbl.Size = new System.Drawing.Size(12, 13);
            this.idCuentaLbl.TabIndex = 17;
            this.idCuentaLbl.Text = "x";
            this.idCuentaLbl.Visible = false;
            // 
            // linkBanco
            // 
            this.linkBanco.AutoSize = true;
            this.linkBanco.Location = new System.Drawing.Point(37, 14);
            this.linkBanco.Name = "linkBanco";
            this.linkBanco.Size = new System.Drawing.Size(38, 13);
            this.linkBanco.TabIndex = 16;
            this.linkBanco.TabStop = true;
            this.linkBanco.Text = "Banco";
            this.linkBanco.VisitedLinkColor = System.Drawing.Color.Blue;
            this.linkBanco.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkBanco_LinkClicked);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::APP.Properties.Resources.Salir_16;
            this.btnSalir.Location = new System.Drawing.Point(334, 100);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 25);
            this.btnSalir.TabIndex = 15;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::APP.Properties.Resources.Buscar_16;
            this.btnBuscar.Location = new System.Drawing.Point(253, 100);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 25);
            this.btnBuscar.TabIndex = 14;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = global::APP.Properties.Resources.Salvar_16;
            this.btnSalvar.Location = new System.Drawing.Point(172, 100);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 25);
            this.btnSalvar.TabIndex = 13;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Image = global::APP.Properties.Resources.Edit_16;
            this.btnModificar.Location = new System.Drawing.Point(91, 100);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 25);
            this.btnModificar.TabIndex = 12;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::APP.Properties.Resources.Nuevo_16;
            this.btnNuevo.Location = new System.Drawing.Point(10, 100);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 25);
            this.btnNuevo.TabIndex = 11;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Numero";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nombre Cta.";
            // 
            // numeroCuentaTxt
            // 
            this.numeroCuentaTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.numeroCuentaTxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.numeroCuentaTxt.Location = new System.Drawing.Point(81, 63);
            this.numeroCuentaTxt.Name = "numeroCuentaTxt";
            this.numeroCuentaTxt.Size = new System.Drawing.Size(100, 20);
            this.numeroCuentaTxt.TabIndex = 3;
            this.numeroCuentaTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numeroCuentaTxt_KeyDown);
            // 
            // cuentaNombreTxt
            // 
            this.cuentaNombreTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cuentaNombreTxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cuentaNombreTxt.Location = new System.Drawing.Point(81, 37);
            this.cuentaNombreTxt.Name = "cuentaNombreTxt";
            this.cuentaNombreTxt.Size = new System.Drawing.Size(196, 20);
            this.cuentaNombreTxt.TabIndex = 2;
            this.cuentaNombreTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cuentaNombreTxt_KeyDown);
            // 
            // bancoNombreTxt
            // 
            this.bancoNombreTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bancoNombreTxt.Location = new System.Drawing.Point(127, 11);
            this.bancoNombreTxt.Name = "bancoNombreTxt";
            this.bancoNombreTxt.ReadOnly = true;
            this.bancoNombreTxt.Size = new System.Drawing.Size(150, 20);
            this.bancoNombreTxt.TabIndex = 1;
            // 
            // idBancoTxt
            // 
            this.idBancoTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.idBancoTxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.idBancoTxt.Location = new System.Drawing.Point(81, 11);
            this.idBancoTxt.Name = "idBancoTxt";
            this.idBancoTxt.Size = new System.Drawing.Size(40, 20);
            this.idBancoTxt.TabIndex = 0;
            this.idBancoTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.idBancoTxt_KeyDown);
            this.idBancoTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.idBancoTxt_KeyPress);
            this.idBancoTxt.Validating += new System.ComponentModel.CancelEventHandler(this.idBancoTxt_Validating);
            // 
            // errorBanco
            // 
            this.errorBanco.ContainerControl = this;
            // 
            // errorNombre
            // 
            this.errorNombre.ContainerControl = this;
            // 
            // errorNumero
            // 
            this.errorNumero.ContainerControl = this;
            // 
            // FrmBancosCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(435, 171);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmBancosCuentas";
            this.ShowIcon = false;
            this.Text = "Cuentas de Bancos";
            this.Load += new System.EventHandler(this.FrmBancosCuentas_Load);
            this.panelTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorBanco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorNumero)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox idBancoTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox numeroCuentaTxt;
        private System.Windows.Forms.TextBox cuentaNombreTxt;
        private System.Windows.Forms.TextBox bancoNombreTxt;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.LinkLabel linkBanco;
        private System.Windows.Forms.ErrorProvider errorBanco;
        private System.Windows.Forms.ErrorProvider errorNombre;
        private System.Windows.Forms.ErrorProvider errorNumero;
        private System.Windows.Forms.Label idCuentaLbl;
    }
}