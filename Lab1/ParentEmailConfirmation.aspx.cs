using System;
using System.Collections.Generic;
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
            lblConfirm.Text = "Thank you, " + Session["ParentFirstName"].ToString() + " " + Session["ParentLastName"].ToString() ;
            lblSucess.Text = "Please check your email at: " + "'" +  Session["ParentEmail"].ToString() + "'" + " " + "to continue to Step 3: Registration" ;

        }
    }
}