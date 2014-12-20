using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using AForge.Video;
using AForge.Video.DirectShow;
using System.IO;
using GYM.Clases;

namespace GYM.Formularios.Socio
{
    public partial class frmEditarMiembro : Form
    {
        bool loCerroReg = false, loCerroCon = false;
        int numSocio;
        CMiembro miem = new CMiembro();
        private bool ExisteDispositivo = false;
        private FilterInfoCollection DispositivoDeVideo;
        private VideoCaptureDevice FuenteDeVideo = null;
        public byte[] huella = null;

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
            pbxImagenPerfil.Image = Imagen;
        }

        #endregion

        #region Metodos
        public frmEditarMiembro(int numSocio)
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
            cbxEstado.SelectedIndex = 0;
            cbxSexo.SelectedIndex = 0;
            BuscarDispositivos();
            this.numSocio = numSocio;
            miem.ObtenerUsuarioPorID(numSocio);
        }

        private bool validarCampos()
        {
            if (txtNumSocio.Text == "")
            {
                MessageBox.Show("Debes haber ingresado un número de socio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Debes ingresar el nombre del socio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtApellidos.Text.Trim() == "")
            {
                MessageBox.Show("Debes ingresar los apellidos del socio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtDomicilio.Text.Trim() == "")
            {
                MessageBox.Show("Debes ingresar el domicilio del socio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtTel.Text == "")
            {
                if (txtCelular.Text == "")
                {
                    MessageBox.Show("Debes ingresar al menos un número teléfonico", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            else if (txtCelular.Text == "")
            {
                if (txtTel.Text == "")
                {
                    MessageBox.Show("Debes ingresar al menos un número teléfonico", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return true;
        }

        private void MostrarDatosMiembro()
        {
            DateTime dt;
            txtNumSocio.Text = miem.NumeroSocio.ToString();
            txtNombre.Text = miem.Nombre;
            txtApellidos.Text = miem.Apellidos;
            if (DateTime.TryParse(miem.FechaNacimiento.ToString(), out dt) && miem.FechaNacimiento >= dtpFechaNac.MinDate && miem.FechaNacimiento <= dtpFechaNac.MaxDate)
                dtpFechaNac.Value = dt;
            else
                dtpFechaNac.Value = DateTime.Now;
            cbxSexo.SelectedIndex = miem.Genero;
            txtDomicilio.Text = miem.Direccion;
            cbxEstado.Text = miem.Estado;
            txtCiudad.Text = miem.Ciudad;
            txtCelular.Text = miem.Celular;
            txtTel.Text = miem.Telefono;
            txtEmail.Text = miem.Email;
            pbxImagenPerfil.Image = CMiembro.ObtenerImagenSocio(miem.NumeroSocio);
            this.huella = miem.Huella;
        }
        #endregion

        private void frmEditarMiembro_Load(object sender, EventArgs e)
        {
            CFuncionesGenerales.CerrarHuellas();
            if (Clases.HuellaDigital.reader == null)
                btnHuella.Enabled = false;
            Clases.CFuncionesGenerales.CargarInterfaz(this);
            MostrarDatosMiembro();
        }

        private void txtNumSocio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.CFuncionesGenerales.VerificarEsNumero(ref sender, ref e, true);
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.CFuncionesGenerales.VerificarEsNumero(ref sender, ref e, true);
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.CFuncionesGenerales.VerificarEsNumero(ref sender, ref e, true);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarCampos())
                {
                    DialogResult dialogResult = MessageBox.Show("¿Los datos ingresados son correctos?", "Nuevo Miembro -GymCSY", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        CMiembro miembro = new CMiembro();
                        miembro.UpdateUser = frmMain.id;
                        miembro.NumeroSocio = int.Parse(txtNumSocio.Text);
                        miembro.Nombre = txtNombre.Text;
                        miembro.Direccion = txtDomicilio.Text;
                        miembro.Apellidos = txtApellidos.Text;
                        miembro.Ciudad = txtCiudad.Text;
                        miembro.Celular = txtCelular.Text;
                        miembro.Telefono = txtTel.Text;
                        miembro.Email = txtEmail.Text;
                        miembro.Estado = cbxEstado.Text;
                        miembro.FechaNacimiento = dtpFechaNac.Value;
                        miembro.Genero = cbxSexo.SelectedIndex;
                        miembro.Huella = huella;
                        miembro.ImagenMiembro = pbxImagenPerfil.Image;
                        //Guardar imagen
                        //Clases.CFuncionesGenerales.GuardarImagen(pbxImagenPerfil.Image, txtNumSocio.Text.Trim());
                        miembro.EditarMiembro();
                        MessageBox.Show("Socio actualizado Satisfactoriamente", "Actualizacion Socio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        System.Threading.Thread.Sleep(100);
                        CMiembro.ObtenerHuellas();
                        this.Close();
                    }
                    else
                        return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnTomarFoto_Click(object sender, EventArgs e)
        {
            if (btnTomarFoto.Text.Equals("Iniciar Camara"))
            {
                btnTomarFoto.Text = "Tomar Imagen";
                if (ExisteDispositivo)
                {
                    FuenteDeVideo = new VideoCaptureDevice(DispositivoDeVideo[cbxCamara.SelectedIndex].MonikerString);
                    FuenteDeVideo.NewFrame += new NewFrameEventHandler(Mostrar_Imagen);
                    FuenteDeVideo.Start();
                    cbxCamara.Enabled = false;
                }
                else
                    MessageBox.Show("No se encuentra ningún dispositivo de vídeo en el sistema\nPor lo tanto no se podran tomar fotografias.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                if (FuenteDeVideo.IsRunning)
                {
                    TerminarFuenteDeVideo();
                    btnTomarFoto.Text = "Iniciar Camara";
                }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEditarMiembro_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (FuenteDeVideo.IsRunning)
                    TerminarFuenteDeVideo();
            }
            catch (Exception) { }
        }

        private void btnHuella_Click(object sender, EventArgs e)
        {
            (new frmCapturarHuella(this)).ShowDialog(this);
        }

        private void frmEditarMiembro_FormClosed(object sender, FormClosedEventArgs e)
        {
            CFuncionesGenerales.AbrirHuellas();
        }
    }
}
