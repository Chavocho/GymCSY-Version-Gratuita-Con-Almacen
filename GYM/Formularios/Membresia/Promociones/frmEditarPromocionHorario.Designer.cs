namespace GYM.Formularios.Membresia
{
    partial class frmEditarPromocionHorario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditarPromocionHorario));
            this.cboGenero = new System.Windows.Forms.ComboBox();
            this.lblEGenero = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.lblEDuracion = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblEPrecio = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblEDescripcion = new System.Windows.Forms.Label();
            this.lblEFechaFin = new System.Windows.Forms.Label();
            this.dtpHoraFin = new System.Windows.Forms.DateTimePicker();
            this.lblEFechaInicio = new System.Windows.Forms.Label();
            this.dtpHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.grbDatos = new System.Windows.Forms.GroupBox();
            this.lblUpdateUser = new System.Windows.Forms.Label();
            this.lblEUpdateUser = new System.Windows.Forms.Label();
            this.lblUpdateTime = new System.Windows.Forms.Label();
            this.lblEUpdateTime = new System.Windows.Forms.Label();
            this.lblCreateTime = new System.Windows.Forms.Label();
            this.lblECreateTime = new System.Windows.Forms.Label();
            this.lblCreateUser = new System.Windows.Forms.Label();
            this.lblECreateUser = new System.Windows.Forms.Label();
            this.grbDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboGenero
            // 
            this.cboGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGenero.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cboGenero.FormattingEnabled = true;
            this.cboGenero.Items.AddRange(new object[] {
            "Hombre",
            "Mujer"});
            this.cboGenero.Location = new System.Drawing.Point(12, 198);
            this.cboGenero.Name = "cboGenero";
            this.cboGenero.Size = new System.Drawing.Size(243, 27);
            this.cboGenero.TabIndex = 38;
            // 
            // lblEGenero
            // 
            this.lblEGenero.AutoSize = true;
            this.lblEGenero.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEGenero.Location = new System.Drawing.Point(8, 176);
            this.lblEGenero.Name = "lblEGenero";
            this.lblEGenero.Size = new System.Drawing.Size(54, 19);
            this.lblEGenero.TabIndex = 37;
            this.lblEGenero.Text = "Genero";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAceptar.Location = new System.Drawing.Point(422, 315);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(82, 23);
            this.btnAceptar.TabIndex = 36;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "Semanal",
            "1 Mes",
            "2 Meses",
            "3 Meses",
            "4 Meses",
            "5 Meses",
            "6 Meses",
            "7 Meses",
            "8 Meses",
            "9 Meses",
            "10 Meses",
            "11 Meses",
            "12 Meses"});
            this.cboTipo.Location = new System.Drawing.Point(261, 141);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(243, 27);
            this.cboTipo.TabIndex = 35;
            // 
            // lblEDuracion
            // 
            this.lblEDuracion.AutoSize = true;
            this.lblEDuracion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEDuracion.Location = new System.Drawing.Point(257, 119);
            this.lblEDuracion.Name = "lblEDuracion";
            this.lblEDuracion.Size = new System.Drawing.Size(64, 19);
            this.lblEDuracion.TabIndex = 34;
            this.lblEDuracion.Text = "Duración";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrecio.Location = new System.Drawing.Point(261, 86);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(243, 25);
            this.txtPrecio.TabIndex = 33;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // lblEPrecio
            // 
            this.lblEPrecio.AutoSize = true;
            this.lblEPrecio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEPrecio.Location = new System.Drawing.Point(257, 64);
            this.lblEPrecio.Name = "lblEPrecio";
            this.lblEPrecio.Size = new System.Drawing.Size(46, 19);
            this.lblEPrecio.TabIndex = 32;
            this.lblEPrecio.Text = "Precio";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescripcion.Location = new System.Drawing.Point(12, 86);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(243, 82);
            this.txtDescripcion.TabIndex = 31;
            // 
            // lblEDescripcion
            // 
            this.lblEDescripcion.AutoSize = true;
            this.lblEDescripcion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEDescripcion.Location = new System.Drawing.Point(8, 64);
            this.lblEDescripcion.Name = "lblEDescripcion";
            this.lblEDescripcion.Size = new System.Drawing.Size(79, 19);
            this.lblEDescripcion.TabIndex = 30;
            this.lblEDescripcion.Text = "Descripción";
            // 
            // lblEFechaFin
            // 
            this.lblEFechaFin.AutoSize = true;
            this.lblEFechaFin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEFechaFin.Location = new System.Drawing.Point(257, 9);
            this.lblEFechaFin.Name = "lblEFechaFin";
            this.lblEFechaFin.Size = new System.Drawing.Size(139, 19);
            this.lblEFechaFin.TabIndex = 29;
            this.lblEFechaFin.Text = "Fecha de terminación";
            // 
            // dtpHoraFin
            // 
            this.dtpHoraFin.CustomFormat = "hh:mm tt";
            this.dtpHoraFin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraFin.Location = new System.Drawing.Point(261, 31);
            this.dtpHoraFin.Name = "dtpHoraFin";
            this.dtpHoraFin.ShowUpDown = true;
            this.dtpHoraFin.Size = new System.Drawing.Size(243, 25);
            this.dtpHoraFin.TabIndex = 28;
            // 
            // lblEFechaInicio
            // 
            this.lblEFechaInicio.AutoSize = true;
            this.lblEFechaInicio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEFechaInicio.Location = new System.Drawing.Point(8, 9);
            this.lblEFechaInicio.Name = "lblEFechaInicio";
            this.lblEFechaInicio.Size = new System.Drawing.Size(98, 19);
            this.lblEFechaInicio.TabIndex = 27;
            this.lblEFechaInicio.Text = "Fecha de inicio";
            // 
            // dtpHoraInicio
            // 
            this.dtpHoraInicio.CustomFormat = "hh:mm tt";
            this.dtpHoraInicio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraInicio.Location = new System.Drawing.Point(12, 31);
            this.dtpHoraInicio.Name = "dtpHoraInicio";
            this.dtpHoraInicio.ShowUpDown = true;
            this.dtpHoraInicio.Size = new System.Drawing.Size(243, 25);
            this.dtpHoraInicio.TabIndex = 26;
            // 
            // grbDatos
            // 
            this.grbDatos.Controls.Add(this.lblUpdateUser);
            this.grbDatos.Controls.Add(this.lblEUpdateUser);
            this.grbDatos.Controls.Add(this.lblUpdateTime);
            this.grbDatos.Controls.Add(this.lblEUpdateTime);
            this.grbDatos.Controls.Add(this.lblCreateTime);
            this.grbDatos.Controls.Add(this.lblECreateTime);
            this.grbDatos.Controls.Add(this.lblCreateUser);
            this.grbDatos.Controls.Add(this.lblECreateUser);
            this.grbDatos.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.grbDatos.Location = new System.Drawing.Point(12, 238);
            this.grbDatos.Name = "grbDatos";
            this.grbDatos.Size = new System.Drawing.Size(320, 100);
            this.grbDatos.TabIndex = 39;
            this.grbDatos.TabStop = false;
            this.grbDatos.Text = "Datos de promoción";
            // 
            // lblUpdateUser
            // 
            this.lblUpdateUser.AutoSize = true;
            this.lblUpdateUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUpdateUser.Location = new System.Drawing.Point(125, 58);
            this.lblUpdateUser.Name = "lblUpdateUser";
            this.lblUpdateUser.Size = new System.Drawing.Size(94, 15);
            this.lblUpdateUser.TabIndex = 7;
            this.lblUpdateUser.Text = "Sin información";
            // 
            // lblEUpdateUser
            // 
            this.lblEUpdateUser.AutoSize = true;
            this.lblEUpdateUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEUpdateUser.Location = new System.Drawing.Point(6, 58);
            this.lblEUpdateUser.Name = "lblEUpdateUser";
            this.lblEUpdateUser.Size = new System.Drawing.Size(118, 15);
            this.lblEUpdateUser.TabIndex = 6;
            this.lblEUpdateUser.Text = "Usuario modificador:";
            // 
            // lblUpdateTime
            // 
            this.lblUpdateTime.AutoSize = true;
            this.lblUpdateTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUpdateTime.Location = new System.Drawing.Point(125, 78);
            this.lblUpdateTime.Name = "lblUpdateTime";
            this.lblUpdateTime.Size = new System.Drawing.Size(94, 15);
            this.lblUpdateTime.TabIndex = 5;
            this.lblUpdateTime.Text = "Sin información";
            // 
            // lblEUpdateTime
            // 
            this.lblEUpdateTime.AutoSize = true;
            this.lblEUpdateTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEUpdateTime.Location = new System.Drawing.Point(5, 78);
            this.lblEUpdateTime.Name = "lblEUpdateTime";
            this.lblEUpdateTime.Size = new System.Drawing.Size(114, 15);
            this.lblEUpdateTime.TabIndex = 4;
            this.lblEUpdateTime.Text = "Fecha modificación:";
            // 
            // lblCreateTime
            // 
            this.lblCreateTime.AutoSize = true;
            this.lblCreateTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCreateTime.Location = new System.Drawing.Point(125, 38);
            this.lblCreateTime.Name = "lblCreateTime";
            this.lblCreateTime.Size = new System.Drawing.Size(94, 15);
            this.lblCreateTime.TabIndex = 3;
            this.lblCreateTime.Text = "Sin información";
            // 
            // lblECreateTime
            // 
            this.lblECreateTime.AutoSize = true;
            this.lblECreateTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblECreateTime.Location = new System.Drawing.Point(30, 38);
            this.lblECreateTime.Name = "lblECreateTime";
            this.lblECreateTime.Size = new System.Drawing.Size(89, 15);
            this.lblECreateTime.TabIndex = 2;
            this.lblECreateTime.Text = "Fecha creación:";
            // 
            // lblCreateUser
            // 
            this.lblCreateUser.AutoSize = true;
            this.lblCreateUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCreateUser.Location = new System.Drawing.Point(125, 18);
            this.lblCreateUser.Name = "lblCreateUser";
            this.lblCreateUser.Size = new System.Drawing.Size(94, 15);
            this.lblCreateUser.TabIndex = 1;
            this.lblCreateUser.Text = "Sin información";
            // 
            // lblECreateUser
            // 
            this.lblECreateUser.AutoSize = true;
            this.lblECreateUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblECreateUser.Location = new System.Drawing.Point(26, 18);
            this.lblECreateUser.Name = "lblECreateUser";
            this.lblECreateUser.Size = new System.Drawing.Size(93, 15);
            this.lblECreateUser.TabIndex = 0;
            this.lblECreateUser.Text = "Usuario creador:";
            // 
            // frmEditarPromocionHorario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 350);
            this.Controls.Add(this.grbDatos);
            this.Controls.Add(this.cboGenero);
            this.Controls.Add(this.lblEGenero);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.lblEDuracion);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.lblEPrecio);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblEDescripcion);
            this.Controls.Add(this.lblEFechaFin);
            this.Controls.Add(this.dtpHoraFin);
            this.Controls.Add(this.lblEFechaInicio);
            this.Controls.Add(this.dtpHoraInicio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEditarPromocionHorario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar promoción";
            this.Load += new System.EventHandler(this.frmEditarPromocionHorario_Load);
            this.grbDatos.ResumeLayout(false);
            this.grbDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboGenero;
        private System.Windows.Forms.Label lblEGenero;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Label lblEDuracion;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblEPrecio;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblEDescripcion;
        private System.Windows.Forms.Label lblEFechaFin;
        private System.Windows.Forms.DateTimePicker dtpHoraFin;
        private System.Windows.Forms.Label lblEFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpHoraInicio;
        private System.Windows.Forms.GroupBox grbDatos;
        private System.Windows.Forms.Label lblUpdateUser;
        private System.Windows.Forms.Label lblEUpdateUser;
        private System.Windows.Forms.Label lblUpdateTime;
        private System.Windows.Forms.Label lblEUpdateTime;
        private System.Windows.Forms.Label lblCreateTime;
        private System.Windows.Forms.Label lblECreateTime;
        private System.Windows.Forms.Label lblCreateUser;
        private System.Windows.Forms.Label lblECreateUser;
    }
}