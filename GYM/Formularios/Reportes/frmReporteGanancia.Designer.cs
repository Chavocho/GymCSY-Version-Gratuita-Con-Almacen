namespace GYM.Formularios.Reportes
{
    partial class frmReporteGanancia
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteGanancia));
            this.chrGanancia = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grbEntradas = new System.Windows.Forms.GroupBox();
            this.lblIVouchersDiversos = new System.Windows.Forms.Label();
            this.lblEIVouchersDiversos = new System.Windows.Forms.Label();
            this.lblEIngresosDiversos = new System.Windows.Forms.Label();
            this.lblIEfectivoDiversos = new System.Windows.Forms.Label();
            this.lblIDiversos = new System.Windows.Forms.Label();
            this.lblEIEfectivoDiverso = new System.Windows.Forms.Label();
            this.lblIVouchersVentas = new System.Windows.Forms.Label();
            this.lblEIVouchersVentas = new System.Windows.Forms.Label();
            this.lblEIngresosVentas = new System.Windows.Forms.Label();
            this.lblIEfectivoVentas = new System.Windows.Forms.Label();
            this.lblIVentas = new System.Windows.Forms.Label();
            this.lblEIEfectivoVentas = new System.Windows.Forms.Label();
            this.lblIVouchersMembresias = new System.Windows.Forms.Label();
            this.lblEIVouchersMembresias = new System.Windows.Forms.Label();
            this.lblEIngresosMembresia = new System.Windows.Forms.Label();
            this.lblIEfectivoMembresias = new System.Windows.Forms.Label();
            this.lblIMembresias = new System.Windows.Forms.Label();
            this.lblEIEfectivoMembresias = new System.Windows.Forms.Label();
            this.lblVouchers = new System.Windows.Forms.Label();
            this.lblEVouchers = new System.Windows.Forms.Label();
            this.lblEGanancia = new System.Windows.Forms.Label();
            this.lblEfectivo = new System.Windows.Forms.Label();
            this.lblGanancia = new System.Windows.Forms.Label();
            this.lblEEfectivo = new System.Windows.Forms.Label();
            this.grbSalidas = new System.Windows.Forms.GroupBox();
            this.lblEVouchersDiversos = new System.Windows.Forms.Label();
            this.lblEEVouchesDiversos = new System.Windows.Forms.Label();
            this.lblEEEfectivoDiversos = new System.Windows.Forms.Label();
            this.lblEEfectivoDiversos = new System.Windows.Forms.Label();
            this.lblEDiversos = new System.Windows.Forms.Label();
            this.lblEEDiversos = new System.Windows.Forms.Label();
            this.lblEVouchersCompras = new System.Windows.Forms.Label();
            this.lblEECompras = new System.Windows.Forms.Label();
            this.lblEEVouchesCompras = new System.Windows.Forms.Label();
            this.lblEEEfectivoCompras = new System.Windows.Forms.Label();
            this.lblECompras = new System.Windows.Forms.Label();
            this.lblEEfectivoCompras = new System.Windows.Forms.Label();
            this.grbIngresos = new System.Windows.Forms.GroupBox();
            this.grbFechas = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblEFechaFin = new System.Windows.Forms.Label();
            this.lblEFechaIni = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaIni = new System.Windows.Forms.DateTimePicker();
            this.bgwReporte = new System.ComponentModel.BackgroundWorker();
            this.tmrEspera = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chrGanancia)).BeginInit();
            this.grbEntradas.SuspendLayout();
            this.grbSalidas.SuspendLayout();
            this.grbIngresos.SuspendLayout();
            this.grbFechas.SuspendLayout();
            this.SuspendLayout();
            // 
            // chrGanancia
            // 
            this.chrGanancia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "chaGanancias";
            this.chrGanancia.ChartAreas.Add(chartArea1);
            this.chrGanancia.Location = new System.Drawing.Point(12, 89);
            this.chrGanancia.Name = "chrGanancia";
            this.chrGanancia.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chrGanancia.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192))))),
        System.Drawing.Color.SlateBlue,
        System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0))))),
        System.Drawing.Color.Orange};
            this.chrGanancia.Size = new System.Drawing.Size(984, 329);
            this.chrGanancia.TabIndex = 0;
            this.chrGanancia.Text = "Ganancias";
            // 
            // grbEntradas
            // 
            this.grbEntradas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbEntradas.Controls.Add(this.lblIVouchersDiversos);
            this.grbEntradas.Controls.Add(this.lblEIVouchersDiversos);
            this.grbEntradas.Controls.Add(this.lblEIngresosDiversos);
            this.grbEntradas.Controls.Add(this.lblIEfectivoDiversos);
            this.grbEntradas.Controls.Add(this.lblIDiversos);
            this.grbEntradas.Controls.Add(this.lblEIEfectivoDiverso);
            this.grbEntradas.Controls.Add(this.lblIVouchersVentas);
            this.grbEntradas.Controls.Add(this.lblEIVouchersVentas);
            this.grbEntradas.Controls.Add(this.lblEIngresosVentas);
            this.grbEntradas.Controls.Add(this.lblIEfectivoVentas);
            this.grbEntradas.Controls.Add(this.lblIVentas);
            this.grbEntradas.Controls.Add(this.lblEIEfectivoVentas);
            this.grbEntradas.Controls.Add(this.lblIVouchersMembresias);
            this.grbEntradas.Controls.Add(this.lblEIVouchersMembresias);
            this.grbEntradas.Controls.Add(this.lblEIngresosMembresia);
            this.grbEntradas.Controls.Add(this.lblIEfectivoMembresias);
            this.grbEntradas.Controls.Add(this.lblIMembresias);
            this.grbEntradas.Controls.Add(this.lblEIEfectivoMembresias);
            this.grbEntradas.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.grbEntradas.Location = new System.Drawing.Point(12, 424);
            this.grbEntradas.Name = "grbEntradas";
            this.grbEntradas.Size = new System.Drawing.Size(984, 120);
            this.grbEntradas.TabIndex = 5;
            this.grbEntradas.TabStop = false;
            this.grbEntradas.Text = "Entradas";
            // 
            // lblIVouchersDiversos
            // 
            this.lblIVouchersDiversos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIVouchersDiversos.AutoSize = true;
            this.lblIVouchersDiversos.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblIVouchersDiversos.Location = new System.Drawing.Point(785, 92);
            this.lblIVouchersDiversos.Name = "lblIVouchersDiversos";
            this.lblIVouchersDiversos.Size = new System.Drawing.Size(49, 21);
            this.lblIVouchersDiversos.TabIndex = 24;
            this.lblIVouchersDiversos.Text = "$0.00";
            // 
            // lblEIVouchersDiversos
            // 
            this.lblEIVouchersDiversos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEIVouchersDiversos.AutoSize = true;
            this.lblEIVouchersDiversos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEIVouchersDiversos.Location = new System.Drawing.Point(695, 92);
            this.lblEIVouchersDiversos.Name = "lblEIVouchersDiversos";
            this.lblEIVouchersDiversos.Size = new System.Drawing.Size(84, 21);
            this.lblEIVouchersDiversos.TabIndex = 23;
            this.lblEIVouchersDiversos.Text = "Vouchers:";
            // 
            // lblEIngresosDiversos
            // 
            this.lblEIngresosDiversos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEIngresosDiversos.AutoSize = true;
            this.lblEIngresosDiversos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEIngresosDiversos.Location = new System.Drawing.Point(93, 92);
            this.lblEIngresosDiversos.Name = "lblEIngresosDiversos";
            this.lblEIngresosDiversos.Size = new System.Drawing.Size(145, 21);
            this.lblEIngresosDiversos.TabIndex = 19;
            this.lblEIngresosDiversos.Text = "Ingresos diversos:";
            // 
            // lblIEfectivoDiversos
            // 
            this.lblIEfectivoDiversos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIEfectivoDiversos.AutoSize = true;
            this.lblIEfectivoDiversos.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblIEfectivoDiversos.Location = new System.Drawing.Point(510, 92);
            this.lblIEfectivoDiversos.Name = "lblIEfectivoDiversos";
            this.lblIEfectivoDiversos.Size = new System.Drawing.Size(49, 21);
            this.lblIEfectivoDiversos.TabIndex = 22;
            this.lblIEfectivoDiversos.Text = "$0.00";
            // 
            // lblIDiversos
            // 
            this.lblIDiversos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIDiversos.AutoSize = true;
            this.lblIDiversos.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblIDiversos.Location = new System.Drawing.Point(244, 92);
            this.lblIDiversos.Name = "lblIDiversos";
            this.lblIDiversos.Size = new System.Drawing.Size(49, 21);
            this.lblIDiversos.TabIndex = 20;
            this.lblIDiversos.Text = "$0.00";
            // 
            // lblEIEfectivoDiverso
            // 
            this.lblEIEfectivoDiverso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEIEfectivoDiverso.AutoSize = true;
            this.lblEIEfectivoDiverso.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEIEfectivoDiverso.Location = new System.Drawing.Point(428, 92);
            this.lblEIEfectivoDiverso.Name = "lblEIEfectivoDiverso";
            this.lblEIEfectivoDiverso.Size = new System.Drawing.Size(76, 21);
            this.lblEIEfectivoDiverso.TabIndex = 21;
            this.lblEIEfectivoDiverso.Text = "Efectivo:";
            // 
            // lblIVouchersVentas
            // 
            this.lblIVouchersVentas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIVouchersVentas.AutoSize = true;
            this.lblIVouchersVentas.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblIVouchersVentas.Location = new System.Drawing.Point(785, 55);
            this.lblIVouchersVentas.Name = "lblIVouchersVentas";
            this.lblIVouchersVentas.Size = new System.Drawing.Size(49, 21);
            this.lblIVouchersVentas.TabIndex = 18;
            this.lblIVouchersVentas.Text = "$0.00";
            // 
            // lblEIVouchersVentas
            // 
            this.lblEIVouchersVentas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEIVouchersVentas.AutoSize = true;
            this.lblEIVouchersVentas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEIVouchersVentas.Location = new System.Drawing.Point(695, 55);
            this.lblEIVouchersVentas.Name = "lblEIVouchersVentas";
            this.lblEIVouchersVentas.Size = new System.Drawing.Size(84, 21);
            this.lblEIVouchersVentas.TabIndex = 17;
            this.lblEIVouchersVentas.Text = "Vouchers:";
            // 
            // lblEIngresosVentas
            // 
            this.lblEIngresosVentas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEIngresosVentas.AutoSize = true;
            this.lblEIngresosVentas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEIngresosVentas.Location = new System.Drawing.Point(6, 55);
            this.lblEIngresosVentas.Name = "lblEIngresosVentas";
            this.lblEIngresosVentas.Size = new System.Drawing.Size(232, 21);
            this.lblEIngresosVentas.TabIndex = 13;
            this.lblEIngresosVentas.Text = "Ingresos de venta mostrador:";
            // 
            // lblIEfectivoVentas
            // 
            this.lblIEfectivoVentas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIEfectivoVentas.AutoSize = true;
            this.lblIEfectivoVentas.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblIEfectivoVentas.Location = new System.Drawing.Point(510, 55);
            this.lblIEfectivoVentas.Name = "lblIEfectivoVentas";
            this.lblIEfectivoVentas.Size = new System.Drawing.Size(49, 21);
            this.lblIEfectivoVentas.TabIndex = 16;
            this.lblIEfectivoVentas.Text = "$0.00";
            // 
            // lblIVentas
            // 
            this.lblIVentas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIVentas.AutoSize = true;
            this.lblIVentas.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblIVentas.Location = new System.Drawing.Point(244, 55);
            this.lblIVentas.Name = "lblIVentas";
            this.lblIVentas.Size = new System.Drawing.Size(49, 21);
            this.lblIVentas.TabIndex = 14;
            this.lblIVentas.Text = "$0.00";
            // 
            // lblEIEfectivoVentas
            // 
            this.lblEIEfectivoVentas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEIEfectivoVentas.AutoSize = true;
            this.lblEIEfectivoVentas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEIEfectivoVentas.Location = new System.Drawing.Point(428, 55);
            this.lblEIEfectivoVentas.Name = "lblEIEfectivoVentas";
            this.lblEIEfectivoVentas.Size = new System.Drawing.Size(76, 21);
            this.lblEIEfectivoVentas.TabIndex = 15;
            this.lblEIEfectivoVentas.Text = "Efectivo:";
            // 
            // lblIVouchersMembresias
            // 
            this.lblIVouchersMembresias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIVouchersMembresias.AutoSize = true;
            this.lblIVouchersMembresias.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblIVouchersMembresias.Location = new System.Drawing.Point(785, 18);
            this.lblIVouchersMembresias.Name = "lblIVouchersMembresias";
            this.lblIVouchersMembresias.Size = new System.Drawing.Size(49, 21);
            this.lblIVouchersMembresias.TabIndex = 12;
            this.lblIVouchersMembresias.Text = "$0.00";
            // 
            // lblEIVouchersMembresias
            // 
            this.lblEIVouchersMembresias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEIVouchersMembresias.AutoSize = true;
            this.lblEIVouchersMembresias.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEIVouchersMembresias.Location = new System.Drawing.Point(695, 18);
            this.lblEIVouchersMembresias.Name = "lblEIVouchersMembresias";
            this.lblEIVouchersMembresias.Size = new System.Drawing.Size(84, 21);
            this.lblEIVouchersMembresias.TabIndex = 11;
            this.lblEIVouchersMembresias.Text = "Vouchers:";
            // 
            // lblEIngresosMembresia
            // 
            this.lblEIngresosMembresia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEIngresosMembresia.AutoSize = true;
            this.lblEIngresosMembresia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEIngresosMembresia.Location = new System.Drawing.Point(41, 18);
            this.lblEIngresosMembresia.Name = "lblEIngresosMembresia";
            this.lblEIngresosMembresia.Size = new System.Drawing.Size(197, 21);
            this.lblEIngresosMembresia.TabIndex = 7;
            this.lblEIngresosMembresia.Text = "Ingresos de membresías:";
            // 
            // lblIEfectivoMembresias
            // 
            this.lblIEfectivoMembresias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIEfectivoMembresias.AutoSize = true;
            this.lblIEfectivoMembresias.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblIEfectivoMembresias.Location = new System.Drawing.Point(510, 18);
            this.lblIEfectivoMembresias.Name = "lblIEfectivoMembresias";
            this.lblIEfectivoMembresias.Size = new System.Drawing.Size(49, 21);
            this.lblIEfectivoMembresias.TabIndex = 10;
            this.lblIEfectivoMembresias.Text = "$0.00";
            // 
            // lblIMembresias
            // 
            this.lblIMembresias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIMembresias.AutoSize = true;
            this.lblIMembresias.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblIMembresias.Location = new System.Drawing.Point(244, 18);
            this.lblIMembresias.Name = "lblIMembresias";
            this.lblIMembresias.Size = new System.Drawing.Size(49, 21);
            this.lblIMembresias.TabIndex = 8;
            this.lblIMembresias.Text = "$0.00";
            // 
            // lblEIEfectivoMembresias
            // 
            this.lblEIEfectivoMembresias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEIEfectivoMembresias.AutoSize = true;
            this.lblEIEfectivoMembresias.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEIEfectivoMembresias.Location = new System.Drawing.Point(428, 18);
            this.lblEIEfectivoMembresias.Name = "lblEIEfectivoMembresias";
            this.lblEIEfectivoMembresias.Size = new System.Drawing.Size(76, 21);
            this.lblEIEfectivoMembresias.TabIndex = 9;
            this.lblEIEfectivoMembresias.Text = "Efectivo:";
            // 
            // lblVouchers
            // 
            this.lblVouchers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVouchers.AutoSize = true;
            this.lblVouchers.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblVouchers.Location = new System.Drawing.Point(702, 18);
            this.lblVouchers.Name = "lblVouchers";
            this.lblVouchers.Size = new System.Drawing.Size(49, 21);
            this.lblVouchers.TabIndex = 12;
            this.lblVouchers.Text = "$0.00";
            // 
            // lblEVouchers
            // 
            this.lblEVouchers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEVouchers.AutoSize = true;
            this.lblEVouchers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEVouchers.Location = new System.Drawing.Point(612, 18);
            this.lblEVouchers.Name = "lblEVouchers";
            this.lblEVouchers.Size = new System.Drawing.Size(84, 21);
            this.lblEVouchers.TabIndex = 11;
            this.lblEVouchers.Text = "Vouchers:";
            // 
            // lblEGanancia
            // 
            this.lblEGanancia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEGanancia.AutoSize = true;
            this.lblEGanancia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEGanancia.Location = new System.Drawing.Point(6, 18);
            this.lblEGanancia.Name = "lblEGanancia";
            this.lblEGanancia.Size = new System.Drawing.Size(149, 21);
            this.lblEGanancia.TabIndex = 7;
            this.lblEGanancia.Text = "Total de ganancia:";
            // 
            // lblEfectivo
            // 
            this.lblEfectivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEfectivo.AutoSize = true;
            this.lblEfectivo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEfectivo.Location = new System.Drawing.Point(427, 18);
            this.lblEfectivo.Name = "lblEfectivo";
            this.lblEfectivo.Size = new System.Drawing.Size(49, 21);
            this.lblEfectivo.TabIndex = 10;
            this.lblEfectivo.Text = "$0.00";
            // 
            // lblGanancia
            // 
            this.lblGanancia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGanancia.AutoSize = true;
            this.lblGanancia.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblGanancia.Location = new System.Drawing.Point(161, 18);
            this.lblGanancia.Name = "lblGanancia";
            this.lblGanancia.Size = new System.Drawing.Size(49, 21);
            this.lblGanancia.TabIndex = 8;
            this.lblGanancia.Text = "$0.00";
            // 
            // lblEEfectivo
            // 
            this.lblEEfectivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEEfectivo.AutoSize = true;
            this.lblEEfectivo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEEfectivo.Location = new System.Drawing.Point(345, 18);
            this.lblEEfectivo.Name = "lblEEfectivo";
            this.lblEEfectivo.Size = new System.Drawing.Size(76, 21);
            this.lblEEfectivo.TabIndex = 9;
            this.lblEEfectivo.Text = "Efectivo:";
            // 
            // grbSalidas
            // 
            this.grbSalidas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbSalidas.Controls.Add(this.lblEVouchersDiversos);
            this.grbSalidas.Controls.Add(this.lblEEVouchesDiversos);
            this.grbSalidas.Controls.Add(this.lblEEEfectivoDiversos);
            this.grbSalidas.Controls.Add(this.lblEEfectivoDiversos);
            this.grbSalidas.Controls.Add(this.lblEDiversos);
            this.grbSalidas.Controls.Add(this.lblEEDiversos);
            this.grbSalidas.Controls.Add(this.lblEVouchersCompras);
            this.grbSalidas.Controls.Add(this.lblEECompras);
            this.grbSalidas.Controls.Add(this.lblEEVouchesCompras);
            this.grbSalidas.Controls.Add(this.lblEEEfectivoCompras);
            this.grbSalidas.Controls.Add(this.lblECompras);
            this.grbSalidas.Controls.Add(this.lblEEfectivoCompras);
            this.grbSalidas.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.grbSalidas.Location = new System.Drawing.Point(12, 550);
            this.grbSalidas.Name = "grbSalidas";
            this.grbSalidas.Size = new System.Drawing.Size(984, 85);
            this.grbSalidas.TabIndex = 13;
            this.grbSalidas.TabStop = false;
            this.grbSalidas.Text = "Salidas";
            // 
            // lblEVouchersDiversos
            // 
            this.lblEVouchersDiversos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEVouchersDiversos.AutoSize = true;
            this.lblEVouchersDiversos.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEVouchersDiversos.Location = new System.Drawing.Point(757, 54);
            this.lblEVouchersDiversos.Name = "lblEVouchersDiversos";
            this.lblEVouchersDiversos.Size = new System.Drawing.Size(49, 21);
            this.lblEVouchersDiversos.TabIndex = 36;
            this.lblEVouchersDiversos.Text = "$0.00";
            // 
            // lblEEVouchesDiversos
            // 
            this.lblEEVouchesDiversos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEEVouchesDiversos.AutoSize = true;
            this.lblEEVouchesDiversos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEEVouchesDiversos.Location = new System.Drawing.Point(667, 54);
            this.lblEEVouchesDiversos.Name = "lblEEVouchesDiversos";
            this.lblEEVouchesDiversos.Size = new System.Drawing.Size(84, 21);
            this.lblEEVouchesDiversos.TabIndex = 35;
            this.lblEEVouchesDiversos.Text = "Vouchers:";
            // 
            // lblEEEfectivoDiversos
            // 
            this.lblEEEfectivoDiversos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEEEfectivoDiversos.AutoSize = true;
            this.lblEEEfectivoDiversos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEEEfectivoDiversos.Location = new System.Drawing.Point(374, 54);
            this.lblEEEfectivoDiversos.Name = "lblEEEfectivoDiversos";
            this.lblEEEfectivoDiversos.Size = new System.Drawing.Size(76, 21);
            this.lblEEEfectivoDiversos.TabIndex = 33;
            this.lblEEEfectivoDiversos.Text = "Efectivo:";
            // 
            // lblEEfectivoDiversos
            // 
            this.lblEEfectivoDiversos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEEfectivoDiversos.AutoSize = true;
            this.lblEEfectivoDiversos.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEEfectivoDiversos.Location = new System.Drawing.Point(456, 54);
            this.lblEEfectivoDiversos.Name = "lblEEfectivoDiversos";
            this.lblEEfectivoDiversos.Size = new System.Drawing.Size(49, 21);
            this.lblEEfectivoDiversos.TabIndex = 34;
            this.lblEEfectivoDiversos.Text = "$0.00";
            // 
            // lblEDiversos
            // 
            this.lblEDiversos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEDiversos.AutoSize = true;
            this.lblEDiversos.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEDiversos.Location = new System.Drawing.Point(176, 54);
            this.lblEDiversos.Name = "lblEDiversos";
            this.lblEDiversos.Size = new System.Drawing.Size(49, 21);
            this.lblEDiversos.TabIndex = 32;
            this.lblEDiversos.Text = "$0.00";
            // 
            // lblEEDiversos
            // 
            this.lblEEDiversos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEEDiversos.AutoSize = true;
            this.lblEEDiversos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEEDiversos.Location = new System.Drawing.Point(31, 54);
            this.lblEEDiversos.Name = "lblEEDiversos";
            this.lblEEDiversos.Size = new System.Drawing.Size(139, 21);
            this.lblEEDiversos.TabIndex = 31;
            this.lblEEDiversos.Text = "Egresos diversos:";
            // 
            // lblEVouchersCompras
            // 
            this.lblEVouchersCompras.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEVouchersCompras.AutoSize = true;
            this.lblEVouchersCompras.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEVouchersCompras.Location = new System.Drawing.Point(757, 18);
            this.lblEVouchersCompras.Name = "lblEVouchersCompras";
            this.lblEVouchersCompras.Size = new System.Drawing.Size(49, 21);
            this.lblEVouchersCompras.TabIndex = 30;
            this.lblEVouchersCompras.Text = "$0.00";
            // 
            // lblEECompras
            // 
            this.lblEECompras.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEECompras.AutoSize = true;
            this.lblEECompras.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEECompras.Location = new System.Drawing.Point(6, 18);
            this.lblEECompras.Name = "lblEECompras";
            this.lblEECompras.Size = new System.Drawing.Size(164, 21);
            this.lblEECompras.TabIndex = 25;
            this.lblEECompras.Text = "Egresos de compras:";
            // 
            // lblEEVouchesCompras
            // 
            this.lblEEVouchesCompras.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEEVouchesCompras.AutoSize = true;
            this.lblEEVouchesCompras.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEEVouchesCompras.Location = new System.Drawing.Point(667, 18);
            this.lblEEVouchesCompras.Name = "lblEEVouchesCompras";
            this.lblEEVouchesCompras.Size = new System.Drawing.Size(84, 21);
            this.lblEEVouchesCompras.TabIndex = 29;
            this.lblEEVouchesCompras.Text = "Vouchers:";
            // 
            // lblEEEfectivoCompras
            // 
            this.lblEEEfectivoCompras.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEEEfectivoCompras.AutoSize = true;
            this.lblEEEfectivoCompras.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEEEfectivoCompras.Location = new System.Drawing.Point(374, 18);
            this.lblEEEfectivoCompras.Name = "lblEEEfectivoCompras";
            this.lblEEEfectivoCompras.Size = new System.Drawing.Size(76, 21);
            this.lblEEEfectivoCompras.TabIndex = 27;
            this.lblEEEfectivoCompras.Text = "Efectivo:";
            // 
            // lblECompras
            // 
            this.lblECompras.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblECompras.AutoSize = true;
            this.lblECompras.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblECompras.Location = new System.Drawing.Point(176, 18);
            this.lblECompras.Name = "lblECompras";
            this.lblECompras.Size = new System.Drawing.Size(49, 21);
            this.lblECompras.TabIndex = 26;
            this.lblECompras.Text = "$0.00";
            // 
            // lblEEfectivoCompras
            // 
            this.lblEEfectivoCompras.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEEfectivoCompras.AutoSize = true;
            this.lblEEfectivoCompras.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEEfectivoCompras.Location = new System.Drawing.Point(456, 18);
            this.lblEEfectivoCompras.Name = "lblEEfectivoCompras";
            this.lblEEfectivoCompras.Size = new System.Drawing.Size(49, 21);
            this.lblEEfectivoCompras.TabIndex = 28;
            this.lblEEfectivoCompras.Text = "$0.00";
            // 
            // grbIngresos
            // 
            this.grbIngresos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbIngresos.Controls.Add(this.lblEGanancia);
            this.grbIngresos.Controls.Add(this.lblEEfectivo);
            this.grbIngresos.Controls.Add(this.lblVouchers);
            this.grbIngresos.Controls.Add(this.lblGanancia);
            this.grbIngresos.Controls.Add(this.lblEVouchers);
            this.grbIngresos.Controls.Add(this.lblEfectivo);
            this.grbIngresos.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.grbIngresos.Location = new System.Drawing.Point(12, 641);
            this.grbIngresos.Name = "grbIngresos";
            this.grbIngresos.Size = new System.Drawing.Size(984, 45);
            this.grbIngresos.TabIndex = 14;
            this.grbIngresos.TabStop = false;
            this.grbIngresos.Text = "Ingresos";
            // 
            // grbFechas
            // 
            this.grbFechas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grbFechas.Controls.Add(this.btnBuscar);
            this.grbFechas.Controls.Add(this.lblEFechaFin);
            this.grbFechas.Controls.Add(this.lblEFechaIni);
            this.grbFechas.Controls.Add(this.dtpFechaFin);
            this.grbFechas.Controls.Add(this.dtpFechaIni);
            this.grbFechas.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.grbFechas.Location = new System.Drawing.Point(496, 12);
            this.grbFechas.Name = "grbFechas";
            this.grbFechas.Size = new System.Drawing.Size(498, 71);
            this.grbFechas.TabIndex = 15;
            this.grbFechas.TabStop = false;
            this.grbFechas.Text = "Búsqueda por fechas";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(401, 42);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(91, 23);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblEFechaFin
            // 
            this.lblEFechaFin.AutoSize = true;
            this.lblEFechaFin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEFechaFin.Location = new System.Drawing.Point(200, 18);
            this.lblEFechaFin.Name = "lblEFechaFin";
            this.lblEFechaFin.Size = new System.Drawing.Size(82, 19);
            this.lblEFechaFin.TabIndex = 3;
            this.lblEFechaFin.Text = "Fecha de fin";
            // 
            // lblEFechaIni
            // 
            this.lblEFechaIni.AutoSize = true;
            this.lblEFechaIni.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEFechaIni.Location = new System.Drawing.Point(5, 18);
            this.lblEFechaIni.Name = "lblEFechaIni";
            this.lblEFechaIni.Size = new System.Drawing.Size(98, 19);
            this.lblEFechaIni.TabIndex = 2;
            this.lblEFechaIni.Text = "Fecha de inicio";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.CustomFormat = "dd \'de\' MMMM \'del\' yyyy";
            this.dtpFechaFin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFin.Location = new System.Drawing.Point(204, 40);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(191, 25);
            this.dtpFechaFin.TabIndex = 1;
            this.dtpFechaFin.ValueChanged += new System.EventHandler(this.dtpFechas_ValueChanged);
            // 
            // dtpFechaIni
            // 
            this.dtpFechaIni.CustomFormat = "dd \'de\' MMMM \'del\' yyyy";
            this.dtpFechaIni.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaIni.Location = new System.Drawing.Point(9, 40);
            this.dtpFechaIni.Name = "dtpFechaIni";
            this.dtpFechaIni.Size = new System.Drawing.Size(189, 25);
            this.dtpFechaIni.TabIndex = 0;
            this.dtpFechaIni.ValueChanged += new System.EventHandler(this.dtpFechas_ValueChanged);
            // 
            // bgwReporte
            // 
            this.bgwReporte.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwReporte_DoWork);
            this.bgwReporte.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwReporte_RunWorkerCompleted);
            // 
            // tmrEspera
            // 
            this.tmrEspera.Interval = 300;
            this.tmrEspera.Tick += new System.EventHandler(this.tmrEspera_Tick);
            // 
            // frmReporteGanancia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 698);
            this.Controls.Add(this.grbFechas);
            this.Controls.Add(this.grbIngresos);
            this.Controls.Add(this.grbSalidas);
            this.Controls.Add(this.grbEntradas);
            this.Controls.Add(this.chrGanancia);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1024, 736);
            this.Name = "frmReporteGanancia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte Ganancia";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.chrGanancia)).EndInit();
            this.grbEntradas.ResumeLayout(false);
            this.grbEntradas.PerformLayout();
            this.grbSalidas.ResumeLayout(false);
            this.grbSalidas.PerformLayout();
            this.grbIngresos.ResumeLayout(false);
            this.grbIngresos.PerformLayout();
            this.grbFechas.ResumeLayout(false);
            this.grbFechas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chrGanancia;
        private System.Windows.Forms.GroupBox grbEntradas;
        private System.Windows.Forms.Label lblIVouchersMembresias;
        private System.Windows.Forms.Label lblEIVouchersMembresias;
        private System.Windows.Forms.Label lblEIngresosMembresia;
        private System.Windows.Forms.Label lblIEfectivoMembresias;
        private System.Windows.Forms.Label lblIMembresias;
        private System.Windows.Forms.Label lblEIEfectivoMembresias;
        private System.Windows.Forms.Label lblIVouchersVentas;
        private System.Windows.Forms.Label lblEIVouchersVentas;
        private System.Windows.Forms.Label lblEIngresosVentas;
        private System.Windows.Forms.Label lblIEfectivoVentas;
        private System.Windows.Forms.Label lblIVentas;
        private System.Windows.Forms.Label lblEIEfectivoVentas;
        private System.Windows.Forms.Label lblIVouchersDiversos;
        private System.Windows.Forms.Label lblEIVouchersDiversos;
        private System.Windows.Forms.Label lblEIngresosDiversos;
        private System.Windows.Forms.Label lblIEfectivoDiversos;
        private System.Windows.Forms.Label lblIDiversos;
        private System.Windows.Forms.Label lblEIEfectivoDiverso;
        private System.Windows.Forms.Label lblVouchers;
        private System.Windows.Forms.Label lblEVouchers;
        private System.Windows.Forms.Label lblEGanancia;
        private System.Windows.Forms.Label lblEfectivo;
        private System.Windows.Forms.Label lblGanancia;
        private System.Windows.Forms.Label lblEEfectivo;
        private System.Windows.Forms.GroupBox grbSalidas;
        private System.Windows.Forms.Label lblEVouchersCompras;
        private System.Windows.Forms.Label lblEECompras;
        private System.Windows.Forms.Label lblEEVouchesCompras;
        private System.Windows.Forms.Label lblEEEfectivoCompras;
        private System.Windows.Forms.Label lblECompras;
        private System.Windows.Forms.Label lblEEfectivoCompras;
        private System.Windows.Forms.Label lblEEDiversos;
        private System.Windows.Forms.Label lblEVouchersDiversos;
        private System.Windows.Forms.Label lblEEVouchesDiversos;
        private System.Windows.Forms.Label lblEEEfectivoDiversos;
        private System.Windows.Forms.Label lblEEfectivoDiversos;
        private System.Windows.Forms.Label lblEDiversos;
        private System.Windows.Forms.GroupBox grbIngresos;
        private System.Windows.Forms.GroupBox grbFechas;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaIni;
        private System.Windows.Forms.Label lblEFechaIni;
        private System.Windows.Forms.Label lblEFechaFin;
        private System.Windows.Forms.Button btnBuscar;
        private System.ComponentModel.BackgroundWorker bgwReporte;
        private System.Windows.Forms.Timer tmrEspera;
    }
}