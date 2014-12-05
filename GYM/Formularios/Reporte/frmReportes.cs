using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using GYM.Clases;
using System.Threading;

namespace GYM.Formularios.Reporte
{
    public partial class frmReportes : Form
    {
        #region Instancia
        private static frmReportes frmInstancia;
        public static frmReportes Instancia
        {
            get
            {
                if (frmInstancia == null)
                    frmInstancia = new frmReportes();
                else if (frmInstancia.IsDisposed)
                    frmInstancia = new frmReportes();
                return frmInstancia;
            }
            set
            {
                frmInstancia = value;
            }
        }
        #endregion

        #region VARS
        bool buscarPorFecha;
        bool fullscreen;
        public frmEncabezados encabezado = new frmEncabezados();
        //constantes para generar repote
        private const int SOCIOS_MEMBRESIAS = 0;
        private const int TRABAJADOR = 1;
        private const int PRODUCTO = 2;
        private const int USUARIOS = 3;
        private const int CAJA = 4;
        private const int POS = 5;
        private frmVisorPDF visorPDF = new frmVisorPDF();
        //socios
        Thread threadSocio;
        //   frmDialogo dialogo = new frmDialogo();
        List<List<List<string>>> dataPDFSocio = new List<List<List<string>>>();
        int keySocio = 0;
        frmOpcionesAvanzadasSociosMembresias opcionesAvanzadasSociosMembresias;
        int celdaSeleccionaSocios = -1;
        string rutaSocioMembresia = "reporte.pdf";
        //Trabajador
        frmOpcionesAvanzadasTrabajador opcionesAvanzadasTrabajador;
        Thread threadTrabajador;
        int celdasSeleccionadaTrabajador = -1;
        // List<List<List<string>>> dataPDFTrabajador = new List<List<List<string>>>();
        List<List<List<string>>> dataPDFTrabajador;
        string rutaTrabajador = "reporte.pdf";
        //Producto
        Thread threadProducto;
        int celdasSeleccionadaProducto = -1;
        //Dictionary<int, List<List<string>>> dataPDFProducto = new Dictionary<int, List<List<string>>>();
        // List<List<List<string>>> dataPDFProducto = new List<List<List<string>>>();
        List<List<List<string>>> dataPDFProducto;
        frmOpcionesAvanzadasProducto opcionesAvanzadasProducto;
        string rutaProducto = "reporte.pdf";
        //Usuarios
        Thread threadUsuarios;
        int celdasSeleccionadaUsuarios = -1;
        //List<List<List<string>>> dataPDFUsuarios = new List<List<List<string>>>();
        List<List<List<string>>> dataPDFUsuarios;
        frmOpcionesAvanzadasUsuario opcionesAvanzadasUsuario;
        string rutaUsuario = "reporte.pdf";
        //Caja
        Thread threadCaja;
        int celdasSeleccionadaCaja = -1;
        // List<List<List<string>>> dataPDFCaja = new List<List<List<string>>>();
        List<List<List<string>>> dataPDFCaja;
        frmOpcionesAvanzadasCaja opcionesAvandasCaja;
        string rutaCaja = "reporte.pdf";
        //POS
        Thread threadPOS;
        int celdasSeleccionadaPOS = -1;
        //List<List<List<string>>> dataPDFPOS = new List<List<List<string>>>();
        List<List<List<string>>> dataPDFPOS;

        frmOpcionesAvanzadasPOS opcionesAvandasPOS;
        string rutaPOS = "reporte.pdf";
        #endregion

        bool frmOpcionesAvanzadasInicialidoProducto = false, frmOpcionesAvanzadasInicialidoPOS = false,
            frmOpcionesAvanzadasInicialidoCaja = false, frmOpcionesAvanzadasInicialidoUsuario = false;

        #region FORMULARIO

        public frmReportes()
        {
            InitializeComponent();
            fullscreen = true;

        }
        private void frmReportes_FormClosing(object sender, FormClosingEventArgs e)
        {
            visorPDF.Dispose();
            visorPDF.Close();
        }

        private void mostrarDialogoEspera()
        {
            Application.Run(new frmDialogo());
        }

        private void showSplashScreen()
        {
            using (frmDialogo fsplash = new frmDialogo())
            {
                if (fsplash.ShowDialog() == System.Windows.Forms.DialogResult.Cancel) this.Close();
            }
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
            comboxTipoAgreado.SelectedIndex = cboxTipoAgregadoPOS.SelectedIndex = cboxTipoAgregadoCaja.SelectedIndex = cboxTipoAgregadoUsuario.SelectedIndex = cboxTipoAgragadoProducto.SelectedIndex = 0;
            tabReportes.Width = this.Width;
            tabReportes.Height = this.Height - 40;
            dgvSocios.Width = tabReportes.TabPages[0].Width - 50;
            opcionesAvanzadasSociosMembresias = new frmOpcionesAvanzadasSociosMembresias();
        }

        private void fullScreen()
        {
            fullscreen = !fullscreen;
            if (fullscreen)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }

            tabReportes.Width = this.Width;
            tabReportes.Height = this.Height - 75;
            dgvSocios.Width = tabReportes.Width - 50;
        }
        private void tabReportes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
                this.Close();
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.N)
                fullScreen();
        }

        private void tabReportes_SelectedIndexChanged(object sender, EventArgs e)
        {

          /*  if (((TabControl)sender).SelectedIndex == 1 && !frmOpcionesAvanzadasInicialidoTrabajadores)//Trabajadores
            {
                dataPDFTrabajador = new List<List<List<string>>>();
                opcionesAvanzadasTrabajador = new frmOpcionesAvanzadasTrabajador();
                frmOpcionesAvanzadasInicialidoTrabajadores = true;
            }
            */
            if (((TabControl)sender).SelectedIndex == 1 && !frmOpcionesAvanzadasInicialidoProducto)//Productos
            {
                dataPDFProducto = new List<List<List<string>>>();
                opcionesAvanzadasProducto = new frmOpcionesAvanzadasProducto();
                frmOpcionesAvanzadasInicialidoProducto = true;
            }
            if (((TabControl)sender).SelectedIndex == 2 && !frmOpcionesAvanzadasInicialidoPOS)//Punto de venta
            {
                dataPDFPOS = new List<List<List<string>>>();
                opcionesAvandasPOS = new frmOpcionesAvanzadasPOS();
                frmOpcionesAvanzadasInicialidoPOS = true;
            }
            if (((TabControl)sender).SelectedIndex == 3 && !frmOpcionesAvanzadasInicialidoCaja)//Caja
            {
                dataPDFCaja = new List<List<List<string>>>();
                opcionesAvandasCaja = new frmOpcionesAvanzadasCaja();
                frmOpcionesAvanzadasInicialidoCaja = true;
            }
            if (((TabControl)sender).SelectedIndex == 4 && !frmOpcionesAvanzadasInicialidoUsuario)//Usuario
            {
                dataPDFUsuarios = new List<List<List<string>>>();
                opcionesAvanzadasUsuario = new frmOpcionesAvanzadasUsuario();
                frmOpcionesAvanzadasInicialidoUsuario = true;
            }
        }
        #endregion


        #region FUNCIONES GENERALES

        private string ObtenerRuta(int CONSTANTE)
        {
            

            switch (CONSTANTE)
            {
                case SOCIOS_MEMBRESIAS:
                    return  rutaSocioMembresia;
                case TRABAJADOR:
                    return rutaTrabajador;
                case PRODUCTO:
                    return rutaProducto;
                case USUARIOS:
                    return rutaUsuario;
                case CAJA:
                    return rutaCaja;
                case POS:
                    return rutaPOS;
                default:
                    return "";
            }
        }

        private bool GenerarReporte(int CONSTANTE)
        {
            CPDF generar = new CPDF();
            //Configuracion documento
            generar.AlturaFooter = 36;
            generar.AlturaHeader = 10;
            generar.FuenteCuerpo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11, iTextSharp.text.Font.NORMAL);
            generar.FuenteTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.BOLD);
            generar.MargenDerecho = 30;
            generar.MargenInferior = 30;
            generar.MargenIzquierdo = 30;
            generar.MargenSuperior = 130;
            generar.TamanioPagina = iTextSharp.text.PageSize.LETTER;
            generar.AnchoHeader = iTextSharp.text.PageSize.LETTER.Width - 120f;

            //Datos reporte
            generar.RutaLogo = "Img/logo.png";
            generar.TextoNumeroPagina = "Página ";

           /* try
            {
                visorPDF.pdf.src = "";
            }
            catch 
            {
                
            }
            */
            
            switch (CONSTANTE)
            {
                case SOCIOS_MEMBRESIAS:
                    if (dataPDFSocio.Count > 20)
                        MessageBox.Show("Por la cantidad de registros, puede que está operación tome un poco de tiempo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    generar.TipoReporte = "Socios y membresias";
                    generar.Generar(dataPDFSocio, opcionesAvanzadasSociosMembresias, ObtenerRuta(CONSTANTE));
                    break;
                case TRABAJADOR:
                    if (dataPDFTrabajador.Count > 20)
                        MessageBox.Show("Por la cantidad de registros, puede que está operación tome un poco de tiempo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    generar.TipoReporte = "Trabajadores";
                    generar.Generar(dataPDFTrabajador, opcionesAvanzadasTrabajador, ObtenerRuta(CONSTANTE));
                    break;
                case PRODUCTO:
                    if (dataPDFProducto.Count > 20)
                        MessageBox.Show("Por la cantidad de registros, puede que está operación tome un poco de tiempo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    generar.TipoReporte = "Productos";
                    generar.Generar(dataPDFProducto, opcionesAvanzadasProducto, ObtenerRuta(CONSTANTE));
                    break;
                case USUARIOS:
                    if (dataPDFUsuarios.Count > 20)
                        MessageBox.Show("Por la cantidad de registros, puede que está operación tome un poco de tiempo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    generar.TipoReporte = "Usuarios";
                    generar.Generar(dataPDFUsuarios, opcionesAvanzadasUsuario, ObtenerRuta(CONSTANTE));
                    break;
                case CAJA:
                    if (dataPDFCaja.Count > 20)
                        MessageBox.Show("Por la cantidad de registros, puede que está operación tome un poco de tiempo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    generar.TipoReporte = "Caja";
                    generar.Generar(dataPDFCaja, this.opcionesAvandasCaja, ObtenerRuta(CONSTANTE));
                    break;
                case POS:
                    if (dataPDFPOS.Count > 20)
                        MessageBox.Show("Por la cantidad de registros, puede que está operación tome un poco de tiempo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    generar.TipoReporte = "Punto de venta";
                    generar.Generar(dataPDFPOS, this.opcionesAvandasPOS, ObtenerRuta(CONSTANTE));
                    break;
                default:
                    return false;
            }
            return generar.StatusPDF;
        }

        private void GuardarReporte(int CONSTANTE)
        {
            try
            {
                if (GenerarReporte(CONSTANTE))
                {
                    SaveFileDialog guardar = new SaveFileDialog();
                    guardar.DefaultExt = "pdf";
                    guardar.Filter = "PDF |*.pdf";
                    guardar.AddExtension = true;
                    guardar.RestoreDirectory = true;
                    guardar.Title = "Guardar reporte";
                    guardar.InitialDirectory = "c:/";
                    if (guardar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (guardar.FileName != "")
                        {
                            File.Copy(ObtenerRuta(CONSTANTE), guardar.FileName);
                            MessageBox.Show("Archivo guardado con éxito", "Archivo Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }
                //else
                //MessageBox.Show("Se ha generado un error al interta almacenar reporte\nintentelo de nuevo", "Error al generar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Se ha generado un error al interta almacenar reporte\nintentelo de nuevo", "Error al generar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarVistaPrevia(int CONSTANTE)
        {
            try
            {
                if (GenerarReporte(CONSTANTE))
                    visorPDF.cargar(ObtenerRuta(CONSTANTE));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void EliminarRegistroSeleccionado(ref int celdaSeleccionada, ref DataGridView dgv, ref List<List<List<string>>> dataPDF)
        {
            try
            {

                if (celdaSeleccionada != -1)
                {
                    DialogResult eliminar = MessageBox.Show("Seguro que desea eliminar el registro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (eliminar == DialogResult.Yes)
                    {
                        dgv.Rows.Remove(dgv.Rows[celdaSeleccionada]);
                        dataPDF.Remove(dataPDF[celdaSeleccionada]);
                        MessageBox.Show("Se ha eliminado con éxito el registro seleccionado", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        celdaSeleccionada = -1;
                    }
                }
                else
                    MessageBox.Show("Selecciones un registro antes de eliminar", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch
            {
            }
        }

        private string GenerarSQL(int CONSTANTE,bool fecha = false)
        {
            switch (CONSTANTE)
            {
                case SOCIOS_MEMBRESIAS:
                    if (!this.tbxBuscar.Text.Equals(""))
                        return "SELECT  miembros.numSocio,nombre, " +
                           "apellidos,direccion,ciudad, estado,  telefono, celular, email, " +
                           "fecha_nac,create_user_id,update_user_id " +
                            " FROM  miembros   WHERE " +
                             " numSocio = '" + tbxBuscar.Text + "' OR " +
                             " nombre like '%" + tbxBuscar.Text + "%'  OR " +
                             " apellidos like '%" + tbxBuscar.Text + "%' ";
                    else
                        return "SELECT  miembros.numSocio,nombre, " +
                           "apellidos,direccion,ciudad, estado,  telefono, celular, email, " +
                           "fecha_nac,create_user_id,update_user_id " +
                            " FROM  miembros   WHERE 1";
                 
                case PRODUCTO:

                    if (!txtboxBuscarProducto.Text.Equals(""))
                        return " SELECT nombre,marca,descripcion,unidad,precio,costo,create_user_id,update_user_id " +
                                        " FROM  producto " +
                                       " WHERE " +
                                            " nombre LIKE '%" + txtboxBuscarProducto.Text.Trim() + "%' OR " +
                                           " marca LIKE '%" + txtboxBuscarProducto.Text.Trim() + "%' OR " +
                                           " precio = '" + txtboxBuscarProducto.Text.Trim() + "'";
                    else
                        return " SELECT nombre,marca,descripcion,unidad,precio,costo,create_user_id,update_user_id " +
                                        " FROM  producto " +
                                       " WHERE 1";
                    
                case POS:
                    if (chboxRespetarFechasPOS.Checked || fecha)
                    {
                        //Se respertará la fecha
                        if (!txtboxBuscarPOS.Text.Equals(""))
                            return " SELECT id,fecha,subtotal,estado,abierta,create_user_id FROM venta WHERE (fecha BETWEEN '" + dtpFechaInicioPOS.Value.ToString("yyyy-MM-dd") + " 00:00:00" + "' AND '" + dtpFechaFinPOS.Value.ToString("yyyy-MM-dd") + " 23:59:59" + "') AND  id = '" + txtboxBuscarPOS.Text + "'";
                        else
                            return " SELECT id,fecha,subtotal,estado,abierta,create_user_id FROM venta WHERE (fecha BETWEEN '" + dtpFechaInicioPOS.Value.ToString("yyyy-MM-dd") + " 00:00:00" + "' AND '" + dtpFechaFinPOS.Value.ToString("yyyy-MM-dd") + " 23:59:59" + "')";
                    }
                    else
                    {
                        if (!txtboxBuscarPOS.Text.Equals(""))
                            return " SELECT id,fecha,subtotal,estado,abierta,create_user_id FROM venta WHERE id = '" + txtboxBuscarPOS.Text + "'";
                        else
                            return " SELECT id,fecha,subtotal,estado,abierta,create_user_id FROM venta WHERE 1";
                    }
                case CAJA:
                    if (chboxRespetarFechasCaja.Checked || fecha)
                    {
                        if (!txtboxBuscarCaja.Text.Equals(""))
                            return "SELECT id_venta,efectivo,tarjeta,tipo_movimiento,fecha,descripcion FROM caja WHERE " +
                                        "id_venta = '" + txtboxBuscarCaja.Text + "' AND  " +
     " (fecha BETWEEN '" + dtpFechaInicioCaja.Value.ToString("yyyy-MM-dd") + " 00:00:00" + "' AND '" + dtpFechaFinCaja.Value.ToString("yyyy-MM-dd") + " 23:59:59" + "')";
                        else
                            return "SELECT id_venta,efectivo,tarjeta,tipo_movimiento,fecha,descripcion FROM caja WHERE (fecha BETWEEN '" + dtpFechaInicioCaja.Value.ToString("yyyy-MM-dd") + " 00:00:00" + "' AND '" + dtpFechaFinCaja.Value.ToString("yyyy-MM-dd") + " 23:59:59" + "')";
                    }
                    else
                    {
                        if (!txtboxBuscarCaja.Text.Equals(""))
                            return "SELECT id_venta,efectivo,tarjeta,tipo_movimiento,fecha,descripcion FROM caja WHERE " +
                                        "id_venta = '" + txtboxBuscarCaja.Text + "'";
                        else
                            return "SELECT id_venta,efectivo,tarjeta,tipo_movimiento,fecha,descripcion FROM caja WHERE 1";
                    }
                case USUARIOS:

                    if (!txtboxBuscarUsuario.Text.Equals(""))
                        return "SELECT * FROM usuarios WHERE " +
                          "id = '" + txtboxBuscarUsuario.Text.Trim() + "' OR userName like '%" + txtboxBuscarUsuario.Text.Trim() + "%'";
                    else
                        return "SELECT * FROM usuarios WHERE 1";
                   
                default:
                    return "";
            }
        }

        #endregion


        #region TAB SOCIO & MEMBRESIAS

        private void tabSocios_Click(object sender, EventArgs e)
        {

        }

        private void tbxBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckForIllegalCrossThreadCalls = false;
                this.threadSocio = new Thread(new ThreadStart(this.BuscarSocio));
                this.threadSocio.Start();
            }

        }

        private void BuscarSocio()
        {
            try
            {
                if (comboxTipoAgreado.SelectedIndex == 1)
                    limpiarDGV();
                
                DataTable busquedaSocio = Clases.ConexionBD.EjecutarConsultaSelect(GenerarSQL(SOCIOS_MEMBRESIAS));

      
                DataTable busquedaMembresia = null;
                DataTable busquedaMembresiaAll = null;
                foreach (DataRow dr in busquedaSocio.Rows)
                {
                    string tipoMembresia = "Sin información";
                    string tipoPago = "Sin información";
                    string statusMembresia = "";
                    string precioMembresia = "";

                    try
                    {
                        //Por cada socio buscamos su membresia
                        string sqlMembresia = "SELECT " +
                        " tipo,tipo_pago,folio_remision,folio_ticket,fecha_ini,fecha_fin,status, precio," +
                        " descripcion,create_user_id, tiempo " +
                        " FROM  membresias  WHERE numSocio = " + dr["numSocio"].ToString();
                        busquedaMembresia = Clases.ConexionBD.EjecutarConsultaSelect(sqlMembresia);
                        if (busquedaMembresia.Rows.Count > 0)
                        {
                            foreach (DataRow drm in busquedaMembresia.Rows)
                            {
                               tipoMembresia =  ObtenerTipoMembresia(Convert.ToInt32(drm["tipo"].ToString()));
                                if (Convert.ToInt32(drm["status"]) == 0)
                                    statusMembresia = "Inactiva";
                                else
                                    statusMembresia = "Activa";
                                precioMembresia = drm["precio"].ToString();
                                if (Convert.ToInt32(drm["tipo_pago"].ToString()) == 0)
                                    tipoPago = "Efectivo";
                                else
                                    tipoPago = "Tarjeta";
                            }
                        }

                        //Agregar todas las membresias pasadas
                        string sqlMembresiaAll = "SELECT fecha_reg,fecha_fin,tipo,descripcion,precio,usuario " +
                   " FROM  registro_membresias  WHERE numSocio = " + dr["numSocio"];
                        busquedaMembresiaAll = Clases.ConexionBD.EjecutarConsultaSelect(sqlMembresiaAll);

                    }
                    catch
                    { }

                   this.dgvSocios.Rows.Add(new object[] { 
                   dr["numSocio"],
                   dr["nombre"].ToString() + " " + dr["apellidos"].ToString(), 
                   dr["email"],
                   tipoMembresia,                   
                   precioMembresia,
                   tipoPago,statusMembresia
                   });

                    try
                    {
                        CrearTabla(dr, busquedaMembresia.Rows.Count>0?busquedaMembresia.Rows[0]:null, busquedaMembresiaAll.Rows);
                    }
                    catch (Exception e) 
                    { 
                        MessageBox.Show(e.Message,"Buscar Socio",MessageBoxButtons.OK,MessageBoxIcon.Error); 
                    }

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,"Buscar Socio",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }


        }

        private string ObtenerTipoMembresia(int tipo)
        {
            string tipoMembresia = "";
            switch (tipo)
            {
                case 0:
                    tipoMembresia = "SEMANA";
                    break;
                case 1:
                    tipoMembresia = "MENSUAL";
                    break;
                case 2:
                    tipoMembresia = "2 MESES";
                    break;
                case 3:
                    tipoMembresia = "3 MESES";
                    break;
                case 4:
                    tipoMembresia = "4 MESES";
                    break;
                case 5:
                    tipoMembresia = "5 MESES";
                    break;
                case 6:
                    tipoMembresia = "6 MESES";
                    break;
                case 7:
                    tipoMembresia = "7 MESES";
                    break;
                case 8:
                    tipoMembresia = "8 MESES";
                    break;
                case 9:
                    tipoMembresia = "9 MESES";
                    break;
                case 10:
                    tipoMembresia = "10 MESES";
                    break;
                case 11:
                    tipoMembresia = "11 MESES";
                    break;
                case 12:
                    tipoMembresia = "12 MESES";
                    break;
                default:
                    tipoMembresia = "";
                    break;
            }
            return tipoMembresia;
        }

        private void CrearTabla(DataRow drSocio, DataRow drMembresia, DataRowCollection drMembresiaAll)
        {

            //Datos usuario

            List<string> datosPersonales = new List<string>();
            datosPersonales.Add(drSocio["numSocio"].ToString());
            datosPersonales.Add(drSocio["nombre"].ToString() + " " + drSocio["apellidos"].ToString());
            datosPersonales.Add(drSocio["direccion"].ToString());
            datosPersonales.Add(drSocio["ciudad"].ToString());
            datosPersonales.Add(drSocio["estado"].ToString());
            datosPersonales.Add(drSocio["telefono"].ToString());
            datosPersonales.Add(drSocio["celular"].ToString());
            datosPersonales.Add(drSocio["email"].ToString());
            datosPersonales.Add(drSocio["fecha_nac"].ToString().Split(' ')[0]);
            datosPersonales.Add(drSocio["create_user_id"].ToString());
            datosPersonales.Add(drSocio["update_user_id"].ToString());

            //Membresia
            //Agregar datos de la tabla membresias
            List<string> datosMembresias = new List<string>();
            if (drMembresia != null)
            {                
                datosMembresias.Add(drMembresia["tipo"].ToString());
                datosMembresias.Add(drMembresia["tipo_pago"].ToString());
                datosMembresias.Add(drMembresia["folio_remision"].ToString());
                datosMembresias.Add(drMembresia["folio_ticket"].ToString());
                datosMembresias.Add(drMembresia["fecha_ini"].ToString().Split(' ')[0]);
                datosMembresias.Add(drMembresia["fecha_fin"].ToString().Split(' ')[0]);
                datosMembresias.Add(drMembresia["status"].ToString());
                datosMembresias.Add(drMembresia["descripcion"].ToString());
                datosMembresias.Add(drMembresia["create_user_id"].ToString());
                datosMembresias.Add(drMembresia["tiempo"].ToString());
            }

            //Validar si la variable  drMembresiaAll  es diferente de null
            //y si es así, cargar todas las membresias a una nueva variable
            List<string> datosMembresiasAll = new List<string>();

            if (drMembresiaAll != null)
                foreach (DataRow drAll in drMembresiaAll)
                {

                    datosMembresiasAll.Add(drAll["fecha_reg"].ToString().Split(' ')[0]);
                    datosMembresiasAll.Add(drAll["fecha_fin"].ToString().Split(' ')[0]);
                    datosMembresiasAll.Add(ObtenerTipoMembresia(Convert.ToInt32(drAll["tipo"].ToString())));
                    datosMembresiasAll.Add(drAll["descripcion"].ToString());
                    datosMembresiasAll.Add(drAll["precio"].ToString());
                    datosMembresiasAll.Add(drAll["usuario"].ToString());
                }

            dataPDFSocio.Add(new List<List<string>>() { datosPersonales, datosMembresias, datosMembresiasAll });

        }

        private void btnLimpiarTabla_Click(object sender, EventArgs e)
        {
            DialogResult limpiar = MessageBox.Show("Seguro que desea limpiar la tabla?", "Limpiar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (limpiar == DialogResult.Yes)
            {
                limpiarDGV();
                MessageBox.Show("Se ha limpiado la tabla con éxito", "Limpiar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            GuardarReporte(SOCIOS_MEMBRESIAS);
        }

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            GenerarVistaPrevia(SOCIOS_MEMBRESIAS);
        }

        private void btnOpcionesAvanzadas_Click(object sender, EventArgs e)
        {
            opcionesAvanzadasSociosMembresias.ShowInTaskbar = false;
            opcionesAvanzadasSociosMembresias.ShowDialog();
        }

        private void dgvSocios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            celdaSeleccionaSocios = e.RowIndex;
        }

        private void btnEliminarRegistroSeleccionado_Click(object sender, EventArgs e)
        {
            EliminarRegistroSeleccionado(ref celdaSeleccionaSocios, ref dgvSocios, ref  dataPDFSocio);
        }

        private void limpiarDGV()
        {
            dgvSocios.Rows.Clear();
            dataPDFSocio = new List<List<List<string>>>();
            keySocio = 0;
        }

        #endregion


        #region TAB TRABAJADORES (Deshabilitada Por el momento!!)
        /*
        private void btnSalirTrabajador_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpcionesAvanzadasTrabajador_Click(object sender, EventArgs e)
        {
            //opcionesAvanzadasTrabajador.ShowDialog();
        }

        private void txtboxBuscarTrabajador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckForIllegalCrossThreadCalls = false;
                this.threadTrabajador = new Thread(new ThreadStart(this.buscarTrabajador));
                this.threadTrabajador.Start();
            }

        }

        private void buscarTrabajador()
        {
            try
            {
                if (cboxTipoAgragadorTrabajador.SelectedIndex == 1)
                    limpiarDGVTrabajador();

                string sqlTrabajador = "SELECT " +
                                                " numTrabajador, nombre,apellidos, " +
                                                " direccion,ciudad,estado,telefono,celular,email,fecha_nac, " +
                                                " fecha_creacion,create_user_id,update_user_id " +

                                          " FROM " +
                                                " trabajadores " +
                                           " WHERE " +
                                                " numTrabajador = '" + txtboxBuscarTrabajador.Text.Trim() + "' OR " +
                                                " nombre like '%" + txtboxBuscarTrabajador.Text.Trim() + "%'  OR " +
                                                " apellidos like '% " + txtboxBuscarTrabajador.Text.Trim() + "%' ";

                DataTable selectTrabajador = ConexionBD.EjecutarConsultaSelect(sqlTrabajador);
                string telefono = "";
                DataTable selectRegistoTrabajador = null;
                foreach (DataRow dr in selectTrabajador.Rows)
                {
                    try
                    {
                        if (!dr["telefono"].ToString().Equals("") && dr["celular"].ToString().Equals(""))
                            telefono = (dr["telefono"].ToString());
                        else if (!dr["celular"].ToString().Equals("") && !dr["telefono"].ToString().Equals(""))
                            telefono = (dr["telefono"].ToString() + "/" + dr["celular"].ToString());
                        else
                            telefono = dr["celular"].ToString();

                        string registro_trabajadores = "SELECT * FROM registro_trabajadores WHERE numTrabajador = '" + dr["numTrabajador"].ToString() + "'";
                        selectRegistoTrabajador = ConexionBD.EjecutarConsultaSelect(registro_trabajadores);

                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }

                    this.dgvTrabajadores.Rows.Add(new object[] {
                    dr["numTrabajador"].ToString().ToUpper(),
                    dr["nombre"].ToString().ToUpper() + " " + dr["apellidos"].ToString().ToUpper(),
                    dr["direccion"].ToString().ToUpper() + " " + dr["ciudad"].ToString().ToUpper() + " " + dr["estado"].ToString().ToUpper(),
                    telefono,
                    dr["email"].ToString().ToUpper(),
                    dr["fecha_nac"]
                     });

                    try
                    {
                        crearDataPDFTrabajadores(dr, selectRegistoTrabajador);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message, "Crear data"); }


                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            
        }

        private void crearDataPDFTrabajadores(DataRow dr, DataTable selectRegistoTrabajador)
        {
            List<string> trabajador = new List<string>();


            trabajador.Add(dr["numTrabajador"].ToString());
            trabajador.Add(dr["nombre"].ToString().ToUpper() + " " + dr["apellidos"].ToString().ToUpper());
            trabajador.Add(dr["direccion"].ToString().ToUpper() + " ");
            trabajador.Add(dr["ciudad"].ToString().ToUpper());
            trabajador.Add(dr["estado"].ToString().ToUpper());
            trabajador.Add(dr["telefono"].ToString());
            trabajador.Add(dr["celular"].ToString());
            trabajador.Add(dr["email"].ToString());
            trabajador.Add(dr["fecha_nac"].ToString());
            trabajador.Add(dr["fecha_creacion"].ToString());
            trabajador.Add(dr["create_user_id"].ToString());
            trabajador.Add(dr["update_user_id"].ToString());

            List<List<string>> registroTrabajador = new List<List<string>>();

            registroTrabajador.Add(trabajador);

            if (selectRegistoTrabajador != null)
            {
                foreach (DataRow item in selectRegistoTrabajador.Rows)
                {
                    List<string> aux = new List<string>();
                    aux.Add(item["numTrabajador"].ToString());
                    aux.Add(item["fecha_modificacion"].ToString());
                    aux.Add(item["descripcion"].ToString());
                    aux.Add(item["usuario"].ToString());

                    registroTrabajador.Add(aux);
                }

            }


            dataPDFTrabajador.Add(registroTrabajador);

        }

        private void btnLimpiarTablaTrabajador_Click(object sender, EventArgs e)
        {
            DialogResult limpiar = MessageBox.Show("Seguro que desea limpiar la tabla?", "Limpiar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (limpiar == DialogResult.Yes)
            {
                limpiarDGVTrabajador();
                MessageBox.Show("Se ha limpiado la tabla con éxito", "Limpiar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvTrabajadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            celdasSeleccionadaTrabajador = e.RowIndex;
        }

        private void btnEliminarRegistroSeleccionadoTrabajador_Click(object sender, EventArgs e)
        {
           // EliminarRegistroSeleccionado(ref celdasSeleccionadaTrabajador, ref dgvTrabajadores, ref  dataPDFTrabajador);
        }

        private void limpiarDGVTrabajador()
        {
            try
            {

                dgvTrabajadores.Rows.Clear();
                celdasSeleccionadaTrabajador = -1;
                dataPDFTrabajador = new List<List<List<string>>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        private void btnVistaPreviaTrabajador_Click(object sender, EventArgs e)
        {
            //GenerarVistaPrevia(TRABAJADOR);
        }

        private void btnGenerarReporteTrabajador_Click(object sender, EventArgs e)
        {
            //GuardarReporte(TRABAJADOR);
        }
*/
        #endregion


        #region TAB PRODUCTO

        private void BuscarProducto()
        {
            try
            {
                if (cboxTipoAgragadoProducto.SelectedIndex == 1)
                    limpiarDGVProducto();

                DataTable busqueda = ConexionBD.EjecutarConsultaSelect(GenerarSQL(PRODUCTO));

                foreach (DataRow dr in busqueda.Rows)
                {


                    this.dgvProductos.Rows.Add(new object[]{
                        dr["nombre"].ToString().ToUpper(),
                        dr["marca"].ToString().ToUpper(),
                        dr["unidad"].ToString().ToUpper(),
                        dr["precio"],
                        dr["costo"],
                        dr["descripcion"].ToString().ToUpper()
                    });

                    try
                    {
                        crearDataPDFProductos(dr);
                    }
                    catch { }

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void crearDataPDFProductos(DataRow dr)
        {
            List<string> list = new List<string>();

            list.Add(dr["nombre"].ToString());
            list.Add(dr["marca"].ToString().ToUpper());
            list.Add(dr["descripcion"].ToString().ToUpper());
            list.Add(dr["unidad"].ToString().ToUpper());
            list.Add(dr["precio"].ToString().ToUpper());
            list.Add(dr["costo"].ToString());
            list.Add(dr["create_user_id"].ToString());
            list.Add(dr["update_user_id"].ToString());

            dataPDFProducto.Add(new List<List<string>>() { list });

        }

        private void txtboxBuscarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckForIllegalCrossThreadCalls = false;
                this.threadProducto = new Thread(new ThreadStart(this.BuscarProducto));
                this.threadProducto.Start();
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            celdasSeleccionadaProducto = e.RowIndex;
        }

        private void btnEliminarRegistroSeleccionadoProducto_Click(object sender, EventArgs e)
        {
            EliminarRegistroSeleccionado(ref celdasSeleccionadaProducto, ref dgvProductos, ref  dataPDFProducto);
        }



        private void btnLimpiarTabalProducto_Click(object sender, EventArgs e)
        {
            DialogResult limpiar = MessageBox.Show("Seguro que desea limpiar la tabla?", "Limpiar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (limpiar == DialogResult.Yes)
            {
                limpiarDGVProducto();
                MessageBox.Show("Se ha limpiado la tabla con éxito", "Limpiar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void limpiarDGVProducto()
        {
            try
            {

                dgvProductos.Rows.Clear();
                celdasSeleccionadaProducto = -1;
                dataPDFProducto = new List<List<List<string>>>();
            }
            catch 
            {
               // MessageBox.Show(ex.ToString());
               // throw;
            }
        }

        private void btnVistaPreviaProducto_Click(object sender, EventArgs e)
        {
            GenerarVistaPrevia(PRODUCTO);
        }

        private void btnGenerarReporteProducto_Click(object sender, EventArgs e)
        {
            GuardarReporte(PRODUCTO);
        }

        private void btnSalirProducto_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnOpcionesAvanzadasProductos_Click(object sender, EventArgs e)
        {
            opcionesAvanzadasProducto.ShowDialog();
        }


        #endregion


        #region TAB USUARIO

        private void btnSalirUsuario_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiarTablaUsuario_Click(object sender, EventArgs e)
        {
            dgvUsuario.Rows.Clear();
        }

        private void dgvUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            celdasSeleccionadaUsuarios = e.RowIndex;
        }

        private void btnEliminarRegistroUsuario_Click(object sender, EventArgs e)
        {
            EliminarRegistroSeleccionado(ref celdasSeleccionadaUsuarios, ref dgvUsuario, ref  dataPDFUsuarios);
        }

        private void txtboxBuscarUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckForIllegalCrossThreadCalls = false;
                this.threadUsuarios = new Thread(new ThreadStart(this.BuscarUsuario));
                this.threadUsuarios.Start();
            }
        }

        private void BuscarUsuario()
        {
            try
            {
                if (cboxTipoAgregadoUsuario.SelectedIndex == 1)
                    dgvUsuario.Rows.Clear();

                DataTable busqueda = ConexionBD.EjecutarConsultaSelect(GenerarSQL(USUARIOS));
                string nivelUsuario = "";
                foreach (DataRow dr in busqueda.Rows)
                {
                    if (dr["nivel"].ToString().Equals("3"))
                        nivelUsuario = "ADMINISTRATIVO";
                    else if (dr["nivel"].ToString().Equals("2"))
                        nivelUsuario = "ENCARGADO";
                    else
                        nivelUsuario = "Asistente";

                    this.dgvUsuario.Rows.Add(new object[]{
                            dr["userName"].ToString().ToUpper(),
                        nivelUsuario
                    });

                    try
                    {
                        crearDataPDFPUsuarios(dr, nivelUsuario);
                    }
                    catch { }

                }
            }
            catch
            {

            }
        }

        private void crearDataPDFPUsuarios(DataRow dr, string nivel)
        {
            List<string> list = new List<string>();
            list.Add(dr["userName"].ToString());
            list.Add(nivel);
            dataPDFUsuarios.Add(new List<List<string>>() { list });
        }

        private void btnVistaPreviaUsuario_Click(object sender, EventArgs e)
        {
            GenerarVistaPrevia(USUARIOS);
        }

        private void btnGenerarReporteUsuario_Click(object sender, EventArgs e)
        {
            GuardarReporte(USUARIOS);
        }

        private void btnOpcionesAvanzadasUsuarios_Click(object sender, EventArgs e)
        {

            opcionesAvanzadasUsuario.ShowDialog();
        }




        #endregion


        #region TAB CAJA

        private void dtpFechasCaja_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaInicioCaja.Value > dtpFechaFinCaja.Value)
                dtpFechaInicioCaja.Value = dtpFechaFinCaja.Value.AddDays(-1);
            if (dtpFechaFinCaja.Value < dtpFechaInicioCaja.Value)
                dtpFechaFinCaja.Value = dtpFechaInicioCaja.Value.AddDays(1);
            GenerarBusquedaCaja(true);
        }

        private void GenerarBusquedaCaja(bool fecha = false)
        {
           CheckForIllegalCrossThreadCalls = false;

            ThreadStart _ts = delegate { BuscarCaja(fecha); };
            threadPOS = new Thread(_ts);
            threadPOS.Start();
        }

        private void btnGenerarReporteCaja_Click(object sender, EventArgs e)
        {
            GuardarReporte(CAJA);
        }

        private void btnVistaPreviaCaja_Click(object sender, EventArgs e)
        {
            GenerarVistaPrevia(CAJA);
        }

        private void btnSalirCaja_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpcionesAvanzadasCaja_Click(object sender, EventArgs e)
        {
            opcionesAvandasCaja.ShowDialog();
        }

        private void btnLimpiarCaja_Click(object sender, EventArgs e)
        {
            dgvCaja.Rows.Clear();
        }

        private void btnEliminarRegistroSeleccionadoCaja_Click(object sender, EventArgs e)
        {
            EliminarRegistroSeleccionado(ref celdasSeleccionadaCaja, ref dgvCaja, ref  dataPDFCaja);
        }

        private void txtboxBuscarCaja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GenerarBusquedaCaja();
            }
        }

        private void BuscarCaja(bool fecha_ = false)
        {
            try
            {
                if (this.cboxTipoAgregadoCaja.SelectedIndex == 1)
                    dgvCaja.Rows.Clear();

                DataTable busqueda = ConexionBD.EjecutarConsultaSelect(GenerarSQL(CAJA,fecha_));

                foreach (DataRow dr in busqueda.Rows)
                {
                    string fecha = null;
                    fecha = DateTime.Parse(dr["fecha"].ToString()).ToString("dd")+" de "+DateTime.Parse(dr["fecha"].ToString()).ToString("MMMM")+" del "+DateTime.Parse(dr["fecha"].ToString()).ToString("yyyy");
                    string tipMov = "";
                    if (dr["tipo_movimiento"].ToString() == "0")
                        tipMov = "Entrada";
                    else
                        tipMov = "Salida";
                    this.dgvCaja.Rows.Add(new object[]{
                    dr["id_venta"],
                    decimal.Parse(dr["efectivo"].ToString()).ToString("C2"),
                    decimal.Parse(dr["tarjeta"].ToString()).ToString("C2"),
                    tipMov,
                    fecha,
                    dr["descripcion"]
                    });

                    string sqlSubtotal = "SELECT subtotal,create_user_id from venta WHERE id = '" + dr["id_venta"].ToString() + "'";
                    DataTable busqueaVenta = ConexionBD.EjecutarConsultaSelect(sqlSubtotal);
                    crearDataPDFCaja(dr,
                        busqueaVenta.Rows.Count == 0?null: busqueaVenta.Rows[0]["subtotal"].ToString(),
                        busqueaVenta.Rows.Count == 0?null:busqueaVenta.Rows[0]["create_user_id"].ToString());
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void crearDataPDFCaja(DataRow dr, string subtotal, string create_user_id)
        {
            List<string> list = new List<string>();

            list.Add(dr["id_venta"].ToString());
            list.Add(dr["efectivo"].ToString());
            list.Add(dr["tarjeta"].ToString());
            list.Add(dr["tipo_movimiento"].ToString());
            list.Add(DateTime.Parse(dr["fecha"].ToString()).ToString("dd") + " de " + DateTime.Parse(dr["fecha"].ToString()).ToString("MMMM") + " del " + DateTime.Parse(dr["fecha"].ToString()).ToString("yyyy"));
            list.Add(dr["descripcion"].ToString());

            if (subtotal != null)
            list.Add(subtotal);
            else
                list.Add("Sin información");

            if (create_user_id != null)
            list.Add(create_user_id);
            else
                list.Add("Sin información");

            dataPDFCaja.Add(new List<List<string>>() { list });
        }

        private void dgvCaja_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            celdasSeleccionadaCaja = e.RowIndex;
        }


        #endregion


        #region TAB POS

        private void dtpFechas_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaInicioPOS.Value > dtpFechaFinPOS.Value)
                dtpFechaInicioPOS.Value = dtpFechaFinPOS.Value.AddDays(-1);
            if (dtpFechaFinPOS.Value < dtpFechaInicioPOS.Value)
                dtpFechaFinPOS.Value = dtpFechaInicioPOS.Value.AddDays(1);
            generarBusquedaPOS(true);
        }

        private void chboxRespetarFechasPOS_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtboxBuscarPOS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                generarBusquedaPOS();
            }
        }

        private void generarBusquedaPOS(bool fecha = false)
        {
            CheckForIllegalCrossThreadCalls = false;

            ThreadStart _ts = delegate { BuscarPOS(fecha); };
            threadPOS = new Thread(_ts);
            threadPOS.Start();
            //mainTableGetter.Name = "GetMainTableAsync";
           // mainTableGetter.Start();

           // this.threadPOS = new Thread(new ThreadStart(this.BuscarPOS));
           // this.threadPOS.Start(true);
        }

        private void BuscarPOS(bool fecha = false)
        {
            try
            {
                if (this.cboxTipoAgregadoPOS.SelectedIndex == 1)
                    this.dgvPOS.Rows.Clear();

                DataTable busquedaVentas = ConexionBD.EjecutarConsultaSelect(GenerarSQL(POS, fecha));

                foreach (DataRow drVentas in busquedaVentas.Rows)
                {
                    List<List<string>> aux = new List<List<string>>();
                    string estado = "Cerrada";
                    if(Convert.ToBoolean(drVentas["estado"].ToString()))
                        estado = "Abierta";
                    aux.Add(new List<string>() { drVentas["id"].ToString(), drVentas["fecha"].ToString().Split(' ')[0], drVentas["subtotal"].ToString(), estado, drVentas["abierta"].ToString(), drVentas["create_user_id"].ToString() });
                    string sqlVentaDetallada = "SELECT id,id_venta,id_producto,cantidad FROM venta_detallada WHERE id_venta = '" + drVentas["id"].ToString() + "'";
                    DataTable busquedaVentaDetallada = ConexionBD.EjecutarConsultaSelect(sqlVentaDetallada);
                    foreach (DataRow drVentaDetallada in busquedaVentaDetallada.Rows)
                    {
                        List<string> venta_detallada = new List<string>();
                        venta_detallada.Add(drVentaDetallada["cantidad"].ToString());
                        string sqlProducto = "SELECT id,nombre,marca,descripcion,unidad,precio,costo FROM producto WHERE id = '" + drVentaDetallada["id_producto"].ToString() + "'";
                        DataTable busquedaProducto = ConexionBD.EjecutarConsultaSelect(sqlProducto);
                        foreach (DataRow drProducto in busquedaProducto.Rows)
                        {
                            venta_detallada.Add(drProducto["id"].ToString());
                            venta_detallada.Add(drProducto["nombre"].ToString());
                            venta_detallada.Add(drProducto["marca"].ToString());
                            venta_detallada.Add(drProducto["descripcion"].ToString());
                            venta_detallada.Add(drProducto["precio"].ToString());

                            this.dgvPOS.Rows.Add(new object[] { drVentas["id"].ToString(), drVentas["fecha"].ToString().Split(' ')[0], drProducto["id"].ToString(), drProducto["nombre"].ToString(), drProducto["marca"], drVentaDetallada["cantidad"], drProducto["precio"].ToString(), (Convert.ToDouble(drVentaDetallada["cantidad"]) * Convert.ToDouble(drProducto["precio"].ToString())) });
                        }
                        aux.Add(venta_detallada);
                    }
                    crearDataPDFPOS(aux);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void crearDataPDFPOS(List<List<string>> aux)
        {
            dataPDFPOS.Add(aux);
        }

        private void dgvPOS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            celdasSeleccionadaPOS = e.RowIndex;
        }

        private void btnEliminarRegistroSeleccionadoPOS_Click(object sender, EventArgs e)
        {
            EliminarRegistroSeleccionado(ref celdasSeleccionadaPOS, ref dgvPOS, ref  dataPDFPOS);
        }

        private void btnLimpiarPOS_Click(object sender, EventArgs e)
        {
            this.dgvPOS.Rows.Clear();
        }

        private void btnOpcionesAvanzadasPOS_Click(object sender, EventArgs e)
        {
            opcionesAvandasPOS.ShowDialog();
        }

        private void btnSaliarPOS_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVistaPreviaPOS_Click(object sender, EventArgs e)
        {
            GenerarVistaPrevia(POS);
        }

        #endregion

      





    }
}
