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
    public partial class EditStudentInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //save the session state credentials into local variables for validation processing
            string currentUserRole = Session["UserRole"].ToString();
            string currentUser = Session["Username"].ToString();

            //sql query to be used in determining if a student belongs to a certain teacher
            string sqlQuery = "SELECT COUNT(1) FROM Student s, Teacher t WHERE s.TeacherID = t.TeacherID AND t.Username = @Username AND s.LastName = @LastName";
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.Connection = connection;
            command.Parameters.AddWithValue("@Username", currentUser);
            command.Parameters.AddWithValue("@LastName", HttpUtility.HtmlEncode(txtStudentSearch.Text));
            connection.Open();
            int count = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();


            //sql query to be used in determining if a student belongs to a certain teacher
            string query = "SELECT COUNT(1) FROM Student WHERE LastName = @LastName";
            SqlConnection connect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
            SqlCommand sqlCommand = new SqlCommand(query, connect);
            sqlCommand.Connection = connect;
            sqlCommand.Parameters.AddWithValue("@LastName", HttpUtility.HtmlEncode(txtStudentSearch.Text));
            connect.Open();
            int studentCount = Convert.ToInt32(sqlCommand.ExecuteScalar());
            connect.Close();





            //if the current application user is NOT a Teacher, they will not be allowed to edit student information
            if (currentUserRole != "Teacher")
            {
                GridView1.Visible = false;
                lblError.Text = "Invalid Credential: You must be a Teacher to edit student information!";

            }
            //check to see if the searched student exists at all in the database
            else if (studentCount < 1 && count < 1 )
            {
               
                GridView1.Visible = false;
                lblError.Text = "Error: No student with the Last Name: " + "'" + HttpUtility.HtmlEncode(txtStudentSearch.Text) + "'" + " exists in the Database!";

            }
            //if the student does exist in the DB, validate to see if the searched student belongs to the current teacher/user
            else if (count < 1)
            {
                GridView1.Visible = false;
                lblError.Text = "Error: This student is assigned to a different teacher!";

            }

            //if the user is a teacher AND the searched student belongs to them, let them edit the information
            else
            {
                GridView1.Visible = true;
                lblError.Text = "";

                SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
                SqlCommand cmd = new SqlCommand("Select s.StudentID, s.FirstName, s.LastName, s.Age, s.Notes, s.LunchTicket, s.TShirtSize, s.TSHirtColor, s.TShirtDescription" +
                    " FROM Student s, Teacher t" +
                    " WHERE s.TeacherID = t.TeacherID AND t.Username = @Username AND s.LastName = @LastName", con);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Username", currentUser);
                cmd.Parameters.AddWithValue("@LastName", HttpUtility.HtmlEncode(txtStudentSearch.Text));
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();


            }


        }

        //method to handle sending the user to the edit student information page
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            if (e.CommandName == "EditButton")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                Response.Redirect("~/Update Students.aspx?StudentID=" + row.Cells[0].Text);
            }


        }
    }
}