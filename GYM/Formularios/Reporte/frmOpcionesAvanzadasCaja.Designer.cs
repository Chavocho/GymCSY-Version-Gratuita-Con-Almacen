namespace GYM.Formularios.Reporte
{
    partial class frmOpcionesAvanzadasCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpcionesAvanzadasCaja));
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCaja = new System.Windows.Forms.TabPage();
            this.chboxSubtotalCaja = new System.Windows.Forms.CheckBox();
            this.chboxUsuarioCreadorCaja = new System.Windows.Forms.CheckBox();
            this.chboxDescripcionCaja = new System.Windows.Forms.CheckBox();
            this.chboxIdentificadorVentaCaja = new System.Windows.Forms.CheckBox();
            this.chboxFechaCaja = new System.Windows.Forms.CheckBox();
            this.chboxEfectivoCaja = new System.Windows.Forms.CheckBox();
            this.chboxTarjetaCaja = new System.Windows.Forms.CheckBox();
            this.chboxTipoMovimientoCaja = new System.Windows.Forms.CheckBox();
            this.tabRegiones = new System.Windows.Forms.TabPage();
            this.txtboxPiePagina = new System.Windows.Forms.TextBox();
            this.chboxPiePagina = new System.Windows.Forms.CheckBox();
            this.btnEditarEncabezado = new System.Windows.Forms.Button();
            this.txtboxObservacionReporte = new System.Windows.Forms.TextBox();
            this.chboxNumeroPaginasReporte = new System.Windows.Forms.CheckBox();
            this.chboxObservacionesArchivoReporte = new System.Windows.Forms.CheckBox();
            this.chboxDatosUsuarioCreadorReporte = new System.Windows.Forms.CheckBox();
            this.chboxHoraCreacionReporte = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabCaja.SuspendLayout();
            this.tabRegiones.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(358, 216);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Salir";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCaja);
            this.tabControl1.Controls.Add(this.tabRegiones);
            this.tabControl1.Location = new System.Drawing.Point(0, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(447, 205);
            this.tabControl1.TabIndex = 4;
            // 
            // tabCaja
            // 
            this.tabCaja.Controls.Add(this.chboxSubtotalCaja);
            this.tabCaja.Controls.Add(this.chboxUsuarioCreadorCaja);
            this.tabCaja.Controls.Add(this.chboxDescripcionCaja);
            this.tabCaja.Controls.Add(this.chboxIdentificadorVentaCaja);
            this.tabCaja.Controls.Add(this.chboxFechaCaja);
            this.tabCaja.Controls.Add(this.chboxEfectivoCaja);
            this.tabCaja.Controls.Add(this.chboxTarjetaCaja);
            this.tabCaja.Controls.Add(this.chboxTipoMovimientoCaja);
            this.tabCaja.Location = new System.Drawing.Point(4, 22);
            this.tabCaja.Name = "tabCaja";
            this.tabCaja.Padding = new System.Windows.Forms.Padding(3);
            this.tabCaja.Size = new System.Drawing.Size(439, 179);
            this.tabCaja.TabIndex = 0;
            this.tabCaja.Text = "Movimientos en la caja";
            this.tabCaja.UseVisualStyleBackColor = true;
            // 
            // chboxSubtotalCaja
            // 
            this.chboxSubtotalCaja.AutoSize = true;
            this.chboxSubtotalCaja.Location = new System.Drawing.Point(177, 66);
            this.chboxSubtotalCaja.Name = "chboxSubtotalCaja";
            this.chboxSubtotalCaja.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxSubtotalCaja.Size = new System.Drawing.Size(65, 17);
            this.chboxSubtotalCaja.TabIndex = 34;
            this.chboxSubtotalCaja.Text = "Subtotal";
            this.chboxSubtotalCaja.UseVisualStyleBackColor = true;
            // 
            // chboxUsuarioCreadorCaja
            // 
            this.chboxUsuarioCreadorCaja.AutoSize = true;
            this.chboxUsuarioCreadorCaja.Location = new System.Drawing.Point(177, 89);
            this.chboxUsuarioCreadorCaja.Name = "chboxUsuarioCreadorCaja";
            this.chboxUsuarioCreadorCaja.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxUsuarioCreadorCaja.Size = new System.Drawing.Size(101, 17);
            this.chboxUsuarioCreadorCaja.TabIndex = 32;
            this.chboxUsuarioCreadorCaja.Text = "Usuario creador";
            this.chboxUsuarioCreadorCaja.UseVisualStyleBackColor = true;
            // 
            // chboxDescripcionCaja
            // 
            this.chboxDescripcionCaja.AutoSize = true;
            this.chboxDescripcionCaja.Checked = true;
            this.chboxDescripcionCaja.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chboxDescripcionCaja.Location = new System.Drawing.Point(177, 43);
            this.chboxDescripcionCaja.Name = "chboxDescripcionCaja";
            this.chboxDescripcionCaja.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxDescripcionCaja.Size = new System.Drawing.Size(77, 17);
            this.chboxDescripcionCaja.TabIndex = 28;
            this.chboxDescripcionCaja.Text = "Decripción";
            this.chboxDescripcionCaja.UseVisualStyleBackColor = true;
            // 
            // chboxIdentificadorVentaCaja
            // 
            this.chboxIdentificadorVentaCaja.AutoSize = true;
            this.chboxIdentificadorVentaCaja.Checked = true;
            this.chboxIdentificadorVentaCaja.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chboxIdentificadorVentaCaja.Location = new System.Drawing.Point(19, 20);
            this.chboxIdentificadorVentaCaja.Name = "chboxIdentificadorVentaCaja";
            this.chboxIdentificadorVentaCaja.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxIdentificadorVentaCaja.Size = new System.Drawing.Size(129, 17);
            this.chboxIdentificadorVentaCaja.TabIndex = 0;
            this.chboxIdentificadorVentaCaja.Text = "Identificador de venta";
            this.chboxIdentificadorVentaCaja.UseVisualStyleBackColor = true;
            // 
            // chboxFechaCaja
            // 
            this.chboxFechaCaja.AutoSize = true;
            this.chboxFechaCaja.Location = new System.Drawing.Point(177, 20);
            this.chboxFechaCaja.Name = "chboxFechaCaja";
            this.chboxFechaCaja.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxFechaCaja.Size = new System.Drawing.Size(56, 17);
            this.chboxFechaCaja.TabIndex = 27;
            this.chboxFechaCaja.Text = "Fecha";
            this.chboxFechaCaja.UseVisualStyleBackColor = true;
            // 
            // chboxEfectivoCaja
            // 
            this.chboxEfectivoCaja.AutoSize = true;
            this.chboxEfectivoCaja.Checked = true;
            this.chboxEfectivoCaja.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chboxEfectivoCaja.Location = new System.Drawing.Point(19, 43);
            this.chboxEfectivoCaja.Name = "chboxEfectivoCaja";
            this.chboxEfectivoCaja.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxEfectivoCaja.Size = new System.Drawing.Size(65, 17);
            this.chboxEfectivoCaja.TabIndex = 1;
            this.chboxEfectivoCaja.Text = "Efectivo";
            this.chboxEfectivoCaja.UseVisualStyleBackColor = true;
            // 
            // chboxTarjetaCaja
            // 
            this.chboxTarjetaCaja.AutoSize = true;
            this.chboxTarjetaCaja.Checked = true;
            this.chboxTarjetaCaja.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chboxTarjetaCaja.Location = new System.Drawing.Point(19, 66);
            this.chboxTarjetaCaja.Name = "chboxTarjetaCaja";
            this.chboxTarjetaCaja.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxTarjetaCaja.Size = new System.Drawing.Size(59, 17);
            this.chboxTarjetaCaja.TabIndex = 2;
            this.chboxTarjetaCaja.Text = "Tarjeta";
            this.chboxTarjetaCaja.UseVisualStyleBackColor = true;
            // 
            // chboxTipoMovimientoCaja
            // 
            this.chboxTipoMovimientoCaja.AutoSize = true;
            this.chboxTipoMovimientoCaja.Location = new System.Drawing.Point(19, 89);
            this.chboxTipoMovimientoCaja.Name = "chboxTipoMovimientoCaja";
            this.chboxTipoMovimientoCaja.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxTipoMovimientoCaja.Size = new System.Drawing.Size(118, 17);
            this.chboxTipoMovimientoCaja.TabIndex = 23;
            this.chboxTipoMovimientoCaja.Text = "Tipo de movimiento";
            this.chboxTipoMovimientoCaja.UseVisualStyleBackColor = true;
            // 
            // tabRegiones
            // 
            this.tabRegiones.Controls.Add(this.txtboxPiePagina);
            this.tabRegiones.Controls.Add(this.chboxPiePagina);
            this.tabRegiones.Controls.Add(this.btnEditarEncabezado);
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
            this.txtboxPiePagina.Location = new System.Drawing.Point(20, 109);
            this.txtboxPiePagina.MaxLength = 25;
            this.txtboxPiePagina.Name = "txtboxPiePagina";
            this.txtboxPiePagina.Size = new System.Drawing.Size(154, 20);
            this.txtboxPiePagina.TabIndex = 41;
            // 
            // chboxPiePagina
            // 
            this.chboxPiePagina.AutoSize = true;
            this.chboxPiePagina.Location = new System.Drawing.Point(19, 86);
            this.chboxPiePagina.Name = "chboxPiePagina";
            this.chboxPiePagina.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxPiePagina.Size = new System.Drawing.Size(91, 17);
            this.chboxPiePagina.TabIndex = 40;
            this.chboxPiePagina.Text = "Pie de página";
            this.chboxPiePagina.UseVisualStyleBackColor = true;
            this.chboxPiePagina.CheckedChanged += new System.EventHandler(this.chboxPiePagina_CheckedChanged);
            // 
            // btnEditarEncabezado
            // 
            this.btnEditarEncabezado.Location = new System.Drawing.Point(199, 18);
            this.btnEditarEncabezado.Name = "btnEditarEncabezado";
            this.btnEditarEncabezado.Size = new System.Drawing.Size(185, 23);
            this.btnEditarEncabezado.TabIndex = 37;
            this.btnEditarEncabezado.Text = "Editar encabezado";
            this.btnEditarEncabezado.UseVisualStyleBackColor = true;
            this.btnEditarEncabezado.Click += new System.EventHandler(this.btnEditarEncabezado_Click);
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
            this.chboxHoraCreacionReporte.Size = new System.Drawing.Size(115, 17);
            this.chboxHoraCreacionReporte.TabIndex = 30;
            this.chboxHoraCreacionReporte.Text = "Fecha de creacion";
            this.chboxHoraCreacionReporte.UseVisualStyleBackColor = true;
            // 
            // frmOpcionesAvanzadasCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 244);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOpcionesAvanzadasCaja";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Opciones avanzadas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOpcionesAvanzadasCaja_FormClosing);
            this.Load += new System.EventHandler(this.frmOpcionesAvanzadasCaja_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabCaja.ResumeLayout(false);
            this.tabCaja.PerformLayout();
            this.tabRegiones.ResumeLayout(false);
            this.tabRegiones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage tabCaja;
        public System.Windows.Forms.CheckBox chboxSubtotalCaja;
        public System.Windows.Forms.CheckBox chboxUsuarioCreadorCaja;
        public System.Windows.Forms.CheckBox chboxDescripcionCaja;
        public System.Windows.Forms.CheckBox chboxIdentificadorVentaCaja;
        public System.Windows.Forms.CheckBox chboxFechaCaja;
        public System.Windows.Forms.CheckBox chboxEfectivoCaja;
        public System.Windows.Forms.CheckBox chboxTarjetaCaja;
        public System.Windows.Forms.CheckBox chboxTipoMovimientoCaja;
        public System.Windows.Forms.TabPage tabRegiones;
        public System.Windows.Forms.TextBox txtboxPiePagina;
        public System.Windows.Forms.CheckBox chboxPiePagina;
        public System.Windows.Forms.Button btnEditarEncabezado;
        public System.Windows.Forms.TextBox txtboxObservacionReporte;
        public System.Windows.Forms.CheckBox chboxNumeroPaginasReporte;
        public System.Windows.Forms.CheckBox chboxObservacionesArchivoReporte;
        public System.Windows.Forms.CheckBox chboxDatosUsuarioCreadorReporte;
        public System.Windows.Forms.CheckBox chboxHoraCreacionReporte;
    }
}