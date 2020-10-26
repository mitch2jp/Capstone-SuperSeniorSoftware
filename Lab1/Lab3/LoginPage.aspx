<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Lab1.LoginPage" %>
<%--Jake Mitchell
Section 0002
10/3/2020--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="css/CustomStyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-6 mx-auto">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col">
                                    <center><img width="150px" src="images/dukes.png" 
                                    </center>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <center>
                                        <h3>User Login</h3>
                                    </center>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <hr>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <div class="form-group">
                                        <asp:Label ID="lblUsername1" runat="server" Text="
                                            "></asp:Label>
                                        <asp:TextBox CssClass="form-control" placeholder="Username" ID="TextBox1" runat="server"></asp:TextBox>
                                
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" TextMode="Password" placeholder="Username" ID="TextBox2" runat="server"></asp:TextBox>
                                
                                    </div>

                                    <div class="form-group">
                                        <asp:Button ID="btnLogin1" CssClass="btn btn-success btn-block btn-lg" runat="server" Text="Login" />
                                
                                    </div>

                                    <div class="form-group">
                                        <asp:Button ID="Button2" CssClass="btn btn-info btn-block btn-lg" runat="server" Text="Sign Up" />
                                
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
     </div>
        <div>
            <asp:Table runat ="server" HorizontalAlign="Center">
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell HorizontalAlign="Center" >
                        <asp:Label ID="lblPageInstructions" runat="server" Text="Please Login to the Application: " Font-Bold ="true"  ></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:Table ID="Table1" runat="server" HorizontalAlign="Center" BorderStyle ="Solid" Height="232px" Width="518px"  >
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblUsername" runat="server" Text="User Name:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" Width="100" Height="30"/>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">
                        <asp:Label ID="lblIncorrectLogin" runat="server" Text="" ForeColor="Red" FontBold="true"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblTeachers" runat="server" Text="New Teachers -->  "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:LinkButton ID="lnkBtn" runat="server" OnClick="btnCreateAccount_Click" PostBackUrl="~/Create a Teacher.aspx">Create an Account</asp:LinkButton>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>

</body>
</html>
