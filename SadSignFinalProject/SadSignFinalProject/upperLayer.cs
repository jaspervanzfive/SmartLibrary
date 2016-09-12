using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transitions;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using MetroFramework;
using System.IO;

namespace SadSignFinalProject
{
    public partial class upperLayer : UserControl
    {
        LoginForm AccountForm { get; set; }
        public string savedata;
        public string TEXTINFO;
        //variables
        Form _owner = null;
        bool _loaded = false;


        //events
        #region Events
        public event EventHandler Closed;
        public event EventHandler Shown;

        protected virtual void closed(EventArgs e)
        {
            EventHandler handler = Closed;

            if (handler != null) handler(this, e);
        }

        protected virtual void shown(EventArgs e)
        {
            EventHandler handler = Shown;

            if (handler != null) handler(this, e);
        }
        #endregion


        public upperLayer(Form owner, LoginForm _form1)
        {
            InitializeComponent();
            AccountForm = _form1;
            //avoid flickers
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);

            this.Visible = false;
            _owner = owner;
            owner.Controls.Add(this);
            this.BringToFront();
            
            this.Click += upperLayer_Click;
            ResizeForm();

            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox2.Width - 3, pictureBox2.Height - 3);
            Region rg = new Region(gp);
            pictureBox2.Region = rg;

           


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

                CreateParams cp = base.CreateParams;
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
            
        }
        private void upperLayer_Load(object sender, EventArgs e)
        {
            savedata = TEXTINFO;
            updateUser();
        }

        private void upperLayer_Click(object sender, EventArgs e)
        {
            swipe(false);
        }

        private void metroUserControl1_Load(object sender, EventArgs e)
        {

        }
        int code1;
        int code2;
        int code3;
        int code4;

        int buttonclick;
        int count;
        private string passcode;

        private void ResizeForm()
        {
            this.Width = _owner.Width;
            this.Height = _owner.Height - 77;
            this.Location = new Point(_loaded ? 0 : _owner.Width, 50);
        }
        public void swipe(bool show = true)
        {
            this.Visible = true;
            Transition _transition = new Transitions.Transition(new TransitionType_EaseInEaseOut(1000));
            _transition.add(this, "Left", show ? 0 : this.Width);
            _transition.run();

            while (this.Left != (show ? 0 : this.Width))
            {
                Application.DoEvents();
            }

            if (!show)
            {
                closed(new EventArgs());
               
                _owner.Controls.Remove(this);
                this.Dispose();

                

            }
            else
            {
                _loaded = true;
                ResizeForm();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.z1;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.one;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.z2;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.two;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.z3;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.three;
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5.Image = Properties.Resources.z4;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Image = Properties.Resources.four;
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            pictureBox6.Image = Properties.Resources.z5;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.Image = Properties.Resources.five;
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            pictureBox7.Image = Properties.Resources.z6;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.Image = Properties.Resources.six;
        }

        private void pictureBox8_MouseEnter(object sender, EventArgs e)
        {
            pictureBox8.Image = Properties.Resources.z7;
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            pictureBox8.Image = Properties.Resources.seven;
        }

        private void pictureBox9_MouseEnter(object sender, EventArgs e)
        {
            pictureBox9.Image = Properties.Resources.z8;
        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            pictureBox9.Image = Properties.Resources.eight;
        }

        private void pictureBox10_MouseEnter(object sender, EventArgs e)
        {
            pictureBox10.Image = Properties.Resources.z9;
        }

        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            pictureBox10.Image = Properties.Resources.nine;
        }

        private void pictureBox11_MouseEnter(object sender, EventArgs e)
        {
            pictureBox11.Image = Properties.Resources.z0;
        }

        private void pictureBox11_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox11_MouseLeave(object sender, EventArgs e)
        {
            pictureBox11.Image = Properties.Resources.zero;
        }
        
        public void updateUser()
        {
            
            MySqlConnection mcon = new MySqlConnection("Server=localhost;Port=3306;database=library_management;Uid=root;Pwd='0e15ecJasper'");
            MySqlCommand mcd;
            MySqlDataReader mdr;
            string s;
            try
            {
                mcon.Open();
                s = "select * from stafftable where staffnum='" + savedata + "';";
                mcd = new MySqlCommand(s, mcon);
                mdr = mcd.ExecuteReader();
                if (mdr.Read())
                {

                    byte[] byteBLOBData = (byte[])mdr["picture"];
                    var stream = new MemoryStream(byteBLOBData);
                    pictureBox2.Image = Image.FromStream(stream);

                    string firstname = mdr.GetString("fullname");
                    
                    label1.Text = firstname;
                    label2.Text = mdr.GetString("position");
                    passcode = mdr.GetString("passcode");
                    mdr.Close();
                    mcon.Close();
                }
                else {
                    MessageBox.Show("NO DATA");
                    mdr.Close();
                    mcon.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                if (mcon.State == ConnectionState.Open)
                {
                    mcon.Close();

                }

            }



        }
        
        public void circleControl()
        {
            count++;
            switch (count)
            {
                case 1:
                    pictureBox12.Image = Properties.Resources.filled;
                    code1 = buttonclick;

                    break;
                case 2:
                    pictureBox13.Image = Properties.Resources.filled;
                    code2 = buttonclick;

                    break;
                case 3:
                    pictureBox14.Image = Properties.Resources.filled;
                    code3 = buttonclick;

                    break;
                case 4:

                    pictureBox15.Image = Properties.Resources.filled;
                    code4 = buttonclick;

                    String masterTest = code1 + "" + code2 + "" + code3 + "" + code4;
                    if (masterTest == passcode)
                    {
                        this.Hide();
                       var lgf = new LoginForm();
                        //MainFormUI mf = new MainFormUI(this);
                        
                        
                        var mf = new MainFormUI(this);
                        mf.TEXTINFO = label1.Text;
                        mf.TEXTINFO2 = label2.Text;
                        mf.pic1 = pictureBox2;
                        ((Form)this.TopLevelControl).Close();
                        mf.Show();

                        

                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Please use a valid passcode", "Unauthorized Login",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        /*
                        label3.Visible = true;
                        label3.Text = "Unauthorized Login";*/
                    }

                    pictureBox12.Image = Properties.Resources.unfilled;
                    pictureBox13.Image = Properties.Resources.unfilled;
                    pictureBox14.Image = Properties.Resources.unfilled;
                    pictureBox15.Image = Properties.Resources.unfilled;



                    count = 0;
                    break;

            }

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            buttonclick = 1;
            circleControl();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            buttonclick = 2;
            circleControl();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            buttonclick = 3;
            circleControl();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            buttonclick = 4;
            circleControl();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            buttonclick = 5;
            circleControl();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            buttonclick = 6;
            circleControl();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            buttonclick = 7;
            circleControl();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            buttonclick = 8;
            circleControl();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            buttonclick = 9;
            circleControl();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            buttonclick = 0;
            circleControl();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
