﻿// class míčku 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp6
{
    public class clsBall
    {
        //Variables

        // Class of ball - deklarace , objekt ze třídy
       


        //Graphics
        Graphics mobjGrafika;

        // Ball variables
        int mintXBall, mintYBall;
        
        public int mintVectorX, mintVectorY;
        const int mintRBall = 10;
        const int mintShiftSpeed = 4;
        const int mintRychlostPosunu = 10;
        public bool blSpodniHranaMic = false;
        

        //----------------------------
        //Constructor
        //----------------------------
        public clsBall(Graphics objCanvas)
        { 
            mobjGrafika = objCanvas;

            mintXBall = (int)objCanvas.VisibleClipBounds.Width / 2;
            mintYBall = (int)objCanvas.VisibleClipBounds.Height / 2;
            mintVectorX = mintRychlostPosunu;
            mintVectorY = mintRychlostPosunu;
        }

        //načtení hodnot souřadnic 
        public int intXK   //property
        {
            get
            {
                return mintXBall;
            }
            set
            { mintXBall = value; }
        }
        public int intYK   //property
        {
            get
            {
                return mintYBall;
            }
            set { mintYBall = value; }
        }
        public int intWK   //property
        {
            get
            {
                return mintRBall;
            }
            
        }
        public int intHK   //property
        {
            get
            {
                return mintRBall;
            }
        }

        //Ball set to center and adding start bt
        //Done like that to use it in other lines
        //of code without writing too many lines

        public void BallSetToCenter(Graphics objCanvas)
        {
            mobjGrafika = objCanvas;

            mintXBall = (int)objCanvas.ClipBounds.Width / 2;
            mintYBall = (int)objCanvas.ClipBounds.Height / 2;

            mintVectorX = 0;
            mintVectorY = 0;
        }


        public void Vector(Graphics objCanvas)
        {
            //Drawing  of ball
            mobjGrafika.FillEllipse(Brushes.Black, mintXBall, mintYBall, mintRBall, mintRBall);

            

            //shift

            mintXBall += mintVectorX;
            mintYBall += mintVectorY;

            //koliza hran pbCanvasu - odraz
            if (mintYBall + mintRBall >= (int)objCanvas.VisibleClipBounds.Height || mintYBall <= 0)
            {
                mintVectorY = mintVectorY * (-1);
            }
            else if (mintXBall + mintRBall >= (int)objCanvas.VisibleClipBounds.Width || mintXBall <= 0)
            {
                mintVectorX = mintVectorX * (-1);
            }
            //podmínka pro spodní hranu 
            else if (mintYBall + mintRBall >= (int)objCanvas.VisibleClipBounds.Height )
            {
                blSpodniHranaMic = true;
            }
        }
        public void StartOfTheBall()
        {
            mintVectorX = mintShiftSpeed;
            mintVectorY = mintShiftSpeed;
        }
        public bool TestkolizeVozik(int intXVozik, int intYVozik, int intWVozik, int intHVozik)
        {
         Rectangle rectangleBall = new Rectangle(mintXBall, mintYBall, mintRBall, mintRBall);
      
          Rectangle rectangleVozik = new Rectangle(intXVozik, intYVozik, intWVozik, intHVozik);
            if (rectangleBall.IntersectsWith(rectangleVozik))
            {
                mintVectorY = mintVectorY * (-1);
                mintVectorX = mintVectorX * (-1);
                return true;
            }
            else
            {
                return false;
            }

        }

    }
   
}
