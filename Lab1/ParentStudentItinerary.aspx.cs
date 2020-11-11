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

using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Security.Cryptography;
using System.Configuration;


namespace Lab1
{
    public partial class SelectEvents : System.Web.UI.Page
    {

        string cs = ConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString();
        SqlConnection con;
        SqlDataAdapter adapt;
        DataTable dt;
        string sql = "SELECT * FROM Event";

        protected void Page_Load(object sender, EventArgs e)
        {
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
                grdItinerary.DataSource = dt;
                grdItinerary.DataBind();

            }
            con.Close();



        }

        protected void grdEvents_RowCommand(object sender, GridViewCommandEventArgs e)
        {


        }

        protected void grdItinerary_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dt = ViewState["dtbl"] as DataTable;
            dt.DefaultView.Sort = e.SortExpression;
            grdItinerary.DataSource = dt;
            grdItinerary.DataBind();
        }
    }
}