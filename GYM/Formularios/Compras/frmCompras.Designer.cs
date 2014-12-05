namespace GYM.Formularios.Compras
{
    partial class frmCompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompras));
            this.dgvCompras = new System.Windows.Forms.DataGridView();
            this.CFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTipoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDetallado = new System.Windows.Forms.Button();
            this.btnNuevaCompra = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCompras
            // 
            this.dgvCompras.AllowUserToAddRows = false;
            this.dgvCompras.AllowUserToDeleteRows = false;
            this.dgvCompras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCompras.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.dgvCompras.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCompras.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvCompras.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CFecha,
            this.CUsuario,
            this.CTipoPago,
            this.CTotal});
            this.dgvCompras.Location = new System.Drawing.Point(141, 37);
            this.dgvCompras.Name = "dgvCompras";
            this.dgvCompras.ReadOnly = true;
            this.dgvCompras.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCompras.RowHeadersVisible = false;
            this.dgvCompras.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCompras.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompras.Size = new System.Drawing.Size(720, 273);
            this.dgvCompras.TabIndex = 6;
            // 
            // CFecha
            // 
            this.CFecha.HeaderText = "Fecha de compra";
            this.CFecha.Name = "CFecha";
            this.CFecha.ReadOnly = true;
            this.CFecha.Width = 230;
            // 
            // CUsuario
            // 
            this.CUsuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CUsuario.HeaderText = "Usuario";
            this.CUsuario.Name = "CUsuario";
            this.CUsuario.ReadOnly = true;
            // 
            // CTipoPago
            // 
            this.CTipoPago.HeaderText = "Tipo de pago";
            this.CTipoPago.Name = "CTipoPago";
            this.CTipoPago.ReadOnly = true;
            this.CTipoPago.Width = 120;
            // 
            // CTotal
            // 
            this.CTotal.HeaderText = "Total de compra";
            this.CTotal.Name = "CTotal";
            this.CTotal.ReadOnly = true;
            this.CTotal.Width = 120;
            // 
            // btnDetallado
            // 
            this.btnDetallado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDetallado.Image = global::GYM.Properties.Resources.ImgBuscar;
            this.btnDetallado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetallado.Location = new System.Drawing.Point(12, 82);
            this.btnDetallado.Name = "btnDetallado";
            this.btnDetallado.Size = new System.Drawing.Size(123, 39);
            this.btnDetallado.TabIndex = 8;
            this.btnDetallado.Text = "Detallado de\r\ncompra";
            this.btnDetallado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetallado.UseVisualStyleBackColor = true;
            // 
            // btnNuevaCompra
            // 
            this.btnNuevaCompra.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNuevaCompra.Image = global::GYM.Properties.Resources.ImgNuevaVenta;
            this.btnNuevaCompra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevaCompra.Location = new System.Drawing.Point(12, 37);
            this.btnNuevaCompra.Name = "btnNuevaCompra";
            this.btnNuevaCompra.Size = new System.Drawing.Size(123, 39);
            this.btnNuevaCompra.TabIndex = 7;
            this.btnNuevaCompra.Text = "Nueva compra";
            this.btnNuevaCompra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevaCompra.UseVisualStyleBackColor = true;
            // 
            // frmCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 322);
            this.Controls.Add(this.btnDetallado);
            this.Controls.Add(this.btnNuevaCompra);
            this.Controls.Add(this.dgvCompras);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compras";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCompras;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTipoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTotal;
        private System.Windows.Forms.Button btnNuevaCompra;
        private System.Windows.Forms.Button btnDetallado;
    }
}