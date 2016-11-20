using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CallanMethod.DataClass;

namespace CallanMethod
{
    public partial class ucChalkboard : MetroFramework.Controls.MetroUserControl
    {
        Word currentWords;
        Question currentlyQuestion;
        public ucChalkboard()
        {
            InitializeComponent();  
        }


        /// <summary>
        /// GetWordOnMonitor -for first tabPage. Show new word from stage. 
        /// </summary>
        public void GetWordOnMonitor()
        {
            tabBord.SelectTab(0);
            if (MainForm.Instance.contollerID.WordForStudy.Count > 1)
            { 
                currentWords = MainForm.Instance.contollerID.WordForStudy.Dequeue();
                pageOneTitle.Text = currentWords.Name;
                pageOneFoot.Text = currentWords.Translation;
            }
            else
            {
                pageOneTitle.Text = "Congratulations!!! You learn all word in this stage. Repeat them or try next stage!))";
                pageOneFoot.Text ="";
            }
        }

        public void GetWordRepeatOnMonitor()
        {
           
            if (MainForm.Instance.contollerID.WordForRepeat.Count > 0)
            {
                currentWords = MainForm.Instance.contollerID.WordForRepeat.Dequeue();
                labTranslate.Text = String.Format("Write translation word {0} into English", currentWords.Translation);
                mTextWord.Text = "";
                tabBord.SelectTab(2);

            }
            else
            {
                tabBord.SelectTab(0);
                pageOneTitle.Text = "Congratulations!!!\n You repeat all word \n in this stage. \nTry learn more!))";
                pageOneFoot.Text = "";
                currentWords = null;
            }
        }

        public void GetQuestionOnMonitor()
        {
            tabBord.SelectTab(3);

            if (MainForm.Instance.contollerID.Questions.Count > 0)
            {
                currentlyQuestion = MainForm.Instance.contollerID.Questions.Dequeue();
                labQuestion.Text = currentlyQuestion.Name;
                labAnswer.Text = "";
            }
            else
            {
                labQuestion.Text = "Congratulations!!!\n You repeat all questions \n in this stage. \nTry learn more!))";
                labAnswer.Text = "";
                currentlyQuestion = null;
            }
        }
        private void pNext_Click(object sender, EventArgs e)
        {
            mTBoxOne.Text = metroTextBox1.Text = metroTextBox2.Text = metroTextBox3.Text = metroTextBox4.Text = "";
            if (MainForm.Instance.contollerID.stateForStudy == StateForLearnig.LearningLesson)
                workingWithStudy();
            if (MainForm.Instance.contollerID.stateForStudy ==  StateForLearnig.RepeatLesson)
                workinWithRepeat();


        }

        void workingWithStudy()
        {
            if (tabBord.SelectedTab == tPageOne)
            {
                labelTitle.Text = "Write five sentences with new word " + currentWords.Name;
                tabBord.SelectTab(1);
            }
            else if (tabBord.SelectedIndex == 1)
            {
                labTranslate.Text = String.Format("Write translation word {0} into English", currentWords.Translation);
                tabBord.SelectTab(2);
            }
            else
            {
                if (mTextWord.Text.ToUpper() == currentWords.Name.ToUpper())
                {
                    if(currentWords != null)
                    {
                        MainForm.Instance.contollerID.AddNewWordForLernt(currentWords);
                    }
                    tabBord.SelectTab(0);
                    GetWordOnMonitor();
                }
                else
                {
                    labelErorr.Text = "It doesn't correct answer. Try again or use help!!!";
                }

            }

        }

        void workinWithRepeat()
        {
            if (tabBord.SelectedIndex == 2)
            {
                if (mTextWord.Text.ToUpper() != currentWords.Name.ToUpper())
                {
                    labelErorr.Text = "It doesn't correct answer. Try again or use help!!!";
                    return;
                }

                labTranslate.Text = "Write five sentences with new word " + currentWords.Name;
                tabBord.SelectTab(1);
            }
            else
            {
                GetWordRepeatOnMonitor();
                if(currentWords != null)
                    tabBord.SelectTab(2);
            }

        }




        private void pictureBox4_Click(object sender, EventArgs e)
        {
            mTextWord.Text = currentWords.Name;
        }

        private void mTextWord_Click(object sender, EventArgs e)
        {
            labelErorr.Text = "";
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            tabBord.TabPages[0].BackColor = Color.FromArgb(73, 120, 89);
            tabBord.TabPages[1].BackColor = Color.FromArgb(73, 120, 89);
            tabBord.TabPages[2].BackColor = Color.FromArgb(73, 120, 89);
            tabBord.TabPages[3].BackColor = Color.FromArgb(73, 120, 89);

            if (MainForm.Instance.contollerID.stateForStudy == StateForLearnig.LearningLesson)
                GetWordOnMonitor();
            else if (MainForm.Instance.contollerID.stateForStudy == StateForLearnig.RepeatLesson)
                GetWordRepeatOnMonitor();
            else if (MainForm.Instance.contollerID.stateForStudy == StateForLearnig.RepeatQuestion)
                GetQuestionOnMonitor();

        }

        private void pageOneTitle_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            GetQuestionOnMonitor();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (currentlyQuestion != null)
                labAnswer.Text = currentlyQuestion.Answer;
        }
    }
}
