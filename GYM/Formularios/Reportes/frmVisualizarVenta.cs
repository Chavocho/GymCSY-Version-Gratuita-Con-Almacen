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

namespace GYM.Formularios.Reportes
{
    public partial class frmVisualizarVenta : Form
    {
        int idV;
        public frmVisualizarVenta(int idV)
        {
            InitializeComponent();
            this.idV = idV;
        }

        private void ObtenerDatosVenta()
        {
            try
            {
                string sql = "SELECT * FROM venta WHERE id='" + idV + "'";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    DateTime fecha, updateTime;
                    string folioTicket, terminacion;
                    int estado, tipoPago;
                    decimal total = 0;
                    fecha = DateTime.Parse(dr["fecha"].ToString());
                    estado = int.Parse(dr["estado"].ToString());
                    tipoPago = int.Parse(dr["tipo_pago"].ToString());
                    total = decimal.Parse(dr["total"].ToString());
                    if (dr["folio_ticket"] != DBNull.Value)
                        folioTicket = dr["folio_ticket"].ToString();
                    else
                        folioTicket = "Sin información";
                    if (dr["terminacion"] != DBNull.Value)
                        terminacion = dr["terminacion"].ToString();
                    else
                        terminacion = "Sin información";
                    if (dr["update_time"] != DBNull.Value)
                        updateTime = DateTime.Parse(dr["update_time"].ToString());
                    else
                        updateTime = new DateTime();

                    lblFecha.Text = fecha.ToString("dd") + " de " + fecha.ToString("MMMM") + " del " + fecha.ToString("yyyy");
                    if (tipoPago == 0)
                        lblTipoPago.Text = "Efectivo";
                    else
                        lblTipoPago.Text = "Tarjeta";
                    lblRemision.Text = int.Parse(dr["id"].ToString()).ToString("00000000");
                    lblFolioTicket.Text = folioTicket;
                    lblTerminacion.Text = terminacion;
                    lblTotal.Text = total.ToString("C2");
                    lblCreateUser.Text = NombreUsuario(dr["create_user_id"].ToString());
                    lblUpdateUser.Text = NombreUsuario(dr["update_user_id"].ToString());
                    if (updateTime != new DateTime())
                        lblUpdateTime.Text = updateTime.ToString("dd") + " de " + updateTime.ToString("MMMM") + " del " + updateTime.ToString("yyyy");
                    else
                        lblUpdateTime.Text = "Sin información";
                }
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido obtener la información de la venta. Ocurrió un error al conectar con la base de datos. La ventana se cerrará.", ex);
                this.Close();
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido obtener la información de la venta. Ocurrió un error genérico. La ventana se cerrará.", ex);
                this.Close();
            }
        }

        private void ObtenerDatosVentaDetallada()
        {
            try
            {
                string sql = "SELECT v.*, p.nombre FROM venta_detallada AS v LEFT JOIN producto AS p ON (v.id_producto=p.id) WHERE id_venta='" + idV + "'";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    decimal precio = (decimal)dr["precio"];
                    dgvVentaDetallada.Rows.Add(new object[] { dr["id_producto"], dr["nombre"], dr["cantidad"], precio, (int)dr["cantidad"] * precio });
                }
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido obtener la información de la venta detallada. Ocurrió un error al conectar con la base de datos. La ventana se cerrará.", ex);
                this.Close();
            }
            catch (InvalidCastException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido obtener la información de la venta detallada. Ocurrió un error al convertir una variable. La ventana se cerrará.", ex);
                this.Close();
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido obtener la información de la venta detallada. Ocurrió un error genérico. La ventana se cerrará.", ex);
                this.Close();
            }
        }

        private string NombreUsuario(string id)
        {
            string nom = "Sin información";
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT userName FROM usuarios WHERE id=?id";
                sql.Parameters.AddWithValue("?id", id);
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    nom = dr["userName"].ToString();
                }
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido obtener el nombre del usuario. Ocurrió un error al conectar con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido obtener el nombre del usuario. Ocurrió un error genérico.", ex);
            }
            return nom;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmVisualizarVenta_Load(object sender, EventArgs e)
        {
            ObtenerDatosVenta();
            ObtenerDatosVentaDetallada();
        }
    }
}
