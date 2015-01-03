namespace GYM.Formularios.Membresia
{
    partial class frmEditarMembresia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditarMembresia));
            this.lblEtiquetaFechaFin = new System.Windows.Forms.Label();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.lblNombreMiembro = new System.Windows.Forms.Label();
            this.lblEtiquetaDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblEtiquetaFolioRemision = new System.Windows.Forms.Label();
            this.txtFolio = new System.Windows.Forms.TextBox();
            this.lblEtiquetaPrecio = new System.Windows.Forms.Label();
            this.lblEtiquetaFechaInicio = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblEtiquetaTipo = new System.Windows.Forms.Label();
            this.cbxTipo = new System.Windows.Forms.ComboBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.cbxTipoPago = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFolioTicket = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTerminacion = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.btnAsignarPromo = new System.Windows.Forms.Button();
            this.btnQuitarPromo = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblEtiquetaFechaFin
            // 
            this.lblEtiquetaFechaFin.AutoSize = true;
            this.lblEtiquetaFechaFin.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblEtiquetaFechaFin.Location = new System.Drawing.Point(400, 39);
            this.lblEtiquetaFechaFin.Name = "lblEtiquetaFechaFin";
            this.lblEtiquetaFechaFin.Size = new System.Drawing.Size(141, 19);
            this.lblEtiquetaFechaFin.TabIndex = 6;
            this.lblEtiquetaFechaFin.Text = "Fecha de vencimiento";
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFechaFin.Location = new System.Drawing.Point(400, 62);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(0, 21);
            this.lblFechaFin.TabIndex = 7;
            // 
            // lblNombreMiembro
            // 
            this.lblNombreMiembro.AutoSize = true;
            this.lblNombreMiembro.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblNombreMiembro.Location = new System.Drawing.Point(430, 2);
            this.lblNombreMiembro.Name = "lblNombreMiembro";
            this.lblNombreMiembro.Size = new System.Drawing.Size(214, 21);
            this.lblNombreMiembro.TabIndex = 1;
            this.lblNombreMiembro.Text = "Añadir una nueva membresía";
            // 
            // lblEtiquetaDescripcion
            // 
            this.lblEtiquetaDescripcion.AutoSize = true;
            this.lblEtiquetaDescripcion.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblEtiquetaDescripcion.Location = new System.Drawing.Point(403, 177);
            this.lblEtiquetaDescripcion.Name = "lblEtiquetaDescripcion";
            this.lblEtiquetaDescripcion.Size = new System.Drawing.Size(79, 19);
            this.lblEtiquetaDescripcion.TabIndex = 20;
            this.lblEtiquetaDescripcion.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Enabled = false;
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtDescripcion.Location = new System.Drawing.Point(404, 199);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(240, 96);
            this.txtDescripcion.TabIndex = 21;
            // 
            // lblEtiquetaFolioRemision
            // 
            this.lblEtiquetaFolioRemision.AutoSize = true;
            this.lblEtiquetaFolioRemision.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblEtiquetaFolioRemision.Location = new System.Drawing.Point(206, 177);
            this.lblEtiquetaFolioRemision.Name = "lblEtiquetaFolioRemision";
            this.lblEtiquetaFolioRemision.Size = new System.Drawing.Size(94, 19);
            this.lblEtiquetaFolioRemision.TabIndex = 14;
            this.lblEtiquetaFolioRemision.Text = "Folio remisión";
            // 
            // txtFolio
            // 
            this.txtFolio.Enabled = false;
            this.txtFolio.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtFolio.Location = new System.Drawing.Point(210, 199);
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.Size = new System.Drawing.Size(178, 26);
            this.txtFolio.TabIndex = 15;
            this.txtFolio.LostFocus += new System.EventHandler(this.txtFolio_LostFocus);
            // 
            // lblEtiquetaPrecio
            // 
            this.lblEtiquetaPrecio.AutoSize = true;
            this.lblEtiquetaPrecio.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblEtiquetaPrecio.Location = new System.Drawing.Point(12, 177);
            this.lblEtiquetaPrecio.Name = "lblEtiquetaPrecio";
            this.lblEtiquetaPrecio.Size = new System.Drawing.Size(46, 19);
            this.lblEtiquetaPrecio.TabIndex = 12;
            this.lblEtiquetaPrecio.Text = "Precio";
            // 
            // lblEtiquetaFechaInicio
            // 
            this.lblEtiquetaFechaInicio.AutoSize = true;
            this.lblEtiquetaFechaInicio.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblEtiquetaFechaInicio.Location = new System.Drawing.Point(206, 40);
            this.lblEtiquetaFechaInicio.Name = "lblEtiquetaFechaInicio";
            this.lblEtiquetaFechaInicio.Size = new System.Drawing.Size(98, 19);
            this.lblEtiquetaFechaInicio.TabIndex = 4;
            this.lblEtiquetaFechaInicio.Text = "Fecha de inicio";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CustomFormat = "dd/MMMM/yyyy";
            this.dtpFechaInicio.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaInicio.Location = new System.Drawing.Point(210, 62);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(178, 26);
            this.dtpFechaInicio.TabIndex = 5;
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.dtpFechaInicio_ValueChanged);
            // 
            // lblEtiquetaTipo
            // 
            this.lblEtiquetaTipo.AutoSize = true;
            this.lblEtiquetaTipo.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblEtiquetaTipo.Location = new System.Drawing.Point(12, 39);
            this.lblEtiquetaTipo.Name = "lblEtiquetaTipo";
            this.lblEtiquetaTipo.Size = new System.Drawing.Size(64, 19);
            this.lblEtiquetaTipo.TabIndex = 2;
            this.lblEtiquetaTipo.Text = "Duración";
            // 
            // cbxTipo
            // 
            this.cbxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipo.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cbxTipo.FormattingEnabled = true;
            this.cbxTipo.Items.AddRange(new object[] {
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
            this.cbxTipo.Location = new System.Drawing.Point(16, 61);
            this.cbxTipo.Name = "cbxTipo";
            this.cbxTipo.Size = new System.Drawing.Size(178, 27);
            this.cbxTipo.TabIndex = 3;
            this.cbxTipo.SelectedIndexChanged += new System.EventHandler(this.cbxTipo_SelectedIndexChanged);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTitulo.Location = new System.Drawing.Point(12, 2);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(215, 21);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Renovar membresía existente";
            // 
            // cbxTipoPago
            // 
            this.cbxTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoPago.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cbxTipoPago.FormattingEnabled = true;
            this.cbxTipoPago.Items.AddRange(new object[] {
            "Efectivo",
            "Tarjeta"});
            this.cbxTipoPago.Location = new System.Drawing.Point(16, 132);
            this.cbxTipoPago.Name = "cbxTipoPago";
            this.cbxTipoPago.Size = new System.Drawing.Size(178, 27);
            this.cbxTipoPago.TabIndex = 9;
            this.cbxTipoPago.SelectedIndexChanged += new System.EventHandler(this.cbxTipoPago_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.label1.Location = new System.Drawing.Point(15, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tipo de pago";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.label3.Location = new System.Drawing.Point(206, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 19);
            this.label3.TabIndex = 18;
            this.label3.Text = "Folio ticket terminal";
            // 
            // txtFolioTicket
            // 
            this.txtFolioTicket.Enabled = false;
            this.txtFolioTicket.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtFolioTicket.Location = new System.Drawing.Point(210, 269);
            this.txtFolioTicket.Name = "txtFolioTicket";
            this.txtFolioTicket.Size = new System.Drawing.Size(178, 26);
            this.txtFolioTicket.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.label2.Location = new System.Drawing.Point(12, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 19);
            this.label2.TabIndex = 16;
            this.label2.Text = "Terminación tarjeta";
            // 
            // txtTerminacion
            // 
            this.txtTerminacion.Enabled = false;
            this.txtTerminacion.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtTerminacion.Location = new System.Drawing.Point(16, 269);
            this.txtTerminacion.Name = "txtTerminacion";
            this.txtTerminacion.Size = new System.Drawing.Size(178, 26);
            this.txtTerminacion.TabIndex = 17;
            this.txtTerminacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmEditarMembresia_KeyPress);
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblPrecio.Location = new System.Drawing.Point(12, 202);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(45, 19);
            this.lblPrecio.TabIndex = 13;
            this.lblPrecio.Text = "$0.00";
            // 
            // btnAsignarPromo
            // 
            this.btnAsignarPromo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnAsignarPromo.Location = new System.Drawing.Point(210, 132);
            this.btnAsignarPromo.Name = "btnAsignarPromo";
            this.btnAsignarPromo.Size = new System.Drawing.Size(178, 27);
            this.btnAsignarPromo.TabIndex = 10;
            this.btnAsignarPromo.Text = "Asignar promoción";
            this.btnAsignarPromo.UseVisualStyleBackColor = true;
            this.btnAsignarPromo.Click += new System.EventHandler(this.btnAsignarPromo_Click);
            // 
            // btnQuitarPromo
            // 
            this.btnQuitarPromo.Enabled = false;
            this.btnQuitarPromo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnQuitarPromo.Location = new System.Drawing.Point(404, 132);
            this.btnQuitarPromo.Name = "btnQuitarPromo";
            this.btnQuitarPromo.Size = new System.Drawing.Size(178, 27);
            this.btnQuitarPromo.TabIndex = 11;
            this.btnQuitarPromo.Text = "Quitar promoción";
            this.btnQuitarPromo.UseVisualStyleBackColor = true;
            this.btnQuitarPromo.Click += new System.EventHandler(this.btnQuitarPromo_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnAceptar.Image = global::GYM.Properties.Resources.ImgAceptar;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(539, 345);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(105, 40);
            this.btnAceptar.TabIndex = 22;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmEditarMembresia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 397);
            this.Controls.Add(this.btnQuitarPromo);
            this.Controls.Add(this.btnAsignarPromo);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFolioTicket);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTerminacion);
            this.Controls.Add(this.cbxTipoPago);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblEtiquetaFechaFin);
            this.Controls.Add(this.lblFechaFin);
            this.Controls.Add(this.lblNombreMiembro);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblEtiquetaDescripcion);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblEtiquetaFolioRemision);
            this.Controls.Add(this.txtFolio);
            this.Controls.Add(this.lblEtiquetaPrecio);
            this.Controls.Add(this.lblEtiquetaFechaInicio);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.lblEtiquetaTipo);
            this.Controls.Add(this.cbxTipo);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEditarMembresia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Renovar membresía";
            this.Load += new System.EventHandler(this.frmEditarMembresia_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmEditarMembresia_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEtiquetaFechaFin;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Label lblNombreMiembro;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblEtiquetaDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblEtiquetaFolioRemision;
        private System.Windows.Forms.TextBox txtFolio;
        private System.Windows.Forms.Label lblEtiquetaPrecio;
        private System.Windows.Forms.Label lblEtiquetaFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblEtiquetaTipo;
        private System.Windows.Forms.ComboBox cbxTipo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ComboBox cbxTipoPago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFolioTicket;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTerminacion;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Button btnAsignarPromo;
        private System.Windows.Forms.Button btnQuitarPromo;


    }
}