using AForge.Video;
using AForge.Video.DirectShow;
using GYM.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYM.Formularios
{
    public partial class frmNuevoUsuario : Form
    {
        int nivel = 0;
        byte[] huella = null;
        private bool ExisteDispositivo = false;
        private FilterInfoCollection DispositivoDeVideo;
        private VideoCaptureDevice FuenteDeVideo = null;

        public byte[] Huella
        {
            get { return huella; }
            set { huella = value; }
        }

        frmUsuarios frm;

        public frmNuevoUsuario(IWin32Window frm)
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this); 
            BuscarDispositivos();
            if (frm != null)
                this.frm = (frmUsuarios)frm;
        }

        #region Funciones Camara

        /*
         * Función con la cual se cargan los dispositivos (camaras conectadas a la computadora).
         * Recibe como parametro FilterInfoCollection @var Dispositivos
         */
        public void CargarDispositivos(FilterInfoCollection Dispositivos)
        {
            for (int i = 0; i < Dispositivos.Count; i++)
                cbxCamara.Items.Add(Dispositivos[i].Name.ToString());
            cbxCamara.Text = cbxCamara.Items[0].ToString();
        }

        /*
         * BuscarDispositivos() verifica si existen webcams conectadas a la computadora
         * return @var bool ExisteDispositivo
         */
        public void BuscarDispositivos()
        {
            DispositivoDeVideo = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (DispositivoDeVideo.Count == 0)
                ExisteDispositivo = false;
            else
            {
                ExisteDispositivo = true;
                CargarDispositivos(DispositivoDeVideo);
            }
        }

        /*
         * TerminarFuenteVideo()
         * Cierra la conexión con la webcam.
         */
        public void TerminarFuenteDeVideo()
        {
            if (!(FuenteDeVideo == null))
                if (FuenteDeVideo.IsRunning)
                {
                    FuenteDeVideo.SignalToStop();
                    FuenteDeVideo = null;
                }
        }

        public void Mostrar_Imagen(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap Imagen = (Bitmap)eventArgs.Frame.Clone();
            pcbImagenUsuario.Image = Imagen;
        }

        #endregion

        private void InsertarUsuario()
        {
            MySql.Data.MySqlClient.MySqlCommand sql = new MySql.Data.MySqlClient.MySqlCommand();
            sql.CommandText = "INSERT INTO usuarios (userName, password, nivel, imagen, huella) " +
                "VALUES (?userName, ?password, ?nivel, ?imagen, ?huella)";
            sql.Parameters.AddWithValue("?userName", txtNombreUsu.Text);
            sql.Parameters.AddWithValue("?password", Clases.CFuncionesGenerales.GetHashString(txtContra.Text));
            sql.Parameters.AddWithValue("?nivel", nivel);
            if (pcbImagenUsuario.Image != null)
                sql.Parameters.AddWithValue("?imagen", CFuncionesGenerales.ImagenBytes(pcbImagenUsuario.Image));
            else
                sql.Parameters.AddWithValue("?imagen", DBNull.Value);
            if (huella != null)
                sql.Parameters.AddWithValue("?huella", huella);
            else
                sql.Parameters.AddWithValue("?huella", DBNull.Value);
            Clases.ConexionBD.EjecutarConsulta(sql);
        }

        private void CargarNiveles()
        {
            switch (frmMain.nivelUsuario)
            {
                case 3:
                    cboNivel.Items.AddRange(new object[] { "Asistente", "Encargado", "Administrador" });
                    break;
                case 2:
                    cboNivel.Items.AddRange(new object[] { "Asistente", "Encargado" });
                    break;
                case 1:
                    cboNivel.Items.AddRange(new object[] { "Asistente" });
                    break;
                default:
                    cboNivel.Items.AddRange(new object[] { "Administrador" });
                    break;
            }
        }

        private bool ValidarCampos()
        {
            if (txtNombreUsu.Text.Trim() == "")
            {
                MessageBox.Show("El nombre de usuario es un campo obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtContra.Text.Trim() == "")
            {
                MessageBox.Show("La contraseña es un campo obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (txtContra.Text != txtRepContra.Text)
                {
                    MessageBox.Show("Las contraseñas no coinciden, verífiquelas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void frmNuevoUsuario_Load(object sender, EventArgs e)
        {
            CFuncionesGenerales.CerrarHuellas();
            CargarNiveles();
            cboNivel.SelectedIndex = 0;
        }

        private void cboNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNivel.Items[cboNivel.SelectedIndex].ToString() == "Administrador")
                nivel = 3;
            else if (cboNivel.Items[cboNivel.SelectedIndex].ToString() == "Encargado")
                nivel = 2;
            else
                nivel = 1;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                InsertarUsuario();
                if (frm != null)
                    frm.CargarUsuarios();
                MessageBox.Show("El usuario se ha agregado correctamente", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void pcbImagenUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Archivos de imagen (*.jpeg, *.jpg) | *.jpeg;*.jpg";
                ofd.Multiselect = false;
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                DialogResult r = ofd.ShowDialog();
                if (r == System.Windows.Forms.DialogResult.OK)
                {
                    pcbImagenUsuario.Image = new Bitmap(ofd.FileName);
                }
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("Ocurrió un error al seleccionar la imagen. Hubo un error genérico.", ex);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            pcbImagenUsuario.Image = null;
        }

        private void frmNuevoUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            CFuncionesGenerales.AbrirHuellas();
        }

        private void btnHuella_Click(object sender, EventArgs e)
        {
            if (!Clases.CConfiguracionXML.ExisteConfiguracion("huella", "lector"))
                MessageBox.Show("No se ha configurado un lector de huella digital", "Gym CSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                (new Formularios.Socio.frmCapturarHuella(this)).ShowDialog();
        }

        private void btnCamara_Click(object sender, EventArgs e)
        {
            if (ExisteDispositivo)
            {
                if (FuenteDeVideo == null)
                {
                    FuenteDeVideo = new VideoCaptureDevice(DispositivoDeVideo[cbxCamara.SelectedIndex].MonikerString);
                    FuenteDeVideo.NewFrame += new NewFrameEventHandler(Mostrar_Imagen);
                    FuenteDeVideo.Start();
                    cbxCamara.Enabled = false;
                }
                else
                {
                    TerminarFuenteDeVideo();
                    cbxCamara.Enabled = true;
                }
            }
        }
    }
}
