using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Lab1
{
    public partial class VolunteerEmailConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            lblSucess.Text = "Please check your email at: " + "'" + Session["VolunteerEmail"].ToString() + "'" + " " + "to continue to Step 3: Registration";

        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["AuthenticationCode"]) == Convert.ToInt32(txtAuthCode.Text))
            {
                Session["Authenticated"] = true;
                Response.Redirect("CreateVolunteer.aspx");

            }
            else
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Invalid Authentication Code!";
            }
        }
    }
}