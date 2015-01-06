using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYM.Formularios.Socio
{
    public partial class frmMiembros : Form
    {
        int numSocio = 0;

        #region Instancia
        private static frmMiembros frmInstancia;
        public static frmMiembros Instancia
        {
            get
            {
                if (frmInstancia == null)
                    frmInstancia = new frmMiembros();
                else if (frmInstancia.IsDisposed)
                    frmInstancia = new frmMiembros();
                return frmInstancia;
            }
            set
            {
                frmInstancia = value;
            }
        }
        #endregion

        #region Metodos

        public frmMiembros()
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
        }

        private void BuscarMiembros(string busqueda)
        {
            dgvPersonas.Rows.Clear();
            try
            {
                string sql = "SELECT numSocio, nombre, apellidos, telefono, celular, fecha_nac FROM miembros WHERE numSocio='" + busqueda + "' OR nombre LIKE '%" + busqueda + "%' OR apellidos LIKE '%" + busqueda + "%'";
                DataTable dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    string tel=null, cel=null, fecha=null;
                    if (dr["telefono"] != DBNull.Value)
                        tel = dr["telefono"].ToString();
                    if (dr["celular"] != DBNull.Value)
                        cel = dr["celular"].ToString();
                    if (dr["telefono"].ToString().Equals("0"))
                        tel = "No especificado";
                    if (dr["celular"].ToString().Equals("0"))
                        cel = "No especificado";
                    if (dr["fecha_nac"] != DBNull.Value)
                        fecha = fecha = DateTime.Parse(dr["fecha_nac"].ToString()).ToString("dd") + " de " + DateTime.Parse(dr["fecha_nac"].ToString()).ToString("MMMM");
                    dgvPersonas.Rows.Add(new object[] { dr["numSocio"].ToString(), dr["nombre"].ToString() + " " + dr["apellidos"].ToString(), tel,cel,fecha });
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region Eventos
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            (new frmAgregarMiembro()).ShowDialog(this);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (numSocio != 0)
                (new frmEditarMiembro(numSocio)).ShowDialog(this);
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                BuscarMiembros(txtBusqueda.Text);
        }
        #endregion


        private void frmMiembros_Load(object sender, EventArgs e)
        {

            Clases.CFuncionesGenerales.CargarInterfaz(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dgvPersonas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                numSocio = int.Parse(dgvPersonas[0, e.RowIndex].Value.ToString());
            }
            catch
            {
            }
        }
    }
}
