<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="ParentStudentRegistration.aspx.cs" Inherits="Lab1.ParentStudentRegistration" %>
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
                                        <asp:Label ID="lblStudentFirstName" runat="server" Text="First Name"></asp:Label>
                                        <asp:TextBox CssClass="form-control" placeholder="Student's First Name" ID="txtFirstName" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblStudentLastName" runat="server" Text="Last Name"></asp:Label>
                                        <asp:TextBox CssClass="form-control" placeholder="Student's Last Name" ID="txtLastName" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblAge" runat="server" Text="Age"></asp:Label>
                                        <asp:TextBox CssClass="form-control" placeholder="" ID="txtAge" Width="50" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblNotes" runat="server" Text="Notes"></asp:Label>
                                        <asp:TextBox CssClass="form-control" ID="txtNotes" runat="server" TextMode="MultiLine" Width="300" Height="100"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
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
                            </div>
                             <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblPriorParticipation" runat="server" Text="Has your student participated in CyberDay previously? "></asp:Label>
                                    </div>
                                </div>
                                 <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:RadioButton GroupName="PriorParticipation" ID="chkboxPriorYes" runat="server" Text="Yes"/>
                                        <asp:RadioButton GroupName="PriorParticipation" ID="chkboxPriorNo" runat="server" Text="No"/>
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
                                        <asp:RadioButton GroupName="StudentMealTicket" ID="chkboxMealYes" runat="server" Text="Yes" />
                                        <asp:RadioButton GroupName="StudentMealTicket" ID="chkboxMealNo" runat="server" Text="No" />
                                    </div>
                                </div>
                            </div>

                            
                           <%-- <div class="row">
                                <div class="col">
                                    <hr>
                                </div>
                            </div>--%>


                        
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblParentParticipation" runat="server" Text="Will you like to chaperone or participate at CyberDay?"></asp:Label>
                                    </div>
                                </div>
                                 <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:RadioButton ID="rdoParentParticipateYes" runat="server" GroupName="ParentParticipate" Text="Yes" AutoPostBack="true" OnCheckedChanged="rdoParentParticipateYes_CheckedChanged" />
                                        <asp:RadioButton ID="rdoParentParticipateNo" runat="server" GroupName="ParentParticipate" Text="No" AutoPostBack="true" OnCheckedChanged="rdoParentParticipateNo_CheckedChanged" />
                                    </div>
                                </div>
                            </div>

                            <div id="divParentInfo" runat="server" class="container-fluid" style="border:1px dashed #000000" >
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblParentFirstName" runat="server" Text="First Name: " ></asp:Label>
                                            <asp:TextBox CssClass="form-control" ID="txtParentFirstName" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblParentLastName" runat="server" Text="Last Name: " ></asp:Label>
                                            <asp:TextBox CssClass="form-control" ID="txtParentLastName" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblParentEmail" runat="server" Text="Email Adress: "></asp:Label>
                                            <asp:TextBox CssClass="form-control" ID="txtParentEmail" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="lblParentPhone" runat="server" Text="Phone Number: "></asp:Label>
                                            <asp:TextBox CssClass="form-control" ID="txtParentPhone" runat="server" TextMode="Phone"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
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
                                </div>

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
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
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
                                </div>
                            </div>
                        

                            <div class="row">
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
                            </div>

                            <div class="row">
                                <div class="col">
                                    <div class="form-group">
                                        <asp:Button ID="btnRegister" CssClass="btn btn-success btn-block btn-lg" runat="server" PostBackUrl="~/ParentPhotoReleaseAuth.aspx" Text="Register" />
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
