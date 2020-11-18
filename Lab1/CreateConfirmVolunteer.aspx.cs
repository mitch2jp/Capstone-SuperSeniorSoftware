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
            //else if (!txtEmail.Text.Contains("@dukes.jmu.edu") || !txtEmail.Text.Contains("@jmu.edu"))
            //{
            //    lblStatus.Text = "You must be a JMU student or faculty member to create a volunteer account! (Use your JMU email address)";

            //}
            else
            {
                Session["VolunteerEmail"] = txtEmail.Text.ToString();



                try
                {


                    EASendMail.SmtpMail oMail = new EASendMail.SmtpMail("TryIt");

                    oMail.From = "jmu.cyberday@gmail.com";

                    oMail.To = Session["VolunteerEmail"].ToString();

                    oMail.Subject = "JMU CyberDay Volunteer Registration";

                    //oMail.TextBody = "Thank you for your interest in James Madison University's annual CyberDay Event!" + "\n" + "\n" +
                    //    "Please follow the corresponding link to continue the registraiton process: " + "\n" + "\n" + "http://jmu-cyberday.us-east-1.elasticbeanstalk.com/ParentStudentRegistration";

                    oMail.TextBody = "Hello " + "," + "\n" + "\n" +
                        "Thank you for your interest in volunteering at James Madison University's annual CyberDay Event!" + "\n" +
                        "Please return to the application and enter the following Authentication code to continue: " + "\n" + "\n" + "Authentication Code: " + GenerateAuthCode();

                    EASendMail.SmtpServer oServer = new EASendMail.SmtpServer("smtp.gmail.com");

                    oServer.User = "jmu.cyberday@gmail.com";
                    oServer.Password = "cyberday!";

                    oServer.Port = 587;

                    oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                    EASendMail.SmtpClient oSmtp = new EASendMail.SmtpClient();
                    oSmtp.SendMail(oServer, oMail);

                    lblStatus.ForeColor = Color.Green;
                    Response.Redirect("VolunteerEmailConfirmation.aspx");




                }
                catch (Exception ep)
                {
                    lblStatus.Text = ep.Message;


                }

            }
            
           

        }

        public int GenerateAuthCode()
        {
            int min = 1000;
            int max = 9999;
            Random rdm = new Random();

            Session["AuthenticationCode"] = rdm.Next(min, max);

            return Convert.ToInt32(Session["AuthenticationCode"]);

        }
    }
}