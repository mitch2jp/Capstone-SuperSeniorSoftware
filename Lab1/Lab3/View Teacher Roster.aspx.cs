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
    public partial class View_Teacher_Roster : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            //use the sql connection to fill the gridview for each teacher in the DB
            using (SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString()))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT FirstName, LastName, GradeTaught, EmailAddress, LunchTicket, TShirtSize, TSHirtColor, TShirtDescription FROM Teacher", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                gvTeacherRoster.DataSource = dtbl;
                gvTeacherRoster.DataBind();
                sqlCon.Close();



            }



        }
    }
}