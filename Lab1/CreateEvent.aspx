<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="CreateEvent.aspx.cs" Inherits="Lab1.CreateEvent" %>
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
                                    <img width="100px" src="Images/new-event.png" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3></h3>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <h4>Please enter the event's information: </h4>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="lblEventName" runat="server" Text="Event Name: "></asp:Label>
                                    <asp:TextBox CssClass="form-control" Width="300" placeholder="Event Name" ID="txtEventName" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="lblEventDescription" runat="server" Text="Event Description: "></asp:Label>
                                    <asp:TextBox CssClass="form-control" ID="txtEventDescription" runat="server" TextMode="MultiLine" Width="300" Height="200"></asp:TextBox>

                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="lblBuilding" runat="server" Text="Building (Select from list): "></asp:Label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlBuilding" runat="server">
                                        <asp:ListItem Enabled="true" Text="Choose one" Value="-1"></asp:ListItem>
                                        <asp:ListItem Text="COB Learning Complex" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Showker Hall" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="ISAT/CS" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="Engineering/Geosciences" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="Godwin" Value="6"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="lblRoom" runat="server" Text="Room: "></asp:Label>
                                    <asp:TextBox CssClass="form-control" ID="txtRoom" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblEventTime" runat="server" Text="Event Time:"></asp:Label>
                                        <asp:TextBox CssClass="form-control" ID="txtEventTime" runat="server" Width="200" TextMode="Time"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblEventDate" runat="server" Text="Event Date:"></asp:Label>
                                        <asp:Calendar ID="calEvent" runat="server" OnSelectionChanged="calEvent_SelectionChanged1" ></asp:Calendar>
                                    </div>
                                </div>
                            </div>

                        <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblSchoolContact" runat="server" Text="School Contact (Select from list)"></asp:Label>
                                        <asp:DropDownList CssClass="form-control" ID="ddlSchoolContact" runat="server">
                                            <asp:ListItem Enabled="true" Text="Choose One" Value="-1"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                    </div>
                                </div>
                            </div>

                        <div class="row">
                                <div class="col">
                                    <div class="form-group">
                                        <asp:Button ID="btnCreateEvent" CssClass="btn btn-success btn-block btn-lg" runat="server" PostBackUrl="~/CreateEventSuccess.aspx" Text="Create Event" />
                                    </div>
                                    <div class="form-group">
                                        <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-block btn-lg" PostBackUrl="~/CoordinatorDashboard.aspx" runat="server" Text="Cancel" />
                                    </div>
                                </div>
                            </div>

                        

                    </div>

                    
                </div>

            </div>

        </div>

    </div>
</asp:Content>
