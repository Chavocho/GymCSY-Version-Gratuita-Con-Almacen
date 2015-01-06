using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYM.Formularios.POS
{
    public partial class frmCancelarVenta : Form
    {
        int folio;

        public frmCancelarVenta()
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
        }

        private void CancelarVenta(string folio)
        {
            CambiarColorDataGrid();
            string sql = "UPDATE venta SET estado=0 WHERE id='" + folio + "'";
            Clases.ConexionBD.EjecutarConsulta(sql);
            RegresarInventario(folio);
        }

        private void RegresarInventario(string folio)
        {
            try
            {
                List<string> prod = new List<string>();
                List<int> cant = new List<int>();
                string sql = "SELECT id_producto, cantidad FROM venta_detallada WHERE id_venta='" + folio + "'";
                DataTable dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    prod.Add(dr["id_producto"].ToString());
                    cant.Add(Convert.ToInt32(dr["cantidad"]));
                }
                RegresarInventario(prod, cant, folio);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de conectar con la base de datos.", ex);
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de dar formato a una variable.", ex);
            }
            catch (InvalidCastException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de convertir una variable.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El argumento dado al método es nulo.", ex);
            }
        }

        private void RegresarInventario(List<string> prods, List<int> cants, string folio)
        {
            try
            {
                string sql;
                for (int i = 0; i < prods.Count; i++)
                {
                    sql = "UPDATE venta_detallada SET cantidad=0 WHERE id_producto='" + prods[i] + "' AND id_venta='" + folio + "'";
                    Clases.ConexionBD.EjecutarConsulta(sql);
                    Clases.CProducto.AgregarInventarioMostrador(prods[i].ToString(), cants[i]);
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de regresar los productos al inventario.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void BuscarVentaFolio(string folio)
        {
            try
            {
                int fol;
                int.TryParse(folio, out fol);
                string sql = "SELECT id, fecha, total, estado, abierta FROM venta WHERE id='" + fol.ToString() + "' AND abierta=0";
                DataTable dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
                LlenarDataGrid(dt);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de buscar la venta.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void BuscarVentaFechas(DateTime fechaIni, DateTime fechaFin)
        {
            try
            {
                MySql.Data.MySqlClient.MySqlCommand sql = new MySql.Data.MySqlClient.MySqlCommand();
                sql.CommandText = "SELECT id, fecha, total, estado, abierta FROM venta WHERE (fecha BETWEEN ? AND ?) AND abierta=0";
                //Recuerda que en cualquier gestor de base de datos, las fechas van en orden yyyy-MM-dd,
                //y así te quitas muchos pedos Chava u.u
                sql.Parameters.AddWithValue("@fechaIni", fechaIni.ToString("yyyy-MM-dd") + " 00:00:00");
                sql.Parameters.AddWithValue("@fechaFin", fechaFin.ToString("yyyy-MM-dd") + " 23:59:59");
                DataTable dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
                LlenarDataGrid(dt);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de buscar la venta.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void CambiarColorDataGrid()
        {
            dgvVentas.Rows[dgvVentas.CurrentRow.Index].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgvVentas.Rows[dgvVentas.CurrentRow.Index].DefaultCellStyle.ForeColor = Color.FromArgb(150, 0, 0);
            dgvVentas.Rows[dgvVentas.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.FromArgb(150, 0, 0);
            dgvVentas.Rows[dgvVentas.CurrentRow.Index].DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgvVentas[3, dgvVentas.CurrentRow.Index].Value = "Cancelada";
        }

        private void LlenarDataGrid(DataTable dt)
        {
            try
            {
                folio = 0;
                dgvVentas.Rows.Clear();
                string estaAbierta = "";
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["estado"].ToString() == "1")
                        estaAbierta = "Normal";
                    else
                        estaAbierta = "Cancelada";
                    dgvVentas.Rows.Add(new object[] { int.Parse(dr["id"].ToString()).ToString("00000000"), DateTime.Parse(dr["fecha"].ToString()).ToString("dd/MM/yyyy hh:mm tt"), decimal.Parse(dr["total"].ToString()).ToString("C2"), estaAbierta });
                    if (dr["estado"].ToString() == "0")
                    {
                        dgvVentas.Rows[dgvVentas.RowCount - 1].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                        dgvVentas.Rows[dgvVentas.RowCount - 1].DefaultCellStyle.ForeColor = Color.FromArgb(150, 0, 0);
                        dgvVentas.Rows[dgvVentas.RowCount - 1].DefaultCellStyle.SelectionBackColor = Color.FromArgb(150, 0, 0);
                        dgvVentas.Rows[dgvVentas.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
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
                Clases.CFuncionesGenerales.MensajeError("Algún método invocado en LlenarDataGrid no admite argumentos nulos.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void txtFolio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BuscarVentaFolio(txtFolio.Text);
        }

        private void dtpFechas_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtpFechaInicio.Value > dtpFechaFin.Value)
                    dtpFechaInicio.Value = dtpFechaFin.Value.AddDays(-1);
                if (dtpFechaFin.Value < dtpFechaInicio.Value)
                    dtpFechaFin.Value = dtpFechaInicio.Value.AddDays(1);
                BuscarVentaFechas(dtpFechaInicio.Value, dtpFechaFin.Value);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("La fecha ingresada se ha salido del rango admitido.", ex);
            }
        }

        private void frmCancelarVenta_Load(object sender, EventArgs e)
        {
            try
            {
                Clases.CFuncionesGenerales.CargarInterfaz(this);
                BuscarVentaFechas(DateTime.Now, DateTime.Now);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CancelarVenta(folio.ToString());
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvVentas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                folio = int.Parse(dgvVentas[0, e.RowIndex].Value.ToString());
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo convertir el valor del folio a int. El formato no es correcto.", ex);
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo convertir el valor del folio a int. Ha ocurrido un desbordamiento.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo convertir el valor del folio a int. El argumento dado es nulo.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo convertir el valor del folio a int. Ha ocurrido un error genérico.", ex);
            }
        }
    }
}
