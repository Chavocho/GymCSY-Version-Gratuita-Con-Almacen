﻿using GYM.Clases;
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

        DataTable dtV = new DataTable(), dtVD = new DataTable(), dtM = new DataTable();
        DateTime horaIni = DateTime.Parse(DateTime.Now.ToString("dd-MM-yyyy") + " " + CConfiguracionXML.LeerConfiguración("ticket", "turnoMat")),
            horaFin = DateTime.Parse(DateTime.Now.ToString("dd-MM-yyyy") + " " + CConfiguracionXML.LeerConfiguración("ticket", "turnoVes")),
            fecha;

        public frmReporteVentaDia()
        {
            InitializeComponent();
            cboReporte.SelectedIndex = cboTurno.SelectedIndex = 0;
            fecha = dtpFecha.Value;
        }

        private void ObtenerTotalVentasMembresias()
        {
            try
            {
                lblETotal.Text = "Total de ventas de membresías:";
                lblEEfectivo.Text = "Total efectivo de membresías:";
                lblEVoucher.Text = "Total vouchers de membresías:";
                lblTotal.Left = lblETotal.Right + 6;
                lblEfectivo.Left = lblEEfectivo.Right + 6;
                lblVoucher.Left = lblEVoucher.Right + 6;

                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT SUM(efectivo) AS ef, SUM(tarjeta) AS ta, SUM(efectivo + tarjeta) AS tot FROM caja " + 
                    "WHERE (fecha BETWEEN ?fechaIni AND ?fechaFin) AND (descripcion=?concepto01 OR descripcion=?concepto02)";
                sql.Parameters.AddWithValue("?fechaIni", dtpFecha.Value.ToString("yyyy-MM-dd") + " 00:00:00");
                sql.Parameters.AddWithValue("?fechaFin", dtpFecha.Value.ToString("yyyy-MM-dd") + " 23:59:59");
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
                sql.Parameters.AddWithValue("?fechaIni", dtpFecha.Value.ToString("yyyy-MM-dd") + " 00:00:00");
                sql.Parameters.AddWithValue("?fechaFin", dtpFecha.Value.ToString("yyyy-MM-dd") + " 23:59:59");
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
                MessageBox.Show(ex.ToString());
            }
	        catch (Exception ex)
            {   
                MessageBox.Show(ex.ToString());
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
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
	        catch (Exception ex)
	        {
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
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
                if (cboReporte.SelectedIndex == 0)
                {
                    foreach (DataRow dr in dtM.Rows)
	                {
                        dgvVentas.Rows.Add(new object[] { dr["id"], dr["numSocio"].ToString(), decimal.Parse(dr["efectivo"].ToString()), decimal.Parse(dr["tarjeta"].ToString()), dr["folio_remision"].ToString(), DateTime.Parse(dr["fecha"].ToString()), dr["descripcion"].ToString(), dr["userName"].ToString() });
	                }
                }
                else if (cboReporte.SelectedIndex == 1)
                {
                    foreach (DataRow dr in dtV.Rows)
                    {
                        dgvVentas.Rows.Add(new object[] { dr["idv"], "", decimal.Parse(dr["efectivo"].ToString()), decimal.Parse(dr["tarjeta"].ToString()), dr["idv"].ToString(), DateTime.Parse(dr["fecha"].ToString()).ToString("hh:mm tt"), dr["descripcion"].ToString(), dr["userName"].ToString() });
                    } 
                    dgvVentas_RowEnter(dgvVentas, new DataGridViewCellEventArgs(0, 0));
                }
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
                PropiedadesLabelEtiqueta(ref lblECodProd, "lblECodProd", "Código de producto", new Point(lCod, y));
                PropiedadesLabelEtiqueta(ref lblENombre, "lblENombre", "Nombre", new Point(lNom, y));
                PropiedadesLabelEtiqueta(ref lblEPrecio, "lblEPrecio", "Precio", new Point(lPre, y));
                PropiedadesLabelEtiqueta(ref lblECant, "lblECant", "Cantidad", new Point(lCan, y));

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
                    PropiedadesLabel(ref lblCodProd, "lblCodProd" + x.ToString("000"), dr["id_producto"].ToString(), new Point(lCod, y));
                    PropiedadesLabel(ref lblNombre, "lblNombre" + x.ToString("000"), dr["nombre"].ToString(), new Point(lNom, y));
                    PropiedadesLabel(ref lblPrecio, "lblPrecio" + x.ToString("000"), dr["precio"].ToString(), new Point(lPre, y));
                    PropiedadesLabel(ref lblCant, "lblCant" + x.ToString("000"), dr["cantidad"].ToString(), new Point(lCan, y));

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

        private void PropiedadesLabelEtiqueta(ref Label lbl, string name, string texto, Point location)
        {
            try
            {
                lbl.Name = name;
                lbl.AutoSize = true;
                lbl.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                lbl.Text = texto;
                lbl.Location = location;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void PropiedadesLabel(ref Label lbl, string name, string texto, Point location)
        {
            try
            {
                lbl.Name = name;
                lbl.AutoSize = true;
                lbl.Font = new Font("Segoe UI", 11, FontStyle.Regular);
                lbl.Text = texto;
                lbl.Location = location;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            pnlProductos.Controls.Clear();
            tmrEspera.Enabled = true;
            switch (cboReporte.SelectedIndex)
            {
                case 0:
                    ObtenerTotalVentasMembresias();
                    dgvVentas.Columns[1].Visible = true;
                    bgwMembresia.RunWorkerAsync(cboTurno.SelectedIndex);
                    break;
                case 1:
                    ObtenerTotalVentasPOS();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}