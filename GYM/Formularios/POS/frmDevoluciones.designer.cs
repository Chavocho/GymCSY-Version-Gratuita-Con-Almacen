namespace GYM.Formularios.POS
{
    partial class frmDevoluciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDevoluciones));
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.IDPV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductoV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDevoluciones = new System.Windows.Forms.DataGridView();
            this.IDPD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductoD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblVenta = new System.Windows.Forms.Label();
            this.lblDevoluciones = new System.Windows.Forms.Label();
            this.lblEtiquetaTotal = new System.Windows.Forms.Label();
            this.lblEfectivo = new System.Windows.Forms.Label();
            this.lblProductos = new System.Windows.Forms.Label();
            this.lblEtiquetaProductos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevoluciones)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowDrop = true;
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.AllowUserToResizeColumns = false;
            this.dgvProductos.AllowUserToResizeRows = false;
            this.dgvProductos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvProductos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.dgvProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDPV,
            this.ProductoV,
            this.CantidadV,
            this.PrecioV});
            this.dgvProductos.Location = new System.Drawing.Point(12, 35);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvProductos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(381, 341);
            this.dgvProductos.TabIndex = 3;
            this.dgvProductos.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvProductos_DragDrop);
            this.dgvProductos.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvProductos_DragEnter);
            this.dgvProductos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvProductos_MouseDown);
            this.dgvProductos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvProductos_MouseMove);
            // 
            // IDPV
            // 
            this.IDPV.HeaderText = "IdProducto";
            this.IDPV.Name = "IDPV";
            this.IDPV.ReadOnly = true;
            this.IDPV.Visible = false;
            // 
            // ProductoV
            // 
            this.ProductoV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductoV.HeaderText = "Producto";
            this.ProductoV.Name = "ProductoV";
            this.ProductoV.ReadOnly = true;
            // 
            // CantidadV
            // 
            this.CantidadV.HeaderText = "Cantidad";
            this.CantidadV.Name = "CantidadV";
            this.CantidadV.ReadOnly = true;
            this.CantidadV.Width = 60;
            // 
            // PrecioV
            // 
            this.PrecioV.HeaderText = "Precio";
            this.PrecioV.Name = "PrecioV";
            this.PrecioV.ReadOnly = true;
            this.PrecioV.Width = 80;
            // 
            // dgvDevoluciones
            // 
            this.dgvDevoluciones.AllowDrop = true;
            this.dgvDevoluciones.AllowUserToAddRows = false;
            this.dgvDevoluciones.AllowUserToDeleteRows = false;
            this.dgvDevoluciones.AllowUserToResizeColumns = false;
            this.dgvDevoluciones.AllowUserToResizeRows = false;
            this.dgvDevoluciones.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvDevoluciones.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.dgvDevoluciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDevoluciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvDevoluciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDevoluciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDevoluciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDPD,
            this.ProductoD,
            this.CantidadD,
            this.PrecioD});
            this.dgvDevoluciones.Location = new System.Drawing.Point(399, 35);
            this.dgvDevoluciones.Name = "dgvDevoluciones";
            this.dgvDevoluciones.ReadOnly = true;
            this.dgvDevoluciones.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDevoluciones.RowHeadersVisible = false;
            this.dgvDevoluciones.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDevoluciones.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDevoluciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDevoluciones.Size = new System.Drawing.Size(381, 341);
            this.dgvDevoluciones.TabIndex = 4;
            this.dgvDevoluciones.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvProductos_DragDrop);
            this.dgvDevoluciones.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvProductos_DragEnter);
            this.dgvDevoluciones.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvProductos_MouseDown);
            this.dgvDevoluciones.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvProductos_MouseMove);
            // 
            // IDPD
            // 
            this.IDPD.HeaderText = "IDPD";
            this.IDPD.Name = "IDPD";
            this.IDPD.ReadOnly = true;
            this.IDPD.Visible = false;
            // 
            // ProductoD
            // 
            this.ProductoD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductoD.HeaderText = "Producto";
            this.ProductoD.Name = "ProductoD";
            this.ProductoD.ReadOnly = true;
            // 
            // CantidadD
            // 
            this.CantidadD.HeaderText = "Cantidad";
            this.CantidadD.Name = "CantidadD";
            this.CantidadD.ReadOnly = true;
            this.CantidadD.Width = 60;
            // 
            // PrecioD
            // 
            this.PrecioD.HeaderText = "Precio";
            this.PrecioD.Name = "PrecioD";
            this.PrecioD.ReadOnly = true;
            this.PrecioD.Width = 80;
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnAceptar.FlatAppearance.BorderSize = 2;
            this.btnAceptar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAceptar.Image = global::GYM.Properties.Resources.ImgAceptar;
            this.btnAceptar.Location = new System.Drawing.Point(686, 382);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(94, 32);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // lblVenta
            // 
            this.lblVenta.AutoSize = true;
            this.lblVenta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblVenta.Location = new System.Drawing.Point(8, 13);
            this.lblVenta.Name = "lblVenta";
            this.lblVenta.Size = new System.Drawing.Size(145, 19);
            this.lblVenta.TabIndex = 27;
            this.lblVenta.Text = "Productos en la venta:";
            // 
            // lblDevoluciones
            // 
            this.lblDevoluciones.AutoSize = true;
            this.lblDevoluciones.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDevoluciones.Location = new System.Drawing.Point(395, 13);
            this.lblDevoluciones.Name = "lblDevoluciones";
            this.lblDevoluciones.Size = new System.Drawing.Size(141, 19);
            this.lblDevoluciones.TabIndex = 28;
            this.lblDevoluciones.Text = "Productos a devolver:";
            // 
            // lblEtiquetaTotal
            // 
            this.lblEtiquetaTotal.AutoSize = true;
            this.lblEtiquetaTotal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEtiquetaTotal.Location = new System.Drawing.Point(178, 398);
            this.lblEtiquetaTotal.Name = "lblEtiquetaTotal";
            this.lblEtiquetaTotal.Size = new System.Drawing.Size(126, 19);
            this.lblEtiquetaTotal.TabIndex = 29;
            this.lblEtiquetaTotal.Text = "Efectivo a devolver:";
            // 
            // lblEfectivo
            // 
            this.lblEfectivo.AutoSize = true;
            this.lblEfectivo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEfectivo.Location = new System.Drawing.Point(310, 398);
            this.lblEfectivo.Name = "lblEfectivo";
            this.lblEfectivo.Size = new System.Drawing.Size(44, 19);
            this.lblEfectivo.TabIndex = 30;
            this.lblEfectivo.Text = "$0.00";
            // 
            // lblProductos
            // 
            this.lblProductos.AutoSize = true;
            this.lblProductos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblProductos.Location = new System.Drawing.Point(155, 398);
            this.lblProductos.Name = "lblProductos";
            this.lblProductos.Size = new System.Drawing.Size(17, 19);
            this.lblProductos.TabIndex = 32;
            this.lblProductos.Text = "0";
            // 
            // lblEtiquetaProductos
            // 
            this.lblEtiquetaProductos.AutoSize = true;
            this.lblEtiquetaProductos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEtiquetaProductos.Location = new System.Drawing.Point(8, 398);
            this.lblEtiquetaProductos.Name = "lblEtiquetaProductos";
            this.lblEtiquetaProductos.Size = new System.Drawing.Size(141, 19);
            this.lblEtiquetaProductos.TabIndex = 31;
            this.lblEtiquetaProductos.Text = "Productos a devolver:";
            // 
            // frmDevoluciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 426);
            this.Controls.Add(this.lblProductos);
            this.Controls.Add(this.lblEtiquetaProductos);
            this.Controls.Add(this.lblEfectivo);
            this.Controls.Add(this.lblEtiquetaTotal);
            this.Controls.Add(this.lblDevoluciones);
            this.Controls.Add(this.lblVenta);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dgvDevoluciones);
            this.Controls.Add(this.dgvProductos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDevoluciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devoluciones";
            this.Load += new System.EventHandler(this.frmDevoluciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevoluciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvProductos;
        public System.Windows.Forms.DataGridView dgvDevoluciones;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblVenta;
        private System.Windows.Forms.Label lblDevoluciones;
        private System.Windows.Forms.Label lblEtiquetaTotal;
        private System.Windows.Forms.Label lblEfectivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDPD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductoD;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadD;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioD;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDPV;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductoV;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadV;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioV;
        private System.Windows.Forms.Label lblProductos;
        private System.Windows.Forms.Label lblEtiquetaProductos;
    }
}