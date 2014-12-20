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
    public partial class frmVisualizarVenta : Form
    {
        int idV;
        public frmVisualizarVenta(int idV)
        {
            InitializeComponent();
            this.idV = idV;
        }

        private void ObtenerDatosVenta()
        {
            try
            {
                string sql = "";
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
