namespace APP
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Detalle Articulo");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Marcas");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Ajuste Inventario");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Cambiar Codigo");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("ItBis Articulo");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Reporte Inventario");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Articulos", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Detalle Clientes");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Clientes", new System.Windows.Forms.TreeNode[] {
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Suplidores");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Detalle Usuarios");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Permiso Usuarios");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Usuarios", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("RegistroComprobantes");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Reporte 607");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("NCF", new System.Windows.Forms.TreeNode[] {
            treeNode14,
            treeNode15});
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Detalle Banco");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Cuenta Bancos");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Movimiento Bancos");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Bancos", new System.Windows.Forms.TreeNode[] {
            treeNode17,
            treeNode18,
            treeNode19});
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Datos", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode9,
            treeNode10,
            treeNode13,
            treeNode16,
            treeNode20});
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Facturacion Normal");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Devolucion S\\Venta");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Cotizaciones");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("CuadreCaja");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Facturacion", new System.Windows.Forms.TreeNode[] {
            treeNode22,
            treeNode23,
            treeNode24,
            treeNode25});
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Recibo Ingreso");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("CxC", new System.Windows.Forms.TreeNode[] {
            treeNode27});
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Compra");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Devolucion Compra");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Recibo Pago");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("CxP", new System.Windows.Forms.TreeNode[] {
            treeNode29,
            treeNode30,
            treeNode31});
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
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
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
            treeNode1.Name = "detalleArticulo";
            treeNode1.Text = "Detalle Articulo";
            treeNode2.Name = "marcas";
            treeNode2.Text = "Marcas";
            treeNode3.Name = "ajusteInventario";
            treeNode3.Text = "Ajuste Inventario";
            treeNode4.Name = "cambiarCodigo";
            treeNode4.Text = "Cambiar Codigo";
            treeNode5.Name = "itbis";
            treeNode5.Text = "ItBis Articulo";
            treeNode6.Name = "reporteInventario";
            treeNode6.Text = "Reporte Inventario";
            treeNode7.Name = "articulos";
            treeNode7.Text = "Articulos";
            treeNode8.Name = "detalleClientes";
            treeNode8.Text = "Detalle Clientes";
            treeNode9.Name = "clientes";
            treeNode9.Text = "Clientes";
            treeNode10.Name = "suplidores";
            treeNode10.Text = "Suplidores";
            treeNode11.Name = "detalleUsuario";
            treeNode11.Text = "Detalle Usuarios";
            treeNode12.Name = "permisoUsuarios";
            treeNode12.Text = "Permiso Usuarios";
            treeNode13.Name = "usuario";
            treeNode13.Text = "Usuarios";
            treeNode14.Name = "registroComprobantes";
            treeNode14.Text = "RegistroComprobantes";
            treeNode15.Name = "reporte607";
            treeNode15.Text = "Reporte 607";
            treeNode16.Name = "ncf";
            treeNode16.Text = "NCF";
            treeNode17.Name = "Node1";
            treeNode17.Text = "Detalle Banco";
            treeNode18.Name = "Node2";
            treeNode18.Text = "Cuenta Bancos";
            treeNode19.Name = "Node3";
            treeNode19.Text = "Movimiento Bancos";
            treeNode20.Name = "Node0";
            treeNode20.Text = "Bancos";
            treeNode21.Name = "datos";
            treeNode21.Text = "Datos";
            this.treeViewDatos.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode21});
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
            treeNode22.Name = "facturacionNormal";
            treeNode22.Text = "Facturacion Normal";
            treeNode23.Name = "devolucionVenta";
            treeNode23.Text = "Devolucion S\\Venta";
            treeNode24.Name = "cotizaciones";
            treeNode24.Text = "Cotizaciones";
            treeNode25.Name = "cuadreCaja";
            treeNode25.Text = "CuadreCaja";
            treeNode26.Name = "facturacion";
            treeNode26.Text = "Facturacion";
            this.treeViewFacturacion.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode26});
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
            treeNode27.Name = "reciboIngreso";
            treeNode27.Text = "Recibo Ingreso";
            treeNode28.Name = "cxc";
            treeNode28.Text = "CxC";
            this.treeViewCxc.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode28});
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
            treeNode29.Name = "compra";
            treeNode29.Text = "Compra";
            treeNode30.Name = "devolucionCompra";
            treeNode30.Text = "Devolucion Compra";
            treeNode31.Name = "reciboPago";
            treeNode31.Text = "Recibo Pago";
            treeNode32.Name = "cxp";
            treeNode32.Text = "CxP";
            this.treeViewCxp.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode32});
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