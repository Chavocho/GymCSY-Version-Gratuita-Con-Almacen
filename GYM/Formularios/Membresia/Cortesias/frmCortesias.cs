using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GYM.Formularios.Membresia
{
    public partial class frmCortesias : Form
    {
        #region Instancia
        private static frmCortesias frmInstancia;
        public static frmCortesias Instancia
        {
            get
            {
                if (frmInstancia == null)
                    frmInstancia = new frmCortesias();
                else if (frmInstancia.IsDisposed)
                    frmInstancia = new frmCortesias();
                return frmInstancia;
            }
            set
            {
                frmInstancia = value;
            }
        }
        #endregion

        int numSocio, sexo;

        public frmCortesias()
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
        }

        private void BuscarCortesias(string p)
        {
            try
            {
                dgvPersonas.Rows.Clear();
                string sql = "SELECT mi.numSocio, mi.nombre, mi.apellidos, mi.telefono, mi.celular, mi.genero, c.fecha_fin AS fecha FROM miembros AS mi INNER JOIN cortesias AS c ON (mi.numSocio=c.numSocio) WHERE mi.numSocio='" + p + "' OR mi.nombre LIKE '%" + p + "%' OR mi.apellidos LIKE '%" + p + "%'";
                DataTable dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    string tel = "";
                    DateTime fecha = (DateTime)dr["fecha"];
                    if (dr["telefono"].ToString() != "" && dr["celular"].ToString() == "")
                        tel = dr["telefono"].ToString();
                    else if (dr["celular"].ToString() != "" && dr["telefono"].ToString() == "")
                        tel = dr["celular"].ToString();
                    else
                        tel = dr["telefono"].ToString() + ", " + dr["celular"].ToString();
                    dgvPersonas.Rows.Add(new object[] { dr["numSocio"], dr["nombre"].ToString() + " " + dr["apellidos"].ToString(), tel, fecha.ToString("dd") + " de " + fecha.ToString("MMMM") + " del " + fecha.ToString("yyyy"), dr["genero"] });
                }
            }
            catch (MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de obtener las cortesías.", ex);
            }
            catch (InvalidOperationException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se ha podido agregar las cortesías a la tabla.", ex);
            }
            catch (InvalidCastException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("La fecha de la cortesía no se pudo convertir.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarCortesias(txtBusqueda.Text);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            (new frmNuevaCortesia()).ShowDialog(this);
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (numSocio > 0)
            {
                DialogResult r = MessageBox.Show("¿Realmente deseas crear la membresía de este miembro de cortesía?", "GymCSY", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (r == System.Windows.Forms.DialogResult.Yes)
                {
                    (new frmNuevaMembresia(numSocio, sexo)).ShowDialog(this);
                }
            }
        }

        private void dgvPersonas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                numSocio = (int)dgvPersonas[0, e.RowIndex].Value;
                sexo = (int)dgvPersonas[4, e.RowIndex].Value;
            }
            catch
            {
            }
        }
    }
}
