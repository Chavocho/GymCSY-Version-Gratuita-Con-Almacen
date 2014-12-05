using GYM.Clases;
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
    public partial class frmNuevaCortesia : Form
    {
        private int numSocio = 0;

        public int NumeroSocio
        {
            get { return numSocio; }
            set { numSocio = value; }
        }

        public string NombreSocio
        {
            set { lblMiembro.Text = "Socio: " + value; }
        }
        
        
        public frmNuevaCortesia()
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
            cbxTipo.SelectedIndex = 0;
        }

        private void CrearCortesia()
        {
            MySql.Data.MySqlClient.MySqlCommand sql = new MySql.Data.MySqlClient.MySqlCommand();
            sql.CommandText = "INSERT INTO cortesias (numSocio, fecha_ini, fecha_fin, comentario, create_time, create_user_id) " +
                "VALUES (?numSocio, ?fecha_ini, ?fecha_fin, ?comentario, NOW(), ?create_user_id)";
            sql.Parameters.AddWithValue("?numSocio", this.NumeroSocio);
            sql.Parameters.AddWithValue("?fecha_ini", dtpFechaInicio.Value);
            sql.Parameters.AddWithValue("?fecha_fin", dtpFechaInicio.Value.AddDays(cbxTipo.SelectedIndex + 1));
            sql.Parameters.AddWithValue("?comentario", txtComentarios.Text);
            sql.Parameters.AddWithValue("?create_user_id", frmMain.id);
            ConexionBD.EjecutarConsultaSelect(sql);
        }

        private void cbxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxTipo.SelectedIndex)
            {
                case 0:
                    lblFechaFin.Text = dtpFechaInicio.Value.AddDays(1).ToString("dd") + " de " + dtpFechaInicio.Value.AddDays(1).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddDays(1).ToString("yyyy");
                    break;
                case 1:
                    lblFechaFin.Text = dtpFechaInicio.Value.AddDays(2).ToString("dd") + " de " + dtpFechaInicio.Value.AddDays(2).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddDays(2).ToString("yyyy");
                    break;
                case 2:
                    lblFechaFin.Text = dtpFechaInicio.Value.AddDays(3).ToString("dd") + " de " + dtpFechaInicio.Value.AddDays(3).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddDays(3).ToString("yyyy");
                    break;
                case 3:
                    lblFechaFin.Text = dtpFechaInicio.Value.AddDays(4).ToString("dd") + " de " + dtpFechaInicio.Value.AddDays(4).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddDays(4).ToString("yyyy");
                    break;
                case 4:
                    lblFechaFin.Text = dtpFechaInicio.Value.AddDays(5).ToString("dd") + " de " + dtpFechaInicio.Value.AddDays(5).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddDays(5).ToString("yyyy");
                    break;
                case 5:
                    lblFechaFin.Text = dtpFechaInicio.Value.AddDays(6).ToString("dd") + " de " + dtpFechaInicio.Value.AddDays(6).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddDays(6).ToString("yyyy");
                    break;
                case 6:
                    lblFechaFin.Text = dtpFechaInicio.Value.AddDays(7).ToString("dd") + " de " + dtpFechaInicio.Value.AddDays(7).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddDays(7).ToString("yyyy");
                    break;
            }
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            switch (cbxTipo.SelectedIndex)
            {
                case 0:
                    lblFechaFin.Text = dtpFechaInicio.Value.AddDays(1).ToString("dd") + " de " + dtpFechaInicio.Value.AddDays(1).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddDays(1).ToString("yyyy");
                    break;
                case 1:
                    lblFechaFin.Text = dtpFechaInicio.Value.AddDays(2).ToString("dd") + " de " + dtpFechaInicio.Value.AddDays(2).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddDays(2).ToString("yyyy");
                    break;
                case 2:
                    lblFechaFin.Text = dtpFechaInicio.Value.AddDays(3).ToString("dd") + " de " + dtpFechaInicio.Value.AddDays(3).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddDays(3).ToString("yyyy");
                    break;
                case 3:
                    lblFechaFin.Text = dtpFechaInicio.Value.AddDays(4).ToString("dd") + " de " + dtpFechaInicio.Value.AddDays(4).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddDays(4).ToString("yyyy");
                    break;
                case 4:
                    lblFechaFin.Text = dtpFechaInicio.Value.AddDays(5).ToString("dd") + " de " + dtpFechaInicio.Value.AddDays(5).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddDays(5).ToString("yyyy");
                    break;
                case 5:
                    lblFechaFin.Text = dtpFechaInicio.Value.AddDays(6).ToString("dd") + " de " + dtpFechaInicio.Value.AddDays(6).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddDays(6).ToString("yyyy");
                    break;
                case 6:
                    lblFechaFin.Text = dtpFechaInicio.Value.AddDays(7).ToString("dd") + " de " + dtpFechaInicio.Value.AddDays(7).ToString("MMMM") + " del " + dtpFechaInicio.Value.AddDays(7).ToString("yyyy");
                    break;
            }
        }

        private void btnMiembro_Click(object sender, EventArgs e)
        {
            (new frmMiembroCortesia(this)).ShowDialog(this);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (NumeroSocio > 0)
            {
                if (dtpFechaInicio.Value.Date >= DateTime.Now.Date)
                {
                    CrearCortesia();
                    MessageBox.Show("Se ha asignado correctamente la cortesía","GymCSY", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("La fecha de inicio de la cortesía no puede ser menor a la fecha actual.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Debes elegir un socio al cual asignarle la cortesía.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
