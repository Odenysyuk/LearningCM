using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallanMethod.DataClass
{
    class LearntWord
    {
        public Word word { get; set; }
        public User user { get; set; }

        static public SqlCommand CommandUpdate(SqlConnection connection, Word word, User User)
        {
            SqlCommand command = new SqlCommand(
                "UPDATE LearntWords SET ID_Word = @ID_Word, ID_Login = @ID_Login " +
                " WHERE ID_Word = @ID_Word_OLD ", connection);

            command.Parameters.Add("@ID_Login", SqlDbType.NChar, 50, "ID_Login");
            command.Parameters.Add("@ID_Word", SqlDbType.NChar, 50, "ID_Word");

            SqlParameter parameter = command.Parameters.Add(
                "@ID_Word_OLD", SqlDbType.NChar, 50, "ID_Word");
            parameter.SourceVersion = DataRowVersion.Original;

            return command;

        }

        static public SqlCommand CommandInsert(SqlConnection connection, Word word, User user)
        {
            SqlCommand command = new SqlCommand("INSERT INTO LearntWords (ID_Word, ID_Login) " +
               " VALUES (@ID_Word, '"+user.userLogin+"') " 
              , connection);

            command.Parameters.Add("@ID_Word", SqlDbType.NChar, 50, "ID_Word");

            return command;


        }
        static public SqlCommand CommanDelete(SqlConnection connection, Word word, User User)
        {
            SqlCommand command = new SqlCommand(
               "DELETE FROM LearntWords WHERE ID_Word = @ID_Word_OLD AND  ID_Login = @ID_Login_OLD ", connection);

            SqlParameter parameter = command.Parameters.Add(
                "@ID_Word_OLD", SqlDbType.NChar, 50, "ID_Word");
            parameter.SourceVersion = DataRowVersion.Original;
            SqlParameter parameter1 = command.Parameters.Add(
                "@ID_Login_OLD", SqlDbType.NChar, 50, "ID_Login");
            parameter1.SourceVersion = DataRowVersion.Original;

            return command;


        }
    }
}
