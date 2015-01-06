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
    public partial class frmAsignarLocker : Form
    {
        delegate void AbrirMSGBox(string mensaje, Exception ex);
        frmLockers frm;
        DataTable dt = new DataTable();
        int idLocker, numSocio = 0;
        string ultimoFolio = "";

        public frmAsignarLocker(frmLockers frm, int idLocker)
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
            this.frm = frm;
            this.idLocker = idLocker;
            cboTipoPago.SelectedIndex = 0;
            UltimoFolio();
            ConfigFolio();
        }

        private void ConfigFolio()
        {
            if (CConfiguracionXML.ExisteConfiguracion("membresia", "folio"))
            {
                if (bool.Parse(CConfiguracionXML.LeerConfiguración("membresia", "folio")) == true)
                {
                    txtFolio.Text = ultimoFolio;
                    txtFolio.Enabled = false;
                }
                else
                {
                    txtFolio.Enabled = true;
                }
            }
            else
                txtFolio.Enabled = true;
        }

        private void UltimoFolio()
        {
            try
            {
                string sql = "SELECT MAX(id) AS i FROM registro_locker";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["i"] != DBNull.Value)
                        ultimoFolio = ((int)dr["i"] + 1).ToString();
                    else
                        ultimoFolio = "1";
                }
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("Ocurrió un error al generar el nuevo folio. No se ha podido conectar con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("Ocurrió un error al generar el nuevo folio. Ocurrió un error genérico.", ex);
            }
        }

        private bool ExisteFolio(string folio)
        {
            bool existe = false;
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT folio_remision FROM registro_locker WHERE folio_remision=?folio";
                sql.Parameters.AddWithValue("?folio", folio);
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                if (dt.Rows.Count > 0)
                    existe = true;
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("No se pudo comprobar el estado del folio. No se pudo establecer la conexión con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se pudo comprobar el estado del folio. Ocurrió un error genérico.", ex);
            }
            return existe;
        }

        private void BuscarMiembros(string p)
        {
            try
            {
                string sql = "SELECT l.id AS idl, s.numSocio, s.nombre, s.apellidos, s.telefono, s.celular FROM locker AS l RIGHT JOIN miembros AS s ON (l.numSocio=s.numSocio) WHERE s.numSocio='" + p + "' OR s.nombre LIKE '%" + p + "%' OR s.apellidos LIKE '%" + p + "%'";
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
                string tel;
                foreach (DataRow dr in dt.Rows)
                {
                    tel = "";
                    if (dr["telefono"] != DBNull.Value && dr["celular"] != DBNull.Value)
                        tel = dr["telefono"].ToString() + ", " + dr["celular"].ToString();
                    else if (dr["telefono"] != DBNull.Value)
                        tel = dr["telefono"].ToString();
                    else if (dr["celular"] != DBNull.Value)
                        tel = dr["celular"].ToString();
                    dgvSocios.Rows.Add(new object[] { dr["numSocio"], dr["nombre"] + " " + dr["apellidos"], tel });
                }
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se ha logrado mostrar la información. ", ex);
            }
        }

        private bool ValidarCampos()
        {
            if (chbPersona.Checked)
            {
                if (txtPersona.Text.Trim() == "")
                {
                    MessageBox.Show("El campo \"Nombre de persona\" es obligatorio.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else
            {
                if (dgvSocios.RowCount == 0)
                {
                    MessageBox.Show("Debes seleccionar a un socio.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if (dgvSocios.CurrentRow == null)
                {
                    MessageBox.Show("Debes seleccionar a un socio.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            if (txtFolio.Text.Trim() == "")
            {
                MessageBox.Show("El campo \"Folio\" es obligatorio.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtPrecio.Text.Trim() == "")
            {
                MessageBox.Show("El campo \"Precio\" es obligatorio.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                if (decimal.Parse(txtPrecio.Text) <= 0)
                {
                    MessageBox.Show("El campo \"Precio\" no puede ser menor o igual a cero.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            if (cboTipoPago.SelectedIndex == 1)
            {
                if (txtTerminación.Text.Trim() == "")
                {
                    MessageBox.Show("En una venta con tarjeta, debes ingresar el campo \"Terminación de tarjeta\".", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            return true;
        }

        private void InsertarLocker()
        {
            try
            {
                //Actualizamos los datos del locker
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "UPDATE locker SET numSocio=?numSocio, fecha_fin=?fecha_fin, fecha_ini=NOW(), estado=?estado, update_user_id=?update_user_id, update_time=NOW() WHERE id=?id";
                sql.Parameters.AddWithValue("?numSocio", numSocio);
                sql.Parameters.AddWithValue("?fecha_fin", dtpFechaFin.Value);
                sql.Parameters.AddWithValue("?estado", frmLockers.EstadoLocker.Pendiente);
                sql.Parameters.AddWithValue("?update_user_id", frmMain.id);
                sql.Parameters.AddWithValue("?id", idLocker);
                ConexionBD.EjecutarConsulta(sql);
                sql.Parameters.Clear();
                //Insertamos el registro de lockers
                sql.CommandText = "INSERT INTO registro_locker (locker_id, nom_persona, fecha_fin, fecha_ini, descripcion, tipo_pago, precio, terminacion, folio_remision, folio_ticket, create_user_id, create_time) " +
                    "VALUES (?locker_id, ?nom_persona, ?fecha_fin, NOW(), ?descripcion, ?tipo_pago, ?precio, ?terminacion, ?folio_remision, ?folio_ticket, ?create_user_id, NOW())";
                sql.Parameters.AddWithValue("?locker_id", idLocker);
                if (chbPersona.Checked)
                {
                    sql.Parameters.AddWithValue("?nom_persona", txtPersona.Text);
                }
                else
                {
                    sql.Parameters.AddWithValue("?nom_persona", DBNull.Value);
                }
                sql.Parameters.AddWithValue("?fecha_fin", dtpFechaFin.Value);
                sql.Parameters.AddWithValue("?descripcion", txtDescripcion.Text);
                sql.Parameters.AddWithValue("?tipo_pago", cboTipoPago.SelectedIndex);
                sql.Parameters.AddWithValue("?precio", txtPrecio.Text);
                if (cboTipoPago.SelectedIndex == 1)
                {
                    sql.Parameters.AddWithValue("?terminacion", txtTerminación.Text);
                    sql.Parameters.AddWithValue("?folio_ticket", txtFolioTicket.Text);
                }
                else
                {
                    sql.Parameters.AddWithValue("?terminacion", DBNull.Value);
                    sql.Parameters.AddWithValue("?folio_ticket", DBNull.Value);
                }
                sql.Parameters.AddWithValue("?folio_remision", txtFolio.Text);
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
        }

        private void InsertarCaja()
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "INSERT INTO caja (efectivo, tarjeta, tipo_movimiento, fecha, descripcion, create_user_id, create_time) " +
                    "VALUES (?efectivo, ?tarjeta, ?tipo_movimiento, NOW(), ?descripcion, ?create_user_id, NOW())";
                if (cboTipoPago.SelectedIndex == 0)
                {
                    sql.Parameters.AddWithValue("?efectivo", decimal.Parse(txtPrecio.Text));
                    sql.Parameters.AddWithValue("?tarjeta", 0M);
                }
                else
                {
                    sql.Parameters.AddWithValue("?efectivo", 0M);
                    sql.Parameters.AddWithValue("?tarjeta", decimal.Parse(txtPrecio.Text));
                }
                sql.Parameters.AddWithValue("?tipo_movimiento", 0);
                sql.Parameters.AddWithValue("?descripcion", "RENTA DE LOCKER");
                sql.Parameters.AddWithValue("?create_user_id", frmMain.id);
                ConexionBD.EjecutarConsulta(sql);
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("Hubo un error al registrar el movimiento en la caja. La conexión con la base de datos no se ha podido realizar.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("Hubo un error al registrar el movimiento en la caja. Ha ocurrido un error genérico.", ex);
            }
        }

        private void ImprimirTicket()
        {
            try
            {
                if (Clases.CConfiguracionXML.ExisteConfiguracion("ticket", "imprimir"))
                {
                    if (bool.Parse(Clases.CConfiguracionXML.LeerConfiguración("ticket", "imprimir")))
                    {
                        if (Clases.CConfiguracionXML.ExisteConfiguracion("ticket", "preguntar"))
                        {
                            if (bool.Parse(Clases.CConfiguracionXML.LeerConfiguración("ticket", "preguntar")))
                            {
                                if (MessageBox.Show("¿Deseas imprimir el ticket de la asignación de locker?", "GymCSY", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    (new Clases.CTicket()).ImprimirTicketLocker(idLocker);
                                    (new Clases.CTicket()).ImprimirTicketLocker(idLocker);
                                }
                            }
                            else
                            {
                                (new Clases.CTicket()).ImprimirTicketLocker(idLocker);
                                (new Clases.CTicket()).ImprimirTicketLocker(idLocker);
                            }
                        }
                        else
                        {
                            (new Clases.CTicket()).ImprimirTicketLocker(idLocker);
                            (new Clases.CTicket()).ImprimirTicketLocker(idLocker);
                        }
                    }
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

        private void tmrConteo_Tick(object sender, EventArgs e)
        {
            tmrConteo.Enabled = false;
            CFuncionesGenerales.frmEspera("Espere, buscando miembros.", this);
        }

        private void bgwLocker_DoWork(object sender, DoWorkEventArgs e)
        {
            AbrirMSGBox a = new AbrirMSGBox(CFuncionesGenerales.MensajeError);
            try
            {
                tmrConteo.Enabled = true;
                BuscarMiembros(e.Argument.ToString());
            }
            catch (MySqlException ex)
            {
                this.Invoke(a, new object[] { "Ha ocurrido un error al buscar los socios. No se pudo conectar con la base de datos.", ex });
            }
            catch (Exception ex)
            {
                this.Invoke(a, new object[] { "Ha ocurrido un error al buscar los socios. Ha ocurrido un error genérico.", ex });
            }
        }

        private void bgwLocker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tmrConteo.Enabled = false;
            CFuncionesGenerales.frmEsperaClose();
            LlenarDataGrid();
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            CFuncionesGenerales.VerificarEsNumero(ref sender, ref e, false);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bool.Parse(Clases.CConfiguracionXML.LeerConfiguración("caja", "estado")))
                {
                    if (ValidarCampos())
                    {
                        InsertarLocker();
                        InsertarCaja();
                        ImprimirTicket();
                        if (!chbPersona.Checked)
                            MessageBox.Show("El locker ha sido asignado a " + dgvSocios[1, dgvSocios.CurrentRow.Index].Value.ToString() + ".", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("El locker ha sido asignado a " + txtPersona.Text + ".", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frm.BuscarLockers();
                        this.Close();
                    }
                }
                else
                {
                    if (MessageBox.Show("No puedes realizar operaciones de venta si la caja esta cerrada.\n¿Deseas abrirla?", "GymCSY", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                    {
                        (new Formularios.Caja.frmAbrirCaja()).ShowDialog(this);
                        btnAceptar.PerformClick();
                    }
                }
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido asignar el locker. No se pudo conectar con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido asignar el locker. Ha ocurrido un error genérico.", ex);
            }
        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bgwLocker.RunWorkerAsync(txtBusqueda.Text);
            }
        }

        private void cboTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoPago.SelectedIndex == 0)
            {
                txtFolioTicket.Enabled = txtTerminación.Enabled = false;
            }
            else if (cboTipoPago.SelectedIndex == 1)
            {
                txtFolioTicket.Enabled = txtTerminación.Enabled = true;
            }
        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaFin.Value < DateTime.Now)
                dtpFechaFin.Value = DateTime.Now;
        }

        private void chbPersona_CheckedChanged(object sender, EventArgs e)
        {
            if (chbPersona.Checked)
            {
                txtPersona.Enabled = true;
                txtBusqueda.Enabled = false;
                dgvSocios.Enabled = false;
                dgvSocios.Rows.Clear();
                numSocio = 0;
            }
            else
            {
                txtPersona.Enabled = false;
                txtBusqueda.Enabled = true;
                dgvSocios.Enabled = true;
            }
        }

        private void txtFolio_LostFocus(object sender, EventArgs e)
        {
            //if (ExisteFolio(txtFolio.Text))
            //{
            //    MessageBox.Show("El folio ingresado ya existe, ingrese otro para poder continuar.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtFolio.Focus();
            //    txtFolio.SelectAll();
            //}
        }

        private void dgvSocios_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                numSocio = (int)dgvSocios[0, e.RowIndex].Value;
            }
            catch
            {
            }
        }
    }
}
