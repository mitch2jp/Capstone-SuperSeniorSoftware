<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="TeacherDashboard.aspx.cs" Inherits="Lab1.TeacherDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                    <h2 style="border:1px groove #000000">Teacher Dashboard: </h2>
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
                        <h2>Register Student</h2>
                        <img width="150px" height="150px" src="Images/register_student.png" />
                        <br />
                        <br />
                        <p class="text-justify"> Begin registering your students for CyberDay!   </p>
                        <br />
                   
                    <h4>
                        <asp:Button ID="btnRegisterStudent" CssClass="btn btn-primary btn-block" PostBackUrl="~/TeacherStudentRegistration.aspx" runat="server" Text="Register Student"  />
                    </h4>
                    
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <h2>Validate Parent(s)</h2>
                        <img width="150px" height="150px" src="Images/validation.png" />
                        <br />
                        <br />
                        <p class="text-justify">Verify your student's parents for registration authorization</p>
                        <br />
                   
                    <h4>
                        <asp:Button ID="btnValidateParents" CssClass="btn btn-primary btn-block" PostBackUrl="~/TeacherValidateParents.aspx" runat="server" Text="Validate Parent Registration(s)"  />
                    </h4>
                    
                    </center>
                </div>

                <div class="col-md-4">
                    <center>
                        <h2>Itinerary</h2>
                        <img width="150px" height="150px" src="Images/Itinerary_schedule.png" />
                        <br />
                        <br />
                        <p class="text-justify">View the current CyberDay itinerary! </p>
                        <br />
                    <h4>
                        <asp:Button ID="btnViewEventInfo" CssClass="btn btn-primary btn-block" PostBackUrl="~/TeacherItinerary.aspx" runat="server" Text="Event Information "  />
                    </h4>
                    <p class="text-justify"></p>
                    
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <h2>Edit Profile</h2>
                        <img width="150px" height="150px" src="Images/edit-profile.png" />
                        <br />
                        <br />
                        <p class="text-justify">Edit, update and change your account information!</p>

                    <h4>
                        <asp:Button ID="btnEditProfile" CssClass="btn btn-primary btn-block" runat="server" PostBackUrl="~/EditTeacherProfile.aspx" Text="Edit Profile" />
                    </h4>
                    
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <h2>Class Roster</h2>
                        <img width="150px" height="150px" src="Images/student-roster.png" />
                        <br />
                        <br />
                        <p class="text-justify">View, edit and manage your student's CyberDay information!</p>
                    <h4>
                        <asp:Button ID="btnClassRoster" CssClass="btn btn-primary btn-block" runat="server" PostBackUrl="~/ClassRoster.aspx" Text="View Class Roster" />
                    </h4>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <h2>Chaperone Roster</h2>
                        <img width="150px" height="150px" src="Images/volunteer-list.png" />
                        <br />
                        <br />
                        <p class="text-justify">View, Edit and Manage your class chaperones for CyberDay!</p>
                    <h4>
                        <asp:Button ID="btnChaperoneRoster" CssClass="btn btn-primary btn-block" PostBackUrl="~/TeacherChaperoneRoster.aspx" runat="server" Text="View Chaperone Roster" />
                    </h4>
                    </center>
                </div>

            </div>
        </div>
    </section>
    <br />
    <br />

    

</asp:Content>
