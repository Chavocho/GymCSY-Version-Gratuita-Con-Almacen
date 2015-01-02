using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.Clases
{
    class CProducto
    {
        #region propiedades
        private string id;
        private string nombre;
        private string marca;
        private string descripcion;
        private string unidad;
        private decimal precio;
        private decimal costo;
        private DateTime createTime;
        private int createUser;
        private DateTime updateTime;
        private int updateUser;
        private int cantidad;
        private int cantAlmacen;
        private bool controlStock;

        #region settes and gettes
        public int UpdateUser
        {
            get { return updateUser; }
            set { updateUser = value; }
        }

        public DateTime UpdateTime
        {
            get { return updateTime; }
            set { updateTime = value; }
        }

        public int CreateUser
        {
            get { return createUser; }
            set { createUser = value; }
        }

        public DateTime CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }

        public decimal Costo
        {
            get { return costo; }
            set { costo = value; }
        }

        public decimal Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public string Unidad
        {
            get { return unidad; }
            set { unidad = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public int CantidadAlmacen
        {
            get { return cantAlmacen; }
            set { cantAlmacen = value; }
        }
        
        public bool ControlStock
        {
            get { return controlStock; }
            set { controlStock = value; }
        }
        #endregion

        #endregion

        #region Métodos y Eventos

        /// <summary>
        /// Inicializa una nueva instancia de la clase CProducto
        /// </summary>
        /// <param name="id">ID del producto</param>
        public CProducto(string id)
        {
            ID = id;
            //Cargar datos por ID

        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase CProducto
        /// </summary>
        public CProducto()
        {
        }

        /// <summary>
        /// Función que obtiene la información guardada en la base de datos de un producto.
        /// </summary>
        /// <param name="ID">ID del producto que se desea obtener.</param>
        /// <exception cref="MySql.Data.MySqlClient.MySqlException">Excepción que se lanza cuando ocurre un error con la conexión a la base de datos o con la ejecución de la consulta</exception>
        /// <exception cref="System.FormatException">Excepción que se produce cuando el formato de un argumento no cumple las especificaciones de los parámetros del método invocado.</exception>
        /// <exception cref="Systen.OverflowException">Excepción que se produce cuando una operación aritmética, de conversión de tipo o de conversión de otra naturaleza en un contexto comprobado, da como resultado una sobrecarga.</exception>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de una aplicación.</exception>
        /// <returns>Objeto de la clase CProducto con la información del producto.</returns>
        public static CProducto ObtenerProductoPorID(string ID)
        {
            CProducto t = null;
            try
            {
                t = new CProducto();
                string sql = "SELECT * FROM producto WHERE id='" + ID + "'";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    t.ID = ID;
                    t.Nombre = dr["nombre"].ToString();
                    t.Marca = dr["marca"].ToString();
                    if (dr["descripcion"] == DBNull.Value)
                        t.Descripcion = null;
                    else
                        t.Descripcion = dr["descripcion"].ToString();
                    t.Unidad = dr["unidad"].ToString();
                    t.Precio = Convert.ToDecimal(dr["precio"].ToString());
                    t.Costo = Convert.ToDecimal(dr["costo"].ToString());
                    t.Cantidad = (int)dr["cant"];
                    t.CantidadAlmacen = (int)dr["cant_alm"];
                    string a = dr["control_stock"].ToString();
                    if (a == "0")
                    {
                        t.ControlStock = false;
                    }
                    else
                    {
                        t.ControlStock = true;
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
            catch (OverflowException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }

        /// <summary>
        /// Función que verifica si el código de producto existe.
        /// </summary>
        /// <param name="id">ID del producto a verificar</param>
        /// <exception cref="MySql.Data.MySqlClient.MySqlException">Excepción que se lanza cuando ocurre un error con la conexión a la base de datos o con la ejecución de la consulta</exception>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de una aplicación.</exception>
        /// <returns>Valor booleano que indica si el código existe o no</returns>
        public static bool ExisteCodigo(string id)
        {
            bool existe = false;
            try
            {
                string sql = "SELECT id FROM producto WHERE id='" + id + "'";
                DataTable dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                    existe = true;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return existe;
        }

        /// <summary>
        /// Función que agrega a la cantidad existente en el inventario la cantidad indicada en el parametro
        /// </summary>
        /// <param name="id">ID del producto</param>
        /// <param name="cant">Cantidad a sumar en el inventario</param>
        /// <exception cref="MySql.Data.MySqlClient.MySqlException">Excepción que se lanza cuando ocurre un error con la conexión a la base de datos o con la ejecución de la consulta</exception>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de una aplicación.</exception>
        public static void AgregarInventario(string id, int cant)
        {
            try
            {
                string sql = "UPDATE producto SET cant_alm=cant_alm+" + cant.ToString() + " WHERE id='" + id + "' AND control_stock=1"; ;
                Clases.ConexionBD.EjecutarConsulta(sql);
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
        /// Función que agrega a la cantidad existente en el inventario la cantidad indicada en el parametro
        /// </summary>
        /// <param name="id">ID del producto</param>
        /// <param name="cant">Cantidad a sumar en el inventario</param>
        /// <exception cref="MySql.Data.MySqlClient.MySqlException">Excepción que se lanza cuando ocurre un error con la conexión a la base de datos o con la ejecución de la consulta</exception>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de una aplicación.</exception>
        public static void AgregarInventarioMostrador(string id, int cant)
        {
            try
            {
                string sql = "UPDATE producto SET cant=cant+" + cant.ToString() + " WHERE id='" + id + "' AND control_stock=1"; ;
                Clases.ConexionBD.EjecutarConsulta(sql);
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
        /// Función que descuenta de la cantidad del inventario la cantidad indicada en el parametro
        /// </summary>
        /// <param name="id">ID del producto</param>
        /// <param name="cant">Cantidad a descontar en el inventario</param>
        /// <exception cref="MySql.Data.MySqlClient.MySqlException">Excepción que se lanza cuando ocurre un error con la conexión a la base de datos o con la ejecución de la consulta</exception>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de una aplicación.</exception>
        public static void DescontarInventario(string id, int cant)
        {
            try
            {
                string sql = "UPDATE producto SET cant=cant-" + cant.ToString() + " WHERE id='" + id + "' AND control_stock=1"; ;
                Clases.ConexionBD.EjecutarConsulta(sql);
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
        /// Función que inserta un producto en la base de datos con la información que se encuentran en las propiedades de la clase.
        /// </summary>
        /// <exception cref="MySql.Data.MySqlClient.MySqlException">Excepción que se lanza cuando ocurre un error con la conexión a la base de datos o con la ejecución de la consulta</exception>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de una aplicación.</exception>
        /// <returns>Valor que indica si el producto se inserto correctamente</returns>
        public bool InsertarProducto()
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "INSERT INTO producto (id, nombre, marca, descripcion, unidad, cant, cant_alm, costo, precio, control_stock, create_time, create_user_id) " +
                    "VALUES (?id, ?nombre, ?marca, ?descripcion, ?unidad, ?cant, ?cant_alm, ?costo, ?precio, ?control_stock, NOW(), ?create_user_id)";
                sql.Parameters.AddWithValue("?id", ID);
                sql.Parameters.AddWithValue("?nombre", Nombre);
                sql.Parameters.AddWithValue("?marca", Marca);
                sql.Parameters.AddWithValue("?descripcion", Descripcion);
                sql.Parameters.AddWithValue("?unidad", Unidad);
                sql.Parameters.AddWithValue("?cant", Cantidad);
                sql.Parameters.AddWithValue("?cant_alm", CantidadAlmacen);
                sql.Parameters.AddWithValue("?costo", Costo);
                sql.Parameters.AddWithValue("?precio", Precio);
                sql.Parameters.AddWithValue("?control_stock", ControlStock);
                sql.Parameters.AddWithValue("?create_user_id", frmMain.id);
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
            return true;
        }

        /// <summary>
        /// Función que edita un producto con la información dada en las propiedades de la clase.
        /// </summary>
        /// <exception cref="MySql.Data.MySqlClient.MySqlException">Excepción que se lanza cuando ocurre un error con la conexión a la base de datos o con la ejecución de la consulta</exception>
        /// <exception cref="System.Exception">Representa los errores que se producen durante la ejecución de una aplicación.</exception>
        public void EditarProducto()
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "UPDATE producto SET nombre=?nombre, marca=?marca, descripcion=?descripcion, unidad=?unidad, " +
                    "cant=?cant, cant_alm=?cant_alm, costo=?costo, precio=?precio, control_stock=?control_stock, update_time=NOW(), update_user_id=?update_user_id WHERE id=?id";
                sql.Parameters.AddWithValue("?nombre", Nombre);
                sql.Parameters.AddWithValue("?marca", Marca);
                sql.Parameters.AddWithValue("?descripcion", Descripcion);
                sql.Parameters.AddWithValue("?unidad", Unidad);
                sql.Parameters.AddWithValue("?cant", Cantidad);
                sql.Parameters.AddWithValue("?cant_alm", CantidadAlmacen);
                sql.Parameters.AddWithValue("?costo", Costo);
                sql.Parameters.AddWithValue("?precio", Precio);
                sql.Parameters.AddWithValue("?control_stock", ControlStock);
                sql.Parameters.AddWithValue("?update_user_id", frmMain.id);
                sql.Parameters.AddWithValue("?id", ID);
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
        /// Función que elimina un producto de la base de datos
        /// </summary>
        /// <param name="id">ID del producto a eliminar</param>
        /// <exception cref="MySql.Data.MySqlClient.MySqlException"></exception>
        /// <exception cref="System.Exception"></exception>
        public void EliminarProducto(string id)
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "DELETE FROM producto WHERE id=?id";
                sql.Parameters.AddWithValue("?id", id);
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
        #endregion

    }
}
