using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        //Variables

        int lintX, lintY;


        // Class of ball
        clsBall mobjBall;

        //grafika pro kereslení 
        Graphics mobjGrafika;

        //kulička
        int mintXKulicky, mintYKulicky;
        int mintPohybX, mintPohybY;
       
        //poloměr jako konstanta
        const int mintRKulicky = 10;
        const int mintRychlostPosunu = 3;

        //pole cihel 
        int mintPocetCihel;
        clsBrick[] mobjBrick;
        const int mintSirkaCihly = 80, mintVyskaCihly = 20;
        const int mintVelikostMezery = 20, mintPocetRadCihel = 3;

        //Timer
        const int mintRychlostTimeru = 10;

        public Form1()
        {
            

            InitializeComponent();
            //innit proměnných
            mobjGrafika = pbCanvas.CreateGraphics();
            mintXKulicky = pbCanvas.Width/2;
            mintYKulicky = pbCanvas.Height/2;
            mintPohybX = mintRychlostPosunu;
            mintPohybY = mintRychlostPosunu;
         


            //Create of ball
            mobjBall = new clsBall(mobjGrafika);

            //init of variables
            mobjBall.BallSetToCenter(mobjGrafika);
            btStartGame.Visible = true;
            //vytvoření pole
            mintPocetCihel = mintPocetRadCihel *
                ((pbCanvas.Width -mintVelikostMezery) /
                (mintSirkaCihly + mintVelikostMezery));


            mobjBrick = new clsBrick[mintPocetCihel];


            //vytvoření cihel
            lintX = lintY = mintVelikostMezery;
            for (int i = 0; i< mintPocetCihel; i++)
            {
                //test zda bude vidět celá cihla
                if ((lintX + mintVelikostMezery + mintSirkaCihly) >pbCanvas.Width)
                {
                    lintX = mintVelikostMezery;
                    lintY = lintY + mintVyskaCihly + mintVelikostMezery;
                }
                //innit jedné cihly
                mobjBrick[i] = new clsBrick(mobjGrafika, lintX, lintY, mintSirkaCihly, mintVyskaCihly);
                // změna souřadnic
                lintX = lintX + mintSirkaCihly + mintVelikostMezery;
            }
                
            



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //innit timeru
            tmrPrekreslit.Interval = mintRychlostTimeru;
            tmrPrekreslit.Start();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tmrPrekreslit_Tick(object sender, EventArgs e)
        {
            //smazání scény
            mobjGrafika.Clear(Color.White);
            //vykreslení kuličky
            mobjGrafika.FillEllipse(Brushes.Black, mintXKulicky, mintYKulicky, mintRKulicky, mintRKulicky);
            //posun
            mintXKulicky += mintPohybX;
            mintYKulicky += mintPohybY;

            //test kulize na hranách, změna pohybu  - minus 1 
            if (((mintYKulicky + mintRKulicky) > pbCanvas.Height) ||
                (mintYKulicky < 0))
            {
                mintPohybY = mintPohybY * (-1);
            }
             
      
            if (((mintXKulicky + mintRKulicky) > pbCanvas.Width) ||
                (mintXKulicky < 0))
            {
                mintPohybX = mintPohybX * (-1);
            }
            // vykreslení cihel
            for (int i = 0; i < mintPocetCihel; i++)  //clsBrick objBrick in mobjBrick

            {
                mobjBrick[i].NakresliSe();
            }
            //druhá možnost: foreach(ClsCihla objCihla in mobjCihla)
            //{objCihla.NakresliSe();}

            // test kolize všech cihel 
            foreach (clsBrick objBrick in mobjBrick) 

            {
                objBrick.TestKolize(mobjBall.intXK, mobjBall.intYK, mobjBall.intWK, mobjBall.intHK);
            }
        }
    }
}
