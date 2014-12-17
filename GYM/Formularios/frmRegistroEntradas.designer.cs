namespace GYM.Formularios
{
    partial class frmRegistroEntradas
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroEntradas));
            this.lblNumSocio = new System.Windows.Forms.Label();
            this.tbxNumSocio = new System.Windows.Forms.TextBox();
            this.btnRegEntrada = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.tmrTiempo = new System.Windows.Forms.Timer(this.components);
            this.tmrPromociones = new System.Windows.Forms.Timer(this.components);
            this.lblHora = new System.Windows.Forms.Label();
            this.chbTeclado = new System.Windows.Forms.CheckBox();
            this.btnConfiguración = new System.Windows.Forms.Button();
            this.pcbPromociones = new System.Windows.Forms.PictureBox();
            this.tclSocios = new GYM.Teclado();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPromociones)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumSocio
            // 
            this.lblNumSocio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumSocio.AutoSize = true;
            this.lblNumSocio.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblNumSocio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNumSocio.Location = new System.Drawing.Point(478, 62);
            this.lblNumSocio.Name = "lblNumSocio";
            this.lblNumSocio.Size = new System.Drawing.Size(364, 25);
            this.lblNumSocio.TabIndex = 0;
            this.lblNumSocio.Text = "Ingrese su número de socio y presione enter";
            this.lblNumSocio.Click += new System.EventHandler(this.lblNumSocio_Click);
            // 
            // tbxNumSocio
            // 
            this.tbxNumSocio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxNumSocio.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.tbxNumSocio.Location = new System.Drawing.Point(423, 90);
            this.tbxNumSocio.MaxLength = 8;
            this.tbxNumSocio.Name = "tbxNumSocio";
            this.tbxNumSocio.Size = new System.Drawing.Size(273, 34);
            this.tbxNumSocio.TabIndex = 1;
            this.tbxNumSocio.TextChanged += new System.EventHandler(this.tbxNumSocio_TextChanged);
            this.tbxNumSocio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxNumSocio_KeyPress);
            // 
            // btnRegEntrada
            // 
            this.btnRegEntrada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegEntrada.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRegEntrada.Image = global::GYM.Properties.Resources.ImgAceptar;
            this.btnRegEntrada.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegEntrada.Location = new System.Drawing.Point(702, 90);
            this.btnRegEntrada.Name = "btnRegEntrada";
            this.btnRegEntrada.Size = new System.Drawing.Size(140, 34);
            this.btnRegEntrada.TabIndex = 2;
            this.btnRegEntrada.Text = "Aceptar";
            this.btnRegEntrada.UseVisualStyleBackColor = true;
            this.btnRegEntrada.Click += new System.EventHandler(this.btnRegEntrada_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblFecha.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblFecha.Location = new System.Drawing.Point(2, 5);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(136, 30);
            this.lblFecha.TabIndex = 6;
            this.lblFecha.Text = "Fecha y hora";
            this.lblFecha.Click += new System.EventHandler(this.lblFecha_Click);
            // 
            // tmrTiempo
            // 
            this.tmrTiempo.Interval = 1000;
            this.tmrTiempo.Tick += new System.EventHandler(this.tmrTiempo_Tick);
            // 
            // tmrPromociones
            // 
            this.tmrPromociones.Interval = 60000;
            this.tmrPromociones.Tick += new System.EventHandler(this.tmrPromociones_Tick);
            // 
            // lblHora
            // 
            this.lblHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblHora.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblHora.Location = new System.Drawing.Point(502, 5);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(136, 30);
            this.lblHora.TabIndex = 8;
            this.lblHora.Text = "Fecha y hora";
            // 
            // chbTeclado
            // 
            this.chbTeclado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chbTeclado.AutoSize = true;
            this.chbTeclado.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chbTeclado.Location = new System.Drawing.Point(624, 137);
            this.chbTeclado.Name = "chbTeclado";
            this.chbTeclado.Size = new System.Drawing.Size(218, 25);
            this.chbTeclado.TabIndex = 9;
            this.chbTeclado.Text = "Mostrar teclado en pantalla";
            this.chbTeclado.UseVisualStyleBackColor = true;
            this.chbTeclado.CheckedChanged += new System.EventHandler(this.chbTeclado_CheckedChanged);
            // 
            // btnConfiguración
            // 
            this.btnConfiguración.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfiguración.Location = new System.Drawing.Point(722, 12);
            this.btnConfiguración.Name = "btnConfiguración";
            this.btnConfiguración.Size = new System.Drawing.Size(120, 25);
            this.btnConfiguración.TabIndex = 10;
            this.btnConfiguración.Text = "Cambiar configuración";
            this.btnConfiguración.UseVisualStyleBackColor = true;
            this.btnConfiguración.Click += new System.EventHandler(this.btnConfiguración_Click);
            // 
            // pcbPromociones
            // 
            this.pcbPromociones.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pcbPromociones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pcbPromociones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pcbPromociones.Image = global::GYM.Properties.Resources.gym_promo_title;
            this.pcbPromociones.Location = new System.Drawing.Point(0, 168);
            this.pcbPromociones.Name = "pcbPromociones";
            this.pcbPromociones.Size = new System.Drawing.Size(854, 287);
            this.pcbPromociones.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbPromociones.TabIndex = 4;
            this.pcbPromociones.TabStop = false;
            // 
            // tclSocios
            // 
            this.tclSocios.Location = new System.Drawing.Point(7, 40);
            this.tclSocios.MaximumSize = new System.Drawing.Size(324, 325);
            this.tclSocios.MinimumSize = new System.Drawing.Size(324, 325);
            this.tclSocios.Name = "tclSocios";
            this.tclSocios.Size = new System.Drawing.Size(324, 325);
            this.tclSocios.TabIndex = 7;
            this.tclSocios.Visible = false;
            // 
            // frmRegistroEntradas
            // 
            this.AcceptButton = this.btnRegEntrada;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 455);
            this.Controls.Add(this.btnConfiguración);
            this.Controls.Add(this.chbTeclado);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.tclSocios);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.btnRegEntrada);
            this.Controls.Add(this.tbxNumSocio);
            this.Controls.Add(this.lblNumSocio);
            this.Controls.Add(this.pcbPromociones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegistroEntradas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso de socios";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRegistroEntradas_FormClosed);
            this.Load += new System.EventHandler(this.frmRegistroEntradas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbPromociones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumSocio;
        private System.Windows.Forms.TextBox tbxNumSocio;
        private System.Windows.Forms.Button btnRegEntrada;
        private System.Windows.Forms.PictureBox pcbPromociones;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Timer tmrTiempo;
        private System.Windows.Forms.Timer tmrPromociones;
        private Teclado tclSocios;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.CheckBox chbTeclado;
        private System.Windows.Forms.Button btnConfiguración;
    }
}