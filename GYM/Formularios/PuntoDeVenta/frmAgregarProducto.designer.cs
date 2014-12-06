namespace GYM.Formularios.PuntoDeVenta
{
    partial class frmAgregarProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarProducto));
            this.lblNombreProducto = new System.Windows.Forms.Label();
            this.txbNombre = new System.Windows.Forms.TextBox();
            this.txbMarca = new System.Windows.Forms.TextBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblUnidad = new System.Windows.Forms.Label();
            this.txbPrecio = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txbCosto = new System.Windows.Forms.TextBox();
            this.lblCosto = new System.Windows.Forms.Label();
            this.txbDescripcion = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.btnAgregarOtro = new System.Windows.Forms.Button();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.cboPieza = new System.Windows.Forms.ComboBox();
            this.chbProductoServicio = new System.Windows.Forms.CheckBox();
            this.chbControlStock = new System.Windows.Forms.CheckBox();
            this.txtCantidadAlmacen = new System.Windows.Forms.TextBox();
            this.lblCantidadAlmacen = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNombreProducto
            // 
            this.lblNombreProducto.AutoSize = true;
            this.lblNombreProducto.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblNombreProducto.Location = new System.Drawing.Point(8, 38);
            this.lblNombreProducto.Name = "lblNombreProducto";
            this.lblNombreProducto.Size = new System.Drawing.Size(135, 21);
            this.lblNombreProducto.TabIndex = 0;
            this.lblNombreProducto.Text = "Nombre producto";
            // 
            // txbNombre
            // 
            this.txbNombre.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txbNombre.Location = new System.Drawing.Point(12, 62);
            this.txbNombre.Name = "txbNombre";
            this.txbNombre.Size = new System.Drawing.Size(238, 29);
            this.txbNombre.TabIndex = 0;
            // 
            // txbMarca
            // 
            this.txbMarca.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txbMarca.Location = new System.Drawing.Point(12, 128);
            this.txbMarca.Name = "txbMarca";
            this.txbMarca.Size = new System.Drawing.Size(238, 29);
            this.txbMarca.TabIndex = 2;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblMarca.Location = new System.Drawing.Point(8, 104);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(53, 21);
            this.lblMarca.TabIndex = 2;
            this.lblMarca.Text = "Marca";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDescripcion.Location = new System.Drawing.Point(8, 231);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(91, 21);
            this.lblDescripcion.TabIndex = 5;
            this.lblDescripcion.Text = "Descripción";
            // 
            // lblUnidad
            // 
            this.lblUnidad.AutoSize = true;
            this.lblUnidad.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblUnidad.Location = new System.Drawing.Point(252, 38);
            this.lblUnidad.Name = "lblUnidad";
            this.lblUnidad.Size = new System.Drawing.Size(172, 21);
            this.lblUnidad.TabIndex = 6;
            this.lblUnidad.Text = "Unidad (Pieza/Paquete)";
            // 
            // txbPrecio
            // 
            this.txbPrecio.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txbPrecio.Location = new System.Drawing.Point(256, 128);
            this.txbPrecio.Name = "txbPrecio";
            this.txbPrecio.Size = new System.Drawing.Size(202, 29);
            this.txbPrecio.TabIndex = 3;
            this.txbPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbUnidad_KeyPress);
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblPrecio.Location = new System.Drawing.Point(252, 104);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(116, 21);
            this.lblPrecio.TabIndex = 8;
            this.lblPrecio.Text = "Precio de venta";
            // 
            // txbCosto
            // 
            this.txbCosto.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txbCosto.Location = new System.Drawing.Point(256, 191);
            this.txbCosto.Name = "txbCosto";
            this.txbCosto.Size = new System.Drawing.Size(202, 29);
            this.txbCosto.TabIndex = 5;
            this.txbCosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbUnidad_KeyPress);
            // 
            // lblCosto
            // 
            this.lblCosto.AutoSize = true;
            this.lblCosto.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCosto.Location = new System.Drawing.Point(252, 167);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(131, 21);
            this.lblCosto.TabIndex = 10;
            this.lblCosto.Text = "Precio de compra";
            // 
            // txbDescripcion
            // 
            this.txbDescripcion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txbDescripcion.Location = new System.Drawing.Point(12, 255);
            this.txbDescripcion.Multiline = true;
            this.txbDescripcion.Name = "txbDescripcion";
            this.txbDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txbDescripcion.Size = new System.Drawing.Size(238, 85);
            this.txbDescripcion.TabIndex = 6;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAceptar.Image = global::GYM.Properties.Resources.ImgAceptar;
            this.btnAceptar.Location = new System.Drawing.Point(360, 346);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(98, 42);
            this.btnAceptar.TabIndex = 11;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCantidad.Location = new System.Drawing.Point(256, 255);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(202, 29);
            this.txtCantidad.TabIndex = 7;
            this.txtCantidad.Text = "0";
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCantidad.Location = new System.Drawing.Point(252, 231);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(170, 21);
            this.lblCantidad.TabIndex = 17;
            this.lblCantidad.Text = "Cantidad en mostrador";
            // 
            // btnAgregarOtro
            // 
            this.btnAgregarOtro.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnAgregarOtro.Location = new System.Drawing.Point(256, 346);
            this.btnAgregarOtro.Name = "btnAgregarOtro";
            this.btnAgregarOtro.Size = new System.Drawing.Size(98, 42);
            this.btnAgregarOtro.TabIndex = 10;
            this.btnAgregarOtro.Text = "Guardar y agregar otro";
            this.btnAgregarOtro.UseVisualStyleBackColor = true;
            this.btnAgregarOtro.Click += new System.EventHandler(this.btnAgregarOtro_Click);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCodigo.Location = new System.Drawing.Point(8, 167);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(60, 21);
            this.lblCodigo.TabIndex = 19;
            this.lblCodigo.Text = "Código";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCodigo.Location = new System.Drawing.Point(12, 191);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(238, 29);
            this.txtCodigo.TabIndex = 4;
            // 
            // cboPieza
            // 
            this.cboPieza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPieza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPieza.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboPieza.FormattingEnabled = true;
            this.cboPieza.Items.AddRange(new object[] {
            "Pieza",
            "Paquete"});
            this.cboPieza.Location = new System.Drawing.Point(256, 62);
            this.cboPieza.Name = "cboPieza";
            this.cboPieza.Size = new System.Drawing.Size(202, 29);
            this.cboPieza.TabIndex = 1;
            // 
            // chbProductoServicio
            // 
            this.chbProductoServicio.AutoSize = true;
            this.chbProductoServicio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chbProductoServicio.Location = new System.Drawing.Point(12, 12);
            this.chbProductoServicio.Name = "chbProductoServicio";
            this.chbProductoServicio.Size = new System.Drawing.Size(219, 23);
            this.chbProductoServicio.TabIndex = 0;
            this.chbProductoServicio.Text = "Vender producto como servicio";
            this.chbProductoServicio.UseVisualStyleBackColor = true;
            this.chbProductoServicio.CheckedChanged += new System.EventHandler(this.chbProductoServicio_CheckedChanged);
            // 
            // chbControlStock
            // 
            this.chbControlStock.AutoSize = true;
            this.chbControlStock.Checked = true;
            this.chbControlStock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbControlStock.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chbControlStock.Location = new System.Drawing.Point(12, 346);
            this.chbControlStock.Name = "chbControlStock";
            this.chbControlStock.Size = new System.Drawing.Size(122, 23);
            this.chbControlStock.TabIndex = 9;
            this.chbControlStock.Text = "Controlar stock";
            this.chbControlStock.UseVisualStyleBackColor = true;
            // 
            // txtCantidadAlmacen
            // 
            this.txtCantidadAlmacen.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCantidadAlmacen.Location = new System.Drawing.Point(256, 311);
            this.txtCantidadAlmacen.Name = "txtCantidadAlmacen";
            this.txtCantidadAlmacen.Size = new System.Drawing.Size(202, 29);
            this.txtCantidadAlmacen.TabIndex = 8;
            this.txtCantidadAlmacen.Text = "0";
            this.txtCantidadAlmacen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // lblCantidadAlmacen
            // 
            this.lblCantidadAlmacen.AutoSize = true;
            this.lblCantidadAlmacen.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCantidadAlmacen.Location = new System.Drawing.Point(252, 287);
            this.lblCantidadAlmacen.Name = "lblCantidadAlmacen";
            this.lblCantidadAlmacen.Size = new System.Drawing.Size(155, 21);
            this.lblCantidadAlmacen.TabIndex = 21;
            this.lblCantidadAlmacen.Text = "Cantidad en almacen";
            // 
            // frmAgregarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 400);
            this.Controls.Add(this.txtCantidadAlmacen);
            this.Controls.Add(this.lblCantidadAlmacen);
            this.Controls.Add(this.chbProductoServicio);
            this.Controls.Add(this.chbControlStock);
            this.Controls.Add(this.cboPieza);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.btnAgregarOtro);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txbDescripcion);
            this.Controls.Add(this.txbCosto);
            this.Controls.Add(this.lblCosto);
            this.Controls.Add(this.txbPrecio);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblUnidad);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txbMarca);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.txbNombre);
            this.Controls.Add(this.lblNombreProducto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAgregarProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar producto";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAgregarProducto_FormClosed);
            this.Load += new System.EventHandler(this.frmAgregarProducto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombreProducto;
        private System.Windows.Forms.TextBox txbNombre;
        private System.Windows.Forms.TextBox txbMarca;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblUnidad;
        private System.Windows.Forms.TextBox txbPrecio;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txbCosto;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.TextBox txbDescripcion;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Button btnAgregarOtro;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.ComboBox cboPieza;
        private System.Windows.Forms.CheckBox chbProductoServicio;
        private System.Windows.Forms.CheckBox chbControlStock;
        private System.Windows.Forms.TextBox txtCantidadAlmacen;
        private System.Windows.Forms.Label lblCantidadAlmacen;
    }
}