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

namespace GYM.Formularios.Caja
{
    public partial class frmCortes : Form
    {
        int idA = 0, idC = 0;
        DataTable dt = new DataTable();

        public frmCortes()
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
        }

        private void BuscarCortes(DateTime fechaIni, DateTime fechaFin)
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT id, efectivo, tarjeta, fecha FROM caja WHERE (descripcion='CIERRE DE CAJA') AND (fecha BETWEEN ?fechaIni AND ?fechaFin)";
                sql.Parameters.AddWithValue("?fechaIni", fechaIni.ToString("yyyy/MM/dd") + " 00:00:00");
                sql.Parameters.AddWithValue("?fechaFin", fechaFin.ToString("yyyy/MM/dd") + " 23:59:59");
                dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
            }
            catch (MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de obtener la información de los cierres de caja.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void LlenarDataGrid()
        {
            try
            {
                dgvCaja.Rows.Clear();
                DateTime fechas;
                foreach (DataRow dr in dt.Rows)
                {
                    fechas = DateTime.Parse(dr["fecha"].ToString());
                    dgvCaja.Rows.Add(new object[] { dr["id"], fechas.ToString("dd") + " de " + fechas.ToString("MMMM") + " del " + fechas.ToString("yyyy"), (decimal.Parse(dr["efectivo"].ToString()) * -1).ToString("C2"), (decimal.Parse(dr["tarjeta"].ToString()) * -1).ToString("C2") });
                }
                if (dgvCaja.RowCount > 0)
                    dgvCaja_CellClick(dgvCaja, new DataGridViewCellEventArgs(0, 0));
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de convertir una variable. El formato de entrada no es correcto.", ex);
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un desbordamiento.", ex);
            }
            catch (InvalidOperationException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("La operación no pudo ser completada. El estado actual del DataGridView no lo permite.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El argumento dado en la llamada al método es nulo, y el método no admite este tipo de valores.", ex);
            }
        }

        private void Imprimir()
        {
            DialogResult r = MessageBox.Show("¿Realmente deseas imprimir éste corte?", "GymCSY", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (r == System.Windows.Forms.DialogResult.Yes)
            {
                Clases.CTicket t = new Clases.CTicket();
                t.ImprimirCorteCaja(idA, idC);
            }
        }

        private void dgvCaja_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idC = (int)dgvCaja[0, e.RowIndex].Value;
                string sql = "SELECT MAX(id) AS idA FROM caja WHERE descripcion = 'APERTURA DE CAJA' AND id<" + idC;
                DataTable dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    idA = (int)dr["idA"];
                }
            }
            catch
            {
            }
        }

        private void dtpFechas_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bgwCortes_DoWork(object sender, DoWorkEventArgs e)
        {
            Array a = (Array)e.Argument;
            BuscarCortes((DateTime)a.GetValue(0), (DateTime)a.GetValue(1));
        }

        private void bgwCortes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tmrEspera.Enabled = false;
            Clases.CFuncionesGenerales.frmEsperaClose();
            LlenarDataGrid();

        }

        private void tmrEspera_Tick(object sender, EventArgs e)
        {
            tmrEspera.Enabled = false;
            Clases.CFuncionesGenerales.frmEspera("Espere, búscando los cortes", this);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dgvCaja.RowCount>0)
            Imprimir();
            else
                MessageBox.Show("Debes de seleccionar un corte de caja, para poder imprimirlo","GymCSY",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dtpFechaInicio.Value > dtpFechaFin.Value)
                dtpFechaInicio.Value = dtpFechaFin.Value.AddDays(-1);
            if (dtpFechaFin.Value < dtpFechaInicio.Value)
                dtpFechaFin.Value = dtpFechaInicio.Value.AddDays(1);
            bgwCortes.RunWorkerAsync(new object[] { dtpFechaInicio.Value, dtpFechaFin.Value });
            tmrEspera.Enabled = true;
        }
    }
}
