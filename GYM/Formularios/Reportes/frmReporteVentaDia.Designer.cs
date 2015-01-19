namespace GYM.Formularios.Reportes
{
    partial class frmReporteVentaDia
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteVentaDia));
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.cboTurno = new System.Windows.Forms.ComboBox();
            this.lblETurno = new System.Windows.Forms.Label();
            this.pnlProductos = new System.Windows.Forms.Panel();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblEFecha = new System.Windows.Forms.Label();
            this.lblEReporte = new System.Windows.Forms.Label();
            this.cboReporte = new System.Windows.Forms.ComboBox();
            this.bgwMembresia = new System.ComponentModel.BackgroundWorker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.bgwVentas = new System.ComponentModel.BackgroundWorker();
            this.tmrEspera = new System.Windows.Forms.Timer(this.components);
            this.lblETotal = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblEfectivo = new System.Windows.Forms.Label();
            this.lblEEfectivo = new System.Windows.Forms.Label();
            this.lblVoucher = new System.Windows.Forms.Label();
            this.lblEVoucher = new System.Windows.Forms.Label();
            this.CID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNumSocio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CEfectivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CVouchers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CFolio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVentas
            // 
            this.dgvVentas.AllowUserToAddRows = false;
            this.dgvVentas.AllowUserToDeleteRows = false;
            this.dgvVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVentas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.dgvVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVentas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvVentas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CID,
            this.CNumSocio,
            this.CEfectivo,
            this.CVouchers,
            this.CFolio,
            this.CHora,
            this.CDescripcion,
            this.CUsuario});
            this.dgvVentas.Location = new System.Drawing.Point(12, 43);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.ReadOnly = true;
            this.dgvVentas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvVentas.RowHeadersVisible = false;
            this.dgvVentas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvVentas.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVentas.Size = new System.Drawing.Size(984, 423);
            this.dgvVentas.TabIndex = 3;
            this.dgvVentas.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVentas_RowEnter);
            // 
            // cboTurno
            // 
            this.cboTurno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTurno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTurno.FormattingEnabled = true;
            this.cboTurno.Items.AddRange(new object[] {
            "Matutino",
            "Vespertino"});
            this.cboTurno.Location = new System.Drawing.Point(710, 12);
            this.cboTurno.Name = "cboTurno";
            this.cboTurno.Size = new System.Drawing.Size(205, 25);
            this.cboTurno.TabIndex = 4;
            // 
            // lblETurno
            // 
            this.lblETurno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblETurno.AutoSize = true;
            this.lblETurno.Location = new System.Drawing.Point(656, 15);
            this.lblETurno.Name = "lblETurno";
            this.lblETurno.Size = new System.Drawing.Size(48, 19);
            this.lblETurno.TabIndex = 5;
            this.lblETurno.Text = "Turno:";
            // 
            // pnlProductos
            // 
            this.pnlProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProductos.AutoScroll = true;
            this.pnlProductos.BackColor = System.Drawing.SystemColors.Control;
            this.pnlProductos.Location = new System.Drawing.Point(12, 472);
            this.pnlProductos.Name = "pnlProductos";
            this.pnlProductos.Size = new System.Drawing.Size(984, 225);
            this.pnlProductos.TabIndex = 6;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFecha.CustomFormat = "dd \'de\'MMMM\'del\' yyyy";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(150, 12);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(196, 25);
            this.dtpFecha.TabIndex = 7;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // lblEFecha
            // 
            this.lblEFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEFecha.AutoSize = true;
            this.lblEFecha.Location = new System.Drawing.Point(99, 15);
            this.lblEFecha.Name = "lblEFecha";
            this.lblEFecha.Size = new System.Drawing.Size(44, 19);
            this.lblEFecha.TabIndex = 8;
            this.lblEFecha.Text = "Fecha";
            // 
            // lblEReporte
            // 
            this.lblEReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEReporte.AutoSize = true;
            this.lblEReporte.Location = new System.Drawing.Point(352, 15);
            this.lblEReporte.Name = "lblEReporte";
            this.lblEReporte.Size = new System.Drawing.Size(87, 19);
            this.lblEReporte.TabIndex = 10;
            this.lblEReporte.Text = "Tipo reporte:";
            // 
            // cboReporte
            // 
            this.cboReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboReporte.FormattingEnabled = true;
            this.cboReporte.Items.AddRange(new object[] {
            "Membresías",
            "Ventas"});
            this.cboReporte.Location = new System.Drawing.Point(445, 12);
            this.cboReporte.Name = "cboReporte";
            this.cboReporte.Size = new System.Drawing.Size(205, 25);
            this.cboReporte.TabIndex = 9;
            // 
            // bgwMembresia
            // 
            this.bgwMembresia.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwMembresia_DoWork);
            this.bgwMembresia.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwMembresia_RunWorkerCompleted);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnBuscar.Location = new System.Drawing.Point(921, 12);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 25);
            this.btnBuscar.TabIndex = 11;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // bgwVentas
            // 
            this.bgwVentas.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwVentas_DoWork);
            this.bgwVentas.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwVentas_RunWorkerCompleted);
            // 
            // tmrEspera
            // 
            this.tmrEspera.Interval = 300;
            this.tmrEspera.Tick += new System.EventHandler(this.tmrEspera_Tick);
            // 
            // lblETotal
            // 
            this.lblETotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblETotal.AutoSize = true;
            this.lblETotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblETotal.Location = new System.Drawing.Point(12, 700);
            this.lblETotal.Name = "lblETotal";
            this.lblETotal.Size = new System.Drawing.Size(248, 21);
            this.lblETotal.TabIndex = 12;
            this.lblETotal.Text = "Total de ventas de membresías:";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTotal.Location = new System.Drawing.Point(266, 701);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(44, 20);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "$0.00";
            // 
            // lblEfectivo
            // 
            this.lblEfectivo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblEfectivo.AutoSize = true;
            this.lblEfectivo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblEfectivo.Location = new System.Drawing.Point(586, 701);
            this.lblEfectivo.Name = "lblEfectivo";
            this.lblEfectivo.Size = new System.Drawing.Size(44, 20);
            this.lblEfectivo.TabIndex = 15;
            this.lblEfectivo.Text = "$0.00";
            // 
            // lblEEfectivo
            // 
            this.lblEEfectivo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblEEfectivo.AutoSize = true;
            this.lblEEfectivo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEEfectivo.Location = new System.Drawing.Point(343, 700);
            this.lblEEfectivo.Name = "lblEEfectivo";
            this.lblEEfectivo.Size = new System.Drawing.Size(237, 21);
            this.lblEEfectivo.TabIndex = 14;
            this.lblEEfectivo.Text = "Total efectivo de membresías:";
            // 
            // lblVoucher
            // 
            this.lblVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVoucher.AutoSize = true;
            this.lblVoucher.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblVoucher.Location = new System.Drawing.Point(913, 701);
            this.lblVoucher.Name = "lblVoucher";
            this.lblVoucher.Size = new System.Drawing.Size(44, 20);
            this.lblVoucher.TabIndex = 17;
            this.lblVoucher.Text = "$0.00";
            // 
            // lblEVoucher
            // 
            this.lblEVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEVoucher.AutoSize = true;
            this.lblEVoucher.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEVoucher.Location = new System.Drawing.Point(663, 700);
            this.lblEVoucher.Name = "lblEVoucher";
            this.lblEVoucher.Size = new System.Drawing.Size(244, 21);
            this.lblEVoucher.TabIndex = 16;
            this.lblEVoucher.Text = "Total vouchers de membresías:";
            // 
            // CID
            // 
            this.CID.HeaderText = "ID";
            this.CID.Name = "CID";
            this.CID.ReadOnly = true;
            this.CID.Visible = false;
            // 
            // CNumSocio
            // 
            this.CNumSocio.HeaderText = "Núm. Socio";
            this.CNumSocio.Name = "CNumSocio";
            this.CNumSocio.ReadOnly = true;
            // 
            // CEfectivo
            // 
            this.CEfectivo.HeaderText = "Efectivo";
            this.CEfectivo.Name = "CEfectivo";
            this.CEfectivo.ReadOnly = true;
            // 
            // CVouchers
            // 
            this.CVouchers.HeaderText = "Vouchers";
            this.CVouchers.Name = "CVouchers";
            this.CVouchers.ReadOnly = true;
            // 
            // CFolio
            // 
            this.CFolio.HeaderText = "Folio";
            this.CFolio.Name = "CFolio";
            this.CFolio.ReadOnly = true;
            this.CFolio.Width = 130;
            // 
            // CHora
            // 
            dataGridViewCellStyle1.Format = "hh:mm tt";
            this.CHora.DefaultCellStyle = dataGridViewCellStyle1;
            this.CHora.HeaderText = "Hora";
            this.CHora.Name = "CHora";
            this.CHora.ReadOnly = true;
            // 
            // CDescripcion
            // 
            this.CDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CDescripcion.HeaderText = "Descripción";
            this.CDescripcion.Name = "CDescripcion";
            this.CDescripcion.ReadOnly = true;
            // 
            // CUsuario
            // 
            this.CUsuario.HeaderText = "Atendió";
            this.CUsuario.Name = "CUsuario";
            this.CUsuario.ReadOnly = true;
            this.CUsuario.Width = 150;
            // 
            // frmReporteVentaDia
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.lblVoucher);
            this.Controls.Add(this.lblEVoucher);
            this.Controls.Add(this.lblEfectivo);
            this.Controls.Add(this.lblEEfectivo);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblETotal);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblEReporte);
            this.Controls.Add(this.cboReporte);
            this.Controls.Add(this.lblEFecha);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.pnlProductos);
            this.Controls.Add(this.lblETurno);
            this.Controls.Add(this.cboTurno);
            this.Controls.Add(this.dgvVentas);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReporteVentaDia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Reporte de venta diario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.ComboBox cboTurno;
        private System.Windows.Forms.Label lblETurno;
        private System.Windows.Forms.Panel pnlProductos;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblEFecha;
        private System.Windows.Forms.Label lblEReporte;
        private System.Windows.Forms.ComboBox cboReporte;
        private System.ComponentModel.BackgroundWorker bgwMembresia;
        private System.Windows.Forms.Button btnBuscar;
        private System.ComponentModel.BackgroundWorker bgwVentas;
        private System.Windows.Forms.Timer tmrEspera;
        private System.Windows.Forms.Label lblETotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblEfectivo;
        private System.Windows.Forms.Label lblEEfectivo;
        private System.Windows.Forms.Label lblVoucher;
        private System.Windows.Forms.Label lblEVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn CID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNumSocio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CEfectivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CVouchers;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFolio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUsuario;
    }
}