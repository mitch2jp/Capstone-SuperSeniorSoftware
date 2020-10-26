<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="EditStudentInfo.aspx.cs" Inherits="Lab1.EditStudentInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table runat="server" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblInstructions" runat="server" Text="Enter a Student's Last Name to search"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>


    <asp:Table ID="Table1" runat="server" HorizontalAlign="Center" BorderStyle="Solid">
        <asp:TableRow>
            <asp:TableCell>
                <asp:TextBox ID="txtStudentSearch" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <br />
    <br />


    <asp:GridView ID="GridView1" HeaderStyle-BackColor="SteelBlue" HeaderStyle-ForeColor="White" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" HorizontalAlign="Center" Width="1123px">  
                <Columns>  
                    <asp:BoundField ReadOnly="true" DataField="StudentID" HeaderText="StudentID" SortExpression="StudentID" />
                     <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                     <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                     <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                     <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" />
                     <asp:BoundField DataField="TShirtSize" HeaderText="T-Shirt Size" SortExpression="TShirtSize" />
                     <asp:BoundField DataField="TSHirtColor" HeaderText="T-Shirt Color" SortExpression="TSHirtColor" />
                     <asp:BoundField DataField="TShirtDescription" HeaderText="T-Shirt Description" SortExpression="TShirtDescription" /> 
                    <asp:TemplateField>  
                        <ItemTemplate>  
                            <asp:Button ID="btnEdit" runat="server" Width="60" Text="Edit" CommandName="EditButton" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />  
                        </ItemTemplate>  
                    </asp:TemplateField>  
                </Columns>  
            </asp:GridView>  









    <%--<asp:GridView
        ID="grdStudents"
        runat="server"
         DataKeyNames="StudentID"
         DataSourceID="srcStudents"
         AutoGenerateEditButton="true"
         AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField ReadOnly="true" DataField="StudentID" HeaderText="StudentID" SortExpression="StudentID" />
             <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
             <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
             <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
             <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" />
             <asp:BoundField DataField="TShirtSize" HeaderText="T-Shirt Size" SortExpression="TShirtSize" />
             <asp:BoundField DataField="TSHirtColor" HeaderText="T-Shirt Color" SortExpression="TSHirtColor" />
             <asp:BoundField DataField="TShirtDescription" HeaderText="T-Shirt Description" SortExpression="TShirtDescription" />
        </Columns>
        

    </asp:GridView>




    

    <asp:SqlDataSource ID="srcStudents"
        runat="server"
         ConnectionString="<%$ ConnectionStrings:Lab3 %>"
         SelectCommand="Select s.StudentID, s.FirstName, s.LastName, s.Age, s.Notes, s.LunchTicket, s.TShirtSize, s.TSHirtColor, s.TShirtDescription
        FROM Student s, Teacher t
        WHERE s.TeacherID = t.TeacherID AND t.Username = @Username AND s.LastName = @LastName"
         UpdateCommand="UPDATE Student SET FirstName = @FirstName, LastName = @LastName, Age = @Age, Notes = @Notes, LunchTicket = @LunchTicket,
         TShirtSize = @TShirtSize, TSHirtColor = @TShirtColor, TShirtDescription = @TShirtDescription WHERE StudentID = @StudentID">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtStudentSearch" Name="LastName" PropertyName="Text" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Type="String" Name="FirstName" />
            <
        </UpdateParameters>
    </asp:SqlDataSource>--%>

    
    

</asp:Content>
