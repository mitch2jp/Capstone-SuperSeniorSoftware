<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="EditTeacherProfile.aspx.cs" Inherits="Lab1.EditTeacherProfile" %>
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
                                <asp:Label ID="lblPageInstructions" runat="server" Font-Bold="true" Text="Please verify the following information: "></asp:Label>
                            </div>
                        </div>
                        <br />

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblUsername" runat="server" Text="User Name: "></asp:Label>
                                <asp:TextBox CssClass="form-control" Width="200" ID="txtUsername" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valtxtUsername" ControlToValidate="txtUsername" Font-Bold="true" Text="(Required)" ForeColor="Red" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                            </div>
                            <div class="col">
                                <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
                                <asp:TextBox CssClass="form-control" Width="200" ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valPassword" ControlToValidate="txtPassword" Font-Bold="true" Text="(Required)" ForeColor="Red" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblFirstName" runat="server" Text="First Name: "></asp:Label>
                                <asp:TextBox CssClass="form-control" Width="200" ID="txtFirstName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valFirstName" ControlToValidate="txtFirstName" Font-Bold="true" Text="(Required)" ForeColor="Red" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                            </div>
                            <div class="col">
                                <asp:Label ID="lblLastName" runat="server" Text="Last Name:  "></asp:Label>
                                <asp:TextBox CssClass="form-control" Width="200" ID="txtLastName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valLastName" ControlToValidate="txtLastName" Font-Bold="true" Text="(Required)" ForeColor="Red" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblEmail" runat="server" Text="Email Address: "></asp:Label>
                                <asp:TextBox CssClass="form-control" Width="200" ID="txtEmail" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valEmail" ControlToValidate="txtEmail" Font-Bold="true" Text="(Required)" ForeColor="Red" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                            </div>
                            <div class="col">
                                <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number: "></asp:Label>
                                <asp:TextBox CssClass="form-control" Width="200" ID="txtPhoneNumber" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valPhone" ControlToValidate="txtPhoneNumber" Font-Bold="true" Text="(Required)" ForeColor="Red" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblGradeTaught" runat="server" Text="Grade Taught: "></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="ddlGradeTaught" Width="60" runat="server">
                                    <asp:ListItem Text="" Value="-1"></asp:ListItem>
                                    <asp:ListItem Text="K" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="valGradeTaught" InitialValue="" ControlToValidate="ddlGradeTaught" Text="(Required)" Font-Bold="true" ForeColor="Red" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                            </div>
                            <div class="col">
                                <asp:Label ID="lblSubjectTaught" runat="server" Text="Subject Taught: "></asp:Label>
                                <asp:TextBox CssClass="form-control" Width="200" ID="txtSubjectTaught" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valSubjectTaught" ControlToValidate="txtSubjectTaught" Text="(Required)" Font-Bold="true" ForeColor="Red" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                            </div>
                            <br />
                            
                        </div>
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
                                    <asp:Label ID="valMealTicket" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>

                                </div>
                            </div>
                        </div>
                        <br />
                        <br />

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="lblSchool" runat="server" Text="Please school from drop down. (If school is not listed, select 'Other' and enter school information)"></asp:Label>
                                </div>
                            </div>
                                <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="lblSchoollist" runat="server" Text="School: "></asp:Label>
                                        <asp:DropDownList CssClass="form-control" Width="300" ID="ddlSchool"  OnSelectedIndexChanged="ddlSchool_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="valSchool" InitialValue="Choose One" Text="(Required)" ControlToValidate="ddlSchool" Font-Bold="true" ForeColor="Red" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>

                                </div>
                            </div>
                        </div>

                  

                        <%--<div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblParentTShirtSize" runat="server" Text="Shirt Size: "></asp:Label>
                                            <asp:DropDownList CssClass="form-control" Width="150" ID="ddlParentShirtSize" runat="server">
                                                <asp:ListItem Enabled="true" Text="Select one" Value="-1"></asp:ListItem>
                                                <asp:ListItem Text="S" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="M" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="L" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="XL" Value="4"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>--%>
                        <br />
                        <br />


                        <div class="row">
                                <div class="col">
                                    <div class="form-group">
                                        <asp:Button ID="btnUpdate" CssClass="btn btn-success btn-block btn-lg" runat="server" OnClick="btnUpdate_Click" Text="Update Account Information" />
                                    </div>
                                    <div class="form-group">
                                        <asp:Button ID="btnCancel" CausesValidation="false" CssClass="btn btn-danger btn-block btn-lg" PostBackUrl="~/TeacherDashboard.aspx" runat="server" Text="Cancel" />
                                    </div>
                                </div>
                            </div>

                        



            </div>
        </div>
    </div>
</asp:Content>
