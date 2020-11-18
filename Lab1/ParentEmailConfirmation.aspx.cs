using System;
using System.Collections.Generic;
using System.Drawing;
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
    public partial class EmailConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //get the session parent's ID to associate with the newly registered student
            String queryTeacherFirstName = "SELECT FirstName FROM Teacher WHERE LastName = @LastName";
            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString());
            SqlCommand getTeacherFirstName = new SqlCommand();
            getTeacherFirstName.Connection = sqlConnection;
            getTeacherFirstName.CommandType = CommandType.Text;
            getTeacherFirstName.CommandText = queryTeacherFirstName;
            getTeacherFirstName.Parameters.AddWithValue("@LastName", Session["ParentStudentTeacherLastName"].ToString());
            sqlConnection.Open();
            string teacherFirstName = getTeacherFirstName.ExecuteScalar().ToString();





            //lblConfirm.Text = "Thank you, " + Session["ParentFirstName"].ToString() + " " + Session["ParentLastName"].ToString() ;
            lblSucess.Text = "An email has been sent to your student's teacher, " + "<b>" + teacherFirstName + " " + Session["ParentStudentTeacherLastName"].ToString() + "</b>" + "," + "requesting authentication" + "\n" + "\n" +
                "Please wait for your student's teacher to send you your authentication code to continue";


        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(Session["AuthenticationCode"]) == Convert.ToInt32(txtAuthCode.Text))
            //{
            //    Session["Authenticated"] = true;
            //    Response.Redirect("ParentStudentRegistration.aspx");

            //}
            //else
            //{
            //    lblStatus.ForeColor = Color.Red;
            //    lblStatus.Text = "Invalid Authentication Code!";
            //}

        }
    }
}