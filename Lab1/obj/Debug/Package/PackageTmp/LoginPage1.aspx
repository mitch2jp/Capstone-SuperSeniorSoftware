<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="TestApp.LoginPage" %>
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
                                    <h3>User Login</h3>
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
                                    <asp:TextBox CssClass="form-control" placeholder="Username" ID="TextBox1" runat="server"></asp:TextBox>
                                
                                </div>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" TextMode="Password" placeholder="Username" ID="TextBox2" runat="server"></asp:TextBox>
                                
                                </div>

                                <div class="form-group">
                                    <asp:Button ID="Button1" CssClass="btn btn-success btn-block btn-lg" runat="server" Text="Login" />
                                
                                </div>

                                <div class="form-group">
                                    <asp:Button ID="Button2" CssClass="btn btn-info btn-block btn-lg" runat="server" Text="Sign Up" />
                                
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
