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
using MySql.Data.MySqlClient;
using DPUruNet;

namespace GYM.Formularios
{
    public partial class frmRegistroEntradas : Form
    {
        #region Instancia
        private static frmRegistroEntradas frmInstancia;
        public static frmRegistroEntradas Instancia
        {
            get
            {
                if (frmInstancia == null)
                    frmInstancia = new frmRegistroEntradas();
                else if (frmInstancia.IsDisposed)
                    frmInstancia = new frmRegistroEntradas();
                return frmInstancia;
            }
            set
            {
                frmInstancia = value;
            }
        }
        #endregion

        #region Huella
        private const int DPFJ_PROBABILITY_ONE = 0x7fffffff;
        DataResult<Fmd> res;

        private void OnCaptured(CaptureResult captureResult)
        {
            bool existio = false;
            try
            {
                if (!Clases.HuellaDigital.CheckCaptureResult(captureResult))
                    return;

                ////Creamos el bitmap para el PictureBox
                //foreach (Fid.Fiv fiv in captureResult.Data.Views)
                //{
                //    SendMessage(Action.SendBitmap, Clases.HuellaDigital.CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height));
                //}

                //Guardamos la variable de la huella
                res = FeatureExtraction.CreateFmdFromFid(captureResult.Data, Constants.Formats.Fmd.ANSI);
                if (captureResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
                {
                    Clases.HuellaDigital.Reset = true;
                    throw new Exception(captureResult.ResultCode.ToString());
                }

                Fmd[] fmds = new Fmd[2];

                foreach  (int k in Clases.HuellaDigital.Fmds.Keys)
                {
                    fmds[0] = Clases.HuellaDigital.Fmds[k];
                    int probabilidad = DPFJ_PROBABILITY_ONE * 1 / 100000;

                    IdentifyResult ideRes = Comparison.Identify(res.Data, 0, fmds, probabilidad, Clases.HuellaDigital.Fmds.Count + 1);

                    if (ideRes.ResultCode != Constants.ResultCode.DP_SUCCESS)
                    {
                        Clases.HuellaDigital.Reset = true;
                        throw new Exception(ideRes.ResultCode.ToString());
                    }
                    if (ideRes.Indexes.Length > 0)
                    {
                        SendMessage(Action.SendOK, k.ToString());
                        existio = true;
                        break;
                    }
                }
                if (!existio)
                    SendMessage(Action.SendMessage, "La huella no coincide con alguna del registro\n");
            }
            catch (Exception ex)
            {
                //Mostramos un MessageBox con el mensaje de error
                SendMessage(Action.SendMessage, ex.Message);
            }
        }

        #region SendMessage
        private enum Action
        {
            SendOK,
            SendMessage
        }

        private delegate void SendMessageCallback(Action action, object payload);
        private void SendMessage(Action action, object payload)
        {
            try
            {
                if (this.tbxNumSocio.InvokeRequired)
                {
                    SendMessageCallback d = new SendMessageCallback(SendMessage);
                    this.Invoke(d, new object[] { action, payload });
                }
                else
                {
                    switch (action)
                    {
                        case Action.SendMessage:
                            (new frmMensaje((string)payload, "Error")).ShowDialog(this);
                            break;
                        case Action.SendOK:
                            string numSocio = (string)payload;
                            for (int i = 0; i < numSocio.Length; i++)
                            {
                                tbxNumSocio.Text += numSocio[i];
                                System.Threading.Thread.Sleep(50);
                                Application.DoEvents();
                            }
                            btnRegEntrada_Click(btnRegEntrada, new EventArgs());
                            break;
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #endregion
        
        public int id = 0;
        private int nivelUsuario;
        Dictionary<int, Image> imgs = new Dictionary<int, Image>();
        int posImg = 0;

        public int NivelUsuario
        {
            get { return nivelUsuario; }
            set { nivelUsuario = value; }
        }
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        public frmRegistroEntradas()
        {
            this.NivelUsuario = nivelUsuario;
            this.ID = id;
            InitializeComponent();
            tmrTiempo.Enabled = true;
            if (!Clases.CFuncionesGenerales.soloRegistro)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmRegistroEntradas_Load(object sender, EventArgs e)
        {
            if (Clases.CFuncionesGenerales.soloRegistro)
            {
                btnConfiguración.Visible = true;
            }
            else
            {
                this.StartPosition = FormStartPosition.CenterScreen;
                btnConfiguración.Visible = false;
            }
            CerrarForms();
            Clases.CFuncionesGenerales.CargarInterfaz(this);
            lblFecha.Text = DateTime.Now.ToLongDateString().ToUpper();
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss tt");
            tbxNumSocio.Select();
            CargarImagenes();
            tclSocios.Ctr = tbxNumSocio;
            if (!Clases.HuellaDigital.OpenReader())
            {
                //MessageBox.Show("No es posible usar el lector de huellas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (!Clases.HuellaDigital.StartCaptureAsync(this.OnCaptured))
            {
                //MessageBox.Show("No es posible usar el lector de huellas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarImagenes()
        {
            for (int i = 1; i < 7; i++)
            {
                string promo = Clases.CConfiguracionXML.LeerConfiguración("promociones", "promo" + i.ToString("00"));
                if (promo != "null")
                    imgs.Add(imgs.Count, Image.FromFile(promo));
            }
            if (imgs.Count > 0)
            {
                tmrPromociones.Enabled = true;
                tmrPromociones_Tick(tmrPromociones, new EventArgs());
            }
            else
                pcbPromociones.Image = GYM.Properties.Resources.gym_promo_title;
        }

        private void CerrarForms()
        {
            Form fConfig = null, fCapt = null;
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == "frmCapturarHuella")
                    fCapt = frm;
                else if (frm.Name == "frmConfiguracionHuella")
                    fConfig = frm;
            }
            if (fConfig != null)
                fConfig.Close();
            if (fCapt != null)
                fCapt.Close();
        }

        private void btnRegEntrada_Click(object sender, EventArgs e)
        {
            CMiembro Persona = new CMiembro();
            if (tbxNumSocio.Text != "")
            {
                if (Persona.VerificarExistenciaMiembro(int.Parse(tbxNumSocio.Text)))
                {
                    (new Formularios.Socio.frmMostrarSocio(int.Parse(tbxNumSocio.Text))).ShowDialog();
                    tbxNumSocio.Text = "";
                    tbxNumSocio.Select();
                }
                else
                {
                    (new frmMensaje("El número ingresado es incorrecto o no existe", "Socio No Encontrado")).ShowDialog(this);
                    tbxNumSocio.Text = "";
                    tbxNumSocio.Select();
                }
           }   

        }

        private void tmrTiempo_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToLongDateString().ToUpper();
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void frmRegistroEntradas_FormClosed(object sender, FormClosedEventArgs e)
        {
            //(new frmMain(this.NivelUsuario,this.ID)).Show();
            Clases.HuellaDigital.CancelCaptureAndCloseReader(this.OnCaptured);
            if (Clases.CFuncionesGenerales.soloRegistro)
                Application.Exit();
        }

        private void tbxNumSocio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.CFuncionesGenerales.VerificarEsNumero(ref sender, ref e, true);
        }

        private void lblNumSocio_Click(object sender, EventArgs e)
        {

        }

        private void tbxNumSocio_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblFecha_Click(object sender, EventArgs e)
        {

        }

        private void tmrPromociones_Tick(object sender, EventArgs e)
        {
            if (posImg < imgs.Count)
            {
                pcbPromociones.Image = imgs[posImg];
                posImg++;
            }
            else
            {
                posImg = 0;
                pcbPromociones.Image = imgs[posImg];
            }
        }

        private void chbTeclado_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTeclado.Checked)
            {
                tclSocios.Visible = true;
                if (this.WindowState != FormWindowState.Maximized)
                {
                    this.Size = new Size(this.Size.Width, this.Size.Height + 200);
                    this.Location = new Point(this.Location.X, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
                }
            }
            else
            {
                tclSocios.Visible = false;
                if (this.WindowState != FormWindowState.Maximized)
                {
                    this.Size = new Size(this.Size.Width, this.Size.Height - 200);
                    this.Location = new Point(this.Location.X, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
                }
            }
        }

        private void btnConfiguración_Click(object sender, EventArgs e)
        {
            if ((new frmLoginConfig()).ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Formularios.frmConfiguracionGeneral.Instancia.ShowDialog(this);
            }
        }
    }
}
