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
    public partial class frmReporteVentaDia : Form
    {
        #region Instancia
        private static frmReporteVentaDia frmInstancia;
        public static frmReporteVentaDia Instancia
        {
            get
            {
                if (frmInstancia == null)
                    frmInstancia = new frmReporteVentaDia();
                else if (frmInstancia.IsDisposed)
                    frmInstancia = new frmReporteVentaDia();
                return frmInstancia;

            }
            set
            {
                frmInstancia = value;
            }
        }
        #endregion

        DataTable dtV = new DataTable(), dtVD = new DataTable(), dtM = new DataTable(), dtP = new DataTable();
        DateTime horaIni = DateTime.Parse(DateTime.Now.ToString("dd-MM-yyyy") + " " + CConfiguracionXML.LeerConfiguración("ticket", "turnoMat")),
            horaFin = DateTime.Parse(DateTime.Now.ToString("dd-MM-yyyy") + " " + CConfiguracionXML.LeerConfiguración("ticket", "turnoVes")),
            fecha;

        public frmReporteVentaDia()
        {
            InitializeComponent();
            cboReporte.SelectedIndex = cboTurno.SelectedIndex = 0;
            fecha = dtpFecha.Value;
        }

        private void ObtenerTotalVentasMembresias(int turno)
        {
            try
            {
                lblETotal.Text = "Total de membresías:";
                lblEEfectivo.Text = "Total efectivo de membresías:";
                lblEVoucher.Text = "Total vouchers de membresías:";
                lblTotal.Left = lblETotal.Right + 6;
                lblEfectivo.Left = lblEEfectivo.Right + 6;
                lblVoucher.Left = lblEVoucher.Right + 6;

                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT SUM(efectivo) AS ef, SUM(tarjeta) AS ta, SUM(efectivo + tarjeta) AS tot FROM caja " +
                    "WHERE (fecha BETWEEN ?fechaIni AND ?fechaFin) AND (descripcion=?concepto01 OR descripcion=?concepto02)";
                if (turno == 0)
                {
                    sql.Parameters.AddWithValue("?fechaIni", dtpFecha.Value.ToString("yyyy-MM-dd") + " 00:00:00");
                    sql.Parameters.AddWithValue("?fechaFin", dtpFecha.Value.ToString("yyyy-MM-dd") + " " + horaFin.ToString("HH:mm") + ":00");
                }
                else
                {
                    sql.Parameters.AddWithValue("?fechaIni", dtpFecha.Value.ToString("yyyy-MM-dd") + " " + horaFin.ToString("HH:mm") + ":00");
                    sql.Parameters.AddWithValue("?fechaFin", dtpFecha.Value.ToString("yyyy-MM-dd") + " 23:59:59");
                }
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

        private void ObtenerTotalVentasPOS(int turno)
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
                if (turno == 0)
                {
                    sql.Parameters.AddWithValue("?fechaIni", dtpFecha.Value.ToString("yyyy-MM-dd") + " 00:00:00");
                    sql.Parameters.AddWithValue("?fechaFin", dtpFecha.Value.ToString("yyyy-MM-dd") + " " + horaFin.ToString("HH:mm") + ":00");
                }
                else
                {
                    sql.Parameters.AddWithValue("?fechaIni", dtpFecha.Value.ToString("yyyy-MM-dd") + " " + horaFin.ToString("HH:mm") + ":00");
                    sql.Parameters.AddWithValue("?fechaFin", dtpFecha.Value.ToString("yyyy-MM-dd") + " 23:59:59");
                }
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
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al obtener el total de las ventas. No se pudo realizar la conexión con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al obtener el total de las ventas. Ocurrió un error genérico.", ex);
            }
        }

        private void ObtenerDatosVentas(int turno)
        {
            try 
	        {	        
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT v.id AS idv, v.total, c.*, u.userName FROM venta AS v INNER JOIN caja AS c ON (c.id_venta=v.id) LEFT JOIN usuarios AS u ON (v.create_user_id=u.id) WHERE c.fecha BETWEEN ?fechaIni AND ?fechaFin";
                if (turno == 0)
                {
                    sql.Parameters.AddWithValue("?fechaIni", fecha.ToString("yyyy-MM-dd") + " 00:00:00");
                    sql.Parameters.AddWithValue("?fechaFin", fecha.ToString("yyyy-MM-dd") + " " + horaFin.ToString("HH:mm") + ":00");
                }
                else
                {
                    sql.Parameters.AddWithValue("?fechaIni", fecha.ToString("yyyy-MM-dd") + " " + horaFin.ToString("HH:mm") + ":00");
                    sql.Parameters.AddWithValue("?fechaFin", fecha.ToString("yyyy-MM-dd") + " 23:59:59");
                }
                dtV = ConexionBD.EjecutarConsultaSelect(sql);
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al obtener los datos de las ventas. No se pudo realizar la conexión con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al obtener los datos de las ventas. Ocurrió un error genérico.", ex);
            }
        }

        private void ObtenerDatosVentasDetalladas(int id)
        {
            try 
	        {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT v.id_producto, v.cantidad, v.precio, p.nombre, p.descripcion FROM venta_detallada AS v INNER JOIN producto AS p ON (p.id=v.id_producto) WHERE v.id_venta=?id_venta";
                sql.Parameters.AddWithValue("?id_venta", id);
                dtVD = ConexionBD.EjecutarConsultaSelect(sql);
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al obtener el detallado de las ventas. No se pudo realizar la conexión con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al obtener el detallado de las ventas. Ocurrió un error genérico.", ex);
            }
        }

        private void ObtenerDatosProductosFecha(int turno)
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT p.nombre, p.descripcion, SUM(vd.cantidad) AS cant FROM venta_detallada AS vd INNER JOIN venta AS v ON (v.id=vd.id_venta) INNER JOIN producto AS p ON (vd.id_producto=p.id) WHERE v.fecha BETWEEN ?fechaIni AND ?fechaFin GROUP BY vd.id_producto";
                if (turno == 0)
                {
                    sql.Parameters.AddWithValue("?fechaIni", fecha.ToString("yyyy-MM-dd") + " 00:00:00");
                    sql.Parameters.AddWithValue("?fechaFin", fecha.ToString("yyyy-MM-dd") + " " + horaFin.ToString("HH:mm") + ":00");
                }
                else
                {
                    sql.Parameters.AddWithValue("?fechaIni", fecha.ToString("yyyy-MM-dd") + " " + horaFin.ToString("HH:mm") + ":00");
                    sql.Parameters.AddWithValue("?fechaFin", fecha.ToString("yyyy-MM-dd") + " 23:59:59");
                }
                dtP = ConexionBD.EjecutarConsultaSelect(sql);
                LlenarPanelTotalProductos();
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al obtener el total de productos de ventas. No se pudo realizar la conexión con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al obtener el total de productos de ventas. Ocurrió un error genérico.", ex);
            }
        }

        private void ObtenerDatosMembresias(int turno)
        {
            try 
	        {	        
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT c.*, r.folio_remision, m.numSocio, u.userName FROM caja AS c INNER JOIN registro_membresias AS r ON (c.id_membresia=r.membresia_id) LEFT JOIN membresias AS m ON (c.id_membresia=m.id) LEFT JOIN usuarios AS u ON (r.create_user_id=u.id) WHERE (c.fecha BETWEEN ?fechaIni AND ?fechaFin) AND (r.create_time BETWEEN ?fechaIni01 AND ?fechaFin01) ORDER BY c.fecha DESC";
                if (turno == 0)
                {
                    sql.Parameters.AddWithValue("?fechaIni", fecha.ToString("yyyy-MM-dd") + " 00:00:00");
                    sql.Parameters.AddWithValue("?fechaFin", fecha.ToString("yyyy-MM-dd") + " " + horaFin.ToString("HH:mm") + ":00");
                    sql.Parameters.AddWithValue("?fechaIni01", fecha.ToString("yyyy-MM-dd") + " 00:00:00");
                    sql.Parameters.AddWithValue("?fechaFin01", fecha.ToString("yyyy-MM-dd") + " " + horaFin.ToString("HH:mm") + ":00");
                }
                else
                {
                    sql.Parameters.AddWithValue("?fechaIni", fecha.ToString("yyyy-MM-dd") + " " + horaFin.ToString("HH:mm") + ":00");
                    sql.Parameters.AddWithValue("?fechaFin", fecha.ToString("yyyy-MM-dd") + " 23:59:59");
                    sql.Parameters.AddWithValue("?fechaIni01", fecha.ToString("yyyy-MM-dd") + " " + horaFin.ToString("HH:mm") + ":00");
                    sql.Parameters.AddWithValue("?fechaFin01", fecha.ToString("yyyy-MM-dd") + " 23:59:59");
                }
                dtM = ConexionBD.EjecutarConsultaSelect(sql);
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al obtener los datos de las membresías. No se pudo realizar la conexión con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al obtener los datos de las membresías. Ocurrió un error genérico.", ex);
            }
        }

        private void LlenarDataGrid()
        {
            try 
	        {
                dgvVentas.Rows.Clear();
                if (cboReporte.SelectedIndex == 0)
                {
                    foreach (DataRow dr in dtM.Rows)
	                {
                        dgvVentas.Rows.Add(new object[] { dr["id"], dr["numSocio"].ToString(), decimal.Parse(dr["efectivo"].ToString()), decimal.Parse(dr["tarjeta"].ToString()), dr["folio_remision"].ToString(), DateTime.Parse(dr["fecha"].ToString()), dr["descripcion"].ToString(), dr["userName"].ToString() });
                        Application.DoEvents();
	                }
                }
                else if (cboReporte.SelectedIndex == 1)
                {
                    foreach (DataRow dr in dtV.Rows)
                    {
                        dgvVentas.Rows.Add(new object[] { dr["idv"], "", decimal.Parse(dr["efectivo"].ToString()), decimal.Parse(dr["tarjeta"].ToString()), dr["idv"].ToString(), DateTime.Parse(dr["fecha"].ToString()), dr["descripcion"].ToString(), dr["userName"].ToString() });
                        Application.DoEvents();
                    } 
                }
                dgvVentas_RowEnter(dgvVentas, new DataGridViewCellEventArgs(0, 0));
	        }
	        catch (Exception ex)
	        {
                CFuncionesGenerales.MensajeError("Ocurrió un error genérico al mostrar la información.", ex);
	        }
        }

        private void LlenarPanelProductos()
        {
            pnlProductos.Controls.Clear();
            Label lblTitulo;
            Label lblECodProd;
            Label lblCodProd;
            Label lblENombre;
            Label lblNombre;
            Label lblEDescripcion;
            Label lblDescripcion;
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
                int lNom = 200;
                int lDes = (pnlProductos.Width / 4) * 2 - 150;
                int lPre = (pnlProductos.Width / 4) * 3;
                int lCan = (pnlProductos.Width / 4) * 3 + 100;

                lblTitulo = new Label();
                lblECodProd = new Label();
                lblENombre = new Label();
                lblEDescripcion = new Label();
                lblEPrecio = new Label();
                lblECant = new Label();

                //Asignamos sus propiedades usando el método PropiedadesLabelEtiqueta
                PropiedadesLabelEtiqueta(ref lblTitulo, "lblTitulo", "Detalle de venta", new Point(lCod, y), tabIndex);
                lblTitulo.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                tabIndex++;
                y += salto;

                PropiedadesLabelEtiqueta(ref lblECodProd, "lblECodProd", "Código de producto", new Point(lCod, y), tabIndex);
                tabIndex++;
                PropiedadesLabelEtiqueta(ref lblENombre, "lblENombre", "Nombre", new Point(lNom, y), tabIndex);
                tabIndex++;
                PropiedadesLabelEtiqueta(ref lblEDescripcion, "lblEDescripcion", "Descripción", new Point(lDes, y), tabIndex);
                tabIndex++;
                PropiedadesLabelEtiqueta(ref lblEPrecio, "lblEPrecio", "Precio", new Point(lPre, y), tabIndex);
                tabIndex++;
                PropiedadesLabelEtiqueta(ref lblECant, "lblECant", "Cantidad", new Point(lCan, y), tabIndex);
                tabIndex++;

                //Agregamos los controles al panel
                pnlProductos.Controls.Add(lblTitulo);
                pnlProductos.Controls.Add(lblECodProd);
                pnlProductos.Controls.Add(lblENombre);
                pnlProductos.Controls.Add(lblEDescripcion);
                pnlProductos.Controls.Add(lblEPrecio);
                pnlProductos.Controls.Add(lblECant);
                y += salto;
                foreach (DataRow dr in dtVD.Rows)
                {
                    int x = 0;
                    lblCodProd = new Label();
                    lblNombre = new Label();
                    lblDescripcion = new Label();
                    lblPrecio = new Label();
                    lblCant = new Label();
                    
                    //Asignamos sus propiedades usando el método PropiedadesLabel
                    PropiedadesLabel(ref lblCodProd, "lblCodProd" + x.ToString("000"), dr["id_producto"].ToString(), new Point(lCod, y), tabIndex);
                    tabIndex++;
                    PropiedadesLabel(ref lblNombre, "lblNombre" + x.ToString("000"), dr["nombre"].ToString(), new Point(lNom, y), tabIndex);
                    tabIndex++;
                    PropiedadesLabel(ref lblDescripcion, "lblDescripcion" + x.ToString("000"), dr["descripcion"].ToString(), new Point(lDes, y), tabIndex);
                    tabIndex++;
                    PropiedadesLabel(ref lblPrecio, "lblPrecio" + x.ToString("000"), dr["precio"].ToString(), new Point(lPre, y), tabIndex);
                    tabIndex++;
                    PropiedadesLabel(ref lblCant, "lblCant" + x.ToString("000"), dr["cantidad"].ToString(), new Point(lCan, y), tabIndex);
                    tabIndex++;

                    //Agregamos los controles al panel
                    pnlProductos.Controls.Add(lblCodProd);
                    pnlProductos.Controls.Add(lblNombre);
                    pnlProductos.Controls.Add(lblDescripcion);
                    pnlProductos.Controls.Add(lblPrecio);
                    pnlProductos.Controls.Add(lblCant);
                    y += salto;
                }

            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("Ocurrió un error genérico al mostrar la información de los productos.", ex);
            }
        }

        private void LlenarPanelTotalProductos()
        {
            pnlTotalProds.Controls.Clear();
            Label lblTitulo;
            Label lblENomProd;
            Label lblNomProd;
            Label lblEDesc;
            Label lblDesc;
            Label lblECant;
            Label lblCant;
            int tabIndex = 0;
            try
            {
                Graphics e = this.CreateGraphics();
                int y = 10;
                int salto = (int)(e.MeasureString("Algo", new Font("Segoe UI", 12, FontStyle.Bold)).Height) + 5;
                int lNom = 10;
                int lDesc = 350;
                int lCant = (pnlProductos.Width / 4) * 3;

                lblTitulo = new Label();
                lblENomProd = new Label();
                lblEDesc = new Label();
                lblECant = new Label();

                //Asignamos sus propiedades usando el método PropiedadesLabelEtiqueta
                PropiedadesLabelEtiqueta(ref lblTitulo, "lblTitulo", "Total de productos vendidos", new Point(lNom, y), tabIndex);
                lblTitulo.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                tabIndex++;
                y += salto;

                PropiedadesLabelEtiqueta(ref lblENomProd, "lblENomProd", "Nombre", new Point(lNom, y), tabIndex);
                tabIndex++;
                PropiedadesLabelEtiqueta(ref lblEDesc, "lblEDescripcion", "Descripción", new Point(lDesc, y), tabIndex);
                tabIndex++;
                PropiedadesLabelEtiqueta(ref lblECant, "lblECant", "Cantidad", new Point(lCant, y), tabIndex);
                tabIndex++;

                //Agregamos los controles al panel
                pnlTotalProds.Controls.Add(lblTitulo);
                pnlTotalProds.Controls.Add(lblENomProd);
                pnlTotalProds.Controls.Add(lblEDesc);
                pnlTotalProds.Controls.Add(lblECant);
                y += salto;

                foreach (DataRow dr in dtP.Rows)
                {
                    int x = 0;
                    lblNomProd = new Label();
                    lblDesc = new Label();
                    lblCant = new Label();

                    //Asignamos sus propiedades usando el método PropiedadesLabel
                    PropiedadesLabel(ref lblNomProd, "lblNomProd" + x.ToString("000"), dr["nombre"].ToString(), new Point(lNom, y), tabIndex);
                    tabIndex++;
                    PropiedadesLabel(ref lblDesc, "lblDescripcion" + x.ToString("000"), dr["descripcion"].ToString(), new Point(lDesc, y), tabIndex);
                    tabIndex++;
                    PropiedadesLabel(ref lblCant, "lblCant" + x.ToString("000"), dr["cant"].ToString(), new Point(lCant, y), tabIndex);
                    tabIndex++;

                    //Agregamos los controles al panel
                    pnlTotalProds.Controls.Add(lblNomProd);
                    pnlTotalProds.Controls.Add(lblDesc);
                    pnlTotalProds.Controls.Add(lblCant);
                    y += salto;
                }
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("Ocurrió un error genérico al mostrar la información de los totales de productos.", ex);
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
            catch
            {
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
            catch
            {
            }
        }

        private void bgwMembresia_DoWork(object sender, DoWorkEventArgs e)
        {
            ObtenerDatosMembresias((int)e.Argument);
        }

        private void bgwMembresia_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tmrEspera.Enabled = false;
            CFuncionesGenerales.frmEsperaClose();
            LlenarDataGrid();
            btnBuscar.Enabled = true;
            CFuncionesGenerales.HabilitarBotonCerrar(this);
        }

        private void bgwVentas_DoWork(object sender, DoWorkEventArgs e)
        {
            ObtenerDatosVentas((int)e.Argument);
        }

        private void bgwVentas_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tmrEspera.Enabled = false;
            CFuncionesGenerales.frmEsperaClose();
            LlenarDataGrid();
            btnBuscar.Enabled = true;
            CFuncionesGenerales.HabilitarBotonCerrar(this);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            pnlProductos.Controls.Clear();
            pnlTotalProds.Controls.Clear();
            tmrEspera.Enabled = true;
            CFuncionesGenerales.DeshabilitarBotonCerrar(this);
            btnBuscar.Enabled = false;
            switch (cboReporte.SelectedIndex)
            {
                case 0:
                    dgvVentas.Size = new Size(dgvVentas.Width, pnlTotalProds.Bottom - dgvVentas.Location.Y);
                    pnlProductos.Visible = false;
                    pnlTotalProds.Visible = false;
                    ObtenerTotalVentasMembresias(cboTurno.SelectedIndex);
                    dgvVentas.Columns[1].Visible = true;
                    bgwMembresia.RunWorkerAsync(cboTurno.SelectedIndex);
                    break;
                case 1:
                    dgvVentas.Size = new Size(dgvVentas.Width, pnlProductos.Location.Y - dgvVentas.Location.Y - 6);
                    pnlProductos.Visible = true;
                    pnlTotalProds.Visible = true;
                    ObtenerTotalVentasPOS(cboTurno.SelectedIndex);
                    ObtenerDatosProductosFecha(cboTurno.SelectedIndex);
                    dgvVentas.Columns[1].Visible = false;
                    bgwVentas.RunWorkerAsync(cboTurno.SelectedIndex);
                    break;
            }

        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            fecha = dtpFecha.Value;
        }

        private void tmrEspera_Tick(object sender, EventArgs e)
        {
            tmrEspera.Enabled = false;
            CFuncionesGenerales.frmEspera("Espere, buscando las ventas", this);
        }

        private void dgvVentas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvVentas.CurrentRow != null)
                {
                    if (cboReporte.SelectedIndex == 1)
                    {
                        ObtenerDatosVentasDetalladas((int)dgvVentas[0, e.RowIndex].Value);
                        LlenarPanelProductos();
                    }
                }
            }
            catch
            {
            }
        }

        private void frmReporteVentaDia_SizeChanged(object sender, EventArgs e)
        {
            if (cboReporte.SelectedIndex == 1)
            {
                if (dgvVentas.CurrentRow != null)
                {
                    LlenarPanelProductos();
                    LlenarPanelTotalProductos();
                }
            }
        }
    }
}
