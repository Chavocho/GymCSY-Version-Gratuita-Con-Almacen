using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GYM.Formularios.POS;
using GYM.Clases;

namespace GYM.Formularios.POS
{
    public partial class frmProductos : Form
    {
        string id;
        decimal precio;
        List<int> cant;
        DataTable dt = new DataTable();
        frmPuntoVenta frm;

        public frmProductos(IWin32Window frm)
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
            this.frm = (frmPuntoVenta)frm;
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CFuncionesGenerales.DeshabilitarBotonCerrar(this);
                tmrEspera.Enabled = true;
                txtCodigo.Enabled = false;
                bgwBusqueda.RunWorkerAsync(txtCodigo.Text);
            }
        }

        private void BuscarProducto(string paramBusqueda)
        {
            try
            {
                cant = new List<int>();
                dgvProductos.Rows.Clear();
                string sql = "SELECT id, nombre, precio, cant, control_stock FROM producto WHERE id='" + paramBusqueda + "' OR nombre LIKE '%" + paramBusqueda + "%' ORDER BY precio ASC";
                dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al buscar los productos.", ex);
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de dar formato a una variable.", ex);
            }
            catch (InvalidCastException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de convertir una variable a otro tipo.", ex);
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un desbordamiento.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Algún método invocado en BuscarProducto no admite argumentos nulos.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void LlenarDataGrid()
        {
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dgvProductos.Rows.Add(dr["id"], dr["nombre"], int.Parse(dr["cant"].ToString()), decimal.Parse(dr["precio"].ToString()), dr["control_stock"]);
                    cant.Add(Convert.ToInt32(dr["cant"]));
                }
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al mostrar la información.", ex);
            }
        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if ((cant[dgvProductos.CurrentRow.Index] - Convert.ToInt32(nudCantidad.Value)) >= 0)
                {
                    lblTotal.Text = (precio * nudCantidad.Value).ToString("C2");
                }
                else
                {
                    MessageBox.Show("No se puede agregar más productos de las existencias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    nudCantidad.Value -= 1;
                }
            }
            catch (InvalidOperationException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("La llamada al método no se ha podido realizar porque el estado actual del objeto no lo permite.", ex);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El argumento dado se sale de rango.", ex);
            }
        }

        private void InsertarProductoVenta()
        {
            try
            {
                frm.AgregarProductoDataGrid(id, Convert.ToInt32(nudCantidad.Value), true);
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un desbordamiento.", ex);
            }
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (nudCantidad.Value == 0)
            {
                MessageBox.Show("La cantidad de productos debe ser mayor a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("No haz seleccionado ningún producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frm.AgregarProductoDataGrid(id, Convert.ToInt32(nudCantidad.Value), true);
            System.Threading.Thread.Sleep(100);
            this.Close();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            Clases.CFuncionesGenerales.CargarInterfaz(this);
            txtCodigo.Focus();
        }

        private void dgvProductos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvProductos.CurrentRow != null)
                {
                    nudCantidad.Value = 1;
                    for (int i = 0; i < cant.Count; i++)
                    {
                        dgvProductos[2, i].Value = cant[i];
                    }
                    id = dgvProductos[0, e.RowIndex].Value.ToString();
                    precio = decimal.Parse(dgvProductos[3, e.RowIndex].Value.ToString(), System.Globalization.NumberStyles.Currency);
                    lblTotal.Text = (precio * nudCantidad.Value).ToString("C2");
                }
            }
            catch (InvalidOperationException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El estado actual del objeto no permite ejecutar operaciones en él.", ex);
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de dar formato una variable.", ex);
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un desbordamiento.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Algún método invocado en el evento CellClick del DataGridView no admite argumentos nulos.", ex);
            }
            catch (ArgumentException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void bgwBusqueda_DoWork(object sender, DoWorkEventArgs e)
        {
            BuscarProducto(e.Argument.ToString());
        }

        private void bgwBusqueda_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tmrEspera.Enabled = false;
            CFuncionesGenerales.frmEsperaClose();
            CFuncionesGenerales.HabilitarBotonCerrar(this);
            txtCodigo.Enabled = true;
            LlenarDataGrid();
        }

        private void tmrEspera_Tick(object sender, EventArgs e)
        {
            tmrEspera.Enabled = false;
            CFuncionesGenerales.frmEspera("Espere, buscando productos", this);
        }
    }
}
