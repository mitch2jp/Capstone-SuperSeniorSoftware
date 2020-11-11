using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab1
{
    public partial class EmailConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblConfirm.Text = "Thank you, " + Session["ParentFirstName"].ToString() + " " + Session["ParentLastName"].ToString() ;
            lblSucess.Text = "Please check your email at: "  + "<b>" + Session["ParentEmail"].ToString() + "</b>" + " " + "and enter your registration code to continue" ;

        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["AuthenticationCode"]) == Convert.ToInt32(txtAuthCode.Text))
            {
                Session["Authenticated"] = true;
                Response.Redirect("ParentStudentRegistration.aspx");

            }
            else
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Invalid Authentication Code!";
            }

        }
    }
}