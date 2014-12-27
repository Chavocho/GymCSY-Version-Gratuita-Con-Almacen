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

namespace GYM.Formularios.Membresia
{
    public partial class frmPrecioMembresia : Form
    {
        int sexo;
        public frmPrecioMembresia(int sexo)
        {
            InitializeComponent();
            this.sexo = sexo;
            CFuncionesGenerales.CargarInterfaz(this);
        }

        private void CargarPrecio(int id)
        {
            try
            {
                string sql = "SELECT precio, descripcion FROM precio_membresia WHERE id='" + id + "' AND sexo='" + sexo + "'";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    txtPrecio.Text = dr["precio"].ToString();
                    txtDescripcion.Text = dr["descripcion"].ToString();
                    return;
                }
                txtPrecio.Text = "";
                txtDescripcion.Text = "";
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido cargar el precio de la duración seleccionada. Ocurrió un error al conectar la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido cargar el precio de la duración seleccionada. Ocurrió un error genérico.", ex);
            }
        }

        private void GuardarPrecio()
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "INSERT INTO precio_membresia (id, sexo, descripcion, precio, create_user_id, create_time) VALUES (?id, ?sexo, ?descripcion, ?precio, ?user, NOW()) " + 
                    "ON DUPLICATE KEY UPDATE descripcion=?descripcion, precio=?precio, update_user_id=?user, update_time=NOW();";
                sql.Parameters.AddWithValue("?id", cbxTipo.SelectedIndex);
                sql.Parameters.AddWithValue("?sexo", sexo);
                sql.Parameters.AddWithValue("?descripcion", txtDescripcion.Text);
                sql.Parameters.AddWithValue("?precio", decimal.Parse(txtPrecio.Text));
                sql.Parameters.AddWithValue("?user", frmMain.id);
                ConexionBD.EjecutarConsulta(sql);
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {   
                throw ex;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            CFuncionesGenerales.VerificarEsNumero(ref sender, ref e, false);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtPrecio.Text != "")
            {
                try
                {
                    GuardarPrecio();
                    MessageBox.Show("Se ha guardado correctamente el precio.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    CFuncionesGenerales.MensajeError("No se ha podido guardar el precio de la duración seleccionada. Ocurrió un error al conectar la base de datos.", ex);
                }
                catch (Exception ex)
                {
                    CFuncionesGenerales.MensajeError("No se ha podido guardar el precio de la duración seleccionada. Ocurrió un error genérico.", ex);
                }
            }
        }

        private void cbxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPrecio(cbxTipo.SelectedIndex);
        }
    }
}
