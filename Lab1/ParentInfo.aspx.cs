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

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString());
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
            if (txtEmail.Text != txtVerifyEmail.Text)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Emails do not match!";

            }
            else
            {

                Session["ParentFirstName"] = txtFirstName.Text.ToString();
                Session["ParentLastName"] = txtLastName.Text.ToString();
                Session["ParentPhoneNumber"] = txtPhone.Text.ToString();
                Session["ParentEmail"] = txtEmail.Text.ToString();
                Session["ParentStudentSchool"] = ddlSchool.SelectedValue;
                Session["ParentStudentTeacher"] = ddlTeacher.SelectedValue;


                SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString());
                SqlCommand addParent = new SqlCommand();
                addParent.Connection = sqlConnect2;
                addParent.CommandText = "INSERT INTO Parent VALUES (@FirstName, @LastName, @EmailAddress, @PhoneNumber, @StudentSchool, @StudentTeacher)";
                addParent.Parameters.Add(new SqlParameter("@FirstName", HttpUtility.HtmlEncode(txtFirstName.Text)));
                addParent.Parameters.Add(new SqlParameter("@LastName", HttpUtility.HtmlEncode(txtLastName.Text)));
                addParent.Parameters.Add(new SqlParameter("@EmailAddress", HttpUtility.HtmlEncode(txtEmail.Text)));
                addParent.Parameters.Add(new SqlParameter("@PhoneNumber", HttpUtility.HtmlEncode(txtPhone.Text)));
                addParent.Parameters.Add(new SqlParameter("@StudentSchool", HttpUtility.HtmlEncode(ddlSchool.Text)));
                addParent.Parameters.Add(new SqlParameter("@StudentTeacher", HttpUtility.HtmlEncode(ddlTeacher.Text)));
                sqlConnect2.Open();
                addParent.ExecuteNonQuery();

                //get the session parent's ID to associate with the newly registered student
                String getParentID = "SELECT ParentID FROM Parent WHERE FirstName = @FirstName AND LastName = @LastName";
                SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString());
                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                command.CommandType = CommandType.Text;
                command.CommandText = getParentID;
                command.Parameters.AddWithValue("@FirstName", Session["ParentFirstName"].ToString());
                command.Parameters.AddWithValue("@LastName", Session["ParentLastName"].ToString());
                sqlConnection.Open();
                Session["ParentID"] = Convert.ToInt32(command.ExecuteScalar());

                string breakpoint = "";


                try
                {


                    EASendMail.SmtpMail oMail = new EASendMail.SmtpMail("TryIt");

                    oMail.From = "jmu.cyberday@gmail.com";

                    oMail.To = Session["ParentEmail"].ToString();

                    oMail.Subject = "JMU CyberDay Student Registration";

                    //oMail.TextBody = "Thank you for your interest in James Madison University's annual CyberDay Event!" + "\n" + "\n" +
                    //    "Please follow the corresponding link to continue the registraiton process: " + "\n" + "\n" + "http://jmu-cyberday.us-east-1.elasticbeanstalk.com/ParentStudentRegistration";

                    oMail.TextBody = "Hi " + Session["ParentFirstName"].ToString() + "," + "\n" + "\n" + 
                        "Thank you for your interest in James Madison University's annual CyberDay Event!" + "\n" + 
                        "Please return to the application and enter the following authentication code to continue: " + "\n" + "\n" + "Authentication Code: " + GenerateAuthCode();

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

            }


        }

        protected void ddlSchool_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //generate the authentication code to be used for registration
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