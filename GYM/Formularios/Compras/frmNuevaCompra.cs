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
    public partial class frmNuevaCompra : Form
    {
        string id = "";
        private int iva = 16;
        public int IVA
        {
            get { return iva; }
            set 
            {
                iva = value;
                CalcularTotales();
            }
        }
        

        public frmNuevaCompra()
        {
            InitializeComponent();
            cboTipoPago.SelectedIndex = 0;
        }

        /// <summary>
        /// Función que agrega el producto al DataGridView
        /// </summary>
        /// <param name="id">ID del producto</param>
        /// <param name="cant">Cantidad a ingresar</param>
        /// <param name="desc">Descuento aplicado al producto</param>
        public void AgregarProducto(string id, int cant, decimal desc)
        {
            try
            {
                if (!VerificarProducto(id, cant, desc))
                {
                    string sql = "SELECT nombre, costo FROM producto WHERE id='" + id + "'";
                    DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                    foreach (DataRow dr in dt.Rows)
                    {
                        dgvProductos.Rows.Add(new object[] { id, dr["nombre"], decimal.Parse(dr["costo"].ToString()).ToString("C2"), cant, desc.ToString("C2") });
                        dgvProductos_CellClick(dgvProductos, new DataGridViewCellEventArgs(0, dgvProductos.RowCount - 1));
                    }
                }
                CalcularTotales();
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("Ocurrio un error al agregar el producto a la venta. No se pudo conectar con la base de datos.", ex);
            }
            catch (FormatException ex)
            {
                CFuncionesGenerales.MensajeError("Ocurrio un error al agregar el producto a la venta. No se pudo dar formato a una variable.", ex);
            }
            catch (OverflowException ex)
            {
                CFuncionesGenerales.MensajeError("Ocurrio un error al agregar el producto a la venta. Ocurrio un desbordamiento.", ex);
            }
            catch (ArgumentNullException ex)
            {
                CFuncionesGenerales.MensajeError("Ocurrio un error al agregar el producto a la venta. El argumento dado al método es nulo.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("Ocurrio un error al agregar el producto a la venta. Ha ocurrido un error genérico.", ex);
            }
        }

        /// <summary>
        /// Función que verifica si el producto existe o no en el DataGridView, y en caso de existir, suma las cantidades
        /// y modifica el valor del descuento.
        /// </summary>
        /// <param name="id">ID del producto</param>
        /// <param name="cant">Cantidad de producto que se desea ingresar</param>
        /// <param name="desc">Valor del descuento que se ha hecho al producto</param>
        /// <returns>Valor booleano que indica si el producto existe o no</returns>
        private bool VerificarProducto(string id, int cant, decimal desc)
        {
            try
            {
                foreach (DataGridViewRow dr in dgvProductos.Rows)
                {
                    if (dr.Cells[0].Value.ToString() == id)
                    {
                        dr.Cells[3].Value = (int)dr.Cells[3].Value + cant;
                        dr.Cells[4].Value = desc;
                        dgvProductos_CellClick(dgvProductos, new DataGridViewCellEventArgs(0, dr.Index));
                        return true;
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido verificar la existencia del producto. No se ha podido convertir una variable.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido verificar la existencia del producto. Ha ocurrido un error genérico.", ex);
            }
            return false;
        }

        /// <summary>
        /// Función que modifica los valores de un producto
        /// </summary>
        /// <param name="id">ID del producto</param>
        /// <param name="cant">Cantidad del producto</param>
        /// <param name="descuento">Descuento aplicado al producto</param>
        public void ModificarProducto(string id, int cant, decimal descuento)
        {
            try
            {
                foreach (DataGridViewRow dr in dgvProductos.Rows)
                {
                    if (dr.Cells[0].Value.ToString() == id)
                    {
                        dr.Cells[3].Value = cant;
                        dr.Cells[4].Value = descuento;
                        CalcularTotales();
                        return;
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido verificar la existencia del producto. No se ha podido convertir una variable.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido verificar la existencia del producto. Ha ocurrido un error genérico.", ex);
            }
        }

        /// <summary>
        /// Función que quita un producto del DataGridView
        /// </summary>
        /// <param name="id">ID del producto a quitar   </param>
        private void QuitarProducto(string id)
        {
            try
            {
                foreach (DataGridViewRow dr in dgvProductos.Rows)
                {
                    if (dr.Cells[0].Value.ToString() == id)
                    {
                        dgvProductos.Rows.Remove(dr);
                        CalcularTotales();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido eliminar el producto. Ha ocurrido un error genérico.", ex);
            }
        }

        /// <summary>
        /// Función que calcula los totales de compra
        /// </summary>
        private void CalcularTotales()
        {
            try
            {
                decimal subtotal = 0, importe = 0, descuento = 0, total = 0;
                foreach (DataGridViewRow dr in dgvProductos.Rows)
                {
                    decimal costo = decimal.Parse(dr.Cells[2].Value.ToString(), System.Globalization.NumberStyles.Currency);
                    int cant = (int)dr.Cells[3].Value;
                    subtotal += costo * cant;
                    descuento += decimal.Parse(dr.Cells[4].Value.ToString(), System.Globalization.NumberStyles.Currency);
                }
                importe = subtotal * (iva / 100M);
                total = subtotal + importe - descuento;

                lblSubtotal.Text = subtotal.ToString("C2");
                lblImporte.Text = importe.ToString("C2");
                lblDescuento.Text = descuento.ToString("C2");
                lblTotal.Text = total.ToString("C2");
            }
            catch (InvalidCastException ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al sumar los totales. La conversión no pudo ser realizada.", ex);
            }
            catch (FormatException ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al sumar los totales. La conversión no pudo ser realizada.", ex);
            }
            catch (OverflowException ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al sumar los totales. Ocurrió un desbordamiento.", ex);
            }
            catch (ArgumentNullException ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al sumar los totales. El argumento dado al método es nulo.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al sumar los totales. Ha ocurrido un error genérico.", ex);
            }
        }

        /// <summary>
        /// Función que verifica que todos los campos necesarios esten completos
        /// </summary>
        /// <returns>Valor booleano que indica si los campos requeridos están llenos.</returns>
        private bool ValidarCampos()
        {
            if (dgvProductos.RowCount <= 0)
            {
                MessageBox.Show("Debes ingresar al menos un producto a la compra.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (rabRemision.Checked)
            {
                if (txtRemision.Text.Trim() == "")
                {
                    MessageBox.Show("Debes ingresar el folio de la remisión.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else
            {
                if (txtFactura.Text.Trim() == "")
                {
                    MessageBox.Show("Debes ingresar el folio de la factura.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Función que inserta en la base de datos la compra.
        /// </summary>
        private void IngresarCompra()
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "INSERT INTO compra (fecha, tipo_pago, remision, factura, folio_remision, folio_factura, subtotal, descuento, impuesto, create_user_id) " +
                    "VALUES (NOW(), ?tipo_pago, ?remision, ?factura, ?folio_remision, ?folio_factura, ?subtotal, ?descuento, ?importe, ?create_user_id)";
                sql.Parameters.AddWithValue("?tipo_pago", cboTipoPago.SelectedIndex);
                sql.Parameters.AddWithValue("?remision", rabRemision.Checked);
                sql.Parameters.AddWithValue("?factura", rabFactura.Checked);
                if (rabRemision.Checked)
                {
                    sql.Parameters.AddWithValue("?folio_remision", txtRemision.Text);
                    sql.Parameters.AddWithValue("?folio_factura", DBNull.Value);
                }
                else
                {
                    sql.Parameters.AddWithValue("?folio_remision", DBNull.Value);
                    sql.Parameters.AddWithValue("?folio_factura", txtFactura.Text);
                }
                sql.Parameters.AddWithValue("?subtotal", decimal.Parse(lblSubtotal.Text, System.Globalization.NumberStyles.Currency));
                sql.Parameters.AddWithValue("?descuento", decimal.Parse(lblDescuento.Text, System.Globalization.NumberStyles.Currency));
                sql.Parameters.AddWithValue("?importe", decimal.Parse(lblImporte.Text, System.Globalization.NumberStyles.Currency));
                sql.Parameters.AddWithValue("?create_user_id", frmMain.id);
                ConexionBD.EjecutarConsulta(sql);
                sql.Parameters.Clear();

                int id = 0;
                sql.CommandText = "SELECT MAX(id) AS i FROM compra LIMIT 1";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                    id = (int)dr["i"];
                IngresarCompraDetallada(id);
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (OverflowException ex)
            {
                throw ex;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void IngresarCompraDetallada(int idCompra)
        {
            try
            {
                foreach (DataGridViewRow dr in dgvProductos.Rows)
                {
                    MySqlCommand sql = new MySqlCommand();
                    sql.CommandText = "INSERT INTO compra_producto (id_compra, id_producto, cantidad, precio, descuento) " +
                        "VALUES (?id_compra, ?id_producto, ?cantidad, ?precio, ?descuento)";
                    sql.Parameters.AddWithValue("?id_compra", idCompra);
                    sql.Parameters.AddWithValue("?id_producto", dr.Cells[0].Value);
                    sql.Parameters.AddWithValue("?cantidad", dr.Cells[3].Value);
                    sql.Parameters.AddWithValue("?precio", decimal.Parse(dr.Cells[2].Value.ToString(), System.Globalization.NumberStyles.Currency));
                    sql.Parameters.AddWithValue("?descuento", decimal.Parse(dr.Cells[4].Value.ToString(), System.Globalization.NumberStyles.Currency));
                    ConexionBD.EjecutarConsulta(sql);
                    CProducto.AgregarInventario(dr.Cells[0].Value.ToString(), (int)dr.Cells[3].Value);
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (OverflowException ex)
            {
                throw ex;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnIVA_Click(object sender, EventArgs e)
        {
            (new frmIVA(this)).ShowDialog(this);
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            (new frmProductosCompra(this)).ShowDialog(this);
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string nomProd = dgvProductos[1, e.RowIndex].Value.ToString();
                int cant = (int)dgvProductos[3, e.RowIndex].Value;
                decimal desc = decimal.Parse(dgvProductos[4, e.RowIndex].Value.ToString(), System.Globalization.NumberStyles.Currency);
                (new frmModificarProductoCompra(this, id, nomProd, cant, desc)).ShowDialog(this);
            }
            catch 
            {
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = dgvProductos[e.ColumnIndex, e.RowIndex].Value.ToString();
            }
            catch
            {
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Realmente deseas quitar este producto de la compra?", "GymCSY", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (r == System.Windows.Forms.DialogResult.Yes)
            {
                QuitarProducto(id);
            }
        }

        private void rabRemision_CheckedChanged(object sender, EventArgs e)
        {
            txtRemision.Enabled = true;
            txtFactura.Enabled = false;
            txtRemision.Text = "";
            txtFactura.Text = "";
        }

        private void rabFactura_CheckedChanged(object sender, EventArgs e)
        {
            txtFactura.Enabled = true;
            txtRemision.Enabled = false;
            txtFactura.Text = "";
            txtRemision.Text = "";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    IngresarCompra();
                    MessageBox.Show("Se ha ingresado la compra con éxito.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (MySqlException ex)
                {
                    CFuncionesGenerales.MensajeError("Ha ocurrido un error al ingresar la compra. No se pudo conectar con la base de datos.", ex);
                }
                catch (FormatException ex)
                {
                    CFuncionesGenerales.MensajeError("Ha ocurrido un error al ingresar la compra. Ocurrió un error al dar formato a una variable.", ex);
                }
                catch (OverflowException ex)
                {
                    CFuncionesGenerales.MensajeError("Ha ocurrido un error al ingresar la compra. Ocurrió un desbordamiento.", ex);
                }
                catch (ArgumentNullException ex)
                {
                    CFuncionesGenerales.MensajeError("Ha ocurrido un error al ingresar la compra. El argumento dado al método es nulo.", ex);
                }
                catch (ArgumentException ex)
                {
                    CFuncionesGenerales.MensajeError("Ha ocurrido un error al ingresar la compra. El argumento dado al método no es admitido por éste.", ex);
                }
                catch (Exception ex)
                {
                    CFuncionesGenerales.MensajeError("Ha ocurrido un error al ingresar la compra. Ocurrió un error genérico.", ex);
                }
            }
        }

        private void lblEImporte_Click(object sender, EventArgs e)
        {

        }
    }
}
