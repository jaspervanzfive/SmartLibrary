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
    public partial class IssueBooks : Form
    {
        
        borrowers_section AccountForm { get; set; }
        public string savedata;
        public string TEXTINFO;

        public string Opgave { get { return returnvalue.Text; } }
        public IssueBooks(borrowers_section _form1)
        {
            InitializeComponent();

            AccountForm = _form1;

            //LOAD COMBOBOX AVAILABLE CAMERA
            Dispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            //LOAD
            foreach (FilterInfo x in Dispositivos)
            {
                comboBox1.Items.Add(x.Name);
            }
            comboBox1.SelectedIndex = 0;
            availability.Visible = false;
        }
        private FilterInfoCollection Dispositivos;
        private VideoCaptureDevice FuenteDeVideo;
        private void IssueBooks_Load(object sender, EventArgs e)
        {
            savedata = TEXTINFO;
            dateEdit1.EditValue = DateTime.Now;
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
                const int CS_DROPSHADOW = 0x20000;


                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
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

        private void ActivateScanner(object state)
        {
            Invoke(new Action(() =>
            {
                if (radRadioButton3.IsChecked == true)
                {
                    pictureBox1.Image = Properties.Resources.findd;
                    searchControl1.Enabled = false;
                    pictureBox2.Image = Properties.Resources.findd;
                    searchControl2.Enabled = false;
                    videoSourcePlayer1.Visible = true;
                    FuenteDeVideo = new VideoCaptureDevice(Dispositivos[comboBox1.SelectedIndex].MonikerString);
                    videoSourcePlayer1.VideoSource = FuenteDeVideo;
                    videoSourcePlayer1.Start();
                }
                else
                {
                    videoSourcePlayer1.Visible = false;
                    videoSourcePlayer1.Stop();
                }
            }));
        }

        private void radRadioButton1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (videoSourcePlayer1.IsRunning)
            {

                videoSourcePlayer1.Visible = false;
                videoSourcePlayer1.Stop();
                pictureBox1.Image = Properties.Resources.find;
                searchControl1.Enabled = true;
                pictureBox2.Image = Properties.Resources.findd;
                searchControl2.Enabled = false;
            }
            else
            {
                pictureBox1.Image = Properties.Resources.find;
                searchControl1.Enabled = true;
                pictureBox2.Image = Properties.Resources.findd;
                searchControl2.Enabled = false;
            }
        }

        private void radRadioButton3_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            timer1.Enabled = true;
            ParameterizedThreadStart pts = new ParameterizedThreadStart(ActivateScanner);
            Thread t = new Thread(pts);
            t.Start();
        }

        private void radRadioButton2_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (videoSourcePlayer1.IsRunning)
            {
                videoSourcePlayer1.Visible = false;
                videoSourcePlayer1.Stop();
                pictureBox1.Image = Properties.Resources.findd;
                searchControl1.Enabled = false;
                pictureBox2.Image = Properties.Resources.find;
                searchControl2.Enabled = true;
            }
            else
            {
                pictureBox1.Image = Properties.Resources.findd;
                searchControl1.Enabled = false;
                pictureBox2.Image = Properties.Resources.find;
                searchControl2.Enabled = true;
            }
        }
        MySqlConnection mcon = new MySqlConnection("Server=localhost;Port=3306;database=library_management;Uid=root;Pwd='0e15ecJasper'");
        MySqlCommand mcd;
        MySqlDataReader mdr;
        string s;
        string book_id=null;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ParameterizedThreadStart pts = new ParameterizedThreadStart(booksSearching);
            Thread t = new Thread(pts);
            t.Start();
        }
        private void booksSearching(object staet)
        {
            try
            {

                mcon.Open();
                s = "select * from booktable where bookid='" + searchControl1.Text.ToString() + "';";
                mcd = new MySqlCommand(s, mcon);
                mdr = mcd.ExecuteReader();
                if (mdr.Read())
                {
                    Invoke(new Action(() =>
                    {
                        string booktitle = mdr.GetString("booktitle");
                        string bookauthor = mdr.GetString("bookauthor");
                        int borrows = Convert.ToInt32(mdr.GetString("bookquantity"));
                        book_id = mdr.GetString("bookid");

                        byte[] byteBLOBData = (byte[])mdr["bookcoverphoto"];
                        var stream = new MemoryStream(byteBLOBData);
                        photo.Image = Image.FromStream(stream);


                        booksAuthor.Visible = true;
                        booksTitle.Visible = true;
                        available.Visible = true;
                        availability.Visible = true;

                        booksTitle.Text = booktitle.ToString();
                        booksAuthor.Text = bookauthor.ToString();


                        if (borrows == 0)
                        {
                            available.Image = Properties.Resources.borrowed;
                            add.Enabled = false;
                            add.Image = Properties.Resources.addd;
                        }
                        else
                        {
                            available.Image = Properties.Resources.available;
                            add.Enabled = true;
                            add.Image = Properties.Resources.adde;
                        }
                    }));
                    mdr.Close();
                    mcon.Close();
                }
                else {
                    this.Invoke(new Action(() =>
                    {
                        booksTitle.Visible = true;
                        booksTitle.Text = "No Records Found";
                        booksAuthor.Visible = false;
                        available.Visible = false;
                        availability.Visible = false;
                        add.Enabled = false;
                        add.Image = Properties.Resources.addd;
                        photo.Image = Properties.Resources.no_book_cover;
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

        private void cancel_Click(object sender, EventArgs e)
        {
            if (videoSourcePlayer1.IsRunning)
                videoSourcePlayer1.Stop();
            this.Close();
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (videoSourcePlayer1.IsRunning)
                videoSourcePlayer1.Stop();
            ParameterizedThreadStart pts = new ParameterizedThreadStart(addBook);
            Thread t = new Thread(pts);
            t.Start();
        }
        string MyConnectionString = "Server=localhost;Port=3306;database=library_management;Uid=root;Pwd='0e15ecJasper'";
        private void addBook(object state)
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            MySqlCommand cmd1;
            MySqlCommand cmd2;
            connection.Open();

            string dateToday = DateTime.Now.ToString("MMM d yyyy HH:mm");


            try
            {
                cmd = connection.CreateCommand();
                cmd1 = connection.CreateCommand();
                cmd2 = connection.CreateCommand();
                Invoke(new Action(() =>
                {
                    cmd1.CommandText = "UPDATE booktable SET bookborrowers = bookborrowers + 1,bookquantity=bookquantity -1 where bookid=@idbook";
                    cmd2.CommandText = "UPDATE studenttable SET booksborrowed = booksborrowed + 1 where studnum=@idstud";
                    cmd.CommandText = "INSERT INTO borrowerstable(idbook,studid,dateissue,datereturn,datereturned)VALUES(@idbook,@studid,@dateissue,@datereturn,NULL)";
                    cmd1.Parameters.AddWithValue("@idbook", book_id.ToString());
                    cmd2.Parameters.AddWithValue("@idstud", savedata.ToString());
                    cmd.Parameters.AddWithValue("@idbook", book_id.ToString());
                    cmd.Parameters.AddWithValue("@studid", savedata.ToString());
                    cmd.Parameters.AddWithValue("@dateissue", dateToday.ToString());
                    cmd.Parameters.AddWithValue("@datereturn", dateEdit1.Text.ToString());
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    //return value to the main form , via dialogbox
                    returnvalue.Text = "refresh";
                    this.Close();
                    add.Enabled = false;

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

        string _lastResult = null;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                // WEBCAM
                if (videoSourcePlayer1.GetCurrentVideoFrame() != null)
                {


                    var img = new Bitmap(videoSourcePlayer1.GetCurrentVideoFrame());
                    var result = BarcodeReader.read(img, BarcodeReader.CODE128);
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
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
       }

        private void SearchedData(object state)
        {
            try
            {

                mcon.Open();
                s = "select * from booktable where bookid='" + _lastResult + "';";
                mcd = new MySqlCommand(s, mcon);
                mdr = mcd.ExecuteReader();
                if (mdr.Read())
                {
                    Invoke(new Action(() =>
                    {
                        string booktitle = mdr.GetString("booktitle");
                        string bookauthor = mdr.GetString("bookauthor");
                        int borrows = Convert.ToInt32(mdr.GetString("bookquantity"));
                        book_id = mdr.GetString("bookid");

                        byte[] byteBLOBData = (byte[])mdr["bookcoverphoto"];
                        var stream = new MemoryStream(byteBLOBData);
                        photo.Image = Image.FromStream(stream);


                        booksAuthor.Visible = true;
                        booksTitle.Visible = true;
                        available.Visible = true;
                        availability.Visible = true;

                        booksTitle.Text = booktitle.ToString();
                        booksAuthor.Text = bookauthor.ToString();


                        if (borrows == 0)
                        {
                            available.Image = Properties.Resources.borrowed;
                            add.Enabled = false;
                            add.Image = Properties.Resources.addd;
                        }
                        else
                        {
                            available.Image = Properties.Resources.available;
                            add.Enabled = true;
                            add.Image = Properties.Resources.adde;
                        }
                    }));
                    mdr.Close();
                    mcon.Close();
                }
                else {
                    this.Invoke(new Action(() =>
                    {
                        booksTitle.Visible = true;
                        booksTitle.Text = "No Records Found";
                        booksAuthor.Visible = false;
                        available.Visible = false;
                        availability.Visible = false;
                        add.Enabled = false;
                        add.Image = Properties.Resources.addd;
                        photo.Image = Properties.Resources.no_book_cover;
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

        private void videoSourcePlayer1_Click(object sender, EventArgs e)
        {

        }
    }
}
