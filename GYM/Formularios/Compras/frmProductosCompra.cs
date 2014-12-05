using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using GYM.Clases;

namespace GYM.Formularios.Compras
{
    public partial class frmProductosCompra : Form
    {
        delegate void MensajeError(string mensaje, Exception ex);
        DataTable dt = new DataTable();
        frmNuevaCompra frm;

        public frmProductosCompra(frmNuevaCompra frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        private void BuscarProductos(string p)
        {
            MensajeError m = new MensajeError(CFuncionesGenerales.MensajeError);
            try
            {
                string sql = "SELECT id, nombre, cant_alm, costo FROM producto WHERE id='" + p + "' OR nombre LIKE '%" + p + "%'";
                dt = ConexionBD.EjecutarConsultaSelect(sql);
            }
            catch (MySqlException ex)
            {
                this.Invoke(m, new object[] { "Ha ocurrido un error al buscar los productos. No se ha podido conectar con la base de datos.", ex });
            }
            catch (Exception ex)
            {
                this.Invoke(m, new object[] { "Ha ocurrido un error al buscar los productos. Ocurrio un error genérico.", ex });
            }
        }

        private void LlenarDataGrid()
        {
            try
            {
                dgvProductos.Rows.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    dgvProductos.Rows.Add(new object[] { dr["id"], dr["nombre"], dr["cant_alm"], decimal.Parse(dr["costo"].ToString()).ToString("C2") });
                }
            }
            catch (FormatException ex)
            {
                CFuncionesGenerales.MensajeError("Ocurrio un error al mostrar la información. No se pudo dar formato a una variable.", ex);
            }
            catch (OverflowException ex)
            {
                CFuncionesGenerales.MensajeError("Ocurrio un error al mostrar la información. Ocurrio un desbordamiento.", ex);
            }
            catch (ArgumentNullException ex)
            {
                CFuncionesGenerales.MensajeError("Ocurrio un error al mostrar la información. El argumento dado es nulo.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("Ocurrio un error al mostrar la información. Ocurrió un error genérico.", ex);
            }
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            CFuncionesGenerales.VerificarEsNumero(ref sender, ref e, false);
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bgwBusqueda.RunWorkerAsync(txtCodigo.Text);
            }
        }

        private void bgwBusqueda_DoWork(object sender, DoWorkEventArgs e)
        {
            BuscarProductos(e.Argument.ToString());
        }

        private void bgwBusqueda_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LlenarDataGrid();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null)
            {
                try
                {
                    string id = dgvProductos[0, dgvProductos.CurrentRow.Index].Value.ToString();
                    decimal descuento = 0;
                    decimal.TryParse(txtDescuento.Text, out descuento);
                    frm.AgregarProducto(id, (int)nudCantidad.Value, descuento);
                    this.Close();
                }
                catch (InvalidCastException ex)
                {
                    CFuncionesGenerales.MensajeError("No se ha podido agregar el producto. No se pudo realizar una conversión.", ex);
                }
                catch (InvalidOperationException ex)
                {
                    CFuncionesGenerales.MensajeError("No se ha podido agregar el producto. La operación no se pudo efectuar porqué el estado actual del objeto no lo permite.", ex);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    CFuncionesGenerales.MensajeError("No se ha podido agregar el producto. El argumento dado se salió de rango.", ex);
                }
                catch (Exception ex)
                {
                    CFuncionesGenerales.MensajeError("No se ha podido agregar el producto. Ha ocurrido un error genérico.", ex);
                }
            }
            else
            {
                MessageBox.Show("¡Debes seleccionar un producto!", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
