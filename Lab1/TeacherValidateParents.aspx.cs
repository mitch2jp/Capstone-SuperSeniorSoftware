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
using System.Configuration;


namespace Lab1
{
    public partial class TeacherValidateParents : System.Web.UI.Page
    {

        string cs = ConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString();
        SqlConnection con;
        SqlDataAdapter adapt;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TeacherLastName"] == null)
            {
                Response.Redirect("TeacherLogin.aspx");

            }




            if (!IsPostBack)
            {
                ShowData();


            }



        }

        public void ShowData()
        {

            string sql = "SELECT vp.ValidationID, vp.FirstName, vp.LastName, vp.EmailAddress, vp.PhoneNumber, vp.Authorized" +
            " FROM Teacher t, ValidateParent vp" +
            " WHERE t.TeacherEventID = vp.TeacherEventID AND t.LastName = " + "'" + Session["TeacherLastName"].ToString() + "'";

            dt = new DataTable();
            con = new SqlConnection(cs);
            con.Open();
            adapt = new SqlDataAdapter(sql, con);
            adapt.Fill(dt);
            ViewState["dtbl"] = dt;
            if (dt.Rows.Count > 0)
            {
                grdParentAuthorization.DataSource = dt;
                grdParentAuthorization.DataBind();

            }
            con.Close();



        }

        protected void grdParentAuthorization_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void grdParentAuthorization_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            


            if (e.CommandName == "Authorize")
            {

                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = grdParentAuthorization.Rows[rowIndex];

                string email = (row.FindControl("lblEmailAddress") as Label).Text;


                string breakpoint = "";

                try
                {

                    SqlConnection sqlConnect2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString());
                    String queryTeacherEventID = "SELECT TeacherEventID FROM ValidateParent WHERE EmailAddress = @EmailAddress";
                    SqlCommand getTeacherEventID = new SqlCommand();
                    getTeacherEventID.Connection = sqlConnect2;
                    getTeacherEventID.CommandType = CommandType.Text;
                    getTeacherEventID.CommandText = queryTeacherEventID;
                    getTeacherEventID.Parameters.AddWithValue("@EmailAddress", email.ToString());
                    sqlConnect2.Open();
                    string teacherEventID = getTeacherEventID.ExecuteScalar().ToString();



                    EASendMail.SmtpMail oMail = new EASendMail.SmtpMail("TryIt");

                    oMail.From = "jmu.cyberday@gmail.com";

                    oMail.To = email.ToString();

                    oMail.Subject = "CyberDay: Authorization Code";

                    //oMail.TextBody = "Thank you for your interest in James Madison University's annual CyberDay Event!" + "\n" + "\n" +
                    //    "Please follow the corresponding link to continue the registraiton process: " + "\n" + "\n" + "http://jmu-cyberday.us-east-1.elasticbeanstalk.com/ParentStudentRegistration";

                    oMail.TextBody = teacherEventID;

                    EASendMail.SmtpServer oServer = new EASendMail.SmtpServer("smtp.gmail.com");

                    oServer.User = "jmu.cyberday@gmail.com";
                    oServer.Password = "cyberday!";

                    oServer.Port = 587;

                    oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                    EASendMail.SmtpClient oSmtp = new EASendMail.SmtpClient();
                    oSmtp.SendMail(oServer, oMail);

                    lblStatus.ForeColor = Color.Green;

                    lblStatus.Text = "Authentication successfully sent to: " + email;

                }
                catch (Exception ep)
                {
                    lblStatus.Text = ep.Message;


                }

            }
            


        }

        protected void btn_Authorize_Click(object sender, EventArgs e)
        {
            




        }

        protected void grdParentAuthorization_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            

        }
    }
}