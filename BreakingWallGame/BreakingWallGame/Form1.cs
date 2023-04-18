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

        bool boolKulickaOdrazena;

        const int mintRadiusKulicky = 24;
        const float mfloatHeightOfKulicky = 1.3f;
        //player
        int mintXPlayer, mintYPlayer;
        int mintPohybXPlayer;

        bool boolMoveLeftPlayer;

        const int mintWidthPlayer = 120;
        const int mintHeightPlayer = 25;
        const int mintMomentumOdrazuPlayer = 3;
        const float mfloatHeightOfPlayer = 1.2f;
        //zed
        int mintPocetBloku, mintMezeraStrany;
        int mintXBloku = 0, mintYBloku = 0;

        const int mintXmezeraBloku = 115; 
        const int mintYmezeraBloku = 50;
        const int mintPocetRadBloku = 4;
        const int mintWidthBloku = 90;
        const int mintHeightBloku = 30;

        int[] marrZnicenebloky;
        int mintPoradiRady = 0;
        //end screen 
        const int mintMezeraElemntu = 80;
        //skore
        int mintSkore = 0;

        //konstanty => nemeni se v prubehu programu
        const int mintRychlostPosunu = 7;
        const int tmrRedrawSpeed = 20;
        const int mintMarginOfError = 15;

        private void Form1_Load(object sender, EventArgs e)
        {
            //init Timeru 
            tmrRedraw.Interval = tmrRedrawSpeed;
            tmrRedraw.Start();
        }

        //funkce pro restart hry
        private void btStartOver_Click(object sender, EventArgs e)
        {
            mintSkore = 0;
            mintPoradiRady = 0;

            btStartOver.Enabled = false;
            btStartOver.Visible = false;

            lbGameOver.Enabled = false;
            lbGameOver.Visible = false;

            InitPromenych();
            tmrRedraw.Start();

            //puts focus back on the form and keeps my sanity, delete at your own discretion
            this.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //po zmacknuti mezerniku meni smer kterym se pohybuje hrac
            if (e.KeyCode == Keys.Space && boolMoveLeftPlayer == false)
            {
                boolMoveLeftPlayer = true;
            }
            else if (e.KeyCode == Keys.Space)
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
            mintYKulicky = (int)(pbplatno.Height / mfloatHeightOfKulicky);
            mintPohybX = mintRychlostPosunu;
            mintPohybY = mintRychlostPosunu;
            mintYPlayer = (int)(pbplatno.Height / mfloatHeightOfPlayer);

            //init promenych hrace
            mintXPlayer = pbplatno.Width / 2;
            mintPohybXPlayer = (int)(mintRychlostPosunu * 1.4);

            //spocitani kolik bloku zdi se ma vzkreslit a jak velke mezery maji byt po stranach
            mintPocetBloku = pbplatno.Width / mintXmezeraBloku;
            //urceni delky array, tak aby v ni bylo misto pro vsechny bloky
            //vymeneni defaultni nuly za -1, aby hra nezacala s chybejcim prvnim dilkem
            marrZnicenebloky = Enumerable.Repeat(-1, mintPocetRadBloku * (int)mintPocetBloku).ToArray();
            // zjisti zbztek deleni sirky pbplatno velikosti mezer bloku (cihel)
            //pricte velikost rozdilu jedne mezery a velikosti bloku ten nasledne rozdeli na dva dili => mezery od okarju
            mintMezeraStrany = (pbplatno.Width % mintXmezeraBloku / 2) + (mintXmezeraBloku - mintWidthBloku) / 2;

            //skore
            lbScore.Enabled = true;
            lbScore.ForeColor = Color.Black;
            lbScore.Font = new Font("Arial", 30, FontStyle.Bold);
            lbScore.Text = "Skore: 0";
            lbScore.Location = new Point(pbplatno.Width / 2 - lbScore.Width /2, pbplatno.Height);
        }

        //kontroluje jestli kulicka prave nenarazi do nektereho z objektu (Zed), nebo hrace
        public void DetekceNarazuKulicky(int mintX, int mintY, int mintWidthObject, int mintHeightObject)
        {
            if ((mintYKulicky + mintRadiusKulicky >= mintY) &&
                (mintYKulicky + mintRadiusKulicky <= mintY + mintMarginOfError) &&
                (mintXKulicky + mintRadiusKulicky >= mintX) && 
                (mintXKulicky <= mintX + mintWidthObject))
            {
                //odrzeni kulicky
                mintPohybY = mintPohybY * (-1);
                boolKulickaOdrazena = true;
                
                //pokud odrzeno hracem ziska kulicka cast momenta hrace
                if (mintY == mintYPlayer && boolMoveLeftPlayer)
                {
                    mintPohybX= mintPohybX + (mintPohybXPlayer / mintMomentumOdrazuPlayer) * (-1);
                    mintPohybY = mintPohybY + 1/ mintMomentumOdrazuPlayer * mintMomentumOdrazuPlayer;
                }
                else if (mintY == mintYPlayer && boolMoveLeftPlayer == false)
                {
                    mintPohybX = mintPohybX + (mintPohybXPlayer / mintMomentumOdrazuPlayer);
                    mintPohybY = mintPohybY + 1 / mintMomentumOdrazuPlayer * mintMomentumOdrazuPlayer;
                }
                else if (mintY != mintYPlayer)
                {
                    //zvyseni skore
                    mintSkore++;
                    lbScore.Text = "Skore: " + mintSkore;
                }
            }
            else boolKulickaOdrazena = false;
        }
        private void tmrRedraw_Tick(object sender, EventArgs e)
        {
            //for development purpuses delete awfter testing finished
            tsMouseCor.Text = "Mouse X: " + MousePosition.X + " Y: " + MousePosition.Y;
            tsPlayerCor.Text = "Player X: " + mintXPlayer + " Y: " + mintYPlayer;

            //smazani sceny
            mobjGrafika.Clear(Color.White);

            //for loop ktery vykresluje nove bloky v tolika radach kolik je zadano
            mintYBloku += mintYmezeraBloku;
            for (int i = 0, a = 0; i < mintPocetRadBloku * mintPocetBloku; i++, a++)
            {
                if (a == mintPocetBloku)
                {
                    //vykresleni dalsi rady posunute dolu
                    mintYBloku += mintYmezeraBloku;
                    a = 0;
                }

                //prvni blok veliost mintMezeraStrany se pouzije misto mintXmezera
                if (a == 0)
                {
                    mintXBloku = mintMezeraStrany;
                }
                else mintXBloku += mintXmezeraBloku;
                                             
                if (marrZnicenebloky == null || (!Array.Exists(marrZnicenebloky, element => element == a + i * mintPocetBloku)))
                {
                    mobjGrafika.FillRectangle(Brushes.DarkBlue, mintXBloku, mintYBloku, mintWidthBloku, mintHeightBloku);
                    //pri detekovani narazu kulicky zvisujeme hodnotu Y tak aby hitbox odpovida stredu bloku
                    DetekceNarazuKulicky(mintXBloku, mintYBloku + mintHeightBloku, mintWidthBloku, mintHeightBloku);

                    if (boolKulickaOdrazena)
                    {
                        //ulozeni souradnic jednotlivizch znicenzch bloku
                        //a udave x souradnici a i * mintPocetBloku udava y souradnici
                        marrZnicenebloky[mintPoradiRady] = a + i * mintPocetBloku;
                        mintPoradiRady++;
                    }
                }            
            }
            mintXBloku = mintYBloku = 0;
        
            //posun kulicky
            mintXKulicky += mintPohybX;
            mintYKulicky += mintPohybY;
            //vykresleni kulicky
            mobjGrafika.FillEllipse(Brushes.Red, mintXKulicky, mintYKulicky, mintRadiusKulicky, mintRadiusKulicky);

            //detekce jestli kulicka narazi na hrace
           
            DetekceNarazuKulicky(mintXPlayer, mintYPlayer, mintWidthPlayer, mintHeightPlayer);
                
            //pokud kulicka narazi do steny, stropu nebo hrace odrazi se opacnym smerem => *(-1)
            if (mintYKulicky < 0) //odrzeni od spodni hrany: || (mintYKulicky + mintRadiusKulicky) > pbplatno.Height
            {
                mintYKulicky= 0;
                mintPohybY = mintPohybY * (-1);
            }
            if ((mintXKulicky + mintRadiusKulicky) > pbplatno.Width || mintXKulicky < 0)
            {
                mintPohybX = mintPohybX * (-1);
            }

            //vykresleni odrazeci plochy
            mobjGrafika.FillRectangle(Brushes.DarkGray, mintXPlayer, mintYPlayer, mintWidthPlayer, mintHeightPlayer);

            //posun hrace pokud je v rozmezi platna
            if (mintXPlayer >= 0 && boolMoveLeftPlayer)
            {
                mintXPlayer -= mintPohybXPlayer;
            }
            else if (mintXPlayer < (pbplatno.Width - mintWidthPlayer) && boolMoveLeftPlayer == false)
            {
                mintXPlayer += mintPohybXPlayer;
            }

            //konec hry
            if (mintYKulicky > pbplatno.Height)
            {                
                tmrRedraw.Stop();

                //tlacitko pro restart hry
                btStartOver.BackColor = Color.DarkBlue;
                btStartOver.Enabled = true;
                btStartOver.Text = "Start Again";
                btStartOver.ForeColor = Color.WhiteSmoke;
                btStartOver.Font = new Font("Arial", 30, FontStyle.Bold);
                btStartOver.Width = (int)(pbplatno.Width /2.5f);
                btStartOver.Height = pbplatno.Height /7;
                btStartOver.Location = new Point(pbplatno.Width / 2 - btStartOver.Width / 2, pbplatno.Height / 2 - btStartOver.Height / 2 + mintMezeraElemntu);
                btStartOver.Visible = true;

                //Game over text
                lbGameOver.Location = new Point(pbplatno.Width /2 - lbGameOver.Width /2, pbplatno.Height /2 - lbGameOver.Height /2 - mintMezeraElemntu);
                lbGameOver.Visible = true;
            }
            if (!Array.Exists(marrZnicenebloky, element => element == -1))
            {
                //Game over text
                lbGameOver.Text = "You Won!!";
                lbGameOver.Location = new Point(pbplatno.Width / 2 - lbGameOver.Width / 2, pbplatno.Height / 2 - lbGameOver.Height / 2 - mintMezeraElemntu);
                lbGameOver.Visible = true;
            }    
        }
    }
}