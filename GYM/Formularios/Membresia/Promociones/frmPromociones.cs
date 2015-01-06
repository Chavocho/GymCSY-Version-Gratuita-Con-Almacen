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

namespace GYM.Formularios.Membresia
{
    public partial class frmPromociones : Form
    {
        int id = 0;

        #region Instancia
        private static frmPromociones frmInstancia;
        public static frmPromociones Instancia
        {
            get
            {
                if (frmInstancia == null)
                    frmInstancia = new frmPromociones();
                else if (frmInstancia.IsDisposed)
                    frmInstancia = new frmPromociones();
                return frmInstancia;

            }
            set
            {
                frmInstancia = value;
            }
        }
        #endregion

        public frmPromociones()
        {
            InitializeComponent();
            CFuncionesGenerales.CargarInterfaz(this);
            cboTipoPromo.SelectedIndex = 0;
        }

        private void BuscarPromocionesFechas()
        {
            try
            {
                dgvPromociones.Rows.Clear();
                string sql = "SELECT * FROM promocion ORDER BY fecha_inicio ASC";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    string duracion = "", genero = "";
                    DateTime fechaIni = DateTime.Parse(dr["fecha_inicio"].ToString()), fechaFin = DateTime.Parse(dr["fecha_fin"].ToString());
                    decimal precio = (decimal)dr["precio"];
                    switch ((int)dr["duracion"])
                    {
                        case 0:
                            duracion = "Semanal";
                            break;
                        case 1:
                            duracion = "Un mes";
                            break;
                        case 2:
                            duracion = "Dos meses";
                            break;
                        case 3:
                            duracion = "Tres meses";
                            break;
                        case 4:
                            duracion = "Cuatro meses";
                            break;
                        case 5:
                            duracion = "Cinco meses";
                            break;
                        case 6:
                            duracion = "Seis meses";
                            break;
                        case 7:
                            duracion = "Siete meses";
                            break;
                        case 8:
                            duracion = "Ocho meses";
                            break;
                        case 9:
                            duracion = "Nueve meses";
                            break;
                        case 10:
                            duracion = "Diez meses";
                            break;
                        case 11:
                            duracion = "Once meses";
                            break;
                        case 12:
                            duracion = "Doce meses";
                            break;
                    }
                    if (dr["genero"].ToString() == "0")
                        genero = "Hombre";
                    else
                        genero = "Mujer";

                    dgvPromociones.Rows.Add(new object[] { dr["id"], dr["descripcion"], precio.ToString("C2"), duracion, genero, fechaIni.ToString("dd") + " de " + fechaIni.ToString("MMMM") + " del " + fechaIni.ToString("yyyy"), fechaFin.ToString("dd") + " de " + fechaFin.ToString("MMMM") + " del " + fechaFin.ToString("yyyy") });
                }
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido obtener las promociones. No se pudo conectar con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido obtener las promociones. Ha ocurrido un error genérico.", ex);
            }
        }

        private void BuscarPromocionesHorarios()
        {
            try
            {
                dgvPromociones.Rows.Clear();
                string sql = "SELECT * FROM promocion_horario ORDER BY hora_inicio ASC";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    string duracion = "", genero = "";
                    DateTime horaIni = DateTime.Parse(dr["hora_inicio"].ToString()), horaFin = DateTime.Parse(dr["hora_fin"].ToString());
                    decimal precio = (decimal)dr["precio"];
                    switch ((int)dr["duracion"])
                    {
                        case 0:
                            duracion = "Semanal";
                            break;
                        case 1:
                            duracion = "Un mes";
                            break;
                        case 2:
                            duracion = "Dos meses";
                            break;
                        case 3:
                            duracion = "Tres meses";
                            break;
                        case 4:
                            duracion = "Cuatro meses";
                            break;
                        case 5:
                            duracion = "Cinco meses";
                            break;
                        case 6:
                            duracion = "Seis meses";
                            break;
                        case 7:
                            duracion = "Siete meses";
                            break;
                        case 8:
                            duracion = "Ocho meses";
                            break;
                        case 9:
                            duracion = "Nueve meses";
                            break;
                        case 10:
                            duracion = "Diez meses";
                            break;
                        case 11:
                            duracion = "Once meses";
                            break;
                        case 12:
                            duracion = "Doce meses";
                            break;
                    }
                    if (dr["genero"].ToString() == "0")
                        genero = "Hombre";
                    else
                        genero = "Mujer";

                    dgvPromociones.Rows.Add(new object[] { dr["id"], dr["descripcion"], precio.ToString("C2"), duracion, genero, horaIni.ToString("hh:mm tt"), horaFin.ToString("hh:mm tt")});
                }
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido obtener las promociones. No se pudo conectar con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido obtener las promociones. Ha ocurrido un error genérico.", ex);
            }
        }

        private void EliminarPromocionFecha()
        {
            try
            {
                string sql = "DELETE FROM promocion WHERE id='" + id + "'";
                ConexionBD.EjecutarConsulta(sql);
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido eliminar la promoción. No se pudo conectar con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido eliminar la promoción. Ha ocurrido un error genérico.", ex);
            }
        }

        private void EliminarPromocionHorario()
        {
            try
            {
                string sql = "DELETE FROM promocion_horario WHERE id='" + id + "'";
                ConexionBD.EjecutarConsulta(sql);
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido eliminar la promoción. No se pudo conectar con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido eliminar la promoción. Ha ocurrido un error genérico.", ex);
            }
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            if (cboTipoPromo.SelectedIndex == 0)
            {
                (new frmNuevaPromocion()).ShowDialog(this);
                BuscarPromocionesFechas();
            }
            else
            {
                (new frmNuevaPromocionHorario()).ShowDialog(this);
                BuscarPromocionesHorarios();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvPromociones.CurrentRow != null)
            {
                if (cboTipoPromo.SelectedIndex == 0)
                {
                    (new frmEditarPromocion(id)).ShowDialog(this);
                    BuscarPromocionesFechas();
                }
                else
                {
                    (new frmEditarPromocionHorario(id)).ShowDialog(this);
                    BuscarPromocionesHorarios();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPromociones.CurrentRow != null)
            {
                DialogResult r = MessageBox.Show("¿Realmente deseas eliminar ésta promoción?", "GymCSY", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (r == System.Windows.Forms.DialogResult.Yes)
                {
                    if (cboTipoPromo.SelectedIndex == 0)
                    {
                        EliminarPromocionFecha();
                    }
                    else
                    {
                        EliminarPromocionHorario();
                    }
                    MessageBox.Show("Se ha eliminado correctamente la promoción.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvPromociones.Rows.RemoveAt(dgvPromociones.CurrentRow.Index);
                }
            }
        }

        private void cboTipoPromo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //5 y 6 las columnas
            switch (cboTipoPromo.SelectedIndex)
            {
                case 0 :
                    dgvPromociones.Columns[5].HeaderText = "Fecha de inicio";
                    dgvPromociones.Columns[6].HeaderText = "Fecha de terminación";
                    BuscarPromocionesFechas();
                    break;
                case 1:
                    dgvPromociones.Columns[5].HeaderText = "Hora de inicio";
                    dgvPromociones.Columns[6].HeaderText = "Hora de terminación";
                    BuscarPromocionesHorarios();
                    break;
            }
        }

        private void dgvPromociones_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = (int)dgvPromociones[0, e.RowIndex].Value;
            }
            catch
            {
            }
        }
    }
}
