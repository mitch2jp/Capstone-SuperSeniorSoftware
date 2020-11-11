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
    public partial class StudentRoster : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString();
        SqlConnection con;
        SqlDataAdapter adapt;
        DataTable dt;
        string sql = "SELECT s.StudentID, s.FirstName, s.LastName, s.Age, s.Gender, s.Notes, s.MealTicket, s.PhotoAuthorization, s.PriorParticipation, sc.SchoolName, t.LastName" +
            " FROM Student s, School sc, Teacher t" +
            " WHERE s.SchoolID = sc.SchoolID AND s.TeacherID = t.TeacherID";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CoordinatorUsername"] == null)
            {
                Response.Redirect("CoordinatorLogin.aspx");

            }


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
                grdStudentRoster.DataSource = dt;
                grdStudentRoster.DataBind();

            }
            con.Close();



        }


        protected void grdStudentRoster_Sorting(object sender, GridViewSortEventArgs e)
        {


            DataTable dt = ViewState["dtbl"] as DataTable;
            dt.DefaultView.Sort = e.SortExpression;
            grdStudentRoster.DataSource = dt;
            grdStudentRoster.DataBind();



        }

        protected void grdStudentRoster_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdStudentRoster.EditIndex = -1;
            ShowData();

        }

        protected void grdStudentRoster_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdStudentRoster.EditIndex = e.NewEditIndex;
            ShowData();

        }

        protected void grdStudentRoster_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label id = grdStudentRoster.Rows[e.RowIndex].FindControl("lblStudentID") as Label;
            TextBox firstName = grdStudentRoster.Rows[e.RowIndex].FindControl("txtFirstName") as TextBox;
            TextBox lastName = grdStudentRoster.Rows[e.RowIndex].FindControl("txtLastName") as TextBox;
            TextBox age = grdStudentRoster.Rows[e.RowIndex].FindControl("txtAge") as TextBox;
            TextBox gender = grdStudentRoster.Rows[e.RowIndex].FindControl("txtGender") as TextBox;
            TextBox notes = grdStudentRoster.Rows[e.RowIndex].FindControl("txtNotes") as TextBox;
            TextBox mealTicket = grdStudentRoster.Rows[e.RowIndex].FindControl("txtMealTicket") as TextBox;
            TextBox photoAuthorization = grdStudentRoster.Rows[e.RowIndex].FindControl("txtPhotoAuthorization") as TextBox;
            TextBox priorParticipation = grdStudentRoster.Rows[e.RowIndex].FindControl("txtPriorParticipation") as TextBox;
            Label schoolName = grdStudentRoster.Rows[e.RowIndex].FindControl("txtSchoolName") as Label;
            Label teacherLastName = grdStudentRoster.Rows[e.RowIndex].FindControl("txtTeacherLastName") as Label;
            con = new SqlConnection(cs);
            con.Open();

            SqlCommand cmd = new SqlCommand("UPDATE Student SET FirstName = @FirstName, LastName = @LastName, Age = @Age, " +
                "Gender = @Gender, Notes = @Notes, MealTicket = @MealTicket, PhotoAuthorization = @PhotoAuthorization, " +
                "PriorParticipation = @PriorParticipation WHERE StudentID = @StudentID");
            cmd.Connection = con;
            cmd.Parameters.Add(new SqlParameter("@FirstName", HttpUtility.HtmlEncode(firstName.Text)));
            cmd.Parameters.Add(new SqlParameter("@LastName", HttpUtility.HtmlEncode(lastName.Text)));
            cmd.Parameters.Add(new SqlParameter("@Age", HttpUtility.HtmlEncode(age.Text)));
            cmd.Parameters.Add(new SqlParameter("@Gender", HttpUtility.HtmlEncode(gender.Text)));
            cmd.Parameters.Add(new SqlParameter("@Notes", HttpUtility.HtmlEncode(notes.Text)));
            cmd.Parameters.Add(new SqlParameter("@MealTicket", HttpUtility.HtmlEncode(mealTicket.Text)));
            cmd.Parameters.Add(new SqlParameter("@PhotoAuthorization", HttpUtility.HtmlEncode(photoAuthorization.Text)));
            cmd.Parameters.Add(new SqlParameter("@PriorParticipation", HttpUtility.HtmlEncode(priorParticipation.Text)));
            cmd.Parameters.Add(new SqlParameter("@StudentID", Convert.ToInt32(id.Text)));
            cmd.ExecuteNonQuery();
            con.Close();

            grdStudentRoster.EditIndex = -1;

            ShowData();










        }

        protected void grdStudentRoster_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label id = grdStudentRoster.Rows[e.RowIndex].FindControl("lblStudentID") as Label;

            con = new SqlConnection(cs);
            con.Open();
            SqlCommand foreignKeyHandling = new SqlCommand("DELETE FROM EventStudent WHERE StudentID = @StudentID");
            foreignKeyHandling.Connection = con;
            foreignKeyHandling.Parameters.Add(new SqlParameter("@StudentID", Convert.ToInt32(id.Text)));
            foreignKeyHandling.ExecuteNonQuery();

            SqlCommand foreignKeyHandling2 = new SqlCommand("DELETE FROM ParentStudent WHERE StudentID = @StudentID");
            foreignKeyHandling2.Connection = con;
            foreignKeyHandling2.Parameters.Add(new SqlParameter("@StudentID", Convert.ToInt32(id.Text)));
            foreignKeyHandling2.ExecuteNonQuery();

            SqlCommand deleteStudent = new SqlCommand("DELETE FROM Student WHERE StudentID = @StudentID");
            deleteStudent.Connection = con;
            deleteStudent.Parameters.Add(new SqlParameter("@StudentID", Convert.ToInt32(id.Text)));

            adapt = new SqlDataAdapter(sql, con);
            adapt.DeleteCommand = deleteStudent;
            adapt.DeleteCommand.ExecuteNonQuery();
            con.Close();

            ShowData();


        }
    }
}