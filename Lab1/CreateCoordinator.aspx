<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="CreateCoordinator.aspx.cs" Inherits="Lab1.CreateCoordinator" %>
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
                                    <img width="150px" src="Images/new-user.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblPageInstructions" runat="server" Font-Bold="true" Text="Please enter the following information: "></asp:Label>
                            </div>
                        </div>
                        <br />

                        <div id="divAccountInfo" runat="server" class="container-fluid" style="border:1px dashed #000000" >
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblUsername" runat="server" Text="Username: " ></asp:Label>
                                            <asp:TextBox CssClass="form-control" Width="200" ID="txtUsername" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="valUsername" ControlToValidate="txtUsername" Font-Bold="true" ForeColor="Red" runat="server" Text="(Required)" ErrorMessage=""></asp:RequiredFieldValidator>
                                            <asp:Label ID="lblUsernameStatus" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblPassword" runat="server" Text="Password: " ></asp:Label>
                                            <asp:TextBox CssClass="form-control" Width="200" TextMode="Password" ID="txtPassword" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="valPassword" ControlToValidate="txtPassword" ForeColor="Red" Font-Bold="true" runat="server" Text="(Required)" ErrorMessage=""></asp:RequiredFieldValidator>
                                            <asp:Label ID="lblPasswordStatus" Font-Bold="true" ForeColor="Red" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                           <asp:Label ID="lblVerifyPassword" runat="server" Text="Verify Password: " ></asp:Label>
                                           <asp:TextBox CssClass="form-control" Width="200" TextMode="Password" ID="txtVerifyPassword" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="valVerifyPassword" ControlToValidate="txtVerifyPassword" ForeColor="Red" Font-Bold="true" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                    
                            </div>
                            <br />
                            <br />

                        


                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblFirstName" runat="server" Text="First Name: "></asp:Label>
                                <asp:TextBox CssClass="form-control" Width="200" ID="txtFirstName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtVerifyPassword" ForeColor="Red" Font-Bold="true" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                            </div>
                            <div class="col">
                                <asp:Label ID="lblLastName" runat="server" Text="Last Name:  "></asp:Label>
                                <asp:TextBox CssClass="form-control" Width="200" ID="txtLastName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valLastName" ControlToValidate="txtLastName" ForeColor="Red" Font-Bold="true" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblEmail" runat="server" Text="Email Address: "></asp:Label>
                                <asp:TextBox CssClass="form-control" Width="200" ID="txtEmail" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valEmail" ControlToValidate="txtEmail" ForeColor="Red" Font-Bold="true" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="validEmail" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="" Text="Invalid Email" ForeColor="Red" Font-Bold="true"></asp:RegularExpressionValidator>
                            </div>
                            <div class="col">
                                <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number: "></asp:Label>
                                <asp:TextBox CssClass="form-control" Width="200" ID="txtPhoneNumber" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valPhoneNumber" ControlToValidate="txtPhoneNumber" ForeColor="Red" Font-Bold="true" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />
                        <br />



                        <div class="row">
                                <div class="col">
                                    <div class="form-group">
                                        <asp:Button ID="btnCreateAccount" CssClass="btn btn-success btn-block btn-lg" runat="server" OnClick="btnCreateAccount_Click" Text="Create Account" />
                                    </div>
                                    <div class="form-group">
                                        <asp:Button ID="btnCancel" CausesValidation="false" CssClass="btn btn-danger btn-block btn-lg" PostBackUrl="~/CoordinatorDashboard.aspx" runat="server" Text="Cancel" />
                                    </div>
                                </div>
                            </div>

                        </div>

                    </div>
                </div>
            </div>
         </div>





</asp:Content>
