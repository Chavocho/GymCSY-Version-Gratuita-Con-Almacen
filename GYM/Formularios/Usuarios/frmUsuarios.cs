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
    public partial class frmUsuarios : Form
    {
        string id;

        #region Instancia
        private static frmUsuarios frmInstancia;
        public static frmUsuarios Instancia
        {
            get
            {
                if (frmInstancia == null)
                    frmInstancia = new frmUsuarios();
                else if (frmInstancia.IsDisposed)
                    frmInstancia = new frmUsuarios();
                return frmInstancia;

            }
            set
            {
                frmInstancia = value;
            }
        }
        #endregion

        public frmUsuarios()
        {
            InitializeComponent();
            GYM.Clases.CFuncionesGenerales.CargarInterfaz(this);
        }

        public void CargarUsuarios()
        {
            dgvUsuarios.Rows.Clear();
            string sql = "SELECT * FROM usuarios WHERE eliminado=0 ORDER BY nivel DESC";
            DataTable dt = Clases.ConexionBD.EjecutarConsultaSelect(sql);
            foreach (DataRow dr in dt.Rows)
            {
                int nivel = Convert.ToInt32(dr["nivel"]);
                string niv;
                if (nivel == 3)
                    niv = "Administrador";
                else if (nivel == 2)
                    niv = "Encargado";
                else
                    niv = "Asistente";
                dgvUsuarios.Rows.Add(new object[] { dr["id"], dr["userName"], niv });
            }
        }

        private void EliminarUsuario(string id)
        {
            string sql = "UPDATE usuarios SET eliminado=1 WHERE id='" + id + "'";
            Clases.ConexionBD.EjecutarConsultaSelect(sql);
            dgvUsuarios.Rows.RemoveAt(dgvUsuarios.CurrentRow.Index);
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            (new frmNuevoUsuario(this)).ShowDialog(this);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (frmMain.nivelUsuario == 3)
                (new frmEditarUsuario(this, id)).ShowDialog(this);
            else if (frmMain.nivelUsuario == 2)
            {
                if (dgvUsuarios[2, dgvUsuarios.CurrentRow.Index].Value.ToString() != "Administrador")
                    (new frmEditarUsuario(this, id)).ShowDialog(this);
                else
                    MessageBox.Show("No tienes permisos de editar a este usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (frmMain.nivelUsuario == 1)
            {
                if (dgvUsuarios[2, dgvUsuarios.CurrentRow.Index].Value.ToString() == "Asistente")
                    (new frmEditarUsuario(this, id)).ShowDialog(this);
                else
                    MessageBox.Show("No tienes permisos de editar a este usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("No tienes permisos de editar a este usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null)
            {
                if (frmMain.nivelUsuario == 3 && frmMain.id.ToString() != id)
                {
                    if (MessageBox.Show("¿Realmente desea eliminar a " + dgvUsuarios[1, dgvUsuarios.CurrentRow.Index].Value.ToString() + "?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        EliminarUsuario(id);
                }
                else if (frmMain.nivelUsuario == 2 && frmMain.id.ToString() != id)
                {
                    if (dgvUsuarios[2, dgvUsuarios.CurrentRow.Index].Value.ToString() != "Administrador")
                    {
                        if (MessageBox.Show("¿Realmente desea eliminar a " + dgvUsuarios[1, dgvUsuarios.CurrentRow.Index].Value.ToString() + "?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            EliminarUsuario(id);
                    }
                    else
                    {
                        MessageBox.Show("No tienes permisos para eliminar a este usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (frmMain.nivelUsuario == 1 && frmMain.id.ToString() != id)
                {
                    if (dgvUsuarios[2, dgvUsuarios.CurrentRow.Index].Value.ToString() == "Asistente")
                    {
                        if (MessageBox.Show("¿Realmente desea eliminar a " + dgvUsuarios[1, dgvUsuarios.CurrentRow.Index].Value.ToString() + "?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            EliminarUsuario(id);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No tienes permisos para eliminar a este usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("No tienes permisos para eliminar a este usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsuarios_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = dgvUsuarios[0, e.RowIndex].Value.ToString();
            }
            catch { }
        }
    }
}
