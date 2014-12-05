namespace GYM.Informes
{
    partial class frmSociosInactivos
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnPdf = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dgvMembresiasInactivas = new System.Windows.Forms.DataGridView();
            this.btnInformacion = new System.Windows.Forms.Button();
            this.numeroSocio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.celular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembresiasInactivas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(29, 28);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(286, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Socios con membresías inactivas";
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExcel.Location = new System.Drawing.Point(298, 519);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(124, 30);
            this.btnExcel.TabIndex = 3;
            this.btnExcel.Text = "Exportar a Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            // 
            // btnPdf
            // 
            this.btnPdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPdf.Location = new System.Drawing.Point(507, 519);
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Size = new System.Drawing.Size(124, 30);
            this.btnPdf.TabIndex = 4;
            this.btnPdf.Text = "Exportar PDF";
            this.btnPdf.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Location = new System.Drawing.Point(748, 519);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(124, 30);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dgvMembresiasInactivas
            // 
            this.dgvMembresiasInactivas.AllowUserToAddRows = false;
            this.dgvMembresiasInactivas.AllowUserToDeleteRows = false;
            this.dgvMembresiasInactivas.AllowUserToResizeColumns = false;
            this.dgvMembresiasInactivas.AllowUserToResizeRows = false;
            this.dgvMembresiasInactivas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMembresiasInactivas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMembresiasInactivas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMembresiasInactivas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembresiasInactivas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numeroSocio,
            this.nombre,
            this.telefono,
            this.celular,
            this.email,
            this.fechaVencimiento,
            this.fechaInicio,
            this.fechaRegistro});
            this.dgvMembresiasInactivas.Location = new System.Drawing.Point(34, 74);
            this.dgvMembresiasInactivas.MultiSelect = false;
            this.dgvMembresiasInactivas.Name = "dgvMembresiasInactivas";
            this.dgvMembresiasInactivas.ReadOnly = true;
            this.dgvMembresiasInactivas.RowHeadersVisible = false;
            this.dgvMembresiasInactivas.RowHeadersWidth = 100;
            this.dgvMembresiasInactivas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMembresiasInactivas.Size = new System.Drawing.Size(813, 414);
            this.dgvMembresiasInactivas.TabIndex = 7;
            // 
            // btnInformacion
            // 
            this.btnInformacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInformacion.Location = new System.Drawing.Point(45, 519);
            this.btnInformacion.Name = "btnInformacion";
            this.btnInformacion.Size = new System.Drawing.Size(124, 30);
            this.btnInformacion.TabIndex = 8;
            this.btnInformacion.Text = "Visualizar membresías";
            this.btnInformacion.UseVisualStyleBackColor = true;
            this.btnInformacion.Click += new System.EventHandler(this.btnInformacion_Click);
            // 
            // numeroSocio
            // 
            this.numeroSocio.HeaderText = "Socio";
            this.numeroSocio.Name = "numeroSocio";
            this.numeroSocio.ReadOnly = true;
            this.numeroSocio.Width = 59;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre y apellido";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 106;
            // 
            // telefono
            // 
            this.telefono.HeaderText = "Telefono";
            this.telefono.Name = "telefono";
            this.telefono.ReadOnly = true;
            this.telefono.Width = 74;
            // 
            // celular
            // 
            this.celular.HeaderText = "Celular";
            this.celular.Name = "celular";
            this.celular.ReadOnly = true;
            this.celular.Width = 64;
            // 
            // email
            // 
            this.email.HeaderText = "E-mail";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            this.email.Width = 60;
            // 
            // fechaVencimiento
            // 
            this.fechaVencimiento.HeaderText = "Fecha de vencimiento";
            this.fechaVencimiento.Name = "fechaVencimiento";
            this.fechaVencimiento.ReadOnly = true;
            this.fechaVencimiento.Width = 125;
            // 
            // fechaInicio
            // 
            this.fechaInicio.HeaderText = "Ultima membresía adquirida";
            this.fechaInicio.Name = "fechaInicio";
            this.fechaInicio.ReadOnly = true;
            this.fechaInicio.Width = 148;
            // 
            // fechaRegistro
            // 
            this.fechaRegistro.HeaderText = "Fecha de registro";
            this.fechaRegistro.Name = "fechaRegistro";
            this.fechaRegistro.ReadOnly = true;
            this.fechaRegistro.Width = 105;
            // 
            // frmSociosInactivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.btnInformacion);
            this.Controls.Add(this.dgvMembresiasInactivas);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnPdf);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.lblTitulo);
            this.Name = "frmSociosInactivos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Socios Membresías Inactivas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSociosInactivos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembresiasInactivas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnPdf;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgvMembresiasInactivas;
        private System.Windows.Forms.Button btnInformacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroSocio;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn celular;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaVencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistro;
    }
}