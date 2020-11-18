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
        <center>
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div>      
                            <asp:GridView ID="grdStudentRoster" runat="server" AutoGenerateColumns="False" CellPadding="6"
                                OnRowCancelingEdit="grdStudentRoster_RowCancelingEdit" OnRowEditing="grdStudentRoster_RowEditing"
                                OnRowUpdating="grdStudentRoster_RowUpdating" OnRowDeleting="grdStudentRoster_RowDeleting" AllowSorting="true" AllowPaging="true" OnSorting="grdStudentRoster_Sorting">  
                                <Columns>  
                                    <asp:TemplateField>  
                                        <ItemTemplate>  
                                            <asp:Button ID="btn_Edit" CssClass="btn btn-info btn-block btn-sm" runat="server"  Text="Edit" CommandName="Edit" />  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:Button ID="btn_Update" CssClass="btn btn-success btn-block btn-sm" runat="server" Text="Update" CommandName="Update"/>  
                                            <asp:Button ID="btn_delete" CssClass="btn btn-warning btn-block btn-sm" runat="server" Text="Delete" CommandName="Delete"/>
                                            <asp:Button ID="btn_Cancel" CssClass="btn btn-danger btn-block btn-sm" runat="server" Text="Cancel" CommandName="Cancel"/>
                                        </EditItemTemplate>  
                                    </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="StudentID" SortExpression="StudentID">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblStudentID" runat="server" Text='<%#Eval("StudentID") %>'></asp:Label>  
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
                                    <asp:TemplateField HeaderText="Age" SortExpression="Age">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblAge" runat="server" Text='<%#Eval("Age") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtAge" runat="server" Text='<%#Eval("Age") %>'></asp:TextBox>  
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
                                    <asp:TemplateField HeaderText="Notes" SortExpression="Notes">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblNotes" runat="server" Text='<%#Eval("Notes") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtNotes" runat="server" Text='<%#Eval("Notes") %>'></asp:TextBox>  
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
                                    <asp:TemplateField HeaderText="Photo Authorization" SortExpression="PhotoAuthorization">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblPhotoAuthorization" runat="server" Text='<%#Eval("PhotoAuthorization") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtPhotoAuthorization" runat="server" Text='<%#Eval("PhotoAuthorization") %>'></asp:TextBox>  
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
                                    <asp:TemplateField HeaderText="School" SortExpression="SchoolName">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblSchoolName" runat="server" Text='<%#Eval("SchoolName") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <%--<EditItemTemplate>  
                                            <asp:TextBox ID="txtSchoolName" runat="server" Text='<%#Eval("SchoolName") %>'></asp:TextBox>
                                            <asp:DropDownList ID="ddlSchool" AppendDataBoundItems="true" runat="server"></asp:DropDownList>
                                        </EditItemTemplate> --%> 
                                    </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="Teacher" SortExpression="LastName">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblTeacherLastName" runat="server" Text='<%#Eval("LastName") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <%--<EditItemTemplate>  
                                            <asp:TextBox ID="txtTeacherLastName" runat="server" Text='<%#Eval("LastName") %>'></asp:TextBox>  
                                        </EditItemTemplate> --%> 
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
