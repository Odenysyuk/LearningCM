using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CallanMethod.Properties;

namespace CallanMethod.DataClass
{
    public class ControllerForm
    {
        DataSet dtSet = new DataSet();
        SqlDataAdapter adapterBlock;
        SqlDataAdapter adapterLessons;
        SqlDataAdapter adapterStages;
        SqlDataAdapter adapterQuestion;
        SqlDataAdapter adapterWords;
        SqlDataAdapter aUsers;
        public User user { get; set; }

        public bool HasRegistration(User userAplication)
        {
            using (SqlConnection connection = new SqlConnection(Settings.Default.DbConnect))
            {
                aUsers = new SqlDataAdapter(userAplication.CommandFindUsers(), connection);
                try
                {
                    aUsers.Fill(dtSet, "Users");
                }
                catch (Exception e)
                {
                    ShowMessage(e.Message);
                    return false;
                }
                var users = dtSet.Tables["Users"].Rows;
                if (users.Count == 0)
                    return false;

            }
            
            return true;
        }

        public bool RegistaionNewUser(User userAplication)
        {
            using (SqlConnection connection = new SqlConnection(Settings.Default.DbConnect))
            {
                aUsers = new SqlDataAdapter(userAplication.CommandFindUsers(), connection);
                aUsers.UpdateCommand = userAplication.CommandUpdate(connection);
                aUsers.InsertCommand = userAplication.CommandInsert(connection);
                aUsers.DeleteCommand = userAplication.CommanDelete(connection);
                try
                {
                    aUsers.Update(dtSet, "Users");
                }
                catch (Exception e)
                {
                    ShowMessage(e.Message);
                    return false;
                }
                var users = dtSet.Tables["Users"].Rows;
                if (users.Count == 0)
                    return false;
            }

            return true;
        }

        public void ShowMessage(String textMessage)
        {
            MetroFramework.Forms.MetroMessageBox msg = new MetroFramework.Forms.MetroMessageBox();
            msg.ShowIcon = true;
            msg.Style = MetroFramework.MetroColorStyle.Teal;
            msg.Theme = MetroFramework.MetroThemeStyle.Dark;
            msg.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            msg.Text = textMessage;
            msg.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.AeroShadow;
            msg.ShowDialog();
        }
    }
}
