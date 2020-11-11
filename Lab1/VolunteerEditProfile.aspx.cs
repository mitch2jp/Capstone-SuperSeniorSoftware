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
    public partial class VolunteerEditProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["VolunteerUsername"] != null)
            {
                txtUsername.Text = Session["VolunteerUsername"].ToString();
            }
            if (Session["VolunteerPassword"] != null)
            {
                txtPassword.Text = Session["VolunteerPassword"].ToString();
                txtVerifyPassword.Text = Session["VolunteerPassword"].ToString();
            }
            if (Session["VolunteerFirstName"] != null)
            {
                txtFirstName.Text = Session["VolunteerFirstName"].ToString();

            }
            if (Session["VolunteerLastName"] != null)
            {
                txtLastName.Text = Session["VolunteerLastName"].ToString();

            }
            if (Session["VolunteerEmail"] != null)
            {
                txtEmail.Text = Session["VolunteerEmail"].ToString();

            }
            if (Session["VolunteerPhoneNumber"] != null)
            {
                txtPhoneNumber.Text = Session["VolunteerPhoneNumber"].ToString();

            }
            if (Session["VolunteerGender"] != null)
            {
                ddlGender.Text = Session["VolunteerGender"].ToString();
            }
            if (Session["VolunteerMealTicket"] != null)
            {
                if (Session["VolunteerMealTicket"].ToString() == "Yes")
                {
                    rdoMealTicketYes.Checked = true;
                }
                else if (Session["VolunteerMealTicket"].ToString() == "No")
                {
                    rdoMealTicketNo.Checked = true;
                }
            }
            if (Session["VolunteerMajor"] != null)
            {
                txtMajor.Text = Session["VolunteerMajor"].ToString();

            }
            if (Session["VolunteerPriorParticipation"] != null)
            {
                if (Session["VolunteerPriorParticipation"].ToString() == "Yes")
                {
                    rdoPriorNo.Checked = true;
                }
                else if (Session["VolunteerPriorParticipation"].ToString() == "No")
                {
                    rdoPriorYes.Checked = true;
                }

            }
            if (Session["VolunteerOrganizationAfilliation"] != null)
            {
                txtOrgAfilliation.Text = Session["VolunteerOrganizationAfilliation"].ToString();
            }


        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            Response.Redirect("VolunteerEditProfileConfirmation.aspx");

            //String usernameCheck = "SELECT COUNT(1) FROM Pass WHERE Username = @Username";
            //SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH_Local"].ToString());
            //SqlCommand loginCommand = new SqlCommand();
            //loginCommand.Connection = sqlConnection;
            //loginCommand.CommandType = CommandType.Text;
            //loginCommand.CommandText = usernameCheck;
            //loginCommand.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtUsername.Text));
            //sqlConnection.Open();
            //int count = Convert.ToInt32(loginCommand.ExecuteScalar());


            //if (count == 1)
            //{
            //    lblUsernameStatus.Text = "Username is already taken!";


            //}
            //else if (txtPassword.Text != txtVerifyPassword.Text)
            //{

            //    lblPasswordStatus.Text = "Passwords do not match!";

            //}
            //else
            //{

            //    Session["VolunteerUsername"] = txtUsername.Text;
            //    Session["VolunteerPassword"] = txtPassword.Text;
            //    Session["VolunteerFirstName"] = txtFirstName.Text;
            //    Session["VolunteerLastName"] = txtLastName.Text;
            //    Session["VolunteerEmail"] = txtEmail.Text;
            //    Session["VolunteerPhoneNumber"] = txtPhoneNumber.Text;
            //    Session["VolunteerGender"] = ddlGender.Text;
            //    if (rdoMealTicketYes.Checked)
            //    {
            //        Session["VolunteerMealTicket"] = rdoMealTicketYes.Checked; ;

            //    }
            //    else
            //    {
            //        Session["VolunteerMealTicket"] = rdoMealTicketNo.Checked;
            //    }

            //    Session["VolunteerMajor"] = txtMajor.Text;

            //    if (rdoPriorNo.Checked)
            //    {
            //        Session["VolunteerPriorParticipation"] = rdoPriorNo.Checked;

            //    }
            //    else
            //    {
            //        Session["VolunteerPriorParticipation"] = rdoPriorYes.Checked;
            //    }

            //    Session["VolunteerOrganizationAfilliation"] = txtOrgAfilliation.Text;




            //    string volunteer = "Volunteer";
            //    string typeStudent = "Student";

            //    //insert the new teacher record into the AUTH_Local pass table with the hashed password
            //    SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH_Local"].ToString());
            //    SqlCommand updatePass = new SqlCommand("UPDATE Pass SET Username = @NewUsername, Password = @Password" +
            //        "WHERE Username = @Username");
            //    updatePass.Connection = sqlConnect;
                

            //    sqlConnect.Open();
            //    setPass.ExecuteNonQuery();


            //    //add the volunteer to the volunteer table in the Cyberday_Local DB
            //    SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString());
            //    SqlCommand addVolunteer = new SqlCommand();
            //    addVolunteer.Connection = sqlConnect2;
                

            //    if (rdoMealTicketYes.Checked)
            //    {
                    
            //    }
            //    else
            //    {
                    
            //    }

                

            //    if (rdoPriorYes.Checked)
            //    {
                    
            //    }
            //    else
            //    {
                    

            //    }
                

            //    sqlConnect2.Open();
            //    addVolunteer.ExecuteNonQuery();

            }
    }
}