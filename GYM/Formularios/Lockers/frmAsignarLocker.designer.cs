namespace GYM.Formularios
{
    partial class frmAsignarLocker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsignarLocker));
            this.dgvSocios = new System.Windows.Forms.DataGridView();
            this.NumSocio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Socio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNumLocker = new System.Windows.Forms.Label();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.lblBusqueda = new System.Windows.Forms.Label();
            this.bgwLocker = new System.ComponentModel.BackgroundWorker();
            this.tmrConteo = new System.Windows.Forms.Timer(this.components);
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblTipoPago = new System.Windows.Forms.Label();
            this.cboTipoPago = new System.Windows.Forms.ComboBox();
            this.txtFolio = new System.Windows.Forms.TextBox();
            this.lblFolio = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblTerminación = new System.Windows.Forms.Label();
            this.txtTerminación = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblFolioTicket = new System.Windows.Forms.Label();
            this.txtFolioTicket = new System.Windows.Forms.TextBox();
            this.chbPersona = new System.Windows.Forms.CheckBox();
            this.lblPersona = new System.Windows.Forms.Label();
            this.txtPersona = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocios)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSocios
            // 
            this.dgvSocios.AllowUserToAddRows = false;
            this.dgvSocios.AllowUserToDeleteRows = false;
            this.dgvSocios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSocios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.dgvSocios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSocios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvSocios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSocios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSocios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumSocio,
            this.Socio,
            this.Telefono});
            this.dgvSocios.Location = new System.Drawing.Point(12, 72);
            this.dgvSocios.Name = "dgvSocios";
            this.dgvSocios.ReadOnly = true;
            this.dgvSocios.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSocios.RowHeadersVisible = false;
            this.dgvSocios.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSocios.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSocios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSocios.Size = new System.Drawing.Size(771, 216);
            this.dgvSocios.TabIndex = 4;
            this.dgvSocios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSocios_CellClick);
            // 
            // NumSocio
            // 
            this.NumSocio.HeaderText = "Número de socio";
            this.NumSocio.Name = "NumSocio";
            this.NumSocio.ReadOnly = true;
            this.NumSocio.Width = 120;
            // 
            // Socio
            // 
            this.Socio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Socio.HeaderText = "Socio";
            this.Socio.Name = "Socio";
            this.Socio.ReadOnly = true;
            // 
            // Telefono
            // 
            this.Telefono.HeaderText = "Teléfono";
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            this.Telefono.Width = 150;
            // 
            // lblNumLocker
            // 
            this.lblNumLocker.AutoSize = true;
            this.lblNumLocker.Location = new System.Drawing.Point(12, 15);
            this.lblNumLocker.Name = "lblNumLocker";
            this.lblNumLocker.Size = new System.Drawing.Size(125, 19);
            this.lblNumLocker.TabIndex = 0;
            this.lblNumLocker.Text = "Número de locker: ";
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Location = new System.Drawing.Point(284, 291);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(82, 19);
            this.lblFechaFin.TabIndex = 7;
            this.lblFechaFin.Text = "Fecha de fin";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Location = new System.Drawing.Point(288, 313);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(245, 25);
            this.dtpFechaFin.TabIndex = 8;
            this.dtpFechaFin.ValueChanged += new System.EventHandler(this.dtpFechaFin_ValueChanged);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBusqueda.Location = new System.Drawing.Point(526, 12);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(257, 25);
            this.txtBusqueda.TabIndex = 2;
            this.txtBusqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBusqueda_KeyDown);
            // 
            // lblBusqueda
            // 
            this.lblBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBusqueda.AutoSize = true;
            this.lblBusqueda.Location = new System.Drawing.Point(320, 15);
            this.lblBusqueda.Name = "lblBusqueda";
            this.lblBusqueda.Size = new System.Drawing.Size(200, 19);
            this.lblBusqueda.TabIndex = 1;
            this.lblBusqueda.Text = "Búsqueda de socio por nombre";
            // 
            // bgwLocker
            // 
            this.bgwLocker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwLocker_DoWork);
            this.bgwLocker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwLocker_RunWorkerCompleted);
            // 
            // tmrConteo
            // 
            this.tmrConteo.Interval = 300;
            this.tmrConteo.Tick += new System.EventHandler(this.tmrConteo_Tick);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(12, 313);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(270, 75);
            this.txtDescripcion.TabIndex = 6;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(8, 291);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(79, 19);
            this.lblDescripcion.TabIndex = 5;
            this.lblDescripcion.Text = "Descripción";
            // 
            // lblTipoPago
            // 
            this.lblTipoPago.AutoSize = true;
            this.lblTipoPago.Location = new System.Drawing.Point(534, 291);
            this.lblTipoPago.Name = "lblTipoPago";
            this.lblTipoPago.Size = new System.Drawing.Size(89, 19);
            this.lblTipoPago.TabIndex = 9;
            this.lblTipoPago.Text = "Tipo de pago";
            // 
            // cboTipoPago
            // 
            this.cboTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipoPago.FormattingEnabled = true;
            this.cboTipoPago.Items.AddRange(new object[] {
            "Efectivo",
            "Tarjeta"});
            this.cboTipoPago.Location = new System.Drawing.Point(538, 313);
            this.cboTipoPago.Name = "cboTipoPago";
            this.cboTipoPago.Size = new System.Drawing.Size(244, 25);
            this.cboTipoPago.TabIndex = 10;
            this.cboTipoPago.SelectedIndexChanged += new System.EventHandler(this.cboTipoPago_SelectedIndexChanged);
            // 
            // txtFolio
            // 
            this.txtFolio.Location = new System.Drawing.Point(538, 363);
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.Size = new System.Drawing.Size(245, 25);
            this.txtFolio.TabIndex = 14;
            this.txtFolio.LostFocus += new System.EventHandler(this.txtFolio_LostFocus);
            // 
            // lblFolio
            // 
            this.lblFolio.AutoSize = true;
            this.lblFolio.Location = new System.Drawing.Point(534, 341);
            this.lblFolio.Name = "lblFolio";
            this.lblFolio.Size = new System.Drawing.Size(38, 19);
            this.lblFolio.TabIndex = 13;
            this.lblFolio.Text = "Folio";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(284, 341);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(46, 19);
            this.lblPrecio.TabIndex = 11;
            this.lblPrecio.Text = "Precio";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(288, 363);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(245, 25);
            this.txtPrecio.TabIndex = 12;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // lblTerminación
            // 
            this.lblTerminación.AutoSize = true;
            this.lblTerminación.Location = new System.Drawing.Point(534, 391);
            this.lblTerminación.Name = "lblTerminación";
            this.lblTerminación.Size = new System.Drawing.Size(83, 19);
            this.lblTerminación.TabIndex = 19;
            this.lblTerminación.Text = "Terminación";
            // 
            // txtTerminación
            // 
            this.txtTerminación.Enabled = false;
            this.txtTerminación.Location = new System.Drawing.Point(538, 413);
            this.txtTerminación.Name = "txtTerminación";
            this.txtTerminación.Size = new System.Drawing.Size(245, 25);
            this.txtTerminación.TabIndex = 20;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnAceptar.Location = new System.Drawing.Point(708, 469);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 21;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblFolioTicket
            // 
            this.lblFolioTicket.AutoSize = true;
            this.lblFolioTicket.Location = new System.Drawing.Point(284, 391);
            this.lblFolioTicket.Name = "lblFolioTicket";
            this.lblFolioTicket.Size = new System.Drawing.Size(75, 19);
            this.lblFolioTicket.TabIndex = 17;
            this.lblFolioTicket.Text = "Folio ticket";
            // 
            // txtFolioTicket
            // 
            this.txtFolioTicket.Enabled = false;
            this.txtFolioTicket.Location = new System.Drawing.Point(288, 413);
            this.txtFolioTicket.Name = "txtFolioTicket";
            this.txtFolioTicket.Size = new System.Drawing.Size(245, 25);
            this.txtFolioTicket.TabIndex = 18;
            // 
            // chbPersona
            // 
            this.chbPersona.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbPersona.AutoSize = true;
            this.chbPersona.Location = new System.Drawing.Point(526, 43);
            this.chbPersona.Name = "chbPersona";
            this.chbPersona.Size = new System.Drawing.Size(257, 23);
            this.chbPersona.TabIndex = 3;
            this.chbPersona.Text = "Rentar locker a persona no registrada";
            this.chbPersona.UseVisualStyleBackColor = true;
            this.chbPersona.CheckedChanged += new System.EventHandler(this.chbPersona_CheckedChanged);
            // 
            // lblPersona
            // 
            this.lblPersona.AutoSize = true;
            this.lblPersona.Location = new System.Drawing.Point(8, 391);
            this.lblPersona.Name = "lblPersona";
            this.lblPersona.Size = new System.Drawing.Size(145, 19);
            this.lblPersona.TabIndex = 15;
            this.lblPersona.Text = "Nombre de la persona";
            // 
            // txtPersona
            // 
            this.txtPersona.Enabled = false;
            this.txtPersona.Location = new System.Drawing.Point(12, 413);
            this.txtPersona.Name = "txtPersona";
            this.txtPersona.Size = new System.Drawing.Size(270, 25);
            this.txtPersona.TabIndex = 16;
            // 
            // frmAsignarLocker
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(795, 504);
            this.Controls.Add(this.lblPersona);
            this.Controls.Add(this.txtPersona);
            this.Controls.Add(this.chbPersona);
            this.Controls.Add(this.lblFolioTicket);
            this.Controls.Add(this.txtFolioTicket);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtTerminación);
            this.Controls.Add(this.lblTerminación);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.lblFolio);
            this.Controls.Add(this.txtFolio);
            this.Controls.Add(this.cboTipoPago);
            this.Controls.Add(this.lblTipoPago);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblBusqueda);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.lblFechaFin);
            this.Controls.Add(this.lblNumLocker);
            this.Controls.Add(this.dgvSocios);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAsignarLocker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignar Locker";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSocios;
        private System.Windows.Forms.Label lblNumLocker;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Label lblBusqueda;
        private System.ComponentModel.BackgroundWorker bgwLocker;
        private System.Windows.Forms.Timer tmrConteo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblTipoPago;
        private System.Windows.Forms.ComboBox cboTipoPago;
        private System.Windows.Forms.TextBox txtFolio;
        private System.Windows.Forms.Label lblFolio;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblTerminación;
        private System.Windows.Forms.TextBox txtTerminación;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblFolioTicket;
        private System.Windows.Forms.TextBox txtFolioTicket;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumSocio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Socio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.CheckBox chbPersona;
        private System.Windows.Forms.Label lblPersona;
        private System.Windows.Forms.TextBox txtPersona;
    }
}