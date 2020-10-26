using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using Microsoft.Ajax.Utilities;
using System.Security.Cryptography;

namespace Lab3
{
    //Jake Mitchell
    //Section 0002
    //10/14/2020
    public partial class Event_Sign_Up_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnAssign_Click(object sender, EventArgs e)
        {
            //determine which button is checked before assignment/processing
            if (rdobtnStudent.Checked == true)
            {

                //Validate to see if the currently selected student is already signed up for the currently selected event
                if (rdobtnStudent.Checked == true)
                {
                    string sqlQueryCheck = "SELECT COUNT(1) FROM EventAttendance WHERE EventName = @EventName AND StudentLastName = @StudentLastName";
                    SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
                    SqlCommand sqlCommand = new SqlCommand(sqlQueryCheck, sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@EventName", ddlEvent.SelectedValue.ToString());
                    sqlCommand.Parameters.AddWithValue("@StudentLastName", ddlParticipant.SelectedValue.ToString());

                    sqlConnection.Open();


                    int count = Convert.ToInt32(sqlCommand.ExecuteScalar());

                    sqlConnection.Close();

                    if (count == 1)
                    {
                        lblSuccess.Text = "";
                        lblError.Text = "Student is already signed up for the " + "'" + ddlEvent.SelectedValue.ToString() + "'" + " Event !";


                    }
                    //if not, sign them up for the selected event
                    else
                    {
                        //Retrieve the selected student's studentID from the DB
                        string participantLastName = ddlParticipant.Text;
                        String sqlQueryStudentID = "SELECT StudentID FROM Student WHERE LastName = " + "'" + participantLastName + "'";

                        SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
                        SqlCommand sqlCommandStudent = new SqlCommand();
                        sqlCommandStudent.Connection = sqlConnect;
                        sqlCommandStudent.CommandType = CommandType.Text;
                        sqlCommandStudent.CommandText = sqlQueryStudentID;

                        //Open the DB connection and send the query
                        sqlConnect.Open();
                        SqlDataReader queryResultsStudentID = sqlCommandStudent.ExecuteReader();
                        queryResultsStudentID.Read();

                        //Retrieve and store the StudentID
                        string currentStudentID = queryResultsStudentID["StudentID"].ToString();
                        sqlConnect.Close();



                        //Retrieve the associated Student's first name from the DB
                        string sqlQueryStudentFirstName = "SELECT FirstName FROM Student WHERE LastName = " + "'" + participantLastName + "'" + " AND StudentID = " + currentStudentID;

                        SqlConnection sqlConnectStudentFirstName = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
                        SqlCommand sqlCommandStudentFirstName = new SqlCommand();
                        sqlCommandStudentFirstName.Connection = sqlConnectStudentFirstName;
                        sqlCommandStudentFirstName.CommandType = CommandType.Text;
                        sqlCommandStudentFirstName.CommandText = sqlQueryStudentFirstName;

                        //Open the DB connection and send the query
                        sqlConnectStudentFirstName.Open();
                        SqlDataReader queryResultsStudentFirstName = sqlCommandStudentFirstName.ExecuteReader();
                        queryResultsStudentFirstName.Read();

                        //Retrieve and store the student's first name
                        string currentStudentFirstName = queryResultsStudentFirstName["FirstName"].ToString();
                        sqlConnectStudentFirstName.Close();



                        //Retrieve the selected event's EventID from the DB
                        string eventName = ddlEvent.Text;
                        String sqlQueryEventID = "SELECT EventID FROM Event WHERE EventName = " + "'" + eventName + "'";

                        SqlConnection sqlConnectEvent = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
                        SqlCommand sqlCommandEvent = new SqlCommand();
                        sqlCommandEvent.Connection = sqlConnectEvent;
                        sqlCommandEvent.CommandType = CommandType.Text;
                        sqlCommandEvent.CommandText = sqlQueryEventID;

                        //Open the DB connection and send the query
                        sqlConnectEvent.Open();
                        SqlDataReader queryResultsEventID = sqlCommandEvent.ExecuteReader();
                        queryResultsEventID.Read();

                        //Retrieve and store the EventID
                        string currentEventID = queryResultsEventID["EventID"].ToString();

                        sqlConnectEvent.Close();


                        //Create query string, define connection and object, fill DB INSERT statement with associated studentArray object data fields 
                        SqlConnection connection1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
                        SqlDataAdapter cmd = new SqlDataAdapter();
                        cmd.InsertCommand = new SqlCommand("INSERT INTO EventAttendance(StudentID, EventID, EventName, StudentFirstname, StudentLastName) VALUES(@StudentID, @EventID, @EventName, @StudentFirstName, @StudentLastName)");
                        cmd.InsertCommand.Connection = connection1;
                        cmd.InsertCommand.Parameters.AddWithValue("@StudentID", currentStudentID);
                        cmd.InsertCommand.Parameters.AddWithValue("@EventID", currentEventID);
                        cmd.InsertCommand.Parameters.AddWithValue("@EventName", eventName);
                        cmd.InsertCommand.Parameters.AddWithValue("@StudentFirstName", currentStudentFirstName);
                        cmd.InsertCommand.Parameters.AddWithValue("@StudentLastName", participantLastName);
                        connection1.Open();
                        cmd.InsertCommand.ExecuteNonQuery();
                        connection1.Close();

                        //Confirmation message if successful
                        lblError.Text = "";
                        lblSuccess.Text = "Student successfully assigned to " + "'" + ddlEvent.SelectedValue.ToString() + "'" + " Event!";



                    }

                }

            }
            else if (rdobtnVolunteer.Checked == true)
            {

                //Retrieve the EventID from the DB
                string eventName = ddlEvent.Text;
                String sqlQueryEventID = "SELECT EventID FROM Event WHERE EventName = " + "'" + eventName + "'";
                SqlConnection sqlConnectEvent = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
                SqlCommand sqlCommandEvent = new SqlCommand();
                sqlCommandEvent.Connection = sqlConnectEvent;
                sqlCommandEvent.CommandType = CommandType.Text;
                sqlCommandEvent.CommandText = sqlQueryEventID;

                //Open the DB connection and send the query
                sqlConnectEvent.Open();
                SqlDataReader queryResultsEventID = sqlCommandEvent.ExecuteReader();
                queryResultsEventID.Read();

                //Retrieve and store the EventID
                string currentEventID = queryResultsEventID["EventID"].ToString();
                sqlConnectEvent.Close();




                //Retrieve the VolunteerID from the DB
                string volunteerID = ddlParticipant.Text;
                String sqlQueryVolunteerID = "SELECT VolunteerID FROM Volunteer WHERE LastName = " + "'" + volunteerID + "'";
                SqlConnection sqlConnectVolunteerID = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
                SqlCommand sqlCommandVolunteerID = new SqlCommand();
                sqlCommandVolunteerID.Connection = sqlConnectVolunteerID;
                sqlCommandVolunteerID.CommandType = CommandType.Text;
                sqlCommandVolunteerID.CommandText = sqlQueryVolunteerID;

                //Open the DB connection and send the query
                sqlConnectVolunteerID.Open();
                SqlDataReader queryResultsVolunteerID = sqlCommandVolunteerID.ExecuteReader();
                queryResultsVolunteerID.Read();

                //Retrieve and store the volunteerID
                string currentVolunteerID = queryResultsVolunteerID["VolunteerID"].ToString();
                sqlConnectVolunteerID.Close();




                //Validate to see if the currently selected volunteer is already signed up for the currently selected event, OR if the volunteer is already signed up for 2 events
                if (rdobtnVolunteer.Checked == true)
                {
                    //send query counting the number of instances where the selected volunteer is signed up for the selected event
                    string sqlQueryCheck = "SELECT COUNT(1) FROM EventVolunteer WHERE EventID = @EventID AND VolunteerID = @VolunteerID";

                    SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
                    SqlCommand sqlCommand = new SqlCommand(sqlQueryCheck, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@EventID", currentEventID);
                    sqlCommand.Parameters.AddWithValue("@VolunteerID", currentVolunteerID);
                    sqlConnection.Open();


                    int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    sqlConnection.Close();




                    //send query counting the instances of the total number of events the selected volunteer is currently signed up for
                    string sqlQueryCheckEvents = "SELECT COUNT(2) FROM EventVolunteer WHERE VolunteerID = @VolunteerID";
                    SqlConnection sqlConnectionCheckEvents = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
                    SqlCommand sqlCommandCheckEvents = new SqlCommand(sqlQueryCheckEvents, sqlConnectionCheckEvents);

                    sqlCommandCheckEvents.Parameters.AddWithValue("@VolunteerID", currentVolunteerID);
                    sqlConnectionCheckEvents.Open();


                    int countEvents = Convert.ToInt32(sqlCommandCheckEvents.ExecuteScalar());
                    sqlConnectionCheckEvents.Close();


                    if (count == 1)
                    {
                        lblSuccess.Text = "";
                        lblError.Text = "Volunteer is already signed up for the " + "'" + ddlEvent.SelectedValue.ToString() + "'" + " Event !";


                    }
                    //if volunteer is already signed up for 2 events, don't process form 
                    else if (countEvents == 2)
                    {
                        lblSuccess.Text = "";
                        lblError.Text = "Volunteer is already signed up for 2 Events!";

                    }
                    else
                    {

                        //associate the selected volunteer to the selected event in the DB
                        SqlConnection connection1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
                        SqlDataAdapter cmd = new SqlDataAdapter();
                        cmd.InsertCommand = new SqlCommand("INSERT INTO EventVolunteer(EventID, VolunteerID) VALUES(@EventID, @VolunteerID)");
                        cmd.InsertCommand.Connection = connection1;


                        cmd.InsertCommand.Parameters.AddWithValue("@EventID", currentEventID);
                        cmd.InsertCommand.Parameters.AddWithValue("@VolunteerID", currentVolunteerID);

                        connection1.Open();
                        cmd.InsertCommand.ExecuteNonQuery();
                        connection1.Close();

                        lblError.Text = "";
                        lblSuccess.Text = "Volunteer successfully assigned to " + "'" + ddlEvent.SelectedValue.ToString() + "'" + " Event!";






                    }

                }

            }
            else
            {

                //Retrieve the EventID from the DB
                string eventName = ddlEvent.Text;
                String sqlQueryEventID = "SELECT EventID FROM Event WHERE EventName = " + "'" + eventName + "'";
                SqlConnection sqlConnectEvent = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
                SqlCommand sqlCommandEvent = new SqlCommand();
                sqlCommandEvent.Connection = sqlConnectEvent;
                sqlCommandEvent.CommandType = CommandType.Text;
                sqlCommandEvent.CommandText = sqlQueryEventID;

                //Open the DB connection and send the query
                sqlConnectEvent.Open();
                SqlDataReader queryResultsEventID = sqlCommandEvent.ExecuteReader();
                queryResultsEventID.Read();

                //Retrieve and store the EventID
                string currentEventID = queryResultsEventID["EventID"].ToString();
                sqlConnectEvent.Close();
                


                //Retrieve the CoordinatorID from the DB
                string CoordinatorID = ddlParticipant.Text;
                String sqlQueryCoordinatorID = "SELECT CoordinatorID FROM Coordinator WHERE LastName = " + "'" + CoordinatorID + "'";
                SqlConnection sqlConnectCoordinatorID = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
                SqlCommand sqlCommandCoordinatorID = new SqlCommand();
                sqlCommandCoordinatorID.Connection = sqlConnectCoordinatorID;
                sqlCommandCoordinatorID.CommandType = CommandType.Text;
                sqlCommandCoordinatorID.CommandText = sqlQueryCoordinatorID;

                //Open the DB connection and send the query
                sqlConnectCoordinatorID.Open();
                SqlDataReader queryResultsCoordinatorID = sqlCommandCoordinatorID.ExecuteReader();
                queryResultsCoordinatorID.Read();

                //Retrieve and store the CoordinatorID
                string currentCoordinatorID = queryResultsCoordinatorID["CoordinatorID"].ToString();
                sqlConnectCoordinatorID.Close();



                if (rdobtnCoordinator.Checked == true)
                {
                    //send query counting the number of instances where the selected coordinator is signed up for the selected event
                    string sqlQueryCheck = "SELECT COUNT(1) FROM EventCoordinator WHERE EventID = @EventID AND CoordinatorID = @CoordinatorID";
                    SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
                    SqlCommand sqlCommand = new SqlCommand(sqlQueryCheck, sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@EventID", currentEventID);
                    sqlCommand.Parameters.AddWithValue("@CoordinatorID", currentCoordinatorID);

                    sqlConnection.Open();


                    int count = Convert.ToInt32(sqlCommand.ExecuteScalar());

                    sqlConnection.Close();

                    if (count == 1)
                    {
                        lblSuccess.Text = "";
                        lblError.Text = "Coordinator is already signed up for the " + "'" + ddlEvent.SelectedValue.ToString() + "'" + " Event!";


                    }
                    else
                    {
                        //associate the selected coordinator to the selected event in the DB
                        SqlConnection connection1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());
                        SqlDataAdapter cmd = new SqlDataAdapter();
                        cmd.InsertCommand = new SqlCommand("INSERT INTO EventCoordinator(EventID, CoordinatorID) VALUES(@EventID, @CoordinatorID)");
                        cmd.InsertCommand.Connection = connection1;


                        cmd.InsertCommand.Parameters.AddWithValue("@EventID", currentEventID);
                        cmd.InsertCommand.Parameters.AddWithValue("@CoordinatorID", currentCoordinatorID);

                        connection1.Open();
                        cmd.InsertCommand.ExecuteNonQuery();
                        connection1.Close();

                        lblError.Text = "";
                        lblSuccess.Text = "Coordinator successfully assigned to " + "'" + ddlEvent.SelectedValue.ToString() + "'" + " Event!";



                    }

                }

            }

        }

        protected void rdobtnStudent_CheckedChanged(object sender, EventArgs e)
        {
            //populate ddl's accordingly if student is checked
            ddlEvent.Items.Clear();
            ddlParticipant.Items.Clear();

            string sqlQueryStudent = "Select * From Student";
            string sqlQueryEvent = "Select EventName FROM Event";

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());

            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.Connection = sqlConnect;
            sqlCommand1.CommandType = CommandType.Text;
            sqlCommand1.CommandText = sqlQueryStudent;

            SqlCommand sqlCommand2 = new SqlCommand();
            sqlCommand2.Connection = sqlConnect;
            sqlCommand2.CommandType = CommandType.Text;
            sqlCommand2.CommandText = sqlQueryEvent;

            sqlConnect.Open();
            SqlDataReader queryResultsStudent = sqlCommand1.ExecuteReader();
            SqlDataReader queryResultsEvent = sqlCommand2.ExecuteReader();

            while (queryResultsStudent.Read())
            {
                string lastName = queryResultsStudent["LastName"].ToString();
                ddlParticipant.Items.Add(lastName);


            }

            while (queryResultsEvent.Read())
            {
                string eventName = queryResultsEvent["EventName"].ToString();
                ddlEvent.Items.Add(eventName);


            }

            queryResultsStudent.Close();
            queryResultsEvent.Close();
            sqlConnect.Close();


            ddlEvent.SelectedIndex = 3;

        }

        protected void rdobtnVolunteer_CheckedChanged(object sender, EventArgs e)
        {

           
            // populate ddl's accordingly if volunteer is checked
            ddlParticipant.Items.Clear();
            ddlEvent.Items.Clear();

            string sqlQueryVolunteer = "Select * From Volunteer";
            string sqlQueryEvent = "Select EventName FROM Event";

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());

            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.Connection = sqlConnect;
            sqlCommand1.CommandType = CommandType.Text;
            sqlCommand1.CommandText = sqlQueryVolunteer;

            SqlCommand sqlCommand2 = new SqlCommand();
            sqlCommand2.Connection = sqlConnect;
            sqlCommand2.CommandType = CommandType.Text;
            sqlCommand2.CommandText = sqlQueryEvent;

            sqlConnect.Open();
            SqlDataReader queryResultsVolunteer = sqlCommand1.ExecuteReader();
            SqlDataReader queryResultsEvent = sqlCommand2.ExecuteReader();

            while (queryResultsVolunteer.Read())
            {
                string lastName = queryResultsVolunteer["LastName"].ToString();
                ddlParticipant.Items.Add(lastName);
            }

            while (queryResultsEvent.Read())
            {
                string eventName = queryResultsEvent["EventName"].ToString();
                ddlEvent.Items.Add(eventName);
            }

            queryResultsVolunteer.Close();
            queryResultsEvent.Close();
            sqlConnect.Close();

            ddlParticipant.SelectedIndex = 2;

        }

        protected void rdobtnCoordinator_CheckedChanged(object sender, EventArgs e)
        {
            //populate ddl's accordingly if coordinator is checked
            ddlEvent.Items.Clear();
            ddlParticipant.Items.Clear();

            string sqlQueryCoordinator = "Select * From Coordinator";
            string sqlQueryEvent = "Select EventName FROM Event";

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ToString());

            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.Connection = sqlConnect;
            sqlCommand1.CommandType = CommandType.Text;
            sqlCommand1.CommandText = sqlQueryCoordinator;

            SqlCommand sqlCommand2 = new SqlCommand();
            sqlCommand2.Connection = sqlConnect;
            sqlCommand2.CommandType = CommandType.Text;
            sqlCommand2.CommandText = sqlQueryEvent;

            sqlConnect.Open();
            SqlDataReader queryResultsCoordinator = sqlCommand1.ExecuteReader();
            SqlDataReader queryResultsEvent = sqlCommand2.ExecuteReader();

            while (queryResultsCoordinator.Read())
            {
                string lastName = queryResultsCoordinator["LastName"].ToString();
                ddlParticipant.Items.Add(lastName);
            }

            while (queryResultsEvent.Read())
            {
                string eventName = queryResultsEvent["EventName"].ToString();
                ddlEvent.Items.Add(eventName);
            }

            queryResultsCoordinator.Close();
            queryResultsEvent.Close();
            sqlConnect.Close();

            ddlParticipant.SelectedIndex = 3;

        }
    }
}