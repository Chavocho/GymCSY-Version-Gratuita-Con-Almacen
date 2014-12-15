using System;
using System.Security.Cryptography;
using System.Xml;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using GYM.Formularios;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace System
{
    /// <summary>
    /// Permite crear un delegado que te permite mostrar el mensaje de error cuando se manda a llamar desde un hilo.
    /// </summary>
    /// <param name="mensaje">Mensaje personalizado a mostrar.</param>
    /// <param name="ex">Excepción que ocurrió.</param>
    public delegate void MensajeError(string mensaje, Exception ex);
}

namespace GYM.Clases
{
    class CFuncionesGenerales
    {
        static frmEspera frm;

        #region Criptografía
        private static string clave = "Ever esperame esperame esperame";

        /// <summary>
        /// Función que cifra una cadena para una mayor seguridad
        /// </summary>
        /// <param name="cadena">Cadena a cifrar</param>
        /// <returns>Cadena original cifrada</returns>
        /// <exception cref="System.ObjectDisposedException">Excepción que se produce cuando se realiza una operación en un objeto desechado</exception>
        /// <exception cref="System.InvalidOperationException">Excepción que se produce cuando una llamada a un método no es válida para el estado actual del objeto.</exception>
        /// <exception cref="System.ArgumentNullException">Excepción que se produce cuando se pasa una referencia nula a un método que no la acepta como argumento válido.</exception>
        /// <exception cref="System.Text.EncoderFallbackException">La excepción que se produce cuando se produce un error en la operación de reserva de codificador.</exception>
        /// <exception cref="System.Security.Cryptography.CryptographicException">Excepción que se produce cuando se produce un error durante una operación criptográfica.</exception>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de un programa.</exception>
        public static string Cifrar(string cadena)
        {
            byte[] llave = null; //Arreglo donde guardaremos la llave para el cifrado 3DES.
            byte[] arreglo = null; //Arreglo donde guardaremos la cadena descifrada.
            byte[] resultado = null;
            // Ciframos utilizando el Algoritmo MD5.
            MD5CryptoServiceProvider md5;
            try
            {
                md5 = new MD5CryptoServiceProvider();
                arreglo = UTF8Encoding.UTF8.GetBytes(cadena);
                llave = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(clave));
                md5.Clear();

                //Ciframos utilizando el Algoritmo 3DES.
                TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider();
                tripledes.Key = llave;
                tripledes.Mode = CipherMode.ECB;
                tripledes.Padding = PaddingMode.PKCS7;
                ICryptoTransform convertir = tripledes.CreateEncryptor(); // Iniciamos la conversión de la cadena
                resultado = convertir.TransformFinalBlock(arreglo, 0, arreglo.Length); //Arreglo de bytes donde guardaremos la cadena cifrada.
                tripledes.Clear();
            }
            catch (ObjectDisposedException ex)
            {
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (EncoderFallbackException ex)
            {
                throw ex;
            }
            catch (CryptographicException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Convert.ToBase64String(resultado, 0, resultado.Length); // Convertimos la cadena y la regresamos.
        }

        /// <summary>
        /// Función que descifra una cadena cifrada
        /// </summary>
        /// <param name="cadena">Cadena cifrada</param>
        /// <returns>Cadena con su valor original</returns>
        /// <exception cref="System.FormatException">Excepción que se produce cuando el formato de un argumento no cumple las especificaciones de los parámetros del método invocado.</exception>
        /// <exception cref="System.Text.EncoderFallbackException">La excepción que se produce cuando se produce un error en la operación de reserva de codificador.</exception>
        /// <exception cref="System.Text.DecoderFallbackException">Excepción que se produce cuando una operación de retroceso del descodificador (decoder fallback) no se realiza correctamente.</exception>
        /// <exception cref="System.Security.Cryptography.CryptographicException">Excepción que se produce cuando se produce un error durante una operación criptográfica.</exception>
        /// <exception cref="System.ObjectDisposedException">Excepción que se produce cuando se realiza una operación en un objeto desechado</exception>
        /// <exception cref="System.InvalidOperationException">Excepción que se produce cuando una llamada a un método no es válida para el estado actual del objeto.</exception>
        /// <exception cref="System.ArgumentNullException">Excepción que se produce cuando se pasa una referencia nula a un método que no la acepta como argumento válido.</exception>
        /// <exception cref="System.ArgumentException">Excepción que se produce cuando no es válido uno de los argumentos proporcionados para un método.</exception>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de un programa.</exception>
        public static string Descifrar(string cadena)
        {
            byte[] llave = null;
            byte[] arreglo = null; // Arreglo donde guardaremos la cadena descovertida.
            byte[] resultado = null;
            string cadena_descifrada = null;
            // Ciframos utilizando el Algoritmo MD5.
            MD5CryptoServiceProvider md5;
            try
            {
                md5 = new MD5CryptoServiceProvider();
                arreglo = Convert.FromBase64String(cadena);
                llave = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(clave));
                md5.Clear();

                //Ciframos utilizando el Algoritmo 3DES.
                TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider();
                tripledes.Key = llave;
                tripledes.Mode = CipherMode.ECB;
                tripledes.Padding = PaddingMode.PKCS7;
                ICryptoTransform convertir = tripledes.CreateDecryptor();
                resultado = convertir.TransformFinalBlock(arreglo, 0, arreglo.Length);
                tripledes.Clear();
                cadena_descifrada = UTF8Encoding.UTF8.GetString(resultado); // Obtenemos la cadena
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (EncoderFallbackException ex)
            {
                throw ex;
            }
            catch (DecoderFallbackException ex)
            {
                throw ex;
            }
            catch (CryptographicException ex)
            {
                throw ex;
            }
            catch (ObjectDisposedException ex)
            {
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cadena_descifrada; // Devolvemos la cadena
        }
        #endregion

        #region Criptografía Leo
        //Función para agregar la encriptacion SHA1 a la contraseña
        private static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm;
            try
            {
                algorithm = SHA1.Create();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }
        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                foreach (byte b in GetHash(inputString))
                    sb.Append(b.ToString("X2"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sb.ToString();
        }

        #endregion

        #region Variables
        public static bool versionGratuita = false;
        public static bool soloRegistro;
        public static string rutaBase;
        public static string tema;
        public static string temaCumple;
        public static Color fondo;
        public static Color letras;
        public static Color fondoCumple;
        public static Color letrasCumple;
        public static Bitmap img;
        public static Bitmap promo01;
        public static Bitmap promo02;
        public static Bitmap promo03;
        public static Bitmap promo04;
        public static Bitmap promo05;
        public static Bitmap promo06;
        public static bool usarHuella;
        public static bool usarSonidos;
        public static string sonidoRegBien;
        public static string sonidoRegMal;

        const int SWP_NOSIZE = 0x1;
        const int SWP_NOMOVE = 0x2;
        const int SWP_NOACTIVATE = 0x10;
        const int wFlags = SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE;
        const int HWND_TOPMOST = -1;
        const int HWND_NOTOPMOST = -2;

        #endregion

        /// <summary>
        /// Función que valida que un TextBox solo sea númerico
        /// </summary>
        /// <param name="sender">TextBox al que se le desea hacer la validación</param>
        /// <param name="e">Variable de evento</param>
        /// <param name="soloEnteros">Valor booleano que indica si solo pueden entrar números enteros al campo</param>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de un programa.</exception>
        public static void VerificarEsNumero(ref object sender, ref KeyPressEventArgs e, bool soloEnteros)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                if (soloEnteros && e.KeyChar == '.')
                {
                    e.Handled = true;
                }
                if (txt.Text == "" && e.KeyChar == '.' && !soloEnteros)
                {
                    txt.Text = "0" + e.KeyChar;
                    txt.SelectionStart = txt.Text.Length;
                }
                if (txt.Text.Contains(".") && e.KeyChar == '.' && !soloEnteros)
                {
                    e.Handled = true;
                    return;
                }
                else if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función que recibe una cadena de parametro y verifica que sea un correo electrónico valido.
        /// </summary>
        /// <param name="correo">Cadena de la cual se desea verificar sea un correo valido</param>
        /// <exception cref="System.Text.RegularExpressions.RegexMatchTimeoutException">Excepción que se produce cuando el tiempo de ejecución de un método de coincidencia de expresión regular supera su intervalo de tiempo de espera.</exception>
        /// <exception cref="System.ArgumentNullException">Excepción que se produce cuando se pasa una referencia nula a un método que no la acepta como argumento válido.</exception>
        /// <exception cref="System.ArgumentException">Excepción que se produce cuando no es válido uno de los argumentos proporcionados para un método.</exception>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de un programa.</exception>
        /// <returns>Valor booleano que indica si es un correo valido</returns>
        public static bool EsCorreoValido(string correo)
        {
            bool valido = false;
            try
            {
                Regex reg = new Regex("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@" +
                                        "(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
                Match m = reg.Match(correo);
                valido = m.Success;
            }
            catch (RegexMatchTimeoutException ex)
            {
                throw ex;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return valido;
        }

        //Funcion que no ocupe, pero por si las dudas
        ///// <summary>
        ///// Función que verifica que el valor de una cadena sea númerico
        ///// </summary>
        ///// <param name="valor">Cadena de la cual se comprobará el valor</param>
        ///// <returns>Valor booleano que indica si la cadena es o no un número</returns>
        //public static bool EsNumero(string valor)
        //{
        //    //Y pus a declarar variables a lo loco porque así lo requiere la función ¬¬
        //    int num;
        //    decimal num2;
        //    float num3;
        //    long num4;
        //    double num5;
        //    bool esNum = false;
        //    if (int.TryParse(valor, out num))
        //        esNum = true;
        //    else if (decimal.TryParse(valor, out num2))
        //        esNum = true;
        //    else if (float.TryParse(valor, out num3))
        //        esNum = true;
        //    else if (long.TryParse(valor, out num4))
        //        esNum = true;
        //    else if (double.TryParse(valor, out num5))
        //        esNum = true;
        //    return esNum;
        //}

        /// <summary>
        /// Redimensiona una imagen al tamaño definido
        /// </summary>
        /// <param name="imagen">Imagen a redimensionar</param>
        /// <param name="nuevoTamanio">Nuevo tamaño de la imagen.</param>
        /// <exception cref="System.ArgumentNullException">Excepción que se produce cuando se pasa una referencia nula a un método que no la acepta como argumento válido.</exception>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de un programa.</exception>
        /// <returns>Imagen redimensionada.</returns>
        public static System.Drawing.Image RedimensionarLogo(System.Drawing.Image imagen, System.Drawing.Size nuevoTamanio)
        {
            System.Drawing.Image nuevaImagen = null;
            try
            {
                nuevaImagen = new System.Drawing.Bitmap(nuevoTamanio.Width, nuevoTamanio.Height);
                using (System.Drawing.Graphics GFX = System.Drawing.Graphics.FromImage((System.Drawing.Bitmap)nuevaImagen))
                {
                    GFX.DrawImage(imagen, new System.Drawing.Rectangle(System.Drawing.Point.Empty, nuevoTamanio));
                }
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return nuevaImagen;
        }

        /// <summary>
        /// Función que verifica que una cadena contiene un valor RGB
        /// </summary>
        /// <param name="valor">Valor a verificar</param>
        /// <exception cref="System.Text.RegularExpressions.RegexMatchTimeoutException">Excepción que se produce cuando el tiempo de ejecución de un método de coincidencia de expresión regular supera su intervalo de tiempo de espera.</exception>
        /// <exception cref="System.ArgumentNullException">Excepción que se produce cuando se pasa una referencia nula a un método que no la acepta como argumento válido.</exception>
        /// <exception cref="System.ArgumentException">Excepción que se produce cuando no es válido uno de los argumentos proporcionados para un método.</exception>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de un programa.</exception>
        /// <returns>Valor que indica si el valor se puede identificar como RGB</returns>
        public static bool EsRGB(string valor)
        {
            bool es = false;
            try
            {
                Regex reg = new Regex("^(\\d{1,2}|[1][0-9][0-9]|[2][0-5][0-5]), ?(\\d{1,2}|[1][0-9][0-9]|[2][0-5][0-5]), ?(\\d{1,2}|[1][0-9][0-9]|[2][0-5][0-5])$");
                Match m = reg.Match(valor);
                es = m.Success;
            }
            catch (RegexMatchTimeoutException ex)
            {
                throw ex;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return es;
        }

        /// <summary>
        /// Función que carga la interfaz de la ventana de acuerdo al tema seleccionado
        /// </summary>
        /// <param name="frm">Formulario al que se le aplicará la interfaz</param>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de un programa.</exception>
        public static void CargarInterfaz(IWin32Window frm)
        {
            try
            {
                dynamic f = frm;
                f.BackColor = fondo;
                foreach (Control ctr in f.Controls)
                {
                    if (ctr is Panel || ctr is GroupBox)
                    {
                        ctr.ForeColor = letras;
                        ctr.BackColor = fondo;
                        foreach (Control ct in ctr.Controls)
                        {
                            if (ct is Label || ctr is CheckBox)
                            {
                                ct.ForeColor = letras;
                                ct.BackColor = Color.Transparent;
                            }
                            if (ct is Button)
                                ct.ForeColor = SystemColors.ControlText;
                        }
                    }
                    else if (ctr is Label || ctr is CheckBox)
                    {
                        ctr.ForeColor = letras;
                        ctr.BackColor = Color.Transparent;
                    }
                    else if (ctr is TabControl)
                    {
                        ctr.ForeColor = letras;
                        ctr.BackColor = fondo;
                        foreach (Control ct in ctr.Controls)
                        {
                            if (!(ct is Button))
                            {
                                ct.ForeColor = letras;
                                ct.BackColor = fondo;
                            }
                            else if (ct is TabPage)
                            {
                                foreach (Control c in ct.Controls)
                                {
                                    if (!(c is Button))
                                    {
                                        c.ForeColor = letras;
                                        c.BackColor = fondo;
                                    }
                                    else
                                    {
                                        c.ForeColor = SystemColors.ControlText;
                                    }
                                }
                            }
                            else
                            {
                                ct.ForeColor = SystemColors.ControlText;
                            }
                        }
                    }
                    else if (ctr is Button)
                    {
                        ctr.ForeColor = SystemColors.ControlText;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función que compara que dos imagenes sean iguales
        /// </summary>
        /// <param name="img01">Primer imagen a comparar</param>
        /// <param name="img02">Segunda imagen a comparar</param>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de un programa.</exception>
        /// <returns>Valor booleano que indica si las dos imagenes son iguales</returns>
        public static bool CompararImagenes(Bitmap img01, Bitmap img02)
        {
            bool sonIguales = true;
            try
            {
                string pxl01;
                string pxl02;
                if (img01 != null && img02 != null)
                {
                    if (img01.Width == img02.Width && img01.Height == img02.Height)
                    {
                        for (int i = 0; i < img01.Width; i++)
                        {
                            for (int j = 0; j < img01.Height; j++)
                            {
                                pxl01 = img01.GetPixel(i, j).ToString();
                                pxl02 = img02.GetPixel(i, j).ToString();
                                if (pxl01 != pxl02)
                                {
                                    sonIguales = false;
                                    break;
                                }
                            }
                            if (sonIguales == false)
                                break;
                        }
                    }
                    else
                        sonIguales = false;
                }
                else
                    sonIguales = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sonIguales;
        }

        private static List<string> ActiveForms = new List<string>();
        public static bool AperturaUnicaFormulario(string formName)
        {
            if (ActiveForms.Contains(formName))
            {
                //ActiveForms.Add(formName);
                return true;
            }
            else
            {
                ActiveForms.Add(formName);
                return false;
            }
        }

        public static void EliminarFormularioLista(string formName)
        {
            try
            {
                ActiveForms.Remove(formName);
            }
            catch
            {
            }
        }

        public static bool RangoFecha(DateTime fechaInicio, DateTime fechaFinal, DateTime fechaComparar)
        {
            if (fechaInicio >= fechaComparar && fechaComparar <= fechaFinal)
                return true;
            return false;
        }

        /// <summary>
        /// Función que guarda una imagen en la carpeta de photo de la aplicación
        /// </summary>
        /// <param name="img">Imagen a guardar</param>
        /// <param name="nomImg">Nombre de la imagen</param>
        /// <exception cref="System.Runtime.InteropServices.ExternalException">El tipo de excepción base para todas las excepciones de interoperabilidad COM y excepciones de control de excepciones estructurado (SEH).</exception>
        /// <exception cref="System.ArgumentNullException">Excepción que se produce cuando se pasa una referencia nula a un método que no la acepta como argumento válido.</exception>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de un programa.</exception>
        public static void GuardarImagen(Image img, string nomImg)
        {
            if (img == null) return;
            try
            {
                string ruta = Application.StartupPath + "\\photo\\" + nomImg + ".jpg";
                if (!File.Exists(ruta))
                {
                    Bitmap btm = new Bitmap(img);
                    btm.Save(ruta, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else
                {
                    File.Delete(ruta);
                    GuardarImagen(img, nomImg);
                }

            }
            catch (System.Runtime.InteropServices.ExternalException ex)
            {
                throw ex;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función que convierte una imagen a un arreglo de bytes
        /// </summary>
        /// <param name="img">Imagen en formato .jpeg que se convertirá a bytes</param>
        /// <exception cref="System.Runtime.InteropServices.ExternalException">El tipo de excepción base para todas las excepciones de interoperabilidad COM y excepciones de control de excepciones estructurado (SEH).</exception>
        /// <exception cref="System.ArgumentNullException">Excepción que se produce cuando se pasa una referencia nula a un método que no la acepta como argumento válido.</exception>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de un programa.</exception>
        /// <returns>Arreglo de bytes que contienen la imagen</returns>
        public static byte[] ImagenBytes(Image img)
        {
            byte[] bimg = null;
            try
            {
                if (img.Width > 1280 && img.Height > 800)
                    img = RedimensionarImagen(img, (img.Width / 50), (img.Height / 50));
                MemoryStream m = new MemoryStream();
                img.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg);
                bimg = m.ToArray();
            }
            catch (System.Runtime.InteropServices.ExternalException ex)
            {
                throw ex;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return bimg;
        }

        /// <summary>
        /// Función que convierte un arreglo de bytes a imagen
        /// </summary>
        /// <param name="bimg">Arreglo de bytes que se convertirán en una imagen</param>
        /// <exception cref="System.IO.IOException">Excepción que es lanzada cuando se produce un error de E/S.</exception>
        /// <exception cref="System.ObjectDisposedException">Excepción que se produce cuando se realiza una operación en un objeto desechado.</exception>
        /// <exception cref="System.NotSupportedException">Excepción que se produce cuando no se admite un método invocado o cuando se intenta leer, buscar o escribir en una secuencia que no admite la funcionalidad invocada.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Excepción que se produce cuando el valor de un argumento se encuentra fuera del intervalo de valores permitido definido por el método invocado.</exception>
        /// <exception cref="System.ArgumentNullException">Excepción que se produce cuando se pasa una referencia nula a un método que no la acepta como argumento válido.</exception>
        /// <exception cref="System.ArgumentException">Excepción que se produce cuando no es válido uno de los argumentos proporcionados para un método.</exception>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de un programa.</exception>
        /// <returns>Imagen en formato .jpeg</returns>
        public static Image BytesImagen(byte[] bimg)
        {
            Image img = null;
            try
            {
                MemoryStream m = new MemoryStream(bimg);
                m.Write(bimg, 0, bimg.Length);
                img = Image.FromStream(m, true);
            }
            catch (System.IO.IOException ex)
            {
                throw ex;
            }
            catch (ObjectDisposedException ex)
            {
                throw ex;
            }
            catch (NotSupportedException ex)
            {
                throw ex;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw ex;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
                //MessageBox.Show(ex.Message, "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return img;
        }

        /// <summary>
        /// Función que redimensiona una imagen a una resolución dada sin recorte
        /// </summary>
        /// <param name="imgPhoto">Imagen a redimensionar</param>
        /// <param name="Width">Ancho al que se desea redimensionar</param>
        /// <param name="Height">Alto al que se desea redimensionar</param>
        /// <returns>Imagen redimensionada</returns>
        public static Image RedimensionarImagen(Image imgPhoto, int Width, int Height)
        {
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)Width / (float)sourceWidth);
            nPercentH = ((float)Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((Width -
                              (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((Height -
                              (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(Width, Height,
                              PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                             imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.Red);
            grPhoto.InterpolationMode =
                    InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }

        /// <summary>
        /// Función que muestra un MessageBox con un mensaje de error y el mensaje de la excepción.
        /// </summary>
        /// <param name="mensaje">Mensaje a mostrar</param>
        /// <param name="ex">Excepción que ocurrió</param>
        public static void MensajeError(string mensaje, Exception ex)
        {
            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\log.txt", true);
            sw.WriteLine(ex.ToString() + "|");
            sw.Close();
            sw.Dispose();
            MessageBox.Show(mensaje + "\nMensaje de error: " + ex.Message, "Error GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Función que muestra el formulario de espera.
        /// </summary>
        /// <param name="mensaje">Mensaje que se mostrará en el formulario</param>
        /// <param name="f">Formulario dueño del formulario de búsqueda</param>
        public static void frmEspera(string mensaje, IWin32Window f)
        {
            frm = new frmEspera(mensaje);
            frm.ShowDialog(f);
        }

        /// <summary>
        /// Función que cierra el formulario de búsqueda.
        /// </summary>
        public static void frmEsperaClose()
        {
            if (frm != null)
                if (!frm.IsDisposed)
                    if (frm.Visible)
                        frm.Close();
            frm = null;
        }

        static bool loCerroReg = false, loCerroCon = false;
        /// <summary>
        /// Función que cierra determinados formularios para que se pueda usar el API de huella digital.
        /// </summary>
        public static void CerrarHuellas()
        {
            Form fRegistro = null, fConfiguracion = null;

            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == "frmRegistroEntradas")
                    fRegistro = frm;
                else if (frm.Name == "frmConfiguracionHuella")
                    fConfiguracion = frm;
            }
            if (fRegistro != null)
            {
                loCerroReg = true;
                fRegistro.Close();
            }
            if (fConfiguracion != null)
            {
                loCerroCon = true;
                fConfiguracion.Close();
            }
        }

        /// <summary>
        /// Función que abre los formularios cerrados por la función de CerrarHuellas()
        /// </summary>
        public static void AbrirHuellas()
        {
            if (loCerroReg)
                frmRegistroEntradas.Instancia.Show();
            else if (loCerroCon)
                frmConfigurarHuella.Instancia.Show();
            loCerroReg = false;
            loCerroCon = false;
        }

        #region Siempre Encima
        [DllImport("user32.DLL")]
        private extern static void SetWindowPos(
            int hWnd, int hWndInsertAfter,
            int X, int Y,
            int cx, int cy,
            int wFlags);

        /// <summary>
        /// Función que muestra una ventana encima de las otras.
        /// </summary>
        /// <param name="handle">Código de identificación de la ventana</param>
        public static void SiempreEncima(int handle)
        {
            SetWindowPos(handle, HWND_TOPMOST, 0, 0, 0, 0, wFlags);
        }

        /// <summary>
        /// Función que muestra una en un modo normal de visualización en el orden Z.
        /// </summary>
        /// <param name="handle">Código de identificación de la ventana</param>
        public static void NoSiempreEncima(int handle)
        {
            SetWindowPos(handle, HWND_NOTOPMOST, 0, 0, 0, 0, wFlags);
        }
        #endregion

        #region Numeros
        /// <summary>
        /// Función que convierte un número a su representación númerica
        /// </summary>
        /// <param name="num">Número a convertir</param>
        /// <exception cref="System.FormatException">Excepción que se produce cuando el formato de un argumento no cumple las especificaciones de los parámetros del método invocado.</exception>
        /// <exception cref="System.OverflowException">Excepción que se produce cuando una operación aritmética, de conversión de tipo o de conversión de otra naturaleza en un contexto comprobado, da como resultado una sobrecarga.</exception>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de un programa.</exception>
        /// <returns>Representación en texto del número</returns>
        public static string ConvertirNumeroLetra(string num)
        {
            string res = "", dec = "";
            Int64 entero;
            int decimales;
            double nro;

            try
            {
                nro = Convert.ToDouble(num);
                entero = Convert.ToInt64(Math.Truncate(nro));
                decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));
                if (decimales > 0)
                {
                    dec = " CON " + decimales.ToString() + "/100";
                }
                res = ConvertirATexto(Convert.ToDouble(entero)) + " PESOS " + dec + " M.N.";
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (OverflowException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return res;
        }

        private static string ConvertirATexto(double value)
        {
            string Num2Text = "";
            value = Math.Truncate(value);
            if (value == 0) Num2Text = "CERO";
            else if (value == 1) Num2Text = "UNO";
            else if (value == 2) Num2Text = "DOS";
            else if (value == 3) Num2Text = "TRES";
            else if (value == 4) Num2Text = "CUATRO";
            else if (value == 5) Num2Text = "CINCO";
            else if (value == 6) Num2Text = "SEIS";
            else if (value == 7) Num2Text = "SIETE";
            else if (value == 8) Num2Text = "OCHO";
            else if (value == 9) Num2Text = "NUEVE";
            else if (value == 10) Num2Text = "DIEZ";
            else if (value == 11) Num2Text = "ONCE";
            else if (value == 12) Num2Text = "DOCE";
            else if (value == 13) Num2Text = "TRECE";
            else if (value == 14) Num2Text = "CATORCE";
            else if (value == 15) Num2Text = "QUINCE";
            else if (value < 20) Num2Text = "DIECI" + ConvertirATexto(value - 10);
            else if (value == 20) Num2Text = "VEINTE";
            else if (value < 30) Num2Text = "VEINTI" + ConvertirATexto(value - 20);
            else if (value == 30) Num2Text = "TREINTA";
            else if (value == 40) Num2Text = "CUARENTA";
            else if (value == 50) Num2Text = "CINCUENTA";
            else if (value == 60) Num2Text = "SESENTA";
            else if (value == 70) Num2Text = "SETENTA";
            else if (value == 80) Num2Text = "OCHENTA";
            else if (value == 90) Num2Text = "NOVENTA";
            else if (value < 100) Num2Text = ConvertirATexto(Math.Truncate(value / 10) * 10) + " Y " + ConvertirATexto(value % 10);
            else if (value == 100) Num2Text = "CIEN";
            else if (value < 200) Num2Text = "CIENTO " + ConvertirATexto(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = ConvertirATexto(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) Num2Text = "QUINIENTOS";
            else if (value == 700) Num2Text = "SETECIENTOS";
            else if (value == 900) Num2Text = "NOVECIENTOS";
            else if (value < 1000) Num2Text = ConvertirATexto(Math.Truncate(value / 100) * 100) + " " + ConvertirATexto(value % 100);
            else if (value == 1000) Num2Text = "MIL";
            else if (value < 2000) Num2Text = "MIL " + ConvertirATexto(value % 1000);
            else if (value < 1000000)
            {
                Num2Text = ConvertirATexto(Math.Truncate(value / 1000)) + " MIL";
                if ((value % 1000) > 0) Num2Text = Num2Text + " " + ConvertirATexto(value % 1000);
            }

            else if (value == 1000000) Num2Text = "UN MILLON";
            else if (value < 2000000) Num2Text = "UN MILLON " + ConvertirATexto(value % 1000000);
            else if (value < 1000000000000)
            {
                Num2Text = ConvertirATexto(Math.Truncate(value / 1000000)) + " MILLONES ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + ConvertirATexto(value - Math.Truncate(value / 1000000) * 1000000);
            }

            else if (value == 1000000000000) Num2Text = "UN BILLON";
            else if (value < 2000000000000) Num2Text = "UN BILLON " + ConvertirATexto(value - Math.Truncate(value / 1000000000000) * 1000000000000);

            else
            {
                Num2Text = ConvertirATexto(Math.Truncate(value / 1000000000000)) + " BILLONES";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + ConvertirATexto(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            }
            return Num2Text;

        }
        #endregion
    }
}
