using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYM.Formularios.Membresia
{
    public partial class frmMiembroCortesia : Form
    {
        int numSocio;
        string nomSocio = "";

        frmEspere frmE = new frmEspere();
        DataTable dt = new DataTable();
        frmNuevaCortesia frm;

        public frmMiembroCortesia(frmNuevaCortesia frm)
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
            this.frm = frm;
        }

        private void BuscarMiembro(string p)
        {
            try
            {
                string sql = "SELECT mi.numSocio, mi.nombre, mi.apellidos, mi.telefono, mi.celular, c.id AS idc, m.id AS idm FROM miembros AS mi LEFT JOIN cortesias AS c ON (mi.numSocio = c.numSocio) LEFT JOIN membresias AS m ON (m.numSocio=mi.numSocio) WHERE mi.numSocio = '" + p + "' OR mi.nombre LIKE '%" + p + "%' OR mi.apellidos LIKE '%" + p + "%' ORDER BY mi.numSocio";
                dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de buscar los miembros.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void LlenarDataTable()
        {
            try
            {
                dgvPersonas.Rows.Clear();
                string tel = "";
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["idc"] == DBNull.Value && dr["idm"] == DBNull.Value)
                    {
                        tel = "";
                        if (dr["telefono"].ToString() != "")
                            tel = dr["telefono"].ToString();
                        else if (dr["celular"].ToString() != "")
                            tel = dr["celular"].ToString();
                        dgvPersonas.Rows.Add(new object[] { (int)dr["numSocio"], dr["nombre"].ToString() + " " + dr["apellidos"].ToString(), tel });
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("La operación no pudo ser completada. El estado actual del objeto no lo permite.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El método invocado no admite argumentos nulos.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !bgwConsulta.IsBusy)
            {
                tmrEspera.Enabled = true;
                bgwConsulta.RunWorkerAsync(txtBusqueda.Text);
            }
        }

        private void bgwConsulta_DoWork(object sender, DoWorkEventArgs e)
        {
            BuscarMiembro((string)e.Argument);
        }

        private void bgwConsulta_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tmrEspera.Enabled = false;
            Clases.CFuncionesGenerales.frmEsperaClose();
            LlenarDataTable();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            frm.NumeroSocio = numSocio;
            frm.NombreSocio = nomSocio;
            this.Close();
        }

        private void tmrEspera_Tick(object sender, EventArgs e)
        {
            tmrEspera.Enabled = false;
            Clases.CFuncionesGenerales.frmEspera("Espere, búscando los miembros sin membresías.", this);
        }

        private void dgvPersonas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                numSocio = (int)dgvPersonas[0, e.RowIndex].Value;
                nomSocio = (string)dgvPersonas[1, e.RowIndex].Value;
            }
            catch
            {
                numSocio = 0;
            }
        }
    }
}
