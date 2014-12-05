using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYM.Formularios.Reporte
{
    public partial class frmVisorPDF : Form
    {
        private string ruta;

        public string Ruta
        {
            get { return ruta; }
            set { ruta = value; }
        }
        
        public frmVisorPDF(string ruta)
        {
            InitializeComponent();
            cargar(ruta);
        }
        public frmVisorPDF()
        {
            InitializeComponent();
        }

        public void cargar(string ruta)
        {
            if (!System.IO.File.Exists(ruta))
            {
                this.Visible = false;
                MessageBox.Show("Se ha generado un error al generar la vista previa, intentelo de nuevo.","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {              
                pdf.LoadFile(ruta);
                pdf.Refresh();
                this.Visible = true;
                this.StartPosition = FormStartPosition.CenterParent;
            }
            //ShowDialog();
        }

        private void frmVisorPDF_Load(object sender, EventArgs e)
        {
            if (Clases.CFuncionesGenerales.AperturaUnicaFormulario(this.Name))
                this.Close();
        }

        private void frmVisorPDF_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void frmVisorPDF_FormClosing(object sender, FormClosingEventArgs e)
        {
            //pdf = new AxAcroPDFLib.AxAcroPDF() ;
            e.Cancel = true;
            this.Visible = false;
        }

        private void frmVisorPDF_Deactivate(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
        }

        private void frmVisorPDF_Enter(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
        }
    }
}
