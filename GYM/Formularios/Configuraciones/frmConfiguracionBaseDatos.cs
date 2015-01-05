using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYM.Formularios
{
    public partial class frmConfiguracionBaseDatos : Form
    {
        #region Instancia
        private static frmConfiguracionBaseDatos frmInstancia;
        public static frmConfiguracionBaseDatos Instancia
        {
            get
            {
                if (frmInstancia == null)
                    frmInstancia = new frmConfiguracionBaseDatos();
                else if (frmInstancia.IsDisposed)
                    frmInstancia = new frmConfiguracionBaseDatos();
                return frmInstancia;
            }
            set
            {
                frmInstancia = value;
            }
        }
        #endregion

        public frmConfiguracionBaseDatos()
        {
            InitializeComponent();
            Clases.CFuncionesGenerales.CargarInterfaz(this);
        }

        private void GuardarConfig()
        {
            try
            {
                Clases.CConfiguracionXML.GuardarConfiguracion("baseDatos", "servidor", txtServidor.Text);
                Clases.CConfiguracionXML.GuardarConfiguracion("baseDatos", "base", txtBaseDatos.Text);
                Clases.CConfiguracionXML.GuardarConfiguracion("baseDatos", "usuario", txtUsuario.Text);
                Clases.CConfiguracionXML.GuardarConfiguracion("baseDatos", "pass", txtPass.Text);
                Clases.ConexionBD.servidor = txtServidor.Text;
                Clases.ConexionBD.baseDatos = txtBaseDatos.Text;
                Clases.ConexionBD.usuario = txtUsuario.Text;
                Clases.ConexionBD.pass = txtPass.Text;
            }
            catch (System.Xml.XmlException ex)
            {
                MessageBox.Show("Ha ocurrido un error al querer guardar en el archivo XML. Mensaje de error:" + ex.Message + "\nNúmero de linea y posición: " + ex.LineNumber + ", " + ex.LinePosition,
                    "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.IO.PathTooLongException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("La ruta del directorio es muy larga.", ex);
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El directorio del archivo de configuración no se encontró.", ex);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se encontro el archivo de configuración.", ex);
            }
            catch (System.IO.IOException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error de E/S.", ex);
            }
            catch (InvalidOperationException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("La llamada al método no se pudo efectuar porque el estado actual del objeto no lo permite.", ex);
            }
            catch (NotSupportedException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo leer o modificar la secuencia de datos.", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El sistema ha negado el acceso al archivo de configuración.\nPuede deberse a un error de E/S o a un error de seguridad.", ex);
            }
            catch (System.Security.SecurityException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error de seguridad.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El método no acepta referencias nulas.", ex);
            }
            catch (ArgumentException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El argumento que se pasó al método no es aceptado por este.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                GuardarConfig();
                MessageBox.Show("La aplicación se cerrará.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            catch (ObjectDisposedException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error llamando a un método en un objeto desechado.", ex);
            }
            catch (InvalidOperationException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Se ha llamado a un método en un objeto cuyo estado actual no lo permite.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void frmConfiguracionBaseDatos_Load(object sender, EventArgs e)
        {
            try
            {
                if (Clases.CConfiguracionXML.ExisteConfiguracion("baseDatos"))
                {
                    txtServidor.Text = Clases.CConfiguracionXML.LeerConfiguración("baseDatos", "servidor");
                    txtBaseDatos.Text = Clases.CConfiguracionXML.LeerConfiguración("baseDatos", "base");
                    txtUsuario.Text = Clases.CConfiguracionXML.LeerConfiguración("baseDatos", "usuario");
                    txtPass.Text = Clases.CConfiguracionXML.LeerConfiguración("baseDatos", "pass");
                }
            }
            catch (System.Xml.XmlException ex)
            {
                MessageBox.Show("Ha ocurrido un error al querer leer del archivo XML. Mensaje de error:" + ex.Message + "\nNúmero de linea y posición: " + ex.LineNumber + ", " + ex.LinePosition,
                    "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.IO.PathTooLongException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("La ruta del directorio es muy larga.", ex);
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El directorio del archivo de configuración no se encontró.", ex);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se encontro el archivo de configuración.", ex);
            }
            catch (System.IO.IOException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error de E/S.", ex);
            }
            catch (InvalidOperationException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("La llamada al método no se pudo efectuar porque el estado actual del objeto no lo permite.", ex);
            }
            catch (NotSupportedException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo leer o modificar la secuencia de datos.", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El sistema ha negado el acceso al archivo de configuración.\nPuede deberse a un error de E/S o a un error de seguridad.", ex);
            }
            catch (System.Security.SecurityException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error de seguridad.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El método no acepta referencias nulas.", ex);
            }
            catch (ArgumentException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El argumento que se pasó al método no es aceptado por este.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }
    }
}
