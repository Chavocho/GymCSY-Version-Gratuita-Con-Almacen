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
    public partial class frmAgregarProducto : Form
    {
        public frmAgregarProducto()
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
            cboPieza.SelectedIndex = 0;
        }

        private void frmAgregarProducto_Load(object sender, EventArgs e)
        {
            Clases.CFuncionesGenerales.CargarInterfaz(this);
            if (Clases.CFuncionesGenerales.AperturaUnicaFormulario(this.Name))
                this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿La información es correcta?", "GymCSY", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (Validar())
                    {
                        Clases.CProducto p = new Clases.CProducto();
                        p.ID = txtCodigo.Text.Trim();
                        p.Nombre = txbNombre.Text.Trim();
                        p.Marca = txbMarca.Text.Trim();
                        p.Descripcion = txbDescripcion.Text.Trim();
                        p.Unidad = cboPieza.Text.Trim();
                        p.Precio = Convert.ToDecimal(txbPrecio.Text.Trim());
                        p.Costo = Convert.ToDecimal(txbCosto.Text.Trim());
                        p.ControlStock = chbControlStock.Checked;
                        p.CreateTime = DateTime.Now;
                        p.CreateUser = frmMain.id;
                        p.Cantidad = int.Parse(txtCantidad.Text);
                        p.CantidadAlmacen = int.Parse(txtCantidadAlmacen.Text);
                        if (p.InsertarProducto())
                        {

                            MessageBox.Show("Se ha insertado el producto con exito", "Producto Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (((Button)sender).Name.Equals(btnAceptar.Name))
                            {
                                this.Close();
                            }
                            else
                            {
                                limpiarFormulario();
                            }
                        }
                        else
                            MessageBox.Show("Se ha generado un error al insertado el producto, intentelo de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo agregar el producto. No se pudo conectar con la base de datos.", ex);
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo agregar el producto. Ocurrio un error al tratar de convertir una variable, el formato no es correcto.", ex);
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo agregar el producto. Ocurrio un desbordamiento.", ex);
            }
            catch (InvalidCastException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo agregar el producto. La conversión de una variable no se pudo realizar.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo agregar el producto. Ha ocurrido un error genérico.", ex);
            }
        }

        private void limpiarFormulario()
        {
            txtCantidad.Text = "";
            txtCodigo.Text = "";
            txbNombre.Text = "";
            txbMarca.Text = "";
            txbDescripcion.Text = "";
            cboPieza.SelectedIndex = 0;
            txbPrecio.Text = "";
            txbCosto.Text = "";
            txtCantidad.Text = "0";
            txtCantidadAlmacen.Text = "0";
            txtCodigo.Text = "";
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
                if (txtCantidad.Text == "" && txtCantidad.Enabled)
                {
                    MessageBox.Show("Debes ingresar la cantidad de producto en el mostrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (txtCantidadAlmacen.Text == "" && txtCantidadAlmacen.Enabled)
                {
                    MessageBox.Show("Debes ingresar la cantidad de producto en el almacen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (txtCodigo.Text == "")
                {
                    MessageBox.Show("Debes ingresar el código de producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (Clases.CProducto.ExisteCodigo(txtCodigo.Text))
                {
                    MessageBox.Show("El código de producto registrado ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnAgregarOtro_Click(object sender, EventArgs e)
        {
            btnAceptar_Click(sender, e);
        }

        private void txbUnidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.CFuncionesGenerales.VerificarEsNumero(ref sender, ref  e, false);
        }

        private void txbPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.CFuncionesGenerales.VerificarEsNumero(ref sender, ref  e, false);
        }

        private void txbCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.CFuncionesGenerales.VerificarEsNumero(ref sender, ref  e, false);
        }

        private void frmAgregarProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            Clases.CFuncionesGenerales.EliminarFormularioLista(this.Name);
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.CFuncionesGenerales.VerificarEsNumero(ref sender, ref e, true);
        }

        private void chbProductoServicio_CheckedChanged(object sender, EventArgs e)
        {
            if (chbProductoServicio.Checked)
            {
                cboPieza.Enabled = txbMarca.Enabled = txtCantidad.Enabled = txtCantidadAlmacen.Enabled = chbControlStock.Checked = chbControlStock.Enabled = false;
                txbMarca.Text = "";
                txtCantidad.Text = "0";
                txtCantidadAlmacen.Text = "0";
            }
            else
            {
                cboPieza.Enabled = txbMarca.Enabled = txtCantidad.Enabled = txtCantidadAlmacen.Enabled = chbControlStock.Checked = chbControlStock.Enabled = true;
                txtCantidad.Text = "0";
                txtCantidadAlmacen.Text = "0";
            }
        }

        private void chbControlStock_CheckedChanged(object sender, EventArgs e)
        {
            if (!chbControlStock.Checked)
            {
                txtCantidad.Text = "0";
                txtCantidadAlmacen.Text = "0";
                txtCantidad.Enabled = false;
                txtCantidadAlmacen.Enabled = false;
            }
            else
            {
                txtCantidad.Enabled = true;
                txtCantidadAlmacen.Enabled = true;
            }
        }
    }
}
