namespace GYM.Formularios.Membresia
{
    partial class frmNuevaPromocion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevaPromocion));
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblEFechaInicio = new System.Windows.Forms.Label();
            this.lblEFechaFin = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.lblEDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblEPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblEDuracion = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblEGenero = new System.Windows.Forms.Label();
            this.cboGenero = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFechaInicio.Location = new System.Drawing.Point(12, 31);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(243, 25);
            this.dtpFechaInicio.TabIndex = 1;
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.dtpFechas_ValueChanged);
            // 
            // lblEFechaInicio
            // 
            this.lblEFechaInicio.AutoSize = true;
            this.lblEFechaInicio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEFechaInicio.Location = new System.Drawing.Point(8, 9);
            this.lblEFechaInicio.Name = "lblEFechaInicio";
            this.lblEFechaInicio.Size = new System.Drawing.Size(98, 19);
            this.lblEFechaInicio.TabIndex = 0;
            this.lblEFechaInicio.Text = "Fecha de inicio";
            // 
            // lblEFechaFin
            // 
            this.lblEFechaFin.AutoSize = true;
            this.lblEFechaFin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEFechaFin.Location = new System.Drawing.Point(257, 9);
            this.lblEFechaFin.Name = "lblEFechaFin";
            this.lblEFechaFin.Size = new System.Drawing.Size(139, 19);
            this.lblEFechaFin.TabIndex = 2;
            this.lblEFechaFin.Text = "Fecha de terminación";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFechaFin.Location = new System.Drawing.Point(261, 31);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(243, 25);
            this.dtpFechaFin.TabIndex = 3;
            this.dtpFechaFin.ValueChanged += new System.EventHandler(this.dtpFechas_ValueChanged);
            // 
            // lblEDescripcion
            // 
            this.lblEDescripcion.AutoSize = true;
            this.lblEDescripcion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEDescripcion.Location = new System.Drawing.Point(8, 64);
            this.lblEDescripcion.Name = "lblEDescripcion";
            this.lblEDescripcion.Size = new System.Drawing.Size(79, 19);
            this.lblEDescripcion.TabIndex = 4;
            this.lblEDescripcion.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescripcion.Location = new System.Drawing.Point(12, 86);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(243, 82);
            this.txtDescripcion.TabIndex = 5;
            // 
            // lblEPrecio
            // 
            this.lblEPrecio.AutoSize = true;
            this.lblEPrecio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEPrecio.Location = new System.Drawing.Point(257, 64);
            this.lblEPrecio.Name = "lblEPrecio";
            this.lblEPrecio.Size = new System.Drawing.Size(46, 19);
            this.lblEPrecio.TabIndex = 6;
            this.lblEPrecio.Text = "Precio";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrecio.Location = new System.Drawing.Point(261, 86);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(243, 25);
            this.txtPrecio.TabIndex = 7;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // lblEDuracion
            // 
            this.lblEDuracion.AutoSize = true;
            this.lblEDuracion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEDuracion.Location = new System.Drawing.Point(257, 119);
            this.lblEDuracion.Name = "lblEDuracion";
            this.lblEDuracion.Size = new System.Drawing.Size(64, 19);
            this.lblEDuracion.TabIndex = 8;
            this.lblEDuracion.Text = "Duración";
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
            this.cboTipo.TabIndex = 9;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAceptar.Location = new System.Drawing.Point(422, 244);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(82, 23);
            this.btnAceptar.TabIndex = 12;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblEGenero
            // 
            this.lblEGenero.AutoSize = true;
            this.lblEGenero.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEGenero.Location = new System.Drawing.Point(8, 176);
            this.lblEGenero.Name = "lblEGenero";
            this.lblEGenero.Size = new System.Drawing.Size(54, 19);
            this.lblEGenero.TabIndex = 10;
            this.lblEGenero.Text = "Genero";
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
            this.cboGenero.TabIndex = 11;
            // 
            // frmNuevaPromocion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 279);
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
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.lblEFechaInicio);
            this.Controls.Add(this.dtpFechaInicio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmNuevaPromocion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva Promoción";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblEFechaInicio;
        private System.Windows.Forms.Label lblEFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label lblEDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblEPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblEDuracion;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblEGenero;
        private System.Windows.Forms.ComboBox cboGenero;
    }
}