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

namespace GYM.Formularios.Membresia
{
    public partial class frmMembresia : Form
    {
        int numSocio = 0;

        #region Instancia
        private static frmMembresia frmInstancia;
        public static frmMembresia Instancia
        {
            get
            {
                if (frmInstancia == null)
                    frmInstancia = new frmMembresia();
                else if (frmInstancia.IsDisposed)
                    frmInstancia = new frmMembresia();
                return frmInstancia;
            }
            set
            {
                frmInstancia = value;
            }
        }
        #endregion

        public frmMembresia()
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
        }

        #region Metodos

        private void BuscarMiembros(string textoBusqueda)
        {
            dgvPersonas.Rows.Clear();
            try
            {
                //Fecha_fin
                string sql = "SELECT mi.numSocio, mi.nombre, mi.apellidos, mi.telefono, mi.celular, me.estado, me.fecha_ini, me.fecha_fin AS fecha FROM miembros AS mi LEFT JOIN membresias AS me ON (mi.numSocio=me.numSocio) WHERE mi.numSocio='" + textoBusqueda + "' OR mi.nombre LIKE '%" + textoBusqueda + "%' OR mi.apellidos LIKE '%" + textoBusqueda + "%'";
                DataTable dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    string status = null;
                    string fecha = null;
                    string fechaIni = null;
                    DateTime fechaI;
                    if (dr["estado"] != DBNull.Value)
                    {
                        CMembresia.EstadoMembresia es = (CMembresia.EstadoMembresia)Enum.Parse(typeof(CMembresia.EstadoMembresia), dr["estado"].ToString());
                        if (es == CMembresia.EstadoMembresia.Terminada)
                            status = "Inactivo";
                        else if (es == CMembresia.EstadoMembresia.Activa)
                            status = "Activo";
                        else if (es == CMembresia.EstadoMembresia.Pendiente)
                            status = "Pendiente";
                        else if (es == CMembresia.EstadoMembresia.Rechazada)
                            status = "Rechazada";
                    }
                    else
                        status = "Sin información";
                    if (dr["fecha"] != DBNull.Value)
                        fecha = DateTime.Parse(dr["fecha"].ToString()).ToString("dd") + " de " + DateTime.Parse(dr["fecha"].ToString()).ToString("MMMM") + " del " + DateTime.Parse(dr["fecha"].ToString()).ToString("yyyy");
                    else
                        fecha = "No especificada";
                    if (dr["fecha_ini"] != DBNull.Value)
                    {
                        fechaI = DateTime.Parse(dr["fecha_ini"].ToString());
                        fechaIni = fechaI.ToString("dd") + " de " + fechaI.ToString("MMMM") + " del " + fechaI.ToString("yyyy");
                    }
                    else
                        fechaIni = "Sin información";
                    dgvPersonas.Rows.Add(new object[] { dr["numSocio"], dr["nombre"].ToString() + " " + dr["apellidos"].ToString(), status, fechaIni, fecha });
                }
            }
            catch (MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de conectar con la base de datos.", ex);
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de dar formato a una variable.", ex);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El argumento dado en algún método se ha salido del rango.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Algún método llamado en buscar miembros no admite argumentos nulos.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        #endregion

        #region Eventos
        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BuscarMiembros(txtBusqueda.Text);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {

                if (numSocio != 0)
                    if (!Clases.CMembresia.TieneMembresia(numSocio))
                        (new frmNuevaMembresia(numSocio)).ShowDialog(this);
                    else
                        if (MessageBox.Show("El socio seleccionado ya tiene una membresía.\n¿Deseas renovarla?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                            btnEditar.PerformClick();
            }
            catch (MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de conectar con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (numSocio != 0)
                    if (Clases.CMembresia.TieneMembresia(numSocio))
                        (new frmEditarMembresia(numSocio)).ShowDialog(this);
                    else
                        if (MessageBox.Show("El socio seleccionado no tiene una membresía.\n¿Desea generar una nueva membresía?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                            btnNuevo.PerformClick();
            }
            catch (MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de conectar con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void dgvPersonas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                numSocio = int.Parse(dgvPersonas[0, e.RowIndex].Value.ToString());
            }
            catch 
            {
            }
        }

        private void frmMembresia_Shown(object sender, EventArgs e)
        {
            txtBusqueda.Focus();
        }
        #endregion

        private void frmMembresia_Load(object sender, EventArgs e)
        {
            try
            {
                Clases.CFuncionesGenerales.CargarInterfaz(this);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }
    }
}
