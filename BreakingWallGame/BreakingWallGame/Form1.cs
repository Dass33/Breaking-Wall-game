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
        //player
        int mintXPlayer, mintYPlayer;
        int mintPohybXPlayer;

        bool boolMoveLeftPlayer;
        bool boolKulickaOdrazena;

        //konstanty => nemeni se v prubehu programu
        const int mintWidthPlayer = 100;
        const int mintHeightPlayer = 20;
        const float mfloatHeightOfPlayer = 1.2f;
        const int mintRadiusKulicky = 23;
        const int mintRychlostPosunu = 5;
        const int tmrRedrawSpeed = 20;

        private void Form1_Load(object sender, EventArgs e)
        {
            //init Timeru 
            tmrRedraw.Interval = tmrRedrawSpeed;
            tmrRedraw.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                boolMoveLeftPlayer = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                boolMoveLeftPlayer = false;
            }
        }

        public Form1()
        {
            InitializeComponent();
            InitPromenych();
            
        }

        private void InitPromenych()
        {
            //init grafiky, ktera kresli na platno
            mobjGrafika = pbplatno.CreateGraphics();

            //init promenych kulicky
            mintXKulicky = pbplatno.Width / 2;
            mintYKulicky = pbplatno.Height / 2;
            mintPohybX = mintRychlostPosunu;
            mintPohybY = mintRychlostPosunu;
            mintYPlayer = (int)(pbplatno.Height / mfloatHeightOfPlayer);

            //init promenych hrace
            mintXPlayer = pbplatno.Width / 2;
            mintPohybXPlayer = mintRychlostPosunu;

            //init Postaveni zdi

            //spocitani kolik bloku zdi se ma vzkreslit a jak velke mezerz maji byt po stranach 
            //vydeli sirku pbplatno velikosti jednotlivych bloku (cihel) + mezer mezi nimi
            //ke zbztku pricte velikost jedne mezery a ten nasledne rozdeli na dva dili => mezery od okarju
            //if statmenty kontroluji jestli neni prave vykreslovany blok prvni nebo posledni 

            //for loop ktery vykresluje nove bloky v tolika radach kolik je zadano
        }

        //kontroluje jestli kulicka prave nenarazi do nektereho z objektu (Zed), nebo hrace
        public void DetekceNarazuKulicky(int mintX, int mintY, int mintWidthObject, int mintHeightObject)
        {
            if ((mintYKulicky + mintRadiusKulicky >= mintY) &&
                (mintYKulicky + mintRadiusKulicky <= mintY + mintHeightObject) &&
                (mintXKulicky >= mintX) && (mintXKulicky <= mintX + mintWidthObject))
            {
                boolKulickaOdrazena = true;
            }
            else boolKulickaOdrazena = false;
        }
            private void tmrRedraw_Tick(object sender, EventArgs e)
        {
            //smazat scenu
            mobjGrafika.Clear(Color.White);

            //vykresleni kulicky
            mobjGrafika.FillEllipse(Brushes.Red, mintXKulicky, mintYKulicky, mintRadiusKulicky, mintRadiusKulicky);

            //posun kulicky
            mintXKulicky += mintPohybX;
            mintYKulicky += mintPohybY;

            //detekce jestli kulicka narazi na hrace
            DetekceNarazuKulicky(mintXPlayer, mintYPlayer, mintWidthPlayer, mintHeightPlayer);

            //pokud kulicka narazi do steny, stropu nebo hrace odrazi se opacnym smerem => *(-1)
            if (mintYKulicky < 0 || boolKulickaOdrazena) //(mintYKulicky + mintRadiusKulicky) > pbplatno.Height || //Vratit nazpatek pokud se kulicka odrayi od spodni hrany)
            {
                mintPohybY = mintPohybY * (-1);
            }
            if ((mintXKulicky + mintRadiusKulicky) > pbplatno.Width || mintXKulicky < 0)
            {
                mintPohybX = mintPohybX * (-1);
            }

            //vykresleni odrazeci plochy
            mobjGrafika.FillRectangle(Brushes.DarkGray, mintXPlayer, mintYPlayer, mintWidthPlayer, mintHeightPlayer);

            //posun hrace
            if (boolMoveLeftPlayer && mintXPlayer > 0)
            {
                mintXPlayer -= mintPohybXPlayer;
            }
            if (boolMoveLeftPlayer == false && mintXPlayer < (pbplatno.Width - mintWidthPlayer))
            {
                mintXPlayer += mintPohybXPlayer;
            }

            //konec hry
            if(mintYKulicky > pbplatno.Height)
            {
                InitPromenych();
            }
        }
    }
}