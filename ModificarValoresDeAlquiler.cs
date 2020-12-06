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
    [Serializable]
    public partial class ModificarValoresDeAlquiler : Form
    {
        public ModificarValoresDeAlquiler()
        {
            InitializeComponent();
        }

        private void ModificarValoresDeAlquiler_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
