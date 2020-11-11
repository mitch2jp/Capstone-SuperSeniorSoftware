<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="TeacherItinerary.aspx.cs" Inherits="Lab1.TeacherSelectEvents" %>
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
                            <asp:GridView ID="grdItinerary" runat="server" AutoGenerateColumns="False" CellPadding="6" AllowSorting="true" AllowPaging="true" OnSorting="grdItinerary_Sorting">  
                                <Columns>  
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
                    <asp:Button ID="btnBack" CssClass="btn btn-info btn-block btn-md" Width="250" runat="server" PostBackUrl="~/VolunteerDashboard.aspx" Text="Back to Dashboard " />
                    </center>
                </div>
            </div>
            <br />
            <br />
        
    </div>
</asp:Content>
