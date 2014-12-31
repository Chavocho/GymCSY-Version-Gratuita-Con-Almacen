namespace GYM.Formularios.POS
{
    partial class frmCancelarVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCancelarVenta));
            this.txtFolio = new System.Windows.Forms.TextBox();
            this.lblInstrucciones = new System.Windows.Forms.Label();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbFechas = new System.Windows.Forms.GroupBox();
            this.lblEtiquetaInicio = new System.Windows.Forms.Label();
            this.lblEtiquetaFin = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.grbFechas.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFolio
            // 
            this.txtFolio.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtFolio.Location = new System.Drawing.Point(446, 49);
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.Size = new System.Drawing.Size(226, 29);
            this.txtFolio.TabIndex = 28;
            this.txtFolio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFolio_KeyDown);
            // 
            // lblInstrucciones
            // 
            this.lblInstrucciones.AutoSize = true;
            this.lblInstrucciones.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInstrucciones.Location = new System.Drawing.Point(442, 26);
            this.lblInstrucciones.Name = "lblInstrucciones";
            this.lblInstrucciones.Size = new System.Drawing.Size(107, 19);
            this.lblInstrucciones.TabIndex = 31;
            this.lblInstrucciones.Text = "Buscar por folio:";
            // 
            // dgvVentas
            // 
            this.dgvVentas.AllowUserToAddRows = false;
            this.dgvVentas.AllowUserToDeleteRows = false;
            this.dgvVentas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvVentas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.dgvVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVentas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvVentas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Fecha,
            this.Total,
            this.Estado});
            this.dgvVentas.Location = new System.Drawing.Point(12, 95);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.ReadOnly = true;
            this.dgvVentas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvVentas.RowHeadersVisible = false;
            this.dgvVentas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvVentas.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVentas.Size = new System.Drawing.Size(660, 238);
            this.dgvVentas.TabIndex = 29;
            this.dgvVentas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVentas_CellClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "Folio";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 130;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Width = 120;
            // 
            // grbFechas
            // 
            this.grbFechas.Controls.Add(this.lblEtiquetaInicio);
            this.grbFechas.Controls.Add(this.lblEtiquetaFin);
            this.grbFechas.Controls.Add(this.dtpFechaInicio);
            this.grbFechas.Controls.Add(this.dtpFechaFin);
            this.grbFechas.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.grbFechas.Location = new System.Drawing.Point(12, 9);
            this.grbFechas.Name = "grbFechas";
            this.grbFechas.Size = new System.Drawing.Size(424, 76);
            this.grbFechas.TabIndex = 27;
            this.grbFechas.TabStop = false;
            this.grbFechas.Text = "Buscar por fechas";
            // 
            // lblEtiquetaInicio
            // 
            this.lblEtiquetaInicio.AutoSize = true;
            this.lblEtiquetaInicio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEtiquetaInicio.Location = new System.Drawing.Point(6, 17);
            this.lblEtiquetaInicio.Name = "lblEtiquetaInicio";
            this.lblEtiquetaInicio.Size = new System.Drawing.Size(83, 19);
            this.lblEtiquetaInicio.TabIndex = 30;
            this.lblEtiquetaInicio.Text = "Fecha Inicio:";
            // 
            // lblEtiquetaFin
            // 
            this.lblEtiquetaFin.AutoSize = true;
            this.lblEtiquetaFin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEtiquetaFin.Location = new System.Drawing.Point(208, 17);
            this.lblEtiquetaFin.Name = "lblEtiquetaFin";
            this.lblEtiquetaFin.Size = new System.Drawing.Size(69, 19);
            this.lblEtiquetaFin.TabIndex = 31;
            this.lblEtiquetaFin.Text = "Fecha Fin:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFechaInicio.Location = new System.Drawing.Point(6, 40);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(200, 29);
            this.dtpFechaInicio.TabIndex = 0;
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.dtpFechas_ValueChanged);
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFechaFin.Location = new System.Drawing.Point(212, 40);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(200, 29);
            this.dtpFechaFin.TabIndex = 1;
            this.dtpFechaFin.ValueChanged += new System.EventHandler(this.dtpFechas_ValueChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnCancelar.FlatAppearance.BorderSize = 2;
            this.btnCancelar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancelar.Image = global::GYM.Properties.Resources.ImgCancelar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(517, 339);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(155, 40);
            this.btnCancelar.TabIndex = 32;
            this.btnCancelar.Text = "Cancelar venta";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmCancelarVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 391);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtFolio);
            this.Controls.Add(this.lblInstrucciones);
            this.Controls.Add(this.dgvVentas);
            this.Controls.Add(this.grbFechas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCancelarVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cancelar Venta";
            this.Load += new System.EventHandler(this.frmCancelarVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.grbFechas.ResumeLayout(false);
            this.grbFechas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFolio;
        private System.Windows.Forms.Label lblInstrucciones;
        public System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.GroupBox grbFechas;
        private System.Windows.Forms.Label lblEtiquetaInicio;
        private System.Windows.Forms.Label lblEtiquetaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Button btnCancelar;
    }
}