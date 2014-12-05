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

namespace GYM.Formularios.Socio
{
    public partial class frmCapturarHuella : Form
    {
        
        DataResult<Fmd> res;
        frmAgregarMiembro frmA = null;
        frmEditarMiembro frmE = null;

        public frmCapturarHuella(frmAgregarMiembro frm)
        {
            InitializeComponent();
            this.frmA = frm;
        }

        public frmCapturarHuella(frmEditarMiembro frm)
        {
            InitializeComponent();
            this.frmE = frm;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (res != null)
            {
                if (frmA != null)
                    frmA.huella = res.Data.Bytes;
                else if (frmE != null)
                    frmE.huella = res.Data.Bytes;
            }
            else
            {
                MessageBox.Show("No haz registrado ninguna huella", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Close();
        }

        private void frmCapturarHuella_Load(object sender, EventArgs e)
        {
            pcbHuella.Image = null;
            if (!Clases.HuellaDigital.OpenReader())
            {
                this.Close();
            }

            if (!Clases.HuellaDigital.StartCaptureAsync(this.OnCaptured))
            {
                this.Close();
            }
        }

        /// <summary>
        /// Handler for when a fingerprint is captured.
        /// </summary>
        /// <param name="captureResult">contains info and data on the fingerprint capture</param>
        public void OnCaptured(CaptureResult captureResult)
        {
            try
            {
                // Check capture quality and throw an error if bad.
                if (!Clases.HuellaDigital.CheckCaptureResult(captureResult)) return;

                // Create bitmap
                foreach (Fid.Fiv fiv in captureResult.Data.Views)
                {
                    SendMessage(Action.SendBitmap, Clases.HuellaDigital.CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height));
                }
                //Guardamos el FMD de la huella
                res = FeatureExtraction.CreateFmdFromFid(captureResult.Data, Constants.Formats.Fmd.ANSI);
            }
            catch (Exception ex)
            {
                // Send error message, then close form
                SendMessage(Action.SendMessage, "Error:  " + ex.Message);
            }
        }

        #region SendMessage
        private enum Action
        {
            SendBitmap,
            SendMessage
        }

        private delegate void SendMessageCallback(Action action, object payload);
        private void SendMessage(Action action, object payload)
        {
            try
            {
                if (this.pcbHuella.InvokeRequired)
                {
                    SendMessageCallback d = new SendMessageCallback(SendMessage);
                    this.Invoke(d, new object[] { action, payload });
                }
                else
                {
                    switch (action)
                    {
                        case Action.SendMessage:
                            MessageBox.Show((string)payload);
                            break;
                        case Action.SendBitmap:
                            pcbHuella.Image = (Bitmap)payload;
                            pcbHuella.Refresh();
                            break;
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion

        private void frmCapturarHuella_FormClosed(object sender, FormClosedEventArgs e)
        {
            Clases.HuellaDigital.CancelCaptureAndCloseReader(this.OnCaptured);
        }
    }
}
