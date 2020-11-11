﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab1
{
    public partial class VolunteerEditProfileConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session["VolunteerID"] = null;
            Session["VolunteerUsername"] = null;
            Session["VolunteerPassword"] = null;
            Session["VolunteerFirstName"] = null;
            Session["VolunteerLastName"] = null;
            Session["VolunteerEmail"] = null;
            Session["VolunteerPhoneNumber"] = null;
            Session["VolunteerGender"] = null;
            Session["VolunteerMealTicket"] = null;
            Session["VolunteerMajor"] = null;
            Session["VolunteerPriorParticipation"] = null;
            Session["VolunteerOrganizationAfilliation"] = null;

            Response.Redirect("VolunteerLogin.aspx");


        }
    }
}