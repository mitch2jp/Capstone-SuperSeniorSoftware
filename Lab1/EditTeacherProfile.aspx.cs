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
using System.Diagnostics;
using System.Web.DynamicData;
using Microsoft.Ajax.Utilities;


namespace Lab1
{
    public partial class EditTeacherProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["TeacherUsername"] == null && Session["TeacherPassword"] == null)
            {
                Response.Redirect("TeacherLogin.aspx");
            }

            //populate the drop down lists 
            ddlSchool.Items.Insert(0, "Choose One");

            string sqlQuerySchool = "Select SchoolName FROM School";

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString());
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

            //ddlSchool.Items.Add("Other");

            queryResultsSchool.Close();


            txtUsername.Text = Session["TeacherUsername"].ToString();
            txtPassword.Text = Session["TeacherPassword"].ToString();
            txtFirstName.Text = Session["TeacherFirstName"].ToString();
            txtLastName.Text = Session["TeacherLastName"].ToString();
            txtEmail.Text = Session["TeacherEmailAddress"].ToString();
            txtPhoneNumber.Text = Session["TeacherPhoneNumber"].ToString();
            ddlGradeTaught.Text = Session["TeacherGradeTaught"].ToString();
            txtSubjectTaught.Text = Session["TeacherSubjectTaught"].ToString();
            if (Session["TeacherMealTicket"].ToString() == "Yes    ")
            {
                rdoMealTicketYes.Checked = true;

            }
            else if (Session["TeacherMealTicket"].ToString() == "No")
            {
                rdoMealTicketNo.Checked = true;
            }
           
            ddlSchool.Text = Session["TeacherSchool"].ToString();


        }

        protected void ddlSchool_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAddSchool_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!rdoMealTicketNo.Checked && !rdoMealTicketYes.Checked)
            {
                valMealTicket.Text = "(Required)";

            }
            else
            {

                //Create the query string, Define the connection to the database, Create the SQL Command Object that will process out query
                string schoolName = ddlSchool.Text;
                String sqlQuerySchoolID = "SELECT SchoolID FROM School WHERE SchoolName = @SchoolName";
                SqlConnection sqlConnectSchoolID = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString());
                SqlCommand sqlCommandSchoolName = new SqlCommand();
                sqlCommandSchoolName.Connection = sqlConnectSchoolID;
                sqlCommandSchoolName.CommandType = CommandType.Text;
                sqlCommandSchoolName.CommandText = sqlQuerySchoolID;
                sqlCommandSchoolName.Parameters.AddWithValue("@SchoolName", schoolName);

                //Open the DB connection and send the query
                sqlConnectSchoolID.Open();
                SqlDataReader queryResultsSchoolID = sqlCommandSchoolName.ExecuteReader();
                queryResultsSchoolID.Read();

                //Retrieve the results
                string schoolID = queryResultsSchoolID["SchoolID"].ToString();
                sqlConnectSchoolID.Close();

                SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString());
                SqlConnection con2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString());
                con.Open();
                con2.Open();

                SqlCommand cmd = new SqlCommand("UPDATE Teacher SET Username = @Username, FirstName = @FirstName, LastName = @LastName," +
                    " EmailAddress = @EmailAddress, " +
                    "PhoneNumber = @PhoneNumber, GradeTaught = @GradeTaught, SubjectTaught = @SubjectTaught, MealTicket = @MealTicket, " +
                    "TShirtSize = @TShirtSize, TSHirtColor = @TShirtColor, TShirtDescription = @TShirtDescription," +
                    " SchoolID = @SchoolID WHERE TeacherID = @TeacherID");
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@TeacherID", Convert.ToInt32(Session["TeacherID"])));
                cmd.Parameters.Add(new SqlParameter("@Username", HttpUtility.HtmlEncode(txtUsername.Text)));
                cmd.Parameters.Add(new SqlParameter("@FirstName", HttpUtility.HtmlEncode(txtFirstName.Text)));
                cmd.Parameters.Add(new SqlParameter("@LastName", HttpUtility.HtmlEncode(txtLastName.Text)));
                cmd.Parameters.Add(new SqlParameter("@EmailAddress", HttpUtility.HtmlEncode(txtEmail.Text)));
                cmd.Parameters.Add(new SqlParameter("@PhoneNumber", HttpUtility.HtmlEncode(txtPhoneNumber.Text)));
                cmd.Parameters.Add(new SqlParameter("@GradeTaught", HttpUtility.HtmlEncode(ddlGradeTaught.Text)));
                cmd.Parameters.Add(new SqlParameter("@SubjectTaught", HttpUtility.HtmlEncode(txtSubjectTaught.Text)));
                if (rdoMealTicketYes.Checked)
                {
                    cmd.Parameters.Add(new SqlParameter("@MealTicket", "Yes"));

                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@MealTicket", "No"));
                }
                cmd.Parameters.Add(new SqlParameter("@TShirtSize", ""));
                cmd.Parameters.Add(new SqlParameter("@TShirtColor", ""));
                cmd.Parameters.Add(new SqlParameter("@TShirtDescription", ""));
                cmd.Parameters.Add(new SqlParameter("@SchoolID", schoolID));


                SqlCommand command = new SqlCommand("UPDATE Pass SET Username = @Username, PasswordHash = @PasswordHash");
                command.Connection = con2;
                command.Parameters.Add(new SqlParameter("@Username", Convert.ToInt32(Session["TeacherID"])));
                command.Parameters.Add(new SqlParameter("@PasswordHash", PasswordHash.HashPassword(HttpUtility.HtmlEncode(txtPassword.Text))));

                command.ExecuteNonQuery();
                con.Close();
                con2.Close();


                Response.Redirect("UpdateTeacherAccountConfirmation.aspx");

            }

            

        }
    }
}