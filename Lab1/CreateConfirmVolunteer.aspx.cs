using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EASendMail;

using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Drawing;

namespace Lab1
{
    public partial class CreateConfirmVolunteer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
           
            if (!txtEmail.Text.Contains("@"))
            {
                lblStatus.Text = "Please enter a valid email!";

            }
            else if (txtEmail.Text != txtVerifyEmail.Text)
            {
                lblStatus.Text = "Email's do not match!";

            }
            else if (!txtEmail.Text.Contains("@dukes.jmu.edu"))
            {
                lblStatus.Text = "You must be a JMU student to create a volunteer account!";

            }
            else
            {
                Session["VolunteerEmail"] = txtEmail.Text.ToString();



                try
                {
                    EASendMail.SmtpMail oMail = new EASendMail.SmtpMail("TryIt");

                    oMail.From = "jmu.cyberday@gmail.com";

                    oMail.To = Session["VolunteerEmail"].ToString();

                    oMail.Subject = "JMU CyberDay Volunteer Registration";

                    oMail.TextBody = "Thank you for your interest in James Madison University's annual CyberDay Event!" + "\n" + "\n" +
                        "Please follow the corresponding link to continue the registration process: " + "\n" + "\n" + "https://localhost:44322/CreateVolunteer";

                    EASendMail.SmtpServer oServer = new EASendMail.SmtpServer("smtp.gmail.com");

                    oServer.User = "jmu.cyberday@gmail.com";
                    oServer.Password = "cyberday!";

                    oServer.Port = 587;

                    oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                    EASendMail.SmtpClient oSmtp = new EASendMail.SmtpClient();
                    oSmtp.SendMail(oServer, oMail);

                    lblStatus.ForeColor = Color.Green;
                    Response.Redirect("VolunteerEmailConfirmation");




                }
                catch (Exception ep)
                {
                    lblStatus.Text = ep.Message;


                }

            }
            
           

        }
    }
}