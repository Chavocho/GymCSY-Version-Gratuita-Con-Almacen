namespace GYM.Formularios.Socio
{
    partial class frmEditarMiembro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditarMiembro));
            this.txtNumSocio = new System.Windows.Forms.TextBox();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.lblEtiquetaCiudad = new System.Windows.Forms.Label();
            this.lblEtiquetaSocio = new System.Windows.Forms.Label();
            this.cbxCamara = new System.Windows.Forms.ComboBox();
            this.cbxEstado = new System.Windows.Forms.ComboBox();
            this.dtpFechaNac = new System.Windows.Forms.DateTimePicker();
            this.btnTomarFoto = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cbxSexo = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblEtiquetaEmail = new System.Windows.Forms.Label();
            this.lblEtiquetaTelefono = new System.Windows.Forms.Label();
            this.lblEtiquetaEstado = new System.Windows.Forms.Label();
            this.lblEtiquetaCelular = new System.Windows.Forms.Label();
            this.lblEtiquetaDomicilio = new System.Windows.Forms.Label();
            this.lblEtiquetaSexo = new System.Windows.Forms.Label();
            this.lblEtiquetaFechaNac = new System.Windows.Forms.Label();
            this.lblEtiquetaApellidos = new System.Windows.Forms.Label();
            this.lblEtiquetaNombre = new System.Windows.Forms.Label();
            this.pbxImagenPerfil = new System.Windows.Forms.PictureBox();
            this.btnHuella = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagenPerfil)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNumSocio
            // 
            this.txtNumSocio.Enabled = false;
            this.txtNumSocio.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtNumSocio.Location = new System.Drawing.Point(393, 12);
            this.txtNumSocio.Name = "txtNumSocio";
            this.txtNumSocio.Size = new System.Drawing.Size(80, 26);
            this.txtNumSocio.TabIndex = 67;
            this.txtNumSocio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumSocio_KeyPress);
            // 
            // txtCiudad
            // 
            this.txtCiudad.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtCiudad.Location = new System.Drawing.Point(572, 173);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(122, 26);
            this.txtCiudad.TabIndex = 56;
            // 
            // lblEtiquetaCiudad
            // 
            this.lblEtiquetaCiudad.AutoSize = true;
            this.lblEtiquetaCiudad.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblEtiquetaCiudad.Location = new System.Drawing.Point(511, 176);
            this.lblEtiquetaCiudad.Name = "lblEtiquetaCiudad";
            this.lblEtiquetaCiudad.Size = new System.Drawing.Size(55, 19);
            this.lblEtiquetaCiudad.TabIndex = 66;
            this.lblEtiquetaCiudad.Text = "Ciudad:";
            // 
            // lblEtiquetaSocio
            // 
            this.lblEtiquetaSocio.AutoSize = true;
            this.lblEtiquetaSocio.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblEtiquetaSocio.Location = new System.Drawing.Point(271, 15);
            this.lblEtiquetaSocio.Name = "lblEtiquetaSocio";
            this.lblEtiquetaSocio.Size = new System.Drawing.Size(116, 19);
            this.lblEtiquetaSocio.TabIndex = 65;
            this.lblEtiquetaSocio.Text = "Número de socio:";
            // 
            // cbxCamara
            // 
            this.cbxCamara.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCamara.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxCamara.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cbxCamara.FormattingEnabled = true;
            this.cbxCamara.Location = new System.Drawing.Point(36, 265);
            this.cbxCamara.Name = "cbxCamara";
            this.cbxCamara.Size = new System.Drawing.Size(209, 27);
            this.cbxCamara.TabIndex = 64;
            // 
            // cbxEstado
            // 
            this.cbxEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxEstado.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cbxEstado.FormattingEnabled = true;
            this.cbxEstado.Items.AddRange(new object[] {
            "Aguascalientes",
            "Baja California",
            "Baja California Sur",
            "Campeche",
            "Chiapas",
            "Chihuahua",
            "Coahuila",
            "Colima",
            "Durango",
            "Distrito Federal",
            "Guanajuato",
            "Guerrero",
            "Hidalgo",
            "Jalisco",
            "México",
            "Michoacán",
            "Morelos",
            "Nayarit",
            "Nuevo León",
            "Oaxaca",
            "Puebla",
            "Querétaro",
            "Quintana Roo",
            "San Luis Potosí",
            "Sinaloa",
            "Sonora",
            "Tabasco",
            "Tamaulipas",
            "Tlaxcala",
            "Veracruz",
            "Yucatán",
            "Zacatecas"});
            this.cbxEstado.Location = new System.Drawing.Point(393, 173);
            this.cbxEstado.Name = "cbxEstado";
            this.cbxEstado.Size = new System.Drawing.Size(112, 27);
            this.cbxEstado.TabIndex = 54;
            // 
            // dtpFechaNac
            // 
            this.dtpFechaNac.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dtpFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNac.Location = new System.Drawing.Point(449, 108);
            this.dtpFechaNac.Name = "dtpFechaNac";
            this.dtpFechaNac.Size = new System.Drawing.Size(93, 26);
            this.dtpFechaNac.TabIndex = 50;
            // 
            // btnTomarFoto
            // 
            this.btnTomarFoto.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnTomarFoto.Image = global::GYM.Properties.Resources.ImgCamaraSmall;
            this.btnTomarFoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTomarFoto.Location = new System.Drawing.Point(70, 305);
            this.btnTomarFoto.Name = "btnTomarFoto";
            this.btnTomarFoto.Size = new System.Drawing.Size(150, 44);
            this.btnTomarFoto.TabIndex = 62;
            this.btnTomarFoto.Text = "Iniciar Camara";
            this.btnTomarFoto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTomarFoto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTomarFoto.UseVisualStyleBackColor = true;
            this.btnTomarFoto.Click += new System.EventHandler(this.btnTomarFoto_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnAceptar.Image = global::GYM.Properties.Resources.ImgAceptar;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(543, 365);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(151, 34);
            this.btnAceptar.TabIndex = 60;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnCancelar.Image = global::GYM.Properties.Resources.ImgCancelar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(386, 365);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(151, 34);
            this.btnCancelar.TabIndex = 61;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cbxSexo
            // 
            this.cbxSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSexo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxSexo.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cbxSexo.FormattingEnabled = true;
            this.cbxSexo.Items.AddRange(new object[] {
            "Masculino",
            "Femenino"});
            this.cbxSexo.Location = new System.Drawing.Point(592, 108);
            this.cbxSexo.Name = "cbxSexo";
            this.cbxSexo.Size = new System.Drawing.Size(102, 27);
            this.cbxSexo.TabIndex = 52;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtEmail.Location = new System.Drawing.Point(393, 270);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(301, 26);
            this.txtEmail.TabIndex = 59;
            // 
            // txtTel
            // 
            this.txtTel.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtTel.Location = new System.Drawing.Point(393, 238);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(149, 26);
            this.txtTel.TabIndex = 58;
            this.txtTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTel_KeyPress);
            // 
            // txtCelular
            // 
            this.txtCelular.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtCelular.Location = new System.Drawing.Point(393, 206);
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(149, 26);
            this.txtCelular.TabIndex = 57;
            this.txtCelular.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCelular_KeyPress);
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtDomicilio.Location = new System.Drawing.Point(393, 141);
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(301, 26);
            this.txtDomicilio.TabIndex = 53;
            // 
            // txtApellidos
            // 
            this.txtApellidos.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtApellidos.Location = new System.Drawing.Point(393, 76);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(301, 26);
            this.txtApellidos.TabIndex = 49;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtNombre.Location = new System.Drawing.Point(393, 44);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(301, 26);
            this.txtNombre.TabIndex = 48;
            // 
            // lblEtiquetaEmail
            // 
            this.lblEtiquetaEmail.AutoSize = true;
            this.lblEtiquetaEmail.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblEtiquetaEmail.Location = new System.Drawing.Point(343, 273);
            this.lblEtiquetaEmail.Name = "lblEtiquetaEmail";
            this.lblEtiquetaEmail.Size = new System.Drawing.Size(44, 19);
            this.lblEtiquetaEmail.TabIndex = 47;
            this.lblEtiquetaEmail.Text = "Email:";
            // 
            // lblEtiquetaTelefono
            // 
            this.lblEtiquetaTelefono.AutoSize = true;
            this.lblEtiquetaTelefono.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblEtiquetaTelefono.Location = new System.Drawing.Point(323, 241);
            this.lblEtiquetaTelefono.Name = "lblEtiquetaTelefono";
            this.lblEtiquetaTelefono.Size = new System.Drawing.Size(64, 19);
            this.lblEtiquetaTelefono.TabIndex = 46;
            this.lblEtiquetaTelefono.Text = "Telefono:";
            // 
            // lblEtiquetaEstado
            // 
            this.lblEtiquetaEstado.AutoSize = true;
            this.lblEtiquetaEstado.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblEtiquetaEstado.Location = new System.Drawing.Point(334, 176);
            this.lblEtiquetaEstado.Name = "lblEtiquetaEstado";
            this.lblEtiquetaEstado.Size = new System.Drawing.Size(53, 19);
            this.lblEtiquetaEstado.TabIndex = 44;
            this.lblEtiquetaEstado.Text = "Estado:";
            // 
            // lblEtiquetaCelular
            // 
            this.lblEtiquetaCelular.AutoSize = true;
            this.lblEtiquetaCelular.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblEtiquetaCelular.Location = new System.Drawing.Point(333, 209);
            this.lblEtiquetaCelular.Name = "lblEtiquetaCelular";
            this.lblEtiquetaCelular.Size = new System.Drawing.Size(54, 19);
            this.lblEtiquetaCelular.TabIndex = 43;
            this.lblEtiquetaCelular.Text = "Celular:";
            // 
            // lblEtiquetaDomicilio
            // 
            this.lblEtiquetaDomicilio.AutoSize = true;
            this.lblEtiquetaDomicilio.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblEtiquetaDomicilio.Location = new System.Drawing.Point(319, 144);
            this.lblEtiquetaDomicilio.Name = "lblEtiquetaDomicilio";
            this.lblEtiquetaDomicilio.Size = new System.Drawing.Size(68, 19);
            this.lblEtiquetaDomicilio.TabIndex = 42;
            this.lblEtiquetaDomicilio.Text = "Domicilio:";
            // 
            // lblEtiquetaSexo
            // 
            this.lblEtiquetaSexo.AutoSize = true;
            this.lblEtiquetaSexo.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblEtiquetaSexo.Location = new System.Drawing.Point(548, 111);
            this.lblEtiquetaSexo.Name = "lblEtiquetaSexo";
            this.lblEtiquetaSexo.Size = new System.Drawing.Size(40, 19);
            this.lblEtiquetaSexo.TabIndex = 41;
            this.lblEtiquetaSexo.Text = "Sexo:";
            // 
            // lblEtiquetaFechaNac
            // 
            this.lblEtiquetaFechaNac.AutoSize = true;
            this.lblEtiquetaFechaNac.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblEtiquetaFechaNac.Location = new System.Drawing.Point(306, 111);
            this.lblEtiquetaFechaNac.Name = "lblEtiquetaFechaNac";
            this.lblEtiquetaFechaNac.Size = new System.Drawing.Size(137, 19);
            this.lblEtiquetaFechaNac.TabIndex = 40;
            this.lblEtiquetaFechaNac.Text = "Fecha de nacimiento:";
            // 
            // lblEtiquetaApellidos
            // 
            this.lblEtiquetaApellidos.AutoSize = true;
            this.lblEtiquetaApellidos.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblEtiquetaApellidos.Location = new System.Drawing.Point(320, 79);
            this.lblEtiquetaApellidos.Name = "lblEtiquetaApellidos";
            this.lblEtiquetaApellidos.Size = new System.Drawing.Size(67, 19);
            this.lblEtiquetaApellidos.TabIndex = 39;
            this.lblEtiquetaApellidos.Text = "Apellidos:";
            // 
            // lblEtiquetaNombre
            // 
            this.lblEtiquetaNombre.AutoSize = true;
            this.lblEtiquetaNombre.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblEtiquetaNombre.Location = new System.Drawing.Point(325, 47);
            this.lblEtiquetaNombre.Name = "lblEtiquetaNombre";
            this.lblEtiquetaNombre.Size = new System.Drawing.Size(62, 19);
            this.lblEtiquetaNombre.TabIndex = 38;
            this.lblEtiquetaNombre.Text = "Nombre:";
            // 
            // pbxImagenPerfil
            // 
            this.pbxImagenPerfil.Image = global::GYM.Properties.Resources.ImgCamara;
            this.pbxImagenPerfil.Location = new System.Drawing.Point(12, 12);
            this.pbxImagenPerfil.Name = "pbxImagenPerfil";
            this.pbxImagenPerfil.Size = new System.Drawing.Size(256, 241);
            this.pbxImagenPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxImagenPerfil.TabIndex = 37;
            this.pbxImagenPerfil.TabStop = false;
            // 
            // btnHuella
            // 
            this.btnHuella.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnHuella.Location = new System.Drawing.Point(70, 355);
            this.btnHuella.Name = "btnHuella";
            this.btnHuella.Size = new System.Drawing.Size(151, 34);
            this.btnHuella.TabIndex = 68;
            this.btnHuella.Text = "Capturar huella";
            this.btnHuella.UseVisualStyleBackColor = true;
            this.btnHuella.Click += new System.EventHandler(this.btnHuella_Click);
            // 
            // frmEditarMiembro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 411);
            this.Controls.Add(this.btnHuella);
            this.Controls.Add(this.txtNumSocio);
            this.Controls.Add(this.txtCiudad);
            this.Controls.Add(this.lblEtiquetaCiudad);
            this.Controls.Add(this.lblEtiquetaSocio);
            this.Controls.Add(this.cbxCamara);
            this.Controls.Add(this.cbxEstado);
            this.Controls.Add(this.dtpFechaNac);
            this.Controls.Add(this.btnTomarFoto);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.cbxSexo);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.txtCelular);
            this.Controls.Add(this.txtDomicilio);
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblEtiquetaEmail);
            this.Controls.Add(this.lblEtiquetaTelefono);
            this.Controls.Add(this.lblEtiquetaEstado);
            this.Controls.Add(this.lblEtiquetaCelular);
            this.Controls.Add(this.lblEtiquetaDomicilio);
            this.Controls.Add(this.lblEtiquetaSexo);
            this.Controls.Add(this.lblEtiquetaFechaNac);
            this.Controls.Add(this.lblEtiquetaApellidos);
            this.Controls.Add(this.lblEtiquetaNombre);
            this.Controls.Add(this.pbxImagenPerfil);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEditarMiembro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Socio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditarMiembro_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEditarMiembro_FormClosed);
            this.Load += new System.EventHandler(this.frmEditarMiembro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagenPerfil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumSocio;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.Label lblEtiquetaCiudad;
        private System.Windows.Forms.Label lblEtiquetaSocio;
        private System.Windows.Forms.ComboBox cbxCamara;
        private System.Windows.Forms.ComboBox cbxEstado;
        private System.Windows.Forms.DateTimePicker dtpFechaNac;
        private System.Windows.Forms.Button btnTomarFoto;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cbxSexo;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtCelular;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblEtiquetaEmail;
        private System.Windows.Forms.Label lblEtiquetaTelefono;
        private System.Windows.Forms.Label lblEtiquetaEstado;
        private System.Windows.Forms.Label lblEtiquetaCelular;
        private System.Windows.Forms.Label lblEtiquetaDomicilio;
        private System.Windows.Forms.Label lblEtiquetaSexo;
        private System.Windows.Forms.Label lblEtiquetaFechaNac;
        private System.Windows.Forms.Label lblEtiquetaApellidos;
        private System.Windows.Forms.Label lblEtiquetaNombre;
        private System.Windows.Forms.PictureBox pbxImagenPerfil;
        private System.Windows.Forms.Button btnHuella;

    }
}