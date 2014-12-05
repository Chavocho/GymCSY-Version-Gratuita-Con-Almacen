namespace GYM.Formularios.Reporte
{
    partial class frmOpcionesAvanzadasUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpcionesAvanzadasUsuario));
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabRegiones = new System.Windows.Forms.TabPage();
            this.txtboxPiePagina = new System.Windows.Forms.TextBox();
            this.chboxPiePagina = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtboxObservacionReporte = new System.Windows.Forms.TextBox();
            this.chboxNumeroPaginasReporte = new System.Windows.Forms.CheckBox();
            this.chboxObservacionesArchivoReporte = new System.Windows.Forms.CheckBox();
            this.chboxDatosUsuarioCreadorReporte = new System.Windows.Forms.CheckBox();
            this.chboxHoraCreacionReporte = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabRegiones.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(357, 216);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Salir";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabRegiones);
            this.tabControl1.Location = new System.Drawing.Point(0, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(447, 205);
            this.tabControl1.TabIndex = 5;
            // 
            // tabRegiones
            // 
            this.tabRegiones.Controls.Add(this.txtboxPiePagina);
            this.tabRegiones.Controls.Add(this.chboxPiePagina);
            this.tabRegiones.Controls.Add(this.button1);
            this.tabRegiones.Controls.Add(this.txtboxObservacionReporte);
            this.tabRegiones.Controls.Add(this.chboxNumeroPaginasReporte);
            this.tabRegiones.Controls.Add(this.chboxObservacionesArchivoReporte);
            this.tabRegiones.Controls.Add(this.chboxDatosUsuarioCreadorReporte);
            this.tabRegiones.Controls.Add(this.chboxHoraCreacionReporte);
            this.tabRegiones.Location = new System.Drawing.Point(4, 22);
            this.tabRegiones.Name = "tabRegiones";
            this.tabRegiones.Padding = new System.Windows.Forms.Padding(3);
            this.tabRegiones.Size = new System.Drawing.Size(439, 179);
            this.tabRegiones.TabIndex = 2;
            this.tabRegiones.Text = "Agregar al reporte";
            this.tabRegiones.UseVisualStyleBackColor = true;
            // 
            // txtboxPiePagina
            // 
            this.txtboxPiePagina.Enabled = false;
            this.txtboxPiePagina.Location = new System.Drawing.Point(19, 109);
            this.txtboxPiePagina.MaxLength = 25;
            this.txtboxPiePagina.Name = "txtboxPiePagina";
            this.txtboxPiePagina.Size = new System.Drawing.Size(154, 20);
            this.txtboxPiePagina.TabIndex = 39;
            // 
            // chboxPiePagina
            // 
            this.chboxPiePagina.AutoSize = true;
            this.chboxPiePagina.Location = new System.Drawing.Point(18, 86);
            this.chboxPiePagina.Name = "chboxPiePagina";
            this.chboxPiePagina.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxPiePagina.Size = new System.Drawing.Size(91, 17);
            this.chboxPiePagina.TabIndex = 38;
            this.chboxPiePagina.Text = "Pie de página";
            this.chboxPiePagina.UseVisualStyleBackColor = true;
            this.chboxPiePagina.CheckedChanged += new System.EventHandler(this.chboxPiePagina_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(199, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 23);
            this.button1.TabIndex = 37;
            this.button1.Text = "Editar encabezado";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtboxObservacionReporte
            // 
            this.txtboxObservacionReporte.Enabled = false;
            this.txtboxObservacionReporte.Location = new System.Drawing.Point(199, 84);
            this.txtboxObservacionReporte.Multiline = true;
            this.txtboxObservacionReporte.Name = "txtboxObservacionReporte";
            this.txtboxObservacionReporte.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtboxObservacionReporte.Size = new System.Drawing.Size(232, 39);
            this.txtboxObservacionReporte.TabIndex = 35;
            // 
            // chboxNumeroPaginasReporte
            // 
            this.chboxNumeroPaginasReporte.AutoSize = true;
            this.chboxNumeroPaginasReporte.Checked = true;
            this.chboxNumeroPaginasReporte.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chboxNumeroPaginasReporte.Location = new System.Drawing.Point(18, 18);
            this.chboxNumeroPaginasReporte.Name = "chboxNumeroPaginasReporte";
            this.chboxNumeroPaginasReporte.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxNumeroPaginasReporte.Size = new System.Drawing.Size(118, 17);
            this.chboxNumeroPaginasReporte.TabIndex = 0;
            this.chboxNumeroPaginasReporte.Text = "Numero de paginas";
            this.chboxNumeroPaginasReporte.UseVisualStyleBackColor = true;
            // 
            // chboxObservacionesArchivoReporte
            // 
            this.chboxObservacionesArchivoReporte.AutoSize = true;
            this.chboxObservacionesArchivoReporte.Location = new System.Drawing.Point(199, 62);
            this.chboxObservacionesArchivoReporte.Name = "chboxObservacionesArchivoReporte";
            this.chboxObservacionesArchivoReporte.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxObservacionesArchivoReporte.Size = new System.Drawing.Size(185, 17);
            this.chboxObservacionesArchivoReporte.TabIndex = 31;
            this.chboxObservacionesArchivoReporte.Text = "Observaciones al final del archivo";
            this.chboxObservacionesArchivoReporte.UseVisualStyleBackColor = true;
            this.chboxObservacionesArchivoReporte.CheckedChanged += new System.EventHandler(this.chboxObservacionesArchivoReporte_CheckedChanged);
            // 
            // chboxDatosUsuarioCreadorReporte
            // 
            this.chboxDatosUsuarioCreadorReporte.AutoSize = true;
            this.chboxDatosUsuarioCreadorReporte.Location = new System.Drawing.Point(19, 40);
            this.chboxDatosUsuarioCreadorReporte.Name = "chboxDatosUsuarioCreadorReporte";
            this.chboxDatosUsuarioCreadorReporte.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxDatosUsuarioCreadorReporte.Size = new System.Drawing.Size(147, 17);
            this.chboxDatosUsuarioCreadorReporte.TabIndex = 29;
            this.chboxDatosUsuarioCreadorReporte.Text = "Datos del usuario creador";
            this.chboxDatosUsuarioCreadorReporte.UseVisualStyleBackColor = true;
            // 
            // chboxHoraCreacionReporte
            // 
            this.chboxHoraCreacionReporte.AutoSize = true;
            this.chboxHoraCreacionReporte.Location = new System.Drawing.Point(19, 63);
            this.chboxHoraCreacionReporte.Name = "chboxHoraCreacionReporte";
            this.chboxHoraCreacionReporte.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxHoraCreacionReporte.Size = new System.Drawing.Size(108, 17);
            this.chboxHoraCreacionReporte.TabIndex = 30;
            this.chboxHoraCreacionReporte.Text = "Hora de creacion";
            this.chboxHoraCreacionReporte.UseVisualStyleBackColor = true;
            // 
            // frmOpcionesAvanzadasUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 244);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOpcionesAvanzadasUsuario";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Opciones avanzadas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOpcionesAvanzadasUsuario_FormClosing);
            this.Load += new System.EventHandler(this.frmOpcionesAvanzadasUsuario_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabRegiones.ResumeLayout(false);
            this.tabRegiones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage tabRegiones;
        public System.Windows.Forms.TextBox txtboxObservacionReporte;
        public System.Windows.Forms.CheckBox chboxNumeroPaginasReporte;
        public System.Windows.Forms.CheckBox chboxObservacionesArchivoReporte;
        public System.Windows.Forms.CheckBox chboxDatosUsuarioCreadorReporte;
        public System.Windows.Forms.CheckBox chboxHoraCreacionReporte;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox txtboxPiePagina;
        public System.Windows.Forms.CheckBox chboxPiePagina;
    }
}