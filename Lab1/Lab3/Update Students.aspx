<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="Update Students.aspx.cs" Inherits="Lab1.Update_Students" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Table runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblStudentID" runat="server" Text="StudentID"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtStudentID" runat="server" ReadOnly="true"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblFirstName" runat="server" Text="First Name: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblLastName" runat="server" Text="Last Name: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                <asp:Label ID="lblAge" runat="server" Text="Age: "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtAge" runat="server" ></asp:TextBox>
            </asp:TableCell>
                <asp:TableCell>
                    <asp:CompareValidator ID="valAge" runat="server" ControlToValidate="txtAge" ErrorMessage="" Operator="DataTypeCheck" Type="Integer" Text="* Invalid Age (Must be a number)"></asp:CompareValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblNotes" runat="server" Text="Notes: " Width=""></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" Rows="6"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
            </asp:TableCell>
        </asp:TableRow>
            <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblLunchTicket" runat="server" Text="Lunch Ticket (Yes/No)"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtLunchTicket" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="valLunchTicket" runat="server" ErrorMessage="" ControlToValidate="txtLunchTicket" Text="* Please specify student's Lunch attendance" ForeColor="Red" Font-Bold="true" Enabled="true"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
            <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblTShirtSize" runat="server" Text="T-Shirt Size (XL/L/M/S): "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtTShirtSize" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="valTShirtSize" runat="server" ErrorMessage="" ControlToValidate="txtTShirtSize" Text="* Please enter a T-Shirt Size" ForeColor="Red" Font-Bold="true" Enabled="true"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblTShirtColor" runat="server" Text="T-Shirt Color (Green/Yellow/Blue/Black): "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtTShirtColor" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="valTShirtColor" runat="server" ErrorMessage="" ControlToValidate="txtTShirtColor" Text="* Please enter a T-Shirt Color" ForeColor="Red" Font-Bold="true" Enabled="true"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblTShirtDescription" runat="server" Text="T-Shirt Description: "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtTShirtDescription" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="valTShirtDescription" runat="server" ErrorMessage="" ControlToValidate="txtTShirtDescription" Text="* Please enter a T-Shirt Description" ForeColor="Red" Font-Bold="true" Enabled="true"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        </asp:Table>
        <br />
        <br>

        <asp:Table runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblStatus" runat="server" Text="" ForeColor="Green" Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>




    </div>


</asp:Content>
