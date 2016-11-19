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
            if (!MainForm.Instance.MetroContainer.Controls.ContainsKey("ucChalkboard"))
            {
                ucChalkboard uc = new ucChalkboard();
                uc.Dock = DockStyle.Fill;
                MainForm.Instance.MetroContainer.Controls.Add(uc);
            }            
            MainForm.Instance.MetroContainer.Controls["ucChalkboard"].BringToFront();
            MainForm.Instance.PictureBack.Visible = true;
            MainForm.Instance.UserHistory.Push("ChoiceInStage");
        }

        private void metroRepeatLesson_Click(object sender, EventArgs e)
        {
            if (!MainForm.Instance.MetroContainer.Controls.ContainsKey("ucChalkboard"))
            {
                ucChalkboard uc = new ucChalkboard();
                uc.Dock = DockStyle.Fill;
                MainForm.Instance.MetroContainer.Controls.Add(uc);
            }
            MainForm.Instance.MetroContainer.Controls["ucChalkboard"].BringToFront();
            MainForm.Instance.PictureBack.Visible = true;
        }

        private void metroRepeatDictionary_Click(object sender, EventArgs e)
        {
            if (!MainForm.Instance.MetroContainer.Controls.ContainsKey("ucChalkboard"))
            {
                ucChalkboard uc = new ucChalkboard();
                uc.Dock = DockStyle.Fill;
                MainForm.Instance.MetroContainer.Controls.Add(uc);
            }
            MainForm.Instance.MetroContainer.Controls["ucChalkboard"].BringToFront();
            MainForm.Instance.PictureBack.Visible = true;
        }
    }
}
