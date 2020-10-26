using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Drawing;

namespace Lab1
{
    public partial class ParentInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void lnkBtn_Click(object sender, EventArgs e)
        {

        }

        protected void lnkBtn_Click1(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            Session["ParentFirstName"] = txtFirstName.Text.ToString();
            Session["ParentLastName"] = txtLastName.Text.ToString();
            Session["ParentEmail"] = txtEmail.Text.ToString();

            Response.Redirect("ParentStudentRegistration.aspx");



            MailMessage mailMessage = new MailMessage(txtEmail.Text, "jmu.cyberday@gmail.com");
            mailMessage.Subject = "CyberDay Registration";
            mailMessage.Body = "blah";

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "jmu.cyberday@gmail.com",
                Password = "cyberday!"


            };
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);


            lblStatus.ForeColor = Color.Green;
            lblStatus.Text = "Email Sent successfully. Please check your email to verify your credentials and continue the process. ";


            Response.Redirect("ParentStudentRegistration.aspx");




        }
    }
}