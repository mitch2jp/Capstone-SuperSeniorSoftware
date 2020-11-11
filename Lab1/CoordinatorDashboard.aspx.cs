using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab1
{
    public partial class CoordinatorDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["CoordinatorUsername"] == null)
            {
                Response.Redirect("CoordinatorLogin.aspx");

            }

            lblUsername.Text = "Username: " + "<b>" + Session["CoordinatorUsername"].ToString() + "</b>";
            lblUser.Text = "User: " + "<b>" + Session["CoordinatorFirstName"].ToString() + " " + Session["CoordinatorLastName"].ToString() + "</b>";


        }

        protected void btnCreatEvent_Click(object sender, EventArgs e)
        {

        }

        protected void btnViewEventInfo_Click(object sender, EventArgs e)
        {

        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {

            Session["CoordinatorID"] = null;
            Session["CoordinatorUsername"] = null;
            Session["CoordinatorFirstName"] = null;
            Session["CoordinatorLastName"] = null;
            Session["CoordinatorEmail"] = null;
            Session["CoordinatorPhoneNumber"] = null;

            Response.Redirect("CoordinatorLogin.aspx");




        }
    }
}