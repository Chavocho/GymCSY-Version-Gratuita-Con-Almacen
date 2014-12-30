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
    public partial class frmNuevaPromocion : Form
    {
        public frmNuevaPromocion()
        {
            InitializeComponent();
            cboTipo.SelectedIndex = 0;
            cboGenero.SelectedIndex = 0;
            CFuncionesGenerales.CargarInterfaz(this);
        }

        private void InsertarPromocion()
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "INSERT INTO promocion (descripcion, precio, duracion, genero, fecha_inicio, fecha_fin, create_user_id, create_time) " +
                    "VALUES (?descripcion, ?precio, ?duracion, ?genero, ?fecha_inicio, ?fecha_fin, ?create_user_id, NOW())";
                sql.Parameters.AddWithValue("?descripcion", txtDescripcion.Text);
                sql.Parameters.AddWithValue("?precio", decimal.Parse(txtPrecio.Text));
                sql.Parameters.AddWithValue("?duracion", cboTipo.SelectedIndex);
                sql.Parameters.AddWithValue("?genero", cboGenero.SelectedIndex);
                sql.Parameters.AddWithValue("?fecha_inicio", dtpFechaInicio.Value);
                sql.Parameters.AddWithValue("?fecha_fin", dtpFechaFin.Value);
                sql.Parameters.AddWithValue("?create_user_id", frmMain.id);
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
                    InsertarPromocion();
                    MessageBox.Show("Se ha guardado correctamente la promoción.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dtpFechas_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaInicio.Value > dtpFechaFin.Value)
                dtpFechaInicio.Value = dtpFechaFin.Value;
            if (dtpFechaFin.Value < dtpFechaInicio.Value)
                dtpFechaFin.Value = dtpFechaInicio.Value;
        }
    }
}
