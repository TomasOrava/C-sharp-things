using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_test
{
    internal class clsTimer

    {

        //interval v milisekundach  , za úkol nastavení na mikro, máhodnotu 1 zadanou z formu řadek 35 button 1 click 
        int mintIntervalIn_ms;

        Thread mobjVlakno1; //thread pro časování timeru 
  
        bool mblStop;// zastavit thread 

        // definice tavru eventu 
        public delegate void dlgTick(); //deklarce ukazatele na funkci, delegat je ukazatel 
        //deklarace eventu ticku 
        public event dlgTick Tick;

        //formulář kde existuje můj objekt 
        public Form1 mobjForm;

        public int Interval
        {

            get { return mintIntervalIn_ms; }   
            set { mintIntervalIn_ms = value;}
                

        }

        //-------------------------------------------------------------------------------------------------
        // konstruktor timeru
        //-------------------------------------------------------------------------------------------------
        public clsTimer(int intIntervalIN_ms)
        {
            mintIntervalIn_ms = Math.Abs(intIntervalIN_ms);
            mobjForm = null;
        }


        //-------------------------------------------------------------------------------------------------
        // start timeru
        //-------------------------------------------------------------------------------------------------


       public bool Start()
        {
            // vytvoření threadu
            mobjVlakno1 = new Thread(MojeRutina);

            //spustit timer
            mblStop = false;
            
            //mobjVlakno1.Priority = ThreadPriority.Highest;
            mobjVlakno1.Start();


            return true;
        }

        private void MojeRutina()
        {
            do
            {
                //zavolat eventy v threadu formuláře 
                if (mobjForm != null) //=! - nerovná se 
                mobjForm.Invoke(Tick);

                //upravit tak aby thread běžěl v mikrosekundách - funkce DateTime.Ticks  - -něco vrací - smyčka která čte - tik za 1 až tisíc mikroseknud - timer využívá jedno jádro - pomocí ticks 


                //pozastavit thread
                //
                //Thread.Sleep(mintIntervalIn_ms);
                

              //  do
                //{
                    // DateTime
                    TimeSpan.FromMilliseconds(mintIntervalIn_ms / 1000); //převedení na mikrosekundy, v class nastavené timer = 1, (1 tick je o,1 mikrosekundy)
              //  } while (mobjForm == this);

                 
            } while (mblStop == false);


        }




        //-------------------------------------------------------------------------------------------------
        // stop timeru
        //-------------------------------------------------------------------------------------------------
        public bool Stop()
        {
            mobjForm = null;
            //zastavit thread
            mblStop = true;
            return true;
        }
    }
}

  
    
    
   
