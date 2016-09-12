using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarcodeLib.BarcodeReader;
using MySql.Data.MySqlClient;
using System.Threading;
using System.IO;
using AForge.Video;
using AForge.Video.DirectShow;
namespace SadSignFinalProject
{
    public partial class ScannerForm : Form
    {

        private FilterInfoCollection Dispositivos;
        //VARIABLE PARA FUENTE DE VIDEO
        private VideoCaptureDevice FuenteDeVideo;

      
        public ScannerForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;


            //avoid flickers
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);
            
            formLoad();
            timer1.Enabled = true;

            /*
            ParameterizedThreadStart pts = new ParameterizedThreadStart(announce);
            Thread t = new Thread(pts);
            t.Start();
            */

            
             
             


        }

        private void topborrowers(object state)
        {
            try
            {
                mcon.Open();
                
                s = "select booktitle,bookauthor,MAX(bookborrowers),bookcoverphoto from booktable";
                mcd = new MySqlCommand(s, mcon);
                mdr = mcd.ExecuteReader();
                if (mdr.Read())
                {
                    this.Invoke(new Action(() =>
                    {
                        string title = mdr.GetString("booktitle");
                        string bookauthor = mdr.GetString("bookauthor");
                        int bookborrowers = Convert.ToInt16(mdr.GetString("MAX(bookborrowers)"));
                        

                        byte[] byteBLOBData = (byte[])mdr["bookcoverphoto"];
                        var stream = new MemoryStream(byteBLOBData);
                        photo1.Image = Image.FromStream(stream);

                        title1.Text = title;
                        author1.Text = "by "+bookauthor;
                        borrows.Text = Convert.ToString(bookborrowers);
                        titlehead.Text = title;
                        authorhead.Text = "by " + bookauthor;


                    }));

                }
                mdr.Close();
                mcon.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void toptwoborrowers(object state)
        {
            try
            {
                mcon.Open();

                s = "SELECT booktitle,bookauthor,bookcoverphoto,MAX(bookborrowers) FROM booktable WHERE bookborrowers < (SELECT MAX(bookborrowers) FROM booktable )";
                mcd = new MySqlCommand(s, mcon);
                mdr = mcd.ExecuteReader();
                if (mdr.Read())
                {
                    this.Invoke(new Action(() =>
                    {
                        string title = mdr.GetString("booktitle");
                        string bookauthor = mdr.GetString("bookauthor");
                        int bookborrowers = Convert.ToInt16(mdr.GetString("MAX(bookborrowers)"));


                        byte[] byteBLOBData = (byte[])mdr["bookcoverphoto"];
                        var stream = new MemoryStream(byteBLOBData);
                        photo2.Image = Image.FromStream(stream);

                        title2.Text = title;
                        author2.Text = "by " + bookauthor;


                    }));

                }
                mdr.Close();
                mcon.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void formLoad()
        {
            //PictureBox shape circle
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox2.Width - 3, pictureBox2.Height - 3);
            Region rg = new Region(gp);
            pictureBox2.Region = rg;

            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Parent = videoSourcePlayer1;
            pictureBox1.Enabled = true;
            pictureBox1.Visible = true;
            pictureBox1.Location = new Point(20, 15);

            
            //LOAD COMBOBOX AVAILABLE CAMERA
            Dispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            //LOAD
            foreach (FilterInfo x in Dispositivos)
            {
                comboBox1.Items.Add(x.Name);
            }
            comboBox1.SelectedIndex = 0;

            FuenteDeVideo = new VideoCaptureDevice(Dispositivos[comboBox1.SelectedIndex].MonikerString);
            videoSourcePlayer1.VideoSource = FuenteDeVideo;

            videoSourcePlayer1.Start();
            timer1.Enabled = true;

         
            //timer2.Enabled = true;

            //timer interval
            timer3.Interval = 1000;  //in milliseconds

            timer3.Tick += new EventHandler(this.timer3_Tick);

            //start timer when form loads
            timer3.Start();  //this will use t_Tick() method
        }
        private int xpos = 0, ypos = 0;
        string messages = null;
        private void ScannerForm_Load(object sender, EventArgs e)
        {
            xpos = label9.Location.X;
            ypos = label9.Location.Y;
          

            
            timer4.Enabled = true;
            timer4.Start();


            


        }

        private void announce(object state)
        {
            try
            {

                mcon.Open();
                s = "select message from announcementtable ";
                mcd = new MySqlCommand(s, mcon);
                mdr = mcd.ExecuteReader();
                if (mdr.Read())
                {
                    this.Invoke(new Action(() =>
                    {
                        messages= mdr.GetString("message");
                        label9.Text = messages;

                       
                    }));

                    mdr.Close();
                    mcon.Close();
                }
                mdr.Close();
                mcon.Close();
                /*
                ParameterizedThreadStart pts1 = new ParameterizedThreadStart(topborrowers);
                Thread t1 = new Thread(pts1);
                t1.Start();
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            timer2.Enabled = true;

            

        }
        private string _lastResult;
        
        MySqlConnection mcon = new MySqlConnection("Server=localhost;Port=3306;database=library_management;Uid=root;Pwd='0e15ecJasper'");
        MySqlCommand mcd;
        MySqlDataReader mdr;
        string s;
        string schoolid;
        int timer =1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer++;
            if (timer == 2)
            {
                ParameterizedThreadStart pts = new ParameterizedThreadStart(announce);
                Thread t = new Thread(pts);
                t.Start();
            }
            else if (timer == 4)
            {
                ParameterizedThreadStart pts1 = new ParameterizedThreadStart(topborrowers);
                Thread t1 = new Thread(pts1);
                t1.Start();


            }
            else if (timer == 5)
            {
                /*
                ParameterizedThreadStart pts1 = new ParameterizedThreadStart(toptwoborrowers);
                Thread t1 = new Thread(pts1);
                t1.Start();*/
            }
            try {
                // WEBCAM
                if (videoSourcePlayer1.GetCurrentVideoFrame() != null)
                {


                    var img = new Bitmap(videoSourcePlayer1.GetCurrentVideoFrame());
                    var result = BarcodeReader.read(img, BarcodeReader.QRCODE);
                    img.Dispose();


                    if (result != null && result.Count() > 0)
                    {

                        if (result[0].Substring(1) != _lastResult)
                        {
                            _lastResult = result[0].Substring(1);
                            //Search student id in the database /SearchedData
                            ParameterizedThreadStart pts = new ParameterizedThreadStart(SearchedData);
                            Thread t = new Thread(pts);
                            t.Start();
                            
                            //MessageBox.Show(result[0]);
                            


                        }
                        else
                        {
                            return;
                        }

                    }
                }

            }
            catch(Exception ex)
            {
                label6.Text = "No Records Found";
                label7.Visible = false;
                label8.Visible = false;
                pictureBox2.Image = Properties.Resources.unknown;
            }
           
        }

        
       
        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }
        string stud_id = null;
        private void SearchedData(object state)
        {
            try
            {

                mcon.Open();
                s = "select * from studenttable where studnum='" + _lastResult + "';";
                mcd = new MySqlCommand(s, mcon);
                mdr = mcd.ExecuteReader();
                if (mdr.Read())
                {
                    this.Invoke(new Action(() =>
                    {
                        stud_id = mdr.GetString("studnum");
                        string fullanme = mdr.GetString("studname");
                        string section = mdr.GetString("studsec");
                        string course = mdr.GetString("studcourse");

                        byte[] byteBLOBData = (byte[])mdr["studpic"];
                        var stream = new MemoryStream(byteBLOBData);
                        pictureBox2.Image = Image.FromStream(stream);


                        label7.Visible = true;
                        label8.Visible = true;
                        label6.Text = fullanme;
                        label7.Text = section;
                        label8.Text = course;

                        ParameterizedThreadStart pts = new ParameterizedThreadStart(AttendanceAdd);
                        Thread t = new Thread(pts);
                        t.Start();

                    }));
                    mdr.Close();
                    mcon.Close();

                }
                else {
                    this.Invoke(new Action(() =>
                    {
                        label6.Text = "No Records Found";
                        label7.Visible = false;
                        label8.Visible = false;
                        pictureBox2.Image = Properties.Resources.unknown;
                        mdr.Close();
                        mcon.Close();
                    }));

                }
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message);
                
            }
        }
        string MyConnectionString = "Server=localhost;Port=3306;database=library_management;Uid=root;Pwd='0e15ecJasper'";
        private void AttendanceAdd(object state)
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();

        
            string dateToday = DateTime.Now.ToString("MMM d yyyy");
            //string timeToday = DateTime.Now.ToString("HH: mm"); 

            try
            {
                cmd = connection.CreateCommand();
                
                Invoke(new Action(() =>
                {
                    
                    cmd.CommandText = "INSERT INTO attendancetable(studid,date,time)VALUES(@studid,@date,@time)";
                   
                    cmd.Parameters.AddWithValue("@studid", stud_id.ToString());
                    cmd.Parameters.AddWithValue("@date", dateToday.ToString());
                    cmd.Parameters.AddWithValue("@time", timenow.ToString());
                   
                    cmd.ExecuteNonQuery();
                   
                    
                   

                }));
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {

                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();

                }

            }
        }
        string timenow = null;
        private void DateToday(object state)
        {
            //get current time
            Invoke(new Action(() =>
            {

                int numday = DateTime.Now.Day;
                int months = DateTime.Now.Month;
                int dayoftheweek = (int)DateTime.Now.DayOfWeek;
                int numdays = (int)DateTime.Now.Day;


                int hh = DateTime.Now.Hour;
                int mm = DateTime.Now.Minute;
                int ss = DateTime.Now.Second;


                if (DateTime.Now.ToString("tt") == "AM")
                {
                    label5.Text = "AM";
                }
                else if (DateTime.Now.ToString("tt") == "PM")
                {
                    label5.Text = "PM";
                }
                if (numday == numdays)
                    label2.Text = Convert.ToString(numdays);






                if (months == 1)
                {
                    label1.Text = "January";
                }
                else if (months == 2)
                {
                    label1.Text = "February";
                }
                else if (months == 3)
                {
                    label1.Text = "March";
                }
                else if (months == 4)
                {
                    label1.Text = "April";
                }
                else if (months == 5)
                {
                    label1.Text = "May";
                }
                else if (months == 6)
                {
                    label1.Text = "June";
                }
                else if (months == 7)
                {
                    label1.Text = "July";
                }
                else if (months == 8)
                {
                    label1.Text = "August";
                }
                else if (months == 9)
                {
                    label1.Text = "September";
                }
                else if (months == 10)
                {
                    label1.Text = "October";
                }
                else if (months == 11)
                {
                    label1.Text = "November";
                }
                else if (months == 12)
                {
                    label1.Text = "December";
                }



                if (dayoftheweek == 0)
                    label3.Text = "Sunday";
                else if (dayoftheweek == 1)
                    label3.Text = "Monday";
                else if (dayoftheweek == 2)
                    label3.Text = "Tuesday";
                else if (dayoftheweek == 3)
                    label3.Text = "Wednesday";
                else if (dayoftheweek == 4)
                    label3.Text = "Thursday";
                else if (dayoftheweek == 5)
                    label3.Text = "Friday";
                else if (dayoftheweek == 6)
                    label3.Text = "Saturday";

                //time
                string time = "";

                //padding leading zero
                if (hh < 10)
                {

                    if (hh == 0)
                    {
                        time += 12;
                    }
                    else if (hh < 10)
                    {
                        time += "  " + hh;

                    }
                    


                }
                else if (hh >= 12)
                {

                    if (hh == 12)
                        time += 12;
                    else if (hh == 13)
                        time += "  " + 1;
                    else if (hh == 14)
                        time += "  " + 2;
                    else if (hh == 15)
                        time += "  " + 3;
                    else if (hh == 16)
                        time += "  " + 4;
                    else if (hh == 17)
                        time += "  " + 5;
                    else if (hh == 18)
                        time += "  " + 6;
                    else if (hh == 19)
                        time += "  " + 7;
                    else if (hh == 20)
                        time += "  " + 8;
                    else if (hh == 21)
                        time += "  " + 9;
                    else if (hh == 22)
                        time += +10;
                    else if (hh == 23)
                        time += 11;
                    else if (hh == 24)
                        time += 12;
                }

                else
                {
                    time += hh;

                }
                time += ":";

                if (mm < 10)
                {
                    time += "0" + mm;
                }
                else
                {
                    time += mm;
                }
                //time += ":";

                /*if (ss < 10)
                {
                    time += "0" + ss;
                }
                elses
                {
                    time += ss;
                }*/

                //update label
                label4.Text = time;
                timenow = time + " " + label5.Text;

                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
            }));
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            ParameterizedThreadStart pts = new ParameterizedThreadStart(DateToday);
            Thread t = new Thread(pts);
            t.Start();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureCircle()
        {
            //PictureBox shape circle
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox2.Width - 3, pictureBox2.Height - 3);
            Region rg = new Region(gp);
            pictureBox2.Region = rg;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            videoSourcePlayer1.Stop();
            this.Hide();
            var MFUI = new MainFormUI(null);
            MFUI.Closed += (s, args) => this.Close();
            MFUI.Show();
        }

        private void videoSourcePlayer1_Click(object sender, EventArgs e)
        {

        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                label9.Left += 10;

                if (label9.Left >= this.Width)
                {
                    label9.Left = label9.Width * -1;
                }
            }));
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void photo3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            ParameterizedThreadStart pts = new ParameterizedThreadStart(SearchBook);
            Thread t = new Thread(pts);
            t.Start();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void SearchBook(object state)
        {
            try
            {

                mcon.Open();
                s = "select * from booktable where booktitle='" + searchControl1.Text.ToString() + "';";
                mcd = new MySqlCommand(s, mcon);
                mdr = mcd.ExecuteReader();
                if (mdr.Read())
                {
                    this.Invoke(new Action(() =>
                    {
                        
                        string booktitle = mdr.GetString("booktitle");
                        string bookauthor = mdr.GetString("bookauthor");
                        int racknumber = Convert.ToInt16(mdr.GetString("bookracknum"));
                        int bookquanity = Convert.ToInt16(mdr.GetString("bookquantity"));

                        available.Visible = true;
                        
                        byte[] byteBLOBData = (byte[])mdr["bookcoverphoto"];
                        var stream = new MemoryStream(byteBLOBData);
                        pictureBox5.Image = Image.FromStream(stream);

                        booktitle1.Text = booktitle;
                        bookauthor1.Text = bookauthor;
                        bookrack.Text = Convert.ToString(racknumber);

                        if (bookquanity == 0)
                        {
                            available.Image = Properties.Resources.borrowed;
                        }
                        else
                        {
                            available.Image = Properties.Resources.available;
                        }


                    }));
                    mdr.Close();
                    mcon.Close();

                }
                else
                {
                    this.Invoke(new Action(() =>
                    {
                        booktitle1.Text = "No Records Found";
                        bookauthor1.Text = "";
                        bookrack.Text = "";
                        pictureBox5.Image = Properties.Resources.no_book_cover;
                        available.Visible = false;
                        mdr.Close();
                        mcon.Close();
                    }));

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
