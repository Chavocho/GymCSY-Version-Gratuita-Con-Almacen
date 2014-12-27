namespace GYM.Formularios.Caja
{
    partial class frmCortes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCortes));
            this.dgvCaja = new System.Windows.Forms.DataGridView();
            this.lblEtiquetaFechaFin = new System.Windows.Forms.Label();
            this.lblEtiquetaFechaInicio = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.bgwCortes = new System.ComponentModel.BackgroundWorker();
            this.tmrEspera = new System.Windows.Forms.Timer(this.components);
            this.btnBuscar = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Efectivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vouchers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaja)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCaja
            // 
            this.dgvCaja.AllowUserToAddRows = false;
            this.dgvCaja.AllowUserToDeleteRows = false;
            this.dgvCaja.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCaja.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.dgvCaja.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCaja.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvCaja.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCaja.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Fecha,
            this.Efectivo,
            this.Vouchers});
            this.dgvCaja.Location = new System.Drawing.Point(12, 60);
            this.dgvCaja.Name = "dgvCaja";
            this.dgvCaja.ReadOnly = true;
            this.dgvCaja.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCaja.RowHeadersVisible = false;
            this.dgvCaja.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCaja.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCaja.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCaja.Size = new System.Drawing.Size(640, 246);
            this.dgvCaja.TabIndex = 4;
            this.dgvCaja.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCaja_CellClick);
            // 
            // lblEtiquetaFechaFin
            // 
            this.lblEtiquetaFechaFin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEtiquetaFechaFin.AutoSize = true;
            this.lblEtiquetaFechaFin.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblEtiquetaFechaFin.Location = new System.Drawing.Point(353, 9);
            this.lblEtiquetaFechaFin.Name = "lblEtiquetaFechaFin";
            this.lblEtiquetaFechaFin.Size = new System.Drawing.Size(73, 13);
            this.lblEtiquetaFechaFin.TabIndex = 14;
            this.lblEtiquetaFechaFin.Text = "Fecha de fin:";
            // 
            // lblEtiquetaFechaInicio
            // 
            this.lblEtiquetaFechaInicio.AutoSize = true;
            this.lblEtiquetaFechaInicio.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblEtiquetaFechaInicio.Location = new System.Drawing.Point(9, 9);
            this.lblEtiquetaFechaInicio.Name = "lblEtiquetaFechaInicio";
            this.lblEtiquetaFechaInicio.Size = new System.Drawing.Size(87, 13);
            this.lblEtiquetaFechaInicio.TabIndex = 13;
            this.lblEtiquetaFechaInicio.Text = "Fecha de inicio:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaFin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFechaFin.Location = new System.Drawing.Point(356, 25);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(296, 29);
            this.dtpFechaFin.TabIndex = 12;
            this.dtpFechaFin.ValueChanged += new System.EventHandler(this.dtpFechas_ValueChanged);
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFechaInicio.Location = new System.Drawing.Point(12, 25);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(296, 29);
            this.dtpFechaInicio.TabIndex = 11;
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.dtpFechas_ValueChanged);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnImprimir.Image = global::GYM.Properties.Resources.impresora;
            this.btnImprimir.Location = new System.Drawing.Point(384, 318);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(102, 35);
            this.btnImprimir.TabIndex = 15;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // bgwCortes
            // 
            this.bgwCortes.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCortes_DoWork);
            this.bgwCortes.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwCortes_RunWorkerCompleted);
            // 
            // tmrEspera
            // 
            this.tmrEspera.Interval = 300;
            this.tmrEspera.Tick += new System.EventHandler(this.tmrEspera_Tick);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Image = global::GYM.Properties.Resources.ImgBuscar;
            this.btnBuscar.Location = new System.Drawing.Point(532, 318);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(104, 37);
            this.btnBuscar.TabIndex = 16;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.button1_Click);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // Efectivo
            // 
            this.Efectivo.HeaderText = "Efectivo retirado";
            this.Efectivo.Name = "Efectivo";
            this.Efectivo.ReadOnly = true;
            this.Efectivo.Width = 150;
            // 
            // Vouchers
            // 
            this.Vouchers.HeaderText = "Vouchers";
            this.Vouchers.Name = "Vouchers";
            this.Vouchers.ReadOnly = true;
            this.Vouchers.Width = 150;
            // 
            // frmCortes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 359);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lblEtiquetaFechaFin);
            this.Controls.Add(this.lblEtiquetaFechaInicio);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.dgvCaja);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCortes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cortes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaja)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCaja;
        private System.Windows.Forms.Label lblEtiquetaFechaFin;
        private System.Windows.Forms.Label lblEtiquetaFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Button btnImprimir;
        private System.ComponentModel.BackgroundWorker bgwCortes;
        private System.Windows.Forms.Timer tmrEspera;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Efectivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vouchers;
    }
}