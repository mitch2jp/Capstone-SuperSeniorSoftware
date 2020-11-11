<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="CreateEvent.aspx.cs" Inherits="Lab1.CreateEvent" %>
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
                                    <asp:RequiredFieldValidator ID="valEventName" ControlToValidate="txtEventName" runat="server" ErrorMessage="" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="lblEventDescription" runat="server" Text="Event Description: "></asp:Label>
                                    <asp:TextBox CssClass="form-control" ID="txtEventDescription" runat="server" TextMode="MultiLine" Width="340" Height="200"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="valEventDescription" ControlToValidate="txtEventDescription" runat="server" ErrorMessage="" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="lblBuilding" runat="server" Text="Building (Select from list): "></asp:Label>
                                    <asp:DropDownList Width="300" CssClass="form-control" ID="ddlBuilding" runat="server">
                                        <asp:ListItem Enabled="true" Text="Choose one"></asp:ListItem>
                                        <asp:ListItem Text="COB Learning Complex"></asp:ListItem>
                                        <asp:ListItem Text="Showker Hall"></asp:ListItem>
                                        <asp:ListItem Text="ISAT/CS"></asp:ListItem>
                                        <asp:ListItem Text="Engineering/Geosciences"></asp:ListItem>
                                        <asp:ListItem Text="Godwin"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="valBuilding" ControlToValidate="ddlBuilding" runat="server" InitialValue="Choose one" ErrorMessage="" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="lblRoom" runat="server" Text="Room: "></asp:Label>
                                    <asp:TextBox CssClass="form-control" ID="txtRoom" Width="150" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="valRoom" ControlToValidate="txtRoom" runat="server" ErrorMessage="" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="valRoomInt" ControlToValidate="txtRoom" Operator="DataTypeCheck" Type="Integer" Text="(Must be a number)" ForeColor="Red" Font-Bold="true"  runat="server" ErrorMessage=""></asp:CompareValidator>

                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblEventDate" runat="server" Text="Event Date:"></asp:Label>
                                        <asp:Calendar ID="calEvent" runat="server" OnSelectionChanged="calEvent_SelectionChanged1" ></asp:Calendar>
                                        <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valDate" ControlToValidate="txtDate" runat="server" ErrorMessage="" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblEventTime" runat="server" Text="Event Time:"></asp:Label>
                                        <asp:TextBox CssClass="form-control" ID="txtEventTime" runat="server" Width="300" TextMode="Time" format></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valTime" ControlToValidate="txtEventTime" runat="server" ErrorMessage="" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        <br />
                        <br />

                         <div class="row">
                            <div class="col">
                                <asp:Label ID="lblVolunteerInstructions" runat="server" Text="Would you like to provide any additional instructions for participating volunteers?: "></asp:Label>
                            </div>
                            <div class="col">
                                <asp:RadioButton ID="rdoYes" GroupName="Instructions" AutoPostBack="true" runat="server" Text="Yes" OnCheckedChanged="rdoYes_CheckedChanged" />
                                <asp:RadioButton ID="rdoNo" GroupName="Instructions" runat="server" AutoPostBack="true" Text="No" OnCheckedChanged="rdoNo_CheckedChanged" />
                                <asp:CustomValidator ID="valRadioButtons" ClientValidationFunction="valRadioButtons_ClientValidate" OnServerValidate="valRadioButtons_ServerValidate" runat="server" ErrorMessage="" Text="(Required)" ForeColor="Red" Font-Bold="true"></asp:CustomValidator>

                            </div>
                        </div>
                        <br />
                        <br />


                        <div id="divVolunteerInstructions" runat="server" class="container-fluid" visible="false" >
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="txtVolunteerInstructions" runat="server" TextMode="MultiLine" Width="400" Height="200" placeholder="Enter volunteer instructions here"></asp:TextBox>
                                            
                                        </div>
                                    </div>
                                </div>
                        </div>
                        <br />
                        <br />

                        <%--<div class="row">
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
                            </div>--%>

                        <div class="row">
                                <div class="col">
                                    <asp:Label ID="lblStatus" runat="server" Text="" Font-Bold="true"></asp:Label>
                                </div>
                            </div>
                        <br />
                        <br />

                        <div class="row">
                                <div class="col">
                                    <div class="form-group">
                                        <asp:Button ID="btnCreateEvent" CssClass="btn btn-success btn-block btn-lg" runat="server" OnClick="btnCreateEvent_Click" Text="Create Event" />
                                    </div>
                                    <div class="form-group">
                                        <asp:Button ID="btnCancel" CausesValidation="false" CssClass="btn btn-danger btn-block btn-lg" PostBackUrl="~/CoordinatorDashboard.aspx" runat="server" Text="Cancel" />
                                    </div>
                                </div>
                            </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
