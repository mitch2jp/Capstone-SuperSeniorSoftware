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


namespace Lab1
{
    public partial class CoordinatorEventInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_AWS"].ToString()))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT EventName, Date, Time, Building, Room, EventDescription FROM Event;", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                grdEvents.DataSource = dtbl;
                grdEvents.DataBind();
                sqlCon.Close();



            }



        }

        protected void grdEvents_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}