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

namespace Lab1
{
    public partial class TeacherLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            


            

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            string teacher = "Teacher";

            //check to see if the credentials exist in the basic credentials table(for already existing users) 
            //in the Lab3 database
            String queryCredentials = "SELECT COUNT(1) FROM Credentials WHERE Username = @Username AND Password = @Password AND Role = @Role";
            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString());
            SqlCommand loginCommand = new SqlCommand();
            loginCommand.Connection = sqlConnection;
            loginCommand.CommandType = CommandType.Text;
            loginCommand.CommandText = queryCredentials;
            loginCommand.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            loginCommand.Parameters.AddWithValue("@Password", HttpUtility.HtmlEncode(txtPassword.Text));
            loginCommand.Parameters.AddWithValue("@Role", teacher);
            sqlConnection.Open();
            int count = Convert.ToInt32(loginCommand.ExecuteScalar());





            //stored procedure to process the login attempt
            //check to see if the entered info exsits int the AUTH_Local credentials table 
            
            SqlConnection sqlConnection3 = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH_Local"].ToString());
            SqlCommand loginCommand2 = new SqlCommand();
            loginCommand2.Connection = sqlConnection3;
            loginCommand2.CommandType = CommandType.StoredProcedure;
            loginCommand2.CommandText = "LoginAttempt";
            loginCommand2.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            loginCommand2.Parameters.AddWithValue("@Role", teacher);

            sqlConnection3.Open();
            SqlDataReader reader = loginCommand2.ExecuteReader();




            //if the basic credentials exist in the Lab3 table (for already existing users), allow user to enter the application
            if (count == 1)
            {

                SaveSessionVariables();

                Response.Redirect("TeacherDashboard.aspx");

            }

            //if the credentials do not exist in the CyberDay table, check if they exist in the AUTH_Local Pass table
            else if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string storedHash = reader["PasswordHash"].ToString();

                    //validate the hashed password
                    if (PasswordHash.ValidatePassword(HttpUtility.HtmlEncode(txtPassword.Text), storedHash))
                    {
                        Session["TeacherUsername"] = HttpUtility.HtmlEncode(txtUsername.Text);
                        Session["TeacherPassword"] = storedHash;
                        Session["UserRole"] = "Teacher";

                        SaveSessionVariablesNewUser();

                        lblStatus.Text = "Success!";

                        Response.Redirect("TeacherDashboard.aspx");

                    }
                    else
                    {
                        lblStatus.ForeColor = Color.Red;
                        lblStatus.Text = "Password is wrong";
                    }

                }

            }

            //if neither, display error 
            else
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Incorrect Username and/or Password! Please try again!";


            }

            sqlConnection.Close();
            sqlConnection3.Close();

        }

        protected void lnkbtnCreateAccount_Click(object sender, EventArgs e)
        {



        }

        public void SaveSessionVariables()
        {
            //get all of the values associated with the entity and save them to session variables
            String queryFirstName = "SELECT FirstName FROM Teacher WHERE Username = @Username";
            SqlConnection sqlConnection2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString());
            SqlCommand getFirstName = new SqlCommand();
            getFirstName.Connection = sqlConnection2;
            getFirstName.CommandType = CommandType.Text;
            getFirstName.CommandText = queryFirstName;
            getFirstName.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            sqlConnection2.Open();
            string firstName = getFirstName.ExecuteScalar().ToString();

            String queryTeacherID = "SELECT TeacherID FROM Teacher WHERE Username = @Username";
            SqlCommand getTeacherID = new SqlCommand();
            getTeacherID.Connection = sqlConnection2;
            getTeacherID.CommandType = CommandType.Text;
            getTeacherID.CommandText = queryTeacherID;
            getTeacherID.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            int teacherID = Convert.ToInt32(getTeacherID.ExecuteScalar());

            String queryPassword = "SELECT c.Password FROM Teacher t, Credentials c WHERE t.Username = c.Username AND t.Username = @Username";
            SqlCommand getPassword = new SqlCommand();
            getPassword.Connection = sqlConnection2;
            getPassword.CommandType = CommandType.Text;
            getPassword.CommandText = queryPassword;
            getPassword.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string password = getPassword.ExecuteScalar().ToString();


            String queryLastName = "SELECT LastName FROM Teacher WHERE Username = @Username";
            SqlCommand getLastName = new SqlCommand();
            getLastName.Connection = sqlConnection2;
            getLastName.CommandType = CommandType.Text;
            getLastName.CommandText = queryLastName;
            getLastName.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string lastName = getLastName.ExecuteScalar().ToString();

            String queryEmailAddress = "SELECT EmailAddress FROM Teacher WHERE Username = @Username";
            SqlCommand getEmailAddress = new SqlCommand();
            getEmailAddress.Connection = sqlConnection2;
            getEmailAddress.CommandType = CommandType.Text;
            getEmailAddress.CommandText = queryEmailAddress;
            getEmailAddress.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string emailAddress = getEmailAddress.ExecuteScalar().ToString();

            String queryPhoneNumber = "SELECT PhoneNumber FROM Teacher WHERE Username = @Username";
            SqlCommand getPhoneNumber = new SqlCommand();
            getPhoneNumber.Connection = sqlConnection2;
            getPhoneNumber.CommandType = CommandType.Text;
            getPhoneNumber.CommandText = queryPhoneNumber;
            getPhoneNumber.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string phoneNumber = getPhoneNumber.ExecuteScalar().ToString();

            String queryGradeTaught = "SELECT GradeTaught FROM Teacher WHERE Username = @Username";
            SqlCommand getGradeTaught = new SqlCommand();
            getGradeTaught.Connection = sqlConnection2;
            getGradeTaught.CommandType = CommandType.Text;
            getGradeTaught.CommandText = queryGradeTaught;
            getGradeTaught.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string gradeTaught = getGradeTaught.ExecuteScalar().ToString();

            String querySubjectTaught = "SELECT SubjectTaught FROM Teacher WHERE Username = @Username";
            SqlCommand getSubjectTaught = new SqlCommand();
            getSubjectTaught.Connection = sqlConnection2;
            getSubjectTaught.CommandType = CommandType.Text;
            getSubjectTaught.CommandText = querySubjectTaught;
            getSubjectTaught.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string subjectTaught = getSubjectTaught.ExecuteScalar().ToString();

            String queryMealTicket = "SELECT MealTicket FROM Teacher WHERE Username = @Username";
            SqlCommand getMealTicket = new SqlCommand();
            getMealTicket.Connection = sqlConnection2;
            getMealTicket.CommandType = CommandType.Text;
            getMealTicket.CommandText = queryMealTicket;
            getMealTicket.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string mealTicket = getMealTicket.ExecuteScalar().ToString();


            String querySchoolName = "SELECT sc.SchoolName FROM Teacher t, School sc WHERE t.SchoolID = sc.SchoolID AND t.Username = @Username";
            SqlCommand getSchoolName = new SqlCommand();
            getSchoolName.Connection = sqlConnection2;
            getSchoolName.CommandType = CommandType.Text;
            getSchoolName.CommandText = querySchoolName;
            getSchoolName.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string schoolName = getSchoolName.ExecuteScalar().ToString();


            //save user session variables in case they want to edit or change profile info
            Session["TeacherID"] = teacherID;
            Session["TeacherUsername"] = txtUsername.Text;
            Session["TeacherPassword"] = password;
            Session["TeacherVerifyPassword"] = password;
            Session["TeacherFirstName"] = firstName;
            Session["TeacherLastName"] = lastName;
            Session["TeacherEmailAddress"] = emailAddress;
            Session["TeacherPhoneNumber"] = phoneNumber;
            Session["TeacherGradeTaught"] = gradeTaught;
            Session["TeacherSubjectTaught"] = subjectTaught;
            Session["TeacherMealTicket"] = mealTicket;
            Session["TeacherSchool"] = schoolName;

            string breakpoint = "";

            sqlConnection2.Close();

        }

        public void SaveSessionVariablesNewUser()
        {

            //get all of the values associated with the entity and save them to session variables
            String queryFirstName = "SELECT FirstName FROM Teacher WHERE Username = @Username";
            SqlConnection sqlConnection2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString());
            SqlCommand getFirstName = new SqlCommand();
            getFirstName.Connection = sqlConnection2;
            getFirstName.CommandType = CommandType.Text;
            getFirstName.CommandText = queryFirstName;
            getFirstName.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            sqlConnection2.Open();
            string firstName = getFirstName.ExecuteScalar().ToString();

            String queryTeacherID = "SELECT TeacherID FROM Teacher WHERE Username = @Username";
            SqlCommand getTeacherID = new SqlCommand();
            getTeacherID.Connection = sqlConnection2;
            getTeacherID.CommandType = CommandType.Text;
            getTeacherID.CommandText = queryTeacherID;
            getTeacherID.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            int teacherID = Convert.ToInt32(getTeacherID.ExecuteScalar());

            //String queryPassword = "SELECT c.Password FROM Teacher t, Credentials c WHERE t.Username = c.Username AND t.Username = @Username";
            //SqlCommand getPassword = new SqlCommand();
            //getPassword.Connection = sqlConnection2;
            //getPassword.CommandType = CommandType.Text;
            //getPassword.CommandText = queryPassword;
            //getPassword.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            //string password = getPassword.ExecuteScalar().ToString();


            String queryLastName = "SELECT LastName FROM Teacher WHERE Username = @Username";
            SqlCommand getLastName = new SqlCommand();
            getLastName.Connection = sqlConnection2;
            getLastName.CommandType = CommandType.Text;
            getLastName.CommandText = queryLastName;
            getLastName.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string lastName = getLastName.ExecuteScalar().ToString();

            String queryEmailAddress = "SELECT EmailAddress FROM Teacher WHERE Username = @Username";
            SqlCommand getEmailAddress = new SqlCommand();
            getEmailAddress.Connection = sqlConnection2;
            getEmailAddress.CommandType = CommandType.Text;
            getEmailAddress.CommandText = queryEmailAddress;
            getEmailAddress.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string emailAddress = getEmailAddress.ExecuteScalar().ToString();

            String queryPhoneNumber = "SELECT PhoneNumber FROM Teacher WHERE Username = @Username";
            SqlCommand getPhoneNumber = new SqlCommand();
            getPhoneNumber.Connection = sqlConnection2;
            getPhoneNumber.CommandType = CommandType.Text;
            getPhoneNumber.CommandText = queryPhoneNumber;
            getPhoneNumber.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string phoneNumber = getPhoneNumber.ExecuteScalar().ToString();

            String queryGradeTaught = "SELECT GradeTaught FROM Teacher WHERE Username = @Username";
            SqlCommand getGradeTaught = new SqlCommand();
            getGradeTaught.Connection = sqlConnection2;
            getGradeTaught.CommandType = CommandType.Text;
            getGradeTaught.CommandText = queryGradeTaught;
            getGradeTaught.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string gradeTaught = getGradeTaught.ExecuteScalar().ToString();

            String querySubjectTaught = "SELECT SubjectTaught FROM Teacher WHERE Username = @Username";
            SqlCommand getSubjectTaught = new SqlCommand();
            getSubjectTaught.Connection = sqlConnection2;
            getSubjectTaught.CommandType = CommandType.Text;
            getSubjectTaught.CommandText = querySubjectTaught;
            getSubjectTaught.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string subjectTaught = getSubjectTaught.ExecuteScalar().ToString();

            String queryMealTicket = "SELECT MealTicket FROM Teacher WHERE Username = @Username";
            SqlCommand getMealTicket = new SqlCommand();
            getMealTicket.Connection = sqlConnection2;
            getMealTicket.CommandType = CommandType.Text;
            getMealTicket.CommandText = queryMealTicket;
            getMealTicket.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string mealTicket = getMealTicket.ExecuteScalar().ToString();


            String querySchoolName = "SELECT sc.SchoolName FROM Teacher t, School sc WHERE t.SchoolID = sc.SchoolID AND t.Username = @Username";
            SqlCommand getSchoolName = new SqlCommand();
            getSchoolName.Connection = sqlConnection2;
            getSchoolName.CommandType = CommandType.Text;
            getSchoolName.CommandText = querySchoolName;
            getSchoolName.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string schoolName = getSchoolName.ExecuteScalar().ToString();


            //save user session variables in case they want to edit or change profile info
            Session["TeacherID"] = teacherID;
            Session["TeacherUsername"] = txtUsername.Text;
            //Session["TeacherPassword"] = password;
            //Session["TeacherVerifyPassword"] = password;
            Session["TeacherFirstName"] = firstName;
            Session["TeacherLastName"] = lastName;
            Session["TeacherEmailAddress"] = emailAddress;
            Session["TeacherPhoneNumber"] = phoneNumber;
            Session["TeacherGradeTaught"] = gradeTaught;
            Session["TeacherSubjectTaught"] = subjectTaught;
            Session["TeacherMealTicket"] = mealTicket;
            Session["TeacherSchool"] = schoolName;

            string breakpoint = "";

            sqlConnection2.Close();


        }

    }
}