﻿using System;
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
      
      
        

        // Class of ball
        clsBall mobjBall;

        //grafika pro kereslení 
        Graphics mobjGrafika;

        
        

        //pole cihel 
        int mintPocetCihel;
        clsBrick[] mobjBrick;
        const int mintSirkaCihly = 80, mintVyskaCihly = 20;
        const int mintVelikostMezery = 20, mintPocetRadCihel = 1;

        //Timer
        const int mintRychlostTimeru = 10;
        //classa vozik
        clsVozik mobjVozik;
        //vozik proměnný 
        int mintXVozik = 350, mintYVozik =400;

        //vozík proměnné posun
        bool goRight, goLeft;
        const int mintRychlostPosunuVozik = 8;
        const int mintVyskaVozik = 15, mintSirkaVozik = 70;
        //proměnné pro počet kolizí - míče a cihly 
        int mintPocetKolize = 0;
       


        //eventy key up a key down, klávesy A , D 
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.D)
            {
                goRight = false;
            }
        }

        private void retryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mobjBall.BallSetToCenter(mobjGrafika); // míč zpět na střed
            //nastavení počtu kolizí na nulu 
            //vykreslení všech cihel na novou hru 
                        foreach (clsBrick objBrick in mobjBrick)

            {
                objBrick.TestKolize(mobjBall.intXK, mobjBall.intYK, mobjBall.intWK, mobjBall.intHK);
                objBrick.NakresliSe();

            }

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.A)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.D)
            {
                goRight = true;
            }
        }

        

        public Form1()
        {
            

            InitializeComponent();
            //innit proměnných
            mobjGrafika = pbCanvas.CreateGraphics();
            //Create of ball
            mobjBall = new clsBall(mobjGrafika);
           
           

            //Variables

            int lintX, lintY;



            //init of variables
            mobjBall.Vector(mobjGrafika);
            //btStartGame.Visible = true;
            //vytvoření pole
            //mintPocetCihel = mintPocetRadCihel *
            //  ((pbCanvas.Width -mintVelikostMezery) /
            //(mintSirkaCihly + mintVelikostMezery));
            mintPocetCihel = 1;


            mobjBrick = new clsBrick[mintPocetCihel];
            //vytvoření voziku
           mobjVozik = new clsVozik(mobjGrafika,mintXVozik, mintYVozik,mintSirkaVozik, mintVyskaVozik );
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
            btExit.TabStop = false;
           // btStartGame.TabStop = false;

        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tmrPrekreslit_Tick(object sender, EventArgs e)
        {
            //smazání scény
            mobjGrafika.Clear(Color.White);
            
            

            //vykreslení voziku 
            mobjVozik.NakresliSe();


            // mobjGrafika.FillRectangle(Brushes.Blue, )

            //test kulize na hranách, změna pohybu  - minus 1 

            // vykreslení cihel - nepouživám
            //for (int i = 0; i < mintPocetCihel; i++)  //clsBrick objBrick in mobjBrick

            // {
            //    mobjBrick[i].NakresliSe();
            // }
            //vyvolání vectora
            mobjBall.Vector(mobjGrafika);


                //druhá možnost: foreach(ClsCihla objCihla in mobjCihla)
                //{objCihla.NakresliSe();}

                // test kolize všech cihel a vykreslení cihel 
                foreach (clsBrick objBrick in mobjBrick) 

            {
                objBrick.TestKolize(mobjBall.intXK, mobjBall.intYK, mobjBall.intWK, mobjBall.intHK);
                objBrick.NakresliSe();
                // odraz kulicky od voziku
              if(  objBrick.blBrickAndBall == true)
                {
                    objBrick.blBrickAndBall = false;
                   mobjBall.mintVectorX = mobjBall.mintVectorX * (-1) ;
                    mobjBall.mintVectorY = mobjBall.mintVectorY * (-1);

                }
              //podmínka když se dotkne míč cihly přičte se hodnota 1
              if (objBrick.blPocetKolize == true)
                {
                    mintPocetKolize += 1;
                    objBrick.blPocetKolize = false;
                }
                // message box výhra - podmínka
                if (mintPocetKolize == mintPocetCihel)
                {

                    mintPocetKolize = 0;

                    tmrPrekreslit.Stop();
                    MessageBox.Show("You have won!!!");
                   
                }
            }
               
            // pohyb voziku 
            
            if (goLeft == true && mobjVozik.intXVozik > 0)
            {
                mobjVozik.intXVozik -= mintRychlostPosunuVozik;
            }
            if (goRight == true && mobjVozik.intXVozik +mobjVozik.intSirkaVozik < pbCanvas.Width)
            {
                mobjVozik.intXVozik += mintRychlostPosunuVozik;
            }
            //test kolize odrazu míče od voziku 
            mobjBall.TestkolizeVozik( mobjVozik.intXVozik, mobjVozik.intYVozik, mobjVozik.intSirkaVozik, mobjVozik.intVyskaVozik);
           
            //message box pro prohru ------------nepoužívám- nefunguje
           // if (mobjBall.blSpodniHranaMic == true)
            //{
           //     MessageBox.Show("You have lost:(");
            //    
           // }
           //nový messagebox pro prohru 
           // if (mobjBall.intYK > mobjVozik.intYVozik)
           // {
            //    tmrPrekreslit.Stop();
            //    MessageBox.Show("You have lost  :(");
                
            //}

        }
    }
}
