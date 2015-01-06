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
    public partial class frmInventario : Form
    {
        string id;

        #region Instancia
        private static frmInventario frmInstancia;
        public static frmInventario Instancia
        {
            get
            {
                if (frmInstancia == null)
                    frmInstancia = new frmInventario();
                else if (frmInstancia.IsDisposed)
                    frmInstancia = new frmInventario();
                return frmInstancia;
            }
            set
            {
                frmInstancia = value;
            }
        }
        #endregion

        public frmInventario()
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
        }

        #region Metodos
        private void BuscarProducto(string valor)
        {
            try
            {
                string sql = "SELECT id, nombre, cant, cant_alm, control_stock FROM producto WHERE id='" + valor + "' OR nombre LIKE '%" + valor + "%'";
                DataTable dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
                LlenarDataGrid(dt);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al buscar un producto. No se pudo conectar a la base de datos.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al buscar un producto. Ha ocurrido un error genérico.", ex);
            }
        }

        private void BuscarBajas()
        {
            try
            {
                string sql = "SELECT id, nombre, cant, cant_alm, control_stock FROM producto WHERE cant<=10 OR cant_alm<=10";
                DataTable dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
                LlenarDataGrid(dt);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al buscar un producto. No se pudo conectar a la base de datos.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al buscar un producto. Ha ocurrido un error genérico.", ex);
            }
        }

        private void LlenarDataGrid(DataTable dt)
        {
            try
            {
                dgvProducto.Rows.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["id"].ToString(), nom = dr["nombre"].ToString();
                    int cant = 0;
                    int cantAlm = 0;
                    int cantTot = 0;
                    bool controlStock = false;
                    if (dr["control_stock"].ToString() == "1")
                        controlStock = true;
                    if (dr["cant"] != DBNull.Value)
                        cant = int.Parse(dr["cant"].ToString());
                    if (dr["cant_alm"] != DBNull.Value)
                        cantAlm = int.Parse(dr["cant_alm"].ToString());
                    cantTot = cant + cantAlm;
                    dgvProducto.Rows.Add(new object[] { id, nom, cant, controlStock, cantAlm, cantTot });
                    if ((cant <= 10 || cantAlm <= 10) && controlStock)
                    {
                        dgvProducto.Rows[dgvProducto.RowCount - 1].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                        dgvProducto.Rows[dgvProducto.RowCount - 1].DefaultCellStyle.ForeColor = Color.FromArgb(150, 0, 0);
                        dgvProducto.Rows[dgvProducto.RowCount - 1].DefaultCellStyle.SelectionBackColor = Color.FromArgb(150, 0, 0);
                        dgvProducto.Rows[dgvProducto.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
                    }
                }
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo mostrar la información. No se pudo convertir una variable porqué el formato dado no es correcto.", ex);
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo mostrar la información. Ocurrio un desbordamiento.", ex);
            }
            catch (InvalidOperationException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo mostrar la información. El estado actual del objeto no lo permitió.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo mostrar la información. Ha ocurrido un error genérico.", ex);
            }
        }

        #endregion

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BuscarProducto(txtBusqueda.Text);
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            if (dgvProducto.CurrentRow != null)
            {
                if ((bool)dgvProducto[3, dgvProducto.CurrentRow.Index].Value == true)
                {
                    (new Formularios.PuntoDeVenta.frmAgregarInventario(dgvProducto[0, dgvProducto.CurrentRow.Index].Value.ToString(), dgvProducto[1, dgvProducto.CurrentRow.Index].Value.ToString(), this)).ShowDialog(this);
                }
                else
                {
                    MessageBox.Show("No puedes agregar productos al inventario de un producto que no tiene habilitado controlar stock.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void chbBajas_CheckedChanged(object sender, EventArgs e)
        {
            if (chbBajas.Checked)
            {
                BuscarBajas();
                txtBusqueda.Enabled = false;
            }
            else
                txtBusqueda.Enabled = true;
        }

        private void btnCantidadAlmacen_Click(object sender, EventArgs e)
        {
            if (dgvProducto.CurrentRow != null)
            {
                if ((bool)dgvProducto[3, dgvProducto.CurrentRow.Index].Value == true)
                {
                    (new frmAlmacenMostrador(id)).ShowDialog(this);
                }
                else
                {
                    MessageBox.Show("No puedes mover productos entre inventarios de un producto que no tiene habilitado controlar stock.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgvProducto_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = dgvProducto[0, e.RowIndex].Value.ToString();
            }
            catch
            {
            }
        }
    }
}
