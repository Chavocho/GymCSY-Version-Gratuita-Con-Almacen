using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using DPUruNet;

namespace GYM.Clases
{
    class HuellaDigital
    {
        public static Reader reader;
        private static bool reset;
        private static Dictionary<int, Fmd> fmds = new Dictionary<int, Fmd>();

        /// <summary>
        /// Guarda todos los FMDs registrados en la base
        /// </summary>
        public static Dictionary<int, Fmd> Fmds
        {
            get { return fmds; }
            set { fmds = value; }
        }

        /// <summary>
        /// Reinicia la UI ocacionando que se tenga que reseleccionar el lector
        /// </summary>
        public static bool Reset
        {
            get { return reset; }
            set { reset = value; }
        }

        /// <summary>
        /// Abre el lector y verifica errores
        /// </summary>
        /// <returns>Regresa true si se abrio, false en caso contrario</returns>
        public static bool OpenReader()
        {
            reset = false;
            Constants.ResultCode result = Constants.ResultCode.DP_DEVICE_FAILURE;

            // Open reader
            if (reader != null)
            {
                result = reader.Open(Constants.CapturePriority.DP_PRIORITY_COOPERATIVE);

                if (result != Constants.ResultCode.DP_SUCCESS)
                {
                    (new frmMensaje("Error:  " + result, "GymCSY")).ShowDialog();
                    //System.Windows.Forms.MessageBox.Show("Error:  " + result);
                    reset = true;
                    return false;
                }

                return true;
            }
            return false;
        }

        /// <summary>
        /// Hookup capture handler and start capture.
        /// </summary>
        /// <param name="OnCaptured">Delegate to hookup as handler of the On_Captured event</param>
        /// <returns>Returns true if successful; false if unsuccessful</returns>
        public static bool StartCaptureAsync(Reader.CaptureCallback OnCaptured)
        {
            if (reader != null)
            {
                // Activate capture handler
                reader.On_Captured += new Reader.CaptureCallback(OnCaptured);

                // Call capture
                if (!CaptureFingerAsync())
                {
                    return false;
                }

                return true;
            }
            return false;
        }


        /// <summary>
        /// Cancel the capture and then close the reader.
        /// </summary>
        /// <param name="OnCaptured">Delegate to unhook as handler of the On_Captured event</param>
        public static void CancelCaptureAndCloseReader(Reader.CaptureCallback OnCaptured)
        {
            if (HuellaDigital.reader != null)
            {
                // Dispose of reader handle and unhook reader events.
                HuellaDigital.reader.Dispose();
                if (reset)
                {
                    HuellaDigital.reader = null;
                }
            }
        }

        /// <summary>
        /// Check the device status before starting capture.
        /// </summary>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de una aplicación.</exception>
        public static void GetStatus()
        {
            if (reader != null)
            {
                Constants.ResultCode result = HuellaDigital.reader.GetStatus();

                if ((result != Constants.ResultCode.DP_SUCCESS))
                {
                    if (HuellaDigital.reader != null)
                    {
                        HuellaDigital.reader.Dispose();
                        HuellaDigital.reader = null;
                    }
                    throw new Exception("Estatus del lector: " + result);
                }
                if ((HuellaDigital.reader.Status.Status == Constants.ReaderStatuses.DP_STATUS_BUSY))
                {
                    Thread.Sleep(50);
                }
                else if ((HuellaDigital.reader.Status.Status == Constants.ReaderStatuses.DP_STATUS_NEED_CALIBRATION))
                {
                    HuellaDigital.reader.Calibrate();
                }
                else if ((HuellaDigital.reader.Status.Status != Constants.ReaderStatuses.DP_STATUS_READY))
                {
                    throw new Exception("Estatus del lector: " + HuellaDigital.reader.Status.Status);
                }
            }
        }

        /// <summary>
        /// Check quality of the resulting capture.
        /// </summary>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de una aplicación.</exception>
        public static bool CheckCaptureResult(CaptureResult captureResult)
        {
            if (reader != null)
            {
                if (captureResult.Data == null)
                {
                    if (captureResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
                    {
                        reset = true;
                        throw new Exception("Resultado de la captura: " + captureResult.ResultCode.ToString());
                    }

                    // Send message if quality shows fake finger
                    if ((captureResult.Quality != Constants.CaptureQuality.DP_QUALITY_CANCELED))
                    {
                        throw new Exception("Calidad de la captura: " + captureResult.Quality);
                    }
                    return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Function to capture a finger. Always get status first and calibrate or wait if necessary.  Always check status and capture errors.
        /// </summary>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de una aplicación.</exception>
        /// <returns>Valor booleano que indica si la operación de lectura se completo correctamente</returns>
        public static bool CaptureFingerAsync()
        {
            try
            {
                GetStatus();

                Constants.ResultCode captureResult = HuellaDigital.reader.CaptureAsync(Constants.Formats.Fid.ANSI, Constants.CaptureProcessing.DP_IMG_PROC_DEFAULT, reader.Capabilities.Resolutions[0]);
                if (captureResult != Constants.ResultCode.DP_SUCCESS)
                {
                    reset = true;
                    throw new Exception("Resultado de captura: " + captureResult);
                }

                return true;
            }
            catch (Exception ex)
            {
                (new frmMensaje("Error:  " + ex.Message, "GymCSY")).ShowDialog();
                //System.Windows.Forms.MessageBox.Show("Error:  " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Crea un bitmap usando los bytes de la huella
        /// </summary>
        /// <param name="bytes">Bytes que contienen la información de la huella</param>
        /// <param name="width">Ancho de la imagen</param>
        /// <param name="height">Alto de la imagen</param>
        /// <returns>Imagen de la huella</returns>
        public static Bitmap CreateBitmap(byte[] bytes, int width, int height)
        {
            byte[] rgbBytes = new byte[bytes.Length * 3];

            for (int i = 0; i <= bytes.Length - 1; i++)
            {
                rgbBytes[(i * 3)] = bytes[i];
                rgbBytes[(i * 3) + 1] = bytes[i];
                rgbBytes[(i * 3) + 2] = bytes[i];
            }
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            for (int i = 0; i <= bmp.Height - 1; i++)
            {
                IntPtr p = new IntPtr(data.Scan0.ToInt64() + data.Stride * i);
                System.Runtime.InteropServices.Marshal.Copy(rgbBytes, i * bmp.Width * 3, p, bmp.Width * 3);
            }

            bmp.UnlockBits(data);

            return bmp;
        }
    }
}
