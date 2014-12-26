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
    public partial class frmEditarPromocion : Form
    {
        int id;
        public frmEditarPromocion(int id)
        {
            InitializeComponent();
            this.id = id;
            cboTipo.SelectedIndex = 0;
            cboGenero.SelectedIndex = 0;
            CFuncionesGenerales.CargarInterfaz(this);
        }

        private void CargarPromocion()
        {
            try
            {
                string sql = "SELECT * FROM promocion WHERE id='" + id + "'";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    DateTime createTime = (DateTime)dr["create_time"], updateTime = new DateTime();
                    if (dr["update_time"] != DBNull.Value)
                        updateTime = (DateTime)dr["update_time"];
                    dtpFechaFin.Value = (DateTime)dr["fecha_fin"];
                    dtpFechaInicio.Value = (DateTime)dr["fecha_inicio"];
                    txtDescripcion.Text = dr["descripcion"].ToString();
                    txtPrecio.Text = dr["precio"].ToString();
                    cboTipo.SelectedIndex = (int)dr["duracion"];
                    cboGenero.SelectedIndex = (int)dr["genero"];
                    lblCreateUser.Text = NombreUsuario(dr["create_user_id"].ToString());
                    lblCreateTime.Text = createTime.ToString("dd") + " de " + createTime.ToString("MMMM") + " del " + createTime.ToString("yyyy");
                    lblUpdateUser.Text = NombreUsuario(dr["update_user"].ToString());
                    if (updateTime == new DateTime())
                        lblUpdateTime.Text = "Sin información";
                    else
                        lblUpdateTime.Text = updateTime.ToString("dd") + " de " + updateTime.ToString("MMMM") + " del " + updateTime.ToString("yyyy");
                }
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("No se han podido obtener los datos. No se pudo conectar con la base de datos. La ventana se cerrará.", ex);
                this.Close();
            }
            catch (InvalidCastException ex)
            {
                CFuncionesGenerales.MensajeError("No se han podido obtener los datos. Ocurrió un error al convertir las variables.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se han podido obtener los datos. Ocurrió un error genérico.", ex);
            }
        }

        private string NombreUsuario(string id)
        {
            string nomUsu = "Sin información";
            try
            {
                string sql = "SELECT userName FROM usuarios WHERE id='" + id + "'";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    nomUsu = dr["userName"].ToString();
                }
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido obtener el nombre de usuario. No se ha podido conectar a la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido obtener el nombre de usuario. Ocurrió un error genérico.", ex);
            }
            return nomUsu;
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

        private void ModificarPromocion()
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "UPDATE promocion SET descripcion=?descripcion, precio=?precio, duracion=?duracion, genero=?genero, " +
                        "fecha_inicio=?fecha_inicio, fecha_fin=?fecha_fin, update_user=?update_user, update_time=NOW() WHERE id=?id";
                sql.Parameters.AddWithValue("?descripcion", txtDescripcion.Text);
                sql.Parameters.AddWithValue("?precio", txtPrecio.Text);
                sql.Parameters.AddWithValue("?duracion", cboTipo.SelectedIndex);
                sql.Parameters.AddWithValue("?genero", cboGenero.SelectedIndex);
                sql.Parameters.AddWithValue("?fecha_inicio", dtpFechaInicio.Value);
                sql.Parameters.AddWithValue("?fecha_fin", dtpFechaFin.Value);
                sql.Parameters.AddWithValue("?update_user", frmMain.id);
                sql.Parameters.AddWithValue("?id", id);
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
            try
            {
                if (ValidarCampos())
                {
                    ModificarPromocion();
                    MessageBox.Show("Se ha modificado la promoción correctamente.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("Se ha producido un error al modificar la promoción. No se pudo conectar a la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("Se ha producido un error al modificar la promoción. Ocurrió un error genérico.", ex);
            }
        }

        private void dtpFechas_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaInicio.Value > dtpFechaFin.Value)
                dtpFechaInicio.Value = dtpFechaFin.Value;
            if (dtpFechaFin.Value < dtpFechaInicio.Value)
                dtpFechaFin.Value = dtpFechaInicio.Value;
        }

        private void frmEditarPromocion_Load(object sender, EventArgs e)
        {
            CargarPromocion();
        }
    }
}
