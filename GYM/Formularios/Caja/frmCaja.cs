using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GYM.Clases;

namespace GYM.Formularios
{
    public partial class frmCaja : Form
    {
        DataTable dt;
        decimal totEfe = 0, totTar = 0;

        #region Instancia
        private static frmCaja frmInstancia;
        public static frmCaja Instancia
        {
            get 
            {
                if (frmInstancia == null)
                        frmInstancia = new frmCaja();
                else if (frmInstancia.IsDisposed)
                    frmInstancia = new frmCaja();
                return frmInstancia;

            }
            set 
            {
                frmInstancia = value;
            }
        }
        #endregion

        public frmCaja()
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
        }

        #region Metodos
        /// <summary>
        /// Función que carga las ventas en el DataGridView
        /// </summary>
        /// <param name="concepto">Concepto de venta</param>
        private void CargarVentas(string concepto)
        {
            try
            {
                string sql = "SELECT id, efectivo, tarjeta, tipo_movimiento, fecha, descripcion, create_user_id FROM caja WHERE descripcion LIKE '%" + concepto + "%' ORDER BY fecha;";
                dt = ConexionBD.EjecutarConsultaSelect(sql);
            }
            catch (MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al conectar con la base de datos.", ex);
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error dar formato a una variable.", ex);
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un desbordamiento.", ex);
            }
            catch (InvalidOperationException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El método de CargarVentas no se pudo efectuar porque el estado actual del objeto no lo permite.", ex);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El argumento dado en el formateo de fecha se sale del rango asignado del método.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ningún método en CargarVentas admite un argumento nulo.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        /// <summary>
        /// Función que carga las ventas entre dos fechas
        /// </summary>
        /// <param name="fechaIni">Fecha de inicio</param>
        /// <param name="fechaFin">Fecha de fin</param>
        public void CargarVentas(DateTime fechaIni, DateTime fechaFin)
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT id, efectivo, tarjeta, tipo_movimiento, fecha, descripcion, create_user_id FROM caja WHERE (fecha BETWEEN ? AND ?) ORDER BY fecha";
                sql.Parameters.AddWithValue("@fechaIni", fechaIni.ToString("yyyy-MM-dd") + " 00:00:00");
                sql.Parameters.AddWithValue("@fechaFin", fechaFin.ToString("yyyy-MM-dd") + " 23:59:59");
                dt = ConexionBD.EjecutarConsultaSelect(sql);
            }   
            catch (MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al conectar con la base de datos.", ex);
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error dar formato a una variable.", ex);
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un desbordamiento.", ex);
            }
            catch (InvalidOperationException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El método de CargarVentas no se pudo efectuar porque el estado actual del objeto no lo permite.", ex);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El argumento dado en el formateo de fecha se sale del rango asignado del método.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ningún método en CargarVentas admite un argumento nulo.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void CargarVentas(DateTime fechaIni, DateTime fechaFin, string concepto)
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT id, efectivo, tarjeta, tipo_movimiento, fecha, descripcion, create_user_id FROM caja WHERE descripcion LIKE '%" + concepto + "%' AND (fecha BETWEEN ? AND ?) ORDER BY fecha";
                sql.Parameters.AddWithValue("@fechaIni", fechaIni.ToString("yyyy-MM-dd") + " 00:00:00");
                sql.Parameters.AddWithValue("@fechaFin", fechaFin.ToString("yyyy-MM-dd") + " 23:59:59");
                dt = ConexionBD.EjecutarConsultaSelect(sql);
            }
            catch (MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al conectar con la base de datos.", ex);
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error dar formato a una variable.", ex);
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un desbordamiento.", ex);
            }
            catch (InvalidOperationException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El método de CargarVentas no se pudo efectuar porque el estado actual del objeto no lo permite.", ex);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El argumento dado en el formateo de fecha se sale del rango asignado del método.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ningún método en CargarVentas admite un argumento nulo.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void LlenarDataGrid(DataTable dt)
        {
            dgvCaja.Rows.Clear();
            string tipoMov = "", nomUsu = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["tipo_movimiento"].ToString() == "0")
                    tipoMov = "Entrada";
                else
                    tipoMov = "Salida";
                if (dr["create_user_id"] != DBNull.Value)
                    nomUsu = CFuncionesGenerales.NombreUsuario(dr["create_user_id"].ToString());
                else
                    nomUsu = "Sin información";
                dgvCaja.Rows.Add(new object[] { DateTime.Parse(dr["fecha"].ToString()).ToString("dd-MM-yyyy hh:mm tt"), decimal.Parse(dr["efectivo"].ToString()).ToString("C2"), decimal.Parse(dr["tarjeta"].ToString()).ToString("C2"), tipoMov, dr["descripcion"].ToString(), nomUsu });
            }
            //idMems.Clear();
            //foreach (DataRow dr in dtm.Rows)
            //{
            //    idVenta = "Sin información";
            //    if (dr["tipo_movimiento"].ToString() == "0")
            //        tipoMov = "Entrada";
            //    else
            //        tipoMov = "Salida";
            //    if (dr["um"] != DBNull.Value)
            //        nomUsu = CFuncionesGenerales.NombreUsuario(dr["um"].ToString());
            //    else
            //        nomUsu = "Sin información"; 
            //    if (dr["folio_remision"] != DBNull.Value)
            //        idMembresia = dr["folio_remision"].ToString();
            //    else
            //        idMembresia = "Sin información";
            //    //if (!idMems.Contains(dr["mem"].ToString()))
            //    //{
            //    //    idMems.Add(dr["mem"].ToString());
            //        dgvCaja.Rows.Add(new object[] { idVenta, idMembresia, DateTime.Parse(dr["fecha"].ToString()).ToString("dd-MM-yyyy hh:mm tt"), decimal.Parse(dr["efectivo"].ToString()).ToString("C2"), decimal.Parse(dr["tarjeta"].ToString()).ToString("C2"), tipoMov, dr["descripcion"].ToString(), nomUsu });
            //    //}
            //}
        }

        public void CargarTotalCaja()
        {
            try
            {
                string sql = "SELECT SUM(efectivo) AS ef, SUM(tarjeta) AS ta FROM caja";
                DataTable dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["ef"] != DBNull.Value)
                        totEfe = decimal.Parse(dr["ef"].ToString());
                    if (dr["ta"] != DBNull.Value)
                        totTar = decimal.Parse(dr["ta"].ToString());
                }
                lblVouchersCaja.Text = totTar.ToString("C2");
                lblEfectivoCaja.Text = totEfe.ToString("C2");
            }
            catch (MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al conectar con la base de datos", ex);
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error dar formato a una variable.", ex);
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un desbordamiento.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ningún metodo en CargarTotalCaja admite un argumento nulo.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void CalcularTotales()
        {
            try
            {
                decimal ef = 0, ta = 0;
                for (int i = 0; i < dgvCaja.RowCount; i++)
                {
                    ef += decimal.Parse(dgvCaja[1, i].Value.ToString(), System.Globalization.NumberStyles.Currency);
                    ta += decimal.Parse(dgvCaja[2, i].Value.ToString(), System.Globalization.NumberStyles.Currency);
                }
                lblEfectivoMostrado.Text = ef.ToString("C2");
                lblVouchersMostrado.Text = ta.ToString("C2");
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error dar formato a una variable.", ex);
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un desbordamiento.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ningún metodo en CargarTotalCaja admite un argumento nulo.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }
        #endregion

        private void dtpFechas_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtpFechaInicio.Value > dtpFechaFin.Value)
                    dtpFechaInicio.Value = dtpFechaFin.Value.AddDays(-1);
                if (dtpFechaFin.Value < dtpFechaInicio.Value)
                    dtpFechaFin.Value = dtpFechaInicio.Value.AddDays(1);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("La propiedad Value de los DateTimePicker sobrepasa el rango admitido.", ex);
            }
        }

        private void txtConcepto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (chbRespetarFechas.Checked)
                    CargarVentas(dtpFechaInicio.Value, dtpFechaFin.Value, txtConcepto.Text);
                else
                    CargarVentas(txtConcepto.Text);
        }

        private void frmCaja_Load(object sender, EventArgs e)
        {
            try
            {
                Clases.CFuncionesGenerales.CargarInterfaz(this);
                if (bool.Parse(Clases.CConfiguracionXML.LeerConfiguración("caja", "estado")))
                    btnAbrirCerrar.Text = "Cerrar Caja";
                else
                    btnAbrirCerrar.Text = "Abrir Caja";
                CargarTotalCaja();
                CargarVentas(DateTime.Now, DateTime.Now);
            }
            catch (System.Xml.XmlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al querer leer el archivo de configuración.\nLinea de error y posición: " + ex.LineNumber + ", " + ex.LinePosition + ".", ex);
            }
            catch (System.IO.PathTooLongException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("La ruta del archivo de configuración es muy larga.", ex);
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("La ruta del archivo de configuración no se encontró.", ex);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El archivo de configuración no fue encontrado.", ex);
            }
            catch (System.IO.IOException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error de E/S.", ex);
            }
            catch (NotSupportedException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se admite la llamada al método invocado, o se ha intentado leer, buscar o escribir en una secuencia que no lo admite.", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El sistema operativo a denegado el acceso a un método de E/S o ha ocurrido un tipo de seguridad concreto.", ex);
            }
            catch (System.Security.SecurityException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error de seguridad.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ningún método llamado en el evento Load admite argumentos nulos.", ex);
            }
            catch (ArgumentException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error en un método llamado en el evento Load.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            try
            {
                if (bool.Parse(Clases.CConfiguracionXML.LeerConfiguración("caja", "estado")))
                {
                    Formularios.Caja.frmEntradaSalida frm = new Formularios.Caja.frmEntradaSalida();
                    frm.TipoMovimiento = Formularios.Caja.frmEntradaSalida.Movimiento.Entrada;
                    frm.Caja = this;
                    frm.ShowDialog(this);
                }
                else
                    if (MessageBox.Show("No puedes realizar movimientos de caja si esta está cerrada.\n¿Deseas abrirla?", "GymCSY", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                        (new Formularios.Caja.frmAbrirCaja()).ShowDialog(this);
            }
            catch (System.Xml.XmlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al querer leer el archivo de configuración.\nLinea de error y posición: " + ex.LineNumber + ", " + ex.LinePosition + ".", ex);
            }
            catch (System.IO.PathTooLongException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("La ruta del archivo de configuración es muy larga.", ex);
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("La ruta del archivo de configuración no se encontró.", ex);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El archivo de configuración no fue encontrado.", ex);
            }
            catch (System.IO.IOException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error de E/S.", ex);
            }
            catch (NotSupportedException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se admite la llamada al método invocado, o se ha intentado leer, buscar o escribir en una secuencia que no lo admite.", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El sistema operativo a denegado el acceso a un método de E/S o ha ocurrido un tipo de seguridad concreto.", ex);
            }
            catch (System.Security.SecurityException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error de seguridad.", ex);
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error dar formato a una variable.", ex);
            }
            catch (InvalidOperationException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error, la operación solicitada no se pudo completar porque el estado actual del objeto no lo permite.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ningún método llamado en el evento Load admite argumentos nulos.", ex);
            }
            catch (ArgumentException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error en un método llamado en el evento Load.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            try
            {
                if (bool.Parse(Clases.CConfiguracionXML.LeerConfiguración("caja", "estado")))
                {
                    Formularios.Caja.frmEntradaSalida frm = new Formularios.Caja.frmEntradaSalida();
                    frm.TipoMovimiento = Formularios.Caja.frmEntradaSalida.Movimiento.Salida;
                    frm.Caja = this;
                    frm.ShowDialog(this);
                }
                else
                    if (MessageBox.Show("No puedes realizar movimientos de caja si esta está cerrada.\n¿Deseas abrirla?", "GymCSY", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                        (new Formularios.Caja.frmAbrirCaja()).ShowDialog(this);
            }
            catch (System.Xml.XmlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al querer leer el archivo de configuración.\nLinea de error y posición: " + ex.LineNumber + ", " + ex.LinePosition + ".", ex);
            }
            catch (System.IO.PathTooLongException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("La ruta del archivo de configuración es muy larga.", ex);
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("La ruta del archivo de configuración no se encontró.", ex);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El archivo de configuración no fue encontrado.", ex);
            }
            catch (System.IO.IOException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error de E/S.", ex);
            }
            catch (NotSupportedException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se admite la llamada al método invocado, o se ha intentado leer, buscar o escribir en una secuencia que no lo admite.", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El sistema operativo a denegado el acceso a un método de E/S o ha ocurrido un tipo de seguridad concreto.", ex);
            }
            catch (System.Security.SecurityException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error de seguridad.", ex);
            }
            catch (InvalidOperationException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error, la operación solicitada no se pudo completar porque el estado actual del objeto no lo permite.", ex);
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error dar formato a una variable.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ningún método llamado en el evento Load admite argumentos nulos.", ex);
            }
            catch (ArgumentException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error en un método llamado en el evento Load.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void btnAbrirCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Clases.Caja.EstadoCaja())
                    (new Formularios.Caja.frmCerrarCaja(this)).ShowDialog(this);
                else
                    (new Formularios.Caja.frmAbrirCaja(this)).ShowDialog(this);
            }
            catch (System.Xml.XmlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al querer leer el archivo de configuración.\nLinea de error y posición: " + ex.LineNumber + ", " + ex.LinePosition + ".", ex);
            }
            catch (System.IO.PathTooLongException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("La ruta del archivo de configuración es muy larga.", ex);
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("La ruta del archivo de configuración no se encontró.", ex);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El archivo de configuración no fue encontrado.", ex);
            }
            catch (System.IO.IOException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error de E/S.", ex);
            }
            catch (NotSupportedException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se admite la llamada al método invocado, o se ha intentado leer, buscar o escribir en una secuencia que no lo admite.", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El sistema operativo a denegado el acceso a un método de E/S o ha ocurrido un tipo de seguridad concreto.", ex);
            }
            catch (System.Security.SecurityException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error de seguridad.", ex);
            }
            catch (InvalidOperationException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error, la operación solicitada no se pudo completar porque el estado actual del objeto no lo permite.", ex);
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error dar formato a una variable.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ningún método llamado en el evento Load admite argumentos nulos.", ex);
            }
            catch (ArgumentException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error en un método llamado en el evento Load.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!bgwCaja.IsBusy)
            {
                tmrEspera.Enabled = true;
                bgwCaja.RunWorkerAsync(new object[] { dtpFechaInicio.Value, dtpFechaFin.Value });
            }
        }

        private void btnBuscarConcepto_Click(object sender, EventArgs e)
        {
            if (!bgwCaja.IsBusy)
            {
                tmrEspera.Enabled = true;
                if (chbRespetarFechas.Checked)
                {
                    bgwCaja.RunWorkerAsync(new object[] { dtpFechaInicio.Value, dtpFechaFin.Value, txtConcepto.Text });
                }
                else
                {
                    bgwCaja.RunWorkerAsync(new object[] { txtConcepto.Text });
                }
            }
        }

        private void bgwCaja_DoWork(object sender, DoWorkEventArgs e)
        {
            Array a = (Array)e.Argument;
            switch (a.Length)
            {
                case 1:
                    CargarVentas(a.GetValue(0).ToString());
                    break;
                case 2:
                    CargarVentas((DateTime)a.GetValue(0), (DateTime)a.GetValue(1));
                    break;
                case 3:
                    CargarVentas((DateTime)a.GetValue(0), (DateTime)a.GetValue(1), a.GetValue(2).ToString());
                    break;
            }
        }

        private void bgwCaja_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tmrEspera.Enabled = false;
            CFuncionesGenerales.frmEsperaClose();
            LlenarDataGrid(dt);
            CalcularTotales();
        }

        private void tmrEspera_Tick(object sender, EventArgs e)
        {
            tmrEspera.Enabled = false;
            CFuncionesGenerales.frmEspera("Espere, buscando los movimientos de caja", this);
        }
    }
}
