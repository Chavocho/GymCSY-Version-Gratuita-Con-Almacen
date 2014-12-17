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
            terminacion = new List<int>(), folioRemision = new List<int>(),
            folioTicket = new List<int>(), createUser = new List<int>();
        List<decimal> precio = new List<decimal>();
        List<DateTime> createTime = new List<DateTime>();

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
                string sql = "SELECT * FROM registro_membresias WHERE membresia_id='" + idM + "'";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                if (dt.Rows.Count==0)
                    MessageBox.Show(nomSoc+" no cuenta con registros de membresías","GymCSY",MessageBoxButtons.OK,MessageBoxIcon.Information);
                foreach (DataRow dr in dt.Rows)
                {
                    DateTime fechaIni = DateTime.Parse(dr["fecha_ini"].ToString()), fechaFin = DateTime.Parse(dr["fecha_fin"].ToString());
                    dgvMembresias.Rows.Add(new object[] { fechaIni.ToString("dd/MM/yyyy"), fechaFin.ToString(""), dr["descripcion"].ToString() });
                    tipo.Add((int)dr["tipo"]);
                    tipoPago.Add((int)dr["tipo_pago"]);
                    precio.Add((decimal)dr["precio"]);
                    folioRemision.Add((int)dr["folio_remision"]);
                    if (dr["terminacion"] != DBNull.Value)
                        terminacion.Add((int)dr["terminacion"]);
                    else
                        terminacion.Add(-1);
                    if (dr["folio_ticket"] != DBNull.Value)
                        folioTicket.Add((int)dr["folio_ticket"]);
                    else
                        folioTicket.Add(-1);
                    createUser.Add((int)dr["create_user_id"]);
                    createTime.Add((DateTime)dr["create_time"]);
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
                if (folioTicket[index] > 0)
                    lblFolioTicket.Text = folioTicket[index].ToString();
                else
                    lblFolioTicket.Text = "Sin información";
                lblCreateUser.Text = NombreUsuario(createUser[index]);
                lblCreateTime.Text = createTime[index].ToString("dd") + " de " + createTime[index].ToString("MMMM") + " del " + createTime[index].ToString("yyyy");
                
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

    }
}
