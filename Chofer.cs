using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agencia_Autos
{
    [Serializable]
    class Chofer : Persona
    {

        public static int viatico = 140;

        protected long carnet;
        private string linea;
        public Chofer() { }

        public Chofer(string nombreCompleto, int dni, long cuil, string dir, long tel, DateTime fechanac, string estadoCiv, string nac, long carnet)
        {

            Nombre = nombreCompleto;
            this.Dni = dni;
            this.Cuit = cuil;
            Direccion = dir;
            Telefono = tel;
            this.Fechanac = fechanac;
            Estadocivil = estadoCiv;
            Nacionalidad = nac;
            this.Carnet = carnet;

            linea = Nombre + ";" + Dni + ";" + Cuit + ";" + Direccion + ";" + Telefono + ";" + Fechanac + ";" + Estadocivil + ";" + Carnet;


        }

       
        public long Carnet { get => carnet; set => carnet = value; }

        public override string DatosPersonales()
        {

            
            return "Chofer: "+Nombre +" - Carnet: "+ Carnet+ "- Telefono: "+ Telefono;



        }

       



    }
}
