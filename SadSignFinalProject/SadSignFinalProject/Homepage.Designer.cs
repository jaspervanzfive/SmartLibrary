namespace SadSignFinalProject
{
    partial class Homepage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Homepage));
            this.ScanerButton = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ScanerButton)).BeginInit();
            this.SuspendLayout();
            // 
            // ScanerButton
            // 
            this.ScanerButton.BackColor = System.Drawing.Color.Transparent;
            this.ScanerButton.Location = new System.Drawing.Point(72, 168);
            this.ScanerButton.Name = "ScanerButton";
            this.ScanerButton.Size = new System.Drawing.Size(400, 202);
            this.ScanerButton.TabIndex = 0;
            this.ScanerButton.TabStop = false;
            this.ScanerButton.Click += new System.EventHandler(this.ScanerButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(378, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "scan";
            // 
            // Homepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ScanerButton);
            this.Name = "Homepage";
            this.Size = new System.Drawing.Size(1246, 949);
            ((System.ComponentModel.ISupportInitialize)(this.ScanerButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ScanerButton;
        private System.Windows.Forms.Label label1;
    }
}
