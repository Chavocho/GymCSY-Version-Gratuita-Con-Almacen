using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GYM.Formularios.POS;
using GYM.Clases;

namespace GYM.Formularios.POS
{
    public partial class frmPuntoVenta : Form
    {
        bool abierta = false;
        string idProducto = "";
        List<string> idProds;
        List<int> cants;

        #region Instancia
        private static frmPuntoVenta frmInstancia;
        public static frmPuntoVenta Instancia
        {
            get
            {
                if (frmInstancia == null)
                    frmInstancia = new frmPuntoVenta();
                else if (frmInstancia.IsDisposed)
                    frmInstancia = new frmPuntoVenta();
                return frmInstancia;
            }
            set
            {
                frmInstancia = value;
            }
        }
        #endregion

        public frmPuntoVenta()
        {
            InitializeComponent();
        }

        #region Metodos
        /// <summary>
        /// Función que obtiene el nombre del usuario actualmente registrado
        /// </summary>
        /// <returns>El nombre de usuario actualmente registrado</returns>
        private string ObtenerNombreUsuario()
        {
            string nomUsuario = "";
            try
            {
                string sql = "SELECT userName FROM usuarios WHERE id='" + frmMain.id.ToString() + "'";
                DataTable dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                    nomUsuario = dr["userName"].ToString();
            }
            catch (MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al obtener el nombre de usuario.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
            return nomUsuario;
        }

        /// <summary>
        /// Función que crea una nueva venta
        /// </summary>
        private void NuevaVenta()
        {
            try
            {
                dgvProductos.Rows.Clear();
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "INSERT INTO venta (fecha, estado, abierta, create_user_id) VALUES (NOW(), ?, ?, ?)";
                sql.Parameters.AddWithValue("@estado", true);
                sql.Parameters.AddWithValue("@abierta", true);
                sql.Parameters.AddWithValue("@create_user_id", frmMain.id);
                Clases.ConexionBD.EjecutarConsulta(sql);
            }
            catch (MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de crear una nueva venta.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        /// <summary>
        /// Función que obtiene el ultimo id de la venta
        /// </summary>
        /// <returns>Ultimo Id de la venta</returns>
        private string UltimoIdVenta()
        {
            string id = "";
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT MAX(id) AS m FROM venta LIMIT 1";
                DataTable dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                    id = int.Parse(dr["m"].ToString()).ToString("00000000");
            }
            catch (MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de obtener el último ID de venta.", ex);
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de dar formato a una variable.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
            return id;
        }

        /// <summary>
        /// Función que agrega un producto al DataGridView de frmPuntoVenta
        /// </summary>
        /// <param name="idProd">Id del producto, el cual se agregará al DataGridView</param>
        public void AgregarProductoDataGrid(string idProd, int cantidad, bool insertarBase)
        {
            try
            {
                if (!VerificarProducto(idProd, cantidad))
                {
                    string sql = "SELECT nombre, precio, cant FROM producto WHERE id='" + idProd + "'";
                    DataTable dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
                    foreach (DataRow dr in dt.Rows)
                    {
                        dgvProductos.Rows.Add(idProd, dr["nombre"], cantidad, decimal.Parse(dr["precio"].ToString()).ToString("C2"));
                        if (insertarBase)
                            InsertarProductoVenta(idProd, cantidad, decimal.Parse(dr["precio"].ToString()));
                    }
                    dgvProductos_CellClick(dgvProductos, new DataGridViewCellEventArgs(0, dgvProductos.RowCount));
                    SumarTotales();
                }
            }
            catch (MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de agregar un producto a la venta.", ex);
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de dar formato a una variable.", ex);
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un desbordamiento.", ex);
            }
            catch (InvalidCastException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("La conversión de una variable no fue válida.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Algún método invocado en AgregarProducto no admite argumentos nulos.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        /// <summary>
        /// Función que verifica si el producto que se desea agregar ya exista en la venta, 
        /// y en caso de estar, solamente actualiza la cantidad.
        /// </summary>
        /// <param name="idProd"></param>
        /// <param name="cant"></param>
        /// <returns>Valor que indica si existe el producto en la venta</returns>
        private bool VerificarProducto(string idProd, int cant)
        {
            try
            {
                foreach (DataGridViewRow dr in dgvProductos.Rows)
                    if (dr.Cells[0].Value.ToString() == idProd.ToString())
                    {
                        if ((int.Parse(dr.Cells[2].Value.ToString()) + cant) <= CantidadInventario(idProd))
                        {
                            dr.Cells[2].Value = decimal.Parse(dr.Cells[2].Value.ToString()) + cant;
                            ModificarCantidadProducto(idProd, cant);
                            SumarTotales();
                        }
                        else
                        {
                            MessageBox.Show("No es posible agregar más productos que los que haya en existencia en inventario.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        return true;
                    }
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de dar formato a una variable.", ex);
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un desbordamiento.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Algún método llamado en VerificarProducto no admite argumentos nulos.", ex);
            }
            return false;
        }

        /// <summary>
        /// Función que inserta un producto a la venta en la base de datos
        /// </summary>
        /// <param name="idProd">Id del producto el cual se insertará en la base de datos</param>
        private void InsertarProductoVenta(string idProd, int cantidad, decimal precio)
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "INSERT INTO venta_detallada (id_venta, id_producto, cantidad, precio) VALUES (?, ?, ?, ?)";
                sql.Parameters.AddWithValue("?id_v", int.Parse(lblFolio.Text));
                sql.Parameters.AddWithValue("?id_p", idProd);
                sql.Parameters.AddWithValue("?cant", cantidad);
                sql.Parameters.AddWithValue("?precio", precio);
                Clases.ConexionBD.EjecutarConsulta(sql);
            }
            catch (MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al insertar el producto en la venta.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        /// <summary>
        /// Función que actualiza la cantidad de productos de una venta
        /// </summary>
        /// <param name="idProd">Id del producto del que se desea modificar la cantidad</param>
        /// <param name="cant">Cantidad que se agrega o se quita</param>
        private void ModificarCantidadProducto(string idProd, int cant)
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "UPDATE venta_detallada SET cantidad = cantidad + " + cant + " WHERE id_venta=? AND id_producto=?";
                sql.Parameters.AddWithValue("@id_venta", int.Parse(lblFolio.Text));
                sql.Parameters.AddWithValue("@id_producto", idProd);
                Clases.ConexionBD.EjecutarConsulta(sql);
                SumarTotales();
            }
            catch (MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al modificar la cantidad del producto.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genéral.", ex);
            }
        }

        /// <summary>
        /// Función que elimina de la venta un producto
        /// </summary>
        /// <param name="idProd">Id del producto que se desea eliminar de la venta</param>
        private void EliminarProductoVenta(string idProd)
        {
            try
            {
                string sql = "DELETE FROM venta_detallada WHERE id_venta='" + int.Parse(lblFolio.Text) + "' AND id_producto='" + idProd + "'";
                Clases.ConexionBD.EjecutarConsulta(sql);
                EliminarProductoDataGrid(idProd);
            }
            catch (MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se ha podido eliminar el producto de la venta. Hubo un error de conexión con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se ha podido eliminar el producto de la venta. Ha ocurrido un error genérico.", ex);
            }
        }

        /// <summary>
        /// Función que elimina el producto de el DataGridView una vez que se ha eliminado de la 
        /// base de datos.
        /// </summary>
        /// <param name="idProd">Id del producto eliminado</param>
        private void EliminarProductoDataGrid(string idProd)
        {
            try
            {
                foreach (DataGridViewRow dr in dgvProductos.Rows)
                    if (dr.Cells[0].Value.ToString() == idProd.ToString())
                        dgvProductos.Rows.Remove(dr);
                SumarTotales();
            }
            catch (InvalidOperationException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo eliminar el producto del DataGridView. La operación no fue válida.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo eliminar el producto del DataGridView. El argumento dado fue nulo.", ex);
            }
            catch (ArgumentException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo eliminar el producto del DataGridView. El argumento dado no fue aceptado por el método.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo eliminar el producto del DataGridView. Ha ocurrido un error genérico.", ex);
            }
        }

        /// <summary>
        /// Función que obtiene los totales de venta
        /// </summary>
        private void SumarTotales()
        {
            try
            {
                decimal tot = 0, cant = 0, tmpCant = 0;
                foreach (DataGridViewRow dr in dgvProductos.Rows)
                {
                    tmpCant = decimal.Parse(dr.Cells[2].Value.ToString());
                    cant += tmpCant;
                    tot += (decimal.Parse(dr.Cells[3].Value.ToString(), System.Globalization.NumberStyles.Currency) * tmpCant);
                }
                lblNumProductos.Text = cant.ToString();
                lblTotal.Text = (tot).ToString("C2");
                ActualizarTotales(tot);
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo actualizar los totales. Ha ocurrido un error al tratar de dar formato a una variable.", ex);
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo actualizar los totales. Hubo un desbordamiento.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo actualizar los totales. El argumento dado es nulo.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo actualizar los totales. Ha ocurrido un error genérico.", ex);
            }
        }

        /// <summary>
        /// Función que actualiza el subtotal en la base de datos
        /// </summary>
        /// <param name="total">Subtotal de la venta</param>
        private void ActualizarTotales(decimal total)
        {
            try
            {
                string sql = "UPDATE venta SET total=" + total.ToString() + " WHERE id='" + int.Parse(lblFolio.Text).ToString() + "'";
                Clases.ConexionBD.EjecutarConsulta(sql);
            }
            catch (MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo actualizar los totales. La conexión con la base de datos no se pudo realizar.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo actualizar los totales. Ha ocurrido un error genérico.", ex);
            }
        }

        /// <summary>
        /// Función que muestra los controles cuando se crea una nueva venta
        /// </summary>
        private void MostrarControles()
        {
            abierta = true;
            txtCodigo.Enabled = true;
            lblFolio.Text = UltimoIdVenta();
            lblFolio.Visible = true;
            lblEtiquetaFolio.Visible = true;
            btnProductos.Visible = true;
            btnCobrar.Visible = true;
            lblEtiquetaNumProductos.Visible = true;
            lblNumProductos.Visible = true;
            lblEtiquetaTotal.Visible = true;
            lblTotal.Visible = true;
            txtCodigo.Focus();
            btnDevolver.Visible = false;
        }

        /// <summary>
        /// Función que muestra los controles cuando se recupera una venta que se encuentre cerrada
        /// </summary>
        private void MostrarControlesRecuperada(decimal total)
        {
            abierta = false;
            lblFolio.Visible = true;
            lblEtiquetaFolio.Visible = true;
            lblEtiquetaNumProductos.Visible = true;
            lblNumProductos.Visible = true;
            lblEtiquetaTotal.Visible = true;
            lblTotal.Visible = true;
            txtCodigo.Enabled = false;
            btnCobrar.Visible = false;
            btnProductos.Visible = false;
            lblTotal.Text = total.ToString("C2");
            lblEtiquetaTotal.Visible = true;
            lblTotal.Visible = true;
            //btnDevolver.Visible = true;
        }

        /// <summary>
        /// Función que hace las operaciones necesarias para recuperar una venta
        /// </summary>
        /// <param name="folio">Folio de la venta que se desea recuperar</param>
        public void RecuperarVenta(int folio)
        {
            try
            {
                dgvProductos.Rows.Clear();
                lblNumProductos.Text = "0";
                lblTotal.Text = "$0.00";
                string sql = "SELECT * FROM venta WHERE id='" + folio + "'";
                DataTable dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["abierta"].ToString() == "0")
                        MostrarControlesRecuperada(decimal.Parse(dr["total"].ToString()));
                    else
                        MostrarControles();
                    if (dr["id"].ToString() != "")
                        lblFolio.Text = int.Parse(dr["id"].ToString()).ToString("00000000");
                }
                RecuperarVentaDetallada(folio);
            }
            catch (MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se ha podido recuperar la venta. Hubo un error con la conexión a la base de datos.", ex);
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se ha podido recuperar la venta. Hubo un error al tratar de dar formato a una variable.", ex);
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se ha podido recuperar la venta. Hubo un desbordamiento.", ex);
            }
            catch (InvalidOperationException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se ha podido recuperar la venta. La operación no pudo ser completada.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se ha podido recuperar la venta. Se ha dado un argumento nulo.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se ha podido recuperar la venta. Ha ocurrido un error genérico.", ex);
            }
        }

        private void RecuperarVentaDetallada(int folio)
        {
            try
            {
                string sql = "SELECT v.*, p.cant AS ca, p.control_stock AS st FROM venta_detallada AS v LEFT JOIN producto AS p ON (v.id_producto=p.id) WHERE id_venta='" + folio + "'";
                DataTable dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["id_producto"].ToString() != "")
                    {
                        if (int.Parse(dr["ca"].ToString()) >= int.Parse(dr["cantidad"].ToString()))
                            AgregarProductoDataGrid(dr["id_producto"].ToString(), int.Parse(dr["cantidad"].ToString()), false);
                        else if (dr["st"].ToString() == "0")
                            AgregarProductoDataGrid(dr["id_producto"].ToString(), int.Parse(dr["cantidad"].ToString()), false);
                        else
                            AgregarProductoDataGrid(dr["id_producto"].ToString(), int.Parse(dr["ca"].ToString()), false);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se ha podido recuperar el detallado de la venta. Hubo un error con la conexión a la base de datos.", ex);
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se ha podido recuperar el detallado de la venta. No se pudo dar formato a una variable.", ex);
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se ha podido recuperar el detallado de la venta. Hubo un desbordamiento.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se ha podido recuperar el detallado de la venta. El argumento dado fue nulo.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se ha podido recuperar el detallado de la venta. Ha ocurrido un error genérico.", ex);
            }
        }

        private int CantidadInventario(string idProd)
        {
            int cant = 0;
            try
            {
                string sql = "SELECT cant, control_stock FROM producto WHERE id='" + idProd + "'";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["control_stock"].ToString() == "1")
                        cant = int.Parse(dr["cant"].ToString());
                    else
                        cant = int.MaxValue;
                }
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("No se pudo obtener la cantidad del producto del inventario. No se pudo conectar con la base de datos.", ex);
            }
            catch (FormatException ex)
            {
                CFuncionesGenerales.MensajeError("No se pudo obtener la cantidad del producto del inventario. No se pudo dar formato a una variable.", ex);
            }
            catch (OverflowException ex)
            {
                CFuncionesGenerales.MensajeError("No se pudo obtener la cantidad del producto del inventario. Ocurrio un desbordamiento.", ex);
            }
            catch (ArgumentNullException ex)
            {
                CFuncionesGenerales.MensajeError("No se pudo obtener la cantidad del producto del inventario. El argumento dado al método es nulo.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se pudo obtener la cantidad del producto del inventario. Ha ocurrido un error genérico.", ex);
            }
            return cant;
        }

        private void Inventariar()
        {
            try
            {
                idProds = new List<string>();
                cants = new List<int>();
                idProds.Clear();
                cants.Clear();
                for (int i = 0; i < dgvProductos.RowCount; i++)
                {
                    idProds.Add(dgvProductos[0, i].Value.ToString());
                    cants.Add(int.Parse(dgvProductos[2, i].Value.ToString()));
                }
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se ha podido Inventariar. Hubo un error al tratar de convertir una variable.", ex);
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se ha podido Inventariar. Ha ocurrido un desbordamiento.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se ha podido Inventariar. El argumento dado al método es nulo y éste no lo acepta.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se ha podido Inventariar. Ocurrio un error genérico.", ex);
            }
        }
        #endregion

        private void frmPuntoVenta_Load(object sender, EventArgs e)
        {
            Clases.CFuncionesGenerales.CargarInterfaz(this);
            lblUsuario.Text = ObtenerNombreUsuario();
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            try
            {
                if (bool.Parse(Clases.CConfiguracionXML.LeerConfiguración("caja", "estado")))
                {
                    if (!abierta)
                    {
                        NuevaVenta();
                        MostrarControles();
                    }
                    else
                    {
                        if (MessageBox.Show("No has concluido la venta, ¿seguro que deseas crear una nueva?\n(Está se guardará para que la puedas continuar en otro momento).", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                        {
                            NuevaVenta();
                            MostrarControles();
                        }
                    }
                }
                else
                    if (MessageBox.Show("No puedes realizar operaciones de venta si la caja esta cerrada.\n¿Deseas abrirla?", "GymCSY", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                        (new Formularios.Caja.frmAbrirCaja()).ShowDialog(this);
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Hubo un error al crear una venta nueva. Ocurrio un error al dar formato a una variable.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Hubo un error al crear una venta nueva. El argumento dado al método es nulo y éste no lo acepta.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Hubo un error al crear una venta nueva. Ocurrio un error genérico.", ex);
            }
            txtCodigo.Focus();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            try
            {
                (new frmProductos(this)).ShowDialog(this);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Hubo un error al abrir la ventana de productos. El argumento dado al método es nulo y éste no lo acepta.", ex);
            }
            catch (InvalidOperationException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Hubo un error al abrir la ventana de productos. La operación no se pudo completar porqué el estado actual del objeto no lo permite.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Hubo un error al abrir la ventana de productos. Ha ocurrido un error genérico.", ex);
            }
            txtCodigo.Focus();
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idProducto = dgvProductos[0, e.RowIndex].Value.ToString();
            }
            catch
            {

            }
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductos.RowCount > 0)
                {
                    Inventariar();
                    (new frmCobrar(this, int.Parse(lblFolio.Text), decimal.Parse(lblTotal.Text, System.Globalization.NumberStyles.Currency), decimal.Parse(lblNumProductos.Text), idProds, cants)).ShowDialog(this);
                }
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo cobrar la cuenta. No se pudo convertir una variable porqué el formato dado no es correcto.", ex);
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo cobrar la cuenta. Ocurrio un desbordamiento.", ex);
            }
            catch (InvalidOperationException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo cobrar la cuenta. El método no se pudo realizar porqué el estado actual del objeto no lo permite.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo cobrar la cuenta. El argumento dado al método es nulo y éste no lo admite.", ex);
            }
            catch (ArgumentException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo cobrar la cuenta. El argumento dado al método no es válido para éste.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo cobrar la cuenta. Ocurrio un error genérico.", ex);
            }
            txtCodigo.Focus();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    AgregarProductoDataGrid(txtCodigo.Text, 1, true);
                    txtCodigo.Text = "";
                }
            }
            catch
            {
            }
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bool.Parse(Clases.CConfiguracionXML.LeerConfiguración("caja", "estado")))
                {
                    if (!abierta)
                        (new frmRecuperarVenta(this)).ShowDialog(this);
                    else
                    {
                        if (MessageBox.Show("No has concluido la venta, ¿seguro que deseas crear una nueva?\n(Está se guardará para que la puedas continuar en otro momento).", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                            (new frmRecuperarVenta(this)).ShowDialog(this);
                    }
                }
                else
                {
                    if (MessageBox.Show("No puedes realizar operaciones de venta si la caja esta cerrada.\n¿Deseas abrirla?", "GymCSY", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                        (new Formularios.Caja.frmAbrirCaja()).ShowDialog(this);
                }
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo abrir la ventana de recuperar la venta. No se pudo convertir la variable porqué el formato dado no es válido.", ex);
            }
            catch (InvalidOperationException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo abrir la ventana de recuperar la venta. La llamada al método no se pudo completar porqué el estado actual del objeto no lo permite.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo abrir la ventana de recuperar la venta. El argumento dado al método es nulo y éste no lo acepta.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo abrir la ventana de recuperar la venta. Ha ocurrido un error genérico.", ex);
            }
            txtCodigo.Focus();
        }

        private void dgvProductos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgvProductos.RowCount == 0)
            {
                btnMas.Enabled = false;
                btnMenos.Enabled = false;
                btnMas.BackgroundImage = GYM.Properties.Resources.Mas_Inactivo;
                btnMenos.BackgroundImage = GYM.Properties.Resources.Menos_Inactivo;
            }
        }

        private void dgvProductos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgvProductos.RowCount > 0)
            {
                btnMas.Enabled = true;
                btnMenos.Enabled = true;
                btnMas.BackgroundImage = GYM.Properties.Resources.Mas;
                btnMenos.BackgroundImage = GYM.Properties.Resources.Menos;
            }
        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null)
            {
                VerificarProducto(idProducto, 1);
            }
            txtCodigo.Focus();
        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null)
            {
                if (decimal.Parse(dgvProductos[2, dgvProductos.CurrentRow.Index].Value.ToString(), System.Globalization.NumberStyles.Currency) <= 1)
                    EliminarProductoVenta(idProducto);
                else
                    VerificarProducto(idProducto, -1);
            }
            txtCodigo.Focus();
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            try
            {
                (new frmDevoluciones(this, int.Parse(this.lblFolio.Text))).ShowDialog(this);
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo abrir la ventana de devoluciones. Ha ocurrido un error al tratar de convertir una variable porqué el formato no es correcto.", ex);
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo abrir la ventana de devoluciones. Ocurrio un desbordamiento.", ex);
            }
            catch (InvalidOperationException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo abrir la ventana de devoluciones. La operación no se pudo completar porqué el estado actual del objeto no lo permite.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo abrir la ventana de devoluciones. El argumento dado al método es nulo y éste no lo acepta.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo abrir la ventana de devoluciones. Ocurrio un error genérico.", ex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                (new frmCancelarVenta()).ShowDialog(this);
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo abrir la ventana de cancelaciones. Ha ocurrido un error al tratar de convertir una variable porqué el formato no es correcto.", ex);
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo abrir la ventana de cancelaciones. Ocurrio un desbordamiento.", ex);
            }
            catch (InvalidOperationException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo abrir la ventana de cancelaciones. La operación no se pudo completar porqué el estado actual del objeto no lo permite.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo abrir la ventana de cancelaciones. El argumento dado al método es nulo y éste no lo acepta.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo abrir la ventana de cancelaciones. Ocurrio un error genérico.", ex);
            }
        }

        private void frmPuntoVenta_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control == true && e.KeyCode == Keys.Oemplus)
                {
                    if (dgvProductos.CurrentRow != null)
                    {
                        VerificarProducto(idProducto, 1);
                    }
                }
                else if (e.Control == true && e.KeyCode == Keys.OemMinus)
                {
                    if (dgvProductos.CurrentRow != null)
                    {
                        if (decimal.Parse(dgvProductos[2, dgvProductos.CurrentRow.Index].Value.ToString(), System.Globalization.NumberStyles.Currency) <= 1)
                            EliminarProductoVenta(idProducto);
                        else
                            VerificarProducto(idProducto, -1);
                    }

                }
                else if (e.Control == true && e.KeyCode == Keys.Delete)
                {
                    EliminarProductoVenta(idProducto);
                }
                else if (e.KeyCode == Keys.F1)
                {
                    btnNueva.PerformClick();
                }
                else if (e.KeyCode == Keys.F2)
                {
                    btnRecuperar.PerformClick();
                }
                else if (e.KeyCode == Keys.F3)
                {
                    btnCancelar.PerformClick();
                }
                else if (e.KeyCode == Keys.F4)
                {
                    btnProductos.PerformClick();
                }
                else if (e.KeyCode == Keys.F5)
                {
                    btnDevolver.PerformClick();
                }
                else if (e.KeyCode == Keys.F6)
                {
                    btnCobrar.PerformClick();
                }
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo modificar la cantidad del producto. Ocurrio un error al tratar de dar formato a una variable.", ex);
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo modificar la cantidad del producto. Ocurrio un desbordamiento.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo modificar la cantidad del producto. El argumento dado al método es nulo y éste no lo acepta.", ex);
            }
            catch (ArgumentException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo modificar la cantidad del producto. El argumento dado al método no es válido para éste.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo modificar la cantidad del producto. Ocurrio un error genérico.", ex);
            }
        }
    }
}