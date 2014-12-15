using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace GYM.Clases
{
    class CRegistro_membresias
    {
        #region Propiedades
        private int id;
        private int idMembresia;
        private DateTime fechaIni;
        private DateTime fechaFin;
        private int tipo;
        private string descripcion;
        private int tipoPago;
        private decimal precio;
        private int terminacion;
        private int folioRemision;
        private int folioTicket;
        private int createUser;
        private DateTime createTime;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int IDMembresia
        {
            get { return idMembresia; }
            set { idMembresia = value; }
        }

        public DateTime FechaInicio
        {
            get { return fechaIni; }
            set { fechaIni = value; }
        }

        public DateTime FechaFin
        {
            get { return fechaFin; }
            set { fechaFin = value; }
        }

        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public int TipoPago
        {
            get { return tipoPago; }
            set { tipoPago = value; }
        }

        public decimal Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public int Terminacion
        {
            get { return terminacion; }
            set { terminacion = value; }
        }

        public int FolioRemision
        {
            get { return folioRemision; }
            set { folioRemision = value; }
        }

        public int FolioTicket
        {
            get { return folioTicket; }
            set { folioTicket = value; }
        }

        public int CreateUser
        {
            get { return createUser; }
            set { createUser = value; }
        }

        public DateTime CreateTime
        {
            get { return createTime; }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Inicializa una nueva instancia de la clase CRegistro_Membresias
        /// </summary>
        public CRegistro_membresias()
        {

        }

        /// <summary>
        /// Función que inserta un nuevo registro de membresías con el valor dados en las propiedades de la clase
        /// </summary>
        /// <exception cref="MySql.Data.MySqlClient.MySqlException">Excepción que se lanza cuando ocurre un error con la conexión a la base de datos o con la ejecución de la consulta</exception>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de una aplicación.</exception>
        public void InsertarRegistroMembresias()
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "INSERT INTO registro_membresias (membresia_id, fecha_fin, fecha_ini, tipo, descripcion, tipo_pago, precio, terminacion, folio_remision, folio_ticket, create_user_id, create_time) " +
                    "VALUES (?membresia_id, ?fecha_fin, ?fecha_ini, ?tipo, ?descripcion, ?tipo_pago, ?precio, ?terminacion, ?folio_remision, ?folio_ticket, ?create_user_id, NOW())";
                sql.Parameters.AddWithValue("?membresia_id", this.IDMembresia);
                sql.Parameters.AddWithValue("?fecha_fin", this.FechaFin);
                sql.Parameters.AddWithValue("?fecha_ini", this.FechaInicio);
                sql.Parameters.AddWithValue("?tipo", this.Tipo);
                sql.Parameters.AddWithValue("?descripcion", this.Descripcion);
                sql.Parameters.AddWithValue("?tipo_pago", this.TipoPago);
                sql.Parameters.AddWithValue("?precio", this.Precio);
                sql.Parameters.AddWithValue("?terminacion", this.Terminacion);
                sql.Parameters.AddWithValue("?folio_remision", this.FolioRemision);
                sql.Parameters.AddWithValue("?folio_ticket", this.FolioTicket);
                sql.Parameters.AddWithValue("?create_user_id", this.CreateUser);
                ConexionBD.EjecutarConsulta(sql);
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

        /// <summary>
        /// Función que obtiene los datos del último registro de membresía.
        /// </summary>
        /// <param name="idMembresia">ID de la membresía con la que esta relacionada el registro.</param>
        /// <exception cref="MySql.Data.MySqlClient.MySqlException"></exception>
        /// <exception cref="System.OverflowException"></exception>
        /// <exception cref="System.FormatException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.Exception"></exception>
        public void ObtenerDatosRegistro(int idMembresia)
        {
            try
            {
                string sql = "SELECT * FROM registro_membresia WHERE membresia_id = '" + idMembresia + "' GROUP BY id LIMIT 1";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    this.ID = (int)dr["id"];
                    this.IDMembresia = idMembresia;
                    this.FechaInicio = DateTime.Parse(dr["fecha_ini"].ToString());
                    this.FechaFin = DateTime.Parse(dr["fecha_fin"].ToString());
                    this.Tipo = int.Parse(dr["tipo"].ToString());
                    this.Descripcion = dr["descripcion"].ToString();
                    this.TipoPago = int.Parse(dr["tipo_pago"].ToString());
                    this.Precio = decimal.Parse(dr["precio"].ToString());
                    this.Terminacion = int.Parse(dr["terminacion"].ToString());
                    this.FolioRemision = int.Parse(dr["folio_remision"].ToString());
                    this.FolioTicket = int.Parse(dr["folio_ticket"].ToString());
                    this.CreateUser = int.Parse(dr["create_user_id"].ToString());
                    this.createTime = DateTime.Parse(dr["create_time"].ToString());
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (OverflowException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función que obtiene los datos del último registro de membresía.
        /// </summary>
        /// <param name="idMembresia">ID de la membresía con la que esta relacionada el registro.</param>
        /// <exception cref="MySql.Data.MySqlClient.MySqlException"></exception>
        /// <exception cref="System.OverflowException"></exception>
        /// <exception cref="System.FormatException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.Exception"></exception>
        public void ObtenerDatosRegistroID(int id)
        {
            try
            {
                string sql = "SELECT * FROM registro_membresia WHERE id = '" + id + "' GROUP BY id LIMIT 1";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    this.ID = (int)dr["id"];
                    this.IDMembresia = idMembresia;
                    this.FechaInicio = DateTime.Parse(dr["fecha_ini"].ToString());
                    this.FechaFin = DateTime.Parse(dr["fecha_fin"].ToString());
                    this.Tipo = int.Parse(dr["tipo"].ToString());
                    this.Descripcion = dr["descripcion"].ToString();
                    this.TipoPago = int.Parse(dr["tipo_pago"].ToString());
                    this.Precio = decimal.Parse(dr["precio"].ToString());
                    this.Terminacion = int.Parse(dr["terminacion"].ToString());
                    this.FolioRemision = int.Parse(dr["folio_remision"].ToString());
                    this.FolioTicket = int.Parse(dr["folio_ticket"].ToString());
                    this.CreateUser = int.Parse(dr["create_user_id"].ToString());
                    this.createTime = DateTime.Parse(dr["create_time"].ToString());
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (OverflowException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función que valida que los datos esten completos en las propiedades
        /// </summary>
        /// <returns>Valor booleano que indica si los datos estan completos o no</returns>
        private bool Validar()
        {
            if (this.IDMembresia == 0)
                return false;
            if (this.FechaFin == null)
                return false;
            if (this.Precio == 0)
                return false;
            if (this.CreateUser == 0)
                return false;
            return true;
        }

        #endregion
    }
}
