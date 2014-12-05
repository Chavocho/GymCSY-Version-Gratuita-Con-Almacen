namespace GYM.Formularios.Reporte
{
    partial class frmVisorPDF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisorPDF));
            this.pdf = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.pdf)).BeginInit();
            this.SuspendLayout();
            // 
            // pdf
            // 
            this.pdf.Enabled = true;
            this.pdf.Location = new System.Drawing.Point(-1, 0);
            this.pdf.Name = "pdf";
            this.pdf.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pdf.OcxState")));
            this.pdf.Size = new System.Drawing.Size(749, 633);
            this.pdf.TabIndex = 0;
            // 
            // frmVisorPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 629);
            this.Controls.Add(this.pdf);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVisorPDF";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vista previa";
            this.Deactivate += new System.EventHandler(this.frmVisorPDF_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVisorPDF_FormClosing);
            this.Load += new System.EventHandler(this.frmVisorPDF_Load);
            this.Enter += new System.EventHandler(this.frmVisorPDF_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.pdf)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public AxAcroPDFLib.AxAcroPDF pdf;
    }
}