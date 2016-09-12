using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using BarcodeLib.BarcodeReader;
using AForge.Video;
using MySql.Data.MySqlClient;
using Telerik;
using MetroFramework;

namespace SadSignFinalProject
{
    public partial class LoginForm : Form
    {
        //AGREGAR USING
        //VARIABLE PARA LISTA DE DISPOSITIVOS
        private FilterInfoCollection Dispositivos;
        //VARIABLE PARA FUENTE DE VIDEO
        private VideoCaptureDevice FuenteDeVideo;
        public LoginForm()
        {
            InitializeComponent();
            this.TransparencyKey = Color.FromArgb(0, 0, 0);
            //avoid flickers
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);
          
            pictureBox2.Visible = true;
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
        /*
        private void button1_Click(object sender, EventArgs e)
        {
            
            upperLayer upp = new upperLayer(this,null);
            videoSourcePlayer1.SignalToStop();
            upp.swipe(true);
            

        }*/
        public async Task timer()
        {
            await Task.Delay(5000);
            timer1.Enabled = true;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
            label2.Text = "Enabled";
            label2.ForeColor = System.Drawing.Color.Yellow;
            videoSourcePlayer1.Visible = true;
            timer1.Enabled = true;
            //ESTABLECER EL DISPOSITIVO SELECCIONADO COMO FUENTE DE VIDEO
            FuenteDeVideo = new VideoCaptureDevice(Dispositivos[comboBox1.SelectedIndex].MonikerString);


            //INICIALIZAR EL CONTROL
            videoSourcePlayer1.VideoSource = FuenteDeVideo;
            
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, videoSourcePlayer1.Width - 3, videoSourcePlayer1.Height - 3);
            Region rg = new Region(gp);
            videoSourcePlayer1.Region = rg;

            //INICIAR RECEPCION DE IMAGENES
            videoSourcePlayer1.Start();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox1.Visible = true;
            label2.Text = "Disabled";
            label2.ForeColor = System.Drawing.Color.Gray;

            videoSourcePlayer1.SignalToStop();

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //LOAD COMBOBOX AVAILABLE CAMERA
            Dispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            //LOAD
            foreach (FilterInfo x in Dispositivos)
            {
                comboBox1.Items.Add(x.Name);
            }
            comboBox1.SelectedIndex = 0;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        string MyConnectionString = "Server=localhost;Port=3306;database=library_management;Uid=root;Pwd='0e15ecJasper'";
        string staffnum;
       
        private string[] testing = null;


        private void timer1_Tick(object sender, EventArgs e)
        {
            
            // WEBCAM
            if (videoSourcePlayer1.GetCurrentVideoFrame() != null)
            {


                Bitmap img = new Bitmap(videoSourcePlayer1.GetCurrentVideoFrame());
                string[] result = BarcodeReader.read(img, BarcodeReader.QRCODE);
                img.Dispose();


                if (result != testing && result != null && result.Count() > 0)
                {
                    testing = result;

                    
                    result[0] = result[0].Substring(1);
                    staffnum = result[0];
                   




                    MySqlConnection connection = new MySqlConnection(MyConnectionString);

                    string selectString =
                                            "SELECT staffnum " +
                        "FROM stafftable " +
                        "WHERE staffnum = '" + staffnum  +  "'";

                    

                    MySqlCommand mySqlCommand = new MySqlCommand(selectString, connection);
                    connection.Open();
                    String strResult = String.Empty;
                    strResult = (String)mySqlCommand.ExecuteScalar();
                    connection.Close();
                    try
                    {
                        if (strResult.Length == 0)
                        {
                            timer1.Enabled = false;
                            MessageBox.Show("failed");
                            timer1.Enabled = true;

                            //MessageBox.Show("FAIL TO LOGIN");
                            //could redirect to register page

                        }
                        else
                        {
                            
                            //MessageBox.Show(staffnum);
                            timer1.Enabled = false;
                            upperLayer upp = new upperLayer(this,this);
                            videoSourcePlayer1.SignalToStop();
                            upp.TEXTINFO = staffnum;
                            upp.swipe(true);
                            pictureBox2.Visible = false;
                            pictureBox1.Visible = true;
                            label2.Text = "Disabled";
                            label2.ForeColor = System.Drawing.Color.Gray;

                        }
                    }
                    catch
                    {
                        timer1.Enabled = false;
                        MetroMessageBox.Show(this, "No Records Found", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        timer1.Enabled = true;
                    }
                    finally
                    {

                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();

                        }

                    }


                }



            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
        
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer2.Enabled = true;
        }

        private void videoSourcePlayer1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void minimize()
        {

            this.WindowState = FormWindowState.Minimized;
        }
    }
}
