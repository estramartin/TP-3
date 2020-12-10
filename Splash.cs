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
    public partial class Splash : Form
    {
        public Splash(int segundos)
        {
            InitializeComponent();
            tempo.Interval = segundos * 1000;

            progressBar1.Maximum = 100000000;
            progressBar1.Minimum = 0;
            progressBar1.Value = 0;
            progressBar1.Step = 1;
            for (int i = progressBar1.Minimum; i < progressBar1.Maximum; i = i + progressBar1.Step) { progressBar1.PerformStep(); }

            tempo.Start();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tempo_Tick(object sender, EventArgs e)
        {
            tempo.Stop();
            Close();
        }
    }
}
