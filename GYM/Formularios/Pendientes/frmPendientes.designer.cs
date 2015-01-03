namespace GYM.Formularios
{
    partial class frmPendientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPendientes));
            this.dgvPendientes = new System.Windows.Forms.DataGridView();
            this.CID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNumSocio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CSocio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CFechaIni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CFechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CFechaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNumTicket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CBtnAceptar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CBtnRechazar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cboPendientes = new System.Windows.Forms.ComboBox();
            this.lblInstruccion = new System.Windows.Forms.Label();
            this.bgwBusqueda = new System.ComponentModel.BackgroundWorker();
            this.tmrEspera = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendientes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPendientes
            // 
            this.dgvPendientes.AllowUserToAddRows = false;
            this.dgvPendientes.AllowUserToDeleteRows = false;
            this.dgvPendientes.AllowUserToOrderColumns = true;
            this.dgvPendientes.AllowUserToResizeColumns = false;
            this.dgvPendientes.AllowUserToResizeRows = false;
            this.dgvPendientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPendientes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.dgvPendientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPendientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvPendientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPendientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CID,
            this.CNumSocio,
            this.CSocio,
            this.CNum,
            this.CDescripcion,
            this.CFechaIni,
            this.CFechaFin,
            this.CFechaPago,
            this.CNumTicket,
            this.CMonto,
            this.CUsuario,
            this.CBtnAceptar,
            this.CBtnRechazar});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPendientes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPendientes.Location = new System.Drawing.Point(12, 47);
            this.dgvPendientes.MultiSelect = false;
            this.dgvPendientes.Name = "dgvPendientes";
            this.dgvPendientes.ReadOnly = true;
            this.dgvPendientes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPendientes.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPendientes.RowHeadersVisible = false;
            this.dgvPendientes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvPendientes.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPendientes.Size = new System.Drawing.Size(960, 352);
            this.dgvPendientes.TabIndex = 2;
            this.dgvPendientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPersonas_CellClick);
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
            this.CNumSocio.HeaderText = "Num. socio";
            this.CNumSocio.Name = "CNumSocio";
            this.CNumSocio.ReadOnly = true;
            // 
            // CSocio
            // 
            this.CSocio.HeaderText = "Socio";
            this.CSocio.Name = "CSocio";
            this.CSocio.ReadOnly = true;
            this.CSocio.Width = 250;
            // 
            // CNum
            // 
            this.CNum.HeaderText = "Num. locker";
            this.CNum.Name = "CNum";
            this.CNum.ReadOnly = true;
            this.CNum.Visible = false;
            this.CNum.Width = 130;
            // 
            // CDescripcion
            // 
            this.CDescripcion.HeaderText = "Descripción";
            this.CDescripcion.Name = "CDescripcion";
            this.CDescripcion.ReadOnly = true;
            this.CDescripcion.Width = 250;
            // 
            // CFechaIni
            // 
            this.CFechaIni.HeaderText = "Fecha inicio";
            this.CFechaIni.Name = "CFechaIni";
            this.CFechaIni.ReadOnly = true;
            this.CFechaIni.Width = 175;
            // 
            // CFechaFin
            // 
            this.CFechaFin.HeaderText = "Fecha terminación";
            this.CFechaFin.Name = "CFechaFin";
            this.CFechaFin.ReadOnly = true;
            this.CFechaFin.Width = 175;
            // 
            // CFechaPago
            // 
            this.CFechaPago.HeaderText = "Fecha pago";
            this.CFechaPago.Name = "CFechaPago";
            this.CFechaPago.ReadOnly = true;
            this.CFechaPago.Width = 175;
            // 
            // CNumTicket
            // 
            this.CNumTicket.HeaderText = "Núm. ticket";
            this.CNumTicket.Name = "CNumTicket";
            this.CNumTicket.ReadOnly = true;
            this.CNumTicket.Width = 130;
            // 
            // CMonto
            // 
            this.CMonto.HeaderText = "Monto";
            this.CMonto.Name = "CMonto";
            this.CMonto.ReadOnly = true;
            this.CMonto.Width = 130;
            // 
            // CUsuario
            // 
            this.CUsuario.HeaderText = "Usuario";
            this.CUsuario.Name = "CUsuario";
            this.CUsuario.ReadOnly = true;
            this.CUsuario.Width = 140;
            // 
            // CBtnAceptar
            // 
            this.CBtnAceptar.HeaderText = "";
            this.CBtnAceptar.Name = "CBtnAceptar";
            this.CBtnAceptar.ReadOnly = true;
            this.CBtnAceptar.Text = "Aceptar";
            this.CBtnAceptar.UseColumnTextForButtonValue = true;
            // 
            // CBtnRechazar
            // 
            this.CBtnRechazar.HeaderText = "";
            this.CBtnRechazar.Name = "CBtnRechazar";
            this.CBtnRechazar.ReadOnly = true;
            this.CBtnRechazar.Text = "Rechazar";
            this.CBtnRechazar.UseColumnTextForButtonValue = true;
            // 
            // cboPendientes
            // 
            this.cboPendientes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPendientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPendientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPendientes.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboPendientes.FormattingEnabled = true;
            this.cboPendientes.Items.AddRange(new object[] {
            "Membresías",
            "Lockers"});
            this.cboPendientes.Location = new System.Drawing.Point(755, 12);
            this.cboPendientes.Name = "cboPendientes";
            this.cboPendientes.Size = new System.Drawing.Size(217, 29);
            this.cboPendientes.TabIndex = 1;
            this.cboPendientes.SelectedIndexChanged += new System.EventHandler(this.cboPendientes_SelectedIndexChanged);
            // 
            // lblInstruccion
            // 
            this.lblInstruccion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInstruccion.AutoSize = true;
            this.lblInstruccion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInstruccion.Location = new System.Drawing.Point(619, 18);
            this.lblInstruccion.Name = "lblInstruccion";
            this.lblInstruccion.Size = new System.Drawing.Size(130, 19);
            this.lblInstruccion.TabIndex = 0;
            this.lblInstruccion.Text = "Lista de pendientes:";
            // 
            // bgwBusqueda
            // 
            this.bgwBusqueda.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwBusqueda_DoWork);
            this.bgwBusqueda.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwBusqueda_RunWorkerCompleted);
            // 
            // tmrEspera
            // 
            this.tmrEspera.Interval = 300;
            this.tmrEspera.Tick += new System.EventHandler(this.tmrEspera_Tick);
            // 
            // frmPendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 411);
            this.Controls.Add(this.lblInstruccion);
            this.Controls.Add(this.cboPendientes);
            this.Controls.Add(this.dgvPendientes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPendientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pendientes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPendientes;
        private System.Windows.Forms.ComboBox cboPendientes;
        private System.Windows.Forms.Label lblInstruccion;
        private System.ComponentModel.BackgroundWorker bgwBusqueda;
        private System.Windows.Forms.Timer tmrEspera;
        private System.Windows.Forms.DataGridViewTextBoxColumn CID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNumSocio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSocio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFechaIni;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFechaFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFechaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNumTicket;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUsuario;
        private System.Windows.Forms.DataGridViewButtonColumn CBtnAceptar;
        private System.Windows.Forms.DataGridViewButtonColumn CBtnRechazar;
    }
}