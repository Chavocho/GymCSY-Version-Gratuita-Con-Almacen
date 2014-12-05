namespace GYM.Formularios.POS
{
    partial class frmPuntoVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPuntoVenta));
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.CodigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNueva = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnRecuperar = new System.Windows.Forms.Button();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblEtiquetaAtiende = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblNumProductos = new System.Windows.Forms.Label();
            this.lblEtiquetaNumProductos = new System.Windows.Forms.Label();
            this.lblEtiquetaTotal = new System.Windows.Forms.Label();
            this.lblFolio = new System.Windows.Forms.Label();
            this.lblEtiquetaFolio = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnMenos = new System.Windows.Forms.Button();
            this.btnMas = new System.Windows.Forms.Button();
            this.btnCobrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.dgvProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoProducto,
            this.Nombre,
            this.Cantidad,
            this.Precio});
            this.dgvProductos.Location = new System.Drawing.Point(12, 37);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvProductos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(808, 255);
            this.dgvProductos.TabIndex = 5;
            this.dgvProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellClick);
            this.dgvProductos.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvProductos_RowsAdded);
            this.dgvProductos.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvProductos_RowsRemoved);
            // 
            // CodigoProducto
            // 
            this.CodigoProducto.HeaderText = "Código Producto";
            this.CodigoProducto.Name = "CodigoProducto";
            this.CodigoProducto.ReadOnly = true;
            this.CodigoProducto.Width = 150;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 120;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Width = 120;
            // 
            // btnNueva
            // 
            this.btnNueva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNueva.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnNueva.FlatAppearance.BorderSize = 2;
            this.btnNueva.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnNueva.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnNueva.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNueva.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNueva.Image = global::GYM.Properties.Resources.ImgNuevaVenta;
            this.btnNueva.Location = new System.Drawing.Point(12, 373);
            this.btnNueva.Name = "btnNueva";
            this.btnNueva.Size = new System.Drawing.Size(102, 48);
            this.btnNueva.TabIndex = 1;
            this.btnNueva.Text = "Nueva Venta (F1)";
            this.btnNueva.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNueva.UseVisualStyleBackColor = true;
            this.btnNueva.Click += new System.EventHandler(this.btnNueva_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnProductos.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnProductos.FlatAppearance.BorderSize = 2;
            this.btnProductos.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnProductos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnProductos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnProductos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnProductos.Location = new System.Drawing.Point(336, 373);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(102, 48);
            this.btnProductos.TabIndex = 3;
            this.btnProductos.Text = "Productos\r\n(F4)";
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Visible = false;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnRecuperar
            // 
            this.btnRecuperar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRecuperar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnRecuperar.FlatAppearance.BorderSize = 2;
            this.btnRecuperar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnRecuperar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnRecuperar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRecuperar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRecuperar.Location = new System.Drawing.Point(120, 373);
            this.btnRecuperar.Name = "btnRecuperar";
            this.btnRecuperar.Size = new System.Drawing.Size(102, 48);
            this.btnRecuperar.TabIndex = 2;
            this.btnRecuperar.Text = "Recuperar Venta (F2)";
            this.btnRecuperar.UseVisualStyleBackColor = true;
            this.btnRecuperar.Click += new System.EventHandler(this.btnRecuperar_Click);
            // 
            // btnDevolver
            // 
            this.btnDevolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDevolver.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnDevolver.FlatAppearance.BorderSize = 2;
            this.btnDevolver.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnDevolver.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnDevolver.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDevolver.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDevolver.Location = new System.Drawing.Point(444, 373);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(102, 48);
            this.btnDevolver.TabIndex = 4;
            this.btnDevolver.Text = "Devolver Producto(s) (F5)";
            this.btnDevolver.UseVisualStyleBackColor = true;
            this.btnDevolver.Visible = false;
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(740, 295);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(49, 21);
            this.lblTotal.TabIndex = 10;
            this.lblTotal.Text = "$0.00";
            this.lblTotal.Visible = false;
            // 
            // lblEtiquetaAtiende
            // 
            this.lblEtiquetaAtiende.AutoSize = true;
            this.lblEtiquetaAtiende.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblEtiquetaAtiende.Location = new System.Drawing.Point(8, 9);
            this.lblEtiquetaAtiende.Name = "lblEtiquetaAtiende";
            this.lblEtiquetaAtiende.Size = new System.Drawing.Size(81, 20);
            this.lblEtiquetaAtiende.TabIndex = 11;
            this.lblEtiquetaAtiende.Text = "Le atiende:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblUsuario.Location = new System.Drawing.Point(95, 9);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(59, 20);
            this.lblUsuario.TabIndex = 12;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblNumProductos
            // 
            this.lblNumProductos.AutoSize = true;
            this.lblNumProductos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumProductos.Location = new System.Drawing.Point(585, 295);
            this.lblNumProductos.Name = "lblNumProductos";
            this.lblNumProductos.Size = new System.Drawing.Size(19, 21);
            this.lblNumProductos.TabIndex = 13;
            this.lblNumProductos.Text = "0";
            this.lblNumProductos.Visible = false;
            // 
            // lblEtiquetaNumProductos
            // 
            this.lblEtiquetaNumProductos.AutoSize = true;
            this.lblEtiquetaNumProductos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEtiquetaNumProductos.Location = new System.Drawing.Point(464, 295);
            this.lblEtiquetaNumProductos.Name = "lblEtiquetaNumProductos";
            this.lblEtiquetaNumProductos.Size = new System.Drawing.Size(125, 21);
            this.lblEtiquetaNumProductos.TabIndex = 14;
            this.lblEtiquetaNumProductos.Text = "Num. productos:";
            this.lblEtiquetaNumProductos.Visible = false;
            // 
            // lblEtiquetaTotal
            // 
            this.lblEtiquetaTotal.AutoSize = true;
            this.lblEtiquetaTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEtiquetaTotal.Location = new System.Drawing.Point(688, 295);
            this.lblEtiquetaTotal.Name = "lblEtiquetaTotal";
            this.lblEtiquetaTotal.Size = new System.Drawing.Size(47, 21);
            this.lblEtiquetaTotal.TabIndex = 15;
            this.lblEtiquetaTotal.Text = "Total:";
            this.lblEtiquetaTotal.Visible = false;
            // 
            // lblFolio
            // 
            this.lblFolio.AutoSize = true;
            this.lblFolio.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblFolio.Location = new System.Drawing.Point(699, 9);
            this.lblFolio.Name = "lblFolio";
            this.lblFolio.Size = new System.Drawing.Size(73, 20);
            this.lblFolio.TabIndex = 18;
            this.lblFolio.Text = "00000000";
            this.lblFolio.Visible = false;
            // 
            // lblEtiquetaFolio
            // 
            this.lblEtiquetaFolio.AutoSize = true;
            this.lblEtiquetaFolio.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblEtiquetaFolio.Location = new System.Drawing.Point(648, 9);
            this.lblEtiquetaFolio.Name = "lblEtiquetaFolio";
            this.lblEtiquetaFolio.Size = new System.Drawing.Size(45, 20);
            this.lblEtiquetaFolio.TabIndex = 17;
            this.lblEtiquetaFolio.Text = "Folio:";
            this.lblEtiquetaFolio.Visible = false;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCodigo.Location = new System.Drawing.Point(12, 298);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(318, 29);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnCancelar.FlatAppearance.BorderSize = 2;
            this.btnCancelar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancelar.Location = new System.Drawing.Point(228, 373);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(102, 48);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar Ventas (F3)";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnMenos
            // 
            this.btnMenos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenos.BackgroundImage = global::GYM.Properties.Resources.Menos_Inactivo;
            this.btnMenos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMenos.Enabled = false;
            this.btnMenos.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnMenos.FlatAppearance.BorderSize = 0;
            this.btnMenos.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnMenos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMenos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMenos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenos.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.btnMenos.Location = new System.Drawing.Point(826, 104);
            this.btnMenos.Name = "btnMenos";
            this.btnMenos.Size = new System.Drawing.Size(35, 35);
            this.btnMenos.TabIndex = 7;
            this.btnMenos.UseVisualStyleBackColor = true;
            this.btnMenos.Click += new System.EventHandler(this.btnMenos_Click);
            // 
            // btnMas
            // 
            this.btnMas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMas.BackgroundImage = global::GYM.Properties.Resources.Mas_Inactivo;
            this.btnMas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMas.Enabled = false;
            this.btnMas.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnMas.FlatAppearance.BorderSize = 0;
            this.btnMas.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnMas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMas.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.btnMas.Location = new System.Drawing.Point(826, 63);
            this.btnMas.Name = "btnMas";
            this.btnMas.Size = new System.Drawing.Size(35, 35);
            this.btnMas.TabIndex = 6;
            this.btnMas.UseVisualStyleBackColor = true;
            this.btnMas.Click += new System.EventHandler(this.btnMas_Click);
            // 
            // btnCobrar
            // 
            this.btnCobrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCobrar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnCobrar.FlatAppearance.BorderSize = 2;
            this.btnCobrar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCobrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnCobrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCobrar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCobrar.Image = global::GYM.Properties.Resources.ImgDinero;
            this.btnCobrar.Location = new System.Drawing.Point(759, 373);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(102, 48);
            this.btnCobrar.TabIndex = 8;
            this.btnCobrar.Text = "Cobrar\r\n(F6)";
            this.btnCobrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCobrar.UseVisualStyleBackColor = true;
            this.btnCobrar.Visible = false;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // frmPuntoVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 433);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnMenos);
            this.Controls.Add(this.btnMas);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblFolio);
            this.Controls.Add(this.lblEtiquetaFolio);
            this.Controls.Add(this.lblEtiquetaTotal);
            this.Controls.Add(this.lblEtiquetaNumProductos);
            this.Controls.Add(this.lblNumProductos);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblEtiquetaAtiende);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnDevolver);
            this.Controls.Add(this.btnRecuperar);
            this.Controls.Add(this.btnCobrar);
            this.Controls.Add(this.btnProductos);
            this.Controls.Add(this.btnNueva);
            this.Controls.Add(this.dgvProductos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmPuntoVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Punto de venta";
            this.Load += new System.EventHandler(this.frmPuntoVenta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPuntoVenta_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.Button btnNueva;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.Button btnRecuperar;
        private System.Windows.Forms.Button btnDevolver;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblEtiquetaAtiende;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblNumProductos;
        private System.Windows.Forms.Label lblEtiquetaNumProductos;
        private System.Windows.Forms.Label lblEtiquetaTotal;
        private System.Windows.Forms.Label lblFolio;
        private System.Windows.Forms.Label lblEtiquetaFolio;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnMas;
        private System.Windows.Forms.Button btnMenos;
        private System.Windows.Forms.Button btnCancelar;
    }
}