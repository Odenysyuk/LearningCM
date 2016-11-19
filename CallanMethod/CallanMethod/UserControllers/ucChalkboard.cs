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

        public ucChalkboard()
        {
            InitializeComponent();
            mTitle.BackColor = Color.FromArgb(73, 120, 89);
            mFoot.BackColor = Color.FromArgb(73, 120, 89);
            if (MainForm.Instance.contollerID.stateForStudy == 0)
                GetWordOnMonitor();





        }

        public void GetWordOnMonitor()
        {
            Word words = MainForm.Instance.contollerID.WordForStudy.Dequeue();
            mTitle.Text = words.Name;
            mFoot.Text = words.Translation;

        }
    }
}
