using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GYM.Clases;

namespace GYM.Formularios.PuntoDeVenta
{
    public partial class frmEditarProducto : Form
    {
        CProducto p = new CProducto();
        string idProducto;
        public frmEditarProducto(string id)
        {
            InitializeComponent();
            try
            {
                p = CProducto.ObtenerProductoPorID(id);
                idProducto = id;

                txbNombre.Text = p.Nombre;
                txbMarca.Text = p.Marca;
                cboPieza.Text = p.Unidad;
                txbPrecio.Text = p.Precio.ToString();
                txbCosto.Text = p.Costo.ToString();
                txbDescripcion.Text = p.Descripcion;
                if (p.Marca == "")
                {
                    chbProductoServicio.Checked = true;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al obtener los datos del producto. No se pudo conectar con la base de datos.", ex);
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al obtener los datos del producto. Ocurrio un error al tratar de dar formato a una variable.", ex);
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al obtener los datos del producto. Ocurrio un debordamiento.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al obtener los datos del producto. El argumento dado al método es nulo y éste no lo acepta.", ex);
            }
        }

        private void frmEditarProducto_Load(object sender, EventArgs e)
        {
            Clases.CFuncionesGenerales.CargarInterfaz(this);
            if (Clases.CFuncionesGenerales.AperturaUnicaFormulario(this.Name))
                this.Close();
        }

        private void btnAgregarOtro_Click(object sender, EventArgs e)
        {
            txbNombre.Enabled = !txbNombre.Enabled;
            txbMarca.Enabled = !txbMarca.Enabled;
            //txbUnidad.Enabled = !txbUnidad.Enabled;
            txbDescripcion.Enabled = !txbDescripcion.Enabled;
            txbPrecio.Enabled = !txbPrecio.Enabled;
            txbCosto.Enabled = !txbCosto.Enabled;
            btnAceptar.Enabled = true;
        }

        private void frmEditarProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            Clases.CFuncionesGenerales.EliminarFormularioLista(this.Name);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    p.ControlStock = chbControlStock.Checked;
                    p.Costo = decimal.Parse(txbCosto.Text);
                    p.Precio = decimal.Parse(txbPrecio.Text);
                    p.Descripcion = txbDescripcion.Text;
                    p.Unidad = cboPieza.Text;
                    p.UpdateTime = DateTime.Now;
                    p.UpdateUser = frmMain.id;
                    p.EditarProducto();
                    MessageBox.Show("Se ha actualizados con éxito", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("Favor de llenar todo los campos", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de editar el producto. No se pudo conectar con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de editar el producto. Ha ocurrido un error genérico.", ex);
            }
        }

        private bool Validar()
        {
            try
            {
                if (txbNombre.Text.Equals(""))
                {
                    MessageBox.Show("Debes ingresar el nombre del producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (txbMarca.Text.Equals("") && txbMarca.Enabled)
                {
                    MessageBox.Show("Debes ingresar la marca del producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (this.txbPrecio.Text.Trim() == "")
                {
                    MessageBox.Show("El campo precio no puede ir vacío.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (Convert.ToDecimal(txbPrecio.Text.Trim()) < 0)
                {
                    MessageBox.Show("Debes ingresar el precio de venta del producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (this.txbCosto.Text.Trim() == "")
                {
                    MessageBox.Show("El campo costo no puede ir vacío.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (Convert.ToDecimal(txbCosto.Text.Trim()) < 0)
                {
                    MessageBox.Show("Debes ingresar el precio de compra del producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Hubo un error al verificar los campos. Ocurrio un error al tratar de dar formato a una variable.", ex);
                return false;
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Hubo un error al verificar los campos. Ocurrio un desbordamiento.", ex);
                return false;
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Hubo un error al verificar los campos. Ocurrio un error genérico.", ex);
                return false;
            }
        }

        private void chbProductoServicio_CheckedChanged(object sender, EventArgs e)
        {
            if (chbProductoServicio.Checked)
            {
                cboPieza.Enabled = txbMarca.Enabled = chbControlStock.Checked = chbControlStock.Enabled = false;
                txbMarca.Text = "";
            }
            else
            {
                cboPieza.Enabled = txbMarca.Enabled = chbControlStock.Checked = chbControlStock.Enabled = true;
            }
        }

        private void txtPrecioCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            CFuncionesGenerales.VerificarEsNumero(ref sender, ref e, false);
        }
    }
}
