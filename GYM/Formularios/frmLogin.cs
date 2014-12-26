using GYM.Clases;
using MySql.Data.MySqlClient;
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
    public partial class frmLogin : Form
    {
        delegate void Imagen(Image img);
        Image img;
        bool estadoTbxUsuario = false, estadoTbxPass = false;
        public frmLogin()
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
            //Validar si es la primera ejecucion
            try
            {
                DataTable data = Clases.ConexionBD.EjecutarConsultaSelect("select * from usuarios where nivel = 3");
                if (data.Rows.Count == 0)
                {
                    DialogResult resultado = MessageBox.Show("No hay usuario registrados que puedan operar el software.\nFavor de registrar un usuario", "No hay usuarios registrados", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if (resultado == System.Windows.Forms.DialogResult.OK)
                        (new Formularios.frmNuevoUsuario(null)).ShowDialog();
                    else
                    {
                        DialogResult respuesta = MessageBox.Show("Si no genera un usuario no podrá utlizar el software.\nSi presiona Aceptar el software se cerrará, presione cancelar para agregar usuario.", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        //Cierra la aplicacion
                        if (respuesta == System.Windows.Forms.DialogResult.OK)
                            Application.Exit();
                        else
                            (new Formularios.frmNuevoUsuario(null)).ShowDialog(this);
                    }
                }

            }
            catch (Exception)
            {
            }
        }

        private void ImagenUsuario(string userName)
        {
            Imagen i = new Imagen(ImagenUsuario);
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT imagen FROM usuarios WHERE userName=?userName";
                sql.Parameters.AddWithValue("?userName", userName);
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    img = CFuncionesGenerales.BytesImagen((byte[])dr["imagen"]);
                    this.Invoke(i, img);
                    return;
                }
            }
            catch
            {
            }
            this.Invoke(i, GYM.Properties.Resources.ImgLogin);
        }

        private void ImagenUsuario(Image img)
        {
            pbxUsuario.Image = img;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (tbxUsuario.Text.Equals("") || tbxPassword.Text.Equals(""))
            {
                MessageBox.Show("Debes ingresar un usuario y una contraseña para poder acceder al sistema.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string sql = "SELECT * FROM usuarios WHERE userName='" + tbxUsuario.Text + "' AND password='" + CFuncionesGenerales.GetHashString(tbxPassword.Text) + "'";
                    DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (tbxUsuario.Text.Equals(dr["userName"]) && Clases.CFuncionesGenerales.GetHashString(tbxPassword.Text.Trim()).Equals(dr["password"]))
                        {
                            Image img = null;
                            if (dr["imagen"] != DBNull.Value)
                                img = CFuncionesGenerales.BytesImagen((byte[])dr["imagen"]);
                            else
                                img = pbxUsuario.Image;
                            (new frmMain(Convert.ToInt32(dr["nivel"]), Convert.ToInt32(dr["id"]), tbxUsuario.Text, img)).Show();
                            this.Close();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("El Usuario y/o contraseña es incorrecta.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbxPassword.Text = "";
                            return;
                        }
                    }
                    MessageBox.Show("El usuario y/o contraseña es incorrecta.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbxPassword.Text = "";
                }
                catch (MySqlException ex)
                {
                    CFuncionesGenerales.MensajeError("Ocurrió un error al verificar los datos del usuario. No se ha podido conectar con la base de datos.", ex);
                    tbxPassword.Text = "";
                }
                catch (Exception ex)
                {
                    CFuncionesGenerales.MensajeError("Ocurrió un error al verificar los datos del usuario. Ocurrió un error genérico.", ex);
                    tbxPassword.Text = "";
                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            Application.DoEvents();
            Clases.CFuncionesGenerales.CargarInterfaz(this);
            tbxUsuario.Select();
        }

        private void tbxUsuario_MouseClick(object sender, MouseEventArgs e)
        {
            if (!estadoTbxUsuario)
                this.tbxUsuario.Text = "";
            estadoTbxUsuario = true;
        }

        private void tbxPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (!estadoTbxPass)
                this.tbxPassword.Text = "";
            estadoTbxPass = true;
        }

        private void tbxUsuario_TextChanged(object sender, EventArgs e)
        {
            estadoTbxUsuario = true;
        }

        private void tbxUsuario_LostFocus(object sender, EventArgs e)
        {
            if (!bgwImagen.IsBusy)
                bgwImagen.RunWorkerAsync(tbxUsuario.Text);
        }

        private void tbxPassword_TextChanged(object sender, EventArgs e)
        {
            estadoTbxPass = true;
        }

        private void bgwImagen_DoWork(object sender, DoWorkEventArgs e)
        {
            ImagenUsuario(e.Argument.ToString());
        }

    }
}
