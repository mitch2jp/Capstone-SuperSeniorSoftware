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
using System.Security.Cryptography;

namespace Lab1
{
    //Jake Mitchell
    //Section 0002
    //10/14/2020
    public partial class Update_Students : System.Web.UI.Page
    {
        int studentID = 0; 
        protected void Page_Load(object sender, EventArgs e)
        {
            //if no username present for the session, send them back to login
            if (Session["Username"] == null)
            {
                Session["InvalidUsage"] = "Please log in to use the application!";
                Response.Redirect("LoginPage.aspx");

            }

            //get the studentid of the student to bb edited
            studentID = Convert.ToInt32(Request.QueryString["StudentID"].ToString());
            if (!IsPostBack)
            {
                BindTextBoxValues();

            }



        }

        private void BindTextBoxValues()
        {
            //bind the values of the columns to the textboxes on the update page
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
            SqlCommand cmd = new SqlCommand("Select * FROM Student WHERE StudentID = @StudentID", con);
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@StudentID", studentID);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            HttpUtility.HtmlEncode(txtStudentID.Text = dt.Rows[0][0].ToString());
            HttpUtility.HtmlEncode(txtFirstName.Text = dt.Rows[0][1].ToString());
            HttpUtility.HtmlEncode(txtLastName.Text = dt.Rows[0][2].ToString());
            HttpUtility.HtmlEncode(txtAge.Text = dt.Rows[0][3].ToString());
            HttpUtility.HtmlEncode(txtNotes.Text = dt.Rows[0][4].ToString());
            HttpUtility.HtmlEncode(txtLunchTicket.Text = dt.Rows[0][5].ToString());
            HttpUtility.HtmlEncode(txtTShirtSize.Text = dt.Rows[0][6].ToString());
            HttpUtility.HtmlEncode(txtTShirtColor.Text = dt.Rows[0][7].ToString());
            HttpUtility.HtmlEncode(txtTShirtDescription.Text = dt.Rows[0][8].ToString());



        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //update the record in the db with any changes the user makes to the values in the textboxes
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
            SqlCommand cmd = new SqlCommand("UPDATE Student SET FirstName = @FirstName, LastName = @LastName, Age = @Age, Notes = @Notes, LunchTicket = @LunchTicket, " +
                "TShirtSize = @TShirtSize, TSHirtColor = @TShirtColor, TShirtDescription = @TShirtDescription WHERE StudentID = @StudentID");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@FirstName", HttpUtility.HtmlEncode(txtFirstName.Text));
            cmd.Parameters.AddWithValue("@LastName", HttpUtility.HtmlEncode(txtLastName.Text));
            cmd.Parameters.AddWithValue("@Age", HttpUtility.HtmlEncode(txtAge.Text));
            cmd.Parameters.AddWithValue("@Notes", HttpUtility.HtmlEncode(txtNotes.Text));
            cmd.Parameters.AddWithValue("@LunchTicket", HttpUtility.HtmlEncode(txtLunchTicket.Text));
            cmd.Parameters.AddWithValue("@TShirtSize", HttpUtility.HtmlEncode(txtTShirtSize.Text));
            cmd.Parameters.AddWithValue("@TSHirtColor", HttpUtility.HtmlEncode(txtTShirtColor.Text));
            cmd.Parameters.AddWithValue("@TShirtDescription", HttpUtility.HtmlEncode(txtTShirtDescription.Text));
            cmd.Parameters.AddWithValue("@StudentID", studentID);
            con.Open();
             int result = cmd.ExecuteNonQuery();

            if (result == 1)
            {
                lblStatus.Text = "Record Updated Successfully";

            }

            con.Close();

        }


        protected void btnBack_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/EditStudentInfo.aspx");


        }
    }
}