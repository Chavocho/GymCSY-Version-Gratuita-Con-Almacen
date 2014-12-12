using GYM.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYM.Formularios.Membresia
{
    public partial class frmEditarMembresia : Form
    {
        int numSocio;
        DateTime fechaFin;
        CMembresia.EstadoMembresia es;
        CMembresia mem;
        CRegistro_membresias rMem;

        #region Metodos
        public frmEditarMembresia(int numSocio)
        {
            InitializeComponent();
            this.numSocio = numSocio;
            mem = new Clases.CMembresia(numSocio);
            rMem = new CRegistro_membresias();
        }

        private void MostrarDatosMembresia()
        {
            try
            {
                if (mem.FechaFin > DateTime.Now)
                    dtpFechaInicio.Value = mem.FechaFin;
                es = mem.Estado;
                lblUsuarioCreador.Text = ObtenerNombreUsuario(mem.CreateUser);
                lblFechaCreacion.Text = mem.CreateTime.ToString("dd/MM/yyyy hh:mm tt");
                lblUsuarioModificador.Text = ObtenerNombreUsuario(mem.UpdateUser);
                if (mem.UpdateTime != new DateTime())
                    lblFechaModificacion.Text = mem.UpdateTime.ToString("dd/MM/yyyy hh:mm tt");
                else
                    lblFechaModificacion.Text = "Sin información.";
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El valor dado a superado el rango esperado.", ex);
            }
        }

        private void CargarNombreMiembro()
        {
            try
            {
                string sql = "SELECT nombre, apellidos FROM miembros WHERE numSocio='" + numSocio.ToString() + "'";
                DataTable dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                    lblNombreMiembro.Text = dr["nombre"].ToString() + " " + dr["apellidos"].ToString();
                lblNombreMiembro.Left = this.Width - lblNombreMiembro.Width - 20;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de conectar con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private string ObtenerNombreUsuario(int idUsuario)
        {
            string valor = "Sin información.";
            try
            {
                string sql = "SELECT userName FROM usuarios WHERE id='" + idUsuario.ToString() + "'";
                DataTable dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                    valor = dr["userName"].ToString();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de conectar con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
            return valor;
        }

        private bool ValidarDatos()
        {
            if (cbxTipo.SelectedIndex < 0)
            {
                MessageBox.Show("Debes seleccionar un tipo de membresía", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cbxTipoPago.SelectedIndex < 0)
            {
                MessageBox.Show("Debes seleccionar un tipo de pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbxTipoPago.Focus();
                return false;
            }
            if (txtPrecio.Text == "")
            {
                MessageBox.Show("Debes ingresar el precio que pagará el miembro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (txtFolio.Text == "")
            {
                MessageBox.Show("Debes ingresar el folio de remisión", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (txtTerminacion.Text == "" && cbxTipoPago.SelectedIndex == 1)
            {
                MessageBox.Show("Debes ingresar una terminacion de tarjeta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTerminacion.Focus();
                return false;
            }
            if (txtFolioTicket.Text == "" && cbxTipoPago.SelectedIndex == 1)
            {
                MessageBox.Show("Debes ingresar el folio del ticket de pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtFolioTicket.Focus();
                return false;
            }
            return true;
        }

        private void AgregarMovimientoCaja()
        {
            decimal ef= 0, ta = 0;
            try
            {
                if (cbxTipoPago.SelectedIndex == 0)
                    ef = decimal.Parse(txtPrecio.Text);
                else
                    ta = decimal.Parse(txtPrecio.Text);
                MySql.Data.MySqlClient.MySqlCommand sql = new MySql.Data.MySqlClient.MySqlCommand();
                sql.CommandText = "INSERT INTO caja (efectivo, tarjeta, tipo_movimiento, fecha, descripcion) VALUES (?, ?, ?, ?, ?)";
                sql.Parameters.AddWithValue("@efectivo", ef);
                sql.Parameters.AddWithValue("@tarjeta", ta);
                sql.Parameters.AddWithValue("@tipo_movimiento", 0);
                sql.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                sql.Parameters.AddWithValue("@descripcion", "RENOVACIÓN MEMBRESÍA");
                Clases.ConexionBD.EjecutarConsulta(sql);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de conectar con la base de datos.", ex);
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de dar formato a una variable.", ex);
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un desbordamiento.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Algún método llamado en AgregarMovimientoCaja no admite argumentos nulos.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }
        #endregion

        #region Eventos
        private void frmEditarMembresia_Load(object sender, EventArgs e)
        {
            try
            {
                Clases.CFuncionesGenerales.CargarInterfaz(this);
                mem.ObtenerDatosMiembro();
                MostrarDatosMembresia();
                CargarNombreMiembro();
                CMembresia.EstadoMembresia es = Clases.CMembresia.EstadoActualMembresia(numSocio);
                if (es == CMembresia.EstadoMembresia.Terminada || es == CMembresia.EstadoMembresia.Rechazada)
                    dtpFechaInicio.Enabled = true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de conectar con la base de datos.", ex);
            }
            catch (InvalidCastException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de realizar la conversión de una variable.", ex);
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de dar formato a una variable.", ex);
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un desbordamiento.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Algún método llamado en el evento Load no admite argumentos nulos.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarDatos())
                {
                    mem.Estado = CMembresia.EstadoMembresia.Pendiente;
                    mem.FechaFin = fechaFin;
                    mem.FechaInicio = dtpFechaInicio.Value;
                    mem.UpdateUser = frmMain.id;

                    rMem.CreateUser = frmMain.id;
                    rMem.IDMembresia = mem.IDMembresia;
                    rMem.Descripcion = txtDescripcion.Text;
                    rMem.FechaFin = fechaFin;
                    rMem.FechaInicio = dtpFechaInicio.Value;
                    rMem.FolioRemision = int.Parse(txtFolio.Text);
                    rMem.Tipo = cbxTipoPago.SelectedIndex + 1;
                    if (txtTerminacion.Text.Trim() != "")
                        rMem.Terminacion = Convert.ToInt32(txtTerminacion.Text);
                    else
                        rMem.Terminacion = 0;
                    if (txtFolioTicket.Text.Trim() != "")
                        rMem.FolioTicket = Convert.ToInt32(txtFolioTicket.Text);
                    else
                        rMem.FolioTicket = 0;

                    mem.EditarMembresia();
                    rMem.InsertarRegistroMembresias();
                    AgregarMovimientoCaja();
                    if (!GYM.Clases.CFuncionesGenerales.versionGratuita)
                        if (MessageBox.Show("¿Desea imprimir el ticket?", "GymCSY", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                            (new Clases.CTicket()).ImprimirTicketMembresia(numSocio);
                    MessageBox.Show("Membresía renovada", "Membresías", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (System.Xml.XmlException ex)
            {
                MessageBox.Show("Ha ocurrido un error al querer leer del archivo XML. Mensaje de error:" + ex.Message + "\nNúmero de linea y posición: " + ex.LineNumber + ", " + ex.LinePosition,
                    "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.IO.PathTooLongException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("La ruta del directorio es muy larga.", ex);
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El directorio del archivo de configuración no se encontró.", ex);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se encontro el archivo de configuración.", ex);
            }
            catch (System.IO.IOException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error de E/S.", ex);
            }
            catch (InvalidOperationException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("La llamada al método no se pudo efectuar porque el estado actual del objeto no lo permite.", ex);
            }
            catch (NotSupportedException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo leer o modificar la secuencia de datos.", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El sistema ha negado el acceso al archivo de configuración.\nPuede deberse a un error de E/S o a un error de seguridad.", ex);
            }
            catch (System.Security.SecurityException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error de seguridad.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El método no acepta referencias nulas.", ex);
            }
            catch (ArgumentException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El argumento que se pasó al método no es aceptado por este.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void cbxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxTipo.SelectedIndex)
            {
                case 0:
                    fechaFin = dtpFechaInicio.Value.AddDays(7);
                    lblFechaFin.Text = dtpFechaInicio.Value.AddDays(7).ToString("dd") + " de " + dtpFechaInicio.Value.AddDays(7).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddDays(7).ToString("yyyy");
                    break;
                case 1:
                    fechaFin = dtpFechaInicio.Value.AddMonths(1);
                    lblFechaFin.Text = dtpFechaInicio.Value.AddMonths(1).ToString("dd") + " de " + dtpFechaInicio.Value.AddMonths(1).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddMonths(1).ToString("yyyy");
                    break;
                case 2:
                    fechaFin = dtpFechaInicio.Value.AddMonths(2);
                    lblFechaFin.Text = dtpFechaInicio.Value.AddMonths(2).ToString("dd") + " de " + dtpFechaInicio.Value.AddMonths(2).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddMonths(2).ToString("yyyy");
                    break;
                case 3:
                    fechaFin = dtpFechaInicio.Value.AddMonths(3);
                    lblFechaFin.Text = dtpFechaInicio.Value.AddMonths(3).ToString("dd") + " de " + dtpFechaInicio.Value.AddMonths(3).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddMonths(3).ToString("yyyy");
                    break;
                case 4:
                    fechaFin = dtpFechaInicio.Value.AddMonths(4);
                    lblFechaFin.Text = dtpFechaInicio.Value.AddMonths(4).ToString("dd") + " de " + dtpFechaInicio.Value.AddMonths(4).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddMonths(4).ToString("yyyy");
                    break;
                case 5:
                    fechaFin = dtpFechaInicio.Value.AddMonths(5);
                    lblFechaFin.Text = dtpFechaInicio.Value.AddMonths(5).ToString("dd") + " de " + dtpFechaInicio.Value.AddMonths(5).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddMonths(5).ToString("yyyy");
                    break;
                case 6:
                    fechaFin = dtpFechaInicio.Value.AddMonths(6);
                    lblFechaFin.Text = dtpFechaInicio.Value.AddMonths(6).ToString("dd") + " de " + dtpFechaInicio.Value.AddMonths(6).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddMonths(6).ToString("yyyy");
                    break;
                case 7:
                    fechaFin = dtpFechaInicio.Value.AddMonths(7);
                    lblFechaFin.Text = dtpFechaInicio.Value.AddMonths(7).ToString("dd") + " de " + dtpFechaInicio.Value.AddMonths(7).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddMonths(7).ToString("yyyy");
                    break;
                case 8:
                    fechaFin = dtpFechaInicio.Value.AddMonths(8);
                    lblFechaFin.Text = dtpFechaInicio.Value.AddMonths(8).ToString("dd") + " de " + dtpFechaInicio.Value.AddMonths(8).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddMonths(8).ToString("yyyy");
                    break;
                case 9:
                    fechaFin = dtpFechaInicio.Value.AddMonths(9);
                    lblFechaFin.Text = dtpFechaInicio.Value.AddMonths(9).ToString("dd") + " de " + dtpFechaInicio.Value.AddMonths(9).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddMonths(9).ToString("yyyy");
                    break;
                case 10:
                    fechaFin = dtpFechaInicio.Value.AddMonths(10);
                    lblFechaFin.Text = dtpFechaInicio.Value.AddMonths(10).ToString("dd") + " de " + dtpFechaInicio.Value.AddMonths(10).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddMonths(10).ToString("yyyy");
                    break;
                case 11:
                    fechaFin = dtpFechaInicio.Value.AddMonths(11);
                    lblFechaFin.Text = dtpFechaInicio.Value.AddMonths(11).ToString("dd") + " de " + dtpFechaInicio.Value.AddMonths(11).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddMonths(11).ToString("yyyy");
                    break;
                case 12:
                    fechaFin = dtpFechaInicio.Value.AddYears(1);
                    lblFechaFin.Text = dtpFechaInicio.Value.AddYears(1).ToString("dd") + " de " + dtpFechaInicio.Value.AddYears(1).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddYears(1).ToString("yyyy");
                    break;
            }
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaInicio.Value.Date < mem.FechaFin.Date && es == CMembresia.EstadoMembresia.Terminada)
                dtpFechaInicio.Value = mem.FechaFin;
            else if (dtpFechaInicio.Value.Date < DateTime.Now.Date)
                dtpFechaInicio.Value = DateTime.Now;
            switch (cbxTipo.SelectedIndex)
            {
                case 0:
                    fechaFin = dtpFechaInicio.Value.AddDays(7);
                    lblFechaFin.Text = dtpFechaInicio.Value.AddDays(7).ToString("dd") + " de " + dtpFechaInicio.Value.AddDays(7).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddDays(7).ToString("yyyy");
                    break;
                case 1:
                    fechaFin = dtpFechaInicio.Value.AddMonths(1);
                    lblFechaFin.Text = dtpFechaInicio.Value.AddMonths(1).ToString("dd") + " de " + dtpFechaInicio.Value.AddMonths(1).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddMonths(1).ToString("yyyy");
                    break;
                case 2:
                    fechaFin = dtpFechaInicio.Value.AddMonths(2);
                    lblFechaFin.Text = dtpFechaInicio.Value.AddMonths(2).ToString("dd") + " de " + dtpFechaInicio.Value.AddMonths(2).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddMonths(2).ToString("yyyy");
                    break;
                case 3:
                    fechaFin = dtpFechaInicio.Value.AddMonths(3);
                    lblFechaFin.Text = dtpFechaInicio.Value.AddMonths(3).ToString("dd") + " de " + dtpFechaInicio.Value.AddMonths(3).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddMonths(3).ToString("yyyy");
                    break;
                case 4:
                    fechaFin = dtpFechaInicio.Value.AddMonths(4);
                    lblFechaFin.Text = dtpFechaInicio.Value.AddMonths(4).ToString("dd") + " de " + dtpFechaInicio.Value.AddMonths(4).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddMonths(4).ToString("yyyy");
                    break;
                case 5:
                    fechaFin = dtpFechaInicio.Value.AddMonths(5);
                    lblFechaFin.Text = dtpFechaInicio.Value.AddMonths(5).ToString("dd") + " de " + dtpFechaInicio.Value.AddMonths(5).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddMonths(5).ToString("yyyy");
                    break;
                case 6:
                    fechaFin = dtpFechaInicio.Value.AddMonths(6);
                    lblFechaFin.Text = dtpFechaInicio.Value.AddMonths(6).ToString("dd") + " de " + dtpFechaInicio.Value.AddMonths(6).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddMonths(6).ToString("yyyy");
                    break;
                case 7:
                    fechaFin = dtpFechaInicio.Value.AddMonths(7);
                    lblFechaFin.Text = dtpFechaInicio.Value.AddMonths(7).ToString("dd") + " de " + dtpFechaInicio.Value.AddMonths(7).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddMonths(7).ToString("yyyy");
                    break;
                case 8:
                    fechaFin = dtpFechaInicio.Value.AddMonths(8);
                    lblFechaFin.Text = dtpFechaInicio.Value.AddMonths(8).ToString("dd") + " de " + dtpFechaInicio.Value.AddMonths(8).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddMonths(8).ToString("yyyy");
                    break;
                case 9:
                    fechaFin = dtpFechaInicio.Value.AddMonths(9);
                    lblFechaFin.Text = dtpFechaInicio.Value.AddMonths(9).ToString("dd") + " de " + dtpFechaInicio.Value.AddMonths(9).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddMonths(9).ToString("yyyy");
                    break;
                case 10:
                    fechaFin = dtpFechaInicio.Value.AddMonths(10);
                    lblFechaFin.Text = dtpFechaInicio.Value.AddMonths(10).ToString("dd") + " de " + dtpFechaInicio.Value.AddMonths(10).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddMonths(10).ToString("yyyy");
                    break;
                case 11:
                    fechaFin = dtpFechaInicio.Value.AddMonths(11);
                    lblFechaFin.Text = dtpFechaInicio.Value.AddMonths(11).ToString("dd") + " de " + dtpFechaInicio.Value.AddMonths(11).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddMonths(11).ToString("yyyy");
                    break;
                case 12:
                    fechaFin = dtpFechaInicio.Value.AddYears(1);
                    lblFechaFin.Text = dtpFechaInicio.Value.AddYears(1).ToString("dd") + " de " + dtpFechaInicio.Value.AddYears(1).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddYears(1).ToString("yyyy");
                    break;
            }
        }   
        
        private void cbxTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPrecio.Enabled = true;
            txtFolio.Enabled = true;
            txtDescripcion.Enabled = true;
            txtTerminacion.Enabled = (cbxTipoPago.SelectedIndex == 1 ? true : false);
            txtFolioTicket.Enabled = (cbxTipoPago.SelectedIndex == 1 ? true : false);
        } 
        
        private void txtFolioTicket_EnabledChanged(object sender, EventArgs e)
        {
         
        }

        #endregion

        private void chbStatus_CheckedChanged(object sender, EventArgs e)
        {

        }

       
     
    }
}
