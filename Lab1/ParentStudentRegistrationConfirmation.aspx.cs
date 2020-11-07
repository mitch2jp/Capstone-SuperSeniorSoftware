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
    public partial class StudentRegistrationConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            lblInstructions.Text = "A confirmation has been sent to: " + "'" + "<b>" + Session["ParentEmail"].ToString() + "</b>" + "'" + " " + "\n" + 
                "Please check your email for your CyberDay registration details and additional intstructions. ";



            try
            {
               

                EASendMail.SmtpMail oMail = new EASendMail.SmtpMail("TryIt");

                oMail.From = "jmu.cyberday@gmail.com";

                oMail.To = Session["ParentEmail"].ToString();

                oMail.Subject = "CyberDay Registration Confirmation";

                oMail.TextBody = "Hi " + Session["ParentFirstName"].ToString() + "," + "\n" + "\n" +
                    "Congratulations on successfully registering your student for JMU's annual CyberDay!" + "\n" +
                    "The following information pertains to your student's registration information. Please save for your personal record" + "\n" + "\n" +
                    "Name: " + Session["StudentFirstName"].ToString() + " " + Session["StudentLastName"] + "\n" +
                    "Age: " + Session["StudentAge"].ToString() + "\n" +
                    "Gender: " + Session["StudentGender"].ToString() + "\n" +
                    "Meal Ticket: " + Session["StudentMealTicket"].ToString() + "\n" +
                    "Photo Authorization: " + Session["StudentPhotoReleaseAuth"].ToString() + "\n" + "\n" +
                    "Additional Comments/Notes: " + Session["StudentNotes"].ToString() + "\n" + "\n" + "\n" +

                    "For additional details about your student's CyberDay experience and an event itinerary, click here: " + "http://jmu-cyberday.us-east-1.elasticbeanstalk.com/ParentStudentItinerary" + "\n" +

                    "If you have any additional questions or concerns, please contact jmu.cyberday@gmail.com for more information.";




                EASendMail.SmtpServer oServer = new EASendMail.SmtpServer("smtp.gmail.com");

                oServer.User = "jmu.cyberday@gmail.com";
                oServer.Password = "cyberday!";

                oServer.Port = 587;

                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                EASendMail.SmtpClient oSmtp = new EASendMail.SmtpClient();
                oSmtp.SendMail(oServer, oMail);

                lblStatus.ForeColor = Color.Green;
                




            }
            catch (Exception ep)
            {
                lblStatus.Text = ep.Message;


            }


        }
    }
}