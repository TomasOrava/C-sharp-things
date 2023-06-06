using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Text;

namespace Thread_test
{
    public partial class Form1 : Form
    {
        clsTimer mobjTimer; // nový timer!!!!!


        Thread mobjVlakno1;
       // int mintCt;
        object mobjSynchro;// nová proměnná --nejobecnější a nejednoduší´- nelze s ním nic dělat 
        bool mblStop;

        public Form1()
        {
            InitializeComponent();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //start nového timeru 
            mobjTimer = new clsTimer(1); // hazí hodnotu do classy
            mobjTimer.Tick += clsTimer_tick; // += tam musí být - do zásobníku volání přídavám rutinu timer click,, adresa  
            mobjTimer.mobjForm = this;  //že to je v tomtu formu
            mobjTimer.Start();

            //defionváaní nivého timeru v kódu 

            
        }

        //tick timeru
        void clsTimer_tick()
        {
            textBox1.Text = "ahoj";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            mobjTimer.Stop();
           
        }
    }
}
