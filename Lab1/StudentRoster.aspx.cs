using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Security.Cryptography;
using System.Configuration;

namespace Lab1
{
    public partial class StudentRoster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "SELECT s.FirstName, s.LastName, s.Age, s.Gender, s.Notes, s.MealTicket, s.PhotoAuthorization, s.PriorParticipation, sc.SchoolName, t.LastName" +
                " FROM Student s, School sc, Teacher t" +
                " WHERE s.SchoolID = sc.SchoolID AND s.TeacherID = t.TeacherID";

            grdStudentRoster.DataSource = this.GetData(sql);
            grdStudentRoster.DataBind();

           



        }

        public DataTable GetData(string sql)
        {
            string db = ConfigurationManager.ConnectionStrings["CyberDay_AWS"].ToString();

            using (SqlConnection con = new SqlConnection(db))
            {
                using (SqlCommand cmd = new SqlCommand(sql))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.Connection = con;
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        ViewState["dtbl"] = dt;
                        return dt;

                    }

                }

            }

        }

        protected void grdStudentRoster_Sorting(object sender, GridViewSortEventArgs e)
        {


            DataTable dt = ViewState["dtbl"] as DataTable;
            dt.DefaultView.Sort = e.SortExpression;
            grdStudentRoster.DataSource = dt;
            grdStudentRoster.DataBind();



        }
    }
}