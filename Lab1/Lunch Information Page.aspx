﻿<%@ Page Title="Jake Mitchell - Lunch Information Page" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="Lunch Information Page.aspx.cs" Inherits="Lab3.Lunch_Information_Page" %>
<%--Jake Mitchell
Section 0002
10/3/2020--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblStudentList" runat="server" Text="Current (live) list of students attending the 'Lunch' event: "></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>

            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>

    <asp:GridView ID="gvStudentLunchInfo" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField ="StudentFirstName" HeaderText="Student's First Name" />
            <asp:BoundField DataField ="StudentLastName" HeaderText="Student's Last Name" />
            <asp:BoundField DataField ="EventName" HeaderText="Event" />
            <asp:BoundField DataField ="DateTime" HeaderText="Date & Time" />
            <asp:BoundField DataField ="Location" HeaderText="Location" />
        </Columns>
    </asp:GridView>
    <br />

    <asp:Table runat ="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblVolunteerList" runat="server" Text="Current (live) list of volunteers attending the 'Lunch' event: "></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:GridView ID="gvVolunteerLunchInfo" runat="server" AutoGenerateColumns ="false">
        <Columns>
            <asp:BoundField DataField ="FirstName" HeaderText="Volunteer's First Name" />
            <asp:BoundField DataField ="LastName" HeaderText ="Volunteer's Last Name" />
            <asp:BoundField DataField ="EmailAddress" HeaderText ="Email Address " />
            <asp:BoundField DataField ="PhoneNumber" HeaderText ="Phone Number " />
            <asp:BoundField DataField ="EventName" HeaderText="Event" />
            <asp:BoundField DataField ="DateTime" HeaderText="Date & Time" />
            <asp:BoundField DataField ="Location" HeaderText="Location" />

        </Columns>
    </asp:GridView>
    <br />

    <asp:Table runat ="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblCoordinatorList" runat="server" Text="Current (live) list of  'Lunch' event coordinators: "></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:GridView ID="gvCoordinatorLunchInfo" runat="server" AutoGenerateColumns ="false">
        <Columns>
            <asp:BoundField DataField ="FirstName" HeaderText="Coordinator's First Name " />
            <asp:BoundField DataField ="LastName" HeaderText ="Coordinator's Last Name " />
            <asp:BoundField DataField ="EmailAddress" HeaderText ="Email Address " />
            <asp:BoundField DataField ="PhoneNumber" HeaderText ="Phone Number " />
            <asp:BoundField DataField ="EventName" HeaderText="Event" />
            <asp:BoundField DataField ="DateTime" HeaderText="Date & Time" />
            <asp:BoundField DataField ="Location" HeaderText="Location" />

        </Columns>
    </asp:GridView>
    



</asp:Content>
