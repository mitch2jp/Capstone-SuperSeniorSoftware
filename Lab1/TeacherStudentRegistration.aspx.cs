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
    public partial class TeacherStudentRegistration : System.Web.UI.Page
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

        }
    }
}