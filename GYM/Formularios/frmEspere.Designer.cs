namespace GYM.Formularios
{
    partial class frmEspere
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEspere));
            this.prbEspere = new System.Windows.Forms.ProgressBar();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // prbEspere
            // 
            this.prbEspere.Location = new System.Drawing.Point(12, 53);
            this.prbEspere.MarqueeAnimationSpeed = 50;
            this.prbEspere.Name = "prbEspere";
            this.prbEspere.Size = new System.Drawing.Size(573, 23);
            this.prbEspere.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.prbEspere.TabIndex = 1;
            this.prbEspere.Value = 100;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.lblTitulo.Location = new System.Drawing.Point(138, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(320, 28);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Espere, guardando la configuración";
            // 
            // frmEspere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 88);
            this.ControlBox = false;
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.prbEspere);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEspere";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GymCSY";
            this.Load += new System.EventHandler(this.frmEspere_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar prbEspere;
        private System.Windows.Forms.Label lblTitulo;
    }
}