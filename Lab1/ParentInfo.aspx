<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="ParentInfo.aspx.cs" Inherits="Lab1.ParentInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
            <div class="row">
                <div class="col-md-8 mx-auto">
                    <div class="card">
                        <div class="card-body">

                            <div class="row">
                                <div class="col">
                                    <center>
                                    <h2>Step 1:</h2>
                                    </center>
                                </div>
                            </div>
                            <br />
                            <br />



                            <div class="row">
                                <div class="col">
                                    <asp:Label ID="lblPageInstructions" runat="server" Font-Bold="true" Text="Please enter your email and the following information to continue the registration process: "></asp:Label>
                                </div>
                            </div>
                            <br />
                            <br />

                            <div class="row">
                                <div class="col">
                                    <asp:Label ID="lblFirstName" runat="server" Text="First Name: "></asp:Label>
                                </div>
                                <div class="col">
                                    <asp:TextBox CssClass="form-control" ID="txtFirstName" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <br />

                            <div class="row">
                                <div class="col">
                                    <asp:Label ID="lblLastName" runat="server" Text="Last Name: "></asp:Label>

                                </div>
                                <div class="col">
                                    <asp:TextBox CssClass="form-control" ID="txtLastName" runat="server"></asp:TextBox>

                                </div>
                            </div>
                             <br />

                            <div class="row">
                                <div class="col">
                                    <asp:Label ID="lblPhone" runat="server" Text="Phone Number: "></asp:Label>

                                </div>
                                <div class="col">
                                    <asp:TextBox CssClass="form-control" ID="txtPhone" runat="server" TextMode="Phone"></asp:TextBox>

                                </div>
                            </div>
                             <br />

                            <div class="row">
                                <div class="col">
                                    <asp:Label ID="lblEmail" runat="server" Text="Email Address: "></asp:Label>

                                </div>
                                <div class="col">
                                    <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server"></asp:TextBox>

                                </div>
                            </div>
                             <br />

                            <div class="row">
                                <div class="col">
                                    <asp:Label ID="lblVerifyEmail" runat="server" Text="Verify Email Address:  "></asp:Label>

                                </div>
                                <div class="col">
                                    <asp:TextBox CssClass="form-control" ID="txtVerifyEmail" runat="server"></asp:TextBox>

                                </div>
                            </div>
                             <br />

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="lblSchool" runat="server" Text="Please your student's school from the list: "></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="lblSchoollist" runat="server" Text="School: "></asp:Label>
                                        <asp:DropDownList CssClass="form-control" AutoPostBack="true" Width="300" ID="ddlSchool" OnSelectedIndexChanged="ddlSchool_SelectedIndexChanged" runat="server"></asp:DropDownList>

                                </div>
                            </div>
                        </div>
                        <br />

                            <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="lblTeacher" runat="server" Text="Please select your student's teacher from the list: "></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="lblTeacher2" runat="server" Text="Teacher: "></asp:Label>
                                        <asp:DropDownList CssClass="form-control" AutoPostBack="true" Width="300" ID="ddlTeacher" OnSelectedIndexChanged="ddlTeacher_SelectedIndexChanged" runat="server"></asp:DropDownList>

                                </div>
                            </div>
                        </div>
                        <br />

                            <div class="row">
                                <div class="col">
                                    <asp:Label ID="lblStatus" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>

                                </div>
                            </div>
                             <br />
                            <br />



                            <div class="row">
                                <div class="col">
                                    <center>
                                    <div class="form-group">
                                        <%--<asp:Button ID="btnSendEmail" CssClass="btn btn-info btn-block btn-sm" runat="server" Width="300" OnClick="btnSendEmail_Click" PostBackUrl="~/EmailConfirmation.aspx" Text="Send Email" />--%>
                                        <asp:Button ID="btnSendEmail" CssClass="btn btn-info btn-block btn-sm" runat="server" Width="300" OnClick="btnSendEmail_Click" Text="Send Email" />

                                    </div>
                                    <div class="form-group">
                                        <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-block btn-sm" PostBackUrl="~/Home.aspx" Width="300"  runat="server" Text="Cancel" />
                                    </div>
                                    </center>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
     </div>





    <%--<div>
            <asp:Table  runat ="server" HorizontalAlign="Center">
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell HorizontalAlign="Center" >
                        <asp:Label ID="lblPageInstructions" runat="server" Text="Please enter the following information " Font-Bold ="true"  ></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:Table ID="Table1" runat="server" HorizontalAlign="Center" BorderStyle ="Solid" Height="232px" Width="518px"  >
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
                        <asp:Label ID="lblLastName" runat="server" Text="Last Name:  "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtLastName" runat="server" ></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblEmail" runat="server" Text="Email Adress: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblVerifyEmail" runat="server" Text="Verify Email Adress: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtVerifyEmail" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">
                        <asp:Label ID="lblStatus" runat="server" Text="" ForeColor="Red" FontBold="true"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblTeachers" runat="server" Text="Already registered? "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:LinkButton ID="lnkBtn" runat="server" OnClick="lnkBtn_Click1" PostBackUrl="">Login</asp:LinkButton>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>--%>
</asp:Content>
