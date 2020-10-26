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
    public partial class Capture_the_Flag_Information_Page : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {


            //use the sql connection to fill the gridview with all of the attending students
            using (SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString()))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT ea.EventName, ea.StudentFirstName, ea.StudentLastName, e.DateTime, e.Location FROM EventAttendance ea, Event e Where ea.EventID = e.EventID AND e.EventID = 3", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                gvLunchInfo.DataSource = dtbl;
                gvLunchInfo.DataBind();
                sqlCon.Close();



            }
            // get a list of all of the associated event's assigned volunteers
            using (SqlConnection sqlCon2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString()))
            {
                sqlCon2.Open();
                SqlDataAdapter sqlDa2 = new SqlDataAdapter("SELECT v.FirstName,v.LastName, v.EmailAddress, v.PhoneNumber, e.EventName, e.DateTime,e.Location FROM Volunteer v, Event e, EventVolunteer ev WHERE v.VolunteerID=ev.VolunteerID AND ev.EventID = e.EventID AND e.EventID = 3", sqlCon2);
                DataTable dtbl2 = new DataTable();
                sqlDa2.Fill(dtbl2);
                gvVolunteerLunchInfo.DataSource = dtbl2;
                gvVolunteerLunchInfo.DataBind();
                sqlCon2.Close();


            }
            // get a list of all of the associated event's assigned coordinators
            using (SqlConnection sqlCon3 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString()))
            {
                sqlCon3.Open();
                SqlDataAdapter sqlDa3 = new SqlDataAdapter("SELECT c.FirstName,c.LastName, c.EmailAddress, c.PhoneNumber, e.EventName, e.DateTime,e.Location FROM Coordinator c, Event e, EventCoordinator ec WHERE c.CoordinatorID=ec.CoordinatorID AND ec.CoordinatorID = e.EventID AND e.EventID = 3", sqlCon3);
                DataTable dtbl3 = new DataTable();
                sqlDa3.Fill(dtbl3);
                gvCoordinatorLunchInfo.DataSource = dtbl3;
                gvCoordinatorLunchInfo.DataBind();
                sqlCon3.Close();


            }


        }
    }
}