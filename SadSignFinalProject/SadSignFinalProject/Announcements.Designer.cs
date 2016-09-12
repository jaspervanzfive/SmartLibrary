namespace SadSignFinalProject
{
    partial class Announcements
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Announcements));
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.delete = new System.Windows.Forms.PictureBox();
            this.add = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.add)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(31, 66);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(997, 20);
            this.textEdit1.TabIndex = 0;
            // 
            // radGridView1
            // 
            this.radGridView1.BackColor = System.Drawing.Color.White;
            this.radGridView1.Location = new System.Drawing.Point(31, 92);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowDragToGroup = false;
            gridViewTextBoxColumn1.HeaderText = "Announcements";
            gridViewTextBoxColumn1.Name = "column1";
            gridViewTextBoxColumn1.Width = 1300;
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1});
            this.radGridView1.MasterTemplate.ShowRowHeaderColumn = false;
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.ReadOnly = true;
            this.radGridView1.ShowGroupPanel = false;
            this.radGridView1.Size = new System.Drawing.Size(1152, 458);
            this.radGridView1.TabIndex = 21;
            this.radGridView1.TabStop = false;
            this.radGridView1.Text = "radGridView1";
            this.radGridView1.ThemeName = "TelerikMetroTouch";
            this.radGridView1.SelectionChanged += new System.EventHandler(this.radGridView1_SelectionChanged);
            // 
            // delete
            // 
            this.delete.BackColor = System.Drawing.Color.Transparent;
            this.delete.Enabled = false;
            this.delete.Image = global::SadSignFinalProject.Properties.Resources.deleted;
            this.delete.Location = new System.Drawing.Point(1103, 62);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(86, 30);
            this.delete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.delete.TabIndex = 23;
            this.delete.TabStop = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // add
            // 
            this.add.BackColor = System.Drawing.Color.Transparent;
            this.add.Image = global::SadSignFinalProject.Properties.Resources.adde;
            this.add.Location = new System.Drawing.Point(1019, 63);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(91, 27);
            this.add.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.add.TabIndex = 22;
            this.add.TabStop = false;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // Announcements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.delete);
            this.Controls.Add(this.add);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.textEdit1);
            this.Name = "Announcements";
            this.Size = new System.Drawing.Size(1316, 624);
            this.Load += new System.EventHandler(this.Announcements_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.add)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEdit1;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private System.Windows.Forms.PictureBox delete;
        private System.Windows.Forms.PictureBox add;
    }
}
