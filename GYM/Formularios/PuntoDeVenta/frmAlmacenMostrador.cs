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

namespace GYM.Formularios.PuntoDeVenta
{
    public partial class frmAlmacenMostrador : Form
    {
        int cantAlm = 0, cantMos = 0;
        string id;

        public frmAlmacenMostrador(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void CargarCantidades()
        {
            try
            {
                string sql = "SELECT cant, cant_alm FROM producto WHERE id='" + id + "'";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    cantAlm = (int)dr["cant_alm"];
                    cantMos = (int)dr["cant"];
                }
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("No se han podido cargar las cantidades. No se ha podido conectar a la base de datos.\nLa ventana se cerrará.", ex);
                this.Close();
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se han podido cargar las cantidades. Ha ocurrido un error genérico.\nLa ventana se cerrará.", ex);
                this.Close();
            }
        }

        private void GuardarCantidades()
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "UPDATE producto SET cant=?cant, cant_alm=?cant_alm WHERE id=?id";
                sql.Parameters.AddWithValue("?cant", nudCantMostrador.Value);
                sql.Parameters.AddWithValue("?cant_alm", lblCantidad.Text);
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

        private void frmAlmacenMostrador_Load(object sender, EventArgs e)
        {
            CargarCantidades();
            nudCantMostrador.Value = cantMos;
            lblCantidad.Text = cantAlm.ToString();
        }

        private void nudCantMostrador_ValueChanged(object sender, EventArgs e)
        {
            if (nudCantMostrador.Value < cantMos)
            {
                nudCantMostrador.Value = cantMos;
            }
            else if (nudCantMostrador.Value > (cantMos + cantAlm))
            {
                nudCantMostrador.Value = (cantMos + cantAlm);
            }
            lblCantidad.Text = ((cantMos + cantAlm) - nudCantMostrador.Value).ToString(); 
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                GuardarCantidades();
                MessageBox.Show("Se ha guardado las cantidades correctamente.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido actualizar las cantidades. No se ha podido conectar con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido actualizar las cantidades. Ha ocurrido un error genérico.", ex);
            }
        }
    }
}
