using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using GYM.Clases;

namespace GYM.Formularios.Reporte
{
    public partial class frmGaleriaIconos : Form
    {
        string name;

        private string rutaImagen;

        public string RutaImagen
        {
            get { return rutaImagen; }
            set { rutaImagen = value; }
        }
        
        public frmGaleriaIconos()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmGaleriaIconos_Load(object sender, EventArgs e)
        {
            rbuton1.Checked = true;
            cargarDatosConfiguracion();

            pictureBox1.Image = new Bitmap("Img/1.gif");
            pictureBox4.Image = new Bitmap("Img/2.gif");
            pictureBox6.Image = new Bitmap("Img/3.gif");
            pictureBox2.Image = new Bitmap("Img/4.gif");
            pictureBox3.Image = new Bitmap("Img/5.gif");
            pictureBox5.Image = new Bitmap("Img/6.gif");
            pictureBox9.Image = new Bitmap("Img/7.gif");
            pictureBox8.Image = new Bitmap("Img/8.gif");



        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
     
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            cargarDesdeArchivoLocal();
        }

        private void rbuton1_CheckedChanged(object sender, EventArgs e)
        {
            RutaImagen = "Img/1.gif";
        }

        private void rbuton2_CheckedChanged(object sender, EventArgs e)
        {
            RutaImagen = "Img/2.gif";
        }

        private void rbuton3_CheckedChanged(object sender, EventArgs e)
        {
            RutaImagen = "Img/3.gif"; 
        }

        private void rbuton4_CheckedChanged(object sender, EventArgs e)
        {
            RutaImagen = "Img/4.gif";
        }
        private void rbuton5_CheckedChanged(object sender, EventArgs e)
        {
            RutaImagen = "Img/5.gif";
        }
        private void rbuton6_CheckedChanged(object sender, EventArgs e)
        {
            RutaImagen = "Img/6.gif";
        }

        private void rbuton7_CheckedChanged(object sender, EventArgs e)
        {
            RutaImagen = "Img/7.gif";
        }

        private void rbuton8_CheckedChanged(object sender, EventArgs e)
        {
            RutaImagen = "Img/8.gif";
        }

        private void rbuton9_CheckedChanged(object sender, EventArgs e)
        {
            RutaImagen = name;
        }

        private void frmGaleriaIconos_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }


        private void cargarDatosConfiguracion()
        {
            try
            {
                pboxCargarImagen.Image = new Bitmap(CConfiguracionXML.LeerConfiguración("encabezado", "ultimaImagenSeleccionada"));
                rbuton9.Enabled = true;
            }
            catch
            {
                
                
            }
            
        }

        private void guardarDatosConfiguracion()
        {
            try
            {
                
            CConfiguracionXML.GuardarConfiguracion("encabezado", "ultimaImagenSeleccionada", name);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void cargarDesdeArchivoLocal()
        {
            OpenFileDialog cargar = new OpenFileDialog();
            cargar.Multiselect = false;
            cargar.Filter = "Archivo de imagenes (*.jpg, *.jpeg, *.jpe, *.png) | *.jpg; *.jpeg; *.jpe; *.png";
            DialogResult respuesta = cargar.ShowDialog();
            if (respuesta == System.Windows.Forms.DialogResult.OK)
            {
                if (!cargar.FileName.Equals(""))
                {
                    name =  DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + "-" + DateTime.Now.Millisecond + "-" + Path.GetFileName(cargar.FileName);
                    if (File.Exists(name))
                        File.Delete(name);
                    //Lo copia a la carpeta temporal
                    File.Copy(cargar.FileName, "Img/temp/" + name);
                    //Redimensiono la imange
                    Image nuevaImagen = new Bitmap("Img/temp/" + name);
                    Image nuevaImagen2 = CFuncionesGenerales.RedimensionarLogo(nuevaImagen, new System.Drawing.Size(70, 40));
                    nuevaImagen2.Save("Img/" + name);
                    //Eliminamos la imagen temporal
                    nuevaImagen.Dispose();
                    nuevaImagen2.Dispose();
                    File.Delete("Img/temp/" + name);
                    name = ("Img/" + name);
                    RutaImagen = name;
                    rbuton9.Enabled = true;
                    rbuton9.Checked = true;
                    pboxCargarImagen.Image = new Bitmap(name);
                    pboxCargarImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                    guardarDatosConfiguracion();

                }
                else
                    MessageBox.Show("Se ha generado un error al cargar la imagen\nintentelo de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pboxCargarImagen_Click(object sender, EventArgs e)
        {
            if (!rbuton9.Enabled)
            cargarDesdeArchivoLocal();
        }
        
        private void rbuton9_Click(object sender, EventArgs e)
        {
            if(!rbuton9.Enabled)
            cargarDesdeArchivoLocal();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            rbuton8.Checked = true;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            rbuton7.Checked = true;
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            rbuton6.Checked = true;
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            rbuton5.Checked = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            rbuton4.Checked = true;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            rbuton3.Checked = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            rbuton2.Checked = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            rbuton1.Checked = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       
    }
}
