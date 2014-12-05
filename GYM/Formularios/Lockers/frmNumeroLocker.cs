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

namespace GYM.Formularios
{
    public partial class frmNumeroLocker : Form
    {
        frmLockers frm;

        public frmNumeroLocker(frmLockers frm, int numLocker = 0)
        {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.frm = frm;
            if (numLocker > 0)
                txtNumLocker.Text = numLocker.ToString();
        }

        private void txtNumLocker_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.CFuncionesGenerales.VerificarEsNumero(ref sender, ref e, true);
        }

        private bool ExisteLocker(string numLocker)
        {
            bool existe = false;
            try
            {
                MySqlCommand sql = new MySqlCommand();
                sql.CommandText = "SELECT id FROM locker WHERE num=?num LIMIT 1";
                sql.Parameters.AddWithValue("?num", numLocker);
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                    existe = true;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return existe;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Es correcta la información?", "GymCSY", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtNumLocker.Text != "")
                {
                    if (!ExisteLocker(txtNumLocker.Text))
                    {
                        frm.NumeroLocker = int.Parse(txtNumLocker.Text);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("El número de locker ingresado ya existe. Ingresa otro.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Debes ingresar el número de locker.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
