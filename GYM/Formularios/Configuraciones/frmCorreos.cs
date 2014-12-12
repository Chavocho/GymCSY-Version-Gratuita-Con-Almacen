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
using System.Xml;
using System.IO;

namespace GYM.Formularios
{
    public partial class frmCorreos : Form
    {
        public frmCorreos()
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
        }

        private void CargarDatos()
        {
            try
            {
                if (CConfiguracionXML.ExisteConfiguracion("correo"))
                {
                    txtCorreo.Text = CConfiguracionXML.LeerConfiguración("correo", "correoR");
                    txtPass.Text = CConfiguracionXML.LeerConfiguración("correo", "pass");
                    txtPuerto.Text = CConfiguracionXML.LeerConfiguración("correo", "puerto");
                    txtHost.Text = CConfiguracionXML.LeerConfiguración("correo", "host");
                }
            }
            catch (XmlException ex)
            {
                MessageBox.Show("Ocurrio un error al leer el archivo de configuración. Linea y posición de error: " + ex.LineNumber + ", " + ex.LinePosition, "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (PathTooLongException ex)
            {
                CFuncionesGenerales.MensajeError("La ruta especificada para el arhcivo de configuración en muy larga.", ex);
            }
            catch (DirectoryNotFoundException ex)
            {
                CFuncionesGenerales.MensajeError("El directorio del archivo de configuración no se pudo encontrar.", ex);
            }
            catch (FileNotFoundException ex)
            {
                CFuncionesGenerales.MensajeError("El archivo de configuración no se pudo encontrar.", ex);
            }
            catch (IOException ex)
            {
                CFuncionesGenerales.MensajeError("Ocurrio un error de E/S.", ex);
            }
            catch (NotSupportedException ex)
            {
                CFuncionesGenerales.MensajeError("El método invocado no admite la funcionalidad invocada.", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                CFuncionesGenerales.MensajeError("Windows ha denegado el acceso al archivo de configuración por un error de E/S o por un problema de seguridad.", ex);
            }
            catch (System.Security.SecurityException ex)
            {
                CFuncionesGenerales.MensajeError("Se detectó un error de seguridad.", ex);
            }
            catch (ArgumentNullException ex)
            {
                CFuncionesGenerales.MensajeError("El argumento dado en el método es nulo.", ex);
            }
            catch (ArgumentException ex)
            {
                CFuncionesGenerales.MensajeError("El argumento dado en el método no es aceptado por éste.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void GuardarDatos()
        {
            try
            {
                CConfiguracionXML.GuardarConfiguracion("correo", "correoR", txtCorreo.Text );
                CConfiguracionXML.GuardarConfiguracion("correo", "pass", txtPass.Text);
                CConfiguracionXML.GuardarConfiguracion("correo", "puerto", txtPuerto.Text);
                CConfiguracionXML.GuardarConfiguracion("correo", "host", txtHost.Text);
                pcbImagen.Image.Save(Application.StartupPath + "\\Img\\imagencorreo.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (XmlException ex)
            {
                MessageBox.Show("Ocurrio un error al leer el archivo de configuración. Linea y posición de error: " + ex.LineNumber + ", " + ex.LinePosition, "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (PathTooLongException ex)
            {
                CFuncionesGenerales.MensajeError("La ruta especificada para el arhcivo de configuración en muy larga.", ex);
            }
            catch (DirectoryNotFoundException ex)
            {
                CFuncionesGenerales.MensajeError("El directorio del archivo de configuración no se pudo encontrar.", ex);
            }
            catch (FileNotFoundException ex)
            {
                CFuncionesGenerales.MensajeError("El archivo de configuración no se pudo encontrar.", ex);
            }
            catch (IOException ex)
            {
                CFuncionesGenerales.MensajeError("Ocurrio un error de E/S.", ex);
            }
            catch (NotSupportedException ex)
            {
                CFuncionesGenerales.MensajeError("El método invocado no admite la funcionalidad invocada.", ex);
                throw ex;
            }
            catch (UnauthorizedAccessException ex)
            {
                CFuncionesGenerales.MensajeError("Windows ha denegado el acceso al archivo de configuración por un error de E/S o por un problema de seguridad.", ex);
            }
            catch (System.Security.SecurityException ex)
            {
                CFuncionesGenerales.MensajeError("Se detectó un error de seguridad.", ex);
            }
            catch (ArgumentNullException ex)
            {
                CFuncionesGenerales.MensajeError("El argumento dado en el método es nulo.", ex);
            }
            catch (ArgumentException ex)
            {
                CFuncionesGenerales.MensajeError("El argumento dado en el método no es aceptado por éste.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private bool ValidarDatos()
        {
            if (txtCorreo.Text.Trim() == "")
            {
                MessageBox.Show("El campo correo no debe ir vacío. Este dato se tomará para enviar el correo.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                if (!CFuncionesGenerales.EsCorreoValido(txtCorreo.Text))
                {
                    MessageBox.Show("El correo ingresado no es válido.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            if (txtPass.Text.Trim() == "")
            {
                MessageBox.Show("El campo contraseña no debe ir vacío. Este dato se tomará para enviar el correo.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtPuerto.Text.Trim() == "")
            {
                MessageBox.Show("El campo puerto no debe ir vacío. Este dato servirá para conectar con el servidor de correos.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtHost.Text.Trim() == "")
            {
                MessageBox.Show("El campo host no puede ir vacío. Este dato servirá para conectar con el servidor de correos.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                GuardarDatos();
                MessageBox.Show("Se ha guardado la información correctamente.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void frmCorreos_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void txtPuerto_KeyPress(object sender, KeyPressEventArgs e)
        {
            CFuncionesGenerales.VerificarEsNumero(ref sender, ref e, true);
        }

        private void pcbImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de imagen (*.jpeg, *.jpg) | *.jpeg; *.jpg;";
            ofd.Multiselect = false;
            DialogResult r = ofd.ShowDialog(this);
            if (r == System.Windows.Forms.DialogResult.OK)
            {
                pcbImagen.Image = new Bitmap(ofd.FileName);
            }
        }
    }
}
