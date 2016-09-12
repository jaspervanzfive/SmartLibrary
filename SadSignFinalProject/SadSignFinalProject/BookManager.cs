using System;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using System.Threading;
using System.Text.RegularExpressions;
using BarcodeLib.Barcode.WinForms;
using DevExpress;
using DevExpress.XtraBars.Ribbon;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


namespace SadSignFinalProject
{
    public partial class BookManager : UserControl
    {
        public BookManager()
        {
            InitializeComponent();
            //avoid flickers
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);

            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.StartFigure();
            gp.AddArc(new Rectangle(0, 0, 40, 40), 180, 90);
            gp.AddLine(40, 0, pictureBox1.Width - 40, 0);
            gp.AddArc(new Rectangle(pictureBox1.Width - 40, 0, 40, 40), -90, 90);
            gp.AddLine(pictureBox1.Width, 40, pictureBox1.Width, pictureBox1.Height - 40);
            gp.AddArc(new Rectangle(pictureBox1.Width - 40, pictureBox1.Height - 40, 40, 40), 0, 90);
            gp.AddLine(pictureBox1.Width - 40, pictureBox1.Height, 40, pictureBox1.Height);
            gp.AddArc(new Rectangle(0, pictureBox1.Height - 40, 40, 40), 90, 90);
            gp.CloseFigure();
            pictureBox1.Region = new Region(gp);
            _TypeGlobal = true;



            ParameterizedThreadStart pts = new ParameterizedThreadStart(LoadBooks);
            Thread t = new Thread(pts);
            t.Start("ID");



        }

        public bool _TypedInto;
        public bool _TypeGlobal;
        GalleryItemGroup group = new GalleryItemGroup();
        public void LoadBooks(object state)
        {
            try {
                string sorts = state.ToString();

                //GalleryItemGroup group = null;
                //ImageList myImageList1 = null;
                Invoke(new Action(() =>
                {
                    group.Items.Clear();
                    add.Image = Properties.Resources.adde;
                    update.Image = Properties.Resources.updated;
                    delete.Image = Properties.Resources.deleted;
                    add.Enabled = true;
                    update.Enabled = false;
                    delete.Enabled = false;
                    errorProvider1.Clear();


                //galleryControl1.Gallery.Groups[0].Items.Clear();
                //  group = new GalleryItemGroup();



                group.Caption = "All books";
                    group.CaptionAlignment = GalleryItemGroupCaptionAlignment.Center;
                //galleryControl1.Gallery.AllowHoverImages = true;


                //galleryControl1.Gallery.ShowItemText = true;
                //galleryControl1.Gallery.ImageSize = new System.Drawing.Size(80, 80);
                //galleryControl1.Gallery.HoverImageSize = new System.Drawing.Size(20, 20);


                //listView1.Clear();
                label9.Visible = true;
                    pictureBox6.Enabled = true;
                    pictureBox6.Visible = true;
                /*
                myImageList1 = new ImageList();
                myImageList1.ColorDepth = ColorDepth.Depth32Bit;    
                listView1.LargeImageList = myImageList1;
                listView1.LargeImageList.ImageSize = new System.Drawing.Size(80, 80);*/


                }));

                MySqlConnection connection = null;
                try
                {
                    connection = new MySqlConnection(MyConnectionString);
                    connection.Open();

                    MySqlCommand cmd = connection.CreateCommand();
                    if (sorts == "Title")
                        cmd.CommandText = "Select * from booktable order by booktitle";
                    else if (sorts == "ID")
                        cmd.CommandText = "Select * from booktable order by bookid";
                    else if (sorts == "Author")
                        cmd.CommandText = "Select * from booktable order by bookauthor";
                    else
                        cmd.CommandText = "Select * from booktable ";
                    //cmd.Parameters.AddWithValue("@booktitle",sorts.ToString());
                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    DataTable ds = new DataTable();
                    adap.Fill(ds);
                    Invoke(new Action(() =>
                    {
                        pictureBox6.Visible = false;
                        pictureBox6.Enabled = false;
                        label9.Visible = false;
                    }));


                    Invoke(new Action(() =>
                    {
                        for (int i = 0; i < ds.Rows.Count; i++)
                        {
                            byte[] byteBLOBData = (byte[])ds.Rows[i]["bookphoto"];
                            var stream = new MemoryStream(byteBLOBData);

                            Image bookimages = Image.FromStream(stream);
                            string author = ds.Rows[i]["bookauthor"].ToString();
                            string title = ds.Rows[i]["booktitle"].ToString();



                            group.Items.Add(new GalleryItem(bookimages, title, author));
                            group.Items[i].HoverImage = group.Items[i].Image;

                        //group.Items.Add(new GalleryItem(bookimages, String.Format(title, i), author));
                        //galleryControl1.Gallery.Groups[0].Items.Add(new GalleryItem(bookimages, title, author));
                        //galleryControl1.Gallery.Groups[0].Items[i].HoverImage = galleryControl1.Gallery.Groups[0].Items[i].Image;
                        //galleryControl1.Gallery.HoverImages = bookimages;

                        /*
                            myImageList1.Images.Add(bookimages);
                            ListViewItem lsvparent = new ListViewItem();
                            lsvparent.Text = ds.Rows[i]["booktitle"].ToString();
                            string author = ds.Rows[i]["bookauthor"].ToString();
                            listView1.Items.Add(lsvparent.Text + "\nby "+ author, i);
                        */

                        }
                    }));
                }
                finally
                {
                    if (connection != null && connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
            catch(Exception ee)
            {
                System.Windows.Forms.MessageBox.Show(ee.Message);
            }
        }

        string orginalId = null;

        private void GalleryItemGroup()
        {
            throw new NotImplementedException();
        }

        



        private void BookManager_Load(object sender, EventArgs e)
        {

            galleryControl1.Gallery.Groups.Add(group);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bookId_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void upload_Click(object sender, EventArgs e)
        {
            //upload picture
            OpenFileDialog opf = new OpenFileDialog(); opf.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                photo.Image = Image.FromFile(opf.FileName);
                //image = ResizeImage(image, this.Width, this.Height);
                photo.Image = ResizeImage(photo.Image, 95, 131);
                //photo.Image = image;


            }
        }
        string MyConnectionString = "Server=localhost;Port=3306;database=library_management;Uid=root;Pwd='0e15ecJasper'";

        private void add_Click(object sender, EventArgs e)
        {
            ParameterizedThreadStart pts = new ParameterizedThreadStart(addBook);
            Thread t = new Thread(pts);
            t.Start();

        }

        public static Image resizeImage(Image imgToResize, System.Drawing.Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        string BCforScanner = null;

        private void BarcodeforScanner()
        {
            BarcodeLib.Barcode.Linear barcode = new BarcodeLib.Barcode.Linear();
            barcode.Type = BarcodeLib.Barcode.BarcodeType.CODE128;
            barcode.Data = " " + bookid.Text.ToString();

            barcode.UOM = BarcodeLib.Barcode.UnitOfMeasure.PIXEL;
            barcode.BarWidth = 1;
            barcode.BarHeight = 80;
            barcode.LeftMargin = 10;
            barcode.RightMargin = 10;
            barcode.TopMargin = 10;
            barcode.BottomMargin = 10;

            barcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;
            // more barcode settings here
            Bitmap bmp = barcode.drawBarcode();
            this.pictureBox2.Image = bmp;
        }

        private void addBook(object state)
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();

            BarcodeforScanner();




            Bitmap bmp = null;
            Invoke(new Action(() =>
            {
                bmp = new Bitmap(111, 145);
                pictureBox3.DrawToBitmap(bmp, new Rectangle(0, 0, 111, 145));
                photo.DrawToBitmap(bmp, new Rectangle(2, 10, 95, 131));
                    //pictureBox2.Image = bmp;
                }));
            MemoryStream memorySt = new MemoryStream();
            pictureBox2.Image.Save(memorySt, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] barcode13 = memorySt.ToArray();

            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] img = ms.ToArray();

            //coverphoto
            MemoryStream ms1 = new MemoryStream();
            photo.Image.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] coverphoto = ms1.ToArray();

            try
            {
                cmd = connection.CreateCommand();
                Invoke(new Action(() =>
              {


                  errorProvider1.Clear();
                  cmd.CommandText = "INSERT INTO booktable(bookid,isbn,booktitle,bookauthor,bookpub,bookdept,bookracknum,bookquantity,bookphoto,bookcoverphoto,bookbarcode)VALUES(@bookid,@isbn,@booktitle,@bookauthor,@bookpub,@bookdept,@bookracknum,@bookquantity,@bookphoto,@bookcoverphoto,@bookbarcode)";
                  cmd.Parameters.AddWithValue("@bookid", bookid.Text.ToString());
                  cmd.Parameters.AddWithValue("@booktitle", booktitle.Text.ToString());
                  cmd.Parameters.AddWithValue("@bookauthor", bookauthor.Text.ToString());
                  cmd.Parameters.AddWithValue("@bookpub", bookpub.Text.ToString());
                  cmd.Parameters.AddWithValue("@bookdept", bookdept.Text.ToString());
                  cmd.Parameters.AddWithValue("@bookracknum", Convert.ToInt32(bookracknum.Text.ToString()));
                  cmd.Parameters.AddWithValue("@bookquantity", Convert.ToInt32(bookquantity.Text.ToString()));
                  cmd.Parameters.AddWithValue("@bookphoto", img);
                  cmd.Parameters.AddWithValue("@bookcoverphoto", coverphoto);
                  cmd.Parameters.AddWithValue("@isbn", bookisbn.Text.ToString());
                  cmd.Parameters.AddWithValue("@bookbarcode", barcode13);


                  if (string.IsNullOrWhiteSpace(bookid.Text) || string.IsNullOrWhiteSpace(bookauthor.Text)
                   || string.IsNullOrWhiteSpace(bookisbn.Text) || string.IsNullOrWhiteSpace(bookpub.Text)
                   || string.IsNullOrWhiteSpace(bookdept.Text) || string.IsNullOrWhiteSpace(bookpub.Text)
                   || bookquantity.Value == 0)
                  {
                      Validation();
                      errorHandler.Text = "*Please fill in all of the required fields";
                  }
                  else {


                      using (MySqlCommand sqlCommand1 = new MySqlCommand("SELECT COUNT(*) from booktable where isbn = @password", connection))
                      {
                          MySqlCommand commandAuthorAndTitle = new MySqlCommand("SELECT COUNT(*) from booktable where booktitle = @booktitle AND bookauthor = @bookauthor  ", connection);
                          commandAuthorAndTitle.Parameters.AddWithValue("@booktitle", booktitle.Text);
                          commandAuthorAndTitle.Parameters.AddWithValue("@bookauthor", bookauthor.Text);
                          sqlCommand1.Parameters.AddWithValue("@password", bookisbn.Text);
                          int userCount1 = Convert.ToInt16(sqlCommand1.ExecuteScalar().ToString());
                          int authorAndTitle = Convert.ToInt16(commandAuthorAndTitle.ExecuteScalar().ToString());
                          if (userCount1 > 0)
                          {
                              Invoke(new Action(() =>
                          {
                              errorProvider1.SetError(bookisbn, "The ISBN you entered is already existing");
                              errorHandler.Text = "* ISBN EXISTS";
                          }));
                          }
                          else if (authorAndTitle > 0)
                          {
                              Invoke(new Action(() =>
                          {
                              errorProvider1.SetError(booktitle, "Title with the author name is already existing");
                              errorProvider1.SetError(bookauthor, "Author with the title of the book is existing");
                              errorHandler.Text = "* The book with the author name is already existing.";
                          }));
                          }

                          else
                          {
                              cmd.ExecuteNonQuery();
                              ClearTextBoxes();
                              booksTitle.Text = "Successfully Added";
                              forloadbooks = false;
                              if (sortby.SelectedItem == null)
                              {
                                  ParameterizedThreadStart ptss = new ParameterizedThreadStart(LoadBooks);
                                  Thread ts = new Thread(ptss);
                                  ts.Start("s");
                              }
                              else {
                                  ParameterizedThreadStart pts = new ParameterizedThreadStart(LoadBooks);
                                  Thread t = new Thread(pts);
                                  t.Start(sortby.SelectedItem.ToString());
                              }
                          }

                      }
                  }
              }));







            }
            catch (Exception ee)
            {
                using (MySqlCommand sqlCommand = new MySqlCommand("SELECT COUNT(*) from booktable where bookid = @username", connection))
                {

                    sqlCommand.Parameters.AddWithValue("@username", bookid.Text);

                    int userCount = Convert.ToInt16(sqlCommand.ExecuteScalar().ToString());

                    if (userCount > 0)
                    {
                        Invoke(new Action(() =>
                        {
                            errorProvider1.SetError(bookid, "The BOOKID you entered is already existing");
                            errorHandler.Text = "* BOOKID EXISTS";
                        }));
                    }


                }



            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
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









        private void update_Click(object sender, EventArgs e)
        {

            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            if (connection != null && connection.State == ConnectionState.Open)
                connection.Close();
            else
                connection.Open();


            BarcodeforScanner();

            Bitmap bmp = null;
            Invoke(new Action(() =>
            {
                bmp = new Bitmap(111, 145);
                pictureBox3.DrawToBitmap(bmp, new Rectangle(0, 0, 111, 145));
                photo.DrawToBitmap(bmp, new Rectangle(2, 10, 95, 131));
                //pictureBox2.Image = bmp;
            }));

            MemoryStream memorySt = new MemoryStream();
            pictureBox2.Image.Save(memorySt, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] barcode13 = memorySt.ToArray();

            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] img = ms.ToArray();

            //coverphoto
            MemoryStream ms1 = new MemoryStream();
            photo.Image.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] coverphoto = ms1.ToArray();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE booktable SET bookid= @bookid,booktitle=@booktitle,bookauthor=@bookauthor,isbn=@isbn,bookpub=@bookpub,bookdept=@bookdept,bookquantity=@bookquantity,bookcoverphoto=@bookcoverphoto,bookphoto=@bookphoto,bookbarcode=@bookbarcode WHERE bookid=@OriginalId";
                cmd.Parameters.AddWithValue("@bookid", bookid.Text.ToString());
                cmd.Parameters.AddWithValue("@isbn", bookisbn.Text.ToString());
                cmd.Parameters.AddWithValue("@booktitle", booktitle.Text.ToString());
                cmd.Parameters.AddWithValue("@bookauthor", bookauthor.Text.ToString());
                cmd.Parameters.AddWithValue("@bookpub", bookpub.Text.ToString());
                cmd.Parameters.AddWithValue("@bookdept", bookdept.Text.ToString());
                cmd.Parameters.AddWithValue("@bookracknum", Convert.ToInt32(bookracknum.Text.ToString()));
                cmd.Parameters.AddWithValue("@bookquantity", Convert.ToInt32(bookquantity.Text.ToString()));
                cmd.Parameters.AddWithValue("@bookphoto", img);
                cmd.Parameters.AddWithValue("@bookcoverphoto", coverphoto);
                cmd.Parameters.AddWithValue("@bookbarcode", barcode13);
                cmd.Parameters.AddWithValue("@OriginalId", orginalId);

                if (string.IsNullOrWhiteSpace(bookid.Text) || string.IsNullOrWhiteSpace(bookauthor.Text)
                    || string.IsNullOrWhiteSpace(bookisbn.Text) || string.IsNullOrWhiteSpace(bookpub.Text)
                    || string.IsNullOrWhiteSpace(bookdept.Text) || string.IsNullOrWhiteSpace(bookpub.Text)
                    || bookquantity.Value == 0 || bookisbn.Text == "Put the 13 EAN ISBN here")
                {
                    Validation();
                    errorHandler.Text = "*Please fill in all of the required fields";
                }
                else
                {

                    cmd.ExecuteNonQuery();
                    errorHandler.Text = " ";
                    ClearTextBoxes();
                    booksTitle.Text = "Successfully Updated";

                    booksAuthor.Visible = false;
                    forloadbooks = false;

                    if (sortby.SelectedItem == null)
                    {
                        ParameterizedThreadStart ptss = new ParameterizedThreadStart(LoadBooks);
                        Thread ts = new Thread(ptss);
                        ts.Start("s");
                    }
                    else {
                        ParameterizedThreadStart pts = new ParameterizedThreadStart(LoadBooks);
                        Thread t = new Thread(pts);
                        t.Start(sortby.SelectedItem.ToString());
                    }
                }



            }
            catch (Exception ee)
            {
                using (MySqlCommand sqlCommand = new MySqlCommand("SELECT COUNT(*) from booktable where bookid = @username", connection))
                {

                    sqlCommand.Parameters.AddWithValue("@username", bookid.Text);

                    int userCount = Convert.ToInt16(sqlCommand.ExecuteScalar().ToString());

                    if (userCount > 0)
                    {
                        Invoke(new Action(() =>
                        {
                            errorProvider1.SetError(bookid, "The BOOKID you entered is already existing");
                            errorHandler.Text = "* BOOKID EXISTS";
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

        private void sample(object state)
        {
            string text = state.ToString();
            System.Windows.Forms.MessageBox.Show(text);
        }
        private void ClearTextBoxes()
        {
            errorHandler.Text = "";
            photo.Image = Properties.Resources.no_book_cover;
            bookisbn.Clear();
            booktitle.Clear();
            bookauthor.Clear();
            bookid.Clear();
            bookdept.Clear();
            searchControl1.ClearFilter();
            bookpub.Clear();
            bookracknum.Value = 0;
            bookquantity.Value = 0;
            Invoke(new Action(() =>
            {

                booksAuthor.Text = "Book Author";
                booksTitle.Text = "Book Title";
                booksTitle.Focus();
                add.Image = Properties.Resources.adde;
                update.Image = Properties.Resources.updated;
                delete.Image = Properties.Resources.deleted;
                add.Enabled = true;
                update.Enabled = false;
                delete.Enabled = false;
            }));
        }
        private void Validation()
        {
            if (string.IsNullOrWhiteSpace(bookid.Text))
            {
                //Validation failed, so set an appropriate error message
                errorProvider1.SetError(bookid, "Enter a book id");
            }
            if (string.IsNullOrWhiteSpace(booktitle.Text))
            {
                errorProvider1.SetError(booktitle, "Enter book title");
            }
            if (string.IsNullOrWhiteSpace(bookauthor.Text))
            {
                //Validation failed, so set an appropriate error message
                errorProvider1.SetError(bookauthor, "Enter book author");
            }
            if (string.IsNullOrWhiteSpace(bookisbn.Text) || bookisbn.Text == "Put the 13 EAN ISBN here")
            {
                //Validation failed, so set an appropriate error message
                errorProvider1.SetError(bookisbn, "Enter 13-ISBN");
            }
            if (string.IsNullOrWhiteSpace(bookdept.Text))
            {
                //Validation failed, so set an appropriate error message
                errorProvider1.SetError(bookdept, "Enter Department");
            }
            if (string.IsNullOrWhiteSpace(bookpub.Text))
            {
                //Validation failed, so set an appropriate error message
                errorProvider1.SetError(bookpub, "Enter Publisher");
            }
            if (bookquantity.Text.Equals("0"))
            {
                //Validation failed, so set an appropriate error message
                errorProvider1.SetError(bookquantity, "Quantity must alteast 1");
            }
        }

        private void galleryControl1_Gallery_ItemClick(object sender, GalleryItemClickEventArgs e)
        {
            _TypeGlobal = false;



            string title = e.Item.Caption.ToString();
            string author = e.Item.Description.ToString();
            Image img = e.Item.Image;

            //System.Windows.Forms.MessageBox.Show(title + author);


            //ParameterizedThreadStart pts = new ParameterizedThreadStart(galleryItemClicK);
            //Thread t = new Thread(pts);
            var thread = new Thread(() => galleryItemClicK(title, author, img));
            thread.Start();
            //t.Start(title);


        }

        private void galleryItemClicK(object state, object a, object b)
        {
            Invoke(new Action(() =>
            {
                update.Image = Properties.Resources.updatee;
                delete.Image = Properties.Resources.deletee;
                add.Image = Properties.Resources.addd;
                add.Enabled = false;
                update.Enabled = true;
                delete.Enabled = true;
            }));
            string title = state.ToString();
            string author = a.ToString();

            Image img = (Image)b;

            MySqlConnection mcon = new MySqlConnection("Server=localhost;Port=3306;database=library_management;Uid=root;Pwd='0e15ecJasper'");
            MySqlCommand mcd;
            MySqlDataReader mdr;
            string s;
            try
            {
                using (mcon)
                {

                    //s = "select * from booktable where booktitle='" + title + "' AND bookauthor='"+author +"';";
                    s = "select * from booktable where booktitle=@title AND bookauthor=@author ";
                    //mcd.Parameters.AddWithValue("@bookid", bookid.Text.ToString());
                    //cmd.Parameters.AddWithValue("@isbn", bookisbn.Text.ToString());


                    mcd = new MySqlCommand(s, mcon);
                    mcd.Parameters.AddWithValue("@title", title.ToString());
                    mcd.Parameters.AddWithValue("@author", author.ToString());
                    mcon.Open();
                    mdr = mcd.ExecuteReader();

                    if (mdr.Read())
                    {
                        Invoke(new Action(() =>
                        {
                            errorHandler.Text = "";
                            errorProvider1.Clear();
                            booksAuthor.Visible = true;
                            string booktitle1 = mdr.GetString("booktitle");
                            string bookauthor1 = mdr.GetString("bookauthor");
                            string bookid1 = mdr.GetString("bookid");
                            string bookisbn1 = mdr.GetString("isbn");
                            string bookdept1 = mdr.GetString("bookdept");
                            string bookpub1 = mdr.GetString("bookpub");
                            int bookracknum1 = Convert.ToInt32(mdr.GetString("bookracknum"));
                            int bookquantity1 = Convert.ToInt32(mdr.GetString("bookquantity"));
                            //string section = mdr.GetString("studsec");
                            //string course = mdr.GetString("studcourse");

                            booksAuthor.Text = "by " + bookauthor1;
                            booksTitle.Text = booktitle1;



                            byte[] byteBLOBData = (byte[])mdr["bookcoverphoto"];
                            var stream = new MemoryStream(byteBLOBData);
                            photo.Image = Image.FromStream(stream);


                            //photo.Image = img;
                            booktitle.Text = booktitle1;
                            bookauthor.Text = bookauthor1;
                            bookid.Text = bookid1;
                            bookisbn.Text = bookisbn1;
                            bookdept.Text = bookdept1;
                            bookpub.Text = bookpub1;
                            bookracknum.Value = bookracknum1;
                            bookquantity.Value = bookquantity1;
                            orginalId = bookid1;




                        }));
                        //mdr.Close();
                        //mcon.Close();
                    }
                }

            }
            catch (Exception ee)
            {
                System.Windows.MessageBox.Show(ee.Message);
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
            connection.Open();

            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE FROM booktable WHERE bookid = @originalId";
                cmd.Parameters.AddWithValue("@originalId", orginalId.ToString());

                Invoke(new Action(() =>
                {
                    cmd.ExecuteNonQuery();
                    errorHandler.Text = " ";
                    ClearTextBoxes();
                    booksTitle.Text = "Successfully Deleted";
                    forloadbooks = false;
                    booksAuthor.Visible = false;

                }));
                if (sortby.SelectedItem == null)
                {
                    ParameterizedThreadStart ptss = new ParameterizedThreadStart(LoadBooks);
                    Thread ts = new Thread(ptss);
                    ts.Start("s");
                }
                else {
                    ParameterizedThreadStart pts = new ParameterizedThreadStart(LoadBooks);
                    Thread t = new Thread(pts);
                    t.Start(sortby.SelectedItem.ToString());
                }
            }
            catch (Exception ee)
            {
                System.Windows.MessageBox.Show(ee.Message);
            }
        }
        bool forloadbooks;
        private void searchControl1_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(searchControl1.Text))
            {
                forloadbooks = true;
                //group.Items.Clear();

                ParameterizedThreadStart pts = new ParameterizedThreadStart(searchMyData);
                Thread t = new Thread(pts);
                t.Start(searchControl1.Text);
            }

            else
            {
                if (forloadbooks)
                {
                    ParameterizedThreadStart pts = new ParameterizedThreadStart(LoadBooks);
                    Thread t = new Thread(pts);
                    t.Start("s");
                }
            }
        }

        public void searchMyData(object state)
        {
            try
            {
                string text = state.ToString();
                using (MySqlConnection connection = new MySqlConnection(MyConnectionString))
                {
                    connection.Open();
                    MySqlCommand cmd = connection.CreateCommand();
                    //cmd.CommandText = "SELECT * from booktable where booktitle like'" + text + "%' OR bookauthor like'" + text + "%' ";


                    cmd.CommandText = "SELECT * from booktable where Match(booktitle) Against(@names IN BOOLEAN MODE) OR Match(bookauthor) Against(@names IN BOOLEAN MODE)";
                    cmd.Parameters.AddWithValue("@names", text.ToString() + "*".ToString());
                    //cmd.Parameters.AddWithValue("@author", text.ToString() + "*".ToString());
                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    DataTable ds = new DataTable();
                    adap.Fill(ds);
                    DataView dv = new DataView();


                    Invoke(new Action(() =>
                    {
                        group.Items.Clear();
                        for (int i = 0; i < ds.Rows.Count; i++)
                        {
                            byte[] byteBLOBData = (byte[])ds.Rows[i]["bookphoto"];
                            var stream = new MemoryStream(byteBLOBData);

                            Image bookimages = Image.FromStream(stream);
                            string author = ds.Rows[i]["bookauthor"].ToString();
                            string title = ds.Rows[i]["booktitle"].ToString();

                            //Add Books in the Gallery Control for every text changed 
                            group.Items.Add(new GalleryItem(bookimages, title, author));
                            group.Items[i].HoverImage = group.Items[i].Image;

                        }
                    }));
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void searchControl1_Click(object sender, EventArgs e)
        {
            errorHandler.Text = "";
            photo.Image = Properties.Resources.no_book_cover;
            bookisbn.Clear();
            booktitle.Clear();
            bookauthor.Clear();
            bookid.Clear();
            bookdept.Clear();
            bookpub.Clear();
            bookracknum.Value = 0;
            bookquantity.Value = 0;
            Invoke(new Action(() =>
            {

                booksAuthor.Text = "Book Author";
                booksTitle.Text = "Book Title";
                add.Image = Properties.Resources.adde;
                update.Image = Properties.Resources.updated;
                delete.Image = Properties.Resources.deleted;
                add.Enabled = true;
                update.Enabled = false;
                delete.Enabled = false;
            }));
        }

        private void sortby_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            ParameterizedThreadStart pts = new ParameterizedThreadStart(LoadBooks);
            Thread t = new Thread(pts);
            t.Start(sortby.SelectedItem.ToString());
        }
    }
}
