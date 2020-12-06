using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Agencia_Autos
{
    [Serializable]
    class Alquiler: IGuardar
    {
        private Persona cliente;
        private Vehículo vehiculo;
        private int cantAcompañantes = 0;
        private Persona[] acompañantes = new Cliente[3];
        private int diasDeAlquiler;
        private DateTime inicioAlquiler;
        private double precioAlquilado;
        private int kmsRecorridos;
        private double multaxdias;
        private double multaxkms;

        public Alquiler()
        { }



       public Alquiler(Persona cliente) {


            this.cliente = new Cliente(((Cliente)cliente).Nombre, ((Cliente)cliente).Dni, ((Cliente)cliente).Cuit, ((Cliente)cliente).Direccion, ((Cliente)cliente).Telefono, ((Cliente)cliente).Fechanac, ((Cliente)cliente).Estadocivil, ((Cliente)cliente).Nacionalidad, ((Cliente)cliente).Carnet, ((Cliente)cliente).Foto);
            
            
        }

        public Vehículo Auto {

            get { return vehiculo; }
            set { vehiculo = value; }
        
        }

        public DateTime InicioAlquiler
        {
            get { return inicioAlquiler; }
            set { inicioAlquiler = value; }
        
        }
        public int KmsRecorridos {

            get { return kmsRecorridos; }
            set { kmsRecorridos = value; }
        
        }

        public int DiasDeAlquiler
        {
            get { return diasDeAlquiler; }
            set { diasDeAlquiler = value; }

        }

        public int CantAcompañantes
        {
            get { return cantAcompañantes; }
            set { cantAcompañantes = value; }
        }

        public double MultaXDias
        {
            get { return multaxdias; }
            set { multaxdias = value; }
        }
        public double MultaxKms
        {
            get { return multaxkms; }
            set { multaxkms = value; }
        }

        public double PrecioAlquilado
        {
            get { return precioAlquilado; }
            set { precioAlquilado = value; }
        }
        public int ExcesoDias
        {
            get;
            set;
        }
        public int ExcesoKms
        {
            get;
            set;
        }
        public double Viaticos
        {
            get;
            set;
        }
        public Persona getClinete() {


            return cliente;
        }


        public Vehículo GetVehículo() {

            return vehiculo;
        
        }

        public void agregarConductores(Persona cliente) {



            acompañantes[CantAcompañantes] = cliente;
            CantAcompañantes++;


               
        }

        public Persona [] getAcompañantes() {


            return acompañantes;
        
        }

        public void GrabarCSV()
        {

            string nombrearchivo= @"D:\Martin\TSP\Laboratorio 2\TP 2\BackUP2\Agencia-Autos-master\bin\Debug\imprimible.csv";     
            FileStream archivo = new FileStream(nombrearchivo, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter escribir = new StreamWriter(archivo);

            escribir.WriteLine(cliente.Nombre);
            escribir.WriteLine(Auto.Modelo + ";" + Auto.Patente);

            escribir.Close();
            archivo.Dispose();

        }


    }
}
