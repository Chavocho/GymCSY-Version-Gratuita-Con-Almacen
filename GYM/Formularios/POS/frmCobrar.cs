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
using System.Globalization;
using GYM.Formularios.POS;

namespace GYM.Formularios.POS
{
    public partial class frmCobrar : Form
    {
        frmPuntoVenta frm;
        int idVenta;
        decimal total, cant, tmpEf;
        List<string> idProds;
        List<int> cants;

        public frmCobrar(IWin32Window frm, int idVenta, decimal total, decimal cant, List<string> idProds, List<int> cants)
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
            this.frm = (frmPuntoVenta)frm;
            this.idVenta = idVenta;
            this.total = total;
            this.cant = cant;
            this.idProds = idProds;
            this.cants = cants;
        }

        private void CerrarCuenta()
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "UPDATE venta SET fecha=NOW(), total=?, estado=?, abierta=?, tipo_pago=?, folio_ticket=?, terminacion=? WHERE id=?";
                sql.Parameters.AddWithValue("@total", total);
                sql.Parameters.AddWithValue("@estado", true);
                sql.Parameters.AddWithValue("@abierta", false);
                if (!chbTarjeta.Checked)
                {
                    sql.Parameters.AddWithValue("@tipo_pago", 0);
                    sql.Parameters.AddWithValue("@folio_ticket", DBNull.Value);
                    sql.Parameters.AddWithValue("@terminacion", DBNull.Value);
                }
                else
                {
                    sql.Parameters.AddWithValue("@tipo_pago", 1);
                    sql.Parameters.AddWithValue("@folio_ticket", txtFolioTicket.Text);
                    sql.Parameters.AddWithValue("@terminacion", txtTerminacion.Text);
                }
                sql.Parameters.AddWithValue("@id", idVenta);
                Clases.ConexionBD.EjecutarConsulta(sql);
            }
            catch (MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de cerrar la cuenta.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void AgregarMovimientoCaja()
        {
            decimal efectivo = 0, tarjeta = 0;
            try
            {
                if (txtEfectivo.Text != "")
                    efectivo = decimal.Parse(lblTotal.Text, System.Globalization.NumberStyles.Currency);
                if (txtTarjeta.Text != "")
                    tarjeta = decimal.Parse(txtTarjeta.Text, System.Globalization.NumberStyles.Currency);
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "INSERT INTO caja (id_venta, efectivo, tarjeta, tipo_movimiento, fecha, descripcion) VALUES (?, ?, ?, ?, ?, ?)";
                sql.Parameters.AddWithValue("@id_venta", int.Parse(lblFolio.Text));
                sql.Parameters.AddWithValue("@efectivo", efectivo.ToString("0.00"));
                sql.Parameters.AddWithValue("@tarjeta", tarjeta.ToString("0.00"));
                //Entrada = 0, Salida = 1
                sql.Parameters.AddWithValue("@tipoMov", 0);
                sql.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                sql.Parameters.AddWithValue("@descripcion", "VENTA POS");
                Clases.ConexionBD.EjecutarConsulta(sql);
            }
            catch (MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de registrar el movimiento en caja.", ex);
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
                Clases.CFuncionesGenerales.MensajeError("Algún método invocado en AgregarMovimientoCaja no admite argumentos nulos.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void DescontarInventario()
        {
            try
            {
                for (int i = 0; i < idProds.Count; i++)
                    Clases.CProducto.DescontarInventario(idProds[i], cants[i]);
            }
            catch (MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de descontar productos del inventario.", ex);
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
                                if (MessageBox.Show("¿Deseas imprimir el ticket de esta venta?", "GymCSY", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    (new Clases.CTicket()).ImprimirTicketVenta(int.Parse(lblFolio.Text));
                                    (new Clases.CTicket()).ImprimirTicketVenta(int.Parse(lblFolio.Text));
                                }
                            }
                            else
                            {
                                (new Clases.CTicket()).ImprimirTicketVenta(int.Parse(lblFolio.Text));
                                (new Clases.CTicket()).ImprimirTicketVenta(int.Parse(lblFolio.Text));
                            }
                        }
                        else
                        {
                            (new Clases.CTicket()).ImprimirTicketVenta(int.Parse(lblFolio.Text));
                            (new Clases.CTicket()).ImprimirTicketVenta(int.Parse(lblFolio.Text));
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

        private void txtDinero_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CalcularCambio()
        {
            try
            {
                if (!chbTarjeta.Checked)
                {
                    if (txtEfectivo.Text != "")
                    {
                        decimal cambio = (decimal.Parse(lblTotal.Text, NumberStyles.Currency) - decimal.Parse(txtEfectivo.Text, NumberStyles.Currency));
                        if (cambio <= 0)
                        {
                            lblEtiquetaCambio.Text = "Cambio:";
                            lblEtiquetaCambio.Left = lblCambio.Left - lblEtiquetaCambio.Width;
                            lblCambio.Text = (cambio * -1).ToString("C2");
                            lblCambio.BackColor = Color.Lime;
                            lblCambio.ForeColor = Color.Black;
                        }
                        else
                        {
                            lblEtiquetaCambio.Text = "Falta:";
                            lblEtiquetaCambio.Left = lblCambio.Left - lblEtiquetaCambio.Width;
                            lblCambio.Text = cambio.ToString("C2");
                            lblCambio.BackColor = Color.Red;
                            lblCambio.ForeColor = Color.White;
                        }
                    }
                    else
                    {
                        lblEtiquetaCambio.Text = "Falta:";
                        lblEtiquetaCambio.Left = lblCambio.Left - lblEtiquetaCambio.Width;
                        lblCambio.Text = lblTotal.Text;
                        lblCambio.BackColor = Color.Red;
                        lblCambio.ForeColor = Color.White;
                    }
                }
                else
                {
                    if (txtTarjeta.Text != "")
                    {
                        decimal cambio = (decimal.Parse(lblTotal.Text, NumberStyles.Currency) - decimal.Parse(txtTarjeta.Text, NumberStyles.Currency));
                        if (cambio <= 0)
                        {
                            lblEtiquetaCambio.Text = "Cambio:";
                            lblEtiquetaCambio.Left = lblCambio.Left - lblEtiquetaCambio.Width;
                            lblCambio.Text = (cambio * -1).ToString("C2");
                            lblCambio.BackColor = Color.Lime;
                            lblCambio.ForeColor = Color.Black;
                        }
                        else
                        {
                            lblEtiquetaCambio.Text = "Falta:";
                            lblEtiquetaCambio.Left = lblCambio.Left - lblEtiquetaCambio.Width;
                            lblCambio.Text = cambio.ToString("C2");
                            lblCambio.BackColor = Color.Red;
                            lblCambio.ForeColor = Color.White;
                        }
                    }
                    else
                    {
                        lblEtiquetaCambio.Text = "Falta:";
                        lblEtiquetaCambio.Left = lblCambio.Left - lblEtiquetaCambio.Width;
                        lblCambio.Text = lblTotal.Text;
                        lblCambio.BackColor = Color.Red;
                        lblCambio.ForeColor = Color.White;
                    }
                }
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
                Clases.CFuncionesGenerales.MensajeError("Algún método invocado en CalcularCambio no admite argumentos nulos.", ex);
            }
        }

        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            CalcularCambio();
        }

        private void frmCobrar_Load(object sender, EventArgs e)
        {
            try
            {
                lblTotal.Text = (total).ToString("C2");
                lblFolio.Text = idVenta.ToString("00000000");
                lblCantidad.Text = cant.ToString();
                CalcularCambio();
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de dar formato a una variable.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (chbTarjeta.Checked)
            {
                if (txtFolioTicket.Text.Trim() == "")
                {
                    MessageBox.Show("Se debe ingresar el folio del ticket de la tarjeta.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtTerminacion.Text.Trim() == "")
                {
                    MessageBox.Show("Se debe ingresar la terminación de la tarjeta.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (lblCambio.BackColor == Color.Red)
                MessageBox.Show("Debes ingresar una cantidad mayor antes de poder cobrar la cuenta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                CerrarCuenta();
                AgregarMovimientoCaja();
                DescontarInventario();
                ImprimirTicket();
                this.Close();
            }
        }

        private void chbTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(decimal.Parse(lblTotal.Text, System.Globalization.NumberStyles.Currency) >= 100))
                {
                    if (chbTarjeta.Checked)
                    {
                        chbTarjeta.Checked = false;
                        MessageBox.Show("La venta debe ser mayor a $100 para que se pueda efectuar con tarjeta", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    return;
                }
                if (chbTarjeta.Checked)
                {
                    this.Size = new System.Drawing.Size(441, 364);
                    txtEfectivo.Enabled = false;
                    pnlTarjeta.Visible = true;
                    if (txtEfectivo.Text != "")
                        tmpEf = decimal.Parse(txtEfectivo.Text);
                    txtEfectivo.Text = "";
                    txtTarjeta.Text = decimal.Parse(lblTotal.Text, System.Globalization.NumberStyles.Currency).ToString();
                    txtTarjeta_TextChanged(txtTarjeta, new EventArgs());
                }
                else
                {
                    this.Size = new System.Drawing.Size(441, 300);
                    pnlTarjeta.Visible = false;
                    txtEfectivo.Enabled = true;
                    txtEfectivo.Text = tmpEf.ToString();
                    txtTarjeta.Text = "";
                }
                this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
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
                Clases.CFuncionesGenerales.MensajeError("Algún método llamado en el evento CheckedChanged del CheckBox Tarjeta no admite argumentos nulos.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void txtTarjeta_TextChanged(object sender, EventArgs e)
        {
            CalcularCambio();
        }
    }
}
