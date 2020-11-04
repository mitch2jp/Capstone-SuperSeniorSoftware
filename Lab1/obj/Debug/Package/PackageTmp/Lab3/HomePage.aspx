<%@ Page Title="Jake Mitchell - Home Page" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Lab3.HomePage1" %>
<%--Jake Mitchell
Section 0002
10/3/2020--%>    

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table runat="server" >
        <asp:TableRow >
            <asp:TableCell>
                <asp:button runat="server" text="SUPERSENIOR" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:button runat="server" text="SUPERSENIOR2" />
            </asp:TableCell>
        </asp:TableRow>
        </asp:Table>
    <asp:Table runat="server" GridLines="Both" HorizontalAlign="Center" CellSpacing="5" Height="309px" Width="424px"  >

        <asp:TableRow >
            <asp:TableCell>
                <asp:Label ID="lblStudent" runat="server" Text="Students:  " Font-Bold="true"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnAddStudent" runat="server" Text="Add a Student" PostBackUrl="~/Add a Student Page.aspx" Width ="200" Height="40" />
                <br />
                <asp:Button ID="btnViewStudentRoster" runat="server" Text="View Student Roster" PostBackUrl="~/View Student Roster.aspx" Width ="200" Height="40" />
                <br />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell Width="200">
                <asp:Label ID="lblEvents" runat="server" Text="Events:  " Font-Bold="true"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnEventInfo" runat="server" Text="Event Information" PostBackUrl="~/Event Information.aspx" Width="200" Height="40" />
                <br />
                <asp:Button ID="btnEventSignUp" runat="server" Text="Event Sign Up" PostBackUrl="~/Event Sign Up Page.aspx" Width="200" Height="40" />
            </asp:TableCell>
        </asp:TableRow>


        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblTeachers" runat="server" Text="Teachers: " Font-Bold="true"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnViewTeacherRoster" runat="server" Text="View Teacher Roster" PostBackUrl="~/View Teacher Roster.aspx" Width="200" Height="40" />
                <br />
                <asp:Button ID="btnCreateTeacher" runat="server" Text="Create a Teacher Account" PostBackUrl="~/Add a Teacher.aspx" Width="200" Height="40" />
                <br />
                <asp:Button ID="btnEditStudent" runat="server" Text="Edit Student Information" PostBackUrl="~/EditStudentInfo.aspx" Width="200" Height="40" OnClick="btnEditStudent_Click" />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblVolunteers" runat="server" Text="Volunteers: " Font-Bold="true"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnViewVolunteerRoster" runat="server" Text="Volunteer Information" PostBackUrl="~/VolunteerInformation.aspx" Width="200" Height="40" />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblCoordinator" runat="server" Text="Coordinators: " Font-Bold="true"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnViewCoordinatorRoster" runat="server" Text="Coordinator Information" PostBackUrl="~/CoordinatorInformation.aspx" Width="200" Height="40" />
            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>

      



</asp:Content>
