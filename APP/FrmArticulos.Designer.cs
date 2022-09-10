namespace APP
{
    partial class FrmArticulos
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
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtBeneficioMinimo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPorcientoItbis = new System.Windows.Forms.Label();
            this.txtIdArticulo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPuntoReorden = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.ckbPlanilla = new System.Windows.Forms.CheckBox();
            this.linkItbis = new System.Windows.Forms.LinkLabel();
            this.linkSuplidor = new System.Windows.Forms.LinkLabel();
            this.linkMarca = new System.Windows.Forms.LinkLabel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.txtBeneficio = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtItbis = new System.Windows.Forms.TextBox();
            this.txtIdItbis = new System.Windows.Forms.TextBox();
            this.txtSuplidor = new System.Windows.Forms.TextBox();
            this.txtIdSuplidor = new System.Windows.Forms.TextBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.txtIdMarca = new System.Windows.Forms.TextBox();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.errorCodigo = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorNombre = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorItbis = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelTop.SuspendLayout();
            this.panelMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorCodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorItbis)).BeginInit();
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
            this.panelTop.Size = new System.Drawing.Size(557, 30);
            this.panelTop.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(555, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Articulos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMid
            // 
            this.panelMid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMid.Controls.Add(this.label7);
            this.panelMid.Controls.Add(this.label13);
            this.panelMid.Controls.Add(this.txtBeneficioMinimo);
            this.panelMid.Controls.Add(this.label6);
            this.panelMid.Controls.Add(this.txtPorcientoItbis);
            this.panelMid.Controls.Add(this.txtIdArticulo);
            this.panelMid.Controls.Add(this.label5);
            this.panelMid.Controls.Add(this.txtPuntoReorden);
            this.panelMid.Controls.Add(this.btnSalir);
            this.panelMid.Controls.Add(this.btnBuscar);
            this.panelMid.Controls.Add(this.btnSalvar);
            this.panelMid.Controls.Add(this.btnModificar);
            this.panelMid.Controls.Add(this.btnNuevo);
            this.panelMid.Controls.Add(this.ckbPlanilla);
            this.panelMid.Controls.Add(this.linkItbis);
            this.panelMid.Controls.Add(this.linkSuplidor);
            this.panelMid.Controls.Add(this.linkMarca);
            this.panelMid.Controls.Add(this.label12);
            this.panelMid.Controls.Add(this.label11);
            this.panelMid.Controls.Add(this.label10);
            this.panelMid.Controls.Add(this.label9);
            this.panelMid.Controls.Add(this.label8);
            this.panelMid.Controls.Add(this.label4);
            this.panelMid.Controls.Add(this.label3);
            this.panelMid.Controls.Add(this.label2);
            this.panelMid.Controls.Add(this.cboEstado);
            this.panelMid.Controls.Add(this.txtBeneficio);
            this.panelMid.Controls.Add(this.txtPrecio);
            this.panelMid.Controls.Add(this.txtCosto);
            this.panelMid.Controls.Add(this.txtCantidad);
            this.panelMid.Controls.Add(this.txtItbis);
            this.panelMid.Controls.Add(this.txtIdItbis);
            this.panelMid.Controls.Add(this.txtSuplidor);
            this.panelMid.Controls.Add(this.txtIdSuplidor);
            this.panelMid.Controls.Add(this.txtMarca);
            this.panelMid.Controls.Add(this.txtIdMarca);
            this.panelMid.Controls.Add(this.txtReferencia);
            this.panelMid.Controls.Add(this.txtCodigo);
            this.panelMid.Controls.Add(this.txtNombre);
            this.panelMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMid.Location = new System.Drawing.Point(0, 30);
            this.panelMid.Name = "panelMid";
            this.panelMid.Size = new System.Drawing.Size(557, 251);
            this.panelMid.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(515, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "%";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(353, 146);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 13);
            this.label13.TabIndex = 40;
            this.label13.Text = "Beneficio Minimo:";
            // 
            // txtBeneficioMinimo
            // 
            this.txtBeneficioMinimo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtBeneficioMinimo.Location = new System.Drawing.Point(449, 143);
            this.txtBeneficioMinimo.Name = "txtBeneficioMinimo";
            this.txtBeneficioMinimo.Size = new System.Drawing.Size(64, 20);
            this.txtBeneficioMinimo.TabIndex = 39;
            this.txtBeneficioMinimo.Text = "20.00";
            this.txtBeneficioMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBeneficioMinimo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBeneficioMinimo_KeyDown);
            this.txtBeneficioMinimo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(515, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "%";
            // 
            // txtPorcientoItbis
            // 
            this.txtPorcientoItbis.AutoSize = true;
            this.txtPorcientoItbis.Location = new System.Drawing.Point(201, 172);
            this.txtPorcientoItbis.Name = "txtPorcientoItbis";
            this.txtPorcientoItbis.Size = new System.Drawing.Size(74, 13);
            this.txtPorcientoItbis.TabIndex = 37;
            this.txtPorcientoItbis.Text = "Porciento Itbis";
            this.txtPorcientoItbis.Visible = false;
            // 
            // txtIdArticulo
            // 
            this.txtIdArticulo.AutoSize = true;
            this.txtIdArticulo.Location = new System.Drawing.Point(234, 16);
            this.txtIdArticulo.Name = "txtIdArticulo";
            this.txtIdArticulo.Size = new System.Drawing.Size(51, 13);
            this.txtIdArticulo.TabIndex = 36;
            this.txtIdArticulo.Text = "IdArticulo";
            this.txtIdArticulo.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Punto Reorden";
            // 
            // txtPuntoReorden
            // 
            this.txtPuntoReorden.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtPuntoReorden.Location = new System.Drawing.Point(95, 169);
            this.txtPuntoReorden.Name = "txtPuntoReorden";
            this.txtPuntoReorden.Size = new System.Drawing.Size(100, 20);
            this.txtPuntoReorden.TabIndex = 34;
            this.txtPuntoReorden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPuntoReorden.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPuntoReorden_KeyDown);
            this.txtPuntoReorden.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Image = global::APP.Properties.Resources.Salir_16;
            this.btnSalir.Location = new System.Drawing.Point(394, 212);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 25);
            this.btnSalir.TabIndex = 33;
            this.btnSalir.Text = "Salir [Esc]";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::APP.Properties.Resources.Buscar_16;
            this.btnBuscar.Location = new System.Drawing.Point(298, 212);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 25);
            this.btnBuscar.TabIndex = 32;
            this.btnBuscar.Text = "Buscar [F1]";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = global::APP.Properties.Resources.Salvar_16;
            this.btnSalvar.Location = new System.Drawing.Point(202, 212);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 25);
            this.btnSalvar.TabIndex = 31;
            this.btnSalvar.Text = "Salvar [F5]";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Image = global::APP.Properties.Resources.Edit_16;
            this.btnModificar.Location = new System.Drawing.Point(106, 211);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 25);
            this.btnModificar.TabIndex = 30;
            this.btnModificar.Text = "Editar [F4]";
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::APP.Properties.Resources.Nuevo_16;
            this.btnNuevo.Location = new System.Drawing.Point(10, 211);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(90, 25);
            this.btnNuevo.TabIndex = 29;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // ckbPlanilla
            // 
            this.ckbPlanilla.AutoSize = true;
            this.ckbPlanilla.Location = new System.Drawing.Point(357, 3);
            this.ckbPlanilla.Name = "ckbPlanilla";
            this.ckbPlanilla.Size = new System.Drawing.Size(123, 17);
            this.ckbPlanilla.TabIndex = 28;
            this.ckbPlanilla.Text = "Utilizar Como Planilla";
            this.ckbPlanilla.UseVisualStyleBackColor = true;
            // 
            // linkItbis
            // 
            this.linkItbis.ActiveLinkColor = System.Drawing.Color.Blue;
            this.linkItbis.AutoSize = true;
            this.linkItbis.Location = new System.Drawing.Point(10, 146);
            this.linkItbis.Name = "linkItbis";
            this.linkItbis.Size = new System.Drawing.Size(29, 13);
            this.linkItbis.TabIndex = 27;
            this.linkItbis.TabStop = true;
            this.linkItbis.Text = "Itbis:";
            this.linkItbis.VisitedLinkColor = System.Drawing.Color.Blue;
            this.linkItbis.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkItbis_LinkClicked);
            // 
            // linkSuplidor
            // 
            this.linkSuplidor.ActiveLinkColor = System.Drawing.Color.Blue;
            this.linkSuplidor.AutoSize = true;
            this.linkSuplidor.Location = new System.Drawing.Point(10, 120);
            this.linkSuplidor.Name = "linkSuplidor";
            this.linkSuplidor.Size = new System.Drawing.Size(48, 13);
            this.linkSuplidor.TabIndex = 26;
            this.linkSuplidor.TabStop = true;
            this.linkSuplidor.Text = "Suplidor:";
            this.linkSuplidor.VisitedLinkColor = System.Drawing.Color.Blue;
            this.linkSuplidor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSuplidor_LinkClicked);
            // 
            // linkMarca
            // 
            this.linkMarca.ActiveLinkColor = System.Drawing.Color.Blue;
            this.linkMarca.AutoSize = true;
            this.linkMarca.Location = new System.Drawing.Point(10, 94);
            this.linkMarca.Name = "linkMarca";
            this.linkMarca.Size = new System.Drawing.Size(40, 13);
            this.linkMarca.TabIndex = 25;
            this.linkMarca.TabStop = true;
            this.linkMarca.Text = "Marca:";
            this.linkMarca.VisitedLinkColor = System.Drawing.Color.Blue;
            this.linkMarca.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkMarca_LinkClicked);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(353, 172);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Estado:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(353, 120);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Beneficio:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(353, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Precio:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(353, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Costo:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(353, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Cantidad:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Referencia:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Codigo:";
            // 
            // cboEstado
            // 
            this.cboEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Items.AddRange(new object[] {
            "ACTIVO",
            "DESACTIVO"});
            this.cboEstado.Location = new System.Drawing.Point(413, 169);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(121, 21);
            this.cboEstado.TabIndex = 13;
            this.cboEstado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboEstado_KeyDown);
            // 
            // txtBeneficio
            // 
            this.txtBeneficio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtBeneficio.Location = new System.Drawing.Point(413, 117);
            this.txtBeneficio.Name = "txtBeneficio";
            this.txtBeneficio.Size = new System.Drawing.Size(100, 20);
            this.txtBeneficio.TabIndex = 12;
            this.txtBeneficio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBeneficio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBeneficio_KeyDown);
            this.txtBeneficio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            this.txtBeneficio.Validating += new System.ComponentModel.CancelEventHandler(this.txtBeneficio_Validating);
            // 
            // txtPrecio
            // 
            this.txtPrecio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtPrecio.Location = new System.Drawing.Point(413, 91);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 20);
            this.txtPrecio.TabIndex = 11;
            this.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrecio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrecio_KeyDown);
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            this.txtPrecio.Validating += new System.ComponentModel.CancelEventHandler(this.txtPrecio_Validating);
            // 
            // txtCosto
            // 
            this.txtCosto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtCosto.Location = new System.Drawing.Point(413, 65);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(100, 20);
            this.txtCosto.TabIndex = 10;
            this.txtCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCosto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCosto_KeyDown);
            this.txtCosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtCantidad.Enabled = false;
            this.txtCantidad.Location = new System.Drawing.Point(413, 39);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.ReadOnly = true;
            this.txtCantidad.Size = new System.Drawing.Size(100, 20);
            this.txtCantidad.TabIndex = 9;
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCantidad_KeyDown);
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // txtItbis
            // 
            this.txtItbis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtItbis.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtItbis.Location = new System.Drawing.Point(134, 143);
            this.txtItbis.MaxLength = 40;
            this.txtItbis.Name = "txtItbis";
            this.txtItbis.ReadOnly = true;
            this.txtItbis.Size = new System.Drawing.Size(194, 20);
            this.txtItbis.TabIndex = 8;
            this.txtItbis.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdItbis_KeyDown);
            // 
            // txtIdItbis
            // 
            this.txtIdItbis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtIdItbis.Location = new System.Drawing.Point(78, 143);
            this.txtIdItbis.Name = "txtIdItbis";
            this.txtIdItbis.Size = new System.Drawing.Size(50, 20);
            this.txtIdItbis.TabIndex = 7;
            this.txtIdItbis.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdItbis_KeyDown);
            this.txtIdItbis.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdMarca_KeyPress);
            this.txtIdItbis.Leave += new System.EventHandler(this.txtIdItbis_Leave);
            // 
            // txtSuplidor
            // 
            this.txtSuplidor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtSuplidor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSuplidor.Location = new System.Drawing.Point(134, 117);
            this.txtSuplidor.MaxLength = 50;
            this.txtSuplidor.Name = "txtSuplidor";
            this.txtSuplidor.Size = new System.Drawing.Size(194, 20);
            this.txtSuplidor.TabIndex = 6;
            this.txtSuplidor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdSuplidor_KeyDown);
            this.txtSuplidor.Leave += new System.EventHandler(this.txtSuplidor_Leave);
            // 
            // txtIdSuplidor
            // 
            this.txtIdSuplidor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtIdSuplidor.Location = new System.Drawing.Point(78, 117);
            this.txtIdSuplidor.Name = "txtIdSuplidor";
            this.txtIdSuplidor.Size = new System.Drawing.Size(50, 20);
            this.txtIdSuplidor.TabIndex = 5;
            this.txtIdSuplidor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdSuplidor_KeyDown);
            this.txtIdSuplidor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdMarca_KeyPress);
            this.txtIdSuplidor.Leave += new System.EventHandler(this.txtIdSuplidor_Leave);
            // 
            // txtMarca
            // 
            this.txtMarca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtMarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMarca.Location = new System.Drawing.Point(134, 91);
            this.txtMarca.MaxLength = 40;
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(194, 20);
            this.txtMarca.TabIndex = 4;
            this.txtMarca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdMarca_KeyDown);
            this.txtMarca.Leave += new System.EventHandler(this.txtMarca_Leave);
            // 
            // txtIdMarca
            // 
            this.txtIdMarca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtIdMarca.Location = new System.Drawing.Point(78, 91);
            this.txtIdMarca.Name = "txtIdMarca";
            this.txtIdMarca.Size = new System.Drawing.Size(50, 20);
            this.txtIdMarca.TabIndex = 3;
            this.txtIdMarca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdMarca_KeyDown);
            this.txtIdMarca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdMarca_KeyPress);
            this.txtIdMarca.Leave += new System.EventHandler(this.txtIdMarca_Leave);
            // 
            // txtReferencia
            // 
            this.txtReferencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtReferencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReferencia.Location = new System.Drawing.Point(78, 65);
            this.txtReferencia.MaxLength = 50;
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(150, 20);
            this.txtReferencia.TabIndex = 2;
            this.txtReferencia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReferencia_KeyDown);
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigo.Location = new System.Drawing.Point(78, 13);
            this.txtCodigo.MaxLength = 50;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(150, 20);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
            this.txtCodigo.Leave += new System.EventHandler(this.txtCodigo_Leave);
            this.txtCodigo.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigo_Validating);
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(78, 39);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(250, 20);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombre_KeyDown);
            // 
            // errorCodigo
            // 
            this.errorCodigo.ContainerControl = this;
            // 
            // errorNombre
            // 
            this.errorNombre.ContainerControl = this;
            // 
            // errorItbis
            // 
            this.errorItbis.ContainerControl = this;
            // 
            // FrmArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(557, 281);
            this.Controls.Add(this.panelMid);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmArticulos";
            this.ShowIcon = false;
            this.Text = "Articulos";
            this.Load += new System.EventHandler(this.FrmArticulos_Load);
            this.panelTop.ResumeLayout(false);
            this.panelMid.ResumeLayout(false);
            this.panelMid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorCodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorItbis)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelMid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.TextBox txtBeneficio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtItbis;
        private System.Windows.Forms.TextBox txtIdItbis;
        private System.Windows.Forms.TextBox txtSuplidor;
        private System.Windows.Forms.TextBox txtIdSuplidor;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.TextBox txtIdMarca;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.CheckBox ckbPlanilla;
        private System.Windows.Forms.LinkLabel linkItbis;
        private System.Windows.Forms.LinkLabel linkSuplidor;
        private System.Windows.Forms.LinkLabel linkMarca;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPuntoReorden;
        private System.Windows.Forms.Label txtPorcientoItbis;
        private System.Windows.Forms.Label txtIdArticulo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorCodigo;
        private System.Windows.Forms.ErrorProvider errorNombre;
        private System.Windows.Forms.ErrorProvider errorItbis;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtBeneficioMinimo;
    }
}