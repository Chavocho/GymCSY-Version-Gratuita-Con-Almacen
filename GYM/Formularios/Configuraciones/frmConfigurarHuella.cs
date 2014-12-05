using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DPUruNet;

namespace GYM.Formularios
{
    public partial class frmConfigurarHuella : Form
    {
        Reader tmpReader;
        public ReaderCollection readers;
        private bool reset = false;
        bool loCerroReg = false;

        #region Instancia
        private static frmConfigurarHuella frmInstancia;
        public static frmConfigurarHuella Instancia
        {
            get
            {
                if (frmInstancia == null)
                    frmInstancia = new frmConfigurarHuella();
                else if (frmInstancia.IsDisposed)
                    frmInstancia = new frmConfigurarHuella();
                return frmInstancia;
            }
            set
            {
                frmInstancia = value;
            }
        }
        #endregion

        public frmConfigurarHuella()
        {
            InitializeComponent();
            try
            {
                Clases.CFuncionesGenerales.CargarInterfaz(this);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void frmConfigurarHuella_Load(object sender, EventArgs e)
        {
            CerrarRegistro();
            tmpReader = Clases.HuellaDigital.reader;
        }

        private void CargarLectores()
        {
            try
            {
                cboLectores.Items.Clear();
                readers = ReaderCollection.GetReaders();
                foreach (Reader rd in readers)
                {
                    cboLectores.Items.Add(rd.Description.SerialNumber);
                }
                if (cboLectores.Items.Count > 0)
                    cboLectores.SelectedIndex = 0;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Indice fuera de rango.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pueden agregar argumentos nulos a un ComboBox.", ex);
            }
        }

        private void Streaming()
        {
            try
            {
                Application.DoEvents();

                pcbHuella.Image = null;

                if (!Clases.HuellaDigital.OpenReader())
                {
                    this.Close();
                }

                if (!Clases.HuellaDigital.reader.Capabilities.CanStream)
                {
                    MessageBox.Show("This reader cannot stream in this environment.");
                    return;
                }

                Clases.HuellaDigital.reader.StartStreaming();

                CaptureResult captureResult = null;

                reset = false;
                while ((!reset))
                {
                    captureResult = Clases.HuellaDigital.reader.GetStreamImage(Constants.Formats.Fid.ANSI, Constants.CaptureProcessing.DP_IMG_PROC_DEFAULT, Clases.HuellaDigital.reader.Capabilities.Resolutions[0]);

                    Application.DoEvents();

                    if (captureResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
                    {
                        if (Clases.HuellaDigital.reader != null)
                        {
                            Clases.HuellaDigital.reader.Dispose();
                            Clases.HuellaDigital.reader = null;
                        }
                        reset = true;
                        MessageBox.Show("Error:  " + captureResult.ResultCode.ToString());
                    }

                    if (captureResult.Data != null)
                    {
                        foreach (Fid.Fiv fiv in captureResult.Data.Views)
                        {
                            SendMessage(Clases.HuellaDigital.CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height));
                        }
                    }
                }
            }
            catch (ObjectDisposedException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Se ha tratado de realizar en un objeto desechado.", ex);
            }
            catch (InvalidOperationException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Se ha tratado de realizar una operación en un objeto cuyo estado actual no lo permite.", ex);
            }
        }

        #region SendMessage
        private delegate void SendMessageCallback(object payload);
        private void SendMessage(object payload)
        {
            try
            {
                if (this.pcbHuella.InvokeRequired)
                {
                    SendMessageCallback d = new SendMessageCallback(SendMessage);
                    this.Invoke(d, new object[] { payload });
                }
                else
                {
                    pcbHuella.Image = (Bitmap)payload;
                    pcbHuella.Refresh();
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion

        private void CerrarRegistro()
        {
            Form fRegistro = null;

            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == "frmRegistroEntradas")
                    fRegistro = frm;
            }
            if (fRegistro != null)
            {
                loCerroReg = true;
                fRegistro.Close();
            }
        }

        private void frmConfigurarHuella_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                for (int i = 0; i < 20; i++)
                {
                    System.Threading.Thread.Sleep(25);
                    Application.DoEvents();
                }

                reset = true;

                for (int i = 0; i < 20; i++)
                {
                    System.Threading.Thread.Sleep(25);
                    Application.DoEvents();
                }

                if (Clases.HuellaDigital.reader != null)
                {
                    Clases.HuellaDigital.reader.StopStreaming();
                    Clases.HuellaDigital.reader.Dispose();
                }
                if (loCerroReg)
                    frmRegistroEntradas.Instancia.Show();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El valor del argumento se encuentra fuera del rango aceptado.", ex);
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarLectores();
        }

        private void cboLectores_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clases.HuellaDigital.reader = readers[cboLectores.SelectedIndex];
            Streaming();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                reset = true;
                Clases.CConfiguracionXML.GuardarConfiguracion("huella", "lector", readers[cboLectores.SelectedIndex].Description.SerialNumber.ToString());
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
            this.Close();
        }

        private void frmConfigurarHuella_Shown(object sender, EventArgs e)
        {
            CargarLectores();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            reset = true;
            Clases.HuellaDigital.reader = tmpReader;
            this.Close();
        }
    }
}
