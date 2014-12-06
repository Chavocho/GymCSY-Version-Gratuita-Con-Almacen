namespace GYM.Formularios.Compras
{
    partial class frmNuevaCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevaCompra));
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.CIDP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNomProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbTotales = new System.Windows.Forms.GroupBox();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.lblEDescuento = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblETotal = new System.Windows.Forms.Label();
            this.lblImporte = new System.Windows.Forms.Label();
            this.lblEImporte = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblESubtotal = new System.Windows.Forms.Label();
            this.btnIVA = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.cboTipoPago = new System.Windows.Forms.ComboBox();
            this.lblTipoPago = new System.Windows.Forms.Label();
            this.txtRemision = new System.Windows.Forms.TextBox();
            this.lblFolioRemision = new System.Windows.Forms.Label();
            this.grbCompra = new System.Windows.Forms.GroupBox();
            this.rabFactura = new System.Windows.Forms.RadioButton();
            this.rabRemision = new System.Windows.Forms.RadioButton();
            this.lblFolioFactura = new System.Windows.Forms.Label();
            this.txtFactura = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.grbTotales.SuspendLayout();
            this.grbCompra.SuspendLayout();
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
            this.CIDP,
            this.CNomProd,
            this.CCosto,
            this.CCantidad,
            this.CDescuento});
            this.dgvProductos.Location = new System.Drawing.Point(12, 13);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvProductos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(984, 265);
            this.dgvProductos.TabIndex = 7;
            this.dgvProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellClick);
            this.dgvProductos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellDoubleClick);
            // 
            // CIDP
            // 
            this.CIDP.HeaderText = "Código de producto";
            this.CIDP.Name = "CIDP";
            this.CIDP.ReadOnly = true;
            this.CIDP.Width = 150;
            // 
            // CNomProd
            // 
            this.CNomProd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CNomProd.HeaderText = "Nombre de producto";
            this.CNomProd.Name = "CNomProd";
            this.CNomProd.ReadOnly = true;
            // 
            // CCosto
            // 
            this.CCosto.HeaderText = "Costo";
            this.CCosto.Name = "CCosto";
            this.CCosto.ReadOnly = true;
            // 
            // CCantidad
            // 
            this.CCantidad.HeaderText = "Cantidad";
            this.CCantidad.Name = "CCantidad";
            this.CCantidad.ReadOnly = true;
            // 
            // CDescuento
            // 
            this.CDescuento.HeaderText = "Descuento";
            this.CDescuento.Name = "CDescuento";
            this.CDescuento.ReadOnly = true;
            // 
            // grbTotales
            // 
            this.grbTotales.Controls.Add(this.lblDescuento);
            this.grbTotales.Controls.Add(this.lblEDescuento);
            this.grbTotales.Controls.Add(this.lblTotal);
            this.grbTotales.Controls.Add(this.lblETotal);
            this.grbTotales.Controls.Add(this.lblImporte);
            this.grbTotales.Controls.Add(this.lblEImporte);
            this.grbTotales.Controls.Add(this.lblSubtotal);
            this.grbTotales.Controls.Add(this.lblESubtotal);
            this.grbTotales.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grbTotales.Location = new System.Drawing.Point(12, 330);
            this.grbTotales.Name = "grbTotales";
            this.grbTotales.Size = new System.Drawing.Size(334, 75);
            this.grbTotales.TabIndex = 8;
            this.grbTotales.TabStop = false;
            this.grbTotales.Text = "Totales";
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblDescuento.Location = new System.Drawing.Point(240, 19);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(45, 19);
            this.lblDescuento.TabIndex = 17;
            this.lblDescuento.Text = "$0.00";
            // 
            // lblEDescuento
            // 
            this.lblEDescuento.AutoSize = true;
            this.lblEDescuento.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblEDescuento.Location = new System.Drawing.Point(157, 19);
            this.lblEDescuento.Name = "lblEDescuento";
            this.lblEDescuento.Size = new System.Drawing.Size(77, 19);
            this.lblEDescuento.TabIndex = 16;
            this.lblEDescuento.Text = "Descuento:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(240, 43);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(45, 19);
            this.lblTotal.TabIndex = 15;
            this.lblTotal.Text = "$0.00";
            // 
            // lblETotal
            // 
            this.lblETotal.AutoSize = true;
            this.lblETotal.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblETotal.Location = new System.Drawing.Point(192, 43);
            this.lblETotal.Name = "lblETotal";
            this.lblETotal.Size = new System.Drawing.Size(42, 19);
            this.lblETotal.TabIndex = 14;
            this.lblETotal.Text = "Total:";
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblImporte.Location = new System.Drawing.Point(75, 43);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(45, 19);
            this.lblImporte.TabIndex = 13;
            this.lblImporte.Text = "$0.00";
            // 
            // lblEImporte
            // 
            this.lblEImporte.AutoSize = true;
            this.lblEImporte.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblEImporte.Location = new System.Drawing.Point(8, 42);
            this.lblEImporte.Name = "lblEImporte";
            this.lblEImporte.Size = new System.Drawing.Size(61, 19);
            this.lblEImporte.TabIndex = 12;
            this.lblEImporte.Text = "Importe:";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblSubtotal.Location = new System.Drawing.Point(75, 19);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(45, 19);
            this.lblSubtotal.TabIndex = 11;
            this.lblSubtotal.Text = "$0.00";
            // 
            // lblESubtotal
            // 
            this.lblESubtotal.AutoSize = true;
            this.lblESubtotal.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblESubtotal.Location = new System.Drawing.Point(6, 19);
            this.lblESubtotal.Name = "lblESubtotal";
            this.lblESubtotal.Size = new System.Drawing.Size(63, 19);
            this.lblESubtotal.TabIndex = 10;
            this.lblESubtotal.Text = "Subtotal:";
            // 
            // btnIVA
            // 
            this.btnIVA.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnIVA.Location = new System.Drawing.Point(12, 283);
            this.btnIVA.Name = "btnIVA";
            this.btnIVA.Size = new System.Drawing.Size(135, 23);
            this.btnIVA.TabIndex = 9;
            this.btnIVA.Text = "Configurar I.V.A.";
            this.btnIVA.UseVisualStyleBackColor = true;
            this.btnIVA.Click += new System.EventHandler(this.btnIVA_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnProductos.Location = new System.Drawing.Point(153, 283);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(135, 23);
            this.btnProductos.TabIndex = 11;
            this.btnProductos.Text = "Agregar producto";
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnEliminar.Location = new System.Drawing.Point(861, 283);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(135, 23);
            this.btnEliminar.TabIndex = 12;
            this.btnEliminar.Text = "Eliminar producto";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // cboTipoPago
            // 
            this.cboTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPago.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTipoPago.FormattingEnabled = true;
            this.cboTipoPago.Items.AddRange(new object[] {
            "Efectivo",
            "Tarjeta"});
            this.cboTipoPago.Location = new System.Drawing.Point(6, 41);
            this.cboTipoPago.Name = "cboTipoPago";
            this.cboTipoPago.Size = new System.Drawing.Size(242, 25);
            this.cboTipoPago.TabIndex = 22;
            // 
            // lblTipoPago
            // 
            this.lblTipoPago.AutoSize = true;
            this.lblTipoPago.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblTipoPago.Location = new System.Drawing.Point(2, 19);
            this.lblTipoPago.Name = "lblTipoPago";
            this.lblTipoPago.Size = new System.Drawing.Size(89, 19);
            this.lblTipoPago.TabIndex = 18;
            this.lblTipoPago.Text = "Tipo de pago";
            // 
            // txtRemision
            // 
            this.txtRemision.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRemision.Location = new System.Drawing.Point(6, 91);
            this.txtRemision.Name = "txtRemision";
            this.txtRemision.Size = new System.Drawing.Size(242, 25);
            this.txtRemision.TabIndex = 23;
            // 
            // lblFolioRemision
            // 
            this.lblFolioRemision.AutoSize = true;
            this.lblFolioRemision.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblFolioRemision.Location = new System.Drawing.Point(2, 69);
            this.lblFolioRemision.Name = "lblFolioRemision";
            this.lblFolioRemision.Size = new System.Drawing.Size(94, 19);
            this.lblFolioRemision.TabIndex = 24;
            this.lblFolioRemision.Text = "Folio remisión";
            // 
            // grbCompra
            // 
            this.grbCompra.Controls.Add(this.rabFactura);
            this.grbCompra.Controls.Add(this.rabRemision);
            this.grbCompra.Controls.Add(this.lblFolioFactura);
            this.grbCompra.Controls.Add(this.txtFactura);
            this.grbCompra.Controls.Add(this.lblFolioRemision);
            this.grbCompra.Controls.Add(this.lblTipoPago);
            this.grbCompra.Controls.Add(this.txtRemision);
            this.grbCompra.Controls.Add(this.cboTipoPago);
            this.grbCompra.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grbCompra.Location = new System.Drawing.Point(352, 283);
            this.grbCompra.Name = "grbCompra";
            this.grbCompra.Size = new System.Drawing.Size(503, 122);
            this.grbCompra.TabIndex = 25;
            this.grbCompra.TabStop = false;
            this.grbCompra.Text = "Datos de compra";
            // 
            // rabFactura
            // 
            this.rabFactura.AutoSize = true;
            this.rabFactura.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rabFactura.Location = new System.Drawing.Point(366, 41);
            this.rabFactura.Name = "rabFactura";
            this.rabFactura.Size = new System.Drawing.Size(72, 23);
            this.rabFactura.TabIndex = 30;
            this.rabFactura.Text = "Factura";
            this.rabFactura.UseVisualStyleBackColor = true;
            this.rabFactura.CheckedChanged += new System.EventHandler(this.rabFactura_CheckedChanged);
            // 
            // rabRemision
            // 
            this.rabRemision.AutoSize = true;
            this.rabRemision.Checked = true;
            this.rabRemision.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rabRemision.Location = new System.Drawing.Point(254, 41);
            this.rabRemision.Name = "rabRemision";
            this.rabRemision.Size = new System.Drawing.Size(82, 23);
            this.rabRemision.TabIndex = 29;
            this.rabRemision.TabStop = true;
            this.rabRemision.Text = "Remision";
            this.rabRemision.UseVisualStyleBackColor = true;
            this.rabRemision.CheckedChanged += new System.EventHandler(this.rabRemision_CheckedChanged);
            // 
            // lblFolioFactura
            // 
            this.lblFolioFactura.AutoSize = true;
            this.lblFolioFactura.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblFolioFactura.Location = new System.Drawing.Point(250, 69);
            this.lblFolioFactura.Name = "lblFolioFactura";
            this.lblFolioFactura.Size = new System.Drawing.Size(84, 19);
            this.lblFolioFactura.TabIndex = 26;
            this.lblFolioFactura.Text = "Folio factura";
            // 
            // txtFactura
            // 
            this.txtFactura.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFactura.Location = new System.Drawing.Point(254, 91);
            this.txtFactura.Name = "txtFactura";
            this.txtFactura.Size = new System.Drawing.Size(243, 25);
            this.txtFactura.TabIndex = 25;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAceptar.Image = global::GYM.Properties.Resources.ImgAceptar;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(861, 366);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(135, 39);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Ingresar compra";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmNuevaCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 417);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnProductos);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnIVA);
            this.Controls.Add(this.grbTotales);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.grbCompra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmNuevaCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva Compra";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.grbTotales.ResumeLayout(false);
            this.grbTotales.PerformLayout();
            this.grbCompra.ResumeLayout(false);
            this.grbCompra.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.GroupBox grbTotales;
        private System.Windows.Forms.Button btnIVA;
        private System.Windows.Forms.Label lblESubtotal;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblETotal;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.Label lblEImporte;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Label lblEDescuento;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIDP;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNomProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDescuento;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ComboBox cboTipoPago;
        private System.Windows.Forms.Label lblTipoPago;
        private System.Windows.Forms.TextBox txtRemision;
        private System.Windows.Forms.Label lblFolioRemision;
        private System.Windows.Forms.GroupBox grbCompra;
        private System.Windows.Forms.Label lblFolioFactura;
        private System.Windows.Forms.TextBox txtFactura;
        private System.Windows.Forms.RadioButton rabRemision;
        private System.Windows.Forms.RadioButton rabFactura;
    }
}