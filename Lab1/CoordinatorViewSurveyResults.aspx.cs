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
    public partial class CoordinatorViewSurveyResults : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString();
        SqlConnection con;
        SqlDataAdapter adapt;
        DataTable dt;
        string sql = "SELECT SurveyID, FirstName, LastName, EmailAddress, CyberDaySatisfaction, ActivitySatisfaction," +
            " VolunteerSatisfaction, HigherEducation, TechnicalPath, Comments FROM StudentSurvey";


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
    }
}