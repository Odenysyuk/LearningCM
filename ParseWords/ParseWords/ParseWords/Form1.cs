using Novacode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using ParseWords.Properties;

namespace ParseWords
{
    public partial class Form1 : Form
    {
        DocX docx;
        DataTable tableBlocks = new DataTable("Blocks");
        DataTable tableLessons = new DataTable("Lessons");
        DataTable tableStages = new DataTable("Stages");
        DataTable tableQuestion = new DataTable("Question");    
        DataTable tableWords = new DataTable("Words");
        DataSet dsBlocks;
        DataSet dsLessons;
        DataSet dsStages;
        DataSet dsQuestion;
        DataSet dsWords;
        SqlDataAdapter adapterBlock;
        SqlDataAdapter adapterLessons;
        SqlDataAdapter adapterStages;
        SqlDataAdapter adapterQuestion;
        SqlDataAdapter adapterWords;
  
        string NameFile
        {
            get { return nameFile; }
            set
            {
                textBox1.Text = value;
                nameFile = value;
            }
        }
        string nameFile;

        public Form1()
        {
            InitializeComponent();

            string set = Settings.Default.DbConnect;
            using(SqlConnection connection = new SqlConnection(Settings.Default.DbConnect))
            {
                connection.Open();
                adapterBlock = new SqlDataAdapter(GetSQLQueryBlocks(), connection);
                adapterBlock.InsertCommand = GetCommandInnerQueryBlocks(connection);
                adapterBlock.UpdateCommand = GetCommandUpdateQueryBlocks(connection);
                adapterBlock.DeleteCommand = GetCommandDeleteQueryBlocks(connection);
                dsBlocks = new DataSet();
                adapterBlock.Fill(dsBlocks);

                adapterLessons = new SqlDataAdapter(GetSQLQueryLessons(), connection);
                adapterLessons.InsertCommand = GetCommandInnerQueryLessons(connection);
                adapterLessons.UpdateCommand = GetCommandUpdateQueryLessons(connection);
                adapterLessons.DeleteCommand = GetCommandDeleteQueryLessons(connection);
                dsLessons = new DataSet();
                adapterLessons.Fill(dsLessons);

                adapterStages = new SqlDataAdapter(GetSQLQueryStages(), connection);
                adapterStages.InsertCommand = GetCommandInnerQueryStages(connection);
                adapterStages.UpdateCommand = GetCommandUpdateQueryStages(connection);
                adapterStages.DeleteCommand = GetCommandDeleteQueryStages(connection);
                dsStages = new DataSet();
                adapterStages.Fill(dsStages);

                adapterQuestion = new SqlDataAdapter(GetSQLQueryQuestion(), connection);
                dsQuestion = new DataSet();
                adapterQuestion.InsertCommand = GetCommandInnerQueryQuestion(connection);
                adapterQuestion.UpdateCommand = GetCommandUpdateQueryQuestion(connection);
                adapterQuestion.DeleteCommand = GetCommandDeleteQueryQuestion(connection);
                adapterQuestion.Fill(dsQuestion);

                adapterWords = new SqlDataAdapter(GetSQLQueryWords(), connection);
                dsWords = new DataSet();
                adapterWords.InsertCommand = GetCommandInnerQueryWords(connection);
                adapterWords.UpdateCommand = GetCommandUpdateQueryWords(connection);
                adapterWords.DeleteCommand = GetCommandDeleteQueryWords(connection);
                adapterWords.Fill(dsWords);
            }

            dsBlocks.WriteXml("dsBlocks.xml");
            dsLessons.WriteXml("dsLessons.xml");
            dsStages.WriteXml("dsStages.xml");
            dsQuestion.WriteXml("dsQuestion.xml");
            dsWords.WriteXml("dsWords.xml");


            tableBlocks = dsBlocks.Tables[0];
            tableBlocks.Columns[0].AllowDBNull = false;
            tableBlocks.Columns[0].AutoIncrement = true;
            tableBlocks.Columns[0].AutoIncrementStep = 1;
            tableBlocks.Columns[0].Unique = true;
            dataBlock.DataSource = tableBlocks;

            tableLessons = dsLessons.Tables[0];
            tableLessons.Columns[0].AllowDBNull = false;
            tableLessons.Columns[0].AutoIncrement = true;
            tableLessons.Columns[0].AutoIncrementStep = 1;
            tableLessons.Columns[0].Unique = true;
            dataLessons.DataSource = tableLessons;

            tableStages = dsStages.Tables[0];
            tableStages.Columns[0].AllowDBNull = false;
            tableStages.Columns[0].AutoIncrement = true;
            tableStages.Columns[0].AutoIncrementSeed = 1;
            tableStages.Columns[0].AutoIncrementStep = 1;
            tableStages.Columns[0].Unique = true;
            dataStage.DataSource = tableStages;

            tableQuestion = dsQuestion.Tables[0];
            tableQuestion.Columns[0].AllowDBNull = false;
            tableQuestion.Columns[0].AutoIncrement = true;
            tableQuestion.Columns[0].AutoIncrementSeed = 1;
            tableQuestion.Columns[0].AutoIncrementStep = 1;
            tableQuestion.Columns[0].Unique = true;
            dataQuestion.DataSource = tableQuestion;

            tableWords = dsWords.Tables[0];
            tableWords.Columns[0].AllowDBNull = false;
            tableWords.Columns[0].AutoIncrement = true;
            tableWords.Columns[0].AutoIncrementSeed = 1;
            tableWords.Columns[0].AutoIncrementStep = 1;
            tableWords.Columns[0].Unique = true;
            dataWords.DataSource = tableWords;
            
        }

        private void butOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "doc files (*.docx)|*.docx";
            file.RestoreDirectory = true;
            if (file.ShowDialog() == DialogResult.OK)
            {
                NameFile = file.FileName;
                try
                {
                    docx = DocX.Load(NameFile);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        private void butParse_Click(object sender, EventArgs e)
        {

            if (docx != null)
            {
                int block = (int)numericUpDown3.Value;
                int lesson = (int)numericUpDown2.Value;
                int stage = (int)numericUpDown1.Value;
                int temp;

                var paraghList = docx.Paragraphs;

                Queue<String> queueWords = new Queue<string>();
                foreach (var el in paraghList)
                {
                    var text = el.Text;
                    var TempetionArray = text.Split("\t".ToCharArray());
                    foreach (var elTemp in TempetionArray)
                    {
                        if (String.IsNullOrEmpty(elTemp))
                            continue;
                        int resTemp;
                        if (Int32.TryParse(elTemp, out resTemp) == true)
                        {
                            block = resTemp;
                            DataRow row = tableBlocks.NewRow();
                            row[0] = block.ToString();
                            row[1] = block.ToString();
                            tableBlocks.Rows.Add(row);
                            break;
                        }

                    }
                    if (text.Contains("STAGE"))
                    {
                        DataRow row = tableStages.NewRow();
                        row[0] = (stage).ToString();
                        row[1] = (stage).ToString();
                        tableStages.Rows.Add(row);
                        continue;
                    }
                    else if (text.Contains("LESSON"))
                    {
                        DataRow row = tableLessons.NewRow();
                        row[0] = (++lesson).ToString();
                        row[1] = (lesson).ToString();
                        tableLessons.Rows.Add(row);
                        continue;
                    }
                    else if (text.Contains("SEE CHART"))
                    {
                        continue;
                    }

                    var MagicTexts = el.MagicText;


                    foreach (var mag in MagicTexts)
                    {
                        var mt = mag.text;

                        if (mt.Trim() == "")
                        {
                            continue;
                        }
                        if (Int32.TryParse(mt, out temp) && temp != block)
                        {
                            block = temp;
                            DataRow row = tableBlocks.NewRow();
                            row[0] = block.ToString();
                            row[1] = block.ToString();
                            tableBlocks.Rows.Add(row);
                            continue;
                        }

                        if ((mag.formatting != null) && (mag.formatting.Bold != null) && (bool)mag.formatting.Bold)
                        {
                            var Arrays = mt.Split("\t".ToCharArray());
                            foreach (var wordin in Arrays)
                            {
                                if (Int32.TryParse(wordin, out temp))
                                {
                                    if (temp != block)
                                    {
                                        block = temp;
                                        DataRow row = tableBlocks.NewRow();
                                        row[0] = block.ToString();
                                        row[1] = block.ToString();
                                        tableBlocks.Rows.Add(row);

                                    }
                                    continue;

                                }
                                queueWords.Enqueue((String)wordin.Trim());
                            }
                            //add block last time
                        }
                        else if ((mag.formatting != null) && (mag.formatting.Italic != null) && (bool)mag.formatting.Italic)
                        {
                            var Arrays = mt.Contains("\t") ? mt.Split("\t".ToCharArray()) : mt.Split(" ".ToCharArray());
                            foreach (var wordin in Arrays)
                            {
                                if (queueWords.Count != 0)
                                {
                                    DataRow row = tableWords.NewRow();
                                    row[1] = queueWords.Dequeue();
                                    row[2] = (String)wordin.Trim();
                                    row[3] = block.ToString();
                                    row[5] = stage.ToString();
                                    row[4] = lesson.ToString();
                                    tableWords.Rows.Add(row);
                                }
                            }

                        }
                        else if ((mag.formatting != null) && (mag.formatting.UnderlineStyle != null) && (mag.formatting.UnderlineStyle == UnderlineStyle.singleLine))
                        {
                            var Arrays = mt.Split("?".ToCharArray());
                            if (Arrays.Count() > 1)
                            {
                                DataRow row = tableQuestion.NewRow();
                                row[1] = block.ToString();
                                row[2] = Arrays[0].Trim() + "?";
                                row[3] = Arrays[1].Trim();
                                tableQuestion.Rows.Add(row);
                            }
                        }
                    }
                }
            }

        }

        private String GetSQLQueryWords()
        {
             return "SELECT * FROM dbo.Words  WHERE ID_Stage = " + numericUpDown1.Value;
        }

        private SqlCommand GetCommandInnerQueryWords(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand("SET IDENTITY_INSERT Words ON  INSERT INTO Words (ID_Word, Name, Translation, ID_Block, ID_Lesson, ID_Stage) " +
                    "VALUES (@ID_Word, @Name, @Translation, @ID_Block, @ID_Lesson, @ID_Stage)  SET IDENTITY_INSERT Words OFF ", connection);
            command.Parameters.Add("@ID_Word", SqlDbType.NVarChar, 5, "ID_Word");
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 100, "Name");
            command.Parameters.Add("@Translation", SqlDbType.NVarChar, 100, "Translation");
            command.Parameters.Add("@ID_Block", SqlDbType.NChar, 5, "ID_Block");
            command.Parameters.Add("@ID_Lesson", SqlDbType.NChar, 5, "ID_Lesson");
            command.Parameters.Add("@ID_Stage", SqlDbType.NChar, 5, "ID_Stage");
            return command;
        }

        private SqlCommand GetCommandUpdateQueryWords(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand("UPDATE Words SET Name = @Name, Translation = @Translation, ID_Block = @ID_Block, ID_Lesson = @ID_Lesson, ID_Stage = @ID_Stage" +
                    " WHERE ID_Word = @oldID_Word", connection);

            command.Parameters.Add("@Name", SqlDbType.NVarChar, 100, "Name");
            command.Parameters.Add("@Translation", SqlDbType.NVarChar, 100, "Translation");
            command.Parameters.Add("@ID_Block", SqlDbType.NChar, 5, "ID_Block");
            command.Parameters.Add("@ID_Lesson", SqlDbType.NChar, 5, "ID_Lesson");
            command.Parameters.Add("@ID_Stage", SqlDbType.NChar, 5, "ID_Stage");
            SqlParameter parameter = command.Parameters.Add(
                    "@oldID_Word", SqlDbType.NChar, 5, "ID_Word");
            parameter.SourceVersion = DataRowVersion.Original;
            return command;
        }
        private SqlCommand GetCommandDeleteQueryWords(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand("DELETE FROM  Words " +
                    " WHERE ID_Word = @ID_Word", connection);

            SqlParameter parameter = command.Parameters.Add(
                    "@ID_Word", SqlDbType.NChar, 5, "ID_Word");
            parameter.SourceVersion = DataRowVersion.Original;
            return command;
        }



        private String GetSQLQueryBlocks()
        {
            return "SELECT b.ID_Block, b.Name FROM dbo.Blocks as b INNER JOIN dbo.Words as w  ON b.ID_Block = w.ID_Block"+
                    " WHERE w.ID_Stage  = " + numericUpDown1.Value;
        }

        
        private SqlCommand GetCommandInnerQueryBlocks(SqlConnection  connection)
        {
            SqlCommand command =  new SqlCommand("SET IDENTITY_INSERT Blocks ON " +
                " INSERT INTO Blocks (ID_Block, Name) " +
                    "VALUES (@ID_Block, @Name) "+
                    " SET IDENTITY_INSERT Blocks OFF ", connection);

            command.Parameters.Add("@ID_Block", SqlDbType.NChar, 5, "ID_Block");
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 40, "Name");
            return command;
        }

        private SqlCommand GetCommandUpdateQueryBlocks(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand("UPDATE Blocks SET  ID_Block = @ID_Block, Name = @Name " +
                    "WHERE ID_Block = @oldID_Block", connection);

            command.Parameters.Add("@ID_Block", SqlDbType.NChar, 5, "ID_Block");
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 40, "Name");
            SqlParameter parameter = command.Parameters.Add(
                    "@oldID_Block", SqlDbType.NChar, 5, "ID_Block");
            parameter.SourceVersion = DataRowVersion.Original;
            return command;
        }

        private SqlCommand GetCommandDeleteQueryBlocks(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand("DELETE FROM  Blocks " +
                    " WHERE ID_Block = @ID_Block", connection);

            SqlParameter parameter = command.Parameters.Add(
                    "@ID_Block", SqlDbType.NChar, 5, "ID_Block");
            parameter.SourceVersion = DataRowVersion.Original;
            return command;
        }

        private String GetSQLQueryLessons()
        {
            return "SELECT l.ID_Lesson, l.Name FROM dbo.Lessons as l INNER JOIN dbo.Words as w  ON l.ID_Lesson = w.ID_Lesson" +
                    " WHERE w.ID_Stage  =" + numericUpDown1.Value;
        }

        private SqlCommand GetCommandInnerQueryLessons(SqlConnection connection)
        {

            SqlCommand command = new SqlCommand("SET IDENTITY_INSERT Lessons ON " +
               " INSERT INTO Lessons (ID_Lesson, Name) " +
                  " VALUES(@ID_Lesson, @Name) " +
                   " SET IDENTITY_INSERT Lessons OFF ", connection);


            command.Parameters.Add("@ID_Lesson", SqlDbType.NChar, 5, "ID_Lesson");
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 40, "Name");
            return command;
        }

        private SqlCommand GetCommandUpdateQueryLessons(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand("UPDATE Lessons SET  ID_Lesson = @ID_Lesson, Name = @Name " +
                    "WHERE ID_Lesson = @oldID_Lesson", connection);

            command.Parameters.Add("@ID_Lesson", SqlDbType.NChar, 5, "ID_Lesson");
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 40, "Name");
            SqlParameter parameter = command.Parameters.Add(
                    "@oldID_Lesson", SqlDbType.NChar, 5, "ID_Lesson");
            parameter.SourceVersion = DataRowVersion.Original;
            return command;
        }

        private SqlCommand GetCommandDeleteQueryLessons(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand("DELETE FROM  Lessons " +
                    " WHERE ID_Lesson = @ID_Lesson", connection);

            SqlParameter parameter = command.Parameters.Add(
                    "@ID_Lesson", SqlDbType.NChar, 5, "ID_Lesson");
            parameter.SourceVersion = DataRowVersion.Original;
            return command;
        }

        private String GetSQLQueryStages()
        {
            return "SELECT* FROM dbo.Stages WHERE ID_Stage = " + numericUpDown1.Value;
        }


        private SqlCommand GetCommandInnerQueryStages(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand("SET IDENTITY_INSERT Stages ON " + 
                "INSERT INTO Stages (ID_Stage, Name) " +
                    "VALUES (@ID_Stage, @Name)" +
                  " SET IDENTITY_INSERT Stages OFF ", connection);

            command.Parameters.Add("@ID_Stage", SqlDbType.NChar, 5, "ID_Stage");
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 40, "Name");
            return command;
        }

        private SqlCommand GetCommandUpdateQueryStages(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand("UPDATE Stages SET  ID_Stage = @ID_Stage, Name = @Name " +
                    "WHERE ID_Stage = @oldID_Stage", connection);

            command.Parameters.Add("@ID_Stage", SqlDbType.NChar, 5, "ID_Stage");
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 40, "Name");
            SqlParameter parameter = command.Parameters.Add(
                    "@oldID_Stage", SqlDbType.NChar, 5, "ID_Stage");
            parameter.SourceVersion = DataRowVersion.Original;
            return command;
        }

        private SqlCommand GetCommandDeleteQueryStages(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand("DELETE FROM  Stages " +
                    " WHERE ID_Stage = @ID_Stage", connection);

            SqlParameter parameter = command.Parameters.Add(
                    "@ID_Block", SqlDbType.NChar, 5, "ID_Block");
            parameter.SourceVersion = DataRowVersion.Original;
            return command;
        }

        private String GetSQLQueryQuestion()
        {
            return "SELECT q.ID_Questin, q.ID_Block, q.Question, q.Answer FROM dbo.Question as q INNER JOIN  dbo.Words as w"+
                    " ON q.ID_Block = w.ID_Block"+
                    " WHERE w.ID_Stage = " + numericUpDown1.Value;
        }

        private SqlCommand GetCommandInnerQueryQuestion(SqlConnection connection)
        {

            SqlCommand command = new SqlCommand("SET IDENTITY_INSERT Question ON " +
                " INSERT INTO Question (ID_Questin, ID_Block, Question, Answer) " +
                    "VALUES (@ID_Questin, @ID_Block, @Question, @Answer) " +
                 " SET IDENTITY_INSERT Question OFF ", connection);
            command.Parameters.Add("@ID_Questin", SqlDbType.NChar, 5, "ID_Questin");
            command.Parameters.Add("@ID_Block", SqlDbType.NChar, 5, "ID_Block");
            command.Parameters.Add("@Question", SqlDbType.NVarChar, 100, "Question");
            command.Parameters.Add("@Answer", SqlDbType.NVarChar, 100, "Answer");
            return command;
        }

        private SqlCommand GetCommandUpdateQueryQuestion(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand("UPDATE Question SET  ID_Block = @ID_Block, Question = @Question, Answer = @Answer  " +
                    "WHERE ID_Questin = @oldID_Questin", connection);

            command.Parameters.Add("@ID_Block", SqlDbType.NChar, 5, "ID_Block");
            command.Parameters.Add("@Question", SqlDbType.NVarChar, 100, "Question");
            command.Parameters.Add("@Answer", SqlDbType.NVarChar, 100, "Answer");
            SqlParameter parameter = command.Parameters.Add(
                    "@oldID_Questin", SqlDbType.NChar, 5, "ID_Questin");
            parameter.SourceVersion = DataRowVersion.Original;
            return command;
        }

        private SqlCommand GetCommandDeleteQueryQuestion(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand("DELETE FROM  Question " +
                    " WHERE ID_Questin = @ID_Questin", connection);

            SqlParameter parameter = command.Parameters.Add(
                    "@ID_Questin", SqlDbType.NChar, 5, "ID_Questin");
            parameter.SourceVersion = DataRowVersion.Original;
            return command;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Settings.Default.DbConnect))
            {
                connection.Open();

                adapterBlock = new SqlDataAdapter(GetSQLQueryBlocks(), connection);
                adapterBlock.InsertCommand = GetCommandInnerQueryBlocks(connection);
                adapterBlock.UpdateCommand = GetCommandUpdateQueryBlocks(connection);
                adapterBlock.DeleteCommand = GetCommandDeleteQueryBlocks(connection);
                adapterBlock.Update(dsBlocks);
                dsBlocks.Clear();
                adapterBlock.Fill(dsBlocks);

                adapterLessons = new SqlDataAdapter(GetSQLQueryLessons(), connection);
                adapterLessons.InsertCommand = GetCommandInnerQueryLessons(connection);
                adapterLessons.UpdateCommand = GetCommandUpdateQueryLessons(connection);
                adapterLessons.DeleteCommand = GetCommandDeleteQueryLessons(connection);
                adapterLessons.Update(dsLessons);
                dsLessons.Clear();
                adapterLessons.Fill(dsLessons);

                adapterStages = new SqlDataAdapter(GetSQLQueryStages(), connection);
                adapterStages.InsertCommand = GetCommandInnerQueryStages(connection);
                adapterStages.UpdateCommand = GetCommandUpdateQueryStages(connection);
                adapterStages.DeleteCommand = GetCommandDeleteQueryStages(connection);
                adapterStages.Update(dsStages);
                dsStages.Clear();
                adapterStages.Fill(dsStages);

                adapterQuestion = new SqlDataAdapter(GetSQLQueryQuestion(), connection);
                adapterQuestion.InsertCommand = GetCommandInnerQueryQuestion(connection);
                adapterQuestion.UpdateCommand = GetCommandUpdateQueryQuestion(connection);
                adapterQuestion.DeleteCommand = GetCommandDeleteQueryQuestion(connection);
                adapterQuestion.Update(dsQuestion);
                dsQuestion.Clear();
                adapterQuestion.Fill(dsQuestion);

                adapterWords = new SqlDataAdapter(GetSQLQueryWords(), connection);
                adapterWords.InsertCommand = GetCommandInnerQueryWords(connection);
                adapterWords.UpdateCommand = GetCommandUpdateQueryWords(connection);
                adapterWords.DeleteCommand = GetCommandDeleteQueryWords(connection);
                adapterWords.Update(dsWords);
                dsWords.Clear();
                adapterWords.Fill(dsWords);

            }              

        }
    }
}








