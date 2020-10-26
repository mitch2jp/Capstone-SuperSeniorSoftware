using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab1
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegisterChild_Click(object sender, EventArgs e)
        {
            Response.Redirect("ParentInfo.aspx");


        }

        protected void btnStudentStart_Click(object sender, EventArgs e)
        {

        }

        protected void btnTeacher_Click(object sender, EventArgs e)
        {

        }
    }
}