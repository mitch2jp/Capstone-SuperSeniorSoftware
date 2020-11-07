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
    public partial class VolunteerRoster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "SELECT FirstName, LastName, EmailAddress, PhoneNumber, Gender, MealTicket, Major, PriorParticipation, OrganizationAfilliation, Type" +
                " FROM Volunteer";

            grdVolunteerRoster.DataSource = this.GetData(sql);
            grdVolunteerRoster.DataBind();



        }

        public DataTable GetData(string sql)
        {
            string db = ConfigurationManager.ConnectionStrings["CyberDay_AWS"].ToString();

            using (SqlConnection con = new SqlConnection(db))
            {
                using (SqlCommand cmd = new SqlCommand(sql))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.Connection = con;
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        ViewState["dtbl"] = dt;
                        return dt;

                    }

                }

            }

        }

        protected void grdVolunteerRoster_Sorting(object sender, GridViewSortEventArgs e)
        {

            DataTable dt = ViewState["dtbl"] as DataTable;
            dt.DefaultView.Sort = e.SortExpression;
            grdVolunteerRoster.DataSource = dt;
            grdVolunteerRoster.DataBind();

        }
    }
}