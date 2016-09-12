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
    public partial class StaffTable : UserControl
    {
        public StaffTable()
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

        private void StaffTable_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        string MyConnectionString = "Server=localhost;Port=3306;database=library_management;Uid=root;Pwd='0e15ecJasper'";
        public void LoadGrid(object state)
        {

            try
            {
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
                    cmd.CommandText = "Select * from stafftable";
                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adap.Fill(ds);
                    Invoke(new Action(() =>
                    {
                        pictureBox5.Enabled = false;
                        pictureBox5.Visible = false;
                        label6.Visible = false;
                        radGridView1.DataSource = ds.Tables[0].DefaultView;

                        radGridView1.Columns[0].HeaderText = "Staff Number";
                        radGridView1.Columns[0].Width = 150;
                        radGridView1.Columns[1].HeaderText = "Name";
                        radGridView1.Columns[1].Width = 400;
                        radGridView1.Columns[2].HeaderText = "Position";
                        radGridView1.Columns[2].Width = 100;
                        radGridView1.Columns[3].HeaderText = "Passcode";
                        radGridView1.Columns[3].Width = 100 ;
                        radGridView1.Columns[4].IsVisible = false;
                        radGridView1.Columns[5].IsVisible = false;

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

        private void studsec_TextChanged(object sender, EventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {

          


        }

        private void Validation()
        {
            if (string.IsNullOrWhiteSpace(studname.Text))
            {
                //Validation failed, so set an appropriate error message
                errorProvider1.SetError(studname, "Enter name");
            }

            if (studsec.Text.Length!=4)
            {
                //Validation failed, so set an appropriate error message
                errorProvider1.SetError(studsec, "Enter a 4 digit code");
            }

            if (string.IsNullOrWhiteSpace(studsec.Text))
            {
                //Validation failed, so set an appropriate error message
                errorProvider1.SetError(studsec, "Enter Passcode");
            }
            
            
            if (studcourse.Text.Equals("Select Course"))
            {
                //Validation failed, so set an appropriate error message
                errorProvider1.SetError(studcourse, "Select Position");
            }
        }

        private void ClearTextBoxes()
        {
            studnum.Clear();
            studname.Clear();
            studsec.Clear();
            studcourse.Text = "Select Position";
            photo.Image = Properties.Resources.unknown;
            studnumlabel.Text = "XXX-XXXX";
            name.Text = "";
            section.Text = "";
            errorProvider1.Clear();
        }   

        private void studnum_TextChanged(object sender, EventArgs e)
        {
            qrCodeImgControl1.Text = " " + studnum.Text;
        }

        private void radGridView1_Click(object sender, EventArgs e)
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
            try
            {
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



                        var data = (Byte[])(dr.Cells[4].Value);
                        var stream = new MemoryStream(data);

                        name.Visible = true;
                        section.Visible = true;


                        studnum.Text = dr.Cells[0].Value.ToString();
                        studname.Text = dr.Cells[1].Value.ToString();
                        studsec.Text = dr.Cells[3].Value.ToString();
                        
                        studcourse.Text = dr.Cells[2].Value.ToString();
                        
                        photo.Image = Image.FromStream(stream);
                        studnumlabel.Text = dr.Cells[0].Value.ToString();
                        name.Text = dr.Cells[1].Value.ToString();
                        section.Text = dr.Cells[3].Value.ToString();
                        label9.Text = dr.Cells[0].Value.ToString();

                    }
                }));
            }
            catch (Exception ee)
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
           
            MemoryStream ms = new MemoryStream();

            
            try
            {
                MessageBox.Show("d");
                connection.Open();
                //qrcodex
                photo.Image.Save(ms, photo.Image.RawFormat);
                byte[] img = ms.ToArray();

                MemoryStream qrCodex = new MemoryStream();
                Image imgs = (Image)qrCodeImgControl1.Image.Clone();
                imgs.Save(qrCodex, imgs.RawFormat);
                byte[] qrCodes = qrCodex.ToArray();

                cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE stafftable SET staffnum= @valstudnum,fullname=@valstudname,passcode=@valstudsec,position=@valstudcourse,picture=@valstudpic,qrcode=@qrcode WHERE staffnum = @id";
                cmd.Parameters.AddWithValue("@valstudnum", studnum.Text.ToString());
                cmd.Parameters.AddWithValue("@valstudname", studname.Text.ToString());
                cmd.Parameters.AddWithValue("@valstudsec", studsec.Text.ToString());
                
                cmd.Parameters.AddWithValue("@valstudcourse", studcourse.Text.ToString());
                cmd.Parameters.AddWithValue("@qrcode", qrCodes);
                cmd.Parameters.AddWithValue("@valstudpic", img);
                cmd.Parameters.AddWithValue("@id", label9.Text.ToString());

                Regex id = new Regex(@"^([0-9]{3})-([0-9]{4})$");


                if (string.IsNullOrWhiteSpace(studnum.Text) || string.IsNullOrWhiteSpace(studname.Text)
                    || string.IsNullOrWhiteSpace(studsec.Text) || string.IsNullOrWhiteSpace(studcourse.Text) || !id.IsMatch(studnum.Text)
                    )
                {
                    if (!id.IsMatch(studnum.Text))
                    {
                        errorhandler.Text = "* Please follow the format for staff number";
                        errorProvider1.SetError(studnum, "XXX-XXXX (eg. 001-1234)");

                    }

                    Validation();
                    errorhandler.Text = "* Please fill in all of the required fields";
                    studnumlabel.Text = "XXX-XXXX";


                }


                else
                {



                    cmd.ExecuteNonQuery();
                    errorhandler.Text = " ";
                    studnumlabel.Text = "Successfully Updated";
                    ClearTextBoxes();
                    photo.Image = Properties.Resources.unknown;
                    name.Visible = false;
                    section.Visible = false;

                    ParameterizedThreadStart pts = new ParameterizedThreadStart(LoadGrid);
                    Thread t = new Thread(pts);
                    t.Start();
                }


            }
            catch (Exception ee)
            {
                using (MySqlCommand sqlCommand = new MySqlCommand("SELECT COUNT(*) from stafftable where staffnum = @username", connection))
                {

                    sqlCommand.Parameters.AddWithValue("@username", studnum.Text);

                    int userCount = Convert.ToInt16(sqlCommand.ExecuteScalar().ToString());

                    if (userCount > 0)
                    {
                        Invoke(new Action(() =>
                        {
                            errorProvider1.SetError(studnum, "The Staff Number you entered is already existing");
                            errorhandler.Text = "* Staff Number already EXISTS";
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

        private void upload_Click(object sender, EventArgs e)
        {
            //upload picture
            OpenFileDialog opf = new OpenFileDialog(); opf.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                photo.Image = Image.FromFile(opf.FileName);
                //photo.Image = ResizeImage(photo.Image, 179, 173);
            }
        }

        private void studname_TextChanged(object sender, EventArgs e)
        {

        }

        private void studname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void studsec_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
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
                cmd.CommandText = "DELETE FROM stafftable WHERE staffnum = @valstudnum";
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

        private void add_Click_1(object sender, EventArgs e)
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
                cmd.CommandText = "INSERT INTO stafftable(staffnum,fullname,position,passcode,picture,qrcode)VALUES(@valstudnum,@valstudname,@valstudsec,@valstudemail,@valstudpic,@qrcode)";
                cmd.Parameters.AddWithValue("@valstudnum", studnum.Text.ToString());
                cmd.Parameters.AddWithValue("@valstudname", studname.Text.ToString());
                cmd.Parameters.AddWithValue("@valstudsec", studcourse.Text.ToString());
                cmd.Parameters.AddWithValue("@valstudemail", studsec.Text.ToString());
                cmd.Parameters.AddWithValue("@valstudpic", img);
                cmd.Parameters.AddWithValue("@qrcode", qrCodes);

                Regex id = new Regex(@"^([0-9]{3})-([0-9]{4})$");


                if (string.IsNullOrWhiteSpace(studnum.Text) || string.IsNullOrWhiteSpace(studname.Text)
                    || string.IsNullOrWhiteSpace(studsec.Text) || string.IsNullOrWhiteSpace(studcourse.Text) || !id.IsMatch(studnum.Text)
                    )
                {
                    if (!id.IsMatch(studnum.Text))
                    {
                        errorhandler.Text = "* Please follow the format for staff number";
                        errorProvider1.SetError(studnum, "XXX-XXXX (eg. 001-1234)");

                    }

                    Validation();
                    errorhandler.Text = "* Please fill in all of the required fields";
                    studnumlabel.Text = "XXX-XXXX";


                }


                else
                {



                    cmd.ExecuteNonQuery();
                    errorhandler.Text = " ";
                    studnumlabel.Text = "Successfully Added";
                    ClearTextBoxes();
                    photo.Image = Properties.Resources.unknown;
                    name.Visible = false;
                    section.Visible = false;

                    ParameterizedThreadStart pts = new ParameterizedThreadStart(LoadGrid);
                    Thread t = new Thread(pts);
                    t.Start();
                }


            }
            catch (Exception ee)
            {
                using (MySqlCommand sqlCommand = new MySqlCommand("SELECT COUNT(*) from stafftable where staffnum = @username", connection))
                {

                    sqlCommand.Parameters.AddWithValue("@username", studnum.Text);

                    int userCount = Convert.ToInt16(sqlCommand.ExecuteScalar().ToString());

                    if (userCount > 0)
                    {
                        Invoke(new Action(() =>
                        {
                            errorProvider1.SetError(studnum, "The Staff Number you entered is already existing");
                            errorhandler.Text = "* Staff Number already EXISTS";
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
    }
}
