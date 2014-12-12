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
    public partial class frmAgregarInventario : Form
    {
        string idProd;
        frmInventario frm;

        public frmAgregarInventario(string idProd, string nomProd, frmInventario frm)
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
            this.frm = frm;
            this.idProd = idProd;
            lblNombreProducto.Text = nomProd;
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.CFuncionesGenerales.VerificarEsNumero(ref sender, ref e, true);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtCantidad.Text.Equals(""))
                    if (decimal.Parse(txtCantidad.Text) > 0)
                    {
                        Clases.CProducto.AgregarInventario(idProd, int.Parse(txtCantidad.Text));
                        frm.dgvProducto[3, frm.dgvProducto.CurrentRow.Index].Value = decimal.Parse(frm.dgvProducto[3, frm.dgvProducto.CurrentRow.Index].Value.ToString()) + decimal.Parse(txtCantidad.Text);
                        if (decimal.Parse(frm.dgvProducto[3, frm.dgvProducto.CurrentRow.Index].Value.ToString()) <= 3)
                        {
                            frm.dgvProducto.Rows[frm.dgvProducto.RowCount - 1].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                            frm.dgvProducto.Rows[frm.dgvProducto.RowCount - 1].DefaultCellStyle.ForeColor = Color.FromArgb(150, 0, 0);
                            frm.dgvProducto.Rows[frm.dgvProducto.RowCount - 1].DefaultCellStyle.SelectionBackColor = Color.FromArgb(150, 0, 0);
                            frm.dgvProducto.Rows[frm.dgvProducto.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
                        }
                        else
                        {
                            frm.dgvProducto.Rows[frm.dgvProducto.RowCount - 1].DefaultCellStyle.BackColor = SystemColors.Control;
                            frm.dgvProducto.Rows[frm.dgvProducto.RowCount - 1].DefaultCellStyle.ForeColor = SystemColors.WindowText;
                            frm.dgvProducto.Rows[frm.dgvProducto.RowCount - 1].DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
                            frm.dgvProducto.Rows[frm.dgvProducto.RowCount - 1].DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
                        }
                        this.Close();
                    }
                    else
                        MessageBox.Show("La cantidad debe ser mayor a cero", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Debes de ingresar alguna cantidad", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ocurrio un error al tratar de agregar productos al inventario. No se pudo conectar con la base de datos.", ex);
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ocurrio un error al tratar de agregar productos al inventario. Hubo un error al tratar de dar formato a una variable", ex);
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ocurrio un error al tratar de agregar productos al inventario. Hubo un desbordamiento.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ocurrio un error al tratar de agregar productos al inventario. El método obtuvo un argumento nulo y éste lo no acepto.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ocurrio un error al tratar de agregar productos al inventario. Ocurrio un error genérico.", ex);
            }
        }
    }
}
