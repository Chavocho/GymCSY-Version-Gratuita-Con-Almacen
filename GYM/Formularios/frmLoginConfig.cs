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
    public partial class frmLoginConfig : Form
    {
        public frmLoginConfig()
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
        }

        private bool VerificarUsuario(string nom, string pass)
        {
            bool existe = false;
            try
            {
                string sql = "SELECT id FROM usuarios WHERE userName='" + nom + "' AND password='" + Clases.CFuncionesGenerales.GetHashString(pass) + "' AND nivel=3";
                DataTable dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
                if (dt.Rows.Count > 0)
                    existe = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error.\n" + ex.Message, "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return existe;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (VerificarUsuario(txtUsuario.Text, txtPassword.Text))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("El usuario ingresado no existe, o no es de nivel administrador.\nVerifica los datos", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void frmLoginConfig_Shown(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }
    }
}
