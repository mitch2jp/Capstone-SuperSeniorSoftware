<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="CreateConfirmVolunteer.aspx.cs" Inherits="Lab1.CreateConfirmVolunteer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
            <div class="row">
                <div class="col-md-8 mx-auto">
                    <div class="card">
                        <div class="card-body">

                            <div class="row">
                                <div class="col">
                                    <center>
                                    <h2>Step 1:</h2>
                                    </center>
                                </div>
                            </div>
                            <br />
                            <br />



                            <div class="row">
                                <div class="col">
                                    <asp:Label ID="lblPageInstructions" runat="server" Font-Bold="true" Text="Please enter your email to continue: "></asp:Label>
                                </div>
                            </div>
                            <br />
                            <br />



                            <div class="row">
                                <div class="col">
                                    <asp:Label ID="lblEmail" runat="server" Text="Email Address: "></asp:Label>

                                </div>
                                <div class="col">
                                    <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server"></asp:TextBox>

                                </div>
                            </div>
                             <br />

                            <div class="row">
                                <div class="col">
                                    <asp:Label ID="lblVerifyEmail" runat="server" Text="Verify Email Address:  "></asp:Label>

                                </div>
                                <div class="col">
                                    <asp:TextBox CssClass="form-control" ID="txtVerifyEmail" runat="server"></asp:TextBox>

                                </div>
                            </div>
                             <br />


                        <br />

                            <div class="row">
                                <div class="col">
                                    <asp:Label ID="lblStatus" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>

                                </div>
                            </div>
                             <br />
                            <br />



                            <div class="row">
                                <div class="col">
                                    <center>
                                    <div class="form-group">
                                        <%--<asp:Button ID="btnSendEmail" CssClass="btn btn-info btn-block btn-sm" runat="server" Width="300" OnClick="btnSendEmail_Click" PostBackUrl="~/EmailConfirmation.aspx" Text="Send Email" />--%>
                                        <asp:Button ID="btnSendEmail" CssClass="btn btn-info btn-block btn-sm" runat="server" Width="300" OnClick="btnSendEmail_Click" Text="Send Email" />

                                    </div>
                                    <div class="form-group">
                                        <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-block btn-sm" PostBackUrl="~/Home.aspx" Width="300"  runat="server" Text="Cancel" />
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
