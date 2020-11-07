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



                if (Session["ParentStudentSchool"] != null)
                {
                    ddlSchool.SelectedValue = Session["ParentStudentSchool"].ToString();

                }
                if (Session["ParentStudentTeacher"] != null)
                {
                    ddlTeacher.SelectedValue = Session["ParentStudentTeacher"].ToString();

                }



            }






        }

        protected void rdoParentParticipateYes_CheckedChanged(object sender, EventArgs e)
        {

            if (Session["ParentStudentSchool"] != null && Session["ParentStudentTeacher"] != null)
            {
                dropDownListHandler(0, 0);
                ddlSchool.SelectedValue = Session["ParentStudentSchool"].ToString();
                ddlTeacher.SelectedValue = Session["ParentStudentTeacher"].ToString();


            }

            

        }

        
        protected void rdoParentParticipateNo_CheckedChanged(object sender, EventArgs e)
        {
            if (Session["ParentStudentSchool"] != null && Session["ParentStudentTeacher"] != null)
            {
                dropDownListHandler(0, 0);
                ddlSchool.SelectedValue = Session["ParentStudentSchool"].ToString();
                ddlTeacher.SelectedValue = Session["ParentStudentTeacher"].ToString();


            }


        }




        protected void btnContinue_Click(object sender, EventArgs e)
        {

            if (Session["ParentStudentSchool"] != null && Session["ParentStudentTeacher"] != null)
            {
                dropDownListHandler(0, 0);
                ddlSchool.SelectedValue = Session["ParentStudentSchool"].ToString();
                ddlTeacher.SelectedValue = Session["ParentStudentTeacher"].ToString();


            }



            if (!rdoPriorYes.Checked && !rdoPriorNo.Checked)
            {
                valPriorParticipation.Text = "(Required)";

            }
            else if (!rdoStudentMealTicketNo.Checked && !rdoStudentMealTicketYes.Checked)
            {
                valMealTicket.Text = "(Required)";

            }
            //else if (!rdoParentParticipateYes.Checked && !rdoParentParticipateNo.Checked)
            //{
            //    lblParentRegistrationStatus.ForeColor = Color.Red;
            //    lblParentRegistrationStatus.Text = "(Required)";

            //}
            else
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
                int schoolID = Convert.ToInt32(command2.ExecuteScalar());

                //get the school ID to associate with the newly registered student
                String getTeacherID = "SELECT TeacherID FROM Teacher WHERE LastName = @LastName";
                SqlCommand command3 = new SqlCommand();
                command3.Connection = sqlConnection;
                command3.CommandType = CommandType.Text;
                command3.CommandText = getTeacherID;
                command3.Parameters.AddWithValue("@LastName", ddlTeacher.Text);
                int teacherID = Convert.ToInt32(command3.ExecuteScalar());


                //save the session variables to be passed into the insert statment on the next page
                Session["StudentFirstName"] = txtFirstName.Text;
                Session["StudentLastName"] = txtLastName.Text;
                Session["StudentAge"] = txtAge.Text;
                Session["StudentGender"] = ddlGender.Text;
                Session["StudentNotes"] = txtNotes.Text;

                if (rdoPriorYes.Checked)
                {
                    Session["StudentPriorParticipation"] = "Yes";
                }
                else
                {
                    Session["StudentPriorParticipation"] = "No";
                }


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


                Response.Redirect("ParentParticipation.aspx");



            }

            

        }

        public void dropDownListHandler(int schoolListIndex, int teacherListIndex)
        {
            //Clear and repopulate the drop down lists to prevent postback ddl duplication
            ddlSchool.Items.Clear();
            ddlTeacher.Items.Clear();
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



            ddlSchool.SelectedIndex = schoolListIndex;
            ddlTeacher.SelectedIndex = teacherListIndex;


        }

        

        protected void btnRegister_Click1(object sender, EventArgs e)
        {

            //if (!rdoParentMealTicketNo.Checked && !rdoParentMealTicketYes.Checked)
            //{
            //    valParentMealTicket.Text = "(Required)";

            //}
            




            //if (Session["ParentStudentSchool"] != null && Session["ParentStudentTeacher"] != null)
            //{
            //    dropDownListHandler(0, 0);
            //    ddlSchool.SelectedValue = Session["ParentStudentSchool"].ToString();
            //    ddlTeacher.SelectedValue = Session["ParentStudentTeacher"].ToString();


            //}

            //HideParentInfo();

            //lblParentRegistrationStatus.Text = "Successfully registered as CyberDay volunteer";



        }
    }
}