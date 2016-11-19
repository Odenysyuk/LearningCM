using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CallanMethod
{
    public class User
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Mail { get; set; }
        public int AmountOfBlock { get; set; }
        private string password;
        public string Password { get { return password; } set { password = ToMD5(value); } }
        public string userLogin { get; set; }

        public User(String userLogin, String password, String FullName, String Mail, DateTime DateOfBirth)
        {
            this.userLogin = userLogin;
            this.Password = password;
            this.FullName = FullName;
            this.Mail = Mail;
            this.DateOfBirth = DateOfBirth;
        }

        public User(String userLogin, String password) : this(userLogin, password, "", "", new DateTime())
        { }


        public static string ToMD5(string str)
        {
            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            return BitConverter.ToString(mD5CryptoServiceProvider.ComputeHash(Encoding.Default.GetBytes(str))).Replace("-", "").ToLower();
        }

        public String CommandFindUsers()
        {
            return @"Select * FROM Users Where ID_Login = '" + this.userLogin + "'";
        }

        public SqlCommand CommandUpdate(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(
                "UPDATE Users SET ID_Login = @ID_Login, Name = @Name, UserPassword = @UserPassword, DateOfBirth = @DateOfBirth, AmoutOfBlock = @AmoutOfBlock " +
                " WHERE ID_Login = @ID_Login_OLD ", connection);

            command.Parameters.Add("@ID_Login", SqlDbType.NChar, 5, "ID_Login");
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
            command.Parameters.Add("@UserPassword", SqlDbType.NChar, 50, "UserPassword");
            command.Parameters.Add("@DateOfBirth", SqlDbType.Date, 50, "DateOfBirth");
            command.Parameters.Add("@AmoutOfBlock", SqlDbType.Int, 50, "AmoutOfBlock");
            SqlParameter parameter = command.Parameters.Add(
                "@oldCustomerID", SqlDbType.NChar, 5, "ID_Login");
            parameter.SourceVersion = DataRowVersion.Original;

            return command;

        }

        public SqlCommand CommandInsert(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(
               "SET IDENTITY_INSERT Words ON "+
               "INSERT INTO Users (ID_Login, Name, UserPassword, DateOfBirth, AmoutOfBlock) " +
               " VALUES (@ID_Login, @Name, @UserPassword, @DateOfBirth, @AmoutOfBlock) "+
               " SET IDENTITY_INSERT Words OFF ", connection);

            command.Parameters.Add("@ID_Login", SqlDbType.NChar, 5, "ID_Login");
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
            command.Parameters.Add("@UserPassword", SqlDbType.NChar, 50, "UserPassword");
            command.Parameters.Add("@DateOfBirth", SqlDbType.Date, 50, "DateOfBirth");
            command.Parameters.Add("@AmoutOfBlock", SqlDbType.Int, 50, "AmoutOfBlock");
            return command;


        }
        public SqlCommand CommanDelete(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(
               "DELETE FROM Users WHERE ID_Login = @ID_Login_OLD", connection);

            SqlParameter parameter = command.Parameters.Add(
                "@oldCustomerID", SqlDbType.NChar, 5, "ID_Login");
            parameter.SourceVersion = DataRowVersion.Original;

            return command;


        }
    }


}
