<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="EventDetails.aspx.cs" Inherits="Lab1.EventDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <center>
            <h2>[Insert Event Details Here]</h2>
        </center>
    </div>
    <br />
    <br />
    <br />

    <div>
        <center>
            <asp:Button ID="Button1" CssClass="btn btn-success btn-block btn-lg" runat="server" PostBackUrl="~/EventInformation.aspx" Width="400" Text="Back to Events" />
        </center>
    </div>
    <br />
     <br />
    <br />


</asp:Content>
