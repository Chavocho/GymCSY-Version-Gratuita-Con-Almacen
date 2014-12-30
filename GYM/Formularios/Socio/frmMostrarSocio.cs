using System;
using System.Media;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using GYM.Clases;


namespace GYM.Formularios.Socio
{
    public partial class frmMostrarSocio : Form
    {
        private delegate void EnviarMensaje(string mensaje);

        int c = 0;
        DateTime horaIni, horaFin;
        CMiembro miembro = new CMiembro();
        CMiembro Persona = new CMiembro();
        Clases.CMembresia mem;
        int num_socio;
        bool ingresar=false;

        public frmMostrarSocio(int numSocio)
        {
            this.num_socio = numSocio;
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
            pbImagenPerfil.Image = CMiembro.ObtenerImagenSocio(numSocio);
            mem = new Clases.CMembresia(numSocio);
            mem.ObtenerDatosMiembro();
            btnAceptar.Select(); 
            miembro.ObtenerUsuarioPorID(numSocio);
            lblNombre.Text = miembro.Nombre;
            lblApellido.Text = miembro.Apellidos;
        }

        private void Mensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void HorasPromocion()
        {
            try
            {
                string sql = "SELECT hora_inicio, hora_fin FROM promocion_horario WHERE id='" + mem.IDPromocion + "'";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    horaIni = DateTime.Parse(DateTime.Now.ToString("dd-MM-yyyy ") + dr["hora_inicio"].ToString());
                    horaFin = DateTime.Parse(DateTime.Now.ToString("dd-MM-yyyy ") + dr["hora_fin"].ToString());
                }
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido obtener los horarios de la promoción del socio. Ocurrió un error al conectar con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido obtener los horarios de la promoción del socio. Ocurrió un error genérico.", ex);
            }
        }

        private bool TieneCortesia()
        {
            bool tiene = false;
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT fecha_ini, fecha_fin FROM cortesias WHERE numSocio=?numSocio";
                sql.Parameters.AddWithValue("?numSocio", num_socio);
                DataTable dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    DateTime fechaC = DateTime.Parse(dr["fecha_ini"].ToString());
                    if (fechaC.Date >= DateTime.Now.Date && fechaC.Date <= DateTime.Now.Date)
                    {
                        tiene = true;
                        lblFechaFinal.Text = fechaC.ToString("dd") + " de " + fechaC.ToString("MMMM") + " del " + fechaC.ToString("yyyy");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo obtener la fecha final de la cortesía.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
            return tiene;
        }

        private void formMostrarSocio_Load(object sender, EventArgs e)
        {
            string sonido = "";
            Application.DoEvents();
            Clases.CFuncionesGenerales.CargarInterfaz(this);
            lblInfo.ForeColor = Color.Orange;
            if (!ingresar)
            {
                btnAceptar.Enabled = false;
                btnCancelar.Text = "Regresar (3)";
                btnCancelar.Select();
            }
            DateTime fecha = new DateTime();
            DateTime fechaSocio = Persona.FechaFinalMembresia(num_socio);
            DateTime fechaX = DateTime.Now.AddDays(-5).Date;
            if (fechaSocio.Equals(fecha))
            {
                if (!TieneCortesia())
                {
                    lblInfo.ForeColor = Color.Red;
                    lblInfo.Visible = true;
                    lblInfo.Text = "¡No cuentas con una membresia!";
                    if (Clases.CFuncionesGenerales.sonidoRegMal != "Personalizado")
                        sonido = "SonidoError" + Clases.CFuncionesGenerales.sonidoRegMal.Substring(Clases.CFuncionesGenerales.sonidoRegMal.Length - 2, 2);
                    else
                        sonido = "SonidoErrorP";
                }
                else
                {
                    lblInfo.ForeColor = Color.LightSeaGreen;
                    lblInfo.Visible = true;
                    lblInfo.Text = "Cuentas con una cortesía";
                    if (Clases.CFuncionesGenerales.sonidoRegBien != "Personalizado")
                        sonido = "SonidoBien" + Clases.CFuncionesGenerales.sonidoRegBien.Substring(Clases.CFuncionesGenerales.sonidoRegBien.Length - 2, 2);
                    else
                        sonido = "SonidoBienP";
                }
            }
            else if (mem.Estado == Clases.CMembresia.EstadoMembresia.Activa || mem.Estado == Clases.CMembresia.EstadoMembresia.Pendiente)
            {
                if (mem.IDPromocion > 0)
                {
                    HorasPromocion();
                    TimeSpan horIni = horaIni.TimeOfDay, horFin = horaFin.TimeOfDay, horAct = DateTime.Now.TimeOfDay;
                    if (horAct >= horIni && horAct <= horFin)
                    {
                        lblInfo.ForeColor = Color.Lime;
                        lblInfo.Visible = true;
                        lblFechaFinal.Text = fechaSocio.ToString("dd") + " de " + fechaSocio.ToString("MMMM") + " del " + fechaSocio.ToString("yyyy");
                        ingresar = true;
                        if (Clases.CFuncionesGenerales.sonidoRegBien != "Personalizado")
                            sonido = "SonidoBien" + Clases.CFuncionesGenerales.sonidoRegBien.Substring(Clases.CFuncionesGenerales.sonidoRegBien.Length - 2, 2);
                        else
                            sonido = "SonidoBienP";
                    }
                    else
                    {
                        lblInfo.ForeColor = Color.Red;
                        lblInfo.Visible = true;
                        lblInfo.Text = "¡Tu membresía no cubre este horario!"; 
                        lblFechaFinal.Text = fechaSocio.ToString("dd") + " de " + fechaSocio.ToString("MMMM") + " del " + fechaSocio.ToString("yyyy");
                        if (Clases.CFuncionesGenerales.sonidoRegMal != "Personalizado")
                            sonido = "SonidoError" + Clases.CFuncionesGenerales.sonidoRegMal.Substring(Clases.CFuncionesGenerales.sonidoRegMal.Length - 2, 2);
                        else
                            sonido = "SonidoErrorP";
                    }
                }
                else if (fechaSocio.Equals(DateTime.Now.ToString("yyyy/MM/dd")) || fechaSocio <= (DateTime.Now))
                {
                    lblInfo.ForeColor = Color.Red;
                    lblInfo.Visible = true;
                    lblInfo.Text = "¡Tu membresia ha expirado!";
                    lblFechaFinal.Text = fechaSocio.ToString("dd") + " de " + fechaSocio.ToString("MMMM") + " del " + fechaSocio.ToString("yyyy");
                    if (Clases.CFuncionesGenerales.sonidoRegMal != "Personalizado")
                        sonido = "SonidoError" + Clases.CFuncionesGenerales.sonidoRegMal.Substring(Clases.CFuncionesGenerales.sonidoRegMal.Length - 2, 2);
                    else
                        sonido = "SonidoErrorP";
                }
                else if (fechaSocio.Date >= fechaX && fechaSocio.Date <= DateTime.Now.Date.AddDays(5))
                {
                    lblInfo.Visible = true;
                    lblInfo.Text = "Bienvenido\nTu membresia esta por expirar";
                    lblFechaFinal.Text = fechaSocio.ToString("dd") + " de " + fechaSocio.ToString("MMMM") + " del " + fechaSocio.ToString("yyyy");
                    ingresar = true;
                    if (Clases.CFuncionesGenerales.sonidoRegBien != "Personalizado")
                        sonido = "SonidoBien" + Clases.CFuncionesGenerales.sonidoRegBien.Substring(Clases.CFuncionesGenerales.sonidoRegBien.Length - 2, 2);
                    else
                        sonido = "SonidoBienP";
                }
                else
                {
                    lblInfo.ForeColor = Color.Lime;
                    lblInfo.Visible = true;
                    lblFechaFinal.Text = fechaSocio.ToString("dd") + " de " + fechaSocio.ToString("MMMM") + " del " + fechaSocio.ToString("yyyy");
                    ingresar = true;
                    if (Clases.CFuncionesGenerales.sonidoRegBien != "Personalizado")
                        sonido = "SonidoBien" + Clases.CFuncionesGenerales.sonidoRegBien.Substring(Clases.CFuncionesGenerales.sonidoRegBien.Length - 2, 2);
                    else
                        sonido = "SonidoBienP";
                }
            }
            else if (mem.Estado == Clases.CMembresia.EstadoMembresia.Rechazada)
            {
                lblInfo.ForeColor = Color.Red;
                lblInfo.Visible = true;
                lblInfo.Text = "¡Han rechazado tu membresía!";
                lblFecha.Visible = false;
                lblFechaFinal.Visible = false;
                if (Clases.CFuncionesGenerales.sonidoRegBien != "Personalizado")
                    sonido = "SonidoError" + Clases.CFuncionesGenerales.sonidoRegBien.Substring(Clases.CFuncionesGenerales.sonidoRegBien.Length - 2, 2);
                else
                    sonido = "SonidoErrorP";
            }
            else if (mem.Estado == Clases.CMembresia.EstadoMembresia.Inactiva)
            {
                lblInfo.ForeColor = Color.Red;
                lblInfo.Visible = true;
                lblInfo.Text = "¡Tu membresía ha terminado!";
                lblFecha.Visible = false;
                lblFechaFinal.Visible = false;
                if (Clases.CFuncionesGenerales.sonidoRegBien != "Personalizado")
                    sonido = "SonidoError" + Clases.CFuncionesGenerales.sonidoRegBien.Substring(Clases.CFuncionesGenerales.sonidoRegBien.Length - 2, 2);
                else
                    sonido = "SonidoErrorP";
            }
            lblInfo.Left = (this.Width - lblInfo.Width) / 2;
            if (Clases.CFuncionesGenerales.usarSonidos)
            {
                bgwSonido.RunWorkerAsync(sonido);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMostrarSocio_Shown(object sender, EventArgs e)
        {
            tmrCerrar.Enabled = true;
            
        }

        private void tmrCerrar_Tick(object sender, EventArgs e)
        {
            c++;
            if (c == 3)
            {
                this.Close();
            }
            else
            {
                btnCancelar.Text = "Regresar (" + (3 - c) + ")";
            }
        }

        private void bgwSonido_DoWork(object sender, DoWorkEventArgs e)
        {
            EnviarMensaje m = new EnviarMensaje(Mensaje);
            try
            {
                if (e.Argument.ToString() != "SonidoBienP" && e.Argument.ToString() != "SonidoErrorP")
                {
                    SoundPlayer sonido = new SoundPlayer(Application.StartupPath + "\\Sonidos\\" + e.Argument.ToString() + ".wav");
                    sonido.PlaySync();
                }
                else
                {
                    SoundPlayer sonido = new SoundPlayer(Application.StartupPath + "\\Sonidos\\" + e.Argument.ToString().Substring(0, e.Argument.ToString().Length - 1).ToLower() + ".wav");
                    sonido.PlaySync();
                }
            }
            catch (UriFormatException ex)
            {
                this.Invoke(m, "Ha ocurrido un error al reproducir el sonido, URI no valido:\n" + ex.Message);
            }
            catch (TimeoutException ex)
            {
                this.Invoke(m, "Ha ocurrido un error al reproducir el sonido, expiro la hora asiganada del proceso:\n" + ex.Message);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                this.Invoke(m, "Ha ocurrido un error al reproducir el sonido, no se encontro el archivo:\n" + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                this.Invoke(m, "Ha ocurrido un error al reproducir el sonido, la llamada al método no es valida:\n" + ex.Message);
            }
            catch (Exception ex)
            {
                this.Invoke(m, "Ha ocurrido un error al reproducir el sonido:\n" + ex.Message);
            }
        }

        
    }
}
