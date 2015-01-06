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
            this.dgvVentaDetallada = new System.Windows.Forms.DataGridView();
            this.CIDProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlVenta = new System.Windows.Forms.Panel();
            this.lblRemision = new System.Windows.Forms.Label();
            this.lblERemision = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblETotal = new System.Windows.Forms.Label();
            this.lblUpdateTime = new System.Windows.Forms.Label();
            this.lblEUpdateTime = new System.Windows.Forms.Label();
            this.lblUpdateUser = new System.Windows.Forms.Label();
            this.lblEUpdateUser = new System.Windows.Forms.Label();
            this.lblCreateUser = new System.Windows.Forms.Label();
            this.lblECreateUser = new System.Windows.Forms.Label();
            this.lblTerminacion = new System.Windows.Forms.Label();
            this.lblETerminacion = new System.Windows.Forms.Label();
            this.lblFolioTicket = new System.Windows.Forms.Label();
            this.lblEFolioTicket = new System.Windows.Forms.Label();
            this.lblTipoPago = new System.Windows.Forms.Label();
            this.lblETipoPago = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblEFecha = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentaDetallada)).BeginInit();
            this.pnlVenta.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAceptar.Location = new System.Drawing.Point(921, 427);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // dgvVentaDetallada
            // 
            this.dgvVentaDetallada.AllowUserToAddRows = false;
            this.dgvVentaDetallada.AllowUserToDeleteRows = false;
            this.dgvVentaDetallada.AllowUserToOrderColumns = true;
            this.dgvVentaDetallada.AllowUserToResizeColumns = false;
            this.dgvVentaDetallada.AllowUserToResizeRows = false;
            this.dgvVentaDetallada.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVentaDetallada.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvVentaDetallada.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVentaDetallada.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvVentaDetallada.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvVentaDetallada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentaDetallada.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CIDProd,
            this.CNombre,
            this.CCantidad,
            this.CPrecio,
            this.CTotal});
            this.dgvVentaDetallada.Location = new System.Drawing.Point(0, 115);
            this.dgvVentaDetallada.MultiSelect = false;
            this.dgvVentaDetallada.Name = "dgvVentaDetallada";
            this.dgvVentaDetallada.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvVentaDetallada.RowHeadersVisible = false;
            this.dgvVentaDetallada.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvVentaDetallada.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVentaDetallada.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVentaDetallada.ShowEditingIcon = false;
            this.dgvVentaDetallada.Size = new System.Drawing.Size(1008, 306);
            this.dgvVentaDetallada.TabIndex = 1;
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
            // CPrecio
            // 
            this.CPrecio.HeaderText = "Precio";
            this.CPrecio.Name = "CPrecio";
            this.CPrecio.Width = 130;
            // 
            // CTotal
            // 
            this.CTotal.HeaderText = "Total de producto";
            this.CTotal.Name = "CTotal";
            this.CTotal.Width = 130;
            // 
            // pnlVenta
            // 
            this.pnlVenta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlVenta.Controls.Add(this.lblRemision);
            this.pnlVenta.Controls.Add(this.lblERemision);
            this.pnlVenta.Controls.Add(this.lblTotal);
            this.pnlVenta.Controls.Add(this.lblETotal);
            this.pnlVenta.Controls.Add(this.lblUpdateTime);
            this.pnlVenta.Controls.Add(this.lblEUpdateTime);
            this.pnlVenta.Controls.Add(this.lblUpdateUser);
            this.pnlVenta.Controls.Add(this.lblEUpdateUser);
            this.pnlVenta.Controls.Add(this.lblCreateUser);
            this.pnlVenta.Controls.Add(this.lblECreateUser);
            this.pnlVenta.Controls.Add(this.lblTerminacion);
            this.pnlVenta.Controls.Add(this.lblETerminacion);
            this.pnlVenta.Controls.Add(this.lblFolioTicket);
            this.pnlVenta.Controls.Add(this.lblEFolioTicket);
            this.pnlVenta.Controls.Add(this.lblTipoPago);
            this.pnlVenta.Controls.Add(this.lblETipoPago);
            this.pnlVenta.Controls.Add(this.lblFecha);
            this.pnlVenta.Controls.Add(this.lblEFecha);
            this.pnlVenta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.pnlVenta.Location = new System.Drawing.Point(0, 0);
            this.pnlVenta.Name = "pnlVenta";
            this.pnlVenta.Size = new System.Drawing.Size(1008, 115);
            this.pnlVenta.TabIndex = 0;
            // 
            // lblRemision
            // 
            this.lblRemision.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblRemision.AutoSize = true;
            this.lblRemision.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRemision.Location = new System.Drawing.Point(496, 28);
            this.lblRemision.Name = "lblRemision";
            this.lblRemision.Size = new System.Drawing.Size(0, 19);
            this.lblRemision.TabIndex = 5;
            // 
            // lblERemision
            // 
            this.lblERemision.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblERemision.AutoSize = true;
            this.lblERemision.Location = new System.Drawing.Point(396, 9);
            this.lblERemision.Name = "lblERemision";
            this.lblERemision.Size = new System.Drawing.Size(94, 19);
            this.lblERemision.TabIndex = 4;
            this.lblERemision.Text = "Folio remisión";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(877, 84);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 19);
            this.lblTotal.TabIndex = 17;
            // 
            // lblETotal
            // 
            this.lblETotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblETotal.AutoSize = true;
            this.lblETotal.Location = new System.Drawing.Point(832, 65);
            this.lblETotal.Name = "lblETotal";
            this.lblETotal.Size = new System.Drawing.Size(39, 19);
            this.lblETotal.TabIndex = 16;
            this.lblETotal.Text = "Total";
            // 
            // lblUpdateTime
            // 
            this.lblUpdateTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblUpdateTime.AutoSize = true;
            this.lblUpdateTime.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUpdateTime.Location = new System.Drawing.Point(622, 84);
            this.lblUpdateTime.Name = "lblUpdateTime";
            this.lblUpdateTime.Size = new System.Drawing.Size(0, 19);
            this.lblUpdateTime.TabIndex = 15;
            // 
            // lblEUpdateTime
            // 
            this.lblEUpdateTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEUpdateTime.AutoSize = true;
            this.lblEUpdateTime.Location = new System.Drawing.Point(489, 65);
            this.lblEUpdateTime.Name = "lblEUpdateTime";
            this.lblEUpdateTime.Size = new System.Drawing.Size(124, 19);
            this.lblEUpdateTime.TabIndex = 14;
            this.lblEUpdateTime.Text = "Fecha modificación";
            // 
            // lblUpdateUser
            // 
            this.lblUpdateUser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblUpdateUser.AutoSize = true;
            this.lblUpdateUser.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUpdateUser.Location = new System.Drawing.Point(359, 84);
            this.lblUpdateUser.Name = "lblUpdateUser";
            this.lblUpdateUser.Size = new System.Drawing.Size(0, 19);
            this.lblUpdateUser.TabIndex = 13;
            // 
            // lblEUpdateUser
            // 
            this.lblEUpdateUser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEUpdateUser.AutoSize = true;
            this.lblEUpdateUser.Location = new System.Drawing.Point(253, 65);
            this.lblEUpdateUser.Name = "lblEUpdateUser";
            this.lblEUpdateUser.Size = new System.Drawing.Size(100, 19);
            this.lblEUpdateUser.TabIndex = 12;
            this.lblEUpdateUser.Text = "Modificó venta";
            // 
            // lblCreateUser
            // 
            this.lblCreateUser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCreateUser.AutoSize = true;
            this.lblCreateUser.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCreateUser.Location = new System.Drawing.Point(70, 84);
            this.lblCreateUser.Name = "lblCreateUser";
            this.lblCreateUser.Size = new System.Drawing.Size(0, 19);
            this.lblCreateUser.TabIndex = 11;
            // 
            // lblECreateUser
            // 
            this.lblECreateUser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblECreateUser.AutoSize = true;
            this.lblECreateUser.Location = new System.Drawing.Point(12, 65);
            this.lblECreateUser.Name = "lblECreateUser";
            this.lblECreateUser.Size = new System.Drawing.Size(52, 19);
            this.lblECreateUser.TabIndex = 10;
            this.lblECreateUser.Text = "Vendió";
            // 
            // lblTerminacion
            // 
            this.lblTerminacion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTerminacion.AutoSize = true;
            this.lblTerminacion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTerminacion.Location = new System.Drawing.Point(952, 28);
            this.lblTerminacion.Name = "lblTerminacion";
            this.lblTerminacion.Size = new System.Drawing.Size(0, 19);
            this.lblTerminacion.TabIndex = 9;
            // 
            // lblETerminacion
            // 
            this.lblETerminacion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblETerminacion.AutoSize = true;
            this.lblETerminacion.Location = new System.Drawing.Point(801, 9);
            this.lblETerminacion.Name = "lblETerminacion";
            this.lblETerminacion.Size = new System.Drawing.Size(145, 19);
            this.lblETerminacion.TabIndex = 8;
            this.lblETerminacion.Text = "Terminación de tarjeta";
            // 
            // lblFolioTicket
            // 
            this.lblFolioTicket.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFolioTicket.AutoSize = true;
            this.lblFolioTicket.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFolioTicket.Location = new System.Drawing.Point(710, 28);
            this.lblFolioTicket.Name = "lblFolioTicket";
            this.lblFolioTicket.Size = new System.Drawing.Size(0, 19);
            this.lblFolioTicket.TabIndex = 7;
            // 
            // lblEFolioTicket
            // 
            this.lblEFolioTicket.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEFolioTicket.AutoSize = true;
            this.lblEFolioTicket.Location = new System.Drawing.Point(585, 9);
            this.lblEFolioTicket.Name = "lblEFolioTicket";
            this.lblEFolioTicket.Size = new System.Drawing.Size(129, 19);
            this.lblEFolioTicket.TabIndex = 6;
            this.lblEFolioTicket.Text = "Folio ticket terminal";
            // 
            // lblTipoPago
            // 
            this.lblTipoPago.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTipoPago.AutoSize = true;
            this.lblTipoPago.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTipoPago.Location = new System.Drawing.Point(328, 28);
            this.lblTipoPago.Name = "lblTipoPago";
            this.lblTipoPago.Size = new System.Drawing.Size(0, 19);
            this.lblTipoPago.TabIndex = 3;
            // 
            // lblETipoPago
            // 
            this.lblETipoPago.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblETipoPago.AutoSize = true;
            this.lblETipoPago.Location = new System.Drawing.Point(238, 9);
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
            this.lblFecha.Size = new System.Drawing.Size(0, 19);
            this.lblFecha.TabIndex = 1;
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
            // frmVisualizarVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 462);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dgvVentaDetallada);
            this.Controls.Add(this.pnlVenta);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVisualizarVenta";
            this.Text = "Venta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVisualizarVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentaDetallada)).EndInit();
            this.pnlVenta.ResumeLayout(false);
            this.pnlVenta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridView dgvVentaDetallada;
        private System.Windows.Forms.Panel pnlVenta;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblETotal;
        private System.Windows.Forms.Label lblTerminacion;
        private System.Windows.Forms.Label lblETerminacion;
        private System.Windows.Forms.Label lblFolioTicket;
        private System.Windows.Forms.Label lblEFolioTicket;
        private System.Windows.Forms.Label lblTipoPago;
        private System.Windows.Forms.Label lblETipoPago;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblEFecha;
        private System.Windows.Forms.Label lblUpdateTime;
        private System.Windows.Forms.Label lblEUpdateTime;
        private System.Windows.Forms.Label lblUpdateUser;
        private System.Windows.Forms.Label lblEUpdateUser;
        private System.Windows.Forms.Label lblCreateUser;
        private System.Windows.Forms.Label lblECreateUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIDProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTotal;
        private System.Windows.Forms.Label lblRemision;
        private System.Windows.Forms.Label lblERemision;
    }
}