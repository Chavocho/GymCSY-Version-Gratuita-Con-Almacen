namespace GYM.Formularios.Reportes
{
    partial class frmVisualizarVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisualizarVenta));
            this.btnAceptar = new System.Windows.Forms.Button();
            this.dgvCompraDetallada = new System.Windows.Forms.DataGridView();
            this.CIDProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlCompra = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblETotal = new System.Windows.Forms.Label();
            this.lblFactura = new System.Windows.Forms.Label();
            this.lblEFactura = new System.Windows.Forms.Label();
            this.lblRemision = new System.Windows.Forms.Label();
            this.lblERemision = new System.Windows.Forms.Label();
            this.lblTipoPago = new System.Windows.Forms.Label();
            this.lblETipoPago = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblEFecha = new System.Windows.Forms.Label();
            this.lblECreateUser = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblEUpdateUser = new System.Windows.Forms.Label();
            this.lblUpdateUser = new System.Windows.Forms.Label();
            this.lblEDescuento = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompraDetallada)).BeginInit();
            this.pnlCompra.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAceptar.Location = new System.Drawing.Point(921, 427);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
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
            this.dgvCompraDetallada.Location = new System.Drawing.Point(0, 115);
            this.dgvCompraDetallada.MultiSelect = false;
            this.dgvCompraDetallada.Name = "dgvCompraDetallada";
            this.dgvCompraDetallada.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCompraDetallada.RowHeadersVisible = false;
            this.dgvCompraDetallada.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCompraDetallada.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCompraDetallada.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompraDetallada.ShowEditingIcon = false;
            this.dgvCompraDetallada.Size = new System.Drawing.Size(1008, 306);
            this.dgvCompraDetallada.TabIndex = 5;
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
            // pnlCompra
            // 
            this.pnlCompra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCompra.Controls.Add(this.lblTotal);
            this.pnlCompra.Controls.Add(this.lblETotal);
            this.pnlCompra.Controls.Add(this.lblDescuento);
            this.pnlCompra.Controls.Add(this.lblEDescuento);
            this.pnlCompra.Controls.Add(this.lblUpdateUser);
            this.pnlCompra.Controls.Add(this.lblEUpdateUser);
            this.pnlCompra.Controls.Add(this.lblSubtotal);
            this.pnlCompra.Controls.Add(this.lblECreateUser);
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
            this.pnlCompra.TabIndex = 4;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(886, 28);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(69, 19);
            this.lblTotal.TabIndex = 19;
            this.lblTotal.Text = "$1350.50";
            // 
            // lblETotal
            // 
            this.lblETotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblETotal.AutoSize = true;
            this.lblETotal.Location = new System.Drawing.Point(841, 9);
            this.lblETotal.Name = "lblETotal";
            this.lblETotal.Size = new System.Drawing.Size(39, 19);
            this.lblETotal.TabIndex = 18;
            this.lblETotal.Text = "Total";
            // 
            // lblFactura
            // 
            this.lblFactura.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFactura.AutoSize = true;
            this.lblFactura.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFactura.Location = new System.Drawing.Point(760, 28);
            this.lblFactura.Name = "lblFactura";
            this.lblFactura.Size = new System.Drawing.Size(41, 19);
            this.lblFactura.TabIndex = 7;
            this.lblFactura.Text = "1233";
            // 
            // lblEFactura
            // 
            this.lblEFactura.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEFactura.AutoSize = true;
            this.lblEFactura.Location = new System.Drawing.Point(609, 9);
            this.lblEFactura.Name = "lblEFactura";
            this.lblEFactura.Size = new System.Drawing.Size(145, 19);
            this.lblEFactura.TabIndex = 6;
            this.lblEFactura.Text = "Terminación de tarjeta";
            // 
            // lblRemision
            // 
            this.lblRemision.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblRemision.AutoSize = true;
            this.lblRemision.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRemision.Location = new System.Drawing.Point(518, 28);
            this.lblRemision.Name = "lblRemision";
            this.lblRemision.Size = new System.Drawing.Size(73, 19);
            this.lblRemision.TabIndex = 5;
            this.lblRemision.Text = "36259323";
            // 
            // lblERemision
            // 
            this.lblERemision.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblERemision.AutoSize = true;
            this.lblERemision.Location = new System.Drawing.Point(418, 9);
            this.lblERemision.Name = "lblERemision";
            this.lblERemision.Size = new System.Drawing.Size(94, 19);
            this.lblERemision.TabIndex = 4;
            this.lblERemision.Text = "Folio de ticket";
            // 
            // lblTipoPago
            // 
            this.lblTipoPago.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTipoPago.AutoSize = true;
            this.lblTipoPago.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTipoPago.Location = new System.Drawing.Point(343, 28);
            this.lblTipoPago.Name = "lblTipoPago";
            this.lblTipoPago.Size = new System.Drawing.Size(62, 19);
            this.lblTipoPago.TabIndex = 3;
            this.lblTipoPago.Text = "Efectivo";
            // 
            // lblETipoPago
            // 
            this.lblETipoPago.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblETipoPago.AutoSize = true;
            this.lblETipoPago.Location = new System.Drawing.Point(253, 9);
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
            this.lblFecha.Size = new System.Drawing.Size(179, 19);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = "21 de diciembre del 2014";
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
            // lblECreateUser
            // 
            this.lblECreateUser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblECreateUser.AutoSize = true;
            this.lblECreateUser.Location = new System.Drawing.Point(12, 65);
            this.lblECreateUser.Name = "lblECreateUser";
            this.lblECreateUser.Size = new System.Drawing.Size(106, 19);
            this.lblECreateUser.TabIndex = 12;
            this.lblECreateUser.Text = "Usuario creador";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSubtotal.Location = new System.Drawing.Point(124, 84);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(50, 19);
            this.lblSubtotal.TabIndex = 13;
            this.lblSubtotal.Text = "MARY";
            // 
            // lblEUpdateUser
            // 
            this.lblEUpdateUser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEUpdateUser.AutoSize = true;
            this.lblEUpdateUser.Location = new System.Drawing.Point(253, 65);
            this.lblEUpdateUser.Name = "lblEUpdateUser";
            this.lblEUpdateUser.Size = new System.Drawing.Size(132, 19);
            this.lblEUpdateUser.TabIndex = 14;
            this.lblEUpdateUser.Text = "Usuario modificador";
            // 
            // lblUpdateUser
            // 
            this.lblUpdateUser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblUpdateUser.AutoSize = true;
            this.lblUpdateUser.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUpdateUser.Location = new System.Drawing.Point(391, 84);
            this.lblUpdateUser.Name = "lblUpdateUser";
            this.lblUpdateUser.Size = new System.Drawing.Size(51, 19);
            this.lblUpdateUser.TabIndex = 15;
            this.lblUpdateUser.Text = "admin";
            // 
            // lblEDescuento
            // 
            this.lblEDescuento.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEDescuento.AutoSize = true;
            this.lblEDescuento.Location = new System.Drawing.Point(489, 65);
            this.lblEDescuento.Name = "lblEDescuento";
            this.lblEDescuento.Size = new System.Drawing.Size(124, 19);
            this.lblEDescuento.TabIndex = 16;
            this.lblEDescuento.Text = "Fecha modificación";
            // 
            // lblDescuento
            // 
            this.lblDescuento.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDescuento.Location = new System.Drawing.Point(622, 84);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(179, 19);
            this.lblDescuento.TabIndex = 17;
            this.lblDescuento.Text = "23 de diciembre del 2014";
            // 
            // frmVisualizarVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 462);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dgvCompraDetallada);
            this.Controls.Add(this.pnlCompra);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVisualizarVenta";
            this.Text = "Venta";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompraDetallada)).EndInit();
            this.pnlCompra.ResumeLayout(false);
            this.pnlCompra.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridView dgvCompraDetallada;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIDProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTotal;
        private System.Windows.Forms.Panel pnlCompra;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblETotal;
        private System.Windows.Forms.Label lblFactura;
        private System.Windows.Forms.Label lblEFactura;
        private System.Windows.Forms.Label lblRemision;
        private System.Windows.Forms.Label lblERemision;
        private System.Windows.Forms.Label lblTipoPago;
        private System.Windows.Forms.Label lblETipoPago;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblEFecha;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Label lblEDescuento;
        private System.Windows.Forms.Label lblUpdateUser;
        private System.Windows.Forms.Label lblEUpdateUser;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblECreateUser;
    }
}