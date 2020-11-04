<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="StudentDashboard.aspx.cs" Inherits="Lab1.StudentDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
        <div class="container">
            <div class="row">
                    <div class="col-12">
                        <center>
                        <h2 style="border:1px groove #000000">Student Dashboard: </h2>
                        <p><b></b></p>
                        </center>
                    </div>
                </div>
                <br />
                <br />

            <div class="row">
                <div class="col-md-4">
                    <center>
                        <h2>Chat With Volunteers:</h2>
                        <img width="150px" height="150px" src="Images/chat.png" />
                        <br />
                        <br />
                    <h4>
                        <asp:Button ID="btnCreateEvent" CssClass="btn btn-primary btn-block" runat="server" Text="Get Help" PostBackUrl="~/StudentChat.aspx" OnClick="btnCreateEvent_Click" />
                    </h4>
                    <p class="text-justify">  
                    </p>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <h2>View Event Information:</h2>
                        <img width="150px" height="150px" src="Images/Itinerary_schedule.png" />
                        <br />
                        <br />
                    <h4>
                        <asp:Button ID="btnViewEventInfo" CssClass="btn btn-primary btn-block" PostBackUrl="~/StudentEventInformation.aspx" runat="server" Text="Event Information" OnClick="btnViewEventInfo_Click" />
                    </h4>
                    <p class="text-justify">
                    </p>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <h2>Upload Projects:</h2>
                        <img width="150px" height="150px" src="Images/upload_folder.png" />
                        
                        <br />
                        <br />
                    <h4>
                        <asp:Button ID="btnItinerary" CssClass="btn btn-primary btn-block" runat="server" PostBackUrl="~/UploadProjects.aspx" Text="Submit Projects" OnClick="btnItinerary_Click" />
                    </h4>
                    <p class="text-justify"></p>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <h2>Exit Survey:</h2>
                        <img width="150px" height="150px" src="Images/survey.png" />
                        <br />
                        <br />
                    <h4>
                        <asp:Button ID="btnSurvey" CssClass="btn btn-primary btn-block" runat="server" Text="Complete Survey" PostBackUrl="~/StudentSurvey.aspx" OnClick="btnItinerary_Click" />
                    </h4>
                    <p class="text-justify"></p>
                    </center>
                </div>
            </div>
        </div>
    </section>




</asp:Content>
