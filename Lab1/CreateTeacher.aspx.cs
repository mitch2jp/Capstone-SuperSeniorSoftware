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
    public partial class CreateTeacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            valSchoolName.Enabled = false;
            valSchoolPhone.Enabled = false;
            valAddress.Enabled = false;
            valCity.Enabled = false;
            valState.Enabled = false;
            valZip.Enabled = false;
            valPrincipalName.Enabled = false;
            valPrincipalEmail.Enabled = false;
            valGuidanceName.Enabled = false;
            valGuidanceEmail.Enabled = false;
            valGuidancePhone.Enabled = false;


            //if (Session["TeacherUsername"] != null && Session["TeacherPassword"] != null && Session["TeacherVerifyPassword"] != null && Session["TeacherFirstName"] != null
            //    && Session["TeacherLastName"] != null && Session["TeacherEmailAddress"] != null && Session["TeacherPhoneNumber"] != null &&
            //    Session["TeacherGradeTaught"] != null && Session["TeacherSubjectTaught"] != null && Session["TeacherMealTicket"] != null)
            //{
            //    txtUsername.Text = Session["TeacherUsername"].ToString();
            //    txtPassword.Text = Session["TeacherPassword"].ToString();
            //    txtVerifyPassword.Text = Session["TeacherVerifyPassword"].ToString();
            //    txtFirstName.Text = Session["TeacherFirstName"].ToString();
            //    txtLastName.Text = Session["TeacherLastName"].ToString();
            //    txtEmail.Text = Session["TeacherEmailAddress"].ToString();
            //    txtPhoneNumber.Text = Session["TeacherPhoneNumber"].ToString();
            //    ddlGradeTaught.SelectedValue = Session["TeacherGradeTaught"].ToString();
            //    txtSubjectTaught.Text = Session["TeacherSubjectTaught"].ToString();


            //}

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

            //ddlSchool.Items.Add("Other");

            queryResultsSchool.Close();

        }

        protected void ddlSchool_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAddSchool_Click(object sender, EventArgs e)
        {

            dropDownListHandler(0);

            Session["TeacherUsername"] = txtUsername.Text;
            Session["TeacherPassword"] = txtPassword.Text;
            Session["TeacherVerifyPassword"] = txtVerifyPassword.Text;
            Session["TeacherFirstName"] = txtFirstName.Text;
            Session["TeacherLastName"] = txtLastName.Text;
            Session["TeacherEmailAddress"] = txtEmail.Text;
            Session["TeacherPhoneNumber"] = txtPhoneNumber.Text;
            Session["TeacherGradeTaught"] = ddlGradeTaught.SelectedValue;
            Session["TeacherSubjectTaught"] = txtSubjectTaught.Text;
            if (rdoMealTicketYes.Checked)
            {
                Session["TeacherMealTicket"] = rdoMealTicketYes.Checked;

            }
            else
            {
                Session["TeacherMealTicket"] = rdoMealTicketNo.Checked;
            }


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

            dropDownListHandler(0);

            //check to see if the entered username already is already taken
            String usernameCheck = "SELECT COUNT(1) FROM Pass WHERE Username = @Username";
            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH_AWS"].ToString());
            SqlCommand loginCommand = new SqlCommand();
            loginCommand.Connection = sqlConnection;
            loginCommand.CommandType = CommandType.Text;
            loginCommand.CommandText = usernameCheck;
            loginCommand.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            sqlConnection.Open();
            int count = Convert.ToInt32(loginCommand.ExecuteScalar());

            //check to see if there is already an account associated with the entered email
            String emailCheck = "SELECT COUNT(1) FROM Teacher WHERE EmailAddress = @EmailAddress";
            SqlConnection sqlConnection3 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_AWS"].ToString());
            SqlCommand emailValidate = new SqlCommand();
            emailValidate.Connection = sqlConnection3;
            emailValidate.CommandType = CommandType.Text;
            emailValidate.CommandText = emailCheck;
            emailValidate.Parameters.AddWithValue("@EmailAddress", HttpUtility.HtmlEncode(txtEmail.Text));
            sqlConnection3.Open();
            int emailCount = Convert.ToInt32(emailValidate.ExecuteScalar());



            //validation checks and submission
            if (count == 1)
            {
                lblUsernameStatus.Text = "Username is already taken!";

            }
            else if (txtPassword.Text != txtVerifyPassword.Text)
            {
                lblPasswordStatus.Text = "Passwords do not match!";

            }
            
            else if (emailCount == 1)
            {
                lblEmailStatus.Text = "There is already an account associated with this email!";

            }
            else if (!rdoMealTicketNo.Checked && !rdoMealTicketYes.Checked)
            {
                lblMealTicketStatus.Text = "(Required)";

            }
            else
            {


                //save user session variables in case they want to edit or change profile info
                Session["TeacherUsername"] = txtUsername.Text;
                Session["TeacherPassword"] = txtPassword.Text;
                Session["TeacherVerifyPassword"] = txtVerifyPassword.Text;
                Session["TeacherFirstName"] = txtFirstName.Text;
                Session["TeacherLastName"] = txtLastName.Text;
                Session["TeacherEmailAddress"] = txtEmail.Text;
                Session["TeacherPhoneNumber"] = txtPhoneNumber.Text;
                Session["TeacherGradeTaught"] = ddlGradeTaught.SelectedValue;
                Session["TeacherSubjectTaught"] = txtSubjectTaught.Text;
                if (rdoMealTicketYes.Checked)
                {
                    Session["TeacherMealTicket"] = rdoMealTicketYes.Checked;

                }
                else
                {
                    Session["TeacherMealTicket"] = rdoMealTicketNo.Checked;
                }

                //Create the query string, Define the connection to the database, Create the SQL Command Object that will process out query
                string schoolName = ddlSchool.Text;
                String sqlQuerySchoolID = "SELECT SchoolID FROM School WHERE SchoolName = @SchoolName";
                SqlConnection sqlConnectSchoolID = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_AWS"].ToString());
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


                //insert the new teacher record into the AUTH_AWS pass table with the hashed password
                string teacher = "Teacher";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH_AWS"].ToString());
                SqlCommand setPass = new SqlCommand();
                setPass.Connection = sqlConnect;
                setPass.CommandText = "INSERT INTO Pass VALUES (@Username, @Role, @Password)";
                setPass.Parameters.Add(new SqlParameter("@Username", HttpUtility.HtmlEncode(txtUsername.Text)));
                setPass.Parameters.Add(new SqlParameter("@Password", PasswordHash.HashPassword(HttpUtility.HtmlEncode(txtPassword.Text))));
                setPass.Parameters.Add(new SqlParameter("@Role", teacher));

                sqlConnect.Open();
                setPass.ExecuteNonQuery();


                //add the newly added teacher to the Teacher table in the CyberDay_AWS Database
                SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_AWS"].ToString());
                SqlCommand addTeacher = new SqlCommand();
                addTeacher.Connection = sqlConnect2;
                addTeacher.CommandText = "INSERT INTO Teacher VALUES (@FirstName, @LastName, @EmailAddress, @PhoneNumber, @GradeTaught," +
                    "@SubjectTaught, @MealTicket, @TShirtSize, @TSHirtColor, @TShirtDescription, @SchoolID)";

                addTeacher.Parameters.Add(new SqlParameter("@FirstName", HttpUtility.HtmlEncode(txtFirstName.Text)));
                addTeacher.Parameters.Add(new SqlParameter("@LastName", HttpUtility.HtmlEncode(txtLastName.Text)));
                addTeacher.Parameters.Add(new SqlParameter("@EmailAddress", HttpUtility.HtmlEncode(txtEmail.Text)));
                addTeacher.Parameters.Add(new SqlParameter("@PhoneNumber", HttpUtility.HtmlEncode(txtPhoneNumber.Text)));
                addTeacher.Parameters.Add(new SqlParameter("@GradeTaught", HttpUtility.HtmlEncode(ddlGradeTaught.Text)));
                addTeacher.Parameters.Add(new SqlParameter("@SubjectTaught", HttpUtility.HtmlEncode(txtSubjectTaught.Text)));
                if (rdoMealTicketYes.Checked)
                {
                    addTeacher.Parameters.Add(new SqlParameter("@MealTicket", "Yes"));
                }
                else
                {
                    addTeacher.Parameters.Add(new SqlParameter("@MealTicket", "No"));
                }
                addTeacher.Parameters.Add(new SqlParameter("@TShirtSize", "NULL"));
                addTeacher.Parameters.Add(new SqlParameter("@TSHirtColor", "NULL"));
                addTeacher.Parameters.Add(new SqlParameter("@TShirtDescription", "NULL"));
                addTeacher.Parameters.Add(new SqlParameter("@SchoolID", schoolID));


                sqlConnect2.Open();
                addTeacher.ExecuteNonQuery();


                Response.Redirect("TeacherAccountConfirmation.aspx");


            }
            

        }

        protected void btnNotListed_Click(object sender, EventArgs e)
        {
            //enable school fields
            divSchoolInfo.Visible = true;
            dropDownListHandler(0);

            valSchoolName.Enabled = true;
            valSchoolPhone.Enabled = true;
            valAddress.Enabled = true;
            valCity.Enabled = true;
            valState.Enabled = true;
            valZip.Enabled = true;
            valPrincipalName.Enabled = true;
            valPrincipalEmail.Enabled = true;
            valGuidanceName.Enabled = true;
            valGuidanceEmail.Enabled = true;
            valGuidancePhone.Enabled = true;

        }

        public void dropDownListHandler(int schoolListIndex)
        {

            //Clear and repopulate the drop down lists to prevent postback ddl duplication
            ddlSchool.Items.Clear();
            ddlSchool.Items.Insert(0, "Choose One");

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

            //ddlSchool.Items.Add("Other");

            queryResultsSchool.Close();



            ddlSchool.SelectedIndex = schoolListIndex;


        }

        protected void btnCancelSchool_Click(object sender, EventArgs e)
        {
            divSchoolInfo.Visible = false;
            dropDownListHandler(0);


        }
    }
}