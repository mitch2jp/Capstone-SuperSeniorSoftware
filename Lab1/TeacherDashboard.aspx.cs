using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab1
{
    public partial class TeacherDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TeacherUsername"] == null && Session["TeacherPassword"] == null)
            {
                Response.Redirect("TeacherLogin.aspx");
            }


            lblUsername.Text = "Username: " + "<b>" + Session["TeacherUsername"].ToString() + "</b>";
            lblUser.Text = "User: " + "<b>" + Session["TeacherFirstName"].ToString() + " " + Session["TeacherLastName"].ToString() + "</b>";




        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session["TeacherUsername"] = null;
            Session["TeacherUsername"] = null;
            Session["TeacherPassword"] = null;
            Session["TeacherVerifyPassword"] = null;
            Session["TeacherFirstName"] = null;
            Session["TeacherLastName"] = null;
            Session["TeacherEmailAddress"] = null;
            Session["TeacherPhoneNumber"] = null;
            Session["TeacherGradeTaught"] = null;
            Session["TeacherSubjectTaught"] = null;
            Session["TeacherMealTicket"] = null;
            Session["TeacherSchool"] = null;

            Response.Redirect("TeacherLogin.aspx");

        }
    }
}