<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="ParentPhotoReleaseAuth.aspx.cs" Inherits="Lab1.ParentPhotoReleaseAuth" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
            <div class="col">
                <center>
                    <h2>Step 4: Photo Authorization</h2>
                </center>
            </div>
        </div>
        <br />
        <br />


    <div class="container">
            <div class="row">
                <div class="col-md-8 mx-auto">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col">
                                    
                                        <h4 class="font-weight-bold">Dear Parent/Guardian:</h4>
                                        <p>During the school year, we take photographs of school activities involving students to share the school's positive vibe and updates.
                                            By which incidentally, some photographs may capture your child's participation, directly or indirectly.</p>
                                        <br />
                                        <p>These photos may be published through our website, social media pages, news bulletins, billboards, and ads.</p>
                                        <br />
                                        <p>With this, we seek for your consent in allowing us to publish photos which may involve your child to the said platforms.</p>
                                        <br />
                                        <p>Please do provide your response by selecting your choice below and submitting this form:</p>
                                    
                                </div>
                            </div>
                            <br />


                            <div class="row">
                                <div class="col">
                                        <asp:Label ID="lblPhotoConsent" runat="server" Font-Bold="true" Text="Photo Release Consent: "></asp:Label>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                        <asp:RadioButton  ID="rdoAllow" runat="server" Text="  I hereby allow the reproduction and publication of my child's photograph(s) "></asp:RadioButton>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                        <asp:RadioButton  ID="rdoDontAllow" runat="server" Text="  I do NOT allow the reproduction and publication of my child's photograph(s) "></asp:RadioButton>
                                </div>
                            </div>
                            <br />

                            <div class="row">
                                <div class="col">
                                    
                                        <asp:Label ID="lblStudentName" runat="server" Text="Name of Student: "></asp:Label>
                                        <asp:TextBox CssClass="form-control" ID="txtStudentName" runat="server" Width="500"></asp:TextBox>
                                    
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    
                                        <asp:Label ID="lblGuardianName" runat="server" Text="Your Name (Name of Guardian): "></asp:Label>
                                        <asp:TextBox CssClass="form-control" ID="txtGuardianName" runat="server" Width="500"></asp:TextBox>
                                    
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    
                                        <asp:Label ID="lblContactNumber" runat="server" Text="Contact Number:  "></asp:Label>
                                        <asp:TextBox CssClass="form-control" ID="txtContactNumber" runat="server" TextMode="Phone" Width="300"></asp:TextBox>
                                    
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    
                                        <asp:Label ID="lblESig" runat="server" Text="Signature (Print Full Name):  "></asp:Label>
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" Width="500"></asp:TextBox>
                                    
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    
                                        <asp:Label ID="lblDateSigned" runat="server" Text="Date Signed:  "></asp:Label>
                                        <asp:TextBox CssClass="form-control" ID="txtDateSigned" runat="server" TextMode="Date" Width="500"></asp:TextBox>
                                    
                                </div>
                            </div>
                            <br />
                            <br />

                            <div class="row">
                                <div class="col">
                                    <div class="form-group">
                                        <asp:Button ID="btnConfirm" CssClass="btn btn-success btn-block btn-lg" runat="server" OnClick="btnConfirm_Click" Text="Confirm" />
                                    </div>
                                    <div class="form-group">
                                        <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-block btn-lg" PostBackUrl="~/Home.aspx" runat="server" Text="Cancel" />
                                    </div>
                                </div>
                            </div>


                        </div>
                    </div>
                </div>
            </div>
     </div>

</asp:Content>
