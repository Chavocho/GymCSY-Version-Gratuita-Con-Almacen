namespace GYM.Formularios
{
    partial class frmConfiguracionSonido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguracionSonido));
            this.lblTema = new System.Windows.Forms.Label();
            this.cboSonidosBien = new System.Windows.Forms.ComboBox();
            this.grbSonidosMembresia = new System.Windows.Forms.GroupBox();
            this.cboSonidosError = new System.Windows.Forms.ComboBox();
            this.pcbPlayMal = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pcbPlayBien = new System.Windows.Forms.PictureBox();
            this.chbSonidosMembresias = new System.Windows.Forms.CheckBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.bgwReproduccion = new System.ComponentModel.BackgroundWorker();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.grbSonidosMembresia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPlayMal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPlayBien)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTema
            // 
            this.lblTema.AutoSize = true;
            this.lblTema.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTema.Location = new System.Drawing.Point(6, 19);
            this.lblTema.Name = "lblTema";
            this.lblTema.Size = new System.Drawing.Size(188, 21);
            this.lblTema.TabIndex = 0;
            this.lblTema.Text = "Sonido membresía activa:";
            // 
            // cboSonidosBien
            // 
            this.cboSonidosBien.BackColor = System.Drawing.SystemColors.Window;
            this.cboSonidosBien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSonidosBien.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboSonidosBien.FormattingEnabled = true;
            this.cboSonidosBien.Items.AddRange(new object[] {
            "Sonido 01",
            "Sonido 02",
            "Sonido 03",
            "Sonido 04",
            "Sonido 05",
            "Personalizado"});
            this.cboSonidosBien.Location = new System.Drawing.Point(10, 43);
            this.cboSonidosBien.Name = "cboSonidosBien";
            this.cboSonidosBien.Size = new System.Drawing.Size(215, 29);
            this.cboSonidosBien.TabIndex = 1;
            this.cboSonidosBien.SelectedIndexChanged += new System.EventHandler(this.cboSonidosBien_SelectedIndexChanged);
            // 
            // grbSonidosMembresia
            // 
            this.grbSonidosMembresia.Controls.Add(this.cboSonidosError);
            this.grbSonidosMembresia.Controls.Add(this.pcbPlayMal);
            this.grbSonidosMembresia.Controls.Add(this.label1);
            this.grbSonidosMembresia.Controls.Add(this.pcbPlayBien);
            this.grbSonidosMembresia.Controls.Add(this.cboSonidosBien);
            this.grbSonidosMembresia.Controls.Add(this.lblTema);
            this.grbSonidosMembresia.Enabled = false;
            this.grbSonidosMembresia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grbSonidosMembresia.Location = new System.Drawing.Point(12, 43);
            this.grbSonidosMembresia.Name = "grbSonidosMembresia";
            this.grbSonidosMembresia.Size = new System.Drawing.Size(357, 137);
            this.grbSonidosMembresia.TabIndex = 1;
            this.grbSonidosMembresia.TabStop = false;
            this.grbSonidosMembresia.Text = "Sonidos puerta";
            // 
            // cboSonidosError
            // 
            this.cboSonidosError.BackColor = System.Drawing.SystemColors.Window;
            this.cboSonidosError.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSonidosError.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboSonidosError.FormattingEnabled = true;
            this.cboSonidosError.Items.AddRange(new object[] {
            "Sonido 01",
            "Sonido 02",
            "Sonido 03",
            "Sonido 04",
            "Sonido 05",
            "Personalizado"});
            this.cboSonidosError.Location = new System.Drawing.Point(10, 99);
            this.cboSonidosError.Name = "cboSonidosError";
            this.cboSonidosError.Size = new System.Drawing.Size(215, 29);
            this.cboSonidosError.TabIndex = 3;
            this.cboSonidosError.SelectedIndexChanged += new System.EventHandler(this.cboSonidosError_SelectedIndexChanged);
            // 
            // pcbPlayMal
            // 
            this.pcbPlayMal.Image = global::GYM.Properties.Resources.Play;
            this.pcbPlayMal.Location = new System.Drawing.Point(231, 99);
            this.pcbPlayMal.Name = "pcbPlayMal";
            this.pcbPlayMal.Size = new System.Drawing.Size(29, 29);
            this.pcbPlayMal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbPlayMal.TabIndex = 7;
            this.pcbPlayMal.TabStop = false;
            this.pcbPlayMal.Click += new System.EventHandler(this.pcbPlayMal_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(6, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sonido membresía terminada:";
            // 
            // pcbPlayBien
            // 
            this.pcbPlayBien.Image = global::GYM.Properties.Resources.Play;
            this.pcbPlayBien.Location = new System.Drawing.Point(231, 43);
            this.pcbPlayBien.Name = "pcbPlayBien";
            this.pcbPlayBien.Size = new System.Drawing.Size(29, 29);
            this.pcbPlayBien.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbPlayBien.TabIndex = 4;
            this.pcbPlayBien.TabStop = false;
            this.pcbPlayBien.Click += new System.EventHandler(this.pcbPlayBien_Click);
            // 
            // chbSonidosMembresias
            // 
            this.chbSonidosMembresias.AutoSize = true;
            this.chbSonidosMembresias.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chbSonidosMembresias.Location = new System.Drawing.Point(12, 12);
            this.chbSonidosMembresias.Name = "chbSonidosMembresias";
            this.chbSonidosMembresias.Size = new System.Drawing.Size(364, 25);
            this.chbSonidosMembresias.TabIndex = 0;
            this.chbSonidosMembresias.Text = "Utilizar alertas de sonido en registro de entradas";
            this.chbSonidosMembresias.UseVisualStyleBackColor = true;
            this.chbSonidosMembresias.CheckedChanged += new System.EventHandler(this.chbSonidosMembresias_CheckedChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAceptar.Location = new System.Drawing.Point(270, 187);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(99, 36);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // bgwReproduccion
            // 
            this.bgwReproduccion.WorkerSupportsCancellation = true;
            this.bgwReproduccion.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwReproduccion_DoWork);
            this.bgwReproduccion.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwReproduccion_RunWorkerCompleted);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnGrabar.Location = new System.Drawing.Point(12, 187);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(120, 36);
            this.btnGrabar.TabIndex = 2;
            this.btnGrabar.Text = "Grabar sonido";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmConfiguracionSonido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 235);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.chbSonidosMembresias);
            this.Controls.Add(this.grbSonidosMembresia);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmConfiguracionSonido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sonidos de sistema";
            this.Load += new System.EventHandler(this.frmConfiguracionSonido_Load);
            this.grbSonidosMembresia.ResumeLayout(false);
            this.grbSonidosMembresia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPlayMal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPlayBien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTema;
        private System.Windows.Forms.ComboBox cboSonidosBien;
        private System.Windows.Forms.GroupBox grbSonidosMembresia;
        private System.Windows.Forms.PictureBox pcbPlayBien;
        private System.Windows.Forms.CheckBox chbSonidosMembresias;
        private System.Windows.Forms.PictureBox pcbPlayMal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSonidosError;
        private System.Windows.Forms.Button btnAceptar;
        private System.ComponentModel.BackgroundWorker bgwReproduccion;
        private System.Windows.Forms.Button btnGrabar;
    }
}