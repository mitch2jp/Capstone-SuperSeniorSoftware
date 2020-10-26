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

namespace Lab3
{
    //Jake Mitchell
    //Section 0002
    //10/14/2020
    public partial class View_Student_Roster : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            //use the sql connection to fill the gridview
            using (SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString()))
            {
                sqlCon.Open();
                //Create a left outer join that will join all of the eventID's associated with each student
                //use the STUFF function to allow the ID's to be listed for each student in the same row, instead of duplicating rows when associated with more than one event
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT DISTINCT s.StudentID, FirstName, LastName, Age, Notes, LunchTicket ,TShirtSize, TShirtColor, TShirtDescription, SchoolID, TeacherID, " +
                    "EventID = STUFF((SELECT DISTINCT ', ' + CAST(EventID AS VARCHAR(MAX))" + 
                    " FROM EventAttendance ea WHERE s.StudentID = ea.StudentID FOR XML PATH('')), 1, 1, '')" +
                    " FROM Student s LEFT OUTER JOIN EventAttendance ea ON s.StudentID = ea.StudentID", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                gvStudentRoster.DataSource = dtbl;
                gvStudentRoster.DataBind();
                sqlCon.Close();



            }



        }
    }
}