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
    public partial class frmEditarPromocionHorario : Form
    {
        int id;
        public frmEditarPromocionHorario(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void ObtenerDatosPromocion()
        {
            try
            {
                string sql = "SELECT * FROM promocion_horario WHERE id='" + id + "'";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    DateTime fechaCreacion = (DateTime)dr["create_time"], fechaModificacion = new DateTime();
                    if (dr["update_time"] != DBNull.Value)
                        fechaModificacion = (DateTime)dr["update_time"];
                    dtpHoraInicio.Value = (DateTime)dr["hora_inicio"];
                    dtpHoraFin.Value = (DateTime)dr["hora_fin"];
                    txtDescripcion.Text = dr["descripcion"].ToString();
                    txtPrecio.Text = dr["precio"].ToString();
                    cboTipo.SelectedIndex = (int)dr["duracion"];
                    cboGenero.SelectedIndex = (int)dr["genero"];
                    lblCreateUser.Text = CFuncionesGenerales.NombreUsuario(dr["create_user_id"].ToString());
                    lblCreateTime.Text = fechaCreacion.ToString("dd") + " de " + fechaCreacion.ToString("MMMM") + " del " + fechaCreacion.ToString("yyyy");
                    if (dr["update_user_id"] != DBNull.Value)
                    {
                        lblUpdateUser.Text = CFuncionesGenerales.NombreUsuario(dr["update_user_id"].ToString());
                        lblUpdateTime.Text = fechaModificacion.ToString("dd") + " de " + fechaModificacion.ToString("MMMM") + " del " + fechaModificacion.ToString("yyyy");
                    }
                }
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("No se pudo recuperar la información de la promoción. Hubo un error al conectar con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se pudo recuperar la información de la promoción. Hubo un error genérico.", ex);
            }
        }

        private void EditarPromocion()
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "UPDATE promocion_horario SET hora_inicio=?hora_inicio, hora_fin=?hora_fin, precio=?precio, " + 
                    "duracion=?duracion, descripcion=?descripcion, genero=?genero, update_user_id=?update_user_id, update_time=NOW() WHERE id=?id";
                sql.Parameters.AddWithValue("?hora_inicio", dtpHoraInicio.Value.ToString("HH:mm:ss"));
                sql.Parameters.AddWithValue("?hora_fin", dtpHoraFin.Value.ToString("HH:mm:ss"));
                sql.Parameters.AddWithValue("?precio", txtPrecio.Text);
                sql.Parameters.AddWithValue("?duracion", cboTipo.SelectedIndex);
                sql.Parameters.AddWithValue("?descripcion", txtDescripcion.Text);
                sql.Parameters.AddWithValue("?genero", cboGenero.SelectedIndex);
                sql.Parameters.AddWithValue("?update_user_id", frmMain.id);
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

        private bool ValidarCampos()
        {
            if (txtDescripcion.Text.Trim() == "")
            {
                MessageBox.Show("El campo descripción es obligatorio.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtPrecio.Text.Trim() == "")
            {
                MessageBox.Show("El campo precio es obligatorio.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                if (decimal.Parse(txtPrecio.Text) < 0)
                {
                    MessageBox.Show("El campo precio no puede ser menor a 0.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            if (cboTipo.SelectedIndex < 0)
            {
                MessageBox.Show("Debes seleccionar la duración a la que aplicará la promoción.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void frmEditarPromocionHorario_Load(object sender, EventArgs e)
        {
            ObtenerDatosPromocion();
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            CFuncionesGenerales.VerificarEsNumero(ref sender, ref e, false);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    EditarPromocion();
                    MessageBox.Show("Se ha modificado la promoción correctamente.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al guardar la promoción. No se ha podido conectar con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al guardar la promoción. Ocurrió un error genérico.", ex);
            }
        }
    }
}
