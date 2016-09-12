using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SadSignFinalProject
{
    public partial class SplashScreen : Form
    {
        private int xpos = 0, ypos = 0;
        
        public SplashScreen()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Start();
            
        }

        
         

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm MFUI = new LoginForm();
            //MainFormUI MFUI = new MainFormUI();
            //this.Close();
            MFUI.Show();

        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            
            xpos = label1.Location.X;
            ypos = label1.Location.Y;
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Left += 5;

            if (label1.Left >= this.Width){
                label1.Left = label1.Width * -1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Gamertag2 = "banana";
            if (textBox1.Text.Contains("-")){
                string samp=textBox1.Text.Replace("-", "");
                MessageBox.Show(samp);
            }

        }

     



    }
}
