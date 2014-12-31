namespace GYM.Formularios.Caja
{
    partial class frmCerrarCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCerrarCaja));
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.lblEtiquetaEfectivoTotal = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblEtiquetaEfectivoDejar = new System.Windows.Forms.Label();
            this.lblAtiende = new System.Windows.Forms.Label();
            this.lblEtiquetaAtiende = new System.Windows.Forms.Label();
            this.lblEfectivoCaja = new System.Windows.Forms.Label();
            this.lblEtiquetaEfectivoCaja = new System.Windows.Forms.Label();
            this.lblVouchers = new System.Windows.Forms.Label();
            this.lblEtiquetaVouchers = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtEfectivo.Location = new System.Drawing.Point(177, 149);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new System.Drawing.Size(170, 31);
            this.txtEfectivo.TabIndex = 0;
            this.txtEfectivo.TextChanged += new System.EventHandler(this.txtEfectivo_TextChanged);
            this.txtEfectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEfectivo_KeyPress);
            // 
            // lblEtiquetaEfectivoTotal
            // 
            this.lblEtiquetaEfectivoTotal.AutoSize = true;
            this.lblEtiquetaEfectivoTotal.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.lblEtiquetaEfectivoTotal.Location = new System.Drawing.Point(12, 197);
            this.lblEtiquetaEfectivoTotal.Name = "lblEtiquetaEfectivoTotal";
            this.lblEtiquetaEfectivoTotal.Size = new System.Drawing.Size(131, 28);
            this.lblEtiquetaEfectivoTotal.TabIndex = 14;
            this.lblEtiquetaEfectivoTotal.Text = "Efectivo total:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.Lime;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(177, 197);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(60, 28);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "$0.00";
            // 
            // lblEtiquetaEfectivoDejar
            // 
            this.lblEtiquetaEfectivoDejar.AutoSize = true;
            this.lblEtiquetaEfectivoDejar.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.lblEtiquetaEfectivoDejar.Location = new System.Drawing.Point(12, 147);
            this.lblEtiquetaEfectivoDejar.Name = "lblEtiquetaEfectivoDejar";
            this.lblEtiquetaEfectivoDejar.Size = new System.Drawing.Size(158, 28);
            this.lblEtiquetaEfectivoDejar.TabIndex = 12;
            this.lblEtiquetaEfectivoDejar.Text = "Efectivo a retirar:";
            // 
            // lblAtiende
            // 
            this.lblAtiende.AutoSize = true;
            this.lblAtiende.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblAtiende.Location = new System.Drawing.Point(82, 9);
            this.lblAtiende.Name = "lblAtiende";
            this.lblAtiende.Size = new System.Drawing.Size(60, 20);
            this.lblAtiende.TabIndex = 11;
            this.lblAtiende.Text = "Alguien";
            // 
            // lblEtiquetaAtiende
            // 
            this.lblEtiquetaAtiende.AutoSize = true;
            this.lblEtiquetaAtiende.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblEtiquetaAtiende.Location = new System.Drawing.Point(12, 9);
            this.lblEtiquetaAtiende.Name = "lblEtiquetaAtiende";
            this.lblEtiquetaAtiende.Size = new System.Drawing.Size(64, 20);
            this.lblEtiquetaAtiende.TabIndex = 10;
            this.lblEtiquetaAtiende.Text = "Atiende:";
            // 
            // lblEfectivoCaja
            // 
            this.lblEfectivoCaja.AutoSize = true;
            this.lblEfectivoCaja.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.lblEfectivoCaja.Location = new System.Drawing.Point(177, 47);
            this.lblEfectivoCaja.Name = "lblEfectivoCaja";
            this.lblEfectivoCaja.Size = new System.Drawing.Size(60, 28);
            this.lblEfectivoCaja.TabIndex = 9;
            this.lblEfectivoCaja.Text = "$0.00";
            // 
            // lblEtiquetaEfectivoCaja
            // 
            this.lblEtiquetaEfectivoCaja.AutoSize = true;
            this.lblEtiquetaEfectivoCaja.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.lblEtiquetaEfectivoCaja.Location = new System.Drawing.Point(12, 47);
            this.lblEtiquetaEfectivoCaja.Name = "lblEtiquetaEfectivoCaja";
            this.lblEtiquetaEfectivoCaja.Size = new System.Drawing.Size(150, 28);
            this.lblEtiquetaEfectivoCaja.TabIndex = 8;
            this.lblEtiquetaEfectivoCaja.Text = "Efectivo en caja:";
            // 
            // lblVouchers
            // 
            this.lblVouchers.AutoSize = true;
            this.lblVouchers.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.lblVouchers.Location = new System.Drawing.Point(177, 97);
            this.lblVouchers.Name = "lblVouchers";
            this.lblVouchers.Size = new System.Drawing.Size(60, 28);
            this.lblVouchers.TabIndex = 17;
            this.lblVouchers.Text = "$0.00";
            // 
            // lblEtiquetaVouchers
            // 
            this.lblEtiquetaVouchers.AutoSize = true;
            this.lblEtiquetaVouchers.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.lblEtiquetaVouchers.Location = new System.Drawing.Point(10, 97);
            this.lblEtiquetaVouchers.Name = "lblEtiquetaVouchers";
            this.lblEtiquetaVouchers.Size = new System.Drawing.Size(161, 28);
            this.lblEtiquetaVouchers.TabIndex = 16;
            this.lblEtiquetaVouchers.Text = "Vouchers en caja:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnAceptar.Image = global::GYM.Properties.Resources.ImgAceptar;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(242, 237);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(103, 32);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmCerrarCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 281);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblVouchers);
            this.Controls.Add(this.lblEtiquetaVouchers);
            this.Controls.Add(this.txtEfectivo);
            this.Controls.Add(this.lblEtiquetaEfectivoTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblEtiquetaEfectivoDejar);
            this.Controls.Add(this.lblAtiende);
            this.Controls.Add(this.lblEtiquetaAtiende);
            this.Controls.Add(this.lblEfectivoCaja);
            this.Controls.Add(this.lblEtiquetaEfectivoCaja);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCerrarCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cerrar Caja";
            this.Load += new System.EventHandler(this.frmCerrarCaja_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.Label lblEtiquetaEfectivoTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblEtiquetaEfectivoDejar;
        private System.Windows.Forms.Label lblAtiende;
        private System.Windows.Forms.Label lblEtiquetaAtiende;
        private System.Windows.Forms.Label lblEfectivoCaja;
        private System.Windows.Forms.Label lblEtiquetaEfectivoCaja;
        private System.Windows.Forms.Label lblVouchers;
        private System.Windows.Forms.Label lblEtiquetaVouchers;
        private System.Windows.Forms.Button btnAceptar;
    }
}