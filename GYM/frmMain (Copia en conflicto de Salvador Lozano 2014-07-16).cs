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

namespace GYM
{
    public partial class frmMain : Form
    {
        int segundos = 0;
        public static int id;
        public static int nivelUsuario;
        public static string rutaRespladoBD = System.Windows.Forms.Application.StartupPath + "\\backup\\";
        public static string rutaBD = System.Windows.Forms.Application.StartupPath + "\\gym.db";

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


        public frmMain(int nivelUsuario, int id)
        {
            InitializeComponent();
            frmMain.nivelUsuario = nivelUsuario;
            frmMain.id = id;
            if(nivelUsuario == 1)
            this.statusLblUsuario.Text = "Ayudante";
            else if (nivelUsuario == 2)
                this.statusLblUsuario.Text = "Encargado";
            else
                this.statusLblUsuario.Text = "Administrador";

            OcultarElementosBarra();

        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void opcionesDeRespaldoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void main_Load(object sender, EventArgs e)
        {
            Clases.CFuncionesGenerales.CargarInterfaz(this);
            this.BackgroundImage = Clases.CFuncionesGenerales.img;
            if (frmMain.nivelUsuario == 3)
                statusLblUsuario.Text = "Administrador";
            else if (frmMain.nivelUsuario == 2)
                statusLblUsuario.Text = "Encargado";
            else
                administraciònToolStripMenuItem.Enabled = false;
                
            statusLblFecha.Text = DateTime.Now.ToLongDateString().ToUpper();
            statusLblHora.Text = DateTime.Now.ToShortTimeString();
            tmrTiempo.Enabled = true;
            tmrCumpleaños.Enabled = true;
        }

        private void toolStripSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            List<Form> frm = new List<Form>();

            foreach (Form f in Application.OpenForms)
                frm.Add(f);

            foreach (Form f in frm)
            {
                if (!f.Name.Equals("frmMain") && !f.Name.Equals("frmLogin"))
                    f.Close();
            }

            (new Formularios.frmLogin()).Show();
        }

        private void toolStripSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tmrTiempo_Tick(object sender, EventArgs e)
        {
            statusLblHora.Text = DateTime.Now.ToShortTimeString();
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
            (new Formularios.frmRegistroEntradas(frmMain.nivelUsuario, frmMain.id)).Show();
        }

        private void administrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Formularios.Membresia.frmMembresia()).Show(this);
        }

        private void acercaDeGymCSYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Formularios.frmAcercaDe()).ShowDialog();
        }

        private void modificarInformacionPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMain.nivelUsuario == 1)
                (new Formularios.Empleado.formUsuarioComun(frmMain.nivelUsuario, frmMain.id)).ShowDialog();
            else
                (new Formularios.Empleado.formEncargadoAdministrador(frmMain.nivelUsuario, frmMain.id)).ShowDialog();
        }

        private void buscarSocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Formularios.Socio.frmMiembros()).Show();
            //(new Formularios.Membresia.frmVisualizarMembresia()).ShowDialog();
        }

        private void OcultarElementosBarra()
        {
            //Archivo
            toolStripOpciones.Visible = false;
            toolStripMenuItem1.Visible = false;
            //Informes
            //// informesToolStripMenuItem.Visible = false;
            //Productos
            ///////////// productosToolStripMenuItem1.Visible = false;
            //Poner invisible los subMenus de administracion
            //administrarSociosToolStripMenuItem.Visible = false;
            //administrarCasillerosToolStripMenuItem.Visible = false;
            //toolStripSeparator1.Visible = false;
            //administrarProductosToolStripMenuItem.Visible = false;
            //administrarVisitasDeInvitadosToolStripMenuItem.Visible = false;
            //toolStripSeparator2.Visible = false;
            //administrarVentasAnonimasToolStripMenuItem.Visible = false;
            //administrarGastosToolStripMenuItem.Visible = false;
            //toolStripSeparator3.Visible = false;
            //administrarToolStripMenuItem1.Visible = false;
            //historialDeRecibosToolStripMenuItem.Visible = false;
            //toolStripSeparator4.Visible = false;
            //Movimientos
            //movimientosToolStripMenuItem.Visible = false;
            //Instructores
            //instructoresToolStripMenuItem.Visible = false;
            //EDitar socio


            switch (frmMain.nivelUsuario)
            {
                case 1://Ayudante
                    
                    //Administracion
                    administraciònToolStripMenuItem.Visible = false;
                    //Submeu de socio

                    //Submenu de producto
                    agregarProductoToolStripMenuItem.Visible = false;
                break;
                case 2://Encargado
                break;
                case 3://Administrador
                break;
                
            }

        }

        private void toolStripSocios_Click(object sender, EventArgs e)
        {
            (new Formularios.Socio.frmMiembros()).Show(this);
        }

        private void puntodeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void ticketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Formularios.frmConfigurarTicket()).Show(this);
        }

        private void registrarEntradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Formularios.frmCaja()).Show();
        }

        private void ventaProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void agregarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void agregarDineroACajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bool.Parse(Clases.CConfiguracionXML.LeerConfiguración("caja", "estado")))
                (new Formularios.Caja.frmEntradaSalida(Formularios.Caja.frmEntradaSalida.Movimiento.Entrada)).ShowDialog(this);
            else
                if (MessageBox.Show("No puedes realizar operaciones de venta si la caja esta cerrada.\n¿Deseas abrirla?", "GymCSY", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                    (new Formularios.Caja.frmAbrirCaja()).ShowDialog(this);
        }

        private void agregarGastoDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bool.Parse(Clases.CConfiguracionXML.LeerConfiguración("caja", "estado")))
                (new Formularios.Caja.frmEntradaSalida(Formularios.Caja.frmEntradaSalida.Movimiento.Salida)).ShowDialog(this);
            else
                if (MessageBox.Show("No puedes realizar operaciones de venta si la caja esta cerrada.\n¿Deseas abrirla?", "GymCSY", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                    (new Formularios.Caja.frmAbrirCaja()).ShowDialog(this);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
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

        private void tmrCumpleaños_Tick(object sender, EventArgs e)
        {
            if (segundos == 300)
            {
                (new CMiembro(DateTime.Now)).Cumpleaños();
                tmrCumpleaños.Enabled = false;
            }
            else
                segundos += 1;
        }

        private void generalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Formularios.frmConfiguracionGeneral(this)).Show();
        }

        private void informesToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void panelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Formularios.Reporte.frmReportes()).ShowDialog();
        }

        private void elToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Formularios.PuntoDeVenta.frmProducto()).ShowDialog();
        }

        private void agregarProductoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            (new Formularios.PuntoDeVenta.frmAgregarProducto()).Show();
        }

        private void sociosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            (new Formularios.Socio.frmMiembros()).Show(this);
        }

        private void registroDeentradasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            (new Formularios.frmRegistroEntradas(frmMain.nivelUsuario, frmMain.id)).Show();
        }

        private void ticketToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            (new Formularios.frmConfigurarTicket()).Show();
        }

        private void puntoDeventaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            (new Formularios.POS.frmPuntoVenta()).Show();
        }

        private void generalToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            (new Formularios.frmConfiguracionGeneral(this)).Show(this);
        }

        private void administrarEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Formularios.PuntoDeVenta.frmInventario()).Show(this);
        }

        private void cumpleañosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new CMiembro(DateTime.Now)).Cumpleaños();
            tmrCumpleaños.Enabled = false;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                MessageBox.Show("Me entearon");
        }
    }
}
