using GYM.Clases;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYM.Formularios
{
    public partial class frmPendientes : Form
    {
        #region Instancia
        private static frmPendientes frmInstancia;
        public static frmPendientes Instancia
        {
            get
            {
                if (frmInstancia == null)
                    frmInstancia = new frmPendientes();
                else if (frmInstancia.IsDisposed)
                    frmInstancia = new frmPendientes();
                return frmInstancia;
            }
            set
            {
                frmInstancia = value;
            }
        }
        #endregion

        int id;
        DataTable dt;

        public frmPendientes()
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
            cboPendientes.SelectedIndex = 0;
        }

        private void ColumnasMembresia()
        {
            dgvPendientes.Columns[3].Visible = false;
        }

        private void ColumnasLocker()
        {
            dgvPendientes.Columns[3].Visible = true;
        }

        private void BuscarPendientesMembresia()
        {
            try
            {
                dt = new DataTable();
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT s.numSocio, s.nombre, s.apellidos, m.id, m.fecha_ini, m.fecha_fin, MAX(r.id) as rID, r.descripcion, r.precio, r.folio_remision, r.create_user_id, r.create_time " + 
                    "FROM miembros AS s INNER JOIN membresias AS m ON (m.numSocio=s.numSocio) AND m.estado=?estado INNER JOIN registro_membresias AS r ON(m.id=r.membresia_id) GROUP BY m.id ORDER BY r.create_time;";
                sql.Parameters.AddWithValue("?estado", Clases.CMembresia.EstadoMembresia.Pendiente);
                dt = ConexionBD.EjecutarConsultaSelect(sql);
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BuscarPendientesLocker()
        {
            try
            {
                dt = new DataTable();
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT l.id, MAX(r.id), r.nom_persona, s.numSocio, s.nombre, s.apellidos, l.num, l.fecha_ini, l.fecha_fin, r.descripcion, r.create_time, r.create_user_id, r.folio_remision, r.precio " +
                    "FROM locker AS l LEFT JOIN registro_locker AS r ON (l.id=r.locker_id) LEFT JOIN miembros AS s ON (l.numSocio=s.numSocio) WHERE l.estado=?estado GROUP BY l.id ORDER BY r.create_time";
                sql.Parameters.AddWithValue("?estado", frmLockers.EstadoLocker.Pendiente);
                dt = ConexionBD.EjecutarConsultaSelect(sql);
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarDataGrid()
        {
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    DateTime fechaIni = DateTime.Parse(dr["fecha_ini"].ToString()), fechaFin = DateTime.Parse(dr["fecha_fin"].ToString()), fechaPago = DateTime.Parse(dr["create_time"].ToString());
                    if (cboPendientes.SelectedIndex == 0)
                    {
                        dgvPendientes.Rows.Add(new object[] { dr["id"], dr["numSocio"], dr["nombre"].ToString() + " " + dr["apellidos"].ToString(), "", dr["descripcion"], fechaIni.ToString("dd/MM/yyyy"), fechaFin.ToString("dd/MM/yyyy"), fechaPago.ToString("dd/MM/yyyy"), dr["folio_remision"], ((decimal)dr["precio"]).ToString("C2"), CFuncionesGenerales.NombreUsuario(dr["create_user_id"].ToString()) });
                    }
                    else
                    {
                        string nom = "";
                        string numSocio = "Sin información";
                        if (dr["nom_persona"] != DBNull.Value)
                            nom = dr["nom_persona"].ToString();
                        else 
                            nom = dr["nombre"].ToString() + " " + dr["apellidos"].ToString();
                        if (dr["numSocio"] != DBNull.Value)
                            numSocio = dr["numSocio"].ToString();
                        dgvPendientes.Rows.Add(new object[] { dr["id"], numSocio, nom, dr["num"], dr["descripcion"], fechaIni.ToString("dd/MM/yyyy"), fechaFin.ToString("dd/MM/yyyy"), fechaPago.ToString("dd/MM/yyyy"), dr["folio_remision"], ((decimal)dr["precio"]).ToString("C2"), CFuncionesGenerales.NombreUsuario(dr["create_user_id"].ToString()) });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void EstadoMembresia(int id, CMembresia.EstadoMembresia e)
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "UPDATE membresias SET estado=?estado WHERE id=?id";
                sql.Parameters.AddWithValue("?estado", e);
                sql.Parameters.AddWithValue("?id", id);
                ConexionBD.EjecutarConsulta(sql);
                sql.Parameters.Clear();
                sql.CommandText = "UPDATE registro_membresias SET autorizacion_user=?user, fecha_autorizacion=NOW() WHERE membresia_id=?id";
                sql.Parameters.AddWithValue("?user", frmMain.id);
                sql.Parameters.AddWithValue("?id", id);
                ConexionBD.EjecutarConsulta(sql);
                dgvPendientes.Rows.RemoveAt(dgvPendientes.CurrentRow.Index);
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido cambiar el estado de la membresía. Hubo un error al tratar de conectar con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido cambiar el estado de la membresía. Ha ocurrido un error genérico.", ex);
            }
        }

        private void EstadoLocker(int id, frmLockers.EstadoLocker e)
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "UPDATE locker SET estado=?estado WHERE id=?id";
                sql.Parameters.AddWithValue("?estado", e);
                sql.Parameters.AddWithValue("?id", id);
                ConexionBD.EjecutarConsulta(sql);
                sql.Parameters.Clear();
                sql.CommandText = "UPDATE registro_locker SET autorizacion_user=?user, fecha_autorizacion=NOW() WHERE locker_id=?id";
                sql.Parameters.AddWithValue("?user", frmMain.id);
                sql.Parameters.AddWithValue("?id", id);
                ConexionBD.EjecutarConsulta(sql);
                dgvPendientes.Rows.RemoveAt(dgvPendientes.CurrentRow.Index);
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido cambiar el estado del locker. Hubo un error al tratar de conectar con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido cambiar el estado del locker. Ha ocurrido un error genérico.", ex);
            }
        }

        private void RegresarCaja()
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT tipo_pago, precio FROM registro_membresias WHERE membresia_id=?id LIMIT 1";
                sql.Parameters.AddWithValue("?id", id);
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    sql.Parameters.Clear();
                    sql.CommandText = "INSERT INTO caja (efectivo, tarjeta, tipo_movimiento, fecha, descripcion, create_user_id, create_time) " +
                        "VALUES (?efectivo, ?tarjeta, ?tipo_movimiento, NOW(), ?descripcion, ?create_user_id, NOW())";
                    if (dr["tipo_pago"].ToString() == "1")
                    {
                        sql.Parameters.AddWithValue("?efectivo", decimal.Parse(dr["precio"].ToString()) * -1);
                        sql.Parameters.AddWithValue("?tarjeta", 0);
                    }
                    else
                    {
                        sql.Parameters.AddWithValue("?efectivo", 0);
                        sql.Parameters.AddWithValue("?tarjeta", decimal.Parse(dr["precio"].ToString()) * -1);
                    }
                    sql.Parameters.AddWithValue("?tipo_movimiento", 1);
                    sql.Parameters.AddWithValue("?descripcion", "SE HA CANCELADO LA MEMBRESÍA.");
                    sql.Parameters.AddWithValue("?create_user_id", frmMain.id);
                    ConexionBD.EjecutarConsulta(sql);
                }
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha registrado el movimiento en caja. Ocurrió un error al conectar con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se ha registrado el movimiento en caja. Ocurrió un error genérico.", ex);
            }
        }

        private void RegresarLocker()
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT tipo_pago, precio FROM registro_locker WHERE locker_id=?id LIMIT 1";
                sql.Parameters.AddWithValue("?id", id);
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    sql.Parameters.Clear();
                    sql.CommandText = "INSERT INTO caja (efectivo, tarjeta, tipo_movimiento, fecha, descripcion, create_user_id, create_time) " +
                        "VALUES (?efectivo, ?tarjeta, ?tipo_movimiento, NOW(), ?descripcion, ?create_user_id, NOW())";
                    if (dr["tipo_pago"].ToString() == "0")
                    {
                        sql.Parameters.AddWithValue("?efectivo", decimal.Parse(dr["precio"].ToString()) * -1);
                        sql.Parameters.AddWithValue("?tarjeta", 0);
                    }
                    else
                    {
                        sql.Parameters.AddWithValue("?efectivo", 0);
                        sql.Parameters.AddWithValue("?tarjeta", decimal.Parse(dr["precio"].ToString()) * -1);
                    }
                    sql.Parameters.AddWithValue("?tipo_movimiento", 1);
                    sql.Parameters.AddWithValue("?descripcion", "SE HA CANCELADO LA RENTA DEL LOCKER.");
                    sql.Parameters.AddWithValue("?create_user_id", frmMain.id);
                    ConexionBD.EjecutarConsulta(sql);
                }
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha registrado el movimiento en caja. Ocurrió un error al conectar con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se ha registrado el movimiento en caja. Ocurrió un error genérico.", ex);
            }
        }

        private void cboPendientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvPendientes.Rows.Clear();
            switch (cboPendientes.SelectedIndex)
            {
                case 0:
                    ColumnasMembresia();
                    break;
                case 1:
                    ColumnasLocker();
                    break;
            }
            tmrEspera.Enabled = true;
            bgwBusqueda.RunWorkerAsync(cboPendientes.SelectedIndex);
        }

        private void bgwBusqueda_DoWork(object sender, DoWorkEventArgs e)
        {
            if ((int)e.Argument == 0)
            {
                BuscarPendientesMembresia();
            }
            else
            {
                BuscarPendientesLocker();
            }
        }

        private void bgwBusqueda_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tmrEspera.Enabled = false;
            CFuncionesGenerales.frmEsperaClose();
            LlenarDataGrid();
        }

        private void tmrEspera_Tick(object sender, EventArgs e)
        {
            tmrEspera.Enabled = false;
            CFuncionesGenerales.frmEspera("Espere, búscando pendientes", this);
        }

        private void dgvPendientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPendientes.RowCount > 0)
                {
                    id = (int)dgvPendientes[0, e.RowIndex].Value;
                    if (cboPendientes.SelectedIndex == 0)
                    {
                        if (e.ColumnIndex == 11)
                        {
                            EstadoMembresia(id, CMembresia.EstadoMembresia.Activa);
                        }
                        else if (e.ColumnIndex == 12)
                        {
                            DialogResult r = MessageBox.Show("¿Realmente desea rechazar la membresía de " + dgvPendientes[2, e.RowIndex].Value.ToString() + "?", "GymCSY", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                            if (r == System.Windows.Forms.DialogResult.Yes)
                            {
                                EstadoMembresia(id, CMembresia.EstadoMembresia.Rechazada);
                                RegresarCaja();
                            }
                        }
                    }
                    else if (cboPendientes.SelectedIndex == 1)
                    {
                        if (e.ColumnIndex == 11)
                        {
                            EstadoLocker(id, frmLockers.EstadoLocker.Ocupado);
                        }
                        else if (e.ColumnIndex == 12)
                        {
                            DialogResult r = MessageBox.Show("¿Realmente desea rechazar la renta de locker a " + dgvPendientes[2, e.RowIndex].Value.ToString() + "?", "GymCSY", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                            if (r == System.Windows.Forms.DialogResult.Yes)
                            {
                                EstadoLocker(id, frmLockers.EstadoLocker.Rechazado);
                                RegresarLocker();
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }
    }
}
