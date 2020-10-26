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


        }

        protected void btnCreatEvent_Click(object sender, EventArgs e)
        {

        }

        protected void btnViewEventInfo_Click(object sender, EventArgs e)
        {

        }
    }
}