﻿namespace GYM.Formularios.POS
{
    partial class frmCobrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCobrar));
            this.lblEtiquetaEfectivo = new System.Windows.Forms.Label();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.txtTarjeta = new System.Windows.Forms.TextBox();
            this.lblEtiquetaTarjeta = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblEtiquetaTotal = new System.Windows.Forms.Label();
            this.lblEtiquetaCambio = new System.Windows.Forms.Label();
            this.lblCambio = new System.Windows.Forms.Label();
            this.lblEtiquetaFolio = new System.Windows.Forms.Label();
            this.lblFolio = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblEtiquetaCantidad = new System.Windows.Forms.Label();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.chbTarjeta = new System.Windows.Forms.CheckBox();
            this.lblFolioTicket = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblEtiquetaEfectivo
            // 
            this.lblEtiquetaEfectivo.AutoSize = true;
            this.lblEtiquetaEfectivo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEtiquetaEfectivo.Location = new System.Drawing.Point(200, 67);
            this.lblEtiquetaEfectivo.Name = "lblEtiquetaEfectivo";
            this.lblEtiquetaEfectivo.Size = new System.Drawing.Size(67, 21);
            this.lblEtiquetaEfectivo.TabIndex = 24;
            this.lblEtiquetaEfectivo.Text = "Efectivo:";
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtEfectivo.Location = new System.Drawing.Point(273, 64);
            this.txtEfectivo.MaxLength = 6;
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new System.Drawing.Size(116, 29);
            this.txtEfectivo.TabIndex = 1;
            this.txtEfectivo.TextChanged += new System.EventHandler(this.txtEfectivo_TextChanged);
            this.txtEfectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDinero_KeyPress);
            // 
            // txtTarjeta
            // 
            this.txtTarjeta.Enabled = false;
            this.txtTarjeta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTarjeta.Location = new System.Drawing.Point(274, 108);
            this.txtTarjeta.Name = "txtTarjeta";
            this.txtTarjeta.Size = new System.Drawing.Size(116, 29);
            this.txtTarjeta.TabIndex = 3;
            this.txtTarjeta.TextChanged += new System.EventHandler(this.txtTarjeta_TextChanged);
            this.txtTarjeta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDinero_KeyPress);
            // 
            // lblEtiquetaTarjeta
            // 
            this.lblEtiquetaTarjeta.AutoSize = true;
            this.lblEtiquetaTarjeta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEtiquetaTarjeta.Location = new System.Drawing.Point(208, 111);
            this.lblEtiquetaTarjeta.Name = "lblEtiquetaTarjeta";
            this.lblEtiquetaTarjeta.Size = new System.Drawing.Size(60, 21);
            this.lblEtiquetaTarjeta.TabIndex = 26;
            this.lblEtiquetaTarjeta.Text = "Tarjeta:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotal.Location = new System.Drawing.Point(277, 23);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(49, 21);
            this.lblTotal.TabIndex = 22;
            this.lblTotal.Text = "$0.00";
            // 
            // lblEtiquetaTotal
            // 
            this.lblEtiquetaTotal.AutoSize = true;
            this.lblEtiquetaTotal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEtiquetaTotal.Location = new System.Drawing.Point(224, 23);
            this.lblEtiquetaTotal.Name = "lblEtiquetaTotal";
            this.lblEtiquetaTotal.Size = new System.Drawing.Size(47, 21);
            this.lblEtiquetaTotal.TabIndex = 23;
            this.lblEtiquetaTotal.Text = "Total:";
            // 
            // lblEtiquetaCambio
            // 
            this.lblEtiquetaCambio.AutoSize = true;
            this.lblEtiquetaCambio.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEtiquetaCambio.Location = new System.Drawing.Point(200, 155);
            this.lblEtiquetaCambio.Name = "lblEtiquetaCambio";
            this.lblEtiquetaCambio.Size = new System.Drawing.Size(67, 21);
            this.lblEtiquetaCambio.TabIndex = 29;
            this.lblEtiquetaCambio.Text = "Cambio:";
            // 
            // lblCambio
            // 
            this.lblCambio.AutoSize = true;
            this.lblCambio.BackColor = System.Drawing.Color.Red;
            this.lblCambio.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCambio.ForeColor = System.Drawing.Color.White;
            this.lblCambio.Location = new System.Drawing.Point(273, 155);
            this.lblCambio.Name = "lblCambio";
            this.lblCambio.Size = new System.Drawing.Size(49, 21);
            this.lblCambio.TabIndex = 2;
            this.lblCambio.Text = "$0.00";
            // 
            // lblEtiquetaFolio
            // 
            this.lblEtiquetaFolio.AutoSize = true;
            this.lblEtiquetaFolio.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEtiquetaFolio.Location = new System.Drawing.Point(7, 23);
            this.lblEtiquetaFolio.Name = "lblEtiquetaFolio";
            this.lblEtiquetaFolio.Size = new System.Drawing.Size(47, 21);
            this.lblEtiquetaFolio.TabIndex = 30;
            this.lblEtiquetaFolio.Text = "Folio:";
            // 
            // lblFolio
            // 
            this.lblFolio.AutoSize = true;
            this.lblFolio.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFolio.Location = new System.Drawing.Point(7, 54);
            this.lblFolio.Name = "lblFolio";
            this.lblFolio.Size = new System.Drawing.Size(82, 21);
            this.lblFolio.TabIndex = 31;
            this.lblFolio.Text = "00000000";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCantidad.Location = new System.Drawing.Point(7, 129);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(19, 21);
            this.lblCantidad.TabIndex = 33;
            this.lblCantidad.Text = "0";
            // 
            // lblEtiquetaCantidad
            // 
            this.lblEtiquetaCantidad.AutoSize = true;
            this.lblEtiquetaCantidad.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEtiquetaCantidad.Location = new System.Drawing.Point(7, 98);
            this.lblEtiquetaCantidad.Name = "lblEtiquetaCantidad";
            this.lblEtiquetaCantidad.Size = new System.Drawing.Size(149, 21);
            this.lblEtiquetaCantidad.TabIndex = 32;
            this.lblEtiquetaCantidad.Text = "Productos Vendidos";
            // 
            // btnCobrar
            // 
            this.btnCobrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCobrar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnCobrar.FlatAppearance.BorderSize = 2;
            this.btnCobrar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCobrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnCobrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCobrar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCobrar.Image = global::GYM.Properties.Resources.ImgAceptar;
            this.btnCobrar.Location = new System.Drawing.Point(316, 282);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(97, 32);
            this.btnCobrar.TabIndex = 4;
            this.btnCobrar.Text = "Aceptar";
            this.btnCobrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCobrar.UseVisualStyleBackColor = true;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // chbTarjeta
            // 
            this.chbTarjeta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbTarjeta.AutoSize = true;
            this.chbTarjeta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chbTarjeta.Location = new System.Drawing.Point(12, 289);
            this.chbTarjeta.Name = "chbTarjeta";
            this.chbTarjeta.Size = new System.Drawing.Size(146, 25);
            this.chbTarjeta.TabIndex = 0;
            this.chbTarjeta.Text = "Pagar con tarjeta";
            this.chbTarjeta.UseVisualStyleBackColor = true;
            this.chbTarjeta.CheckedChanged += new System.EventHandler(this.chbTarjeta_CheckedChanged);
            // 
            // lblFolioTicket
            // 
            this.lblFolioTicket.AutoSize = true;
            this.lblFolioTicket.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFolioTicket.Location = new System.Drawing.Point(9, 206);
            this.lblFolioTicket.Name = "lblFolioTicket";
            this.lblFolioTicket.Size = new System.Drawing.Size(81, 15);
            this.lblFolioTicket.TabIndex = 34;
            this.lblFolioTicket.Text = "Folio de ticket";
            this.lblFolioTicket.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBox1.Location = new System.Drawing.Point(12, 224);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(197, 25);
            this.textBox1.TabIndex = 35;
            this.textBox1.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBox2.Location = new System.Drawing.Point(215, 224);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(198, 25);
            this.textBox2.TabIndex = 37;
            this.textBox2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(212, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 36;
            this.label1.Text = "Terminación";
            this.label1.Visible = false;
            // 
            // frmCobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 326);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblFolioTicket);
            this.Controls.Add(this.chbTarjeta);
            this.Controls.Add(this.btnCobrar);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblEtiquetaCantidad);
            this.Controls.Add(this.lblFolio);
            this.Controls.Add(this.lblEtiquetaFolio);
            this.Controls.Add(this.lblEtiquetaCambio);
            this.Controls.Add(this.lblCambio);
            this.Controls.Add(this.txtTarjeta);
            this.Controls.Add(this.lblEtiquetaTarjeta);
            this.Controls.Add(this.txtEfectivo);
            this.Controls.Add(this.lblEtiquetaEfectivo);
            this.Controls.Add(this.lblEtiquetaTotal);
            this.Controls.Add(this.lblTotal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCobrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cobrar Venta";
            this.Load += new System.EventHandler(this.frmCobrar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEtiquetaEfectivo;
        private System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.TextBox txtTarjeta;
        private System.Windows.Forms.Label lblEtiquetaTarjeta;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblEtiquetaTotal;
        private System.Windows.Forms.Label lblEtiquetaCambio;
        private System.Windows.Forms.Label lblCambio;
        private System.Windows.Forms.Label lblEtiquetaFolio;
        private System.Windows.Forms.Label lblFolio;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblEtiquetaCantidad;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.CheckBox chbTarjeta;
        private System.Windows.Forms.Label lblFolioTicket;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
    }
}