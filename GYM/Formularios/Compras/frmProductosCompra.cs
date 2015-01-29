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
        DataTable dt = new DataTable();
        frmNuevaCompra frm;

        public frmProductosCompra(frmNuevaCompra frm)
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
            this.frm = frm;
        }

        private void BuscarProductos(string p)
        {
            MensajeError m = new MensajeError(CFuncionesGenerales.MensajeError);
            try
            {
                string sql = "SELECT id, nombre,cant,cant_alm, costo FROM producto WHERE (id='" + p + "' OR nombre LIKE '%" + p + "%') AND control_stock=1";
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
                    dgvProductos.Rows.Add(new object[] { dr["id"], dr["nombre"], int.Parse(dr["cant"].ToString()) + int.Parse(dr["cant_alm"].ToString()), decimal.Parse(dr["costo"].ToString()) });
                    Application.DoEvents();
                }
                dgvProductos_RowEnter(dgvProductos, new DataGridViewCellEventArgs(0, 0));
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

        private void CalcularTotales()
        {
            try
            {
                decimal desc;
                decimal.TryParse(txtDescuento.Text, out desc);
                decimal costo = decimal.Parse(dgvProductos[3, dgvProductos.CurrentRow.Index].Value.ToString(), System.Globalization.NumberStyles.Currency);
                lblTotal.Text = ((costo * nudCantidad.Value) - desc).ToString("C2");
            }
            catch (FormatException ex)
            {
                CFuncionesGenerales.MensajeError("No se pudo calcular el total. No se pudo convertir la variable.", ex);
            }
            catch (OverflowException ex)
            {
                CFuncionesGenerales.MensajeError("No se pudo calcular el total. Ocurrió un desbordamiento.", ex);
            }
            catch (ArgumentNullException ex)
            {
                CFuncionesGenerales.MensajeError("No se pudo calcular el total. El argumento dado es nulo.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se pudo calcular el total. Ocurrió un error genérico.", ex);
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
                if (!bgwBusqueda.IsBusy)
                {
                    txtCodigo.Enabled = false;
                    CFuncionesGenerales.DeshabilitarBotonCerrar(this);
                    tmrEspera.Enabled = true;
                    bgwBusqueda.RunWorkerAsync(txtCodigo.Text);
                }
            }
        }

        private void bgwBusqueda_DoWork(object sender, DoWorkEventArgs e)
        {
            BuscarProductos(e.Argument.ToString());
        }

        private void bgwBusqueda_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tmrEspera.Enabled = false;
            CFuncionesGenerales.frmEsperaClose();
            System.Threading.Thread.Sleep(300);
            LlenarDataGrid();
            txtCodigo.Enabled = true;
            CFuncionesGenerales.HabilitarBotonCerrar(this);
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

        private void tmrEspera_Tick(object sender, EventArgs e)
        {
            tmrEspera.Enabled = false;
            CFuncionesGenerales.frmEspera("Espere mientras se efectua la búsqueda", this);
        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductos.CurrentRow != null)
                    CalcularTotales();
                else
                    lblTotal.Text = "$0.00";
            }
            catch
            {
            }
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductos.CurrentRow != null)
                    CalcularTotales();
                else
                    lblTotal.Text = "$0.00";
            }
            catch
            {
            }
        }

        private void dgvProductos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvProductos.CurrentRow != null)
                    CalcularTotales();
                else
                    lblTotal.Text = "$0.00";
            }
            catch
            {
            }
        }
    }
}
