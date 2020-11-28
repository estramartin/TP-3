using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agencia_Autos
{
    public partial class GenerarAlquiler : Form
    {
        public string path1;
        public string path2;
        public string pathTitular;
        public GenerarAlquiler()
        {
            InitializeComponent();
           
            gbConductor1.Hide();
            gbConductor2.Hide();
         
            this.Size = new Size(1128, 718);
            this.btnAlquilar.Location = new Point(685, 374);
            this.btnSalir.Location = new Point(57, 374);


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_Click(object sender, EventArgs e)
        {



            


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
            
            if (comboBox1.SelectedIndex < 1)
            {
                this.Size = new Size(1128, 718);
                this.btnAlquilar.Location = new Point(685, 374);
               this.btnSalir.Location = new Point(377, 374);
               
            }

            else
            {
                this.Size = new Size(1128, 984);
                this.btnAlquilar.Location = new Point(692, 771);
                this.btnSalir.Location = new Point(35, 768);
                if (comboBox1.SelectedIndex == 1) { gbConductor1.Show(); gbConductor2.Hide(); }
                if (comboBox1.SelectedIndex == 2) { gbConductor1.Show(); gbConductor2.Show(); }
                
            }
        }

        private void GenerarAlquiler_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImagen1_Click(object sender, EventArgs e)
        {

            openFileFotos.ShowDialog();
            pbConductor1.Image = Image.FromFile(openFileFotos.FileName);
            path1 = openFileFotos.FileName;



        }

        private void btnImagen2_Click(object sender, EventArgs e)
        {
            openFileFotos.ShowDialog();
            pbConductor2.Image = Image.FromFile(openFileFotos.FileName);
            path2 = openFileFotos.FileName;

        }

        private void btnCargarFotoTitular_Click(object sender, EventArgs e)
        {
            openFileFotos.ShowDialog();
            pbTitular.Image = Image.FromFile(openFileFotos.FileName);
            pathTitular = openFileFotos.FileName;
        }
    }
}
