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
            cboPendientes.SelectedIndex = 0;
        }

        private void ColumnasMembresia()
        {
            DataGridViewColumn id = new DataGridViewColumn();
            DataGridViewColumn numSocio = new DataGridViewColumn();
            DataGridViewColumn socio = new DataGridViewColumn();
            DataGridViewColumn fechaIni = new DataGridViewColumn();
            DataGridViewColumn fechaFin = new DataGridViewColumn();
            DataGridViewButtonColumn btnAceptar = new DataGridViewButtonColumn();
            DataGridViewButtonColumn btnRechazar = new DataGridViewButtonColumn();
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            dgvPendientes.Columns.Clear();
            //Configuración de ID
            id.Visible = false;
            id.Name = "ID";
            id.HeaderText = "ID";
            id.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            id.Width = 1;
            id.Resizable = DataGridViewTriState.False;
            id.ReadOnly = true;
            id.CellTemplate = cell;
            //Configuración de numSocio
            numSocio.Visible = true;
            numSocio.Name = "NumSocio";
            numSocio.HeaderText = "Num. Socio";
            numSocio.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            numSocio.Resizable = DataGridViewTriState.False;
            numSocio.ReadOnly = true;
            numSocio.CellTemplate = cell;
            //Configuración de socio
            socio.Visible = true;
            socio.Name = "Socio";
            socio.HeaderText = "Socio";
            socio.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            socio.Resizable = DataGridViewTriState.False;
            socio.ReadOnly = true;
            socio.CellTemplate = cell;
            //Configuración fecha inicio
            fechaIni.Visible = true;
            fechaIni.Name = "FechaInicio";
            fechaIni.HeaderText = "Fecha Inicio membresía";
            fechaIni.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            fechaIni.Width = 200;
            fechaIni.Resizable = DataGridViewTriState.False;
            fechaIni.ReadOnly = true;
            fechaIni.CellTemplate = cell;
            //Configuración fecha fin
            fechaFin.Visible = true;
            fechaFin.Name = "FechaFin";
            fechaFin.HeaderText = "Fecha vencimiento membresía.";
            fechaFin.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            fechaFin.Width = 220;
            fechaFin.Resizable = DataGridViewTriState.False;
            fechaFin.ReadOnly = true;
            fechaFin.CellTemplate = cell;
            //Configuración botones
            btnAceptar.AutoSizeMode = btnRechazar.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            btnAceptar.Width = btnRechazar.Width = 100;
            btnAceptar.Resizable = btnRechazar.Resizable = DataGridViewTriState.False;
            btnAceptar.UseColumnTextForButtonValue = btnRechazar.UseColumnTextForButtonValue = true;
            btnAceptar.Text = "Aceptar";
            btnRechazar.Text = "Rechazar";

            dgvPendientes.Columns.Add(id);
            dgvPendientes.Columns.Add(numSocio);
            dgvPendientes.Columns.Add(socio);
            dgvPendientes.Columns.Add(fechaIni);
            dgvPendientes.Columns.Add(fechaFin);
            dgvPendientes.Columns.Add(btnAceptar);
            dgvPendientes.Columns.Add(btnRechazar);
        }

        private void ColumnasLocker()
        {
            DataGridViewColumn id = new DataGridViewColumn();
            DataGridViewColumn numSocio = new DataGridViewColumn();
            DataGridViewColumn socio = new DataGridViewColumn();
            DataGridViewColumn num = new DataGridViewColumn();
            DataGridViewColumn fechaIni = new DataGridViewColumn();
            DataGridViewColumn fechaFin = new DataGridViewColumn();
            DataGridViewButtonColumn btnAceptar = new DataGridViewButtonColumn();
            DataGridViewButtonColumn btnRechazar = new DataGridViewButtonColumn();
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            dgvPendientes.Columns.Clear();
            //Configuración de ID
            id.Visible = false;
            id.Name = "ID";
            id.HeaderText = "ID";
            id.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            id.Width = 1;
            id.Resizable = DataGridViewTriState.False;
            id.ReadOnly = true;
            id.CellTemplate = cell;
            //Configuración de numSocio
            numSocio.Visible = true;
            numSocio.Name = "NumSocio";
            numSocio.HeaderText = "Num. Socio";
            numSocio.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            numSocio.Resizable = DataGridViewTriState.False;
            numSocio.ReadOnly = true;
            numSocio.CellTemplate = cell;
            //Configuración de socio
            socio.Visible = true;
            socio.Name = "Socio";
            socio.HeaderText = "Socio";
            socio.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            socio.Resizable = DataGridViewTriState.False;
            socio.ReadOnly = true;
            socio.CellTemplate = cell;
            //Configuración de num
            num.Visible = true;
            num.Name = "Num";
            num.HeaderText = "Número de locker";
            num.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            num.Width = 145;
            num.Resizable = DataGridViewTriState.False;
            num.ReadOnly = true;
            num.CellTemplate = cell;
            //Configuración fecha inicio
            fechaIni.Visible = true;
            fechaIni.Name = "FechaInicio";
            fechaIni.HeaderText = "Fecha inicio renta locker";
            fechaIni.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            fechaIni.Width = 175;
            fechaIni.Resizable = DataGridViewTriState.False;
            fechaIni.ReadOnly = true;
            fechaIni.CellTemplate = cell;
            //Configuración fecha fin
            fechaFin.Visible = true;
            fechaFin.Name = "FechaFin";
            fechaFin.HeaderText = "Fecha fin renta locker";
            fechaFin.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            fechaFin.Width = 175;
            fechaFin.Resizable = DataGridViewTriState.False;
            fechaFin.ReadOnly = true;
            fechaFin.CellTemplate = cell;
            //Configuración botones
            btnAceptar.AutoSizeMode = btnRechazar.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            btnAceptar.Width = btnRechazar.Width = 100;
            btnAceptar.Resizable = btnRechazar.Resizable = DataGridViewTriState.False;  
            btnAceptar.UseColumnTextForButtonValue = btnRechazar.UseColumnTextForButtonValue = true;
            btnAceptar.Text = "Aceptar";
            btnRechazar.Text = "Rechazar";

            dgvPendientes.Columns.Add(id);
            dgvPendientes.Columns.Add(numSocio);
            dgvPendientes.Columns.Add(socio);
            dgvPendientes.Columns.Add(num);
            dgvPendientes.Columns.Add(fechaIni);
            dgvPendientes.Columns.Add(fechaFin);
            dgvPendientes.Columns.Add(btnAceptar);
            dgvPendientes.Columns.Add(btnRechazar);
        }

        private void BuscarPendientesMembresia()
        {
            try
            {
                dt = new DataTable();
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT m.id, s.numSocio, s.nombre, s.apellidos, m.fecha_ini, m.fecha_fin " + 
                    "FROM membresias AS m INNER JOIN miembros AS s ON (m.numSocio=s.numSocio) WHERE m.estado=?estado";
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
                sql.CommandText = "SELECT l.id, r.nom_persona, s.numSocio, s.nombre, s.apellidos, l.num, l.fecha_ini, l.fecha_fin " +
                    "FROM locker AS l LEFT JOIN registro_locker AS r ON (l.id=r.locker_id) LEFT JOIN miembros AS s ON (l.numSocio=s.numSocio) WHERE l.estado=?estado";
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

        private void LlenarDataGrid()
        {
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    DateTime fechaIni = DateTime.Parse(dr["fecha_ini"].ToString()), fechaFin = DateTime.Parse(dr["fecha_fin"].ToString());
                    if (cboPendientes.SelectedIndex == 0)
                    {
                        dgvPendientes.Rows.Add(new object[] { dr["id"], dr["numSocio"], dr["nombre"].ToString() + " " + dr["apellidos"].ToString(), fechaIni.ToString("dd/MM/yyyy"), fechaFin.ToString("dd/MM/yyyy") });
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
                        dgvPendientes.Rows.Add(new object[] { dr["id"], numSocio, nom, dr["num"], fechaIni.ToString("dd/MM/yyyy"), fechaFin.ToString("dd/MM/yyyy") });
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
                    sql.CommandText = "INSERT INTO caja (efectivo, tarjeta, tipo_movimiento, fecha, descripcion) " +
                        "VALUES (?efectivo, ?tarjeta, ?tipo_movimiento, NOW(), ?descripcion)";
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
                    sql.CommandText = "INSERT INTO caja (efectivo, tarjeta, tipo_movimiento, fecha, descripcion) " +
                        "VALUES (?efectivo, ?tarjeta, ?tipo_movimiento, NOW(), ?descripcion)";
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
            tmrEspera_Tick(tmrEspera, new EventArgs());
            LlenarDataGrid();
        }

        private void tmrEspera_Tick(object sender, EventArgs e)
        {
            tmrEspera.Enabled = false;
            CFuncionesGenerales.frmEsperaClose();
        }

        private void dgvPersonas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPendientes.RowCount > 0)
                {
                    id = (int)dgvPendientes[0, e.RowIndex].Value;
                    if (cboPendientes.SelectedIndex == 0)
                    {
                        if (e.ColumnIndex == 5)
                        {
                            EstadoMembresia(id, CMembresia.EstadoMembresia.Activa);
                        }
                        else if (e.ColumnIndex == 6)
                        {
                            EstadoMembresia(id, CMembresia.EstadoMembresia.Rechazada);
                            RegresarCaja();
                        }
                    }
                    else if (cboPendientes.SelectedIndex == 1)
                    {
                        if (e.ColumnIndex == 6)
                        {
                            EstadoLocker(id, frmLockers.EstadoLocker.Ocupado);
                        }
                        else if (e.ColumnIndex == 7)
                        {
                            EstadoLocker(id, frmLockers.EstadoLocker.Rechazado);
                            RegresarLocker();
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
