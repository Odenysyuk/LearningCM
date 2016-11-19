namespace CallanMethod
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.mPanel = new MetroFramework.Controls.MetroPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pBack = new System.Windows.Forms.PictureBox();
            this.dataSet1 = new System.Data.DataSet();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = this;
            this.metroStyleManager.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroStyleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // mPanel
            // 
            this.mPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mPanel.HorizontalScrollbarBarColor = true;
            this.mPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.mPanel.HorizontalScrollbarSize = 10;
            this.mPanel.Location = new System.Drawing.Point(20, 60);
            this.mPanel.Name = "mPanel";
            this.mPanel.Size = new System.Drawing.Size(847, 507);
            this.mPanel.TabIndex = 0;
            this.mPanel.VerticalScrollbarBarColor = true;
            this.mPanel.VerticalScrollbarHighlightOnWheel = false;
            this.mPanel.VerticalScrollbarSize = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(20, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pBack
            // 
            this.pBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pBack.Image = global::CallanMethod.Properties.Resources.back;
            this.pBack.Location = new System.Drawing.Point(700, 13);
            this.pBack.Name = "pBack";
            this.pBack.Size = new System.Drawing.Size(49, 41);
            this.pBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBack.TabIndex = 3;
            this.pBack.TabStop = false;
            this.pBack.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 587);
            this.Controls.Add(this.pBack);
            this.Controls.Add(this.mPanel);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Opacity = 0.95D;
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.None;
            this.Text = "         Callan method";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public MetroFramework.Components.MetroStyleManager metroStyleManager;
        private MetroFramework.Controls.MetroPanel mPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pBack;
        private System.Data.DataSet dataSet1;
    }
}

