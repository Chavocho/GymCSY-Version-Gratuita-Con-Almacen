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
    public partial class frmDialogo : Form
    {
        public frmDialogo()
        {
            InitializeComponent();

           
        }

        private void frmDialogo_Load(object sender, EventArgs e)
        {
        }

        private void frmDialogo_Shown(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(2500);

           // (new Formularios.Reporte.frmReportes()).ShowDialog();
            this.Close();
        }
    }
}
