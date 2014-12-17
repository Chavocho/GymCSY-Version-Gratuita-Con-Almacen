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
    public partial class frmLogin : Form
    {
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (tbxUsuario.Text.Equals("") || tbxPassword.Text.Equals(""))
               MessageBox.Show("Debes ingresar un usuario y una contraseña para poder acceder al sistema.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                try
                {
                    string sql = "Select * from usuarios where userName like '" + tbxUsuario.Text.Trim() + "' and password like '" + Clases.CFuncionesGenerales.GetHashString(tbxPassword.Text.Trim()) + "' limit 1";
                    DataTable respuesta = Clases.ConexionBD.EjecutarConsultaSelect(sql);
                    DataRow dr = respuesta.Rows[0];
                    if (tbxUsuario.Text.Equals(dr["userName"]) && Clases.CFuncionesGenerales.GetHashString(tbxPassword.Text.Trim()).Equals(dr["password"]))
                    {
                        Image img = null;
                        if (dr["imagen"] != DBNull.Value)
                            img = CFuncionesGenerales.BytesImagen((byte[])dr["imagen"]);
                        else
                            img=pbxUsuario.Image;
                        (new frmMain(Convert.ToInt32(dr["nivel"]), Convert.ToInt32(dr["id"]), tbxUsuario.Text, img)).Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("El Usuario y/o contraseña es incorrecta", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbxPassword.Text = "";
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("El Usuario y/o contraseña es incorrecta", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void tbxPassword_TextChanged(object sender, EventArgs e)
        {
            estadoTbxPass = true;
        }

    }
}
