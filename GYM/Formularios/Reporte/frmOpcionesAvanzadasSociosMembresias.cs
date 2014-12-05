using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GYM.Clases;

namespace GYM.Formularios.Reporte
{
    public partial class frmOpcionesAvanzadasSociosMembresias : Form
    {
        frmEncabezados encabezado = new frmEncabezados();
        public frmOpcionesAvanzadasSociosMembresias()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmOpcionesAvanzadasSociosMembresias_FormClosing(object sender, FormClosingEventArgs e)
        {
            guardarDatosReporte();
            e.Cancel = true;
            this.Hide();
        }

        private void btnSalir(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmOpcionesAvanzadasSociosMembresias_Load(object sender, EventArgs e)
        {
            cargarDatosReporte();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            encabezado.ShowDialog();   
        }

        private void chboxObservacionesArchivoReporte_CheckedChanged(object sender, EventArgs e)
        {
            txtboxObservacionReporte.Enabled = chboxObservacionesArchivoReporte.Checked;
            if (!txtboxObservacionReporte.Enabled)
                txtboxObservacionReporte.Text = "";
        }

        private void cargarDatosReporte()
        {
            try
            {
                if (CConfiguracionXML.ExisteConfiguracion("reporte"))
                {
                    //Numero de paginas
                    chboxNumeroPaginasReporte.Checked = Convert.ToBoolean(CConfiguracionXML.LeerConfiguración("reporte", "numeroPaginas"));
                    //Datos del usuario creador
                    chboxDatosUsuarioCreadorReporte.Checked = Convert.ToBoolean(CConfiguracionXML.LeerConfiguración("reporte", "usuarioCreador"));
                    //Hora creacion
                    chboxHoraCreacionReporte.Checked = Convert.ToBoolean(CConfiguracionXML.LeerConfiguración("reporte", "fecha"));
                    //Pie de pagina -bool
                    chboxPiePagina.Checked = Convert.ToBoolean(CConfiguracionXML.LeerConfiguración("reporte", "piePagina"));
                    //Pie de pagina -txt
                    txtboxPiePagina.Text = CConfiguracionXML.LeerConfiguración("reporte", "piePagina-txt");
                    //Observaciones al final del archivo   -bool
                    chboxObservacionesArchivoReporte.Checked = Convert.ToBoolean(CConfiguracionXML.LeerConfiguración("reporte", "observaciones"));
                    //Observaciones al final del archivo   -txt
                    txtboxObservacionReporte.Text = CConfiguracionXML.LeerConfiguración("reporte", "observaciones-txt");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void guardarDatosReporte()
        {
            //Numero de paginas
            CConfiguracionXML.GuardarConfiguracion("reporte", "numeroPaginas", chboxNumeroPaginasReporte.Checked.ToString());
            //Datos del usuario creador
            CConfiguracionXML.GuardarConfiguracion("reporte", "usuarioCreador", chboxDatosUsuarioCreadorReporte.Checked.ToString());
            //Hora creacion
            CConfiguracionXML.GuardarConfiguracion("reporte", "fecha", chboxHoraCreacionReporte.Checked.ToString());
            //Pie de pagina -bool
            CConfiguracionXML.GuardarConfiguracion("reporte", "piePagina", chboxPiePagina.Checked.ToString());
            //Pie de pagina -txt
            CConfiguracionXML.GuardarConfiguracion("reporte", "piePagina-txt", txtboxPiePagina.Text);
            //Observaciones al final del archivo   -bool
            CConfiguracionXML.GuardarConfiguracion("reporte", "observaciones", chboxObservacionesArchivoReporte.Checked.ToString());
            //Observaciones al final del archivo   -txt
            CConfiguracionXML.GuardarConfiguracion("reporte", "observaciones-txt", txtboxObservacionReporte.Text);


        }

        private void chboxPiePagina_CheckedChanged(object sender, EventArgs e)
        {
            txtboxPiePagina.Enabled = chboxPiePagina.Checked;
            if (!txtboxPiePagina.Enabled)
                txtboxPiePagina.Text = "";
        }

       
    }
}
