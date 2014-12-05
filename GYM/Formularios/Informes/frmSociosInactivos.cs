using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYM.Informes
{
    public partial class frmSociosInactivos : Form
    {
        int numSocio = 0;

        #region Instancia
        private static frmSociosInactivos frmInstancia;
        public static frmSociosInactivos Instancia
        {
            get
            {
                if (frmInstancia == null)
                    frmInstancia = new frmSociosInactivos();
                else if (frmInstancia.IsDisposed)
                    frmInstancia = new frmSociosInactivos();
                return frmInstancia;
            }
            set
            {
                frmInstancia = value;
            }
        }
        #endregion



        #region Metodos

        public frmSociosInactivos()
        {
            InitializeComponent();
        }

        private void BuscarMiembros()
        {
            Image img = null;
            dgvMembresiasInactivas.Rows.Clear();
            try
            {
                string sql = "SELECT socio.numSocio, socio.nombre, socio.apellidos, socio.telefono,socio.celular,socio.fecha_creacion,socio.email, mem.fecha_fin, mem.fecha_ini from  miembros as socio  INNER JOIN  membresias as mem ON socio.numSocio=mem.numSocio AND mem.status=0 ORDER BY socio.numSocio ASC";
                DataTable dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    string tel = null, cel = null, fecha = null, fechaIni = null, fechaReg=null; 
                    if (dr["telefono"] != DBNull.Value)
                        tel = dr["telefono"].ToString();
                    if (dr["celular"] != DBNull.Value)
                        cel = dr["celular"].ToString();
                    if (dr["telefono"].ToString().Equals("0"))
                        tel = "No especificado";
                    if (dr["celular"].ToString().Equals("0"))
                        cel = "No especificado";
                    if (dr["fecha_fin"] != DBNull.Value)
                        fecha = DateTime.Parse(dr["fecha_fin"].ToString()).ToString("dd") + " de " + DateTime.Parse(dr["fecha_fin"].ToString()).ToString("MMMM") + " de " + DateTime.Parse(dr["fecha_fin"].ToString()).ToString("yyyy");
                    if (dr["fecha_ini"] != DBNull.Value)
                        fechaIni = DateTime.Parse(dr["fecha_ini"].ToString()).ToString("dd") + " de " + DateTime.Parse(dr["fecha_ini"].ToString()).ToString("MMMM") + " de " + DateTime.Parse(dr["fecha_ini"].ToString()).ToString("yyyy");
                    if (dr["fecha_creacion"] != DBNull.Value)
                        fechaReg = DateTime.Parse(dr["fecha_creacion"].ToString()).ToString("dd") + " de " + DateTime.Parse(dr["fecha_creacion"].ToString()).ToString("MMMM") + " de " + DateTime.Parse(dr["fecha_creacion"].ToString()).ToString("yyyy");
                    else
                        fechaReg = "No especificada";

                    dgvMembresiasInactivas.Rows.Add(new object[] { dr["numSocio"].ToString(), dr["nombre"].ToString() + " " + dr["apellidos"].ToString(), tel,cel,dr["email"].ToString(),fecha,fechaIni,fechaReg });
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void frmSociosInactivos_Load(object sender, EventArgs e)
        {
            Application.DoEvents();
            try
            {
                Clases.CFuncionesGenerales.CargarInterfaz(this);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
            BuscarMiembros();
        }

        private void btnInformacion_Click(object sender, EventArgs e)
        {
            // Mostrar información de todas las membresías adquiridas por el socio seleccionado

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void dgvMembresiasInactivas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                numSocio = int.Parse(dgvMembresiasInactivas[1, e.RowIndex].Value.ToString());
            }
            catch
            {
            }
        }


        #endregion





    }
}
