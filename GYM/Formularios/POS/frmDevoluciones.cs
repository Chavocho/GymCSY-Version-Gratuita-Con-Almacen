using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GYM.Formularios.POS;

namespace GYM.Formularios.POS
{
    public partial class frmDevoluciones : Form
    {
        int folio;
        frmPuntoVenta frm;
        public frmDevoluciones(IWin32Window frm, int folio)
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
            this.frm = (frmPuntoVenta)frm;
            this.folio = folio;
        }

        private void frmDevoluciones_Load(object sender, EventArgs e)
        {
            try
            {
                Clases.CFuncionesGenerales.CargarInterfaz(this);
                ObtenerProductosVenta();
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void ObtenerProductosVenta()
        {
            try
            {
                string sql = "SELECT v.*, p.nombre, p.precio FROM venta_detallada AS v LEFT JOIN producto AS p ON (v.id_producto=p.id) WHERE v.id_venta='" + folio + "'";
                DataTable dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    dgvProductos.Rows.Add(new object[] { dr["id_producto"], dr["nombre"], dr["cantidad"], dr["precio"] });
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error al tratar de obtener los productos de la venta.", ex);
            }
            catch (Exception ex)
            {
                Clases.CFuncionesGenerales.MensajeError("Ha ocurrido un error genérico.", ex);
            }
        }

        private void dgvProductos_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void dgvProductos_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DataGridViewRow)))
                e.Effect = DragDropEffects.Move;
        }

        private void dgvProductos_DragDrop(object sender, DragEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.Name == "dgvDevoluciones")
            {
                dgvDevoluciones.Rows.Add((DataGridViewRow)e.Data);
            }
            else
            {
                dgvProductos.Rows.Add((DataGridViewRow)e.Data.GetData(typeof(DataGridViewRow)));
            }
        }

        private void dgvProductos_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.CurrentRow != null)
                dgv.DoDragDrop(dgv.CurrentRow, DragDropEffects.Move);
        }
    }
}
