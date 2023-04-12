using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BreakingWallGame
{
    public partial class Form1 : Form
    {

        //grafika pro krelsleni
        Graphics mobjGrafika;

        //kulicka
        int mintXKulicky, mintYKulicky;
        int mintPohybX, mintPohybY;
        const int mintRKulicky = 15;
        const int mintRychlostPosunu = 3;
        const int tmrRedrawSpeed = 20;

        private void Form1_Load(object sender, EventArgs e)
        {
            //init Timeru 
            tmrRedraw.Interval = tmrRedrawSpeed;
            tmrRedraw.Start();
        }

        public Form1()
        {
            InitializeComponent();

            //init promenych
            mobjGrafika = pbplatno.CreateGraphics();
            mintXKulicky = pbplatno.Width / 2;
            mintYKulicky = pbplatno.Height / 2;
            mintPohybX = mintRychlostPosunu;
            mintPohybY = mintRychlostPosunu;
        }

        private void tmrRedraw_Tick(object sender, EventArgs e)
        {
            //smazat scenu
            mobjGrafika.Clear(Color.White);

            //vykresleni kulicky
            mobjGrafika.FillEllipse(Brushes.Red, mintXKulicky, mintYKulicky, mintRKulicky, mintRKulicky);

            //posun
            mintXKulicky += mintPohybX;
            mintYKulicky += mintPohybY;

            if ((mintYKulicky + mintRKulicky) > pbplatno.Height || (mintYKulicky + mintRKulicky) < 0)
            {
                mintPohybY = mintPohybY * (-1);
            }
            if ((mintXKulicky + mintRKulicky) > pbplatno.Width || (mintXKulicky + mintRKulicky) < 0)
            {
                mintPohybX = mintPohybX * (-1);
            }
        }
    }
}
