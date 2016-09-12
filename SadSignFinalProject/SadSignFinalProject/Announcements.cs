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
    public partial class Announcements : UserControl
    {
        public Announcements()
        {
            InitializeComponent();
        }

        private void Announcements_Load(object sender, EventArgs e)
        {
            ParameterizedThreadStart pts = new ParameterizedThreadStart(LoadAnnouncements);
            Thread t = new Thread(pts);
            t.Start();
        }

        string MyConnectionString = "Server=localhost;Port=3306;database=library_management;Uid=root;Pwd='0e15ecJasper'";
        MySqlConnection mcon = new MySqlConnection("Server=localhost;Port=3306;database=library_management;Uid=root;Pwd='0e15ecJasper'");
        MySqlCommand mcd;
        MySqlDataReader mdr;
        string s;
        public void LoadAnnouncements(object state)
        {

            //Datagridview
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT id,message from announcementtable ORDER BY announcementtable.id DESC";

                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                Invoke(new Action(() =>
                {
                    radGridView1.Columns.Clear();

                    radGridView1.DataSource = ds.Tables[0].DefaultView;

                    radGridView1.Columns[0].IsVisible = false;
                    radGridView1.Columns[1].HeaderText = "Announcements";
                    radGridView1.Columns[1].Width = 1300;
                    






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

        private void add_Click(object sender, EventArgs e)
        {
            ParameterizedThreadStart pts = new ParameterizedThreadStart(AttendanceAdd);
            Thread t = new Thread(pts);
            t.Start();
        }

        private void AttendanceAdd(object state)
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();

            try
            {
                cmd = connection.CreateCommand();

                Invoke(new Action(() =>
                {

                    cmd.CommandText = "INSERT INTO announcementtable(message)VALUES(@message)";

                    cmd.Parameters.AddWithValue("@message", textEdit1.Text.ToString());
                    
                    cmd.ExecuteNonQuery();

                }));

                ParameterizedThreadStart pts = new ParameterizedThreadStart(LoadAnnouncements);
                Thread t = new Thread(pts);
                t.Start();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void radGridView1_SelectionChanged(object sender, EventArgs e)
        {
            ParameterizedThreadStart pts = new ParameterizedThreadStart(loadMyData);
            Thread t = new Thread(pts);
            t.Start();
        }
        string borrow_id = null;
        public void loadMyData(object state)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    foreach (GridViewRowInfo dr in radGridView1.SelectedRows)
                    {
                        
                        delete.Image = Properties.Resources.deletee;
                        delete.Enabled = true;

                        borrow_id = dr.Cells[0].Value.ToString();
                        
                        

                    }
                }));
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(MyConnectionString);
                MySqlCommand cmd;
                connection.Open();

                
                cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE FROM announcementtable WHERE id = @valstudnum";
                cmd.Parameters.AddWithValue("@valstudnum", borrow_id.ToString());

                cmd.ExecuteNonQuery();

                ParameterizedThreadStart pts = new ParameterizedThreadStart(LoadAnnouncements);
                Thread t = new Thread(pts);
                t.Start();

            }
            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
            }
        
    }
    }
}
