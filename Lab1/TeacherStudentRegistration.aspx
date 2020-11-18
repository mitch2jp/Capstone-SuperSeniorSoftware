<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="TeacherStudentRegistration.aspx.cs" Inherits="Lab1.TeacherStudentRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="css/CustomStyleSheet.css" rel="stylesheet" />
    <link href="fontawesome/css/all.css" rel="stylesheet" />

    <div class="row">
            <div class="col">
                <center>
                    <h2>Step 1: Student Registration </h2>

                </center>
            </div>
        </div>
        <br />
        <br />

     <div class="container-fluid">
            <div class="row">
                <div class="col-md-8 mx-auto">
                    <div class="card">
                        <div class="card-body">
                            <br />
                            <div class="row">
                                <div class="col">
                                    <center><img width="150px" height="150px" src="Images/new-student.png" />
                                    </center>
                                </div>
                            </div>
                            <br />

                            <div class="row">
                                <div class="col">
                                    <center>
                                        <h3></h3>
                                    </center>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <h4>Please enter your student's information: </h4>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <hr>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblStudentFirstName" runat="server" Text="First Name"></asp:Label>
                                        <asp:TextBox CssClass="form-control" placeholder="Student's First Name" Width="350" ID="txtFirstName" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valStudentFirstName" ControlToValidate="txtFirstName" Font-Bold="true" ForeColor="Red" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblStudentLastName" runat="server" Text="Last Name"></asp:Label>
                                        <asp:TextBox CssClass="form-control" placeholder="Student's Last Name" ID="txtLastName" Width="350" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valStudentLastName" ControlToValidate="txtLastName" Font-Bold="true" ForeColor="Red" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblAge" runat="server" Text="Age"></asp:Label>
                                        <asp:TextBox CssClass="form-control" placeholder="" ID="txtAge" Width="75" runat="server" TextMode="Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valAge" ControlToValidate="txtAge" Font-Bold="true" ForeColor="Red" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="valAgeInt" ControlToValidate="txtAge" Operator="DataTypeCheck" Type="Integer" Text="(Must be a number)" runat="server" ErrorMessage=""></asp:CompareValidator>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblNotes" runat="server" Text="Notes"></asp:Label>
                                        <asp:TextBox CssClass="form-control" ID="txtNotes" runat="server" TextMode="MultiLine" Width="350" Height="100"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />

                            <div class="row">
                                <div class="col">
                                        <asp:Label ID="lblGender" runat="server" Text="Gender: "></asp:Label>
                                        <asp:DropDownList ID="ddlGender" Width="225" CssClass="form-control" runat="server">
                                            <asp:ListItem Text="Choose one"></asp:ListItem>
                                            <asp:ListItem Text="Male"></asp:ListItem>
                                            <asp:ListItem Text="Female"></asp:ListItem>
                                            <asp:ListItem Text="Non-Binary"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="valGender"  ControlToValidate="ddlGender" InitialValue="Choose one" ForeColor="Red" Text="(Required)" Font-Bold="true" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                    </div>
                            </div>
                            <br />
                            <br />

                            <%--<div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblStudentTShirtSize" runat="server" Text="Shirt Size: "></asp:Label>
                                        <asp:DropDownList CssClass="form-control" ID="ddlStudentShirtSize" runat="server">
                                            <asp:ListItem Enabled="true" Text="Select one" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="S" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="M" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="L" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="XL" Value="4"></asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                </div>
                            </div>--%>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblPriorParticipation" runat="server" Text="Has your student participated in CyberDay previously? "></asp:Label>
                                    </div>
                                </div>
                                 <div class="col">
                                        <asp:DropDownList  ID="ddlPriorParticipation" Width="225" CssClass="form-control" runat="server">
                                            <asp:ListItem Text="Choose one"></asp:ListItem>
                                            <asp:ListItem Text="Yes"></asp:ListItem>
                                            <asp:ListItem Text="No"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="valPriorParticipation" ControlToValidate="ddlPriorParticipation" InitialValue="Choose one" ForeColor="Red" Text="(Required)" Font-Bold="true" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                    </div>
                            </div>
                            <br />

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblPhotoAuth" runat="server" Text="Have you recieved signed documentation from the legal parent/guardian of the student authorizing their photo to be taken and published while participating in CyberDay?"></asp:Label>
                                    </div>
                                </div>
                                 <div class="col">
                                        <asp:DropDownList  ID="ddlPhotoAuth" Width="225" CssClass="form-control" runat="server">
                                            <asp:ListItem Text="Choose one"></asp:ListItem>
                                            <asp:ListItem Text="Yes"></asp:ListItem>
                                            <asp:ListItem Text="No"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="valPhotoAuth" ControlToValidate="ddlPhotoAuth" InitialValue="Choose one" ForeColor="Red" Text="(Required)" Font-Bold="true" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                    </div>
                            </div>
                            <br />
                            <br />



                             <%--<div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblPriorParticipation" runat="server" Text="Has your student participated in CyberDay previously? "></asp:Label>
                                    </div>
                                </div>
                                 <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:RadioButton GroupName="PriorParticipation" ID="rdoPriorYes" runat="server" Text="Yes"/>
                                        <asp:RadioButton GroupName="PriorParticipation" ID="rdoPriorNo" runat="server" Text="No"/>
                                        <asp:Label ID="valPriorParticipation" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblMealTicket" runat="server" Text="Will your student require a meal ticket? "></asp:Label>
                                    </div>
                                </div>
                                 <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:RadioButton GroupName="StudentMealTicket" ID="rdoMealYes" runat="server" Text="Yes" />
                                        <asp:RadioButton GroupName="StudentMealTicket" ID="rdoMealNo" runat="server" Text="No" />
                                        <asp:Label ID="valMealTicket" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblPhotoAuth" runat="server" Text="Have you recieved signed documentation from the legal parent/guardian of the student authorizing their photo to be taken and published while participating in CyberDay? "></asp:Label>
                                    </div>
                                </div>
                                 <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:RadioButton GroupName="PhotoAuth" ID="rdoAuthYes" runat="server" Text="Yes" />
                                        <asp:RadioButton GroupName="PhotoAuth" ID="rdoAuthNo" runat="server" Text="No" />
                                        <asp:Label ID="valPhotoAuth" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>--%>


                            <%--<div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblSchool" runat="server" Text="Please select the Student's School: "></asp:Label>
                                    </div>
                                </div>
                                 <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:DropDownList CssClass="form-control" ID="ddlSchool" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblTeacher" runat="server" Text="Please select the Student's Teacher: "></asp:Label>
                                    </div>
                                </div>
                                 <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:DropDownList CssClass="form-control" ID="ddlTeacher" runat="server"></asp:DropDownList>

                                    </div>
                                </div>
                            </div>--%>

                            <div class="row">
                                <div class="col">
                                    <div class="form-group">
                                        <asp:Button ID="btnRegister" CssClass="btn btn-success btn-block btn-lg" runat="server" OnClick="btnRegister_Click" Text="Register" />
                                    </div>
                                    <div class="form-group">
                                        <asp:Button ID="btnCancel" CausesValidation="false" CssClass="btn btn-danger btn-block btn-lg" PostBackUrl="~/TeacherDashboard.aspx" runat="server" Text="Cancel" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
         </div>
    <br />
    <br />


</asp:Content>
