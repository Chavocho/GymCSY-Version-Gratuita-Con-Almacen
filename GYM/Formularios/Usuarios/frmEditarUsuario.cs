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
    public partial class frmEditarUsuario : Form
    {
        frmUsuarios frm;
        string id, pass;
        int nivel;
        private byte[] huella;

        public byte[] Huella
        {
            get { return huella; }
            set { huella = value; }
        }
        

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
                if (dr["imagen"] != DBNull.Value)
                    pcbImagenUsuario.Image = CFuncionesGenerales.BytesImagen((byte[])dr["imagen"]);
                if (dr["huella"] != DBNull.Value)
                    huella = (byte[])dr["huella"];
                else
                    huella = null;
            }
        }

        private void EditarUsuario()
        {
            MySql.Data.MySqlClient.MySqlCommand sql = new MySql.Data.MySqlClient.MySqlCommand();
            sql.CommandText = "UPDATE usuarios SET password=?password, nivel=?nivel, imagen=?imagen, huella=?huella WHERE id='" + id + "'";
            if (chbContrasena.Checked)
                sql.Parameters.AddWithValue("?password", Clases.CFuncionesGenerales.GetHashString(txtContra.Text));
            else
                sql.Parameters.AddWithValue("?password", pass);
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
            pnlContra.Enabled = chbContrasena.Checked;
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

        private void btnHuella_Click(object sender, EventArgs e)
        {
            (new Formularios.Socio.frmCapturarHuella(this)).ShowDialog();
        }
    }
}
