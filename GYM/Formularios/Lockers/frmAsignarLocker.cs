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

        public frmAsignarLocker(frmLockers frm, int idLocker)
        {
            InitializeComponent();
            this.frm = frm;
            this.idLocker = idLocker;
            cboTipoPago.SelectedIndex = 0;
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
                dgvSocios_CellClick(dgvSocios, new DataGridViewCellEventArgs(0, 0));
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
                sql.CommandText = "INSERT INTO registro_locker (locker_id, fecha_fin, fecha_ini, descripcion, tipo_pago, precio, terminacion, folio_remision, folio_ticket, create_user_id, create_time) " +
                    "VALUES (?locker_id, ?fecha_fin, NOW(), ?descripcion, ?tipo_pago, ?precio, ?terminacion, ?folio_remision, ?folio_ticket, ?create_user_id, NOW())";
                sql.Parameters.AddWithValue("?locker_id", idLocker);
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
                //if (chbPersona.Checked)
                //{
                //    sql.Parameters.AddWithValue("?nom_persona", txtPersona.Text);
                //}
                //else
                //{
                //    sql.Parameters.AddWithValue("?nom_persona", DBNull.Value);
                //}
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
                if (ValidarCampos())
                {
                    InsertarLocker();
                    if (!chbPersona.Checked)
                        MessageBox.Show("El locker ha sido asignado a " + dgvSocios[1, dgvSocios.CurrentRow.Index].Value.ToString() + ".", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("El locker ha sido asignado a " + txtPersona.Text + ".", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm.BuscarLockers();
                    this.Close();
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

        private void dgvSocios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                numSocio = (int)dgvSocios[0, e.RowIndex].Value;
            }
            catch
            {
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
    }
}
