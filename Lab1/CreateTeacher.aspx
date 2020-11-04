<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="CreateTeacher.aspx.cs" Inherits="Lab1.CreateTeacher" %>
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

                        <div id="divAccountInfo" runat="server" class="container-fluid" style="border:1px dashed #000000" >
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblUsername" runat="server" Text="Username: " ></asp:Label>
                                            <asp:TextBox CssClass="form-control" Width="200" ID="txtUsername" runat="server"></asp:TextBox>
                                            <asp:Label ID="lblUsernameStatus" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblPassword" runat="server" Text="Password: " ></asp:Label>
                                            <asp:TextBox CssClass="form-control" Width="200" ID="txtPassword" runat="server"></asp:TextBox>
                                            <asp:Label ID="lblPasswordStatus" Font-Bold="true" ForeColor="Red" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                           <asp:Label ID="lblVerifyPassword" runat="server" Text="Verify Password: " ></asp:Label>
                                           <asp:TextBox CssClass="form-control" Width="200" ID="txtVerifyPassword" runat="server"></asp:TextBox>
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
                                <asp:Label ID="lblGradeTaught" runat="server" Text="Grade Taught: "></asp:Label>
                                <asp:DropDownList CssClass="form-control" ID="ddlGradeTaught" Width="60" runat="server">
                                    <asp:ListItem Text=""></asp:ListItem>
                                    <asp:ListItem Text="K"></asp:ListItem>
                                    <asp:ListItem Text="1"></asp:ListItem>
                                    <asp:ListItem Text="2"></asp:ListItem>
                                    <asp:ListItem Text="3"></asp:ListItem>
                                    <asp:ListItem Text="4"></asp:ListItem>
                                    <asp:ListItem Text="5"></asp:ListItem>
                                    <asp:ListItem Text="6"></asp:ListItem>
                                    <asp:ListItem Text="7"></asp:ListItem>
                                    <asp:ListItem Text="8"></asp:ListItem>
                                    <asp:ListItem Text="9"></asp:ListItem>
                                    <asp:ListItem Text="10"></asp:ListItem>
                                    <asp:ListItem Text="11"></asp:ListItem>
                                    <asp:ListItem Text="12"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col">
                                <asp:Label ID="lblSubjectTaught" runat="server" Text="Subject Taught: "></asp:Label>
                                <asp:TextBox CssClass="form-control" Width="200" ID="txtSubjectTaught" runat="server"></asp:TextBox>
                            </div>
                            <br />
                            <br />
                            
                        </div>
                        <br />
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
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="lblSchool" runat="server" Text="Please school from drop down. (If school is not listed, select 'Other' and enter school information)"></asp:Label>
                                </div>
                            </div>
                                <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="lblSchoollist" runat="server" Text="School: "></asp:Label>
                                        <asp:DropDownList CssClass="form-control" AutoPostBack="true" Width="300" ID="ddlSchool" OnSelectedIndexChanged="ddlSchool_SelectedIndexChanged" runat="server"></asp:DropDownList>

                                </div>
                            </div>
                        </div>

                    <div id="divSchoolInfo" runat="server" class="container-fluid" style="border:1px dashed #000000" visible="false" >
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblSchoolName" runat="server" Text="SchoolName"></asp:Label>
                                             <asp:TextBox CssClass="form-control" ID="txtSchoolName" runat="server"></asp:TextBox>
                                            
                                        </div>
                                    </div>
                                     <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblSchoolPhone" runat="server" Text="Phone Number: " ></asp:Label>
                                            <asp:TextBox CssClass="form-control" ID="txtSchoolPhone" runat="server" TextMode="Phone"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                            <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblAddress" runat="server" Text="Street Address: "></asp:Label>
                                             <asp:TextBox CssClass="form-control" ID="txtAddress" runat="server"></asp:TextBox>
                                            
                                        </div>
                                    </div>
                                     <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblCity" runat="server" Text="City: " ></asp:Label>
                                            <asp:TextBox CssClass="form-control" ID="txtCity" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                            <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblState" runat="server" Text="State: "></asp:Label>
                                             <asp:TextBox CssClass="form-control" ID="txtState" runat="server"></asp:TextBox>
                                            
                                        </div>
                                    </div>
                                     <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblZip" runat="server" Text="Zip Code:  " ></asp:Label>
                                            <asp:TextBox CssClass="form-control" ID="txtZip" runat="server" TextMode="Number"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblPrincipalName" runat="server" Text="Principal's Name (First and Last): "></asp:Label>
                                            <asp:TextBox CssClass="form-control" ID="txtPrincipalName" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblPrincipalEmail" runat="server" Text="Principal's Email: "></asp:Label>
                                            <asp:TextBox CssClass="form-control" ID="txtPrincipalEmail" runat="server" ></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                            <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblGuidanceName" runat="server" Text="Guidance Counselor's Name (First and Last): "></asp:Label>
                                            <asp:TextBox CssClass="form-control" ID="txtGuidanceName" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblGuidanceEmail" runat="server" Text="Guidance Counselor's Email: "></asp:Label>
                                            <asp:TextBox CssClass="form-control" ID="txtGuidanceEmail" runat="server" ></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblGudiancePhone" runat="server" Text="Guidance Counselor's Phone Number: "></asp:Label>
                                        <asp:TextBox CssClass="form-control" ID="txtGuidancePhone" runat="server" TextMode="Phone"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <br />

                                

                            </div>
                        <br />
                        <br />

                        <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">

                                        </div>
                                    </div>
                                     <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Button ID="btnAddSchool" CssClass="btn btn-info btn-block btn-md" runat="server" Width="200" OnClick="btnAddSchool_Click" Text="Add School" />
                                        </div>
                                    </div>
                                </div>
                    </div>
                        <br />
                        <br />

                        <%--<div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblParentTShirtSize" runat="server" Text="Shirt Size: "></asp:Label>
                                            <asp:DropDownList CssClass="form-control" Width="150" ID="ddlParentShirtSize" runat="server">
                                                <asp:ListItem Enabled="true" Text="Select one" Value="-1"></asp:ListItem>
                                                <asp:ListItem Text="S"></asp:ListItem>
                                                <asp:ListItem Text="M"></asp:ListItem>
                                                <asp:ListItem Text="L"></asp:ListItem>
                                                <asp:ListItem Text="XL"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                        <br />
                        <br />--%>


                        <div class="row">
                                <div class="col">
                                    <div class="form-group">
                                        <asp:Button ID="btnCreateAccount" CssClass="btn btn-success btn-block btn-lg" runat="server"  OnClick="btnCreateAccount_Click" Text="Create Account" />
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
    

</asp:Content>
