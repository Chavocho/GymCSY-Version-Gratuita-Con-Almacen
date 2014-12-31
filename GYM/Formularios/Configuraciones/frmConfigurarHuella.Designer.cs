namespace GYM.Formularios
{
    partial class frmConfigurarHuella
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigurarHuella));
            this.pcbHuella = new System.Windows.Forms.PictureBox();
            this.cboLectores = new System.Windows.Forms.ComboBox();
            this.lblSeleccionar = new System.Windows.Forms.Label();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pcbHuella)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbHuella
            // 
            this.pcbHuella.Location = new System.Drawing.Point(12, 12);
            this.pcbHuella.Name = "pcbHuella";
            this.pcbHuella.Size = new System.Drawing.Size(197, 252);
            this.pcbHuella.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbHuella.TabIndex = 0;
            this.pcbHuella.TabStop = false;
            // 
            // cboLectores
            // 
            this.cboLectores.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboLectores.FormattingEnabled = true;
            this.cboLectores.Location = new System.Drawing.Point(215, 36);
            this.cboLectores.Name = "cboLectores";
            this.cboLectores.Size = new System.Drawing.Size(230, 29);
            this.cboLectores.TabIndex = 1;
            this.cboLectores.SelectedIndexChanged += new System.EventHandler(this.cboLectores_SelectedIndexChanged);
            // 
            // lblSeleccionar
            // 
            this.lblSeleccionar.AutoSize = true;
            this.lblSeleccionar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblSeleccionar.Location = new System.Drawing.Point(211, 12);
            this.lblSeleccionar.Name = "lblSeleccionar";
            this.lblSeleccionar.Size = new System.Drawing.Size(133, 21);
            this.lblSeleccionar.TabIndex = 2;
            this.lblSeleccionar.Text = "Selecciona Lector:";
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnRefrescar.Image = global::GYM.Properties.Resources.ImgActualizar;
            this.btnRefrescar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefrescar.Location = new System.Drawing.Point(301, 71);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(144, 32);
            this.btnRefrescar.TabIndex = 5;
            this.btnRefrescar.Text = "Recargar lista";
            this.btnRefrescar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnAceptar.Image = global::GYM.Properties.Resources.ImgAceptar;
            this.btnAceptar.Location = new System.Drawing.Point(348, 232);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(97, 32);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnCancelar.Image = global::GYM.Properties.Resources.ImgCancelar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(231, 232);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(111, 32);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmConfigurarHuella
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 276);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.lblSeleccionar);
            this.Controls.Add(this.cboLectores);
            this.Controls.Add(this.pcbHuella);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmConfigurarHuella";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurar Huella";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmConfigurarHuella_FormClosed);
            this.Load += new System.EventHandler(this.frmConfigurarHuella_Load);
            this.Shown += new System.EventHandler(this.frmConfigurarHuella_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pcbHuella)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbHuella;
        private System.Windows.Forms.ComboBox cboLectores;
        private System.Windows.Forms.Label lblSeleccionar;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}