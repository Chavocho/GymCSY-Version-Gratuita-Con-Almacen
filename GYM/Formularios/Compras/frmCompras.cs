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

namespace GYM.Formularios.Compras
{
    public partial class frmCompras : Form
    {
        delegate void MensajeError(string mensaje, Exception ex);
        DataTable dt = new DataTable();

        #region Instancia
        private static frmCompras frmInstancia;
        public static frmCompras Instancia
        {
            get
            {
                if (frmInstancia == null)
                    frmInstancia = new frmCompras();
                else if (frmInstancia.IsDisposed)
                    frmInstancia = new frmCompras();
                return frmInstancia;
            }
            set
            {
                frmInstancia = value;
            }
        }
        #endregion

        public frmCompras()
        {
            InitializeComponent();
        }

        private void BuscarCompra(DateTime fechaIni, DateTime fechaFin)
        {
            MensajeError m = new MensajeError(CFuncionesGenerales.MensajeError);
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT c.id, c.fecha, u.userName, c.tipo_pago, c.subtotal, c.descuento, c.impuesto FROM compra AS c LEFT JOIN usuarios AS u ON (c.create_user_id=u.id) WHERE (c.fecha BETWEEN ?fechaIni AND ?fechaFin)";
                sql.Parameters.AddWithValue("?fechaIni", fechaIni.ToString("yyyy/MM/dd") + " 00:00:00");
                sql.Parameters.AddWithValue("?fechaIni", fechaFin.ToString("yyyy/MM/dd") + " 23:59:59");
                dt = ConexionBD.EjecutarConsultaSelect(sql);
            }
            catch (MySqlException ex)
            {
                this.Invoke(m, new object[] { "Ha ocurrido un error al buscar las compras. Ha ocurrido un error al conectar con la base de datos.", ex });
            }
            catch (Exception ex)
            {
                this.Invoke(m, new object[] { "Ha ocurrido un error al buscar las compras. Ha ocurrido un error genérico.", ex });
            }
        }

        private void LlenarDataGrid()
        {
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    decimal subtotal = (decimal)dr["subtotal"], importe = (decimal)dr["importe"], descuento = (decimal)dr["descuento"];
                    DateTime fecha = DateTime.Parse(dr["fecha"].ToString());
                    string tipoPago = "";
                    if (dr["tipo_pago"].ToString() == "0")
                        tipoPago = "Efectivo";
                    else if (dr["tipo_pago"].ToString() == "1")
                        tipoPago = "Tarjeta";

                    dgvCompras.Rows.Add(new object[] { dr["id"],  fecha.ToString("dd") + " de " + fecha.ToString("MMMM") + " del " + fecha.ToString("yyyy"), dr["userName"], tipoPago, (subtotal + importe - descuento).ToString("C2") });
                }
            }
            catch (InvalidOperationException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido mostrar la información. La operación no pudo ser completada ya que el estado actual del objeto no lo permite.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido mostrar la información. Ha ocurrido un error genérico.", ex);
            }
        }

        private void dtpFechas_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaInicio.Value > dtpFechaFin.Value)
                dtpFechaInicio.Value = dtpFechaInicio.Value;
            if (dtpFechaFin.Value < dtpFechaInicio.Value)
                dtpFechaFin.Value = dtpFechaInicio.Value;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            bgwBusqueda.RunWorkerAsync(new object[] { dtpFechaInicio.Value, dtpFechaFin.Value });
            tmrEspera.Enabled = true;
        }

        private void bgwBusqueda_DoWork(object sender, DoWorkEventArgs e)
        {
            Array a = (Array)e.Argument;
            BuscarCompra((DateTime)a.GetValue(0), (DateTime)a.GetValue(1));
        }

        private void bgwBusqueda_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tmrEspera.Enabled = false;
            CFuncionesGenerales.frmEsperaClose();
            LlenarDataGrid();
        }

        private void tmrEspera_Tick(object sender, EventArgs e)
        {
            tmrEspera.Enabled = false;
            CFuncionesGenerales.frmEspera("Espere mientras se efectua la búsqueda", this);
        }

        private void btnNuevaCompra_Click(object sender, EventArgs e)
        {
            (new frmNuevaCompra()).ShowDialog(this);
        }

        private void btnDetallado_Click(object sender, EventArgs e)
        {
            if (dgvCompras.CurrentRow != null)
            {
                (new frmVisualizarCompra((int)dgvCompras[0, dgvCompras.CurrentRow.Index].Value)).ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Debes seleccionar una compra para poderla visualizar.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
