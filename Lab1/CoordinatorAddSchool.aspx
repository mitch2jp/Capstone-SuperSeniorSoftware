<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="CoordinatorAddSchool.aspx.cs" Inherits="Lab1.CoordinatorAddSchool" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">
            <div class="col">
                <center>
                    <h2>Step 1: School Information </h2>

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
                                    <img width="150px" src="Images/school.png" />
                                </center>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblPageInstructions" runat="server" Font-Bold="true" Text="Please enter the school's following information: "></asp:Label>
                            </div>
                        </div>
                        <br />


                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblSchoolName" runat="server" Text="School Name: "></asp:Label>
                                <asp:TextBox ID="txtSchoolName" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valSchoolName" ControlToValidate="txtSchoolName" ForeColor="Red" Font-Bold="true" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                <asp:Label ID="lblValSchoolName" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
                            </div>
                            <div class="col">
                                <asp:Label ID="lblPhoneNumber" runat="server" Text="Main Phone:"></asp:Label>
                                <asp:TextBox ID="txtPhoneNumber" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valPhoneNumber" ControlToValidate="txtPhoneNumber" ForeColor="Red" Font-Bold="true" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblPrincipalName" runat="server" Text="Principal's Name: "></asp:Label>
                                <asp:TextBox ID="txtPrincipalName" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valPrincipalName" ControlToValidate="txtPrincipalName" ForeColor="Red" Font-Bold="true" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                            </div>
                            <div class="col">
                                <asp:Label ID="lblPrincipal" runat="server" Text="Principal's Email: "></asp:Label>
                                <asp:TextBox ID="txtPrincipalEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valPrincipalEmail" ControlToValidate="txtPrincipalEmail" ForeColor="Red" Font-Bold="true" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="validPrincpalEmail" runat="server" Enabled="false" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtPrincipalEmail" ErrorMessage="" Text="Invalid Email" ForeColor="Red" Font-Bold="true"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblGuidanceName" runat="server" Text="Guidance Counselor's Name:  "></asp:Label>
                                <asp:TextBox ID="txtGuidanceName" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valGuidanceName" ControlToValidate="txtGuidanceName" ForeColor="Red" Font-Bold="true" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                            </div>
                            <div class="col">
                                <asp:Label ID="lblGuidanceEmail" runat="server" Text="Guidance Counselor's Email:  "></asp:Label>
                                <asp:TextBox ID="txtGuidanceEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valGuidanceEmail" ControlToValidate="txtGuidanceEmail" ForeColor="Red" Font-Bold="true" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="validGuidanceEmail" runat="server" Enabled="false" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtGuidanceEmail" ErrorMessage="" Text="Invalid Email" ForeColor="Red" Font-Bold="true"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblGuidancePhone" runat="server" Text="Guidance Counselor's Phone:  "></asp:Label>
                                <asp:TextBox ID="txtGuidancePhone" CssClass="form-control"  runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valGuidancePhone" ControlToValidate="txtGuidancePhone" ForeColor="Red" Font-Bold="true" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                            </div>
                            <div class="col">
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <br />
                        <br />

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblPageInstruction2" runat="server" Font-Bold="true" Text="Please enter the school's location information:  "></asp:Label>
                            </div>
                        </div>
                        <br />




                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblAddress" runat="server" Text="Street Address:  "></asp:Label>
                                <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valAddress" ControlToValidate="txtAddress" ForeColor="Red" Font-Bold="true" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                            </div>
                            <div class="col">
                                <asp:Label ID="lblCity" runat="server" Text="City:  "></asp:Label>
                                <asp:TextBox ID="txtCity" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valCity" ControlToValidate="txtCity" ForeColor="Red" Font-Bold="true" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblState" runat="server" Text="State:  "></asp:Label>
                                <asp:TextBox ID="txtState" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valState" ControlToValidate="txtState" ForeColor="Red" Font-Bold="true" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                            </div>
                            <div class="col">
                                <asp:Label ID="lblZip" runat="server" Text="Zip: "></asp:Label>
                                <asp:TextBox ID="txtZip" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valZip" ControlToValidate="txtZip" ForeColor="Red" Font-Bold="true" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />
                        <br />


                        <div class="row">
                                <div class="col">
                                    <div class="form-group">
                                        <asp:Button ID="btnAddSchool" CssClass="btn btn-success btn-block btn-lg" runat="server" OnClick="btnSubmit_Click" Text="Add School" />
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
