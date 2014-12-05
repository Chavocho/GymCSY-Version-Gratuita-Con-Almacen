namespace GYM.Formularios.Socio
{
    partial class frmMostrarSocio
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMostrarSocio));
            this.pbImagenPerfil = new System.Windows.Forms.PictureBox();
            this.lblAp = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblTel = new System.Windows.Forms.Label();
            this.lblDom = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblDomicilio = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblFechaFinal = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.tmrCerrar = new System.Windows.Forms.Timer(this.components);
            this.bgwSonido = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenPerfil)).BeginInit();
            this.SuspendLayout();
            // 
            // pbImagenPerfil
            // 
            this.pbImagenPerfil.Image = global::GYM.Properties.Resources.ImgCamara;
            this.pbImagenPerfil.Location = new System.Drawing.Point(12, 12);
            this.pbImagenPerfil.Name = "pbImagenPerfil";
            this.pbImagenPerfil.Size = new System.Drawing.Size(164, 172);
            this.pbImagenPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImagenPerfil.TabIndex = 28;
            this.pbImagenPerfil.TabStop = false;
            // 
            // lblAp
            // 
            this.lblAp.AutoSize = true;
            this.lblAp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAp.Location = new System.Drawing.Point(254, 67);
            this.lblAp.Name = "lblAp";
            this.lblAp.Size = new System.Drawing.Size(77, 21);
            this.lblAp.TabIndex = 38;
            this.lblAp.Text = "Apellidos:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(260, 24);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(71, 21);
            this.lblName.TabIndex = 36;
            this.lblName.Text = "Nombre:";
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTel.Location = new System.Drawing.Point(258, 164);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(73, 21);
            this.lblTel.TabIndex = 58;
            this.lblTel.Text = "Telefono:";
            // 
            // lblDom
            // 
            this.lblDom.AutoSize = true;
            this.lblDom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDom.Location = new System.Drawing.Point(252, 115);
            this.lblDom.Name = "lblDom";
            this.lblDom.Size = new System.Drawing.Size(79, 21);
            this.lblDom.TabIndex = 50;
            this.lblDom.Text = "Domicilio:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Location = new System.Drawing.Point(365, 357);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(87, 40);
            this.btnAceptar.TabIndex = 62;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Visible = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Image = global::GYM.Properties.Resources.ImgAceptar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(469, 357);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(166, 40);
            this.btnCancelar.TabIndex = 61;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblNombre.Location = new System.Drawing.Point(361, 24);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(73, 21);
            this.lblNombre.TabIndex = 64;
            this.lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblApellido.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblApellido.Location = new System.Drawing.Point(361, 67);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(82, 21);
            this.lblApellido.TabIndex = 65;
            this.lblApellido.Text = "Apellidos";
            // 
            // lblDomicilio
            // 
            this.lblDomicilio.AutoSize = true;
            this.lblDomicilio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDomicilio.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblDomicilio.Location = new System.Drawing.Point(361, 115);
            this.lblDomicilio.Name = "lblDomicilio";
            this.lblDomicilio.Size = new System.Drawing.Size(85, 21);
            this.lblDomicilio.TabIndex = 66;
            this.lblDomicilio.Text = "Domicilio";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTelefono.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblTelefono.Location = new System.Drawing.Point(361, 164);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(77, 21);
            this.lblTelefono.TabIndex = 67;
            this.lblTelefono.Text = "Telefono";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblInfo.ForeColor = System.Drawing.Color.Orange;
            this.lblInfo.Location = new System.Drawing.Point(61, 253);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(203, 47);
            this.lblInfo.TabIndex = 68;
            this.lblInfo.Text = "Bienvenido";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblInfo.Visible = false;
            // 
            // lblFechaFinal
            // 
            this.lblFechaFinal.AutoSize = true;
            this.lblFechaFinal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblFechaFinal.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblFechaFinal.Location = new System.Drawing.Point(361, 212);
            this.lblFechaFinal.Name = "lblFechaFinal";
            this.lblFechaFinal.Size = new System.Drawing.Size(54, 21);
            this.lblFechaFinal.TabIndex = 70;
            this.lblFechaFinal.Text = "Fecha";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(187, 212);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(144, 21);
            this.lblFecha.TabIndex = 69;
            this.lblFecha.Text = "Fecha Vencimiento:";
            // 
            // tmrCerrar
            // 
            this.tmrCerrar.Interval = 1000;
            this.tmrCerrar.Tick += new System.EventHandler(this.tmrCerrar_Tick);
            // 
            // bgwSonido
            // 
            this.bgwSonido.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSonido_DoWork);
            // 
            // frmMostrarSocio
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(647, 409);
            this.Controls.Add(this.lblFechaFinal);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.lblDomicilio);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblTel);
            this.Controls.Add(this.lblDom);
            this.Controls.Add(this.lblAp);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pbImagenPerfil);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMostrarSocio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bienvenido";
            this.Load += new System.EventHandler(this.formMostrarSocio_Load);
            this.Shown += new System.EventHandler(this.frmMostrarSocio_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenPerfil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImagenPerfil;
        private System.Windows.Forms.Label lblAp;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Label lblDom;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblDomicilio;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblFechaFinal;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Timer tmrCerrar;
        private System.ComponentModel.BackgroundWorker bgwSonido;
    }
}