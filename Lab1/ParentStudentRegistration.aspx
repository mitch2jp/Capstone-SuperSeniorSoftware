<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="ParentStudentRegistration.aspx.cs" Inherits="Lab1.ParentStudentRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
            <div class="col">
                <center>
                    <h2>Step 3: Registration </h2>

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
                                <div class="row">
                                    <div class="col">
                                        <center><img width="100px" src="Images/new-user.png" />
                                        </center>
                                    </div>
                                </div>

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
                                            <asp:Label ID="lblStudentFirstName" runat="server" Text="First Name: "></asp:Label>
                                            <asp:TextBox CssClass="form-control" placeholder="Student's First Name" Width="300" ID="txtFirstName" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="valFirstName" ValidationGroup="Student" ControlToValidate="txtFirstName" ForeColor="Red" Font-Bold="true" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblStudentLastName" runat="server" Text="Last Name: "></asp:Label>
                                            <asp:TextBox CssClass="form-control" placeholder="Student's Last Name" Width="300" ID="txtLastName" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="valLastName" ValidationGroup="Student" ControlToValidate="txtLastName" ForeColor="Red" Font-Bold="true" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblAge" runat="server" Text="Age: "></asp:Label>
                                            <asp:TextBox CssClass="form-control" placeholder="" ID="txtAge" Width="85" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="valAge" ValidationGroup="Student" ControlToValidate="txtAge" ForeColor="Red" Font-Bold="true" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblNotes" runat="server" Text="Comments/Notes: "></asp:Label>
                                            <asp:TextBox CssClass="form-control" ValidationGroup="Student" ID="txtNotes" runat="server" TextMode="MultiLine" Width="300" Height="100"></asp:TextBox>

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
                                        <asp:RequiredFieldValidator ID="valGender" ValidationGroup="Student" ControlToValidate="ddlGender" InitialValue="Choose one" ForeColor="Red" Text="(Required)" Font-Bold="true" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                    </div>
                                </div>
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
                                     <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:RadioButton ValidationGroup="PriorParticipate" GroupName="PriorParticipation" ID="rdoPriorYes" runat="server" Text="Yes"/>
                                            <asp:RadioButton ValidationGroup="PriorParticipate" GroupName="PriorParticipation" ID="rdoPriorNo" runat="server" Text="No"/>
                                            <asp:Label ID="valPriorParticipation" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
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
                                            <asp:RadioButton GroupName="StudentMealTicket" ID="rdoStudentMealTicketYes" runat="server" Text="Yes" />
                                            <asp:RadioButton GroupName="StudentMealTicket" ID="rdoStudentMealTicketNo" runat="server" Text="No" />
                                            <asp:Label ID="valMealTicket" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <br />

                            
                               <%-- <div class="row">
                                    <div class="col">
                                        <hr>
                                    </div>
                                </div>--%>


                        
<%--<%--<%--                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblParentParticipation" runat="server" Text="Would you like to chaperone or participate at CyberDay?"></asp:Label>
                                        </div>
                                    </div>
                                     <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:RadioButton ID="rdoParentParticipateYes" runat="server" GroupName="ParentParticipate" Text="Yes" AutoPostBack="true" OnCheckedChanged="rdoParentParticipateYes_CheckedChanged" />
                                            <asp:RadioButton ID="rdoParentParticipateNo" runat="server" GroupName="ParentParticipate" Text="No" AutoPostBack="true" OnCheckedChanged="rdoParentParticipateNo_CheckedChanged" />
                                            <asp:Label ID="valParentParticipation" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
                                        </div>
                                         <div class="form-group">
                                             <asp:Label ID="lblParentRegistrationStatus" Font-Bold="true" ForeColor="Green" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>

                                <div id="divParentInfo" runat="server" class="container-fluid" style="border:1px dashed #000000" >
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <asp:Label ID="lblParentFirstName" runat="server" Text="First Name: " ></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="txtParentFirstName" Width="300" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="valParentFirstName" ControlToValidate="txtParentFirstName" ValidationGroup="Parent" runat="server" ForeColor="Red" Font-Bold="true" ErrorMessage=""></asp:RequiredFieldValidator>

                                            </div>
                                        </div>
                                         <div class="col-md-6">
                                            <div class="form-group">
                                                <asp:Label ID="lblParentLastName" runat="server" Text="Last Name: " ></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="txtParentLastName" Width="300" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="valParentLastName" ControlToValidate="txtParentLastName" ValidationGroup="Parent" runat="server" Font-Bold="true" ForeColor="Red" ErrorMessage=""></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <asp:Label ID="lblParentEmail" runat="server" Text="Email Adress: "></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="txtParentEmail" Width="300" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="valParentEmail" ControlToValidate="txtParentEmail" ValidationGroup="Parent" runat="server" Font-Bold="true" ForeColor="Red" ErrorMessage=""></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ValidationGroup="Parent" ID="validParentEmail" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtParentEmail" ErrorMessage="" Text="Invalid Email" ForeColor="Red" Font-Bold="true"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                         <div class="col-md-6">
                                            <div class="form-group">
                                                <asp:Label ID="lblParentPhone" runat="server" Text="Phone Number: "></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="txtParentPhone" Width="300" runat="server" TextMode="Phone"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="valParentPhone" ControlToValidate="txtParentPhone" ValidationGroup="Parent" runat="server" Font-Bold="true" ForeColor="Red" ErrorMessage=""></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <%--<div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <asp:Label ID="lblParentTShirtSize" runat="server" Text="Shirt Size: "></asp:Label>
                                                <asp:DropDownList CssClass="form-control" ID="ddlParentShirtSize" runat="server">
                                                    <asp:ListItem Enabled="true" Text="Select one" Value="-1"></asp:ListItem>
                                                    <asp:ListItem Text="S" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="M" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="L" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="XL" Value="4"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>--%>


                                    <%--<br />
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

                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                            </div>
                                        </div>
                                         <div class="col-md-6">
                                            <div class="form-group">
                                                <asp:Button ID="btnRegister" CausesValidation="true" ValidationGroup="Parent" CssClass="btn btn-info btn-block btn-md" OnClick="btnRegister_Click1" runat="server" Width="200" Text="Register" />
                                                <asp:Button ID="btnCancelRegister" CausesValidation="false" CssClass="btn btn-danger btn-block btn-md" Width="200" runat="server" Text="Cancel" />
                                            </div>
                                        </div>
                                    </div>

                                    <%--<div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <asp:Label ID="lblParentPriorParticipation" runat="server" Text="Have you participated in CyberDay previously?: "></asp:Label>
                                            </div>
                                        </div>
                                         <div class="col-md-6">
                                            <div class="form-group">
                                                <asp:RadioButton ID="rdoParentPriorParticipationYes" runat="server" Text="Yes" GroupName="ParentPriorParticipation" />
                                                <asp:RadioButton ID="rdoParentPriorParticipationNo" runat="server" Text="No" GroupName="ParentPriorParticipation" />
                                            </div>
                                        </div>
                                    </div>--%>
                                <%--</div>
                                <br />
                                <br />--%>
                       

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblSchool" runat="server" Text="Please select the Student's School: "></asp:Label>
                                        </div>
                                    </div>
                                     <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:DropDownList CssClass="form-control" ID="ddlSchool" Width="300" runat="server"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="valSchooList" ValidationGroup="Student" ControlToValidate="ddlSchool" Font-Bold="true" ForeColor="Red" InitialValue="Choose One" Text="(Required)" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
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
                                            <asp:DropDownList CssClass="form-control" Width="300" ID="ddlTeacher" runat="server"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="valTeacherList" ValidationGroup="Student" ControlToValidate="ddlTeacher" ForeColor="Red" Font-Bold="true" Text="(Required)" InitialValue="Choose One" runat="server" ErrorMessage=""></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <br />

                                <div class="row">
                                    <div class="col">
                                        <div class="form-group">
                                            <asp:Button ID="btnContinue" ValidationGroup="Student" CssClass="btn btn-success btn-block btn-lg" runat="server" OnClick="btnContinue_Click" Text="Continue" />
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
