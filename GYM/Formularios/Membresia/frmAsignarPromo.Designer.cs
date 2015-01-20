namespace GYM.Formularios.Membresia
{
    partial class frmAsignarPromo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsignarPromo));
            this.dgvPromociones = new System.Windows.Forms.DataGridView();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.cboTipoPromo = new System.Windows.Forms.ComboBox();
            this.lblETipoPromo = new System.Windows.Forms.Label();
            this.CID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHoraInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHoraFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDuracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromociones)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPromociones
            // 
            this.dgvPromociones.AllowUserToAddRows = false;
            this.dgvPromociones.AllowUserToDeleteRows = false;
            this.dgvPromociones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPromociones.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.dgvPromociones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPromociones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvPromociones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPromociones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPromociones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPromociones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CID,
            this.CHoraInicio,
            this.CHoraFin,
            this.CDescripcion,
            this.CPrecio,
            this.CDuracion});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPromociones.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPromociones.Location = new System.Drawing.Point(12, 47);
            this.dgvPromociones.Name = "dgvPromociones";
            this.dgvPromociones.ReadOnly = true;
            this.dgvPromociones.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPromociones.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPromociones.RowHeadersVisible = false;
            this.dgvPromociones.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvPromociones.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPromociones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPromociones.Size = new System.Drawing.Size(870, 274);
            this.dgvPromociones.TabIndex = 2;
            this.dgvPromociones.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPromociones_RowEnter);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnAceptar.Location = new System.Drawing.Point(807, 327);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // cboTipoPromo
            // 
            this.cboTipoPromo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPromo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipoPromo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboTipoPromo.FormattingEnabled = true;
            this.cboTipoPromo.Items.AddRange(new object[] {
            "Por fecha",
            "Por horario"});
            this.cboTipoPromo.Location = new System.Drawing.Point(597, 12);
            this.cboTipoPromo.Name = "cboTipoPromo";
            this.cboTipoPromo.Size = new System.Drawing.Size(285, 29);
            this.cboTipoPromo.TabIndex = 1;
            this.cboTipoPromo.SelectedIndexChanged += new System.EventHandler(this.cboTipoPromo_SelectedIndexChanged);
            // 
            // lblETipoPromo
            // 
            this.lblETipoPromo.AutoSize = true;
            this.lblETipoPromo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblETipoPromo.Location = new System.Drawing.Point(467, 18);
            this.lblETipoPromo.Name = "lblETipoPromo";
            this.lblETipoPromo.Size = new System.Drawing.Size(124, 19);
            this.lblETipoPromo.TabIndex = 0;
            this.lblETipoPromo.Text = "Tipo de promoción";
            // 
            // CID
            // 
            this.CID.HeaderText = "ID";
            this.CID.Name = "CID";
            this.CID.ReadOnly = true;
            this.CID.Visible = false;
            // 
            // CHoraInicio
            // 
            dataGridViewCellStyle2.Format = "hh:mm tt";
            this.CHoraInicio.DefaultCellStyle = dataGridViewCellStyle2;
            this.CHoraInicio.HeaderText = "Hora inicio";
            this.CHoraInicio.Name = "CHoraInicio";
            this.CHoraInicio.ReadOnly = true;
            this.CHoraInicio.Visible = false;
            this.CHoraInicio.Width = 130;
            // 
            // CHoraFin
            // 
            dataGridViewCellStyle3.Format = "hh:mm tt";
            this.CHoraFin.DefaultCellStyle = dataGridViewCellStyle3;
            this.CHoraFin.HeaderText = "Hora terminación";
            this.CHoraFin.Name = "CHoraFin";
            this.CHoraFin.ReadOnly = true;
            this.CHoraFin.Visible = false;
            this.CHoraFin.Width = 130;
            // 
            // CDescripcion
            // 
            this.CDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CDescripcion.HeaderText = "Descripción";
            this.CDescripcion.Name = "CDescripcion";
            this.CDescripcion.ReadOnly = true;
            // 
            // CPrecio
            // 
            dataGridViewCellStyle4.Format = "C2";
            this.CPrecio.DefaultCellStyle = dataGridViewCellStyle4;
            this.CPrecio.HeaderText = "Precio";
            this.CPrecio.Name = "CPrecio";
            this.CPrecio.ReadOnly = true;
            // 
            // CDuracion
            // 
            this.CDuracion.HeaderText = "Duración";
            this.CDuracion.Name = "CDuracion";
            this.CDuracion.ReadOnly = true;
            // 
            // frmAsignarPromo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 362);
            this.Controls.Add(this.lblETipoPromo);
            this.Controls.Add(this.cboTipoPromo);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dgvPromociones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAsignarPromo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignar Promoción";
            this.Load += new System.EventHandler(this.frmAsignarPromo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromociones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPromociones;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox cboTipoPromo;
        private System.Windows.Forms.Label lblETipoPromo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHoraInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHoraFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDuracion;
    }
}