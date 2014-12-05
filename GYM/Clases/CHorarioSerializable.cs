using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYM.Clases
{
    [Serializable]
    public class CHorarioSerializable
    {
       int numeroFilas = 0;
       public string nombreDia = "Lunes";
       public Dictionary<String, bool> horas;
       public Dictionary<String, Dictionary<string, bool>> dia;
       int comienzoHorario = 6;
       public int horasTotales;
       public int diasTotales;

       private string mensajeSinSeleccionar = "Sin asignar";
       private string mensajeSeleccionado = "Asignado";
       private Color colorPrimario = Color.AliceBlue;
       private Color colorSecundario = Color.White;
       private Color colorSeleccionado = Color.FromArgb(0, 153, 204);
       private Color colorLetraSeleccionado = Color.White;

       public void CargarDias(DataGridView dgvHorario,Color backColorSeleccionado)
       {
           dia = new Dictionary<string, Dictionary<string, bool>>();
           for (int count = 0; count < dgvHorario.Columns.Count; count++)
           {
               int hora = 6;
               horas = new Dictionary<string, bool>();
               for (int i = 0; i < dgvHorario.Rows.Count; i++)
               {
                   DataGridViewRow row = dgvHorario.Rows[i];
                   //Si es una celda seleccionada
                   bool estado = (row.Cells[count].Style.BackColor == backColorSeleccionado) ? true : false;
                   horas.Add(hora.ToString(), estado);
                   hora++;
               }
               dia.Add(count.ToString(), horas);
           }



       }

       public bool GenerarDGV(ref DataGridView dgvHorario)
       {
           try
           {
               //17 veces
               for (int i = 6; i < horas.Count + 6; i++)
               {
                   List<DataGridViewTextBoxCell> celdas = new List<DataGridViewTextBoxCell>();
                   dgvHorario.Rows.Add(new object[] { null, null, null, null, null, null, null, null });
                   //6 veces
                   for (int j = 0; j < dia.Count; j++)
                   {
                       
                       DataGridViewTextBoxCell a = new DataGridViewTextBoxCell();
                       a = EstadoCelda(dia[j.ToString()][i.ToString()],i);
                       celdas.Add(a);
                       
                       dgvHorario.Rows[i-6].Cells[j] = (a);
                       
                   }
                   dgvHorario.Rows[i - 6].HeaderCell.Value = Convert.ToString(i) + ":00";
                   dgvHorario.Rows[i - 6].Height = 25;                   
               }
               return true;
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.ToString());
               return false;
           }

       }

       private DataGridViewTextBoxCell EstadoCelda(bool estado, int numeroFila)
       {
           try
           {
               DataGridViewTextBoxCell celda = new DataGridViewTextBoxCell();
               //Celda seleccionado
               if (estado)
               {
                   celda.Value = mensajeSeleccionado;
                   celda.Style.BackColor = colorSeleccionado;
                   celda.Style.ForeColor = colorLetraSeleccionado;
               }
                   //Celda no seleccionada
               else
               {
                   celda.Value = mensajeSinSeleccionar;
                   if (numeroFila % 2 == 0)
                       celda.Style.BackColor = colorPrimario;
                   else
                       celda.Style.BackColor = colorSecundario; 

               }

               return celda;
           }
           catch (Exception)
           {
               return null;
           }
       }

    }
}
