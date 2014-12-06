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

namespace GYM.Formularios.Compras
{
    public partial class frmVisualizarCompra : Form
    {
        int idCompra = 0;

        public frmVisualizarCompra(int idCompra)
        {
            InitializeComponent();
            this.idCompra = idCompra;
        }

        private void CargarDatosCompra()
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT * FROM compra WHERE id=?id";
                sql.Parameters.AddWithValue("?id", idCompra);
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    DateTime fecha = DateTime.Parse(dr["fecha"].ToString());
                    int tipoPago = int.Parse(dr["tipo_pago"].ToString());
                    string remision = dr["remision"].ToString(), factura = dr["factura"].ToString(),
                        folioRemision = dr["folio_remision"].ToString(), folioFactura = dr["folio_factura"].ToString();
                    decimal subtotal = decimal.Parse(dr["subtotal"].ToString()), descuento = decimal.Parse(dr["descuento"].ToString()),
                        importe = decimal.Parse(dr["impuesto"].ToString()), total = (subtotal + importe - descuento);

                    lblFecha.Text = fecha.ToString("dd") + " de " + fecha.ToString("MMMM") + " del " + fecha.ToString("yyyy");
                    if (tipoPago == 0)
                        lblTipoPago.Text = "Efectivo";
                    else if (tipoPago == 1)
                        lblTipoPago.Text = "Tarjeta";
                    if (remision == "0")
                    {
                        lblRemision.Text = "No";
                        lblFolioRemision.Text = "Sin información";
                        lblFactura.Text = "Si";
                        lblFolioFactura.Text = folioFactura;
                    }
                    else
                    {
                        lblRemision.Text = "Si";
                        lblFolioRemision.Text = folioRemision;
                        lblFactura.Text = "No";
                        lblFolioFactura.Text = "Sin información";
                    }
                    lblSubtotal.Text = subtotal.ToString("C2");
                    lblImporte.Text = importe.ToString("C2");
                    lblDescuento.Text = descuento.ToString("C2");
                    lblTotal.Text = total.ToString("C2");
                }
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido obtener la información. Ocurrió un error al conectar con la base de datos. La ventana se cerrará.", ex);
                this.Close();
            }
            catch (FormatException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido obtener la información. Ocurrió un error al convertir una variable. La ventana se cerrará.", ex);
                this.Close();
            }
            catch (OverflowException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido obtener la información. Ocurrió un desbordamiento. La ventana se cerrará.", ex);
                this.Close();
            }
            catch (ArgumentNullException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido obtener la información. El argumento dado al método es nulo. La ventana se cerrará.", ex);
                this.Close();
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido obtener la información. Ocurrió un error genérico. La ventana se cerrará.", ex);
                this.Close();
            }
        }

        private void CargarDatosCompraDetallada()
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT c.*, p.nombre AS nom FROM compra_producto AS c INNER JOIN producto AS p ON (c.id_producto=p.id) WHERE id_compra=?id_compra";
                sql.Parameters.AddWithValue("?id_compra", idCompra);
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    decimal costo = decimal.Parse(dr["precio"].ToString()), descuento = decimal.Parse(dr["descuento"].ToString());
                    int cant = int.Parse(dr["cantidad"].ToString());
                    dgvCompraDetallada.Rows.Add(new object[] { dr["id_producto"], dr["nom"], cant, costo.ToString("C2"), descuento.ToString("C2"), ((cant * costo) - descuento).ToString("C2") });
                }
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido obtener el detallado de la información. Ocurrió un error al conectar con la base de datos. La ventana se cerrará.", ex);
                this.Close();
            }
            catch (FormatException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido obtener el detallado de la información. Ocurrió un error al convertir una variable. La ventana se cerrará.", ex);
                this.Close();
            }
            catch (OverflowException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido obtener el detallado de la información. Ocurrió un desbordamiento. La ventana se cerrará.", ex);
                this.Close();
            }
            catch (ArgumentNullException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido obtener el detallado de la información. El argumento dado al método es nulo. La ventana se cerrará.", ex);
                this.Close();
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido obtener la información. Ocurrió un error genérico. La ventana se cerrará.", ex);
                this.Close();
            }
        }

        private void frmVisualizarCompra_Load(object sender, EventArgs e)
        {
            CargarDatosCompra();
            CargarDatosCompraDetallada();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
