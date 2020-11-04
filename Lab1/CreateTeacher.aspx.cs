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
    public partial class CreateTeacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ddlSchool.SelectedValue.ToString() != "Other")
            {
                ddlSchool.Items.Clear();

            }

            divSchoolInfo.Visible = false;

            //populate the drop down lists 
            ddlSchool.Items.Insert(0, "Choose One");
            

            
            string sqlQuerySchool = "Select SchoolName FROM School";

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_AWS"].ToString());
            SqlCommand sqlCommand2 = new SqlCommand();
            sqlCommand2.Connection = sqlConnect;
            sqlCommand2.CommandType = CommandType.Text;
            sqlCommand2.CommandText = sqlQuerySchool;

            sqlConnect.Open();
            SqlDataReader queryResultsSchool = sqlCommand2.ExecuteReader();


            while (queryResultsSchool.Read())
            {
                string school = queryResultsSchool["SchoolName"].ToString();
                ddlSchool.Items.Add(school);

            }
            ddlSchool.Items.Add("Other");

            queryResultsSchool.Close();

        }

        protected void ddlSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSchool.SelectedValue.ToString() ==  "Other")
            {
                divSchoolInfo.Visible = true;


            }

        }

        protected void btnAddSchool_Click(object sender, EventArgs e)
        {


            //add the newly added school to the drop down
            SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_AWS"].ToString());
            SqlCommand addSchool = new SqlCommand();
            addSchool.Connection = sqlConnect2;
            addSchool.CommandText = "INSERT INTO School VALUES (@SchoolName, @PhoneNumber, @PrincipalName, @PrincipalEmail," +
                "@GuidanceName, @GuidanceEmail, @GuidancePhone, @Address, @City, @State, @Zip)";
            addSchool.Parameters.Add(new SqlParameter("@SchoolName", HttpUtility.HtmlEncode(txtSchoolName.Text)));
            addSchool.Parameters.Add(new SqlParameter("@PhoneNumber", HttpUtility.HtmlEncode(txtSchoolPhone.Text)));
            addSchool.Parameters.Add(new SqlParameter("@PrincipalName", HttpUtility.HtmlEncode(txtPrincipalName.Text)));
            addSchool.Parameters.Add(new SqlParameter("@PrincipalEmail", HttpUtility.HtmlEncode(txtPrincipalEmail.Text)));
            addSchool.Parameters.Add(new SqlParameter("@GuidanceName", HttpUtility.HtmlEncode(txtGuidanceName.Text)));
            addSchool.Parameters.Add(new SqlParameter("@GuidanceEmail", HttpUtility.HtmlEncode(txtGuidanceEmail.Text)));
            addSchool.Parameters.Add(new SqlParameter("@GuidancePhone", HttpUtility.HtmlEncode(txtGuidancePhone.Text)));
            addSchool.Parameters.Add(new SqlParameter("@Address", HttpUtility.HtmlEncode(txtAddress.Text)));
            addSchool.Parameters.Add(new SqlParameter("@City", HttpUtility.HtmlEncode(txtCity.Text)));
            addSchool.Parameters.Add(new SqlParameter("@State", HttpUtility.HtmlEncode(txtState.Text)));
            addSchool.Parameters.Add(new SqlParameter("@Zip", HttpUtility.HtmlEncode(txtZip.Text)));

            sqlConnect2.Open();
            addSchool.ExecuteNonQuery();

            Response.Redirect("CreateTeacher.aspx");


        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            


            string teacher = "Teacher";

            //insert the new teacher record into the AUTH_AWS pass table with the hashed password
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH_AWS"].ToString());
            SqlCommand setPass = new SqlCommand();
            setPass.Connection = sqlConnect;
            setPass.CommandText = "INSERT INTO Pass VALUES (@Username, @Role, @Password)";
            setPass.Parameters.Add(new SqlParameter("@Username", HttpUtility.HtmlEncode(txtUsername.Text)));
            setPass.Parameters.Add(new SqlParameter("@Password", PasswordHash.HashPassword(HttpUtility.HtmlEncode(txtPassword.Text))));
            setPass.Parameters.Add(new SqlParameter("@Role", teacher));

            sqlConnect.Open();
            setPass.ExecuteNonQuery();

            Response.Redirect("TeacherAccountConfirmation.aspx");








        }
    }
}