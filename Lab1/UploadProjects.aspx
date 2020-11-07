<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="UploadProjects.aspx.cs" Inherits="Lab1.UploadProjects" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <center>
            <%--<h2>[Insert Project Upload Functionality Here]</h2>--%>
            <asp:Label ID="lblFileUpload" runat="server" Text="Select a File to Upload"></asp:Label>
            <br />
            <asp:FileUpload ID="fileUpload" runat="server"></asp:FileUpload>
            <asp:Button ID="btnFileUpload" runat="server" Text="Upload File" OnClick="btnFileUpload_Click"></asp:Button>
            <br />
            <asp:Label ID="lblUploadStatus" runat="server" Text=""></asp:Label>
        </center>
    </div>
    <br />
    <br />
    <br />

    <div>
        <center>
            <asp:Button ID="Button1" CssClass="btn btn-success btn-block btn-lg" runat="server" PostBackUrl="~/StudentDashboard.aspx" Width="400" Text="Back to Dashboard" />
        </center>
    </div>
    <br />
     <br />
    <br />


</asp:Content>
