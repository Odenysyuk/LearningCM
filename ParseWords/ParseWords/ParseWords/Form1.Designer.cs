namespace ParseWords
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.butOpen = new System.Windows.Forms.Button();
            this.butParse = new System.Windows.Forms.Button();
            this.dataWords = new System.Windows.Forms.DataGridView();
            this.dataBlock = new System.Windows.Forms.DataGridView();
            this.dataLessons = new System.Windows.Forms.DataGridView();
            this.dataStage = new System.Windows.Forms.DataGridView();
            this.dataQuestion = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataWords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLessons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataStage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataQuestion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(605, 20);
            this.textBox1.TabIndex = 0;
            // 
            // butOpen
            // 
            this.butOpen.Location = new System.Drawing.Point(611, 0);
            this.butOpen.Name = "butOpen";
            this.butOpen.Size = new System.Drawing.Size(66, 36);
            this.butOpen.TabIndex = 1;
            this.butOpen.Text = "Open";
            this.butOpen.UseVisualStyleBackColor = true;
            this.butOpen.Click += new System.EventHandler(this.butOpen_Click);
            // 
            // butParse
            // 
            this.butParse.Location = new System.Drawing.Point(930, 0);
            this.butParse.Name = "butParse";
            this.butParse.Size = new System.Drawing.Size(76, 35);
            this.butParse.TabIndex = 2;
            this.butParse.Text = "Parse";
            this.butParse.UseVisualStyleBackColor = true;
            this.butParse.Click += new System.EventHandler(this.butParse_Click);
            // 
            // dataWords
            // 
            this.dataWords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataWords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataWords.Location = new System.Drawing.Point(0, 41);
            this.dataWords.Name = "dataWords";
            this.dataWords.Size = new System.Drawing.Size(725, 486);
            this.dataWords.TabIndex = 3;
            // 
            // dataBlock
            // 
            this.dataBlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataBlock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataBlock.Location = new System.Drawing.Point(731, 41);
            this.dataBlock.Name = "dataBlock";
            this.dataBlock.Size = new System.Drawing.Size(176, 152);
            this.dataBlock.TabIndex = 4;
            // 
            // dataLessons
            // 
            this.dataLessons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataLessons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataLessons.Location = new System.Drawing.Point(913, 41);
            this.dataLessons.Name = "dataLessons";
            this.dataLessons.Size = new System.Drawing.Size(148, 152);
            this.dataLessons.TabIndex = 5;
            // 
            // dataStage
            // 
            this.dataStage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataStage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataStage.Location = new System.Drawing.Point(1067, 41);
            this.dataStage.Name = "dataStage";
            this.dataStage.Size = new System.Drawing.Size(148, 152);
            this.dataStage.TabIndex = 5;
            // 
            // dataQuestion
            // 
            this.dataQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataQuestion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataQuestion.Location = new System.Drawing.Point(731, 198);
            this.dataQuestion.Name = "dataQuestion";
            this.dataQuestion.Size = new System.Drawing.Size(495, 312);
            this.dataQuestion.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1012, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 35);
            this.button1.TabIndex = 6;
            this.button1.Text = "UpdateDatabase";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(731, -2);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(86, 20);
            this.numericUpDown1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(683, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Stage";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(731, 16);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(86, 20);
            this.numericUpDown2.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(683, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "LESSON";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(833, 15);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(93, 20);
            this.numericUpDown3.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(830, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "BLOCK";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 592);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataQuestion);
            this.Controls.Add(this.dataStage);
            this.Controls.Add(this.dataLessons);
            this.Controls.Add(this.dataBlock);
            this.Controls.Add(this.dataWords);
            this.Controls.Add(this.butParse);
            this.Controls.Add(this.butOpen);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Parser";
            ((System.ComponentModel.ISupportInitialize)(this.dataWords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBlock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLessons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataStage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataQuestion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button butOpen;
        private System.Windows.Forms.Button butParse;
        private System.Windows.Forms.DataGridView dataWords;
        private System.Windows.Forms.DataGridView dataBlock;
        private System.Windows.Forms.DataGridView dataLessons;
        private System.Windows.Forms.DataGridView dataStage;
        private System.Windows.Forms.DataGridView dataQuestion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label3;
    }
}

