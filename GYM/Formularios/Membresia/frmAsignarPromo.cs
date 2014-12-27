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
    public partial class frmAsignarPromo : Form
    {
        frmNuevaMembresia frmN = null;
        frmEditarMembresia frmE = null;
        int genero;

        decimal precio;
        List<int> duraciones = new List<int>();

        public frmAsignarPromo(frmNuevaMembresia frm, int genero)
        {
            InitializeComponent();
            this.genero = genero;
            this.frmN = frm;
            CFuncionesGenerales.CargarInterfaz(this);
        }

        public frmAsignarPromo(frmEditarMembresia frm, int genero)
        {
            InitializeComponent();
            this.genero = genero;
            this.frmE = frm;
            CFuncionesGenerales.CargarInterfaz(this);
        }

        private void BuscarPromociones()
        {
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT id, descripcion, precio, duracion FROM promocion WHERE (fecha_inicio<=?fecha AND fecha_fin>=?fecha) AND genero=?genero";
                sql.Parameters.AddWithValue("?fecha", DateTime.Now.ToString("yyyy/MM/dd"));
                sql.Parameters.AddWithValue("?genero", genero);
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    string duracion = "";
                    decimal precio = (decimal)dr["precio"];
                    duraciones.Add((int)dr["duracion"]);
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
                    dgvPromociones.Rows.Add(new object[] { dr["id"], dr["descripcion"].ToString(), precio.ToString("C2"), duracion });
                }
                dgvPromociones_CellClick(dgvPromociones, new DataGridViewCellEventArgs(0, 0));
            }
            catch (MySqlException ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido buscar las promociones. No se pudo conectar con la base de datos.", ex);
            }
            catch (Exception ex)
            {
                CFuncionesGenerales.MensajeError("No se ha podido buscar las promociones. Ocurrió un error genérico.", ex);
            }
        }

        private void dgvPromociones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                precio = decimal.Parse(dgvPromociones[2, e.RowIndex].Value.ToString(), System.Globalization.NumberStyles.Currency);
            }
            catch
            {
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvPromociones.CurrentRow != null)
            {
                if (frmN != null)
                    frmN.AsignarPromocion(duraciones[dgvPromociones.CurrentRow.Index], precio, dgvPromociones[1, dgvPromociones.CurrentRow.Index].Value.ToString());
                else if (frmE != null)
                    frmE.AsignarPromocion(duraciones[dgvPromociones.CurrentRow.Index], precio, dgvPromociones[1, dgvPromociones.CurrentRow.Index].Value.ToString());
                MessageBox.Show("Se ha asignado la promoción correctamente.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                this.Close();
        }

        private void frmAsignarPromo_Load(object sender, EventArgs e)
        {
            BuscarPromociones();
        }
    }
}
