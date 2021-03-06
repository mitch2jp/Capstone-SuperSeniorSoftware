﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="VolunteerAccountConfirmation.aspx.cs" Inherits="Lab1.VolunteerAccountConfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col">
            <center>
            <h2>Step 1: Confirmation </h2>
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
                                <center>
                                    <asp:Label ID="lblSucess" runat="server" Text="Account Successfully Created." ForeColor="Green" Font-Bold="true" Font-Size="Large"></asp:Label>
                                </center>
                            </div>
                        </div>
                        <br />
                        <br />
                        

                        <div class="row">
                                <div class="col">
                                    <center>
                                        <div class="form-group">
                                            <asp:Button ID="btnLogin" CssClass="btn btn-info btn-block btn-sm" Width="400" PostBackUrl="~/VolunteerLogin.aspx" runat="server" Text="Back to Login" />
                                        </div>
                                    </center>
                                </div>
                            </div>
                        <div class="row">
                                <div class="col">
                                    <center>
                                        <div class="form-group">
                                            <asp:Button ID="btnHome" CssClass="btn btn-secondary btn-block btn-sm" Width="400" PostBackUrl="~/Home.aspx" runat="server" Text="Back to Home" />
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
