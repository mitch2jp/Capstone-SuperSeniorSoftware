﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="SelectEvents.aspx.cs" Inherits="Lab1.SelectEvents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" style="border:1px solid #4a2482">
            <div class="row">
                <div class="col-md-6 mx-auto">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col">
                                        <asp:Label ID="lblPageInstructions" runat="server" Font-Size="Large" Text="Please select one or more events to register: "></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col">
                                    <center>

                                        <asp:GridView ID="grdEvents" HeaderStyle-BackColor="SteelBlue" HeaderStyle-ForeColor="White" runat="server" AutoGenerateColumns="false" OnRowCommand="grdEvents_RowCommand" HorizontalAlign="Center" Width="1123px">  
                                            <Columns>  
                                                <asp:BoundField DataField="EventName" HeaderText="Event Name" SortExpression="EventName" />
                                                <asp:BoundField DataField="DateTime" HeaderText="Date & Time" SortExpression="DateTime" />
                                                <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
                                                <asp:TemplateField>  
                                                    <ItemTemplate>  
                                                        <asp:Button CssClass="form-control btn btn-primary btn-block" ID="btnRegister" runat="server" Width="100" Text="Register" CommandName="RegisterButton" on />  
                                                    </ItemTemplate>  
                                                </asp:TemplateField>  
                                            </Columns>  
                                        </asp:GridView>  
                                        
                                    </center>
                                </div>
                            </div>
                            <br />
                            <br />



                            <div class="row">
                                <div class="col">
                                    <center>
                                    <div class="form-group">
                                        <asp:Button ID="btnFinish" CssClass="btn btn-success btn-block btn-lg" runat="server" PostBackUrl="~/SelectEvents.aspx" Width="400" Text="Finish" />
                                    </div>
                                    <div class="form-group">
                                        <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-block btn-lg" PostBackUrl="~/Home.aspx" Width="400" runat="server" Text="Cancel" />
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
