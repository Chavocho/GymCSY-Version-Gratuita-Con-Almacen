namespace GYM.Formularios.Reporte
{
    partial class frmOpcionesAvanzadasProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpcionesAvanzadasProducto));
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabProductos = new System.Windows.Forms.TabPage();
            this.chboxUsuarioActualizadorProductos = new System.Windows.Forms.CheckBox();
            this.chboxUsuarioCreadorProducto = new System.Windows.Forms.CheckBox();
            this.chboxNombreProducto = new System.Windows.Forms.CheckBox();
            this.chboxMarcaProducto = new System.Windows.Forms.CheckBox();
            this.chboxDescripcionProducto = new System.Windows.Forms.CheckBox();
            this.chboxCostoProducto = new System.Windows.Forms.CheckBox();
            this.chboxUnidadProducto = new System.Windows.Forms.CheckBox();
            this.chboxPrecioProducto = new System.Windows.Forms.CheckBox();
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
            this.tabProductos.SuspendLayout();
            this.tabRegiones.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(357, 216);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Salir";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabProductos);
            this.tabControl1.Controls.Add(this.tabRegiones);
            this.tabControl1.Location = new System.Drawing.Point(0, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(447, 205);
            this.tabControl1.TabIndex = 3;
            // 
            // tabProductos
            // 
            this.tabProductos.Controls.Add(this.chboxUsuarioActualizadorProductos);
            this.tabProductos.Controls.Add(this.chboxUsuarioCreadorProducto);
            this.tabProductos.Controls.Add(this.chboxNombreProducto);
            this.tabProductos.Controls.Add(this.chboxMarcaProducto);
            this.tabProductos.Controls.Add(this.chboxDescripcionProducto);
            this.tabProductos.Controls.Add(this.chboxCostoProducto);
            this.tabProductos.Controls.Add(this.chboxUnidadProducto);
            this.tabProductos.Controls.Add(this.chboxPrecioProducto);
            this.tabProductos.Location = new System.Drawing.Point(4, 22);
            this.tabProductos.Name = "tabProductos";
            this.tabProductos.Padding = new System.Windows.Forms.Padding(3);
            this.tabProductos.Size = new System.Drawing.Size(439, 179);
            this.tabProductos.TabIndex = 0;
            this.tabProductos.Text = "Regiones del reporte de producto";
            this.tabProductos.UseVisualStyleBackColor = true;
            // 
            // chboxUsuarioActualizadorProductos
            // 
            this.chboxUsuarioActualizadorProductos.AutoSize = true;
            this.chboxUsuarioActualizadorProductos.Location = new System.Drawing.Point(244, 109);
            this.chboxUsuarioActualizadorProductos.Name = "chboxUsuarioActualizadorProductos";
            this.chboxUsuarioActualizadorProductos.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxUsuarioActualizadorProductos.Size = new System.Drawing.Size(122, 17);
            this.chboxUsuarioActualizadorProductos.TabIndex = 33;
            this.chboxUsuarioActualizadorProductos.Text = "Usuario actualizador";
            this.chboxUsuarioActualizadorProductos.UseVisualStyleBackColor = true;
            // 
            // chboxUsuarioCreadorProducto
            // 
            this.chboxUsuarioCreadorProducto.AutoSize = true;
            this.chboxUsuarioCreadorProducto.Location = new System.Drawing.Point(244, 86);
            this.chboxUsuarioCreadorProducto.Name = "chboxUsuarioCreadorProducto";
            this.chboxUsuarioCreadorProducto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxUsuarioCreadorProducto.Size = new System.Drawing.Size(101, 17);
            this.chboxUsuarioCreadorProducto.TabIndex = 32;
            this.chboxUsuarioCreadorProducto.Text = "Usuario creador";
            this.chboxUsuarioCreadorProducto.UseVisualStyleBackColor = true;
            // 
            // chboxNombreProducto
            // 
            this.chboxNombreProducto.AutoSize = true;
            this.chboxNombreProducto.Checked = true;
            this.chboxNombreProducto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chboxNombreProducto.Location = new System.Drawing.Point(87, 40);
            this.chboxNombreProducto.Name = "chboxNombreProducto";
            this.chboxNombreProducto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxNombreProducto.Size = new System.Drawing.Size(63, 17);
            this.chboxNombreProducto.TabIndex = 0;
            this.chboxNombreProducto.Text = "Nombre";
            this.chboxNombreProducto.UseVisualStyleBackColor = true;
            // 
            // chboxMarcaProducto
            // 
            this.chboxMarcaProducto.AutoSize = true;
            this.chboxMarcaProducto.Checked = true;
            this.chboxMarcaProducto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chboxMarcaProducto.Location = new System.Drawing.Point(87, 63);
            this.chboxMarcaProducto.Name = "chboxMarcaProducto";
            this.chboxMarcaProducto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxMarcaProducto.Size = new System.Drawing.Size(56, 17);
            this.chboxMarcaProducto.TabIndex = 1;
            this.chboxMarcaProducto.Text = "Marca";
            this.chboxMarcaProducto.UseVisualStyleBackColor = true;
            // 
            // chboxDescripcionProducto
            // 
            this.chboxDescripcionProducto.AutoSize = true;
            this.chboxDescripcionProducto.Checked = true;
            this.chboxDescripcionProducto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chboxDescripcionProducto.Location = new System.Drawing.Point(87, 86);
            this.chboxDescripcionProducto.Name = "chboxDescripcionProducto";
            this.chboxDescripcionProducto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxDescripcionProducto.Size = new System.Drawing.Size(82, 17);
            this.chboxDescripcionProducto.TabIndex = 2;
            this.chboxDescripcionProducto.Text = "Descripcion";
            this.chboxDescripcionProducto.UseVisualStyleBackColor = true;
            // 
            // chboxCostoProducto
            // 
            this.chboxCostoProducto.AutoSize = true;
            this.chboxCostoProducto.Location = new System.Drawing.Point(244, 63);
            this.chboxCostoProducto.Name = "chboxCostoProducto";
            this.chboxCostoProducto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxCostoProducto.Size = new System.Drawing.Size(53, 17);
            this.chboxCostoProducto.TabIndex = 25;
            this.chboxCostoProducto.Text = "Costo";
            this.chboxCostoProducto.UseVisualStyleBackColor = true;
            // 
            // chboxUnidadProducto
            // 
            this.chboxUnidadProducto.AutoSize = true;
            this.chboxUnidadProducto.Checked = true;
            this.chboxUnidadProducto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chboxUnidadProducto.Location = new System.Drawing.Point(87, 109);
            this.chboxUnidadProducto.Name = "chboxUnidadProducto";
            this.chboxUnidadProducto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxUnidadProducto.Size = new System.Drawing.Size(60, 17);
            this.chboxUnidadProducto.TabIndex = 23;
            this.chboxUnidadProducto.Text = "Unidad";
            this.chboxUnidadProducto.UseVisualStyleBackColor = true;
            // 
            // chboxPrecioProducto
            // 
            this.chboxPrecioProducto.AutoSize = true;
            this.chboxPrecioProducto.Checked = true;
            this.chboxPrecioProducto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chboxPrecioProducto.Location = new System.Drawing.Point(244, 40);
            this.chboxPrecioProducto.Name = "chboxPrecioProducto";
            this.chboxPrecioProducto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxPrecioProducto.Size = new System.Drawing.Size(56, 17);
            this.chboxPrecioProducto.TabIndex = 24;
            this.chboxPrecioProducto.Text = "Precio";
            this.chboxPrecioProducto.UseVisualStyleBackColor = true;
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
            this.chboxHoraCreacionReporte.Size = new System.Drawing.Size(115, 17);
            this.chboxHoraCreacionReporte.TabIndex = 30;
            this.chboxHoraCreacionReporte.Text = "Fecha de creacion";
            this.chboxHoraCreacionReporte.UseVisualStyleBackColor = true;
            // 
            // frmOpcionesAvanzadasProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 244);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOpcionesAvanzadasProducto";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Opciones avanzadas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOpcionesAvanzadasProducto_FormClosing);
            this.Load += new System.EventHandler(this.frmOpcionesAvanzadasProducto_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabProductos.ResumeLayout(false);
            this.tabProductos.PerformLayout();
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
        public System.Windows.Forms.TabPage tabProductos;
        public System.Windows.Forms.CheckBox chboxUsuarioCreadorProducto;
        public System.Windows.Forms.CheckBox chboxMarcaProducto;
        public System.Windows.Forms.CheckBox chboxDescripcionProducto;
        public System.Windows.Forms.CheckBox chboxCostoProducto;
        public System.Windows.Forms.CheckBox chboxUnidadProducto;
        public System.Windows.Forms.CheckBox chboxPrecioProducto;
        public System.Windows.Forms.CheckBox chboxNombreProducto;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox txtboxPiePagina;
        public System.Windows.Forms.CheckBox chboxPiePagina;
        public System.Windows.Forms.CheckBox chboxUsuarioActualizadorProductos;
    }
}