<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="CoordinatorAddSchoolConfirmation.aspx.cs" Inherits="Lab1.CoordinatorAddSchoolConfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">
            <div class="col">
                <center>
                    <h2>Step 2: Confirmation </h2>

                </center>
            </div>
        </div>
        <br />
        <br />



    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <asp:Label ID="lblSucess" runat="server" Text="School successfully registered." ForeColor="Green" Font-Bold="true" Font-Size="Large"></asp:Label>
                                </center>
                            </div>
                        </div>
                        <br />
                        <br />
                        
                        <div class="row">
                                <div class="col">
                                    <center>
                                        <div class="form-group">
                                            <asp:Button ID="btnAddSchool" CssClass="btn btn-success btn-block btn-sm" Width="400" PostBackUrl="~/CoordinatorDashboard.aspx" runat="server" Text="Add Another School" />
                                        </div>
                                    </center>
                                </div>
                            </div>
                        <div class="row">
                                <div class="col">
                                    <center>
                                        <div class="form-group">
                                            <asp:Button ID="btnHome" CssClass="btn btn-secondary btn-block btn-sm" Width="400" PostBackUrl="~/CoordinatorDashboard.aspx" runat="server" Text="Back to Dashboard" />
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
