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

namespace GYM.Formularios.Compras
{
    public partial class frmModificarProductoCompra : Form
    {
        frmNuevaCompra frm;
        string id;

        public frmModificarProductoCompra(frmNuevaCompra frm, string id, string nomProd, int cant, decimal desc)
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
            lblProducto.Text = nomProd;
            this.frm = frm;
            this.id = id;
            nudCantidad.Value = cant;
            txtDescuento.Text = desc.ToString("0.00");
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            CFuncionesGenerales.VerificarEsNumero(ref sender, ref e, false);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            decimal des;
            decimal.TryParse(txtDescuento.Text, out des);
            frm.ModificarProducto(id, (int)nudCantidad.Value, des);
        }
    }
}
