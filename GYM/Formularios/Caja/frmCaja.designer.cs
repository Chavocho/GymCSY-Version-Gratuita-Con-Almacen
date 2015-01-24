namespace GYM.Formularios
{
    partial class frmCaja
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCaja));
            this.dgvCaja = new System.Windows.Forms.DataGridView();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Efectivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vouchers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEntrada = new System.Windows.Forms.Button();
            this.btnSalida = new System.Windows.Forms.Button();
            this.btnAbrirCerrar = new System.Windows.Forms.Button();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.grbFechas = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblEtiquetaFechaFin = new System.Windows.Forms.Label();
            this.lblEtiquetaFechaInicio = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.lblEtiquetaEfectivo01 = new System.Windows.Forms.Label();
            this.lblEtiquetaEfectivo02 = new System.Windows.Forms.Label();
            this.grbTotales = new System.Windows.Forms.GroupBox();
            this.lblVouchersCaja = new System.Windows.Forms.Label();
            this.lblVouchersMostrado = new System.Windows.Forms.Label();
            this.lblEtiquetaVouchers01 = new System.Windows.Forms.Label();
            this.lblEtiquetaVouchers02 = new System.Windows.Forms.Label();
            this.lblEfectivoCaja = new System.Windows.Forms.Label();
            this.lblEfectivoMostrado = new System.Windows.Forms.Label();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.chbRespetarFechas = new System.Windows.Forms.CheckBox();
            this.grbConcepto = new System.Windows.Forms.GroupBox();
            this.btnBuscarConcepto = new System.Windows.Forms.Button();
            this.bgwCaja = new System.ComponentModel.BackgroundWorker();
            this.tmrEspera = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaja)).BeginInit();
            this.grbFechas.SuspendLayout();
            this.grbTotales.SuspendLayout();
            this.grbConcepto.SuspendLayout();
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
            this.Fecha,
            this.Efectivo,
            this.Vouchers,
            this.TipoMovimiento,
            this.Descripcion,
            this.CVendedor});
            this.dgvCaja.Location = new System.Drawing.Point(12, 100);
            this.dgvCaja.Name = "dgvCaja";
            this.dgvCaja.ReadOnly = true;
            this.dgvCaja.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCaja.RowHeadersVisible = false;
            this.dgvCaja.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCaja.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCaja.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCaja.Size = new System.Drawing.Size(984, 242);
            this.dgvCaja.TabIndex = 2;
            // 
            // Fecha
            // 
            dataGridViewCellStyle1.Format = "dd \'de\' MMMM \'del\' yyyy hh:mm:ss tt";
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle1;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 200;
            // 
            // Efectivo
            // 
            dataGridViewCellStyle2.Format = "C2";
            this.Efectivo.DefaultCellStyle = dataGridViewCellStyle2;
            this.Efectivo.HeaderText = "Efectivo";
            this.Efectivo.Name = "Efectivo";
            this.Efectivo.ReadOnly = true;
            // 
            // Vouchers
            // 
            dataGridViewCellStyle3.Format = "C2";
            this.Vouchers.DefaultCellStyle = dataGridViewCellStyle3;
            this.Vouchers.HeaderText = "Vouchers";
            this.Vouchers.Name = "Vouchers";
            this.Vouchers.ReadOnly = true;
            // 
            // TipoMovimiento
            // 
            this.TipoMovimiento.HeaderText = "Tipo de movimiento";
            this.TipoMovimiento.Name = "TipoMovimiento";
            this.TipoMovimiento.ReadOnly = true;
            this.TipoMovimiento.Width = 150;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // CVendedor
            // 
            this.CVendedor.HeaderText = "Atendió";
            this.CVendedor.Name = "CVendedor";
            this.CVendedor.ReadOnly = true;
            this.CVendedor.Width = 150;
            // 
            // btnEntrada
            // 
            this.btnEntrada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEntrada.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnEntrada.Location = new System.Drawing.Point(12, 439);
            this.btnEntrada.Name = "btnEntrada";
            this.btnEntrada.Size = new System.Drawing.Size(95, 30);
            this.btnEntrada.TabIndex = 6;
            this.btnEntrada.Text = "Entrada";
            this.btnEntrada.UseVisualStyleBackColor = true;
            this.btnEntrada.Click += new System.EventHandler(this.btnEntrada_Click);
            // 
            // btnSalida
            // 
            this.btnSalida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSalida.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnSalida.Location = new System.Drawing.Point(113, 439);
            this.btnSalida.Name = "btnSalida";
            this.btnSalida.Size = new System.Drawing.Size(95, 30);
            this.btnSalida.TabIndex = 5;
            this.btnSalida.Text = "Salida";
            this.btnSalida.UseVisualStyleBackColor = true;
            this.btnSalida.Click += new System.EventHandler(this.btnSalida_Click);
            // 
            // btnAbrirCerrar
            // 
            this.btnAbrirCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbrirCerrar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnAbrirCerrar.Location = new System.Drawing.Point(872, 439);
            this.btnAbrirCerrar.Name = "btnAbrirCerrar";
            this.btnAbrirCerrar.Size = new System.Drawing.Size(124, 30);
            this.btnAbrirCerrar.TabIndex = 4;
            this.btnAbrirCerrar.Text = "Abrir Caja";
            this.btnAbrirCerrar.UseVisualStyleBackColor = true;
            this.btnAbrirCerrar.Click += new System.EventHandler(this.btnAbrirCerrar_Click);
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFechaInicio.Location = new System.Drawing.Point(6, 35);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(280, 29);
            this.dtpFechaInicio.TabIndex = 1;
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.dtpFechas_ValueChanged);
            // 
            // grbFechas
            // 
            this.grbFechas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grbFechas.Controls.Add(this.btnBuscar);
            this.grbFechas.Controls.Add(this.lblEtiquetaFechaFin);
            this.grbFechas.Controls.Add(this.lblEtiquetaFechaInicio);
            this.grbFechas.Controls.Add(this.dtpFechaFin);
            this.grbFechas.Controls.Add(this.dtpFechaInicio);
            this.grbFechas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grbFechas.Location = new System.Drawing.Point(12, 12);
            this.grbFechas.Name = "grbFechas";
            this.grbFechas.Size = new System.Drawing.Size(675, 82);
            this.grbFechas.TabIndex = 0;
            this.grbFechas.TabStop = false;
            this.grbFechas.Text = "Buscar por fechas";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnBuscar.Location = new System.Drawing.Point(578, 43);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(91, 21);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblEtiquetaFechaFin
            // 
            this.lblEtiquetaFechaFin.AutoSize = true;
            this.lblEtiquetaFechaFin.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblEtiquetaFechaFin.Location = new System.Drawing.Point(289, 19);
            this.lblEtiquetaFechaFin.Name = "lblEtiquetaFechaFin";
            this.lblEtiquetaFechaFin.Size = new System.Drawing.Size(73, 13);
            this.lblEtiquetaFechaFin.TabIndex = 2;
            this.lblEtiquetaFechaFin.Text = "Fecha de fin:";
            // 
            // lblEtiquetaFechaInicio
            // 
            this.lblEtiquetaFechaInicio.AutoSize = true;
            this.lblEtiquetaFechaInicio.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblEtiquetaFechaInicio.Location = new System.Drawing.Point(6, 19);
            this.lblEtiquetaFechaInicio.Name = "lblEtiquetaFechaInicio";
            this.lblEtiquetaFechaInicio.Size = new System.Drawing.Size(87, 13);
            this.lblEtiquetaFechaInicio.TabIndex = 0;
            this.lblEtiquetaFechaInicio.Text = "Fecha de inicio:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFechaFin.Location = new System.Drawing.Point(292, 35);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(280, 29);
            this.dtpFechaFin.TabIndex = 3;
            this.dtpFechaFin.ValueChanged += new System.EventHandler(this.dtpFechas_ValueChanged);
            // 
            // lblEtiquetaEfectivo01
            // 
            this.lblEtiquetaEfectivo01.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEtiquetaEfectivo01.AutoSize = true;
            this.lblEtiquetaEfectivo01.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEtiquetaEfectivo01.Location = new System.Drawing.Point(6, 19);
            this.lblEtiquetaEfectivo01.Name = "lblEtiquetaEfectivo01";
            this.lblEtiquetaEfectivo01.Size = new System.Drawing.Size(175, 19);
            this.lblEtiquetaEfectivo01.TabIndex = 0;
            this.lblEtiquetaEfectivo01.Text = "Total de efectivo mostrado:";
            // 
            // lblEtiquetaEfectivo02
            // 
            this.lblEtiquetaEfectivo02.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEtiquetaEfectivo02.AutoSize = true;
            this.lblEtiquetaEfectivo02.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEtiquetaEfectivo02.Location = new System.Drawing.Point(23, 55);
            this.lblEtiquetaEfectivo02.Name = "lblEtiquetaEfectivo02";
            this.lblEtiquetaEfectivo02.Size = new System.Drawing.Size(158, 19);
            this.lblEtiquetaEfectivo02.TabIndex = 2;
            this.lblEtiquetaEfectivo02.Text = "Total de efectivo en caja:";
            // 
            // grbTotales
            // 
            this.grbTotales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbTotales.Controls.Add(this.lblVouchersCaja);
            this.grbTotales.Controls.Add(this.lblVouchersMostrado);
            this.grbTotales.Controls.Add(this.lblEtiquetaVouchers01);
            this.grbTotales.Controls.Add(this.lblEtiquetaVouchers02);
            this.grbTotales.Controls.Add(this.lblEfectivoCaja);
            this.grbTotales.Controls.Add(this.lblEfectivoMostrado);
            this.grbTotales.Controls.Add(this.lblEtiquetaEfectivo01);
            this.grbTotales.Controls.Add(this.lblEtiquetaEfectivo02);
            this.grbTotales.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grbTotales.Location = new System.Drawing.Point(12, 348);
            this.grbTotales.Name = "grbTotales";
            this.grbTotales.Size = new System.Drawing.Size(984, 85);
            this.grbTotales.TabIndex = 3;
            this.grbTotales.TabStop = false;
            this.grbTotales.Text = "Totales";
            // 
            // lblVouchersCaja
            // 
            this.lblVouchersCaja.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblVouchersCaja.AutoSize = true;
            this.lblVouchersCaja.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblVouchersCaja.Location = new System.Drawing.Point(651, 55);
            this.lblVouchersCaja.Name = "lblVouchersCaja";
            this.lblVouchersCaja.Size = new System.Drawing.Size(44, 19);
            this.lblVouchersCaja.TabIndex = 7;
            this.lblVouchersCaja.Text = "$0.00";
            // 
            // lblVouchersMostrado
            // 
            this.lblVouchersMostrado.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblVouchersMostrado.AutoSize = true;
            this.lblVouchersMostrado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblVouchersMostrado.Location = new System.Drawing.Point(651, 19);
            this.lblVouchersMostrado.Name = "lblVouchersMostrado";
            this.lblVouchersMostrado.Size = new System.Drawing.Size(44, 19);
            this.lblVouchersMostrado.TabIndex = 5;
            this.lblVouchersMostrado.Text = "$0.00";
            // 
            // lblEtiquetaVouchers01
            // 
            this.lblEtiquetaVouchers01.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEtiquetaVouchers01.AutoSize = true;
            this.lblEtiquetaVouchers01.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEtiquetaVouchers01.Location = new System.Drawing.Point(462, 19);
            this.lblEtiquetaVouchers01.Name = "lblEtiquetaVouchers01";
            this.lblEtiquetaVouchers01.Size = new System.Drawing.Size(183, 19);
            this.lblEtiquetaVouchers01.TabIndex = 4;
            this.lblEtiquetaVouchers01.Text = "Total de vouchers mostrado:";
            // 
            // lblEtiquetaVouchers02
            // 
            this.lblEtiquetaVouchers02.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEtiquetaVouchers02.AutoSize = true;
            this.lblEtiquetaVouchers02.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEtiquetaVouchers02.Location = new System.Drawing.Point(479, 55);
            this.lblEtiquetaVouchers02.Name = "lblEtiquetaVouchers02";
            this.lblEtiquetaVouchers02.Size = new System.Drawing.Size(166, 19);
            this.lblEtiquetaVouchers02.TabIndex = 6;
            this.lblEtiquetaVouchers02.Text = "Total de vouchers en caja:";
            // 
            // lblEfectivoCaja
            // 
            this.lblEfectivoCaja.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEfectivoCaja.AutoSize = true;
            this.lblEfectivoCaja.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEfectivoCaja.Location = new System.Drawing.Point(187, 55);
            this.lblEfectivoCaja.Name = "lblEfectivoCaja";
            this.lblEfectivoCaja.Size = new System.Drawing.Size(44, 19);
            this.lblEfectivoCaja.TabIndex = 3;
            this.lblEfectivoCaja.Text = "$0.00";
            // 
            // lblEfectivoMostrado
            // 
            this.lblEfectivoMostrado.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEfectivoMostrado.AutoSize = true;
            this.lblEfectivoMostrado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEfectivoMostrado.Location = new System.Drawing.Point(187, 19);
            this.lblEfectivoMostrado.Name = "lblEfectivoMostrado";
            this.lblEfectivoMostrado.Size = new System.Drawing.Size(44, 19);
            this.lblEfectivoMostrado.TabIndex = 1;
            this.lblEfectivoMostrado.Text = "$0.00";
            // 
            // txtConcepto
            // 
            this.txtConcepto.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtConcepto.Location = new System.Drawing.Point(6, 22);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(291, 29);
            this.txtConcepto.TabIndex = 0;
            this.txtConcepto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtConcepto_KeyDown);
            // 
            // chbRespetarFechas
            // 
            this.chbRespetarFechas.AutoSize = true;
            this.chbRespetarFechas.Location = new System.Drawing.Point(6, 57);
            this.chbRespetarFechas.Name = "chbRespetarFechas";
            this.chbRespetarFechas.Size = new System.Drawing.Size(158, 19);
            this.chbRespetarFechas.TabIndex = 1;
            this.chbRespetarFechas.Text = "Respetar rango de fechas";
            this.chbRespetarFechas.UseVisualStyleBackColor = true;
            // 
            // grbConcepto
            // 
            this.grbConcepto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grbConcepto.Controls.Add(this.btnBuscarConcepto);
            this.grbConcepto.Controls.Add(this.chbRespetarFechas);
            this.grbConcepto.Controls.Add(this.txtConcepto);
            this.grbConcepto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grbConcepto.Location = new System.Drawing.Point(693, 12);
            this.grbConcepto.Name = "grbConcepto";
            this.grbConcepto.Size = new System.Drawing.Size(303, 82);
            this.grbConcepto.TabIndex = 1;
            this.grbConcepto.TabStop = false;
            this.grbConcepto.Text = "Buscar por concepto:";
            // 
            // btnBuscarConcepto
            // 
            this.btnBuscarConcepto.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnBuscarConcepto.Location = new System.Drawing.Point(206, 55);
            this.btnBuscarConcepto.Name = "btnBuscarConcepto";
            this.btnBuscarConcepto.Size = new System.Drawing.Size(91, 21);
            this.btnBuscarConcepto.TabIndex = 5;
            this.btnBuscarConcepto.Text = "Buscar";
            this.btnBuscarConcepto.UseVisualStyleBackColor = true;
            this.btnBuscarConcepto.Click += new System.EventHandler(this.btnBuscarConcepto_Click);
            // 
            // bgwCaja
            // 
            this.bgwCaja.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCaja_DoWork);
            this.bgwCaja.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwCaja_RunWorkerCompleted);
            // 
            // tmrEspera
            // 
            this.tmrEspera.Interval = 300;
            this.tmrEspera.Tick += new System.EventHandler(this.tmrEspera_Tick);
            // 
            // frmCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1008, 481);
            this.Controls.Add(this.grbTotales);
            this.Controls.Add(this.grbConcepto);
            this.Controls.Add(this.btnAbrirCerrar);
            this.Controls.Add(this.btnSalida);
            this.Controls.Add(this.dgvCaja);
            this.Controls.Add(this.grbFechas);
            this.Controls.Add(this.btnEntrada);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caja";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaja)).EndInit();
            this.grbFechas.ResumeLayout(false);
            this.grbFechas.PerformLayout();
            this.grbTotales.ResumeLayout(false);
            this.grbTotales.PerformLayout();
            this.grbConcepto.ResumeLayout(false);
            this.grbConcepto.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCaja;
        private System.Windows.Forms.Button btnEntrada;
        private System.Windows.Forms.Button btnSalida;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.GroupBox grbFechas;
        private System.Windows.Forms.Label lblEtiquetaFechaFin;
        private System.Windows.Forms.Label lblEtiquetaFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label lblEtiquetaEfectivo01;
        private System.Windows.Forms.Label lblEtiquetaEfectivo02;
        private System.Windows.Forms.GroupBox grbTotales;
        private System.Windows.Forms.Label lblVouchersCaja;
        private System.Windows.Forms.Label lblVouchersMostrado;
        private System.Windows.Forms.Label lblEtiquetaVouchers01;
        private System.Windows.Forms.Label lblEtiquetaVouchers02;
        private System.Windows.Forms.Label lblEfectivoCaja;
        private System.Windows.Forms.Label lblEfectivoMostrado;
        public System.Windows.Forms.Button btnAbrirCerrar;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.CheckBox chbRespetarFechas;
        private System.Windows.Forms.GroupBox grbConcepto;
        private System.Windows.Forms.Button btnBuscar;
        private System.ComponentModel.BackgroundWorker bgwCaja;
        private System.Windows.Forms.Timer tmrEspera;
        private System.Windows.Forms.Button btnBuscarConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Efectivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vouchers;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CVendedor;
    }
}