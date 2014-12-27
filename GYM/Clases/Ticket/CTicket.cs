using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.Clases
{
    public partial class CTicket
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase CTicket
        /// </summary>
        /// <exception cref="System.ArgumentException"></exception>
        public CTicket()
        {
            try
            {
                pd = new PrintDocument();
                ppd = new PrintPreviewDialog();
                dtVenta = new DataTable();
                dtVentaDetallada = new DataTable();
                ObtenerDatosConfiguracion();
                if (tamPapel == 300)
                {
                    fuentePequeña = new Font("Segoe UI", 8, FontStyle.Regular);
                    fuenteNormal = new Font("Segoe UI", 10, FontStyle.Regular);
                    fuenteResaltada = new Font("Segoe UI", 10, FontStyle.Bold);
                    fuenteGrande = new Font("Segoe UI", 12, FontStyle.Regular);
                    fuenteGrandeResaltada = new Font("Segoe UI", 14, FontStyle.Bold);
                }
                else
                {
                    fuentePequeña = new Font("Segoe UI", 6, FontStyle.Regular);
                    fuenteNormal = new Font("Segoe UI", 7, FontStyle.Regular);
                    fuenteResaltada = new Font("Segoe UI", 7, FontStyle.Bold);
                    fuenteGrande = new Font("Segoe UI", 9, FontStyle.Regular);
                    fuenteGrandeResaltada = new Font("Segoe UI", 11, FontStyle.Bold);
                }
                y = 0;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Imprime un nuevo ticket de venta
        /// </summary>
        /// <param name="folio">Folio de venta</param>
        /// <exception cref="System.Drawing.Printing.InvalidPrinterException"></exception>
        /// <exception cref="System.FormatException">Excepción que se produce cuando el formato de un argumento no cumple las especificaciones de los parámetros del método invocado.</exception>
        /// <exception cref="Systen.OverflowException">Excepción que se produce cuando una operación aritmética, de conversión de tipo o de conversión de otra naturaleza en un contexto comprobado, da como resultado una sobrecarga.</exception>
        /// <exception cref="System.Xml.XmlException">Devuelve información detallada sobre la última excepción.</exception>
        /// <exception cref="System.IO.PathTooLongException">Excepción que se produce cuando una ruta de acceso o un nombre de archivo supera la longitud máxima definida por el sistema.</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">Excepción que se produce cuando no encuentra parte de un archivo o directorio.</exception>
        /// <exception cref="System.IO.FileNotFoundException">Excepción que se produce cuando se produce un error al intentar tener acceso a un archivo que no existe en el disco.</exception>
        /// <exception cref="System.IO.IOException">Excepción que es lanzada cuando se produce un error de E/S.</exception>
        /// <exception cref="System.NotSupportedException">Excepción que se produce cuando no se admite un método invocado o cuando se intenta leer, buscar o escribir en una secuencia que no admite la funcionalidad invocada.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Excepción que se produce cuando el sistema operativo deniega el acceso a causa de un error de E/S o de un error de seguridad de un tipo concreto.</exception>
        /// <exception cref="System.Security.SecurityException">La excepción que se produce cuando se detecta un error de seguridad.</exception>
        /// <exception cref="System.ArgumentNullException">Excepción que se produce cuando se pasa una referencia nula a un método que no la acepta como argumento válido.</exception>
        /// <exception cref="System.ArgumentException">Excepción que se produce cuando no es válido uno de los argumentos proporcionados para un método.</exception>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de una aplicación.</exception>
        public void ImprimirTicketVenta(int folio)
        {
            try
            {
                this.folio = folio;
                ObtenerDatosVenta();
                ObtenerDatosVentaDetallada();
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPageTicketVenta);
                pd.DocumentName = "Ticket";
                pd.DefaultPageSettings.PaperSize = new PaperSize("Ticket", tamPapel, 10000);
                pd.PrinterSettings.PrinterName = impresora;
                //ppd.Document = pd;
                //ppd.ShowDialog();
                pd.Print();
            }
            catch (InvalidPrinterException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (OverflowException ex)
            {
                throw ex;
            }
            catch (System.Xml.XmlException ex)
            {
                throw ex;
            }
            catch (System.IO.PathTooLongException ex)
            {
                throw ex;
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                throw ex;
            }
            catch (System.IO.FileNotFoundException ex)
            {
                throw ex;
            }
            catch (System.IO.IOException ex)
            {
                throw ex;
            }
            catch (NotSupportedException ex)
            {
                throw ex;
            }
            catch (UnauthorizedAccessException ex)
            {
                throw ex;
            }
            catch (System.Security.SecurityException ex)
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
        }

        /// <summary>
        /// Imprime el ticket de nueva o de renovación de membresía
        /// </summary>
        /// <param name="numSoc">Número de socio del que se creo o renovo la membresía</param>
        /// <exception cref="System.FormatException">Excepción que se produce cuando el formato de un argumento no cumple las especificaciones de los parámetros del método invocado.</exception>
        /// <exception cref="Systen.OverflowException">Excepción que se produce cuando una operación aritmética, de conversión de tipo o de conversión de otra naturaleza en un contexto comprobado, da como resultado una sobrecarga.</exception>
        /// <exception cref="System.Xml.XmlException">Devuelve información detallada sobre la última excepción.</exception>
        /// <exception cref="System.IO.PathTooLongException">Excepción que se produce cuando una ruta de acceso o un nombre de archivo supera la longitud máxima definida por el sistema.</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">Excepción que se produce cuando no encuentra parte de un archivo o directorio.</exception>
        /// <exception cref="System.IO.FileNotFoundException">Excepción que se produce cuando se produce un error al intentar tener acceso a un archivo que no existe en el disco.</exception>
        /// <exception cref="System.IO.IOException">Excepción que es lanzada cuando se produce un error de E/S.</exception>
        /// <exception cref="System.NotSupportedException">Excepción que se produce cuando no se admite un método invocado o cuando se intenta leer, buscar o escribir en una secuencia que no admite la funcionalidad invocada.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Excepción que se produce cuando el sistema operativo deniega el acceso a causa de un error de E/S o de un error de seguridad de un tipo concreto.</exception>
        /// <exception cref="System.Security.SecurityException">La excepción que se produce cuando se detecta un error de seguridad.</exception>
        /// <exception cref="System.ArgumentNullException">Excepción que se produce cuando se pasa una referencia nula a un método que no la acepta como argumento válido.</exception>
        /// <exception cref="System.ArgumentException">Excepción que se produce cuando no es válido uno de los argumentos proporcionados para un método.</exception>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de una aplicación.</exception>
        public void ImprimirTicketMembresia(int numSoc)
        {
            try
            {
                this.numSoc = numSoc;
                dtMembresia = new DataTable();
                ObtenerDatosMembresia();
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPageTicketMembresia);
                pd.DocumentName = "Ticket";
                pd.DefaultPageSettings.PaperSize = new PaperSize("Ticket", tamPapel, 10000);
                pd.PrinterSettings.PrinterName = impresora;
                //ppd.Document = pd;
                //ppd.ShowDialog();
                pd.Print();
            }
            catch (InvalidPrinterException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (OverflowException ex)
            {
                throw ex;
            }
            catch (System.Xml.XmlException ex)
            {
                throw ex;
            }
            catch (System.IO.PathTooLongException ex)
            {
                throw ex;
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                throw ex;
            }
            catch (System.IO.FileNotFoundException ex)
            {
                throw ex;
            }
            catch (System.IO.IOException ex)
            {
                throw ex;
            }
            catch (NotSupportedException ex)
            {
                throw ex;
            }
            catch (UnauthorizedAccessException ex)
            {
                throw ex;
            }
            catch (System.Security.SecurityException ex)
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
        }

        /// <summary>
        /// Imprime el ticket de nueva o de renovación de locker
        /// </summary>
        /// <param name="numSoc">Número de socio del que se creo o renovo el locker</param>
        /// <exception cref="System.FormatException">Excepción que se produce cuando el formato de un argumento no cumple las especificaciones de los parámetros del método invocado.</exception>
        /// <exception cref="Systen.OverflowException">Excepción que se produce cuando una operación aritmética, de conversión de tipo o de conversión de otra naturaleza en un contexto comprobado, da como resultado una sobrecarga.</exception>
        /// <exception cref="System.Xml.XmlException">Devuelve información detallada sobre la última excepción.</exception>
        /// <exception cref="System.IO.PathTooLongException">Excepción que se produce cuando una ruta de acceso o un nombre de archivo supera la longitud máxima definida por el sistema.</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">Excepción que se produce cuando no encuentra parte de un archivo o directorio.</exception>
        /// <exception cref="System.IO.FileNotFoundException">Excepción que se produce cuando se produce un error al intentar tener acceso a un archivo que no existe en el disco.</exception>
        /// <exception cref="System.IO.IOException">Excepción que es lanzada cuando se produce un error de E/S.</exception>
        /// <exception cref="System.NotSupportedException">Excepción que se produce cuando no se admite un método invocado o cuando se intenta leer, buscar o escribir en una secuencia que no admite la funcionalidad invocada.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Excepción que se produce cuando el sistema operativo deniega el acceso a causa de un error de E/S o de un error de seguridad de un tipo concreto.</exception>
        /// <exception cref="System.Security.SecurityException">La excepción que se produce cuando se detecta un error de seguridad.</exception>
        /// <exception cref="System.ArgumentNullException">Excepción que se produce cuando se pasa una referencia nula a un método que no la acepta como argumento válido.</exception>
        /// <exception cref="System.ArgumentException">Excepción que se produce cuando no es válido uno de los argumentos proporcionados para un método.</exception>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de una aplicación.</exception>
        public void ImprimirTicketLocker(int idLocker)
        {
            try
            {
                this.idLocker = idLocker;
                dtLocker = new DataTable();
                ObtenerDatosLocker();
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPageTicketLockers);
                pd.DocumentName = "Ticket";
                pd.DefaultPageSettings.PaperSize = new PaperSize("Ticket", tamPapel, 10000);
                pd.PrinterSettings.PrinterName = impresora;
                //ppd.Document = pd;
                //ppd.ShowDialog();
                pd.Print();
            }
            catch (InvalidPrinterException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (OverflowException ex)
            {
                throw ex;
            }
            catch (System.Xml.XmlException ex)
            {
                throw ex;
            }
            catch (System.IO.PathTooLongException ex)
            {
                throw ex;
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                throw ex;
            }
            catch (System.IO.FileNotFoundException ex)
            {
                throw ex;
            }
            catch (System.IO.IOException ex)
            {
                throw ex;
            }
            catch (NotSupportedException ex)
            {
                throw ex;
            }
            catch (UnauthorizedAccessException ex)
            {
                throw ex;
            }
            catch (System.Security.SecurityException ex)
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
        }

        /// <summary>
        /// Función que imprime el ticket de cierre de caja
        /// </summary>
        /// <exception cref="System.FormatException">Excepción que se produce cuando el formato de un argumento no cumple las especificaciones de los parámetros del método invocado.</exception>
        /// <exception cref="Systen.OverflowException">Excepción que se produce cuando una operación aritmética, de conversión de tipo o de conversión de otra naturaleza en un contexto comprobado, da como resultado una sobrecarga.</exception>
        /// <exception cref="System.Xml.XmlException">Devuelve información detallada sobre la última excepción.</exception>
        /// <exception cref="System.IO.PathTooLongException">Excepción que se produce cuando una ruta de acceso o un nombre de archivo supera la longitud máxima definida por el sistema.</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">Excepción que se produce cuando no encuentra parte de un archivo o directorio.</exception>
        /// <exception cref="System.IO.FileNotFoundException">Excepción que se produce cuando se produce un error al intentar tener acceso a un archivo que no existe en el disco.</exception>
        /// <exception cref="System.IO.IOException">Excepción que es lanzada cuando se produce un error de E/S.</exception>
        /// <exception cref="System.NotSupportedException">Excepción que se produce cuando no se admite un método invocado o cuando se intenta leer, buscar o escribir en una secuencia que no admite la funcionalidad invocada.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Excepción que se produce cuando el sistema operativo deniega el acceso a causa de un error de E/S o de un error de seguridad de un tipo concreto.</exception>
        /// <exception cref="System.Security.SecurityException">La excepción que se produce cuando se detecta un error de seguridad.</exception>
        /// <exception cref="System.ArgumentNullException">Excepción que se produce cuando se pasa una referencia nula a un método que no la acepta como argumento válido.</exception>
        /// <exception cref="System.ArgumentException">Excepción que se produce cuando no es válido uno de los argumentos proporcionados para un método.</exception>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de una aplicación.</exception>
        public void ImprimirCaja(bool esCierreCaja)
        {
            try
            {
                dtCaja = new DataTable();
                this.esCierreCaja = esCierreCaja;
                ObtenerDatosCaja();
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPageTicketCaja);
                pd.DocumentName = "Ticket";
                pd.DefaultPageSettings.PaperSize = new PaperSize("Ticket", tamPapel, 10000);
                pd.PrinterSettings.PrinterName = impresora;
                //ppd.Document = pd;
                //ppd.ShowDialog();
                pd.Print();
            }
            catch (InvalidPrinterException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (OverflowException ex)
            {
                throw ex;
            }
            catch (System.Xml.XmlException ex)
            {
                throw ex;
            }
            catch (System.IO.PathTooLongException ex)
            {
                throw ex;
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                throw ex;
            }
            catch (System.IO.FileNotFoundException ex)
            {
                throw ex;
            }
            catch (System.IO.IOException ex)
            {
                throw ex;
            }
            catch (NotSupportedException ex)
            {
                throw ex;
            }
            catch (UnauthorizedAccessException ex)
            {
                throw ex;
            }
            catch (System.Security.SecurityException ex)
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
        }

        /// <summary>
        /// Función que imprime el ticket de cierre de caja hecho en un punto en el pasado
        /// </summary>
        /// <exception cref="System.FormatException">Excepción que se produce cuando el formato de un argumento no cumple las especificaciones de los parámetros del método invocado.</exception>
        /// <exception cref="Systen.OverflowException">Excepción que se produce cuando una operación aritmética, de conversión de tipo o de conversión de otra naturaleza en un contexto comprobado, da como resultado una sobrecarga.</exception>
        /// <exception cref="System.Xml.XmlException">Devuelve información detallada sobre la última excepción.</exception>
        /// <exception cref="System.IO.PathTooLongException">Excepción que se produce cuando una ruta de acceso o un nombre de archivo supera la longitud máxima definida por el sistema.</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">Excepción que se produce cuando no encuentra parte de un archivo o directorio.</exception>
        /// <exception cref="System.IO.FileNotFoundException">Excepción que se produce cuando se produce un error al intentar tener acceso a un archivo que no existe en el disco.</exception>
        /// <exception cref="System.IO.IOException">Excepción que es lanzada cuando se produce un error de E/S.</exception>
        /// <exception cref="System.NotSupportedException">Excepción que se produce cuando no se admite un método invocado o cuando se intenta leer, buscar o escribir en una secuencia que no admite la funcionalidad invocada.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Excepción que se produce cuando el sistema operativo deniega el acceso a causa de un error de E/S o de un error de seguridad de un tipo concreto.</exception>
        /// <exception cref="System.Security.SecurityException">La excepción que se produce cuando se detecta un error de seguridad.</exception>
        /// <exception cref="System.ArgumentNullException">Excepción que se produce cuando se pasa una referencia nula a un método que no la acepta como argumento válido.</exception>
        /// <exception cref="System.ArgumentException">Excepción que se produce cuando no es válido uno de los argumentos proporcionados para un método.</exception>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de una aplicación.</exception>
        public void ImprimirCorteCaja(int idApertura, int idCierre)
        {
            try
            {
                this.idApertura = idApertura;
                this.idCierre = idCierre;
                dtCaja = new DataTable();
                ObtenerDatosCorteCaja();
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPageTicketCaja);
                pd.DocumentName = "Ticket";
                pd.DefaultPageSettings.PaperSize = new PaperSize("Ticket", tamPapel, 10000);
                pd.PrinterSettings.PrinterName = impresora;
                //ppd.Document = pd;
                //ppd.ShowDialog();
                pd.Print();
            }
            catch (InvalidPrinterException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (OverflowException ex)
            {
                throw ex;
            }
            catch (System.Xml.XmlException ex)
            {
                throw ex;
            }
            catch (System.IO.PathTooLongException ex)
            {
                throw ex;
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                throw ex;
            }
            catch (System.IO.FileNotFoundException ex)
            {
                throw ex;
            }
            catch (System.IO.IOException ex)
            {
                throw ex;
            }
            catch (NotSupportedException ex)
            {
                throw ex;
            }
            catch (UnauthorizedAccessException ex)
            {
                throw ex;
            }
            catch (System.Security.SecurityException ex)
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
        }

        /// <summary>
        /// Función que imprime únicamente el código de producto
        /// </summary>
        /// <param name="idProd"></param>
        /// <exception cref="System.FormatException">Excepción que se produce cuando el formato de un argumento no cumple las especificaciones de los parámetros del método invocado.</exception>
        /// <exception cref="Systen.OverflowException">Excepción que se produce cuando una operación aritmética, de conversión de tipo o de conversión de otra naturaleza en un contexto comprobado, da como resultado una sobrecarga.</exception>
        /// <exception cref="System.Xml.XmlException">Devuelve información detallada sobre la última excepción.</exception>
        /// <exception cref="System.IO.PathTooLongException">Excepción que se produce cuando una ruta de acceso o un nombre de archivo supera la longitud máxima definida por el sistema.</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">Excepción que se produce cuando no encuentra parte de un archivo o directorio.</exception>
        /// <exception cref="System.IO.FileNotFoundException">Excepción que se produce cuando se produce un error al intentar tener acceso a un archivo que no existe en el disco.</exception>
        /// <exception cref="System.IO.IOException">Excepción que es lanzada cuando se produce un error de E/S.</exception>
        /// <exception cref="System.NotSupportedException">Excepción que se produce cuando no se admite un método invocado o cuando se intenta leer, buscar o escribir en una secuencia que no admite la funcionalidad invocada.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Excepción que se produce cuando el sistema operativo deniega el acceso a causa de un error de E/S o de un error de seguridad de un tipo concreto.</exception>
        /// <exception cref="System.Security.SecurityException">La excepción que se produce cuando se detecta un error de seguridad.</exception>
        /// <exception cref="System.ArgumentNullException">Excepción que se produce cuando se pasa una referencia nula a un método que no la acepta como argumento válido.</exception>
        /// <exception cref="System.ArgumentException">Excepción que se produce cuando no es válido uno de los argumentos proporcionados para un método.</exception>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de una aplicación.</exception>
        public void ImprimirCodigoProducto(string idProd)
        {
            try
            {
                this.idProd = idProd;
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPageTicketCodigo);
                pd.DocumentName = "Ticket";
                pd.DefaultPageSettings.PaperSize = new PaperSize("Ticket", tamPapel, 500);
                pd.PrinterSettings.PrinterName = impresora;
                //ppd.Document = pd;
                //ppd.ShowDialog();
                pd.Print();
            }
            catch (InvalidPrinterException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (OverflowException ex)
            {
                throw ex;
            }
            catch (System.Xml.XmlException ex)
            {
                throw ex;
            }
            catch (System.IO.PathTooLongException ex)
            {
                throw ex;
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                throw ex;
            }
            catch (System.IO.FileNotFoundException ex)
            {
                throw ex;
            }
            catch (System.IO.IOException ex)
            {
                throw ex;
            }
            catch (NotSupportedException ex)
            {
                throw ex;
            }
            catch (UnauthorizedAccessException ex)
            {
                throw ex;
            }
            catch (System.Security.SecurityException ex)
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
        }

        /// <summary>
        /// Evento de impresión de ticket de venta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="MySql.Data.MySqlClient.MySqlException"></exception>
        /// <exception cref="System.FormatException"></exception>
        /// <exception cref="System.OverflowException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.Exception"></exception>
        private void pd_PrintPageTicketVenta(object sender, PrintPageEventArgs e)
        {
            try
            {
                ObtenerDatosVenta();
                ObtenerDatosVentaDetallada();
                AgregarEncabezadoTicket(ref e);
                AgregarLinea(ref e, new Pen(Brushes.DarkGray, 1));
                AgregarInformacionTicket(ref e, false);
                AgregarLinea(ref e, new Pen(Brushes.DarkGray, 1));
                AgregarProductosVentas(ref e, dtVentaDetallada);
                AgregarTotalVenta(ref e, dtVenta);
                AgregarLinea(ref e, new Pen(Brushes.DarkGray, 1));
                AgregarPieTicket(ref e, dtVenta);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (OverflowException ex)
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
        }

        /// <summary>
        /// Evento de impresión del ticket de membresía
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.Exception"></exception>
        private void pd_PrintPageTicketMembresia(object sender, PrintPageEventArgs e)
        {
            try
            {
                AgregarEncabezadoTicket(ref e);
                AgregarLinea(ref e, new Pen(Brushes.DarkGray, 1));
                AgregarDatosMembresia(ref e);
                AgregarLinea(ref e, new Pen(Brushes.DarkGray, 1));
                AgregarPieTicket(ref e, null);
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
        }

        /// <summary>
        /// Evento de impresión de ticket de locker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pd_PrintPageTicketLockers(object sender, PrintPageEventArgs e)
        {
            try
            {
                AgregarEncabezadoTicket(ref e);
                AgregarLinea(ref e, new Pen(Brushes.DarkGray, 1));
                AgregarDatosLocker(ref e);
                AgregarLinea(ref e, new Pen(Brushes.DarkGray, 1));
                AgregarPieTicket(ref e, null);
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
        }

        /// <summary>
        /// Evento de impresión de ticket de código de producto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="System.OverflowException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.Exception"></exception>
        private void pd_PrintPageTicketCodigo(object sender, PrintPageEventArgs e)
        {
            try
            {
                AgregarCodigoBarrasProducto(ref e, this.idProd);
            }
            catch (OverflowException ex)
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
        }

        /// <summary>
        /// Evento de impresión de ticket de caja
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.Exception"></exception>
        private void pd_PrintPageTicketCaja(object sender, PrintPageEventArgs e)
        {
            try
            {
                AgregarEncabezadoTicket(ref e);
                AgregarLinea(ref e, new Pen(Brushes.DarkGray, 1));
                AgregarInformacionTicket(ref e, true);
                AgregarLinea(ref e, new Pen(Brushes.DarkGray, 1));
                AgregarDatosCierreCaja(ref e);
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
        }
    }
}
