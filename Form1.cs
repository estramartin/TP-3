using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace Agencia_Autos
{
    public partial class Form1 : Form
    {

        Administracion administracion;
        Persona persona;
        Vehículo vehículo;
        double precio;
        string nombreArchivo = Application.StartupPath+"\\datos.dat";
        List<Vehículo> SinChof = new List<Vehículo>();
        List<Vehículo> ConChof = new List<Vehículo>();
        Alquiler devolucion;
        Alquiler Comprobante;
       
        

        public Form1()
        {
            InitializeComponent();

           
            
            if (File.Exists(nombreArchivo))
            {

                FileStream archivo = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
                BinaryFormatter Deserializador = new BinaryFormatter();
                administracion = (Administracion)Deserializador.Deserialize(archivo);
                archivo.Close();
                archivo.Dispose();
            }
                
            else {

                Empresa unaEmpresa = new Empresa();
                unaEmpresa.RazonSocial = "ALQUILAUTO";
                unaEmpresa.DireccionFiscal = "LOS EUCALIPTUS 1234";
                unaEmpresa.Logo = Application.StartupPath + "\\logo.jpg";
                unaEmpresa.Cuil = 465698568;
                Historico unHistorico = new Historico();
                administracion = new Administracion(unaEmpresa,unHistorico);

            }

            ActualizarListboxs();
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            pblogo.Image = Image.FromFile( administracion.GetEmpresa().Logo);
            IngresoUsuario ingresarUsuario = new IngresoUsuario();
            ingresarUsuario.ShowDialog();

          


            if (ingresarUsuario.superovisor == true){ menuStrip1.Show(); }
            else { menuStrip1.Hide(); }


            ingresarUsuario.Dispose();

           SinChof.AddRange(administracion.GetVehículos());
           ConChof.AddRange(administracion.GetVehiculosConChofer());
            
           
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        
       

        private void sinChoferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agregar_Vehiculo agregar = new Agregar_Vehiculo();

            try
            {
                agregar.Size = new Size(816, 370);
                agregar.btnCargar.Location = new Point(657, 296);
                agregar.btnSalir.Location = new Point(59, 300);
                if (agregar.ShowDialog() == DialogResult.OK)
                {

                    bool disponible = true, chofer = false;


                    string patente = agregar.tbPatente.Text;
                    string marca = agregar.tbMarca.Text;
                    string modelo = agregar.tbModelo.Text;
                    string combustible = agregar.tbtipoCombustible.Text;
                    int capacidad = Convert.ToInt32(agregar.tbCapacidad.Text);
                    string path = agregar.path;
                    int unidadDeCobro = Convert.ToInt32(agregar.tbUnidadDeCobro.Text);
                    int kms = Convert.ToInt32(agregar.tbKilometros.Text);

                    foreach (Vehículo v in SinChof)
                    {

                        if (v.Patente == patente)
                        {

                            throw new ApplicationException("La Patente Ya Existe!");

                        }


                    }
                    foreach (Vehículo v in ConChof)
                    {

                        if (v.Patente == patente)
                        {

                            throw new ApplicationException("La Patente Ya Existe!");

                        }


                    }
                    vehículo = new Vehículo(disponible, chofer, patente, marca, modelo, combustible, path, capacidad, unidadDeCobro, kms);



                    administracion.agregarVehiculo(vehículo);
                    administracion.GetVehículos().Sort();
                    SinChof.Clear();
                    SinChof.AddRange(administracion.GetVehículos());

                    ActualizarListboxs();




                }
            }

            catch (FormatException ex)
            {

                MessageBox.Show(ex.Message);

            }
            catch (ApplicationException er) { MessageBox.Show(er.Message); }
                
            
        }

        private void conChoferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agregar_Vehiculo agregar = new Agregar_Vehiculo();
           // agregar.btnEliminar.Hide();
            try
            {

                agregar.Size = new Size(816, 706);
                agregar.btnCargar.Location = new Point(565, 636);
                agregar.btnSalir.Location = new Point(35, 641);

                if (agregar.ShowDialog() == DialogResult.OK)
                {

                    bool disponible = true, chofer = true;


                    string patente = agregar.tbPatente.Text;
                    string marca = agregar.tbMarca.Text;
                    string modelo = agregar.tbModelo.Text;
                    string combustible = agregar.tbtipoCombustible.Text;
                    int capacidad = Convert.ToInt32(agregar.tbCapacidad.Text);
                    string path = agregar.path;
                    int unidadDeCobro = Convert.ToInt32(agregar.tbUnidadDeCobro.Text);
                    int kms = Convert.ToInt32(agregar.tbKilometros.Text);

                    foreach (Vehículo v in SinChof)
                    {

                        if (v.Patente == patente)
                        {

                            throw new ApplicationException("La Patente Ya Existe!");

                        }


                    }
                    foreach (Vehículo v in ConChof)
                    {

                        if (v.Patente == patente)
                        {

                            throw new ApplicationException("La Patente Ya Existe!");

                        }


                    }

                    string nombre = agregar.tbNombreChofer.Text;
                    int Dni = Convert.ToInt32(agregar.tbDniChofer.Text);
                    long cuil = Convert.ToInt64(agregar.tbCuit.Text);
                    string dir = agregar.tbDireccion.Text;
                    int tel = Convert.ToInt32(agregar.tbTelefono.Text);
                    DateTime fechanac = agregar.dtpFechaNac.Value;
                    string estadocivil = agregar.tbEstadoCivil.Text;
                    string nacionalidad = agregar.tbNacionalidad.Text;
                    long carnet = Convert.ToInt64(agregar.tbCarnet.Text);

                    foreach (Vehículo c in administracion.GetVehiculosConChofer()) {

                        if (((VehículoConChofer)c).UnChofer.Cuit == cuil) {

                            throw new ApplicationException("El Cuit: "+cuil+" Ya Existe!");
                        }
                        if (((VehículoConChofer)c).UnChofer.Dni == Dni) {

                            throw new ApplicationException("El DNI: "+Dni+" Ya Existe!");
                        }
                        if (((Chofer)((VehículoConChofer)c).UnChofer).Carnet == carnet)

                            throw new ApplicationException("El Carnet: "+carnet +" Ya Existe!");
                    }


                    persona = new Chofer(nombre, Dni, cuil, dir, tel, fechanac, estadocivil, nacionalidad, carnet);
                    
                    vehículo = new VehículoConChofer(disponible, chofer, patente, marca, modelo, combustible, path, capacidad, persona, unidadDeCobro, kms);


                    administracion.agregarVehiculo(vehículo);
                    administracion.GetVehiculosConChofer().Sort();
                    ConChof.Clear();
                    ConChof.AddRange(administracion.GetVehiculosConChofer());

                    ActualizarListboxs();

                }

            }
            catch (FormatException er)
            {

                MessageBox.Show(er.Message);

            }

            catch (OverflowException er) { MessageBox.Show(er.Message); }
            catch (ApplicationException er) { MessageBox.Show(er.Message); }
        }

        private void modificarValoresDeAlquilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarValoresDeAlquiler modificar = new ModificarValoresDeAlquiler();
            try
            {
                

                modificar.lblMostrarValorActual.Text = administracion.Pesos.ToString();
                if (modificar.ShowDialog() == DialogResult.OK)
                {

                    double valor = Convert.ToDouble(modificar.tbModificarValorDeAlquiler.Text);
                    administracion.Pesos = valor;
                    ActualizarListboxs();

                }
            }
            catch (FormatException er) { MessageBox.Show(er.Message); }

        }

        
        private void button3_Click(object sender, EventArgs e)
        {//ver Alquileres
           
            AlquileresVigentes veralquileres = new AlquileresVigentes();
            veralquileres.btnEliminar.Hide();
            veralquileres.btnFinalizar.Show();
            veralquileres.label1.Show();
            veralquileres.textBox1.Show();
            veralquileres.dateTimePicker1.Show();
            Ticket unTicket = new Ticket();

            veralquileres.dgvAlquileres.AllowUserToAddRows =false;
            string[] alquileres;


            foreach (Alquiler p in administracion.GetAlquileres())
            {


                string datos = p.getClinete().Nombre + ";" + p.getClinete().Dni + ";" + p.getClinete().Telefono + ";" + Convert.ToString(p.DiasDeAlquiler) + ";" + p.Auto.Marca + ";" + p.Auto.Patente + ";" + p.Auto.Kms+";"+(p.Auto.PrecioAlquiladoEnUDC*p.PrecioAlquilado*p.DiasDeAlquiler);
               
                alquileres= datos.Split(';');
                veralquileres.dgvAlquileres.ColumnCount = alquileres.Length;
                veralquileres.dgvAlquileres.Rows.Add(alquileres);

                
            }

            if (veralquileres.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    devolucion = new Alquiler();
                    devolucion = administracion.GetAlquileres()[veralquileres.dgvAlquileres.CurrentRow.Index];
                    precio = administracion.Devolucion(veralquileres.dgvAlquileres.CurrentRow.Index, Convert.ToInt32(veralquileres.textBox1.Text), veralquileres.dgvAlquileres, veralquileres.dateTimePicker1.Value);
                                     

                    unTicket.printPreviewControl1.Document = PrintTicket;
                    ActualizarListboxs();


                    if (unTicket.ShowDialog() == DialogResult.OK)
                    {

                        PrintTicket.Print();


                    }


                }
                catch (Exception er) {

                    MessageBox.Show(er.Message);
                
                }



            }

        }
        

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (File.Exists(nombreArchivo)) File.Delete(nombreArchivo);
            FileStream archivo = new FileStream(nombreArchivo, FileMode.CreateNew, FileAccess.Write);
            BinaryFormatter serializador = new BinaryFormatter();
            serializador.Serialize(archivo, administracion);

            archivo.Close();
           
            

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }



          public void ActualizarListboxs() {
            //metodo que actualiza datagridview

            DGV1.Rows.Clear();
          
            DataGridViewRow fila;
           

            

            if (cbChofer.SelectedIndex == 1)
            {
                foreach (Vehículo v in administracion.GetVehículos())
                {
                   
                    fila = new DataGridViewRow();
                    fila.CreateCells(DGV1);
                    fila.Cells[CMARCA.Index].Value = v.Marca;
                    fila.Cells[CMOODELO.Index].Value = v.Modelo;
                    fila.Cells[CCAPACIDAD.Index].Value = v.Capacidad;
                    fila.Cells[CKMS.Index].Value = v.Kms;
                    fila.Cells[CPRECIO.Index].Value = ((v.UnidadDeCobro) * (administracion.Pesos));
                    if (v.Disponible == true)
                    {
                        fila.Cells[CDISPONIBILE.Index].Value = "Disponible";
                    }
                    else { fila.Cells[CDISPONIBILE.Index].Value = "Alquilado"; }


                    fila.Cells[CCOMBUSTIBLE.Index].Value = v.Tipocombustible;

                    DGV1.Rows.Add(fila);
                }
            }
            else
            {
                foreach (Vehículo v in administracion.GetVehiculosConChofer())
                {
                    
                    fila = new DataGridViewRow();
                    fila.CreateCells(DGV1);
                    fila.Cells[CMARCA.Index].Value = v.Marca;
                    fila.Cells[CMOODELO.Index].Value = v.Modelo;
                    fila.Cells[CCAPACIDAD.Index].Value = v.Capacidad;
                    fila.Cells[CKMS.Index].Value = v.Kms;
                    fila.Cells[CPRECIO.Index].Value = ((v.UnidadDeCobro) * (administracion.Pesos));
                    if (v.Disponible == true)
                    {
                        fila.Cells[CDISPONIBILE.Index].Value = "Disponible";
                    }
                    else { fila.Cells[CDISPONIBILE.Index].Value = "Alquilado"; }


                    fila.Cells[CCOMBUSTIBLE.Index].Value = v.Tipocombustible;

                    DGV1.Rows.Add(fila);
                }
            }
        }

        private void cbVehiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbVehiculosConChofer_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {// Ver Historico
            VerHistorico verHistorico = new VerHistorico();
            verHistorico.dgvHistorico.Rows.Clear();
            verHistorico.btnBorrar.Hide();

            verHistorico.dgvHistorico.AllowUserToAddRows = false;
            string[] historico = new string[6];


            foreach (Alquiler p in administracion.VerHistorico().GetHistorico())
            {

                string datos = p.getClinete().Nombre + ";" + p.getClinete().Dni + ";" + p.getClinete().Telefono + ";" + Convert.ToString(p.CantAcompañantes) + ";" + p.Auto.Marca + ";" + p.Auto.Patente + ";" + p.Auto.Kms;

                historico = datos.Split(';');
                verHistorico.dgvHistorico.ColumnCount = historico.Length;
                verHistorico.dgvHistorico.Rows.Add(historico);

            }                  
            
            DialogResult respuesta = new DialogResult();
            respuesta = verHistorico.ShowDialog();


            if (respuesta == DialogResult.Cancel)
            { } 
        }

        private void borrarRegistrosToolStripMenuItem_Click(object sender, EventArgs e)
        {           
        }

        private void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void DGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (cbChofer.SelectedIndex == 1)
                try
                {
                    pictureBox1.Image = Image.FromFile(SinChof[DGV1.CurrentRow.Index].Imagen);
                }
                catch (ArgumentOutOfRangeException) { }
                catch (ArgumentNullException er) { MessageBox.Show(er.Message); }
                catch (FileNotFoundException er) { MessageBox.Show(er.Message); }

            else {
                try
                {
                    pictureBox1.Image = Image.FromFile(ConChof[DGV1.CurrentRow.Index].Imagen);
                }
                catch (ArgumentOutOfRangeException) { }
                catch (ArgumentNullException er) { MessageBox.Show(er.Message); }
                catch (FileNotFoundException er) { MessageBox.Show(er.Message); }
            }
        }

        private void DGV1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            Ticket comprobante = new Ticket();

            try
            {
                if (cbChofer.SelectedIndex == 1)
                {


                    string ruta = SinChof[DGV1.CurrentRow.Index].Imagen;
                    GenerarAlquiler VentanaAlquilar = new GenerarAlquiler();
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////
                    VentanaAlquilar.tbNombreCliente.Text = "Carlos Gardel";
                    VentanaAlquilar.tbDniCliente.Text = "32831554";
                    VentanaAlquilar.tbCuilCliente.Text = "20328315549";
                    VentanaAlquilar.tbDireccionCliente.Text = "Colon 432";
                    VentanaAlquilar.tbTelefonoCliente.Text = "154234567";
                    VentanaAlquilar.tbEstadoCivilCliente.Text = "Casado";
                    VentanaAlquilar.tbNacionalidadCliente.Text = "Argentino";
                    VentanaAlquilar.tbCarnetCliente.Text = "234234234";
                    VentanaAlquilar.tbDiasDeAlquiler.Text = "2";


                    //////////////////////////////////////////////////////////////////////////////////////////////////////////
                    VentanaAlquilar.btnSalir.Location = new Point(377, 374);
                    VentanaAlquilar.label9.Show();
                    VentanaAlquilar.label11.Text = SinChof[DGV1.CurrentRow.Index].GetVehiculo();
                    if (SinChof[DGV1.CurrentRow.Index].Disponible == false)
                    {

                        VentanaAlquilar.gbCliente.Enabled = false;
                        VentanaAlquilar.btnAlquilar.Enabled = false;

                    }
                    else
                    {

                        VentanaAlquilar.gbCliente.Enabled = true;
                        VentanaAlquilar.btnAlquilar.Enabled = true;

                    }

                    VentanaAlquilar.pictureBox1.Image = Image.FromFile(ruta);
                    VentanaAlquilar.comboBox1.Show();
                    if (VentanaAlquilar.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            string nombre = VentanaAlquilar.tbNombreCliente.Text;
                            int Dni = Convert.ToInt32(VentanaAlquilar.tbDniCliente.Text);
                            long cuil = Convert.ToInt64(VentanaAlquilar.tbCuilCliente.Text);
                            string dir = VentanaAlquilar.tbDireccionCliente.Text;
                            int tel = Convert.ToInt32(VentanaAlquilar.tbTelefonoCliente.Text);
                            DateTime fechanac = VentanaAlquilar.dtpFechaNac.Value;
                            string estadocivil = VentanaAlquilar.tbEstadoCivilCliente.Text;
                            string nacionalidad = VentanaAlquilar.tbNacionalidadCliente.Text;
                            string carnet = VentanaAlquilar.tbCarnetCliente.Text;
                            int diasDeAlquiler = Convert.ToInt32(VentanaAlquilar.tbDiasDeAlquiler.Text);
                            int cantidadConductores = VentanaAlquilar.comboBox1.SelectedIndex;
                            string foto = VentanaAlquilar.pathTitular;
                            persona = new Cliente(nombre, Dni, cuil, dir, tel, fechanac, estadocivil, nacionalidad, carnet, foto);
                            Alquiler alquiler = new Alquiler(persona);
                            alquiler.DiasDeAlquiler = diasDeAlquiler;
                            alquiler.agregarConductores(persona);

                            switch (cantidadConductores)
                            {

                                case 1:
                                    {

                                        string nombre1 = VentanaAlquilar.tbNombreAcompañante1.Text;
                                        int Dni1 = Convert.ToInt32(VentanaAlquilar.tbDNIAcompañante1.Text);
                                        long cuil1 = Convert.ToInt64(VentanaAlquilar.tbCuilAcompañante1.Text);
                                        string dir1 = VentanaAlquilar.tbDirAcompañante1.Text;
                                        int tel1 = Convert.ToInt32(VentanaAlquilar.tbTelAcompañante1.Text);
                                        DateTime fechanac1 = VentanaAlquilar.dtpFechaNacAcompañante1.Value;
                                        string estadocivil1 = VentanaAlquilar.tbEstadoCivilAcompañante1.Text;
                                        string nacionalidad1 = VentanaAlquilar.tbNacAcompañante1.Text;
                                        string carnet1 = (VentanaAlquilar.tbCarnetAcompañante1.Text);
                                        string foto1 = VentanaAlquilar.path1;
                                        persona = new Cliente(nombre1, Dni1, cuil1, dir1, tel1, fechanac1, estadocivil1, nacionalidad1, carnet1, foto1);

                                        alquiler.agregarConductores(persona);

                                        break;
                                    }
                                case 2:
                                    {

                                        string nombre1 = VentanaAlquilar.tbNombreAcompañante1.Text;
                                        int Dni1 = Convert.ToInt32(VentanaAlquilar.tbDNIAcompañante1.Text);
                                        long cuil1 = Convert.ToInt64(VentanaAlquilar.tbCuilAcompañante1.Text);
                                        string dir1 = VentanaAlquilar.tbDirAcompañante1.Text;
                                        int tel1 = Convert.ToInt32(VentanaAlquilar.tbTelAcompañante1.Text);
                                        DateTime fechanac1 = VentanaAlquilar.dtpFechaNacAcompañante1.Value;
                                        string estadocivil1 = VentanaAlquilar.tbEstadoCivilAcompañante1.Text;
                                        string nacionalidad1 = VentanaAlquilar.tbNacAcompañante1.Text;
                                        string carnet1 = (VentanaAlquilar.tbCarnetAcompañante1.Text);
                                        string foto1 = VentanaAlquilar.path1;
                                        persona = new Cliente(nombre1, Dni1, cuil1, dir1, tel1, fechanac1, estadocivil1, nacionalidad1, carnet1, foto1);
                                        alquiler.agregarConductores(persona);

                                        string nombre2 = VentanaAlquilar.tbNombreAcompañante2.Text;
                                        int Dni2 = Convert.ToInt32(VentanaAlquilar.tbDNIAcompañante2.Text);
                                        long cuil2 = Convert.ToInt64(VentanaAlquilar.tbCuilAcompañante2.Text);
                                        string dir2 = VentanaAlquilar.tbDirAcompañante2.Text;
                                        int tel2 = Convert.ToInt32(VentanaAlquilar.tbTelAcompañante2.Text);
                                        DateTime fechanac2 = VentanaAlquilar.dtpFechaNacAcompañante2.Value;
                                        string estadocivil2 = VentanaAlquilar.tbEstadoCivilAcompañante2.Text;
                                        string nacionalidad2 = VentanaAlquilar.tbNacAcompañante2.Text;
                                        string carnet2 = (VentanaAlquilar.tbCarnetAcompañante2.Text);
                                        string foto2 = VentanaAlquilar.path2;
                                        persona = new Cliente(nombre2, Dni2, cuil2, dir2, tel2, fechanac2, estadocivil2, nacionalidad2, carnet2, foto2);
                                        alquiler.agregarConductores(persona);
                                        break;

                                    }


                            }



                            alquiler.Auto = SinChof[DGV1.CurrentRow.Index];
                            alquiler.Auto.PrecioAlquiladoEnUDC = alquiler.Auto.UnidadDeCobro;
                            alquiler.InicioAlquiler = DateTime.Now;
                            alquiler.Auto.Disponible = false;
                            alquiler.PrecioAlquilado = administracion.Pesos;
                            administracion.CargarAlquiler(alquiler);
                            Comprobante = alquiler;
                            DGV1.Rows.Clear();

                            ActualizarListboxs();

                        }
                        catch (FormatException) { }
                        catch (ArgumentOutOfRangeException) { }
                        catch (ApplicationException er) { MessageBox.Show(er.Message); }
                    }


                }
                else
                {
                    try
                    {
                        string ruta = ConChof[DGV1.CurrentRow.Index].Imagen;

                        GenerarAlquiler VentanaAlquilar = new GenerarAlquiler();
                        VentanaAlquilar.label9.Hide();

                        if (ConChof[DGV1.CurrentRow.Index].Disponible == false)
                        {

                            VentanaAlquilar.gbCliente.Enabled = false;
                            VentanaAlquilar.btnAlquilar.Enabled = false;

                        }
                        else
                        {

                            VentanaAlquilar.gbCliente.Enabled = true;
                            VentanaAlquilar.btnAlquilar.Enabled = true;

                        }
                        VentanaAlquilar.label11.Text = ((VehículoConChofer)(ConChof[DGV1.CurrentRow.Index])).UnChofer.DatosPersonales();
                        VentanaAlquilar.comboBox1.Hide();

                        VentanaAlquilar.pictureBox1.Image = Image.FromFile(ruta);
                        VentanaAlquilar.tbCuilAcompañante1.Text = "20328315549";
                        VentanaAlquilar.tbCuilAcompañante2.Text = "20328315549";
                        if (VentanaAlquilar.ShowDialog() == DialogResult.OK)
                        {
                            string nombre = VentanaAlquilar.tbNombreCliente.Text;
                            int Dni = Convert.ToInt32(VentanaAlquilar.tbDniCliente.Text);
                            long cuil = Convert.ToInt64(VentanaAlquilar.tbCuilCliente.Text);
                            string dir = VentanaAlquilar.tbDireccionCliente.Text;
                            int tel = Convert.ToInt32(VentanaAlquilar.tbTelefonoCliente.Text);
                            DateTime fechanac = VentanaAlquilar.dtpFechaNac.Value;
                            string estadocivil = VentanaAlquilar.tbEstadoCivilCliente.Text;
                            string nacionalidad = VentanaAlquilar.tbNacionalidadCliente.Text;
                            string carnet = (VentanaAlquilar.tbCarnetCliente.Text);
                            int diasDeAlquiler = Convert.ToInt32(VentanaAlquilar.tbDiasDeAlquiler.Text);
                            string foto = VentanaAlquilar.pathTitular;

                            persona = new Cliente(nombre, Dni, cuil, dir, tel, fechanac, estadocivil, nacionalidad, carnet, foto);

                            Alquiler alquiler = new Alquiler(persona);
                            alquiler.DiasDeAlquiler = diasDeAlquiler;
                            alquiler.Auto = ConChof[DGV1.CurrentRow.Index];
                            alquiler.Auto.PrecioAlquiladoEnUDC = alquiler.Auto.UnidadDeCobro;
                            alquiler.PrecioAlquilado = administracion.Pesos;
                            alquiler.InicioAlquiler = DateTime.Now;
                            alquiler.Auto.Disponible = false;
                            administracion.CargarAlquiler(alquiler);
                            Comprobante = alquiler;
                            ActualizarListboxs();


                        }

                    }
                    catch (FormatException) { }
                    catch (ArgumentOutOfRangeException) { }
                    catch (ApplicationException er) { MessageBox.Show(er.Message); }
                }




                if (Comprobante == null)
                {
                    throw new ApplicationException("Cancelado por el usuario  ");
                }
                else
                {

                    comprobante.printPreviewControl1.Document = printComprobante;
                    comprobante.printPreviewControl1.Rows = 1;
                    comprobante.printPreviewControl1.Columns = 1;
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if (comprobante.ShowDialog() == DialogResult.OK)
                    {

                        printComprobante.Print();


                    }
                }
                if (cbChofer.SelectedIndex == 1)
                {
                    comprobante.printPreviewControl1.Document = printPermisos;

                    if (comprobante.ShowDialog() == DialogResult.OK)
                    {

                        printPermisos.Print();


                    }
                }
            }
            catch (ApplicationException er) { MessageBox.Show(er.Message); }
            catch (NullReferenceException er) { MessageBox.Show(er.Message); }
        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarListboxs();
           
        }

        private void PrintTicket_PrintPage(object sender, PrintPageEventArgs e)
        {//IMRIMIR FACTURA
             AlquileresVigentes veralquileres = new AlquileresVigentes();

            try
            {
               
                string preciofinal = Convert.ToString(precio);
                //SETEO TAMAÑO PAPEL
                PaperSize paperSize = new PaperSize("My Envelope", 990, 500);
                paperSize.RawKind = (int)PaperKind.Custom;
                Image logo = Image.FromFile(administracion.GetEmpresa().Logo);
                Image factura = Image.FromFile(Application.StartupPath + "\\FACTURA.png");
                


                e.Graphics.DrawImage(logo, new PointF(20, 100));
                e.Graphics.DrawString(administracion.GetEmpresa().RazonSocial, new Font("MV Boli", 20, FontStyle.Bold), Brushes.Blue, new PointF(170, 100));
                e.Graphics.DrawString(DateTime.Now.ToShortDateString(), new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(700, 130));
                e.Graphics.DrawString(administracion.GetEmpresa().DireccionFiscal, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 130));
                e.Graphics.DrawString(administracion.GetEmpresa().Cuil.ToString(), new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 160));
                e.Graphics.DrawString("NOMBRE: ", new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(30, 300));
                e.Graphics.DrawString(devolucion.getClinete().Nombre, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 300));
                e.Graphics.DrawString("CUIL/CUIT: ", new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(30, 330));
                e.Graphics.DrawString(devolucion.getClinete().Cuit.ToString(), new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(200, 330)) ;
                e.Graphics.DrawImage(factura, new PointF(20, 400));
                e.Graphics.DrawString(devolucion.Auto.Marca, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(30, 450));
                e.Graphics.DrawString("$"+((devolucion.Auto.PrecioAlquiladoEnUDC*devolucion.PrecioAlquilado)*devolucion.DiasDeAlquiler).ToString(), new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(650, 490));
                e.Graphics.DrawString("RENTADO POR DIAS: "+ devolucion.DiasDeAlquiler.ToString(), new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(30, 490));
                e.Graphics.DrawString("KMs RECORRIDOS: " + devolucion.KmsRecorridos, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(30, 530));
                e.Graphics.DrawString("MORA POR EXCESO DE DIAS: "+devolucion.ExcesoDias, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(30,570));
                e.Graphics.DrawString("$"+devolucion.MultaXDias.ToString(), new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(650, 570));
                e.Graphics.DrawString("MORA POR EXCESO DE KMS: "+devolucion.ExcesoKms, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(30,610));
                e.Graphics.DrawString("$"+devolucion.MultaxKms.ToString(), new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(650, 610));
                e.Graphics.DrawString("VIATICOS CHOFER ", new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(30, 650));
                e.Graphics.DrawString("$"+devolucion.Viaticos.ToString(), new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(650, 650));
                e.Graphics.DrawString("A PAGAR: ", new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(455, 835));
                e.Graphics.DrawString("$"+ preciofinal, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.White, new PointF(700, 835));
                e.Graphics.DrawString(devolucion.Auto.Patente, new Font("Code 128", 100, FontStyle.Bold), Brushes.Black, new PointF(50, 900));



            }
            catch (NullReferenceException) { }
            }

        private void tbFiltro_TextChanged(object sender, EventArgs e)
        {//FILTRO

            DGV1.Rows.Clear();
            DataGridViewRow fila;
            
            
                if (cbChofer.SelectedIndex == 1)
                {
                    if (cbVehiculos.SelectedIndex == 0)
                    {
                        SinChof = (from v in administracion.GetVehículos() where ((v.Marca != null) && (v.Marca.StartsWith(tbFiltro.Text))) select v).ToList();

                    }
                    if (cbVehiculos.SelectedIndex == 1)
                    {
                        SinChof = (from v in administracion.GetVehículos() where (((v.Capacidad).ToString() != null) && ((v.Capacidad).ToString().StartsWith(tbFiltro.Text))) select v).ToList();

                    }
                    if (cbVehiculos.SelectedIndex == 2)
                    {
                        SinChof = (from v in administracion.GetVehículos() where ((v.Tipocombustible != null) && (v.Tipocombustible.StartsWith(tbFiltro.Text))) select v).ToList();

                    }




                    foreach (Vehículo v in SinChof)
                    {

                        fila = new DataGridViewRow();
                        fila.CreateCells(DGV1);
                        fila.Cells[CMARCA.Index].Value = v.Marca;
                        fila.Cells[CMOODELO.Index].Value = v.Modelo;
                        fila.Cells[CCAPACIDAD.Index].Value = v.Capacidad;
                        fila.Cells[CKMS.Index].Value = v.Kms;
                        fila.Cells[CPRECIO.Index].Value = ((v.UnidadDeCobro) * (administracion.Pesos));
                        if (v.Disponible == true)
                        {
                            fila.Cells[CDISPONIBILE.Index].Value = "Disponible";
                        }
                        else { fila.Cells[CDISPONIBILE.Index].Value = "Alquilado"; }


                        fila.Cells[CCOMBUSTIBLE.Index].Value = v.Tipocombustible;

                        DGV1.Rows.Add(fila);
                    }
                }
                else
                {
                    if (cbVehiculos.SelectedIndex == 0)
                    {
                        ConChof = (from v in administracion.GetVehiculosConChofer() where ((v.Marca != null) && (v.Marca.StartsWith(tbFiltro.Text))) select v).ToList();

                    }
                    if (cbVehiculos.SelectedIndex == 1)
                    {
                        ConChof = (from v in administracion.GetVehiculosConChofer() where (((v.Capacidad).ToString() != null) && ((v.Capacidad).ToString().StartsWith(tbFiltro.Text))) select v).ToList();

                    }
                    if (cbVehiculos.SelectedIndex == 2)
                    {
                        ConChof = (from v in administracion.GetVehiculosConChofer() where ((v.Tipocombustible != null) && (v.Tipocombustible.StartsWith(tbFiltro.Text))) select v).ToList();

                    }




                    foreach (Vehículo v in ConChof)
                    {

                        fila = new DataGridViewRow();
                        fila.CreateCells(DGV1);
                        fila.Cells[CMARCA.Index].Value = v.Marca;
                        fila.Cells[CMOODELO.Index].Value = v.Modelo;
                        fila.Cells[CCAPACIDAD.Index].Value = v.Capacidad;
                        fila.Cells[CKMS.Index].Value = v.Kms;
                        fila.Cells[CPRECIO.Index].Value = ((v.UnidadDeCobro) * (administracion.Pesos));
                        if (v.Disponible == true)
                        {
                            fila.Cells[CDISPONIBILE.Index].Value = "Disponible";
                        }
                        else { fila.Cells[CDISPONIBILE.Index].Value = "Alquilado"; }


                        fila.Cells[CCOMBUSTIBLE.Index].Value = v.Tipocombustible;

                        DGV1.Rows.Add(fila);

                    }
                }
        }

        private void modificarDatosDeVehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {    // MODIFICA DATOS DEL VEHICULO
            Agregar_Vehiculo modificar = new Agregar_Vehiculo();
            int indice = DGV1.CurrentRow.Index;
            List<Vehículo> aux;

            



            if (cbChofer.SelectedIndex == 1)
            {
                modificar.Size = new Size(816, 370);
                modificar.btnCargar.Location = new Point(657, 296);
                modificar.btnSalir.Location = new Point(59, 300);
                aux = SinChof;

            }
            else {



                modificar.Size = new Size(816, 706);
                modificar.btnCargar.Location = new Point(565, 636);
                modificar.btnSalir.Location = new Point(35, 641);
                modificar.tbNombreChofer.Text = ((VehículoConChofer)ConChof[indice]).UnChofer.Nombre;
                modificar.tbDireccion.Text = ((VehículoConChofer)ConChof[indice]).UnChofer.Direccion;
                modificar.tbDniChofer.Text = Convert.ToString(((VehículoConChofer)ConChof[indice]).UnChofer.Dni);
                modificar.tbCuit.Text = Convert.ToString(((VehículoConChofer)ConChof[indice]).UnChofer.Cuit);
                modificar.tbCarnet.Text = Convert.ToString(((Chofer)((VehículoConChofer)ConChof[indice]).UnChofer).Carnet);
                modificar.tbEstadoCivil.Text = ((VehículoConChofer)ConChof[indice]).UnChofer.Estadocivil;
                modificar.tbNacionalidad.Text = ((VehículoConChofer)ConChof[indice]).UnChofer.Nacionalidad;
                modificar.tbTelefono.Text = Convert.ToString(((VehículoConChofer)ConChof[indice]).UnChofer.Telefono);
                modificar.dtpFechaNac.Value = ((VehículoConChofer)ConChof[indice]).UnChofer.Fechanac;
                aux = ConChof;
            }

            if (aux[indice].Disponible == false)
            {

                modificar.gbDatosVehiculos.Enabled = false;
                modificar.gbDatosChofer.Enabled = false;
                modificar.btnCarcarImagenAuto.Enabled = false;
                modificar.btnCargar.Enabled = false;

            }
            else {

                modificar.gbDatosVehiculos.Enabled = true;
                modificar.gbDatosChofer.Enabled = true;
                modificar.btnCarcarImagenAuto.Enabled = true;
                modificar.btnCargar.Enabled = true;
            }


            modificar.pictureBox1.Image = Image.FromFile(aux[indice].Imagen);
                modificar.path = aux[indice].Imagen;
                modificar.tbMarca.Text = aux[indice].Marca;
                modificar.tbModelo.Text = aux[indice].Modelo;
                modificar.tbPatente.Text = aux[indice].Patente;
                modificar.tbCapacidad.Text = Convert.ToString(aux[indice].Capacidad);
                modificar.tbKilometros.Text = Convert.ToString(aux[indice].Kms);
                modificar.tbtipoCombustible.Text = SinChof[indice].Tipocombustible;
                modificar.tbUnidadDeCobro.Text = Convert.ToString(aux[indice].UnidadDeCobro);

                try
                {
                   
                   
                    if (modificar.ShowDialog() == DialogResult.OK)
                    {
                       
                        string patente = modificar.tbPatente.Text;
                        string marca = modificar.tbMarca.Text;
                        string modelo = modificar.tbModelo.Text;
                        string combustible = modificar.tbtipoCombustible.Text;
                        int capacidad = Convert.ToInt32(modificar.tbCapacidad.Text);
                        string path = modificar.path;
                        int unidadDeCobro = Convert.ToInt32(modificar.tbUnidadDeCobro.Text);
                        int kms = Convert.ToInt32(modificar.tbKilometros.Text);



                        aux[indice].Patente = patente;
                        aux[indice].Marca = marca;
                        aux[indice].Modelo = modelo;
                        aux[indice].Tipocombustible = combustible;
                        aux[indice].Capacidad = capacidad;
                        aux[indice].Imagen = path;
                        aux[indice].UnidadDeCobro = unidadDeCobro;
                        aux[indice].Kms = kms;


                                           

                        administracion.GetVehículos().Sort();


                        ActualizarListboxs();
                    }

                      

                }

                catch (FormatException ex)
                {

                    MessageBox.Show(ex.Message);

                }





            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void darDeBajaVehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int[] asd = new int[2];
            asd[4] = 4;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MOSTRAR REGUSTROS DE ARCHIVOS
            VerArchivos unArchivo = new VerArchivos();

            IGuardar guardar;


            guardar = new Vehículo();
           
            guardar.GrabarCSV();

            guardar = new Alquiler();

            guardar.GrabarCSV();
                      

            if (unArchivo.ShowDialog() == DialogResult.OK) { }
            



        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {//Parte Web


            if (e.KeyCode == Keys.F1) {
                   

                Ayuda ayudin = new Ayuda();
                               
                ayudin.navegador.Navigate(@"D:\Martin\TSP\Laboratorio 2\TP 2\BackUP2\Agencia-Autos-master\Ayuda\Ayuda.html");
               
                ayudin.ShowDialog();
            }

        }

        private void printComprobante_PrintPage(object sender, PrintPageEventArgs e)
        {//imprime comprobante
            try
            {
                PaperSize paperSize = new PaperSize("My Envelope", 990, 500);
                paperSize.RawKind = (int)PaperKind.Custom;
                Image logo = Image.FromFile(administracion.GetEmpresa().Logo);
                e.Graphics.DrawImage(logo, new PointF(20, 100));
                e.Graphics.DrawString(administracion.GetEmpresa().RazonSocial, new Font("MV Boli", 20, FontStyle.Bold), Brushes.Blue, new PointF(170, 100));
                e.Graphics.DrawString(DateTime.Now.ToShortDateString(), new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(700, 130));
                e.Graphics.DrawString(administracion.GetEmpresa().DireccionFiscal, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 130));
                e.Graphics.DrawString(administracion.GetEmpresa().Cuil.ToString(), new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 160));
                e.Graphics.DrawString("Nombre: " + Comprobante.getClinete().Nombre, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 300));
                e.Graphics.DrawString("Direccion: " + Comprobante.getClinete().Direccion, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 400));
                e.Graphics.DrawString("Dni: " + Comprobante.getClinete().Dni.ToString(), new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 500));
                e.Graphics.DrawString("Vehiculo: " + Comprobante.Auto.Marca, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 600));
                e.Graphics.DrawString("Patente: " + Comprobante.Auto.Patente, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 700));
                e.Graphics.DrawString("Kms: " + Comprobante.Auto.Kms.ToString(), new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 800));

            }
            catch (NullReferenceException er) { MessageBox.Show(er.Message); }
            catch (ArgumentNullException er) { MessageBox.Show(er.Message); }

        }

        private void printPermisos_PrintPage(object sender, PrintPageEventArgs e)
        {
            //imprimir permisos
           
            PaperSize paperSize = new PaperSize("My Envelope", 990, 500);
              paperSize.RawKind = (int)PaperKind.Custom;
              Image logo = Image.FromFile(administracion.GetEmpresa().Logo);


              if (Comprobante.CantAcompañantes == 1)
              {
                                  
                Image Foto = Image.FromFile(((Cliente)Comprobante.getAcompañantes()[0]).Foto);

                e.Graphics.DrawImage(logo, new PointF(20, 30));
                e.Graphics.DrawImage(Foto, new PointF(600, 40));
                e.Graphics.DrawString(Comprobante.getAcompañantes()[0].Nombre, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 40));
                e.Graphics.DrawString(Comprobante.getAcompañantes()[0].Direccion, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 70));
                e.Graphics.DrawString(Comprobante.getAcompañantes()[0].Dni.ToString(), new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 100));
                e.Graphics.DrawString("AUTIRZADO PARA CONDUCIR:", new Font("Times new Roman", 15, FontStyle.Bold), Brushes.Black, new PointF(170, 160));
                e.Graphics.DrawString(Comprobante.Auto.Marca, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 200));
                e.Graphics.DrawString(Comprobante.Auto.Patente, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 240));
                e.Graphics.DrawString(Comprobante.Auto.Modelo, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 280));

                e.Graphics.DrawString("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ", new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(0, 310));

            }
            if (Comprobante.CantAcompañantes == 2)
            {
               
                   Image Foto = Image.FromFile(((Cliente)Comprobante.getAcompañantes()[0]).Foto);

                e.Graphics.DrawImage(logo, new PointF(20, 30));
                e.Graphics.DrawImage(Foto, new PointF(600, 40));
                e.Graphics.DrawString(Comprobante.getAcompañantes()[0].Nombre, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 40));
                e.Graphics.DrawString(Comprobante.getAcompañantes()[0].Direccion, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 70));
                e.Graphics.DrawString(Comprobante.getAcompañantes()[0].Dni.ToString(), new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 100));
                e.Graphics.DrawString("AUTIRZADO PARA CONDUCIR:", new Font("Times new Roman", 15, FontStyle.Bold), Brushes.Black, new PointF(170, 160));
                e.Graphics.DrawString(Comprobante.Auto.Marca, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 200));
                e.Graphics.DrawString(Comprobante.Auto.Patente, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 240));
                e.Graphics.DrawString(Comprobante.Auto.Modelo, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 280));

                e.Graphics.DrawString("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ", new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(0, 310));

                Image FotoConductor1 = Image.FromFile(((Cliente)Comprobante.getAcompañantes()[1]).Foto);
                e.Graphics.DrawImage(logo, new PointF(20, 370));
                e.Graphics.DrawImage(FotoConductor1, new PointF(600, 350));
                e.Graphics.DrawString(Comprobante.getAcompañantes()[1].Nombre, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 370));
                e.Graphics.DrawString(Comprobante.getAcompañantes()[1].Direccion, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 400));
                e.Graphics.DrawString(Comprobante.getAcompañantes()[1].Dni.ToString(), new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 430));
                e.Graphics.DrawString("AUTIRZADO PARA CONDUCIR:", new Font("Times new Roman", 15, FontStyle.Bold), Brushes.Black, new PointF(170, 490));
                e.Graphics.DrawString(Comprobante.Auto.Marca, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 530));
                e.Graphics.DrawString(Comprobante.Auto.Patente, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 570));
                e.Graphics.DrawString(Comprobante.Auto.Modelo, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 610));

                e.Graphics.DrawString("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ", new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(0, 640));


            }


            if (Comprobante.CantAcompañantes == 3)
            {
                Image Foto = Image.FromFile(((Cliente)Comprobante.getAcompañantes()[0]).Foto);



                e.Graphics.DrawImage(logo, new PointF(20, 30));
                e.Graphics.DrawImage(Foto, new PointF(600, 40));
                e.Graphics.DrawString(Comprobante.getAcompañantes()[0].Nombre, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 40));
                e.Graphics.DrawString(Comprobante.getAcompañantes()[0].Direccion, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 70));
                e.Graphics.DrawString(Comprobante.getAcompañantes()[0].Dni.ToString(), new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 100));
                e.Graphics.DrawString("AUTIRZADO PARA CONDUCIR:", new Font("Times new Roman", 15, FontStyle.Bold), Brushes.Black, new PointF(170, 160));
                e.Graphics.DrawString(Comprobante.Auto.Marca, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 200));
                e.Graphics.DrawString(Comprobante.Auto.Patente, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 240));
                e.Graphics.DrawString(Comprobante.Auto.Modelo, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 280));

                e.Graphics.DrawString("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ", new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(0, 310));

                Image FotoConductor1 = Image.FromFile(((Cliente)Comprobante.getAcompañantes()[1]).Foto);
                e.Graphics.DrawImage(logo, new PointF(20, 370));
                e.Graphics.DrawImage(FotoConductor1, new PointF(600, 350));
                e.Graphics.DrawString(Comprobante.getAcompañantes()[1].Nombre, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 370));
                e.Graphics.DrawString(Comprobante.getAcompañantes()[1].Direccion, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 400));
                e.Graphics.DrawString(Comprobante.getAcompañantes()[1].Dni.ToString(), new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 430));
                e.Graphics.DrawString("AUTIRZADO PARA CONDUCIR:", new Font("Times new Roman", 15, FontStyle.Bold), Brushes.Black, new PointF(170, 490));
                e.Graphics.DrawString(Comprobante.Auto.Marca, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 530));
                e.Graphics.DrawString(Comprobante.Auto.Patente, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 570));
                e.Graphics.DrawString(Comprobante.Auto.Modelo, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 610));

                e.Graphics.DrawString("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ", new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(0, 640));


                Image FotoConductor2 = Image.FromFile(((Cliente)Comprobante.getAcompañantes()[2]).Foto);
                e.Graphics.DrawImage(logo, new PointF(20,700));
                e.Graphics.DrawImage(FotoConductor2, new PointF(600, 690));
                e.Graphics.DrawString(Comprobante.getAcompañantes()[2].Nombre, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 700));
                e.Graphics.DrawString(Comprobante.getAcompañantes()[2].Direccion, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 730));
                e.Graphics.DrawString(Comprobante.getAcompañantes()[2].Dni.ToString(), new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 760));
                e.Graphics.DrawString("AUTIRZADO PARA CONDUCIR:", new Font("Times new Roman", 15, FontStyle.Bold), Brushes.Black, new PointF(170, 820));
                e.Graphics.DrawString(Comprobante.Auto.Marca, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 860));
                e.Graphics.DrawString(Comprobante.Auto.Patente, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 900));
                e.Graphics.DrawString(Comprobante.Auto.Modelo, new Font("Times new Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(170, 940));


               


            }

        }

        private void eliminarVehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {//eliminar vehiculo

            
            Mensajes mensaje = new Mensajes();





            if (cbChofer.SelectedIndex == 1)
            {
                if (SinChof[DGV1.CurrentRow.Index].Disponible == false)
                {

                    mensaje.btnAceptar.Enabled = false;

                }
                

                if (mensaje.ShowDialog() == DialogResult.OK)
                {
                    SinChof.RemoveAt(DGV1.CurrentCell.RowIndex);
                    administracion.GetVehículos().Clear();
                    administracion.GetVehículos().AddRange(SinChof);
                }
            }
            else {
                if (ConChof[DGV1.CurrentRow.Index].Disponible == false)
                {

                    mensaje.btnAceptar.Enabled = false;
                }

                if (mensaje.ShowDialog() == DialogResult.OK)
                {
                    ConChof.RemoveAt(DGV1.CurrentCell.RowIndex);
                    administracion.GetVehiculosConChofer().Clear();
                    administracion.GetVehiculosConChofer().AddRange(ConChof);

                }



            }


            ActualizarListboxs();

           
        }

        private void verGraficosToolStripMenuItem_Click(object sender, EventArgs e)
        { }

        private void conSinChoferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Graficos de choferes

            int vConChofer = 0, vSinChofer = 0;

            foreach (Alquiler h in administracion.VerHistorico().GetHistorico())
            {

                if (h.Auto.Conchofer == true)
                {

                    vConChofer++;
                   

                }
                else { vSinChofer++;  }


            }

            string[] titulos = new string[] { "Vehiculos con Chofer", "Vehiculos sin Chofer" };
            int[] barras = new int[] { vConChofer, vSinChofer };

            Graficos graficos = new Graficos();

            for (int i = 0; i < titulos.Length; i++)
            {

                Series serie = graficos.chart1.Series.Add(titulos[i]);
                serie.Label = barras[i].ToString();
                serie.Points.Add(barras[i]);


            }

            if (graficos.ShowDialog() == DialogResult.OK) { };



        }

        private void asientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Grafico de asientos

            List<int> asientos = new List<int>();
            SortedDictionary<int, int> agrupados= new SortedDictionary<int, int>();

            foreach (Alquiler h in administracion.VerHistorico().GetHistorico())
            {
                asientos.Add(h.Auto.Capacidad);
            }
                      
            foreach (int a in asientos) {
                int cont = 1;
                foreach (int b in asientos) {
                    
                    if (a == b) {

                        agrupados[a] = cont++;
                    
                    }                
                }          
            }

            Graficos grafico = new Graficos();

            foreach (KeyValuePair<int, int> a in agrupados) {

                Series serie = grafico.chart1.Series.Add("Butacas: "+ a.Key.ToString());
                serie.Label = a.Value.ToString();
                serie.Points.Add(a.Value);
                              
            }

            if (grafico.ShowDialog() == DialogResult.OK) { }

        }

        private void historicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Borrar registro de historico
            VerHistorico verHistorico = new VerHistorico();
            verHistorico.dgvHistorico.Rows.Clear();
            verHistorico.btnBorrar.Show();

            verHistorico.dgvHistorico.AllowUserToAddRows = false;
            string[] historico;


            foreach (Alquiler p in administracion.VerHistorico().GetHistorico())
            {

                try
                {
                    string datos = p.getClinete().Nombre + ";" + p.getClinete().Dni + ";" + p.getClinete().Telefono + ";" + Convert.ToString(p.getAcompañantes().Length) + ";" + p.Auto.Marca + ";" + p.Auto.Patente + ";" + p.Auto.Kms;

                    historico = datos.Split(';');
                    verHistorico.dgvHistorico.ColumnCount = historico.Length;
                    verHistorico.dgvHistorico.Rows.Add(historico);


                }
                catch (Exception) { }


            }


           


          while (verHistorico.ShowDialog() == DialogResult.OK)
            {

                administracion.VerHistorico().DeleteItem(verHistorico.dgvHistorico.CurrentRow.Index, verHistorico.dgvHistorico);
                verHistorico.dgvHistorico.Rows.Clear();
                foreach (Alquiler p in administracion.VerHistorico().GetHistorico())
                {

                    string datos = p.getClinete().Nombre + ";" + p.getClinete().Dni + ";" + p.getClinete().Telefono + ";" + Convert.ToString(p.getAcompañantes().Length) + ";" + p.Auto.Marca + ";" + p.Auto.Patente + ";" + p.Auto.Kms;

                    historico = datos.Split(';');
                    verHistorico.dgvHistorico.ColumnCount = historico.Length;
                    verHistorico.dgvHistorico.Rows.Add(historico);

                }
            }
        }

        private void alquilerVigenteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Borrar Alquiler Vigente
            AlquileresVigentes ventana = new AlquileresVigentes();
            ventana.btnFinalizar.Hide();
            ventana.label1.Hide();
            ventana.textBox1.Hide();
            ventana.dateTimePicker1.Hide();
            ventana.btnEliminar.Show();
            
            string[] alquileres;

            foreach (Alquiler p in administracion.GetAlquileres())
            {


                string datos = p.getClinete().Nombre + ";" + p.getClinete().Dni + ";" + p.getClinete().Telefono + ";" + Convert.ToString(p.DiasDeAlquiler) + ";" + p.Auto.Marca + ";" + p.Auto.Patente + ";" + p.Auto.Kms + ";" + (p.Auto.PrecioAlquiladoEnUDC * p.PrecioAlquilado * p.DiasDeAlquiler);

                alquileres = datos.Split(';');
                ventana.dgvAlquileres.ColumnCount = alquileres.Length;
                ventana.dgvAlquileres.Rows.Add(alquileres);


            }


            while (ventana.ShowDialog() == DialogResult.Yes) {

                administracion.GetAlquileres()[ventana.dgvAlquileres.CurrentRow.Index].Auto.Disponible = true;
                administracion.GetAlquileres().RemoveAt(ventana.dgvAlquileres.CurrentRow.Index);


                ActualizarListboxs();


                ventana.dgvAlquileres.Rows.Clear();

                foreach (Alquiler p in administracion.GetAlquileres())
                {


                    string datos = p.getClinete().Nombre + ";" + p.getClinete().Dni + ";" + p.getClinete().Telefono + ";" + Convert.ToString(p.DiasDeAlquiler) + ";" + p.Auto.Marca + ";" + p.Auto.Patente + ";" + p.Auto.Kms + ";" + (p.Auto.PrecioAlquiladoEnUDC * p.PrecioAlquilado * p.DiasDeAlquiler);

                    alquileres = datos.Split(';');
                    ventana.dgvAlquileres.ColumnCount = alquileres.Length;
                    ventana.dgvAlquileres.Rows.Add(alquileres);


                }
            }
        }
    }
}
