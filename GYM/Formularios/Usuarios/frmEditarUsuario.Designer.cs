namespace GYM.Formularios
{
    partial class frmEditarUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditarUsuario));
            this.lblNivel = new System.Windows.Forms.Label();
            this.cboNivel = new System.Windows.Forms.ComboBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.chbContrasena = new System.Windows.Forms.CheckBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.pnlContra = new System.Windows.Forms.Panel();
            this.txtAntiContra = new System.Windows.Forms.TextBox();
            this.lblAntiContra = new System.Windows.Forms.Label();
            this.lblRepContra = new System.Windows.Forms.Label();
            this.txtRepContra = new System.Windows.Forms.TextBox();
            this.txtContra = new System.Windows.Forms.TextBox();
            this.lblContra = new System.Windows.Forms.Label();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.pnlContra.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNivel
            // 
            this.lblNivel.AutoSize = true;
            this.lblNivel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblNivel.Location = new System.Drawing.Point(229, 9);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(46, 20);
            this.lblNivel.TabIndex = 33;
            this.lblNivel.Text = "Nivel:";
            // 
            // cboNivel
            // 
            this.cboNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNivel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboNivel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboNivel.FormattingEnabled = true;
            this.cboNivel.Location = new System.Drawing.Point(233, 32);
            this.cboNivel.Name = "cboNivel";
            this.cboNivel.Size = new System.Drawing.Size(215, 29);
            this.cboNivel.TabIndex = 1;
            this.cboNivel.SelectedIndexChanged += new System.EventHandler(this.cboNivel_SelectedIndexChanged);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblUsuario.Location = new System.Drawing.Point(8, 9);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(140, 20);
            this.lblUsuario.TabIndex = 31;
            this.lblUsuario.Text = "Nombre de usuario:";
            // 
            // chbContrasena
            // 
            this.chbContrasena.AutoSize = true;
            this.chbContrasena.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chbContrasena.Location = new System.Drawing.Point(12, 67);
            this.chbContrasena.Name = "chbContrasena";
            this.chbContrasena.Size = new System.Drawing.Size(171, 25);
            this.chbContrasena.TabIndex = 2;
            this.chbContrasena.Text = "Cambiar Contraseña";
            this.chbContrasena.UseVisualStyleBackColor = true;
            this.chbContrasena.CheckedChanged += new System.EventHandler(this.chbContrasena_CheckedChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAceptar.Image = global::GYM.Properties.Resources.ImgAceptar;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(341, 109);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(109, 37);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // pnlContra
            // 
            this.pnlContra.Controls.Add(this.txtAntiContra);
            this.pnlContra.Controls.Add(this.lblAntiContra);
            this.pnlContra.Controls.Add(this.lblRepContra);
            this.pnlContra.Controls.Add(this.txtRepContra);
            this.pnlContra.Controls.Add(this.txtContra);
            this.pnlContra.Controls.Add(this.lblContra);
            this.pnlContra.Location = new System.Drawing.Point(0, 98);
            this.pnlContra.Name = "pnlContra";
            this.pnlContra.Size = new System.Drawing.Size(460, 112);
            this.pnlContra.TabIndex = 3;
            this.pnlContra.Visible = false;
            // 
            // txtAntiContra
            // 
            this.txtAntiContra.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAntiContra.Location = new System.Drawing.Point(12, 23);
            this.txtAntiContra.Name = "txtAntiContra";
            this.txtAntiContra.PasswordChar = '•';
            this.txtAntiContra.Size = new System.Drawing.Size(215, 29);
            this.txtAntiContra.TabIndex = 0;
            // 
            // lblAntiContra
            // 
            this.lblAntiContra.AutoSize = true;
            this.lblAntiContra.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblAntiContra.Location = new System.Drawing.Point(8, 0);
            this.lblAntiContra.Name = "lblAntiContra";
            this.lblAntiContra.Size = new System.Drawing.Size(142, 20);
            this.lblAntiContra.TabIndex = 42;
            this.lblAntiContra.Text = "Contraseña anterior:";
            // 
            // lblRepContra
            // 
            this.lblRepContra.AutoSize = true;
            this.lblRepContra.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblRepContra.Location = new System.Drawing.Point(229, 55);
            this.lblRepContra.Name = "lblRepContra";
            this.lblRepContra.Size = new System.Drawing.Size(147, 20);
            this.lblRepContra.TabIndex = 40;
            this.lblRepContra.Text = "Repita la contraseña:";
            // 
            // txtRepContra
            // 
            this.txtRepContra.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtRepContra.Location = new System.Drawing.Point(233, 78);
            this.txtRepContra.Name = "txtRepContra";
            this.txtRepContra.PasswordChar = '•';
            this.txtRepContra.Size = new System.Drawing.Size(215, 29);
            this.txtRepContra.TabIndex = 2;
            // 
            // txtContra
            // 
            this.txtContra.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtContra.Location = new System.Drawing.Point(233, 23);
            this.txtContra.Name = "txtContra";
            this.txtContra.PasswordChar = '•';
            this.txtContra.Size = new System.Drawing.Size(215, 29);
            this.txtContra.TabIndex = 1;
            // 
            // lblContra
            // 
            this.lblContra.AutoSize = true;
            this.lblContra.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblContra.Location = new System.Drawing.Point(229, 0);
            this.lblContra.Name = "lblContra";
            this.lblContra.Size = new System.Drawing.Size(86, 20);
            this.lblContra.TabIndex = 38;
            this.lblContra.Text = "Contraseña:";
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblNombreUsuario.Location = new System.Drawing.Point(12, 32);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(64, 20);
            this.lblNombreUsuario.TabIndex = 34;
            this.lblNombreUsuario.Text = "Nombre";
            // 
            // frmEditarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 157);
            this.Controls.Add(this.lblNombreUsuario);
            this.Controls.Add(this.pnlContra);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.chbContrasena);
            this.Controls.Add(this.lblNivel);
            this.Controls.Add(this.cboNivel);
            this.Controls.Add(this.lblUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEditarUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Usuario";
            this.Load += new System.EventHandler(this.frmEditarUsuario_Load);
            this.pnlContra.ResumeLayout(false);
            this.pnlContra.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNivel;
        private System.Windows.Forms.ComboBox cboNivel;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.CheckBox chbContrasena;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Panel pnlContra;
        private System.Windows.Forms.Label lblRepContra;
        private System.Windows.Forms.TextBox txtRepContra;
        private System.Windows.Forms.TextBox txtContra;
        private System.Windows.Forms.Label lblContra;
        private System.Windows.Forms.TextBox txtAntiContra;
        private System.Windows.Forms.Label lblAntiContra;
        private System.Windows.Forms.Label lblNombreUsuario;

    }
}