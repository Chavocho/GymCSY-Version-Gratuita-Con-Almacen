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
    public partial class frmReporteMembresias : Form
    {
        #region Instancia
        private static frmReporteMembresias frmInstancia;
        public static frmReporteMembresias Instancia
        {
            get
            {
                if (frmInstancia == null)
                    frmInstancia = new frmReporteMembresias();
                else if (frmInstancia.IsDisposed)
                    frmInstancia = new frmReporteMembresias();
                return frmInstancia;

            }
            set
            {
                frmInstancia = value;
            }
        }
        #endregion

        DataTable dt = new DataTable();

        public frmReporteMembresias()
        {
            InitializeComponent();
        }

        private void ObtenerTotalVentasMembresias()
        {
            try
            {
                lblTotal.Left = lblETotal.Right + 6;
                lblEfectivo.Left = lblEEfectivo.Right + 6;
                lblVoucher.Left = lblEVoucher.Right + 6;

                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT SUM(efectivo) AS ef, SUM(tarjeta) AS ta, SUM(efectivo + tarjeta) AS tot FROM caja " +
                    "WHERE (fecha BETWEEN ?fechaIni AND ?fechaFin) AND (descripcion=?concepto01 OR descripcion=?concepto02)";
                sql.Parameters.AddWithValue("?fechaIni", dtpFechaInicio.Value.ToString("yyyy-MM-dd") + " 00:00:00");
                sql.Parameters.AddWithValue("?fechaFin", dtpFechaFin.Value.ToString("yyyy-MM-dd") + " 23:59:59");
                sql.Parameters.AddWithValue("?concepto01", "NUEVA MEMBRESÍA");
                sql.Parameters.AddWithValue("?concepto02", "RENOVACIÓN MEMBRESÍA");
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["ef"] != DBNull.Value)
                    {
                        lblEfectivo.Text = decimal.Parse(dr["ef"].ToString()).ToString("C2");
                    }
                    else
                    {
                        lblEfectivo.Text = "$0.00";
                    }
                    if (dr["ta"] != DBNull.Value)
                    {
                        lblVoucher.Text = decimal.Parse(dr["ta"].ToString()).ToString("C2");
                    }
                    else
                    {
                        lblVoucher.Text = "$0.00";
                    }
                    if (dr["tot"] != DBNull.Value)
                    {
                        lblTotal.Text = decimal.Parse(dr["tot"].ToString()).ToString("C2");
                    }
                    else
                    {
                        lblTotal.Text = "$0.00";
                    }
                }
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al obtener el total de las membresías. No se pudo realizar la conexión con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al obtener el total de las membresías. Ocurrió un error genérico.", ex);
            }
        }

        private void BuscarMembresias(DateTime fechaIni, DateTime fechaFin)
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT c.*, r.folio_remision, r.tipo_pago, m.numSocio, u.userName FROM caja AS c INNER JOIN registro_membresias AS r ON (c.id_membresia=r.membresia_id) LEFT JOIN membresias AS m ON (c.id_membresia=m.id) LEFT JOIN usuarios AS u ON (r.create_user_id=u.id) WHERE (c.fecha BETWEEN ?fechaIni AND ?fechaFin) AND (r.create_time BETWEEN ?fechaIni01 AND ?fechaFin01) ORDER BY c.fecha DESC";
                sql.Parameters.AddWithValue("?fechaIni", dtpFechaInicio.Value.ToString("yyyy-MM-dd") + " 00:00:00");
                sql.Parameters.AddWithValue("?fechaFin", dtpFechaFin.Value.ToString("yyyy-MM-dd") + " 23:59:59");
                sql.Parameters.AddWithValue("?fechaIni01", dtpFechaInicio.Value.ToString("yyyy-MM-dd") + " 00:00:00");
                sql.Parameters.AddWithValue("?fechaFin01", dtpFechaFin.Value.ToString("yyyy-MM-dd") + " 23:59:59");
                dt = ConexionBD.EjecutarConsultaSelect(sql);
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al conectar a la base de datos para obtener los datos de las membresías.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al obtener los datos de las membresías.", ex);
            }
        }

        private void LlenarDataGrid()
        {
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dgvVentas.Rows.Add(new object[] { dr["id_membresia"], (DateTime)dr["fecha"], (decimal)dr["efectivo"], (decimal)dr["tarjeta"], dr["userName"] });
                    Application.DoEvents();
                }
            }
            catch (InvalidCastException ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al mostrar la información.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al mostrar la información.", ex);
            }
        }

        private void dtpFechas_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaInicio.Value > dtpFechaFin.Value)
                dtpFechaInicio.Value = dtpFechaFin.Value;
            if (dtpFechaFin.Value < dtpFechaInicio.Value)
                dtpFechaFin.Value = dtpFechaInicio.Value;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!bgwBusqueda.IsBusy)
            {
                CFuncionesGenerales.DeshabilitarBotonCerrar(this);
                btnBuscar.Enabled = false;
                tmrEspera.Enabled = true;
                ObtenerTotalVentasMembresias();
                bgwBusqueda.RunWorkerAsync(new object[] { dtpFechaInicio.Value, dtpFechaFin.Value });
            }
        }

        private void bgwBusqueda_DoWork(object sender, DoWorkEventArgs e)
        {
            Array a = (Array)e.Argument;
            BuscarMembresias((DateTime)a.GetValue(0), (DateTime)a.GetValue(1));
        }

        private void bgwBusqueda_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tmrEspera.Enabled = false;
            CFuncionesGenerales.frmEsperaClose();
            CFuncionesGenerales.HabilitarBotonCerrar(this);
            btnBuscar.Enabled = true;
            LlenarDataGrid();
        }

        private void tmrEspera_Tick(object sender, EventArgs e)
        {
            tmrEspera.Enabled = false;
            CFuncionesGenerales.frmEspera("Espere, buscando los datos de membresías", this);
        }
    }
}
