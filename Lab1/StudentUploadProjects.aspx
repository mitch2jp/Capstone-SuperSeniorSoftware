<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="StudentUploadProjects.aspx.cs" Inherits="Lab1.UploadProjects" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <div class="container">
            
            <div id="divStudentInfo" runat="server" class="container-fluid" style="border:1px dashed #000000" >
                
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label ID="lblPageInstructions"  runat="server" Font-Bold="true" Text="Please select a file to upload: "></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <div class="form-group">
                            <asp:FileUpload ID="fileUpload" runat="server"></asp:FileUpload>
                        </div>
                    </div>
                    <div class="col">
                        <div class="form-group">
                            <asp:Button CssClass="btn btn-primary btn-block btn-sm" ID="btnFileUpload" Width="200" runat="server" Text="Upload File" OnClick="btnFileUpload_Click"></asp:Button>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <div class="form-group">
                            <asp:Label ID="lblUploadStatus" ForeColor="Green" Font-Bold="true" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            
            </div>
            <br />
            <br />




        <div>
            <center>
                <asp:Button ID="Button1" CssClass="btn btn-success btn-block btn-lg" runat="server" PostBackUrl="~/StudentDashboard.aspx" Width="400" Text="Back to Dashboard" />
            </center>
        </div>
    </div>
    <br />
    <br />


</asp:Content>
