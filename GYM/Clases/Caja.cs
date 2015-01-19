using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.Clases
{
    class CajaException : Exception
    {
        private string mensaje;
        public CajaException(string mensaje)
        {
            this.mensaje = mensaje;
        }

        public override string Message
        {
            get
            {
                return mensaje;
            }
        }
    }

    class Caja
    {
        public static void CrearEstadoCaja()
        {
            try
            {
                string sqlc = "SELECT COUNT(estado) AS c FROM estado_caja";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sqlc);
                foreach (DataRow dr in dt.Rows)
                {
                    if (int.Parse(dr["c"].ToString()) <= 0)
                    {
                        try
                        {
                            string sql = "INSERT INTO estado_caja (estado) VALUES (0)";
                            ConexionBD.EjecutarConsulta(sql);
                        }
                        catch (Exception ex)
                        {
                            throw new CajaException(ex.Message);
                        }
                    }
                }
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

        public static bool EstadoCaja()
        {
            bool estado = false;
            try
            {
                string sql = "SELECT estado FROM estado_caja";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    if (bool.Parse(dr["estado"].ToString()) == true)
                    {
                        estado = true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return estado;
        }

        public static void CambiarEstadoCaja(bool estado)
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "UPDATE estado_caja SET estado=?estado";
                sql.Parameters.AddWithValue("?estado", estado);
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
    }
}
