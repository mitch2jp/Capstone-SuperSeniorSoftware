using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Drawing;

namespace Lab1
{
    public partial class ParentStudentRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Authenticated"] == null)
            {
                Response.Redirect("ParentInfo.aspx");

            }
            else if ((bool)Session["Authenticated"] != true)
            {
                Response.Redirect("ParentInfo.aspx");

            }
            else
            {

                HideParentInfo();

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


            }




        }

        protected void rdoParentParticipateYes_CheckedChanged(object sender, EventArgs e)
        {
            ShowParentInfo();


            if (Session["ParentFirstName"] != null && Session["ParentLastName"] != null && Session["ParentEmail"] != null
                && Session["ParentPhoneNumber"] != null)
            {
                txtParentFirstName.Text = Session["ParentFirstName"].ToString();
                txtParentLastName.Text = Session["ParentLastName"].ToString();
                txtParentEmail.Text = Session["ParentEmail"].ToString();
                txtParentPhone.Text = Session["ParentPhoneNumber"].ToString();




            }

        }

        
        protected void rdoParentParticipateNo_CheckedChanged(object sender, EventArgs e)
        {

            HideParentInfo();

        }

        public void HideParentInfo()
        {
            divParentInfo.Visible = false;
            lblParentFirstName.Visible = false;
            lblParentLastName.Visible = false;
            txtParentFirstName.Visible = false;
            txtParentLastName.Visible = false;
            lblParentEmail.Visible = false;
            txtParentEmail.Visible = false;
            lblParentPhone.Visible = false;
            txtParentPhone.Visible = false;
            lblParentMealTicket.Visible = false;
            rdoParentMealTicketNo.Visible = false;
            rdoParentMealTicketYes.Visible = false;
            //lblParentTShirtSize.Visible = false;
            //ddlParentShirtSize.Visible = false;
            lblParentPriorParticipation.Visible = false;
            rdoParentPriorParticipationYes.Visible = false;
            rdoParentPriorParticipationNo.Visible = false;

        }

        public void ShowParentInfo()
        {
            divParentInfo.Visible = true;
            lblParentFirstName.Visible = true;
            lblParentLastName.Visible = true;
            txtParentFirstName.Visible = true;
            txtParentLastName.Visible = true;
            lblParentEmail.Visible = true;
            txtParentEmail.Visible = true;
            lblParentPhone.Visible = true;
            txtParentPhone.Visible = true;
            lblParentMealTicket.Visible = true;
            rdoParentMealTicketNo.Visible = true;
            rdoParentMealTicketYes.Visible = true;
            //lblParentTShirtSize.Visible = true;
            //ddlParentShirtSize.Visible = true;
            lblParentPriorParticipation.Visible = true;
            rdoParentPriorParticipationYes.Visible = true;
            rdoParentPriorParticipationNo.Visible = true;

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //get the session parent's ID to associate with the newly registered student
            String getParentID = "SELECT ParentID FROM Parent WHERE FirstName = @FirstName AND LastName = @LastName";
            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_AWS"].ToString());
            SqlCommand command = new SqlCommand();
            command.Connection = sqlConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = getParentID;
            command.Parameters.AddWithValue("@FirstName", Session["ParentFirstName"].ToString());
            command.Parameters.AddWithValue("@LastName", Session["ParentLastName"].ToString());
            sqlConnection.Open();
            int parentID = Convert.ToInt32(command.ExecuteScalar());


            //get the school ID to associate with the newly registered student
            String getSchoolID = "SELECT SchoolID FROM School WHERE SchoolName = @SchoolName";
            SqlCommand command2 = new SqlCommand();
            command2.Connection = sqlConnection;
            command2.CommandType = CommandType.Text;
            command2.CommandText = getSchoolID;
            command2.Parameters.AddWithValue("@SchoolName", ddlSchool.Text);
            int schoolID = Convert.ToInt32(command.ExecuteScalar());

            //get the school ID to associate with the newly registered student
            String getTeacherID = "SELECT TeacherID FROM Teacher WHERE LastName = @LastName";
            SqlCommand command3 = new SqlCommand();
            command3.Connection = sqlConnection;
            command3.CommandType = CommandType.Text;
            command3.CommandText = getTeacherID;
            command3.Parameters.AddWithValue("@LastName", ddlTeacher.Text);
            int teacherID = Convert.ToInt32(command.ExecuteScalar());


            //save the session variables to be passed into the insert statment on the next page
            Session["StudentFirstName"] = txtFirstName.Text;
            Session["StudentLastName"] = txtLastName.Text;
            Session["StudentAge"] = txtAge.Text;
            Session["StudentGender"] = ddlGender.Text;
            Session["StudentNotes"] = txtNotes.Text;
            if (rdoStudentMealTicketYes.Checked)
            {
                Session["StudentMealTicket"] = "Yes";

            }
            else
            {
                Session["StudentMealTicket"] = "No";
            }

            Session["StudentSchoolID"] = schoolID;
            Session["StudentTeacherID"] = teacherID; ;
            Session["ParentID"] = parentID;

            Response.Redirect("ParentPhotoReleaseAuth.aspx");


        }
    }
}