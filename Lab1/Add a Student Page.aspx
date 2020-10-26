<%@ Page Title="Jake Mitchell - Add Student" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="Add a Student Page.aspx.cs" Inherits="Lab3.Add_a_Student_Page" %>
<%--Jake Mitchell
Section 0002
10/3/2020--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="feedback" runat="server">
        <asp:Table runat="server" HorizontalAlign="Center">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label1" runat="server" Text="Please enter the following information: " Font-Bold="true" ></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    
    <br />
    <asp:Table ID="addStudentTable" runat="server" BorderStyle="Solid" HorizontalAlign="Center" CellSpacing="5" CellPadding="10">

        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblFirstName" runat="server" Text="First Name: "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtFirstName" runat="server"  ></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="valFirstName" runat="server" ErrorMessage="" ControlToValidate="txtFirstName" Text="* Please enter a First Name" ForeColor="Red" Font-Bold="true" Enabled="true" ></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblLastName" runat="server" Text="Last Name: "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="valLastName" runat="server" ErrorMessage="" ControlToValidate="txtLastName" Text="* Please enter a Last Name" ForeColor="Red" Font-Bold="true" Enabled="true"></asp:RequiredFieldValidator>
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
                <asp:RequiredFieldValidator ID="valAge" runat="server" ErrorMessage="" ControlToValidate="txtAge" Text="* Please enter the student's age" ForeColor="Red" Font-Bold="true" Enabled="true"></asp:RequiredFieldValidator>
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
                <asp:Label ID="lblSchooList" runat="server" Text="School (Select from list): "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <<asp:DropDownList ID="ddlSchoolList" runat="server"></asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="valSchoolList" runat="server" ErrorMessage="" ControlToValidate="ddlSchoolList" Text="* Please select the student's school!" InitialValue="Choose One" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblTeacherList" runat="server" Text="Teacher (Select from list): "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <<asp:DropDownList ID="ddlTeacherList" runat="server"></asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="" InitialValue="Choose One" ControlToValidate="ddlTeacherList" Text="* Please select the student's teacher!" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnPopulate" runat="server" Text="Populate" Width="200" Height="30" OnClick="btnPopulate_Click" CausesValidation="false" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="btnCommit" runat="server" Text="Commit to DB" Width="200" Height="30" OnClick="btnCommit_Click"  />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" Width="200" Height="30" CausesValidation="false"  />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblResponseError" runat="server" Text="" ForeColor="Red" Font-Bold="true"></asp:Label>
                <asp:Label ID="lblResponseSuccess" runat="server" Text="" Font-Bold="true" ForeColor="Green"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        

    </asp:Table>

        </div>
</asp:Content>
