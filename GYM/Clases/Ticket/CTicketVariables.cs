using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.Clases
{
    public partial class CTicket
    {
        PrintDocument pd;
        PrintPreviewDialog ppd;
        DataTable dtVenta;
        DataTable dtVentaDetallada;
        DataTable dtMembresia;
        DataTable dtCaja;
        DataTable dtLocker;
        Font fuentePequeña;
        Font fuenteNormal;
        Font fuenteResaltada;
        Font fuenteGrande;
        Font fuenteGrandeResaltada;
        TimeSpan turnoMat;
        TimeSpan turnoVes;

        /// <summary>
        /// 57mm = 210
        /// 80mm = 300
        /// </summary>
        int tamPapel;
        float y;
        const int saltoLinea = 18;
        const int saltoLineaPeque = 10;
        int folio;
        int numSoc;
        int idLocker;
        bool esCierreCaja = false;
        //Variables para el corte de caja
        int idApertura;
        int idCierre;
        //Fin de variables para el corte de caja
        string idProd;
        string impresora;
        string lineaSup01;
        string lineaSup02;
        string lineaSup03;
        string lineaSup04;
        string lineaSup05;
        string lineaSup06;
        string lineaSup07;
        string lineaInf01;
        string lineaInf02;
        string lineaInf03;
    }
}
