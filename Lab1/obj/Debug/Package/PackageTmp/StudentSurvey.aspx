<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="StudentSurvey.aspx.cs" Inherits="Lab1.StudentSurvey" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="css/CustomStyleSheet.css" rel="stylesheet" />


    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150px" src="Images/survey.png" />
                                </center>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblPageInstructions" runat="server" Font-Bold="true" Text="Please enter the following information: "></asp:Label>
                            </div>
                        </div>
                        <br />

                        <div id="divStudentInfo" runat="server" class="container-fluid" style="border:1px dashed #000000" >
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblFirstName" runat="server" Text="First Name: " ></asp:Label>
                                            <asp:TextBox CssClass="form-control" Width="200" ID="txtFirstName" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="valFirstName" ControlToValidate="txtFirstName" Font-Bold="true" ForeColor="Red" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblLastName" runat="server" Text="Last Name: " ></asp:Label>
                                            <asp:TextBox CssClass="form-control" Width="200" ID="txtLastName" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="valLastName" ControlToValidate="txtLastName" Font-Bold="true" ForeColor="Red" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                           <asp:Label ID="lblEmail" runat="server" Text="Email Address (Optional): " ></asp:Label>
                                            <asp:TextBox ID="txtEmail" CssClass="form-control" Width="200" runat="server"></asp:TextBox>
                                            <%--<asp:RegularExpressionValidator ID="validEmail" runat="server" Enabled="false" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="" Text="Invalid Email" ForeColor="Red" Font-Bold="true"></asp:RegularExpressionValidator>--%>
                                            <asp:Label ID="valEmail" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                           <asp:Label ID="lblStudentStatus" ForeColor="Red" Font-Bold="true" runat="server" Text="" ></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <br />

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblPageInstruction2" runat="server" Font-Bold="true" Text="Please rate the following on a scale of 1-5 (1 = Very Dissatisfied, 5 = Very Satisfied)"></asp:Label>
                            </div>
                        </div>
                        <br />

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="col">
                                
                            </div>
                        </div>


                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblCyberDaySatisfaction" runat="server" Text="How satisfied are you with your overall CyberDay Experience? "></asp:Label>
                            </div>
                            <div class="col">
                                <asp:RadioButtonList CellPadding="15" CellSpacing="6" ID="rdoBtnListCDSatisfaction" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="1"></asp:ListItem>
                                    <asp:ListItem Text="2"></asp:ListItem>
                                    <asp:ListItem Text="3"></asp:ListItem>
                                    <asp:ListItem Text="4"></asp:ListItem>
                                    <asp:ListItem Text="5"></asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator ID="valCDSatisfaction" Display="Dynamic" ForeColor="Red" Font-Bold="true" ControlToValidate="rdoBtnListCDSatisfaction" runat="server" Text="(Required)" ErrorMessage=""></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblActivitySatisfaction" runat="server" Text="How satisfied are you with the CyberDay activities you participated in?:  "></asp:Label>
                            </div>
                            <div class="col">
                                <asp:RadioButtonList CellPadding="15" CellSpacing="6" ID="rdoBtnListActivitySatisfaction" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="1"></asp:ListItem>
                                    <asp:ListItem Text="2"></asp:ListItem>
                                    <asp:ListItem Text="3"></asp:ListItem>
                                    <asp:ListItem Text="4"></asp:ListItem>
                                    <asp:ListItem Text="5"></asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator ID="val" Display="Dynamic" ForeColor="Red" Font-Bold="true" ControlToValidate="rdoBtnListActivitySatisfaction" runat="server" Text="(Required)" ErrorMessage=""></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblVolunteerSatisfaction" runat="server" Text="How satisfied are you with CyberDay volunteers that accompanied you?:  "></asp:Label>
                            </div>
                            <div class="col">
                                <asp:RadioButtonList CellPadding="15" CellSpacing="6" ID="rdoBtnListVolunteerSatisfaction" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="1"></asp:ListItem>
                                    <asp:ListItem Text="2"></asp:ListItem>
                                    <asp:ListItem Text="3"></asp:ListItem>
                                    <asp:ListItem Text="4"></asp:ListItem>
                                    <asp:ListItem Text="5"></asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator ID="valVolunteerSatisfaction" Display="Dynamic" ForeColor="Red" Font-Bold="true" ControlToValidate="rdoBtnListVolunteerSatisfaction" runat="server" Text="(Required)" ErrorMessage=""></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />
                        <br />

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblPageInstructions3" runat="server" Font-Bold="true" Text="Please rate the following on a scale of 1-5 (1 = Very Unlikely, 5 = Very Likely)"></asp:Label>
                            </div>
                        </div>
                        <br />

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblTechnicalPath" runat="server" Text="How likely are you to pursue a technical related discipline or career path (i.e. Computer Science, Technology, STEM etc.)?:  "></asp:Label>
                            </div>
                            <div class="col">
                                <asp:RadioButtonList CellPadding="15" CellSpacing="6" ID="rdoBtnListTechnicalPath" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="1"></asp:ListItem>
                                    <asp:ListItem Text="2"></asp:ListItem>
                                    <asp:ListItem Text="3"></asp:ListItem>
                                    <asp:ListItem Text="4"></asp:ListItem>
                                    <asp:ListItem Text="5"></asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator ID="valTechnicalPath" Display="Dynamic" ForeColor="Red" Font-Bold="true" ControlToValidate="rdoBtnListTechnicalPath" runat="server" Text="(Required)" ErrorMessage=""></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />
                        <br />

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblPageInstructions4" runat="server" Font-Bold="true" Text="Please answer the following question(s): "></asp:Label>
                            </div>
                        </div>
                        <br />

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblHigherEducation" runat="server" Text="Do you plan on pursuing higher education (i.e. College/University)?:  "></asp:Label>
                            </div>
                            <div class="col">
                                <asp:RadioButtonList CellPadding="15" CellSpacing="6" ID="rdoBtnListHigherEducation" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="Yes"></asp:ListItem>
                                    <asp:ListItem Text="No"></asp:ListItem>
                                    <asp:ListItem Text="Unsure"></asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator ID="valHigherEducation" Display="Dynamic" ForeColor="Red" Font-Bold="true" ControlToValidate="rdoBtnListHigherEducation" runat="server" Text="(Required)" ErrorMessage=""></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />
                        <br />

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblPageInstruction5" runat="server" Font-Bold="true" Text="Please provide any comments about your CyberDay experience below: "></asp:Label>
                            </div>
                        </div>
                        <br />

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblComments" runat="server" Text="Notes/Comments: "></asp:Label>
                            </div>
                            <div class="col">
                                <asp:TextBox ID="txtComments" CssClass="form-control" placeholder="Specify here" TextMode="MultiLine" Width="350" Height="200" runat="server"></asp:TextBox>
                                
                            </div>
                        </div>
                        <br />
                        <br />


                        <div class="row">
                                <div class="col">
                                    <div class="form-group">
                                        <asp:Button ID="btnSubmit" CssClass="btn btn-success btn-block btn-lg" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
                                    </div>
                                    <div class="form-group">
                                        <asp:Button ID="btnCancel" CausesValidation="false" CssClass="btn btn-danger btn-block btn-lg" PostBackUrl="~/StudentDashboard.aspx" runat="server" Text="Cancel" />
                                    </div>
                                </div>
                            </div>

                        </div>

                    </div>
                </div>
            </div>
         </div>




</asp:Content>
