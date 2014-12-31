namespace GYM.Formularios.Socio
{
    partial class frmCapturarHuella
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCapturarHuella));
            this.pcbHuella = new System.Windows.Forms.PictureBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pcbHuella)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbHuella
            // 
            this.pcbHuella.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pcbHuella.Location = new System.Drawing.Point(12, 12);
            this.pcbHuella.Name = "pcbHuella";
            this.pcbHuella.Size = new System.Drawing.Size(222, 302);
            this.pcbHuella.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbHuella.TabIndex = 1;
            this.pcbHuella.TabStop = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnAceptar.Location = new System.Drawing.Point(247, 280);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(151, 34);
            this.btnAceptar.TabIndex = 16;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmCapturarHuella
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 326);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.pcbHuella);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCapturarHuella";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Capturar Huella";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCapturarHuella_FormClosed);
            this.Load += new System.EventHandler(this.frmCapturarHuella_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbHuella)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbHuella;
        private System.Windows.Forms.Button btnAceptar;
    }
}