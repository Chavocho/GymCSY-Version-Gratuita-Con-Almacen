using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using MySql.Data.MySqlClient;

namespace GYM
{
    public partial class frmMain : Form
    {
        int segundos = 0;
        public static int id;
        public static int nivelUsuario;
        public static string rutaRespladoBD = System.Windows.Forms.Application.StartupPath + "\\backup\\";
        public static string rutaBD = System.Windows.Forms.Application.StartupPath + "\\gym.db";

        #region Instancia
        private static frmMain frmInstancia;
        public static frmMain Instancia
        {
            get
            {
                if (frmInstancia == null)
                    frmInstancia = new frmMain();
                else if (frmInstancia.IsDisposed)
                    frmInstancia = new frmMain();
                return frmInstancia;

            }
            set
            {
                frmInstancia = value;
            }
        }
        #endregion

        private bool Respaldar(int tipoRespaldo)
        {
            //Mover funciones a otra clasae
            try
            {
                string ruta = rutaRespladoBD + "Respaldo " + DateTime.Now.ToShortDateString().Replace('/', '-');

                switch (tipoRespaldo)
                {
                    case 1://Respaldar BD
                        respadarBD(ruta + "\\BD\\");
                        break;
                    case 2://Respaldar Archivos multimedia
                        respaldarMultimedia(ruta);
                        break;
                    case 3: // Respaldar TODO
                        respadarBD(ruta + "\\BD\\");
                        respaldarMultimedia(ruta);
                        break;

                    default:
                        break;
                }

                TextWriter tw = new StreamWriter(ruta + "\\info.i", true);
                tw.WriteLine("\tRespaldo\n\n" +
                    "El respaldo fue creado por el usuario numero: <" + id +
                    ">\n\n Creado el:  <" + DateTime.Now.ToString() + ">");
                tw.Close();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        private void respadarBD(string ruta)
        {
            if (!Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
                File.Copy(rutaBD, ruta + "\\DataBase " + DateTime.Now.ToShortDateString().Replace('/', '-') + ".db");
            }
        }

        private void respaldarMultimedia(string ruta)
        {
            copiarCarpeta(System.Windows.Forms.Application.StartupPath, ruta);
            copiarCarpeta(System.Windows.Forms.Application.StartupPath + "\\photo", ruta + "\\photo");
        }

        private bool copiarCarpeta(string ruta, string rutaDestino)
        {
            try
            {
                string[] carpetas = Directory.GetDirectories(ruta);
                string nombre;
                string destino;
                foreach (string carpeta in carpetas)
                {
                    if (carpeta.Split('\\')[carpeta.Split('\\').Length - 1].Equals("backup"))
                        continue;
                    string[] archivos = Directory.GetFiles(carpeta);
                    Directory.CreateDirectory(rutaDestino + "\\" + carpeta.Split('\\')[carpeta.Split('\\').Length - 1]);
                    foreach (string archivo in archivos)
                    {
                        nombre = System.IO.Path.GetFileName(archivo);
                        destino = System.IO.Path.Combine(rutaDestino + "\\" + carpeta.Split('\\')[carpeta.Split('\\').Length - 1], nombre);
                        System.IO.File.Copy(archivo, destino);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public frmMain()
        {
            InitializeComponent();
            this.BackgroundImage = Clases.CFuncionesGenerales.img;
        }

        public void InformacionInicio(int nivelUsuario, int id, string nomUsu, Image img)
        {
            frmMain.nivelUsuario = nivelUsuario;
            frmMain.id = id;
            pcbUsuario.Image = img;
            if (nivelUsuario == 1)
                lblUsuario.Text = "Asistente: " + nomUsu;
            else if (nivelUsuario == 2)
                lblUsuario.Text = "Encargado: " + nomUsu;
            else
                lblUsuario.Text = "Administrador: " + nomUsu;
            lblUsuario.Location = new Point(this.Width - lblUsuario.Width - 30, lblUsuario.Location.Y); 
            OcultarElementosBarra();
        }

        private void main_Load(object sender, EventArgs e)
        {
            Clases.CFuncionesGenerales.CargarInterfaz(this);
            lblUsuario.ForeColor = Color.WhiteSmoke;
            if (!GYM.Clases.CFuncionesGenerales.versionGratuita)
                tmrCumpleaños.Enabled = true;
        }

        private void toolStripSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            List<Form> frms = new List<Form>();
            (new Formularios.frmLogin()).Show();
            foreach (Form frm in Application.OpenForms)
                frms.Add(frm);
            foreach (Form frm in frms)
                if (frm.Name != "frmLogin" && frm.Name != "frmMain")
                    frm.Close();
        }

        private void toolStripSalir_Click(object sender, EventArgs e)
        {
            try
            {
                
            Application.Exit();
            }
            catch 
            {
                MessageBox.Show("Se ha generado un error, favor de intentarlo de nuevo","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void ingresarSocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Formularios.Socio.frmAgregarMiembro()).ShowDialog();
        }

        private void editarSocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Formularios.Socio.frmEditarMiembro(1)).ShowDialog();
        }

        private void registroDeEntradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Formularios.frmRegistroEntradas.Instancia.Visible)
            {
                Formularios.frmRegistroEntradas.Instancia.ID = frmMain.id;
                Formularios.frmRegistroEntradas.Instancia.NivelUsuario = frmMain.nivelUsuario;
                Formularios.frmRegistroEntradas.Instancia.Show(this);
            }
        }

        private void administrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Formularios.Membresia.frmMembresia.Instancia.Visible)
            {
                Formularios.Membresia.frmMembresia.Instancia.Show(this);
            }
        }

        private void acercaDeGymCSYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Formularios.frmAcercaDe()).ShowDialog();
        }

        private void modificarInformacionPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Formularios.frmUsuarios.Instancia.Visible)
                Formularios.frmUsuarios.Instancia.Show();
        }


        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Formularios.Socio.frmMiembros()).Show();
        }

        private void OcultarElementosBarra()
        {
            switch (frmMain.nivelUsuario)
            {
                case 1://Ayudante
                    ElementosAyudante();
                    break;
                case 2://Encargado
                    ElementosEncargado();
                    break;
                case 3://Administrador
                    break;
                
            }
        }

        private void ElementosEncargado()
        {
            sonidosToolStripMenuItem.Visible = false;
            correoToolStripMenuItem.Visible = false;
            huellaDigitalToolStripMenuItem.Visible = false;
            baseDedatosToolStripMenuItem.Visible = false;
        }

        private void ElementosAyudante()
        {
            configuraciónToolStripMenuItem1.Visible = false;
            productosToolStripMenuItem.Visible = false;
            DetalladoCajaToolStripMenuItem.Visible = false;
            cortesDeCajaToolStripMenuItem.Visible = false;
            empleadoToolStripMenuItem.Visible = false;
            reportesToolStripMenuItem.Visible = false;
            pendientesToolStripMenuItem.Visible = false;
            preciosDemembresíasToolStripMenuItem.Visible = false;
            promocionesToolStripMenuItem.Visible = false;
           
        }

        private void toolStripSocios_Click(object sender, EventArgs e)
        {
            (new Formularios.Socio.frmMiembros()).Show(this);
        }


        private void ticketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Formularios.frmConfigurarTicket()).Show(this);
        }

        private void registrarEntradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GYM.Clases.CFuncionesGenerales.versionGratuita)
            {
                MessageBox.Show("Esta opción no está disponible en la versión gratuita de GymCSY .\nContacta con el proveedor para adquirir la versión completa.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!Formularios.frmCaja.Instancia.Visible)
                Formularios.frmCaja.Instancia.Show(this);
        }


        private void agregarDineroACajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GYM.Clases.CFuncionesGenerales.versionGratuita)
            {
                MessageBox.Show("Esta opción no está disponible en la versión gratuita de GymCSY .\nContacta con el proveedor para adquirir la versión completa.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (bool.Parse(Clases.CConfiguracionXML.LeerConfiguración("caja", "estado")))
            {
                Formularios.Caja.frmEntradaSalida frm = new Formularios.Caja.frmEntradaSalida();
                frm.TipoMovimiento = Formularios.Caja.frmEntradaSalida.Movimiento.Entrada;
                frm.ShowDialog(this);
            }
            else
                if (MessageBox.Show("No puedes realizar operaciones de venta si la caja esta cerrada.\n¿Deseas abrirla?", "GymCSY", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                    (new Formularios.Caja.frmAbrirCaja()).ShowDialog(this);
        }

        private void agregarGastoDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GYM.Clases.CFuncionesGenerales.versionGratuita)
            {
                MessageBox.Show("Esta opción no está disponible en la versión gratuita de GymCSY .\nContacta con el proveedor para adquirir la versión completa.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (bool.Parse(Clases.CConfiguracionXML.LeerConfiguración("caja", "estado")))
            {
                Formularios.Caja.frmEntradaSalida frm = new Formularios.Caja.frmEntradaSalida();
                frm.TipoMovimiento = Formularios.Caja.frmEntradaSalida.Movimiento.Salida;
                frm.ShowDialog(this);
            }
            else
                if (MessageBox.Show("No puedes realizar operaciones de venta si la caja esta cerrada.\n¿Deseas abrirla?", "GymCSY", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                    (new Formularios.Caja.frmAbrirCaja()).ShowDialog(this);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!GYM.Clases.CFuncionesGenerales.versionGratuita)
            {
                if (bool.Parse(Clases.CConfiguracionXML.LeerConfiguración("caja", "estado")))
                {
                    DialogResult d = MessageBox.Show("La caja se encuentra abierta, ¿Desea cerrarla?", "Advertencia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                    if (d == System.Windows.Forms.DialogResult.Yes)
                        (new Formularios.Caja.frmCerrarCaja()).ShowDialog(this);
                    else if (d == System.Windows.Forms.DialogResult.Cancel)
                        e.Cancel = true;
                }
            }
        }

        private void tmrCumpleaños_Tick(object sender, EventArgs e)
        {
            try
            {
                if (segundos == 300)
                {
                    (new CMiembro(DateTime.Now)).Cumpleaños(this);
                    tmrCumpleaños.Enabled = false;
                }
                else
                    segundos += 1;
            }
            catch (MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se ha podido mostrar a los socios que cumplen años. No se pudo conectar con la base de datos.", ex);
            }
            catch (InvalidOperationException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se ha podido mostrar a los socios que cumplen años. La llamada al método no es válida para el estado actual del objeto", ex);
            }
            catch (System.Threading.ThreadStateException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se ha podido mostrar a los socios que cumplen años. El ThreadState del hilo no es válido para el método invocado.", ex);
            }
            catch (OutOfMemoryException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se ha podido mostrar a los socios que cumplen años. No hay suficiente memoria para continuar la ejecución del programa.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se ha podido mostrar a los socios que cumplen años. El argumento dado al método no es válido.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se ha podido mostrar a los socios que cumplen años. Ha ocurrido un error genérico.", ex);
            }
        }

        private void generalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Formularios.frmConfiguracionGeneral.Instancia.Visible)
            {
                Formularios.frmConfiguracionGeneral.Instancia.Frm = this;
                Formularios.frmConfiguracionGeneral.Instancia.Show();
            }
        }

        private void respaldarBaseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Respaldar(1))
                MessageBox.Show("Se ha respaldao la Base de datos con éxito", "Respaldo Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Se ha generado un error al respaldao la Base de datos\n intentelo de nuevo", "Respaldo Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Respaldar(2))
                MessageBox.Show("Se ha respaldao la informacion multimedia con éxito", "Respaldo Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Se ha generado un error al respaldao la informacion multimedia\n intentelo de nuevo", "Respaldo Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void respaldartodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Respaldar(3))
                MessageBox.Show("Se ha respaldao todo los datos con éxito", "Respaldo Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Se ha generado un error al respaldao todo los datos\n intentelo de nuevo", "Respaldo Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void elToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GYM.Clases.CFuncionesGenerales.versionGratuita)
            {
                MessageBox.Show("Esta opción no está disponible en la versión gratuita de GymCSY .\nContacta con el proveedor para adquirir la versión completa.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!Formularios.PuntoDeVenta.frmProducto.Instancia.Visible)
            {
                Formularios.PuntoDeVenta.frmProducto.Instancia.Show(this);
            }
        }

        private void agregarProductoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (GYM.Clases.CFuncionesGenerales.versionGratuita)
            {
                MessageBox.Show("Esta opción no está disponible en la versión gratuita de GymCSY .\nContacta con el proveedor para adquirir la versión completa.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            (new Formularios.PuntoDeVenta.frmAgregarProducto()).ShowDialog(this);
        }

        private void sociosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!Formularios.Socio.frmMiembros.Instancia.Visible)
            {
                Formularios.Socio.frmMiembros.Instancia.Show(this);
            }
        }

        private void registroDeentradasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!Formularios.frmRegistroEntradas.Instancia.Visible)
            {
                Formularios.frmRegistroEntradas.Instancia.ID = frmMain.id;
                Formularios.frmRegistroEntradas.Instancia.NivelUsuario = frmMain.nivelUsuario;
                Formularios.frmRegistroEntradas.Instancia.Show(this);
            }
        }

        private void ticketToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (GYM.Clases.CFuncionesGenerales.versionGratuita)
            {
                MessageBox.Show("Esta opción no está disponible en la versión gratuita de GymCSY .\nContacta con el proveedor para adquirir la versión completa.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!Formularios.frmConfigurarTicket.Instancia.Visible)
            {
                Formularios.frmConfigurarTicket.Instancia.Show(this);
            }
        }

        private void puntoDeventaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (GYM.Clases.CFuncionesGenerales.versionGratuita)
            {
                MessageBox.Show("Esta opción no está disponible en la versión gratuita de GymCSY .\nContacta con el proveedor para adquirir la versión completa.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!Formularios.POS.frmPuntoVenta.Instancia.Visible)
                Formularios.POS.frmPuntoVenta.Instancia.Show();
            else
                Formularios.POS.frmPuntoVenta.Instancia.Select();
        }

        private void generalToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (GYM.Clases.CFuncionesGenerales.versionGratuita)
            {
                MessageBox.Show("Esta opción no está disponible en la versión gratuita de GymCSY .\nContacta con el proveedor para adquirir la versión completa.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!Formularios.frmConfiguracionGeneral.Instancia.Visible)
            {
                Formularios.frmConfiguracionGeneral.Instancia.Frm = this;
                Formularios.frmConfiguracionGeneral.Instancia.Show();
            }
        }


        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GYM.Clases.CFuncionesGenerales.versionGratuita)
            {
                MessageBox.Show("Esta opción no está disponible en la versión gratuita de GymCSY .\nContacta con el proveedor para adquirir la versión completa.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!Formularios.PuntoDeVenta.frmInventario.Instancia.Visible)
            {
                Formularios.PuntoDeVenta.frmInventario.Instancia.Show(this);
            }
        }

        private void cumpleañosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tmrCumpleaños.Enabled = false;
            if (GYM.Clases.CFuncionesGenerales.versionGratuita)
            {
                MessageBox.Show("Esta opción no está disponible en la versión gratuita de GymCSY .\nContacta con el proveedor para adquirir la versión completa.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CMiembro c = new CMiembro(DateTime.Now);
            c.Cumpleaños(this);
            System.Threading.Thread.Sleep(1000);
            if (c.hayCumpleañeros == false)
                MessageBox.Show("Hoy no hay cumpleañeros.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void baseDedatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Formularios.frmConfiguracionBaseDatos.Instancia.Visible)
            {
                Formularios.frmConfiguracionBaseDatos.Instancia.Show(this);
            }
        }


        private void huellaDigitalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GYM.Clases.CFuncionesGenerales.versionGratuita)
            {
                MessageBox.Show("Esta opción no está disponible en la versión gratuita de GymCSY .\nContacta con el proveedor para adquirir la versión completa.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            (new Formularios.frmConfigurarHuella()).ShowDialog(this);
        }

        private void sonidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GYM.Clases.CFuncionesGenerales.versionGratuita)
            {
                MessageBox.Show("Esta opción no está disponible en la versión gratuita de GymCSY .\nContacta con el proveedor para adquirir la versión completa.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!Formularios.frmConfiguracionSonido.Instancia.Visible)
            {
                Formularios.frmConfiguracionSonido.Instancia.Show();
            }
            else
            {
                Formularios.frmConfiguracionSonido.Instancia.Select();
            }
        }

        private void cortesíasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GYM.Clases.CFuncionesGenerales.versionGratuita)
            {
                MessageBox.Show("Esta opción no está disponible en la versión gratuita de GymCSY .\nContacta con el proveedor para adquirir la versión completa.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!Formularios.Membresia.frmCortesias.Instancia.Visible)
                Formularios.Membresia.frmCortesias.Instancia.Show();
            else
                Formularios.Membresia.frmCortesias.Instancia.Select();
        }

        private void cortesDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GYM.Clases.CFuncionesGenerales.versionGratuita)
            {
                MessageBox.Show("Esta opción no está disponible en la versión gratuita de GymCSY .\nContacta con el proveedor para adquirir la versión completa.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            (new Formularios.Caja.frmCortes()).ShowDialog(this);
        }

        private void correoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GYM.Clases.CFuncionesGenerales.versionGratuita)
            {
                MessageBox.Show("Esta opción no está disponible en la versión gratuita de GymCSY .\nContacta con el proveedor para adquirir la versión completa.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            (new Formularios.frmCorreos()).ShowDialog(this);
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bool.Parse(Clases.CConfiguracionXML.LeerConfiguración("caja", "estado")))
            {
                (new Formularios.Caja.frmCerrarCaja()).Show();
            }
            else
            {
                (new Formularios.Caja.frmAbrirCaja()).Show();
            }           
        }

        private void listaDeSociosInactivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Informes.frmSociosInactivos()).Show();
        }

        private void lockersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Formularios.frmLockers.Instancia.Visible)
                Formularios.frmLockers.Instancia.Show();
            else
                Formularios.frmLockers.Instancia.Select();
        }

        private void pendientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nivelUsuario < 2)
                return;
            if (!Formularios.frmPendientes.Instancia.Visible)
                Formularios.frmPendientes.Instancia.Show();
            else
                Formularios.frmPendientes.Instancia.Select();
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Formularios.Compras.frmCompras.Instancia.Visible)
                Formularios.Compras.frmCompras.Instancia.Show();
            else
                Formularios.Compras.frmCompras.Instancia.Select();
        }

        private void membresíasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Formularios.Reportes.frmReporteMembresíasSocio.Instancia.Visible)
                Formularios.Reportes.frmReporteMembresíasSocio.Instancia.Show();
            else
                Formularios.Reportes.frmReporteMembresíasSocio.Instancia.Select();
        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!Formularios.Reportes.frmReporteVentas.Instancia.Visible)
                Formularios.Reportes.frmReporteVentas.Instancia.Show();
            else
                Formularios.Reportes.frmReporteVentas.Instancia.Select();
        }

        private void preciosDemembresíasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Formularios.frmConfigurarMembresías.Instancia.Visible)
                Formularios.frmConfigurarMembresías.Instancia.Show();
            else
                Formularios.frmConfigurarMembresías.Instancia.Select();
        }

        private void promocionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Formularios.Membresia.frmPromociones.Instancia.Visible)
                Formularios.Membresia.frmPromociones.Instancia.Show();
            else
                Formularios.Membresia.frmPromociones.Instancia.Select();
        }

        private void frmMain_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                sonidosToolStripMenuItem.Visible = true;
                correoToolStripMenuItem.Visible = true;
                huellaDigitalToolStripMenuItem.Visible = true;
                baseDedatosToolStripMenuItem.Visible = true;
                configuraciónToolStripMenuItem1.Visible = true;
                productosToolStripMenuItem.Visible = true;
                DetalladoCajaToolStripMenuItem.Visible = true;
                cortesDeCajaToolStripMenuItem.Visible = true;
                empleadoToolStripMenuItem.Visible = true;
                reportesToolStripMenuItem.Visible = true;
                cortesíasToolStripMenuItem.Visible = true;
                pendientesToolStripMenuItem.Visible = true;
                preciosDemembresíasToolStripMenuItem.Visible = true;
                promocionesToolStripMenuItem.Visible = true;
            }
            else
            {
                OcultarElementosBarra();
            }
        }   
    }
}
