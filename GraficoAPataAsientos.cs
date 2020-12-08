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
    public partial class GraficoAPataAsientos : Form
    {
        SortedDictionary<int, int> agrupados = new SortedDictionary<int, int>();

        public GraficoAPataAsientos(SortedDictionary<int,int> agrupados)
        {
            InitializeComponent();

            this.agrupados = agrupados;
        }

        private void GraficoAPataAsientos_Load(object sender, EventArgs e)
        {






        }

        private void GraficoAPataAsientos_Paint(object sender, PaintEventArgs e)
        {

            int tamaño = agrupados.Count;


            //datos de entrada
            int[] xs = new int[tamaño];
            int[] ys = new int[tamaño];

            xs = agrupados.Keys.ToArray();
            ys = agrupados.Values.ToArray();

            Graphics g = e.Graphics;
            Brush brush = new SolidBrush(Color.Black);
            Pen pen = new Pen(brush);
           

            int mg = 30;
            int h = this.ClientSize.Height;
            int w = this.ClientSize.Width;

            //marco
            int xm = mg;
            int ym = mg;
            int hm = h - 2 *70;
            int wm = w - 2 * mg;
            g.DrawRectangle(pen, xm, ym, wm, hm);

            //barras
            int max = ys[0];
            for (int i = 1; i < ys.Length; i++)
            {
                if (max < ys[i])
                    max = ys[i];
            }
            double k = 1.0 * hm / max;


            int cantBar = ys.Length;
            int wb = wm / cantBar;

            for (int i = 0; i < ys.Length; i++)
            {
                //datos de cada barra
                int xi = xs[i], yi = (int)(k * ys[i]);

                int xbi = mg + i * wb;
                int ybi = (hm - yi + mg);
                int hbi = yi;

                switch (i) {
                    case 0: { brush = new SolidBrush(Color.Red);label1.Text = xs[0].ToString(); label1.ForeColor = Color.Red; label36.Text = ys[0].ToString(); label36.ForeColor = Color.Red; break; }
                    case 1: { brush = new SolidBrush(Color.Blue);label2.Text = xs[1].ToString(); label2.ForeColor = Color.Blue; label35.Text = ys[1].ToString(); label35.ForeColor = Color.Blue; break; }                
                    case 2: { brush = new SolidBrush(Color.Orange); label3.Text = xs[2].ToString(); label3.ForeColor = Color.Orange; label34.Text = ys[2].ToString(); label34.ForeColor = Color.Orange; break; }
                    case 3: { brush = new SolidBrush(Color.DarkGreen); label4.Text = xs[3].ToString(); label4.ForeColor = Color.DarkGreen; label33.Text = ys[3].ToString(); label33.ForeColor = Color.DarkGreen; break; }
                    case 4: { brush = new SolidBrush(Color.Yellow); label5.Text = xs[4].ToString(); label5.ForeColor = Color.Yellow; label32.Text = ys[4].ToString(); label32.ForeColor = Color.Yellow; break; }
                    case 5: { brush = new SolidBrush(Color.Coral); label6.Text = xs[5].ToString(); label6.ForeColor = Color.Coral; label31.Text = ys[5].ToString(); label31.ForeColor = Color.Coral; break; }
                    case 6: { brush = new SolidBrush(Color.BurlyWood); label7.Text = xs[6].ToString(); label7.ForeColor = Color.BurlyWood; label30.Text = ys[6].ToString(); label30.ForeColor = Color.BurlyWood; break; }
                    case 7: { brush = new SolidBrush(Color.Aqua); label8.Text = xs[7].ToString(); label8.ForeColor = Color.Aqua; label29.Text = ys[7].ToString(); label29.ForeColor = Color.Aqua; break; }
                    case 8: { brush = new SolidBrush(Color.Beige); label9.Text = xs[8].ToString(); label9.ForeColor = Color.Beige; label28.Text = ys[8].ToString(); label28.ForeColor = Color.Beige; break; }
                    case 9: { brush = new SolidBrush(Color.Chartreuse); label10.Text = xs[9].ToString(); label10.ForeColor = Color.Chartreuse; label27.Text = ys[9].ToString(); label27.ForeColor = Color.Chartreuse; break; }
                    case 10: { brush = new SolidBrush(Color.Magenta); label11.Text = xs[10].ToString(); label11.ForeColor = Color.Magenta; label26.Text = ys[10].ToString(); label26.ForeColor = Color.Magenta; break; }
                    case 11: { brush = new SolidBrush(Color.BlueViolet); label12.Text = xs[11].ToString(); label12.ForeColor = Color.BlueViolet; label25.Text = ys[11].ToString(); label25.ForeColor = Color.BlueViolet; break; }
                    case 12: { brush = new SolidBrush(Color.Violet); label13.Text = xs[12].ToString(); label13.ForeColor = Color.Violet; label24.Text = ys[12].ToString(); label24.ForeColor = Color.Violet; break; }
                    case 13: { brush = new SolidBrush(Color.GreenYellow); label14.Text = xs[13].ToString(); label14.ForeColor = Color.GreenYellow; label23.Text = ys[13].ToString(); label23.ForeColor = Color.GreenYellow; break; }
                    case 14: { brush = new SolidBrush(Color.Lime); label15.Text = xs[14].ToString(); label15.ForeColor = Color.Lime; label22.Text = ys[14].ToString(); label22.ForeColor = Color.Lime; break; }
                    case 15: { brush = new SolidBrush(Color.LightGray); label16.Text = xs[15].ToString(); label16.ForeColor = Color.LightGray; label21.Text = ys[15].ToString(); label21.ForeColor = Color.LightGray; break; }
                    case 16: { brush = new SolidBrush(Color.DarkKhaki); label17.Text = xs[16].ToString(); label17.ForeColor = Color.DarkKhaki; label20.Text = ys[16].ToString(); label20.ForeColor = Color.DarkKhaki; break; }
                    default: { brush = new SolidBrush(Color.Black); break; }
                }
                
                g.FillRectangle(brush, xbi, ybi, wb, hbi);

            }
        }
    }
}
