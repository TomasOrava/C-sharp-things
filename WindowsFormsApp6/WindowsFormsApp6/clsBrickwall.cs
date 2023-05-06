using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp6
{
    public class clsBrick
    {
        //Variables

       

        //Graphics
        Graphics mobjGrafika;

        // Brick variables
        int mintXCihly, mintYCihly;
        int mintVyskaCihly, mintSirkaCihly;
        bool mblJeVidet;

        //----------------------------
        //Constructor
        //----------------------------

        public clsBrick(Graphics objCanvas, int intXBrick, int intYBrick, int mintSirkaBrick, int VyskaBrick )
        {
            mobjGrafika = objCanvas;
            mintXCihly = intXBrick;
            mintYCihly = intYBrick;
            mintVyskaCihly =  VyskaBrick;
            mintSirkaCihly =  mintSirkaBrick;
            mblJeVidet = true;
          
        }
        public void NakresliSe()
        {
            //test viditelnosti cihel 
            if (mblJeVidet == false) return;
            

            //vykreslení
            mobjGrafika.FillRectangle(Brushes.Orange, mintXCihly, mintYCihly, mintSirkaCihly, mintVyskaCihly);
            
        }

        //----------------------------
        //test kolize cihly a kulicky 
        //vrací true pokud došlo ke kolizi 
        //----------------------------
        public bool TestKolize(int intXK, int intYK, int intWK, int intHK)// proměnné kuličky
        {
            Rectangle rectangleBall = new Rectangle(intXK, intYK, intWK, intHK);
            Rectangle rectangleBrick = new Rectangle(mintXCihly, mintYCihly,mintSirkaCihly, mintVyskaCihly);
            //test viditelnosti cihel 
            if (mblJeVidet == false) return false;
         
            //test kolize
            if (rectangleBall.IntersectsWith(rectangleBrick))
            {
                //cihla už není vidět 
                mblJeVidet = false;
                return true;
            }
            else
            {
                return false;
            }
            
        }

    }
}
