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
    public partial class frmEncabezados : Form
    {
        public frmGaleriaIconos galeria = new frmGaleriaIconos();
        public frmEncabezados()
        {
            InitializeComponent();
        }
        private void cargarDatosConfiguracion()
        {
            try
            {
                if (CConfiguracionXML.ExisteConfiguracion("encabezado"))
                {
                    txtboxLinea1.Text = CConfiguracionXML.LeerConfiguración("encabezado", "renglon1");
                    txtboxLinea2.Text = CConfiguracionXML.LeerConfiguración("encabezado", "renglon2");
                    txtboxLinea3.Text = CConfiguracionXML.LeerConfiguración("encabezado", "renglon3");
                    galeria.RutaImagen = CConfiguracionXML.LeerConfiguración("encabezado", "img");


                }
            }
            catch (Exception)
            {
                txtboxLinea1.Text = "";
                txtboxLinea2.Text = "";
                txtboxLinea3.Text = "";
            }
            
        }

        private void guardarDatosConfiguracion()
        {

            CConfiguracionXML.GuardarConfiguracion("encabezado", "renglon1", txtboxLinea1.Text);
            CConfiguracionXML.GuardarConfiguracion("encabezado", "renglon2", txtboxLinea2.Text);
            CConfiguracionXML.GuardarConfiguracion("encabezado", "renglon3", txtboxLinea3.Text);
            CConfiguracionXML.GuardarConfiguracion("encabezado", "img", galeria.RutaImagen);

        }

        private void btnGaleria_Click(object sender, EventArgs e)
        {
            galeria.ShowDialog();
            cambiarIcono();
        }

        private void frmEncabezados_Load(object sender, EventArgs e)
        {
            cargarDatosConfiguracion();
            cambiarIcono();
        }

        private void frmEncabezados_FormClosing(object sender, FormClosingEventArgs e)
        {
            guardarDatosConfiguracion();
            e.Cancel = true;
            Hide();
        }

        private void cambiarIcono()
        {
            try
            {
                
            pboxIcono.Image = new Bitmap(galeria.RutaImagen);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha generado un error al cargar la imagen\nintentelo más tarde","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                throw;
            }
        }

        private void bntAceptar_Click(object sender, EventArgs e)
        {
            this.Hide();
            guardarDatosConfiguracion();
        }
    }
}
