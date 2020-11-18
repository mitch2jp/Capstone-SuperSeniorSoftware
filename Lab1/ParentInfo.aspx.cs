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
            //verify the supplied emails match 
            if (txtEmail.Text != txtVerifyEmail.Text)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Emails do not match!";

            }
            else
            {
                //open the database connections
                SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString());
                sqlConnection.Open();
                SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString());
                sqlConnect2.Open();

                //validate to see if the entered email already exists with a parent in the db
                String valEmail = "SELECT COUNT(1) FROM Parent WHERE EmailAddress = @EmailAddress";
                SqlCommand getParentEmail = new SqlCommand();
                getParentEmail.Connection = sqlConnection;
                getParentEmail.CommandType = CommandType.Text;
                getParentEmail.CommandText = valEmail;
                getParentEmail.Parameters.AddWithValue("@EmailAddress", HttpUtility.HtmlEncode(txtEmail.Text));
                int count = Convert.ToInt32(getParentEmail.ExecuteScalar());



                if (count >= 1)
                {

                    lblStatus.Text = "This email address is already registred to a CyberDay parent!";

                }
                else
                {
                    //save the session variables
                    Session["ParentFirstName"] = txtFirstName.Text.ToString();
                    Session["ParentLastName"] = txtLastName.Text.ToString();
                    Session["ParentPhoneNumber"] = txtPhone.Text.ToString();
                    Session["ParentEmail"] = txtEmail.Text.ToString();
                    Session["ParentStudentSchool"] = ddlSchool.SelectedValue;
                    Session["ParentStudentTeacherLastName"] = ddlTeacher.SelectedValue;


                    //add the registered parent to the DB
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
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlConnection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = getParentID;
                    command.Parameters.AddWithValue("@FirstName", Session["ParentFirstName"].ToString());
                    command.Parameters.AddWithValue("@LastName", Session["ParentLastName"].ToString());
                    Session["ParentID"] = Convert.ToInt32(command.ExecuteScalar());

                    
                    String queryTeacherID = "SELECT TeacherID FROM Teacher WHERE LastName = @LastName";
                    SqlCommand getTeacherID = new SqlCommand();
                    getTeacherID.Connection = sqlConnection;
                    getTeacherID.CommandType = CommandType.Text;
                    getTeacherID.CommandText = queryTeacherID;
                    getTeacherID.Parameters.AddWithValue("@LastName", Session["ParentStudentTeacherLastName"].ToString());
                    Session["ParentTeacherID"] = Convert.ToInt32(getTeacherID.ExecuteScalar());

                    String queryTeacherEmail = "SELECT EmailAddress FROM Teacher WHERE LastName = @LastName";
                    SqlCommand getTeacherEmail = new SqlCommand();
                    getTeacherEmail.Connection = sqlConnection;
                    getTeacherEmail.CommandType = CommandType.Text;
                    getTeacherEmail.CommandText = queryTeacherEmail;
                    getTeacherEmail.Parameters.AddWithValue("@LastName", Session["ParentStudentTeacherLastName"].ToString());
                    Session["ParentTeacherEmail"] = getTeacherEmail.ExecuteScalar().ToString();


                    String queryTeacherFirstName = "SELECT FirstName FROM Teacher WHERE LastName = @LastName";
                    SqlCommand getTeacherFirstName = new SqlCommand();
                    getTeacherFirstName.Connection = sqlConnection;
                    getTeacherFirstName.CommandType = CommandType.Text;
                    getTeacherFirstName.CommandText = queryTeacherFirstName;
                    getTeacherFirstName.Parameters.AddWithValue("@LastName", Session["ParentStudentTeacherLastName"].ToString());
                    Session["ParentTeacherFirstName"] = getTeacherFirstName.ExecuteScalar().ToString();

                    String queryTeacherEventID = "SELECT TeacherEventID FROM Teacher WHERE LastName = @LastName";
                    SqlCommand getTeacherEventID = new SqlCommand();
                    getTeacherEventID.Connection = sqlConnection;
                    getTeacherEventID.CommandType = CommandType.Text;
                    getTeacherEventID.CommandText = queryTeacherEventID;
                    getTeacherEventID.Parameters.AddWithValue("@LastName", Session["ParentStudentTeacherLastName"].ToString());
                    string teacherEventID = getTeacherEventID.ExecuteScalar().ToString();

                    //add the parent to validation table in the DB for the teacher to verify 
                    SqlCommand addValidateParent = new SqlCommand();
                    addValidateParent.Connection = sqlConnect2;
                    addValidateParent.CommandText = "INSERT INTO ValidateParent VALUES (@FirstName, @LastName, @EmailAddress, @PhoneNumber, @Authorized, @TeacherEventID)";
                    addValidateParent.Parameters.Add(new SqlParameter("@FirstName", HttpUtility.HtmlEncode(txtFirstName.Text)));
                    addValidateParent.Parameters.Add(new SqlParameter("@LastName", HttpUtility.HtmlEncode(txtLastName.Text)));
                    addValidateParent.Parameters.Add(new SqlParameter("@EmailAddress", HttpUtility.HtmlEncode(txtEmail.Text)));
                    addValidateParent.Parameters.Add(new SqlParameter("@PhoneNumber", HttpUtility.HtmlEncode(txtPhone.Text)));
                    addValidateParent.Parameters.Add(new SqlParameter("@Authorized", "No"));
                    addValidateParent.Parameters.Add(new SqlParameter("@TeacherEventID", teacherEventID));
                    addValidateParent.ExecuteNonQuery();

                    //send an alert email to the associated teacher letting them know a parent is trying to register
                    try
                    {


                        EASendMail.SmtpMail oMail = new EASendMail.SmtpMail("TryIt");

                        oMail.From = "jmu.cyberday@gmail.com";

                        oMail.To = Session["ParentTeacherEmail"].ToString();

                        oMail.Subject = "CyberDay: Parent Authorization Request";

                        oMail.TextBody = "Hello " + Session["ParentTeacherFirstName"].ToString() + " " + Session["ParentStudentTeacherLastName"].ToString() + "," + "\n" + "\n" +
                            "Thank you for your interest in James Madison University's annual CyberDay Event!" + "\n" +
                            "The following parent has requested authorization to sign their student up for CyberDay: " + "\n" + "\n" + "Name: " + Session["ParentFirstName"].ToString() + " " + Session["ParentLastName"].ToString() + "\n" +
                            "Email: " + Session["ParentEmail"].ToString() + "\n" +
                            "Phone Number: " + Session["ParentPhoneNumber"].ToString() + "\n" + "\n" +
                            "Please proceed to you dashboard to validate the parent's identity and/or supply the authorization code so they may continue.";

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


                    //send a notification email to the parent telling them to wait for authorization from the teacher to continue
                    try
                    {


                        EASendMail.SmtpMail oMail = new EASendMail.SmtpMail("TryIt");

                        oMail.From = "jmu.cyberday@gmail.com";

                        oMail.To = Session["ParentEmail"].ToString();

                        oMail.Subject = "JMU CyberDay Student Registration";


                        oMail.TextBody = "Hi " + Session["ParentFirstName"].ToString() + "," + "\n" + "\n" +
                            "Thank you for your interest in James Madison University's annual CyberDay Event!" + "\n" + "\n" +
                            "An email has been sent to your student's listed teacher, " + Session["ParentTeacherFirstName"].ToString() + " " + Session["ParentStudentTeacherLastName"].ToString() + "," + " " + "Requesting access and authorization the CyberDay application. " + "\n" +
                            "Once your identity has been verified, your student's teacher will send you an associated authorization code to continue the registration process. " + "\n" + "\n" +
                            "When you have recieved your authorization code, click here to continue the registration: " + "https://localhost:44322/ParentAuthentication";

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