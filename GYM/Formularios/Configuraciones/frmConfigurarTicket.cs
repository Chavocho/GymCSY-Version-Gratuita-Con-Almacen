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

namespace GYM.Formularios
{
    public partial class frmConfigurarTicket : Form
    {
        int tamPapel;
        string impresora;

        #region Instancia
        private static frmConfigurarTicket frmInstancia;
        public static frmConfigurarTicket Instancia
        {
            get
            {
                if (frmInstancia == null)
                    frmInstancia = new frmConfigurarTicket();
                else if (frmInstancia.IsDisposed)
                    frmInstancia = new frmConfigurarTicket();
                return frmInstancia;
            }
            set
            {
                frmInstancia = value;
            }
        }
        #endregion

        public frmConfigurarTicket()
        {
            InitializeComponent();
        }

        private void CargarDatos()
        {
            try
            {
                if (!CConfiguracionXML.ExisteConfiguracion("ticket"))
                    return;
                txtLineaSuperior01.Text = CConfiguracionXML.LeerConfiguración("ticket", "lineaSup01");
                txtLineaSuperior02.Text = CConfiguracionXML.LeerConfiguración("ticket", "lineaSup02");
                txtLineaSuperior03.Text = CConfiguracionXML.LeerConfiguración("ticket", "lineaSup03");
                txtLineaSuperior04.Text = CConfiguracionXML.LeerConfiguración("ticket", "lineaSup04");
                txtLineaSuperior05.Text = CConfiguracionXML.LeerConfiguración("ticket", "lineaSup05");
                txtLineaSuperior06.Text = CConfiguracionXML.LeerConfiguración("ticket", "lineaSup06");
                txtLineaSuperior07.Text = CConfiguracionXML.LeerConfiguración("ticket", "lineaSup07");
                txtLineaInferior01.Text = CConfiguracionXML.LeerConfiguración("ticket", "lineaInf01");
                txtLineaInferior02.Text = CConfiguracionXML.LeerConfiguración("ticket", "lineaInf02");
                txtLineaInferior03.Text = CConfiguracionXML.LeerConfiguración("ticket", "lineaInf03");

                for (int i = 0; i < cbxImpresoras.Items.Count; i++)
                    if (cbxImpresoras.Items[i].ToString() == CConfiguracionXML.LeerConfiguración("ticket", "impresora"))
                        cbxImpresoras.SelectedIndex = i;

                if (CConfiguracionXML.LeerConfiguración("ticket", "tamPapel") == "210")
                    cbxTamPapel.SelectedIndex = 0;
                else if (CConfiguracionXML.LeerConfiguración("ticket", "tamPapel") == "300")
                    cbxTamPapel.SelectedIndex = 1;

                dtpTurnoMat.Value = DateTime.Parse(DateTime.Now.ToString("dd-MM-yyyy") + " " + CConfiguracionXML.LeerConfiguración("ticket", "turnoMat"));
                dtpTurnoVes.Value = DateTime.Parse(DateTime.Now.ToString("dd-MM-yyyy") + " " + CConfiguracionXML.LeerConfiguración("ticket", "turnoVes"));
                chbPreguntar.Checked = bool.Parse(CConfiguracionXML.LeerConfiguración("ticket", "preguntar"));
                chbImprimirTickets.Checked = bool.Parse(CConfiguracionXML.LeerConfiguración("ticket", "imprimir"));
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

        private void GuardarDatos()
        {
            try
            {
                CConfiguracionXML.GuardarConfiguracion("ticket", "lineaSup01", txtLineaSuperior01.Text);
                CConfiguracionXML.GuardarConfiguracion("ticket", "lineaSup02", txtLineaSuperior02.Text);
                CConfiguracionXML.GuardarConfiguracion("ticket", "lineaSup03", txtLineaSuperior03.Text);
                CConfiguracionXML.GuardarConfiguracion("ticket", "lineaSup04", txtLineaSuperior04.Text);
                CConfiguracionXML.GuardarConfiguracion("ticket", "lineaSup05", txtLineaSuperior05.Text);
                CConfiguracionXML.GuardarConfiguracion("ticket", "lineaSup06", txtLineaSuperior06.Text);
                CConfiguracionXML.GuardarConfiguracion("ticket", "lineaSup07", txtLineaSuperior07.Text);
                CConfiguracionXML.GuardarConfiguracion("ticket", "lineaInf01", txtLineaInferior01.Text);
                CConfiguracionXML.GuardarConfiguracion("ticket", "lineaInf02", txtLineaInferior02.Text);
                CConfiguracionXML.GuardarConfiguracion("ticket", "lineaInf03", txtLineaInferior03.Text);
                CConfiguracionXML.GuardarConfiguracion("ticket", "impresora", impresora);
                CConfiguracionXML.GuardarConfiguracion("ticket", "tamPapel", tamPapel.ToString());
                CConfiguracionXML.GuardarConfiguracion("ticket", "turnoMat", dtpTurnoMat.Value.ToString("HH:mm:ss"));
                CConfiguracionXML.GuardarConfiguracion("ticket", "turnoVes", dtpTurnoVes.Value.ToString("HH:mm:ss"));
                CConfiguracionXML.GuardarConfiguracion("ticket", "preguntar", chbPreguntar.Checked.ToString());
                CConfiguracionXML.GuardarConfiguracion("ticket", "imprimir", chbImprimirTickets.Checked.ToString());
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

        private void frmConfigurarTicket_Load(object sender, EventArgs e)
        {
            try
            {
                Clases.CFuncionesGenerales.CargarInterfaz(this);
                foreach (String impresora in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                    cbxImpresoras.Items.Add(impresora);
                CargarDatos();
            }
            catch (Win32Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error del tipo Win32.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El método llamado no admite argumentos nulos.", ex);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cbxImpresoras.SelectedIndex < 0)
            {
                MessageBox.Show("¡Debes seleccionar una impresora!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cbxTamPapel.SelectedIndex < 0)
            {
                MessageBox.Show("¡Debes seleccionar el tamaño del papel de la impresora!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            GuardarDatos();
            MessageBox.Show("¡Datos guardados correctamente!", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void cbxImpresoras_SelectedIndexChanged(object sender, EventArgs e)
        {
            impresora = cbxImpresoras.Items[cbxImpresoras.SelectedIndex].ToString();
        }

        private void cbxTamPapel_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxTamPapel.Items[cbxTamPapel.SelectedIndex].ToString())
            {
                case "57mm":
                    tamPapel = 210;
                    break;
                case "80mm":
                    tamPapel = 300;
                    break;
            }
        }
    }
}
