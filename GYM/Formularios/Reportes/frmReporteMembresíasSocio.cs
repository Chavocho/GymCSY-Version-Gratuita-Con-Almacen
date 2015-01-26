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
    public partial class frmReporteMembresíasSocio : Form
    {
        DataTable dt;
        string nomSocio;
        int idM, numSocio;

        #region Instancia
        private static frmReporteMembresíasSocio frmInstancia;
        public static frmReporteMembresíasSocio Instancia
        {
            get
            {
                if (frmInstancia == null)
                    frmInstancia = new frmReporteMembresíasSocio();
                else if (frmInstancia.IsDisposed)
                    frmInstancia = new frmReporteMembresíasSocio();
                return frmInstancia;

            }
            set
            {
                frmInstancia = value;
            }
        }
        #endregion

        public frmReporteMembresíasSocio()
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
        }

        private void BuscarMembresias(string p)
        {
            MensajeError m = new MensajeError(CFuncionesGenerales.MensajeError);
            try
            {
                string sql = "SELECT s.numSocio, s.nombre, s.apellidos, m.id, m.estado, m.fecha_ini, m.fecha_fin " + 
                    "FROM miembros AS s INNER JOIN membresias AS m ON (s.numSocio=m.numSocio) WHERE s.numSocio='" + p + "' OR s.nombre LIKE '%" + p + "%' OR s.apellidos LIKE '%" + p + "%' ORDER BY s.numSocio";
                dt = ConexionBD.EjecutarConsultaSelect(sql);
            }
            catch (MySqlException ex)
            {
                this.Invoke(m, new object[] { "Ha ocurrido un error al obtener los datos de las membresías. No se pudo conectar con la base de datos.", ex });
            }
            catch (Exception ex)
            {
                this.Invoke(m, new object[] { "Ha ocurrido un error al obtener los datos de las membresías. Ha ocurrido un error genérico.", ex });
            }
        }

        private void LlenarDataGrid()
        {
            dgvPersonas.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    CMembresia.EstadoMembresia es = (CMembresia.EstadoMembresia)Enum.Parse(typeof(CMembresia.EstadoMembresia), dr["estado"].ToString());
                    DateTime fechaIni = DateTime.Parse(dr["fecha_ini"].ToString()), fechaFin = DateTime.Parse(dr["fecha_fin"].ToString());
                    dgvPersonas.Rows.Add(new object[] { dr["id"], dr["numSocio"], dr["nombre"].ToString() + " " + dr["apellidos"], es.ToString(), fechaIni.ToString("dd/MM/yyyy"), fechaFin.ToString("dd/MM/yyyy") });
                    Application.DoEvents();
                }
                catch (FormatException ex)
                {
                    CFuncionesGenerales.MensajeError("No se pudo mostrar el dato de un socio. No se pudo dar formato a una variable.", ex);
                }
                catch (ArgumentNullException ex)
                {
                    CFuncionesGenerales.MensajeError("No se pudo mostrar el dato de un socio. El argumento dado al método es nulo.", ex); 
                }
                catch (Exception ex)
                {
                    CFuncionesGenerales.MensajeError("No se pudo mostrar el dato de un socio. Ocurrió un error genérico.", ex);
                }
            }
        }

        private void bgwBusqueda_DoWork(object sender, DoWorkEventArgs e)
        {
            BuscarMembresias(e.Argument.ToString());
        }

        private void bgwBusqueda_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tmrConteo.Enabled = false;
            CFuncionesGenerales.frmEsperaClose();
            LlenarDataGrid();
            txtBusqueda.Enabled = true;
            CFuncionesGenerales.HabilitarBotonCerrar(this);
        }

        private void tmrConteo_Tick(object sender, EventArgs e)
        {
            tmrConteo.Enabled = false;
            CFuncionesGenerales.frmEspera("Espere, búscando socios...", this);
        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBusqueda.Enabled = false;
                CFuncionesGenerales.DeshabilitarBotonCerrar(this);
                tmrConteo.Enabled = true;
                bgwBusqueda.RunWorkerAsync(txtBusqueda.Text);
            }
        }

        private void btnMembresias_Click(object sender, EventArgs e)
        {
            if (dgvPersonas.CurrentRow != null)
            {
                string sql = "SELECT * FROM registro_membresias WHERE membresia_id='" + idM + "' ORDER BY create_time";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(nomSocio + " no cuenta con registros de membresías", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                (new frmVisualizarMembresias(idM, numSocio, nomSocio)).ShowDialog(this);
            }
            else
                MessageBox.Show("Debes seleccionar antes a un socio para visualizar ésta información.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvPersonas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                nomSocio = dgvPersonas[2, e.RowIndex].Value.ToString();
                numSocio = (int)dgvPersonas[1, e.RowIndex].Value;
                idM = (int)dgvPersonas[0, e.RowIndex].Value;
            }
            catch
            {
            }
        }
    }
}
