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
                        dgvProductos.Rows.Add(new object[] { id, dr["nombre"], decimal.Parse(dr["costo"].ToString()), cant, desc });
                        dgvProductos_CellClick(dgvProductos, new DataGridViewCellEventArgs(0, dgvProductos.RowCount - 1));
                    }
                }
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
                    decimal costo = (decimal)dr.Cells[2].Value;
                    int cant = (int)dr.Cells[3].Value;
                    subtotal += costo * cant;
                    descuento += (decimal)dr.Cells[4].Value;
                }
                importe = subtotal * (iva / 100);
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
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al sumar los totales. Ha ocurrido un error genérico.", ex);
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
            DialogResult r = MessageBox.Show("¿Realmente deseas quitar este producto de la venta?", "GymCSY", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (r == System.Windows.Forms.DialogResult.Yes)
            {
                QuitarProducto(id);
            }
        }
    }
}
