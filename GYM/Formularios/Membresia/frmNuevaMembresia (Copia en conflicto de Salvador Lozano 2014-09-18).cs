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
    public partial class frmNuevaMembresia : Form
    {
        int numSocio;
        DateTime fechaFin;
        Clases.CMembresia mem;

        #region Metodos
        public frmNuevaMembresia(int numSocio)
        {
            InitializeComponent();
            this.numSocio = numSocio;
            mem = new Clases.CMembresia(numSocio);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool ValidarDatos()
        {
          
            if (cbxTipo.SelectedIndex < 0)
            {
                MessageBox.Show("Debes seleccionar un tipo de membresía", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbxTipo.Focus();
                return false;
            }
            /*if (DateTime.Parse(dtpFechaInicio.Value.ToString("dd/MM/yyyy")) < DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy")))
            {
                MessageBox.Show("La fecha de inicio debe ser superior o igual a la fecha actual", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpFechaInicio.Focus();
                return false;
            }*/
            if (cbxTipoPago.SelectedIndex < 0)
            {
                MessageBox.Show("Debes seleccionar un tipo de pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbxTipoPago.Focus();
                return false;
            }
            if (txtPrecio.Text == "")
            {
                MessageBox.Show("Debes ingresar el precio que pagará el miembro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecio.Focus();
                return false;
            }
            if (txtFolio.Text == "")
            {
                MessageBox.Show("Debes ingresar el folio de remisión", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtFolio.Focus();
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
            decimal ef = 0, ta = 0;
            if (cbxTipoPago.SelectedIndex == 0)
                ef = decimal.Parse(txtPrecio.Text);
            else
                ta = decimal.Parse(txtPrecio.Text);
            MySql.Data.MySqlClient.MySqlCommand sql = new MySql.Data.MySqlClient.MySqlCommand();
            sql.CommandText = "INSERT INTO caja (efectivo, tarjeta, tipo_movimiento, fecha, descripcion) VALUES (?, ?, ?, ?, ?)";
            sql.Parameters.AddWithValue("@", ef);
            sql.Parameters.AddWithValue("@", ta);
            sql.Parameters.AddWithValue("@", 0);
            sql.Parameters.AddWithValue("@", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sql.Parameters.AddWithValue("@", "NUEVA MEMBRESÍA");
        }
        #endregion

        #region Eventos
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNuevaMembresia_Load(object sender, EventArgs e)
        {
            Clases.CFuncionesGenerales.CargarInterfaz(this);
            CargarNombreMiembro();
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.CFuncionesGenerales.VerificarEsNumero(ref sender, ref e, false);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (txtDescripcion.Text == "")
                    mem.Descripcion = null;
                else
                mem.Descripcion = txtDescripcion.Text;
                mem.FechaCreacion = DateTime.Now;
                mem.FechaFin = this.fechaFin;
                mem.FechaInicio = dtpFechaInicio.Value;
                mem.FechaRegistro = DateTime.Now;
                mem.Folio = int.Parse(txtFolio.Text);
                mem.NumSocio = numSocio;
                mem.Precio = decimal.Parse(txtPrecio.Text);
                mem.Status = chbStatus.Checked;
                mem.TipoMembresia = cbxTipo.SelectedIndex + 1;
                mem.UsuarioCreador = frmMain.id;
                mem.tipoPago = cbxTipoPago.SelectedIndex + 1;
                mem.terminacionTarjeta = (txtTerminacion.Text == "" ? 0 : Convert.ToInt32(txtTerminacion.Text));
                mem.folioTicket = (txtFolioTicket.Text == "" ? 0 : Convert.ToInt32(txtFolioTicket.Text));
                mem.InsertarMembresia();
                AgregarMovimientoCaja();
                if (MessageBox.Show("¿Desea imprimir el ticket?", "GymCSY", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    (new Clases.CTicket()).ImprimirTicketMembresia(numSocio);
                MessageBox.Show("Membresía agregada correctamente", "Membresías", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
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
                    lblFechaFin.Text = dtpFechaInicio.Value.AddMonths(11).ToString("dd") + " de " + dtpFechaInicio.Value.AddMonths(11).ToString("MM") + " del " + dtpFechaInicio.Value.AddMonths(11).ToString("yyyy");
                    break;
                case 12:
                    fechaFin = dtpFechaInicio.Value.AddYears(1);
                    lblFechaFin.Text = dtpFechaInicio.Value.AddYears(1).ToString("dd") + " de " + dtpFechaInicio.Value.AddYears(1).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddYears(1).ToString("yyyy");
                    break;
            }
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
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
        
        private void cbxTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPrecio.Enabled = true;
            txtFolio.Enabled = true;
            txtDescripcion.Enabled = true;
            txtTerminacion.Enabled = (cbxTipoPago.SelectedIndex == 1? true:false);
            txtFolioTicket.Enabled = (cbxTipoPago.SelectedIndex == 1 ? true : false);
        } 
        private void txtTerminacion_EnabledChanged(object sender, EventArgs e)
        {
            txtTerminacion.Text = "";
            txtFolioTicket.Text = "";
        }

        #endregion

        private void txtFolio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.CFuncionesGenerales.VerificarEsNumero(ref sender, ref e, true);
        }     
    }
}
