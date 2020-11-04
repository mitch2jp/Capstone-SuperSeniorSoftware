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


            //check to see if the credentials exist in the basic credentials table(for already existing users) 
            //in the Lab3 database
            String queryCredentials = "SELECT COUNT(1) FROM Credentials WHERE Username = @Username AND Password = @Password";
            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_AWS"].ToString());
            SqlCommand loginCommand = new SqlCommand();
            loginCommand.Connection = sqlConnection;
            loginCommand.CommandType = CommandType.Text;
            loginCommand.CommandText = queryCredentials;
            loginCommand.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            loginCommand.Parameters.AddWithValue("@Password", HttpUtility.HtmlEncode(txtPassword.Text));
            sqlConnection.Open();
            int count = Convert.ToInt32(loginCommand.ExecuteScalar());





            //stored procedure to process the login attempt
            //check to see if the entered info exsits int the AUTH_AWS credentials table 
            string coordinator = "Coordinator";
            SqlConnection sqlConnection3 = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH_AWS"].ToString());
            SqlCommand loginCommand2 = new SqlCommand();
            loginCommand2.Connection = sqlConnection3;
            loginCommand2.CommandType = CommandType.StoredProcedure;
            loginCommand2.CommandText = "LoginAttempt";
            loginCommand2.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            loginCommand2.Parameters.AddWithValue("@Role", coordinator);

            sqlConnection3.Open();
            SqlDataReader reader = loginCommand2.ExecuteReader();




            //if the basic credentials exist in the Lab3 table (for already existing users), allow user to enter the application
            if (count == 1)
            {
                //save the username in the session variable 
                Session["CoordinatorUsername"] = HttpUtility.HtmlEncode(txtUsername.Text);


                //find the current user's role and save it into a session variable to be diplayed in U/I for reference
                String userRoleQuery = "SELECT Role FROM Credentials WHERE Username = @Username AND Password = @Password";
                SqlConnection sqlConnection2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_AWS"].ToString());
                SqlCommand loginCommand3 = new SqlCommand();
                loginCommand3.Connection = sqlConnection2;
                loginCommand3.CommandType = CommandType.Text;
                loginCommand3.CommandText = userRoleQuery;
                loginCommand3.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
                loginCommand3.Parameters.AddWithValue("@Password", HttpUtility.HtmlEncode(txtPassword.Text));
                sqlConnection2.Open();
                SqlDataReader queryResultsUserRole = loginCommand3.ExecuteReader();
                queryResultsUserRole.Read();

                string userRole = queryResultsUserRole["Role"].ToString();

                //save into session variable to be displayed on screen
                Session["UserRole"] = userRole;

                Response.Redirect("CoordinatorDashboard.aspx");
                sqlConnection2.Close();


            }

            //if the credentials do not exist in the CyberDay table, check if they exist in the AUTH_AWS Pass table
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


            //string coordinator = "Coordinator";
            //String queryCredentials = "SELECT COUNT(1) FROM Credentials WHERE Username = @Username AND Password = @Password AND Role = @Role";
            //SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_AWS"].ToString());
            //SqlCommand loginCommand = new SqlCommand();
            //loginCommand.Connection = sqlConnection;
            //loginCommand.CommandType = CommandType.Text;
            //loginCommand.CommandText = queryCredentials;
            //loginCommand.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            //loginCommand.Parameters.AddWithValue("@Password", HttpUtility.HtmlEncode(txtPassword.Text));
            //loginCommand.Parameters.AddWithValue("@Role", coordinator);

            //sqlConnection.Open();
            //int count = Convert.ToInt32(loginCommand.ExecuteScalar());


            //if (count == 1)
            //{
            //    //save the username in the session variable 
            //    Session["CoordinatorUsername"] = HttpUtility.HtmlEncode(txtUsername.Text);


            //    //find the current user's role and save it into a session variable to be diplayed in U/I for reference
            //    String userRoleQuery = "SELECT Role FROM Credentials WHERE Username = @Username AND Password = @Password";
            //    SqlConnection sqlConnection2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_AWS"].ToString());
            //    SqlCommand loginCommand3 = new SqlCommand();
            //    loginCommand3.Connection = sqlConnection2;
            //    loginCommand3.CommandType = CommandType.Text;
            //    loginCommand3.CommandText = userRoleQuery;
            //    loginCommand3.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            //    loginCommand3.Parameters.AddWithValue("@Password", HttpUtility.HtmlEncode(txtPassword.Text));
            //    sqlConnection2.Open();
            //    SqlDataReader queryResultsUserRole = loginCommand3.ExecuteReader();
            //    queryResultsUserRole.Read();

            //    string userRole = queryResultsUserRole["Role"].ToString();

            //    //save into session variable to be displayed on screen
            //    //Session["UserRole"] = userRole;

            //    Response.Redirect("CoordinatorDashboard.aspx");
            //    sqlConnection2.Close();

            //}
            //else
            //{
            //    lblStatus.ForeColor = Color.Red;
            //    lblStatus.Text = "Incorrect Username and/or Password! Please try again!";


            //}

        }
    }
}