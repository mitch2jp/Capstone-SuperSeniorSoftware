using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab1
{
    public partial class VolunteerEmailConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblConfirm.Text = "Success!";
            lblSucess.Text = "Please check your email at: " + "'" + Session["VolunteerEmail"].ToString() + "'" + " " + "to continue to Step 3: Registration";

        }
    }
}