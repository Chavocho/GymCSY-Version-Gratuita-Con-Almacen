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
    public partial class frmEditarUsuario : Form
    {
        frmUsuarios frm;
        string id, pass;
        int nivel;

        public frmEditarUsuario(IWin32Window frm, string id)
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
            this.frm = (frmUsuarios)frm;
            this.id = id;
        }

        private void CargarNiveles()
        {
            switch (frmMain.nivelUsuario)
            {
                case 3:
                    cboNivel.Items.AddRange(new object[] { "Asistente", "Encargado", "Administrador" });
                    cboNivel.SelectedIndex = 2;
                    break;
                case 2:
                    cboNivel.Items.AddRange(new object[] { "Asistente", "Encargado" });
                    cboNivel.SelectedIndex = 1;
                    break;
                case 1:
                    cboNivel.Items.AddRange(new object[] { "Asistente" });
                    cboNivel.SelectedIndex = 0;
                    break;
            }
        }

        private void ObtenerDatosUsuario()
        {
            string sql = "SELECT * FROM usuarios WHERE id='" + id + "'";
            DataTable dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
            foreach (DataRow dr in dt.Rows)
            {
                lblNombreUsuario.Text = dr["userName"].ToString();
                pass = dr["password"].ToString();
                nivel = Convert.ToInt32(dr["nivel"]);
            }
        }

        private void EditarUsuario()
        {
            MySql.Data.MySqlClient.MySqlCommand sql = new MySql.Data.MySqlClient.MySqlCommand();
            sql.CommandText = "UPDATE usuarios SET password=?, nivel=? WHERE id='" + id + "'";
            if (chbContrasena.Checked)
                sql.Parameters.AddWithValue("@pass", Clases.CFuncionesGenerales.GetHashString(txtContra.Text));
            else
                sql.Parameters.AddWithValue("@pass", pass);
            sql.Parameters.AddWithValue("@niv", nivel);
            Clases.ConexionBD.EjecutarConsulta(sql);
        }

        private void EditarDataGrid()
        {
            int index = frm.dgvUsuarios.CurrentRow.Index;
            frm.dgvUsuarios[1, index].Value = lblNombreUsuario.Text;
            frm.dgvUsuarios[2, index].Value = cboNivel.Items[cboNivel.SelectedIndex];
        }

        private bool ValidarCampos()
        {
            if (chbContrasena.Checked)
            {
                if (txtAntiContra.Text.Trim() == "")
                {
                    MessageBox.Show("Debes ingresar la antigua contraseña para cambiarla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    if (Clases.CFuncionesGenerales.GetHashString(txtAntiContra.Text) != pass)
                    {
                        MessageBox.Show("Debes ingresar la antigua contraseña para cambiarla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
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
                    }
                }
            }
            return true;
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

        private void frmEditarUsuario_Load(object sender, EventArgs e)
        {
            ObtenerDatosUsuario();
            CargarNiveles();
        }

        private void chbContrasena_CheckedChanged(object sender, EventArgs e)
        {
            if (chbContrasena.Checked)
            {
                pnlContra.Visible = true;
                this.Size = new Size(this.Width, this.Height + 112);
            }
            else
            {
                pnlContra.Visible = false;
                this.Size = new Size(this.Width, this.Height - 112);
            }
            this.Location = new Point(this.Location.X, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                EditarUsuario(); 
                EditarDataGrid();
                MessageBox.Show("El usuario se ha modificado correctamente", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
