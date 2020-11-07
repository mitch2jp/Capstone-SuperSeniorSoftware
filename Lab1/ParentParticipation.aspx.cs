using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EASendMail;

using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Drawing;
using System.Web.DynamicData;

namespace Lab1
{
    public partial class ParentParticipation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HideParentInfo();


        }


        public void HideParentInfo()
        {
            divParentInfo.Visible = false;
            lblParentFirstName.Visible = false;
            lblParentLastName.Visible = false;
            txtParentFirstName.Visible = false;
            txtParentLastName.Visible = false;
            lblParentEmail.Visible = false;
            txtParentEmail.Visible = false;
            lblParentPhone.Visible = false;
            txtParentPhone.Visible = false;
            lblParentMealTicket.Visible = false;
            rdoParentMealTicketNo.Visible = false;
            rdoParentMealTicketYes.Visible = false;
           

        }

        public void ShowParentInfo()
        {
            divParentInfo.Visible = true;
            lblParentFirstName.Visible = true;
            lblParentLastName.Visible = true;
            txtParentFirstName.Visible = true;
            txtParentLastName.Visible = true;
            lblParentEmail.Visible = true;
            txtParentEmail.Visible = true;
            lblParentPhone.Visible = true;
            txtParentPhone.Visible = true;
            lblParentMealTicket.Visible = true;
            rdoParentMealTicketNo.Visible = true;
            rdoParentMealTicketYes.Visible = true;
           

        }

        protected void rdoParentParticipateYes_CheckedChanged(object sender, EventArgs e)
        {
            valParentParticipation.Text = "";
            ShowParentInfo();

            if (Session["ParentFirstName"] != null)
            {
                txtParentFirstName.Text = Session["ParentFirstName"].ToString();
            }
            if (Session["ParentLastName"] != null)
            {
                txtParentLastName.Text = Session["ParentLastName"].ToString();
            }
            if (Session["ParentPhoneNumber"] != null)
            {
                txtParentPhone.Text = Session["ParentPhoneNumber"].ToString();
            }
            if (Session["ParentEmail"] != null)
            {
                txtParentEmail.Text = Session["ParentEmail"].ToString();
            }


        }

        protected void rdoParentParticipateNo_CheckedChanged(object sender, EventArgs e)
        {
            valParentParticipation.Text = "";
            HideParentInfo();

        }


        protected void btnCancelRegister_Click(object sender, EventArgs e)
        {
            HideParentInfo();
            Response.Redirect("ParentParticipation.aspx");
            

        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            if (rdoParentParticipateYes.Checked)
            {

                SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_AWS"].ToString());
                SqlCommand addParentVolunteer = new SqlCommand();
                addParentVolunteer.Connection = sqlConnect2;
                addParentVolunteer.CommandText = "INSERT INTO Volunteer VALUES (@FirstName, @LastName, @EmailAddress, @PhoneNumber, @Gender," +
                    "@MealTicket, @Major, @TShirtSize, @TShirtColor, @TShirtDescription, @PriorParticipation, @OrganizationAffiliation, @Type )";
                addParentVolunteer.Parameters.Add(new SqlParameter("@FirstName", HttpUtility.HtmlEncode(txtParentFirstName.Text)));
                addParentVolunteer.Parameters.Add(new SqlParameter("@LastName", HttpUtility.HtmlEncode(txtParentLastName.Text)));
                addParentVolunteer.Parameters.Add(new SqlParameter("@EmailAddress", HttpUtility.HtmlEncode(txtParentEmail.Text)));
                addParentVolunteer.Parameters.Add(new SqlParameter("@PhoneNumber", HttpUtility.HtmlEncode(txtParentPhone.Text)));
                addParentVolunteer.Parameters.Add(new SqlParameter("@Gender", HttpUtility.HtmlEncode(ddlGender.Text)));
                if (rdoParentMealTicketYes.Checked)
                {
                    addParentVolunteer.Parameters.Add(new SqlParameter("@MealTicket", "Yes"));
                }
                else
                {
                    addParentVolunteer.Parameters.Add(new SqlParameter("@MealTicket", "No"));
                }
                addParentVolunteer.Parameters.Add(new SqlParameter("@Major", "NULL"));
                addParentVolunteer.Parameters.Add(new SqlParameter("@TShirtSize", "NULL"));
                addParentVolunteer.Parameters.Add(new SqlParameter("@TShirtColor", "NULL"));
                addParentVolunteer.Parameters.Add(new SqlParameter("@TShirtDescription", "NULL"));
                addParentVolunteer.Parameters.Add(new SqlParameter("@PriorParticipation", "NULL"));
                addParentVolunteer.Parameters.Add(new SqlParameter("@OrganizationAffiliation", HttpUtility.HtmlEncode(txtOrgAffiliation.Text)));
                addParentVolunteer.Parameters.Add(new SqlParameter("@Type", "Parent"));



                sqlConnect2.Open();
                addParentVolunteer.ExecuteNonQuery();

                Response.Redirect("ParentPhotoReleaseAuth.aspx");






            }
            else if (rdoParentParticipateNo.Checked)
            {
                Response.Redirect("ParentPhotoReleaseAuth.aspx");
            }
            else
            {
                valParentParticipation.Text = "(Required)";
            }

            

        }
    }
}