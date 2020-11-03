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
                        <h2>Chat With Students</h2>
                        <img width="150px" height="150px" src="Images/chat.jpg" />
                    <h4>
                        <asp:Button ID="btnCreateEvent" CssClass="btn btn-primary btn-block" runat="server" Text="Chat with Students" PostBackUrl="~/VolunteerChat.aspx" OnClick="btnCreatEvent_Click" />
                    </h4>
                    <p class="text-justify">  
                    </p>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <h2>View Event Information</h2>
                        <img width="150px" height="150px" src="Images/list.jpg" />
                    <h4>
                        <asp:Button ID="btnViewEventInfo" CssClass="btn btn-primary btn-block" PostBackUrl="~/VolunteerEventInformation.aspx" runat="server" Text="Event Information" OnClick="btnViewEventInfo_Click" />
                    </h4>
                    <p class="text-justify">
                    </p>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <h2>Edit Profile</h2>
                        <img width="250px" height="150px" src="Images/user-profile.jpg" />
                    <h4>
                        <asp:Button ID="btnItinerary" CssClass="btn btn-primary btn-block" runat="server" PostBackUrl="~/CreateVolunteer.aspx" Text="Edit Profile" />
                    </h4>
                    <p class="text-justify"></p>
                    </center>
                </div>
            </div>
        </div>
    </section>

    
</asp:Content>
