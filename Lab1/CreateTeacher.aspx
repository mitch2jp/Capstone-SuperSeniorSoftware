<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="CreateTeacher.aspx.cs" Inherits="Lab1.CreateTeacher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <div class="row">
            <div class="col">
                <center>
                    <h2>Step 1: Account Registration </h2>

                </center>
            </div>
        </div>
        <br />
        <br />


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
                                            <asp:RequiredFieldValidator ValidationGroup="Teacher" ID="valUsername" ControlToValidate="txtUsername" ForeColor="Red" Font-Bold="true" runat="server" Text="(Required)" ErrorMessage=""></asp:RequiredFieldValidator>
                                            <asp:Label ID="lblUsernameStatus" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblPassword" runat="server" Text="Password: " ></asp:Label>
                                            <asp:TextBox CssClass="form-control" TextMode="Password" Width="200" ID="txtPassword" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ValidationGroup="Teacher" ID="valPassword" ControlToValidate="txtPassword" ForeColor="Red" Font-Bold="true" runat="server" Text="(Required)" ErrorMessage=""></asp:RequiredFieldValidator>
                                            <asp:Label ID="lblPasswordStatus" Font-Bold="true" ForeColor="Red" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                           <asp:Label ID="lblVerifyPassword" runat="server" Text="Verify Password: " ></asp:Label>
                                           <asp:TextBox CssClass="form-control" TextMode="Password" Width="200" ID="txtVerifyPassword" runat="server"></asp:TextBox>
                                           <asp:RequiredFieldValidator ValidationGroup="Teacher" ID="valVerifyPassword" ControlToValidate="txtVerifyPassword" ForeColor="Red" Font-Bold="true" runat="server" Text="(Required)" ErrorMessage=""></asp:RequiredFieldValidator>
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
                                <asp:RequiredFieldValidator ValidationGroup="Teacher" ID="valFirstName" ControlToValidate="txtFirstName" ForeColor="Red" Font-Bold="true" runat="server" Text="(Required)" ErrorMessage=""></asp:RequiredFieldValidator>

                            </div>
                            <div class="col">
                                <asp:Label ID="lblLastName" runat="server" Text="Last Name:  "></asp:Label>
                                <asp:TextBox CssClass="form-control" Width="200" ID="txtLastName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ValidationGroup="Teacher" ID="valLastName" ControlToValidate="txtLastName" ForeColor="Red" Font-Bold="true" runat="server" Text="(Required)" ErrorMessage=""></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblEmail" runat="server" Text="Email Address: "></asp:Label>
                                <asp:TextBox CssClass="form-control" Width="200" ID="txtEmail" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ValidationGroup="Teacher" ID="valEmail" ControlToValidate="txtEmail" ForeColor="Red" Font-Bold="true" runat="server" Text="(Required)" ErrorMessage=""></asp:RequiredFieldValidator>
                                <asp:Label ID="lblEmailStatus" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
                                <asp:RegularExpressionValidator ID="validEmail" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="" Text="Invalid Email" ForeColor="Red" Font-Bold="true"></asp:RegularExpressionValidator>

                                
                            </div>
                            <div class="col">
                                <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number: "></asp:Label>
                                <asp:TextBox CssClass="form-control" Width="200" ID="txtPhoneNumber" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ValidationGroup="Teacher" ID="valPhone" ControlToValidate="txtPhoneNumber" ForeColor="Red" Font-Bold="true" runat="server" Text="(Required)" ErrorMessage=""></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="valPhoneInt" ControlToValidate="txtPhoneNumber" Operator="DataTypeCheck" Type="Integer" runat="server" ForeColor="Red" Font-Bold="true" Text="Must only contain numbers!" ErrorMessage=""></asp:CompareValidator>
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
                                <%--<asp:Label ID="lblGradeTaughtStatus" Font-Bold="true" ForeColor="Red" runat="server" Text=""></asp:Label>--%>
                                <asp:RequiredFieldValidator ValidationGroup="Teacher" ID="valGradeTaught" ControlToValidate="ddlGradeTaught" InitialValue="" runat="server" ErrorMessage="" Font-Bold="true" ForeColor="Red" Text="(Required)"></asp:RequiredFieldValidator>
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
                                    <asp:Label ID="lblMealTicketStatus" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                        <br />

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="lblSchool" runat="server" Text="Please school from drop down. (If school is not listed, select 'Not Listed' and enter school information)"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="lblSchoollist" runat="server" Text="School: "></asp:Label>
                                    <asp:DropDownList ValidationGroup="Teacher" CssClass="form-control" Width="300" ID="ddlSchool" OnSelectedIndexChanged="ddlSchool_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ValidationGroup="Teacher" ID="valddlSchool" ControlToValidate="ddlSchool" runat="server" Font-Bold="true" ForeColor="Red" InitialValue="Choose One" ErrorMessage=""></asp:RequiredFieldValidator>
                                    <asp:Label ID="lblSchoolStatus" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Button CssClass="btn btn-secondary btn-block btn-sm" ID="btnNotListed" CausesValidation="false" OnClick="btnNotListed_Click" Width="150" runat="server" Text="Not Listed" />
                                    
                                </div>
                            </div>
                        </div>

                    <div id="divSchoolInfo" runat="server" class="container-fluid" style="border:1px dashed #000000" visible="false" >
                        <br />
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblSchoolAddInstructions" Font-Bold="true" runat="server" Text="Please enter your school's information: "></asp:Label>
                                        </div>
                                    </div>
                                </div>
                        <br />
                        <br />
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblSchoolName" runat="server" Text="School Name:"></asp:Label>
                                            <asp:TextBox CssClass="form-control" ID="txtSchoolName" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ValidationGroup="School" Enabled="false" ID="valSchoolName" ControlToValidate="txtSchoolName" ForeColor="Red" Font-Bold="true" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                            <%--<asp:Label ID="lblSchoolNameStatus" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>--%>
                                        </div>
                                    </div>
                                     <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblSchoolPhone" runat="server" Text="Phone Number: " ></asp:Label>
                                            <asp:TextBox CssClass="form-control" ID="txtSchoolPhone" runat="server" TextMode="Phone"></asp:TextBox>
                                            <asp:RequiredFieldValidator ValidationGroup="School" Enabled="false" ID="valSchoolPhone" ControlToValidate="txtSchoolPhone" ForeColor="Red" Font-Bold="true" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                            <%--<asp:Label ID="lblSchoolPhoneStatus" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>--%>
                                        </div>
                                    </div>
                                </div>

                            <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblAddress" runat="server" Text="Street Address: "></asp:Label>
                                             <asp:TextBox CssClass="form-control" ID="txtAddress" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ValidationGroup="School" Enabled="false" ID="valAddress" ControlToValidate="txtAddress" ForeColor="Red" Font-Bold="true" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                            <%--<asp:Label ID="lblAddressStatus" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>--%>
                                            
                                        </div>
                                    </div>
                                     <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblCity" runat="server" Text="City: " ></asp:Label>
                                            <asp:TextBox CssClass="form-control" ID="txtCity" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ValidationGroup="School" Enabled="false" ID="valCity" ControlToValidate="txtCity" ForeColor="Red" Font-Bold="true" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                            <%--<asp:Label ID="lblCityStatus" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>--%>
                                        </div>
                                    </div>
                                </div>

                            <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblState" runat="server" Text="State: "></asp:Label>
                                             <asp:TextBox CssClass="form-control" ID="txtState" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ValidationGroup="School" Enabled="false" ID="valState" ControlToValidate="txtState" ForeColor="Red" Font-Bold="true" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                            <%--<asp:Label ID="lblStateStatus" Font-Bold="true" ForeColor="Red" runat="server" Text=""></asp:Label>--%>
                                        </div>
                                    </div>
                                     <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblZip" runat="server" Text="Zip Code:  " ></asp:Label>
                                            <asp:TextBox CssClass="form-control" ID="txtZip" runat="server" TextMode="Number"></asp:TextBox>
                                            <asp:RequiredFieldValidator ValidationGroup="School" Enabled="false" ID="valZip" ControlToValidate="txtZip" ForeColor="Red" Font-Bold="true" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                            <%--<asp:Label ID="lblZipStatus" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>--%>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblPrincipalName" runat="server" Text="Principal's Name (First and Last): "></asp:Label>
                                            <asp:TextBox CssClass="form-control" ID="txtPrincipalName" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ValidationGroup="School" Enabled="false" ID="valPrincipalName" ControlToValidate="txtPrincipalName" ForeColor="Red" Font-Bold="true" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                            <%--<asp:Label ID="lblPrincipalNameStatus" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>--%>
                                        </div>
                                    </div>
                                     <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblPrincipalEmail" runat="server" Text="Principal's Email: "></asp:Label>
                                            <asp:TextBox CssClass="form-control" ID="txtPrincipalEmail" runat="server" ></asp:TextBox>
                                            <asp:RequiredFieldValidator ValidationGroup="School" Enabled="false" ID="valPrincipalEmail" ControlToValidate="txtPrincipalEmail" ForeColor="Red" Font-Bold="true" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                            <%--<asp:Label ID="lblPrincipalEmailStatus" Font-Bold="true" ForeColor="Red" runat="server" Text=""></asp:Label>--%>
                                            <asp:RegularExpressionValidator ID="validPrincipalEmail" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtPrincipalEmail" ErrorMessage="" Text="Invalid Email" ForeColor="Red" Font-Bold="true"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                </div>

                            <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblGuidanceName" runat="server" Text="Guidance Counselor's Name (First and Last): "></asp:Label>
                                            <asp:TextBox CssClass="form-control" ID="txtGuidanceName" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ValidationGroup="School" Enabled="false" ID="valGuidanceName" ControlToValidate="txtGuidanceName" ForeColor="Red" Font-Bold="true" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                            <%--<asp:Label ID="lblGuidanceNameStatus" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>--%>
                                        </div>
                                    </div>
                                     <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblGuidanceEmail" runat="server" Text="Guidance Counselor's Email: "></asp:Label>
                                            <asp:TextBox CssClass="form-control" ID="txtGuidanceEmail" runat="server" ></asp:TextBox>
                                            <asp:RequiredFieldValidator ValidationGroup="School" Enabled="false" ID="valGuidanceEmail" ControlToValidate="txtGuidanceEmail" ForeColor="Red" Font-Bold="true" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                            <%--<asp:Label ID="lblGuidanceEmailStatus" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>--%>
                                            <asp:RegularExpressionValidator ID="validGuidanceEmail" ValidationGroup="School" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtGuidanceEmail" ErrorMessage="" Text="Invalid Email" ForeColor="Red" Font-Bold="true"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblGudiancePhone" runat="server" Text="Guidance Counselor's Phone Number: "></asp:Label>
                                        <asp:TextBox CssClass="form-control" ID="txtGuidancePhone" runat="server" TextMode="Phone"></asp:TextBox>
                                        <asp:RequiredFieldValidator ValidationGroup="School" Enabled="false" ID="valGuidancePhone" ControlToValidate="txtGuidancePhone" ForeColor="Red" Font-Bold="true" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                        <%--<asp:Label ID="lblGuidancePhoneStatus" Font-Bold="true" ForeColor="Red" runat="server" Text=""></asp:Label>--%>

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
                                            <asp:Button ID="btnAddSchool" ValidationGroup="School"  CssClass="btn btn-info btn-block btn-md" runat="server" Width="200" OnClick="btnAddSchool_Click" Text="Add School" />
                                            <asp:Button ID="btnCancelSchool" CausesValidation="false" ValidationGroup="School" CssClass="btn btn-danger btn-block btn-md" Width="200" OnClick="btnCancelSchool_Click" runat="server" Text="Cancel" />
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
                                        <asp:Button ID="btnCreateAccount" ValidationGroup="Teacher" CssClass="btn btn-success btn-block btn-lg" runat="server"  OnClick="btnCreateAccount_Click" Text="Create Account" />
                                    </div>
                                    <div class="form-group">
                                        <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-block btn-lg" CausesValidation="false" PostBackUrl="~/Home.aspx" runat="server" Text="Cancel" />
                                    </div>
                                </div>
                            </div>

                        </div>

                    </div>

                </div>

            </div>
        </div>
    

</asp:Content>
