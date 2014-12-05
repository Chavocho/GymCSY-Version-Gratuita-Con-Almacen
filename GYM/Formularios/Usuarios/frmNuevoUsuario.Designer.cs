namespace GYM.Formularios
{
    partial class frmNuevoUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevoUsuario));
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtNombreUsu = new System.Windows.Forms.TextBox();
            this.lblContra = new System.Windows.Forms.Label();
            this.txtContra = new System.Windows.Forms.TextBox();
            this.lblRepContra = new System.Windows.Forms.Label();
            this.txtRepContra = new System.Windows.Forms.TextBox();
            this.cboNivel = new System.Windows.Forms.ComboBox();
            this.lblNivel = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblUsuario.Location = new System.Drawing.Point(8, 9);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(140, 20);
            this.lblUsuario.TabIndex = 23;
            this.lblUsuario.Text = "Nombre de usuario:";
            // 
            // txtNombreUsu
            // 
            this.txtNombreUsu.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtNombreUsu.Location = new System.Drawing.Point(12, 32);
            this.txtNombreUsu.Name = "txtNombreUsu";
            this.txtNombreUsu.Size = new System.Drawing.Size(215, 29);
            this.txtNombreUsu.TabIndex = 22;
            // 
            // lblContra
            // 
            this.lblContra.AutoSize = true;
            this.lblContra.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblContra.Location = new System.Drawing.Point(229, 9);
            this.lblContra.Name = "lblContra";
            this.lblContra.Size = new System.Drawing.Size(86, 20);
            this.lblContra.TabIndex = 25;
            this.lblContra.Text = "Contraseña:";
            // 
            // txtContra
            // 
            this.txtContra.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtContra.Location = new System.Drawing.Point(233, 32);
            this.txtContra.Name = "txtContra";
            this.txtContra.PasswordChar = '•';
            this.txtContra.Size = new System.Drawing.Size(215, 29);
            this.txtContra.TabIndex = 24;
            // 
            // lblRepContra
            // 
            this.lblRepContra.AutoSize = true;
            this.lblRepContra.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblRepContra.Location = new System.Drawing.Point(229, 64);
            this.lblRepContra.Name = "lblRepContra";
            this.lblRepContra.Size = new System.Drawing.Size(147, 20);
            this.lblRepContra.TabIndex = 27;
            this.lblRepContra.Text = "Repita la contraseña:";
            // 
            // txtRepContra
            // 
            this.txtRepContra.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtRepContra.Location = new System.Drawing.Point(233, 87);
            this.txtRepContra.Name = "txtRepContra";
            this.txtRepContra.PasswordChar = '•';
            this.txtRepContra.Size = new System.Drawing.Size(215, 29);
            this.txtRepContra.TabIndex = 26;
            // 
            // cboNivel
            // 
            this.cboNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNivel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboNivel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboNivel.FormattingEnabled = true;
            this.cboNivel.Location = new System.Drawing.Point(12, 87);
            this.cboNivel.Name = "cboNivel";
            this.cboNivel.Size = new System.Drawing.Size(215, 29);
            this.cboNivel.TabIndex = 28;
            this.cboNivel.SelectedIndexChanged += new System.EventHandler(this.cboNivel_SelectedIndexChanged);
            // 
            // lblNivel
            // 
            this.lblNivel.AutoSize = true;
            this.lblNivel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblNivel.Location = new System.Drawing.Point(8, 64);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(46, 20);
            this.lblNivel.TabIndex = 29;
            this.lblNivel.Text = "Nivel:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAceptar.Image = global::GYM.Properties.Resources.ImgAceptar;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(339, 143);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(109, 37);
            this.btnAceptar.TabIndex = 30;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmNuevoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 192);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblNivel);
            this.Controls.Add(this.cboNivel);
            this.Controls.Add(this.lblRepContra);
            this.Controls.Add(this.txtRepContra);
            this.Controls.Add(this.lblContra);
            this.Controls.Add(this.txtContra);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtNombreUsu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNuevoUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo Usuario";
            this.Load += new System.EventHandler(this.frmNuevoUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtNombreUsu;
        private System.Windows.Forms.Label lblContra;
        private System.Windows.Forms.TextBox txtContra;
        private System.Windows.Forms.Label lblRepContra;
        private System.Windows.Forms.TextBox txtRepContra;
        private System.Windows.Forms.ComboBox cboNivel;
        private System.Windows.Forms.Label lblNivel;
        private System.Windows.Forms.Button btnAceptar;
    }
}