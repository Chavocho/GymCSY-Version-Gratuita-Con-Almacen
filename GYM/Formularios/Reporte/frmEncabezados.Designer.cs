namespace GYM.Formularios.Reporte
{
    partial class frmEncabezados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEncabezados));
            this.bntAceptar = new System.Windows.Forms.Button();
            this.btnGaleria = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtboxLinea3 = new System.Windows.Forms.TextBox();
            this.txtboxLinea2 = new System.Windows.Forms.TextBox();
            this.txtboxLinea1 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pboxIcono = new System.Windows.Forms.PictureBox();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxIcono)).BeginInit();
            this.SuspendLayout();
            // 
            // bntAceptar
            // 
            this.bntAceptar.Location = new System.Drawing.Point(493, 399);
            this.bntAceptar.Name = "bntAceptar";
            this.bntAceptar.Size = new System.Drawing.Size(111, 23);
            this.bntAceptar.TabIndex = 15;
            this.bntAceptar.Text = "Aceptar";
            this.bntAceptar.UseVisualStyleBackColor = true;
            this.bntAceptar.Click += new System.EventHandler(this.bntAceptar_Click);
            // 
            // btnGaleria
            // 
            this.btnGaleria.Location = new System.Drawing.Point(411, 344);
            this.btnGaleria.Name = "btnGaleria";
            this.btnGaleria.Size = new System.Drawing.Size(169, 23);
            this.btnGaleria.TabIndex = 13;
            this.btnGaleria.Text = "Ver galeria";
            this.btnGaleria.UseVisualStyleBackColor = true;
            this.btnGaleria.Click += new System.EventHandler(this.btnGaleria_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(581, 26);
            this.label1.TabIndex = 12;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // txtboxLinea3
            // 
            this.helpProvider1.SetHelpString(this.txtboxLinea3, "Tercera linea del encabezado, se muestra con un tamano menor que la primer linea " +
        "y un color menos oscuro");
            this.txtboxLinea3.Location = new System.Drawing.Point(16, 307);
            this.txtboxLinea3.MaxLength = 20;
            this.txtboxLinea3.Name = "txtboxLinea3";
            this.helpProvider1.SetShowHelp(this.txtboxLinea3, true);
            this.txtboxLinea3.Size = new System.Drawing.Size(266, 20);
            this.txtboxLinea3.TabIndex = 10;
            // 
            // txtboxLinea2
            // 
            this.helpProvider1.SetHelpString(this.txtboxLinea2, "Segunda linea del encabezado, se muestra con un tamano menor que la primer linea " +
        "y un color menos oscuro");
            this.txtboxLinea2.Location = new System.Drawing.Point(16, 261);
            this.txtboxLinea2.MaxLength = 20;
            this.txtboxLinea2.Name = "txtboxLinea2";
            this.helpProvider1.SetShowHelp(this.txtboxLinea2, true);
            this.txtboxLinea2.Size = new System.Drawing.Size(266, 20);
            this.txtboxLinea2.TabIndex = 9;
            // 
            // txtboxLinea1
            // 
            this.helpProvider1.SetHelpString(this.txtboxLinea1, "Primer linea del encabezado, se muestra de un tamano mayor y más oscuro");
            this.txtboxLinea1.Location = new System.Drawing.Point(16, 221);
            this.txtboxLinea1.MaxLength = 20;
            this.txtboxLinea1.Name = "txtboxLinea1";
            this.helpProvider1.SetShowHelp(this.txtboxLinea1, true);
            this.txtboxLinea1.Size = new System.Drawing.Size(266, 20);
            this.txtboxLinea1.TabIndex = 8;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(16, 50);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(588, 139);
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // pboxIcono
            // 
            this.pboxIcono.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.helpProvider1.SetHelpString(this.pboxIcono, "Logotipo representativo de la organizacion, se recomienda que sea de un tamaño pe" +
        "queño");
            this.pboxIcono.Location = new System.Drawing.Point(411, 222);
            this.pboxIcono.Name = "pboxIcono";
            this.helpProvider1.SetShowHelp(this.pboxIcono, true);
            this.pboxIcono.Size = new System.Drawing.Size(169, 105);
            this.pboxIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxIcono.TabIndex = 11;
            this.pboxIcono.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 291);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Renglon 3:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Renglon 2:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Renglon 1:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(408, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Logotipo del negocio:";
            // 
            // frmEncabezados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 431);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bntAceptar);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnGaleria);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pboxIcono);
            this.Controls.Add(this.txtboxLinea3);
            this.Controls.Add(this.txtboxLinea2);
            this.Controls.Add(this.txtboxLinea1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEncabezados";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editar encabezados";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEncabezados_FormClosing);
            this.Load += new System.EventHandler(this.frmEncabezados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxIcono)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bntAceptar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnGaleria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pboxIcono;
        private System.Windows.Forms.TextBox txtboxLinea3;
        private System.Windows.Forms.TextBox txtboxLinea2;
        private System.Windows.Forms.TextBox txtboxLinea1;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}