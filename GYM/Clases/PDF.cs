using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Fuente = iTextSharp.text.Font;
using System.IO;
using System.Data;
using MySql.Data.MySqlClient;

namespace GYM.Clases
{
    class PDF
    {
        string ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Reportes GymCSY\\";
        Document d;
        PdfWriter w; 
        Fuente pequeña;
        Fuente normal;
        Fuente grande;

        /// <summary>
        /// Inicializa la instancia de la clase PDF, creando el archivo con el nombre y en la carpeta especificada.
        /// </summary>
        /// <param name="nomArchivo">Nombre que se le dará al archivo PDF.</param>
        /// <param name="carpeta">Carpeta donde se guardará el</param>
        public PDF(string nomArchivo, string carpeta)
        {
            pequeña = new Fuente(Fuente.FontFamily.HELVETICA, 8, Fuente.NORMAL, BaseColor.BLACK);
            normal = new Fuente(Fuente.FontFamily.HELVETICA, 12, Fuente.NORMAL, BaseColor.BLACK);
            grande = new Fuente(Fuente.FontFamily.HELVETICA, 14, Fuente.NORMAL, BaseColor.BLACK);

            d = new Document(PageSize.LETTER);
            PdfWriter w = PdfWriter.GetInstance(d, new FileStream(ruta + "\\" + carpeta + "\\" + nomArchivo + ".pdf", FileMode.Create));
            d.AddTitle("PDF GymCSY");
            d.AddCreator("GymCSY");
            d.Open();
        }

        #region Membresías

        /// <summary>
        /// Función que imprime el reporte de membresías entre las fechas especificadas
        /// </summary>
        /// <param name="fechaIni">Fecha de inicio de donde se tomará los datos de las membresías</param>
        /// <param name="fechaFin">Fecha final de donde se tomará los datos de las membresías</param>
        public void ReporteMembresias(DateTime fechaIni, DateTime fechaFin)
        {

        }

        /// <summary>
        /// Método que obtiene los datos de registro de membresías entre las fechas especificadas
        /// </summary>
        /// <param name="fechaIni">Fecha de inicio de donde se tomará los datos de las membresías</param>
        /// <param name="fechaFin">Fecha final de donde se tomará los datos de las membresías</param>
        /// <returns>System.DataTable con la información de las membresías</returns>
        private DataTable DatosMembresias(DateTime fechaIni, DateTime fechaFin)
        {
            DataTable dt = null;
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT soc.numSocio, soc.nombre, soc.apellidos, reg.fecha_ini, reg.fecha_fin, reg.tipo_pago, reg.precio, reg.terminacion, " + 
                    "reg.folio_remision, reg.folio_ticket, reg.create_user FROM miembros AS soc INNER JOIN membresias AS mem ON (soc.numSocio=mem.numSocio) " + 
                    "INNER JOIN registro_membresias AS reg ON (mem.id=reg.membresia_id) WHERE (reg.create_time BETWEEN ?fechaIni AND ?fechaFin)";
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;   
            }
            return dt;
        }

        #endregion
    }
}
