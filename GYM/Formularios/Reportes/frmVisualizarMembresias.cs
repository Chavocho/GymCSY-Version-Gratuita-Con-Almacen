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

namespace GYM.Formularios.Reportes
{
    public partial class frmVisualizarMembresias : Form
    {
        int idM, numSocio;
        string nomSoc;
        List<int> tipo = new List<int>(), tipoPago = new List<int>(),
            terminacion = new List<int>(), createUser = new List<int>(), autorizador = new List<int>();
        List<string> folioTicket = new List<string>(), folioRemision = new List<string>();
        List<decimal> precio = new List<decimal>();
        List<DateTime> createTime = new List<DateTime>(), fechaAutorizacion = new List<DateTime>();

        public frmVisualizarMembresias(int idM, int numSocio, string nomSocio)
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
            this.idM = idM;
            this.numSocio = numSocio;
            lblSocio.Text=nomSoc= nomSocio;
        }

        private void BuscarRegMembresias()
        {
            try
            {
                string sql = "SELECT * FROM registro_membresias WHERE membresia_id='" + idM + "' ORDER BY create_time";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(nomSoc + " no cuenta con registros de membresías", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }
                foreach (DataRow dr in dt.Rows)
                {
                    DateTime fechaIni = DateTime.Parse(dr["fecha_ini"].ToString()), fechaFin = DateTime.Parse(dr["fecha_fin"].ToString()), fechaPago = (DateTime)dr["create_time"];

                    dgvMembresias.Rows.Add(new object[] { fechaIni.ToString("dd") + " de " + fechaIni.ToString("MMMM") + " del " + fechaIni.ToString("yyyy"), 
                        fechaFin.ToString("dd") + " de " + fechaFin.ToString("MMMM") + " del " + fechaFin.ToString("yyyy"), 
                        fechaPago.ToString("dd") + " de " + fechaPago.ToString("MMMM") + " del " + fechaPago.ToString("yyyy"), 
                        dr["descripcion"].ToString() });

                    tipo.Add((int)dr["tipo"]);
                    tipoPago.Add((int)dr["tipo_pago"]);
                    precio.Add((decimal)dr["precio"]);
                    folioRemision.Add(dr["folio_remision"].ToString());
                    if (dr["terminacion"] != DBNull.Value)
                        terminacion.Add(int.Parse(dr["terminacion"].ToString()));
                    else
                        terminacion.Add(-1);
                    if (dr["folio_ticket"].ToString() != "0")
                        folioTicket.Add(dr["folio_ticket"].ToString());
                    else
                        folioTicket.Add("Sin información");
                    if (dr["autorizacion_user"] != DBNull.Value)
                        autorizador.Add((int)dr["autorizacion_user"]);
                    else
                        autorizador.Add(0);
                    if (dr["fecha_autorizacion"] != DBNull.Value)
                        fechaAutorizacion.Add((DateTime)dr["fecha_autorizacion"]);
                    else
                        fechaAutorizacion.Add(new DateTime());
                    createUser.Add((int)dr["create_user_id"]);
                }
            }
            catch (InvalidCastException ex)
            {
                CFuncionesGenerales.MensajeError("No se puede cargar los detalles de membresía. Ocurrió un error al realizar el Unboxing de una variable.", ex);
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("No se puede cargar los detalles de membresía. No se pudo conectar con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se puede cargar los detalles de membresía. Ocurrió un error genérico.", ex);
            }
        }

        private string NombreUsuario(int id)
        {
            string nomUsu = "Sin información";
            try
            {
                string sql = "SELECT userName FROM usuarios WHERE id='" + id + "'";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    nomUsu = dr["userName"].ToString();
                }
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido cargar el nombre de usuario. Ocurrió un error al conectar con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido cargar el nombre de usuario. Ocurrió un error genérico.", ex);
            }
            return nomUsu;
        }

        private void MostrarInformacion(int index)
        {
            try
            {
                if (index < 0)
                    return;
                //Mostramos primero el tipo
                switch (tipo[index])
                {
                    case 0:
                        lblTipo.Text = "1 Semana";
                        break;
                    case 1:
                        lblTipo.Text = "1 Mes";
                        break;
                    case 2:
                        lblTipo.Text = "2 Meses";
                        break;
                    case 3:
                        lblTipo.Text = "3 Meses";
                        break;
                    case 4:
                        lblTipo.Text = "4 Meses";
                        break;
                    case 5:
                        lblTipo.Text = "5 Meses";
                        break;
                    case 6:
                        lblTipo.Text = "6 Meses";
                        break;
                    case 7:
                        lblTipo.Text = "7 Meses";
                        break;
                    case 8:
                        lblTipo.Text = "8 Meses";
                        break;
                    case 9:
                        lblTipo.Text = "9 Meses";
                        break;
                    case 10:
                        lblTipo.Text = "10 Meses";
                        break;
                    case 11:
                        lblTipo.Text = "11 Meses";
                        break;
                    case 12:
                        lblTipo.Text = "1 Año";
                        break;
                }
                //Ponemos el tipo de pago
                switch (tipoPago[index])
                {
                    case 1:
                        lblTipoPago.Text = "Efectivo";
                        break;
                    case 2:
                        lblTipoPago.Text = "Tarjeta de crédito";
                        break;
                }
                lblPrecio.Text = precio[index].ToString("C2");
                lblFolioRemision.Text = folioRemision[index].ToString();
                if (terminacion[index] > 0)
                    lblTerminacion.Text = terminacion[index].ToString();
                else
                    lblTerminacion.Text = "Sin información";
                lblFolioTicket.Text = folioTicket[index].ToString();
                lblCreateUser.Text = NombreUsuario(createUser[index]);
                lblUsuarioAut.Text = NombreUsuario(autorizador[index]);
                if (fechaAutorizacion[index] != new DateTime())
                    lblFechaAut.Text = fechaAutorizacion[index].ToString("dd") + " de " + fechaAutorizacion[index].ToString("MMMM") + " del " + fechaAutorizacion[index].ToString("yyyy");
                else
                    lblFechaAut.Text = "Sin información";
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido mostrar la información. Ocurrió un error genérico.", ex);
            }
        }

        private void frmVisualizarMembresias_Load(object sender, EventArgs e)
        {
            BuscarRegMembresias();
            MostrarInformacion(0);
        }

        private void dgvMembresias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                MostrarInformacion(e.RowIndex);
            }
            catch
            {
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvMembresias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
