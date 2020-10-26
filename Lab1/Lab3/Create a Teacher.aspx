<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create a Teacher.aspx.cs" Inherits="Lab1.Create_a_Teacher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Table runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Table runat="server">
                            <asp:TableRow>
                                <asp:TableCell HorizontalAlign="Center" >
                                    <asp:Button ID="btnReturnToHome" runat="server" Text="Return to Home" PostBackUrl="~/HomePage.aspx" CausesValidation="false"  />
                                    <br />
                                    <br />
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow HorizontalAlign="Right">
                            </asp:TableRow>
                        </asp:Table>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>





            <asp:Table runat="server" HorizontalAlign="Center">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label1" runat="server" Text="Please enter the following information: " Font-Bold="true" ></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    
    <br />
    <asp:Table ID="addTeacherTable" runat="server" BorderStyle="Solid" HorizontalAlign="Center" CellSpacing="5" CellPadding="10">

        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblUsername" runat="server" Text="User Name: "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="valUsername" runat="server" ErrorMessage="" ControlToValidate="txtUsername" Text="* Please enter a User Name" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="valPassword" runat="server" ErrorMessage="" ControlToValidate="txtPassword" Text="*Please enter a Password" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>

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
                <asp:Label ID="lblGradeTaught" runat="server" Text="Grade Taught: "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtGradeTaught" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:CompareValidator ID="valGradeTaught" runat="server" ErrorMessage="" ControlToValidate="txtGradeTaught" Text="* Invalid grade (must be a number)" Operator="DataTypeCheck" Type="Integer" ForeColor="Red" Font-Bold="true" ></asp:CompareValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblEmailAddress" runat="server" Text="Email Address: "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtEmailAddress" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblLunchTicket" runat="server" Text="Lunch Ticket (Yes/No)"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtLunchTicket" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblTShirtSize" runat="server" Text="T-Shirt Size (XL/L/M/S): "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtTShirtSize" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblTShirtColor" runat="server" Text="T-Shirt Color (Green/Yellow/Blue/Black): "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtTShirtColor" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblTShirtDescription" runat="server" Text="T-Shirt Description: "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtTShirtDescription" runat="server"></asp:TextBox>
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
                <asp:Button ID="btnCreate" runat="server" Text="Create" Width="200" Height="30" OnClick="btnCreate_Click"  />
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
    </form>
</body>
</html>
