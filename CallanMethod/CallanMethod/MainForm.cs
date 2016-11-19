using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MetroFramework.Forms;
using MetroFramework.Controls;
using System.Windows.Forms;
using System.Data.SqlClient;
using CallanMethod.DataClass;

namespace CallanMethod
{
    public partial class MainForm : MetroForm
    {
 
        static public MainForm _instance;
        public Stack<String> UserHistory = new Stack<String>();
        public ControllerForm contollerID;       

        public static MainForm Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MainForm();
                return _instance;
            }
        }

        public MetroPanel MetroContainer
        {
            get { return mPanel; }
            set { mPanel = value; }
        }

        public PictureBox PictureBack
        {
            get { return pBack; }
            set { pBack = value; }
        }

       
        public MainForm()
        {
            InitializeComponent();
            InitializeDataBase();
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            pBack.Visible = false;
            _instance = this;
            UsetRegistation ru = new UsetRegistation();
            ru.Theme = MetroFramework.MetroThemeStyle.Dark;
            ru.Dock = DockStyle.Fill;
            mPanel.Controls.Add(ru);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //  mPanel.Controls["UsetRegistation"].BringToFront();
            if(UserHistory.Count != 0)
            {
                mPanel.Controls[UserHistory.Pop()].BringToFront();
                if(UserHistory.Count == 0)
                    pBack.Visible = false;
            }
            
        }

        private void InitializeDataBase()
        {
            contollerID = new ControllerForm();
        }
    }
}
