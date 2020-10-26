<%@ Page Title="Jake Mitchell - View Teacher Roster Page" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="View Teacher Roster.aspx.cs" Inherits="Lab3.View_Teacher_Roster" %>
<%--Jake Mitchell
Section 0002
10/3/2020--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="pageInstructions" runat="server" Text="Current Teacher Roster: "></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>

            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>

    <asp:GridView ID="gvTeacherRoster" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField ="FirstName" HeaderText="First Name" />
            <asp:BoundField DataField ="LastName" HeaderText="Last Name" />
            <asp:BoundField DataField ="GradeTaught" HeaderText="Grade Taught" />
            <asp:BoundField DataField ="EmailAddress" HeaderText="Email Address" />
            <asp:BoundField DataField ="LunchTicket" HeaderText ="Lunch Ticket ?" />
            <asp:BoundField DataField ="TShirtSize" HeaderText ="T-Shirt Size" />
            <asp:BoundField DataField ="TShirtColor" HeaderText ="T-Shirt Color" />
            <asp:BoundField DataField ="TShirtDescription" HeaderText="T-Shirt Description" />
        </Columns>

    </asp:GridView>

</asp:Content>
