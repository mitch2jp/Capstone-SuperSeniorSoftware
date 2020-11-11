<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="StudentSurveyConfirmation.aspx.cs" Inherits="Lab1.StudentSurveyConfirmation" %>
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
                                    <asp:Label ID="lblSucess" runat="server" Text="Survey submitted successfully. " ForeColor="Green" Font-Bold="true" Font-Size="Large"></asp:Label>
                                </center>
                            </div>
                        </div>
                        <br />
                        <br />
                        

                        <div class="row">
                                <div class="col">
                                    <center>
                                        <div class="form-group">
                                            <asp:Button ID="BtnBackDashboard" CssClass="btn btn-secondary btn-block btn-sm" Width="400" PostBackUrl="~/StudentDashboard.aspx" runat="server" Text="Back to Dashboard" />
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
