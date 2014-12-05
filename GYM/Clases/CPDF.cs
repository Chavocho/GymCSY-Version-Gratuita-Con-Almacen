using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Data;
using GYM.Formularios.Reporte;

namespace GYM.Clases
{
    class CPDF
    {
        #region Variables
        CEventosPDF eventos = new CEventosPDF();
        //Header & footer
        private string rutaLogo;
        private string rutaLogoCliente;
        private Font fuenteTitulo;
        private Font fuenteCuerpo;
        private string nombreNegocio;
        private string direccionNegocio;
        private string telefonoNegocio;
        private string tipoReporte;
        private string piePagina;
        private string textoNumeroPagina;
        private float altuarHeader;
        private float alturaFooter;
        private float anchoHeader;



      
        private List<List<List<string>>> dataPDF;
        private string rutaPDF;
        private int posDiccionario = 0;
        frmOpcionesAvanzadasSociosMembresias frmOpciones;
        private bool statusPDF;
        private frmOpcionesAvanzadasTrabajador frmTrabajador;
        private frmOpcionesAvanzadasProducto frmProducto;
        private frmOpcionesAvanzadasUsuario frmUsuario;
        private frmOpcionesAvanzadasCaja frmCaja;
        private frmOpcionesAvanzadasPOS frmPOS;
        private float margenIzquierdo;
        private float margenDerecho;
        private float margenSuperios;
        private float margenInferior;
        private Rectangle tamanioPagina;

        public float AnchoHeader
        {
            get { return anchoHeader; }
            set { anchoHeader = value; }
        }

        public Rectangle TamanioPagina
        {
            get { return tamanioPagina; }
            set { tamanioPagina = value; }
        }
        

        public float MargenInferior
        {
            get { return margenInferior; }
            set { margenInferior = value; }
        }
        
        public float MargenSuperior
        {
            get { return margenSuperios; }
            set { margenSuperios = value; }
        }
      
        public float MargenDerecho
        {
            get { return margenDerecho; }
            set { margenDerecho = value; }
        }
       
        public float MargenIzquierdo
        {
            get { return margenIzquierdo; }
            set { margenIzquierdo = value; }
        }
        
        public bool StatusPDF
        {
            get { return statusPDF; }
        }
        
        public string RutaPDF
        {
            get { return rutaPDF; }
            set { rutaPDF = value; }
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

        public Font FuenteCuerpo
        {
            get { return fuenteCuerpo; }
            set { fuenteCuerpo = value; }
        }

        public Font FuenteTitulo
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

        #region Funciones generales
         
       public CPDF()
        {
        }
        private void AgregarHeaderFooter(ref PdfWriter wri)
        {
            try
            {
                eventos.AlturaFooter = AlturaFooter;
                eventos.AlturaHeader = AlturaHeader;
                eventos.DireccionNegocio = DireccionNegocio;
                eventos.FuenteCuerpo = FuenteCuerpo;
                eventos.FuenteTitulo = FuenteTitulo;
                eventos.NombreNegocio = NombreNegocio;
                eventos.PiePagina = PiePagina;
                eventos.RutaLogo = RutaLogo;
                eventos.RutaLogoCliente = RutaLogoCliente;
                eventos.TelefonoNegocio = TelefonoNegocio;
                eventos.TextoNumeroPagina = TextoNumeroPagina;
                eventos.TipoReporte = TipoReporte;
                eventos.AnchoHeader = AnchoHeader;
                wri.PageEvent = eventos;



            }
            catch
            { }
        }

        private void calcularPosicionesTabla(int numeroElementos, ref int tamaniotabla1, ref int tamaniotabala2, ref int tamaniotabla3)
        {
            if (numeroElementos > 5 && numeroElementos != 7)
            {
                tamaniotabla1 = 3;
                if (numeroElementos != 11)
                    tamaniotabala2 = 3;
                else if (numeroElementos == 11)
                    tamaniotabala2 = 4;
            }
            else if (numeroElementos == 7)
            {
                tamaniotabla1 = 3;
                tamaniotabala2 = 4;
            }
            else if (numeroElementos == 5)
            {
                tamaniotabla1 = 3;
                tamaniotabala2 = 2;
            }
            else if (numeroElementos == 4)
            {
                tamaniotabla1 = 2;
                tamaniotabala2 = 2;
            }
            else
            {
                tamaniotabla1 = numeroElementos;
                tamaniotabala2 = 0;
            }

            tamaniotabla3 = numeroElementos - tamaniotabla1 - tamaniotabala2;
        }

        private void agregarObservaciones(ref Document doc)
        {
            try
            {
                if (Convert.ToBoolean(CConfiguracionXML.LeerConfiguración("reporte", "observaciones")))
                {
                    //Creamos una tabla
                    PdfPTable table = new PdfPTable(1);
                    table.TotalWidth = iTextSharp.text.PageSize.LETTER.Width - 120;
                    //fix the absolute width of the table
                    table.LockedWidth = true;

                    table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

                    PdfPCell cell = new PdfPCell(new Phrase("Observaciones"));
                    cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right  
                    cell.Colspan = 1;
                    table.AddCell(cell);

                    PdfPCell cell2 = new PdfPCell(new Phrase(CConfiguracionXML.LeerConfiguración("reporte", "observaciones-txt"),FuenteCuerpo));
                    cell2.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right  
                    cell2.Colspan = 1;
                    cell2.HorizontalAlignment = Element.ALIGN_JUSTIFIED_ALL;
                    cell2.VerticalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell2);
                    table.AddCell("");

                    doc.Add(table);
                }
            }
            catch
            { }

        }
        #endregion

        #region Socios y membresias
        public List<List<List<string>>> DataPDF
        {
            get { return dataPDF; }
            set { dataPDF = value; }
        }

        public void Generar(List<List<List<string>>> dataPDF_, frmOpcionesAvanzadasSociosMembresias frmOpciones_, string ruta)
        {
            frmOpciones = frmOpciones_;
            dataPDF = dataPDF_;
            rutaPDF = ruta;
            statusPDF =  DictionaryToTable();
            
        }

        private bool DictionaryToTable()
        {
            if (dataPDF.Count <= 0)
                return false;

            Document doc = new Document(tamanioPagina,MargenIzquierdo, MargenDerecho, MargenSuperior, MargenInferior);
           
            try
            {
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(rutaPDF, FileMode.Create));
                                
                AgregarHeaderFooter(ref wri);
                doc.Open();               

                for (; posDiccionario < dataPDF.Count; posDiccionario++)
                {
                    if (dataPDF[posDiccionario] == null)
                        continue;
                    datosPersonales(ref doc);
                    doc.Add(new Phrase("\n"));
                    membresiasActivas(ref doc);
                    doc.Add(new Phrase("\n"));
                   if(membresiasPasadas(ref doc))
                    doc.Add(new Phrase("\n"));
                    
                }
                agregarObservaciones(ref doc);
                doc.Close();
                return true;
            }
            catch
            {
                doc.Close();
                return false;
            }
        }


        private void datosPersonales(ref Document doc)
        {
            int tamanioTabla1 = 0, tamanioTabla2 = 0, tamanioTabla3 = 0;
            List<string> celdas = generaListaSocios();
            //Obtenermos el numero de celdas para cada coso de tabla
            calcularPosicionesTabla(celdas.Count, ref tamanioTabla1, ref tamanioTabla2, ref tamanioTabla3);
            if (tamanioTabla1 > 0)
            {
            //Creamos una tabla
            PdfPTable table = new PdfPTable(tamanioTabla1);
            table.TotalWidth = iTextSharp.text.PageSize.LETTER.Width - 120;
            //fix the absolute width of the table
            table.LockedWidth = true;

            table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPCell cell = new PdfPCell(new Phrase("Datos Personales"));
            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right  
            cell.Colspan = tamanioTabla1;
            table.AddCell(cell);

            for (int i = 0; i < tamanioTabla1; i++)
                table.AddCell(celdas[i]);

             doc.Add(table);

             if (tamanioTabla2 > 0)
             {
                 PdfPTable table2 = new PdfPTable(tamanioTabla2);
                 table2.TotalWidth = iTextSharp.text.PageSize.LETTER.Width - 120;
                 //fix the absolute width of the table
                 table2.LockedWidth = true;

                 table2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

                 if(tamanioTabla3 <= 0)
                     for (int i = tamanioTabla1; i < celdas.Count; i++)
                         table2.AddCell(celdas[i]);
                 else
                 for (int i = tamanioTabla1; i < celdas.Count- tamanioTabla3; i++)
                     table2.AddCell(celdas[i]);

                 doc.Add(table2);
             }

             if (tamanioTabla3 > 0)
             {
                 PdfPTable table3 = new PdfPTable(tamanioTabla3);
                 table3.TotalWidth = iTextSharp.text.PageSize.LETTER.Width - 120;
                 //fix the absolute width of the table
                 table3.LockedWidth = true;

                 table3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;


                 for (int i = tamanioTabla2 + tamanioTabla1; i < celdas.Count; i++)
                     table3.AddCell(celdas[i]);

                 doc.Add(table3);
             }
            }
 
        }

        private void membresiasActivas(ref Document doc)
        {
            int tamanioTabla1 = 0;
            int tamanioTabla2 = 0;
            //Obtiene una lista de todas las posibles celdas a acomodar
            List<string> celdas = generarListaMembresiasActivas();
            //Obtenemos los parametros necesarios para generar las tablas con el numero de celdas necesarias
            calcularValoresMembresiasActivas(celdas.Count, ref tamanioTabla1, ref tamanioTabla2);
            if (tamanioTabla1 > 0)
            {
                PdfPTable tabla1 = new PdfPTable(tamanioTabla1);
                tabla1.TotalWidth = iTextSharp.text.PageSize.LETTER.Width - 120;
                tabla1.LockedWidth = true;
                tabla1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

                PdfPCell cell = new PdfPCell(new Phrase("Ultima membresia"));
                cell.Colspan = tamanioTabla1;
                cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right  

                tabla1.AddCell(cell);

                for (int i = 0; i < tamanioTabla1; i++)
                    tabla1.AddCell(celdas[i]);

                doc.Add(tabla1);

                if (tamanioTabla2 > 0)
                {
                    PdfPTable tabla2 = new PdfPTable(tamanioTabla2);
                    tabla2.TotalWidth = iTextSharp.text.PageSize.LETTER.Width - 120;
                    tabla2.LockedWidth = true;
                    tabla2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

                    for (int i = tamanioTabla1; i < celdas.Count; i++)
                        tabla2.AddCell(celdas[i]);

                    doc.Add(tabla2);
                }

            }
        }

        private bool membresiasPasadas(ref Document doc)
        {
            int i = 2;
            try
            {
                for (; i < dataPDF[posDiccionario][2].Count; i++)
                {


                    PdfPTable tabla1 = new PdfPTable(3);
                    tabla1.TotalWidth = iTextSharp.text.PageSize.LETTER.Width - 120;
                    tabla1.LockedWidth = true;
                    tabla1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

                    PdfPCell cell = new PdfPCell(new Phrase("Membresias anteriores"));
                    cell.Colspan = 4;
                    cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right   

                    tabla1.AddCell(cell);

                    tabla1.AddCell("Fecha registro:\n" + preprocesarCadena(dataPDF[posDiccionario][i][0]));
                    tabla1.AddCell("Fecha fin:\n" + preprocesarCadena(dataPDF[posDiccionario][i][1]));
                    tabla1.AddCell("Tipo de membresia:\n" + preprocesarCadena(tipoMembresia(dataPDF[posDiccionario][i][2])));

                    tabla1.AddCell("Precio:\n" + preprocesarCadena(dataPDF[posDiccionario][i][4]));
                    tabla1.AddCell("Descripción:\n " + preprocesarCadena(dataPDF[posDiccionario][i][3]));
                    tabla1.AddCell("Creó:\n" + preprocesarCadena(obtenerNombreUsuario(dataPDF[posDiccionario][i][5])));

                    doc.Add(tabla1);

                }

                if (i == 2)
                    return false;
                else
                    return true;
               
            }
            catch
            {
                if (i == 2)
                    return false;
                else
                    return true;
            }

        }

        private string statusMembresia(string valor)
        {
            if (!Convert.ToBoolean(valor))
                return "Desactivada";
            return "Activada";
        }

        private string tipoMembresia(string valor)
        {
            switch (valor)
            {
                case "0":
                    return "SEMANA";
                case "1":
                    return "MENSUAL";
                case "2":
                    return "2 MESES";
                case "3":
                    return "3 MESES";
                case "4":
                    return "6 MESES";
                case "5":
                    return "12 MESES";
                default:
                    return "";
            }
        }

        private string tipoPago(string valor)
        {
            if (valor.Equals(""))
                return valor;
            if (Convert.ToInt32(valor) == 0)
                return "EFECTIVO";
            return "TARJETA";
        }
    
        private string obtenerNombreUsuario(string idUsuario){
            if (idUsuario.Equals(""))
                return "";
            string sql = "SELECT userName FROM  usuarios WHERE id = " + idUsuario;
            DataTable nombre = ConexionBD.EjecutarConsultaSelect(sql);
            if (!nombre.Rows[0]["userName"].ToString().ToUpper().Equals(""))
                return nombre.Rows[0]["userName"].ToString().ToUpper();
            else
                return "";

        }

        private string preprocesarCadena(string valor)
        {
            if (valor.Equals("sin informacion"))
                return "";
            return valor.ToUpper();
        }

        private void calcularValoresMembresiasActivas(int numeroElementos,ref int tamanioTabla1, ref int tamanioTabla2)
        {
            if (numeroElementos == 10)
            {
                tamanioTabla1 = 5;
                tamanioTabla2 = 5;
            }
            else if (numeroElementos == 9)
            {
                tamanioTabla1 = 4;
                tamanioTabla2 = 5;
            }
            else if (numeroElementos > 5)
            {
                tamanioTabla1 = (numeroElementos / 2);
                tamanioTabla2 = (numeroElementos / 2) + (numeroElementos % 2);
            }
            else if (numeroElementos == 5 || numeroElementos == 3)
            {
                tamanioTabla1 = ((int)(numeroElementos / 3)) * 3;
                tamanioTabla2 = (numeroElementos % 3);
            }
            else if (numeroElementos == 4)
            {
                tamanioTabla1 = 2;
                tamanioTabla2 = 2;                
            }
            else if (numeroElementos < 3)
            {
                tamanioTabla1 = numeroElementos;
                tamanioTabla2 = 0;
            }
        }

        private List<string> generarListaMembresiasActivas()
        {
            List<string> celdas = new List<string>();

            if (this.frmOpciones.chboxStatusMembresia.Checked)
                celdas.Add("Status:\n" + preprocesarCadena(statusMembresia(dataPDF[posDiccionario][1][6])));            
            if (this.frmOpciones.chboxFechaInicioMembresia.Checked)
                celdas.Add("Fecha inicio:\n" + preprocesarCadena(dataPDF[posDiccionario][1][4]));            
            if (this.frmOpciones.chboxFechaFinalMembresia.Checked)
                celdas.Add("Fecha final:\n" + preprocesarCadena(dataPDF[posDiccionario][1][5]));
            if (this.frmOpciones.chboxDescripcionMembresia.Checked)
                celdas.Add("Descripción:\n " + preprocesarCadena(dataPDF[posDiccionario][1][7]));          
            if (this.frmOpciones.chboxTiempoMembresia.Checked)
                celdas.Add("Tiempo de membresia:\n" + preprocesarCadena(tipoMembresia(dataPDF[posDiccionario][1][0])));
            if (this.frmOpciones.chboxTipoMembresiaMembresias.Checked)
                celdas.Add("Tipo de membresia:\n" + preprocesarCadena(tipoMembresia(dataPDF[posDiccionario][1][0])));          
            if (this.frmOpciones.chboxTipoPagoMembresias.Checked)            
                celdas.Add("Tipo de pago:\n" + preprocesarCadena(tipoPago(dataPDF[posDiccionario][1][1])));
            if (this.frmOpciones.chboxFolioRemisionMembresia.Checked)
                celdas.Add("Folio remision:\n" + preprocesarCadena(dataPDF[posDiccionario][1][2]));
            if (this.frmOpciones.chboxFolioTicketMembresia.Checked)
                celdas.Add("Folio ticket:\n" + preprocesarCadena(dataPDF[posDiccionario][1][3]));
            if (this.frmOpciones.chboxUsuarioCreadorMembresia.Checked)
                celdas.Add("Creó:\n" + preprocesarCadena(obtenerNombreUsuario(dataPDF[posDiccionario][1][8])));           

            return celdas;
        }

        private List<string> generaListaSocios()
        {
            List<string> celdas = new List<string>();
            string direccionCiudadEstado = "", telefonoCelular = "";

            if (this.frmOpciones.chboxNumeroSocioSocios.Checked)
                celdas.Add("Numero de socio:\n" + preprocesarCadena(dataPDF[posDiccionario][0][0]));
            if (this.frmOpciones.chboxNombreSocios.Checked)
                celdas.Add("Nombre:\n" + preprocesarCadena(dataPDF[posDiccionario][0][1]));

            if (this.frmOpciones.chboxFechaNacSocios.Checked)
                celdas.Add("Fecha de nacimiento:\n" + preprocesarCadena(dataPDF[posDiccionario][0][8]));
            {
                if (this.frmOpciones.chboxDireccionSocios.Checked)
                    direccionCiudadEstado += (preprocesarCadena(dataPDF[posDiccionario][0][2]) + " ");

                if (this.frmOpciones.chboxCiudadSocios.Checked)
                    direccionCiudadEstado += (preprocesarCadena(dataPDF[posDiccionario][0][3]) + " ");

                if (this.frmOpciones.chboxEstadoSocio.Checked)
                    direccionCiudadEstado += (preprocesarCadena(dataPDF[posDiccionario][0][4]) + " ");
            }

            if (this.frmOpciones.chboxDireccionSocios.Checked || this.frmOpciones.chboxCiudadSocios.Checked || this.frmOpciones.chboxEstadoSocio.Checked)
                celdas.Add("Direccion/ciudad/estado:\n" + direccionCiudadEstado);
            {
                if (this.frmOpciones.chboxTelefonoSocio.Checked)
                    telefonoCelular += (preprocesarCadena(dataPDF[posDiccionario][0][5]) + " ");

                if (this.frmOpciones.chboxCelularSocio.Checked)
                    telefonoCelular += (preprocesarCadena(dataPDF[posDiccionario][0][6]));
            }
            if (this.frmOpciones.chboxTelefonoSocio.Checked || this.frmOpciones.chboxCelularSocio.Checked)
                celdas.Add("Telefono:\n" + telefonoCelular);

            if (this.frmOpciones.chboxEmailSocios.Checked)
                celdas.Add("Email:\n" + preprocesarCadena(dataPDF[posDiccionario][0][7]));

            if (this.frmOpciones.chboxUsuarioCreadorSocio.Checked)
                celdas.Add("Creó:\n" + preprocesarCadena(obtenerNombreUsuario(dataPDF[posDiccionario][0][9])));

            if (this.frmOpciones.chboxUsuarioActualizadorSocio.Checked)
                celdas.Add("Modificó:\n" + preprocesarCadena(obtenerNombreUsuario(dataPDF[posDiccionario][0][10])));

            return celdas;
        }

        #endregion

        #region Trabajadores

        public void Generar(List<List<List<string>>> dataPDFTrabajador, frmOpcionesAvanzadasTrabajador opcionesAvanzadasTrabajador, string ruta)

        {
            this.dataPDF = dataPDFTrabajador;
            this.frmTrabajador = opcionesAvanzadasTrabajador;
            this.rutaPDF = ruta;
            //Funcionanlidad
            statusPDF = DicionarioATablaTrabajador();
        }

      
        private bool DicionarioATablaTrabajador()
        {
            if (dataPDF.Count <= 0)
                return false;
            Document doc = new Document(tamanioPagina, MargenIzquierdo, MargenDerecho, MargenSuperior, MargenInferior);
            try
            {

                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(rutaPDF, FileMode.Create));
                AgregarHeaderFooter(ref wri);
                doc.Open();

                 

                for (; posDiccionario < dataPDF.Count; posDiccionario++)
                {

                    if (dataPDF[posDiccionario] == null)
                        continue; 
                    datosPersonalesTrabajador(ref doc);
                    doc.Add(new Phrase("\n"));
                    registroEntradas(ref doc);

                }

                agregarObservaciones(ref doc);

                doc.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                doc.Close();
                return false;
                throw;
            }

        }

        private void registroEntradas(ref Document doc)
        {
            if (this.frmTrabajador.chboxEntradasTrabajador.Checked)
            {
              
                    for (int i = 1; i < dataPDF[posDiccionario].Count; i++)
                    {
                        if (!this.frmTrabajador.chboxTodasLasEntradas.Checked)
                        {
                            DateTime fecha = DateTime.ParseExact(dataPDF[posDiccionario][i][1],"dd/MM/yyyy H:mm:ss",System.Globalization.CultureInfo.InvariantCulture);
                            if (!CFuncionesGenerales.RangoFecha(frmTrabajador.dtp1.Value, frmTrabajador.dtp2.Value, fecha))
                                continue;                              
                            
                        }
                        PdfPTable tabla1 = new PdfPTable(2);
                        tabla1.TotalWidth = iTextSharp.text.PageSize.LETTER.Width - 120;
                        tabla1.LockedWidth = true;
                        tabla1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

                        PdfPCell cell = new PdfPCell(new Phrase("Registro de entradas"));
                        cell.Colspan = 2;
                        cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right   

                        tabla1.AddCell(cell);

                        tabla1.AddCell("Numero de trabajador:\n" + preprocesarCadena(dataPDF[posDiccionario][i][0]));
                        tabla1.AddCell("Fecha ingreso:\n" + preprocesarCadena(dataPDF[posDiccionario][i][1]));

                        tabla1.AddCell("Descripción:\n" + preprocesarCadena(tipoMembresia(dataPDF[posDiccionario][i][2])));
                        tabla1.AddCell("Usuarios:\n" + obtenerNombreUsuario(dataPDF[posDiccionario][i][3]));

                        doc.Add(tabla1);
                        doc.Add(new Phrase("\n"));
                    }

            }
        }

        private void datosPersonalesTrabajador(ref Document doc)
        {
            int tamanioTabla1 = 0, tamanioTabla2 = 0, tamanioTabla3 = 0;
            List<string> celdas = generaListaTrabajadores();
            //Obtenermos el numero de celdas para cada coso de tabla
            calcularPosicionesTabla(celdas.Count, ref tamanioTabla1, ref tamanioTabla2, ref tamanioTabla3);
            if(tamanioTabla1 > 0){
                if (tamanioTabla1 != 0)
                {
                    //Creamos una tabla
                    PdfPTable table = new PdfPTable(tamanioTabla1);
                    table.TotalWidth = iTextSharp.text.PageSize.LETTER.Width - 120;
                    //fix the absolute width of the table
                    table.LockedWidth = true;

                    table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

                    PdfPCell cell = new PdfPCell(new Phrase("Datos Personales"));
                    cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right  
                    cell.Colspan = tamanioTabla1;
                    table.AddCell(cell);

                    for (int i = 0; i < tamanioTabla1; i++)
                        table.AddCell(celdas[i]);

                    doc.Add(table);

                    if (tamanioTabla2 > 0)
                    {
                        PdfPTable table2 = new PdfPTable(tamanioTabla2);
                        table2.TotalWidth = iTextSharp.text.PageSize.LETTER.Width - 120;
                        //fix the absolute width of the table
                        table2.LockedWidth = true;

                        table2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

                        if (tamanioTabla3 <= 0)
                            for (int i = tamanioTabla1; i < celdas.Count; i++)
                                table2.AddCell(celdas[i]);
                        else
                            for (int i = tamanioTabla1; i < celdas.Count - tamanioTabla3; i++)
                                table2.AddCell(celdas[i]);

                        doc.Add(table2);

                    }
                    if (tamanioTabla3 > 0)
                    {
                        PdfPTable table3 = new PdfPTable(tamanioTabla3);
                        table3.TotalWidth = iTextSharp.text.PageSize.LETTER.Width - 120;
                        //fix the absolute width of the table
                        table3.LockedWidth = true;

                        table3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;


                        for (int i = tamanioTabla2 + tamanioTabla1; i < celdas.Count; i++)
                            table3.AddCell(celdas[i]);

                        doc.Add(table3);

                    }
                }
            }
        }

        private List<string> generaListaTrabajadores()
        {
            List<string> celdas = new List<string>();
            string direccionCiudadEstado = "", telefonoCelular = "";

            if (this.frmTrabajador.chboxNumeroTrabajador.Checked)
                celdas.Add("Numero de socio:\n" + preprocesarCadena(dataPDF[posDiccionario][0][0]));
            if (this.frmTrabajador.chboxNombreTrabajador.Checked)
                celdas.Add("Nombre:\n" + preprocesarCadena(dataPDF[posDiccionario][0][1]));

            if (this.frmTrabajador.chboxFechaNacTrabajador.Checked)
                celdas.Add("Fecha de nacimiento:\n" + preprocesarCadena(dataPDF[posDiccionario][0][8]));
            {
                if (this.frmTrabajador.chboxDireccionTrabajador.Checked)
                    direccionCiudadEstado += (preprocesarCadena(dataPDF[posDiccionario][0][2]) + " ");

                if (this.frmTrabajador.chboxCiudadTrabajador.Checked)
                    direccionCiudadEstado += (preprocesarCadena(dataPDF[posDiccionario][0][3]) + " ");

                if (this.frmTrabajador.chboxEstadoTrabajador.Checked)
                    direccionCiudadEstado += (preprocesarCadena(dataPDF[posDiccionario][0][4]) + " ");
            }

            if (this.frmTrabajador.chboxDireccionTrabajador.Checked || this.frmTrabajador.chboxCiudadTrabajador.Checked || this.frmTrabajador.chboxEstadoTrabajador.Checked)
                celdas.Add("Direccion/ciudad/estado:\n" + direccionCiudadEstado);
            {
                if (this.frmTrabajador.chboxTelefonoTrabajador.Checked)
                    telefonoCelular += (preprocesarCadena(dataPDF[posDiccionario][0][5]) + "/");

                if (this.frmTrabajador.chboxCelulartrabajador.Checked)
                    telefonoCelular += (preprocesarCadena(dataPDF[posDiccionario][0][6]));
            }
            if (this.frmTrabajador.chboxTelefonoTrabajador.Checked || this.frmTrabajador.chboxCelulartrabajador.Checked)
                celdas.Add("Telefono:\n" + telefonoCelular);

            if (this.frmTrabajador.chboxEmailTrabajador.Checked)
                celdas.Add("Email:\n" + preprocesarCadena(dataPDF[posDiccionario][0][7]));

            if (this.frmTrabajador.chboxUsuarioCreadorTrabajador.Checked)
                celdas.Add("Creó:\n" + preprocesarCadena(obtenerNombreUsuario(dataPDF[posDiccionario][0][10])));

            if (this.frmTrabajador.chboxUsuarioActualizadorTrabajador.Checked)
                celdas.Add("Modificó:\n" + preprocesarCadena(obtenerNombreUsuario(dataPDF[posDiccionario][0][11])));

            return celdas;
        }

     
        #endregion

        #region Productos

        public void Generar(List<List<List<string>>> dataPDFProducto, frmOpcionesAvanzadasProducto opcionesAvanzadasProducto, string ruta)
        {
            dataPDF = dataPDFProducto;
            this.frmProducto = opcionesAvanzadasProducto;
            this.rutaPDF = ruta;
            statusPDF = diccionarioATablaProductos();
        }
                   
        private bool diccionarioATablaProductos()
        {
            if (dataPDF.Count <= 0)
                return false;

            Document doc = new Document(tamanioPagina, MargenIzquierdo, MargenDerecho, MargenSuperior, MargenInferior);
            try
            {                
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(rutaPDF, FileMode.Create));
                AgregarHeaderFooter(ref wri);
                doc.Open();
                for (; posDiccionario < dataPDF.Count; posDiccionario++)
                {
                    if (dataPDF[posDiccionario] == null)
                        continue;
                    datosProductos(ref doc);
                    doc.Add(new Phrase("\n"));

                }
             
                agregarObservaciones(ref doc);

                doc.Close();
                return true;
            }
            catch
            {
                doc.Close();
                return false;
            }
        }

        private List<string>  generarListaProductos()
        {
            List<string> celdas = new List<string>();

            if(this.frmProducto.chboxNombreProducto.Checked)
            celdas.Add("Nombre:\n" + preprocesarCadena((dataPDF[posDiccionario][0][0])));
            if(this.frmProducto.chboxMarcaProducto.Checked)
            celdas.Add("Marca:\n" + preprocesarCadena((dataPDF[posDiccionario][0][1])));
            if(this.frmProducto.chboxUnidadProducto.Checked)
            celdas.Add("Unidad:\n" + preprocesarCadena((dataPDF[posDiccionario][0][3])));
            if(this.frmProducto.chboxPrecioProducto.Checked)
            celdas.Add("Precio:\n" + preprocesarCadena((dataPDF[posDiccionario][0][4])));
            if(this.frmProducto.chboxCostoProducto.Checked)
            celdas.Add("Costo:\n" + preprocesarCadena((dataPDF[posDiccionario][0][5])));
            if(this.frmProducto.chboxDescripcionProducto.Checked)
            celdas.Add("Descripcion:\n" + preprocesarCadena((dataPDF[posDiccionario][0][2])));
            if(this.frmProducto.chboxUsuarioCreadorProducto.Checked)
            celdas.Add("Creó:\n" + preprocesarCadena(obtenerNombreUsuario(dataPDF[posDiccionario][0][6])));
            if(this.frmProducto.chboxUsuarioActualizadorProductos.Checked)
            celdas.Add("Actualizó:\n" + preprocesarCadena(obtenerNombreUsuario(dataPDF[posDiccionario][0][7])));

            return celdas;
        }

        private void datosProductos(ref Document doc)
        {
            int tamanioTabla1 = 0, tamanioTabla2 = 0, tamanioTabla3 = 0;
            List<string> celdas = generarListaProductos();
            //Obtenermos el numero de celdas para cada coso de tabla
            calcularPosicionesTabla(celdas.Count, ref tamanioTabla1, ref tamanioTabla2, ref tamanioTabla3);
            if (tamanioTabla1 != 0)
            {
                //Creamos una tabla
                PdfPTable table = new PdfPTable(tamanioTabla1);
                table.TotalWidth = iTextSharp.text.PageSize.LETTER.Width - 120;
                //fix the absolute width of the table
                table.LockedWidth = true;

                table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

                PdfPCell cell = new PdfPCell(new Phrase("Datos producto"));
                cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right  
                cell.Colspan = tamanioTabla1;
                table.AddCell(cell);

                for (int i = 0; i < tamanioTabla1; i++)
                    table.AddCell(celdas[i]);

                doc.Add(table);

                if (tamanioTabla2 > 0)
                {
                    PdfPTable table2 = new PdfPTable(tamanioTabla2);
                    table2.TotalWidth = iTextSharp.text.PageSize.LETTER.Width - 120;
                    //fix the absolute width of the table
                    table2.LockedWidth = true;

                    table2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

                    if (tamanioTabla3 <= 0)
                        for (int i = tamanioTabla1; i < celdas.Count; i++)
                            table2.AddCell(celdas[i]);
                    else
                        for (int i = tamanioTabla1; i < celdas.Count - tamanioTabla3; i++)
                            table2.AddCell(celdas[i]);

                    doc.Add(table2);

                }
                if (tamanioTabla3 > 0)
                {
                    PdfPTable table3 = new PdfPTable(tamanioTabla3);
                    table3.TotalWidth = iTextSharp.text.PageSize.LETTER.Width - 120;
                    //fix the absolute width of the table
                    table3.LockedWidth = true;

                    table3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;


                    for (int i = tamanioTabla2 + tamanioTabla1; i < celdas.Count; i++)
                        table3.AddCell(celdas[i]);

                    doc.Add(table3);

                }
            }
        }
        
        #endregion

        #region Usuarios

        public void Generar(List<List<List<string>>> dataPDFUsuarios, frmOpcionesAvanzadasUsuario opcionesAvanzadasUsuario, string ruta)
        {
            dataPDF = dataPDFUsuarios;
            this.frmUsuario = opcionesAvanzadasUsuario;
            rutaPDF = ruta;
            statusPDF = dicionarioATablaUsuario();
        }

        private bool dicionarioATablaUsuario()
        {
            if (dataPDF.Count <= 0)
                return false;

            Document doc = new Document(tamanioPagina, MargenIzquierdo, MargenDerecho, MargenSuperior, MargenInferior);
            try
            {
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(rutaPDF, FileMode.Create));

                AgregarHeaderFooter(ref wri);

                doc.Open();
                
                for (; posDiccionario < dataPDF.Count; posDiccionario++)
                {
                    if (dataPDF[posDiccionario] == null)
                        continue;
                    datosUsuario(ref doc);
                    doc.Add(new Phrase("\n"));

                }

                agregarObservaciones(ref doc);

                doc.Close();
                return true;
            }
            catch
            {
                doc.Close();
                return false;
            }
        }

        private void datosUsuario(ref Document doc)
        {

            int tamanioTabla1 = 0, tamanioTabla2 = 0, tamanioTabla3 = 0;
            List<string> celdas = generarListaUsuarios();
            //Obtenermos el numero de celdas para cada coso de tabla
            calcularPosicionesTabla(celdas.Count, ref tamanioTabla1, ref tamanioTabla2, ref tamanioTabla3);
            if (tamanioTabla1 != 0)
            {
                //Creamos una tabla
                PdfPTable table = new PdfPTable(tamanioTabla1);
                table.TotalWidth = iTextSharp.text.PageSize.LETTER.Width - 120;
                //fix the absolute width of the table
                table.LockedWidth = true;

                table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

                PdfPCell cell = new PdfPCell(new Phrase("Usuarios"));
                cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right  
                cell.Colspan = tamanioTabla1;
                table.AddCell(cell);

                for (int i = 0; i < tamanioTabla1; i++)
                    table.AddCell(celdas[i]);

                doc.Add(table);
            }

        }

        private List<string> generarListaUsuarios()
        {
            List<string> celdas = new List<string>();

           // if (this.frmUsuario.chboxNombreUsuarioUsuarios.Checked)
                celdas.Add("Nombre de usuario:\n" + preprocesarCadena((dataPDF[posDiccionario][0][0])));
           // if (this.frmUsuario.chboxNivelProducto.Checked)
                celdas.Add("Nivel:\n" + preprocesarCadena((dataPDF[posDiccionario][0][1])));

            return celdas;
            
        }


        #endregion

        #region Caja
       
        public void Generar(List<List<List<string>>> dataPDFCaja, frmOpcionesAvanzadasCaja opcionesAvanzadasCaja, string ruta)
        { 
            dataPDF = dataPDFCaja;
            frmCaja = opcionesAvanzadasCaja;
            rutaPDF = ruta;
            statusPDF = dicionarioATablaCaja();
        }
    
        private bool dicionarioATablaCaja()
        {
            if (dataPDF.Count <= 0)
                return false;

            Document doc = new Document(tamanioPagina, MargenIzquierdo, MargenDerecho, MargenSuperior, MargenInferior);
            try
            {
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(rutaPDF, FileMode.Create));

                AgregarHeaderFooter(ref wri);

                doc.Open();

                for (; posDiccionario < dataPDF.Count; posDiccionario++)
                {
                    if (dataPDF[posDiccionario] == null)
                        continue;
                    datosCaja(ref doc);
                    doc.Add(new Phrase("\n"));

                }

                agregarObservaciones(ref doc);

                doc.Close();
                return true;
            }
            catch
            {
                doc.Close();
                return false;
            }
        }

        private void datosCaja(ref Document doc)
        {
            int tamanioTabla1 = 0;
            int tamanioTabla2 = 0;
            int tamanioTabla3 = 0;
            //Obtiene una lista de todas las posibles celdas a acomodar
            List<string> celdas = generarListaCaja();
            //Obtenemos los parametros necesarios para generar las tablas con el numero de celdas necesarias
            calcularPosicionesTabla(celdas.Count, ref tamanioTabla1, ref tamanioTabla2, ref tamanioTabla3);

            if (tamanioTabla1 > 0)
            {
                //Comienza a dibujar la tabla
                PdfPTable tabla1 = new PdfPTable(tamanioTabla1);
                tabla1.TotalWidth = iTextSharp.text.PageSize.LETTER.Width - 120;
                tabla1.LockedWidth = true;
                tabla1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

                PdfPCell cell = new PdfPCell(new Phrase("Datos de caja"));
                cell.Colspan = 4;
                cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right   
                tabla1.AddCell(cell);

                for (int j = 0; j < tamanioTabla1; j++)
                    tabla1.AddCell(celdas[j]);

                doc.Add(tabla1);
                if (tamanioTabla2 > 0)
                {
                    PdfPTable table2 = new PdfPTable(tamanioTabla2);
                    table2.TotalWidth = iTextSharp.text.PageSize.LETTER.Width - 120;
                    //fix the absolute width of the table
                    table2.LockedWidth = true;

                    table2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

                    if (tamanioTabla3 <= 0)
                        for (int k = tamanioTabla1; k < celdas.Count; k++)
                            table2.AddCell(celdas[k]);
                    else
                        for (int k = tamanioTabla1; k < celdas.Count - tamanioTabla3; k++)
                            table2.AddCell(celdas[k]);

                    doc.Add(table2);
                }

                if (tamanioTabla3 > 0)
                {
                    PdfPTable table3 = new PdfPTable(tamanioTabla3);
                    table3.TotalWidth = iTextSharp.text.PageSize.LETTER.Width - 120;
                    //fix the absolute width of the table
                    table3.LockedWidth = true;

                    table3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;


                    for (int k = tamanioTabla2 + tamanioTabla1; k < celdas.Count; k++)
                        table3.AddCell(celdas[k]);

                    doc.Add(table3);
                }
            }
            
        }

        private List<string> generarListaCaja()
        {
            List<string> celdas = new List<string>();

            if(this.frmCaja.chboxIdentificadorVentaCaja.Checked)
                celdas.Add("Identificador de venta:\n" + preprocesarCadena(dataPDF[posDiccionario][0][0]));
            if(this.frmCaja.chboxEfectivoCaja.Checked)
                celdas.Add("Efectivo:\n" + preprocesarCadena(dataPDF[posDiccionario][0][1]));
            if(this.frmCaja.chboxTarjetaCaja.Checked)
                celdas.Add("Tarjeta:\n" + preprocesarCadena(dataPDF[posDiccionario][0][2]));
            if(this.frmCaja.chboxTipoMovimientoCaja.Checked)
                celdas.Add("Tipo de movimiento:\n" + preprocesarCadena(dataPDF[posDiccionario][0][3]));
            if(this.frmCaja.chboxFechaCaja.Checked)
                celdas.Add("Fecha:\n" + preprocesarCadena(dataPDF[posDiccionario][0][4]));
            if(this.frmCaja.chboxDescripcionCaja.Checked)
                celdas.Add("Descripción:\n" + preprocesarCadena(dataPDF[posDiccionario][0][5]));
            if(this.frmCaja.chboxSubtotalCaja.Checked)
                celdas.Add("Subtotal:\n" + preprocesarCadena(dataPDF[posDiccionario][0][6]));
            if (this.frmCaja.chboxUsuarioCreadorCaja.Checked)
                celdas.Add("Creó:\n" + preprocesarCadena(obtenerNombreUsuario(dataPDF[posDiccionario][0][7])));

            return celdas;
        }
        
        #endregion


        #region POS

        public void Generar(List<List<List<string>>> dataPDFPOS, frmOpcionesAvanzadasPOS opcionesAvanzadasPOS, string ruta)
        {
            dataPDF = dataPDFPOS;
            frmPOS = opcionesAvanzadasPOS;
            rutaPDF = ruta;
            statusPDF = dicionarioATablaPOS();
        }
     
        private bool dicionarioATablaPOS()
        {
            if (dataPDF.Count <= 0)
                return false;
            Document doc = new Document(tamanioPagina, MargenIzquierdo, MargenDerecho, MargenSuperior, MargenInferior);
            try
            {
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(rutaPDF, FileMode.Create));

                AgregarHeaderFooter(ref wri);

                doc.Open();

                for (; posDiccionario < dataPDF.Count; posDiccionario++)
                {
                    if (dataPDF[posDiccionario] == null)
                        continue;
                    datosPOS(ref doc);
                    doc.Add(new Phrase("\n"));
                    datosVentaDetallada(ref doc);
                    doc.Add(new Phrase("\n"));

                }

                agregarObservaciones(ref doc);

                doc.Close();
                return true;
            }
            catch (Exception)
            {
                doc.Close();
                return false;
            }
        }

        private void datosVentaDetallada(ref Document doc)
        {//dataPDF[posdDiccionario][i]   [X]  
            for (int i = 1; i < dataPDF[posDiccionario].Count; i++)
            {   //dataPDF[posdDiccionario][i]   [X]               

                int tamanioTabla1 = 0;
                int tamanioTabla2 = 0;
                int tamanioTabla3 = 0;
                //Obtiene una lista de todas las posibles celdas a acomodar
                List<string> celdas = generarListaVentaDetallada(i);
                //Obtenemos los parametros necesarios para generar las tablas con el numero de celdas necesarias
                calcularPosicionesTabla(celdas.Count, ref tamanioTabla1, ref tamanioTabla2, ref tamanioTabla3);

                if (tamanioTabla1 > 0)
                {
                    //Comienza a dibujar la tabla
                    PdfPTable tabla1 = new PdfPTable(tamanioTabla1);
                    tabla1.TotalWidth = iTextSharp.text.PageSize.LETTER.Width - 120;
                    tabla1.LockedWidth = true;
                    tabla1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

                    PdfPCell cell = new PdfPCell(new Phrase("Venta detallada"));
                    cell.Colspan = tamanioTabla1;
                    cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right   
                    tabla1.AddCell(cell);

                    for (int j = 0; j < tamanioTabla1; j++)
                        tabla1.AddCell(celdas[j]);
                    doc.Add(tabla1);
                    if (tamanioTabla2 > 0)
                    {
                        PdfPTable table2 = new PdfPTable(tamanioTabla2);
                        table2.TotalWidth = iTextSharp.text.PageSize.LETTER.Width - 120;
                        //fix the absolute width of the table
                        table2.LockedWidth = true;

                        table2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

                        if (tamanioTabla3 <= 0)
                            for (int k = tamanioTabla1; k < celdas.Count; k++)
                                table2.AddCell(celdas[k]);
                        else
                            for (int k = tamanioTabla1; k < celdas.Count - tamanioTabla3; k++)
                                table2.AddCell(celdas[k]);

                        doc.Add(table2);
                    }

                    if (tamanioTabla3 > 0)
                    {
                        PdfPTable table3 = new PdfPTable(tamanioTabla3);
                        table3.TotalWidth = iTextSharp.text.PageSize.LETTER.Width - 120;
                        //fix the absolute width of the table
                        table3.LockedWidth = true;

                        table3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;


                        for (int k = tamanioTabla2 + tamanioTabla1; k < celdas.Count; k++)
                            table3.AddCell(celdas[k]);

                        doc.Add(table3);
                    }
                }
            }
            
        }

        private void datosPOS(ref Document doc)
        {              

            int tamanioTabla1 = 0;
            int tamanioTabla2 = 0;
            int tamanioTabla3 = 0;
            //Obtiene una lista de todas las posibles celdas a acomodar
            List<string> celdas = generarListaPOS();
            //Obtenemos los parametros necesarios para generar las tablas con el numero de celdas necesarias
            calcularPosicionesTabla(celdas.Count, ref tamanioTabla1, ref tamanioTabla2, ref tamanioTabla3);

            if (tamanioTabla1 > 0)
            {
                //Comienza a dibujar la tabla
                PdfPTable tabla1 = new PdfPTable(tamanioTabla1);
                tabla1.TotalWidth = iTextSharp.text.PageSize.LETTER.Width - 120;
                tabla1.LockedWidth = true;
                tabla1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

                PdfPCell cell = new PdfPCell(new Phrase("Datos de venta"));
                cell.Colspan = 4;
                cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right   
                tabla1.AddCell(cell);

                for (int j = 0; j < tamanioTabla1; j++)
                    tabla1.AddCell(celdas[j]);

                doc.Add(tabla1);
                if (tamanioTabla2 > 0)
                {
                    PdfPTable table2 = new PdfPTable(tamanioTabla2);
                    table2.TotalWidth = iTextSharp.text.PageSize.LETTER.Width - 120;
                    //fix the absolute width of the table
                    table2.LockedWidth = true;

                    table2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

                    if (tamanioTabla3 <= 0)
                        for (int k = tamanioTabla1; k < celdas.Count; k++)
                            table2.AddCell(celdas[k]);
                    else
                        for (int k = tamanioTabla1; k < celdas.Count - tamanioTabla3; k++)
                            table2.AddCell(celdas[k]);

                    doc.Add(table2);
                }

                if (tamanioTabla3 > 0)
                {
                    PdfPTable table3 = new PdfPTable(tamanioTabla3);
                    table3.TotalWidth = iTextSharp.text.PageSize.LETTER.Width - 120;
                    //fix the absolute width of the table
                    table3.LockedWidth = true;

                    table3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;


                    for (int k = tamanioTabla2 + tamanioTabla1; k < celdas.Count; k++)
                        table3.AddCell(celdas[k]);

                    doc.Add(table3);
                }
            }

        }

        private List<string> generarListaPOS()
        {
            List<string> celdas = new List<string>();

            if (this.frmPOS.chboxIdentificadorVenta.Checked)
            celdas.Add("Identificador de venta:\n" + preprocesarCadena(dataPDF[posDiccionario][0][0]));
            if (this.frmPOS.chboxFechaVentas.Checked)
            celdas.Add("Fecha:\n" + preprocesarCadena(dataPDF[posDiccionario][0][1]));
            if (this.frmPOS.chboxSubtotalVentas.Checked)
            celdas.Add("Subtotal:\n" + preprocesarCadena(dataPDF[posDiccionario][0][2]));
            if (this.frmPOS.chboxEstadoVentas.Checked)
            celdas.Add("Estado:\n" + preprocesarCadena(dataPDF[posDiccionario][0][3]));
            if (this.frmPOS.chboxAbiertaVentas.Checked)
            celdas.Add("Abierta:\n" + preprocesarCadena(dataPDF[posDiccionario][0][4]));
            if (this.frmPOS.chboxUsuarioCreadorVentas.Checked)
            celdas.Add("Creó:\n" + preprocesarCadena( obtenerNombreUsuario(dataPDF[posDiccionario][0][5])));

            return celdas;
        }

        private List<string> generarListaVentaDetallada(int i)
        {
            List<string> celdas = new List<string>();

            if (this.frmPOS.chboxIdentificadorVenta.Checked)
            celdas.Add("Identificador de venta:\n" + preprocesarCadena(dataPDF[posDiccionario][0][0]));
            if (this.frmPOS.chboxIdentificadorProductoVentaDetallada.Checked)
            celdas.Add("Identificador de producto:\n" + preprocesarCadena(dataPDF[posDiccionario][i][1]));
            if (this.frmPOS.chboxNombreVentasDetallas.Checked)
            celdas.Add("Nombre:\n" + preprocesarCadena(dataPDF[posDiccionario][i][2]));
            if (this.frmPOS.chboxMarcaVentaDetallada.Checked)
            celdas.Add("Marca:\n" + preprocesarCadena(dataPDF[posDiccionario][i][3]));
            if (this.frmPOS.chboxDescripcionVentaDetallada.Checked)
            celdas.Add("Descripcion:\n" + preprocesarCadena(dataPDF[posDiccionario][i][4]));
            if (this.frmPOS.chboxCantidadVentaDetallada.Checked)
            celdas.Add("Cantidad:\n" + preprocesarCadena(dataPDF[posDiccionario][i][5]));
            if (this.frmPOS.chboxPrecioVentaDetallada.Checked)
            celdas.Add("Precio:\n" + preprocesarCadena(dataPDF[posDiccionario][i][0]));
            if (this.frmPOS.chboxSubtotalVentaDetallada.Checked)
            celdas.Add("Subtotal:\n" + (Convert.ToDouble(dataPDF[posDiccionario][i][5]) * Convert.ToDouble(dataPDF[posDiccionario][i][0])));

            return celdas;
        }
      
        #endregion


    }
}
