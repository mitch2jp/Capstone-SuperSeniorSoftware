<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="CreateEventSuccess.aspx.cs" Inherits="Lab1.CreateEventSuccess" %>
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
                                    <asp:Label ID="lblSucess" runat="server" Text="Event created sucessfully" ForeColor="Green" Font-Bold="true" Font-Size="Large"></asp:Label>
                                </center>
                            </div>
                        </div>
                        <br />
                        <br />
                        

                        <div class="row">
                                <div class="col">
                                    <center>
                                        <div class="form-group">
                                            <asp:Button ID="btnCreateAnotherEvent" CssClass="btn btn-info btn-block btn-sm" Width="400" runat="server" PostBackUrl="~/CreateEvent.aspx" Text="Create Another Event" />
                                        </div>
                                        <div class="form-group">
                                            <asp:Button ID="Button2" CssClass="btn btn-secondary btn-block btn-sm" Width="400" PostBackUrl="~/CoordinatorDashboard.aspx" runat="server" Text="Back to Dashboard" />
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
