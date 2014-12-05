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

namespace GYM.Formularios.POS
{
    public partial class frmRecuperarVenta : Form
    {
        int folio;
        frmPuntoVenta frm;

        public frmRecuperarVenta(IWin32Window frm)
        {
            InitializeComponent();
            this.frm = (frmPuntoVenta)frm;
        }

        private void BuscarVentaFolio(string folio)
        {
            try
            {
                int fol;
                int.TryParse(folio, out fol);
                string sql = "SELECT id, fecha, total, estado, abierta FROM venta WHERE id='" + fol.ToString() + "' AND estado=1";
                DataTable dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
                LlenarDataGrid(dt);
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
                DataTable dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
                LlenarDataGrid(dt);
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

        private void LlenarDataGrid(DataTable dt)
        {
            try
            {
                dgvVentas.Rows.Clear();
                string estaAbierta = "";
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["abierta"].ToString() == "0")
                        estaAbierta = "Cerrada";
                    else
                        estaAbierta = "Abierta";
                    dgvVentas.Rows.Add(new object[] { int.Parse(dr["id"].ToString()).ToString("00000000"), DateTime.Parse(dr["fecha"].ToString()).ToString("dd/MM/yyyy hh:mm tt"), decimal.Parse(dr["total"].ToString()).ToString("C2"), estaAbierta });
                }
                if (dgvVentas.RowCount > 0)
                    dgvVentas_CellClick(dgvVentas, new DataGridViewCellEventArgs(0, 0));
                else
                    folio = 0;
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

        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
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

        private void txtFolio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BuscarVentaFolio(txtFolio.Text);
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaInicio.Value > dtpFechaFin.Value)
                dtpFechaInicio.Value = dtpFechaFin.Value.AddDays(-1);
            BuscarVentaFechas(dtpFechaInicio.Value, dtpFechaFin.Value);
        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaFin.Value < dtpFechaInicio.Value)
                dtpFechaFin.Value = dtpFechaInicio.Value.AddDays(1);
            BuscarVentaFechas(dtpFechaInicio.Value, dtpFechaFin.Value);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvVentas.CurrentRow == null)
            {
                MessageBox.Show("¡Debes seleccionar una venta!");
                return;
            }
            frm.RecuperarVenta(folio);
            this.Close();
        }

        private void frmRecuperarVenta_Load(object sender, EventArgs e)
        {
            Clases.CFuncionesGenerales.CargarInterfaz(this);
            BuscarVentaFechas(DateTime.Now, DateTime.Now);
        }
    }
}
