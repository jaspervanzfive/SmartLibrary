using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SadSignFinalProject
{
    public partial class Homepage : UserControl
    {
       
        public Homepage()
        {
            InitializeComponent();
        }

        

        private void ScanerButton_Click(object sender, EventArgs e)
        {
            MainFormUI frm1 = new MainFormUI(null);
            
            
            
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainFormUI frm1 = new MainFormUI(null);
          
        }

        
    }
}
