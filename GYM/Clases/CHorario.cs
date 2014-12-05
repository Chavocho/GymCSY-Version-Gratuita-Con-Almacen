using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Runtime.Serialization;

namespace GYM.Clases
{
    class CHorario
    {
        FileStream archivo;
        BinaryFormatter serializador;
        String ruta = "horario/";
        int numTrabajador;

        CHorario()
        {
        }
        
        public CHorario(int numTrabajador)
        {
            this.numTrabajador = numTrabajador;
        }

        public static bool IniciarDgvDefault(ref DataGridView dgvHorario, int comienzoHorario, int numeroFilas,string mensaje,Color ColorPrimario, Color ColorSecundario)
        {
            try
            {
               // Button a = new Button();
                
                for (int i = 0; i < numeroFilas; i++)
                { 
                    DataGridViewTextBoxCell a = new DataGridViewTextBoxCell();
                    a.Style.BackColor = Color.Gray;
                    dgvHorario.Rows.Add(new object[] { a, a, a, a, a, a, a, a });
                    dgvHorario.Rows[i].HeaderCell.Value = Convert.ToString(comienzoHorario + i) + ":00";
                    dgvHorario.Rows[i].Height = 25;
                }

                int temp = 0;
                foreach (DataGridViewRow row in dgvHorario.Rows)
                {
                    foreach (DataGridViewCell boton in row.Cells)
                    {
                        boton.Value = mensaje;
                        if (temp % 2 == 0)
                            boton.Style.BackColor = ColorPrimario;
                        else
                            boton.Style.BackColor = ColorSecundario;                       
                    }
                    temp++;
                }
                
                return true;
            }
            catch (Exception)
            {
                return false;                
            }
        }

        public static bool SeleccionarCelda(ref DataGridView dgvHorario, DataGridViewCellEventArgs e, string mensaje, Color backColor, Color colorLetraSeleccionado)
        {
            try
            {
                dgvHorario[e.ColumnIndex, e.RowIndex].Value = mensaje;
                dgvHorario[e.ColumnIndex, e.RowIndex].Style.BackColor = backColor;
                dgvHorario[e.ColumnIndex, e.RowIndex].Style.ForeColor = colorLetraSeleccionado;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool SeleccionarCelda(ref DataGridView dgvHorario, DataGridViewCellEventArgs e, string mensaje, Color ColorPrimario, Color ColorSecundario, Color colorLetraSinSeleccionado)
        {
            try
            {
                dgvHorario[e.ColumnIndex, e.RowIndex].Value = mensaje;
                if (e.RowIndex % 2 == 0)
                    dgvHorario[e.ColumnIndex, e.RowIndex].Style.BackColor = ColorPrimario;
                else
                    dgvHorario[e.ColumnIndex, e.RowIndex].Style.BackColor = ColorSecundario;
                dgvHorario[e.ColumnIndex, e.RowIndex].Style.ForeColor = colorLetraSinSeleccionado;
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


       
        #region SERIALIZAR los horarios de los trabajadores
        public bool SerializarHorario(DataGridView dgvHorario, Color colorSeleccionado, CHorarioSerializable CHS)
        {
            try
            {
                if (File.Exists(ruta + numTrabajador + ".hr"))
                    File.Delete(ruta + numTrabajador + ".hr");

                CHorarioSerializable cHS = new CHorarioSerializable();
                cHS = CHS;
                cHS.CargarDias(dgvHorario, colorSeleccionado);

                serializador = new BinaryFormatter();
                archivo = new FileStream(ruta + numTrabajador + ".hr", FileMode.OpenOrCreate,FileAccess.Write);
                 serializador.Serialize(archivo, cHS);
                 archivo.Close();
                 return true;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
    
        }

        public CHorarioSerializable DeserializarHorario()
        {
            try
            {
                if (!File.Exists(ruta + numTrabajador + ".hr"))
                    return null;
                serializador = new BinaryFormatter();
                FileStream archivo = new FileStream(ruta + numTrabajador + ".hr", FileMode.OpenOrCreate, FileAccess.Read);
                CHorarioSerializable horario;
                horario = (CHorarioSerializable) serializador.Deserialize(archivo);
                archivo.Close();
                return horario;
            }
            catch (Exception)
            {
                
                throw;
            }

        }
    
    #endregion
    
    
    }
}
