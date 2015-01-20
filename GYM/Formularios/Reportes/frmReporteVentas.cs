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
        DataTable dt = new DataTable(), dtVD = new DataTable();
        delegate void Mensajes(string mensaje);

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

        private void Mensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ObtenerTotalVentasPOS()
        {
            try
            {
                lblETotal.Text = "Total de ventas de mostrador:";
                lblEEfectivo.Text = "Total efectivo de mostrador:";
                lblEVoucher.Text = "Total vouchers de mostrador:";
                lblTotal.Left = lblETotal.Right + 6;
                lblEfectivo.Left = lblEEfectivo.Right + 6;
                lblVoucher.Left = lblEVoucher.Right + 6;

                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT SUM(efectivo) AS ef, SUM(tarjeta) AS ta, SUM(efectivo + tarjeta) AS tot FROM caja " +
                    "WHERE (fecha BETWEEN ?fechaIni AND ?fechaFin) AND (descripcion=?concepto01 OR descripcion=?concepto02)";
                sql.Parameters.AddWithValue("?fechaIni", dtpFechaInicio.Value.ToString("yyyy-MM-dd") + " 00:00:00");
                sql.Parameters.AddWithValue("?fechaFin", dtpFechaFin.Value.ToString("yyyy-MM-dd") + " 23:59:59");
                sql.Parameters.AddWithValue("?concepto01", "VENTA POS");
                sql.Parameters.AddWithValue("?concepto02", "VENTA MOSTRADOR");
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
            Mensajes e = new Mensajes(Mensaje);
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT v.id, v.fecha, v.total, v.tipo_pago, SUM(vd.cantidad) AS c, v.create_user_id FROM venta AS v INNER JOIN venta_detallada AS vd ON (v.id=vd.id_venta) WHERE (v.fecha BETWEEN ?fechaIni AND ?fechaFin) GROUP BY v.id";
                sql.Parameters.AddWithValue("?fechaIni", fechaIni.ToString("yyyy/MM/dd") + " 00:00:00");
                sql.Parameters.AddWithValue("?fechaFin", fechaFin.ToString("yyyy/MM/dd") + " 23:59:59");
                dt = ConexionBD.EjecutarConsultaSelect(sql);
            }
            catch (MySqlException)
            {
                tmrEspera.Enabled = false;
                CFuncionesGenerales.frmEsperaClose();
                this.Invoke(e, new object[] { "No se encontraron ventas en esas fechas." });
            }
            catch (Exception)
            {
                tmrEspera.Enabled = false;
                CFuncionesGenerales.frmEsperaClose();
                this.Invoke(e, new object[] { "No se encontraron ventas en esas fechas." });
            }
        }

        private void ObtenerDatosVentasDetalladas(int id)
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT v.id_producto, v.cantidad, v.precio, p.nombre FROM venta_detallada AS v INNER JOIN producto AS p ON (p.id=v.id_producto) WHERE v.id_venta=?id_venta";
                sql.Parameters.AddWithValue("?id_venta", id);
                dtVD = ConexionBD.EjecutarConsultaSelect(sql);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LlenarPanelProductos()
        {
            pnlProductos.Controls.Clear();
            Label lblECodProd;
            Label lblCodProd;
            Label lblENombre;
            Label lblNombre;
            Label lblEPrecio;
            Label lblPrecio;
            Label lblECant;
            Label lblCant;
            int tabIndex = 0;
            try
            {
                Graphics e = this.CreateGraphics();
                int y = 10;
                int salto = (int)(e.MeasureString("Algo", new Font("Segoe UI", 12, FontStyle.Bold)).Height) + 5;
                int lCod = 10;
                int lNom = 250;
                int lPre = (pnlProductos.Width / 4) * 3;
                int lCan = (pnlProductos.Width / 4) * 3 + 100;

                lblECodProd = new Label();
                lblENombre = new Label();
                lblEPrecio = new Label();
                lblECant = new Label();

                //Asignamos sus propiedades usando el método PropiedadesLabelEtiqueta
                PropiedadesLabelEtiqueta(ref lblECodProd, "lblECodProd", "Código de producto", new Point(lCod, y), tabIndex);
                tabIndex++;
                PropiedadesLabelEtiqueta(ref lblENombre, "lblENombre", "Nombre", new Point(lNom, y), tabIndex);
                tabIndex++;
                PropiedadesLabelEtiqueta(ref lblEPrecio, "lblEPrecio", "Precio", new Point(lPre, y), tabIndex);
                tabIndex++;
                PropiedadesLabelEtiqueta(ref lblECant, "lblECant", "Cantidad", new Point(lCan, y), tabIndex);
                tabIndex++;

                //Agregamos los controles al panel
                pnlProductos.Controls.Add(lblECodProd);
                pnlProductos.Controls.Add(lblENombre);
                pnlProductos.Controls.Add(lblEPrecio);
                pnlProductos.Controls.Add(lblECant);
                y += salto;
                foreach (DataRow dr in dtVD.Rows)
                {
                    int x = 0;
                    lblCodProd = new Label();
                    lblNombre = new Label();
                    lblPrecio = new Label();
                    lblCant = new Label();

                    //Asignamos sus propiedades usando el método PropiedadesLabel
                    PropiedadesLabel(ref lblCodProd, "lblCodProd" + x.ToString("000"), dr["id_producto"].ToString(), new Point(lCod, y), tabIndex);
                    tabIndex++;
                    PropiedadesLabel(ref lblNombre, "lblNombre" + x.ToString("000"), dr["nombre"].ToString(), new Point(lNom, y), tabIndex);
                    tabIndex++;
                    PropiedadesLabel(ref lblPrecio, "lblPrecio" + x.ToString("000"), dr["precio"].ToString(), new Point(lPre, y), tabIndex);
                    tabIndex++;
                    PropiedadesLabel(ref lblCant, "lblCant" + x.ToString("000"), dr["cantidad"].ToString(), new Point(lCan, y), tabIndex);
                    tabIndex++;

                    //Agregamos los controles al panel
                    pnlProductos.Controls.Add(lblCodProd);
                    pnlProductos.Controls.Add(lblNombre);
                    pnlProductos.Controls.Add(lblPrecio);
                    pnlProductos.Controls.Add(lblCant);
                    y += salto;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void PropiedadesLabelEtiqueta(ref Label lbl, string name, string texto, Point location, int tabIndex)
        {
            try
            {
                lbl.Name = name;
                lbl.AutoSize = true;
                lbl.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                lbl.Text = texto;
                lbl.Location = location;
                lbl.TabIndex = tabIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void PropiedadesLabel(ref Label lbl, string name, string texto, Point location, int tabIndex)
        {
            try
            {
                lbl.Name = name;
                lbl.AutoSize = true;
                lbl.Font = new Font("Segoe UI", 11, FontStyle.Regular);
                lbl.Text = texto;
                lbl.Location = location;
                lbl.TabIndex = tabIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                    dgvVentas.Rows.Add(new object[] { dr["id"], fecha, total, tipoPago, dr["c"], CFuncionesGenerales.NombreUsuario(dr["create_user_id"].ToString()) });
                }
                dgvVentas_RowEnter(dgvVentas, new DataGridViewCellEventArgs(0, 0));
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
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!bgwBusqueda.IsBusy)
            {
                tmrEspera.Enabled = true;
                ObtenerTotalVentasPOS();
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

        private void frmReporteVentas_Load(object sender, EventArgs e)
        {
            if (CantidadVentas() == 0)
            {
                MessageBox.Show("No hay ventas registradas. La ventana se cerrará.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void dgvVentas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvVentas.CurrentRow != null)
                {
                    ObtenerDatosVentasDetalladas((int)dgvVentas[0, e.RowIndex].Value);
                    LlenarPanelProductos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmReporteVentas_Resize(object sender, EventArgs e)
        {
            LlenarPanelProductos();
        }
    }
}
