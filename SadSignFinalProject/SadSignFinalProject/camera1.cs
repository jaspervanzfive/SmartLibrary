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
using MySql.Data.MySqlClient;

namespace SadSignFinalProject
{
    public partial class camera1 : Form
    {

        private FilterInfoCollection Dispositivos;
        //VARIABLE PARA FUENTE DE VIDEO
        private VideoCaptureDevice FuenteDeVideo;
       
        
        public string Opgave { get { return return_value.Text; } }
        public camera1()
        {
            InitializeComponent();

            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Parent = videoSourcePlayer1;
            pictureBox2.Enabled = true;
            pictureBox2.Visible = true;
            pictureBox2.Location = new Point(3, 3);

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

            
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            videoSourcePlayer1.Stop();
            
            this.Close();
            
        }

        private void camera1_Load(object sender, EventArgs e)
        {
            
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
            catch (Exception ex)
            {
                label1.Visible = true;
                label1.Text = "No Records Found";
            }

        }
        string fullanme=null;
        MySqlConnection mcon = new MySqlConnection("Server=localhost;Port=3306;database=library_management;Uid=root;Pwd='0e15ecJasper'");
        MySqlCommand mcd;
        MySqlDataReader mdr;
        string s;
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
                        fullanme = mdr.GetString("studnum");
                        
                        label1.Visible = false;

                        return_value.Text = fullanme;
                        videoSourcePlayer1.Stop();
                        this.Close();

                    }));
                    mdr.Close();
                    mcon.Close();

                }
                else {
                    this.Invoke(new Action(() =>
                    {
                        label1.Visible = true;
                        
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
