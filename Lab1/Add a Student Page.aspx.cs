using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Drawing;

namespace Lab3
{
    //Jake Mitchell
    //Section 0002
    //10/14/2020
    public partial class Add_a_Student_Page : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {


            //populate the drop down lists 
            ddlSchoolList.Items.Insert(0, "Choose One");
            ddlTeacherList.Items.Insert(0, "Choose One");

            string sqlQueryTeacher = "Select * From Teacher";
            string sqlQuerySchool = "Select SchoolName FROM School";

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.Connection = sqlConnect;
            sqlCommand1.CommandType = CommandType.Text;
            sqlCommand1.CommandText = sqlQueryTeacher;

            SqlCommand sqlCommand2 = new SqlCommand();
            sqlCommand2.Connection = sqlConnect;
            sqlCommand2.CommandType = CommandType.Text;
            sqlCommand2.CommandText = sqlQuerySchool;

            sqlConnect.Open();
            SqlDataReader queryResultsTeacher = sqlCommand1.ExecuteReader();
            SqlDataReader queryResultsSchool = sqlCommand2.ExecuteReader();
            sqlConnect.Close();

            while (queryResultsTeacher.Read())
            {
                string LastName = queryResultsTeacher["LastName"].ToString();
                ddlTeacherList.Items.Add(queryResultsTeacher["LastName"].ToString());

            }

            while (queryResultsSchool.Read())
            {
                string school = queryResultsSchool["SchoolName"].ToString();
                ddlSchoolList.Items.Add(school);

            }

            queryResultsSchool.Close();
            queryResultsTeacher.Close();




        }

        protected void btnPopulate_Click(object sender, EventArgs e)
        {




            //populate all fields with valid data
            HttpUtility.HtmlEncode(txtFirstName.Text = "Jake");
            HttpUtility.HtmlEncode(txtLastName.Text = "Mitchell");
            HttpUtility.HtmlEncode(txtAge.Text = "20");
            HttpUtility.HtmlEncode(txtNotes.Text = "Has peanut allergy");
            HttpUtility.HtmlEncode(txtTShirtSize.Text = "XL");
            HttpUtility.HtmlEncode(txtTShirtColor.Text = "Blue");
            HttpUtility.HtmlEncode(txtTShirtDescription.Text = "Student Logo");
            HttpUtility.HtmlEncode(txtLunchTicket.Text = "Yes");
            ddlSchoolList.SelectedIndex = 1;
            ddlTeacherList.SelectedIndex = 1;


            lblResponseError.Text = "";
            lblResponseSuccess.Text = "";

            //populate the drop down list with valid data 
            dropDownListHandler(1, 1);


        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

            // clear fields
            ddlSchoolList.SelectedIndex = 0;
            ddlTeacherList.SelectedIndex = 0;
            HttpUtility.HtmlEncode(txtFirstName.Text = string.Empty);
            HttpUtility.HtmlEncode(txtLastName.Text = string.Empty);
            HttpUtility.HtmlEncode(txtAge.Text = string.Empty);
            HttpUtility.HtmlEncode(txtNotes.Text = string.Empty);
            HttpUtility.HtmlEncode(txtTShirtSize.Text = string.Empty);
            HttpUtility.HtmlEncode(txtTShirtColor.Text = string.Empty);
            HttpUtility.HtmlEncode(txtTShirtDescription.Text = string.Empty);
            HttpUtility.HtmlEncode(txtLunchTicket.Text = string.Empty);


            lblResponseError.Text = "";
            lblResponseSuccess.Text = "";

            //reset the drop down lists
            dropDownListHandler(0, 0);

        }

        protected void btnCommit_Click(object sender, EventArgs e)
        {
            
            //Get the total number of students from the DB and save to a variable
            string sqlQueryStudent = "SELECT * FROM Student";
            SqlConnection sqlConnectStudent = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
            SqlCommand sqlCommandStudent = new SqlCommand();
            sqlCommandStudent.Connection = sqlConnectStudent;
            sqlCommandStudent.CommandType = CommandType.Text;
            sqlCommandStudent.CommandText = sqlQueryStudent;

            sqlConnectStudent.Open();
            SqlDataReader queryResultsTotalStudents = sqlCommandStudent.ExecuteReader();
            sqlConnectStudent.Close();


            //While loop reading the Student  data into the DB with the condition that there are more student objects to read
            while (queryResultsTotalStudents.Read())
            {
                //validate to see if the newly added student is already in the DB
                string sqlQueryCheck = "SELECT COUNT(1) FROM Student WHERE FirstName = @FirstName AND LastName = @LastName";
                SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
                SqlCommand sqlCommand = new SqlCommand(sqlQueryCheck, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@FirstName", HttpUtility.HtmlEncode(txtFirstName.Text));
                sqlCommand.Parameters.AddWithValue("@LastName", HttpUtility.HtmlEncode(txtLastName.Text));

                sqlConnection.Open();


                int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                sqlConnection.Close();

                //if so, stop the form from committing and display error message
                if (count == 1)
                {
                    Student.studentExists = true;

                    lblResponseSuccess.Text = "";
                    lblResponseError.Text = "* Student already exists in the DB! Please add a different student!";
                        

                    //keep drop down lists from duplcating, but retain the currently selected values 
                    int currentSelectedSchool = ddlSchoolList.SelectedIndex;
                    int currentSelectedTeacher = ddlTeacherList.SelectedIndex;
                    dropDownListHandler(currentSelectedSchool, currentSelectedTeacher);


                    break;  
                }
                ////if not, add the student to the DB
                else
                {
                    
                    Student.studentExists = false;


                    //Create the query string, Define the connection to the database, Create the SQL Command Object that will process out query
                    string teacherName = ddlTeacherList.Text;
                    String sqlQueryTeacherID = "SELECT TeacherID FROM Teacher WHERE LastName = @LastName";
                    SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
                    SqlCommand sqlCommandTeacherName = new SqlCommand();
                    sqlCommandTeacherName.Connection = sqlConnect;
                    sqlCommandTeacherName.CommandType = CommandType.Text;
                    sqlCommandTeacherName.CommandText = sqlQueryTeacherID;
                    sqlCommandTeacherName.Parameters.AddWithValue("@LastName", teacherName);

                    //Open the DB connection and send the query
                    sqlConnect.Open();
                    SqlDataReader queryResultsTeacherID = sqlCommandTeacherName.ExecuteReader();
                    queryResultsTeacherID.Read();

                    //Retrieve the results
                    string currentTeacherID = queryResultsTeacherID["TeacherID"].ToString();

                    sqlConnect.Close();




                    //Create the query string, Define the connection to the database, Create the SQL Command Object that will process out query
                    string schoolName = ddlSchoolList.Text;
                    String sqlQuerySchoolID = "SELECT SchoolID FROM School WHERE SchoolName = @SchoolName";
                    SqlConnection sqlConnectSchoolID = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
                    SqlCommand sqlCommandSchoolName = new SqlCommand();
                    sqlCommandSchoolName.Connection = sqlConnectSchoolID;
                    sqlCommandSchoolName.CommandType = CommandType.Text;
                    sqlCommandSchoolName.CommandText = sqlQuerySchoolID;
                    sqlCommandSchoolName.Parameters.AddWithValue("@SchoolName", schoolName);

                    //Open the DB connection and send the query
                    sqlConnectSchoolID.Open();
                    SqlDataReader queryResultsSchoolID = sqlCommandSchoolName.ExecuteReader();
                    queryResultsSchoolID.Read();

                    //Retrieve the results
                    string currentSchoolID = queryResultsSchoolID["SchoolID"].ToString();

                    sqlConnectSchoolID.Close();




                    //Create query string, define connection and object, fill DB INSERT statements 
                    SqlConnection connection1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
                    SqlDataAdapter cmd = new SqlDataAdapter();
                    cmd.InsertCommand = new SqlCommand("INSERT INTO Student(FirstName, LastName, Age, Notes, LunchTicket, TShirtSize, TShirtColor, TShirtDescription, SchoolID, TeacherID) VALUES(@FirstName, @LastName, @Age, @Notes, @LunchTicket, @TShirtSize, @TShirtColor, @TShirtDescription, @SchoolID, @TeacherID)");
                    cmd.InsertCommand.Connection = connection1;


                    cmd.InsertCommand.Parameters.AddWithValue("@FirstName", HttpUtility.HtmlEncode(txtFirstName.Text));
                    cmd.InsertCommand.Parameters.AddWithValue("@LastName", HttpUtility.HtmlEncode(txtLastName.Text));
                    cmd.InsertCommand.Parameters.AddWithValue("@Age", HttpUtility.HtmlEncode(txtAge.Text));
                    cmd.InsertCommand.Parameters.AddWithValue("@Notes", HttpUtility.HtmlEncode(txtNotes.Text));
                    cmd.InsertCommand.Parameters.AddWithValue("@LunchTicket", HttpUtility.HtmlEncode(txtLunchTicket.Text));
                    cmd.InsertCommand.Parameters.AddWithValue("@TShirtSize", HttpUtility.HtmlEncode(txtTShirtSize.Text));
                    cmd.InsertCommand.Parameters.AddWithValue("@TShirtColor", HttpUtility.HtmlEncode(txtTShirtColor.Text));
                    cmd.InsertCommand.Parameters.AddWithValue("@TShirtDescription", HttpUtility.HtmlEncode(txtTShirtDescription.Text));
                    cmd.InsertCommand.Parameters.AddWithValue("@SchoolID", currentSchoolID);
                    cmd.InsertCommand.Parameters.AddWithValue("@TeacherID", currentTeacherID);
                    connection1.Open();
                    cmd.InsertCommand.ExecuteNonQuery();
                    connection1.Close();

                    break;

                }

            }

                if (Student.studentExists == false)
                {
                    //Clearing the fields after commit
                    ddlSchoolList.SelectedIndex = 0;
                    ddlTeacherList.SelectedIndex = 0;
                    txtFirstName.Text = string.Empty;
                    txtLastName.Text = string.Empty;
                    txtAge.Text = string.Empty;
                    txtNotes.Text = string.Empty;
                    txtTShirtSize.Text = string.Empty;
                    txtTShirtColor.Text = string.Empty;
                    txtTShirtDescription.Text = string.Empty;
                    txtLunchTicket.Text = string.Empty;


                    lblResponseError.Text = "";
                    lblResponseSuccess.Text = "Student committed to database successfully!";

                    //reset the drop down lists
                    dropDownListHandler(0, 0);


                }
        }

        

        //method to handle erroneous duplication of drop down lists on postback 
        public void dropDownListHandler(int schoolListIndex, int teacherListIndex)
        {
            //Clear and repopulate the drop down lists to prevent postback ddl duplication
            ddlSchoolList.Items.Clear();
            ddlTeacherList.Items.Clear();
            ddlSchoolList.Items.Insert(0, "Choose One");
            ddlTeacherList.Items.Insert(0, "Choose One");

            string sqlQueryTeacher = "Select * From Teacher";
            string sqlQuerySchool = "Select SchoolName FROM School";

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.Connection = sqlConnect;
            sqlCommand1.CommandType = CommandType.Text;
            sqlCommand1.CommandText = sqlQueryTeacher;

            SqlCommand sqlCommand2 = new SqlCommand();
            sqlCommand2.Connection = sqlConnect;
            sqlCommand2.CommandType = CommandType.Text;
            sqlCommand2.CommandText = sqlQuerySchool;

            sqlConnect.Open();
            SqlDataReader queryResultsTeacher = sqlCommand1.ExecuteReader();
            SqlDataReader queryResultsSchool = sqlCommand2.ExecuteReader();

            while (queryResultsTeacher.Read())
            {
                string LastName = queryResultsTeacher["LastName"].ToString();
                ddlTeacherList.Items.Add(queryResultsTeacher["LastName"].ToString());

            }

            while (queryResultsSchool.Read())
            {
                string school = queryResultsSchool["SchoolName"].ToString();
                ddlSchoolList.Items.Add(school);

            }

            queryResultsSchool.Close();
            queryResultsTeacher.Close();
            sqlConnect.Close();

           

            ddlSchoolList.SelectedIndex = schoolListIndex;
            ddlTeacherList.SelectedIndex = teacherListIndex;


        }
        
    }

}