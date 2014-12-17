using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYM.Clases;

namespace GYM.Clases
{
    class CMembresia
    {
        public enum EstadoMembresia
        {
            Inactiva = 0,
            Pendiente = 1,
            Activa = 2,
            Rechazada = 3
        }

        #region Propiedades
        private int idMembresia;
        private int numSocio;
        private DateTime fechaFin;
        private EstadoMembresia estado;
        private int createUser;
        private DateTime createTime;
        private int updateUser;
        private DateTime updateTime;

        public int IDMembresia
        {
            get { return idMembresia; }
            set { idMembresia = value; }
        }

        public int NumeroSocio
        {
            get { return numSocio; }
            set { numSocio = value; }
        }

        public DateTime FechaFin
        {
            get { return fechaFin; }
            set { fechaFin = value; }
        }
        private DateTime fechaIni;

        public DateTime FechaInicio
        {
            get { return fechaIni; }
            set { fechaIni = value; }
        }

        public EstadoMembresia Estado
        {
            get { return estado; }
            set { estado = value; }
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

        public int UpdateUser
        {
            get { return updateUser; }
            set { updateUser = value; }
        }

        public DateTime UpdateTime
        {
            get { return updateTime; }
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Inicializa la instancia de la clase CMembresia y permite la creación de un objeto
        /// </summary>
        /// <param name="socioId">Número de socio sobre el cual se harán operaciones con su membresia</param>
        public CMembresia(int socioId)
        {
            this.NumeroSocio = socioId;
        }

        /// <summary>
        /// Función que verifica que el socio tenga membresia
        /// </summary>
        /// <exception cref="MySql.Data.MySqlClient.MySqlException">Excepción que se lanza cuando ocurre un error con la conexión a la base de datos o con la ejecución de la consulta</exception>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de una aplicación.</exception>
        /// <returns>Valor booleano que indica si tiene membresia</returns>
        public static bool TieneMembresia(int numSocio)
        {
            bool tiene = false;
            try
            {
                string sql = "SELECT numSocio FROM membresias WHERE numSocio=" + numSocio.ToString() + " LIMIT 1";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                if (dt.Rows.Count > 0)
                    tiene = true;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tiene;
        }

        /// <summary>
        /// Función que indica si un socio tiene una membresía activa
        /// </summary>
        /// <param name="socioId">Número identificador del miembro</param>
        /// <exception cref="MySql.Data.MySqlClient.MySqlException">Excepción que se lanza cuando ocurre un error con la conexión a la base de datos o con la ejecución de la consulta</exception>
        /// <exception cref="System.FormatException">Excepción que se produce cuando el formato de un argumento no cumple las especificaciones de los parámetros del método invocado.</exception>
        /// <exception cref="System.ArgumentNullException">Excepción que se produce cuando se pasa una referencia nula a un método que no la acepta como argumento válido.</exception>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de una aplicación.</exception>
        /// <returns>Valor entero que indica si tiene una membresía activa</returns>
        public static EstadoMembresia EstadoActualMembresia(int socioId)
        {
            EstadoMembresia estadoMembresia = 0;
            try
            {
                string sql = "SELECT estado FROM membresias WHERE numSocio='" + socioId.ToString() + "'";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                    estadoMembresia = (EstadoMembresia)Enum.Parse(typeof(EstadoMembresia), dr["estado"].ToString());
            }
            catch (MySqlException ex)
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
            return estadoMembresia;
        }

        /// <summary>
        /// Función que agrega una nueva membresia a la tabla membresias
        /// </summary>
        /// <exception cref="MySql.Data.MySqlClient.MySqlException">Excepción que se lanza cuando ocurre un error con la conexión a la base de datos o con la ejecución de la consulta</exception>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de una aplicación.</exception>
        /// <returns>Último ID agregado</returns>
        public int InsertarMembresia()
        {
            int idMem = 0;
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "INSERT INTO membresias (numSocio, fecha_ini, fecha_fin, estado, create_time, create_user_id) " +
                    "VALUES (?numSocio, ?fecha_ini, ?fecha_fin, ?estado, NOW(), ?create_user_id)";
                sql.Parameters.AddWithValue("?numSocio", NumeroSocio);
                sql.Parameters.AddWithValue("?fecha_ini", FechaInicio);
                sql.Parameters.AddWithValue("?fecha_fin", FechaFin);
                sql.Parameters.AddWithValue("?estado", Estado);
                sql.Parameters.AddWithValue("?create_user_id", CreateUser);
                ConexionBD.EjecutarConsulta(sql);
                sql.Parameters.Clear();
                sql.CommandText = "SELECT MAX(id) AS i FROM membresias";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                    idMem = (int)dr["i"];
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return idMem;
        }

        /// <summary>
        /// Función que edita la membresia de determinado socio
        /// </summary>
        /// <exception cref="MySql.Data.MySqlClient.MySqlException">Excepción que se lanza cuando ocurre un error con la conexión a la base de datos o con la ejecución de la consulta</exception>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de una aplicación.</exception>
        public void EditarMembresia()
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "UPDATE membresias SET fecha_ini=?fecha_ini, fecha_fin=?fecha_fin, " +
                    "estado=?estado, update_time=NOW(), update_user_id=?update_user_id WHERE id=?id";
                sql.Parameters.AddWithValue("?fecha_ini", FechaInicio);
                sql.Parameters.AddWithValue("?fecha_fin", FechaFin);
                sql.Parameters.AddWithValue("?estado", Estado);
                sql.Parameters.AddWithValue("?update_user_id", UpdateUser);
                sql.Parameters.AddWithValue("?id", IDMembresia);
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
        /// Función que recupera todos los datos del miembro dado en el constructor
        /// </summary>
        /// <exception cref="MySql.Data.MySqlClient.MySqlException">Excepción que se lanza cuando ocurre un error con la conexión a la base de datos o con la ejecución de la consulta</exception>
        /// <exception cref="System.InvalidCastException">Excepción que se produce para una conversión de tipo o una conversión explícita de otra naturaleza que no es válida.</exception>
        /// <exception cref="System.FormatException">Excepción que se produce cuando el formato de un argumento no cumple las especificaciones de los parámetros del método invocado.</exception>
        /// <exception cref="Systen.OverflowException">Excepción que se produce cuando una operación aritmética, de conversión de tipo o de conversión de otra naturaleza en un contexto comprobado, da como resultado una sobrecarga.</exception>
        /// <exception cref="System.ArgumentNullException">Excepción que se produce cuando se pasa una referencia nula a un método que no la acepta como argumento válido.</exception>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de una aplicación.</exception>
        public void ObtenerDatosMiembro()
        {
            try
            {
                string sql = "SELECT * FROM membresias WHERE numSocio='" + NumeroSocio.ToString() + "'";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    NumeroSocio = int.Parse(dr["numSocio"].ToString());
                    IDMembresia = int.Parse(dr["id"].ToString());
                    FechaInicio = DateTime.Parse(dr["fecha_ini"].ToString());
                    FechaFin = DateTime.Parse(dr["fecha_fin"].ToString());
                    Estado = (EstadoMembresia)Enum.Parse(typeof(EstadoMembresia), dr["estado"].ToString());
                    if (dr["create_time"] != DBNull.Value)
                        createTime = DateTime.Parse(dr["create_time"].ToString());
                    else
                        createTime = new DateTime();
                    if (dr["create_user_id"] != DBNull.Value)
                        CreateUser = int.Parse(dr["create_user_id"].ToString());
                    else
                        CreateUser = 0;
                    if (dr["update_time"] != DBNull.Value)
                        updateTime = DateTime.Parse(dr["update_time"].ToString());
                    else
                        updateTime = new DateTime();
                    if (dr["update_user_id"] != DBNull.Value)
                        UpdateUser = int.Parse(dr["update_user_id"].ToString());
                    else
                        UpdateUser = 0;
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (InvalidCastException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (OverflowException ex)
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
        /// Función que, en caso de haber pasado la fecha final de la membresia, la desactiva.
        /// </summary>
        /// <exception cref="MySql.Data.MySqlClient.MySqlException">Excepción que se lanza cuando ocurre un error con la conexión a la base de datos o con la ejecución de la consulta</exception>
        /// <exception cref="System.FormatException">Excepción que se produce cuando el formato de un argumento no cumple las especificaciones de los parámetros del método invocado.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Excepción que se produce cuando el valor de un argumento se encuentra fuera del intervalo de valores permitido definido por el método invocado.</exception>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de una aplicación.</exception>
        public static void DesactivarMembresia()
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "UPDATE membresias SET estado=?estado WHERE DATE_FORMAT(fecha_fin, '%Y-%m-%d')<?fecha_fin";
                sql.Parameters.AddWithValue("?estado", EstadoMembresia.Inactiva);
                sql.Parameters.AddWithValue("?fecha_fin", DateTime.Now.ToString("yyyy-MM-dd"));
                ConexionBD.EjecutarConsulta(sql);
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
