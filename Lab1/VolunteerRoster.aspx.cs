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

namespace Lab1
{
    public partial class VolunteerRoster : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString();
        SqlConnection con;
        SqlDataAdapter adapt;
        DataTable dt;

        string sql = "SELECT VolunteerID, FirstName, LastName, EmailAddress, PhoneNumber, Gender, MealTicket, Major, PriorParticipation, OrganizationAfilliation, Type" +
                " FROM Volunteer";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowData();


            }



        }

        public void ShowData()
        {
            dt = new DataTable();
            con = new SqlConnection(cs);
            con.Open();
            adapt = new SqlDataAdapter(sql, con);
            adapt.Fill(dt);
            ViewState["dtbl"] = dt;
            if (dt.Rows.Count > 0)
            {
                grdVolunteerRoster.DataSource = dt;
                grdVolunteerRoster.DataBind();

            }
            con.Close();



        }


        protected void grdVolunteerRoster_Sorting(object sender, GridViewSortEventArgs e)
        {

            DataTable dt = ViewState["dtbl"] as DataTable;
            dt.DefaultView.Sort = e.SortExpression;
            grdVolunteerRoster.DataSource = dt;
            grdVolunteerRoster.DataBind();

        }

        protected void grdVolunteerRoster_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdVolunteerRoster.EditIndex = -1;
            ShowData();
        }

        protected void grdVolunteerRoster_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdVolunteerRoster.EditIndex = e.NewEditIndex;
            ShowData();
        }

        protected void grdVolunteerRoster_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label id = grdVolunteerRoster.Rows[e.RowIndex].FindControl("lblVolunteerID") as Label;
            TextBox firstName = grdVolunteerRoster.Rows[e.RowIndex].FindControl("txtFirstName") as TextBox;
            TextBox lastName = grdVolunteerRoster.Rows[e.RowIndex].FindControl("txtLastName") as TextBox;
            TextBox emailAddress = grdVolunteerRoster.Rows[e.RowIndex].FindControl("txtEmailAddress") as TextBox;
            TextBox phoneNumber = grdVolunteerRoster.Rows[e.RowIndex].FindControl("txtPhoneNumber") as TextBox;
            TextBox gender = grdVolunteerRoster.Rows[e.RowIndex].FindControl("txtGender") as TextBox;
            TextBox mealTicket = grdVolunteerRoster.Rows[e.RowIndex].FindControl("txtMealTicket") as TextBox;
            TextBox major = grdVolunteerRoster.Rows[e.RowIndex].FindControl("txtMajor") as TextBox;
            TextBox priorParticipation = grdVolunteerRoster.Rows[e.RowIndex].FindControl("txtPriorParticipation") as TextBox;
            TextBox organizationAfilliation = grdVolunteerRoster.Rows[e.RowIndex].FindControl("txtOrganizationAfilliation") as TextBox;
            TextBox type = grdVolunteerRoster.Rows[e.RowIndex].FindControl("txtType") as TextBox;
            con = new SqlConnection(cs);
            con.Open();

            SqlCommand cmd = new SqlCommand("UPDATE Volunteer SET FirstName = @FirstName, LastName = @LastName, EmailAddress = @EmailAddress, " +
                "PhoneNumber = @PhoneNumber, Gender = @Gender, MealTicket = @MealTicket, Major = @Major, " +
                "PriorParticipation = @PriorParticipation, OrganizationAfilliation = @OrganizationAfilliation, " +
                "Type = @Type WHERE VolunteerID = @VolunteerID");
            cmd.Connection = con;
            cmd.Parameters.Add(new SqlParameter("@FirstName", HttpUtility.HtmlEncode(firstName.Text)));
            cmd.Parameters.Add(new SqlParameter("@LastName", HttpUtility.HtmlEncode(lastName.Text)));
            cmd.Parameters.Add(new SqlParameter("@EmailAddress", HttpUtility.HtmlEncode(emailAddress.Text)));
            cmd.Parameters.Add(new SqlParameter("@PhoneNumber", HttpUtility.HtmlEncode(phoneNumber.Text)));
            cmd.Parameters.Add(new SqlParameter("@Gender", HttpUtility.HtmlEncode(gender.Text)));
            cmd.Parameters.Add(new SqlParameter("@MealTicket", HttpUtility.HtmlEncode(mealTicket.Text)));
            cmd.Parameters.Add(new SqlParameter("@Major", HttpUtility.HtmlEncode(major.Text)));
            cmd.Parameters.Add(new SqlParameter("@PriorParticipation", HttpUtility.HtmlEncode(priorParticipation.Text)));
            cmd.Parameters.Add(new SqlParameter("@OrganizationAfilliation", HttpUtility.HtmlEncode(organizationAfilliation.Text)));
            cmd.Parameters.Add(new SqlParameter("@Type", HttpUtility.HtmlEncode(type.Text)));
            cmd.Parameters.Add(new SqlParameter("@VolunteerID", Convert.ToInt32(id.Text)));
            cmd.ExecuteNonQuery();
            con.Close();

            grdVolunteerRoster.EditIndex = -1;

            ShowData();

        }

        protected void grdVolunteerRoster_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label id = grdVolunteerRoster.Rows[e.RowIndex].FindControl("lblVolunteerID") as Label;

            con = new SqlConnection(cs);
            con.Open();
            SqlCommand foreignKeyHandling = new SqlCommand("DELETE FROM EventVolunteer WHERE VolunteerID = @VolunteerID");
            foreignKeyHandling.Connection = con;
            foreignKeyHandling.Parameters.Add(new SqlParameter("@VolunteerID", Convert.ToInt32(id.Text)));
            foreignKeyHandling.ExecuteNonQuery();

            SqlCommand deleteVolunteer = new SqlCommand("DELETE FROM Volunteer WHERE VolunteerID = @VolunteerID");
            deleteVolunteer.Connection = con;
            deleteVolunteer.Parameters.Add(new SqlParameter("@VolunteerID", Convert.ToInt32(id.Text)));

            adapt = new SqlDataAdapter(sql, con);
            adapt.DeleteCommand = deleteVolunteer;
            adapt.DeleteCommand.ExecuteNonQuery();
            con.Close();

            grdVolunteerRoster.EditIndex = -1;

            ShowData();

        }

        protected void grdVolunteerRoster_Sorting1(object sender, GridViewSortEventArgs e)
        {

            DataTable dt = ViewState["dtbl"] as DataTable;
            dt.DefaultView.Sort = e.SortExpression;
            grdVolunteerRoster.DataSource = dt;
            grdVolunteerRoster.DataBind();


        }
    }
}