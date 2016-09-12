namespace SadSignFinalProject
{
    partial class attendance
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(attendance));
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.radGridView2 = new Telerik.WinControls.UI.RadGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.section = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.studnumlabel = new System.Windows.Forms.Label();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView2.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // radGridView1
            // 
            this.radGridView1.BackColor = System.Drawing.Color.White;
            this.radGridView1.Location = new System.Drawing.Point(32, 47);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowDragToGroup = false;
            this.radGridView1.MasterTemplate.ShowRowHeaderColumn = false;
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.ReadOnly = true;
            this.radGridView1.ShowGroupPanel = false;
            this.radGridView1.Size = new System.Drawing.Size(730, 506);
            this.radGridView1.TabIndex = 20;
            this.radGridView1.TabStop = false;
            this.radGridView1.Text = "radGridView1";
            this.radGridView1.ThemeName = "TelerikMetroBlue";
            this.radGridView1.SelectionChanged += new System.EventHandler(this.radGridView1_SelectionChanged);
            this.radGridView1.DataBindingComplete += new Telerik.WinControls.UI.GridViewBindingCompleteEventHandler(this.radGridView1_DataBindingComplete);
            this.radGridView1.Click += new System.EventHandler(this.radGridView1_Click);
            // 
            // radGridView2
            // 
            this.radGridView2.BackColor = System.Drawing.Color.White;
            this.radGridView2.Location = new System.Drawing.Point(823, 363);
            // 
            // 
            // 
            this.radGridView2.MasterTemplate.AllowAddNewRow = false;
            this.radGridView2.MasterTemplate.AllowDragToGroup = false;
            this.radGridView2.MasterTemplate.ShowRowHeaderColumn = false;
            this.radGridView2.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.radGridView2.Name = "radGridView2";
            this.radGridView2.ReadOnly = true;
            this.radGridView2.ShowGroupPanel = false;
            this.radGridView2.Size = new System.Drawing.Size(457, 199);
            this.radGridView2.TabIndex = 21;
            this.radGridView2.TabStop = false;
            this.radGridView2.Text = "radGridView2";
            this.radGridView2.ThemeName = "TelerikMetroTouch";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(840, 85);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 115);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // section
            // 
            this.section.AutoSize = true;
            this.section.BackColor = System.Drawing.Color.Transparent;
            this.section.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.section.ForeColor = System.Drawing.Color.White;
            this.section.Location = new System.Drawing.Point(980, 167);
            this.section.Name = "section";
            this.section.Size = new System.Drawing.Size(65, 20);
            this.section.TabIndex = 25;
            this.section.Text = "Section";
            this.section.Visible = false;
            // 
            // name
            // 
            this.name.BackColor = System.Drawing.Color.Transparent;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.ForeColor = System.Drawing.Color.White;
            this.name.Location = new System.Drawing.Point(980, 138);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(257, 25);
            this.name.TabIndex = 24;
            this.name.Text = "Name";
            this.name.Visible = false;
            // 
            // studnumlabel
            // 
            this.studnumlabel.AutoSize = true;
            this.studnumlabel.BackColor = System.Drawing.Color.Transparent;
            this.studnumlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studnumlabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.studnumlabel.Location = new System.Drawing.Point(978, 95);
            this.studnumlabel.Name = "studnumlabel";
            this.studnumlabel.Size = new System.Drawing.Size(262, 31);
            this.studnumlabel.TabIndex = 23;
            this.studnumlabel.Text = "XXXX-XXXX-XXXX";
            // 
            // attendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.section);
            this.Controls.Add(this.name);
            this.Controls.Add(this.studnumlabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.radGridView2);
            this.Controls.Add(this.radGridView1);
            this.Name = "attendance";
            this.Size = new System.Drawing.Size(1316, 624);
            this.Load += new System.EventHandler(this.attendance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView2.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadGridView radGridView2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label section;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label studnumlabel;
        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
    }
}
