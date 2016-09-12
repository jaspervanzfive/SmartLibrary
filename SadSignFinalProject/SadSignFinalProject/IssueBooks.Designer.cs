namespace SadSignFinalProject
{
    partial class IssueBooks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IssueBooks));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
            this.radRadioButton2 = new Telerik.WinControls.UI.RadRadioButton();
            this.radRadioButton1 = new Telerik.WinControls.UI.RadRadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.searchControl2 = new DevExpress.XtraEditors.SearchControl();
            this.radRadioButton3 = new Telerik.WinControls.UI.RadRadioButton();
            this.photo = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.booksTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.booksAuthor = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.available = new System.Windows.Forms.PictureBox();
            this.availability = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.add = new System.Windows.Forms.PictureBox();
            this.cancel = new System.Windows.Forms.PictureBox();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.date = new System.Windows.Forms.Label();
            this.returnvalue = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.photo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.available)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.add)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::SadSignFinalProject.Properties.Resources.findd;
            this.pictureBox1.Location = new System.Drawing.Point(414, 173);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // videoSourcePlayer1
            // 
            this.videoSourcePlayer1.BackColor = System.Drawing.Color.White;
            this.videoSourcePlayer1.BorderColor = System.Drawing.Color.Gray;
            this.videoSourcePlayer1.Location = new System.Drawing.Point(159, 299);
            this.videoSourcePlayer1.Name = "videoSourcePlayer1";
            this.videoSourcePlayer1.Size = new System.Drawing.Size(146, 98);
            this.videoSourcePlayer1.TabIndex = 13;
            this.videoSourcePlayer1.Text = "videoSourcePlayer1";
            this.videoSourcePlayer1.VideoSource = null;
            this.videoSourcePlayer1.Visible = false;
            this.videoSourcePlayer1.Click += new System.EventHandler(this.videoSourcePlayer1_Click);
            // 
            // radRadioButton2
            // 
            this.radRadioButton2.BackColor = System.Drawing.Color.Transparent;
            this.radRadioButton2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.radRadioButton2.ForeColor = System.Drawing.Color.White;
            this.radRadioButton2.Location = new System.Drawing.Point(12, 217);
            this.radRadioButton2.Name = "radRadioButton2";
            this.radRadioButton2.Size = new System.Drawing.Size(156, 21);
            this.radRadioButton2.TabIndex = 12;
            this.radRadioButton2.Text = "Search by Book Title";
            this.radRadioButton2.ThemeName = "Windows8";
            this.radRadioButton2.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton2_ToggleStateChanged);
            // 
            // radRadioButton1
            // 
            this.radRadioButton1.BackColor = System.Drawing.Color.Transparent;
            this.radRadioButton1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.radRadioButton1.ForeColor = System.Drawing.Color.White;
            this.radRadioButton1.Location = new System.Drawing.Point(12, 135);
            this.radRadioButton1.Name = "radRadioButton1";
            this.radRadioButton1.Size = new System.Drawing.Size(142, 21);
            this.radRadioButton1.TabIndex = 11;
            this.radRadioButton1.Text = "Search by Book ID";
            this.radRadioButton1.ThemeName = "Windows8";
            this.radRadioButton1.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton1_ToggleStateChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(52, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Book ID:";
            // 
            // searchControl1
            // 
            this.searchControl1.Enabled = false;
            this.searchControl1.Location = new System.Drawing.Point(127, 174);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Size = new System.Drawing.Size(281, 20);
            this.searchControl1.TabIndex = 9;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::SadSignFinalProject.Properties.Resources.findd;
            this.pictureBox2.Location = new System.Drawing.Point(414, 254);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(66, 23);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(39, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Book Title:";
            // 
            // searchControl2
            // 
            this.searchControl2.Enabled = false;
            this.searchControl2.Location = new System.Drawing.Point(127, 255);
            this.searchControl2.Name = "searchControl2";
            this.searchControl2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl2.Size = new System.Drawing.Size(281, 20);
            this.searchControl2.TabIndex = 15;
            // 
            // radRadioButton3
            // 
            this.radRadioButton3.BackColor = System.Drawing.Color.Transparent;
            this.radRadioButton3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.radRadioButton3.ForeColor = System.Drawing.Color.White;
            this.radRadioButton3.Location = new System.Drawing.Point(12, 297);
            this.radRadioButton3.Name = "radRadioButton3";
            this.radRadioButton3.Size = new System.Drawing.Size(147, 21);
            this.radRadioButton3.TabIndex = 13;
            this.radRadioButton3.Text = "Search by Barcode:";
            this.radRadioButton3.ThemeName = "Windows8";
            this.radRadioButton3.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton3_ToggleStateChanged);
            // 
            // photo
            // 
            this.photo.Image = global::SadSignFinalProject.Properties.Resources.no_book_cover;
            this.photo.Location = new System.Drawing.Point(42, 34);
            this.photo.Name = "photo";
            this.photo.Size = new System.Drawing.Size(71, 95);
            this.photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.photo.TabIndex = 30;
            this.photo.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::SadSignFinalProject.Properties.Resources.bookcover;
            this.pictureBox3.Location = new System.Drawing.Point(40, 25);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(85, 106);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 29;
            this.pictureBox3.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.booksTitle);
            this.panel3.Location = new System.Drawing.Point(131, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(326, 49);
            this.panel3.TabIndex = 42;
            // 
            // booksTitle
            // 
            this.booksTitle.BackColor = System.Drawing.Color.Transparent;
            this.booksTitle.Cursor = System.Windows.Forms.Cursors.Default;
            this.booksTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.booksTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.booksTitle.ForeColor = System.Drawing.Color.DodgerBlue;
            this.booksTitle.Location = new System.Drawing.Point(0, 0);
            this.booksTitle.Name = "booksTitle";
            this.booksTitle.Size = new System.Drawing.Size(326, 49);
            this.booksTitle.TabIndex = 16;
            this.booksTitle.Text = "Book Title";
            this.booksTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.booksTitle.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.booksAuthor);
            this.panel1.Location = new System.Drawing.Point(134, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(326, 30);
            this.panel1.TabIndex = 43;
            // 
            // booksAuthor
            // 
            this.booksAuthor.BackColor = System.Drawing.Color.Transparent;
            this.booksAuthor.Cursor = System.Windows.Forms.Cursors.Default;
            this.booksAuthor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.booksAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.booksAuthor.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.booksAuthor.Location = new System.Drawing.Point(0, 0);
            this.booksAuthor.Name = "booksAuthor";
            this.booksAuthor.Size = new System.Drawing.Size(326, 30);
            this.booksAuthor.TabIndex = 16;
            this.booksAuthor.Text = "Book Author";
            this.booksAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.booksAuthor.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.available);
            this.panel2.Controls.Add(this.availability);
            this.panel2.Location = new System.Drawing.Point(137, 87);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(326, 44);
            this.panel2.TabIndex = 44;
            // 
            // available
            // 
            this.available.BackColor = System.Drawing.Color.Transparent;
            this.available.Image = global::SadSignFinalProject.Properties.Resources.borrowed;
            this.available.Location = new System.Drawing.Point(85, 3);
            this.available.Name = "available";
            this.available.Size = new System.Drawing.Size(158, 38);
            this.available.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.available.TabIndex = 47;
            this.available.TabStop = false;
            this.available.Visible = false;
            // 
            // availability
            // 
            this.availability.BackColor = System.Drawing.Color.Transparent;
            this.availability.Cursor = System.Windows.Forms.Cursors.Default;
            this.availability.Dock = System.Windows.Forms.DockStyle.Fill;
            this.availability.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.availability.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.availability.Location = new System.Drawing.Point(0, 0);
            this.availability.Name = "availability";
            this.availability.Size = new System.Drawing.Size(326, 44);
            this.availability.TabIndex = 16;
            this.availability.Text = "Availability:";
            this.availability.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(184, 376);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.Visible = false;
            // 
            // add
            // 
            this.add.BackColor = System.Drawing.Color.Transparent;
            this.add.Image = global::SadSignFinalProject.Properties.Resources.addd;
            this.add.Location = new System.Drawing.Point(144, 437);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(135, 45);
            this.add.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.add.TabIndex = 45;
            this.add.TabStop = false;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // cancel
            // 
            this.cancel.BackColor = System.Drawing.Color.Transparent;
            this.cancel.Image = global::SadSignFinalProject.Properties.Resources.cancel;
            this.cancel.Location = new System.Drawing.Point(285, 437);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(135, 45);
            this.cancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cancel.TabIndex = 46;
            this.cancel.TabStop = false;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = new System.DateTime(2016, 3, 3, 4, 56, 57, 996);
            this.dateEdit1.Location = new System.Drawing.Point(398, 298);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "MMMM dd, yyyy";
            this.dateEdit1.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dateEdit1.Properties.CalendarTimeProperties.EditFormat.FormatString = "MMMM dd, yyyy";
            this.dateEdit1.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dateEdit1.Properties.CalendarTimeProperties.LookAndFeel.SkinMaskColor = System.Drawing.Color.DodgerBlue;
            this.dateEdit1.Properties.CalendarTimeProperties.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.LightCyan;
            this.dateEdit1.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI;
            this.dateEdit1.Properties.DisplayFormat.FormatString = "MMMM dd, yyyy";
            this.dateEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dateEdit1.Properties.EditFormat.FormatString = "MMMM dd, yyyy";
            this.dateEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dateEdit1.Properties.NullDate = new System.DateTime(2016, 3, 1, 19, 57, 59, 765);
            this.dateEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dateEdit1.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.dateEdit1.Size = new System.Drawing.Size(101, 20);
            this.dateEdit1.TabIndex = 47;
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.BackColor = System.Drawing.Color.Transparent;
            this.date.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date.ForeColor = System.Drawing.Color.White;
            this.date.Location = new System.Drawing.Point(311, 299);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(81, 17);
            this.date.TabIndex = 48;
            this.date.Text = "Due Date:";
            // 
            // returnvalue
            // 
            this.returnvalue.AutoSize = true;
            this.returnvalue.Location = new System.Drawing.Point(381, 404);
            this.returnvalue.Name = "returnvalue";
            this.returnvalue.Size = new System.Drawing.Size(35, 13);
            this.returnvalue.TabIndex = 49;
            this.returnvalue.Text = "label3";
            this.returnvalue.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // IssueBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(511, 511);
            this.Controls.Add(this.returnvalue);
            this.Controls.Add(this.date);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.add);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.photo);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.radRadioButton3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.searchControl2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.videoSourcePlayer1);
            this.Controls.Add(this.radRadioButton2);
            this.Controls.Add(this.radRadioButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchControl1);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IssueBooks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "IssueBooks";
            this.Load += new System.EventHandler(this.IssueBooks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.photo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.available)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.add)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
        private Telerik.WinControls.UI.RadRadioButton radRadioButton2;
        private Telerik.WinControls.UI.RadRadioButton radRadioButton1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SearchControl searchControl1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SearchControl searchControl2;
        private Telerik.WinControls.UI.RadRadioButton radRadioButton3;
        private System.Windows.Forms.PictureBox photo;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label booksTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label booksAuthor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.PictureBox add;
        private System.Windows.Forms.PictureBox cancel;
        private System.Windows.Forms.PictureBox available;
        private System.Windows.Forms.Label availability;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.Label returnvalue;
        private System.Windows.Forms.Timer timer1;
    }
}