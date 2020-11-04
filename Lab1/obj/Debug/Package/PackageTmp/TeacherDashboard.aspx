<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="TeacherDashboard.aspx.cs" Inherits="Lab1.TeacherDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                    <h2>Teacher Dashboard: </h2>
                    <p><b></b></p>
                    </center>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <center>
                        <h2>Register Student</h2>
                        <img width="150px" height="150px" src="Images/new-event.png" />
                    <h4>
                        <asp:Button ID="btnRegisterStudent" CssClass="btn btn-primary btn-block" PostBackUrl="~/TeacherStudentRegistration.aspx" runat="server" Text="Register Student"  />
                    </h4>
                    <p class="text-justify">  
                    </p>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <h2>View Event Information:</h2>
                        <img width="150px" height="150px" src="Images/list.jpg" />
                    <h4>
                        <asp:Button ID="btnViewEventInfo" CssClass="btn btn-primary btn-block" PostBackUrl="~/EventInformation.aspx" runat="server" Text="Event Information "  />
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
                        <asp:Button ID="btnEditProfile" CssClass="btn btn-primary btn-block" runat="server" PostBackUrl="~/EditTeacherProfile.aspx" Text="Edit Profile" />
                    </h4>
                    <p class="text-justify"></p>
                    </center>
                </div>
            </div>
        </div>
    </section>

    

</asp:Content>
