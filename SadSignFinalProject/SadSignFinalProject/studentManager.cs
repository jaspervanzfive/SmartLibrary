using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using System.Threading;
using System.Text.RegularExpressions;
using BarcodeLib.Barcode.WinForms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace SadSignFinalProject
{
    public partial class studentManager : UserControl
    {

        public studentManager()
        {
            InitializeComponent();

            //avoid flickers
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);

            //picturebox make it circle

            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, photo.Width - 3, photo.Height - 3);
            Region rg = new Region(gp);
            photo.Region = rg;


            ParameterizedThreadStart pts = new ParameterizedThreadStart(LoadGrid);
            Thread t = new Thread(pts);
            t.Start();



        }

        private void studentManager_Load(object sender, EventArgs e)
        {


        }



        private void upload_Click(object sender, EventArgs e)
        {
            //upload picture
            OpenFileDialog opf = new OpenFileDialog(); opf.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK) {
                photo.Image = Image.FromFile(opf.FileName);
                //photo.Image = ResizeImage(photo.Image, 179, 173);
            }

        }


        //db
        string MyConnectionString = "Server=localhost;Port=3306;database=library_management;Uid=root;Pwd='0e15ecJasper'";
        private void add_Click(object sender, EventArgs e)
        {
            
                MySqlConnection connection = new MySqlConnection(MyConnectionString);
                MySqlCommand cmd;
                connection.Open();
                MemoryStream ms = new MemoryStream();

                photo.Image.Save(ms, photo.Image.RawFormat);
                byte[] img = ms.ToArray();

                MemoryStream qrCodex = new MemoryStream();
                Image imgs = (Image)qrCodeImgControl1.Image.Clone();
                imgs.Save(qrCodex, imgs.RawFormat);
                byte[] qrCodes = qrCodex.ToArray();
                try
                {
                    //qrcodex




                    cmd = connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO studenttable(studnum,studname,studsec,studemail,studcourse,studgender,studpic,qrcode)VALUES(@valstudnum,@valstudname,@valstudsec,@valstudemail,@valstudcourse,@valstudgender,@valstudpic,@qrcode)";
                    cmd.Parameters.AddWithValue("@valstudnum", studnum.Text.ToString());
                    cmd.Parameters.AddWithValue("@valstudname", studname.Text.ToString());
                    cmd.Parameters.AddWithValue("@valstudsec", studsec.Text.ToString());
                    cmd.Parameters.AddWithValue("@valstudemail", studemail.Text.ToString());
                    cmd.Parameters.AddWithValue("@valstudcourse", studcourse.Text.ToString());
                    cmd.Parameters.AddWithValue("@valstudgender", studgender.Text.ToString());
                    cmd.Parameters.AddWithValue("@valstudpic", img);
                    cmd.Parameters.AddWithValue("@qrcode", qrCodes);

                    Regex id = new Regex(@"^([0-9]{3})-([0-9]{4})-([0-9]{4})$");
                    Regex email = new Regex(@"^([\w]+)@([\w]+)\.([\w]+)$");

                    if (string.IsNullOrWhiteSpace(studnum.Text) || string.IsNullOrWhiteSpace(studname.Text)
                        || string.IsNullOrWhiteSpace(studsec.Text) || string.IsNullOrWhiteSpace(studemail.Text)
                        || string.IsNullOrWhiteSpace(studcourse.Text) || string.IsNullOrWhiteSpace(studgender.Text) || !id.IsMatch(studnum.Text) || !email.IsMatch(studemail.Text)
                        )
                    {
                        if (!id.IsMatch(studnum.Text) || !email.IsMatch(studemail.Text))
                        {
                            iValidate();
                        }
                        Validation();
                        errorhandler.Text = "* Please fill in all of the required fields";
                        studnumlabel.Text = "XXX-XXXX-XXXX";


                    }


                    else
                    {



                        cmd.ExecuteNonQuery();
                        errorhandler.Text = " ";
                        studnumlabel.Text = "Successfully Added";
                        ClearTextBoxes();
                        photo.Image = null;
                        name.Visible = false;
                        section.Visible = false;

                        ParameterizedThreadStart pts = new ParameterizedThreadStart(LoadGrid);
                        Thread t = new Thread(pts);
                        t.Start();
                    }


                }
                catch (Exception ee)
                {
                using (MySqlCommand sqlCommand = new MySqlCommand("SELECT COUNT(*) from studenttable where studnum = @username", connection))
                {

                    sqlCommand.Parameters.AddWithValue("@username", studnum.Text);

                    int userCount = Convert.ToInt16(sqlCommand.ExecuteScalar().ToString());

                    if (userCount > 0)
                    {
                        Invoke(new Action(() =>
                        {
                            errorProvider1.SetError(studnum, "The Student Number you entered is already existing");
                            errorhandler.Text = "* Student Number already EXISTS";
                        }));
                    }


                }
            }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            



        }

        public void LoadGrid(object state)
        {
            
            try {
                Invoke(new Action(() =>
                {
                    //For Buttons stuffs
                    add.Image = Properties.Resources.adde;
                    add.Enabled = true;
                    delete.Image = Properties.Resources.deleted;
                    delete.Enabled = false;
                    update.Image = Properties.Resources.updated;
                    update.Enabled = false;
                    errorProvider1.Clear();
                    pictureBox5.Enabled = true;
                    pictureBox5.Visible = true;
                    label6.Visible = true;
                }));
                //Datagridview
                MySqlConnection connection = new MySqlConnection(MyConnectionString);
                connection.Open();
                try
                {
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "Select * from studenttable";
                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adap.Fill(ds);
                    Invoke(new Action(() =>
                    {
                        pictureBox5.Enabled = false;
                        pictureBox5.Visible = false;
                        label6.Visible = false;
                        radGridView1.DataSource = ds.Tables[0].DefaultView;

                        label8.Text = "Student Information loading completed!";


                        radGridView1.Columns[0].HeaderText = "Student Number";
                        radGridView1.Columns[0].Width = 100;
                        radGridView1.Columns[1].HeaderText = "Name";
                        radGridView1.Columns[1].Width = 300;
                        radGridView1.Columns[2].HeaderText = "Section";
                        radGridView1.Columns[2].Width = 50;
                        radGridView1.Columns[3].HeaderText = "Email";
                        radGridView1.Columns[3].Width = 100;
                        radGridView1.Columns[4].HeaderText = "Course";
                        radGridView1.Columns[4].Width = 50;
                        radGridView1.Columns[5].HeaderText = "Gender";
                        radGridView1.Columns[5].Width = 150;
                        radGridView1.Columns[6].IsVisible = false;
                        radGridView1.Columns[7].IsVisible = false;
                        radGridView1.Columns[8].IsVisible = false;
                    }));
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }


        }

        private void radGridView1_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {

        }

        private void radGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
            ParameterizedThreadStart pts = new ParameterizedThreadStart(loadMyData);
            Thread t = new Thread(pts);
            t.Start();
        }


        public void loadMyData(object state)
        {
            try {
                Invoke(new Action(() =>
                {
                    foreach (GridViewRowInfo dr in radGridView1.SelectedRows)
                    {
                        errorProvider1.Clear();
                        errorhandler.Text = "";
                        add.Image = Properties.Resources.addd;
                        add.Enabled = false;
                        delete.Image = Properties.Resources.deletee;
                        delete.Enabled = true;
                        update.Image = Properties.Resources.updatee;
                        update.Enabled = true;



                        var data = (Byte[])(dr.Cells[6].Value);
                        var stream = new MemoryStream(data);

                        name.Visible = true;
                        section.Visible = true;


                        studnum.Text = dr.Cells[0].Value.ToString();
                        studname.Text = dr.Cells[1].Value.ToString();
                        studsec.Text = dr.Cells[2].Value.ToString();
                        studemail.Text = dr.Cells[3].Value.ToString();
                        studcourse.Text = dr.Cells[4].Value.ToString();
                        studgender.Text = dr.Cells[5].Value.ToString();
                        photo.Image = Image.FromStream(stream);
                        studnumlabel.Text = dr.Cells[0].Value.ToString();
                        name.Text = dr.Cells[1].Value.ToString();
                        section.Text = dr.Cells[2].Value.ToString();
                        label9.Text = dr.Cells[0].Value.ToString();

                    }
                }));
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
           
        }

        private void radGridView1_DataBindingComplete(object sender, GridViewBindingCompleteEventArgs e)
        {
            radGridView1.ClearSelection();
        }

        private void update_Click(object sender, EventArgs e)
        {

            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;


            try
            {

                connection.Open();

                MemoryStream ms = new MemoryStream();
                photo.Image.Save(ms, photo.Image.RawFormat);
                byte[] img = ms.ToArray();

                Regex id = new Regex(@"^([0-9]{3})-([0-9]{4})-([0-9]{4})$");
                Regex email = new Regex(@"^([\w]+)@([\w]+)\.([\w]+)$");

                cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE studenttable SET studnum= @valstudnum,studname=@valstudname,studsec=@valstudsec,studemail=@valstudemail,studcourse=@valstudcourse,studgender=@valstudgender,studpic=@valstudpic WHERE studnum=@OriginalId";
                cmd.Parameters.AddWithValue("@valstudnum", studnum.Text.ToString());
                cmd.Parameters.AddWithValue("@valstudname", studname.Text.ToString());
                cmd.Parameters.AddWithValue("@valstudsec", studsec.Text.ToString());
                cmd.Parameters.AddWithValue("@valstudemail", studemail.Text.ToString());
                cmd.Parameters.AddWithValue("@valstudcourse", studcourse.Text.ToString());
                cmd.Parameters.AddWithValue("@valstudgender", studgender.Text.ToString());
                cmd.Parameters.AddWithValue("@valstudpic", img);
                cmd.Parameters.AddWithValue("@OriginalId", label9.Text.ToString());

                if (string.IsNullOrWhiteSpace(studnum.Text) || string.IsNullOrWhiteSpace(studname.Text)
                    || string.IsNullOrWhiteSpace(studsec.Text) || string.IsNullOrWhiteSpace(studemail.Text)
                    || string.IsNullOrWhiteSpace(studcourse.Text) || string.IsNullOrWhiteSpace(studgender.Text)
                    )
                {
                    Validation();
                    errorhandler.Text = "*Please fill in all of the required fields";
                }
                if (!id.IsMatch(studnum.Text) || !email.IsMatch(studemail.Text))
                {
                    iValidate();
                }
                else
                {

                    cmd.ExecuteNonQuery();
                    errorhandler.Text = " ";
                    studnumlabel.Text = "Successfully Updated";
                    ClearTextBoxes();

                    name.Visible = false;
                    section.Visible = false;

                    ParameterizedThreadStart pts = new ParameterizedThreadStart(LoadGrid);
                    Thread t = new Thread(pts);
                    t.Start();
                }






            }
            catch (Exception es)
            {
                using (MySqlCommand sqlCommand = new MySqlCommand("SELECT COUNT(*) from studenttable where studnum = @username", connection))
                {

                    sqlCommand.Parameters.AddWithValue("@username", studnum.Text);

                    int userCount = Convert.ToInt16(sqlCommand.ExecuteScalar().ToString());

                    if (userCount > 0)
                    {
                        Invoke(new Action(() =>
                        {
                            errorProvider1.SetError(studnum, "The Student Number you entered is already existing");
                            errorhandler.Text = "* Student Number already EXISTS";
                        }));
                    }


                }
            }

            finally
            {
                
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    
                }
                
            }


        }



        public void updateUser()
        {

        }
        private void ClearTextBoxes()
        {
            studnum.Clear();
            studname.Clear();
            studsec.Clear();
            studemail.Clear();
            studcourse.Text = "Select Course";
            studgender.Text = "Select Gender";
            photo.Image = Properties.Resources.unknown;
        }



        private void studname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void Validation()
        {
            if (string.IsNullOrWhiteSpace(studname.Text))
            {
                //Validation failed, so set an appropriate error message
                errorProvider1.SetError(studname, "Enter name");
            }
            if (string.IsNullOrWhiteSpace(studsec.Text))
            {
                //Validation failed, so set an appropriate error message
                errorProvider1.SetError(studsec, "Enter Section");
            }
            if (studgender.Text.Equals("Select Gender"))
            {
                //Validation failed, so set an appropriate error message
                errorProvider1.SetError(studgender, "Select Gender");
            }
            if (string.IsNullOrWhiteSpace(studemail.Text))
            {
                //Validation failed, so set an appropriate error message
                errorProvider1.SetError(studemail, "Enter Email");
            }
            if (studcourse.Text.Equals("Select Course"))
            {
                //Validation failed, so set an appropriate error message
                errorProvider1.SetError(studcourse, "Select Course");
            }
        }

        private void studname_Leave(object sender, EventArgs e)
        {

        }

        private void studnum_Enter(object sender, EventArgs e)
        {

        }

        private void clear_Click(object sender, EventArgs e)
        {

            ClearTextBoxes();
            name.Visible = false;
            section.Visible = false;
            studnumlabel.Text = "XXX-XXXX-XXXX";

            add.Image = Properties.Resources.adde;
            add.Enabled = true;
            delete.Image = Properties.Resources.deleted;
            delete.Enabled = false;
            update.Image = Properties.Resources.updated;
            update.Enabled = false;
            photo.Image = Properties.Resources.unknown;

            ParameterizedThreadStart pts = new ParameterizedThreadStart(defaultData);
            Thread t = new Thread(pts);
            t.Start();
        }

        private void delete_Click(object sender, EventArgs e)
        {

            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;

            try
            {
                connection.Open();

                MemoryStream ms = new MemoryStream();
                if (!(photo.Image == null))
                    photo.Image.Save(ms, photo.Image.RawFormat);

                byte[] img = ms.ToArray();

                cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE FROM studenttable WHERE studnum = @valstudnum";
                cmd.Parameters.AddWithValue("@valstudnum", label9.Text.ToString());

                cmd.ExecuteNonQuery();
                errorhandler.Text = " ";
                studnumlabel.Text = "Successfully Deleted";
                ClearTextBoxes();
                photo.Image = Properties.Resources.unknown;
                name.Visible = false;
                section.Visible = false;

                ParameterizedThreadStart pts = new ParameterizedThreadStart(LoadGrid);
                Thread t = new Thread(pts);
                t.Start();

            }
            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
            }
            finally
            {

                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();

                }

            }

        }
        private void iValidate()
        {
            Regex id = new Regex(@"^([0-9]{3})-([0-9]{4})-([0-9]{4})$");
            Regex email = new Regex(@"^([\w]+)@([\w]+)\.([\w]+)$");
            if (!email.IsMatch(studemail.Text))
            {
                errorhandler.Text = "Invalid Email Address ";
                errorProvider1.SetError(studemail, "Enter a valid email address");
            }
            else
            {
                errorProvider1.Clear();
            }
            if (!id.IsMatch(studnum.Text))
            {
                errorhandler.Text = "Invalid Student ID ";
                errorProvider1.SetError(studnum, "Format must XXX-XXXX-XXXX");
            }
            else
            {
                errorProvider1.Clear();
            }

        }

        private void studemail_Leave(object sender, EventArgs e)
        {
            Regex email = new Regex(@"^([\w]+)@([\w]+)\.([\w]+)$");
            if (!email.IsMatch(studemail.Text))
            {
                errorProvider1.SetError(studemail, "Enter a valid email address");
            }
            else
            {
                errorProvider1.Clear();
            }

        }
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }


        bool forloadbooks;

        public void searchMyData(object state)
        {
            try
            {
                string text = state.ToString();
                using (MySqlConnection connection = new MySqlConnection(MyConnectionString))
                {
                    connection.Open();
                    MySqlCommand cmd = connection.CreateCommand();
                    //cmd.CommandText = "SELECT * from studenttable where studname like'" + text + "%' OR studnum like'" + text + "%' OR studcourse like'" + text + "%' OR studemail like'" + text + "%' OR studsec like'" + text + "%' OR studgender like'" + text + "%' ";
                    //cmd.CommandText = "SELECT * from studenttable where Match(studname) Against(@names IN BOOLEAN MODE) OR Match(studnum) Against(@names IN BOOLEAN MODE) OR Match(studcourse) Against(@names IN BOOLEAN MODE) OR Match(studemail) Against(@names IN BOOLEAN MODE) OR Match(studsec) Against(@names IN BOOLEAN MODE) OR Match(studgender) Against(@names IN BOOLEAN MODE) ";
                    //cmd.Parameters.AddWithValue("@names", text.ToString() + "*".ToString());
                    cmd.CommandText = "SELECT * from studenttable where Match(studname) Against(@names IN BOOLEAN MODE)";
                    cmd.Parameters.AddWithValue("@names", text.ToString() + "*".ToString());
                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adap.Fill(ds);
                    radGridView1.Invoke(new Action(() =>
                     { radGridView1.DataSource = ds.Tables[0].DefaultView; }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ss" + ex);
            }
        }

        public void defaultData(object state)
        {
            try
            {
                
                using (MySqlConnection connection = new MySqlConnection(MyConnectionString))
                {
                    connection.Open();
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "SELECT * from studenttable";
                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adap.Fill(ds);
                    radGridView1.Invoke(new Action(() =>
                    { radGridView1.DataSource = ds.Tables[0].DefaultView; }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ss" + ex);
            }
        }


        private void studnum_TextChanged(object sender, EventArgs e)
        {
            qrCodeImgControl1.Text = " " + studnum.Text;
        }

        private void studname_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchControl1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(searchControl1.Text))
            {
                forloadbooks = true;
                ParameterizedThreadStart pts = new ParameterizedThreadStart(searchMyData);
                Thread t = new Thread(pts);
                t.Start(searchControl1.Text);
            }
            else
            {
                if (forloadbooks)
                {

                    ParameterizedThreadStart pts = new ParameterizedThreadStart(defaultData);
                    Thread t = new Thread(pts);
                    t.Start();
                }
            }
        }

        private void qrCodeImgControl1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void studsec_TextChanged(object sender, EventArgs e)
        {

        }

        private void studemail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void studcourse_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void studgender_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}