<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="VolunteerDashboard.aspx.cs" Inherits="Lab1.VolunteerDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<section>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                    <h2>Volunteer Dashboard: </h2>
                    <p><b></b></p>
                    </center>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <center>
                        <h2>Create an Event</h2>
                        <img width="150px" height="150px" src="Images/new-event.png" />
                    <h4>
                        <asp:Button ID="btnCreateEvent" CssClass="btn btn-primary btn-block" runat="server" Text="Create Event" PostBackUrl="~/CreateEvent.aspx" OnClick="btnCreatEvent_Click" />
                    </h4>
                    <p class="text-justify">  
                    </p>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <h2>Event Information</h2>
                        <img width="150px" height="150px" src="Images/list.jpg" />
                    <h4>
                        <asp:Button ID="btnViewEventInfo" CssClass="btn btn-primary btn-block" runat="server" Text="View Event Information" OnClick="btnViewEventInfo_Click" />
                    </h4>
                    <p class="text-justify">
                    </p>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <h2>Itinerary</h2>
                        <img width="150px" height="150px" src="Images/itinerary.png" />
                    <h4>
                        <asp:Button ID="btnItinerary" CssClass="btn btn-primary btn-block" runat="server" Text="View Itinerary" />
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
</asp:Content>
