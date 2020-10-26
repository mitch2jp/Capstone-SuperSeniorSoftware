<%@ Page Title="Jake Mitchell - Event Sign Up Page" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="Event Sign Up Page.aspx.cs" Inherits="Lab3.Event_Sign_Up_Page" %>
<%--Jake Mitchell
Section 0002
10/3/2020--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table runat="server" BorderStyle ="Solid" HorizontalAlign="Center" CellSpacing="5" CellPadding="10" >
        <asp:TableHeaderRow>
            <asp:TableCell>
                <asp:Label ID="lblPageInstructions" runat="server" Text="Please select a Student, Volunteer or Coordinator to assign to an Event: " Font-Bold="true"></asp:Label>
            </asp:TableCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell >
                <asp:RadioButton ID="rdobtnStudent" runat="server"  Text="Student" OnCheckedChanged="rdobtnStudent_CheckedChanged" AutoPostBack="true" GroupName="Participant"/>
                 <asp:RadioButton ID="rdobtnVolunteer" runat="server" Text="Volunteer"  OnCheckedChanged="rdobtnVolunteer_CheckedChanged" AutoPostBack="true" GroupName="Participant"/>
                <asp:RadioButton ID="rdobtnCoordinator" runat="server" Text ="Coordinator" OnCheckedChanged="rdobtnCoordinator_CheckedChanged" AutoPostBack="true" GroupName ="Participant" />
            </asp:TableCell>
            <asp:TableCell>
            </asp:TableCell>
            <asp:TableCell>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblParticipantType" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblParticipantID" runat="server" Text=""></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:DropDownList ID="ddlParticipant" runat="server"></asp:DropDownList>
                <asp:DropDownList ID="ddlEvent" runat="server"></asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="btnAssign" runat="server" Text="Assign" OnClick="btnAssign_Click" Width="200" Height="30" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" Font-Bold="true"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblSuccess" runat="server" Text="" ForeColor="Green" Font-Bold="true"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>





</asp:Content>
