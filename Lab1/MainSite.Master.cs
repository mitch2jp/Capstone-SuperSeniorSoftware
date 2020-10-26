using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

namespace Lab3
{
    //Jake Mitchell
    //Section 0002
    //10/14/2020
    public partial class MainSite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ////if no verified username is present in the session state variable, return the user to the login and dont allow access to application
            //if (Session["Username"] == null)
            //{
            //    Session["InvalidUsage"] = "Please log in to use the application!";
            //    Response.Redirect("LoginPage.aspx");

            //}
            ////if so, let them in
            //else
            //{
            //    lblCurrentUser.Text = "'" + Session["Username"].ToString() + "'";
            //    lblCurrentUserRole.Text = Session["UserRole"].ToString();
            //}

        }

        //abandond the sesison on logout click and return to the login page 
        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();

            Response.Redirect("LoginPage.aspx?loggedout=true");




        }
    }
}