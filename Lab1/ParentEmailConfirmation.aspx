<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="ParentEmailConfirmation.aspx.cs" Inherits="Lab1.EmailConfirmation" %>
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
                                <center>
                                    <h2>Step 2: </h2>

                                </center>
                            </div>
                        </div>
                        <br />
                        <br />

                        <div class="row">
                            <div class="col">
                                <center>
                                    <asp:Label ID="lblConfirm" runat="server" Text="" ForeColor="Green" Font-Bold="true" Font-Size="Large"></asp:Label>
                                </center>
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
                                    <asp:Label ID="lblRegistrationCode" runat="server" Text="Registration Code: "></asp:Label>
                                    <asp:TextBox CssClass="form-control" ID="txtAuthCode" Width="200" runat="server"></asp:TextBox>
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
