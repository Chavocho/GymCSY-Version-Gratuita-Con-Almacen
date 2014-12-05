
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using GYM.Clases;
using System.Data;
using System.Drawing;
using System.IO;
namespace GYM.Clases
{
    class CEventosPDF : PdfPageEventHelper
    {
        #region Atributos
        private string rutaLogo;
        private string rutaLogoCliente;
        private iTextSharp.text.Font fuenteTitulo;
        private iTextSharp.text.Font fuenteCuerpo;
        private string nombreNegocio;
        private string direccionNegocio;
        private string telefonoNegocio;
        private string tipoReporte;
        private string piePagina;
        private string textoNumeroPagina;
        private float altuarHeader;
        private float alturaFooter;
        private float anchoHeader;


        public float AnchoHeader
        {
            get { return anchoHeader; }
            set { anchoHeader = value; }
        }
        

        public float AlturaFooter
        {
            get { return alturaFooter; }
            set { alturaFooter = value; }
        }

        public float AlturaHeader
        {
            get { return altuarHeader; }
            set { altuarHeader = value; }
        }

        public string TextoNumeroPagina
        {
            get { return textoNumeroPagina; }
            set { textoNumeroPagina = value; }
        }

        public string PiePagina
        {
            get { return piePagina; }
            set { piePagina = value; }
        }

        public string TipoReporte
        {
            get { return tipoReporte; }
            set { tipoReporte = value; }
        }

        public string TelefonoNegocio
        {
            get { return telefonoNegocio; }
            set { telefonoNegocio = value; }
        }

        public string DireccionNegocio
        {
            get { return direccionNegocio; }
            set { direccionNegocio = value; }
        }

        public string NombreNegocio
        {
            get { return nombreNegocio; }
            set { nombreNegocio = value; }
        }

        public iTextSharp.text.Font FuenteCuerpo
        {
            get { return fuenteCuerpo; }
            set { fuenteCuerpo = value; }
        }

        public iTextSharp.text.Font FuenteTitulo
        {
            get { return fuenteTitulo; }
            set { fuenteTitulo = value; }
        }

        public string RutaLogoCliente
        {
            get { return rutaLogoCliente; }
            set { rutaLogoCliente = value; }
        }

        public string RutaLogo
        {
            get { return rutaLogo; }
            set { rutaLogo = value; }
        }

        #endregion

        public override void OnStartPage(PdfWriter writer, Document document)
        {
            try
            {
                //Header
                PdfPTable tablaPrincipalHeader = new PdfPTable(3);
                tablaPrincipalHeader.TotalWidth = iTextSharp.text.PageSize.LETTER.Width - 120;
                tablaPrincipalHeader.LockedWidth = true;
                tablaPrincipalHeader.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                tablaPrincipalHeader.HorizontalAlignment = Element.ALIGN_CENTER;
                //tablaPrincipalHeader.DefaultCell.Border = PdfPCell.NO_BORDER;

                PdfPTable tablaLogoEmpresa = new PdfPTable(1);
                PdfPCell EspacioBlancologoEmpresa = new PdfPCell(new Phrase("\n"));
                EspacioBlancologoEmpresa.Border = PdfPCell.NO_BORDER;
                tablaLogoEmpresa.AddCell(EspacioBlancologoEmpresa);
                PdfPCell logoEmpresa = new PdfPCell(iTextSharp.text.Image.GetInstance(RutaLogo)); //Remplazar por la linea de abajo
                /////////PdfPCell logoEmpresa = new PdfPCell(new Phrase(""));
                logoEmpresa.HorizontalAlignment = Element.ALIGN_CENTER;
                logoEmpresa.VerticalAlignment = Element.ALIGN_CENTER;
                logoEmpresa.Border = PdfPCell.NO_BORDER;
                tablaLogoEmpresa.AddCell(logoEmpresa);
                tablaPrincipalHeader.AddCell(tablaLogoEmpresa);

                PdfPTable tablaDatosNegocio = new PdfPTable(1);
                tablaDatosNegocio.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                // tablaDatosNegocio.DefaultCell.Border = PdfPCell.NO_BORDER;
                {
                    iTextSharp.text.Phrase renglon1 = null;
                    if (Convert.ToBoolean(CConfiguracionXML.ExisteConfiguracion("encabezado", "renglon1")))
                        renglon1 = new iTextSharp.text.Phrase(CConfiguracionXML.LeerConfiguración("encabezado", "renglon1"), FuenteTitulo);
                    else
                        renglon1 = new iTextSharp.text.Phrase("", FuenteTitulo);
                    PdfPCell celdaRenglon1 = new PdfPCell(renglon1);
                    celdaRenglon1.Border = PdfPCell.NO_BORDER;
                    tablaDatosNegocio.AddCell(celdaRenglon1);
                }
                {
                    Phrase renglon2 = null;
                    if (Convert.ToBoolean(CConfiguracionXML.ExisteConfiguracion("encabezado", "renglon2")))
                        renglon2 = new Phrase(CConfiguracionXML.LeerConfiguración("encabezado", "renglon2"), FuenteCuerpo);
                    else
                        renglon2 = new Phrase("", FuenteCuerpo);
                    PdfPCell celdasRenglon2 = new PdfPCell(renglon2);
                    celdasRenglon2.Border = PdfPCell.NO_BORDER;
                    tablaDatosNegocio.AddCell(celdasRenglon2);
                }
                {
                    Phrase renglon3 = null;
                    if (Convert.ToBoolean(CConfiguracionXML.ExisteConfiguracion("encabezado", "renglon3")))
                        renglon3 = new Phrase(CConfiguracionXML.LeerConfiguración("encabezado", "renglon3"), fuenteCuerpo);
                    else
                        renglon3 = new Phrase("", fuenteCuerpo);
                    PdfPCell celdaRenglon3 = new PdfPCell(renglon3);
                    celdaRenglon3.Border = PdfPCell.NO_BORDER;
                    tablaDatosNegocio.AddCell(celdaRenglon3);
                }
                {
                     
                    PdfPCell celdaTipoReporte = new PdfPCell(new Phrase(TipoReporte, FuenteTitulo));
                    celdaTipoReporte.Border = PdfPCell.NO_BORDER;
                    tablaDatosNegocio.AddCell(celdaTipoReporte);
                }
                
                tablaPrincipalHeader.AddCell(tablaDatosNegocio);



                PdfPTable tablaLogoCliente = new PdfPTable(1);
                tablaLogoCliente.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                tablaLogoCliente.DefaultCell.Border = PdfPCell.NO_BORDER;
                if (Convert.ToBoolean(CConfiguracionXML.LeerConfiguración("reporte", "fecha")))
                    tablaLogoCliente.AddCell(new Phrase("Fecha: " + obtenerFecha(), FuenteCuerpo));
                else
                    tablaLogoCliente.AddCell(new Phrase("\n", FuenteCuerpo));
                PdfPCell logoCliente;
                if (Convert.ToBoolean(CConfiguracionXML.ExisteConfiguracion("encabezado", "ultimaImagenSeleccionada")))
                    logoCliente = new PdfPCell(iTextSharp.text.Image.GetInstance(CConfiguracionXML.LeerConfiguración("encabezado", "ultimaImagenSeleccionada")));
                else
                    logoCliente = new PdfPCell(new Phrase("", FuenteCuerpo));
                logoCliente.HorizontalAlignment = Element.ALIGN_CENTER;
                logoCliente.VerticalAlignment = Element.ALIGN_CENTER;
                logoCliente.Border = PdfPCell.NO_BORDER;
                tablaLogoCliente.AddCell(logoCliente);   //Descomentar para icono del cliente
                tablaPrincipalHeader.AddCell(tablaLogoCliente);



                tablaPrincipalHeader.WriteSelectedRows(0, -1, document.LeftMargin + 30, document.PageSize.Height - 36, writer.DirectContent);

                //Footer
                PdfPTable tablaPrincipalFooter = new PdfPTable(3);
                tablaPrincipalFooter.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                tablaPrincipalFooter.DefaultCell.Border = PdfPCell.NO_BORDER;
                tablaPrincipalFooter.TotalWidth = (document.PageSize.Width - document.LeftMargin - document.RightMargin); //this centers [table]
                tablaPrincipalFooter.LockedWidth = true;

                if (Convert.ToBoolean(CConfiguracionXML.LeerConfiguración("reporte", "usuarioCreador")))
                    tablaPrincipalFooter.AddCell("Creó: " + obtenerNombreUsuario(frmMain.id.ToString()));
                else
                    tablaPrincipalFooter.AddCell("");

                if (Convert.ToBoolean(CConfiguracionXML.LeerConfiguración("reporte", "piePagina")))
                    tablaPrincipalFooter.AddCell(new Phrase(CConfiguracionXML.LeerConfiguración("reporte", "piePagina-txt"), FuenteCuerpo));
                else
                    tablaPrincipalFooter.AddCell(new Phrase("", FuenteCuerpo));

                if (Convert.ToBoolean(CConfiguracionXML.LeerConfiguración("reporte", "numeroPaginas")))
                    tablaPrincipalFooter.AddCell(new Phrase("Gym CSY " + TextoNumeroPagina + " " + document.PageNumber, FuenteCuerpo));
                else
                    tablaPrincipalFooter.AddCell(new Phrase("Gym CSY", FuenteCuerpo));

                tablaPrincipalFooter.WriteSelectedRows(0, -1, document.LeftMargin, AlturaFooter, writer.DirectContent);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private string obtenerFecha()
        {
            return DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
        }
       
        private string obtenerNombreUsuario(string idUsuario)
        {
            if (idUsuario.Equals(""))
                return "";
            string sql = "SELECT userName FROM  usuarios WHERE id = " + idUsuario;
            DataTable nombre = ConexionBD.EjecutarConsultaSelect(sql);
            return nombre.Rows[0]["userName"].ToString().ToUpper();

        }



    }
}
