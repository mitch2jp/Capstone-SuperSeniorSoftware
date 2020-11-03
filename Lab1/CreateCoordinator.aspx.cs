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
    public partial class CreateCoordinator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {

            string coordinator = "Coordinator";

            //insert the new teacher record into the AUTH pass table with the hashed password
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ToString());
            SqlCommand setPass = new SqlCommand();
            setPass.Connection = sqlConnect;
            setPass.CommandText = "INSERT INTO Pass VALUES (@Username, @Role, @Password)";
            setPass.Parameters.Add(new SqlParameter("@Username", HttpUtility.HtmlEncode(txtUsername.Text)));
            setPass.Parameters.Add(new SqlParameter("@Password", PasswordHash.HashPassword(HttpUtility.HtmlEncode(txtPassword.Text))));
            setPass.Parameters.Add(new SqlParameter("@Role", coordinator));

            sqlConnect.Open();
            setPass.ExecuteNonQuery();

            //add the coordinator to the coordiantor table in the Cyberday_Local DB
            SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString());
            SqlCommand addCoordinator = new SqlCommand();
            addCoordinator.Connection = sqlConnect2;
            addCoordinator.CommandText = "INSERT INTO Coordinator VALUES (@FirstName, @LastName, @EmailAddress, @PhoneNumber)";
            addCoordinator.Parameters.Add(new SqlParameter("@FirstName", HttpUtility.HtmlEncode(txtFirstName.Text)));
            addCoordinator.Parameters.Add(new SqlParameter("@LastName", HttpUtility.HtmlEncode(txtLastName.Text)));
            addCoordinator.Parameters.Add(new SqlParameter("@EmailAddress", HttpUtility.HtmlEncode(txtEmail.Text)));
            addCoordinator.Parameters.Add(new SqlParameter("@PhoneNumber", HttpUtility.HtmlEncode(txtPhoneNumber.Text)));


            sqlConnect2.Open();
            addCoordinator.ExecuteNonQuery();



            Response.Redirect("CreateCoordinatorSuccess.aspx");

        }
    }
}