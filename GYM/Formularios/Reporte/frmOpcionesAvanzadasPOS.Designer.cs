namespace GYM.Formularios.Reporte
{
    partial class frmOpcionesAvanzadasPOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpcionesAvanzadasPOS));
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDatosVenta = new System.Windows.Forms.TabPage();
            this.chboxUsuarioCreadorVentas = new System.Windows.Forms.CheckBox();
            this.chboxIdentificadorVenta = new System.Windows.Forms.CheckBox();
            this.chboxAbiertaVentas = new System.Windows.Forms.CheckBox();
            this.chboxFechaVentas = new System.Windows.Forms.CheckBox();
            this.chboxEstadoVentas = new System.Windows.Forms.CheckBox();
            this.chboxSubtotalVentas = new System.Windows.Forms.CheckBox();
            this.tabVentaDetallada = new System.Windows.Forms.TabPage();
            this.chboxSubtotalVentaDetallada = new System.Windows.Forms.CheckBox();
            this.chboxPrecioVentaDetallada = new System.Windows.Forms.CheckBox();
            this.chboxCantidadVentaDetallada = new System.Windows.Forms.CheckBox();
            this.chboxDescripcionVentaDetallada = new System.Windows.Forms.CheckBox();
            this.chboxMarcaVentaDetallada = new System.Windows.Forms.CheckBox();
            this.chboxNombreVentasDetallas = new System.Windows.Forms.CheckBox();
            this.chboxIdentificadorProductoVentaDetallada = new System.Windows.Forms.CheckBox();
            this.chboxIdentificadorVentaDetallada = new System.Windows.Forms.CheckBox();
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
            this.tabDatosVenta.SuspendLayout();
            this.tabVentaDetallada.SuspendLayout();
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
            this.tabControl1.Controls.Add(this.tabDatosVenta);
            this.tabControl1.Controls.Add(this.tabVentaDetallada);
            this.tabControl1.Controls.Add(this.tabRegiones);
            this.tabControl1.Location = new System.Drawing.Point(0, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(447, 205);
            this.tabControl1.TabIndex = 4;
            // 
            // tabDatosVenta
            // 
            this.tabDatosVenta.Controls.Add(this.chboxUsuarioCreadorVentas);
            this.tabDatosVenta.Controls.Add(this.chboxIdentificadorVenta);
            this.tabDatosVenta.Controls.Add(this.chboxAbiertaVentas);
            this.tabDatosVenta.Controls.Add(this.chboxFechaVentas);
            this.tabDatosVenta.Controls.Add(this.chboxEstadoVentas);
            this.tabDatosVenta.Controls.Add(this.chboxSubtotalVentas);
            this.tabDatosVenta.Location = new System.Drawing.Point(4, 22);
            this.tabDatosVenta.Name = "tabDatosVenta";
            this.tabDatosVenta.Padding = new System.Windows.Forms.Padding(3);
            this.tabDatosVenta.Size = new System.Drawing.Size(439, 179);
            this.tabDatosVenta.TabIndex = 0;
            this.tabDatosVenta.Text = "Datos de venta";
            this.tabDatosVenta.UseVisualStyleBackColor = true;
            // 
            // chboxUsuarioCreadorVentas
            // 
            this.chboxUsuarioCreadorVentas.AutoSize = true;
            this.chboxUsuarioCreadorVentas.Location = new System.Drawing.Point(161, 66);
            this.chboxUsuarioCreadorVentas.Name = "chboxUsuarioCreadorVentas";
            this.chboxUsuarioCreadorVentas.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxUsuarioCreadorVentas.Size = new System.Drawing.Size(101, 17);
            this.chboxUsuarioCreadorVentas.TabIndex = 32;
            this.chboxUsuarioCreadorVentas.Text = "Usuario creador";
            this.chboxUsuarioCreadorVentas.UseVisualStyleBackColor = true;
            this.chboxUsuarioCreadorVentas.CheckedChanged += new System.EventHandler(this.chboxUsuarioCreadorTrabajador_CheckedChanged);
            // 
            // chboxIdentificadorVenta
            // 
            this.chboxIdentificadorVenta.AutoSize = true;
            this.chboxIdentificadorVenta.Checked = true;
            this.chboxIdentificadorVenta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chboxIdentificadorVenta.Location = new System.Drawing.Point(19, 20);
            this.chboxIdentificadorVenta.Name = "chboxIdentificadorVenta";
            this.chboxIdentificadorVenta.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxIdentificadorVenta.Size = new System.Drawing.Size(129, 17);
            this.chboxIdentificadorVenta.TabIndex = 0;
            this.chboxIdentificadorVenta.Text = "Identificador de venta";
            this.chboxIdentificadorVenta.UseVisualStyleBackColor = true;
            // 
            // chboxAbiertaVentas
            // 
            this.chboxAbiertaVentas.AutoSize = true;
            this.chboxAbiertaVentas.Location = new System.Drawing.Point(161, 43);
            this.chboxAbiertaVentas.Name = "chboxAbiertaVentas";
            this.chboxAbiertaVentas.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxAbiertaVentas.Size = new System.Drawing.Size(59, 17);
            this.chboxAbiertaVentas.TabIndex = 27;
            this.chboxAbiertaVentas.Text = "Abierta";
            this.chboxAbiertaVentas.UseVisualStyleBackColor = true;
            // 
            // chboxFechaVentas
            // 
            this.chboxFechaVentas.AutoSize = true;
            this.chboxFechaVentas.Checked = true;
            this.chboxFechaVentas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chboxFechaVentas.Location = new System.Drawing.Point(19, 43);
            this.chboxFechaVentas.Name = "chboxFechaVentas";
            this.chboxFechaVentas.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxFechaVentas.Size = new System.Drawing.Size(56, 17);
            this.chboxFechaVentas.TabIndex = 1;
            this.chboxFechaVentas.Text = "Fecha";
            this.chboxFechaVentas.UseVisualStyleBackColor = true;
            // 
            // chboxEstadoVentas
            // 
            this.chboxEstadoVentas.AutoSize = true;
            this.chboxEstadoVentas.Checked = true;
            this.chboxEstadoVentas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chboxEstadoVentas.Location = new System.Drawing.Point(161, 20);
            this.chboxEstadoVentas.Name = "chboxEstadoVentas";
            this.chboxEstadoVentas.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxEstadoVentas.Size = new System.Drawing.Size(59, 17);
            this.chboxEstadoVentas.TabIndex = 26;
            this.chboxEstadoVentas.Text = "Estado";
            this.chboxEstadoVentas.UseVisualStyleBackColor = true;
            // 
            // chboxSubtotalVentas
            // 
            this.chboxSubtotalVentas.AutoSize = true;
            this.chboxSubtotalVentas.Checked = true;
            this.chboxSubtotalVentas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chboxSubtotalVentas.Location = new System.Drawing.Point(19, 66);
            this.chboxSubtotalVentas.Name = "chboxSubtotalVentas";
            this.chboxSubtotalVentas.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxSubtotalVentas.Size = new System.Drawing.Size(65, 17);
            this.chboxSubtotalVentas.TabIndex = 2;
            this.chboxSubtotalVentas.Text = "Subtotal";
            this.chboxSubtotalVentas.UseVisualStyleBackColor = true;
            // 
            // tabVentaDetallada
            // 
            this.tabVentaDetallada.Controls.Add(this.chboxSubtotalVentaDetallada);
            this.tabVentaDetallada.Controls.Add(this.chboxPrecioVentaDetallada);
            this.tabVentaDetallada.Controls.Add(this.chboxCantidadVentaDetallada);
            this.tabVentaDetallada.Controls.Add(this.chboxDescripcionVentaDetallada);
            this.tabVentaDetallada.Controls.Add(this.chboxMarcaVentaDetallada);
            this.tabVentaDetallada.Controls.Add(this.chboxNombreVentasDetallas);
            this.tabVentaDetallada.Controls.Add(this.chboxIdentificadorProductoVentaDetallada);
            this.tabVentaDetallada.Controls.Add(this.chboxIdentificadorVentaDetallada);
            this.tabVentaDetallada.Location = new System.Drawing.Point(4, 22);
            this.tabVentaDetallada.Name = "tabVentaDetallada";
            this.tabVentaDetallada.Padding = new System.Windows.Forms.Padding(3);
            this.tabVentaDetallada.Size = new System.Drawing.Size(439, 179);
            this.tabVentaDetallada.TabIndex = 1;
            this.tabVentaDetallada.Text = "Venta detallada";
            this.tabVentaDetallada.UseVisualStyleBackColor = true;
            // 
            // chboxSubtotalVentaDetallada
            // 
            this.chboxSubtotalVentaDetallada.AutoSize = true;
            this.chboxSubtotalVentaDetallada.Checked = true;
            this.chboxSubtotalVentaDetallada.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chboxSubtotalVentaDetallada.Location = new System.Drawing.Point(186, 90);
            this.chboxSubtotalVentaDetallada.Name = "chboxSubtotalVentaDetallada";
            this.chboxSubtotalVentaDetallada.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxSubtotalVentaDetallada.Size = new System.Drawing.Size(65, 17);
            this.chboxSubtotalVentaDetallada.TabIndex = 40;
            this.chboxSubtotalVentaDetallada.Text = "Subtotal";
            this.chboxSubtotalVentaDetallada.UseVisualStyleBackColor = true;
            // 
            // chboxPrecioVentaDetallada
            // 
            this.chboxPrecioVentaDetallada.AutoSize = true;
            this.chboxPrecioVentaDetallada.Checked = true;
            this.chboxPrecioVentaDetallada.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chboxPrecioVentaDetallada.Location = new System.Drawing.Point(186, 67);
            this.chboxPrecioVentaDetallada.Name = "chboxPrecioVentaDetallada";
            this.chboxPrecioVentaDetallada.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxPrecioVentaDetallada.Size = new System.Drawing.Size(56, 17);
            this.chboxPrecioVentaDetallada.TabIndex = 39;
            this.chboxPrecioVentaDetallada.Text = "Precio";
            this.chboxPrecioVentaDetallada.UseVisualStyleBackColor = true;
            // 
            // chboxCantidadVentaDetallada
            // 
            this.chboxCantidadVentaDetallada.AutoSize = true;
            this.chboxCantidadVentaDetallada.Checked = true;
            this.chboxCantidadVentaDetallada.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chboxCantidadVentaDetallada.Location = new System.Drawing.Point(186, 44);
            this.chboxCantidadVentaDetallada.Name = "chboxCantidadVentaDetallada";
            this.chboxCantidadVentaDetallada.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxCantidadVentaDetallada.Size = new System.Drawing.Size(68, 17);
            this.chboxCantidadVentaDetallada.TabIndex = 38;
            this.chboxCantidadVentaDetallada.Text = "Cantidad";
            this.chboxCantidadVentaDetallada.UseVisualStyleBackColor = true;
            // 
            // chboxDescripcionVentaDetallada
            // 
            this.chboxDescripcionVentaDetallada.AutoSize = true;
            this.chboxDescripcionVentaDetallada.Checked = true;
            this.chboxDescripcionVentaDetallada.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chboxDescripcionVentaDetallada.Location = new System.Drawing.Point(186, 21);
            this.chboxDescripcionVentaDetallada.Name = "chboxDescripcionVentaDetallada";
            this.chboxDescripcionVentaDetallada.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxDescripcionVentaDetallada.Size = new System.Drawing.Size(82, 17);
            this.chboxDescripcionVentaDetallada.TabIndex = 37;
            this.chboxDescripcionVentaDetallada.Text = "Descripción";
            this.chboxDescripcionVentaDetallada.UseVisualStyleBackColor = true;
            // 
            // chboxMarcaVentaDetallada
            // 
            this.chboxMarcaVentaDetallada.AutoSize = true;
            this.chboxMarcaVentaDetallada.Checked = true;
            this.chboxMarcaVentaDetallada.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chboxMarcaVentaDetallada.Location = new System.Drawing.Point(19, 90);
            this.chboxMarcaVentaDetallada.Name = "chboxMarcaVentaDetallada";
            this.chboxMarcaVentaDetallada.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxMarcaVentaDetallada.Size = new System.Drawing.Size(56, 17);
            this.chboxMarcaVentaDetallada.TabIndex = 36;
            this.chboxMarcaVentaDetallada.Text = "Marca";
            this.chboxMarcaVentaDetallada.UseVisualStyleBackColor = true;
            // 
            // chboxNombreVentasDetallas
            // 
            this.chboxNombreVentasDetallas.AutoSize = true;
            this.chboxNombreVentasDetallas.Checked = true;
            this.chboxNombreVentasDetallas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chboxNombreVentasDetallas.Location = new System.Drawing.Point(19, 67);
            this.chboxNombreVentasDetallas.Name = "chboxNombreVentasDetallas";
            this.chboxNombreVentasDetallas.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxNombreVentasDetallas.Size = new System.Drawing.Size(63, 17);
            this.chboxNombreVentasDetallas.TabIndex = 35;
            this.chboxNombreVentasDetallas.Text = "Nombre";
            this.chboxNombreVentasDetallas.UseVisualStyleBackColor = true;
            // 
            // chboxIdentificadorProductoVentaDetallada
            // 
            this.chboxIdentificadorProductoVentaDetallada.AutoSize = true;
            this.chboxIdentificadorProductoVentaDetallada.Checked = true;
            this.chboxIdentificadorProductoVentaDetallada.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chboxIdentificadorProductoVentaDetallada.Location = new System.Drawing.Point(19, 44);
            this.chboxIdentificadorProductoVentaDetallada.Name = "chboxIdentificadorProductoVentaDetallada";
            this.chboxIdentificadorProductoVentaDetallada.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxIdentificadorProductoVentaDetallada.Size = new System.Drawing.Size(144, 17);
            this.chboxIdentificadorProductoVentaDetallada.TabIndex = 34;
            this.chboxIdentificadorProductoVentaDetallada.Text = "Identificador de producto";
            this.chboxIdentificadorProductoVentaDetallada.UseVisualStyleBackColor = true;
            // 
            // chboxIdentificadorVentaDetallada
            // 
            this.chboxIdentificadorVentaDetallada.AutoSize = true;
            this.chboxIdentificadorVentaDetallada.Checked = true;
            this.chboxIdentificadorVentaDetallada.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chboxIdentificadorVentaDetallada.Location = new System.Drawing.Point(19, 21);
            this.chboxIdentificadorVentaDetallada.Name = "chboxIdentificadorVentaDetallada";
            this.chboxIdentificadorVentaDetallada.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chboxIdentificadorVentaDetallada.Size = new System.Drawing.Size(129, 17);
            this.chboxIdentificadorVentaDetallada.TabIndex = 33;
            this.chboxIdentificadorVentaDetallada.Text = "Identificador de venta";
            this.chboxIdentificadorVentaDetallada.UseVisualStyleBackColor = true;
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
            // frmOpcionesAvanzadasPOS
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
            this.Name = "frmOpcionesAvanzadasPOS";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Opciones avanzadas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOpcionesAvanzadasPOS_FormClosing);
            this.Load += new System.EventHandler(this.frmOpcionesAvanzadasPOS_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabDatosVenta.ResumeLayout(false);
            this.tabDatosVenta.PerformLayout();
            this.tabVentaDetallada.ResumeLayout(false);
            this.tabVentaDetallada.PerformLayout();
            this.tabRegiones.ResumeLayout(false);
            this.tabRegiones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage tabDatosVenta;
        public System.Windows.Forms.CheckBox chboxIdentificadorVenta;
        public System.Windows.Forms.CheckBox chboxAbiertaVentas;
        public System.Windows.Forms.CheckBox chboxFechaVentas;
        public System.Windows.Forms.CheckBox chboxEstadoVentas;
        public System.Windows.Forms.CheckBox chboxSubtotalVentas;
        public System.Windows.Forms.TabPage tabVentaDetallada;
        public System.Windows.Forms.TabPage tabRegiones;
        public System.Windows.Forms.TextBox txtboxPiePagina;
        public System.Windows.Forms.CheckBox chboxPiePagina;
        public System.Windows.Forms.Button btnEditarEncabezado;
        public System.Windows.Forms.TextBox txtboxObservacionReporte;
        public System.Windows.Forms.CheckBox chboxNumeroPaginasReporte;
        public System.Windows.Forms.CheckBox chboxObservacionesArchivoReporte;
        public System.Windows.Forms.CheckBox chboxDatosUsuarioCreadorReporte;
        public System.Windows.Forms.CheckBox chboxHoraCreacionReporte;
        public System.Windows.Forms.CheckBox chboxUsuarioCreadorVentas;
        public System.Windows.Forms.CheckBox chboxSubtotalVentaDetallada;
        public System.Windows.Forms.CheckBox chboxPrecioVentaDetallada;
        public System.Windows.Forms.CheckBox chboxCantidadVentaDetallada;
        public System.Windows.Forms.CheckBox chboxDescripcionVentaDetallada;
        public System.Windows.Forms.CheckBox chboxMarcaVentaDetallada;
        public System.Windows.Forms.CheckBox chboxNombreVentasDetallas;
        public System.Windows.Forms.CheckBox chboxIdentificadorProductoVentaDetallada;
        public System.Windows.Forms.CheckBox chboxIdentificadorVentaDetallada;
    }
}