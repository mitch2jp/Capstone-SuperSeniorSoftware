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
            if (Session["VolunteerEmail"] != null)
            {
                txtEmail.Text = Session["VolunteerEmail"].ToString();

            }
            

        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            String usernameCheck = "SELECT COUNT(1) FROM Pass WHERE Username = @Username";
            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH_AWS"].ToString());
            SqlCommand loginCommand = new SqlCommand();
            loginCommand.Connection = sqlConnection;
            loginCommand.CommandType = CommandType.Text;
            loginCommand.CommandText = usernameCheck;
            loginCommand.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            sqlConnection.Open();
            int count = Convert.ToInt32(loginCommand.ExecuteScalar());


            if (count == 1)
            {
                lblUsernameStatus.Text = "Username is already taken!";


            }
            else if (txtPassword.Text != txtVerifyPassword.Text)
            {

                lblPasswordStatus.Text = "Passwords do not match!";

            }
            else
            {

                string volunteer = "Volunteer";
                string typeStudent = "Student";

                //insert the new teacher record into the AUTH_AWS pass table with the hashed password
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH_AWS"].ToString());
                SqlCommand setPass = new SqlCommand();
                setPass.Connection = sqlConnect;
                setPass.CommandText = "INSERT INTO Pass VALUES (@Username, @Role, @Password)";
                setPass.Parameters.Add(new SqlParameter("@Username", HttpUtility.HtmlEncode(txtUsername.Text)));
                setPass.Parameters.Add(new SqlParameter("@Password", PasswordHash.HashPassword(HttpUtility.HtmlEncode(txtPassword.Text))));
                setPass.Parameters.Add(new SqlParameter("@Role", volunteer));

                sqlConnect.Open();
                setPass.ExecuteNonQuery();


                //add the volunteer to the volunteer table in the Cyberday_Local DB
                SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_AWS"].ToString());
                SqlCommand addVolunteer = new SqlCommand();
                addVolunteer.Connection = sqlConnect2;
                addVolunteer.CommandText = "INSERT INTO Volunteer VALUES (@FirstName, @LastName, @EmailAddress, @PhoneNumber, @Gender, @MealTicket, @Major, @TShirtSize," +
                    " @TShirtColor, @TShirtDescription, @PriorParticipation, @OrganizationAffiliation, @Type)";
                addVolunteer.Parameters.Add(new SqlParameter("@FirstName", HttpUtility.HtmlEncode(txtFirstName.Text)));
                addVolunteer.Parameters.Add(new SqlParameter("@LastName", HttpUtility.HtmlEncode(txtLastName.Text)));
                addVolunteer.Parameters.Add(new SqlParameter("@EmailAddress", HttpUtility.HtmlEncode(txtEmail.Text)));
                addVolunteer.Parameters.Add(new SqlParameter("@PhoneNumber", HttpUtility.HtmlEncode(txtPhoneNumber.Text)));
                addVolunteer.Parameters.Add(new SqlParameter("@Gender", HttpUtility.HtmlEncode(ddlGender.Text)));

                if (rdoMealTicketYes.Checked)
                {
                    string yes = "Yes";
                    addVolunteer.Parameters.Add(new SqlParameter("@MealTicket", yes));
                }
                else
                {
                    string no = "Yes";
                    addVolunteer.Parameters.Add(new SqlParameter("@MealTicket", no));
                }

                addVolunteer.Parameters.Add(new SqlParameter("@Major", HttpUtility.HtmlEncode(txtMajor.Text)));
                addVolunteer.Parameters.Add(new SqlParameter("@TShirtSize", "NULL"));
                addVolunteer.Parameters.Add(new SqlParameter("@TShirtColor", "NULL"));
                addVolunteer.Parameters.Add(new SqlParameter("@TShirtDescription", "NULL"));

                if (rdoPriorYes.Checked)
                {
                    string yes = "Yes";
                    addVolunteer.Parameters.Add(new SqlParameter("@PriorParticipation", yes));
                }
                else
                {
                    string no = "No";
                    addVolunteer.Parameters.Add(new SqlParameter("@PriorParticipation", no));

                }
                addVolunteer.Parameters.Add(new SqlParameter("@OrganizationAffiliation", HttpUtility.HtmlEncode(txtOrgAfilliation.Text)));
                addVolunteer.Parameters.Add(new SqlParameter("@Type", typeStudent));


                sqlConnect2.Open();
                addVolunteer.ExecuteNonQuery();





                Response.Redirect("VolunteerAccountConfirmation.aspx");

            }

            

        }
    }
}