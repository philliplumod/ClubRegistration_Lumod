using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubRegistrations
{
    class ClassRegistrationQuery
    {

        private SqlConnection sqlConnect = new SqlConnection(connectionString);
        private SqlCommand sqlCommand;
        private SqlDataAdapter sqlAdapter;
        private SqlDataReader sqlReader;

        public DataTable dataTable = new DataTable();
        public BindingSource bindingSource = new BindingSource();
        private static string connectionString = @"Data Source=DESKTOP-FKK41RK;Initial Catalog=ClubDB;Integrated Security=True";

        public string _FirstName, _MiddleName, _LastName, _Gender, _Program;
        public int _Age;


        public void DisplayList()
        {
            string ViewClubMembers = "SELECT StudentID, FirstName, MiddleName, LastName, Age, Gender, Programs FROM ClubMembers1 ";
            sqlAdapter = new SqlDataAdapter(ViewClubMembers, sqlConnect);
            dataTable.Clear();
            sqlAdapter.Fill(dataTable);
            bindingSource.DataSource = dataTable;
        }

        public bool RegisterStudent(int ID, long StudentID, string FirstName, string
                            MiddleName, string LastName, int Age, string Gender, string Program)
        {
            sqlCommand = new SqlCommand("INSERT INTO ClubMembers1 VALUES(@ID, @StudentID, @FirstName, @MiddleName, @LastName, @Age, @Gender, @Programs)", sqlConnect);
            sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            sqlCommand.Parameters.Add("@RegistrationID", SqlDbType.BigInt).Value = StudentID;
            sqlCommand.Parameters.Add("@StudentID", SqlDbType.VarChar).Value = StudentID;
            sqlCommand.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = FirstName;
            sqlCommand.Parameters.Add("@MiddleName", SqlDbType.VarChar).Value = MiddleName;
            sqlCommand.Parameters.Add("@LastName", SqlDbType.VarChar).Value = LastName;
            sqlCommand.Parameters.Add("@Age", SqlDbType.Int).Value = Age;
            sqlCommand.Parameters.Add("@Gender", SqlDbType.VarChar).Value = Gender;
            sqlCommand.Parameters.Add("@Programs", SqlDbType.VarChar).Value = Program;
            sqlConnect.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();
            return true;
        }

        public void AutoSearch(TextBox txtFirstName, TextBox txtMiddleName, TextBox txtLastName, TextBox txtAge, ComboBox cbGender, ComboBox cbProgram, int ID)
        {
            string selectID = "SELECT FirstName,MiddleName,LastName,Age,Gender,Programs FROM ClubMembers1 WHERE StudentID = @ID";
            sqlCommand = new SqlCommand(selectID, sqlConnect);
            sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            sqlCommand.CommandText = selectID;
            sqlConnect.Open();
            sqlReader = sqlCommand.ExecuteReader();

            while (sqlReader.Read())
            {
                txtFirstName.Text = (sqlReader["FirstName"].ToString());
                txtMiddleName.Text = (sqlReader["MiddleName"].ToString());
                txtLastName.Text = (sqlReader["LastName"].ToString());
                txtAge.Text = (sqlReader["Age"].ToString());
                cbGender.Text = (sqlReader["Gender"].ToString());
                cbProgram.Text = (sqlReader["Programs"].ToString());
            }
            sqlConnect.Close();
        }

        public void UpdateStudent(long StudentID, string FirstName, string MiddleName, string LastName, int Age, string Gender, string Programs)
        {
            sqlCommand = new SqlCommand("UPDATE ClubMembers1 SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, Age = @Age, Gender = @Gender, Programs = @Programs WHERE StudentID = @StudentID", sqlConnect);

            sqlCommand.Parameters.Add("@StudentID", SqlDbType.Int).Value = StudentID;
            sqlCommand.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = FirstName;
            sqlCommand.Parameters.Add("@MiddleName", SqlDbType.VarChar).Value = MiddleName;
            sqlCommand.Parameters.Add("@LastName", SqlDbType.VarChar).Value = LastName;
            sqlCommand.Parameters.Add("@Age", SqlDbType.Int).Value = Age;
            sqlCommand.Parameters.Add("@Gender", SqlDbType.VarChar).Value = Gender;
            sqlCommand.Parameters.Add("@Programs", SqlDbType.VarChar).Value = Programs;
            sqlConnect.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();
        }

        public void IdSelect(ComboBox cb)
        {
            string selectId = "SELECT StudentID FROM ClubMembers1";
            sqlCommand = new SqlCommand(selectId, sqlConnect);
            sqlCommand.CommandText = selectId;
            sqlConnect.Open();
            sqlReader = sqlCommand.ExecuteReader();
            while (sqlReader.Read())
            {
                cb.Items.Add(sqlReader["StudentID"].ToString());
            }
            sqlConnect.Close();
        }

    }
}
