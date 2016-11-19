﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CallanMethod.Properties;
using CallanMethod;

namespace CallanMethod.DataClass
{
    public enum StateForLearnig {LearningLesson = 0,  RepeatLesson = 1, RepeatQuestion = 2};
    public class ControllerForm
    {
        DataSet dtSet = new DataSet();
        SqlDataAdapter adapterQuestion;
        SqlDataAdapter adapterWords;
        SqlDataAdapter adapterLearntWords;

        SqlDataAdapter aUsers;
        public User user { get; set; }
        public Stage stage { get; set; }
        public Queue<Word>WordForStudy = new Queue<Word>();
        public StateForLearnig stateForStudy { get; set; }
         

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
                if (users.Count != 0)
                {
                    userAplication.FullName = users[0]["Name"].ToString();
                    userAplication.AmountOfBlock = Convert.ToInt32(users[0]["AmoutOfBlock"].ToString());
                    userAplication.DateOfBirth = Convert.ToDateTime(users[0]["DateOfBirth"].ToString());
                    return true;
                }
                    

            }
            
            return false;
        }

        public bool RegistaionNewUser(User userAplication)
        {
            var newRow = dtSet.Tables["Users"].NewRow();
            newRow["ID_Login"] = userAplication.userLogin;
            newRow["Name"] = userAplication.FullName;
            newRow["UserPassword"] = userAplication.Password;
            newRow["DateOfBirth"] = userAplication.DateOfBirth;
            newRow["Mail"] = userAplication.Mail;
            newRow["AmoutOfBlock"] = userAplication.AmountOfBlock;
            dtSet.Tables["Users"].Rows.Add(newRow);

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
                if (users.Count!= 0)
                {
                    this.user = userAplication;
                    return true;
                }
                    
            }

            return false;
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

        public bool GetWordForLerning()
        {

            WordForStudy.Clear();
            using (SqlConnection connection = new SqlConnection(Settings.Default.DbConnect))
            {
                adapterWords = new SqlDataAdapter(CommandFindWordForStudy(), connection);
                try
                {
                    adapterWords.Fill(dtSet, "Words");
                }
                catch (Exception e)
                {
                    ShowMessage(e.Message);
                    return false;
                }
                DataRowCollection words = dtSet.Tables["Words"].Rows;
                if (words.Count != 0)
                {
                    foreach (DataRow el in words)
                    {
                        WordForStudy.Enqueue(
                                            new Word(Int32.Parse(el["ID_Word"].ToString()),
                                                 el["Name"].ToString(),
                                                 el["Translation"].ToString(),
                                                 el["ID_Block"].ToString(),
                                                 el["ID_Lesson"].ToString(),
                                                 el["ID_Stage"].ToString()
                                                 )
                                            );

                    }

                    return true;
                }

                return false;

            }
        }

        private String CommandFindWordForStudy()
        {
            return "SELECT *  " +
                   " FROM Words " +
                   " WHERE ID_Word Not IN (SELECT ID_Word FROM LearntWords) "+
                   " AND ID_Stage = " + this.stage.ID_Stage.ToString();
        }

    }
}
