using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Drawing;

namespace Lab1
{

    //Jake Mitchell
    //Section 0002
    //10/14/2020
    public partial class Add_a_Teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //populate the drop down lists 
            ddlSchoolList.Items.Insert(0, "Choose One");

            string sqlQuerySchool = "Select SchoolName FROM School";

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());

            SqlCommand sqlCommand2 = new SqlCommand();
            sqlCommand2.Connection = sqlConnect;
            sqlCommand2.CommandType = CommandType.Text;
            sqlCommand2.CommandText = sqlQuerySchool;

            sqlConnect.Open();
            SqlDataReader queryResultsSchool = sqlCommand2.ExecuteReader();


            while (queryResultsSchool.Read())
            {
                string school = queryResultsSchool["SchoolName"].ToString();
                ddlSchoolList.Items.Add(school);

            }

            queryResultsSchool.Close();
            sqlConnect.Close();




        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {

            //Get the total number of students from the DB and save to a variable
            string sqlQueryTeachers = "SELECT * FROM TeacherAccount";
            SqlConnection sqlConnectTeacher = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH_AWS"].ToString());
            SqlCommand sqlCommandTeacher = new SqlCommand();
            sqlCommandTeacher.Connection = sqlConnectTeacher;
            sqlCommandTeacher.CommandType = CommandType.Text;
            sqlCommandTeacher.CommandText = sqlQueryTeachers;

            sqlConnectTeacher.Open();
            SqlDataReader queryResultsTotalTeachers = sqlCommandTeacher.ExecuteReader();
            sqlConnectTeacher.Close();


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




            //Check to see if the table has already has any rows in it. If so, start the loop 
            while (queryResultsTotalTeachers.Read())
            {
                //validate to see if the newly added student is already in the DB
                string sqlQueryCheck = "SELECT COUNT(1) FROM Pass WHERE Username = @Username";
                SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH_AWS"].ToString());
                SqlCommand sqlCommand = new SqlCommand(sqlQueryCheck, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));


                sqlConnection.Open();


                int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                sqlConnection.Close();
                if (count == 1)
                {
                    Global.teacherExists = true;

                    lblResponseSuccess.Text = "";
                    lblResponseError.Text = "There is already an account associated with this username!";
                    break;

                }
                else
                {
                    Global.teacherExists = false;

                    //insert new teacher account record into the AUTH_AWS database
                    SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH_AWS"].ToString());
                    SqlCommand createTeacher = new SqlCommand();
                    createTeacher.Connection = sqlConnect;
                    createTeacher.CommandText = "INSERT INTO [TeacherAccount] VALUES (@FirstName, @LastName, @School, @GradeTaught, @Username)";
                    createTeacher.Parameters.Add(new SqlParameter("@FirstName", HttpUtility.HtmlEncode(txtFirstName.Text)));
                    createTeacher.Parameters.Add(new SqlParameter("@LastName", HttpUtility.HtmlEncode(txtLastName.Text)));
                    createTeacher.Parameters.Add(new SqlParameter("@School", HttpUtility.HtmlEncode(ddlSchoolList.SelectedValue.ToString())));
                    createTeacher.Parameters.Add(new SqlParameter("@GradeTaught", HttpUtility.HtmlEncode(txtGradeTaught.Text)));
                    createTeacher.Parameters.Add(new SqlParameter("@Username ", HttpUtility.HtmlEncode(txtUsername.Text)));

                    sqlConnect.Open();
                    createTeacher.ExecuteNonQuery();


                    //insert the new teacher record into the Lab3 teacher table
                    SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
                    SqlCommand newTeacher = new SqlCommand();
                    newTeacher.Connection = sqlConnect2;
                    newTeacher.CommandText = "INSERT INTO Teacher VALUES (@Username, @FirstName, @LastName, @GradeTaught, @EmailAddress, @LunchTicket, @TShirtSize, @TSHirtColor, @TShirtDescription, @SchoolID)";
                    newTeacher.Parameters.Add(new SqlParameter("@Username", HttpUtility.HtmlEncode(txtUsername.Text)));
                    newTeacher.Parameters.Add(new SqlParameter("@FirstName", HttpUtility.HtmlEncode(txtFirstName.Text)));
                    newTeacher.Parameters.Add(new SqlParameter("@LastName", HttpUtility.HtmlEncode(txtLastName.Text)));
                    newTeacher.Parameters.Add(new SqlParameter("@GradeTaught", HttpUtility.HtmlEncode(txtGradeTaught.Text)));
                    newTeacher.Parameters.Add(new SqlParameter("@EmailAddress", HttpUtility.HtmlEncode(txtEmailAddress.Text)));
                    newTeacher.Parameters.Add(new SqlParameter("@LunchTicket", HttpUtility.HtmlEncode(txtLunchTicket.Text)));
                    newTeacher.Parameters.Add(new SqlParameter("@TShirtSize", HttpUtility.HtmlEncode(txtTShirtSize.Text)));
                    newTeacher.Parameters.Add(new SqlParameter("@TSHirtColor", HttpUtility.HtmlEncode(txtTShirtColor.Text)));
                    newTeacher.Parameters.Add(new SqlParameter("@TShirtDescription", HttpUtility.HtmlEncode(txtTShirtDescription.Text)));
                    newTeacher.Parameters.Add(new SqlParameter("@SchoolID", currentSchoolID));
                    sqlConnect2.Open();
                    newTeacher.ExecuteNonQuery();
                    sqlConnect.Close();
                    sqlConnect2.Close();



                    //insert the new teacher record into the AUTH_AWS pass table with the hashed password
                    SqlCommand setPass = new SqlCommand();
                    setPass.Connection = sqlConnect;
                    setPass.CommandText = "INSERT INTO Pass VALUES ((SELECT MAX(UserID) FROM TeacherAccount), @Username, @Password)";
                    setPass.Parameters.Add(new SqlParameter("@Username", HttpUtility.HtmlEncode(txtUsername.Text)));
                    setPass.Parameters.Add(new SqlParameter("@Password", PasswordHash.HashPassword(HttpUtility.HtmlEncode(txtPassword.Text))));


                    setPass.ExecuteNonQuery();



                    break;

                }

            }

            // if the table does not have any rows in it, insert the first record into the table
            if (queryResultsTotalTeachers.HasRows == false)
            {

                Global.teacherExists = false;

                //insert new teacher account record into the AUTH_AWS database
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH_AWS"].ToString());
                SqlCommand createTeacher = new SqlCommand();
                createTeacher.Connection = sqlConnect;
                createTeacher.CommandText = "INSERT INTO [TeacherAccount] VALUES (@FirstName, @LastName, @School, @GradeTaught, @Username)";
                createTeacher.Parameters.Add(new SqlParameter("@FirstName", HttpUtility.HtmlEncode(txtFirstName.Text)));
                createTeacher.Parameters.Add(new SqlParameter("@LastName", HttpUtility.HtmlEncode(txtLastName.Text)));
                createTeacher.Parameters.Add(new SqlParameter("@School", HttpUtility.HtmlEncode(ddlSchoolList.SelectedValue.ToString())));
                createTeacher.Parameters.Add(new SqlParameter("@GradeTaught", HttpUtility.HtmlEncode(txtGradeTaught.Text)));
                createTeacher.Parameters.Add(new SqlParameter("@Username ", HttpUtility.HtmlEncode(txtUsername.Text)));


                sqlConnect.Open();
                createTeacher.ExecuteNonQuery();
                sqlConnect.Close();



                //insert the new teacher record into the Lab3 teacher table
                SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
                SqlCommand newTeacher = new SqlCommand();
                newTeacher.Connection = sqlConnect2;
                newTeacher.CommandText = "INSERT INTO Teacher VALUES (@Username, @FirstName, @LastName, @GradeTaught, @EmailAddress, @LunchTicket, @TShirtSize, @TSHirtColor, @TShirtDescription, @SchoolID)";
                newTeacher.Parameters.Add(new SqlParameter("@Username", HttpUtility.HtmlEncode(txtUsername.Text)));
                newTeacher.Parameters.Add(new SqlParameter("@FirstName", HttpUtility.HtmlEncode(txtFirstName.Text)));
                newTeacher.Parameters.Add(new SqlParameter("@LastName", HttpUtility.HtmlEncode(txtLastName.Text)));
                newTeacher.Parameters.Add(new SqlParameter("@GradeTaught", HttpUtility.HtmlEncode(txtGradeTaught.Text)));
                newTeacher.Parameters.Add(new SqlParameter("@EmailAddress", HttpUtility.HtmlEncode(txtEmailAddress.Text)));
                newTeacher.Parameters.Add(new SqlParameter("@LunchTicket", HttpUtility.HtmlEncode(txtLunchTicket.Text)));
                newTeacher.Parameters.Add(new SqlParameter("@TShirtSize", HttpUtility.HtmlEncode(txtTShirtSize.Text)));
                newTeacher.Parameters.Add(new SqlParameter("@TSHirtColor", HttpUtility.HtmlEncode(txtTShirtColor.Text)));
                newTeacher.Parameters.Add(new SqlParameter("@TShirtDescription", HttpUtility.HtmlEncode(txtTShirtDescription.Text)));
                newTeacher.Parameters.Add(new SqlParameter("@SchoolID", currentSchoolID));
                sqlConnect2.Open();
                newTeacher.ExecuteNonQuery();
                sqlConnect2.Close();



                //insert the new teacher record into the AUTH_AWS pass table with the hashed password
                SqlCommand setPass = new SqlCommand();
                setPass.Connection = sqlConnect;
                setPass.CommandText = "INSERT INTO Pass VALUES ((SELECT MAX(UserID) FROM TeacherAccount), @Username, @Password)";
                setPass.Parameters.Add(new SqlParameter("@Username", HttpUtility.HtmlEncode(txtUsername.Text)));
                setPass.Parameters.Add(new SqlParameter("@Password", PasswordHash.HashPassword(HttpUtility.HtmlEncode(txtPassword.Text))));


                setPass.ExecuteNonQuery();


            }

            //clear and reset the fields and drop downs 
            if (Global.teacherExists == false)
            {
                txtFirstName.Text = string.Empty;
                txtLastName.Text = string.Empty;
                txtUsername.Text = string.Empty;
                txtGradeTaught.Text = string.Empty;

                lblResponseError.Text = "";
                lblResponseSuccess.Text = "Account created successfully!";


                dropDownListHandler(0);


            }




        }

        protected void btnPopulate_Click(object sender, EventArgs e)
        {
            HttpUtility.HtmlEncode(txtFirstName.Text = "Shawn");
            HttpUtility.HtmlEncode(txtLastName.Text = "Lough");
            HttpUtility.HtmlEncode(txtUsername.Text = "loughsr");

            dropDownListHandler(1);

            HttpUtility.HtmlEncode(txtGradeTaught.Text = "8");
            HttpUtility.HtmlEncode(txtEmailAddress.Text = "loughsr@jmu.edu");
            HttpUtility.HtmlEncode(txtLunchTicket.Text = "Yes");
            HttpUtility.HtmlEncode(txtTShirtSize.Text = "L");
            HttpUtility.HtmlEncode(txtTShirtColor.Text = "Blue");
            HttpUtility.HtmlEncode(txtTShirtDescription.Text = "Teacher Logo");



        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtGradeTaught.Text = string.Empty;

            dropDownListHandler(0);


        }

        public void dropDownListHandler(int schoolListIndex)
        {
            //Clear and repopulate the drop down lists to prevent postback ddl duplication
            ddlSchoolList.Items.Clear();
            //populate the drop down lists 
            ddlSchoolList.Items.Insert(0, "Choose One");

            string sqlQuerySchool = "Select SchoolName FROM School";

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());

            SqlCommand sqlCommand2 = new SqlCommand();
            sqlCommand2.Connection = sqlConnect;
            sqlCommand2.CommandType = CommandType.Text;
            sqlCommand2.CommandText = sqlQuerySchool;

            sqlConnect.Open();
            SqlDataReader queryResultsSchool = sqlCommand2.ExecuteReader();


            while (queryResultsSchool.Read())
            {
                string school = queryResultsSchool["SchoolName"].ToString();
                ddlSchoolList.Items.Add(school);

            }

            queryResultsSchool.Close();
            sqlConnect.Close();



            ddlSchoolList.SelectedIndex = schoolListIndex;


        }
    }
}