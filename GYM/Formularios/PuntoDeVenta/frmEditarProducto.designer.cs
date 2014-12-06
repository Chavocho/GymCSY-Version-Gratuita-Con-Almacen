namespace GYM.Formularios.PuntoDeVenta
{
    partial class frmEditarProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditarProducto));
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txbDescripcion = new System.Windows.Forms.TextBox();
            this.txbCosto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txbPrecio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txbMarca = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPieza = new System.Windows.Forms.ComboBox();
            this.chbControlStock = new System.Windows.Forms.CheckBox();
            this.chbProductoServicio = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAceptar.Image = global::GYM.Properties.Resources.ImgAceptar;
            this.btnAceptar.Location = new System.Drawing.Point(298, 268);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(101, 39);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txbDescripcion
            // 
            this.txbDescripcion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txbDescripcion.Location = new System.Drawing.Point(12, 181);
            this.txbDescripcion.Multiline = true;
            this.txbDescripcion.Name = "txbDescripcion";
            this.txbDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txbDescripcion.Size = new System.Drawing.Size(200, 75);
            this.txbDescripcion.TabIndex = 4;
            // 
            // txbCosto
            // 
            this.txbCosto.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txbCosto.Location = new System.Drawing.Point(218, 181);
            this.txbCosto.Name = "txbCosto";
            this.txbCosto.Size = new System.Drawing.Size(181, 29);
            this.txbCosto.TabIndex = 5;
            this.txbCosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioCosto_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label7.Location = new System.Drawing.Point(214, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 21);
            this.label7.TabIndex = 26;
            this.label7.Text = "Precio de compra";
            // 
            // txbPrecio
            // 
            this.txbPrecio.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txbPrecio.Location = new System.Drawing.Point(218, 120);
            this.txbPrecio.Name = "txbPrecio";
            this.txbPrecio.Size = new System.Drawing.Size(181, 29);
            this.txbPrecio.TabIndex = 3;
            this.txbPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioCosto_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label6.Location = new System.Drawing.Point(214, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 21);
            this.label6.TabIndex = 24;
            this.label6.Text = "Precio de venta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.Location = new System.Drawing.Point(214, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 21);
            this.label5.TabIndex = 22;
            this.label5.Text = "Unidad (Pieza/Paquete)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.Location = new System.Drawing.Point(8, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 21);
            this.label4.TabIndex = 21;
            this.label4.Text = "Descripción";
            // 
            // txbMarca
            // 
            this.txbMarca.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txbMarca.Location = new System.Drawing.Point(12, 120);
            this.txbMarca.Name = "txbMarca";
            this.txbMarca.Size = new System.Drawing.Size(200, 29);
            this.txbMarca.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(8, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 21);
            this.label2.TabIndex = 19;
            this.label2.Text = "Marca";
            // 
            // txbNombre
            // 
            this.txbNombre.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txbNombre.Location = new System.Drawing.Point(12, 62);
            this.txbNombre.Name = "txbNombre";
            this.txbNombre.Size = new System.Drawing.Size(200, 29);
            this.txbNombre.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(8, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 21);
            this.label1.TabIndex = 17;
            this.label1.Text = "Nombre producto";
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
            this.cboPieza.Location = new System.Drawing.Point(218, 62);
            this.cboPieza.Name = "cboPieza";
            this.cboPieza.Size = new System.Drawing.Size(181, 29);
            this.cboPieza.TabIndex = 1;
            // 
            // chbControlStock
            // 
            this.chbControlStock.AutoSize = true;
            this.chbControlStock.Checked = true;
            this.chbControlStock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbControlStock.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chbControlStock.Location = new System.Drawing.Point(277, 216);
            this.chbControlStock.Name = "chbControlStock";
            this.chbControlStock.Size = new System.Drawing.Size(122, 23);
            this.chbControlStock.TabIndex = 6;
            this.chbControlStock.Text = "Controlar stock";
            this.chbControlStock.UseVisualStyleBackColor = true;
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
            // frmEditarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 319);
            this.Controls.Add(this.chbProductoServicio);
            this.Controls.Add(this.chbControlStock);
            this.Controls.Add(this.cboPieza);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txbDescripcion);
            this.Controls.Add(this.txbCosto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txbPrecio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbMarca);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbNombre);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEditarProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Producto";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEditarProducto_FormClosed);
            this.Load += new System.EventHandler(this.frmEditarProducto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txbDescripcion;
        private System.Windows.Forms.TextBox txbCosto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbPrecio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbMarca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPieza;
        private System.Windows.Forms.CheckBox chbControlStock;
        private System.Windows.Forms.CheckBox chbProductoServicio;
    }
}