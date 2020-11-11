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
    public partial class VolunteerLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string volunteer = "Volunteer";

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
            loginCommand.Parameters.AddWithValue("@Role", volunteer);
            sqlConnection.Open();
            int count = Convert.ToInt32(loginCommand.ExecuteScalar());

            string breakpoint = "";



            //stored procedure to process the login attempt
            //check to see if the entered info exsits int the AUTH_Local credentials table 
            
            SqlConnection sqlConnection3 = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH_Local"].ToString());
            SqlCommand loginCommand2 = new SqlCommand();
            loginCommand2.Connection = sqlConnection3;
            loginCommand2.CommandType = CommandType.StoredProcedure;
            loginCommand2.CommandText = "LoginAttempt";
            loginCommand2.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            loginCommand2.Parameters.AddWithValue("@Role", volunteer);

            sqlConnection3.Open();
            SqlDataReader reader = loginCommand2.ExecuteReader();




            //if the basic credentials exist in the Lab3 table (for already existing users), allow user to enter the application
            if (count == 1)
            {
                //save the username in the session variable 

                SaveSessionVariables();

                Response.Redirect("VolunteerDashboard.aspx");




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
                        Session["VolunteerUsername"] = HttpUtility.HtmlEncode(txtUsername.Text);
                        Session["UserRole"] = "Volunteer";

                        lblStatus.Text = "Success!";

                        SaveSessionVariablesNewUser();

                        Response.Redirect("VolunteerDashboard.aspx");


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
            String queryFirstName = "SELECT FirstName FROM Volunteer WHERE Username = @Username";
            SqlConnection sqlConnection2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString());
            SqlCommand getFirstName = new SqlCommand();
            getFirstName.Connection = sqlConnection2;
            getFirstName.CommandType = CommandType.Text;
            getFirstName.CommandText = queryFirstName;
            getFirstName.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            sqlConnection2.Open();
            string firstName = getFirstName.ExecuteScalar().ToString();

            String queryVolunteerID = "SELECT VolunteerID FROM Volunteer WHERE Username = @Username";
            SqlCommand getVolunteerID = new SqlCommand();
            getVolunteerID.Connection = sqlConnection2;
            getVolunteerID.CommandType = CommandType.Text;
            getVolunteerID.CommandText = queryVolunteerID;
            getVolunteerID.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            int volunteerID = Convert.ToInt32(getVolunteerID.ExecuteScalar());

            String queryPassword = "SELECT c.Password FROM Volunteer t, Credentials c WHERE t.Username = c.Username AND t.Username = @Username";
            SqlCommand getPassword = new SqlCommand();
            getPassword.Connection = sqlConnection2;
            getPassword.CommandType = CommandType.Text;
            getPassword.CommandText = queryPassword;
            getPassword.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string password = getPassword.ExecuteScalar().ToString();


            String queryLastName = "SELECT LastName FROM Volunteer WHERE Username = @Username";
            SqlCommand getLastName = new SqlCommand();
            getLastName.Connection = sqlConnection2;
            getLastName.CommandType = CommandType.Text;
            getLastName.CommandText = queryLastName;
            getLastName.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string lastName = getLastName.ExecuteScalar().ToString();

            String queryEmailAddress = "SELECT EmailAddress FROM Volunteer WHERE Username = @Username";
            SqlCommand getEmailAddress = new SqlCommand();
            getEmailAddress.Connection = sqlConnection2;
            getEmailAddress.CommandType = CommandType.Text;
            getEmailAddress.CommandText = queryEmailAddress;
            getEmailAddress.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string emailAddress = getEmailAddress.ExecuteScalar().ToString();

            String queryPhoneNumber = "SELECT PhoneNumber FROM Volunteer WHERE Username = @Username";
            SqlCommand getPhoneNumber = new SqlCommand();
            getPhoneNumber.Connection = sqlConnection2;
            getPhoneNumber.CommandType = CommandType.Text;
            getPhoneNumber.CommandText = queryPhoneNumber;
            getPhoneNumber.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string phoneNumber = getPhoneNumber.ExecuteScalar().ToString();

            String queryGender = "SELECT Gender FROM Volunteer WHERE Username = @Username";
            SqlCommand getGender = new SqlCommand();
            getGender.Connection = sqlConnection2;
            getGender.CommandType = CommandType.Text;
            getGender.CommandText = queryGender;
            getGender.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string gender = getGender.ExecuteScalar().ToString();

            

            String queryMealTicket = "SELECT MealTicket FROM Volunteer WHERE Username = @Username";
            SqlCommand getMealTicket = new SqlCommand();
            getMealTicket.Connection = sqlConnection2;
            getMealTicket.CommandType = CommandType.Text;
            getMealTicket.CommandText = queryMealTicket;
            getMealTicket.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string mealTicket = getMealTicket.ExecuteScalar().ToString();

            String queryMajor = "SELECT Major FROM Volunteer WHERE Username = @Username";
            SqlCommand getMajor = new SqlCommand();
            getMajor.Connection = sqlConnection2;
            getMajor.CommandType = CommandType.Text;
            getMajor.CommandText = queryMajor;
            getMajor.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string major = getMajor.ExecuteScalar().ToString();

            String queryPrior = "SELECT PriorParticipation FROM Volunteer WHERE Username = @Username";
            SqlCommand getPrior = new SqlCommand();
            getPrior.Connection = sqlConnection2;
            getPrior.CommandType = CommandType.Text;
            getPrior.CommandText = queryPrior;
            getPrior.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string priorParticipation = getPrior.ExecuteScalar().ToString();

            String queryOrgAfil = "SELECT OrganizationAfilliation FROM Volunteer WHERE Username = @Username";
            SqlCommand getOrgAfil = new SqlCommand();
            getOrgAfil.Connection = sqlConnection2;
            getOrgAfil.CommandType = CommandType.Text;
            getOrgAfil.CommandText = queryOrgAfil;
            getOrgAfil.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string orgAfil = getOrgAfil.ExecuteScalar().ToString();

            String queryType = "SELECT Type FROM Volunteer WHERE Username = @Username";
            SqlCommand getType = new SqlCommand();
            getType.Connection = sqlConnection2;
            getType.CommandType = CommandType.Text;
            getType.CommandText = queryType;
            getType.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string type = getType.ExecuteScalar().ToString();





            //save user session variables in case they want to edit or change profile info
            Session["VolunteerID"] = volunteerID;
            Session["VolunteerUsername"] = HttpUtility.HtmlEncode(txtUsername.Text);
            Session["VolunteerPassword"] = password;
            Session["VolunteerFirstName"] = firstName;
            Session["VolunteerLastName"] = lastName;
            Session["VolunteerEmail"] = emailAddress;
            Session["VolunteerPhoneNumber"] = phoneNumber;
            Session["VolunteerGender"] = gender;
            Session["VolunteerMealTicket"] = mealTicket;
            Session["VolunteerMajor"] = major;
            Session["VolunteerPriorParticipation"] = priorParticipation;
            Session["VolunteerOrganizationAfilliation"] = orgAfil;

            string breakpoint = "";

            sqlConnection2.Close();

        }

        public void SaveSessionVariablesNewUser()
        {
            //get all of the values associated with the entity and save them to session variables
            String queryFirstName = "SELECT FirstName FROM Volunteer WHERE Username = @Username";
            SqlConnection sqlConnection2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString());
            SqlCommand getFirstName = new SqlCommand();
            getFirstName.Connection = sqlConnection2;
            getFirstName.CommandType = CommandType.Text;
            getFirstName.CommandText = queryFirstName;
            getFirstName.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            sqlConnection2.Open();
            string firstName = getFirstName.ExecuteScalar().ToString();

            String queryVolunteerID = "SELECT VolunteerID FROM Volunteer WHERE Username = @Username";
            SqlCommand getVolunteerID = new SqlCommand();
            getVolunteerID.Connection = sqlConnection2;
            getVolunteerID.CommandType = CommandType.Text;
            getVolunteerID.CommandText = queryVolunteerID;
            getVolunteerID.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            int volunteerID = Convert.ToInt32(getVolunteerID.ExecuteScalar());

            //String queryPassword = "SELECT c.Password FROM Volunteer t, Credentials c WHERE t.Username = c.Username AND t.Username = @Username";
            //SqlCommand getPassword = new SqlCommand();
            //getPassword.Connection = sqlConnection2;
            //getPassword.CommandType = CommandType.Text;
            //getPassword.CommandText = queryPassword;
            //getPassword.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            //string password = getPassword.ExecuteScalar().ToString();


            String queryLastName = "SELECT LastName FROM Volunteer WHERE Username = @Username";
            SqlCommand getLastName = new SqlCommand();
            getLastName.Connection = sqlConnection2;
            getLastName.CommandType = CommandType.Text;
            getLastName.CommandText = queryLastName;
            getLastName.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string lastName = getLastName.ExecuteScalar().ToString();

            String queryEmailAddress = "SELECT EmailAddress FROM Volunteer WHERE Username = @Username";
            SqlCommand getEmailAddress = new SqlCommand();
            getEmailAddress.Connection = sqlConnection2;
            getEmailAddress.CommandType = CommandType.Text;
            getEmailAddress.CommandText = queryEmailAddress;
            getEmailAddress.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string emailAddress = getEmailAddress.ExecuteScalar().ToString();

            String queryPhoneNumber = "SELECT PhoneNumber FROM Volunteer WHERE Username = @Username";
            SqlCommand getPhoneNumber = new SqlCommand();
            getPhoneNumber.Connection = sqlConnection2;
            getPhoneNumber.CommandType = CommandType.Text;
            getPhoneNumber.CommandText = queryPhoneNumber;
            getPhoneNumber.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string phoneNumber = getPhoneNumber.ExecuteScalar().ToString();

            String queryGender = "SELECT Gender FROM Volunteer WHERE Username = @Username";
            SqlCommand getGender = new SqlCommand();
            getGender.Connection = sqlConnection2;
            getGender.CommandType = CommandType.Text;
            getGender.CommandText = queryGender;
            getGender.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string gender = getGender.ExecuteScalar().ToString();



            String queryMealTicket = "SELECT MealTicket FROM Volunteer WHERE Username = @Username";
            SqlCommand getMealTicket = new SqlCommand();
            getMealTicket.Connection = sqlConnection2;
            getMealTicket.CommandType = CommandType.Text;
            getMealTicket.CommandText = queryMealTicket;
            getMealTicket.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string mealTicket = getMealTicket.ExecuteScalar().ToString();

            String queryMajor = "SELECT Major FROM Volunteer WHERE Username = @Username";
            SqlCommand getMajor = new SqlCommand();
            getMajor.Connection = sqlConnection2;
            getMajor.CommandType = CommandType.Text;
            getMajor.CommandText = queryMajor;
            getMajor.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string major = getMajor.ExecuteScalar().ToString();

            String queryPrior = "SELECT PriorParticipation FROM Volunteer WHERE Username = @Username";
            SqlCommand getPrior = new SqlCommand();
            getPrior.Connection = sqlConnection2;
            getPrior.CommandType = CommandType.Text;
            getPrior.CommandText = queryPrior;
            getPrior.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string priorParticipation = getPrior.ExecuteScalar().ToString();

            String queryOrgAfil = "SELECT OrganizationAfilliation FROM Volunteer WHERE Username = @Username";
            SqlCommand getOrgAfil = new SqlCommand();
            getOrgAfil.Connection = sqlConnection2;
            getOrgAfil.CommandType = CommandType.Text;
            getOrgAfil.CommandText = queryOrgAfil;
            getOrgAfil.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string orgAfil = getOrgAfil.ExecuteScalar().ToString();

            String queryType = "SELECT Type FROM Volunteer WHERE Username = @Username";
            SqlCommand getType = new SqlCommand();
            getType.Connection = sqlConnection2;
            getType.CommandType = CommandType.Text;
            getType.CommandText = queryType;
            getType.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string type = getType.ExecuteScalar().ToString();


            //save user session variables in case they want to edit or change profile info
            Session["VolunteerID"] = volunteerID;
            Session["VolunteerUsername"] = HttpUtility.HtmlEncode(txtUsername.Text);
            //Session["VolunteerPassword"] = password;
            Session["VolunteerFirstName"] = firstName;
            Session["VolunteerLastName"] = lastName;
            Session["VolunteerEmail"] = emailAddress;
            Session["VolunteerPhoneNumber"] = phoneNumber;
            Session["VolunteerGender"] = gender;
            Session["VolunteerMealTicket"] = mealTicket;
            Session["VolunteerMajor"] = major;
            Session["VolunteerPriorParticipation"] = priorParticipation;
            Session["VolunteerOrganizationAfilliation"] = orgAfil;


        }

    }
}