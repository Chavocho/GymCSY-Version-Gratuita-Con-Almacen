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
        int numSocio = 0, sexo;

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

        private int PreciosH()
        {
            int cant = 0;
            try
            {
                string sql = "SELECT COUNT(id) AS i FROM precio_membresia WHERE sexo=0";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["i"] != DBNull.Value)
                        cant = int.Parse(dr["i"].ToString());
                }
            }
            catch
            {
            }
            return cant;
        }

        private int PreciosM()
        {
            int cant = 0;
            try
            {
                string sql = "SELECT COUNT(id) AS i FROM precio_membresia WHERE sexo=1";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["i"] != DBNull.Value)
                        cant = int.Parse(dr["i"].ToString());
                }
            }
            catch
            {
            }
            return cant;
        }

        private void BuscarMiembros(string textoBusqueda)
        {
            dgvPersonas.Rows.Clear();
            try
            {
                //Fecha_fin
                string sql = "SELECT mi.numSocio, mi.nombre, mi.apellidos, mi.telefono, mi.celular, mi.genero, me.estado, me.fecha_ini, me.fecha_fin AS fecha FROM miembros AS mi LEFT JOIN membresias AS me ON (mi.numSocio=me.numSocio) WHERE mi.numSocio='" + textoBusqueda + "' OR mi.nombre LIKE '%" + textoBusqueda + "%' OR mi.apellidos LIKE '%" + textoBusqueda + "%'";
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
                        if (es == CMembresia.EstadoMembresia.Inactiva)
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
                    dgvPersonas.Rows.Add(new object[] { dr["numSocio"], dr["nombre"].ToString() + " " + dr["apellidos"].ToString(), status, fechaIni, fecha, dr["genero"] });
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

        private void EstadoPendiente(string numSocio)
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "UPDATE membresias SET estado=?estado WHERE numSocio=?numSocio";
                sql.Parameters.AddWithValue("?estado", CMembresia.EstadoMembresia.Pendiente);
                sql.Parameters.AddWithValue("?numSocio", numSocio);
                ConexionBD.EjecutarConsulta(sql);
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido cambiar el estado de la membresía. Ocurrió un error al conectar con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido cambiar el estado de la membresía. Ha ocurrido un error genérico.", ex);
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
                {
                    if (!Clases.CMembresia.TieneMembresia(numSocio))
                    {
                        if (sexo == 0)
                        {
                            if (PreciosH() == 0)
                            {
                                MessageBox.Show("No tienes precios para hombres configurados. Es necesario configurarlos para asignar una membresía.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            if (PreciosM() == 0)
                            {
                                MessageBox.Show("No tienes precios para mujeres configurados. Es necesario configurarlos para asignar una membresía.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        (new frmNuevaMembresia(numSocio, sexo)).ShowDialog(this);
                    }
                    else
                    {
                        if (MessageBox.Show("El socio seleccionado ya tiene una membresía.\n¿Deseas renovarla?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                        {
                            btnEditar.PerformClick();
                        }
                    }
                }
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
                {
                    if (Clases.CMembresia.TieneMembresia(numSocio))
                    {
                        if (sexo == 0)
                        {
                            if (PreciosH() == 0)
                            {
                                MessageBox.Show("No tienes precios para hombres configurados. Es necesario configurarlos para asignar una membresía.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            if (PreciosM() == 0)
                            {
                                MessageBox.Show("No tienes precios para mujeres configurados. Es necesario configurarlos para asignar una membresía.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        (new frmEditarMembresia(numSocio, sexo)).ShowDialog(this);
                    }
                    else
                    {
                        if (MessageBox.Show("El socio seleccionado no tiene una membresía.\n¿Desea generar una nueva membresía?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                        {
                            btnNuevo.PerformClick();
                        }
                    }
                }
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

        private void dgvPersonas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                numSocio = int.Parse(dgvPersonas[0, e.RowIndex].Value.ToString());
                sexo = (int)dgvPersonas[5, e.RowIndex].Value;
            }
            catch
            {
            }
        }

        private void btnPendiente_Click(object sender, EventArgs e)
        {
            if (dgvPersonas.CurrentRow != null)
            {
                if (dgvPersonas[2, dgvPersonas.CurrentRow.Index].Value.ToString() == "Activo")
                {
                    DialogResult r = MessageBox.Show("¿Realmente desea cambiar el estado de la membresía de " + dgvPersonas[1, dgvPersonas.CurrentRow.Index].Value.ToString() + " a pendiente?", "GymCSY", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (r == System.Windows.Forms.DialogResult.Yes)
                    {
                        EstadoPendiente(numSocio.ToString());
                        dgvPersonas[2, dgvPersonas.CurrentRow.Index].Value = "Pendiente";
                    }
                }
            }
        }
    }
}
