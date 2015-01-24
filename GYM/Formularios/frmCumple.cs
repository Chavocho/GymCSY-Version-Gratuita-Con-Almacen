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
    public partial class frmCumple : Form
    {
        const int salto = 19;
        bool huboEnter = false;
        DataTable dt;

        public frmCumple(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void AgregarCumpleañeros()
        {
            int pos = lblTitulo.Bottom + 10;
            PictureBox pcb;
            Label lblNom;
            Label lblNumSocio;
            Label lblAños;
            Clases.CCorreos c;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                try
                {
                    huboEnter = false;
                    DataRow dr = dt.Rows[i];
                    string numSocio = dr["numSocio"].ToString();
                    string nombre = dr["nombre"].ToString();
                    string apellidos = dr["apellidos"].ToString();
                    DateTime fechaNac = DateTime.Parse(dr["fecha_nac"].ToString());
                    pcb = new PictureBox();
                    lblNom = new Label();
                    lblNumSocio = new Label();
                    lblAños = new Label();

                    //Empezamos por el PictureBox
                    pcb.Name = "pcbImagen" + dr["numSocio"].ToString();
                    pcb.Location = new Point(10, pos);
                    Image img = CMiembro.ObtenerImagenSocio(int.Parse(numSocio));
                    if (img != null)
                        pcb.Image = img;
                    else
                        pcb.Image = GYM.Properties.Resources.Cumpleaños;
                    pcb.Size = new Size(75, 75);
                    pcb.SizeMode = PictureBoxSizeMode.StretchImage;
                    pcb.BackColor = Color.WhiteSmoke;

                    //Seguimos con el Label del nombre
                    lblNom.Name = "lblNombre" + dr["numSocio"].ToString();
                    lblNom.Location = new Point(pcb.Width + pcb.Left, pos);
                    AcomodarNombreLabel(ref lblNom, ref pos, nombre, apellidos);
                    lblNom.AutoSize = true;
                    lblNom.Font = new Font("Segoe UI", 10);
                    lblNom.ForeColor = SystemColors.ButtonHighlight;
                    //lblNom.BackColor = Color.WhiteSmoke;

                    pos += salto;
                    //Seguimos con el Label de número de socio
                    lblNumSocio.Name = "lblNumSocio" + dr["numSocio"].ToString();
                    lblNumSocio.Location = new Point(pcb.Width + pcb.Left, pos);
                    lblNumSocio.Text = "Número de socio: " + numSocio;
                    lblNumSocio.AutoSize = true;
                    lblNumSocio.Font = new Font("Segoe UI", 10);
                    lblNumSocio.ForeColor = SystemColors.ButtonHighlight;
                    //lblNumSocio.BackColor = Color.WhiteSmoke;

                    pos += salto;
                    //Seguimos con el Label de edad
                    lblAños.Name = "lblEdad" + dr["numSocio"].ToString();
                    lblAños.Location = new Point(pcb.Width + pcb.Left, pos);
                    lblAños.Text = "¡Cumple " + (DateTime.Now.Year - fechaNac.Year).ToString() + " años!";
                    lblAños.AutoSize = true;
                    lblAños.Font = new Font("Segoe UI", 10);
                    lblAños.ForeColor = SystemColors.ButtonHighlight;
                    //lblAños.BackColor = Color.WhiteSmoke;

                    //Agregamos los controles al formulario
                    this.Controls.Add(pcb);
                    this.Controls.Add(lblNom);
                    this.Controls.Add(lblNumSocio);
                    this.Controls.Add(lblAños);

                    if (huboEnter == false)
                        pos += (salto * 2) + 9;
                    else
                        pos += salto + 9;

                    if (Clases.CFuncionesGenerales.EsCorreoValido(dr["email"].ToString()))
                    {
                        c = new Clases.CCorreos();
                        c.CorreosDestino = dr["email"].ToString();
                        c.Asunto = "¡Feliz cumpleaños " + dr["nombre"].ToString() + " " + dr["apellidos"] + "!";
                        c.Adjuntos = new string[] { Application.StartupPath + "\\Img\\imagencorreo.jpeg" };
                        c.EnviarCorreo();
                    }
                    Application.DoEvents();
                }
                catch (MySqlException ex)
                {
                    throw ex;
                }
                catch (System.IO.IOException ex)
                {
                    throw ex;
                }
                catch (ObjectDisposedException ex)
                {
                    throw ex;
                }
                catch (NotSupportedException ex)
                {
                    throw ex;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    throw ex;
                }
                catch (ArgumentNullException ex)
                {
                    throw ex;
                }
                catch (ArgumentException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void AcomodarNombreLabel(ref Label lbl, ref int pos, string nombre, string apellidos)
        {
            string nomCompleto = "";
            string[] nom = nombre.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] ape = apellidos.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < nom.Length; i++)
            {
                if (TextRenderer.MeasureText(nomCompleto + nom[i] + " ", new Font("Segoe UI", 10)).Width < 175)
                    nomCompleto += nom[i] + " ";
                else
                {
                    huboEnter = true;
                    pos += salto;
                    nomCompleto += Environment.NewLine + nom[i];
                    lbl.Text += nomCompleto;
                    nomCompleto = "";
                }
            }

            for (int i = 0; i < ape.Length; i++)
            {
                if (TextRenderer.MeasureText(nomCompleto + ape[i] + " ", new Font("Segoe UI", 10)).Width < 175)
                    nomCompleto += ape[i] + " ";
                else
                {
                    huboEnter = true;
                    pos += salto;
                    nomCompleto += Environment.NewLine + ape[i];
                    lbl.Text += nomCompleto;
                    nomCompleto = "";
                }
            }
            lbl.Text += nomCompleto;
        }

        private void frmCumple_Shown(object sender, EventArgs e)
        {
            int x = 0;
            while (x < 270)
            {
                this.Left -= 5;
                Application.DoEvents();
                x += 5;
            }
        }

        private void frmCumple_Load(object sender, EventArgs e)
        {
            this.Size = new Size(270, Screen.PrimaryScreen.Bounds.Height);
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width, 0);
        }

        private void frmCumple_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                int x = 0;
                while (x < 270)
                {
                    this.Left += 5;
                    Application.DoEvents();
                    x += 5;
                }
            }
            catch
            {
            }
        }
    }
}
