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

        public ucChalkboard()
        {
            InitializeComponent();
            tabBord.TabPages[0].BackColor = Color.FromArgb(73, 120, 89);
            tabBord.TabPages[1].BackColor = Color.FromArgb(73, 120, 89);
            tabBord.TabPages[2].BackColor = Color.FromArgb(73, 120, 89);

            if (MainForm.Instance.contollerID.stateForStudy == 0)
                GetWordOnMonitor();

        }

        public void GetWordOnMonitor()
        {
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

        private void pNext_Click(object sender, EventArgs e)
        {
            if(tabBord.SelectedTab == tPageOne)
            {
                labelTitle.Text = "Write five sentences with new word " + currentWords.Name;
                tabBord.SelectTab(1);
            }
            else if(tabBord.SelectedIndex == 1)
            {
                labTranslate.Text = String.Format("Write translation word {0} into English", currentWords.Translation); 
                tabBord.SelectTab(2);
            }
            else
            {
                if(mTextWord.Text == currentWords.Name)
                {
                    tabBord.SelectTab(0);
                    GetWordOnMonitor();
                }
                else
                {
                    labelErorr.Text = "It doesn't correct answer. Try again or use help!!!";
                }
                
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            mTextWord.Text = currentWords.Name;
        }
    }
}
