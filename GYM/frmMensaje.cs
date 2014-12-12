using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYM
{
    public partial class frmMensaje : Form
    {
        int cont = 0;

        public frmMensaje(string mensaje, string titulo)
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
            this.lblMensaje.Text = mensaje;
            this.Text = titulo;
            this.Size = new Size(lblMensaje.Size.Width + 60, 145);
        }

        private void frmMensaje_HandleCreated(object sender, EventArgs e)
        {
            this.lblMensaje.Location = new Point((this.Size.Width - lblMensaje.Width) / 2 - 10, lblMensaje.Location.Y);
        }

        private void frmMensaje_Shown(object sender, EventArgs e)
        {
            tmrConteo.Enabled = true;
        }

        private void tmrConteo_Tick(object sender, EventArgs e)
        {
            cont++;
            if (cont == 3)
            {
                btnAceptar.Text = "Aceptar (" + (3 - cont) + ")";
                this.Close();
            }
            else
            {
                btnAceptar.Text = "Aceptar (" +  (3 - cont) + ")";
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
