using GYM.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GYM.Formularios.PuntoDeVenta
{
    public partial class frmProducto : Form
    {
        string id;
        int celdaSeleccionad = -1;

        #region Instancia
        private static frmProducto frmInstancia;
        public static frmProducto Instancia
        {
            get
            {
                if (frmInstancia == null)
                    frmInstancia = new frmProducto();
                else if (frmInstancia.IsDisposed)
                    frmInstancia = new frmProducto();
                return frmInstancia;
            }
            set
            {
                frmInstancia = value;
            }
        }
        #endregion

        public frmProducto()
        {
            InitializeComponent();
            if (frmMain.nivelUsuario == 1)
            {
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
                btnImprimir.Location = btnEditar.Location;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            (new frmAgregarProducto()).ShowDialog();
        }

        private void BuscarProductos(string busqueda)
        {
            try
            {
                dgvProducto.Rows.Clear();
                string sql = "SELECT id, nombre, marca, descripcion, precio FROM producto WHERE id='" + busqueda + "' OR nombre LIKE '%" + busqueda + "%' OR marca LIKE '%" + busqueda + "%'";
                DataTable dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    string des;
                    if (dr["descripcion"] != DBNull.Value)
                        des = dr["descripcion"].ToString();
                    else
                        des = "";
                    dgvProducto.Rows.Add(new object[] { dr["id"].ToString(), dr["nombre"].ToString(), dr["marca"].ToString(), des, dr["precio"] });
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de buscar un producto. No se pudo conectar a la base de datos.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de buscar un producto. Ocurrio un error genérico.", ex);
            }
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                BuscarProductos(txtBusqueda.Text);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProducto.CurrentRow != null)
            {
                (new frmEditarProducto(id)).ShowDialog(this);
                BuscarProductos(txtBusqueda.Text);
            }
            else
                MessageBox.Show("seleccione un producto valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                celdaSeleccionad = e.RowIndex;
                id = this.dgvProducto[0, e.RowIndex].Value.ToString();
            }
            catch
            {
            }
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            if (Clases.CFuncionesGenerales.AperturaUnicaFormulario(this.Name))
                this.Close();
        }

        private void Productos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Clases.CFuncionesGenerales.EliminarFormularioLista(this.Name);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProducto.CurrentRow != null)
                {

                    if (MessageBox.Show("¿Seguro que desea eliminar el producto seleccionado?", "GymCSY", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Clases.CProducto p = new Clases.CProducto();
                        p.EliminarProducto(id);
                        celdaSeleccionad = -1;
                        MessageBox.Show("Se ha eliminado el producto con éxito", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BuscarProductos(txtBusqueda.Text);
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro valido", "Seleccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo eliminar el producto. No se pudo conectar a la base de datos.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo eliminar el producto. Ocurrio un error genérico.", ex);
            }
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            Clases.CFuncionesGenerales.CargarInterfaz(this);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                (new Clases.CTicket()).ImprimirCodigoProducto(dgvProducto[0, dgvProducto.CurrentRow.Index].Value.ToString());
            }
            catch (XmlException ex)
            {
                MessageBox.Show("Ocurrio un error al leer el archivo de configuración. Linea y posición de error: " + ex.LineNumber + ", " + ex.LinePosition, "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (PathTooLongException ex)
            {
                CFuncionesGenerales.MensajeError("No se pudo imprimir el código. La ruta especificada para el arhcivo de configuración en muy larga.", ex);
            }
            catch (DirectoryNotFoundException ex)
            {
                CFuncionesGenerales.MensajeError("No se pudo imprimir el código. El directorio del archivo de configuración no se pudo encontrar.", ex);
            }
            catch (FileNotFoundException ex)
            {
                CFuncionesGenerales.MensajeError("No se pudo imprimir el código. El archivo de configuración no se pudo encontrar.", ex);
            }
            catch (IOException ex)
            {
                CFuncionesGenerales.MensajeError("No se pudo imprimir el código. Ocurrio un error de E/S.", ex);
            }
            catch (NotSupportedException ex)
            {
                CFuncionesGenerales.MensajeError("No se pudo imprimir el código. El método invocado no admite la funcionalidad invocada.", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                CFuncionesGenerales.MensajeError("No se pudo imprimir el código. Windows ha denegado el acceso al archivo de configuración por un error de E/S o por un problema de seguridad.", ex);
            }
            catch (System.Security.SecurityException ex)
            {
                CFuncionesGenerales.MensajeError("No se pudo imprimir el código. Se detectó un error de seguridad.", ex);
            }
            catch (ArgumentNullException ex)
            {
                CFuncionesGenerales.MensajeError("No se pudo imprimir el código. El argumento dado en el método es nulo.", ex);
            }
            catch (ArgumentException ex)
            {
                CFuncionesGenerales.MensajeError("No se pudo imprimir el código. El argumento dado en el método no es aceptado por éste.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se pudo imprimir el código. Ha ocurrido un error genérico.", ex);
            }
        }
    }
}
