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
using System.Security.Cryptography;

namespace Lab1
{
    public partial class VolunteerInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //populate the drop down lists 
            ddlVolunteers.Items.Add("Choose One");

            string sqlQueryVolunteer = "Select LastName FROM Volunteer";

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.Connection = sqlConnect;
            sqlCommand1.CommandType = CommandType.Text;
            sqlCommand1.CommandText = sqlQueryVolunteer;

            SqlCommand sqlCommand2 = new SqlCommand();
            sqlCommand2.Connection = sqlConnect;
            sqlCommand2.CommandType = CommandType.Text;
            sqlCommand2.CommandText = sqlQueryVolunteer;

            sqlConnect.Open();
            SqlDataReader queryResultsVolunteer = sqlCommand1.ExecuteReader();

            while (queryResultsVolunteer.Read())
            {
                string LastName = queryResultsVolunteer["LastName"].ToString();
                ddlVolunteers.Items.Add(queryResultsVolunteer["LastName"].ToString());

            }

            queryResultsVolunteer.Close();
            sqlConnect.Close();



        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            // clear out the other table(s) that are not being selected/viewed
            lblCompleteRoster.Visible = false;
            gvCompleteRoster.Visible = false;

            lblSelectedVolunteerInfo.Visible = true;
            lblSelectedVolunteerEvents.Visible = true;
            gvVolunteerEvents.Visible = true;
            gvVolunteerRoster.Visible = true;

            DropDownlistHandler(ddlVolunteers.SelectedIndex);

            //Validation if user doesnt select a volunteer from the drop down 
            if (ddlVolunteers.SelectedItem.ToString() == "Choose One")
            {
                lblError.Text = "Please select a coordinator from the list!";
                lblCompleteRoster.Visible = false;
                gvCompleteRoster.Visible = false;

                lblSelectedVolunteerInfo.Visible = false;
                lblSelectedVolunteerEvents.Visible = false;
                gvVolunteerEvents.Visible = false;
                gvVolunteerRoster.Visible = false;
                DropDownlistHandler(0);

            }
            else
            {
                //Get the selected volunteer's ID from the DB
                string currentVolunteerLastName = ddlVolunteers.SelectedValue.ToString();
                String sqlQueryVolunteerID = "SELECT VolunteerID FROM Volunteer WHERE LastName = @LastName";
                SqlConnection sqlConnectVolunteerID = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
                SqlCommand sqlCommandVolunteerID = new SqlCommand();
                sqlCommandVolunteerID.Connection = sqlConnectVolunteerID;
                sqlCommandVolunteerID.CommandType = CommandType.Text;
                sqlCommandVolunteerID.CommandText = sqlQueryVolunteerID;

                sqlCommandVolunteerID.Parameters.AddWithValue("@LastName", currentVolunteerLastName);

                //Open the DB connection and send the query
                sqlConnectVolunteerID.Open();
                SqlDataReader queryResultsVolunteerID = sqlCommandVolunteerID.ExecuteReader();
                queryResultsVolunteerID.Read();

                //Retrieve the results
                string currentVolunteerID = queryResultsVolunteerID["VolunteerID"].ToString();
                sqlConnectVolunteerID.Close();


                lblSelectedVolunteerInfo.Visible = true;
                lblSelectedVolunteerEvents.Visible = true;

                //use gridview to display the selected volunteer's information
                using (SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString()))
                {
                    sqlCon.Open();
                    string sqlCommand = "SELECT FirstName, LastName, EmailAddress, PhoneNumber, TShirtSize, TSHirtColor, TShirtDescription FROM Volunteer WHERE LastName =  " + "'" + currentVolunteerLastName + "'";
                    SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCommand, sqlCon);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    gvVolunteerRoster.DataSource = dtbl;
                    gvVolunteerRoster.DataBind();
                    sqlCon.Close();



                }
                // use gridview to display the selected volunteer's assigned events
                using (SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString()))
                {


                    sqlCon.Open();
                    //Use a INNER JOIN on all of the events associated with each volunteer
                    string sqlCommand = "SELECT e.EventName, e.DateTime, e.Location FROM EventVolunteer ev INNER JOIN Volunteer v ON v.VolunteerID = ev.VolunteerID AND v.VolunteerID = " + "'" + currentVolunteerID + "'" + " INNER JOIN Event e ON v.VolunteerID = ev.VolunteerID AND ev.EventID = e.EventID";
                    SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCommand, sqlCon);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    gvVolunteerEvents.DataSource = dtbl;
                    gvVolunteerEvents.DataBind();
                    sqlCon.Close();



                }




                lblError.Text = "";

            }





        }

        public void DropDownlistHandler(int volunteerIndex)
        {
            //populate the drop down lists 
            ddlVolunteers.Items.Clear();
            ddlVolunteers.Items.Add("Choose One");

            string sqlQueryVolunteer = "Select LastName FROM Volunteer";

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.Connection = sqlConnect;
            sqlCommand1.CommandType = CommandType.Text;
            sqlCommand1.CommandText = sqlQueryVolunteer;

            SqlCommand sqlCommand2 = new SqlCommand();
            sqlCommand2.Connection = sqlConnect;
            sqlCommand2.CommandType = CommandType.Text;
            sqlCommand2.CommandText = sqlQueryVolunteer;

            sqlConnect.Open();
            SqlDataReader queryResultsVolunteer = sqlCommand1.ExecuteReader();

            while (queryResultsVolunteer.Read())
            {
                string LastName = queryResultsVolunteer["LastName"].ToString();
                ddlVolunteers.Items.Add(queryResultsVolunteer["LastName"].ToString());

            }

            queryResultsVolunteer.Close();
            sqlConnect.Close();


            ddlVolunteers.SelectedIndex = volunteerIndex;


        }

        //Display a complete list of all volunteers in the DB
        protected void btnRoster_Click(object sender, EventArgs e)
        {
            DropDownlistHandler(0);
            lblCompleteRoster.Visible = true;
            gvCompleteRoster.Visible = true;

            lblSelectedVolunteerInfo.Visible = false;
            lblSelectedVolunteerEvents.Visible = false;
            gvVolunteerEvents.Visible = false;
            gvVolunteerRoster.Visible = false;

            //use the sql connection to fill the gridview
            using (SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString()))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT FirstName, LastName, EmailAddress, PhoneNumber, TShirtSize, TSHirtColor, TShirtDescription FROM Volunteer", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                gvCompleteRoster.DataSource = dtbl;
                gvCompleteRoster.DataBind();
                sqlCon.Close();



            }




        }
    }
}