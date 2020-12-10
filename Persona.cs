using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia_Autos
{
    [Serializable]
    abstract class Persona
    {
        protected string nombre;
        //protected bool sexo;
        protected int dni;
        private long cuit;
        protected string direccion;
        protected long telefono;
        protected DateTime fechanac;
        protected string estadocivil;
        protected string nacionalidad;


        public string Nombre { get => nombre; set => nombre = value; }
        public int Dni { get => dni; set => dni = value; }
      

        public long Cuit
        {
            //Funciona!!

            get { return cuit; }
            set {
                
                this.cuit = value;
                
                int sumatorianumeros =0;

                string cuit = this.cuit.ToString();

                if (cuit.Length < 11) { throw new ArgumentOutOfRangeException("CUIT INVALIDO"); }

                else
                {

                    string[] CUIT = new string[11];
                    int[] CONTROLCUIT = new int[10];

                    for (int i = 0; i < CUIT.Length; i++)
                    {
                        CUIT[i] = cuit.Substring(i, 1);

                    }

                    CONTROLCUIT[0] = Convert.ToInt32(CUIT[0]) * 5;
                    CONTROLCUIT[1] = Convert.ToInt32(CUIT[1]) * 4;
                    CONTROLCUIT[2] = Convert.ToInt32(CUIT[2]) * 3;
                    CONTROLCUIT[3] = Convert.ToInt32(CUIT[3]) * 2;
                    CONTROLCUIT[4] = Convert.ToInt32(CUIT[4]) * 7;
                    CONTROLCUIT[5] = Convert.ToInt32(CUIT[5]) * 6;
                    CONTROLCUIT[6] = Convert.ToInt32(CUIT[6]) * 5;
                    CONTROLCUIT[7] = Convert.ToInt32(CUIT[7]) * 4;
                    CONTROLCUIT[8] = Convert.ToInt32(CUIT[8]) * 3;
                    CONTROLCUIT[9] = Convert.ToInt32(CUIT[9]) * 2;

                    string documento = cuit.Substring(2, 8);

                    if (dni.ToString() != documento) {

                        throw new ApplicationException("Documento o Cuit mal ingresado");
                    }


                    foreach (int C in CONTROLCUIT)
                    {

                        sumatorianumeros = C + sumatorianumeros;

                    }

                    int ultimoNumero = sumatorianumeros % 11;
                    int verificador = 11 - ultimoNumero;


                    if (Convert.ToInt32(CUIT[10]) == verificador)
                    {

                        this.cuit = value;

                    }
                    else { throw new ApplicationException("CUIT INVALIDO"); }


                }
            }
           
        
        
        }





        public string Direccion { get => direccion; set => direccion = value; }
        public long Telefono { get => telefono; set => telefono = value; }
        public DateTime Fechanac { get => fechanac; set => fechanac = value; }
        public string Estadocivil { get => estadocivil; set => estadocivil = value; }
        public string Nacionalidad { get => nacionalidad; set => nacionalidad = value; }
       //public long Cuit { get => cuit; set => cuit = value; }

        public abstract string DatosPersonales();







    }
}
