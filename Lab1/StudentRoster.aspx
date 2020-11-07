<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="StudentRoster.aspx.cs" Inherits="Lab1.StudentRoster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
            <div class="col">
                <center>
                    <h2>Student Roster</h2>

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
                        <div class="row">
                            <div class="col mx-auto" style="width:auto">
                                
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col mx-auto" style="width:auto">
                                <asp:GridView ID="grdStudentRoster" AllowSorting="true" OnSorting="grdStudentRoster_Sorting" HeaderStyle-BackColor="SteelBlue" HeaderStyle-ForeColor="White" runat="server" AutoGenerateColumns="false" HorizontalAlign="Center" Width="1123px">  
                                        <Columns>  
                                            <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                                            <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                                            <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                                            <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                                            <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" />
                                            <asp:BoundField DataField="MealTicket" HeaderText="MealTicket" SortExpression="MealTicket" />
                                            <asp:BoundField DataField="PhotoAuthorization" HeaderText="Photo Authorization" SortExpression="PhotoAuthorization" />
                                            <asp:BoundField DataField="PriorParticipation" HeaderText="Prior Participation" SortExpression="PriorParticipation" />
                                            <asp:BoundField DataField="SchoolName" HeaderText="School" SortExpression="SchoolName" />
                                            <asp:BoundField DataField="LastName" HeaderText="Teacher" SortExpression="LastName" />
                                            
                                            
                                        </Columns>  
                                    </asp:GridView>  
                            </div>
                        </div>
                        <br />
                        <br />
                        <br />

                        <div class="row">
                            <div class="col mx-auto" style="width:auto">
                                <center>
                                <asp:Button ID="btnBack" CssClass="btn btn-info btn-block btn-md" Width="250" runat="server" PostBackUrl="~/CoordinatorDashboard.aspx" Text="Back to Dashboard " />
                                </center>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
