using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Security.Cryptography;
using System.Configuration;
using System.Drawing;

namespace Lab1
{
    public partial class ParentAuthentication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString());
            sqlConnection.Open();

            //validate to see if the parent has begun the registraiotn process by checking the db for the entered email
            String queryParentEmail = "SELECT COUNT(1) FROM ValidateParent WHERE EmailAddress = @EmailAddress";
            SqlCommand getParentEmail = new SqlCommand();
            getParentEmail.Connection = sqlConnection;
            getParentEmail.CommandType = CommandType.Text;
            getParentEmail.CommandText = queryParentEmail;
            getParentEmail.Parameters.AddWithValue("@EmailAddress", HttpUtility.HtmlEncode(txtParentEmail.Text));
            int count = Convert.ToInt32(getParentEmail.ExecuteScalar());

            if (count < 1)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Invalid Email";

            }
            else
            {
                //pull the correct teacherEventID (Auth code) from the db for matching 
                String queryTeacherEventID = "SELECT TeacherEventID FROM ValidateParent WHERE EmailAddress = @EmailAddress";
                SqlCommand getTeacherEventID = new SqlCommand();
                getTeacherEventID.Connection = sqlConnection;
                getTeacherEventID.CommandType = CommandType.Text;
                getTeacherEventID.CommandText = queryTeacherEventID;
                getTeacherEventID.Parameters.AddWithValue("@EmailAddress", HttpUtility.HtmlEncode(txtParentEmail.Text));
                string teacherEventID = getTeacherEventID.ExecuteScalar().ToString();

                if (txtAuthCode.Text == teacherEventID)
                {
                    Session["Authenticated"] = true;

                    Response.Redirect("ParentStudentRegistration.aspx");



                }
                else
                {
                    lblStatus.Text = "Invalid Authentication Code";
                }




            }





            



        }
    }
}