<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="VolunteerChat.aspx.cs" Inherits="Lab1.VolunteerChat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div>
        <center>
            <h2>[Insert Chat Functionality Here]</h2>
        </center>
    </div>
    <br />
    <br />
    <br />

    <div>
        <center>
            <asp:Button ID="Button1" CssClass="btn btn-success btn-block btn-lg" runat="server" PostBackUrl="~/VolunteerDashboard.aspx" Width="400" Text="Back to Dashboard" />
        </center>
    </div>
    <br />
     <br />
    <br />



</asp:Content>
