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
    public partial class frmReporteVentas : Form
    {
        int id;
        DataTable dt;

        #region Instancia
        private static frmReporteVentas frmInstancia;
        public static frmReporteVentas Instancia
        {
            get
            {
                if (frmInstancia == null)
                    frmInstancia = new frmReporteVentas();
                else if (frmInstancia.IsDisposed)
                    frmInstancia = new frmReporteVentas();
                return frmInstancia;
            }
            set
            {
                frmInstancia = value;
            }
        }
        #endregion

        public frmReporteVentas()
        {
            InitializeComponent();
        }

        private int CantidadVentas()
        {
            int cant = 0;
            try
            {
                string sql = "SELECT COUNT(id) AS i FROM venta";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["i"] != DBNull.Value)
                        cant = int.Parse(dr["i"].ToString());
                }
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al tomar la cantidad de ventas. La ventana se cerrará. Ocurrió un error al conectar con la base de datos.", ex);
                this.Close();
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al tomar la cantidad de ventas. La ventana se cerrará. Ocurrió un error genérico.", ex);
                this.Close();
            }
            return cant;
        }

        private void BuscarVentas(DateTime fechaIni, DateTime fechaFin)
        {
            MensajeError e = new MensajeError(CFuncionesGenerales.MensajeError);
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT v.id, v.fecha, v.total, v.tipo_pago, SUM(vd.cantidad) AS c FROM venta AS v INNER JOIN venta_detallada AS vd ON (v.id=vd.id_venta) WHERE (v.fecha BETWEEN ?fechaIni AND ?fechaFin)";
                sql.Parameters.AddWithValue("?fechaIni", fechaIni.ToString("yyyy/MM/dd") + " 00:00:00");
                sql.Parameters.AddWithValue("?fechaFin", fechaFin.ToString("yyyy/MM/dd") + " 23:59:59");
                dt = ConexionBD.EjecutarConsultaSelect(sql);
            }
            catch (MySqlException ex)
            {
                tmrEspera.Enabled = false;
                CFuncionesGenerales.frmEsperaClose();
                this.Invoke(e, new object[] { "No se ha podido buscar las ventas. No se ha podido conectar con la base de datos.", ex });
            }
            catch (Exception ex)
            {
                tmrEspera.Enabled = false;
                CFuncionesGenerales.frmEsperaClose();
                this.Invoke(e, new object[] { "No se ha podido buscar las ventas. Ocurrió un error genérico.", ex });
            }
        }

        private void LlenarDataGrid()
        {
            try
            {
                dgvVentas.Rows.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    DateTime fecha = DateTime.Parse(dr["fecha"].ToString());
                    decimal total = decimal.Parse(dr["total"].ToString());
                    string tipoPago = "Sin información";
                    if (dr["tipo_pago"].ToString() == "0")
                        tipoPago = "Efectivo";
                    else if (dr["tipo_pago"].ToString() == "1")
                        tipoPago = "Tarjeta";
                    dgvVentas.Rows.Add(new object[] { dr["id"], fecha.ToString("dd") + " de " + fecha.ToString("MMMM") + " del " + fecha.ToString("yyyy"), total.ToString("C2"), tipoPago, dr["c"] });
                }
                dgvVentas_CellClick(dgvVentas, new DataGridViewCellEventArgs(0, 0));
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido mostrar la información. ", ex);
            }
        }

        private void dtpFechas_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaInicio.Value > dtpFechaFin.Value)
                dtpFechaInicio.Value = dtpFechaFin.Value;
            if (dtpFechaFin.Value < dtpFechaInicio.Value)
                dtpFechaFin.Value = dtpFechaInicio.Value;
        }

        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = (int)dgvVentas[0, e.RowIndex].Value;
            }
            catch
            {
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!bgwBusqueda.IsBusy)
            {
                tmrEspera.Enabled = true;
                bgwBusqueda.RunWorkerAsync(new object[] { dtpFechaInicio.Value, dtpFechaFin.Value });
            }
        }

        private void bgwBusqueda_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] a = (object[])e.Argument;
            BuscarVentas((DateTime)a[0], (DateTime)a[1]);
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

        private void btnMembresias_Click(object sender, EventArgs e)
        {
            if (dgvVentas.CurrentRow != null)
            {
                (new frmVisualizarVenta(id)).ShowDialog(this);
            }
        }

        private void frmReporteVentas_Load(object sender, EventArgs e)
        {
            if (CantidadVentas() == 0)
            {
                MessageBox.Show("No hay ventas registradas. La ventana se cerrará.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
