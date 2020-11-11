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
    public partial class CoordinatorSchoolInfo : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString();
        SqlConnection con;
        SqlDataAdapter adapt;
        DataTable dt;

        string sql = "SELECT * FROM School";


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
                grdSchoolInfo.DataSource = dt;
                grdSchoolInfo.DataBind();

            }
            con.Close();



        }



        protected void grdVolunteerRoster_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dt = ViewState["dtbl"] as DataTable;
            dt.DefaultView.Sort = e.SortExpression;
            grdSchoolInfo.DataSource = dt;
            grdSchoolInfo.DataBind();
        }

        protected void grdVolunteerRoster_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Label id = grdSchoolInfo.Rows[e.RowIndex].FindControl("lblSchoolID") as Label;

            //con = new SqlConnection(cs);
            //con.Open();
            //SqlCommand foreignKeyHandling = new SqlCommand("DELETE FROM EventVolunteer WHERE VolunteerID = @VolunteerID");
            //foreignKeyHandling.Connection = con;
            //foreignKeyHandling.Parameters.Add(new SqlParameter("@VolunteerID", Convert.ToInt32(id.Text)));
            //foreignKeyHandling.ExecuteNonQuery();

            //SqlCommand deleteVolunteer = new SqlCommand("DELETE FROM Volunteer WHERE VolunteerID = @VolunteerID");
            //deleteVolunteer.Connection = con;
            //deleteVolunteer.Parameters.Add(new SqlParameter("@VolunteerID", Convert.ToInt32(id.Text)));

            //adapt = new SqlDataAdapter(sql, con);
            //adapt.DeleteCommand = deleteVolunteer;
            //adapt.DeleteCommand.ExecuteNonQuery();
            //con.Close();

            //grdSchoolInfo.EditIndex = -1;

            //ShowData();

        }

        protected void grdVolunteerRoster_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            Label id = grdSchoolInfo.Rows[e.RowIndex].FindControl("lblSchoolID") as Label;
            TextBox schoolName = grdSchoolInfo.Rows[e.RowIndex].FindControl("txtSchoolName") as TextBox;
            TextBox phoneNumber = grdSchoolInfo.Rows[e.RowIndex].FindControl("txtPhoneNumber") as TextBox;
            TextBox princpalName = grdSchoolInfo.Rows[e.RowIndex].FindControl("txtPrincipalName") as TextBox;
            TextBox principalEmail = grdSchoolInfo.Rows[e.RowIndex].FindControl("txtPrincipalEmail") as TextBox;
            TextBox guidanceName = grdSchoolInfo.Rows[e.RowIndex].FindControl("txtGuidanceName") as TextBox;
            TextBox guidanceEmail = grdSchoolInfo.Rows[e.RowIndex].FindControl("txtGuidanceEmail") as TextBox;
            TextBox guidancePhone = grdSchoolInfo.Rows[e.RowIndex].FindControl("txtGuidancePhone") as TextBox;
            TextBox address = grdSchoolInfo.Rows[e.RowIndex].FindControl("txtAddress") as TextBox;
            TextBox city = grdSchoolInfo.Rows[e.RowIndex].FindControl("txtCity") as TextBox;
            TextBox state = grdSchoolInfo.Rows[e.RowIndex].FindControl("txtState") as TextBox;
            TextBox zip = grdSchoolInfo.Rows[e.RowIndex].FindControl("txtZip") as TextBox;
            con = new SqlConnection(cs);
            con.Open();

            SqlCommand cmd = new SqlCommand("UPDATE School SET SchoolName = @SchoolName, PhoneNumber = @PhoneNumber," +
                " PrincipalName = @PrincipalName, " +
                "PrincipalEmail = @PrincipalEmail, GuidanceName = @GuidanceName, GuidanceEmail = @GuidanceEmail, GuidancePhone = @GuidancePhone, " +
                "Address = @Address, City = @City, State = @State, " +
                "Zip = @Zip WHERE SchoolID = @SchoolID");
            cmd.Connection = con;
            cmd.Parameters.Add(new SqlParameter("@SchoolName", HttpUtility.HtmlEncode(schoolName.Text)));
            cmd.Parameters.Add(new SqlParameter("@PhoneNumber", HttpUtility.HtmlEncode(phoneNumber.Text)));
            cmd.Parameters.Add(new SqlParameter("@PrincipalName", HttpUtility.HtmlEncode(princpalName.Text)));
            cmd.Parameters.Add(new SqlParameter("@PrincipalEmail", HttpUtility.HtmlEncode(principalEmail.Text)));
            cmd.Parameters.Add(new SqlParameter("@GuidanceName", HttpUtility.HtmlEncode(guidanceName.Text)));
            cmd.Parameters.Add(new SqlParameter("@GuidanceEmail", HttpUtility.HtmlEncode(guidanceEmail.Text)));
            cmd.Parameters.Add(new SqlParameter("@GuidancePhone", HttpUtility.HtmlEncode(guidancePhone.Text)));
            cmd.Parameters.Add(new SqlParameter("@Address", HttpUtility.HtmlEncode(address.Text)));
            cmd.Parameters.Add(new SqlParameter("@City", HttpUtility.HtmlEncode(city.Text)));
            cmd.Parameters.Add(new SqlParameter("@State", HttpUtility.HtmlEncode(state.Text)));
            cmd.Parameters.Add(new SqlParameter("@Zip", HttpUtility.HtmlEncode(zip.Text)));
            cmd.Parameters.Add(new SqlParameter("@SchoolID", Convert.ToInt32(id.Text)));
            cmd.ExecuteNonQuery();
            con.Close();

            grdSchoolInfo.EditIndex = -1;

            ShowData();

        }

        protected void grdVolunteerRoster_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdSchoolInfo.EditIndex = e.NewEditIndex;
            ShowData();

        }

        protected void grdVolunteerRoster_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdSchoolInfo.EditIndex = -1;
            ShowData();
        }
    }
}