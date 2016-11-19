namespace CallanMethod
{
    partial class ucChalkboard
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mTitle = new MetroFramework.Controls.MetroLabel();
            this.mFoot = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::CallanMethod.Properties.Resources.EmptyChalkboard;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(867, 490);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // mTitle
            // 
            this.mTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mTitle.AutoSize = true;
            this.mTitle.BackColor = System.Drawing.SystemColors.Window;
            this.mTitle.CustomBackground = true;
            this.mTitle.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.mTitle.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.mTitle.ForeColor = System.Drawing.Color.White;
            this.mTitle.Location = new System.Drawing.Point(372, 181);
            this.mTitle.Name = "mTitle";
            this.mTitle.Size = new System.Drawing.Size(118, 25);
            this.mTitle.Style = MetroFramework.MetroColorStyle.White;
            this.mTitle.TabIndex = 3;
            this.mTitle.Text = "metroLabel2";
            this.mTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mTitle.UseStyleColors = true;
            // 
            // mFoot
            // 
            this.mFoot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mFoot.AutoSize = true;
            this.mFoot.BackColor = System.Drawing.Color.SeaGreen;
            this.mFoot.CustomBackground = true;
            this.mFoot.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.mFoot.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.mFoot.Location = new System.Drawing.Point(372, 259);
            this.mFoot.Name = "mFoot";
            this.mFoot.Size = new System.Drawing.Size(118, 25);
            this.mFoot.Style = MetroFramework.MetroColorStyle.White;
            this.mFoot.TabIndex = 3;
            this.mFoot.Text = "metroLabel2";
            this.mFoot.UseStyleColors = true;
            // 
            // ucChalkboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mFoot);
            this.Controls.Add(this.mTitle);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ucChalkboard";
            this.Size = new System.Drawing.Size(867, 490);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroLabel mTitle;
        private MetroFramework.Controls.MetroLabel mFoot;
    }
}
