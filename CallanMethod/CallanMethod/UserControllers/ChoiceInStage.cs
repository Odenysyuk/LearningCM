using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CallanMethod
{
    public partial class ChoiceInStage : MetroFramework.Controls.MetroUserControl
    {
        public ChoiceInStage()
        {
            InitializeComponent();
            
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            if(MainForm.Instance.contollerID.GetWordForLerning() == false)
            {
                MainForm.Instance.contollerID.ShowMessage("Ups...Haven't got any information!!!");
                return;
            }

            MainForm.Instance.contollerID.GetWordForRepeat();

            MainForm.Instance.contollerID.stateForStudy = DataClass.StateForLearnig.LearningLesson;

            if (!MainForm.Instance.MetroContainer.Controls.ContainsKey("ucChalkboard"))
            {
                ucChalkboard uc = new ucChalkboard();
                uc.Dock = DockStyle.Fill;
                MainForm.Instance.MetroContainer.Controls.Add(uc);
            }
            MainForm.Instance.MetroContainer.Controls["ucChalkboard"].Invalidate(true);
            MainForm.Instance.MetroContainer.Controls["ucChalkboard"].BringToFront();
            MainForm.Instance.PictureBack.Visible = true;
            MainForm.Instance.UserHistory.Push("ChoiceInStage");
        }

        private void metroRepeatLesson_Click(object sender, EventArgs e)
        {
            if (MainForm.Instance.contollerID.GetWordForRepeat() == false)
            {
                MainForm.Instance.contollerID.ShowMessage("Ups...Haven't got any information!!!");
                return;
            }

            MainForm.Instance.contollerID.stateForStudy = DataClass.StateForLearnig.RepeatLesson;

            if (!MainForm.Instance.MetroContainer.Controls.ContainsKey("ucChalkboard"))
            {
                ucChalkboard uc = new ucChalkboard();
                uc.Dock = DockStyle.Fill;
                MainForm.Instance.MetroContainer.Controls.Add(uc);
            }
            MainForm.Instance.MetroContainer.Controls["ucChalkboard"].Invalidate(true);
            MainForm.Instance.MetroContainer.Controls["ucChalkboard"].BringToFront();
            MainForm.Instance.PictureBack.Visible = true;
        }

        private void metroRepeatDictionary_Click(object sender, EventArgs e)
        {

            if (MainForm.Instance.contollerID.GetWordForReQuestion() == false)
            {
                MainForm.Instance.contollerID.ShowMessage("Ups...Haven't got any information!!!");
                return;
            }

            MainForm.Instance.contollerID.stateForStudy = DataClass.StateForLearnig.RepeatQuestion;

            if (!MainForm.Instance.MetroContainer.Controls.ContainsKey("ucChalkboard"))
            {
                ucChalkboard uc = new ucChalkboard();
                uc.Dock = DockStyle.Fill;
                MainForm.Instance.MetroContainer.Controls.Add(uc);
            }
            MainForm.Instance.MetroContainer.Controls["ucChalkboard"].Invalidate(true);
            MainForm.Instance.MetroContainer.Controls["ucChalkboard"].BringToFront();
            MainForm.Instance.PictureBack.Visible = true;
        }

        private void ChoiceInStage_Load(object sender, EventArgs e)
        {

        }

        private void ChoiceInStage_StyleChanged(object sender, EventArgs e)
        {

        }

        private void ChoiceInStage_Paint(object sender, PaintEventArgs e)
        {
            labStage.Text = "Stage " + MainForm.Instance.contollerID.stage.Name;
        }
    }
}
