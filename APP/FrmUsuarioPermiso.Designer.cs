﻿namespace APP
{
    partial class FrmUsuarioPermiso
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
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Detalle Articulo");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Marcas");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Ajuste Inventario");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Cambiar Codigo");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("ItBis Articulo");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("Reporte Inventario");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("Articulos", new System.Windows.Forms.TreeNode[] {
            treeNode29,
            treeNode30,
            treeNode31,
            treeNode32,
            treeNode33,
            treeNode34});
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("Detalle Clientes");
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("Clientes", new System.Windows.Forms.TreeNode[] {
            treeNode36});
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("Suplidores");
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("Detalle Usuarios");
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("Permiso Usuarios");
            System.Windows.Forms.TreeNode treeNode41 = new System.Windows.Forms.TreeNode("Usuarios", new System.Windows.Forms.TreeNode[] {
            treeNode39,
            treeNode40});
            System.Windows.Forms.TreeNode treeNode42 = new System.Windows.Forms.TreeNode("RegistroComprobantes");
            System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode("Reporte 607");
            System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("NCF", new System.Windows.Forms.TreeNode[] {
            treeNode42,
            treeNode43});
            System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode("Datos", new System.Windows.Forms.TreeNode[] {
            treeNode35,
            treeNode37,
            treeNode38,
            treeNode41,
            treeNode44});
            System.Windows.Forms.TreeNode treeNode46 = new System.Windows.Forms.TreeNode("Facturacion Normal");
            System.Windows.Forms.TreeNode treeNode47 = new System.Windows.Forms.TreeNode("Devolucion S\\Venta");
            System.Windows.Forms.TreeNode treeNode48 = new System.Windows.Forms.TreeNode("Cotizaciones");
            System.Windows.Forms.TreeNode treeNode49 = new System.Windows.Forms.TreeNode("CuadreCaja");
            System.Windows.Forms.TreeNode treeNode50 = new System.Windows.Forms.TreeNode("Facturacion", new System.Windows.Forms.TreeNode[] {
            treeNode46,
            treeNode47,
            treeNode48,
            treeNode49});
            System.Windows.Forms.TreeNode treeNode51 = new System.Windows.Forms.TreeNode("Recibo Ingreso");
            System.Windows.Forms.TreeNode treeNode52 = new System.Windows.Forms.TreeNode("CxC", new System.Windows.Forms.TreeNode[] {
            treeNode51});
            System.Windows.Forms.TreeNode treeNode53 = new System.Windows.Forms.TreeNode("Compra");
            System.Windows.Forms.TreeNode treeNode54 = new System.Windows.Forms.TreeNode("Devolucion Compra");
            System.Windows.Forms.TreeNode treeNode55 = new System.Windows.Forms.TreeNode("Recibo Pago");
            System.Windows.Forms.TreeNode treeNode56 = new System.Windows.Forms.TreeNode("CxP", new System.Windows.Forms.TreeNode[] {
            treeNode53,
            treeNode54,
            treeNode55});
            this.panelTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.treeViewDatos = new System.Windows.Forms.TreeView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.treeViewFacturacion = new System.Windows.Forms.TreeView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.treeViewCxc = new System.Windows.Forms.TreeView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.treeViewCxp = new System.Windows.Forms.TreeView();
            this.panelTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
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
            this.panelTop.Size = new System.Drawing.Size(341, 30);
            this.panelTop.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario Permiso";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.btnSalvar);
            this.panel1.Controls.Add(this.btnNuevo);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(341, 393);
            this.panel1.TabIndex = 2;
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Image = global::APP.Properties.Resources.Salir_16;
            this.btnSalir.Location = new System.Drawing.Point(216, 350);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 25);
            this.btnSalir.TabIndex = 38;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = global::APP.Properties.Resources.Salvar_16;
            this.btnSalvar.Location = new System.Drawing.Point(120, 350);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 25);
            this.btnSalvar.TabIndex = 36;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::APP.Properties.Resources.Nuevo_16;
            this.btnNuevo.Location = new System.Drawing.Point(23, 350);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(90, 25);
            this.btnNuevo.TabIndex = 34;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::APP.Properties.Resources.Buscar_16;
            this.btnBuscar.Location = new System.Drawing.Point(223, 29);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 25);
            this.btnBuscar.TabIndex = 27;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(19, 32);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(198, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Schoolbook", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Seleccione un Usuario";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(19, 60);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(294, 276);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.treeViewDatos);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(286, 250);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // treeViewDatos
            // 
            this.treeViewDatos.CheckBoxes = true;
            this.treeViewDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewDatos.Location = new System.Drawing.Point(3, 3);
            this.treeViewDatos.Name = "treeViewDatos";
            treeNode29.Name = "detalleArticulo";
            treeNode29.Text = "Detalle Articulo";
            treeNode30.Name = "marcas";
            treeNode30.Text = "Marcas";
            treeNode31.Name = "ajusteInventario";
            treeNode31.Text = "Ajuste Inventario";
            treeNode32.Name = "cambiarCodigo";
            treeNode32.Text = "Cambiar Codigo";
            treeNode33.Name = "itbis";
            treeNode33.Text = "ItBis Articulo";
            treeNode34.Name = "reporteInventario";
            treeNode34.Text = "Reporte Inventario";
            treeNode35.Name = "articulos";
            treeNode35.Text = "Articulos";
            treeNode36.Name = "detalleClientes";
            treeNode36.Text = "Detalle Clientes";
            treeNode37.Name = "clientes";
            treeNode37.Text = "Clientes";
            treeNode38.Name = "suplidores";
            treeNode38.Text = "Suplidores";
            treeNode39.Name = "detalleUsuario";
            treeNode39.Text = "Detalle Usuarios";
            treeNode40.Name = "permisoUsuarios";
            treeNode40.Text = "Permiso Usuarios";
            treeNode41.Name = "usuario";
            treeNode41.Text = "Usuarios";
            treeNode42.Name = "registroComprobantes";
            treeNode42.Text = "RegistroComprobantes";
            treeNode43.Name = "reporte607";
            treeNode43.Text = "Reporte 607";
            treeNode44.Name = "ncf";
            treeNode44.Text = "NCF";
            treeNode45.Name = "datos";
            treeNode45.Text = "Datos";
            this.treeViewDatos.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode45});
            this.treeViewDatos.Size = new System.Drawing.Size(280, 244);
            this.treeViewDatos.TabIndex = 28;
            this.treeViewDatos.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewDatos_AfterCheck);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.treeViewFacturacion);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(286, 250);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Facturacion";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // treeViewFacturacion
            // 
            this.treeViewFacturacion.CheckBoxes = true;
            this.treeViewFacturacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewFacturacion.Location = new System.Drawing.Point(3, 3);
            this.treeViewFacturacion.Name = "treeViewFacturacion";
            treeNode46.Name = "facturacionNormal";
            treeNode46.Text = "Facturacion Normal";
            treeNode47.Name = "devolucionVenta";
            treeNode47.Text = "Devolucion S\\Venta";
            treeNode48.Name = "cotizaciones";
            treeNode48.Text = "Cotizaciones";
            treeNode49.Name = "cuadreCaja";
            treeNode49.Text = "CuadreCaja";
            treeNode50.Name = "facturacion";
            treeNode50.Text = "Facturacion";
            this.treeViewFacturacion.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode50});
            this.treeViewFacturacion.Size = new System.Drawing.Size(280, 244);
            this.treeViewFacturacion.TabIndex = 0;
            this.treeViewFacturacion.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFacturacion_AfterCheck);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.treeViewCxc);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(286, 250);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "CxC";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // treeViewCxc
            // 
            this.treeViewCxc.CheckBoxes = true;
            this.treeViewCxc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewCxc.Location = new System.Drawing.Point(0, 0);
            this.treeViewCxc.Name = "treeViewCxc";
            treeNode51.Name = "reciboIngreso";
            treeNode51.Text = "Recibo Ingreso";
            treeNode52.Name = "cxc";
            treeNode52.Text = "CxC";
            this.treeViewCxc.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode52});
            this.treeViewCxc.Size = new System.Drawing.Size(286, 250);
            this.treeViewCxc.TabIndex = 0;
            this.treeViewCxc.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewCxc_AfterCheck);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.treeViewCxp);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(286, 250);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "CxP";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // treeViewCxp
            // 
            this.treeViewCxp.CheckBoxes = true;
            this.treeViewCxp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewCxp.Location = new System.Drawing.Point(0, 0);
            this.treeViewCxp.Name = "treeViewCxp";
            treeNode53.Name = "compra";
            treeNode53.Text = "Compra";
            treeNode54.Name = "devolucionCompra";
            treeNode54.Text = "Devolucion Compra";
            treeNode55.Name = "reciboPago";
            treeNode55.Text = "Recibo Pago";
            treeNode56.Name = "cxp";
            treeNode56.Text = "CxP";
            this.treeViewCxp.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode56});
            this.treeViewCxp.Size = new System.Drawing.Size(286, 250);
            this.treeViewCxp.TabIndex = 0;
            this.treeViewCxp.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewCxp_AfterCheck);
            // 
            // FrmUsuarioPermiso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(341, 423);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTop);
            this.Name = "FrmUsuarioPermiso";
            this.Text = "Usuario Permiso";
            this.Load += new System.EventHandler(this.FrmUsuarioPermiso_Load);
            this.panelTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TreeView treeViewDatos;
        private System.Windows.Forms.TreeView treeViewFacturacion;
        private System.Windows.Forms.TreeView treeViewCxc;
        private System.Windows.Forms.TreeView treeViewCxp;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnNuevo;
    }
}