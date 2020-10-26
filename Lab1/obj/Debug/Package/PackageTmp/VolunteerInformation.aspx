<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="VolunteerInformation.aspx.cs" Inherits="Lab1.VolunteerInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Table runat="server" BorderStyle="Solid" HorizontalAlign="Center" CellPadding="7">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblPageInstructions" runat="server" Text="Please select a volunteer from the list and hit 'View Selected Volunteer Roster'" Font-Bold="true"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:DropDownList ID="ddlVolunteers" runat="server"></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="btnView" runat="server" Text="View Selected Volunteer" Height="30" OnClick="btnView_Click" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnRoster" runat="server" Text="View Complete Volunteer Roster" Height="30" OnClick="btnRoster_Click"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblError" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <br />
    <br />

    <asp:Table  runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblSelectedVolunteerInfo" runat="server" Text="Selected volunteer's information: " Visible="false"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:GridView ID="gvVolunteerRoster" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField ="FirstName" HeaderText="First Name" />
            <asp:BoundField DataField ="LastName" HeaderText="Last Name" />
            <asp:BoundField DataField ="EmailAddress" HeaderText="Email Address" />
            <asp:BoundField DataField ="PhoneNumber" HeaderText="Phone Number" />
            <asp:BoundField DataField ="TShirtSize" HeaderText ="T-Shirt Size" />
            <asp:BoundField DataField ="TShirtColor" HeaderText ="T-Shirt Color" />
            <asp:BoundField DataField ="TShirtDescription" HeaderText="T-Shirt Description" />
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <br />

    <asp:Table  runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblSelectedVolunteerEvents" runat="server" Text="Selected volunteer's assigned events: " Visible="false"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

     <asp:GridView ID="gvVolunteerEvents" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField ="EventName" HeaderText="Event Name" />
            <asp:BoundField DataField ="DateTime" HeaderText="Date & Time" />
            <asp:BoundField DataField ="Location" HeaderText="Location" />
            
        </Columns>
    </asp:GridView>

    <asp:Table  runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblCompleteRoster" runat="server" Text="Complete list of volunteers: " Visible="false"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

     <asp:GridView ID="gvCompleteRoster" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField ="FirstName" HeaderText="First Name" />
            <asp:BoundField DataField ="LastName" HeaderText="Last Name" />
            <asp:BoundField DataField ="EmailAddress" HeaderText="Email Address" />
            <asp:BoundField DataField ="PhoneNumber" HeaderText="Phone Number" />
            <asp:BoundField DataField ="TShirtSize" HeaderText ="T-Shirt Size" />
            <asp:BoundField DataField ="TShirtColor" HeaderText ="T-Shirt Color" />
            <asp:BoundField DataField ="TShirtDescription" HeaderText="T-Shirt Description" />
        </Columns>

    </asp:GridView>




</asp:Content>
