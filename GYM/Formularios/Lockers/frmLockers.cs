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
    public partial class frmLockers : Form
    {
        private int numLocker;
        private int idLocker = 0;

        #region Instancia
        private static frmLockers frmInstancia;
        public static frmLockers Instancia
        {
            get
            {
                if (frmInstancia == null)
                    frmInstancia = new frmLockers();
                else if (frmInstancia.IsDisposed)
                    frmInstancia = new frmLockers();
                return frmInstancia;

            }
            set
            {
                frmInstancia = value;
            }
        }
        #endregion

        public enum EstadoLocker
        {
            Ocupado = 0,
            Pendiente = 1,
            Desocupado = 2,
            Rechazado = 3
        }

        public int NumeroLocker
        {
            get { return numLocker; }
            set { numLocker = value; }
        }
        
        public frmLockers()
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
        }

        public void BuscarLockers()
        {
            try
            {
                dgvLockers.Rows.Clear();
                string sql = "SELECT l.id, l.num, l.estado, r.nom_persona, s.nombre, s.apellidos, s.telefono, s.celular FROM locker AS l LEFT JOIN miembros AS s ON (l.numSocio=s.numSocio) LEFT JOIN registro_locker AS r ON (l.id=r.locker_id)";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    string nombre = "Sin información";
                    string tel = "Sin información";
                    string estado = "";
                    if (dr["estado"].ToString() == "0")
                        estado = "Ocupado";
                    else if (dr["estado"].ToString() == "1")
                        estado = "Pendiente";
                    else if (dr["estado"].ToString() == "2")
                        estado = "Desocupado";
                    else if (dr["estado"].ToString() == "3")
                        estado = "Rechazado";
                    if (dr["nombre"] != DBNull.Value)
                    {
                        nombre = dr["nombre"].ToString() + " " + dr["apellidos"].ToString();
                        if (dr["telefono"].ToString().Trim() != "" && dr["celular"].ToString().Trim() != "")
                            tel = dr["telefono"].ToString() + ", " + dr["celular"].ToString();
                        else if (dr["telefono"].ToString().Trim() != "")
                            tel = dr["telefono"].ToString();
                        else if (dr["celular"].ToString().Trim() != "")
                            tel = dr["celular"].ToString();
                    }
                    else if (dr["nom_persona"] != DBNull.Value)
                    {
                        nombre = dr["nom_persona"].ToString();
                    }
                    dgvLockers.Rows.Add(new object[] { dr["id"], dr["num"], nombre, tel, estado });
                }
                dgvLockers_CellClick(dgvLockers, new DataGridViewCellEventArgs(0, 0));
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("No se han podido cargar los lockers. No se pudo conectar a la base de datos.", ex);
            }
            catch (InvalidOperationException ex)
            {
                CFuncionesGenerales.MensajeError("No se han podido cargar los lockers. La operación no se pudo completar debido al estado actual del control DataGridView.", ex);
            }
            catch (ArgumentNullException ex)
            {
                CFuncionesGenerales.MensajeError("No se han podido cargar los lockers. El argumento dado es nulo y el control DataGridView no lo admite.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se han podido cargar los lockers. Ha ocurrido un error genérico.", ex);
            }
        }

        private void InsertarLocker()
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "INSERT INTO locker (numSocio, num, fecha_fin, estado, create_time, create_user_id) " +
                    "VALUES (?numSocio, ?num, NOW(), ?estado, NOW(), ?create_user_id)";
                sql.Parameters.AddWithValue("?numSocio", 0);
                sql.Parameters.AddWithValue("?num", this.NumeroLocker);
                sql.Parameters.AddWithValue("?estado", EstadoLocker.Desocupado);
                sql.Parameters.AddWithValue("?create_user_id", frmMain.id);
                ConexionBD.EjecutarConsulta(sql);
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido crear el locker. No se pudo conectar con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido crear el locker. Ha ocurrido un error genérico.", ex);
            }
        }

        private void EditarLocker()
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "UPDATE locker SET num=?num WHERE id=?id";
                sql.Parameters.AddWithValue("?num", this.NumeroLocker);
                sql.Parameters.AddWithValue("?id", this.idLocker);
                ConexionBD.EjecutarConsulta(sql);
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido editar el locker. No se pudo conectar con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido editar el locker. Ha ocurrido un error genérico.", ex);
            }
        }

        private void EliminarLocker()
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SET foreign_key_checks=0; DELETE FROM locker WHERE id=?id; SET foreign_key_checks=1;";
                sql.Parameters.AddWithValue("?id", this.idLocker);
                ConexionBD.EjecutarConsulta(sql);
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido eliminar el locker. No se pudo conectar con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido eliminar el locker. Ha ocurrido un error genérico.", ex);
            }
        }

        private void dgvLockers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idLocker = (int)dgvLockers[0, e.RowIndex].Value;
                numLocker = (int)dgvLockers[1, e.RowIndex].Value;
            }
            catch
            {
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if ((new frmNumeroLocker(this)).ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                InsertarLocker();
            BuscarLockers();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idLocker > 0)
            {
                if ((new frmNumeroLocker(this, this.numLocker)).ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    EditarLocker();
                BuscarLockers();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idLocker > 0)
            {
                if (MessageBox.Show("¿Deseas realmente eliminar el locker?\n(No se podrá recuperar)", "GymCSY", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    EliminarLocker();
                BuscarLockers();
            }
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (idLocker > 0)
            {
                (new frmAsignarLocker(this, idLocker)).ShowDialog(this);
                BuscarLockers();
            }
        }

        private void frmLockers_Load(object sender, EventArgs e)
        {
            BuscarLockers();
        }
    }
}
