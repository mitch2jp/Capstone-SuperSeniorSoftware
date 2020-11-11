<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="CoordinatorViewSurveyResults.aspx.cs" Inherits="Lab1.CoordinatorViewSurveyResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
            <div class="col">
                <center>
                    <h2>Survey Results</h2>

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
                            <asp:GridView ID="grdStudentRoster" runat="server" AutoGenerateColumns="False" CellPadding="6"
                                AllowSorting="true" AllowPaging="true" OnSorting="grdStudentRoster_Sorting">  
                                <Columns>  
                                    
                                    <asp:TemplateField HeaderText="SurveyID" SortExpression="SurveyID">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblSurveyID" runat="server" Text='<%#Eval("SurveyID") %>'></asp:Label>  
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
                                    <asp:TemplateField HeaderText="Overall Satisfaction" SortExpression="CyberDaySatisfaction">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblCyberDaySatisfaction" runat="server" Text='<%#Eval("CyberDaySatisfaction") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtCyberDaySatisfaction" runat="server" Text='<%#Eval("CyberDaySatisfaction") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="Activity Satisfaction" SortExpression="ActivitySatisfaction">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblActivitySatisfaction" runat="server" Text='<%#Eval("ActivitySatisfaction") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtActivitySatisfaction" runat="server" Text='<%#Eval("ActivitySatisfaction") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="Volunteer Satisfaction" SortExpression="VolunteerSatisfaction">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblVolunteerSatisfaction" runat="server" Text='<%#Eval("VolunteerSatisfaction") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtVolunteerSatisfaction" runat="server" Text='<%#Eval("VolunteerSatisfaction") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="Higher Education" SortExpression="HigherEducation">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblHigherEducation" runat="server" Text='<%#Eval("HigherEducation") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtHigherEducation" runat="server" Text='<%#Eval("HigherEducation") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="Technical Path" SortExpression="TechnicalPath">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblTechnicalPath" runat="server" Text='<%#Eval("TechnicalPath") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtTechnicalPath" runat="server" Text='<%#Eval("TechnicalPath") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="Comments" SortExpression="Comments">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblComments" runat="server" Text='<%#Eval("Comments") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtComments" runat="server" Text='<%#Eval("Comments") %>'></asp:TextBox>  
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
