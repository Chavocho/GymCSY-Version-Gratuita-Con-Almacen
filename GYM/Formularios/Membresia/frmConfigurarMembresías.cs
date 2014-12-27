using GYM.Clases;
using GYM.Formularios.Membresia;
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

namespace GYM.Formularios
{
    public partial class frmConfigurarMembresías : Form
    {
        #region Instancia
        private static frmConfigurarMembresías frmInstancia;
        public static frmConfigurarMembresías Instancia
        {
            get
            {
                if (frmInstancia == null)
                    frmInstancia = new frmConfigurarMembresías();
                else if (frmInstancia.IsDisposed)
                    frmInstancia = new frmConfigurarMembresías();
                return frmInstancia;

            }
            set
            {
                frmInstancia = value;
            }
        }
        #endregion

        public frmConfigurarMembresías()
        {
            InitializeComponent();
            CFuncionesGenerales.CargarInterfaz(this);
        }

        private void PreciosHombres()
        {
            try
            {
                string sql = "SELECT id, precio FROM precio_membresia WHERE sexo=0";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    switch ((int)dr["id"])
                    {
                        case 0:
                            lblHSemanal.Text = ((decimal)dr["precio"]).ToString("C2");
                            break;
                        case 1:
                            lblHMes01.Text = ((decimal)dr["precio"]).ToString("C2");
                            break;
                        case 2:
                            lblHMes02.Text = ((decimal)dr["precio"]).ToString("C2");
                            break;
                        case 3:
                            lblHMes03.Text = ((decimal)dr["precio"]).ToString("C2");
                            break;
                        case 4:
                            lblHMes04.Text = ((decimal)dr["precio"]).ToString("C2");
                            break;
                        case 5:
                            lblHMes05.Text = ((decimal)dr["precio"]).ToString("C2");
                            break;
                        case 6:
                            lblHMes06.Text = ((decimal)dr["precio"]).ToString("C2");
                            break;
                        case 7:
                            lblHMes07.Text = ((decimal)dr["precio"]).ToString("C2");
                            break;
                        case 8:
                            lblHMes08.Text = ((decimal)dr["precio"]).ToString("C2");
                            break;
                        case 9:
                            lblHMes09.Text = ((decimal)dr["precio"]).ToString("C2");
                            break;
                        case 10:
                            lblHMes10.Text = ((decimal)dr["precio"]).ToString("C2");
                            break;
                        case 11:
                            lblHMes11.Text = ((decimal)dr["precio"]).ToString("C2");
                            break;
                        case 12:
                            lblHAnual.Text = ((decimal)dr["precio"]).ToString("C2");
                            break;
                    }
                }
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de obtener los precios. No se pudo conectar con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de obtener los precios. Ocurrió un error genérico.", ex);
            }
        }


        private void PreciosMujeres()
        {
            try
            {
                string sql = "SELECT id, precio FROM precio_membresia WHERE sexo=1";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    switch ((int)dr["id"])
                    {
                        case 0:
                            lblMSemanal.Text = ((decimal)dr["precio"]).ToString("C2");
                            break;
                        case 1:
                            lblMMes01.Text = ((decimal)dr["precio"]).ToString("C2");
                            break;
                        case 2:
                            lblMMes02.Text = ((decimal)dr["precio"]).ToString("C2");
                            break;
                        case 3:
                            lblMMes03.Text = ((decimal)dr["precio"]).ToString("C2");
                            break;
                        case 4:
                            lblMMes04.Text = ((decimal)dr["precio"]).ToString("C2");
                            break;
                        case 5:
                            lblMMes05.Text = ((decimal)dr["precio"]).ToString("C2");
                            break;
                        case 6:
                            lblMMes06.Text = ((decimal)dr["precio"]).ToString("C2");
                            break;
                        case 7:
                            lblMMes07.Text = ((decimal)dr["precio"]).ToString("C2");
                            break;
                        case 8:
                            lblMMes08.Text = ((decimal)dr["precio"]).ToString("C2");
                            break;
                        case 9:
                            lblMMes09.Text = ((decimal)dr["precio"]).ToString("C2");
                            break;
                        case 10:
                            lblMMes10.Text = ((decimal)dr["precio"]).ToString("C2");
                            break;
                        case 11:
                            lblMMes11.Text = ((decimal)dr["precio"]).ToString("C2");
                            break;
                        case 12:
                            lblMAnual.Text = ((decimal)dr["precio"]).ToString("C2");
                            break;
                    }
                }
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de obtener los precios. No se pudo conectar con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de obtener los precios. Ocurrió un error genérico.", ex);
            }
        }

        private void frmConfigurarMembresías_Load(object sender, EventArgs e)
        {
            PreciosHombres();
            PreciosMujeres();
            if (CConfiguracionXML.ExisteConfiguracion("membresia", "folio"))
            {
                chbFolio.Checked = bool.Parse(CConfiguracionXML.LeerConfiguración("membresia", "folio"));
            }
        }

        private void btnPreciosMujeres_Click(object sender, EventArgs e)
        {
            frmPrecioMembresia frm = new frmPrecioMembresia(1);
            frm.Text = "Precio de membresías de mujeres";
            frm.ShowDialog(this);
            PreciosMujeres();
        }

        private void btnPreciosHombres_Click(object sender, EventArgs e)
        {
            frmPrecioMembresia frm = new frmPrecioMembresia(0);
            frm.Text = "Precio de membresías de hombres";
            frm.ShowDialog(this);
            PreciosHombres();
        }

        private void chbFolio_CheckedChanged(object sender, EventArgs e)
        {
            CConfiguracionXML.GuardarConfiguracion("membresia", "folio", chbFolio.Checked.ToString());
        }
    }
}
