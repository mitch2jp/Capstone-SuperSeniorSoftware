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

using System;
using System.Globalization;
using System.Text.RegularExpressions;


namespace Lab1
{
    public partial class StudentSurvey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {


            if (txtEmail.Text == string.Empty)
            {
                SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString());
                sqlConnection.Open();

                //check to see if the student taking the survey has been registered for CyberDay
                String queryFindStudent = "SELECT COUNT(1) FROM Student WHERE FirstName = @FirstName AND LastName = @LastName";
                SqlCommand findStudent = new SqlCommand();
                findStudent.Connection = sqlConnection;
                findStudent.CommandType = CommandType.Text;
                findStudent.CommandText = queryFindStudent;
                findStudent.Parameters.AddWithValue("@FirstName", HttpUtility.HtmlEncode(txtFirstName.Text));
                findStudent.Parameters.AddWithValue("@LastName", HttpUtility.HtmlEncode(txtLastName.Text));
                int count = Convert.ToInt32(findStudent.ExecuteScalar());

                if (count < 1)
                {
                    lblStudentStatus.Text = "Student has not yet been registered for CyberDay! Please register the student before completing the survey!";

                }
                else
                {

                    //retrieve studentid associated with student taking the survey
                    String queryStudentID = "SELECT StudentID FROM Student WHERE FirstName = @FirstName AND LastName = @LastName";
                    SqlCommand getStudentID = new SqlCommand();
                    getStudentID.Connection = sqlConnection;
                    getStudentID.CommandType = CommandType.Text;
                    getStudentID.CommandText = queryStudentID;
                    getStudentID.Parameters.AddWithValue("@FirstName", HttpUtility.HtmlEncode(txtFirstName.Text));
                    getStudentID.Parameters.AddWithValue("@LastName", HttpUtility.HtmlEncode(txtLastName.Text));
                    int studentID = Convert.ToInt32(getStudentID.ExecuteScalar());

                    //add the completed survey to the DB
                    SqlCommand insertStudentSurvey = new SqlCommand();
                    insertStudentSurvey.Connection = sqlConnection;
                    insertStudentSurvey.CommandText = "INSERT INTO StudentSurvey VALUES (@FirstName, @LastName, @EmailAddress, " +
                        "@CyberDaySatisfaction, @ActivitySatisfaction, @VolunteerSatisfaction, @HigherEducation," +
                        "@TechnicalPath, @Comments, @StudentID)";
                    insertStudentSurvey.Parameters.Add(new SqlParameter("@FirstName", HttpUtility.HtmlEncode(txtFirstName.Text)));
                    insertStudentSurvey.Parameters.Add(new SqlParameter("@LastName", HttpUtility.HtmlEncode(txtLastName.Text)));
                    insertStudentSurvey.Parameters.Add(new SqlParameter("@EmailAddress", HttpUtility.HtmlEncode(txtEmail.Text)));
                    insertStudentSurvey.Parameters.Add(new SqlParameter("@CyberDaySatisfaction", HttpUtility.HtmlEncode(rdoBtnListCDSatisfaction.Text)));
                    insertStudentSurvey.Parameters.Add(new SqlParameter("@ActivitySatisfaction", HttpUtility.HtmlEncode(rdoBtnListActivitySatisfaction.Text)));
                    insertStudentSurvey.Parameters.Add(new SqlParameter("@VolunteerSatisfaction", HttpUtility.HtmlEncode(rdoBtnListVolunteerSatisfaction.Text)));
                    insertStudentSurvey.Parameters.Add(new SqlParameter("@HigherEducation", HttpUtility.HtmlEncode(rdoBtnListHigherEducation.Text)));
                    insertStudentSurvey.Parameters.Add(new SqlParameter("@TechnicalPath", HttpUtility.HtmlEncode(rdoBtnListTechnicalPath.Text)));
                    insertStudentSurvey.Parameters.Add(new SqlParameter("@Comments", HttpUtility.HtmlEncode(txtComments.Text)));
                    insertStudentSurvey.Parameters.Add(new SqlParameter("@StudentID", studentID));
                    insertStudentSurvey.ExecuteNonQuery();



                    Response.Redirect("StudentSurveyConfirmation.aspx");





                }


            }
            else
            {

                if (IsValidEmail(txtEmail.Text) == false)
                {
                    valEmail.Text = "Invalid Email";


                }
                else
                {

                    SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_Local"].ToString());
                    sqlConnection.Open();

                    //check to see if the student taking the survey has been registered for CyberDay
                    String queryFindStudent = "SELECT COUNT(1) FROM Student WHERE FirstName = @FirstName AND LastName = @LastName";
                    SqlCommand findStudent = new SqlCommand();
                    findStudent.Connection = sqlConnection;
                    findStudent.CommandType = CommandType.Text;
                    findStudent.CommandText = queryFindStudent;
                    findStudent.Parameters.AddWithValue("@FirstName", HttpUtility.HtmlEncode(txtFirstName.Text));
                    findStudent.Parameters.AddWithValue("@LastName", HttpUtility.HtmlEncode(txtLastName.Text));
                    int count = Convert.ToInt32(findStudent.ExecuteScalar());

                    if (count < 1)
                    {
                        lblStudentStatus.Text = "Student has not yet been registered for CyberDay! Please register the student before completing the survey!";

                    }
                    else
                    {

                        //retrieve studentid associated with student taking the survey
                        String queryStudentID = "SELECT StudentID FROM Student WHERE FirstName = @FirstName AND LastName = @LastName";
                        SqlCommand getStudentID = new SqlCommand();
                        getStudentID.Connection = sqlConnection;
                        getStudentID.CommandType = CommandType.Text;
                        getStudentID.CommandText = queryStudentID;
                        getStudentID.Parameters.AddWithValue("@FirstName", HttpUtility.HtmlEncode(txtFirstName.Text));
                        getStudentID.Parameters.AddWithValue("@LastName", HttpUtility.HtmlEncode(txtLastName.Text));
                        int studentID = Convert.ToInt32(getStudentID.ExecuteScalar());

                        //add the completed survey to the DB
                        SqlCommand insertStudentSurvey = new SqlCommand();
                        insertStudentSurvey.Connection = sqlConnection;
                        insertStudentSurvey.CommandText = "INSERT INTO StudentSurvey VALUES (@FirstName, @LastName, @EmailAddress, " +
                            "@CyberDaySatisfaction, @ActivitySatisfaction, @VolunteerSatisfaction, @HigherEducation," +
                            "@TechnicalPath, @Comments, @StudentID)";
                        insertStudentSurvey.Parameters.Add(new SqlParameter("@FirstName", HttpUtility.HtmlEncode(txtFirstName.Text)));
                        insertStudentSurvey.Parameters.Add(new SqlParameter("@LastName", HttpUtility.HtmlEncode(txtLastName.Text)));
                        insertStudentSurvey.Parameters.Add(new SqlParameter("@EmailAddress", HttpUtility.HtmlEncode(txtEmail.Text)));
                        insertStudentSurvey.Parameters.Add(new SqlParameter("@CyberDaySatisfaction", HttpUtility.HtmlEncode(rdoBtnListCDSatisfaction.Text)));
                        insertStudentSurvey.Parameters.Add(new SqlParameter("@ActivitySatisfaction", HttpUtility.HtmlEncode(rdoBtnListActivitySatisfaction.Text)));
                        insertStudentSurvey.Parameters.Add(new SqlParameter("@VolunteerSatisfaction", HttpUtility.HtmlEncode(rdoBtnListVolunteerSatisfaction.Text)));
                        insertStudentSurvey.Parameters.Add(new SqlParameter("@HigherEducation", HttpUtility.HtmlEncode(rdoBtnListHigherEducation.Text)));
                        insertStudentSurvey.Parameters.Add(new SqlParameter("@TechnicalPath", HttpUtility.HtmlEncode(rdoBtnListTechnicalPath.Text)));
                        insertStudentSurvey.Parameters.Add(new SqlParameter("@Comments", HttpUtility.HtmlEncode(txtComments.Text)));
                        insertStudentSurvey.Parameters.Add(new SqlParameter("@StudentID", studentID));
                        insertStudentSurvey.ExecuteNonQuery();



                        Response.Redirect("StudentSurveyConfirmation.aspx");





                    }




                }



            }




            

        }

        public static bool IsValidEmail(string email)
        {
            

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}