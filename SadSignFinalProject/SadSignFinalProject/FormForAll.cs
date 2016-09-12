using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SadSignFinalProject
{
    public partial class FormForAll : Form
    {
        
        MainFormUI splash;

        MainFormUI AccountForm { get; set; }
        public string savedata;
        public string staffpos;
        public string TEXTINFO;
        public string staffposition;

        public FormForAll(MainFormUI _form1)
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;


            AccountForm = _form1;
            
            //avoid flickers
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);

            

        }
        //This is for avoid flickering of controls
        
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


        //Form load when this form loads user control will load up but I am having a delay , they are not sync when it executes        
        private void FormForAll_Load(object sender, EventArgs e)
        {
            savedata = TEXTINFO;
            staffpos = staffposition;

            dashboard.Parent = pictureBox1;
            pictureBox2.Parent = pictureBox1;
            pictureBox3.Parent = pictureBox1;
            pictureBox4.Parent = pictureBox1;
            pictureBox5.Parent = pictureBox1;
            pictureBox6.Parent = pictureBox1;
            pictureBox7.Parent = pictureBox1;

            dashboard.Location = new Point(486,9);
            pictureBox2.Location = new Point(424, 9);
            pictureBox3.Location = new Point(365, 9);
            pictureBox4.Location = new Point(305, 9);
            pictureBox5.Location = new Point(5, 9);
            pictureBox7.Location = new Point(65, 9);
            pictureBox6.Location = new Point(125, 9);


            ParameterizedThreadStart pts = new ParameterizedThreadStart(userControlforForms);
            Thread t = new Thread(pts);
            t.Start(savedata);



        }
        private void userControlforForms(object state)
        {
            string savedatas1 = state.ToString();


            if (savedatas1 == "students")
            {
                Invoke(new Action(() =>
                {
                    pictureBox2.Enabled = false;
                    pictureBox3.Enabled = true;
                    pictureBox4.Enabled = true;
                    pictureBox5.Enabled = true;
                    pictureBox6.Enabled = true;
                    pictureBox7.Enabled = true;
                    pictureBox1.Image = Properties.Resources.navstudents;
                    label1.Visible = true;
                    label1.Text = "MANAGE STUDENTS";
                    while (panel1.Controls.Count > 0)
                        panel1.Controls[0].Dispose();

                    studentManager frm = new studentManager();


                    frm.AutoScroll = true;
                    panel1.Controls.Add(frm);
                    frm.Show();
                }));
            }
            else if (savedatas1 == "books")
            {
                Invoke(new Action(() =>
                {
                    pictureBox2.Enabled = true;
                    pictureBox3.Enabled = false;
                    pictureBox4.Enabled = true;
                    pictureBox5.Enabled = true;
                    pictureBox6.Enabled = true;
                    pictureBox7.Enabled = true;
                    pictureBox1.Image = Properties.Resources.navbooks;
                    label1.Visible = true;
                    label1.Text = "    MANAGE  BOOKS";
                    while (panel1.Controls.Count > 0)
                        panel1.Controls[0].Dispose();

                    BookManager frm = new BookManager();


                    frm.AutoScroll = true;
                    panel1.Controls.Add(frm);
                    frm.Show();
                }));
            }
            else if (savedatas1 == "admin1")
            {
                Invoke(new Action(() =>
                {
                    this.Hide();
                    var MFUI = new MainFormUI(null);
                    MFUI.Closed += (s, args) => this.Close();
                    MFUI.Show();
                }));
            }
            else if (savedatas1 == "borrowers")
            {
                Invoke(new Action(() =>
                {
                    pictureBox2.Enabled = true;
                    pictureBox3.Enabled = true;
                    pictureBox4.Enabled = false;
                    pictureBox5.Enabled = true;
                    pictureBox6.Enabled = true;
                    pictureBox7.Enabled = true;
                    pictureBox1.Image = Properties.Resources.navborrow;
                    label1.Visible = true;
                    label1.Text = "MANAGE BORROWERS";
                    while (panel1.Controls.Count > 0)
                        panel1.Controls[0].Dispose();

                    borrowers_section frm = new borrowers_section();


                    frm.AutoScroll = true;
                    panel1.Controls.Add(frm);
                    frm.Show();
                }));
            }
            else if (savedatas1 == "attendance")
            {
                Invoke(new Action(() =>
                {
                    pictureBox2.Enabled = true;
                    pictureBox3.Enabled = true;
                    pictureBox4.Enabled = true;
                    pictureBox5.Enabled = false;
                    pictureBox6.Enabled = true;
                    pictureBox7.Enabled = true;
                    pictureBox1.Image = Properties.Resources.navattendance;
                    label1.Visible = true;
                    label1.Text = "Attendance List";
                    while (panel1.Controls.Count > 0)
                        panel1.Controls[0].Dispose();

                    attendance frm = new attendance();


                    frm.AutoScroll = true;
                    panel1.Controls.Add(frm);
                    frm.Show();
                }));
            }
            else if (savedatas1 == "announcement")
            {
                Invoke(new Action(() =>
                {
                    pictureBox2.Enabled = true;
                    pictureBox3.Enabled = true;
                    pictureBox4.Enabled = true;
                    pictureBox5.Enabled = true;
                    pictureBox6.Enabled = false;
                    pictureBox7.Enabled = true;
                    pictureBox1.Image = Properties.Resources.navanounce;
                    label1.Visible = true;
                    label1.Text = "Announcements!";
                    while (panel1.Controls.Count > 0)
                        panel1.Controls[0].Dispose();

                    Announcements frm = new Announcements();


                    frm.AutoScroll = true;
                    panel1.Controls.Add(frm);
                    frm.Show();
                }));
            }
            else if (savedatas1 == "staff")
            {
                Invoke(new Action(() =>
                {
                    if (staffpos == "ADMIN")
                    {
                        pictureBox2.Enabled = true;
                        pictureBox3.Enabled = true;
                        pictureBox4.Enabled = true;
                        pictureBox5.Enabled = true;
                        pictureBox6.Enabled = true;
                        pictureBox7.Enabled = false;
                        pictureBox1.Image = Properties.Resources.navstaffs;
                        label1.Visible = true;
                        label1.Text = "MANAGE STAFFS";
                        while (panel1.Controls.Count > 0)
                            panel1.Controls[0].Dispose();

                        StaffTable frm = new StaffTable();


                        frm.AutoScroll = true;
                        panel1.Controls.Add(frm);
                        frm.Show();
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Only admin can edit staffs, please contact the admin in order to manage staffs", "Unauthorized Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }));
            }
           


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ParameterizedThreadStart pts = new ParameterizedThreadStart(userControlforForms);
            Thread t = new Thread(pts);
            t.Start("students");
        }
            

        
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ParameterizedThreadStart pts = new ParameterizedThreadStart(userControlforForms);
            Thread t = new Thread(pts);
            t.Start("books");
        }

        private void dashboard_Click(object sender, EventArgs e)
        {
            ParameterizedThreadStart pts = new ParameterizedThreadStart(userControlforForms);
            Thread t = new Thread(pts);
            t.Start("admin1");
        }

        

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ParameterizedThreadStart pts = new ParameterizedThreadStart(userControlforForms);
            Thread t = new Thread(pts);
            t.Start("borrowers");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ParameterizedThreadStart pts = new ParameterizedThreadStart(userControlforForms);
            Thread t = new Thread(pts);
            t.Start("attendance");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ParameterizedThreadStart pts = new ParameterizedThreadStart(userControlforForms);
            Thread t = new Thread(pts);
            t.Start("announcement");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            ParameterizedThreadStart pts = new ParameterizedThreadStart(userControlforForms);
            Thread t = new Thread(pts);
            t.Start("staff");
        }
    }
}
