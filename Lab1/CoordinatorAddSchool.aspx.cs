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
    public partial class CoordinatorAddSchool : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            //check to see if the school already exists in the DB
            String querySchool = "SELECT COUNT(1) FROM School WHERE SchoolName = @SchoolName";
            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_AWS"].ToString());
            SqlCommand getSchool = new SqlCommand();
            getSchool.Connection = sqlConnection;
            getSchool.CommandType = CommandType.Text;
            getSchool.CommandText = querySchool;
            getSchool.Parameters.AddWithValue("@SchoolName", HttpUtility.HtmlEncode(txtSchoolName.Text));
            sqlConnection.Open();
            int count = Convert.ToInt32(getSchool.ExecuteScalar());

            if (count == 1)
            {

                lblValSchoolName.Text = "School has already been added!";

            }
            else
            {


                //add the newly added school to the drop down
                SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_AWS"].ToString());
                SqlCommand addSchool = new SqlCommand();
                addSchool.Connection = sqlConnect2;
                addSchool.CommandText = "INSERT INTO School VALUES (@SchoolName, @PhoneNumber, @PrincipalName, @PrincipalEmail," +
                    "@GuidanceName, @GuidanceEmail, @GuidancePhone, @Address, @City, @State, @Zip)";
                addSchool.Parameters.Add(new SqlParameter("@SchoolName", HttpUtility.HtmlEncode(txtSchoolName.Text)));
                addSchool.Parameters.Add(new SqlParameter("@PhoneNumber", HttpUtility.HtmlEncode(txtPhoneNumber.Text)));
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


                Response.Redirect("CoordinatorAddSchoolConfirmation.aspx");


            }

        }
    }
}