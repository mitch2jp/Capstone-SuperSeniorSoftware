<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="CoordinatorDashboard.aspx.cs" Inherits="Lab1.CoordinatorDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <section>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                    <h2 style="border:1px groove #000000">Coordinator Dashboard: </h2>
                    <p><b></b></p>
                    </center>
                </div>
            </div>

            <asp:Table ID="Table1" runat="server" Width="350" BorderStyle="Dashed">
                
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblUsername" Font-Size="Large" runat="server" Text=""></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblUser" Font-Size="Large" runat="server" Text=""></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Button ID="btnLogOut" CssClass="btn btn-danger btn-sm"  Width="100" OnClick="btnLogOut_Click" runat="server" Text="Log Out"  />
                    </asp:TableCell>
                </asp:TableRow>
                
            </asp:Table>
            <br />
            <br />


            <div class="row">
                <div class="col-md-4">
                    <center>
                        <h2>Create Event</h2>
                        <img width="150px" height="150px" src="Images/add-event.png" />
                        <br />
                        <br />
                    <h4>
                        <asp:Button ID="btnCreateEvent" CssClass="btn btn-primary btn-block" runat="server" Text="Create a New Event" PostBackUrl="~/CreateEvent.aspx" OnClick="btnCreatEvent_Click" />
                    </h4>
                    <p class="text-justify">  
                    </p>
                    </center>
                </div>
                
                <div class="col-md-4">
                    <center>
                        <h2>Itinerary</h2>
                        <img width="150px" height="150px" src="Images/Itinerary_schedule.png" />
                        <br />
                        <br />
                    <h4>
                        <asp:Button ID="btnItinerary" CssClass="btn btn-primary btn-block" runat="server" PostBackUrl="~/CoordinatorItinerary.aspx" Text="View Itinerary" />
                    </h4>
                    <p class="text-justify"></p>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <h2>Chat With Students</h2>
                        <img width="150px" height="150px" src="Images/chat.png" />
                        <br />
                        <br />
                    <h4>
                        <asp:Button ID="Button1" CssClass="btn btn-primary btn-block" runat="server" PostBackUrl="~/CoordinatorChat.aspx" Text="Chat With Students" />
                    </h4>
                    <p class="text-justify"></p>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <h2>Add Coordinator</h2>
                        <img width="150px" height="150px" src="Images/add-user1.png" />
                        <br />
                        <br />
                        
                    <h4>
                        <asp:Button ID="btnCreateCoordinator" CssClass="btn btn-primary btn-block" PostBackUrl="~/CreateCoordinator.aspx" runat="server" Text="Create a New Coordinator" />
                    </h4>
                    <p class="text-justify"></p>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <h2>Student Roster</h2>
                        <img width="150px" height="150px" src="Images/student-roster.png" />
                        <br />
                        <br />
                        
                    <h4>
                        <asp:Button ID="btnViewStudentRoster" CssClass="btn btn-primary btn-block" runat="server" PostBackUrl="~/StudentRoster.aspx" Text="View Student Roster" />
                    </h4>
                    <p class="text-justify"></p>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <h2>Volunteer Roster</h2>
                        <img width="150px" height="150px" src="Images/volunteer-list.png" />
                        <br />
                        <br />
                        
                    <h4>
                        <asp:Button ID="btnViewVolunteerRoster" CssClass="btn btn-primary btn-block" PostBackUrl="~/VolunteerRoster.aspx" runat="server" Text="View Volunteer Roster" />
                    </h4>
                    <p class="text-justify"></p>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <h2>Survey Results</h2>
                        <img width="150px" height="150px" src="Images/survey.png" />
                        <br />
                        <br />
                        
                    <h4>
                        <asp:Button ID="btnSurveyResults" CssClass="btn btn-primary btn-block" PostBackUrl="~/CoordinatorViewSurveyResults.aspx" runat="server" Text="View Survey Results" />
                    </h4>
                    <p class="text-justify"></p>
                    </center>
                </div>
            </div>
        </div>
    </section>

    <section>
        <div class="container-fluid" style="border:5px solid #461c87">
            <div class="row">
                <div class="col-12">
                    
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <center>
                        <p>[Insert Tableau analytics here]</p>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <p>[Insert Tableau analytics here]</p>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <p>[Insert Tableau analytics here]</p>
                    <p class="text-justify"></p>
                    </center>
                </div>
            </div>
        </div>
    </section>
    <br />
    <br />





</asp:Content>
