using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using GYM.Clases;

namespace GYM.Clases
{
    class CRegistro_trabajadores
    {
        #region Propiedades
        private int id;
        private int numTrabajador;
        private DateTime fecha_modificacion;
        private int usuario;

        public int Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }     

        public DateTime FechaModificacion
        {
            get { return fecha_modificacion; }
            set { fecha_modificacion = value; }
        }
        
        public int NumeroTrabajador
        {
            get { return numTrabajador; }
            set { numTrabajador = value; }
        }
        
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Función que inserta un nuevo registro de los trabajadores
        /// </summary>
        /// <exception cref="MySql.Data.MySqlClient.MySqlException">Excepción que se lanza cuando ocurre un error con la conexión a la base de datos o con la ejecución de la consulta</exception>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de una aplicación.</exception>
        /// <returns>Valor booleano que indica si se efectuo el registro</returns>
        public bool InsetarRegiostroTrabajadores()
        {
            bool registro = false;
            try
            {
                if (Validar())
                {
                    MySqlCommand sql = new MySqlCommand();
                    sql.CommandText = "INSERT INTO registro_trabajadores " +
                        "(numTrabajador,fecha_modificacion,usuario) VALUES" +
                        "(?,?,?)";
                    sql.Parameters.AddWithValue("@numTrabajador", NumeroTrabajador);
                    sql.Parameters.AddWithValue("@fecha_modificacion", FechaModificacion);
                    sql.Parameters.AddWithValue("@usuario", Usuario);
                    ConexionBD.EjecutarConsulta(sql);
                }
                registro = true;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return registro;
        }

        /// <summary>
        /// Función que valida que los datos esten completos en las propiedades
        /// </summary>
        /// <returns>Valor booleano que indica si los datos estan completos o no</returns>
        private bool Validar()
        {
            if (numTrabajador == 0)
                return false;
            if (FechaModificacion == null)
                return false;
            if (Usuario == 0)
                return false;
            return true;
        }
        #endregion
    }
}
