using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Drawing;
using System.Text;
using EASendMail;

using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Drawing;

namespace Lab1
{
    public partial class ParentInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            //populate the drop down lists 
            ddlSchool.Items.Insert(0, "Choose One");
            ddlTeacher.Items.Insert(0, "Choose One");

            string sqlQueryTeacher = "Select * From Teacher";
            string sqlQuerySchool = "Select SchoolName FROM School";

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_AWS"].ToString());
            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.Connection = sqlConnect;
            sqlCommand1.CommandType = CommandType.Text;
            sqlCommand1.CommandText = sqlQueryTeacher;

            SqlCommand sqlCommand2 = new SqlCommand();
            sqlCommand2.Connection = sqlConnect;
            sqlCommand2.CommandType = CommandType.Text;
            sqlCommand2.CommandText = sqlQuerySchool;

            sqlConnect.Open();
            SqlDataReader queryResultsTeacher = sqlCommand1.ExecuteReader();
            SqlDataReader queryResultsSchool = sqlCommand2.ExecuteReader();

            while (queryResultsTeacher.Read())
            {
                string LastName = queryResultsTeacher["LastName"].ToString();
                ddlTeacher.Items.Add(queryResultsTeacher["LastName"].ToString());

            }

            while (queryResultsSchool.Read())
            {
                string school = queryResultsSchool["SchoolName"].ToString();
                ddlSchool.Items.Add(school);

            }

            queryResultsSchool.Close();
            queryResultsTeacher.Close();
            sqlConnect.Close();




            


        }

        protected void lnkBtn_Click(object sender, EventArgs e)
        {

        }

        protected void lnkBtn_Click1(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {


        }

        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            Session["ParentFirstName"] = txtFirstName.Text.ToString();
            Session["ParentLastName"] = txtLastName.Text.ToString();
            Session["ParentEmail"] = txtEmail.Text.ToString();



            try
            {
                EASendMail.SmtpMail oMail = new EASendMail.SmtpMail("TryIt");

                oMail.From = "jmu.cyberday@gmail.com";

                oMail.To = Session["ParentEmail"].ToString();

                oMail.Subject = "JMU CyberDay Student Registration";

                oMail.TextBody = "Thank you for your interest in James Madison University's annual CyberDay Event!" + "\n" + "\n" +
                    "Please follow the corresponding link to continue the registraiton process: " + "\n" + "\n" + "http://jmu-cyberday.us-east-1.elasticbeanstalk.com/ParentStudentRegistration";

                EASendMail.SmtpServer oServer = new EASendMail.SmtpServer("smtp.gmail.com");

                oServer.User = "jmu.cyberday@gmail.com";
                oServer.Password = "cyberday!";

                oServer.Port = 587;

                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                EASendMail.SmtpClient oSmtp = new EASendMail.SmtpClient();
                oSmtp.SendMail(oServer, oMail);

                lblStatus.ForeColor = Color.Green;
                Response.Redirect("ParentEmailConfirmation");
                



            }
            catch (Exception ep)
            {
                lblStatus.Text = ep.Message;

                
            }


            //Response.Redirect("ParentStudentRegistration.aspx");



            //MailMessage mailMessage = new MailMessage(txtEmail.Text, "jmu.cyberday@gmail.com");
            //mailMessage.Subject = "CyberDay Registration";
            //mailMessage.Body = "blah";

            //SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            //smtpClient.Credentials = new System.Net.NetworkCredential()
            //{
            //    UserName = "jmu.cyberday@gmail.com",
            //    Password = "cyberday!"


            //};
            //smtpClient.EnableSsl = true;
            //smtpClient.Send(mailMessage);


            //lblStatus.ForeColor = Color.Green;
            //lblStatus.Text = "Email Sent successfully. Please check your email to verify your credentials and continue the process. ";


            //Response.Redirect("ParentStudentRegistration.aspx");

        }

        protected void ddlSchool_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}