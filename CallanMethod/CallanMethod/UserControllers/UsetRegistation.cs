using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using CallanMethod.DataClass;


namespace CallanMethod
{
    public partial class UsetRegistation : MetroFramework.Controls.MetroUserControl
    {
        public UsetRegistation()
        {
            InitializeComponent();
        }

        private void butSignUp_Click(object sender, EventArgs e)
        {
            String fullName = tbFullName.Text;
            String userLogin = tbLogin.Text;
            String userEmail = tbEmail.Text;
            String userPassword = tbPassword.Text;

            if (String.IsNullOrEmpty(fullName)
                || String.IsNullOrEmpty(userLogin)
                || String.IsNullOrEmpty(userEmail)
                || String.IsNullOrEmpty(userPassword))
            {
                MainForm.Instance.contollerID.ShowMessage("Some field is empty!!! Check again!!!");
            }

            User tUser = new User(userLogin, userPassword, fullName, userEmail, dateTimePicker1.Value);

            if (MainForm.Instance.contollerID.HasRegistration(tUser))
            {
                MainForm.Instance.contollerID.ShowMessage("Program have got login with login. Change it to another!");
            }
            else
            {
                MainForm.Instance.contollerID.RegistaionNewUser(tUser);
            }

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {

            PanelSignIn.Location = new Point(3, 102);
            PanelSignIn.BringToFront();
          

        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            PanelSigpUp.Location = new Point(3, 102);
            PanelSigpUp.BringToFront();
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {

            String userLogin = mLoginIn.Text;
            String userPassword = mPasswordIn.Text;

            if (String.IsNullOrEmpty(userLogin)
                || String.IsNullOrEmpty(userPassword))
            {
                MainForm.Instance.contollerID.ShowMessage("Some field is empty!!! Check again!!!");
            }

            User tUser = new User(userLogin, userPassword);

            if (MainForm.Instance.contollerID.HasRegistration(tUser) == false)
            {
                MainForm.Instance.contollerID.ShowMessage(@"Program haven't got login with password. Change it to another!");
                return;
            }
            
            if (!MainForm.Instance.MetroContainer.Controls.ContainsKey("MainMenu"))
            {
                MainMenu uc = new MainMenu();
                uc.Dock = DockStyle.Fill;
                MainForm.Instance.MetroContainer.Controls.Add(uc);
            }
            MainForm.Instance.MetroContainer.Controls["MainMenu"].BringToFront();
            MainForm.Instance.PictureBack.Visible = true;
            MainForm.Instance.UserHistory.Push("UsetRegistation");
        }

    }
}
