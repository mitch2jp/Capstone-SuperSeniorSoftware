<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="ParentAuthentication.aspx.cs" Inherits="Lab1.ParentAuthentication" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
            <div class="col">
                <center>
                    <h2>Step 2: Authentication </h2>

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
                                    <center><img width="150px" height="150px" src="Images/validate.png" />
                                    </center>
                                </div>
                            </div>
                            <br />
                        <div class="row">
                            <div class="col">
                                    <asp:Label ID="lblPageInstruction" runat="server" Text="Please enter your email address and authentication code to continue:" Font-Bold="true" Font-Size="Large"></asp:Label>
                            </div>
                        </div>
                        <br />
                        <br />


                        <div class="row">
                            <div class="col">
                                <center>
                                    <asp:Label ID="lblSucess" runat="server" Text="" Font-Size="Large"></asp:Label>
                                </center>
                            </div>
                        </div>
                        <br />
                        <br />

                        <div class="row">
                            <div class="col">
                                <center>
                                    <asp:Label ID="lblEmail" runat="server" Text="Email Address:  "></asp:Label>
                                    <asp:TextBox CssClass="form-control" style="text-align:center" ID="txtParentEmail" Width="200" runat="server"></asp:TextBox>
                                    </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <asp:Label ID="lblRegistrationCode" runat="server" Text="Authentication Code: "></asp:Label>
                                    <asp:TextBox CssClass="form-control" style="text-align:center" ID="txtAuthCode" Width="120" runat="server"></asp:TextBox>
                                    </center>
                            </div>
                        </div>
                        <br />
                        <br />
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                    <asp:Label ID="lblStatus" runat="server" Text="" Font-Bold="true"></asp:Label>
                                </center>
                            </div>
                            
                        </div>
                        <br />
                        <br />
                        

                        <div class="row">
                            <div class="col">
                                    <center>
                                        <div class="form-group">
                                            <asp:Button ID="btnProceed" CssClass="btn btn-success btn-block btn-sm" Width="300" runat="server" OnClick="btnProceed_Click" Text="Proceed"></asp:Button>

                                        </div>
                                    </center>
                                </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                    <center>
                                        <div class="form-group">
                                            <asp:Button ID="btnHome" CssClass="btn btn-secondary btn-block btn-sm" Width="300" PostBackUrl="~/Home.aspx" runat="server" Text="Back to Home" />
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
