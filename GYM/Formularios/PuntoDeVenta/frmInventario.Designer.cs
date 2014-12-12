namespace GYM.Formularios.PuntoDeVenta
{
    partial class frmInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventario));
            this.dgvProducto = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ControlStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadAlmacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInventario = new System.Windows.Forms.Button();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.lblInstrucciones = new System.Windows.Forms.Label();
            this.chbBajas = new System.Windows.Forms.CheckBox();
            this.btnCantidadAlmacen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProducto
            // 
            this.dgvProducto.AllowUserToAddRows = false;
            this.dgvProducto.AllowUserToDeleteRows = false;
            this.dgvProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProducto.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.dgvProducto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProducto.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvProducto.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Nombre,
            this.Cantidad,
            this.ControlStock,
            this.CantidadAlmacen,
            this.CantTotal});
            this.dgvProducto.Location = new System.Drawing.Point(12, 78);
            this.dgvProducto.Name = "dgvProducto";
            this.dgvProducto.ReadOnly = true;
            this.dgvProducto.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvProducto.RowHeadersVisible = false;
            this.dgvProducto.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvProducto.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducto.Size = new System.Drawing.Size(836, 298);
            this.dgvProducto.TabIndex = 20;
            // 
            // Codigo
            // 
            this.Codigo.Frozen = true;
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
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
            this.Cantidad.HeaderText = "Cantidad en mostrador";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 130;
            // 
            // ControlStock
            // 
            this.ControlStock.HeaderText = "ControlStock";
            this.ControlStock.Name = "ControlStock";
            this.ControlStock.ReadOnly = true;
            this.ControlStock.Visible = false;
            // 
            // CantidadAlmacen
            // 
            this.CantidadAlmacen.HeaderText = "Cantidad en almacen";
            this.CantidadAlmacen.Name = "CantidadAlmacen";
            this.CantidadAlmacen.ReadOnly = true;
            this.CantidadAlmacen.Width = 130;
            // 
            // CantTotal
            // 
            this.CantTotal.HeaderText = "Cantidad total";
            this.CantTotal.Name = "CantTotal";
            this.CantTotal.ReadOnly = true;
            this.CantTotal.Width = 130;
            // 
            // btnInventario
            // 
            this.btnInventario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnInventario.Location = new System.Drawing.Point(566, 382);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(138, 40);
            this.btnInventario.TabIndex = 21;
            this.btnInventario.Text = "Agregar al inventario";
            this.btnInventario.UseVisualStyleBackColor = true;
            this.btnInventario.Visible = false;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtBusqueda.Location = new System.Drawing.Point(655, 12);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(193, 29);
            this.txtBusqueda.TabIndex = 22;
            this.txtBusqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBusqueda_KeyDown);
            // 
            // lblInstrucciones
            // 
            this.lblInstrucciones.AutoSize = true;
            this.lblInstrucciones.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblInstrucciones.Location = new System.Drawing.Point(342, 15);
            this.lblInstrucciones.Name = "lblInstrucciones";
            this.lblInstrucciones.Size = new System.Drawing.Size(307, 21);
            this.lblInstrucciones.TabIndex = 23;
            this.lblInstrucciones.Text = "Buscar por nombre o por código de barras:";
            // 
            // chbBajas
            // 
            this.chbBajas.AutoSize = true;
            this.chbBajas.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chbBajas.Location = new System.Drawing.Point(655, 47);
            this.chbBajas.Name = "chbBajas";
            this.chbBajas.Size = new System.Drawing.Size(193, 25);
            this.chbBajas.TabIndex = 24;
            this.chbBajas.Text = "Buscar bajas existencias";
            this.chbBajas.UseVisualStyleBackColor = true;
            this.chbBajas.CheckedChanged += new System.EventHandler(this.chbBajas_CheckedChanged);
            // 
            // btnCantidadAlmacen
            // 
            this.btnCantidadAlmacen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCantidadAlmacen.Location = new System.Drawing.Point(710, 382);
            this.btnCantidadAlmacen.Name = "btnCantidadAlmacen";
            this.btnCantidadAlmacen.Size = new System.Drawing.Size(138, 40);
            this.btnCantidadAlmacen.TabIndex = 27;
            this.btnCantidadAlmacen.Text = "Actualizar cantidades mostrador";
            this.btnCantidadAlmacen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCantidadAlmacen.UseVisualStyleBackColor = true;
            this.btnCantidadAlmacen.Click += new System.EventHandler(this.btnCantidadAlmacen_Click);
            // 
            // frmInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 434);
            this.Controls.Add(this.btnCantidadAlmacen);
            this.Controls.Add(this.chbBajas);
            this.Controls.Add(this.lblInstrucciones);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.btnInventario);
            this.Controls.Add(this.dgvProducto);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventario";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Label lblInstrucciones;
        public System.Windows.Forms.DataGridView dgvProducto;
        private System.Windows.Forms.CheckBox chbBajas;
        private System.Windows.Forms.Button btnCantidadAlmacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ControlStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadAlmacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantTotal;
    }
}