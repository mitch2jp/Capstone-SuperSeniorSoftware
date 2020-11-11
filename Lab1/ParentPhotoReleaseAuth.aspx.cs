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

namespace Lab1
{
    public partial class ParentPhotoReleaseAuth : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {

            if (!rdoAllow.Checked && !rdoDontAllow.Checked)
            {
                lblPhotoAuthStatus.Text = "(Required)";

            }
            else
            {

                if (rdoAllow.Checked)
                {
                    Session["StudentPhotoReleaseAuth"] = "Yes";

                }
                else
                {
                    Session["StudentPhotoReleaseAuth"] = "No";
                }

                SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString());
                SqlCommand addStudent = new SqlCommand();
                addStudent.Connection = sqlConnect2;
                addStudent.CommandText = "INSERT INTO Student VALUES (@FirstName, @LastName, @Age, @Gender, @Notes, @MealTicket, @TShirtSize," +
                    " @TSHirtColor, @TShirtDescription, @PhotoAuthorization, @PriorParticipation, @SchoolID, @TeacherID)";
                addStudent.Parameters.Add(new SqlParameter("@FirstName", Session["StudentFirstName"].ToString()));
                addStudent.Parameters.Add(new SqlParameter("@LastName", Session["StudentLastName"].ToString()));
                addStudent.Parameters.Add(new SqlParameter("@Age", Session["StudentAge"].ToString()));
                addStudent.Parameters.Add(new SqlParameter("@Gender", Session["StudentGender"].ToString()));
                addStudent.Parameters.Add(new SqlParameter("@Notes", Session["StudentNotes"].ToString()));
                addStudent.Parameters.Add(new SqlParameter("@MealTicket", Session["StudentMealTicket"].ToString()));
                addStudent.Parameters.Add(new SqlParameter("@TShirtSize", ""));
                addStudent.Parameters.Add(new SqlParameter("@TSHirtColor", ""));
                addStudent.Parameters.Add(new SqlParameter("@TShirtDescription", ""));
                addStudent.Parameters.Add(new SqlParameter("@PhotoAuthorization", Session["StudentPhotoReleaseAuth"].ToString()));
                addStudent.Parameters.Add(new SqlParameter("@PriorParticipation", Session["StudentPriorParticipation"].ToString()));
                addStudent.Parameters.Add(new SqlParameter("@SchoolID", Convert.ToInt32(Session["StudentSchoolID"])));
                addStudent.Parameters.Add(new SqlParameter("@TeacherID", Convert.ToInt32(Session["StudentTeacherID"])));
                sqlConnect2.Open();
                addStudent.ExecuteNonQuery();

                //get the session parent's ID to associate with the newly registered student
                String getCurrentStudentID = "SELECT StudentID FROM Student WHERE FirstName = @FirstName AND LastName = @LastName";
                SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString());
                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                command.CommandType = CommandType.Text;
                command.CommandText = getCurrentStudentID;
                command.Parameters.AddWithValue("@FirstName", Session["StudentFirstName"].ToString());
                command.Parameters.AddWithValue("@LastName", Session["StudentLastName"].ToString());
                sqlConnection.Open();
                int studentID = Convert.ToInt32(command.ExecuteScalar());

                string breakpoint = "";

                SqlConnection sqlConnect3 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString());
                SqlCommand addParentStudent = new SqlCommand();
                addParentStudent.Connection = sqlConnect3;
                addParentStudent.CommandText = "INSERT INTO ParentStudent VALUES (@ParentID, @StudentID)";
                addParentStudent.Parameters.Add(new SqlParameter("@ParentID", Convert.ToInt32(Session["ParentID"])));
                addParentStudent.Parameters.Add(new SqlParameter("@StudentID", studentID));
                sqlConnect3.Open();
                addParentStudent.ExecuteNonQuery();

                Response.Redirect("ParentStudentRegistrationConfirmation.aspx");

            }


            

        }
    }
}