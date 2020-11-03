<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="CreateVolunteer.aspx.cs" Inherits="Lab1.CreateVolunteer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
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

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblUsername" runat="server" Text="User Name: "></asp:Label>
                                <asp:TextBox CssClass="form-control" Width="200" ID="txtUsername" runat="server"></asp:TextBox>
                            </div>
                            <div class="col">
                                <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
                                <asp:TextBox CssClass="form-control" Width="200" ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblFirstName" runat="server" Text="First Name: "></asp:Label>
                                <asp:TextBox CssClass="form-control" Width="200" ID="txtFirstName" runat="server"></asp:TextBox>
                            </div>
                            <div class="col">
                                <asp:Label ID="lblLastName" runat="server" Text="Last Name:  "></asp:Label>
                                <asp:TextBox CssClass="form-control" Width="200" ID="txtLastName" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblEmail" runat="server" Text="Email Address: "></asp:Label>
                                <asp:TextBox CssClass="form-control" Width="200" ID="txtEmail" runat="server"></asp:TextBox>
                            </div>
                            <div class="col">
                                <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number: "></asp:Label>
                                <asp:TextBox CssClass="form-control" Width="200" ID="txtPhoneNumber" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblGender" runat="server" Text="Gender: "></asp:Label>
                                <asp:DropDownList ID="ddlGender" Width="225" CssClass="form-control" runat="server">
                                    <asp:ListItem Text="Choose one" Value="-1"></asp:ListItem>
                                    <asp:ListItem Text="Male" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Female" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Non-Binary" Value="2"></asp:ListItem>

                                </asp:DropDownList>

                                <br />
                                


                        
                            
                        
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="lblMealTicket" runat="server" Text="Will you require a meal ticket? "></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:RadioButton GroupName="MealTicket" ID="rdoMealTicketYes" runat="server" Text="Yes"/>
                                    <asp:RadioButton GroupName="MealTicket" ID="rdoMealTicketNo" runat="server" Text="No"/>
                                </div>
                            </div>
                        </div>
                        <br />
                        

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblMajor" runat="server" Text="Major: "></asp:Label>
                                <asp:TextBox CssClass="form-control" Width="200" ID="txtMajor" runat="server"></asp:TextBox>
                            </div>
                            <div class="col">
                                <asp:Label ID="lblOrgAfilliation" runat="server" Text="Organization: "></asp:Label>
                                <asp:TextBox CssClass="form-control" Width="200" ID="txtOrgAfilliation" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <br />

                        <div class="row">
                            <div class="col-md-6">
                                <%--<div class="form-group">
                                    <asp:Label ID="lblParentTShirtSize" runat="server" Text="Shirt Size: "></asp:Label>
                                    <asp:DropDownList CssClass="form-control" Width="150" ID="ddlParentShirtSize" runat="server">
                                        <asp:ListItem Enabled="true" Text="Select one" Value="-1"></asp:ListItem>
                                        <asp:ListItem Text="S" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="M" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="L" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="XL" Value="4"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>--%>
                                <div class="col">
                                        <asp:Label ID="lblOccupation" runat="server" Text="Occupation: "></asp:Label>
                                        <asp:TextBox CssClass="form-control" Width="200" ID="txtOccupation" runat="server"></asp:TextBox>
                                </div>
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
                                        <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-block btn-lg" PostBackUrl="~/Home.aspx" runat="server" Text="Cancel" />
                                    </div>
                                </div>
                            </div>

                        </div>

                    </div>

                </div>

            </div>
        </div>
    </div>
</div>


</asp:Content>
