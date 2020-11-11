<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="ParentParticipation.aspx.cs" Inherits="Lab1.ParentParticipation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
            <div class="col">
                <center>
                    <h2>Step 4: Parent Participation </h2>

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
                            <div class="col mx-auto" style="width:auto">
                                <div class="form-group">
                                    <center>
                                        <asp:Label ID="lblParentParticipation" runat="server" Text="Would you like to chaperone or participate at CyberDay?"></asp:Label>
                                    </center>
                                </div>
                            </div>
                            <div class="col mx-auto" style="width:auto">
                                <div class="form-group">
                                    
                                        <asp:RadioButton ID="rdoParentParticipateYes" runat="server" GroupName="ParentParticipate" Text="Yes" AutoPostBack="true" OnCheckedChanged="rdoParentParticipateYes_CheckedChanged"  />
                                        <asp:RadioButton ID="rdoParentParticipateNo" runat="server" GroupName="ParentParticipate" Text="No" AutoPostBack="true" OnCheckedChanged="rdoParentParticipateNo_CheckedChanged"  />
                                        <asp:Label ID="valParentParticipation" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
                                    
                                </div>
                            </div>
                        </div>
                        <div id="divParentInfo" runat="server" class="container-fluid" style="border:1px dashed #000000" >
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <asp:Label ID="lblParentFirstName" runat="server" Text="First Name: " ></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="txtParentFirstName" Width="300" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="valParentFirstName" ControlToValidate="txtParentFirstName" Text="(Required)" ValidationGroup="Parent" runat="server" ForeColor="Red" Font-Bold="true" ErrorMessage=""></asp:RequiredFieldValidator>

                                            </div>
                                        </div>
                                         <div class="col-md-6">
                                            <div class="form-group">
                                                <asp:Label ID="lblParentLastName" runat="server" Text="Last Name: " ></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="txtParentLastName" Width="300" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="valParentLastName" ControlToValidate="txtParentLastName" ValidationGroup="Parent" Text="(Required)" runat="server" Font-Bold="true" ForeColor="Red" ErrorMessage=""></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <asp:Label ID="lblParentEmail" runat="server" Text="Email Adress: "></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="txtParentEmail" Width="300" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="valParentEmail" ControlToValidate="txtParentEmail" ValidationGroup="Parent" runat="server" Text="(Required)" Font-Bold="true" ForeColor="Red" ErrorMessage=""></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ValidationGroup="Parent" ID="validParentEmail" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtParentEmail" ErrorMessage="" Text="Invalid Email" ForeColor="Red" Font-Bold="true"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                         <div class="col-md-6">
                                            <div class="form-group">
                                                <asp:Label ID="lblParentPhone" runat="server" Text="Phone Number: "></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="txtParentPhone" Width="300" runat="server" TextMode="Phone"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="valParentPhone" ControlToValidate="txtParentPhone" ValidationGroup="Parent" Text="(Required)" runat="server" Font-Bold="true" ForeColor="Red" ErrorMessage=""></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <asp:Label ID="lblGender" runat="server" Text="Gender: "></asp:Label>
                                            <asp:DropDownList ID="ddlGender" Width="225" CssClass="form-control" runat="server">
                                                <asp:ListItem Text="Choose one"></asp:ListItem>
                                                <asp:ListItem Text="Male"></asp:ListItem>
                                                <asp:ListItem Text="Female"></asp:ListItem>
                                                <asp:ListItem Text="Non-Binary"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="valGender" ValidationGroup="Parent" ControlToValidate="ddlGender" InitialValue="Choose one" ForeColor="Red" Text="(Required)" Font-Bold="true" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col">
                                            <div class="form-group">
                                                    <asp:Label ID="lblOrgAffiliation" runat="server" Text="Organization/Affiliation: "></asp:Label>
                                                    <asp:TextBox CssClass="form-control" ID="txtOrgAffiliation" Width="300" runat="server" ></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <br />
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <asp:Label ID="lblParentMealTicket" runat="server" Text="Will you require a meal ticket? "></asp:Label>
                                            </div>
                                        </div>
                                         <div class="col-md-6">
                                            <div class="form-group">
                                                <asp:RadioButton ID="rdoParentMealTicketYes" GroupName="ParentMealTicket" runat="server" Text="Yes" />
                                                <asp:RadioButton ID="rdoParentMealTicketNo" GroupName="ParentMealTicket" Text="No" runat="server" />
                                                <asp:Label ID="valParentMealTicket" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                        <br />
                        <br />
                        <br />

                                 <div class="row">
                                    <div class="col">
                                            <center>
                                                <div class="form-group">
                                                    <asp:Button ID="btnContinue" CssClass="btn btn-success btn-block btn-sm" ValidationGroup="Parent" CausesValidation="true" Width="300" runat="server" OnClick="btnContinue_Click" Text="Continue"></asp:Button>

                                                </div>
                                            </center>
                                        </div>
                                </div>
                                <%--<div class="row">
                                    <div class="col">
                                            <center>
                                                <div class="form-group">
                                                    <asp:Button ID="btnBack" CssClass="btn btn-warning btn-block btn-sm" Width="300" PostBackUrl="~/ParentStudentRegistration.aspx" runat="server" Text="Back" />
                                                </div>
                                            </center>
                                        </div>
                                </div>--%>
                                <div class="row">
                                    <div class="col">
                                            <center>
                                                <div class="form-group">
                                                    <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-block btn-sm" Width="300" PostBackUrl="~/Home.aspx" runat="server" Text="Cancel" />
                                                </div>
                                            </center>
                                        </div>
                                </div>
                        

                    </div>
                </div>
            </div>
        </div>
    </div>
        

            

                             

</asp:Content>
