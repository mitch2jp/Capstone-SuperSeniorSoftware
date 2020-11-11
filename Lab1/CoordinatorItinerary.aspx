<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="CoordinatorItinerary.aspx.cs" Inherits="Lab1.CoordinatorEventInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">
        <div class="col">
            <center>
                <h2>CyberDay Itinerary</h2>

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
                       <%-- <div class="row">
                            <div class="col">
                                <asp:Button ID="btnModify" OnClick="btnModify_Click" CssClass="btn btn-warning btn-block btn-sm" Width="200" runat="server" Text="Modify" />
                            </div>
                        </div>
                        <br />--%>

                        <center>
                        <div>      
                            <asp:GridView ID="grdItinerary" runat="server" AutoGenerateColumns="False" CellPadding="6"
                                 OnRowCancelingEdit="grdItinerary_RowCancelingEdit" OnRowEditing="grdItinerary_RowEditing"
                                 OnRowUpdating="grdItinerary_RowUpdating" OnRowDeleting="grdItinerary_RowDeleting" AllowSorting="true"
                                AllowPaging="true" OnSorting="grdItinerary_Sorting">  
                                <Columns>  
                                    <asp:TemplateField>  
                                        <ItemTemplate>  
                                            <asp:Button ID="btn_Edit" CssClass="btn btn-info btn-block btn-sm" runat="server" Text="Edit" CommandName="Edit" />  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:Button ID="btn_Update" CssClass="btn btn-success btn-block btn-sm"  runat="server" Text="Update" CommandName="Update"/>  
                                            <asp:Button ID="btn_delete" CssClass="btn btn-warning btn-block btn-sm" runat="server" Text="Delete" CommandName="Delete"/>
                                            <asp:Button ID="btn_Cancel" CssClass="btn btn-danger btn-block btn-sm" runat="server" Text="Cancel" CommandName="Cancel"/>
                                        </EditItemTemplate>  
                                    </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="EventID" SortExpression="EventID">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblEventID" runat="server" Text='<%#Eval("EventID") %>'></asp:Label>  
                                        </ItemTemplate>  
                                    </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="Event Name" SortExpression="EventName">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblEventName" runat="server" Text='<%#Eval("EventName") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtEventName" runat="server" Text='<%#Eval("EventName") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="Date" SortExpression="Date">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Date") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtDate" runat="server" Text='<%#Eval("Date") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="Time" SortExpression="Time">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblTime" runat="server" Text='<%#Eval("Time") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtTime" runat="server" Text='<%#Eval("Time") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="Building" SortExpression="Building">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblBuilding" runat="server" Text='<%#Eval("Building") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtBuilding" runat="server" Text='<%#Eval("Building") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="Room" SortExpression="Room">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblRoom" runat="server" Text='<%#Eval("Room") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtRoom" runat="server" Text='<%#Eval("Room") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="Volunteer Instructions" SortExpression="VolunteerInstructions">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblVolunteerInstructions" runat="server" Text='<%#Eval("VolunteerInstructions") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtVolunteerInstructions" TextMode="MultiLine" Width="200" Height="200" runat="server" Text='<%#Eval("VolunteerInstructions") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="Event Description" SortExpression="EventDescription">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblEventDescription"  runat="server" Text='<%#Eval("EventDescription") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtEventDescription" TextMode="MultiLine" Width="200" Height="200" runat="server" Text='<%#Eval("EventDescription") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField>  
                                </Columns>  
                                <HeaderStyle BackColor="#663300" ForeColor="#ffffff"/>  
                                <RowStyle BackColor="#e7ceb6"/>  
                            </asp:GridView>  
      
                        </div> 
                        </center>
                        
                    </div>
                </div>
            </div>
        </div>
            <br />
            <br />
            <div class="row">
                <div class="col mx-auto" style="width:auto">
                    <center>
                    <asp:Button ID="btnBack" CssClass="btn btn-info btn-block btn-md" Width="250" runat="server" PostBackUrl="~/CoordinatorDashboard.aspx" Text="Back to Dashboard " />
                    </center>
                </div>
            </div>
            <br />
            <br />
        
    </div>





    <%--<div class="container-fluid" style="border:1px solid #4a2482">
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
                                                <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                                                <asp:BoundField DataField="Time" HeaderText="Time" SortExpression="Time" />
                                                <asp:BoundField DataField="Building" HeaderText="Building" SortExpression="Building" />
                                                <asp:BoundField DataField="Room" HeaderText="Room" SortExpression="Room" />
                                                <asp:BoundField DataField="EventDescription" HeaderText="EventDescription" SortExpression="EventDescription" ItemStyle-Width="200" ItemStyle-Height="100" />
                                                <asp:TemplateField>  
                                                    <ItemTemplate>  
                                                        <asp:Button CssClass="form-control btn btn-primary btn-block"  ID="btnView" runat="server" Width="100" Text="View" PostBackUrl="~/CoordinatorEventDetails.aspx" CommandName="RegisterButton" />  
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
                                        <asp:Button ID="btnBackToDashboard" CssClass="btn btn-success btn-block btn-lg" runat="server" PostBackUrl="~/CoordinatorDashboard.aspx" Width="400" Text="Back to Dashboard" />
                                    </div>
                                    
                                    </center>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
     </div>--%>




</asp:Content>
