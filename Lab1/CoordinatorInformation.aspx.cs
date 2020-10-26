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
    public partial class CoordinatorInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //populate the drop down lists 
            ddlCoordinators.Items.Add("Choose One");

            string sqlQueryCoordinator = "Select LastName FROM Coordinator";

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.Connection = sqlConnect;
            sqlCommand1.CommandType = CommandType.Text;
            sqlCommand1.CommandText = sqlQueryCoordinator;

            SqlCommand sqlCommand2 = new SqlCommand();
            sqlCommand2.Connection = sqlConnect;
            sqlCommand2.CommandType = CommandType.Text;
            sqlCommand2.CommandText = sqlQueryCoordinator;

            sqlConnect.Open();
            SqlDataReader queryResultsCoordinator = sqlCommand1.ExecuteReader();

            while (queryResultsCoordinator.Read())
            {
                string LastName = queryResultsCoordinator["LastName"].ToString();
                ddlCoordinators.Items.Add(queryResultsCoordinator["LastName"].ToString());

            }

            queryResultsCoordinator.Close();
            sqlConnect.Close();

        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            // clear out the other table(s) that are not being selected/viewed
            lblCompleteRoster.Visible = false;
            gvCompleteRoster.Visible = false;

            lblSelectedCoordinatorInfo.Visible = true;
            lblSelectedCoordinatorEvents.Visible = true;
            gvCoordinatorEvents.Visible = true;
            gvCoordinatorRoster.Visible = true;

            DropDownlistHandler(ddlCoordinators.SelectedIndex);

            //Validation if user doesnt select a coordinator from the drop down 
            if (ddlCoordinators.SelectedItem.ToString() == "Choose One")
            {

                lblError.Text = "Please select a coordinator from the list!";
                lblCompleteRoster.Visible = false;
                gvCompleteRoster.Visible = false;

                lblSelectedCoordinatorInfo.Visible = false;
                lblSelectedCoordinatorEvents.Visible = false;
                gvCoordinatorEvents.Visible = false;
                gvCoordinatorRoster.Visible = false;
                DropDownlistHandler(0);

            }
            else
            {
                //get the selected coordinator's ID from the DB
                string currentCoordinatorLastName = ddlCoordinators.SelectedValue.ToString();
                String sqlQueryCoordinatorID = "SELECT CoordinatorID FROM Coordinator WHERE LastName = @LastName";
                SqlConnection sqlConnectCoordinatorID = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
                SqlCommand sqlCommandCoordinatorID = new SqlCommand();
                sqlCommandCoordinatorID.Connection = sqlConnectCoordinatorID;
                sqlCommandCoordinatorID.CommandType = CommandType.Text;
                sqlCommandCoordinatorID.CommandText = sqlQueryCoordinatorID;
                sqlCommandCoordinatorID.Parameters.AddWithValue("@LastName", currentCoordinatorLastName);

                //Open the DB connection and send the query
                sqlConnectCoordinatorID.Open();
                SqlDataReader queryResultsCoordinatorID = sqlCommandCoordinatorID.ExecuteReader();
                queryResultsCoordinatorID.Read();

                //Retrieve the results
                string currentCoordinatorID = queryResultsCoordinatorID["CoordinatorID"].ToString();
                sqlConnectCoordinatorID.Close();


                lblSelectedCoordinatorInfo.Visible = true;
                lblSelectedCoordinatorEvents.Visible = true;

                //use gridview to display selected coordinator's information 
                using (SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString()))
                {
                    sqlCon.Open();
                    string sqlCommand = "SELECT c.FirstName, c.LastName, c.EmailAddress, c.PhoneNumber, c.TShirtSize,c.TSHirtColor,c.TShirtDescription FROM Coordinator c WHERE c.LastName = " + "'" + currentCoordinatorLastName + "'";
                    SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCommand, sqlCon);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    gvCoordinatorRoster.DataSource = dtbl;
                    gvCoordinatorRoster.DataBind();
                    sqlCon.Close();



                }
                //use gridview to display a list of all of the selected coordinators assigned events
                using (SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString()))
                {


                    sqlCon.Open();
                    //Use a INNER JOIN for all of the coordinator's associated events
                    string sqlCommand = "SELECT e.EventName, e.DateTime, e.Location FROM EventCoordinator ec INNER JOIN Coordinator c ON c.CoordinatorID = ec.CoordinatorID AND c.CoordinatorID = " + "'" + currentCoordinatorID + "'" + "INNER JOIN Event e ON c.CoordinatorID = ec.CoordinatorID AND ec.EventID = e.EventID";
                    SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCommand, sqlCon);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    gvCoordinatorEvents.DataSource = dtbl;
                    gvCoordinatorEvents.DataBind();
                    sqlCon.Close();



                }




                lblError.Text = "";

            }

            

            
            



        }
        public void DropDownlistHandler(int coordinatorIndex)
        {
            //populate the drop down lists 
            ddlCoordinators.Items.Clear();
            ddlCoordinators.Items.Add("Choose One");

            string sqlQueryCoordinator = "Select LastName FROM Coordinator";

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.Connection = sqlConnect;
            sqlCommand1.CommandType = CommandType.Text;
            sqlCommand1.CommandText = sqlQueryCoordinator;

            SqlCommand sqlCommand2 = new SqlCommand();
            sqlCommand2.Connection = sqlConnect;
            sqlCommand2.CommandType = CommandType.Text;
            sqlCommand2.CommandText = sqlQueryCoordinator;

            sqlConnect.Open();
            SqlDataReader queryResultsCoordinator = sqlCommand1.ExecuteReader();

            while (queryResultsCoordinator.Read())
            {
                string LastName = queryResultsCoordinator["LastName"].ToString();
                ddlCoordinators.Items.Add(queryResultsCoordinator["LastName"].ToString());

            }

            queryResultsCoordinator.Close();
            sqlConnect.Close();

            ddlCoordinators.SelectedIndex = coordinatorIndex;
           

        }

        //Display a complete list of all volunteers in the DB
        protected void btnRoster_Click(object sender, EventArgs e)
        {
            DropDownlistHandler(0);
            lblCompleteRoster.Visible = true;
            gvCompleteRoster.Visible = true;

            lblSelectedCoordinatorInfo.Visible = false;
            lblSelectedCoordinatorEvents.Visible = false;
            gvCoordinatorEvents.Visible = false;
            gvCoordinatorRoster.Visible = false;

            //use the sql connection to fill the gridview
            using (SqlConnection sqlCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString()))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT FirstName, LastName, EmailAddress, PhoneNumber, TShirtSize, TSHirtColor, TShirtDescription FROM Coordinator", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                gvCompleteRoster.DataSource = dtbl;
                gvCompleteRoster.DataBind();
                sqlCon.Close();



            }

        }

    }
    
}