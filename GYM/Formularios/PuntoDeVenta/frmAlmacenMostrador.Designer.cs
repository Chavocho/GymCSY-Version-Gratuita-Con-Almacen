namespace GYM.Formularios.PuntoDeVenta
{
    partial class frmAlmacenMostrador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlmacenMostrador));
            this.lblECantidad = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.nudCantMostrador = new System.Windows.Forms.NumericUpDown();
            this.lblECantMostrador = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantMostrador)).BeginInit();
            this.SuspendLayout();
            // 
            // lblECantidad
            // 
            this.lblECantidad.AutoSize = true;
            this.lblECantidad.Location = new System.Drawing.Point(8, 9);
            this.lblECantidad.Name = "lblECantidad";
            this.lblECantidad.Size = new System.Drawing.Size(99, 19);
            this.lblECantidad.TabIndex = 0;
            this.lblECantidad.Text = "Cantidad total:";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(113, 9);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(17, 19);
            this.lblCantidad.TabIndex = 1;
            this.lblCantidad.Text = "0";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnAceptar.Location = new System.Drawing.Point(143, 127);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // nudCantMostrador
            // 
            this.nudCantMostrador.Location = new System.Drawing.Point(12, 69);
            this.nudCantMostrador.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudCantMostrador.Name = "nudCantMostrador";
            this.nudCantMostrador.Size = new System.Drawing.Size(95, 25);
            this.nudCantMostrador.TabIndex = 3;
            this.nudCantMostrador.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantMostrador.ValueChanged += new System.EventHandler(this.nudCantMostrador_ValueChanged);
            // 
            // lblECantMostrador
            // 
            this.lblECantMostrador.AutoSize = true;
            this.lblECantMostrador.Location = new System.Drawing.Point(8, 47);
            this.lblECantMostrador.Name = "lblECantMostrador";
            this.lblECantMostrador.Size = new System.Drawing.Size(154, 19);
            this.lblECantMostrador.TabIndex = 4;
            this.lblECantMostrador.Text = "Cantidad en mostrador:";
            // 
            // frmAlmacenMostrador
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(230, 162);
            this.Controls.Add(this.lblECantMostrador);
            this.Controls.Add(this.nudCantMostrador);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblECantidad);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAlmacenMostrador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventario";
            this.Load += new System.EventHandler(this.frmAlmacenMostrador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCantMostrador)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblECantidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.NumericUpDown nudCantMostrador;
        private System.Windows.Forms.Label lblECantMostrador;
    }
}