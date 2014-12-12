using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GYM.Clases;

namespace GYM.Formularios
{
    public partial class frmConfiguracionGeneral : Form
    {
        #region Instancia
        private static frmConfiguracionGeneral frmInstancia;
        public static frmConfiguracionGeneral Instancia
        {
            get
            {
                if (frmInstancia == null)
                    frmInstancia = new frmConfiguracionGeneral();
                else if (frmInstancia.IsDisposed)
                    frmInstancia = new frmConfiguracionGeneral();
                return frmInstancia;
            }
            set
            {
                frmInstancia = value;
            }
        }
        #endregion
        bool solo;

        public frmMain Frm
        {
            get { return frm; }
            set { frm = value; }
        }
        
        #region Variables
        frmMain frm;
        frmEspere e;
        string tema;
        string temaCumple;
        Color fondo;
        Color letras;
        Color fondoCumple;
        Color letrasCumple;
        Bitmap img;
        Bitmap promo01;
        Bitmap promo02;
        Bitmap promo03;
        Bitmap promo04;
        Bitmap promo05;
        Bitmap promo06;
        ColorDialog cldColor;
        OpenFileDialog ofdImagen;

        string tmpLetras;
        string tmpFondo;
        string tmpLetrasCumple;
        string tmpFondoCumple;
        #endregion

        public frmConfiguracionGeneral()
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
        }

        #region Metodos
        private void CargarConfiguracion()
        {
            tema = CFuncionesGenerales.tema;
            temaCumple = CFuncionesGenerales.temaCumple;
            fondo = CFuncionesGenerales.fondo;
            letras = CFuncionesGenerales.letras;
            fondoCumple = CFuncionesGenerales.fondoCumple;
            letrasCumple = CFuncionesGenerales.letrasCumple;
            img = CFuncionesGenerales.img;
            promo01 = CFuncionesGenerales.promo01;
            promo02 = CFuncionesGenerales.promo02;
            promo03 = CFuncionesGenerales.promo03;
            promo04 = CFuncionesGenerales.promo04;
            promo05 = CFuncionesGenerales.promo05;
            promo06 = CFuncionesGenerales.promo06;
            chbLectorHuella.Checked = CFuncionesGenerales.usarHuella;
            solo = chbRegistro.Checked = CFuncionesGenerales.soloRegistro;
        }

        private void CargarInterfaz()
        {
            try
            {
                this.BackColor = fondo;
                foreach (Control ctr in this.Controls)
                {
                    if (ctr is Panel || ctr is GroupBox)
                    {
                        ctr.ForeColor = letras;
                        ctr.BackColor = fondo;
                        foreach (Control ct in ctr.Controls)
                        {
                            if (ct is Label || ctr is CheckBox)
                            {
                                ct.ForeColor = letras;
                                ct.BackColor = Color.Transparent;
                            }
                            if (ct is Button)
                                ct.ForeColor = SystemColors.ControlText;
                        }
                    }
                    else if (ctr is Label || ctr is CheckBox)
                    {
                        ctr.ForeColor = letras;
                        ctr.BackColor = Color.Transparent;
                    }
                    else if (ctr is TabControl)
                    {
                        ctr.ForeColor = letras;
                        ctr.BackColor = fondo;
                        foreach (Control ct in ctr.Controls)
                        {
                            if (!(ct is Button))
                            {
                                ct.ForeColor = letras;
                                ct.BackColor = fondo;
                            }
                            else if (ct is TabPage)
                            {
                                foreach (Control c in ct.Controls)
                                {
                                    if (!(c is Button))
                                    {
                                        c.ForeColor = letras;
                                        c.BackColor = fondo;
                                    }
                                    else
                                    {
                                        c.ForeColor = SystemColors.ControlText;
                                    }
                                }
                            }
                            else
                            {
                                ct.ForeColor = SystemColors.ControlText;
                            }
                        }
                    }
                    else if (ctr is Button)
                    {
                        ctr.ForeColor = SystemColors.ControlText;
                    }
                }
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
            pcbColorFondo.BackColor = fondo;
            txtRGBFondo.Text = fondo.R + ", " + fondo.G + ", " + fondo.B;
            pcbColorLetras.BackColor = letras;
            txtRGBLetras.Text = letras.R + ", " + letras.G + ", " + letras.B;
            pcbFondo.Image = img;
            pcbFondoCumple.BackColor = fondoCumple;
            txtFondoCumple.Text = fondoCumple.R + ", " + fondoCumple.G + ", " + fondoCumple.B;
            pcbLetrasCumple.BackColor = letrasCumple;
            txtLetrasCumple.Text = letrasCumple.R + ", " + letrasCumple.G + ", " + letrasCumple.B;

            pcbPromocion01.Image = promo01;
            pcbPromocion02.Image = promo02;
            pcbPromocion03.Image = promo03;
            pcbPromocion04.Image = promo04;
            pcbPromocion05.Image = promo05;
            pcbPromocion06.Image = promo06;
        }

        private void SeleccionarTemaCombo()
        {
            for (int i = 0; i < cbxTema.Items.Count; i++)
            {
                if (cbxTema.Items[i].ToString() == tema)
                {
                    cbxTema.SelectedIndex = i;
                    break;
                }
            }
        }

        private void SeleccionarTemaCumpleCombo()
        {
            for (int i = 0; i < cbxTemaCumple.Items.Count; i++)
            {
                if (cbxTemaCumple.Items[i].ToString() == temaCumple)
                {
                    cbxTemaCumple.SelectedIndex = i;
                    break;
                }
            }
        }

        private void HabilitarControles()
        {
            lblPersonalizar.Enabled = true;
            lblLetras.Enabled = true;
            lblFondo.Enabled = true;
            pcbColorLetras.Enabled = true;
            pcbColorFondo.Enabled = true;
            txtRGBLetras.Enabled = true;
            txtRGBFondo.Enabled = true;
        }

        private void DeshabilitarControles()
        {
            lblPersonalizar.Enabled = false;
            lblLetras.Enabled = false;
            lblFondo.Enabled = false;
            pcbColorLetras.Enabled = false;
            pcbColorFondo.Enabled = false;
            txtRGBLetras.Enabled = false;
            txtRGBFondo.Enabled = false;
        }

        private void HabilitarControlesCumple()
        {
            lblLetrasCumple.Enabled = true;
            lblFondoCumple.Enabled = true;
            pcbFondoCumple.Enabled = true;
            pcbLetrasCumple.Enabled = true;
            txtLetrasCumple.Enabled = true;
            txtFondoCumple.Enabled = true;
        }

        private void DeshabilitarControlesCumple()
        {
            lblLetrasCumple.Enabled = false;
            lblFondoCumple.Enabled = false;
            pcbFondoCumple.Enabled = false;
            pcbLetrasCumple.Enabled = false;
            txtLetrasCumple.Enabled = false;
            txtFondoCumple.Enabled = false;
        }

        private void TemaPredeterminado()
        {
            fondo = SystemColors.Control;
            txtRGBFondo.Text = fondo.R + ", " + fondo.G + ", " + fondo.B;
            pcbColorFondo.BackColor = fondo;
            letras = SystemColors.ControlText;
            txtRGBLetras.Text = letras.R + ", " + letras.G + ", " + letras.B;
            pcbColorLetras.BackColor = letras;
        }

        private void TemaClaro()
        {
            fondo = Color.FromArgb(252, 252, 252);
            txtRGBFondo.Text = "252, 252, 252";
            pcbColorFondo.BackColor = fondo;
            letras = Color.FromArgb(75, 75, 75);
            txtRGBLetras.Text = "75, 75, 75";
            pcbColorLetras.BackColor = letras;
        }

        private void TemaOscuro()
        {
            fondo = Color.FromArgb(50, 50, 50);
            txtRGBFondo.Text = "50, 50, 50";
            pcbColorFondo.BackColor = fondo;
            letras = Color.FromArgb(245, 250, 250);
            txtRGBLetras.Text = "245, 250, 250";
            pcbColorLetras.BackColor = letras;
        }

        private void TemaFiesta()
        {
            fondoCumple = Color.SteelBlue;
            txtFondoCumple.Text = "70, 130, 180";
            pcbFondoCumple.BackColor = fondoCumple;
            letrasCumple = SystemColors.ButtonHighlight;
            txtLetrasCumple.Text = "255, 255, 255";
            pcbLetrasCumple.BackColor = letrasCumple;
        }

        private void GuardarVariables()
        {
            CFuncionesGenerales.fondo = fondo;
            CFuncionesGenerales.fondoCumple = fondoCumple;
            CFuncionesGenerales.img = img;
            CFuncionesGenerales.letras = letras;
            CFuncionesGenerales.letrasCumple = letrasCumple;
            CFuncionesGenerales.promo01 = promo01;
            CFuncionesGenerales.promo02 = promo02;
            CFuncionesGenerales.promo03 = promo03;
            CFuncionesGenerales.promo04 = promo04;
            CFuncionesGenerales.promo05 = promo05;
            CFuncionesGenerales.promo06 = promo06;
            CFuncionesGenerales.tema = tema;
            CFuncionesGenerales.temaCumple = temaCumple;
            CFuncionesGenerales.usarHuella = chbLectorHuella.Checked;
            CFuncionesGenerales.soloRegistro = chbRegistro.Checked;
        }

        private void GuardarConfiguracion()
        {
            try
            {
                CConfiguracionXML.GuardarConfiguracion("huella", "usar", chbLectorHuella.Checked.ToString());
                CConfiguracionXML.GuardarConfiguracion("general", "soloRegistro", chbRegistro.Checked.ToString());
                CConfiguracionXML.GuardarConfiguracion("tema", "nombre", tema);
                CConfiguracionXML.GuardarConfiguracion("tema", "nombreCumple", temaCumple);
                CConfiguracionXML.GuardarConfiguracion("tema", "colorFondo", fondo.ToArgb().ToString());
                CConfiguracionXML.GuardarConfiguracion("tema", "colorLetras", letras.ToArgb().ToString());
                if (CFuncionesGenerales.CompararImagenes(img, (Bitmap)GYM.Properties.Resources.Fondo_Default))
                    CConfiguracionXML.GuardarConfiguracion("tema", "imagenFondo", "Fondo_Default");
                else if (img != null)
                {
                    string ruta = Application.StartupPath + "\\Img\\fondo.jpeg";
                    CConfiguracionXML.GuardarConfiguracion("tema", "imagenFondo", ruta);
                    Bitmap b = new Bitmap(img);
                    try
                    {
                        b.Save(ruta, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                    }
                }
                else
                    CConfiguracionXML.GuardarConfiguracion("tema", "imagenFondo", "null");
                CConfiguracionXML.GuardarConfiguracion("tema", "colorFondoCumple", Color.SteelBlue.ToArgb().ToString());
                CConfiguracionXML.GuardarConfiguracion("tema", "colorLetrasCumple", SystemColors.ButtonHighlight.ToArgb().ToString());

                if (pcbPromocion01.Image == null)
                {
                    CConfiguracionXML.GuardarConfiguracion("promociones", "promo01", "null");
                    CFuncionesGenerales.promo01 = null;
                }
                else
                {
                    string ruta = Application.StartupPath + "\\Img\\promo01.jpeg";
                    CConfiguracionXML.GuardarConfiguracion("promociones", "promo01", ruta);
                    Bitmap b = new Bitmap(pcbPromocion01.Image);
                    b.Save(ruta, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                if (pcbPromocion02.Image == null)
                {
                    CConfiguracionXML.GuardarConfiguracion("promociones", "promo02", "null");
                    CFuncionesGenerales.promo02 = null;
                }
                else
                {
                    string ruta = Application.StartupPath + "\\Img\\promo02.jpeg";
                    CConfiguracionXML.GuardarConfiguracion("promociones", "promo02", ruta);
                    Bitmap b = new Bitmap(pcbPromocion02.Image);
                    b.Save(ruta, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                if (pcbPromocion03.Image == null)
                {
                    CConfiguracionXML.GuardarConfiguracion("promociones", "promo03", "null");
                    CFuncionesGenerales.promo03 = null;
                }
                else
                {
                    string ruta = Application.StartupPath + "\\Img\\promo03.jpeg";
                    CConfiguracionXML.GuardarConfiguracion("promociones", "promo03", ruta);
                    Bitmap b = new Bitmap(pcbPromocion03.Image);
                    b.Save(ruta, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                if (pcbPromocion04.Image == null)
                {
                    CConfiguracionXML.GuardarConfiguracion("promociones", "promo04", "null");
                    CFuncionesGenerales.promo04 = null;
                }
                else
                {
                    string ruta = Application.StartupPath + "\\Img\\promo04.jpeg";
                    CConfiguracionXML.GuardarConfiguracion("promociones", "promo04", ruta);
                    Bitmap b = new Bitmap(pcbPromocion04.Image);
                    b.Save(ruta, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                if (pcbPromocion05.Image == null)
                {
                    CConfiguracionXML.GuardarConfiguracion("promociones", "promo05", "null");
                    CFuncionesGenerales.promo05 = null;
                }
                else
                {
                    string ruta = Application.StartupPath + "\\Img\\promo05.jpeg";
                    CConfiguracionXML.GuardarConfiguracion("promociones", "promo05", ruta);
                    Bitmap b = new Bitmap(pcbPromocion05.Image);
                    b.Save(ruta, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                if (pcbPromocion06.Image == null)
                {
                    CConfiguracionXML.GuardarConfiguracion("promociones", "promo06", "null");
                    CFuncionesGenerales.promo06 = null;
                }
                else
                {
                    string ruta = Application.StartupPath + "\\Img\\promo06.jpeg";
                    CConfiguracionXML.GuardarConfiguracion("promociones", "promo06", ruta);
                    Bitmap b = new Bitmap(pcbPromocion06.Image);
                    b.Save(ruta, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            catch (System.Xml.XmlException ex)
            {
                MessageBox.Show("Ha ocurrido un error al querer leer del archivo XML. Mensaje de error:" + ex.Message + "\nNúmero de linea y posición: " + ex.LineNumber + ", " + ex.LinePosition,
                    "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.IO.PathTooLongException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("La ruta del directorio es muy larga.", ex);
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El directorio del archivo de configuración no se encontró.", ex);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se encontro el archivo de configuración.", ex);
            }
            catch (System.IO.IOException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error de E/S.", ex);
            }
            catch (InvalidOperationException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("La llamada al método no se pudo efectuar porque el estado actual del objeto no lo permite.", ex);
            }
            catch (NotSupportedException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se pudo leer o modificar la secuencia de datos.", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El sistema ha negado el acceso al archivo de configuración.\nPuede deberse a un error de E/S o a un error de seguridad.", ex);
            }
            catch (System.Security.SecurityException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error de seguridad.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El método no acepta referencias nulas.", ex);
            }
            catch (ArgumentException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El argumento que se pasó al método no es aceptado por este.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }
        #endregion

        private void frmConfiguracionGeneral_Load(object sender, EventArgs e)
        {
            CargarConfiguracion();
            CargarInterfaz();
            SeleccionarTemaCombo();
            SeleccionarTemaCumpleCombo();
        }

        private void frmConfiguracionGeneral_FormClosing(object sender, FormClosingEventArgs e)
        {
            lnsSeparador01.Dispose();
            lnsSeparador02.Dispose();
        }

        private void pcbColorLetras_Click(object sender, EventArgs e)
        {
            cldColor = new ColorDialog();
            cldColor.FullOpen = true;
            cldColor.Color = letras;
            DialogResult d = cldColor.ShowDialog();
            if (d == System.Windows.Forms.DialogResult.OK)
            {
                letras = cldColor.Color;
                txtRGBLetras.Text = letras.R + ", " + letras.G + ", " + letras.B;
                CargarInterfaz();
            }
        }

        private void pcbColorFondo_Click(object sender, EventArgs e)
        {
            cldColor = new ColorDialog();
            cldColor.FullOpen = true;
            cldColor.Color = fondo;
            DialogResult d = cldColor.ShowDialog();
            if (d == System.Windows.Forms.DialogResult.OK)
            {
                fondo = cldColor.Color;
                txtRGBFondo.Text = fondo.R + ", " + fondo.G + ", " + fondo.B;
                CargarInterfaz();
            }
        }

        private void pcbLetrasCumple_Click(object sender, EventArgs e)
        {
            cldColor = new ColorDialog();
            cldColor.FullOpen = true;
            cldColor.Color = letrasCumple;
            DialogResult d = cldColor.ShowDialog();
            if (d == System.Windows.Forms.DialogResult.OK)
            {
                letrasCumple = cldColor.Color;
                txtLetrasCumple.Text = letrasCumple.R + ", " + letrasCumple.G + ", " + letrasCumple.B;
                CargarInterfaz();
            }
        }

        private void pcbFondoCumple_Click(object sender, EventArgs e)
        {
            cldColor = new ColorDialog();
            cldColor.FullOpen = true;
            cldColor.Color = fondoCumple;
            DialogResult d = cldColor.ShowDialog();
            if (d == System.Windows.Forms.DialogResult.OK)
            {
                fondoCumple = cldColor.Color;
                txtFondoCumple.Text = fondoCumple.R + ", " + fondoCumple.G + ", " + fondoCumple.B;
                CargarInterfaz();
            }
        }

        private void cbxTema_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxTema.SelectedIndex)
            {
                case 0:
                    DeshabilitarControles();
                    tema = cbxTema.Items[cbxTema.SelectedIndex].ToString();
                    TemaPredeterminado();
                    CargarInterfaz();
                    break;
                case 1:
                    DeshabilitarControles();
                    tema = cbxTema.Items[cbxTema.SelectedIndex].ToString();
                    TemaClaro();
                    CargarInterfaz();
                    break;
                case 2:
                    DeshabilitarControles();
                    tema = cbxTema.Items[cbxTema.SelectedIndex].ToString();
                    TemaOscuro();
                    CargarInterfaz();
                    break;
                case 3:
                    HabilitarControles();
                    tema = cbxTema.Items[cbxTema.SelectedIndex].ToString();
                    break;
            }
        }

        private void cbxTemaCumple_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxTemaCumple.SelectedIndex)
            {
                case 0:
                    DeshabilitarControlesCumple();
                    temaCumple = cbxTemaCumple.Items[cbxTemaCumple.SelectedIndex].ToString();
                    TemaFiesta();
                    CargarInterfaz();
                    break;
                case 1:
                    HabilitarControlesCumple();
                    temaCumple = cbxTemaCumple.Items[cbxTemaCumple.SelectedIndex].ToString();
                    break;
            }
        }

        private void txtRGBLetras_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (CFuncionesGenerales.EsRGB(txtRGBLetras.Text))
                {
                    string[] rgb = txtRGBLetras.Text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    letras = Color.FromArgb(int.Parse(rgb[0]), int.Parse(rgb[1]), int.Parse(rgb[2]));
                    tmpLetras = txtRGBLetras.Text;
                    CargarInterfaz();
                }
                else
                {
                    txtRGBLetras.Text = tmpLetras;
                    MessageBox.Show("Ese no es un formato valido de color", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (System.Text.RegularExpressions.RegexMatchTimeoutException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Se ha sobrepasado el tiempo de ejecución del método de coincidencia.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ningún método llamado en el evento LostFocus admite argumentos nulos.", ex);
            }
            catch (ArgumentException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al pasar los argumentos no válidos para un método.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void txtRGBLetras_GotFocus(object sender, EventArgs e)
        {
            tmpLetras = txtRGBLetras.Text;
        }

        private void txtRGBFondo_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (CFuncionesGenerales.EsRGB(txtRGBFondo.Text))
                {
                    string[] rgb = txtRGBFondo.Text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    fondo = Color.FromArgb(int.Parse(rgb[0]), int.Parse(rgb[1]), int.Parse(rgb[2]));
                    tmpFondo = txtRGBFondo.Text;
                    CargarInterfaz();
                }
                else
                {
                    txtRGBFondo.Text = tmpFondo;
                    MessageBox.Show("Ese no es un formato valido de color", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (System.Text.RegularExpressions.RegexMatchTimeoutException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Se ha sobrepasado el tiempo de ejecución del método de coincidencia.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ningún método llamado en el evento LostFocus admite argumentos nulos.", ex);
            }
            catch (ArgumentException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al pasar los argumentos no válidos para un método.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void txtRGBFondo_GotFocus(object sender, EventArgs e)
        {
            tmpFondo = txtRGBFondo.Text;
        }

        private void txtLetrasCumple_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (CFuncionesGenerales.EsRGB(txtLetrasCumple.Text))
                {
                    string[] rgb = txtLetrasCumple.Text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    letrasCumple = Color.FromArgb(int.Parse(rgb[0]), int.Parse(rgb[1]), int.Parse(rgb[2]));
                    tmpLetrasCumple = txtLetrasCumple.Text;
                    CargarInterfaz();
                }
                else
                {
                    txtLetrasCumple.Text = tmpLetrasCumple;
                    MessageBox.Show("Ese no es un formato valido de color", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (System.Text.RegularExpressions.RegexMatchTimeoutException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Se ha sobrepasado el tiempo de ejecución del método de coincidencia.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ningún método llamado en el evento LostFocus admite argumentos nulos.", ex);
            }
            catch (ArgumentException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al pasar los argumentos no válidos para un método.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void txtLetrasCumple_GotFocus(object sender, EventArgs e)
        {
            tmpLetrasCumple = txtLetrasCumple.Text;
        }

        private void txtFondoCumple_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (CFuncionesGenerales.EsRGB(txtFondoCumple.Text))
                {
                    string[] rgb = txtFondoCumple.Text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    fondoCumple = Color.FromArgb(int.Parse(rgb[0]), int.Parse(rgb[1]), int.Parse(rgb[2]));
                    tmpFondoCumple = txtFondoCumple.Text;
                    CargarInterfaz();
                }
                else
                {
                    txtFondoCumple.Text = tmpFondoCumple;
                    MessageBox.Show("Ese no es un formato valido de color", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (System.Text.RegularExpressions.RegexMatchTimeoutException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Se ha sobrepasado el tiempo de ejecución del método de coincidencia.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ningún método llamado en el evento LostFocus admite argumentos nulos.", ex);
            }
            catch (ArgumentException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al pasar los argumentos no válidos para un método.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void txtFondoCumple_GotFocus(object sender, EventArgs e)
        {
            tmpFondoCumple = txtFondoCumple.Text;
        }

        private void pcbFondo_Click(object sender, EventArgs e)
        {
            try
            {
                ofdImagen = new OpenFileDialog();
                ofdImagen.Filter = "Imagenes (*.jpg;*.bmp,*.png,*.gif)|*.jpg;*.bmp;*.png;*.gif";
                ofdImagen.Multiselect = false;
                ofdImagen.RestoreDirectory = false;
                DialogResult d = ofdImagen.ShowDialog();
                if (d == System.Windows.Forms.DialogResult.OK)
                {
                    img = new Bitmap(ofdImagen.FileName);
                    pcbFondo.Image = img;
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El archivo no se encontró. Verífique que no se haya borrado.", ex);
            }
            catch (ArgumentException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al asignar una propiedad.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void pcbPromociones_Click(object sender, EventArgs e)
        {
            try
            {
                PictureBox pcb = (PictureBox)sender;
                int n = int.Parse(pcb.Name.Substring(pcb.Name.Length - 2, 2));
                ofdImagen = new OpenFileDialog();
                ofdImagen.Filter = "Imagenes (*.jpg;*.bmp,*.png,*.gif)|*.jpg;*.bmp;*.png;*.gif";
                ofdImagen.Multiselect = false;
                ofdImagen.RestoreDirectory = false;
                DialogResult d = ofdImagen.ShowDialog();
                if (d == System.Windows.Forms.DialogResult.OK)
                {
                    switch (n)
                    {
                        case 1:
                            promo01 = new Bitmap(ofdImagen.FileName);
                            pcb.Image = img;
                            break;
                        case 2:
                            promo02 = new Bitmap(ofdImagen.FileName);
                            pcb.Image = img;
                            break;
                        case 3:
                            promo03 = new Bitmap(ofdImagen.FileName);
                            pcb.Image = img;
                            break;
                        case 4:
                            promo04 = new Bitmap(ofdImagen.FileName);
                            pcb.Image = img;
                            break;
                        case 5:
                            promo05 = new Bitmap(ofdImagen.FileName);
                            pcb.Image = img;
                            break;
                        case 6:
                            promo06 = new Bitmap(ofdImagen.FileName);
                            pcb.Image = img;
                            break;
                    }
                    CargarInterfaz();
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El archivo no se encontró. Verífique que no se haya borrado.", ex);
            }
            catch (FormatException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al dar formato a una variable.", ex);
            }
            catch (OverflowException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un desbordamiento.", ex);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El argumento dado se sale de rango.", ex);
            }
            catch (ArgumentNullException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("El método llamado no admite argumentos nulos.", ex);
            }
            catch (ArgumentException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al asignar una propiedad.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Deseas guardar los cambios?", "GymCSY", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    GuardarVariables();
                    bgwGuardar.RunWorkerAsync();
                    this.e = new frmEspere();
                    this.e.ShowDialog();
                    if (chbRegistro.Checked != solo)
                    {
                        MessageBox.Show("La aplicación se reiniciará.", "GymCSY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Restart();
                    }
                }
            }
            catch (System.ComponentModel.InvalidEnumArgumentException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("La enumeración pasada no es válida para el método llamado.", ex);
            }
            catch (InvalidOperationException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("La llamada al método no es válida para el estado actual del objeto.", ex);
            }
            catch (NotSupportedException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("No se admite el método invocado o una secuencia no admite ningún tipo de operación.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            img = null;
            pcbFondo.Image = img;
        }

        private void btnPredeterminado_Click(object sender, EventArgs e)
        {
            img = GYM.Properties.Resources.Fondo_Default;
            pcbFondo.Image = img;
        }

        private void btnQuitarPromo01_Click(object sender, EventArgs e)
        {
            pcbPromocion01.Image = null;
        }

        private void btnQuitarPromo02_Click(object sender, EventArgs e)
        {
            pcbPromocion02.Image = null;
        }

        private void btnQuitarPromo03_Click(object sender, EventArgs e)
        {
            pcbPromocion03.Image = null;
        }

        private void btnQuitarPromo04_Click(object sender, EventArgs e)
        {
            pcbPromocion04.Image = null;
        }

        private void btnQuitarPromo05_Click(object sender, EventArgs e)
        {
            pcbPromocion05.Image = null;
        }

        private void btnQuitarPromo06_Click(object sender, EventArgs e)
        {
            pcbPromocion06.Image = null;
        }

        private void bgwGuardar_DoWork(object sender, DoWorkEventArgs e)
        {
            GuardarConfiguracion();
            if (frm != null)
                frm.BackgroundImage = img;
            foreach (Form f in Application.OpenForms)
                if (f.Name != "frmCumple")
                    CFuncionesGenerales.CargarInterfaz(f);
            Application.DoEvents();
        }

        private void bgwGuardar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.e.Close();
            this.Close();
        }
    }
}
