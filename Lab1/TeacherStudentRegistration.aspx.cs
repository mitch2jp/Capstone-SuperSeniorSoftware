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
using System.Web.DynamicData;

namespace Lab1
{
    public partial class TeacherStudentRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TeacherUsername"] == null && Session["TeacherPassword"] == null)
            {
                Response.Redirect("TeacherLogin.aspx");
            }

            //populate the drop down lists
            //ddlSchool.Items.Insert(0, "Choose One");
            //ddlTeacher.Items.Insert(0, "Choose One");

            //string sqlQueryTeacher = "Select * From Teacher";
            //string sqlQuerySchool = "Select SchoolName FROM School";

            //SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString());
            //SqlCommand sqlCommand1 = new SqlCommand();
            //sqlCommand1.Connection = sqlConnect;
            //sqlCommand1.CommandType = CommandType.Text;
            //sqlCommand1.CommandText = sqlQueryTeacher;

            //SqlCommand sqlCommand2 = new SqlCommand();
            //sqlCommand2.Connection = sqlConnect;
            //sqlCommand2.CommandType = CommandType.Text;
            //sqlCommand2.CommandText = sqlQuerySchool;

            //sqlConnect.Open();
            //SqlDataReader queryResultsTeacher = sqlCommand1.ExecuteReader();
            //SqlDataReader queryResultsSchool = sqlCommand2.ExecuteReader();

            //while (queryResultsTeacher.Read())
            //{
            //    string LastName = queryResultsTeacher["LastName"].ToString();
            //    ddlTeacher.Items.Add(queryResultsTeacher["LastName"].ToString());

            //}

            //while (queryResultsSchool.Read())
            //{
            //    string school = queryResultsSchool["SchoolName"].ToString();
            //    ddlSchool.Items.Add(school);

            //}

            //queryResultsSchool.Close();
            //queryResultsTeacher.Close();

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString());
            sqlConnection.Open();


            //retrieve schoolid based on session variable
            //get the school ID to associate with the newly registered student
            String getSchoolID = "SELECT SchoolID FROM Teacher WHERE FirstName = @FirstName AND LastName = @LastName";
            SqlCommand command2 = new SqlCommand();
            command2.Connection = sqlConnection;
            command2.CommandType = CommandType.Text;
            command2.CommandText = getSchoolID;
            command2.Parameters.AddWithValue("@FirstName", Session["TeacherFirstName"].ToString());
            command2.Parameters.AddWithValue("@LastName", Session["TeacherLastName"].ToString());
            int schoolID = Convert.ToInt32(command2.ExecuteScalar());



            //retrieve teacherid based on session variable
            //get the teacher ID to associate with the newly registered student
            String getTeacherID = "SELECT TeacherID FROM Teacher WHERE FirstName = @FirstName AND LastName = @LastName";
            SqlCommand command3 = new SqlCommand();
            command3.Connection = sqlConnection;
            command3.CommandType = CommandType.Text;
            command3.CommandText = getTeacherID;
            command3.Parameters.AddWithValue("@FirstName", Session["TeacherFirstName"].ToString());
            command3.Parameters.AddWithValue("@LastName", Session["TeacherLastName"].ToString());
            int teacherID = Convert.ToInt32(command3.ExecuteScalar());




            SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString());
            SqlCommand addStudent = new SqlCommand();
            addStudent.Connection = sqlConnect2;
            addStudent.CommandText = "INSERT INTO Student VALUES (@FirstName, @LastName, @Age, @Gender, @Notes, @MealTicket, @TShirtSize," +
                " @TSHirtColor, @TShirtDescription, @PhotoAuthorization, @PriorParticipation, @SchoolID, @TeacherID)";
            addStudent.Parameters.Add(new SqlParameter("@FirstName", HttpUtility.HtmlEncode(txtFirstName.Text)));
            addStudent.Parameters.Add(new SqlParameter("@LastName", HttpUtility.HtmlEncode(txtLastName.Text)));
            addStudent.Parameters.Add(new SqlParameter("@Age", HttpUtility.HtmlEncode(txtAge.Text)));
            addStudent.Parameters.Add(new SqlParameter("@Gender", HttpUtility.HtmlEncode(ddlGender.Text)));
            addStudent.Parameters.Add(new SqlParameter("@Notes", HttpUtility.HtmlEncode(txtNotes.Text)));
            addStudent.Parameters.Add(new SqlParameter("@MealTicket", "Yes"));
            addStudent.Parameters.Add(new SqlParameter("@TShirtSize", ""));
            addStudent.Parameters.Add(new SqlParameter("@TSHirtColor", ""));
            addStudent.Parameters.Add(new SqlParameter("@TShirtDescription", ""));
            addStudent.Parameters.Add(new SqlParameter("@PhotoAuthorization", HttpUtility.HtmlEncode(ddlPhotoAuth.Text)));
            addStudent.Parameters.Add(new SqlParameter("@PriorParticipation", HttpUtility.HtmlEncode(ddlPriorParticipation.Text)));
            addStudent.Parameters.Add(new SqlParameter("@SchoolID", schoolID));
            addStudent.Parameters.Add(new SqlParameter("@TeacherID", teacherID));
            sqlConnect2.Open();
            addStudent.ExecuteNonQuery();


            Response.Redirect("TeacherStudentRegistrationConfirmation.aspx");

        }
    }
}