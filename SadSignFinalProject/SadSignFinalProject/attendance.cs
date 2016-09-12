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
    public partial class attendance : UserControl
    {
        public attendance()
        {
            InitializeComponent();

            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox1.Width - 3, pictureBox1.Height - 3);
            Region rg = new Region(gp);
            pictureBox1.Region = rg;

            ParameterizedThreadStart pts = new ParameterizedThreadStart(LoadAttendanceList);
            Thread t = new Thread(pts);
            t.Start();
        }

        private void attendance_Load(object sender, EventArgs e)
        {

        }
        string MyConnectionString = "Server=localhost;Port=3306;database=library_management;Uid=root;Pwd='0e15ecJasper'";
        MySqlConnection mcon = new MySqlConnection("Server=localhost;Port=3306;database=library_management;Uid=root;Pwd='0e15ecJasper'");
        MySqlCommand mcd;
        MySqlDataReader mdr;
        string s;
        public void LoadAttendanceList(object state)
        {

            //Datagridview
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT DISTINCT studenttable.studname,studenttable.studsec,studenttable.studnum,attendancetable.date,studenttable.studpic FROM attendancetable,studenttable WHERE attendancetable.studid=studenttable.studnum ORDER BY attendancetable.id DESC";

                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                Invoke(new Action(() =>
                {
                    radGridView1.Columns.Clear();

                    radGridView1.DataSource = ds.Tables[0].DefaultView;

                    radGridView1.Columns[0].HeaderText = "Student Name";
                    radGridView1.Columns[0].Width = 300;
                    radGridView1.Columns[1].HeaderText = "Section";
                    radGridView1.Columns[1].Width = 120;
                    radGridView1.Columns[2].HeaderText = "Student Number";
                    radGridView1.Columns[2].Width = 180;
                    radGridView1.Columns[3].HeaderText = "Date";
                    radGridView1.Columns[3].Width = 120;
                    radGridView1.Columns[4].IsVisible = false;






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


                        var data = (Byte[])(dr.Cells[4].Value);
                        var stream = new MemoryStream(data);

                        name.Visible = true;
                        section.Visible = true;


                        studnumlabel.Text = dr.Cells[2].Value.ToString();
      
                        name.Text = dr.Cells[0].Value.ToString();
                        section.Text = dr.Cells[1].Value.ToString();

                        pictureBox1.Image = Image.FromStream(stream);
                        ParameterizedThreadStart pts = new ParameterizedThreadStart(loadDateAndTime);
                        Thread t = new Thread(pts);
                        t.Start();

                    }
                }));
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        public void loadDateAndTime(object state)
        {

            //Datagridview
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT date,time from attendancetable where studid=@studid ORDER by attendancetable.id DESC";
                cmd.Parameters.AddWithValue("@studid",studnumlabel.Text.ToString());
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                Invoke(new Action(() =>
                {
                    radGridView2.Columns.Clear();

                    radGridView2.DataSource = ds.Tables[0].DefaultView;

                    radGridView2.Columns[0].HeaderText = "Date";
                    radGridView2.Columns[0].Width = 210;
                    radGridView2.Columns[1].HeaderText = "Time";
                    radGridView2.Columns[1].Width = 210;
                  

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

        private void radGridView1_DataBindingComplete(object sender, GridViewBindingCompleteEventArgs e)
        {
            radGridView1.ClearSelection();
        }

        private void radGridView1_Click(object sender, EventArgs e)
        {

        }
    }
}
