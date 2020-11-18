<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="ParentStudentRegistrationConfirmation.aspx.cs" Inherits="Lab1.StudentRegistrationConfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="row">
            <div class="col">
                <center>
                    <h2>Step 5: Confirmation</h2>
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
                                    <center><img width="150px" height="150px" src="Images/success.png" />
                                    </center>
                                </div>
                            </div>
                            <br />
                        <div class="row">
                            <div class="col">
                                <center>
                                    <asp:Label ID="lblSucess" runat="server" Text="Registration Successful!" ForeColor="Green" Font-Bold="true" Font-Size="Large"></asp:Label>
                                </center>
                            </div>
                        </div>
                        <br />
                        <br />

                        <div class="row">
                            <div class="col">
                                <center>
                                    <asp:Label ID="lblInstructions" runat="server" Text="" Font-Size="Large"></asp:Label>
                                </center>
                            </div>
                        </div>
                        <br />
                        <br />

                        <div class="row">
                            <div class="col">
                                <center>
                                    <asp:Label ID="lblStatus" runat="server" Text="" Font-Size="Large"></asp:Label>
                                </center>
                            </div>
                        </div>
                        <br />
                        <br />
                        

                        <div class="row">
                                <div class="col">
                                    <center>
                                        <div class="form-group">
                                            <asp:Button ID="btnItinerary" CssClass="btn btn-info btn-block btn-sm" Width="400" runat="server" PostBackUrl="~/ParentStudentItinerary.aspx" Text="View Itinerary" />
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
