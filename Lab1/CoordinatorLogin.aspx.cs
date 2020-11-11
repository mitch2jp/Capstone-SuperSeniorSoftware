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

using System.Security.Cryptography;


namespace Lab1
{
    public partial class CoordinatorLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
           
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string coordinator = "Coordinator";

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
            loginCommand.Parameters.AddWithValue("@Role", coordinator);
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
            loginCommand2.Parameters.AddWithValue("@Role", coordinator);

            sqlConnection3.Open();
            SqlDataReader reader = loginCommand2.ExecuteReader();




            //if the basic credentials exist in the Lab3 table (for already existing users/test data), allow user to enter the application
            if (count == 1)
            {
                SaveSessionVariables();

                Response.Redirect("CoordinatorDashboard.aspx");

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
                        Session["CoordinatorUsername"] = HttpUtility.HtmlEncode(txtUsername.Text);
                        Session["UserRole"] = "Coordinator";

                        lblStatus.Text = "Success!";

                        SaveSessionVariablesNewUser();

                        Response.Redirect("CoordinatorDashboard.aspx");


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

        public void SaveSessionVariables()
        {
            //get all of the values associated with the entity and save them to session variables
            String queryFirstName = "SELECT FirstName FROM Coordinator WHERE Username = @Username";
            SqlConnection sqlConnection2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString());
            SqlCommand getFirstName = new SqlCommand();
            getFirstName.Connection = sqlConnection2;
            getFirstName.CommandType = CommandType.Text;
            getFirstName.CommandText = queryFirstName;
            getFirstName.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            sqlConnection2.Open();
            string firstName = getFirstName.ExecuteScalar().ToString();

            String queryCoordinatorID = "SELECT CoordinatorID FROM Coordinator WHERE Username = @Username";
            SqlCommand getCoordinatorID = new SqlCommand();
            getCoordinatorID.Connection = sqlConnection2;
            getCoordinatorID.CommandType = CommandType.Text;
            getCoordinatorID.CommandText = queryCoordinatorID;
            getCoordinatorID.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            int coordinatorID = Convert.ToInt32(getCoordinatorID.ExecuteScalar());

            String queryPassword = "SELECT c.Password FROM Coordinator t, Credentials c WHERE t.Username = c.Username AND t.Username = @Username";
            SqlCommand getPassword = new SqlCommand();
            getPassword.Connection = sqlConnection2;
            getPassword.CommandType = CommandType.Text;
            getPassword.CommandText = queryPassword;
            getPassword.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string password = getPassword.ExecuteScalar().ToString();


            String queryLastName = "SELECT LastName FROM Coordinator WHERE Username = @Username";
            SqlCommand getLastName = new SqlCommand();
            getLastName.Connection = sqlConnection2;
            getLastName.CommandType = CommandType.Text;
            getLastName.CommandText = queryLastName;
            getLastName.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string lastName = getLastName.ExecuteScalar().ToString();

            String queryEmailAddress = "SELECT EmailAddress FROM Coordinator WHERE Username = @Username";
            SqlCommand getEmailAddress = new SqlCommand();
            getEmailAddress.Connection = sqlConnection2;
            getEmailAddress.CommandType = CommandType.Text;
            getEmailAddress.CommandText = queryEmailAddress;
            getEmailAddress.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string emailAddress = getEmailAddress.ExecuteScalar().ToString();

            String queryPhoneNumber = "SELECT PhoneNumber FROM Coordinator WHERE Username = @Username";
            SqlCommand getPhoneNumber = new SqlCommand();
            getPhoneNumber.Connection = sqlConnection2;
            getPhoneNumber.CommandType = CommandType.Text;
            getPhoneNumber.CommandText = queryPhoneNumber;
            getPhoneNumber.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string phoneNumber = getPhoneNumber.ExecuteScalar().ToString();

            




            //save user session variables in case they want to edit or change profile info
            Session["CoordinatorID"] = coordinatorID;
            Session["CoordinatorUsername"] = HttpUtility.HtmlEncode(txtUsername.Text);
            Session["CoordinatorPassword"] = password;
            Session["CoordinatorFirstName"] = firstName;
            Session["CoordinatorLastName"] = lastName;
            Session["CoordinatorEmail"] = emailAddress;
            Session["CoordinatorPhoneNumber"] = phoneNumber;

            string breakpoint = "";

            sqlConnection2.Close();

        }

        public void SaveSessionVariablesNewUser()
        {
            //get all of the values associated with the entity and save them to session variables
            String queryFirstName = "SELECT FirstName FROM Coordinator WHERE Username = @Username";
            SqlConnection sqlConnection2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString());
            SqlCommand getFirstName = new SqlCommand();
            getFirstName.Connection = sqlConnection2;
            getFirstName.CommandType = CommandType.Text;
            getFirstName.CommandText = queryFirstName;
            getFirstName.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            sqlConnection2.Open();
            string firstName = getFirstName.ExecuteScalar().ToString();

            String queryCoordinatorID = "SELECT CoordinatorID FROM Coordinator WHERE Username = @Username";
            SqlCommand getCoordinatorID = new SqlCommand();
            getCoordinatorID.Connection = sqlConnection2;
            getCoordinatorID.CommandType = CommandType.Text;
            getCoordinatorID.CommandText = queryCoordinatorID;
            getCoordinatorID.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            int CoordinatorID = Convert.ToInt32(getCoordinatorID.ExecuteScalar());

            //String queryPassword = "SELECT c.Password FROM Coordinator t, Credentials c WHERE t.Username = c.Username AND t.Username = @Username";
            //SqlCommand getPassword = new SqlCommand();
            //getPassword.Connection = sqlConnection2;
            //getPassword.CommandType = CommandType.Text;
            //getPassword.CommandText = queryPassword;
            //getPassword.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            //string password = getPassword.ExecuteScalar().ToString();


            String queryLastName = "SELECT LastName FROM Coordinator WHERE Username = @Username";
            SqlCommand getLastName = new SqlCommand();
            getLastName.Connection = sqlConnection2;
            getLastName.CommandType = CommandType.Text;
            getLastName.CommandText = queryLastName;
            getLastName.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string lastName = getLastName.ExecuteScalar().ToString();

            String queryEmailAddress = "SELECT EmailAddress FROM Coordinator WHERE Username = @Username";
            SqlCommand getEmailAddress = new SqlCommand();
            getEmailAddress.Connection = sqlConnection2;
            getEmailAddress.CommandType = CommandType.Text;
            getEmailAddress.CommandText = queryEmailAddress;
            getEmailAddress.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string emailAddress = getEmailAddress.ExecuteScalar().ToString();

            String queryPhoneNumber = "SELECT PhoneNumber FROM Coordinator WHERE Username = @Username";
            SqlCommand getPhoneNumber = new SqlCommand();
            getPhoneNumber.Connection = sqlConnection2;
            getPhoneNumber.CommandType = CommandType.Text;
            getPhoneNumber.CommandText = queryPhoneNumber;
            getPhoneNumber.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            string phoneNumber = getPhoneNumber.ExecuteScalar().ToString();

            


            //save user session variables in case they want to edit or change profile info
            Session["CoordinatorID"] = CoordinatorID;
            Session["CoordinatorUsername"] = HttpUtility.HtmlEncode(txtUsername.Text);
            //Session["CoordinatorPassword"] = password;
            Session["CoordinatorFirstName"] = firstName;
            Session["CoordinatorLastName"] = lastName;
            Session["CoordinatorEmail"] = emailAddress;
            Session["CoordinatorPhoneNumber"] = phoneNumber;
            


        }
    }
}