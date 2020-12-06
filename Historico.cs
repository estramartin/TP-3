using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Agencia_Autos
{
    [Serializable]
    class Historico
    {

        List<Alquiler> historico = new List<Alquiler>();
       
        

        public void IngrearAlquiler(Alquiler unalquiler) {

            historico.Add(unalquiler);
        
        }
              

        public List<Alquiler> GetHistorico() {


            return historico;
        
        }

        public void DeleteItem(int pos, DataGridView lb1) {


            historico.RemoveAt(pos);
            lb1.Rows.Clear();

            foreach (Alquiler p in historico) {
                lb1.Rows.Add(p.getClinete().Nombre + " " + p.getClinete().Dni + " " + p.getClinete().Telefono + " " + Convert.ToString(p.getAcompañantes().Length) + " " + p.Auto.Marca + " " + p.Auto.Patente + " " + p.Auto.Kms);

            }        
        }
    }
}
