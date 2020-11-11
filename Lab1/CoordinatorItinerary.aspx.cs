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
    public partial class CoordinatorEventInformation : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString();
        SqlConnection con;
        SqlDataAdapter adapt;
        DataTable dt;
        string sql = "SELECT * FROM Event";


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
                grdItinerary.DataSource = dt;
                grdItinerary.DataBind();

            }
            con.Close();



        }

        protected void grdItinerary_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdItinerary.EditIndex = -1;
            ShowData();

        }

        protected void grdItinerary_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdItinerary.EditIndex = e.NewEditIndex;
            ShowData();

        }

        protected void grdItinerary_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label id = grdItinerary.Rows[e.RowIndex].FindControl("lblEventID") as Label;
            TextBox eventName = grdItinerary.Rows[e.RowIndex].FindControl("txtEventName") as TextBox;
            TextBox date = grdItinerary.Rows[e.RowIndex].FindControl("txtDate") as TextBox;
            TextBox time = grdItinerary.Rows[e.RowIndex].FindControl("txtTime") as TextBox;
            TextBox building = grdItinerary.Rows[e.RowIndex].FindControl("txtBuilding") as TextBox;
            TextBox room = grdItinerary.Rows[e.RowIndex].FindControl("txtRoom") as TextBox;
            TextBox volunteerInstructions = grdItinerary.Rows[e.RowIndex].FindControl("txtVolunteerInstructions") as TextBox;
            TextBox eventDescription = grdItinerary.Rows[e.RowIndex].FindControl("txtEventDescription") as TextBox;
            con = new SqlConnection(cs);
            con.Open();

            SqlCommand cmd = new SqlCommand("UPDATE Event SET EventName = @EventName, Date = @Date, Time = @Time, " +
                "Building = @Building, Room = @Room, VolunteerInstructions = @VolunteerInstructions, " +
                "EventDescription = @EventDescription WHERE EventID = @EventID");
            cmd.Connection = con;
            cmd.Parameters.Add(new SqlParameter("@EventName", HttpUtility.HtmlEncode(eventName.Text)));
            cmd.Parameters.Add(new SqlParameter("@Date", HttpUtility.HtmlEncode(date.Text)));
            cmd.Parameters.Add(new SqlParameter("@Time", HttpUtility.HtmlEncode(time.Text)));
            cmd.Parameters.Add(new SqlParameter("@Building", HttpUtility.HtmlEncode(building.Text)));
            cmd.Parameters.Add(new SqlParameter("@Room", HttpUtility.HtmlEncode(room.Text)));
            cmd.Parameters.Add(new SqlParameter("@VolunteerInstructions", HttpUtility.HtmlEncode(volunteerInstructions.Text)));
            cmd.Parameters.Add(new SqlParameter("@EventDescription", HttpUtility.HtmlEncode(eventDescription.Text)));
            cmd.Parameters.Add(new SqlParameter("@EventID", Convert.ToInt32(id.Text)));
            cmd.ExecuteNonQuery();
            con.Close();

            grdItinerary.EditIndex = -1;

            ShowData();

        }

        protected void grdItinerary_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label id = grdItinerary.Rows[e.RowIndex].FindControl("lblEventID") as Label;

            con = new SqlConnection(cs);
            con.Open();
            SqlCommand foreignKeyHandling = new SqlCommand("DELETE FROM EventStudent WHERE EventID = @EventID");
            foreignKeyHandling.Connection = con;
            foreignKeyHandling.Parameters.Add(new SqlParameter("@EventID", Convert.ToInt32(id.Text)));
            foreignKeyHandling.ExecuteNonQuery();

            SqlCommand foreignKeyHandling2 = new SqlCommand("DELETE FROM EventCoordinator WHERE EventID = @EventID");
            foreignKeyHandling2.Connection = con;
            foreignKeyHandling2.Parameters.Add(new SqlParameter("@EventID", Convert.ToInt32(id.Text)));
            foreignKeyHandling2.ExecuteNonQuery();

            SqlCommand foreignKeyHandling3 = new SqlCommand("DELETE FROM EventVolunteer WHERE EventID = @EventID");
            foreignKeyHandling3.Connection = con;
            foreignKeyHandling3.Parameters.Add(new SqlParameter("@EventID", Convert.ToInt32(id.Text)));
            foreignKeyHandling3.ExecuteNonQuery();


            SqlCommand deleteStudent = new SqlCommand("DELETE FROM Event WHERE EventID = @EventID");
            deleteStudent.Connection = con;
            deleteStudent.Parameters.Add(new SqlParameter("@EventID", Convert.ToInt32(id.Text)));

            adapt = new SqlDataAdapter(sql, con);
            adapt.DeleteCommand = deleteStudent;
            adapt.DeleteCommand.ExecuteNonQuery();
            con.Close();

            ShowData();





        }

        protected void grdItinerary_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dt = ViewState["dtbl"] as DataTable;
            dt.DefaultView.Sort = e.SortExpression;
            grdItinerary.DataSource = dt;
            grdItinerary.DataBind();

        }

        protected void btnModify_Click(object sender, EventArgs e)
        {



        }
    }
}