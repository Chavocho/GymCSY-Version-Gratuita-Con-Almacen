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

namespace GYM.Formularios.Membresia
{
    public partial class frmNuevaMembresia : Form
    {
        Dictionary<int, decimal> preciosM = new Dictionary<int, decimal>();
        Dictionary<int, string> descripcionM = new Dictionary<int, string>();
        int numSocio, sexo, idPromo = -1;
        string ultimoFolio = "";
        DateTime fechaFin;
        CMembresia mem;
        CRegistro_membresias rMem;

        #region Metodos
        public frmNuevaMembresia(int numSocio, int sexo)
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
            this.numSocio = numSocio;
            this.sexo = sexo;
            mem = new Clases.CMembresia(numSocio);
            rMem = new CRegistro_membresias();
            UltimoFolio();
            ConfigFolio();
            PreciosMembresias();
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

        private void PreciosMembresias()
        {
            try
            {
                string sql = "SELECT id, precio, descripcion FROM precio_membresia WHERE sexo='" + sexo.ToString() + "'";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    preciosM.Add((int)dr["id"], (decimal)dr["precio"]);
                    descripcionM.Add((int)dr["id"], dr["descripcion"].ToString());
                }
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido cargar el precio de la duración seleccionada. Ocurrió un error al conectar la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido cargar el precio de la duración seleccionada. Ocurrió un error genérico.", ex);
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

        public void AsignarPromocion(int duracion, decimal precio, string descripcion)
        {
            cbxTipo.SelectedIndex = duracion;
            cbxTipo.Enabled = false;
            lblPrecio.Text = precio.ToString("C2");
            btnQuitarPromo.Enabled = true;
            txtDescripcion.Text = descripcion;
        }

        private void QuitarPromoción()
        {
            cbxTipo.SelectedIndex = -1;
            cbxTipo.Enabled = true;
            lblPrecio.Text = "$0.00";
            btnQuitarPromo.Enabled = false;
            txtDescripcion.Text = "";
        }

        public void AsignarPromocionHorario(int id, int duracion, decimal precio, string descripcion)
        {
            idPromo = id;
        }

        private void QuitarPromocionHorario()
        {
            idPromo = -1;
        }

        private bool ValidarDatos()
        {
          
            if (cbxTipo.SelectedIndex < 0)
            {
                MessageBox.Show("Debes seleccionar una duración en la membresía", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbxTipo.Focus();
                return false;
            }
            if (cbxTipoPago.SelectedIndex < 0)
            {
                MessageBox.Show("Debes seleccionar un tipo de pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbxTipoPago.Focus();
                return false;
            }
            if (lblPrecio.Text == "$0.00")
            {
                MessageBox.Show("Debes ingresar el precio que pagará el miembro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            try
            {
                decimal ef = 0, ta = 0;
                if (cbxTipoPago.SelectedIndex == 0)
                    ef = decimal.Parse(lblPrecio.Text, System.Globalization.NumberStyles.Currency);
                else
                    ta = decimal.Parse(lblPrecio.Text, System.Globalization.NumberStyles.Currency);
                MySql.Data.MySqlClient.MySqlCommand sql = new MySql.Data.MySqlClient.MySqlCommand();
                sql.CommandText = "INSERT INTO caja (id_membresia, efectivo, tarjeta, tipo_movimiento, fecha, descripcion) VALUES (?, ?, ?, ?, ?, ?)";
                sql.Parameters.AddWithValue("@id_membresia", rMem.IDMembresia);
                sql.Parameters.AddWithValue("@efectivo", ef);
                sql.Parameters.AddWithValue("@tarjeta", ta);
                sql.Parameters.AddWithValue("@tipo_movimiento", 0);
                sql.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                sql.Parameters.AddWithValue("@descripcion", "NUEVA MEMBRESÍA");
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
                                if (MessageBox.Show("¿Deseas imprimir el ticket de la membresía?", "GymCSY", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    (new Clases.CTicket()).ImprimirTicketMembresia(numSocio);
                                    (new Clases.CTicket()).ImprimirTicketMembresia(numSocio);
                                }
                            }
                            else
                            {
                                (new Clases.CTicket()).ImprimirTicketMembresia(numSocio);
                                (new Clases.CTicket()).ImprimirTicketMembresia(numSocio);
                            }
                        }
                        else
                        {
                            (new Clases.CTicket()).ImprimirTicketMembresia(numSocio);
                            (new Clases.CTicket()).ImprimirTicketMembresia(numSocio);
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
        #endregion

        #region Eventos
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNuevaMembresia_Load(object sender, EventArgs e)
        {
            if (preciosM.Keys.Count == 0)
            {
                MessageBox.Show("No tienes precios configurados. Configura primero los precios a asignar por duración.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            Clases.CFuncionesGenerales.CargarInterfaz(this);
            CargarNombreMiembro();
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.CFuncionesGenerales.VerificarEsNumero(ref sender, ref e, false);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bool.Parse(Clases.CConfiguracionXML.LeerConfiguración("caja", "estado")))
                {
                    if (ValidarDatos())
                    {
                        mem.NumeroSocio = numSocio;
                        mem.FechaInicio = dtpFechaInicio.Value;
                        mem.FechaFin = this.fechaFin;
                        mem.IDPromocion = idPromo;
                        mem.Estado = Clases.CMembresia.EstadoMembresia.Pendiente;//Al ingresar una Membresía esta queda en estado pendiente de activación.
                        mem.CreateUser = frmMain.id;
                        rMem.IDMembresia = mem.InsertarMembresia();

                        rMem.FechaInicio = this.dtpFechaInicio.Value;
                        rMem.FechaFin = this.fechaFin;
                        rMem.Tipo = cbxTipo.SelectedIndex;
                        if (txtDescripcion.Text == "")
                            rMem.Descripcion = null;
                        else
                            rMem.Descripcion = txtDescripcion.Text;
                        rMem.TipoPago = cbxTipoPago.SelectedIndex + 1;
                        rMem.Precio = decimal.Parse(lblPrecio.Text, System.Globalization.NumberStyles.Currency);
                        if (txtTerminacion.Text != "")
                            rMem.Terminacion = txtTerminacion.Text;
                        else
                            rMem.Terminacion = "0";
                        if (txtFolio.Text != "")
                            rMem.FolioRemision = txtFolio.Text;
                        else
                            rMem.FolioRemision = "0";
                        if (txtFolioTicket.Text != "")
                            rMem.FolioTicket = txtFolioTicket.Text;
                        else
                            rMem.FolioTicket = "0";
                        rMem.CreateUser = frmMain.id;

                        rMem.InsertarRegistroMembresias();
                        AgregarMovimientoCaja();
                        MessageBox.Show("Membresía agregada correctamente", "Membresías", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (!GYM.Clases.CFuncionesGenerales.versionGratuita)
                        {
                            ImprimirTicket();
                        }
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
            if (cbxTipo.SelectedIndex == -1 || cbxTipo.Enabled == false)
                return;
            if (preciosM.ContainsKey(cbxTipo.SelectedIndex))
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
            else
            {
                MessageBox.Show("El precio de esa duración no ha sido configurado.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbxTipo.SelectedIndex = -1;
                int tmp = 0;
                foreach (int k in preciosM.Keys)
                {
                    if (k > cbxTipo.SelectedIndex)
                    {
                        cbxTipo.SelectedIndex = tmp;
                        break;
                    }
                    tmp = k;
                }
                if (tmp < cbxTipo.SelectedIndex)
                {
                    cbxTipo.SelectedIndex = tmp;
                }
                else
                {
                    for (int i = 0; i < cbxTipo.Items.Count; i++)
                    {
                        if (preciosM.ContainsKey(i))
                        {
                            cbxTipo.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
            lblPrecio.Text = preciosM[cbxTipo.SelectedIndex].ToString("C2");
            txtDescripcion.Text = descripcionM[cbxTipo.SelectedIndex];
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

        private void btnAsignarPromo_Click(object sender, EventArgs e)
        {
            (new frmAsignarPromo(this, sexo)).ShowDialog(this);
        }

        private void btnQuitarPromo_Click(object sender, EventArgs e)
        {
            QuitarPromoción();
        }

        private void txtFolio_LostFocus(object sender, EventArgs e)
        {
            if (CMembresia.ExisteFolio(txtFolio.Text))
            {
                MessageBox.Show("El folio ingresado ya existe, ingrese otro para poder continuar.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFolio.Focus();
                txtFolio.SelectAll();
            }
        }
    }
}
