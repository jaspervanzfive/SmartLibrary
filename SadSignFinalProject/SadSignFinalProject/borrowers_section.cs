using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
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
using Telerik.WinControls.UI;

namespace SadSignFinalProject
{
    public partial class borrowers_section : UserControl
    {
        public borrowers_section()
        {
            InitializeComponent();
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox3.Width - 3, pictureBox3.Height - 3);
            Region rg = new Region(gp);
            pictureBox3.Region = rg;

            System.Drawing.Drawing2D.GraphicsPath gp2 = new System.Drawing.Drawing2D.GraphicsPath();
            gp2.AddEllipse(0, 0, photo2.Width - 3, photo2.Height - 3);
            Region rg2 = new Region(gp2);
            photo2.Region = rg2;


            ParameterizedThreadStart pts = new ParameterizedThreadStart(LoadBorrowerList);
            Thread t = new Thread(pts);
            t.Start();

            ParameterizedThreadStart pts1 = new ParameterizedThreadStart(LoadReturnList);
            Thread t1 = new Thread(pts1);
            t1.Start();
        }
        private FilterInfoCollection Dispositivos;
        private VideoCaptureDevice FuenteDeVideo;
        string stud_id=null;
        private void borrowers_section_Load(object sender, EventArgs e)
        {

        }
        public void LoadBorrowerList(object state)
        {

                //Datagridview
                MySqlConnection connection = new MySqlConnection(MyConnectionString);
                connection.Open();
                try
                {
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "SELECT borrowerstable.id,booktable.booktitle,studenttable.studname,studenttable.studsec,studenttable.studcourse,borrowerstable.dateissue,borrowerstable.datereturn FROM booktable,borrowerstable,studenttable WHERE borrowerstable.idbook=booktable.bookid AND borrowerstable.studid = studenttable.studnum AND borrowerstable.datereturned is null";
                
                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adap.Fill(ds);
                    Invoke(new Action(() =>
                    {
                        radGridView1.Columns.Clear();

                        radGridView1.DataSource = ds.Tables[0].DefaultView;

                        radGridView1.Columns[0].IsVisible = false;
                        radGridView1.Columns[1].HeaderText = "Book Title";
                        radGridView1.Columns[1].Width = 300;
                        radGridView1.Columns[2].HeaderText = "Borrower's Name";
                        radGridView1.Columns[2].Width = 270;
                        radGridView1.Columns[3].HeaderText = "Section";
                        radGridView1.Columns[3].Width = 80;
                        radGridView1.Columns[4].HeaderText = "Course";
                        radGridView1.Columns[4].Width = 80;
                        radGridView1.Columns[5].HeaderText = "Date Issue";
                        radGridView1.Columns[5].Width = 120;
                        radGridView1.Columns[6].HeaderText = "Due Date";
                        radGridView1.Columns[6].Width = 120;
                        


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

        public void LoadReturnList(object state)
        {

            //Datagridview
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT booktable.booktitle,studenttable.studname,studenttable.studcourse,borrowerstable.dateissue,borrowerstable.datereturn,borrowerstable.datereturned FROM booktable,borrowerstable,studenttable WHERE borrowerstable.idbook=booktable.bookid AND borrowerstable.studid = studenttable.studnum AND borrowerstable.datereturned is not null";

                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                Invoke(new Action(() =>
                {
                    radGridView2.Columns.Clear();

                    radGridView2.DataSource = ds.Tables[0].DefaultView;

                    radGridView2.Columns[0].HeaderText = "Book Title";
                    radGridView2.Columns[0].Width = 300;
                    radGridView2.Columns[1].HeaderText = "Borrower's Name";
                    radGridView2.Columns[1].Width = 260;
                    radGridView2.Columns[2].HeaderText = "Course";
                    radGridView2.Columns[2].Width = 80;
                    radGridView2.Columns[3].HeaderText = "Date Issue";
                    radGridView2.Columns[3].Width = 100;
                    radGridView2.Columns[4].HeaderText = "Due Date";
                    radGridView2.Columns[4].Width = 100;
                    radGridView2.Columns[5].HeaderText = "Returned Date";
                    radGridView2.Columns[5].Width = 100;



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

        private void radRadioButton2_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            
            
           
        }
        
        private void radRadioButton1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
      
            

        }
        MySqlConnection mcon = new MySqlConnection("Server=localhost;Port=3306;database=library_management;Uid=root;Pwd='0e15ecJasper'");
        MySqlCommand mcd;
        MySqlDataReader mdr;
        string s;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
        private void studentsSearching(object staet)
        {
            try
            {
                string text = staet.ToString();
                mcon.Open();
                s = "select * from studenttable where studnum='" + text + "';";
                mcd = new MySqlCommand(s, mcon);
                mdr = mcd.ExecuteReader();
                if (mdr.Read())
                {
                    this.Invoke(new Action(() =>
                    {
                        string fullanme = mdr.GetString("studname");
                        string sectionss = mdr.GetString("studsec");
                        string studnumber = mdr.GetString("studnum");
                        int borrows = Convert.ToInt32(mdr.GetString("booksborrowed"));
                        stud_id = mdr.GetString("studnum");
                        byte[] byteBLOBData = (byte[])mdr["studpic"];
                        var stream = new MemoryStream(byteBLOBData);
                        pictureBox3.Image = Image.FromStream(stream);
                        



                        name.Visible = true;
                        section.Visible = true;
                        label2.Visible = true;
                        booksborrowed.Visible = true;

                        studnumlabel.Text = studnumber;
                        name.Text = fullanme;
                        section.Text = sectionss;
                        booksborrowed.Text = Convert.ToString(borrows);

                        select.Enabled = true;
                        select.Image = Properties.Resources.select;

                    }));
                    mdr.Close();
                    mcon.Close();

                }
                else {
                    this.Invoke(new Action(() =>
                    {
                        studnumlabel.Text = "No Records Found";
                        name.Visible = false;
                        section.Visible = false;
                        label2.Visible = false;
                        booksborrowed.Visible = false;
                        pictureBox3.Image = Properties.Resources.unknown;
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

        private void select_Click(object sender, EventArgs e)
        {
            ParameterizedThreadStart pts = new ParameterizedThreadStart(whenSelect);
            Thread t = new Thread(pts);
            t.Start();
        }
        private void whenSelect(object state)
        {
            this.Invoke(new Action(() =>
            {
                label5.Visible = false;

                photo2.Visible = true;
                studnum2.Visible = true;
                studname2.Visible = true;

                photo2.Image = pictureBox3.Image;
                studnum2.Text = studnumlabel.Text;
                studname2.Text = name.Text;
                

                studnumlabel.Text = "XXX-XXX-XXX";
                name.Visible = false;
                section.Visible = false;
                label2.Visible = false;
                booksborrowed.Visible = false;
                select.Enabled = false;
                pictureBox3.Image = Properties.Resources.unknown;
                issue.Image = Properties.Resources.issue;
                select.Image = Properties.Resources.selectd;
                returnbook.Enabled = false;
                returnbook.Image = Properties.Resources.returnd;
            }));
            
                ParameterizedThreadStart pts = new ParameterizedThreadStart(LoadStudentBooks);
                Thread t = new Thread(pts);
                t.Start();

                ParameterizedThreadStart pts1 = new ParameterizedThreadStart(LoadStudentReturnList);
                Thread t1 = new Thread(pts1);
                t1.Start();
            
        }
        string MyConnectionString = "Server=localhost;Port=3306;database=library_management;Uid=root;Pwd='0e15ecJasper'";
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            
        }

        private void issue_Click(object sender, EventArgs e)
        {
            
        }
       
        private void LoadStudentBooks(object state)
        {

            //Datagridview
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT borrowerstable.id,borrowerstable.idbook,booktable.booktitle,booktable.bookauthor,borrowerstable.dateissue,borrowerstable.datereturn from booktable,borrowerstable WHERE borrowerstable.idbook = booktable.bookid AND borrowerstable.studid=@stud AND datereturned is null";
                cmd.Parameters.AddWithValue("@stud",stud_id.ToString());
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                Invoke(new Action(() =>
                {
                    radGridView1.Columns.Clear();
                    radGridView1.DataSource = ds.Tables[0].DefaultView;

                    radGridView1.Columns[0].IsVisible = false;
                    radGridView1.Columns[1].IsVisible = false;
                    radGridView1.Columns[2].HeaderText = "Book Title";
                    radGridView1.Columns[2].Width = 350;
                    radGridView1.Columns[3].HeaderText = "Book Author";
                    radGridView1.Columns[3].Width = 250;
                    radGridView1.Columns[4].HeaderText = "Date Issued";
                    radGridView1.Columns[4].Width = 180;
                    radGridView1.Columns[5].HeaderText = "Due Date";
                    radGridView1.Columns[5].Width = 180;



                    
                    


                    

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

        public void LoadStudentReturnList(object state)
        {

            //Datagridview
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT booktable.booktitle,booktable.bookauthor,borrowerstable.dateissue,borrowerstable.datereturn,borrowerstable.datereturn from booktable,borrowerstable WHERE borrowerstable.idbook = booktable.bookid AND borrowerstable.studid=@stud AND datereturned is not null";
                cmd.Parameters.AddWithValue("@stud", stud_id.ToString());
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                Invoke(new Action(() =>
                {
                    radGridView2.Columns.Clear();

                    radGridView2.DataSource = ds.Tables[0].DefaultView;

                    radGridView2.Columns[0].HeaderText = "Book Title";
                    radGridView2.Columns[0].Width = 350;
                    radGridView2.Columns[1].HeaderText = "Book Author";
                    radGridView2.Columns[1].Width = 250;
                    radGridView2.Columns[2].HeaderText = "Date Issued";
                    radGridView2.Columns[2].Width = 180;
                    radGridView2.Columns[3].HeaderText = "Due Date";
                    radGridView2.Columns[3].Width = 180;
                    radGridView2.Columns[4].HeaderText = "Returned Date";
                    radGridView2.Columns[4].Width = 180;



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

        private void tileBarItem1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            

            searchControl1.Visible = true;
                label1.Visible = true;
                pictureBox1.Visible = true;


                
                pictureBox1.Enabled = true;
                pictureBox1.Image = Properties.Resources.find;
                searchControl1.Enabled = true;
            
           
        }
        
        private void tileBarItem4_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            camera1 issue = new camera1();
            issue.ShowDialog();
            issue.Opgave.ToString();

            string samp = issue.Opgave.ToString();
            if (samp != "label2")
            {
                ParameterizedThreadStart pts = new ParameterizedThreadStart(studentsSearching);
                Thread t = new Thread(pts);
                t.Start(samp.ToString());
            }
            
            /*
            issue.Opgave.ToString();
            string samp = issue.Opgave.ToString();
            */


        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            ParameterizedThreadStart pts = new ParameterizedThreadStart(studentsSearching);
            Thread t = new Thread(pts);
            t.Start(searchControl1.Text.ToString());
        }

        private void studnum2_Click(object sender, EventArgs e)
        {

        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                
                issue.Enabled = false;
                returnbook.Enabled = false;
                issue.Image = Properties.Resources.issued;
                returnbook.Image = Properties.Resources.returnd;
            }
            else
            {
                if (studnum2.Visible == true)
                {
                    issue.Enabled = true;
                    issue.Image = Properties.Resources.issue;
                    if (book_id != null)
                    {
                        returnbook.Enabled = true;
                        returnbook.Image = Properties.Resources._return;
                    }
                }
            }
        }
        string borrow_id = null;
        string book_id = null;
        private void radGridView1_SelectionChanged(object sender, EventArgs e)
        {
            ParameterizedThreadStart pts = new ParameterizedThreadStart(loadMyData);
            Thread t = new Thread(pts);
            t.Start();
        }

        public void loadMyData(object state)
        {
            Invoke(new Action(() =>
            {
                if (studnum2.Visible == true)
                {
                    returnbook.Enabled = true;
                    returnbook.Image = Properties.Resources._return;
                }
                else
                {
                    returnbook.Enabled = false;
                    returnbook.Image = Properties.Resources.returnd;
                }
            }));

                try
            {
                Invoke(new Action(() =>
                {
                    if (studnum2.Visible == true)
                    {
                        foreach (GridViewRowInfo dr in radGridView1.SelectedRows)
                        {


                           
                            borrow_id = dr.Cells[0].Value.ToString();
                            book_id = dr.Cells[1].Value.ToString();
                        }
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

        private void returnbook_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            MySqlCommand cmd1;
            MySqlCommand cmd2;
            connection.Open();

            //string dateToday = DateTime.Now.ToString("dddd, d MMM, yyyy 'at' HH:mm");
            string dateToday = DateTime.Now.ToString("MMM d yyyy HH:mm");

            try
            {

                cmd = connection.CreateCommand();
                cmd1 = connection.CreateCommand();
                cmd2 = connection.CreateCommand();
                Invoke(new Action(() =>
                {
                    cmd.CommandText = "UPDATE borrowerstable SET datereturned = @datereturn where id=@idbook";
                    cmd1.CommandText = "UPDATE studenttable SET booksborrowed = booksborrowed - 1 where studnum=@studid";
                    cmd2.CommandText = "UPDATE booktable SET bookquantity = bookquantity + 1 where bookid=@bookid";

                    cmd.Parameters.AddWithValue("@idbook", borrow_id.ToString());
                    cmd.Parameters.AddWithValue("@datereturn", dateToday.ToString());
                    cmd1.Parameters.AddWithValue("@studid", stud_id.ToString());
                    cmd2.Parameters.AddWithValue("@bookid", book_id.ToString());

                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                }));

                ParameterizedThreadStart pts = new ParameterizedThreadStart(LoadStudentBooks);
                Thread t = new Thread(pts);
                t.Start();

                ParameterizedThreadStart pts1 = new ParameterizedThreadStart(LoadStudentReturnList);
                Thread t1 = new Thread(pts1);
                t1.Start();


            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            }

        private void issue_Click_1(object sender, EventArgs e)
        {
            IssueBooks issue = new IssueBooks(this);
            issue.TEXTINFO = studnum2.Text;
            issue.ShowDialog();

            issue.Opgave.ToString();
            string samp = issue.Opgave.ToString();

            if (samp == "refresh")
            {
                ParameterizedThreadStart pts = new ParameterizedThreadStart(LoadStudentBooks);
                Thread t = new Thread(pts);
                t.Start();
            }


        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                studnumlabel.Text = "XXX-XXX-XXX";
                name.Visible = false;
                section.Visible = false;
                label2.Visible = false;
                booksborrowed.Visible = false;
                pictureBox3.Image = Properties.Resources.unknown;

                photo2.Visible = false;
                studnum2.Visible = false;
                studname2.Visible = false;

                label5.Visible = true;


            }));

            ParameterizedThreadStart pts = new ParameterizedThreadStart(LoadBorrowerList);
            Thread t = new Thread(pts);
            t.Start();

            ParameterizedThreadStart pts1 = new ParameterizedThreadStart(LoadReturnList);
            Thread t1 = new Thread(pts1);
            t1.Start();
        }
    }
}
