<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="CoordinatorSchoolInfo.aspx.cs" Inherits="Lab1.CoordinatorSchoolInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
            <div class="col">
                <center>
                    <h2>School Information</h2>

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
                            <asp:GridView ID="grdSchoolInfo" runat="server" AutoGenerateColumns="False" CellPadding="6"
                                  OnRowCancelingEdit="grdVolunteerRoster_RowCancelingEdit" OnRowEditing="grdVolunteerRoster_RowEditing"
                                 OnRowUpdating="grdVolunteerRoster_RowUpdating" OnRowDeleting="grdVolunteerRoster_RowDeleting" AllowSorting="true" AllowPaging="true" OnSorting="grdVolunteerRoster_Sorting">  
                                <Columns>  
                                    <asp:TemplateField>  
                                        <ItemTemplate>  
                                            <asp:Button ID="btn_Edit" runat="server" CssClass="btn btn-info btn-block btn-sm" Text="Edit" CommandName="Edit" />  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:Button ID="btn_Update" CssClass="btn btn-success btn-block btn-sm" runat="server" Text="Update" CommandName="Update"/>  
                                            <%--<asp:Button ID="btn_delete" CssClass="btn btn-warning btn-block btn-sm" runat="server" Text="Delete" CommandName="Delete"/>--%>
                                            <asp:Button ID="btn_Cancel" CssClass="btn btn-danger btn-block btn-sm" runat="server" Text="Cancel" CommandName="Cancel"/>
                                        </EditItemTemplate>  
                                    </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="SchoolID" SortExpression="SchoolID">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblSchoolID" runat="server" Text='<%#Eval("SchoolID") %>'></asp:Label>  
                                        </ItemTemplate>  
                                    </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="School" SortExpression="SchoolName">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblSchoolName" runat="server" Text='<%#Eval("SchoolName") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtSchoolName" runat="server" Text='<%#Eval("SchoolName") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="Main Phone" SortExpression="PhoneNumber">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblPhoneNumber" runat="server" Text='<%#Eval("PhoneNumber") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtPhoneNumber" runat="server" Text='<%#Eval("PhoneNumber") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="Principal" SortExpression="PrincipalName">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblPrincipalName" runat="server" Text='<%#Eval("PrincipalName") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtPrincipalName" runat="server" Text='<%#Eval("PrincipalName") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField> 
                                    <asp:TemplateField HeaderText="Principal's Email" SortExpression="PrincipalEmail">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblPrincipalEmail" runat="server" Text='<%#Eval("PrincipalEmail") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtPrincipalEmail" runat="server" Text='<%#Eval("PrincipalEmail") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="Guidance Counselor" SortExpression="GuidanceName">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblGuidanceName" runat="server" Text='<%#Eval("GuidanceName") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtGuidanceName" runat="server" Text='<%#Eval("GuidanceName") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField>  
                                    
                                    <asp:TemplateField HeaderText="Guidance Counselor's Email" SortExpression="GuidanceEmail">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblGuidanceEmail" runat="server" Text='<%#Eval("GuidanceEmail") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtGuidanceEmail" runat="server" Text='<%#Eval("GuidanceEmail") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField>  

                                    <asp:TemplateField HeaderText="Guidance Counselor's Phone" SortExpression="GuidancePhone">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblGuidancePhone" runat="server" Text='<%#Eval("GuidancePhone") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtGuidancePhone" runat="server" Text='<%#Eval("GuidancePhone") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField>  
                                    
                                    <asp:TemplateField HeaderText="Address" SortExpression="Address">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtAddress" runat="server" Text='<%#Eval("Address") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="City" SortExpression="City">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblCity" runat="server" Text='<%#Eval("City") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtCity" runat="server" Text='<%#Eval("City") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="State" SortExpression="State">  
                                        <ItemTemplate>  
                                            <asp:Label ID="txtState" runat="server" Text='<%#Eval("State") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtState" runat="server" Text='<%#Eval("State") %>'></asp:TextBox>  
                                        </EditItemTemplate>  
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Zip" SortExpression="Zip">  
                                        <ItemTemplate>  
                                            <asp:Label ID="txtZip" runat="server" Text='<%#Eval("Zip") %>'></asp:Label>  
                                        </ItemTemplate>  
                                        <EditItemTemplate>  
                                            <asp:TextBox ID="txtZip" runat="server" Text='<%#Eval("Zip") %>'></asp:TextBox>  
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
