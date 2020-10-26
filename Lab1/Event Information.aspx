<%@ Page Title="Jake Mitchell - Event Information Page" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="Event Information.aspx.cs" Inherits="Lab3.Event_Information" %>
<%--Jake Mitchell
Section 0002
10/3/2020--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table runat="server" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblEventInfoPageDirection" runat="server" Text="Please choose an Event: "></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table >

    <asp:Table runat="server" HorizontalAlign="Center" BorderStyle="Solid">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" Text="Events: "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnLunch" runat="server" Text="Lunch" PostBackUrl="~/Lunch Information Page.aspx" Width="200" Height="30" />
                <asp:Button ID="btnLearningSeminar" runat="server" Text="Learning Seminar" PostBackUrl="~/Learning Seminar Information Page.aspx" Width="200" Height="30" />
                <asp:Button ID="btnCaptureTheFlag" runat="server" Text="Capture the Flag" PostBackUrl="~/Capture the Flag Information Page.aspx" Width="200" Height="30" />
                <asp:Button ID="btnBagToss" runat="server" Text="Bag Toss" PostBackUrl="~/Bag Toss Information Page.aspx" Width="200" Height="30" />

            </asp:TableCell>
        </asp:TableRow>



    </asp:Table>




</asp:Content>
