<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="TeacherValidateParents.aspx.cs" Inherits="Lab1.TeacherValidateParents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
            <div class="col">
                <center>
                    <h2>Parent Authorization</h2>

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
                            <asp:GridView ID="grdParentAuthorization" runat="server" AutoGenerateColumns="False" CellPadding="6"
                                OnSorting="grdParentAuthorization_Sorting" OnRowCommand="grdParentAuthorization_RowCommand">  
                                <Columns>  
                                    <asp:TemplateField HeaderText="ValidationID" SortExpression="ValidationID">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblValidationID" runat="server" Text='<%#Eval("ValidationID") %>'></asp:Label>  
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
                                    <asp:TemplateField HeaderText="Email" SortExpression="EmailAddress">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblEmailAddress" runat="server" Text='<%#Eval("EmailAddress") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtEmailAddress" runat="server" Text='<%#Eval("EmailAddress") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="Phone" SortExpression="PhoneNumber">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblPhoneNumber" runat="server" Text='<%#Eval("PhoneNumber") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtPhoneNumber" runat="server" Text='<%#Eval("PhoneNumber") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="Authorized" SortExpression="Authorized">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblAuthorized" runat="server" Text='<%#Eval("Authorized") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtAuthorized" runat="server" Text='<%#Eval("Authorized") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField>
                                    <asp:TemplateField> 
                                        <ItemTemplate>
                                            <asp:Button ID="btn_Authorize" CssClass="btn btn-warning btn-block btn-sm" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnClick="btn_Authorize_Click" runat="server" Text="Authorize" CommandName="Authorize" />  
                                        </ItemTemplate>
                                        
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
            <div class="row">
                <div class="col mx-auto" style="width:auto">
                    <center>
                        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                    </center>
                </div>
            </div>




            <br />
            <br />
            <div class="row">
                <div class="col mx-auto" style="width:auto">
                    <center>
                    <asp:Button ID="btnBack" CssClass="btn btn-info btn-block btn-md" Width="250" runat="server" PostBackUrl="~/TeacherDashboard.aspx" Text="Back to Dashboard " />
                    </center>
                </div>
            </div>
            <br />
            <br />
        </center>
    </div>


</asp:Content>
