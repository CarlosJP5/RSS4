namespace APP
{
    partial class FrmUsuarios
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
            this.panelMid = new System.Windows.Forms.Panel();
            this.txtCedula = new System.Windows.Forms.MaskedTextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtFechaIngreso = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtClaveConfirma = new System.Windows.Forms.TextBox();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.errorUsuario = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorNombre = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorClave = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorConfirmaClave = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelTop.SuspendLayout();
            this.panelMid.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorClave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorConfirmaClave)).BeginInit();
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
            this.panelTop.Size = new System.Drawing.Size(531, 30);
            this.panelTop.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Century Schoolbook", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(529, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuarios";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMid
            // 
            this.panelMid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMid.Controls.Add(this.txtCedula);
            this.panelMid.Controls.Add(this.btnSalir);
            this.panelMid.Controls.Add(this.btnBuscar);
            this.panelMid.Controls.Add(this.btnGuardar);
            this.panelMid.Controls.Add(this.btnEditar);
            this.panelMid.Controls.Add(this.btnNuevo);
            this.panelMid.Controls.Add(this.panel2);
            this.panelMid.Controls.Add(this.panel1);
            this.panelMid.Controls.Add(this.txtTelefono);
            this.panelMid.Controls.Add(this.label12);
            this.panelMid.Controls.Add(this.txtClaveConfirma);
            this.panelMid.Controls.Add(this.cboEstado);
            this.panelMid.Controls.Add(this.label11);
            this.panelMid.Controls.Add(this.label10);
            this.panelMid.Controls.Add(this.label9);
            this.panelMid.Controls.Add(this.label8);
            this.panelMid.Controls.Add(this.label7);
            this.panelMid.Controls.Add(this.label6);
            this.panelMid.Controls.Add(this.label5);
            this.panelMid.Controls.Add(this.label4);
            this.panelMid.Controls.Add(this.label3);
            this.panelMid.Controls.Add(this.label2);
            this.panelMid.Controls.Add(this.txtClave);
            this.panelMid.Controls.Add(this.txtCorreo);
            this.panelMid.Controls.Add(this.txtDireccion);
            this.panelMid.Controls.Add(this.txtNombre);
            this.panelMid.Controls.Add(this.txtUsuario);
            this.panelMid.Controls.Add(this.txtCodigo);
            this.panelMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMid.Location = new System.Drawing.Point(0, 30);
            this.panelMid.Name = "panelMid";
            this.panelMid.Size = new System.Drawing.Size(531, 250);
            this.panelMid.TabIndex = 1;
            // 
            // txtCedula
            // 
            this.txtCedula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtCedula.HidePromptOnLeave = true;
            this.txtCedula.Location = new System.Drawing.Point(68, 88);
            this.txtCedula.Mask = "000-0000000-0";
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(100, 20);
            this.txtCedula.TabIndex = 4;
            this.txtCedula.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCedula_KeyDown);
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Image = global::APP.Properties.Resources.Salir_16;
            this.btnSalir.Location = new System.Drawing.Point(418, 209);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 25);
            this.btnSalir.TabIndex = 27;
            this.btnSalir.Text = "Salir [Esc]";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::APP.Properties.Resources.Buscar_16;
            this.btnBuscar.Location = new System.Drawing.Point(318, 209);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 25);
            this.btnBuscar.TabIndex = 26;
            this.btnBuscar.Text = "Buscar [F1]";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::APP.Properties.Resources.Salvar_16;
            this.btnGuardar.Location = new System.Drawing.Point(218, 209);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 25);
            this.btnGuardar.TabIndex = 25;
            this.btnGuardar.Text = "Guardar [F5]";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Image = global::APP.Properties.Resources.Edit_16;
            this.btnEditar.Location = new System.Drawing.Point(118, 209);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(90, 25);
            this.btnEditar.TabIndex = 24;
            this.btnEditar.Text = "Editar [F4]";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::APP.Properties.Resources.Nuevo_16;
            this.btnNuevo.Location = new System.Drawing.Point(18, 209);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(90, 25);
            this.btnNuevo.TabIndex = 23;
            this.btnNuevo.Text = "Nuevo [F9]";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(0, 200);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(531, 1);
            this.panel2.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtFechaIngreso);
            this.panel1.Location = new System.Drawing.Point(382, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(116, 25);
            this.panel1.TabIndex = 18;
            // 
            // txtFechaIngreso
            // 
            this.txtFechaIngreso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFechaIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaIngreso.Location = new System.Drawing.Point(0, 0);
            this.txtFechaIngreso.Name = "txtFechaIngreso";
            this.txtFechaIngreso.Size = new System.Drawing.Size(114, 23);
            this.txtFechaIngreso.TabIndex = 0;
            this.txtFechaIngreso.Text = "21 / 07 / 2022";
            this.txtFechaIngreso.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtTelefono.Location = new System.Drawing.Point(382, 62);
            this.txtTelefono.Mask = "(999) 000-0000";
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(100, 20);
            this.txtTelefono.TabIndex = 10;
            this.txtTelefono.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTelefono_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(295, 117);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "Confirmar Clave";
            // 
            // txtClaveConfirma
            // 
            this.txtClaveConfirma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.errorConfirmaClave.SetError(this.txtClaveConfirma, "e");
            this.errorConfirmaClave.SetIconPadding(this.txtClaveConfirma, 3);
            this.txtClaveConfirma.Location = new System.Drawing.Point(382, 114);
            this.txtClaveConfirma.Name = "txtClaveConfirma";
            this.txtClaveConfirma.Size = new System.Drawing.Size(121, 20);
            this.txtClaveConfirma.TabIndex = 14;
            this.txtClaveConfirma.UseSystemPasswordChar = true;
            this.txtClaveConfirma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtClaveConfirma_KeyDown);
            // 
            // cboEstado
            // 
            this.cboEstado.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Items.AddRange(new object[] {
            "ACTIVO",
            "DESACTIVO"});
            this.cboEstado.Location = new System.Drawing.Point(382, 140);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(121, 21);
            this.cboEstado.TabIndex = 16;
            this.cboEstado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboEstado_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(336, 143);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Estado";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(342, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Clave";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(301, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Fecha Ingreso";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Correo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(327, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Telefono";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Direccion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Cedula";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Codigo";
            // 
            // txtClave
            // 
            this.txtClave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.errorClave.SetError(this.txtClave, "e");
            this.errorClave.SetIconPadding(this.txtClave, 3);
            this.txtClave.Location = new System.Drawing.Point(382, 88);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(121, 20);
            this.txtClave.TabIndex = 12;
            this.txtClave.UseSystemPasswordChar = true;
            this.txtClave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtClave_KeyDown);
            // 
            // txtCorreo
            // 
            this.txtCorreo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtCorreo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCorreo.Location = new System.Drawing.Point(68, 166);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(210, 20);
            this.txtCorreo.TabIndex = 8;
            this.txtCorreo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCorreo_KeyDown);
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccion.Location = new System.Drawing.Point(68, 114);
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(210, 46);
            this.txtDireccion.TabIndex = 6;
            this.txtDireccion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDireccion_KeyDown);
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.errorNombre.SetError(this.txtNombre, "e");
            this.errorNombre.SetIconPadding(this.txtNombre, 5);
            this.txtNombre.Location = new System.Drawing.Point(68, 62);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(210, 20);
            this.txtNombre.TabIndex = 2;
            this.txtNombre.Text = "CARLOS JOSE PACHECO ECHAVARRIA";
            this.txtNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombre_KeyDown);
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.errorUsuario.SetError(this.txtUsuario, "e");
            this.errorUsuario.SetIconPadding(this.txtUsuario, 5);
            this.txtUsuario.Location = new System.Drawing.Point(68, 36);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(150, 20);
            this.txtUsuario.TabIndex = 0;
            this.txtUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsuario_KeyDown);
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(68, 10);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 20;
            // 
            // errorUsuario
            // 
            this.errorUsuario.BlinkRate = 500;
            this.errorUsuario.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.errorUsuario.ContainerControl = this;
            // 
            // errorNombre
            // 
            this.errorNombre.BlinkRate = 500;
            this.errorNombre.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.errorNombre.ContainerControl = this;
            // 
            // errorClave
            // 
            this.errorClave.BlinkRate = 500;
            this.errorClave.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.errorClave.ContainerControl = this;
            // 
            // errorConfirmaClave
            // 
            this.errorConfirmaClave.BlinkRate = 500;
            this.errorConfirmaClave.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.errorConfirmaClave.ContainerControl = this;
            // 
            // FrmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(531, 280);
            this.Controls.Add(this.panelMid);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmUsuarios";
            this.ShowIcon = false;
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.FrmUsuarios_Load);
            this.panelTop.ResumeLayout(false);
            this.panelMid.ResumeLayout(false);
            this.panelMid.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorClave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorConfirmaClave)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelMid;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.MaskedTextBox txtTelefono;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtClaveConfirma;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtFechaIngreso;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.MaskedTextBox txtCedula;
        private System.Windows.Forms.ErrorProvider errorConfirmaClave;
        private System.Windows.Forms.ErrorProvider errorClave;
        private System.Windows.Forms.ErrorProvider errorNombre;
        private System.Windows.Forms.ErrorProvider errorUsuario;
    }
}