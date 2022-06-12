namespace APP
{
    partial class FrmListaCompra
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
            this.panelMid = new System.Windows.Forms.Panel();
            this.dgvListar = new System.Windows.Forms.DataGridView();
            this.btnGenerarLista = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.linkSuplidor = new System.Windows.Forms.LinkLabel();
            this.txtIdSuplidor = new System.Windows.Forms.TextBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panelTop.Size = new System.Drawing.Size(903, 30);
            this.panelTop.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(901, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lista de Compra";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMid
            // 
            this.panelMid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMid.Controls.Add(this.dgvListar);
            this.panelMid.Controls.Add(this.btnGenerarLista);
            this.panelMid.Controls.Add(this.txtNombre);
            this.panelMid.Controls.Add(this.linkSuplidor);
            this.panelMid.Controls.Add(this.txtIdSuplidor);
            this.panelMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMid.Location = new System.Drawing.Point(0, 30);
            this.panelMid.Name = "panelMid";
            this.panelMid.Size = new System.Drawing.Size(903, 420);
            this.panelMid.TabIndex = 1;
            // 
            // dgvListar
            // 
            this.dgvListar.AllowUserToAddRows = false;
            this.dgvListar.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvListar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgvListar.Location = new System.Drawing.Point(10, 50);
            this.dgvListar.Name = "dgvListar";
            this.dgvListar.RowHeadersVisible = false;
            this.dgvListar.Size = new System.Drawing.Size(719, 300);
            this.dgvListar.TabIndex = 4;
            // 
            // btnGenerarLista
            // 
            this.btnGenerarLista.Location = new System.Drawing.Point(396, 11);
            this.btnGenerarLista.Name = "btnGenerarLista";
            this.btnGenerarLista.Size = new System.Drawing.Size(142, 23);
            this.btnGenerarLista.TabIndex = 3;
            this.btnGenerarLista.Text = "Generar Lista";
            this.btnGenerarLista.UseVisualStyleBackColor = true;
            this.btnGenerarLista.Click += new System.EventHandler(this.btnGenerarLista_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(151, 13);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(200, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // linkSuplidor
            // 
            this.linkSuplidor.ActiveLinkColor = System.Drawing.Color.Blue;
            this.linkSuplidor.AutoSize = true;
            this.linkSuplidor.Location = new System.Drawing.Point(10, 16);
            this.linkSuplidor.Name = "linkSuplidor";
            this.linkSuplidor.Size = new System.Drawing.Size(69, 13);
            this.linkSuplidor.TabIndex = 1;
            this.linkSuplidor.TabStop = true;
            this.linkSuplidor.Text = "[F1] Suplidor:";
            this.linkSuplidor.VisitedLinkColor = System.Drawing.Color.Blue;
            this.linkSuplidor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSuplidor_LinkClicked);
            // 
            // txtIdSuplidor
            // 
            this.txtIdSuplidor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtIdSuplidor.Location = new System.Drawing.Point(85, 13);
            this.txtIdSuplidor.Name = "txtIdSuplidor";
            this.txtIdSuplidor.Size = new System.Drawing.Size(60, 20);
            this.txtIdSuplidor.TabIndex = 0;
            this.txtIdSuplidor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdSuplidor_KeyDown);
            this.txtIdSuplidor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdSuplidor_KeyPress);
            this.txtIdSuplidor.Leave += new System.EventHandler(this.txtIdSuplidor_Leave);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "IdArticulo";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Codigo";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Referencia";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Nombre";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 230;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Marca";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.Column6.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column6.HeaderText = "Cant.";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 60;
            // 
            // Column7
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.Column7.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column7.HeaderText = "Costo";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // FrmListaCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(903, 450);
            this.Controls.Add(this.panelMid);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmListaCompra";
            this.ShowIcon = false;
            this.Text = "Lista Compra";
            this.Load += new System.EventHandler(this.FrmListaCompra_Load);
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
        private System.Windows.Forms.DataGridView dgvListar;
        private System.Windows.Forms.Button btnGenerarLista;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.LinkLabel linkSuplidor;
        private System.Windows.Forms.TextBox txtIdSuplidor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}