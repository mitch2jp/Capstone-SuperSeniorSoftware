using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab1
{
    public partial class CreateEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["CoordinatorUsername"] == null)
            {
                Response.Redirect("CoordinatorLogin.aspx");

            }

        }

        protected void calEvent_SelectionChanged(object sender, EventArgs e)
        {
            //lblFirstStatus.Text = calEvent.SelectedDate.ToLongDateString();
            //lblSecondStatus.Text = calEvent.SelectedDate.ToShortDateString();
            //lblThirdStatus.Text = calEvent.SelectedDate.ToString();


        }

        protected void calEvent_SelectionChanged1(object sender, EventArgs e)
        {

        }
    }
}