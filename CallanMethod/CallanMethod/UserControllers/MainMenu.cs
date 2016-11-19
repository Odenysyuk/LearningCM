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
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            if (!MainForm.Instance.MetroContainer.Controls.ContainsKey("ChoiceInStage"))
            {
                ChoiceInStage uc = new ChoiceInStage();
                uc.Dock = DockStyle.Fill;
                MainForm.Instance.MetroContainer.Controls.Add(uc);
            }
            MainForm.Instance.MetroContainer.Controls["ChoiceInStage"].BringToFront();
            MainForm.Instance.PictureBack.Visible = true;
            MainForm.Instance.UserHistory.Push("MainMenu");

        }
    }
}
