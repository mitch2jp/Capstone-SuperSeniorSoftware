<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="VolunteerRoster.aspx.cs" Inherits="Lab1.VolunteerRoster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
            <div class="col">
                <center>
                    <h2>Volunteer Roster</h2>

                </center>
            </div>
        </div>
        <br />
        <br />

    <div class="container-fluid">
        <center>
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div>      
                            <asp:GridView ID="grdVolunteerRoster" runat="server" AutoGenerateColumns="False" CellPadding="6"
                                 OnRowCancelingEdit="grdVolunteerRoster_RowCancelingEdit" OnRowEditing="grdVolunteerRoster_RowEditing"
                                OnRowUpdating="grdVolunteerRoster_RowUpdating" OnRowDeleting="grdVolunteerRoster_RowDeleting" AllowSorting="true" AllowPaging="true" OnSorting="grdVolunteerRoster_Sorting1">  
                                <Columns>  
                                    <asp:TemplateField>  
                                        <ItemTemplate>  
                                            <asp:Button ID="btn_Edit" runat="server" CssClass="btn btn-info btn-block btn-sm" Text="Edit" CommandName="Edit" />  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:Button ID="btn_Update" CssClass="btn btn-success btn-block btn-sm" runat="server" Text="Update" CommandName="Update"/>  
                                            <asp:Button ID="btn_delete" CssClass="btn btn-warning btn-block btn-sm" runat="server" Text="Delete" CommandName="Delete"/>
                                            <asp:Button ID="btn_Cancel" CssClass="btn btn-danger btn-block btn-sm" runat="server" Text="Cancel" CommandName="Cancel"/>
                                        </EditItemTemplate>  
                                    </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="VolunteerID" SortExpression="VolunteerID">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblVolunteerID" runat="server" Text='<%#Eval("VolunteerID") %>'></asp:Label>  
                                        </ItemTemplate>  
                                    </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="First Name" SortExpression="FirstName">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("FirstName") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtFirstName" runat="server" Text='<%#Eval("FirstName") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="Last Name" SortExpression="LastName">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblLastName" runat="server" Text='<%#Eval("LastName") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtLastName" runat="server" Text='<%#Eval("LastName") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="Email Address" SortExpression="EmailAddress">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblEmailAddress" runat="server" Text='<%#Eval("EmailAddress") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtEmailAddress" runat="server" Text='<%#Eval("EmailAddress") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField> 
                                    <asp:TemplateField HeaderText="Phone Number" SortExpression="PhoneNumber">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblPhoneNumber" runat="server" Text='<%#Eval("PhoneNumber") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtPhoneNumber" runat="server" Text='<%#Eval("PhoneNumber") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="Gender" SortExpression="Gender">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblGender" runat="server" Text='<%#Eval("Gender") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtGender" runat="server" Text='<%#Eval("Gender") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField>  
                                    
                                    <asp:TemplateField HeaderText="Meal Ticket" SortExpression="MealTicket">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblMealTicket" runat="server" Text='<%#Eval("MealTicket") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtMealTicket" runat="server" Text='<%#Eval("MealTicket") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField>  

                                    <asp:TemplateField HeaderText="Major" SortExpression="Major">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblMajor" runat="server" Text='<%#Eval("Major") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtMajor" runat="server" Text='<%#Eval("Major") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField>  
                                    
                                    <asp:TemplateField HeaderText="Prior Participation" SortExpression="PriorParticipation">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblPriorParticipation" runat="server" Text='<%#Eval("PriorParticipation") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtPriorParticipation" runat="server" Text='<%#Eval("PriorParticipation") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="Organization" SortExpression="OrganizationAfilliation">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblOrganizationAfilliation" runat="server" Text='<%#Eval("OrganizationAfilliation") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtOrganizationAfilliation" runat="server" Text='<%#Eval("OrganizationAfilliation") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Type" SortExpression="Type">  
                                        <ItemTemplate>  
                                            <asp:Label ID="txtType" runat="server" Text='<%#Eval("Type") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtType" runat="server" Text='<%#Eval("Type") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField> 
                                </Columns>  
                                <HeaderStyle BackColor="#663300" ForeColor="#ffffff"/>  
                                <RowStyle BackColor="#e7ceb6"/>  
                            </asp:GridView>  
      
                        </div>   
                        
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
        </center>
    </div>







    

</asp:Content>
