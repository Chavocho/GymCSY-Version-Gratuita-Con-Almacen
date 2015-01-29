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
using System.Windows.Forms.DataVisualization.Charting;

namespace GYM.Formularios.Reportes
{
    public partial class frmReporteGanancia : Form
    {
        #region Instancia
        private static frmReporteGanancia frmInstancia;
        public static frmReporteGanancia Instancia
        {
            get
            {
                if (frmInstancia == null)
                    frmInstancia = new frmReporteGanancia();
                else if (frmInstancia.IsDisposed)
                    frmInstancia = new frmReporteGanancia();
                return frmInstancia;

            }
            set
            {
                frmInstancia = value;
            }
        }
        #endregion

        int años;
        decimal efeMem = 0M,
            tarMem = 0M,
            efeVen = 0M,
            tarVen = 0M,
            efeDiv = 0M,
            tarDiv = 0M,
            efeCom = 0M,
            tarCom = 0M,
            efeEDiv = 0M,
            tarEDiv = 0M,
            efe = 0M,
            tar = 0M;
        DataTable dtIM = new DataTable(), dtIV = new DataTable(), dtID = new DataTable(),
            dtEC = new DataTable(), dtED = new DataTable();
        DateTime fechaIni, fechaFin;
        MensajeError men;

        public frmReporteGanancia()
        {
            InitializeComponent();
            fechaIni = fechaFin = DateTime.Now;
        }

        private void ObtenerTotalesMembresias()
        {
            men = new MensajeError(CFuncionesGenerales.MensajeError);
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT c.fecha, c.efectivo, c.tarjeta FROM caja AS c INNER JOIN membresias AS m ON (c.id_membresia=m.id) WHERE (c.fecha BETWEEN ?fechaIni AND ?fechaFin)";
                sql.Parameters.AddWithValue("?fechaIni", fechaIni.ToString("yyyy-MM-dd" + " 00:00:00"));
                sql.Parameters.AddWithValue("?fechaFin", fechaFin.ToString("yyyy-MM-dd" + " 23:59:59"));
                dtIM = ConexionBD.EjecutarConsultaSelect(sql);
            }
            catch (MySqlException ex)
            {
                this.Invoke(men, new object[] { "Ha ocurrido un error al obtener los datos de las ganancias.", ex });
            }
            catch (Exception ex)
            {
                this.Invoke(men, new object[] { "Ha ocurrido un error al obtener los datos de las ganancias.", ex });
            }
        }

        private void ObtenerTotalesVentas()
        {
            men = new MensajeError(CFuncionesGenerales.MensajeError);
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT c.fecha, c.efectivo, c.tarjeta FROM caja AS c INNER JOIN venta AS v ON (c.id_venta=v.id) WHERE (c.fecha BETWEEN ?fechaIni AND ?fechaFin)";
                sql.Parameters.AddWithValue("?fechaIni", fechaIni.ToString("yyyy-MM-dd" + " 00:00:00"));
                sql.Parameters.AddWithValue("?fechaFin", fechaFin.ToString("yyyy-MM-dd" + " 23:59:59"));
                dtIV = ConexionBD.EjecutarConsultaSelect(sql);
            }
            catch (MySqlException ex)
            {
                this.Invoke(men, new object[] { "Ha ocurrido un error al obtener los datos de las ganancias.", ex });
            }
            catch (Exception ex)
            {
                this.Invoke(men, new object[] { "Ha ocurrido un error al obtener los datos de las ganancias.", ex });
            }
        }

        private void ObtenerTotalesIngresosDiversos()
        {
            men = new MensajeError(CFuncionesGenerales.MensajeError);
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT fecha, efectivo, tarjeta, tipo_movimiento, descripcion FROM caja WHERE (fecha BETWEEN ?fechaIni AND ?fechaFin) " + 
                    " AND (descripcion != 'APERTURA DE CAJA') AND (descripcion != 'CIERRE DE CAJA') AND (descripcion != 'NUEVA MEMBRESÍA') " + 
                    "AND (descripcion != 'RENOVACIÓN MEMBRESÍA') AND (descripcion != 'VENTA POS') AND (descripcion != 'VENTA MOSTRADOR') AND tipo_movimiento=0;";
                sql.Parameters.AddWithValue("?fechaIni", fechaIni.ToString("yyyy-MM-dd" + " 00:00:00"));
                sql.Parameters.AddWithValue("?fechaFin", fechaFin.ToString("yyyy-MM-dd" + " 23:59:59"));
                dtID = ConexionBD.EjecutarConsultaSelect(sql);
            }
            catch (MySqlException ex)
            {
                this.Invoke(men, new object[] { "Ha ocurrido un error al obtener los datos de las ganancias.", ex });
            }
            catch (Exception ex)
            {
                this.Invoke(men, new object[] { "Ha ocurrido un error al obtener los datos de las ganancias.", ex });
            }
        }

        private void ObtenerTotalesCompras()
        {
            men = new MensajeError(CFuncionesGenerales.MensajeError);
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT fecha, tipo_pago, subtotal, descuento, impuesto FROM compra WHERE fecha BETWEEN ?fechaIni AND ?fechaFin";
                sql.Parameters.AddWithValue("?fechaIni", fechaIni.ToString("yyyy-MM-dd" + " 00:00:00"));
                sql.Parameters.AddWithValue("?fechaFin", fechaFin.ToString("yyyy-MM-dd" + " 23:59:59"));
                dtEC = ConexionBD.EjecutarConsultaSelect(sql);
            }
            catch (MySqlException ex)
            {
                this.Invoke(men, new object[] { "Ha ocurrido un error al obtener los datos de las ganancias.", ex });
            }
            catch (Exception ex)
            {
                this.Invoke(men, new object[] { "Ha ocurrido un error al obtener los datos de las ganancias.", ex });
            }
        }

        private void ObtenerTotalesEgresosDiversos()
        {
            men = new MensajeError(CFuncionesGenerales.MensajeError);
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT fecha, efectivo, tarjeta, tipo_movimiento, descripcion FROM caja WHERE (fecha BETWEEN ?fechaIni AND ?fechaFin) " +
                    " AND (descripcion != 'APERTURA DE CAJA') AND (descripcion != 'CIERRE DE CAJA') AND (descripcion != 'NUEVA MEMBRESÍA') " +
                    "AND (descripcion != 'RENOVACIÓN MEMBRESÍA') AND (descripcion != 'VENTA POS') AND (descripcion != 'VENTA MOSTRADOR') AND tipo_movimiento=1;";
                sql.Parameters.AddWithValue("?fechaIni", fechaIni.ToString("yyyy-MM-dd" + " 00:00:00"));
                sql.Parameters.AddWithValue("?fechaFin", fechaFin.ToString("yyyy-MM-dd" + " 23:59:59"));
                dtED = ConexionBD.EjecutarConsultaSelect(sql);
            }
            catch (MySqlException ex)
            {
                this.Invoke(men, new object[] { "Ha ocurrido un error al obtener los datos de las ganancias.", ex });
            }
            catch (Exception ex)
            {
                this.Invoke(men, new object[] { "Ha ocurrido un error al obtener los datos de las ganancias.", ex });
            }
        }

        private void CalcularTotales()
        {
            //Inicializamos variables
            efeMem = 0M;
            tarMem = 0M;
            efeVen = 0M;
            tarVen = 0M;
            efeDiv = 0M;
            tarDiv = 0M;
            efeCom = 0M;
            tarCom = 0M;
            efeEDiv = 0M;
            tarEDiv = 0M;
            efe = 0M;
            tar = 0M;
            try
            {
                //Hacemos la sumatoria de los totales de las membresías
                foreach (DataRow dr in dtIM.Rows)
                {
                    efeMem += (decimal)dr["efectivo"];
                    tarMem += (decimal)dr["tarjeta"];
                }
                //Hacemos la sumatoria de los totales de las ventas
                foreach (DataRow dr in dtIV.Rows)
                {
                    efeVen += (decimal)dr["efectivo"];
                    tarVen += (decimal)dr["tarjeta"];
                }
                //Hacemos la sumatoria de los totales diversos
                foreach (DataRow dr in dtID.Rows)
                {
                    efeDiv += (decimal)dr["efectivo"];
                    tarDiv += (decimal)dr["tarjeta"];
                }
                //Hacemos la sumatoria de los egresos de compras
                foreach (DataRow dr in dtEC.Rows)
                {
                    if (dr["tipo_pago"].ToString() == "0")
                        efeCom += (decimal)dr["subtotal"] + (decimal)dr["descuento"] + (decimal)dr["impuesto"];
                    else if (dr["tipo_pago"].ToString() == "1")
                        tarCom += (decimal)dr["subtotal"] + (decimal)dr["descuento"] + (decimal)dr["impuesto"];
                }
                //Hacemos la sumatoria de los egresos diversos
                foreach (DataRow dr in dtED.Rows)
                {
                    efeEDiv += ((decimal)dr["efectivo"] * -1);
                    tarEDiv += ((decimal)dr["tarjeta"] * -1);
                }
                efe = (efeMem + efeVen + efeDiv) - (efeCom + efeEDiv);
                tar = (tarMem + tarVen + tarDiv) - (tarCom + tarEDiv);
            }
            catch (InvalidCastException ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al realizar las operaciones de cálculo de ganancias.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al realizar las operaciones de cálculo de ganancias.", ex);
            }
        }

        private void AsignarValoresLabels()
        {
            lblIMembresias.Text = (efeMem + tarMem).ToString("C2");
            lblIEfectivoMembresias.Text = efeMem.ToString("C2");
            lblIVouchersMembresias.Text = tarMem.ToString("C2");

            lblIVentas.Text = (efeVen + tarVen).ToString("C2");
            lblIEfectivoVentas.Text = efeVen.ToString("C2");
            lblIVouchersVentas.Text = tarVen.ToString("C2");

            lblIDiversos.Text = (efeDiv + tarDiv).ToString("C2");
            lblIEfectivoDiversos.Text = efeDiv.ToString("C2");
            lblIVouchersDiversos.Text = tarDiv.ToString("C2");

            lblECompras.Text = (efeCom + tarCom).ToString("C2");
            lblEEfectivoCompras.Text = efeCom.ToString("C2");
            lblEVouchersCompras.Text = tarCom.ToString("C2");

            lblEDiversos.Text = (efeEDiv + tarEDiv).ToString("C2");
            lblEEfectivoDiversos.Text = efeEDiv.ToString("C2");
            lblEVouchersDiversos.Text = tarEDiv.ToString("C2");

            lblGanancia.Text = (efe + tar).ToString("C2");
            lblEfectivo.Text = efe.ToString("C2");
            lblVouchers.Text = tar.ToString("C2");
        }

        private void CalcularMesMembresia()
        {
            try
            {
                for (int i = 0; i <= años; i++)
                {
                    decimal enero = 0M,
                    febrero = 0M,
                    marzo = 0M,
                    abril = 0M,
                    mayo = 0M,
                    junio = 0M,
                    julio = 0M,
                    agosto = 0M,
                    septiembre = 0M,
                    octubre = 0M,
                    noviembre = 0M,
                    diciembre = 0M;

                    foreach (DataRow dr in dtIM.Rows)
                    {
                        DateTime fecha = (DateTime)dr["fecha"];
                        if (fecha.Year == fechaIni.Year + i)
                        {
                            switch (fecha.Month)
                            {
                                case 1:
                                    enero += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 2:
                                    febrero += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 3:
                                    marzo += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 4:
                                    abril += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 5:
                                    mayo += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 6:
                                    junio += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 7:
                                    julio += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 8:
                                    agosto += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 9:
                                    septiembre += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 10:
                                    octubre += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 11:
                                    noviembre += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 12:
                                    diciembre += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                            }
                        }
                    }
                    Series s = chrGanancia.Series["Membresias"];
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 1, 1), enero);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 2, 1), febrero);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 3, 1), marzo);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 4, 1), abril);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 5, 1), mayo);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 6, 1), junio);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 7, 1), julio);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 8, 1), agosto);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 9, 1), septiembre);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 10, 1), octubre);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 11, 1), noviembre);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 12, 1), diciembre);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CalcularMesVenta()
        {
            try
            {
                for (int i = 0; i <= años; i++)
                {
                    decimal enero = 0M,
                    febrero = 0M,
                    marzo = 0M,
                    abril = 0M,
                    mayo = 0M,
                    junio = 0M,
                    julio = 0M,
                    agosto = 0M,
                    septiembre = 0M,
                    octubre = 0M,
                    noviembre = 0M,
                    diciembre = 0M;

                    foreach (DataRow dr in dtIV.Rows)
                    {
                        DateTime fecha = (DateTime)dr["fecha"];
                        if (fecha.Year == fechaIni.Year + i)
                        {
                            switch (fecha.Month)
                            {
                                case 1:
                                    enero += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 2:
                                    febrero += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 3:
                                    marzo += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 4:
                                    abril += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 5:
                                    mayo += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 6:
                                    junio += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 7:
                                    julio += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 8:
                                    agosto += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 9:
                                    septiembre += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 10:
                                    octubre += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 11:
                                    noviembre += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 12:
                                    diciembre += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                            }
                        }
                    }
                    Series s = chrGanancia.Series["Ventas"];
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 1, 1), enero);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 2, 1), febrero);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 3, 1), marzo);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 4, 1), abril);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 5, 1), mayo);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 6, 1), junio);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 7, 1), julio);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 8, 1), agosto);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 9, 1), septiembre);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 10, 1), octubre);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 11, 1), noviembre);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 12, 1), diciembre);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CalcularMesIDiversos()
        {
            try
            {
                for (int i = 0; i <= años; i++)
                {
                    decimal enero = 0M,
                    febrero = 0M,
                    marzo = 0M,
                    abril = 0M,
                    mayo = 0M,
                    junio = 0M,
                    julio = 0M,
                    agosto = 0M,
                    septiembre = 0M,
                    octubre = 0M,
                    noviembre = 0M,
                    diciembre = 0M;

                    foreach (DataRow dr in dtID.Rows)
                    {
                        DateTime fecha = (DateTime)dr["fecha"];
                        if (fecha.Year == fechaIni.Year + i)
                        {
                            switch (fecha.Month)
                            {
                                case 1:
                                    enero += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 2:
                                    febrero += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 3:
                                    marzo += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 4:
                                    abril += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 5:
                                    mayo += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 6:
                                    junio += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 7:
                                    julio += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 8:
                                    agosto += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 9:
                                    septiembre += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 10:
                                    octubre += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 11:
                                    noviembre += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 12:
                                    diciembre += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                            }
                        }
                    }
                    Series s = chrGanancia.Series["Ingresos diversos"];
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 1, 1), enero);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 2, 1), febrero);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 3, 1), marzo);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 4, 1), abril);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 5, 1), mayo);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 6, 1), junio);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 7, 1), julio);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 8, 1), agosto);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 9, 1), septiembre);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 10, 1), octubre);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 11, 1), noviembre);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 12, 1), diciembre);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CalcularMesCompras()
        {
            try
            {
                for (int i = 0; i <= años; i++)
                {
                    decimal enero = 0M,
                    febrero = 0M,
                    marzo = 0M,
                    abril = 0M,
                    mayo = 0M,
                    junio = 0M,
                    julio = 0M,
                    agosto = 0M,
                    septiembre = 0M,
                    octubre = 0M,
                    noviembre = 0M,
                    diciembre = 0M;

                    foreach (DataRow dr in dtEC.Rows)
                    {
                        DateTime fecha = (DateTime)dr["fecha"];
                        if (fecha.Year == fechaIni.Year + i)
                        {
                            switch (fecha.Month)
                            {
                                case 1:
                                    enero += ((decimal)dr["subtotal"] + (decimal)dr["descuento"] + (decimal)dr["impuesto"]) * -1;
                                    break;
                                case 2:
                                    febrero += ((decimal)dr["subtotal"] + (decimal)dr["descuento"] + (decimal)dr["impuesto"]) * -1;
                                    break;
                                case 3:
                                    marzo += ((decimal)dr["subtotal"] + (decimal)dr["descuento"] + (decimal)dr["impuesto"]) * -1;
                                    break;
                                case 4:
                                    abril += ((decimal)dr["subtotal"] + (decimal)dr["descuento"] + (decimal)dr["impuesto"]) * -1;
                                    break;
                                case 5:
                                    mayo += ((decimal)dr["subtotal"] + (decimal)dr["descuento"] + (decimal)dr["impuesto"]) * -1;
                                    break;
                                case 6:
                                    junio += ((decimal)dr["subtotal"] + (decimal)dr["descuento"] + (decimal)dr["impuesto"]) * -1;
                                    break;
                                case 7:
                                    julio += ((decimal)dr["subtotal"] + (decimal)dr["descuento"] + (decimal)dr["impuesto"]) * -1;
                                    break;
                                case 8:
                                    agosto += ((decimal)dr["subtotal"] + (decimal)dr["descuento"] + (decimal)dr["impuesto"]) * -1;
                                    break;
                                case 9:
                                    septiembre += ((decimal)dr["subtotal"] + (decimal)dr["descuento"] + (decimal)dr["impuesto"]) * -1;
                                    break;
                                case 10:
                                    octubre += ((decimal)dr["subtotal"] + (decimal)dr["descuento"] + (decimal)dr["impuesto"]) * -1;
                                    break;
                                case 11:
                                    noviembre += ((decimal)dr["subtotal"] + (decimal)dr["descuento"] + (decimal)dr["impuesto"]) * -1;
                                    break;
                                case 12:
                                    diciembre += ((decimal)dr["subtotal"] + (decimal)dr["descuento"] + (decimal)dr["impuesto"]) * -1;
                                    break;
                            }
                        }
                    }
                    Series s = chrGanancia.Series["Compras"];
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 1, 1), enero);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 2, 1), febrero);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 3, 1), marzo);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 4, 1), abril);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 5, 1), mayo);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 6, 1), junio);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 7, 1), julio);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 8, 1), agosto);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 9, 1), septiembre);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 10, 1), octubre);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 11, 1), noviembre);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 12, 1), diciembre);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CalcularMesEDiversos()
        {
            try
            {
                for (int i = 0; i <= años; i++)
                {
                    decimal enero = 0M,
                    febrero = 0M,
                    marzo = 0M,
                    abril = 0M,
                    mayo = 0M,
                    junio = 0M,
                    julio = 0M,
                    agosto = 0M,
                    septiembre = 0M,
                    octubre = 0M,
                    noviembre = 0M,
                    diciembre = 0M;

                    foreach (DataRow dr in dtED.Rows)
                    {
                        DateTime fecha = (DateTime)dr["fecha"];
                        if (fecha.Year == fechaIni.Year + i)
                        {
                            switch (fecha.Month)
                            {
                                case 1:
                                    enero += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 2:
                                    febrero += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 3:
                                    marzo += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 4:
                                    abril += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 5:
                                    mayo += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 6:
                                    junio += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 7:
                                    julio += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 8:
                                    agosto += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 9:
                                    septiembre += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 10:
                                    octubre += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 11:
                                    noviembre += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                                case 12:
                                    diciembre += ((decimal)dr["efectivo"] + (decimal)dr["tarjeta"]);
                                    break;
                            }
                        }
                    }
                    Series s = chrGanancia.Series["Egresos diversos"];
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 1, 1), enero);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 2, 1), febrero);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 3, 1), marzo);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 4, 1), abril);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 5, 1), mayo);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 6, 1), junio);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 7, 1), julio);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 8, 1), agosto);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 9, 1), septiembre);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 10, 1), octubre);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 11, 1), noviembre);
                    s.Points.AddXY(new DateTime(fechaIni.Year + i, 12, 1), diciembre);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Graficar()
        {
            chrGanancia.Series.Clear();
            chrGanancia.Legends.Clear();
            try
            {
                chrGanancia.ChartAreas[0].AxisX.LabelStyle.Format = "MMMM/yyyy";
                chrGanancia.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Years;
                chrGanancia.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
                chrGanancia.ChartAreas[0].AxisX.Interval = -1;
                chrGanancia.ChartAreas[0].AxisX.IntervalOffset = -1;
                chrGanancia.ChartAreas[0].AxisX.IsLabelAutoFit = true;
                chrGanancia.ChartAreas[0].AxisY.LabelStyle.Format = "C2";

                Series sMem, sVen, sIDiv, sCom, sEDiv;
                Legend lMem, lVen, lIDiv, lCom, lEDiv;
                //Primero agregamos las series a el chart y creamos los objetos de tipo Series para modificar sus propiedades
                sMem = chrGanancia.Series.Add("Membresias");
                lMem = chrGanancia.Legends.Add("Membresías");
                sMem.ChartType = SeriesChartType.Column;
                sMem.XValueType = ChartValueType.Date;

                sVen = chrGanancia.Series.Add("Ventas");
                lVen = chrGanancia.Legends.Add("Ventas");
                sVen.ChartType = SeriesChartType.Column;
                sVen.XValueType = ChartValueType.Date;

                sIDiv = chrGanancia.Series.Add("Ingresos diversos");
                lIDiv = chrGanancia.Legends.Add("Ingresos diversos");
                sIDiv.ChartType = SeriesChartType.Column;
                sIDiv.XValueType = ChartValueType.Date;

                sCom = chrGanancia.Series.Add("Compras");
                lCom = chrGanancia.Legends.Add("Compras");
                sCom.ChartType = SeriesChartType.Column;
                sCom.XValueType = ChartValueType.Date;

                sEDiv = chrGanancia.Series.Add("Egresos diversos");
                lEDiv = chrGanancia.Legends.Add("Egresos diversos");
                sEDiv.ChartType = SeriesChartType.Column;
                sEDiv.XValueType = ChartValueType.Date;

                CalcularMesMembresia();
                CalcularMesVenta();
                CalcularMesIDiversos();
                CalcularMesCompras();
                CalcularMesEDiversos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dtpFechas_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaIni.Value > dtpFechaFin.Value)
                dtpFechaIni.Value = dtpFechaFin.Value;
            if (dtpFechaFin.Value < dtpFechaIni.Value)
                dtpFechaFin.Value = dtpFechaIni.Value;
            fechaIni = dtpFechaIni.Value;
            fechaFin = dtpFechaFin.Value;
            años = fechaFin.Year - fechaIni.Year;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!bgwReporte.IsBusy)
            {
                tmrEspera.Enabled = true;
                CFuncionesGenerales.DeshabilitarBotonCerrar(this);
                grbFechas.Enabled = false;
                bgwReporte.RunWorkerAsync();
            }
        }

        private void bgwReporte_DoWork(object sender, DoWorkEventArgs e)
        {
            ObtenerTotalesCompras();
            ObtenerTotalesEgresosDiversos();
            ObtenerTotalesIngresosDiversos();
            ObtenerTotalesMembresias();
            ObtenerTotalesVentas();
        }

        private void bgwReporte_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tmrEspera.Enabled = false;
            CFuncionesGenerales.frmEsperaClose();
            CFuncionesGenerales.HabilitarBotonCerrar(this);
            grbFechas.Enabled = true;
            CalcularTotales();
            AsignarValoresLabels();
            Graficar();
        }

        private void tmrEspera_Tick(object sender, EventArgs e)
        {
            tmrEspera.Enabled = false;
            CFuncionesGenerales.frmEspera("Espere, obteniendo datos para calcular ganancias", this);
        }
    }
}
