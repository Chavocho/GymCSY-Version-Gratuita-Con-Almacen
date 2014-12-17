namespace GYM.Formularios.Reportes
{
    partial class frmVisualizarMembresias
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisualizarMembresias));
            this.dgvMembresias = new System.Windows.Forms.DataGridView();
            this.FechaIni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblETipo = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblTipoPago = new System.Windows.Forms.Label();
            this.lblETipoPago = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblEPrecio = new System.Windows.Forms.Label();
            this.lblFolioRemision = new System.Windows.Forms.Label();
            this.lblEFolioRemision = new System.Windows.Forms.Label();
            this.lblTerminacion = new System.Windows.Forms.Label();
            this.lblETerminacion = new System.Windows.Forms.Label();
            this.lblFolioTicket = new System.Windows.Forms.Label();
            this.lblEFolioTicket = new System.Windows.Forms.Label();
            this.lblCreateUser = new System.Windows.Forms.Label();
            this.lblECreateUser = new System.Windows.Forms.Label();
            this.lblCreateTime = new System.Windows.Forms.Label();
            this.lblECreateTime = new System.Windows.Forms.Label();
            this.lblSocio = new System.Windows.Forms.Label();
            this.lblESocio = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblInformacion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembresias)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMembresias
            // 
            this.dgvMembresias.AllowUserToAddRows = false;
            this.dgvMembresias.AllowUserToDeleteRows = false;
            this.dgvMembresias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMembresias.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.dgvMembresias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMembresias.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvMembresias.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMembresias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMembresias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembresias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FechaIni,
            this.FechaFin,
            this.Descripcion});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMembresias.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMembresias.Location = new System.Drawing.Point(12, 172);
            this.dgvMembresias.Name = "dgvMembresias";
            this.dgvMembresias.ReadOnly = true;
            this.dgvMembresias.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMembresias.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMembresias.RowHeadersVisible = false;
            this.dgvMembresias.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvMembresias.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMembresias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMembresias.Size = new System.Drawing.Size(984, 316);
            this.dgvMembresias.TabIndex = 14;
            this.dgvMembresias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMembresias_CellClick);
            // 
            // FechaIni
            // 
            this.FechaIni.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FechaIni.HeaderText = "Fecha de inicio";
            this.FechaIni.Name = "FechaIni";
            this.FechaIni.ReadOnly = true;
            this.FechaIni.Width = 250;
            // 
            // FechaFin
            // 
            this.FechaFin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FechaFin.HeaderText = "Fecha de fin";
            this.FechaFin.Name = "FechaFin";
            this.FechaFin.ReadOnly = true;
            this.FechaFin.Width = 250;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // lblETipo
            // 
            this.lblETipo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblETipo.AutoSize = true;
            this.lblETipo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblETipo.Location = new System.Drawing.Point(516, 9);
            this.lblETipo.Name = "lblETipo";
            this.lblETipo.Size = new System.Drawing.Size(128, 19);
            this.lblETipo.TabIndex = 15;
            this.lblETipo.Text = "Tipo de membresía:";
            // 
            // lblTipo
            // 
            this.lblTipo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTipo.Location = new System.Drawing.Point(650, 28);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(114, 19);
            this.lblTipo.TabIndex = 16;
            this.lblTipo.Text = "Sin información";
            // 
            // lblTipoPago
            // 
            this.lblTipoPago.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTipoPago.AutoSize = true;
            this.lblTipoPago.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTipoPago.Location = new System.Drawing.Point(869, 28);
            this.lblTipoPago.Name = "lblTipoPago";
            this.lblTipoPago.Size = new System.Drawing.Size(114, 19);
            this.lblTipoPago.TabIndex = 18;
            this.lblTipoPago.Text = "Sin información";
            // 
            // lblETipoPago
            // 
            this.lblETipoPago.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblETipoPago.AutoSize = true;
            this.lblETipoPago.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblETipoPago.Location = new System.Drawing.Point(771, 9);
            this.lblETipoPago.Name = "lblETipoPago";
            this.lblETipoPago.Size = new System.Drawing.Size(92, 19);
            this.lblETipoPago.TabIndex = 17;
            this.lblETipoPago.Text = "Tipo de pago:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPrecio.Location = new System.Drawing.Point(63, 84);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(114, 19);
            this.lblPrecio.TabIndex = 20;
            this.lblPrecio.Text = "Sin información";
            // 
            // lblEPrecio
            // 
            this.lblEPrecio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEPrecio.AutoSize = true;
            this.lblEPrecio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEPrecio.Location = new System.Drawing.Point(8, 65);
            this.lblEPrecio.Name = "lblEPrecio";
            this.lblEPrecio.Size = new System.Drawing.Size(49, 19);
            this.lblEPrecio.TabIndex = 19;
            this.lblEPrecio.Text = "Precio:";
            // 
            // lblFolioRemision
            // 
            this.lblFolioRemision.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFolioRemision.AutoSize = true;
            this.lblFolioRemision.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFolioRemision.Location = new System.Drawing.Point(358, 84);
            this.lblFolioRemision.Name = "lblFolioRemision";
            this.lblFolioRemision.Size = new System.Drawing.Size(114, 19);
            this.lblFolioRemision.TabIndex = 22;
            this.lblFolioRemision.Text = "Sin información";
            // 
            // lblEFolioRemision
            // 
            this.lblEFolioRemision.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEFolioRemision.AutoSize = true;
            this.lblEFolioRemision.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEFolioRemision.Location = new System.Drawing.Point(236, 65);
            this.lblEFolioRemision.Name = "lblEFolioRemision";
            this.lblEFolioRemision.Size = new System.Drawing.Size(116, 19);
            this.lblEFolioRemision.TabIndex = 21;
            this.lblEFolioRemision.Text = "Folio de remisión:";
            // 
            // lblTerminacion
            // 
            this.lblTerminacion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTerminacion.AutoSize = true;
            this.lblTerminacion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTerminacion.Location = new System.Drawing.Point(602, 79);
            this.lblTerminacion.Name = "lblTerminacion";
            this.lblTerminacion.Size = new System.Drawing.Size(114, 19);
            this.lblTerminacion.TabIndex = 24;
            this.lblTerminacion.Text = "Sin información";
            // 
            // lblETerminacion
            // 
            this.lblETerminacion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblETerminacion.AutoSize = true;
            this.lblETerminacion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblETerminacion.Location = new System.Drawing.Point(510, 65);
            this.lblETerminacion.Name = "lblETerminacion";
            this.lblETerminacion.Size = new System.Drawing.Size(86, 19);
            this.lblETerminacion.TabIndex = 23;
            this.lblETerminacion.Text = "Terminación:";
            // 
            // lblFolioTicket
            // 
            this.lblFolioTicket.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFolioTicket.AutoSize = true;
            this.lblFolioTicket.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFolioTicket.Location = new System.Drawing.Point(857, 79);
            this.lblFolioTicket.Name = "lblFolioTicket";
            this.lblFolioTicket.Size = new System.Drawing.Size(114, 19);
            this.lblFolioTicket.TabIndex = 26;
            this.lblFolioTicket.Text = "Sin información";
            // 
            // lblEFolioTicket
            // 
            this.lblEFolioTicket.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEFolioTicket.AutoSize = true;
            this.lblEFolioTicket.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEFolioTicket.Location = new System.Drawing.Point(754, 65);
            this.lblEFolioTicket.Name = "lblEFolioTicket";
            this.lblEFolioTicket.Size = new System.Drawing.Size(97, 19);
            this.lblEFolioTicket.TabIndex = 25;
            this.lblEFolioTicket.Text = "Folio de ticket:";
            // 
            // lblCreateUser
            // 
            this.lblCreateUser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCreateUser.AutoSize = true;
            this.lblCreateUser.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCreateUser.Location = new System.Drawing.Point(117, 138);
            this.lblCreateUser.Name = "lblCreateUser";
            this.lblCreateUser.Size = new System.Drawing.Size(114, 19);
            this.lblCreateUser.TabIndex = 28;
            this.lblCreateUser.Text = "Sin información";
            // 
            // lblECreateUser
            // 
            this.lblECreateUser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblECreateUser.AutoSize = true;
            this.lblECreateUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblECreateUser.Location = new System.Drawing.Point(8, 121);
            this.lblECreateUser.Name = "lblECreateUser";
            this.lblECreateUser.Size = new System.Drawing.Size(109, 19);
            this.lblECreateUser.TabIndex = 27;
            this.lblECreateUser.Text = "Usuario creador:";
            // 
            // lblCreateTime
            // 
            this.lblCreateTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCreateTime.AutoSize = true;
            this.lblCreateTime.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCreateTime.Location = new System.Drawing.Point(373, 138);
            this.lblCreateTime.Name = "lblCreateTime";
            this.lblCreateTime.Size = new System.Drawing.Size(114, 19);
            this.lblCreateTime.TabIndex = 30;
            this.lblCreateTime.Text = "Sin información";
            // 
            // lblECreateTime
            // 
            this.lblECreateTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblECreateTime.AutoSize = true;
            this.lblECreateTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblECreateTime.Location = new System.Drawing.Point(254, 121);
            this.lblECreateTime.Name = "lblECreateTime";
            this.lblECreateTime.Size = new System.Drawing.Size(120, 19);
            this.lblECreateTime.TabIndex = 29;
            this.lblECreateTime.Text = "Fecha de creación:";
            // 
            // lblSocio
            // 
            this.lblSocio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSocio.AutoSize = true;
            this.lblSocio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSocio.Location = new System.Drawing.Point(58, 28);
            this.lblSocio.Name = "lblSocio";
            this.lblSocio.Size = new System.Drawing.Size(17, 19);
            this.lblSocio.TabIndex = 32;
            this.lblSocio.Text = "2";
            // 
            // lblESocio
            // 
            this.lblESocio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblESocio.AutoSize = true;
            this.lblESocio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblESocio.Location = new System.Drawing.Point(8, 9);
            this.lblESocio.Name = "lblESocio";
            this.lblESocio.Size = new System.Drawing.Size(44, 19);
            this.lblESocio.TabIndex = 31;
            this.lblESocio.Text = "Socio:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnAceptar.Location = new System.Drawing.Point(894, 511);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(102, 39);
            this.btnAceptar.TabIndex = 37;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblInformacion
            // 
            this.lblInformacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInformacion.AutoSize = true;
            this.lblInformacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformacion.Location = new System.Drawing.Point(40, 524);
            this.lblInformacion.Name = "lblInformacion";
            this.lblInformacion.Size = new System.Drawing.Size(566, 24);
            this.lblInformacion.TabIndex = 38;
            this.lblInformacion.Text = "Selecciona un registro para ver su información en la parte superior\r\n";
            // 
            // frmVisualizarMembresias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 562);
            this.Controls.Add(this.lblInformacion);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblSocio);
            this.Controls.Add(this.lblESocio);
            this.Controls.Add(this.lblCreateTime);
            this.Controls.Add(this.lblECreateTime);
            this.Controls.Add(this.lblCreateUser);
            this.Controls.Add(this.lblECreateUser);
            this.Controls.Add(this.lblFolioTicket);
            this.Controls.Add(this.lblEFolioTicket);
            this.Controls.Add(this.lblTerminacion);
            this.Controls.Add(this.lblETerminacion);
            this.Controls.Add(this.lblFolioRemision);
            this.Controls.Add(this.lblEFolioRemision);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblEPrecio);
            this.Controls.Add(this.lblTipoPago);
            this.Controls.Add(this.lblETipoPago);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblETipo);
            this.Controls.Add(this.dgvMembresias);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVisualizarMembresias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de membresías ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVisualizarMembresias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembresias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMembresias;
        private System.Windows.Forms.Label lblETipo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaIni;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.Label lblTipoPago;
        private System.Windows.Forms.Label lblETipoPago;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblEPrecio;
        private System.Windows.Forms.Label lblFolioRemision;
        private System.Windows.Forms.Label lblEFolioRemision;
        private System.Windows.Forms.Label lblTerminacion;
        private System.Windows.Forms.Label lblETerminacion;
        private System.Windows.Forms.Label lblFolioTicket;
        private System.Windows.Forms.Label lblEFolioTicket;
        private System.Windows.Forms.Label lblCreateUser;
        private System.Windows.Forms.Label lblECreateUser;
        private System.Windows.Forms.Label lblCreateTime;
        private System.Windows.Forms.Label lblECreateTime;
        private System.Windows.Forms.Label lblSocio;
        private System.Windows.Forms.Label lblESocio;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblInformacion;
    }
}