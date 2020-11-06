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
            //if (rdoAllow.Checked)
            //{
            //    Session["StudentPhotoReleaseAuth"] = "Yes";

            //}
            //else
            //{
            //    Session["StudentPhotoReleaseAuth"] = "No";
            //}

            //SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_AWS"].ToString());
            //SqlCommand addParent = new SqlCommand();
            //addParent.Connection = sqlConnect2;
            //addParent.CommandText = "INSERT INTO Student VALUES (@FirstName, @LastName, @Age, @Gender, @Notes, @MealTicket, @TShirtSize," +
            //    " @TSHirtColor, @TShirtDescription, @PhotoAuthorization, @SchoolID, @TeacherID, @ParentID)";
            //addParent.Parameters.Add(new SqlParameter("@FirstName", Session["StudentFirstName"].ToString()));
            //addParent.Parameters.Add(new SqlParameter("@LastName", Session["StudentLastName"].ToString()));
            //addParent.Parameters.Add(new SqlParameter("@Age", Session["StudentAge"].ToString()));
            //addParent.Parameters.Add(new SqlParameter("@Gender", Session["StudentGender"].ToString()));
            //addParent.Parameters.Add(new SqlParameter("@Notes", Session["StudentNotes"].ToString()));
            //addParent.Parameters.Add(new SqlParameter("@MealTicket", Session["StudentMealTicket"].ToString()));
            //addParent.Parameters.Add(new SqlParameter("@TShirtSize", "NULL"));
            //addParent.Parameters.Add(new SqlParameter("@TSHirtColor", "NULL"));
            //addParent.Parameters.Add(new SqlParameter("@TShirtDescription", "NULL"));
            //addParent.Parameters.Add(new SqlParameter("@PhotoAuthorization", Session["StudentPhotoReleaseAuth"].ToString()));
            //addParent.Parameters.Add(new SqlParameter("@SchoolID", Convert.ToInt32(Session["StudentSchoolID"])));
            //addParent.Parameters.Add(new SqlParameter("@TeacherID", Convert.ToInt32(Session["StudentTeacherID"])));
            //addParent.Parameters.Add(new SqlParameter("@ParentID", Convert.ToInt32(Session["ParentID"])));


            //sqlConnect2.Open();
            //addParent.ExecuteNonQuery();

        }
    }
}