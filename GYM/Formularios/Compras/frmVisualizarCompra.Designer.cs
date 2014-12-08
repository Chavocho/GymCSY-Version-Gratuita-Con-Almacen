namespace GYM.Formularios.Compras
{
    partial class frmVisualizarCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisualizarCompra));
            this.pnlCompra = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblETotal = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.lblEDescuento = new System.Windows.Forms.Label();
            this.lblImporte = new System.Windows.Forms.Label();
            this.lblEImporte = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblESubtotal = new System.Windows.Forms.Label();
            this.lblFolioFactura = new System.Windows.Forms.Label();
            this.lblEFolioFactura = new System.Windows.Forms.Label();
            this.lblFolioRemision = new System.Windows.Forms.Label();
            this.lblEFolioRemision = new System.Windows.Forms.Label();
            this.lblFactura = new System.Windows.Forms.Label();
            this.lblEFactura = new System.Windows.Forms.Label();
            this.lblRemision = new System.Windows.Forms.Label();
            this.lblERemision = new System.Windows.Forms.Label();
            this.lblTipoPago = new System.Windows.Forms.Label();
            this.lblETipoPago = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblEFecha = new System.Windows.Forms.Label();
            this.dgvCompraDetallada = new System.Windows.Forms.DataGridView();
            this.CIDProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.pnlCompra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompraDetallada)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCompra
            // 
            this.pnlCompra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCompra.Controls.Add(this.lblTotal);
            this.pnlCompra.Controls.Add(this.lblETotal);
            this.pnlCompra.Controls.Add(this.lblDescuento);
            this.pnlCompra.Controls.Add(this.lblEDescuento);
            this.pnlCompra.Controls.Add(this.lblImporte);
            this.pnlCompra.Controls.Add(this.lblEImporte);
            this.pnlCompra.Controls.Add(this.lblSubtotal);
            this.pnlCompra.Controls.Add(this.lblESubtotal);
            this.pnlCompra.Controls.Add(this.lblFolioFactura);
            this.pnlCompra.Controls.Add(this.lblEFolioFactura);
            this.pnlCompra.Controls.Add(this.lblFolioRemision);
            this.pnlCompra.Controls.Add(this.lblEFolioRemision);
            this.pnlCompra.Controls.Add(this.lblFactura);
            this.pnlCompra.Controls.Add(this.lblEFactura);
            this.pnlCompra.Controls.Add(this.lblRemision);
            this.pnlCompra.Controls.Add(this.lblERemision);
            this.pnlCompra.Controls.Add(this.lblTipoPago);
            this.pnlCompra.Controls.Add(this.lblETipoPago);
            this.pnlCompra.Controls.Add(this.lblFecha);
            this.pnlCompra.Controls.Add(this.lblEFecha);
            this.pnlCompra.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.pnlCompra.Location = new System.Drawing.Point(0, 0);
            this.pnlCompra.Name = "pnlCompra";
            this.pnlCompra.Size = new System.Drawing.Size(1008, 115);
            this.pnlCompra.TabIndex = 1;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(918, 84);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(69, 19);
            this.lblTotal.TabIndex = 19;
            this.lblTotal.Text = "$1350.50";
            // 
            // lblETotal
            // 
            this.lblETotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblETotal.AutoSize = true;
            this.lblETotal.Location = new System.Drawing.Point(873, 65);
            this.lblETotal.Name = "lblETotal";
            this.lblETotal.Size = new System.Drawing.Size(39, 19);
            this.lblETotal.TabIndex = 18;
            this.lblETotal.Text = "Total";
            // 
            // lblDescuento
            // 
            this.lblDescuento.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDescuento.Location = new System.Drawing.Point(793, 84);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(69, 19);
            this.lblDescuento.TabIndex = 17;
            this.lblDescuento.Text = "$1350.50";
            // 
            // lblEDescuento
            // 
            this.lblEDescuento.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEDescuento.AutoSize = true;
            this.lblEDescuento.Location = new System.Drawing.Point(713, 65);
            this.lblEDescuento.Name = "lblEDescuento";
            this.lblEDescuento.Size = new System.Drawing.Size(74, 19);
            this.lblEDescuento.TabIndex = 16;
            this.lblEDescuento.Text = "Descuento";
            // 
            // lblImporte
            // 
            this.lblImporte.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblImporte.AutoSize = true;
            this.lblImporte.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblImporte.Location = new System.Drawing.Point(637, 84);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(69, 19);
            this.lblImporte.TabIndex = 15;
            this.lblImporte.Text = "$1350.50";
            // 
            // lblEImporte
            // 
            this.lblEImporte.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEImporte.AutoSize = true;
            this.lblEImporte.Location = new System.Drawing.Point(573, 65);
            this.lblEImporte.Name = "lblEImporte";
            this.lblEImporte.Size = new System.Drawing.Size(58, 19);
            this.lblEImporte.TabIndex = 14;
            this.lblEImporte.Text = "Importe";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSubtotal.Location = new System.Drawing.Point(487, 84);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(69, 19);
            this.lblSubtotal.TabIndex = 13;
            this.lblSubtotal.Text = "$1350.50";
            // 
            // lblESubtotal
            // 
            this.lblESubtotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblESubtotal.AutoSize = true;
            this.lblESubtotal.Location = new System.Drawing.Point(421, 65);
            this.lblESubtotal.Name = "lblESubtotal";
            this.lblESubtotal.Size = new System.Drawing.Size(60, 19);
            this.lblESubtotal.TabIndex = 12;
            this.lblESubtotal.Text = "Subtotal";
            // 
            // lblFolioFactura
            // 
            this.lblFolioFactura.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFolioFactura.AutoSize = true;
            this.lblFolioFactura.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFolioFactura.Location = new System.Drawing.Point(331, 84);
            this.lblFolioFactura.Name = "lblFolioFactura";
            this.lblFolioFactura.Size = new System.Drawing.Size(73, 19);
            this.lblFolioFactura.TabIndex = 11;
            this.lblFolioFactura.Text = "46528012";
            // 
            // lblEFolioFactura
            // 
            this.lblEFolioFactura.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEFolioFactura.AutoSize = true;
            this.lblEFolioFactura.Location = new System.Drawing.Point(222, 65);
            this.lblEFolioFactura.Name = "lblEFolioFactura";
            this.lblEFolioFactura.Size = new System.Drawing.Size(103, 19);
            this.lblEFolioFactura.TabIndex = 10;
            this.lblEFolioFactura.Text = "Folio de factura";
            // 
            // lblFolioRemision
            // 
            this.lblFolioRemision.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFolioRemision.AutoSize = true;
            this.lblFolioRemision.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFolioRemision.Location = new System.Drawing.Point(131, 84);
            this.lblFolioRemision.Name = "lblFolioRemision";
            this.lblFolioRemision.Size = new System.Drawing.Size(73, 19);
            this.lblFolioRemision.TabIndex = 9;
            this.lblFolioRemision.Text = "46528012";
            // 
            // lblEFolioRemision
            // 
            this.lblEFolioRemision.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEFolioRemision.AutoSize = true;
            this.lblEFolioRemision.Location = new System.Drawing.Point(12, 65);
            this.lblEFolioRemision.Name = "lblEFolioRemision";
            this.lblEFolioRemision.Size = new System.Drawing.Size(113, 19);
            this.lblEFolioRemision.TabIndex = 8;
            this.lblEFolioRemision.Text = "Folio de remisión";
            // 
            // lblFactura
            // 
            this.lblFactura.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFactura.AutoSize = true;
            this.lblFactura.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFactura.Location = new System.Drawing.Point(918, 28);
            this.lblFactura.Name = "lblFactura";
            this.lblFactura.Size = new System.Drawing.Size(21, 19);
            this.lblFactura.TabIndex = 7;
            this.lblFactura.Text = "Si";
            // 
            // lblEFactura
            // 
            this.lblEFactura.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEFactura.AutoSize = true;
            this.lblEFactura.Location = new System.Drawing.Point(799, 9);
            this.lblEFactura.Name = "lblEFactura";
            this.lblEFactura.Size = new System.Drawing.Size(113, 19);
            this.lblEFactura.TabIndex = 6;
            this.lblEFactura.Text = "Se recibió factura";
            // 
            // lblRemision
            // 
            this.lblRemision.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblRemision.AutoSize = true;
            this.lblRemision.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRemision.Location = new System.Drawing.Point(713, 28);
            this.lblRemision.Name = "lblRemision";
            this.lblRemision.Size = new System.Drawing.Size(29, 19);
            this.lblRemision.TabIndex = 5;
            this.lblRemision.Text = "No";
            // 
            // lblERemision
            // 
            this.lblERemision.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblERemision.AutoSize = true;
            this.lblERemision.Location = new System.Drawing.Point(584, 9);
            this.lblERemision.Name = "lblERemision";
            this.lblERemision.Size = new System.Drawing.Size(123, 19);
            this.lblERemision.TabIndex = 4;
            this.lblERemision.Text = "Se recibió remisión";
            // 
            // lblTipoPago
            // 
            this.lblTipoPago.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTipoPago.AutoSize = true;
            this.lblTipoPago.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTipoPago.Location = new System.Drawing.Point(421, 28);
            this.lblTipoPago.Name = "lblTipoPago";
            this.lblTipoPago.Size = new System.Drawing.Size(62, 19);
            this.lblTipoPago.TabIndex = 3;
            this.lblTipoPago.Text = "Efectivo";
            // 
            // lblETipoPago
            // 
            this.lblETipoPago.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblETipoPago.AutoSize = true;
            this.lblETipoPago.Location = new System.Drawing.Point(331, 9);
            this.lblETipoPago.Name = "lblETipoPago";
            this.lblETipoPago.Size = new System.Drawing.Size(84, 19);
            this.lblETipoPago.TabIndex = 2;
            this.lblETipoPago.Text = "Se pago con";
            // 
            // lblFecha
            // 
            this.lblFecha.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFecha.Location = new System.Drawing.Point(62, 28);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(175, 19);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = "21 de diciembre de 2014";
            // 
            // lblEFecha
            // 
            this.lblEFecha.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEFecha.AutoSize = true;
            this.lblEFecha.Location = new System.Drawing.Point(12, 9);
            this.lblEFecha.Name = "lblEFecha";
            this.lblEFecha.Size = new System.Drawing.Size(44, 19);
            this.lblEFecha.TabIndex = 0;
            this.lblEFecha.Text = "Fecha";
            // 
            // dgvCompraDetallada
            // 
            this.dgvCompraDetallada.AllowUserToAddRows = false;
            this.dgvCompraDetallada.AllowUserToDeleteRows = false;
            this.dgvCompraDetallada.AllowUserToOrderColumns = true;
            this.dgvCompraDetallada.AllowUserToResizeColumns = false;
            this.dgvCompraDetallada.AllowUserToResizeRows = false;
            this.dgvCompraDetallada.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCompraDetallada.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCompraDetallada.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCompraDetallada.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvCompraDetallada.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCompraDetallada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompraDetallada.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CIDProd,
            this.CNombre,
            this.CCantidad,
            this.CCosto,
            this.CDescuento,
            this.CTotal});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCompraDetallada.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCompraDetallada.Location = new System.Drawing.Point(0, 115);
            this.dgvCompraDetallada.MultiSelect = false;
            this.dgvCompraDetallada.Name = "dgvCompraDetallada";
            this.dgvCompraDetallada.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCompraDetallada.RowHeadersVisible = false;
            this.dgvCompraDetallada.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCompraDetallada.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCompraDetallada.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompraDetallada.ShowEditingIcon = false;
            this.dgvCompraDetallada.Size = new System.Drawing.Size(1008, 506);
            this.dgvCompraDetallada.TabIndex = 2;
            // 
            // CIDProd
            // 
            this.CIDProd.HeaderText = "Código de producto";
            this.CIDProd.Name = "CIDProd";
            this.CIDProd.Width = 150;
            // 
            // CNombre
            // 
            this.CNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CNombre.HeaderText = "Nombre del producto";
            this.CNombre.Name = "CNombre";
            // 
            // CCantidad
            // 
            this.CCantidad.HeaderText = "Cantidad";
            this.CCantidad.Name = "CCantidad";
            this.CCantidad.Width = 130;
            // 
            // CCosto
            // 
            this.CCosto.HeaderText = "Costo";
            this.CCosto.Name = "CCosto";
            this.CCosto.Width = 130;
            // 
            // CDescuento
            // 
            this.CDescuento.HeaderText = "Descuento";
            this.CDescuento.Name = "CDescuento";
            this.CDescuento.Width = 130;
            // 
            // CTotal
            // 
            this.CTotal.HeaderText = "Total de producto";
            this.CTotal.Name = "CTotal";
            this.CTotal.Width = 130;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAceptar.Location = new System.Drawing.Point(921, 627);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmVisualizarCompra
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1008, 662);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dgvCompraDetallada);
            this.Controls.Add(this.pnlCompra);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1024, 500);
            this.Name = "frmVisualizarCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compra";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVisualizarCompra_Load);
            this.pnlCompra.ResumeLayout(false);
            this.pnlCompra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompraDetallada)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCompra;
        private System.Windows.Forms.Label lblEFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblRemision;
        private System.Windows.Forms.Label lblERemision;
        private System.Windows.Forms.Label lblTipoPago;
        private System.Windows.Forms.Label lblETipoPago;
        private System.Windows.Forms.Label lblFactura;
        private System.Windows.Forms.Label lblEFactura;
        private System.Windows.Forms.Label lblFolioRemision;
        private System.Windows.Forms.Label lblEFolioRemision;
        private System.Windows.Forms.Label lblFolioFactura;
        private System.Windows.Forms.Label lblEFolioFactura;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblESubtotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblETotal;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Label lblEDescuento;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.Label lblEImporte;
        private System.Windows.Forms.DataGridView dgvCompraDetallada;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIDProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTotal;
        private System.Windows.Forms.Button btnAceptar;
    }
}