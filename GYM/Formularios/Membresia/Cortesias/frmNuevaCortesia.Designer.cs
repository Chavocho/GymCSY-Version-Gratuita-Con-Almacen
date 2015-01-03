namespace GYM.Formularios.Membresia
{
    partial class frmNuevaCortesia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevaCortesia));
            this.cbxTipo = new System.Windows.Forms.ComboBox();
            this.lblEtiquetaTipo = new System.Windows.Forms.Label();
            this.lblEtiquetaFechaInicio = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.grbFechas = new System.Windows.Forms.GroupBox();
            this.lblEtiquetaFechaFin = new System.Windows.Forms.Label();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.txtComentarios = new System.Windows.Forms.TextBox();
            this.lblEtiquetaComentarios = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnMiembro = new System.Windows.Forms.Button();
            this.lblMiembro = new System.Windows.Forms.Label();
            this.grbFechas.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxTipo
            // 
            this.cbxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipo.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cbxTipo.FormattingEnabled = true;
            this.cbxTipo.Items.AddRange(new object[] {
            "1 Día",
            "2 Días",
            "3 Días",
            "4 Días",
            "5 Días",
            "6 Días",
            "1 Semana"});
            this.cbxTipo.Location = new System.Drawing.Point(6, 41);
            this.cbxTipo.Name = "cbxTipo";
            this.cbxTipo.Size = new System.Drawing.Size(178, 27);
            this.cbxTipo.TabIndex = 1;
            this.cbxTipo.SelectedIndexChanged += new System.EventHandler(this.cbxTipo_SelectedIndexChanged);
            // 
            // lblEtiquetaTipo
            // 
            this.lblEtiquetaTipo.AutoSize = true;
            this.lblEtiquetaTipo.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblEtiquetaTipo.Location = new System.Drawing.Point(6, 19);
            this.lblEtiquetaTipo.Name = "lblEtiquetaTipo";
            this.lblEtiquetaTipo.Size = new System.Drawing.Size(64, 19);
            this.lblEtiquetaTipo.TabIndex = 0;
            this.lblEtiquetaTipo.Text = "Duración";
            // 
            // lblEtiquetaFechaInicio
            // 
            this.lblEtiquetaFechaInicio.AutoSize = true;
            this.lblEtiquetaFechaInicio.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblEtiquetaFechaInicio.Location = new System.Drawing.Point(186, 20);
            this.lblEtiquetaFechaInicio.Name = "lblEtiquetaFechaInicio";
            this.lblEtiquetaFechaInicio.Size = new System.Drawing.Size(98, 19);
            this.lblEtiquetaFechaInicio.TabIndex = 2;
            this.lblEtiquetaFechaInicio.Text = "Fecha de inicio";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dtpFechaInicio.Location = new System.Drawing.Point(190, 42);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(178, 26);
            this.dtpFechaInicio.TabIndex = 3;
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.dtpFechaInicio_ValueChanged);
            // 
            // grbFechas
            // 
            this.grbFechas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbFechas.Controls.Add(this.lblEtiquetaFechaFin);
            this.grbFechas.Controls.Add(this.cbxTipo);
            this.grbFechas.Controls.Add(this.lblFechaFin);
            this.grbFechas.Controls.Add(this.lblEtiquetaFechaInicio);
            this.grbFechas.Controls.Add(this.lblEtiquetaTipo);
            this.grbFechas.Controls.Add(this.dtpFechaInicio);
            this.grbFechas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grbFechas.Location = new System.Drawing.Point(12, 12);
            this.grbFechas.Name = "grbFechas";
            this.grbFechas.Size = new System.Drawing.Size(586, 78);
            this.grbFechas.TabIndex = 0;
            this.grbFechas.TabStop = false;
            this.grbFechas.Text = "Configuración de fechas";
            // 
            // lblEtiquetaFechaFin
            // 
            this.lblEtiquetaFechaFin.AutoSize = true;
            this.lblEtiquetaFechaFin.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblEtiquetaFechaFin.Location = new System.Drawing.Point(374, 19);
            this.lblEtiquetaFechaFin.Name = "lblEtiquetaFechaFin";
            this.lblEtiquetaFechaFin.Size = new System.Drawing.Size(141, 19);
            this.lblEtiquetaFechaFin.TabIndex = 4;
            this.lblEtiquetaFechaFin.Text = "Fecha de vencimiento";
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFechaFin.Location = new System.Drawing.Point(374, 42);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(70, 21);
            this.lblFechaFin.TabIndex = 5;
            this.lblFechaFin.Text = "--/--/----";
            // 
            // txtComentarios
            // 
            this.txtComentarios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtComentarios.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtComentarios.Location = new System.Drawing.Point(12, 115);
            this.txtComentarios.Multiline = true;
            this.txtComentarios.Name = "txtComentarios";
            this.txtComentarios.Size = new System.Drawing.Size(295, 114);
            this.txtComentarios.TabIndex = 2;
            // 
            // lblEtiquetaComentarios
            // 
            this.lblEtiquetaComentarios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEtiquetaComentarios.AutoSize = true;
            this.lblEtiquetaComentarios.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblEtiquetaComentarios.Location = new System.Drawing.Point(8, 93);
            this.lblEtiquetaComentarios.Name = "lblEtiquetaComentarios";
            this.lblEtiquetaComentarios.Size = new System.Drawing.Size(87, 19);
            this.lblEtiquetaComentarios.TabIndex = 1;
            this.lblEtiquetaComentarios.Text = "Comentarios";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAceptar.Image = global::GYM.Properties.Resources.ImgAceptar;
            this.btnAceptar.Location = new System.Drawing.Point(496, 190);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(102, 39);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnMiembro
            // 
            this.btnMiembro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMiembro.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMiembro.Image = global::GYM.Properties.Resources.ImgBuscar;
            this.btnMiembro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMiembro.Location = new System.Drawing.Point(313, 190);
            this.btnMiembro.Name = "btnMiembro";
            this.btnMiembro.Size = new System.Drawing.Size(114, 39);
            this.btnMiembro.TabIndex = 4;
            this.btnMiembro.Text = "Buscar socio";
            this.btnMiembro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMiembro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMiembro.UseVisualStyleBackColor = true;
            this.btnMiembro.Click += new System.EventHandler(this.btnMiembro_Click);
            // 
            // lblMiembro
            // 
            this.lblMiembro.AutoSize = true;
            this.lblMiembro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMiembro.Location = new System.Drawing.Point(309, 94);
            this.lblMiembro.Name = "lblMiembro";
            this.lblMiembro.Size = new System.Drawing.Size(0, 19);
            this.lblMiembro.TabIndex = 3;
            // 
            // frmNuevaCortesia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 241);
            this.Controls.Add(this.lblMiembro);
            this.Controls.Add(this.btnMiembro);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblEtiquetaComentarios);
            this.Controls.Add(this.txtComentarios);
            this.Controls.Add(this.grbFechas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmNuevaCortesia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva Cortesía";
            this.grbFechas.ResumeLayout(false);
            this.grbFechas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxTipo;
        private System.Windows.Forms.Label lblEtiquetaTipo;
        private System.Windows.Forms.Label lblEtiquetaFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.GroupBox grbFechas;
        private System.Windows.Forms.Label lblEtiquetaFechaFin;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.TextBox txtComentarios;
        private System.Windows.Forms.Label lblEtiquetaComentarios;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnMiembro;
        private System.Windows.Forms.Label lblMiembro;
    }
}