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
        frmUsuarios frm;

        public frmNuevoUsuario(IWin32Window frm)
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
            if (frm != null)
                this.frm = (frmUsuarios)frm;
        }

        private void InsertarUsuario()
        {
            MySql.Data.MySqlClient.MySqlCommand sql = new MySql.Data.MySqlClient.MySqlCommand();
            sql.CommandText = "INSERT INTO usuarios (userName, password, nivel) VALUES (?, ?, ?)";
            sql.Parameters.AddWithValue("@nom", txtNombreUsu.Text);
            sql.Parameters.AddWithValue("@pass", Clases.CFuncionesGenerales.GetHashString(txtContra.Text));
            sql.Parameters.AddWithValue("@niv", nivel);
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
    }
}
