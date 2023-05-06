using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp6
{
    public class clsVozik
    {
        //Graphics
        Graphics mobjGrafika;

        // Brick variables
        int mintXVozik, mintYVozik;
        int mintVyskaVozik, mintSirkaVozik;

        //----------------------------
        //Constructor
        //----------------------------
        
        public clsVozik(Graphics objCanvas, int intXVozik, int intYVozik, int intSirkaVozik, int intVyskaVozik)
        {
            mobjGrafika = objCanvas;
            mintXVozik = intXVozik;
            mintYVozik = intYVozik;
            mintVyskaVozik = intVyskaVozik;
            mintSirkaVozik = intSirkaVozik;
        }
        public int intXVozik
        {
            get
            {
                return mintXVozik;
            }
            set
            {
                mintXVozik = value;           //s value je to public
            }

        }
        public int intYVozik
        {
            get
            {
                return mintYVozik;
            }
        }
        public int intSirkaVozik
        {
            get
            {
                return mintSirkaVozik;
            }
        }
        public int intVyskaVozik
        {
            get
            {
                return mintVyskaVozik;
            }
        }

        public void NakresliSe()
        {
           
            //vykreslení
            mobjGrafika.FillRectangle(Brushes.Blue,mintXVozik, mintYVozik, mintSirkaVozik, mintVyskaVozik);
            
        }
    }
    
}
