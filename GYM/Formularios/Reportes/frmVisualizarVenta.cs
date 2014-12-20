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
                string sql = "SELECT * FROM venta WHERE id='" + idV + "'";
                DataTable dt = ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    DateTime fecha;
                    string folioTicket, terminacion;
                    int estado, tipoPago;
                    decimal total = 0;
                    fecha = DateTime.Parse(dr["fecha"].ToString());
                    estado = int.Parse(dr["estado"].ToString());
                    tipoPago = int.Parse(dr["tipo_pago"].ToString());
                    total = decimal.Parse(dr["total"].ToString());
                    folioTicket = dr["folio_ticket"].ToString();
                    terminacion = dr["terminacion"].ToString();


                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
