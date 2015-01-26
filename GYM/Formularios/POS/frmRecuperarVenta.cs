using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GYM.Formularios.POS;
using GYM.Clases;

namespace GYM.Formularios.POS
{
    public partial class frmRecuperarVenta : Form
    {
        int folio;
        frmPuntoVenta frm;
        DataTable dt = new DataTable();

        public frmRecuperarVenta(IWin32Window frm)
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
            this.frm = (frmPuntoVenta)frm;
        }

        private void BuscarVentaFolio(string folio)
        {
            try
            {
                int fol;
                int.TryParse(folio, out fol);
                string sql = "SELECT id, fecha, total, estado, abierta FROM venta WHERE id='" + fol.ToString() + "' AND estado=1";
                dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ocurrio un error búscando las ventas. No se pudo conectar a la base de datos.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ocurrio un error búscando las ventas. Ha ocurrido un error genérico.", ex);
            }
        }

        private void BuscarVentaFechas(DateTime fechaIni, DateTime fechaFin)
        {
            try
            {
                MySql.Data.MySqlClient.MySqlCommand sql = new MySql.Data.MySqlClient.MySqlCommand();
                sql.CommandText = "SELECT id, fecha, total, estado, abierta FROM venta WHERE (fecha BETWEEN ? AND ?) AND estado=1";
                //Recuerda que en cualquier gestor de base de datos, las fechas van en orden yyyy-MM-dd,
                //y así te quitas muchos pedos Chava u.u
                sql.Parameters.AddWithValue("@fechaIni", fechaIni.ToString("yyyy-MM-dd") + " 00:00:00");
                sql.Parameters.AddWithValue("@fechaFin", fechaFin.ToString("yyyy-MM-dd") + " 23:59:59");
                dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ocurrio un error búscando las ventas. No se pudo conectar a la base de datos.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ocurrio un error búscando las ventas. Ha ocurrido un error genérico.", ex);
            }
        }

        private void LlenarDataGrid()
        {
            try
            {
                folio = 0;
                dgvVentas.Rows.Clear();
                string estaAbierta = "";
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["abierta"].ToString() == "0")
                        estaAbierta = "Cerrada";
                    else
                        estaAbierta = "Abierta";
                    dgvVentas.Rows.Add(new object[] { int.Parse(dr["id"].ToString()).ToString("00000000"), DateTime.Parse(dr["fecha"].ToString()), decimal.Parse(dr["total"].ToString()), estaAbierta });
                }
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo mostrar la información. ", ex);
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo mostrar la información. ", ex);
            }
            catch (InvalidOperationException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo mostrar la información. ", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo mostrar la información. ", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo mostrar la información. ", ex);
            }
        }

        private void txtFolio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !bgwBusqueda.IsBusy)
            {
                tmrEspera.Enabled = true;
                CFuncionesGenerales.DeshabilitarBotonCerrar(this);
                btnBuscar.Enabled = false;
                txtFolio.Enabled = false;
                bgwBusqueda.RunWorkerAsync(new object[] { txtFolio.Text });
            }
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaInicio.Value > dtpFechaFin.Value)
                dtpFechaInicio.Value = dtpFechaFin.Value.AddDays(-1);
        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaFin.Value < dtpFechaInicio.Value)
                dtpFechaFin.Value = dtpFechaInicio.Value.AddDays(1);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvVentas.CurrentRow == null)
            {
                MessageBox.Show("¡Debes seleccionar una venta!", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //.0
            frm.RecuperarVenta(folio);
            this.Close();
        }

        private void frmRecuperarVenta_Load(object sender, EventArgs e)
        {
            Clases.CFuncionesGenerales.CargarInterfaz(this);
            BuscarVentaFechas(DateTime.Now, DateTime.Now);
        }

        private void dgvVentas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                folio = int.Parse(dgvVentas[0, e.RowIndex].Value.ToString());
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ocurrio un error al dar click en el DataGridView", ex);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!bgwBusqueda.IsBusy)
            {
                tmrEspera.Enabled = true;
                CFuncionesGenerales.DeshabilitarBotonCerrar(this);
                btnBuscar.Enabled = false;
                txtFolio.Enabled = false;
                bgwBusqueda.RunWorkerAsync(new object[] { dtpFechaInicio.Value, dtpFechaFin.Value });
            }
        }

        private void bgwBusqueda_DoWork(object sender, DoWorkEventArgs e)
        {
            Array a = (Array)e.Argument;
            switch (a.Length)
            {
                case 1:
                    BuscarVentaFolio(a.GetValue(0).ToString());
                    break;
                case 2:
                    BuscarVentaFechas((DateTime)a.GetValue(0), (DateTime)a.GetValue(1));
                    break;
            }
        }

        private void bgwBusqueda_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tmrEspera.Enabled = false;
            CFuncionesGenerales.frmEsperaClose();
            CFuncionesGenerales.HabilitarBotonCerrar(this);
            btnBuscar.Enabled = true;
            txtFolio.Enabled = true;
            LlenarDataGrid();
        }

        private void tmrEspera_Tick(object sender, EventArgs e)
        {
            tmrEspera.Enabled = false;
            CFuncionesGenerales.frmEspera("Espere, buscando ventas sin terminar", this);
        }
    }
}
