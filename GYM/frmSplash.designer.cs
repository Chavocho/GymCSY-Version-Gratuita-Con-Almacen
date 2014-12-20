namespace GYM
{
    partial class frmSplash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSplash));
            this.lblGYM = new System.Windows.Forms.Label();
            this.lblCSY = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblCargando = new System.Windows.Forms.Label();
            this.bgwCargar = new System.ComponentModel.BackgroundWorker();
            this.prbProgreso = new System.Windows.Forms.ProgressBar();
            this.pcbImagen = new System.Windows.Forms.PictureBox();
            this.lblBETA = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcbImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGYM
            // 
            this.lblGYM.AutoSize = true;
            this.lblGYM.Font = new System.Drawing.Font("Segoe UI", 70F, System.Drawing.FontStyle.Bold);
            this.lblGYM.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblGYM.Location = new System.Drawing.Point(24, 19);
            this.lblGYM.Name = "lblGYM";
            this.lblGYM.Size = new System.Drawing.Size(256, 125);
            this.lblGYM.TabIndex = 1;
            this.lblGYM.Text = "Gym";
            // 
            // lblCSY
            // 
            this.lblCSY.AutoSize = true;
            this.lblCSY.Font = new System.Drawing.Font("Segoe UI", 45F);
            this.lblCSY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblCSY.Location = new System.Drawing.Point(143, 133);
            this.lblCSY.Name = "lblCSY";
            this.lblCSY.Size = new System.Drawing.Size(137, 81);
            this.lblCSY.TabIndex = 2;
            this.lblCSY.Text = "CSY";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblVersion.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblVersion.Location = new System.Drawing.Point(12, 267);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(61, 20);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "v 1.0.0.0";
            // 
            // lblCargando
            // 
            this.lblCargando.AutoSize = true;
            this.lblCargando.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblCargando.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblCargando.Location = new System.Drawing.Point(399, 95);
            this.lblCargando.Name = "lblCargando";
            this.lblCargando.Size = new System.Drawing.Size(160, 20);
            this.lblCargando.TabIndex = 4;
            this.lblCargando.Text = "Cargando el programa";
            // 
            // bgwCargar
            // 
            this.bgwCargar.WorkerReportsProgress = true;
            this.bgwCargar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCargar_DoWork);
            this.bgwCargar.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwCargar_ProgressChanged);
            this.bgwCargar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwCargar_RunWorkerCompleted);
            // 
            // prbProgreso
            // 
            this.prbProgreso.Location = new System.Drawing.Point(0, 298);
            this.prbProgreso.MarqueeAnimationSpeed = 10;
            this.prbProgreso.Name = "prbProgreso";
            this.prbProgreso.Size = new System.Drawing.Size(612, 10);
            this.prbProgreso.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prbProgreso.TabIndex = 5;
            // 
            // pcbImagen
            // 
            this.pcbImagen.Image = global::GYM.Properties.Resources.Imagen_Inicio;
            this.pcbImagen.Location = new System.Drawing.Point(403, 118);
            this.pcbImagen.Name = "pcbImagen";
            this.pcbImagen.Size = new System.Drawing.Size(305, 284);
            this.pcbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbImagen.TabIndex = 0;
            this.pcbImagen.TabStop = false;
            // 
            // lblBETA
            // 
            this.lblBETA.AutoSize = true;
            this.lblBETA.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBETA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lblBETA.Location = new System.Drawing.Point(545, 9);
            this.lblBETA.Name = "lblBETA";
            this.lblBETA.Size = new System.Drawing.Size(57, 25);
            this.lblBETA.TabIndex = 6;
            this.lblBETA.Text = "BETA";
            // 
            // frmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(612, 308);
            this.Controls.Add(this.lblBETA);
            this.Controls.Add(this.prbProgreso);
            this.Controls.Add(this.lblCargando);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblCSY);
            this.Controls.Add(this.lblGYM);
            this.Controls.Add(this.pcbImagen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSplash";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSplash";
            this.Load += new System.EventHandler(this.frmSplash_Load);
            this.Shown += new System.EventHandler(this.frmSplash_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pcbImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbImagen;
        private System.Windows.Forms.Label lblGYM;
        private System.Windows.Forms.Label lblCSY;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblCargando;
        private System.ComponentModel.BackgroundWorker bgwCargar;
        private System.Windows.Forms.ProgressBar prbProgreso;
        private System.Windows.Forms.Label lblBETA;
    }
}