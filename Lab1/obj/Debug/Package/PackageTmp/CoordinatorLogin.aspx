<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="CoordinatorLogin.aspx.cs" Inherits="Lab1.CoordinatorLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center><img width="150px" src="images/dukes.png" 
                                    </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                        <h3>Coordinator Login</h3>
                                    </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:Label ID="lblUsername" runat="server" Text=""></asp:Label>
                                    <asp:TextBox CssClass="form-control" placeholder="Username" ID="txtUsername" runat="server"></asp:TextBox>

                                </div>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" TextMode="Password" placeholder="Password" ID="txtPassword" runat="server"></asp:TextBox>

                                </div>

                                <div class="form-group">
                                    <asp:Button ID="btnLogin" CssClass="btn btn-success btn-block btn-lg" runat="server" Text="Login" OnClick="btnLogin_Click" />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>

                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
