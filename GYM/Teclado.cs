using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYM
{
    public partial class Teclado : UserControl
    {
        Control ctr;

        public Control Ctr
        {
            set { this.ctr = value; }
        }

        public Teclado()
        {
            InitializeComponent();
        }

        private void Teclado_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            SendKeys.Send("{" + btn.Text + "}");
            ctr.Focus();
        }
    }
}
