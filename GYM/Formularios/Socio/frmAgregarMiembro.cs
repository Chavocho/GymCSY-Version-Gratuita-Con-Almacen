using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using GYM.Clases;


namespace GYM.Formularios.Socio
{
    public partial class frmAgregarMiembro : Form
    {
        bool loCerroReg = false, loCerroCon = false;
        public byte[] huella = null;
        private bool ExisteDispositivo = false;
        private FilterInfoCollection DispositivoDeVideo;
        private VideoCaptureDevice FuenteDeVideo = null;
        //private int numSocio = 0;

        public frmAgregarMiembro()
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
            cbxEstado.SelectedIndex = 0;
            cbxSexo.SelectedIndex = 0;
            BuscarDispositivos();
            try
            {
                DataTable dt = Clases.ConexionBD.EjecutarConsultaSelect("SELECT numSocio FROM miembros ORDER BY numSocio DESC LIMIT 1");

                if (dt.Rows.Count == 0)
                    txtNumSocio.Text = "1000";
                else
                {
                    DataRow dr = dt.Rows[0];
                    txtNumSocio.Text = (int.Parse(dr["numSocio"].ToString()) + 1).ToString();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo obtener el último número de miembro. No se pudo conectar a la base de datos.", ex);
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo obtener el último número de miembro. No se pudo dar formato a una variable.", ex);
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo obtener el último número de miembro. Hubo un desbordamiento.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo obtener el último número de miembro. El argumento dado al método es nulo y éste no lo acepta.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo obtener el último número de miembro. Ocurrio un error genérico.", ex);
            }
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
            pbxImagenPerfil.Image = Imagen;
        }

        #endregion

        private void Form_Load(object sender, EventArgs e)
        {
            CFuncionesGenerales.CerrarHuellas();
            if (Clases.HuellaDigital.reader == null)
                btnHuella.Enabled = false;
            Clases.CFuncionesGenerales.CargarInterfaz(this);
            cbxSexo.SelectedIndex = 0;
            cbxEstado.SelectedIndex = 13;
        }

        private bool validarCampos()
        {
            if (txtNumSocio.Text == "")
            {
                MessageBox.Show("Debes haber ingresado un número de socio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (tbxNombre.Text.Trim() == "")
            {
                MessageBox.Show("Debes ingresar el nombre del socio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (tbxApellidos.Text.Trim() == "")
            {
                MessageBox.Show("Debes ingresar los apellidos del socio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (tbxDomicilio.Text.Trim() == "")
            {
                MessageBox.Show("Debes ingresar el domicilio del socio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (tbxTel.Text == "")
            {
                if (tbxCelular.Text == "")
                {
                    MessageBox.Show("Debes ingresar al menos un número teléfonico", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            else if (tbxCelular.Text == "")
            {
                if (tbxTel.Text == "")
                {
                    MessageBox.Show("Debes ingresar al menos un número teléfonico", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return true;
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarCampos())
                {
                    DialogResult dialogResult = MessageBox.Show("¿Los datos ingresados son correctos?", "Nuevo Socio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        CMiembro miembro = new CMiembro();
                        miembro.CreateUser = frmMain.id;
                        miembro.NumeroSocio = int.Parse(txtNumSocio.Text);
                        miembro.Nombre = tbxNombre.Text;
                        miembro.Direccion = tbxDomicilio.Text;
                        miembro.Apellidos = tbxApellidos.Text;
                        miembro.Ciudad = tbxCiudad.Text;
                        miembro.Celular = tbxCelular.Text;
                        miembro.Telefono = tbxTel.Text;
                        miembro.Email = tbxEmail.Text;
                        miembro.Estado = cbxEstado.Text;
                        miembro.FechaNacimiento = timePickerFechaNac.Value;
                        miembro.Genero = cbxSexo.SelectedIndex;
                        miembro.Huella = huella;
                        miembro.ImagenMiembro = pbxImagenPerfil.Image;

                        //Guardar imagen
                        //Clases.CFuncionesGenerales.GuardarImagen(pbxImagenPerfil.Image, txtNumSocio.Text.Trim());
                        if (miembro.InsertarMiembro(miembro))
                        {
                            MessageBox.Show("Socio Agregado Satisfactoriamente", "Socio Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CMiembro.ObtenerHuellas();
                            this.Close();
                        }
                        else
                            MessageBox.Show("Ocurrio un error al ingresar el socio", "Socio Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        return;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de agregar el miembro. No se pudo conectar con la base de datos.", ex);
            }
            catch (System.Runtime.InteropServices.ExternalException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de agregar el miembro. Hubo un problema con la interoperabilidad COM.", ex);
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de agregar el miembro. Ha ocurrido un error al dar formato a una variable.", ex);
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de agregar el miembro. Ocurrio un desbordamiento.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de agregar el miembro. El argumento dado es nulo y el método no lo acepta.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de agregar el miembro. Ocurrio un error genérico.", ex);
            }
        }

        private void btnTomarFoto_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de tomar la foto del miembro.", ex);
            }
        }

        private void txtNumSocio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.CFuncionesGenerales.VerificarEsNumero(ref sender, ref e, true);
        }

        private void frmAgregarMiembro_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (FuenteDeVideo.IsRunning)
                    TerminarFuenteDeVideo();
            }
            catch
            {
            }
        }

        private void tbxCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.CFuncionesGenerales.VerificarEsNumero(ref sender, ref e, true);
        }

        private void tbxTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.CFuncionesGenerales.VerificarEsNumero(ref sender, ref e, true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuella_Click(object sender, EventArgs e)
        {
            (new frmCapturarHuella(this)).ShowDialog(this);
        }

        private void frmAgregarMiembro_FormClosed(object sender, FormClosedEventArgs e)
        {
            CFuncionesGenerales.AbrirHuellas();
        }

        private void cbxCamara_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            CFuncionesGenerales.VerificarEsNumero(ref sender, ref e, true);
        }
    }
}
