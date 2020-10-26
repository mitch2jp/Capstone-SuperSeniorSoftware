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
            String queryCredentials = "SELECT COUNT(1) FROM Credentials WHERE Username = @Username AND Password = @Password AND Role = @Role";
            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_AWS"].ToString());
            SqlCommand loginCommand = new SqlCommand();
            loginCommand.Connection = sqlConnection;
            loginCommand.CommandType = CommandType.Text;
            loginCommand.CommandText = queryCredentials;
            loginCommand.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            loginCommand.Parameters.AddWithValue("@Password", HttpUtility.HtmlEncode(txtPassword.Text));
            loginCommand.Parameters.AddWithValue("@Role", coordinator);

            sqlConnection.Open();
            int count = Convert.ToInt32(loginCommand.ExecuteScalar());
            string breakpoint = "";
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
                //Session["UserRole"] = userRole;

                Response.Redirect("CoordinatorDashboard.aspx");
                sqlConnection2.Close();

            }
            else
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Incorrect Username and/or Password! Please try again!";


            }

        }
    }
}