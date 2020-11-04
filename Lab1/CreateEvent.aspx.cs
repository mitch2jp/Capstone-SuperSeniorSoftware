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
    public partial class CreateEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (Session["CoordinatorUsername"] == null)
            //{
            //    Response.Redirect("CoordinatorLogin.aspx");

            //}

        }

        protected void calEvent_SelectionChanged(object sender, EventArgs e)
        {
            //lblFirstStatus.Text = calEvent.SelectedDate.ToLongDateString();
            //lblSecondStatus.Text = calEvent.SelectedDate.ToShortDateString();
            //lblThirdStatus.Text = calEvent.SelectedDate.ToString();

            txtDate.Text = calEvent.SelectedDate.ToShortDateString();


        }

        protected void calEvent_SelectionChanged1(object sender, EventArgs e)
        {
            txtDate.Text = calEvent.SelectedDate.ToShortDateString();

        }

        protected void btnCreateEvent_Click(object sender, EventArgs e)
        {


            if (Page.IsValid)
            {

                //validate to see if the newly added student is already in the DB
                string sqlQuery = "SELECT COUNT(1) FROM Event WHERE EventName = @EventName";
                SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_AWS"].ToString());
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@EventName", HttpUtility.HtmlEncode(txtEventName.Text));

                sqlConnection.Open();
                int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                sqlConnection.Close();




                if (count == 1)
                {
                    lblStatus.ForeColor = Color.Red;
                    lblStatus.Text = "This event has already been created!";

                }
                else
                {

                    //Create query string, define connection and object, fill DB INSERT statements 
                    SqlConnection connection1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["CyberDay_AWS"].ToString());
                    SqlDataAdapter cmd = new SqlDataAdapter();
                    cmd.InsertCommand = new SqlCommand("INSERT INTO Event(EventName, Date, Time, Building, Room, VolunteerInstructions, EventDescription) VALUES(@EventName, @Date, @Time, @Building, @Room, @VolunteerInstructions, @EventDescription)");
                    cmd.InsertCommand.Connection = connection1;


                    cmd.InsertCommand.Parameters.AddWithValue("@EventName", HttpUtility.HtmlEncode(txtEventName.Text));
                    cmd.InsertCommand.Parameters.AddWithValue("@Date", HttpUtility.HtmlEncode(txtDate.Text));
                    cmd.InsertCommand.Parameters.AddWithValue("@Time", HttpUtility.HtmlEncode(txtEventTime.Text));
                    cmd.InsertCommand.Parameters.AddWithValue("@Building", HttpUtility.HtmlEncode(ddlBuilding.Text));
                    cmd.InsertCommand.Parameters.AddWithValue("@Room", HttpUtility.HtmlEncode(txtRoom.Text));
                    cmd.InsertCommand.Parameters.AddWithValue("@VolunteerInstructions", HttpUtility.HtmlEncode(txtVolunteerInstructions.Text));
                    cmd.InsertCommand.Parameters.AddWithValue("@EventDescription", HttpUtility.HtmlEncode(txtEventDescription.Text));

                    connection1.Open();
                    cmd.InsertCommand.ExecuteNonQuery();
                    connection1.Close();

                    Response.Redirect("CreateEventSuccess.aspx");


                }




            }



        }

        protected void rdoYes_CheckedChanged(object sender, EventArgs e)
        {

            divVolunteerInstructions.Visible = true;

        }

        protected void rdoNo_CheckedChanged(object sender, EventArgs e)
        {
            divVolunteerInstructions.Visible = false;


        }

        protected void valRadioButtons_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = rdoYes.Checked || rdoNo.Checked;

        }
    }
}