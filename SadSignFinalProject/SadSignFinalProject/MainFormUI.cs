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
using MySql.Data;
using System.ComponentModel;
using MetroFramework;

namespace SadSignFinalProject
{
    public partial class MainFormUI : Form
    {
        upperLayer AccountForm { get; set; }
        public string savedata;
        public string savedata2;
        public PictureBox savepic; 

        public string TEXTINFO;
        public string TEXTINFO2;
        public PictureBox pic1;


        public MainFormUI(upperLayer _form1)
        {
            InitializeComponent();
            //avoid flickers
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);

            AccountForm = _form1;
            //HomePage();
            
            



        }
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;


        ///
        /// Handling the window messages
        ///
        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
                message.Result = (IntPtr)HTCAPTION;


        }

        //avoid lags
        int originalExStyle = -1;
        bool enableFormLevelDoubleBuffering = true;

        protected override CreateParams CreateParams
        {
            get
            {
                if (originalExStyle == -1)
                    originalExStyle = base.CreateParams.ExStyle;
                //const int CS_DROPSHADOW = 0x20000;
                
                
                CreateParams cp = base.CreateParams;
                //cp.ClassStyle |= CS_DROPSHADOW;
                if (enableFormLevelDoubleBuffering)
                    cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
                else
                    cp.ExStyle = originalExStyle;

                return cp;
            }
        }

        public void TurnOffFormLevelDoubleBuffering()
        {
            enableFormLevelDoubleBuffering = false;
            this.MaximizeBox = true;
        }
       
        private void MainFormUI_Load(object sender, EventArgs e)
        {

            savedata = TEXTINFO;
            savedata2 = TEXTINFO2;
            savepic = pic1;


            //profile.Image= savepic.Image;
            name.Text = TEXTINFO;
     
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {


        }


     
            
        /* for PANELS
            while (metroPanel1.Controls.Count > 0)
                metroPanel1.Controls[0].Dispose();

            ScannerPage frm = new ScannerPage();

            
            frm.AutoScroll = true;
            metroPanel1.Controls.Add(frm);
            frm.Show();
        */

       

        private void closebutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       


        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.calendarblue;
            pictureBox2.Image = Properties.Resources.homedefa;
            pictureBox4.Image = Properties.Resources.setdef;
            pictureBox5.Image = Properties.Resources.aboutdef;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.caldefs;
            pictureBox2.Image = Properties.Resources.homeblue;
            pictureBox4.Image = Properties.Resources.setdef;
            pictureBox5.Image = Properties.Resources.aboutdef;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.settingsblue;
            pictureBox2.Image = Properties.Resources.homedefa;
            pictureBox3.Image = Properties.Resources.caldefs;
            pictureBox5.Image = Properties.Resources.aboutdef;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox5.Image = Properties.Resources.aboutblue;
            pictureBox2.Image = Properties.Resources.homedefa;
            pictureBox3.Image = Properties.Resources.caldefs;
            pictureBox4.Image = Properties.Resources.setdef;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            ScannerForm sf = new ScannerForm();
            this.Close();
            sf.Show();
        }
        private string container;

        //ASYNC AND AWAIT

        private async void pictureBox10_Click(object sender, EventArgs e)
        {

            FormForAll frm = new FormForAll(this);

            frm.TEXTINFO = "students";
            frm.Show();
            this.Close();

        }

        public async Task Run()
        {
            FormForAll frm = new FormForAll(this);

            frm.TEXTINFO = "students";
            frm.Show();
            this.Close();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            FormForAll frm = new FormForAll(this);

            frm.TEXTINFO = "books";
            frm.Show();
            this.Close();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            FormForAll frm = new FormForAll(this);

            frm.TEXTINFO = "borrowers";
            frm.Show();
            this.Close();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            FormForAll frm = new FormForAll(this);

            frm.TEXTINFO = "attendance";
            frm.Show();
            this.Close();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            FormForAll frm = new FormForAll(this);

            frm.TEXTINFO = "announcement";
            frm.Show();
            this.Close();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            FormForAll frm = new FormForAll(this);

            if (TEXTINFO2 == "ADMIN")
            {

                frm.TEXTINFO = "staff";
                frm.staffposition = TEXTINFO2;
                frm.Show();
                this.Close();
            }
            else {
                MetroMessageBox.Show(this, "Only admin can edit staffs, please contact the admin in order to manage staffs", "Unauthorized Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm MFUI = new LoginForm();
            //MainFormUI MFUI = new MainFormUI();
            //this.Close();
            MFUI.Show();
        }
    }
    
}
