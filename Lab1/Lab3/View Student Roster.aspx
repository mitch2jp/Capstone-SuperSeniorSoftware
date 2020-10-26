<%@ Page Title="Jake Mitchell - View Student Roster Page" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="View Student Roster.aspx.cs" Inherits="Lab3.View_Student_Roster" %>
<%--Jake Mitchell
Section 0002
10/3/2020--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="pageInstructions" runat="server" Text="Current (live) student roster: "></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>

            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>

    <asp:GridView ID="gvStudentRoster" runat="server" AutoGenerateColumns="false" >
        <Columns>
            <asp:BoundField DataField ="StudentID" HeaderText="StudentID" />
            <asp:BoundField DataField ="FirstName" HeaderText="First Name" />
            <asp:BoundField DataField ="LastName" HeaderText="Last Name" />
            <asp:BoundField DataField ="Age" HeaderText="Age" />
            <asp:BoundField DataField ="Notes" HeaderText="Notes" />
            <asp:BoundField DataField ="LunchTicket" HeaderText="Lunch Ticket?" />
            <asp:BoundField DataField ="TShirtSize" HeaderText ="T-Shirt Size" />
            <asp:BoundField DataField ="TShirtColor" HeaderText ="T-Shirt Color" />
            <asp:BoundField DataField ="TShirtDescription" HeaderText="T-Shirt Description" />
            <asp:BoundField DataField ="SchoolID" HeaderText="SchoolID" />
            <asp:BoundField DataField ="TeacherID" HeaderText="TeacherID" />
            <asp:BoundField DataField ="EventID" HeaderText="EventID" />

        </Columns>

    </asp:GridView>


</asp:Content>
