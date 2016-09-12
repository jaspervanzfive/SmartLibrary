namespace SadSignFinalProject
{
    partial class StaffTable
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition9 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffTable));
            this.photo = new System.Windows.Forms.PictureBox();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.section = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.studnumlabel = new System.Windows.Forms.Label();
            this.upload = new System.Windows.Forms.PictureBox();
            this.update = new System.Windows.Forms.PictureBox();
            this.clear = new System.Windows.Forms.PictureBox();
            this.delete = new System.Windows.Forms.PictureBox();
            this.add = new System.Windows.Forms.PictureBox();
            this.qrCodeImgControl1 = new Gma.QrCodeNet.Encoding.Windows.Forms.QrCodeImgControl();
            this.label9 = new System.Windows.Forms.Label();
            this.studsec = new Telerik.WinControls.UI.RadTextBox();
            this.studname = new Telerik.WinControls.UI.RadTextBox();
            this.studnum = new Telerik.WinControls.UI.RadTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.studcourse = new Telerik.WinControls.UI.RadDropDownList();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorhandler = new System.Windows.Forms.Label();
            this.telerikMetroTouchTheme1 = new Telerik.WinControls.Themes.TelerikMetroTouchTheme();
            ((System.ComponentModel.ISupportInitialize)(this.photo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            this.radGridView1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.update)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.add)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrCodeImgControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studsec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studnum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studcourse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // photo
            // 
            this.photo.BackColor = System.Drawing.Color.Transparent;
            this.photo.Image = global::SadSignFinalProject.Properties.Resources.unknown;
            this.photo.Location = new System.Drawing.Point(32, 64);
            this.photo.Name = "photo";
            this.photo.Size = new System.Drawing.Size(179, 173);
            this.photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.photo.TabIndex = 43;
            this.photo.TabStop = false;
            // 
            // radGridView1
            // 
            this.radGridView1.BackColor = System.Drawing.Color.White;
            this.radGridView1.Controls.Add(this.label6);
            this.radGridView1.Controls.Add(this.pictureBox5);
            this.radGridView1.Location = new System.Drawing.Point(545, 67);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowDragToGroup = false;
            this.radGridView1.MasterTemplate.ShowRowHeaderColumn = false;
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition9;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.ReadOnly = true;
            this.radGridView1.ShowGroupPanel = false;
            this.radGridView1.Size = new System.Drawing.Size(749, 472);
            this.radGridView1.TabIndex = 42;
            this.radGridView1.TabStop = false;
            this.radGridView1.Text = "radGridView1";
            this.radGridView1.ThemeName = "Windows8";
            this.radGridView1.SelectionChanged += new System.EventHandler(this.radGridView1_SelectionChanged);
            this.radGridView1.DataBindingComplete += new Telerik.WinControls.UI.GridViewBindingCompleteEventHandler(this.radGridView1_DataBindingComplete);
            this.radGridView1.Click += new System.EventHandler(this.radGridView1_Click);
            // 
            // section
            // 
            this.section.AutoSize = true;
            this.section.BackColor = System.Drawing.Color.Transparent;
            this.section.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.section.ForeColor = System.Drawing.Color.White;
            this.section.Location = new System.Drawing.Point(227, 132);
            this.section.Name = "section";
            this.section.Size = new System.Drawing.Size(69, 20);
            this.section.TabIndex = 41;
            this.section.Text = "Position";
            this.section.Visible = false;
            // 
            // name
            // 
            this.name.BackColor = System.Drawing.Color.Transparent;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.ForeColor = System.Drawing.Color.White;
            this.name.Location = new System.Drawing.Point(227, 103);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(257, 25);
            this.name.TabIndex = 40;
            this.name.Text = "Name";
            this.name.Visible = false;
            // 
            // studnumlabel
            // 
            this.studnumlabel.AutoSize = true;
            this.studnumlabel.BackColor = System.Drawing.Color.Transparent;
            this.studnumlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studnumlabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.studnumlabel.Location = new System.Drawing.Point(225, 60);
            this.studnumlabel.Name = "studnumlabel";
            this.studnumlabel.Size = new System.Drawing.Size(157, 31);
            this.studnumlabel.TabIndex = 39;
            this.studnumlabel.Text = "XXX-XXXX";
            // 
            // upload
            // 
            this.upload.BackColor = System.Drawing.Color.Transparent;
            this.upload.Image = global::SadSignFinalProject.Properties.Resources.uploadb;
            this.upload.Location = new System.Drawing.Point(217, 197);
            this.upload.Name = "upload";
            this.upload.Size = new System.Drawing.Size(270, 50);
            this.upload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.upload.TabIndex = 38;
            this.upload.TabStop = false;
            this.upload.Click += new System.EventHandler(this.upload_Click);
            // 
            // update
            // 
            this.update.BackColor = System.Drawing.Color.Transparent;
            this.update.Image = global::SadSignFinalProject.Properties.Resources.updatee;
            this.update.Location = new System.Drawing.Point(15, 532);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(150, 50);
            this.update.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.update.TabIndex = 48;
            this.update.TabStop = false;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // clear
            // 
            this.clear.BackColor = System.Drawing.Color.Transparent;
            this.clear.Image = global::SadSignFinalProject.Properties.Resources.cleare;
            this.clear.Location = new System.Drawing.Point(327, 532);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(150, 50);
            this.clear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.clear.TabIndex = 47;
            this.clear.TabStop = false;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // delete
            // 
            this.delete.BackColor = System.Drawing.Color.Transparent;
            this.delete.Image = global::SadSignFinalProject.Properties.Resources.deletee;
            this.delete.Location = new System.Drawing.Point(171, 532);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(150, 50);
            this.delete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.delete.TabIndex = 46;
            this.delete.TabStop = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // add
            // 
            this.add.BackColor = System.Drawing.Color.Transparent;
            this.add.Image = global::SadSignFinalProject.Properties.Resources.adde;
            this.add.Location = new System.Drawing.Point(171, 482);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(150, 50);
            this.add.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.add.TabIndex = 45;
            this.add.TabStop = false;
            this.add.Click += new System.EventHandler(this.add_Click_1);
            // 
            // qrCodeImgControl1
            // 
            this.qrCodeImgControl1.ErrorCorrectLevel = Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.M;
            this.qrCodeImgControl1.Image = ((System.Drawing.Image)(resources.GetObject("qrCodeImgControl1.Image")));
            this.qrCodeImgControl1.Location = new System.Drawing.Point(333, 397);
            this.qrCodeImgControl1.Name = "qrCodeImgControl1";
            this.qrCodeImgControl1.QuietZoneModule = Gma.QrCodeNet.Encoding.Windows.Render.QuietZoneModules.Two;
            this.qrCodeImgControl1.Size = new System.Drawing.Size(154, 129);
            this.qrCodeImgControl1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.qrCodeImgControl1.TabIndex = 60;
            this.qrCodeImgControl1.TabStop = false;
            this.qrCodeImgControl1.Text = "qrCodeImgControl1";
            this.qrCodeImgControl1.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(240, 588);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 59;
            this.label9.Text = "label9";
            this.label9.Visible = false;
            // 
            // studsec
            // 
            this.studsec.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.studsec.Location = new System.Drawing.Point(191, 342);
            this.studsec.MaxLength = 4;
            this.studsec.Name = "studsec";
            this.studsec.Size = new System.Drawing.Size(317, 23);
            this.studsec.TabIndex = 56;
            this.studsec.ThemeName = "Windows8";
            this.studsec.TextChanged += new System.EventHandler(this.studsec_TextChanged);
            this.studsec.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.studsec_KeyPress);
            // 
            // studname
            // 
            this.studname.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.studname.Location = new System.Drawing.Point(191, 308);
            this.studname.Name = "studname";
            this.studname.Size = new System.Drawing.Size(317, 23);
            this.studname.TabIndex = 57;
            this.studname.ThemeName = "Windows8";
            this.studname.TextChanged += new System.EventHandler(this.studname_TextChanged);
            this.studname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.studname_KeyPress);
            // 
            // studnum
            // 
            this.studnum.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.studnum.Location = new System.Drawing.Point(191, 275);
            this.studnum.Name = "studnum";
            this.studnum.Size = new System.Drawing.Size(317, 23);
            this.studnum.TabIndex = 55;
            this.studnum.ThemeName = "Windows8";
            this.studnum.TextChanged += new System.EventHandler(this.studnum_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(13, 375);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 17);
            this.label5.TabIndex = 53;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(13, 346);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 17);
            this.label4.TabIndex = 52;
            this.label4.Text = "4 digits Password";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(13, 379);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 51;
            this.label3.Text = "Position";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 313);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 50;
            this.label2.Text = "Full Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 49;
            this.label1.Text = "Staff Number";
            // 
            // studcourse
            // 
            this.studcourse.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            radListDataItem1.Text = "ADMIN";
            radListDataItem2.Text = "Librarian";
            this.studcourse.Items.Add(radListDataItem1);
            this.studcourse.Items.Add(radListDataItem2);
            this.studcourse.Location = new System.Drawing.Point(191, 376);
            this.studcourse.Name = "studcourse";
            this.studcourse.Size = new System.Drawing.Size(106, 20);
            this.studcourse.TabIndex = 23;
            this.studcourse.Text = "Select Position";
            this.studcourse.ThemeName = "Windows8";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label6.Location = new System.Drawing.Point(267, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(211, 22);
            this.label6.TabIndex = 62;
            this.label6.Text = "Generating Data.........";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.White;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(229, 222);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(275, 31);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 61;
            this.pictureBox5.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorhandler
            // 
            this.errorhandler.AutoSize = true;
            this.errorhandler.BackColor = System.Drawing.Color.Transparent;
            this.errorhandler.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorhandler.ForeColor = System.Drawing.Color.LightCoral;
            this.errorhandler.Location = new System.Drawing.Point(198, 253);
            this.errorhandler.Name = "errorhandler";
            this.errorhandler.Size = new System.Drawing.Size(0, 15);
            this.errorhandler.TabIndex = 61;
            // 
            // StaffTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.errorhandler);
            this.Controls.Add(this.studcourse);
            this.Controls.Add(this.qrCodeImgControl1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.studsec);
            this.Controls.Add(this.studname);
            this.Controls.Add(this.studnum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.update);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.add);
            this.Controls.Add(this.photo);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.section);
            this.Controls.Add(this.name);
            this.Controls.Add(this.studnumlabel);
            this.Controls.Add(this.upload);
            this.Name = "StaffTable";
            this.Size = new System.Drawing.Size(1316, 624);
            this.Load += new System.EventHandler(this.StaffTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.photo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            this.radGridView1.ResumeLayout(false);
            this.radGridView1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.update)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.add)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrCodeImgControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studsec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studnum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studcourse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox photo;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private System.Windows.Forms.Label section;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label studnumlabel;
        private System.Windows.Forms.PictureBox upload;
        private System.Windows.Forms.PictureBox update;
        private System.Windows.Forms.PictureBox clear;
        private System.Windows.Forms.PictureBox delete;
        private System.Windows.Forms.PictureBox add;
        private Gma.QrCodeNet.Encoding.Windows.Forms.QrCodeImgControl qrCodeImgControl1;
        private System.Windows.Forms.Label label9;
        private Telerik.WinControls.UI.RadTextBox studsec;
        private Telerik.WinControls.UI.RadTextBox studname;
        private Telerik.WinControls.UI.RadTextBox studnum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadDropDownList studcourse;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label errorhandler;
        private Telerik.WinControls.Themes.TelerikMetroTouchTheme telerikMetroTouchTheme1;
    }
}
