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

namespace GYM.Formularios.Caja
{
    public partial class frmCerrarCaja : Form
    {
        decimal efectivoCaja = 0, vouchersCaja = 0;
        frmCaja frm = null;

        #region Instancia
        private static frmCerrarCaja frmInstancia;
        public static frmCerrarCaja Instancia
        {
            get
            {
                if (frmInstancia == null)
                    frmInstancia = new frmCerrarCaja();
                else if (frmInstancia.IsDisposed)
                    frmInstancia = new frmCerrarCaja();
                return frmInstancia;

            }
            set
            {
                frmInstancia = value;
            }
        }
        #endregion

        public frmCerrarCaja()
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
        }

        public frmCerrarCaja(frmCaja frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        private void CerrarCaja()
        {
            try
            {
                decimal efectivo = 0;
                if (txtEfectivo.Text != "")
                    efectivo = decimal.Parse(txtEfectivo.Text);
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "INSERT INTO caja (efectivo, tarjeta, tipo_movimiento, fecha, descripcion) VALUES (?, ?, ?, NOW(), ?)";
                sql.Parameters.AddWithValue("@efectivo", (efectivo * -1).ToString("0.00"));
                sql.Parameters.AddWithValue("@tarjeta", (vouchersCaja * -1).ToString("0.00"));
                sql.Parameters.AddWithValue("@tipo_movimiento", 1);
                sql.Parameters.AddWithValue("@descripcion", "CIERRE DE CAJA");
                Clases.ConexionBD.EjecutarConsulta(sql);
            }
            catch (MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de conectar con la base de datos.", ex);
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error dar formato a una variable.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void CambiarEstadoCaja()
        {
            try
            {
                Clases.CConfiguracionXML.GuardarConfiguracion("caja", "estado", false.ToString());
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

        private void CargarTotalesCaja()
        {
            try
            {
                string sql = "SELECT SUM(efectivo) AS ef, SUM(tarjeta) AS ta FROM caja";
                DataTable dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["ta"] != DBNull.Value)
                        vouchersCaja = decimal.Parse(dr["ta"].ToString());
                    if (dr["ef"] != DBNull.Value)
                        efectivoCaja = decimal.Parse(dr["ef"].ToString());
                }
                lblVouchers.Text = vouchersCaja.ToString("C2");
                lblEfectivoCaja.Text = efectivoCaja.ToString("C2");
            }
            catch (MySqlException ex)
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
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void CalcularTotal()
        {
            try
            {
                if (txtEfectivo.Text != "")
                {
                    decimal total = efectivoCaja - decimal.Parse(txtEfectivo.Text);
                    if (total >= 0)
                        lblTotal.BackColor = Color.Lime;
                    else
                        lblTotal.BackColor = Color.Red;
                    lblTotal.Text = total.ToString("C2");
                }
                else
                    lblTotal.Text = lblEfectivoCaja.Text;
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
                Clases.CFuncionesGenerales.MensajeError("Ningún método en CalcularTotal admite argumentos nulos.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void ObtenerNombreUsuario()
        {
            try
            {
                string sql = "SELECT userName FROM usuarios WHERE id='" + frmMain.id.ToString() + "'";
                DataTable dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                    lblAtiende.Text = dr["userName"].ToString();
            }
            catch (MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al conectar con la base de datos.", ex);
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
                    if (bool.Parse(Clases.CConfiguracionXML.LeerConfiguración("ticket", "imprimir")))
                        if (Clases.CConfiguracionXML.ExisteConfiguracion("ticket", "preguntar"))
                        {
                            if (bool.Parse(Clases.CConfiguracionXML.LeerConfiguración("ticket", "preguntar")))
                            {
                                if (MessageBox.Show("¿Deseas imprimir el ticket del cierre de caja?", "GymCSY", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                                    (new Clases.CTicket()).ImprimirCaja(true);
                            }
                            else
                                (new Clases.CTicket()).ImprimirCaja(true);
                        }
                        else
                            (new Clases.CTicket()).ImprimirCaja(true);
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
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al dar formato a una variable.", ex);
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un desbordamiento.", ex);
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

        private void frmCerrarCaja_Load(object sender, EventArgs e)
        {
            try
            {
                Clases.CFuncionesGenerales.CargarInterfaz(this);
                ObtenerNombreUsuario();
                CargarTotalesCaja();
                CalcularTotal();
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Clases.CFuncionesGenerales.VerificarEsNumero(ref sender, ref e, false);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEfectivo.Text != "")
                {
                    if (decimal.Parse(txtEfectivo.Text) <= efectivoCaja)
                    {
                        CerrarCaja();
                        CambiarEstadoCaja();
                        if (frm != null)
                        {
                            frm.CargarTotalCaja();
                            frm.CargarVentas(DateTime.Now, DateTime.Now);
                            frm.btnAbrirCerrar.Text = "Abrir Caja";
                        }
                        ImprimirTicket();
                        MessageBox.Show("Se ha cerrado la caja con éxito.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                        MessageBox.Show("El dinero a retirar no puede ser mayor al efectivo existente en caja", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    CerrarCaja();
                    CambiarEstadoCaja();
                    if (frm != null)
                    {
                        frm.CargarTotalCaja();
                        frm.CargarVentas(DateTime.Now, DateTime.Now);
                        frm.btnAbrirCerrar.Text = "Abrir Caja";
                    }
                    this.Close();
                }
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido al tratar de dar formato a una variable.", ex);
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un desbordamiento.", ex);
            }
            catch (ObjectDisposedException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Se ha tratado de realizar una operación en un objeto desechado.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ningún método llamado en el evento Click del botón aceptar admite argumentos nulos.", ex);
            }
            catch (InvalidOperationException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error llamando a un método porque el estado actual del objeto no lo permite.", ex);
            }
        }
    }
}
