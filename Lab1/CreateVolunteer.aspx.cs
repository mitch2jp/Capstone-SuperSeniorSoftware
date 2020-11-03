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
    public partial class CreateVolunteer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {

            string volunteer = "Volunteer";

            //insert the new teacher record into the AUTH pass table with the hashed password
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ToString());
            SqlCommand setPass = new SqlCommand();
            setPass.Connection = sqlConnect;
            setPass.CommandText = "INSERT INTO Pass VALUES (@Username, @Role, @Password)";
            setPass.Parameters.Add(new SqlParameter("@Username", HttpUtility.HtmlEncode(txtUsername.Text)));
            setPass.Parameters.Add(new SqlParameter("@Password", PasswordHash.HashPassword(HttpUtility.HtmlEncode(txtPassword.Text))));
            setPass.Parameters.Add(new SqlParameter("@Role", volunteer));

            sqlConnect.Open();
            setPass.ExecuteNonQuery();

            Response.Redirect("VolunteerAccountConfirmation.aspx");

        }
    }
}