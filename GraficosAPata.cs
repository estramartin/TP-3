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
    public partial class GraficosAPata : Form
    {
        int vConChofer, vSinChofer;

        public GraficosAPata(int vConChofer, int vSinChofer)
        {
            InitializeComponent();

            this.vConChofer = vConChofer * 50;
            this.vSinChofer = vSinChofer * 50;

        }

        private void GraficosAPata_Paint(object sender, PaintEventArgs e)
        {
            // marco

            // marco

            Graphics g = e.Graphics;

            Brush pincel = new SolidBrush(Color.Black);
            Pen lapiz = new Pen(pincel);
            Brush pincel2 = new SolidBrush(Color.Blue);
            Pen lapiz2 = new Pen(pincel2);
            Brush pincel3 = new SolidBrush(Color.Orange);
            Pen lapiz3 = new Pen(pincel3);
            int margen = 30;

            int h = this.ClientSize.Height;
            int w = this.ClientSize.Width;

            //marco interior
            int xm = margen;
            int ym = margen;
            int hm = h - 2 * 50;
            int wm = w - 2 * margen;


            g.DrawRectangle(lapiz, xm, ym, wm, hm);

            //barras

            int cantBarras = 2;
            int wb = wm / cantBarras;

            //graficos primera barra
            {
                int yi = vConChofer;

                int i = 0;
                int xbi = margen + i * wb;
                int ybi = hm + ym - yi;
                int hbi = yi;



                g.FillRectangle(pincel3, xbi, ybi, wb, hbi);


            }

            {
                //datos de la segunda barra
                int yi = vSinChofer;

                //iteración uno
                int i = 1;

                //dibujo barra uno
                int xbi = margen + i * wb;
                int ybi = hm - yi + margen;
                int hbi = yi;
                g.FillRectangle(pincel2, xbi, ybi, wb, hbi);




            }
        }
    }
}
